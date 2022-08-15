using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SerializedPayloadGenerator.Models
{
    public class YSoSerialJava
    {
        [DisplayName("Select Gadget:")]
        public JavaGadget gadget { set; get; }
        [DisplayName("Enter Command to Execute:")]
        public string command { set; get; }
        [DisplayName("Select Payload Output Type:")]
        public JavaOutput output { set; get; }
        public string payload { set; get; }
        [DisplayName("YSoSerial Command-line Utility Command:")]
        public string ysoserialCommand { get; set; }
    }

    public enum JavaGadget
    {
        [Description("Blanched Almond Color")]
        AspectJWeaver,
        BeanShell1,
        C3P0,
        Click1,
        Clojure,
        CommonsBeanutils1,
        CommonsCollections1,
        CommonsCollections2,
        CommonsCollections3,
        CommonsCollections4,
        CommonsCollections5,
        CommonsCollections6,
        CommonsCollections7,
        FileUpload1,
        Groovy1,
        Hibernate1,
        Hibernate2,
        JBossInterceptors1,
        JRMPClient,
        JRMPListener,
        JSON1,
        JavassistWeld1,
        Jdk7u21,
        Jython1,
        MozillaRhino1,
        MozillaRhino2,
        Myfaces1,
        Myfaces2,
        ROME,
        Spring1,
        Spring2,
        URLDNS,
        Vaadin1,
        Wicket1
    }

    public enum JavaOutput
    {
        Base64,
        Raw
    }

    public enum ValidationAlgo
    {
        SHA1,
        HMACSHA256,
        HMACSHA384,
        HMACSHA512
    }

    public enum DecryptionAlgo
    {
        AES,
        DES,
        ThreeDES //Handle 3DES String
    }
}