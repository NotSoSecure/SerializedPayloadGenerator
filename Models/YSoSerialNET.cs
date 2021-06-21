using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SerializedPayloadGenerator.Models
{
    public class YSoSerialNET
    {
        [DisplayName("Select Plugin:")]
        public Plugin plugin { get; set;}
        [DisplayName("Select Gadget:")]
        public NetGadget gadget { get; set; }
        [DisplayName("Select Formatter:")]
        public Formatter formatter { get; set; }
        [DisplayName("Select Payload Output Type:")]
        public NetOutput output { get; set; }
        [DisplayName("Enter Command to Execute:")]
        public string command { set; get; }
        [DisplayName("Minify")]
        public BoolType minify { get; set; }
        [DisplayName("Use Simple Type:")]
        public BoolType useSimpleType { get; set; }
        [DisplayName("VIEWSTATEGENERATOR Paramter:")]
        public string generator { set; get; }
        [DisplayName("Path:")]
        public string path { set; get; }
        [DisplayName("App Path:")]
        public string appPath { set; get; }
        [DisplayName("Legacy:")]
        public BoolType legacy { get; set; }
        [DisplayName("Encrypted:")]
        public BoolType ecnrypted { get; set; }
        [DisplayName("ViewState User Key:")]
        public string viewStateUserKey { set; get; }
        [DisplayName("Validation Algorithm:")]
        public ValidationAlgo validationAlgo { get; set; }
        [DisplayName("Validation Key:")]
        public string validationKey { set; get; }
        [DisplayName("Decryption Algorithm:")]
        public DecryptionAlgo decryptionAlgo { get; set; }
        [DisplayName("Decryption Key:")]
        public string decryptionKey { get; set; }
        [DisplayName("Mode:")]
        public string mode { set; get; }
        [DisplayName("File:")]
        public string file { set; get; }
        [DisplayName("Format:")]
        public string format { set; get; }
        [DisplayName("Payload:")]
        public string payload { set; get; }
        [DisplayName("YSoSerial.NET Command-line Utility Command:")]
        public string ysoserialNetCommand { get; set; }
    }

    public enum Plugin
    {
        Generic,
        ActivatorUrl,
        Altserialization,
        ApplicationTrust,
        Clipboard,
        DotNetNuke,
        Resx,
        SessionSecurityTokenHandler,
        SharePoint,
        TransactionManagerReenlist,
        ViewState
    }

    public enum NetGadget
    {
        ActivitySurrogateSelector,
        ActivitySurrogateDisableTypeCheck,
        ActivitySurrogateSelectorFromFile,
        AxHostState,
        ClaimsIdentity,
        DataSet,
        ObjectDataProvider,
        PSObject,
        RolePrincipal,
        ResourceSet,
        SessionSecurityToken,
        SessionViewStateHistoryItem,
        TextFormattingRunProperties,
        TypeConfuseDelegate,
        TypeConfuseDelegateMono,
        WindowsClaimsIdentity,
        WindowsIdentity,
        WindowsPrincipal
    }

    public enum Formatter
    {
        BinaryFormatter,
        DataContractSerializer,
        LosFormatter,
        SoapFormatter,
        NetDataContractSerializer,
        JsonNet,//Needs to handle Json.Net
        DataContractJsonSerializer,
        FastJson,
        FsPickler,
        JavaScriptSerializer,
        SharpSerializerBinary,
        SharpSerializerXml,
        Xaml,
        XmlSerializer,
        YamlDotNet
    }

    public enum NetOutput
    {
        Base64,
        Raw
    }

    public enum BoolType
    {
        True,
        False
    }
}