---
title: ट्रस्ट लेवल आवश्यकताएँ
type: docs
weight: 190
url: /hi/net/declaration/
keywords:
- ट्रस्ट लेवल
- पूर्ण भरोसा अनुमति
- आंशिक भरोसा
- मध्यम भरोसा
- कोड एक्सेस सुरक्षा
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET को किस कोड एक्सेस सुरक्षा ट्रस्ट लेवल की आवश्यकता है: .NET Framework पर पूर्ण भरोसा, और .NET 6 और उसके बाद के संस्करणों में कोई भरोसा सेटिंग नहीं।"
---
## **अवलोकन**

कोड एक्सेस सुरक्षा (CAS) ट्रस्ट स्तर केवल .NET Framework में मौजूद हैं। यह आलेख समझाता है कि उनका क्या अर्थ है Aspose.Slides for .NET के लिए: लाइब्रेरी को .NET Framework पर पूर्ण भरोसा (फुल ट्रस्ट) की आवश्यकता होती है, और .NET 6 और उसके बाद के संस्करणों में कॉन्फ़िगर करने के लिए कोई ट्रस्ट स्तर नहीं है।

## **.NET Framework**

Aspose.Slides को .NET Framework पर पूर्ण भरोसा (फुल ट्रस्ट) चाहिए। यह आंशिक भरोसे (पार्शियल ट्रस्ट) के तहत नहीं चलता, जैसे कि मध्यम भरोसा (Medium Trust) के लिए कॉन्फ़िगर किया गया ASP.NET एप्लिकेशन (`<trust level="Medium" />`): एक [प्रेज़ेंटेशन](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ऑब्जेक्ट बनाना `SecurityException` के साथ विफल हो जाता है।

Microsoft अब ASP.NET आंशिक भरोसे को अनुप्रयोगों को एक‑दूसरे से अलग करने का तरीका नहीं मानता, और इसके बजाय अलग‑अलग एप्लिकेशन पूल में एप्लिकेशन चलाने की सलाह देता है। देखें [ASP.NET आंशिक भरोसा अनुप्रयोग पृथक्करण की गारंटी नहीं देता](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation)।

## **.NET 6 और आगे**

कोड एक्सेस सुरक्षा .NET 6 और बाद के संस्करणों में उपलब्ध नहीं है, इसलिए प्रदान करने के लिए कोई ट्रस्ट स्तर नहीं है। Aspose.Slides आपके एप्लिकेशन को चलाने वाले खाते की अनुमतियों के साथ चलता है। यह निर्धारित करने के लिए कि एक एप्लिकेशन क्या एक्सेस कर सकता है, Microsoft ऑपरेटिंग‑सिस्टम सीमाओं, जैसे उपयोगकर्ता खाते, कंटेनर, या वर्चुअल मशीनों की सलाह देता है। देखें [कोड एक्सेस सुरक्षा (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Aspose.Slides को ऐसे होस्टिंग प्रोवाइडर के साथ उपयोग कर सकता हूँ जो ASP.NET एप्लिकेशन को मध्यम भरोसे (Medium Trust) में चलाता है?**

मध्यम भरोसे में नहीं। .NET Framework पर, Aspose.Slides का उपयोग करने वाला एप्लिकेशन पूर्ण भरोसे के साथ चलना चाहिए।