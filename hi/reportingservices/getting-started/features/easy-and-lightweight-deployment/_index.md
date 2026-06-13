---
title: सरल और हल्का परिनियोजन
type: docs
weight: 50
url: /hi/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services Microsoft SQL Server Reporting Services के लिए एक [rendering extension](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) है। 
Aspose.Slides for Reporting Services को एक एकल MSI इंस्टॉलर के रूप में प्रदान किया गया है जो निम्नलिखित में से किसी एक चलाने वाले कंप्यूटरों पर स्थापित किया जा सकता है: 

- Microsoft SQL Server 2005 Reporting Services (32-bit और 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit और 64-bit)

यह Aspose.Slides for Reporting Services को मैन्युअल रूप से तैनात और प्रबंधित करना भी आसान बनाता है, क्योंकि यह केवल एक .NET assembly *Aspose.Slides* *.ReportingServices.dll* से बना है, जो पूरी तरह C# में लिखा गया है, CLS अनुपालन वाला है और केवल सुरक्षित मैनेज्ड कोड शामिल करता है। 

{{% /alert %}} 

MSI इंस्टॉलर और ZIP डाउनलोड में Aspose.Slides for ReportingServices शामिल हैं: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 और .NET Framework 2.0 के लिए निर्मित (x86 और x64 के लिए उपयोग करें)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 और .NET Framework 2.0 के लिए निर्मित (x86 और x64 के लिए उपयोग करें)

स्थापना के दौरान, Aspose.Slides.ReportingServices.dll को ReportServer\bin डायरेक्टरी में कॉपी किया जाता है और कॉन्फ़िगरेशन फ़ाइल को अपडेट किया जाता है ताकि Reporting Services नई rendering extension के बारे में जागरूक हो सके। ये कदम Aspose.Slides for Reporting Services इंस्टॉलर द्वारा किए जाते हैं, लेकिन आप इसे इस दस्तावेज़ में आगे वर्णित अनुसार मैन्युअल रूप से भी कर सकते हैं। 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll को **ReportServer\bin** डायरेक्टरी में कॉपी किया गया है।