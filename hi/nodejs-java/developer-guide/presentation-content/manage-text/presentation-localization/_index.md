---
title: जावास्क्रिप्ट में प्रस्तुति स्थानीयकरण का स्वचालन
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/nodejs-java/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जाँच
- भाषा पहचानकर्ता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ जावास्क्रिप्ट में PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक कोड नमूने और तेज़ वैश्विक रोलआउट के टिप्स का उपयोग करके।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके एक प्रस्तुति में टेक्स्ट के लिए `LanguageId` सेट करने की विधि समझाता है। यह प्रदर्शित करता है कि प्रस्तुति को कैसे खोलें, टेक्स्ट वाले एक Shape जोड़ें, टेक्स्ट भाग को भाषा पहचानकर्ता असाइन करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **Change Language for Presentation and Shape's Text**

- `Presentation` क्लास की एक instance बनाएँ।
- उसके Index का उपयोग करके एक स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड में `Rectangle` प्रकार का एक `AutoShape` जोड़ें।
- `TextFrame` में कुछ टेक्स्ट जोड़ें।
- टेक्स्ट को `[Setting Language Id](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)` सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपर्युक्त चरणों का कार्यान्वयन नीचे एक उदाहरण में दिखाया गया है।

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या language ID स्वतः टेक्स्ट अनुवाद को ट्रिगर करता है?**

नहीं। Aspose.Slides में `setLanguageId` वर्तनी‑जाँच और व्याकरण‑प्रूफ़िंग के लिए भाषा को संग्रहीत करता है, लेकिन यह टेक्स्ट की सामग्री को अनुवादित या बदलता नहीं है। यह मेटा‑डेटा है जिसे PowerPoint प्रूफ़िंग के लिये समझता है।

**क्या language ID रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक को प्रभावित करता है?**

Aspose.Slides में `setLanguageId` प्रूफ़िंग के लिये है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः उपलब्ध `[proper fonts](/slides/hi/nodejs-java/powerpoint-fonts/)` और लेखन प्रणाली की लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग के लिये आवश्यक फ़ॉन्ट उपलब्ध कराएँ, `[font substitution rules](/slides/hi/nodejs-java/font-substitution/)` कॉन्फ़िगर करें, और/या प्रस्तुति में फ़ॉन्ट को `[embed fonts](/slides/hi/nodejs-java/embedded-font/)` करें।

**क्या मैं एक ही पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हां। `setLanguageId` टेक्स्ट भाग स्तर पर लागू होता है, इसलिए एक पैराग्राफ कई भाषाओं को अलग‑अलग प्रूफ़िंग सेटिंग्स के साथ मिश्रित कर सकता है।