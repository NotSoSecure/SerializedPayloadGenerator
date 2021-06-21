using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SerializedPayloadGenerator.Models
{
    public class PhpGGC
    {
        [DisplayName("Select Gadget:")]
        public Gadget gadget { set; get; }

        [DisplayName("Select Encoding Type:")]
        public Encoding encoding { get; set; }

        [DisplayName("Enter Function name to execute:")]
        public string functionName { set; get; }

        [DisplayName("Enter Function Parameter:")]
        public string functionParameter { set; get; }

        [DisplayName("Select Enhancement:")]
        public Gadget enhancement { set; get; }

        [DisplayName("Select PHAR:")]
        public Gadget phar { set; get; }
        
        [DisplayName("Select Output Type:")]
        public OutputType outputType { set; get; }
        
        [DisplayName("Deserialization Payload:")]
        public string payload { set; get; }

        [DisplayName("PHPGGC Command:")]
        public string phpggcCommand { set; get; }
    }

    public enum Gadget
    {
        CodeIgniter4_RCE1,
        CodeIgniter4_RCE2,
        Doctrine_FW1,
        Drupal7_FD1,
        Drupal7_RCE1,
        Guzzle_FW1,
        Guzzle_INFO1,
        Guzzle_RCE1,
        Laminas_FD1,
        Laravel_RCE1,
        Laravel_RCE2,
        Laravel_RCE3,
        Laravel_RCE4,
        Laravel_RCE5,
        Laravel_RCE6,
        Magento_FW1,
        Magento_SQLI1,
        Monolog_RCE1,
        Monolog_RCE2,
        Monolog_RCE3,
        Phalcon_RCE1,
        Pydio_Guzzle_RCE1,
        Slim_RCE1,
        SwiftMailer_FD1,
        SwiftMailer_FW1,
        SwiftMailer_FW2,
        SwiftMailer_FW3,
        SwiftMailer_FW4,
        Symfony_FW1,
        Symfony_FW2,
        Symfony_RCE1,
        Symfony_RCE2,
        Symfony_RCE3,
        Symfony_RCE4,
        ThinkPHP_RCE1,
        WordPress_Dompdf_RCE1,
        WordPress_Dompdf_RCE2,
        WordPress_Guzzle_RCE1,
        WordPress_Guzzle_RCE2,
        WordPress_P_EmailSubscribers_RCE1,
        WordPress_P_EverestForms_RCE1,
        WordPress_P_WooCommerce_RCE1,
        WordPress_P_YetAnotherStarsRating_RCE1,
        Yii_RCE1,
        ZendFramework_FD1,
        ZendFramework_RCE1,
        ZendFramework_RCE2,
        ZendFramework_RCE3
    }

    public enum Encoding
    {
        None,
        SoftURLEncode,
        URLEncode,
        Base64Output,
        JsonOutput
    }

    public enum Enhancement
    {
        None
    }

    public enum PHAR
    {
        None
    }
    public enum OutputType
    {
        Console,
        File
    }

}