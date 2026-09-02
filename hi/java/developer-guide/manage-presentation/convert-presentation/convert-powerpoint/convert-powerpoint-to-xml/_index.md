---
title: जावा में PowerPoint प्रस्तुतियों को XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रेजेंटेशन को XML में बदलें
- PPT को XML में बदलें
- PPTX को XML में बदलें
- ODP को XML में बदलें
- PowerPoint XML प्रस्तुतीकरण
- SaveFormat.Xml
- प्रेजेंटेशन को XML के रूप में सहेजें
- प्रेजेंटेशन को XML में निर्यात करें
- XML स्ट्रीम
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके जावा में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में बदलें।"
---
## **सारांश**

Aspose.Slides for Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation स्वरूप में बदल सकता है। XML आउटपुट उपयोगी है जब आपको प्रस्तुति की संरचना की जांच, उत्पन्न दस्तावेजों की समस्या निवारण, स्वचालित परीक्षणों में आउटपुट की तुलना, या ऐसे वर्कफ़्लो के साथ एकीकरण की आवश्यकता हो जो प्रस्तुति पैकेज के बजाय XML का उपभोग करता है।

[Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) क्लास से `Xml` मान के साथ उपयोग करें। आप परिणाम को सीधे फ़ाइल में या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के अंदर संग्रहीत व्यक्तिगत Office Open XML भागों को नहीं निकालता है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो स्वयं PPTX पैकेज की जांच करें।
{{% /alert %}}

## **एक प्रस्तुतीकरण को XML फ़ाइल में बदलें**

स्रोत प्रस्तुतीकरण को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास से लोड करें, और फिर आउटपुट पथ और `SaveFormat.Xml` को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) में पास करें। स्रोत किसी भी लोडिंग के लिए समर्थित प्रस्तुतीकरण स्वरूप जैसे PPT, PPTX, या ODP हो सकता है।

निम्नलिखित उदाहरण PPTX प्रस्तुतीकरण को XML फ़ाइल में बदलता है:

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

[Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) की स्ट्रीम ओवरलोड का उपयोग करें जब XML को मेमोरी में बनाए रखना हो या किसी अन्य घटक को भेजना हो, जैसे वेब सेवा, स्टोरेज प्रदाता, या XML प्रसंस्करण पाइपलाइन। निम्नलिखित उदाहरण परिणाम को [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) में लिखता है और परिणामी XML को बाइट एरे के रूप में प्राप्त करता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // वर्कफ़्लो में अगली घटक को xmlData पास करें।
} finally {
    presentation.dispose();
}
```

## **XML की तुलना प्रस्तुतीकरण और निर्यात स्वरूपों से करें**

परिणाम के उपयोग के अनुसार आउटपुट स्वरूप चुनें:

| स्वरूप | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML प्रस्तुतीकरण | संरचना की जांच, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | एक लिगेसी बाइनरी प्रस्तुतीकरण फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | नियमित PowerPoint संपादन और प्रस्तुतीकरण आदान-प्रदान |
| PDF या TIFF | फिक्स्ड-लेआउट पृष्ठ या बहु-पृष्ठ छवि | दृश्य, प्रिंटिंग, और अभिलेखन |
| PNG, JPEG, या SVG | व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और चित्र एसेट |
| HTML या HTML5 | वेब-उन्मुख प्रस्तुतीकरण आउटपुट | ब्राउज़र में दिखाना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा-उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML, और स्लाइड इमेज स्वरूपों के विपरीत, यह प्रस्तुतीकरण डेटा को दर्शाता है न कि स्लाइडों को पृष्ठों या दृश्य एसेट के रूप में रेंडर करता है। [supported file formats](/slides/hi/java/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल-सेव स्वरूप के रूप में सूचीबद्ध करती है, इसलिए जब कोई कार्यप्रवाह निर्यातित फ़ाइल को पुनः Aspose.Slides में लोड करके आगे संपादन करना हो, तब इसका प्रयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`SaveFormat.Xml` PPTX फ़ाइल को सहेजने के समान है?**

नहीं। PPTX एक पैकेज है जिसमें कई Office Open XML भाग होते हैं, जबकि `SaveFormat.Xml` एक PowerPoint XML प्रस्तुतीकरण फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**

हाँ। [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) को लिखने योग्य स्ट्रीम पास करें। उदाहरण के लिए, इन‑मेमोरी प्रसंस्करण के लिए [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) का उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। PowerPoint XML प्रस्तुतीकरण वर्तमान में केवल सहेजने के लिए समर्थित है, लोड करने के लिये नहीं। जब राउंड‑ट्रिप संपादन आवश्यक हो तो PPTX या कोई अन्य समर्थित प्रस्तुतीकरण स्वरूप उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुतीकरण डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिये PNG, JPEG, और SVG का प्रयोग करें।