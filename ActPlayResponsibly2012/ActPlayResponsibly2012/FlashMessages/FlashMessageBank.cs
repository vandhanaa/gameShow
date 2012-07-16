using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPlayResponsibly2012.FlashMessages
{
    public class FlashMessageBank
    {
        private static FlashMessageBank current;
        public static FlashMessageBank Current
        {
            get
            {
                if (current == null)
                {
                    current = new FlashMessageBank();
                }
                return current;
            }
            private set
            {
                current = value;
            }
        }

        private Random random;

        private FlashMessageBank() { random = new Random(); }

        private List<FlashMessage> msgList;
        public List<FlashMessage> MsgList
        {
            get
            {
                if (msgList == null)
                {
                    msgList = new List<FlashMessage>();
                }
                return msgList;
            }
            set
            {
                msgList = value;
            }
        }

        public FlashMessage GetFlashMessage(FlashMessageType type)
        {
            MsgList = MsgList.OrderBy(p => random.NextDouble()).ToList();
            return MsgList.Find(delegate(FlashMessage e) { return e.Type == type; });
        }

        public FlashMessage GetFlashMessage(FlashMessageType type, int id)
        {
            MsgList = MsgList.OrderBy(p => random.NextDouble()).ToList();
            return MsgList.Find(delegate(FlashMessage e) { return e.Type == type && e.Id == id; });
        }

        public void SetFlashMessageBank(List<FlashMessage> MsgList)
        {
            this.MsgList = MsgList;           
        }
    }
}
