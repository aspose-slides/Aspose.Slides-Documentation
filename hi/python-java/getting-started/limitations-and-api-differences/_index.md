---
title: सीमाएँ और API अंतर
type: docs
weight: 100
url: /hi/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- API अंतर
- Python
- Java
- JPype
- JVM सीमाएँ
- PowerPoint
description: "Aspose.Slides for Java और Python via Java के बीच JVM सीमाएँ और API अंतर के बारे में जानें, जिसमें आयात, संसाधन सफाई और फ़ाइल हैंडलिंग शामिल हैं।"
---
## **परिचय**

Aspose.Slides for Python via Java JPype का उपयोग करके Python से Java लाइब्रेरी तक पहुँचता है। नीचे दिए गए उदाहरण दो APIs में पैकेज आयात, प्रस्तुति निर्माण और फ़ाइल हैंडलिंग की तुलना करते हैं।

## **ज्ञात सीमाएँ**

- **JVM lifecycle:** JPype एक Python प्रक्रिया प्रति एक JVM का समर्थन करता है। इसे बंद करने के बाद, आप उसी प्रक्रिया में इसे पुनः प्रारंभ नहीं कर सकते। इसे एक बार शुरू करें और बाद के प्रस्तुति कार्यों के लिए पुनः उपयोग करें।
- **Architecture compatibility:** Python और Java की आर्किटेक्चर मेल खानी चाहिए। विवरण के लिए देखें [सिस्टम आवश्यकताएँ](/slides/hi/python-java/system-requirements/#python-java-and-jpype-requirements)।

इन प्रतिबंधों और Java अंतर-कार्यात्मकता के विवरण के लिए देखें [JPype उपयोगकर्ता गाइड](https://jpype.readthedocs.io/en/latest/userguide.html)।

## **सार्वजनिक API अंतर**

नीचे Java और Python उदाहरणों की तुलना करें। Python via Java सदस्य विवरण के लिए देखें [API संदर्भ](/slides/hi/python-java/api-reference/)।

### **लाइब्रेरी आयात करें**

Java `com.aspose.slides` से क्लासेस आयात करता है। Python में, JVM शुरू करने से पहले `asposeslides` आयात करें, फिर JVM चलने के बाद `asposeslides.api` से क्लासेस आयात करें। पहले से चल रहे JVM को पुनः शुरू होने से बचाने के लिए उपयोग करें [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted)।

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Python उदाहरण JVM को तब तक चलाते रहते हैं जब तक Python प्रक्रिया समाप्त नहीं होती। नोटबुक में, सक्रिय JVM को विभिन्न सेल्स में पुनः उपयोग करें। यदि इसे पहले ही बंद कर दिया गया है, तो Java ऑब्जेक्ट्स को फिर से उपयोग करने से पहले नोटबुक कर्नेल को पुनः प्रारंभ करें।
{{% /alert %}}

### **प्रस्तुति बनाएं**

Java `new` कीवर्ड का उपयोग करता है; Python सीधे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास को कॉल करता है। `finally` ब्लॉक में [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) के साथ प्रस्तुति संसाधनों को रिलीज़ करें।

दोनों उदाहरण एक खाली प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) और [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#pptx) का उपयोग करके सहेजते हैं।

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **फ़ाइलें पढ़ें और स्वरूप स्थिरांक उपयोग करें**

Java एक Java इनपुट स्ट्रीम से प्रस्तुति लोड कर सकता है। Python में, फ़ाइल को बाइनरी डेटा के रूप में पढ़ें और प्राप्त बाइट्स को [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#createpresentationfrombytes) को पास करें। एक Python फ़ाइल ऑब्जेक्ट एक Java इनपुट स्ट्रीम नहीं होता।

नीचे के उदाहरणों के लिए कार्यशील निर्देशिका में मौजूदा `presentation.pptx` आवश्यक है और एक कॉपी `result.pptx` के रूप में सहेजी जाती है। दोनों इनपुट फ़ाइल को बंद करते हैं और प्रस्तुति संसाधनों को रिलीज़ करते हैं। Python उदाहरण पूरी इनपुट फ़ाइल को मेमोरी में पढ़ता है।

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रत्येक प्रस्तुति के लिए JVM को पुनः प्रारंभ करना चाहिए?**

नहीं। JVM को चलाते रखें और आवश्यकतानुसार प्रस्तुति ऑब्जेक्ट्स बनाएं और डिस्पोज़ करें। JVM को बंद करने से उसी Python प्रक्रिया में आगे के Java संचालन निषिद्ध हो जाते हैं।

**क्या मैं किसी फ़ाइल पाथ से सीधे प्रस्तुति खोल सकता हूँ?**

हां। [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कन्स्ट्रक्टर एक फ़ाइल पाथ स्वीकार करता है। जब प्रस्तुति डेटा पहले से Python बाइट्स के रूप में उपलब्ध हो, तो बाइट-आधारित हेल्पर का उपयोग करें।

**क्या मुझे Java उदाहरणों को Python में अनुवादित करते समय स्वरूप स्थिरांक नाम बदलने चाहिए?**

नहीं। उदाहरण के लिए, [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#pptx) दोनों APIs में समान वर्तनी और बड़े अक्षर उपयोग करता है।