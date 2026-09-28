---
title: आसान और हल्का परिनियोजन
type: docs
weight: 50
url: /hi/reportingservices/easy-and-lightweight-deployment/
description: "जानें कि Aspose.Slides for Reporting Services कैसे परिनियोजित किया जाता है: रिपोर्ट सर्वर की bin फ़ोल्डर में एक असेंबली, रिपोर्ट सर्वर कॉन्फ़िगरेशन में पंजीकृत।"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services Microsoft SQL Server Reporting Services और Power BI Report Server के लिए एक [रेंडरिंग एक्सटेंशन](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) है।  
Aspose.Slides for Reporting Services एक एकल MSI इंस्टॉलर के रूप में प्रदान किया गया है जो समर्थित रिपोर्ट सर्वर, 32‑bit या 64‑bit चलाने वाले कंप्यूटरों पर स्थापित किया जा सकता है; देखें [सिस्टम आवश्यकताएँ](/slides/hi/reportingservices/system-requirements/)।  

यह Aspose.Slides for Reporting Services को मैन्युअल रूप से तैनात और प्रबंधित करना भी आसान बनाता है, क्योंकि यह केवल एक .NET असेंबली *Aspose.Slides* *.ReportingServices.dll* से बना है, पूरी तरह से C# में लिखा गया, CLS अनुरूप है और केवल सुरक्षित प्रबंधित कोड रखता है।

{{% /alert %}}

ZIP डाउनलोड में रिपोर्ट सर्वरों के लिए Aspose.Slides.ReportingServices.dll की दो बिल्ड्स शामिल हैं:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 और .NET Framework 2.0 के लिए तैयार किया गया (x86 और x64 के लिए उपयोग करें)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 और बाद के संस्करण, Power BI Report Server और .NET Framework 2.0 के लिए तैयार किया गया (x86 और x64 के लिए उपयोग करें)

MSI इंस्टॉलर वही दो बिल्ड्स स्थापित करता है और प्रत्येक रिपोर्ट सर्वर इंस्टेंस के लिए सही वाले को चुनता है। [मैन्युअल रूप से स्थापित करें](/slides/hi/reportingservices/install-manually/) ZIP डाउनलोड में प्रत्येक फ़ाइल की सूची देता है।

स्थापना के दौरान, Aspose.Slides.ReportingServices.dll को ReportServer\bin निर्देशिका में कॉपी किया जाता है और कॉन्फ़िगरेशन फ़ाइल को अपडेट किया जाता है ताकि Reporting Services नई रेंडरिंग एक्सटेंशन के बारे में जागरूक हो सके। ये चरण Aspose.Slides for Reporting Services इंस्टॉलर द्वारा किए जाते हैं, लेकिन आप इन्हें इस दस्तावेज़ में आगे वर्णित अनुसार मैन्युअल रूप से भी कर सकते हैं।

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**चित्र**: Aspose.Slides.ReportingServices.dll को **ReportServer\bin** निर्देशिका में कॉपी किया जाता है।