using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DeserializationHelper.Models
{
    public class Python
    {
        [DisplayName("Select Deseraliztion Type:")]
        public PyDeserType type { set; get; }
        
        [DisplayName("Enter Command to Execute:")]
        public string command { set; get; }

        [DisplayName("Otuput Type:")]
        public PythonOutput output { set; get; }

        [DisplayName("Payload:")]
        public string payload { set; get; }
    }

    public enum PythonOutput
    {
        Base64,
        Dictionary
    }
    public enum PyDeserType
    {
        Pickle,
        PyYML
    }
}