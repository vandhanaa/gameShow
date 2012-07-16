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

        private FlashMessageBank() { }

        public FlashMessage GetFlashMessage(FlashMessageType type)
        {
            // TODO: hardcode
            return new FlashMessage() { Type = type, Content = "Test type = " + type };
        }

        public FlashMessage GetFlashMessage(FlashMessageType type, int id)
        {
            // TODO: hardcode
            return new FlashMessage() { Type = type, Content = "Test type = " + type + " id " + id };
        }
    }
}
