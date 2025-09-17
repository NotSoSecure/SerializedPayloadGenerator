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
        Bitrix_RCE1,
        CakePHP_RCE1,
        CakePHP_RCE2,
        CodeIgniter4_FD1,
        CodeIgniter4_FD2,
        CodeIgniter4_FR1,
        CodeIgniter4_RCE1,
        CodeIgniter4_RCE2,
        CodeIgniter4_RCE3,
        CodeIgniter4_RCE4,
        CodeIgniter4_RCE5,
        CodeIgniter4_RCE6,
        Doctrine_FW1,
        Doctrine_FW2,
        Doctrine_RCE1,
        Doctrine_RCE2,
        Dompdf_FD1,
        Dompdf_FD2,
        Drupal_AT1,
        Drupal_FD1,
        Drupal_PsySH_INFO1,
        Drupal_SQLI1,
        Drupal_SSRF1,
        Drupal_XXE1,
        Drupal7_FD1,
        Drupal7_RCE1,
        Drupal7_SQLI1,
        Drupal7_SSRF1,
        Drupal9_RCE1,
        Grav_FD1,
        Guzzle_FW1,
        Guzzle_INFO1,
        Guzzle_RCE1,
        Horde_RCE1,
        Joomla_FW1,
        Kohana_FR1,
        Laminas_FD1,
        Laminas_FW1,
        Laravel_FD1,
        Laravel_RCE1,
        Laravel_RCE2,
        Laravel_RCE3,
        Laravel_RCE4,
        Laravel_RCE5,
        Laravel_RCE6,
        Laravel_RCE7,
        Laravel_RCE8,
        Laravel_RCE9,
        Laravel_RCE10,
        Laravel_RCE11,
        Laravel_RCE12,
        Laravel_RCE13,
        Laravel_RCE14,
        Laravel_RCE15,
        Laravel_RCE16,
        Laravel_RCE17,
        Laravel_RCE18,
        Laravel_RCE19,
        Laravel_RCE20,
        Laravel_RCE21,
        Laravel_RCE22,
        Magento_FW1,
        Magento_SQLI1,
        Magento2_FD1,
        Magento2_FD2,
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
        OpenCart_FW1,
        OpenCart_FW2,
        OpenCart_FW3,
        OpenCart_RCE1,
        OpenCart_RCE2,
        Phalcon_RCE1,
        Phing_FD1,
        PHPCSFixer_FD1,
        PHPCSFixer_FD2,
        PHPExcel_FD1,
        PHPExcel_FD2,
        PHPExcel_FD3,
        PHPExcel_FD4,
        PHPSecLib_RCE1,
        phpThumb_FD1,
        PHPWord_FD1,
        Plates_RCE1,
        Pydio_Guzzle_RCE1,
        Silverstripe_FD1,
        Slim_RCE1,
        Smarty_FD1,
        Smarty_SSRF1,
        Snappy_FD1,
        Spiral_RCE1,
        Spiral_RCE2,
        SwiftMailer_FD1,
        SwiftMailer_FD2,
        SwiftMailer_FR1,
        SwiftMailer_FW1,
        SwiftMailer_FW2,
        SwiftMailer_FW3,
        SwiftMailer_FW4,
        Symfony_FD1,
        Symfony_FW1,
        Symfony_FW2,
        Symfony_RCE1,
        Symfony_RCE2,
        Symfony_RCE3,
        Symfony_RCE4,
        Symfony_RCE5,
        Symfony_RCE6,
        Symfony_RCE7,
        Symfony_RCE8,
        Symfony_RCE9,
        Symfony_RCE10,
        Symfony_RCE11,
        Symfony_RCE12,
        Symfony_RCE13,
        Symfony_RCE14,
        Symfony_RCE15,
        Symfony_RCE16,
        TCPDF_FD1,
        ThinkPHP_FW1,
        ThinkPHP_FW2,
        ThinkPHP_RCE1,
        ThinkPHP_RCE2,
        ThinkPHP_RCE3,
        ThinkPHP_RCE4,
        Typo3_FD1,
        vBulletin_RCE1,
        WordPress_Dompdf_RCE1,
        WordPress_Dompdf_RCE2,
        WordPress_Guzzle_RCE1,
        WordPress_Guzzle_RCE2,
        WordPress_P_EmailSubscribers_RCE1,
        WordPress_P_EverestForms_RCE1,
        WordPress_P_WooCommerce_RCE1,
        WordPress_P_WooCommerce_RCE2,
        WordPress_P_YetAnotherStarsRating_RCE1,
        WordPress_P_YoastSEO_FW1,
        WordPress_PHPExcel_RCE1,
        WordPress_PHPExcel_RCE2,
        WordPress_PHPExcel_RCE3,
        WordPress_PHPExcel_RCE4,
        WordPress_PHPExcel_RCE5,
        WordPress_PHPExcel_RCE6,
        WordPress_RCE1,
        WordPress_RCE2,
        Yii_RCE1,
        Yii_RCE2,
        Yii2_RCE1,
        Yii2_RCE2,
        ZendFramework_FD1,
        ZendFramework_RCE1,
        ZendFramework_RCE2,
        ZendFramework_RCE3,
        ZendFramework_RCE4,
        ZendFramework_RCE5
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