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
        CakePHP_RCE1,
        CakePHP_RCE2,
        CodeIgniter4_RCE1,
        CodeIgniter4_RCE2,
        CodeIgniter4_RCE3,
        Doctrine_FW1,
        Doctrine_FW2,
        Dompdf_FD1,
        Dompdf_FD2,
        Drupal7_FD1,
        Drupal7_RCE1,
        Guzzle_FW1,
        Guzzle_INFO1,
        Guzzle_RCE1,
        Horde_RCE1,
        Kohana_FR1,
        Laminas_FD1,
        Laminas_FW1,
        Laravel_RCE1,
        Laravel_RCE10,
        Laravel_RCE2,
        Laravel_RCE3,
        Laravel_RCE4,
        Laravel_RCE5,
        Laravel_RCE6,
        Laravel_RCE7,
        Laravel_RCE8,
        Laravel_RCE9,
        Magento_FW1,
        Magento_SQLI1,
        Magento2_FD1,
        Monolog_FW1,
        Monolog_RCE1,
        Monolog_RCE2,
        Monolog_RCE3,
        Monolog_RCE4,
        Monolog_RCE5,
        Monolog_RCE6,
        Monolog_RCE7,
        Monolog_RCE8,
        Monolog_RCE9,
        Phalcon_RCE1,
        PHPCSFixer_FD1,
        PHPCSFixer_FD2,
        PHPExcel_FD1,
        PHPExcel_FD2,
        PHPExcel_FD3,
        PHPExcel_FD4,
        PHPSecLib_RCE1,
        Pydio_Guzzle_RCE1,
        Slim_RCE1,
        Smarty_FD1,
        Smarty_SSRF1,
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
        Symfony_RCE5,
        TCPDF_FD1,
        ThinkPHP_FW1,
        ThinkPHP_FW2,
        ThinkPHP_RCE1,
        ThinkPHP_RCE2,
        Typo3_FD1,
        WordPress_Dompdf_RCE1,
        WordPress_Dompdf_RCE2,
        WordPress_Guzzle_RCE1,
        WordPress_Guzzle_RCE2,
        WordPress_P_EmailSubscribers_RCE1,
        WordPress_P_EverestForms_RCE1,
        WordPress_P_WooCommerce_RCE1,
        WordPress_P_WooCommerce_RCE2,
        WordPress_P_YetAnotherStarsRating_RCE1,
        WordPress_PHPExcel_RCE1,
        WordPress_PHPExcel_RCE2,
        WordPress_PHPExcel_RCE3,
        WordPress_PHPExcel_RCE4,
        WordPress_PHPExcel_RCE5,
        WordPress_PHPExcel_RCE6,
        Yii_RCE1,
        Yii2_RCE1,
        Yii2_RCE2,
        ZendFramework_FD1,
        ZendFramework_RCE1,
        ZendFramework_RCE2,
        ZendFramework_RCE3,
        ZendFramework_RCE4
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