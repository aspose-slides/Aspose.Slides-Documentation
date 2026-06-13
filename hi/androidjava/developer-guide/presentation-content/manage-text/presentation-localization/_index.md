---
title: Android पर प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/androidjava/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- भाषा आईडी
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ जावा में PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक कोड उदाहरणों और तेज़ वैश्विक रोलआउट के लिए सुझावों का उपयोग करके।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में टेक्स्ट के लिए `LanguageId` सेट करने की प्रक्रिया को समझाता है। यह प्रस्तुति खोलने, टेक्स्ट वाले आकार को जोड़ने, टेक्स्ट भाग को भाषा पहचानकर्ता सौंपने, और परिणाम को PPTX फ़ाइल के रूप में सहेजने का तरीका दर्शाता है।

## **प्रेजेंटेशन और आकार के टेक्स्ट की भाषा बदलें**
- [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड में [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) में [Rectangle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeType#Rectangle) प्रकार का एक आकार जोड़ें।
- TextFrame में कुछ टेक्स्ट जोड़ें।
- टेक्स्ट पर [Setting Language Id](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) लागू करें।
- प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

ऊपर बताए चरणों का कार्यान्वयन नीचे एक उदाहरण में दर्शाया गया है।

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

**क्या भाषा ID स्वचालित टेक्स्ट अनुवाद को ट्रिगर करती है?**

नहीं। Aspose.Slides में [Language ID](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) वर्तनी जाँच और व्याकरण प्रूफ़िंग के लिए भाषा को संग्रहीत करता है, लेकिन यह टेक्स्ट सामग्री का अनुवाद या परिवर्तन नहीं करता। यह मेटाडेटा है जिसे PowerPoint प्रूफ़िंग हेतु समझता है।

**क्या रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक्स पर भाषा ID का प्रभाव पड़ता है?**

Aspose.Slides में, [language ID](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) प्रूफ़िंग के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः उचित फ़ॉन्ट्स की उपलब्धता तथा लिखने की प्रणाली के लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए, आवश्यक फ़ॉन्ट्स उपलब्ध कराएँ, फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें, और/या फ़ॉन्ट्स को प्रस्तुति में एंबेड करें।

**क्या मैं एक पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हां। [Language ID](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) टेक्स्ट भाग स्तर पर लागू होती है, इसलिए एक पैराग्राफ में विभिन्न भाषाओं को अलग-अलग प्रूफ़िंग सेटिंग्स के साथ मिलाया जा सकता है।