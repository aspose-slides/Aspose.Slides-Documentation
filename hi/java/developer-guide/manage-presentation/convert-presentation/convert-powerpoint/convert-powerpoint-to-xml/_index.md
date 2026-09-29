---
title: Java में PowerPoint प्रस्तुतियों को XML में परिवर्तित करें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुतीकरण
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ Java में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में बदलें।"
---
## **अवलोकन**

Aspose.Slides for Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation प्रारूप में रूपांतरण कर सकता है। XML आउटपुट तब उपयोगी होता है जब आपको प्रस्तुति संरचना की जांच, उत्पन्न दस्तावेज़ों की समस्या निवारण, स्वचालित परीक्षणों में आउटपुट की तुलना, या ऐसी कार्यप्रवाह के साथ एकीकृत करने के लिए टेक्स्ट‑आधारित प्रतिनिधित्व चाहिए जो प्रस्तुति पैकेज के बजाय XML का उपयोग करता है।

[Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करें और [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) क्लास से `Xml` मान दें। आप परिणाम को सीधे फ़ाइल में या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको ठीक‑ठीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो स्वयं PPTX पैकेज की जांच करें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में परिवर्तित करें**

[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास से स्रोत प्रस्तुति लोड करें, और फिर आउटपुट पथ और `SaveFormat.Xml` को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) में पास करें। स्रोत कोई भी प्रस्तुति प्रारूप हो सकता है जो लोड करने के लिए समर्थित हो, जैसे PPT, PPTX, या ODP।

निम्नलिखित उदाहरण एक PPTX प्रस्तुति को XML फ़ाइल में परिवर्तित करता है:
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

[Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) की स्ट्रीम ओवरलोड का उपयोग करें जब XML को मेमोरी में बनाए रखना हो या उसे किसी अन्य घटक को पास किया जाना हो, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन। निम्नलिखित उदाहरण परिणाम को एक [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) में लिखता है और प्राप्त XML को बाइट एरे के रूप में निकालता है:
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // कार्यप्रवाह में अगले घटक को xmlData पास करें।
} finally {
    presentation.dispose();
}
```

## **XML की प्रस्तुति और एक्सपोर्ट प्रारूपों से तुलना**

परिणाम के उपयोग के अनुसार आउटपुट प्रारूप चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML प्रस्तुति | संरचना की जांच, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML‑आधारित एकीकरण |
| PPT (`.ppt`) | एक पुरानी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | सामान्य PowerPoint संपादन और प्रस्तुति आदान‑प्रदान |
| PDF or TIFF | स्थिर‑लेआउट पृष्ठ या बहु‑पृष्ठ छवि | देखना, प्रिंट करना, और अभिलेखीयकरण |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया हुआ प्रतिनिधित्व | थंबनेल, प्रीव्यू और छवि संपत्तियां |
| HTML or HTML5 | वेब‑उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्य रूप से निरीक्षण और डेटा‑उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML, और स्लाइड छवि प्रारूपों के विपरीत, यह प्रस्तुति डेटा का प्रतिनिधित्व करता है न कि स्लाइडों को पृष्ठों या दृश्य संपत्तियों के रूप में रेंडर करना। [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/java/supported-file-formats/) तालिका उन सभी फ़ॉर्मेटों को सूचीबद्ध करती है जिन्हें Aspose.Slides लोड, आयात, सहेज या रेंडर कर सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `SaveFormat.Xml` PPTX फ़ाइल सहेजने के समान है?**  
नहीं। PPTX कई Office Open XML भागों वाला एक पैकेज है, जबकि `SaveFormat.Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**  
हां। लिखने योग्य स्ट्रीम को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) में पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए एक [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) का उपयोग करें।

**क्या Aspose.Slides निर्यात किए गए XML फ़ाइल को फिर से लोड कर सकता है?**  
हां। XML फ़ाइल या स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) कंस्ट्रक्टर में पास करें। [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSourceFormat--) फिर `SourceFormat.Xml` लौटाता है। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) इस फ़ॉर्मेट के लिए `LoadFormat.Unknown` रिपोर्ट करता है, इसलिए इसका उपयोग यह तय करने के लिए न करें कि XML फ़ाइल खोली जा सकती है या नहीं।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पेज या छवि के रूप में रेंडर करता है?**  
नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पेज‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, और SVG का उपयोग करें।