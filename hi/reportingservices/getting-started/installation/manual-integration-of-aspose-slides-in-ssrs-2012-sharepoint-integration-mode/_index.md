---
title: SSRS 2012 SharePoint इंटीग्रेशन मोड में Aspose.Slides का मैन्युअल एकीकरण
type: docs
weight: 100
url: /hi/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 
यह लेख आपको बताता है कि कैसे Aspose.Slides को Reporting Services के साथ मैन्युअल रूप से SSRS 2012 SharePoint इंटीग्रेशन अवधारणा में एकीकृत किया जाए। 
{{% /alert %}} 
## **SharePoint इंटीग्रेशन मोड में SSRS 2012 के साथ Aspose.Slides का एकीकरण**
यहां मैनुअल इंस्टॉलेशन MSI इंस्टॉलर के स्थान पर DLL का उपयोग करता है। 

हम अनुशंसा करते हैं कि आप उत्पाद को MSI इंस्टॉलर का उपयोग करके स्थापित करें क्योंकि यह सभी आवश्यक इंस्टॉलेशन प्रक्रियाएँ और कॉन्फ़िगरेशन कार्य स्वतः करता है। हालांकि, यदि MSI इंस्टॉलर के साथ स्वचालित इंस्टॉलेशन विफल हो जाता है, तो आपको नीचे दिए गए चरणों का पालन करना चाहिए:

1. **Aspose.Slides.ReportingServices.dll** को **Universal** निर्देशिका से **SharePonit RS** बिन निर्देशिका में कॉपी करें। हमारे उदाहरण में, यह *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* है। 
1. Sharepoint की **rssrvpolicy.config** फ़ाइल को (जो *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* निर्देशिका में है) उसी तरीके से अपडेट करें जैसा कि [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/hi/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) लेख में बताया गया है। 
1. इस स्क्रिप्ट को PowerShell में चलाएँ, लेकिन rs_test को अपने Reporting Services एप्लिकेशन के नाम से बदलें। 

**rs_test**

``` xml



Write-Host "Adding Aspose.Slides rendering extensions"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Get ReportinService Application Service"

$app = get-sprsserviceapplication



if ($app) {

                $app | ForEach-Object {



                $aspps = Get-SPRSExtension -Identity $_ -Name "ASPPS" -ExtensionType "Render"

                $aspptx = Get-SPRSExtension -Identity $_ -Name "ASPPTX" -ExtensionType "Render"

                $asppsx = Get-SPRSExtension -Identity $_ -Name "ASPPSX" -ExtensionType "Render"

                $asppt = Get-SPRSExtension -Identity $_ -Name "ASPPT" -ExtensionType "Render"



                if (-not $aspps ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPS" -TypeName "Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices" }

                if (-not $aspptx) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPTX" -TypeName "Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppsx ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPSX" -TypeName "Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppt ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPT" -TypeName "Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"}

                }

}



```

SharePoint के लिए Reporting Service cmdlets के बारे में अधिक जानकारी के लिए, [this Microsoft article](http://technet.microsoft.com/en-us/library/gg492249?ppud=4) पढ़ें।