---
title: Java में प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/java/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- भाषा आईडी
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides के साथ PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक कोड नमूने और तेज़ वैश्विक रोलआउट के लिए टिप्स का उपयोग करके।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में टेक्स्ट के लिए `LanguageId` सेट करने की विधि समझाता है। यह दिखाता है कि प्रस्तुति को कैसे खोला जाए, टेक्स्ट के साथ एक शेप जोड़ें, टेक्स्ट भाग को भाषा पहचानकर्ता असाइन करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **प्रेजेंटेशन और शेप टेक्स्ट के लिए भाषा बदलें**
- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड में [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) का [Rectangle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeType#Rectangle) प्रकार जोड़ें।
- TextFrame में कुछ टेक्स्ट जोड़ें।
- टेक्स्ट पर [Setting Language Id](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपरोक्त चरणों का कार्यान्वयन नीचे एक उदाहरण में दिखाया गया है।

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा आईडी स्वचालित टेक्स्ट अनुवाद को ट्रिगर करती है?**

नहीं। Aspose.Slides में [Language ID](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) वर्तनी-जाँच और व्याकरण प्रूफ़िंग के लिए भाषा रखती है, लेकिन यह टेक्स्ट सामग्री का अनुवाद या परिवर्तन नहीं करती। यह मेटाडेटा है जिसे PowerPoint प्रूफ़िंग के लिए समझता है।

**क्या भाषा आईडी रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक को प्रभावित करती है?**

Aspose.Slides में, [language ID](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) प्रूफ़िंग के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः उपलब्ध [proper fonts](/slides/hi/java/powerpoint-fonts/) और लिखने की प्रणाली के लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ, [font substitution rules](/slides/hi/java/font-substitution/) कॉन्फ़िगर करें, और/या प्रस्तुति में फ़ॉन्ट एम्बेड करें।

**क्या मैं एक ही पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हां। [Language ID](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) टेक्स्ट भाग स्तर पर लागू होती है, इसलिए एक ही पैराग्राफ कई भाषाओं के साथ विभिन्न प्रूफ़िंग सेटिंग्स को मिश्रित कर सकता है।