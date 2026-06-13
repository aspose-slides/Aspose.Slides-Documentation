---
title: ".NET में प्रस्तुति स्थानीयकरण को स्वचालित करें"
linktitle: "प्रस्तुति स्थानीयकरण"
type: docs
weight: 100
url: /hi/net/presentation-localization/
keywords:
- "भाषा बदलें"
- "वर्तनी जाँच"
- "भाषा आईडी"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET में Aspose.Slides के साथ PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक C# कोड नमूने और तेज़ वैश्विक रोलआउट के टिप्स का उपयोग करके।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में पाठ के लिए `LanguageId` सेट करने की प्रक्रिया समझाता है। यह दिखाता है कि प्रस्तुति कैसे खोलें, पाठ के साथ एक आकार जोड़ें, पाठ भाग में भाषा पहचानकर्ता असाइन करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **प्रस्तुति और आकार पाठ के लिए भाषा बदलें**
- [Presentation] क्लास का एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड में Rectangle प्रकार का AutoShape जोड़ें।
- TextFrame में कुछ टेक्स्ट जोड़ें।
- टेक्स्ट के लिए Language Id सेट करना।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपरोक्त चरणों का कार्यान्वयन नीचे एक उदाहरण में दिखाया गया है।

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID स्वचालित टेक्स्ट अनुवाद को ट्रिगर करती है?**

नहीं। Aspose.Slides में [LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/) भाषा को स्पेल‑चेकिंग और व्याकरण प्रमाणन के लिए संग्रहीत करता है, लेकिन यह टेक्स्ट सामग्री का अनुवाद या परिवर्तन नहीं करता। यह मेटा‑डेटा है जिसे PowerPoint प्रमाणन के लिए समझता है।

**क्या भाषा ID रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक को प्रभावित करती है?**

Aspose.Slides में, [LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/) प्रमाणन के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः [उचित फॉन्ट](/slides/hi/net/powerpoint-fonts/) की उपलब्धता और लेखन प्रणाली के लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए, आवश्यक फ़ॉन्ट उपलब्ध कराएं, [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/net/font-substitution/) कॉन्फ़िगर करें, और/या प्रस्तुति में [फ़ॉन्ट एम्बेड](/slides/hi/net/embedded-font/) करें।

**क्या मैं एक ही पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हाँ। [LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/) टेक्स्ट भाग स्तर पर लागू होता है, इसलिए एक पैराग्राफ में विभिन्न भाषाओं को अलग‑अलग प्रमाणन सेटिंग्स के साथ मिलाया जा सकता है।