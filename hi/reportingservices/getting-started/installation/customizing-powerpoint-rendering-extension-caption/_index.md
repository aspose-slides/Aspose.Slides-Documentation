---
title: PowerPoint रेंडरिंग एक्सटेंशन कैप्शन को अनुकूलित करना
type: docs
weight: 60
url: /hi/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

यह लेख आपको दिखाता है कैसे Aspose.Slides for Reporting Services की रेंडरिंग विकल्प कैप्शन को कस्टमाइज़ किया जाता है। 

{{% /alert %}} 
## **उदाहरण**
Aspose.Slides for Reporting Services को स्थापित करते समय, निर्यात विकल्पों के ड्रॉप‑डाउन मेनू में 4 अतिरिक्त निर्यात विकल्प जोड़े जाते हैं:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **कैप्शन टेक्स्ट कैसे संशोधित करें**
इन एक्सटेंशन के डिफ़ॉल्ट कैप्शन को डिफ़ॉल्ट नामों को ओवरराइड करके बदला जा सकता है। ये चरण आपको दिखाते हैं कि कैप्शन को “**PPT – PowerPoint** **Presentation via** **Aspose.Slides**” से “**PowerPoint 97 – 2003 format(PPT)**” में कैसे बदलें। 

**चरण 1:** Locate the **rsreportserver.config** file that is usually in this directory: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**चरण** **2:** Find these lines in rsreportserver.config file: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**चरण** **3:** Replace the extension parameter with this: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

अब निर्यात विकल्प इस प्रकार दिखेंगे: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)