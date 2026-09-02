---
title: Android पर PowerPoint प्रस्तुतियों को XML में परिवर्तित करें
linktitle: PowerPoint को XML में
type: docs
weight: 145
url: /hi/androidjava/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में परिवर्तित करें
- प्रस्तुति को XML में परिवर्तित करें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में परिवर्तित करें।"
---
## **सारांश**

Aspose.Slides for Android via Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में बदल सकता है। XML आउटपुट उपयोगी होता है जब आपको प्रस्तुति की संरचना का निरीक्षण करने, उत्पन्न दस्तावेज़ों की समस्या निवारण करने, स्वचालित परीक्षणों में आउटपुट की तुलना करने, या ऐसे वर्कफ़्लो के साथ एकीकृत करने की आवश्यकता हो जिसमें प्रस्तुति पैकेज के बजाय XML का उपयोग किया जाता है।

[Presentation.save] मेथड को [SaveFormat.Xml] के साथ उपयोग करें। आप परिणाम को सीधे फ़ाइल में या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को नहीं निकालता है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो सीधे PPTX पैकेज को देखें।
{{% /alert %}}

## **प्रस्तुति को XML फ़ाइल में बदलें**

[Presentation] क्लास का उपयोग करके स्रोत प्रस्तुति लोड करें, फिर आउटपुट पथ और [SaveFormat.Xml] को [Presentation.save] में पास करें। स्रोत कोई भी प्रस्तुति फ़ॉर्मेट हो सकता है जो लोड करने के लिए समर्थित है, जैसे PPT, PPTX, या ODP।

निम्न उदाहरण PPTX प्रस्तुति को XML फ़ाइल में बदलता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को मेमोरी में रखना हो या इसे किसी अन्य घटक, जैसे वेब सर्विस, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन को पास करना हो, तो [Presentation.save] के स्ट्रीम ओवरलोड का उपयोग करें। निम्न उदाहरण परिणाम को एक [ByteArrayOutputStream] में लिखता है और उत्पन्न XML को बाइट ऐरे के रूप में प्राप्त करता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // xmlData को कार्यप्रवाह में अगले घटक को पास करें।
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML की प्रस्तुति और निर्यात फ़ॉर्मेट्स से तुलना**

परिणाम के उपयोग के अनुसार आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML प्रस्तुति | संरचना की जाँच, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | पारंपरिक बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | एक Office Open XML पैकेज जिसमें कई भाग होते हैं | सामान्य PowerPoint संपादन और प्रस्तुति आदान‑प्रदान |
| PDF or TIFF | स्थिर लेआउट पृष्ठ या बहु‑पृष्ठ छवि | देखना, प्रिंट करना, और संग्रहीत करना |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और छवि संपत्तियाँ |
| HTML or HTML5 | वेब‑उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा‑उन्मुख वर्कफ़्लो के लिए अभिप्रेत है। PDF, TIFF, HTML और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह प्रस्तुति डेटा को दर्शाता है न कि स्लाइड को पृष्ठों या दृश्य संपत्तियों के रूप में रेंडर करता है। [supported file formats](/slides/hi/androidjava/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल‑सहेजने वाले फ़ॉर्मेट के रूप में सूचीबद्ध करती है, इसलिए जब किसी वर्कफ़्लो को निर्यातित फ़ाइल को फिर से Aspose.Slides में लोड करके आगे संपादन करना हो, तो इसका उपयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `SaveFormat.Xml` PPTX फ़ाइल को सहेजने के समान है?**  
नहीं। PPTX कई Office Open XML भागों वाला एक पैकेज है, जबकि `SaveFormat.Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**  
हां। लिखने योग्य स्ट्रीम को [Presentation.save] में पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए एक [ByteArrayOutputStream] उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**  
नहीं। PowerPoint XML Presentation वर्तमान में केवल सहेजने के लिए समर्थित है, लोड करने के लिए नहीं। जब राउंड‑ट्रिप संपादन आवश्यक हो, तो PPTX या कोई अन्य समर्थित प्रस्तुति फ़ॉर्मेट का उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**  
नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिए PDF या TIFF, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, और SVG का उपयोग करें।