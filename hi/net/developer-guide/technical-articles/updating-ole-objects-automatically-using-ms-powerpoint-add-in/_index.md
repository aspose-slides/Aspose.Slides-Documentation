---
title: PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना
type: docs
weight: 10
url: /hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE ऑब्जेक्ट
- OLE अपडेट
- स्वचालित रूप से
- ऐड‑इन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint में ऐड‑इन और Aspose.Slides for .NET के साथ OLE चार्ट और ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करने का तरीका जानें, जिसमें व्यावहारिक कोड और अनुकूलन सुझाव शामिल हैं।"
---
## **परिचय**

Aspose.Slides for .NET ग्राहकों द्वारा पूछे जाने वाले सबसे सामान्य प्रश्नों में से एक है कि कैसे संपादन योग्य चार्ट (या अन्य OLE ऑब्जेक्ट) बनाएँ या संशोधित करें ताकि प्रस्तुति खुलते ही वे स्वतः अपडेट हो जाएँ। दुर्भाग्यवश, PowerPoint Excel और Word की तरह स्वचालित मैक्रो को सपोर्ट नहीं करता। उपलब्ध केवल `Auto_Open` और `Auto_Close` मैक्रो हैं, और ये केवल एक ऐड‑इन से स्वतः चलते हैं। यह छोटा तकनीकी टिप दिखाता है कि इसे कैसे प्राप्त किया जाए।

## **OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करें**

सबसे पहले, कई मुफ्त ऐड‑इन उपलब्ध हैं जो PowerPoint में Auto_Open मैक्रो फीचर जोड़ते हैं, उदाहरण के लिए [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) और [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)।

इनमें से किसी भी ऐड‑इन को स्थापित करने के बाद, बस अपने टेम्प्लेट प्रेज़ेंटेशन में नीचे दिखाए अनुसार `Auto_Open()` मैक्रो (या यदि आप Event Generator का उपयोग कर रहे हैं तो `OnPresentationOpen()`) जोड़ें:

```cs
public void Auto_Open()
{
    // प्रस्तुति में प्रत्येक स्लाइड के माध्यम से लूप करें।
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // वर्तमान स्लाइड पर सभी शैप्स के माध्यम से लूप करें।
        foreach (var oShape in oSlide.Shapes)
        {
            // जांचें कि शैप OLE ऑब्जेक्ट है या नहीं।
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // एक OLE ऑब्जेक्ट मिला। उसका ऑब्जेक्ट रेफ़रेंस प्राप्त करें और फिर अपडेट करें।
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // अब, OLE सर्वर प्रोग्राम को बंद करें।
                // यह मेमोरी मुक्त करता है, और किसी भी समस्या को रोकता है।
                // इसके अलावा, oObject को Nothing सेट करें ताकि ऑब्जेक्ट रिहा हो जाए।
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Aspose.Slides for .NET के साथ किए गए OLE ऑब्जेक्ट्स में कोई भी परिवर्तन PowerPoint द्वारा प्रस्तुति खोलने पर स्वतः अपडेट हो जाएगा। यदि आपके पास कई OLE ऑब्जेक्ट्स हैं और आप सभी को अपडेट नहीं करना चाहते, तो केवल उन शैप्स में एक कस्टम टैग जोड़ें जिन्हें आप प्रोसेस करना चाहते हैं और मैक्रो में उसकी जाँच करें।