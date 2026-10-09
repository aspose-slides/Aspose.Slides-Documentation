---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/java/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- समर्थित प्लेटफ़ॉर्म
- Java संस्करण
- JDK
- JRE
- fontconfig
- फ़ॉन्ट्स
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुतिकरण
- Java
- Aspose.Slides
description: "इंस्टॉल करने से पहले Aspose.Slides for Java को क्या चाहिए, देखें: समर्थित Java संस्करण और ऑपरेटिंग सिस्टम, तथा वह फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स जो Linux को आवश्यक हैं।"
---
## **परिचय**

Aspose.Slides for Java एक स्वतंत्र लाइब्रेरी है: इसे Microsoft PowerPoint या Microsoft Office की आवश्यकता नहीं है। यह एक ही JAR फ़ाइल है, जो Aspose के Maven रिपॉज़िटरी में प्रकाशित होती है। JAR फ़ाइल में केवल Java क्लासेज़ और संसाधन होते हैं, इसमें कोई नेटिव लाइब्रेरी नहीं होती, और यह अन्य लाइब्रेरीज़ पर कोई निर्भरता नहीं घोषित करती। इसलिए यही फ़ाइल सभी ऑपरेटिंग सिस्टम और प्रोसेसर पर चलती है, जिनके लिए समर्थित Java रनटाइम उपलब्ध है।

यह लेख समर्थित Java संस्करणों और ऑपरेटिंग सिस्टम, तथा Linux को आवश्यक फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स की सूची देता है, और एक छोटा प्रोग्राम के साथ समाप्त होता है जो आपके सेटअप की जांच करता है। लाइब्रेरी को प्रोजेक्ट में जोड़ने के लिए, देखें [स्थापना](/slides/hi/java/installation/).

## **समर्थित Java संस्करण**

Aspose.Slides for Java Java 8 या उससे बाद के संस्करणों पर चलता है, एक JDK या JRE के साथ। इसमें लंबी अवधि के समर्थन वाले रिलीज़ Java 8, 11, 17, 21, और 25, तथा बाद के रिलीज़ जैसे Java 26 और Java 27 शामिल हैं। Java रनटाइम किसी भी विक्रेता से हो सकता है, उदाहरण के लिए Eclipse Temurin, Amazon Corretto, Oracle, या किसी Linux वितरण के OpenJDK पैकेज।

Aspose.Slides को इन संस्करणों में किसी भी JVM विकल्प, जैसे `--add-opens`, की आवश्यकता नहीं होती। Java 11 पर, JVM एक चेतावनी प्रिंट करता है जो "WARNING: An illegal reflective access operation has occurred" से शुरू होती है; यह चेतावनी परिणाम को प्रभावित नहीं करती।

{{% alert color="warning" title="Warning" %}}
Java 6 और Java 7 को अप्रचलित घोषित किया गया है। Aspose.Slides for Java 26.9 अभी भी उन पर चलता है लेकिन एक अप्रचलन चेतावनी देता है। संस्करण 26.10 से, Java 8 न्यूनतम आवश्यक है, और Java 6 व Java 7 अब समर्थित नहीं हैं।
{{% /alert %}}

Maven प्रोजेक्ट और [स्थापना](/slides/hi/java/installation/) में दिए गए कमांड को JDK 11 या बाद का चाहिए। Java 8 के साथ, अपना प्रोग्राम संकलित करें और चलाएँ जैसा कि [अपना सेटअप जांचें](#check-your-setup) में दिखाया गया है।

## **समर्थित ऑपरेटिंग सिस्टम**

क्योंकि JAR फ़ाइल में कोई नेटिव कोड नहीं है, Aspose.Slides for Java Windows, Linux, और macOS पर चलता है, किसी भी प्रोसेसर आर्किटेक्चर पर जिसे Java रनटाइम समर्थन करता है, जैसे x64 और ARM64। Windows पर Java रनटाइम ही एकमात्र आवश्यकता है। Linux पर, Java का फ़ॉन्ट समर्थन भी [Linux](#linux) में वर्णित फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स की आवश्यकता रखता है।

## **Linux**

Aspose.Slides for Java Java रनटाइम की फ़ॉन्ट समर्थन के साथ टेक्स्ट को लेआउट और ड्रॉ करता है। Linux पर, इस समर्थन के लिए fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट आवश्यक है। Linux वितरणों की आधिकारिक कंटेनर इमेजों में अक्सर दोनों नहीं होते। इनके बिना, [प्रेज़ेंटेशन बनाएँ](/slides/hi/java/create-presentation/) में पहला उदाहरण प्रस्तुति को सेव करने पर विफल हो जाता है, एक खाली फ़ाइल छोड़ देता है, और यह त्रुटि रिपोर्ट करता है:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

आधिकारिक `eclipse-temurin` कंटेनर इमेजें, Ubuntu और Alpine Linux के लिए, पहले से ही fontconfig और DejaVu फ़ॉन्ट्स को शामिल करती हैं, इसलिए उन पर कुछ भी स्थापित करने की आवश्यकता नहीं है। अन्य सिस्टमों पर, नीचे दिए गए पैकेज स्थापित करें। Debian, Ubuntu, और Red Hat कमांड `sudo` का उपयोग करते हैं; Dockerfile में, उन्हें `RUN` निर्देश में `sudo` के बिना चलाएँ। DejaVu फ़ॉन्ट्स Aspose.Slides चलाने के लिए पर्याप्त हैं; आपके प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट्स [फ़ॉन्ट्स](#fonts) में कवर किए गए हैं।

### **Debian और Ubuntu**

यदि आप Debian या Ubuntu पैकेजों से डिफ़ॉल्ट `apt-get` सेटिंग्स के साथ Java स्थापित करते हैं, जैसा कि [स्थापना](/slides/hi/java/installation/#linux) में कमांड दिखाता है, तो Java पैकेज fontconfig लाइब्रेरी, DejaVu फ़ॉन्ट्स, और HarfBuzz लाइब्रेरी को भी स्थापित करते हैं, जो इन Java पैकेजों को आवश्यक है, और कुछ भी अतिरिक्त आवश्यक नहीं है।

यदि Java रनटाइम किसी अन्य स्रोत से है, जैसे Eclipse Temurin आर्काइव, तो fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

एक Dockerfile अक्सर Debian या Ubuntu Java पैकेज, जैसे `openjdk-21-jdk-headless` या `default-jdk-headless`, को `--no-install-recommends` विकल्प के साथ स्थापित करता है, जो इन सभी को छोड़ देता है। ऊपर दिए गए कमांड से fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें, और साथ ही HarfBuzz भी स्थापित करें:

```bash
sudo apt-get install -y libharfbuzz0b
```

यदि HarfBuzz नहीं है, तो ये Java पैकेज `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` संदेश प्रदर्शित करते हैं, और सहेजना `UnsatisfiedLinkError` के साथ विफल हो जाता है जो बताता है कि `libharfbuzz.so.0` नहीं खोल सकता।

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux के `java-<version>-openjdk-headless` पैकेज fontconfig लाइब्रेरी स्थापित नहीं करते। इसे DejaVu फ़ॉन्ट्स के साथ स्थापित करें:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

पूर्ण `java-<version>-openjdk` पैकेज fontconfig और फ़ॉन्ट्स को निर्भरताओं के रूप में स्थापित करते हैं, और Amazon Linux 2023 के Amazon Corretto पैकेज भी, जैसे `java-21-amazon-corretto-headless`।

### **Alpine Linux**

Alpine Linux पर आधारित Dockerfile में, fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

वर्तमान Alpine रिलीज़ में, `ttf-dejavu` `font-dejavu` पैकेज स्थापित करता है। Java को `openjdk<version>-jre` या `openjdk<version>-jdk` पैकेज से स्थापित करें, जैसे `openjdk25-jdk`। Alpine Linux के `openjdk<version>-jre-headless` पैकेजों में Java की फ़ॉन्ट लाइब्रेरी नहीं होती, इसलिए इनके साथ प्रोग्राम `UnsatisfiedLinkError: no fontmanager in system library path` के साथ विफल हो जाता है, भले ही फ़ॉन्ट्स स्थापित हों।

### **फ़ॉन्ट्स**

सही फ़ॉन्ट्स और मेट्रिक्स के साथ टेक्स्ट रेंडर करने के लिए, आपके प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट्स, या उपयुक्त विकल्प, सिस्टम पर स्थापित होने चाहिए या आपके अनुप्रयोग द्वारा लोड होने चाहिए। देखें [फ़ॉन्ट्स तैनात करें](/slides/hi/java/deploy-fonts/), [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/), और [कस्टम फ़ॉन्ट्स](/slides/hi/java/custom-font/)।

## **अपना सेटअप जांचें**

लाइब्रेरी और उसकी आवश्यकताएँ सही ढंग से मौजूद हैं यह जांचने के लिए, एक प्रोग्राम चलाएँ जो प्रेज़ेंटेशन को सहेजता है और एक स्लाइड को छवि में रेंडर करता है। सहेजना और रेंडरिंग Java रनटाइम की फ़ॉन्ट समर्थन का उपयोग करती हैं, जो ऊपर दी गई Linux आवश्यकताओं द्वारा प्रदान की गई हैं।

नीचे दिया गया कोड *CheckSetup.java* के रूप में उस फ़ोल्डर में सेव करें जिसमें Aspose.Slides JAR फ़ाइल मौजूद है। JAR फ़ाइल डाउनलोड करने के लिए, देखें [Maven के बिना JAR फ़ाइल का उपयोग करें](/slides/hi/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // पहली स्लाइड में टेक्स्ट के साथ एक आयत जोड़ें और प्रस्तुति को सहेजें।
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // स्लाइड को प्रत्येक पॉइंट पर एक पिक्सेल के साथ रेंडर करें और छवि को सहेजें।
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

JDK 11 या बाद के संस्करण के साथ, उस फ़ोल्डर में नीचे दिए गए कमांड से प्रोग्राम चलाएँ। यदि आपकी JAR फ़ाइल का नाम अलग है, तो कमांड में नाम बदलें।

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Java 8 के साथ, या ऐसे सिस्टम पर जहाँ केवल JRE है, प्रोग्राम को JDK से `javac` के द्वारा संकलित करें और फिर संकलित क्लास चलाएँ। Linux और macOS पर, चलाएँ:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Windows पर, वही `javac` कमांड चलाएँ, और फिर क्लास पाथ विभाजक के रूप में सेमिकॉलन के साथ क्लास चलाएँ। कोट्स रखें, ताकि PowerShell सेमिकॉलन को कमांड का अंत न समझे: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

प्रोग्राम पहले स्लाइड में टेक्स्ट के साथ एक आयत जोड़ता है और प्रस्तुति को *hello.pptx* के रूप में [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड से सहेजता है। फिर यह स्लाइड को [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) से रेंडर करता है और परिणाम को *hello.png* के रूप में [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) से [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) फ़ॉर्मेट में सहेजता है। स्केल फैक्टर 1 एक पॉइंट पर एक पिक्सेल रेंडर करता है, इसलिए डिफ़ॉल्ट 720 × 540 पॉइंट स्लाइड 720 × 540 पिक्सेल छवि बन जाती है, जिसमें आयत के अंदर टेक्स्ट दिखाई देता है। बिना लाइसेंस के, दोनों फ़ाइलों में एक इवैल्यूएशन वॉटरमार्क भी रहता है; देखें [लाइसेंसिंग](/slides/hi/java/licensing/). यदि कोई आवश्यक तत्व अनुपलब्ध है, तो प्रोग्राम [Linux](#linux) में वर्णित त्रुटियों में से एक के साथ रोक देता है।

## **विकास उपकरण**

आप समर्थित Java संस्करण के किसी भी JDK के साथ Aspose.Slides का उपयोग करने वाले अनुप्रयोग बना सकते हैं। Aspose के Maven रिपॉज़िटरी के साथ Apache Maven का उपयोग करें, जैसा कि [स्थापना](/slides/hi/java/installation/) में बताया गया है, या कोई भी अन्य बिल्ड टूल जो Maven रिपॉज़िटरी का उपयोग कर सके। आप स्वयं JAR फ़ाइल को अपने IDE या बिल्ड टूल की क्लास पाथ में भी जोड़ सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या रूपांतरण और रेंडरिंग के लिए Microsoft PowerPoint स्थापित होना आवश्यक है?**

नहीं, PowerPoint आवश्यक नहीं है। Aspose.Slides एक स्वतंत्र इंजन है [बनाना](/slides/hi/java/create-presentation/), संशोधित करने, [रूपांतरण](/slides/hi/java/convert-presentation/), और [रेंडरिंग](/slides/hi/java/convert-powerpoint-to-png/) प्रस्तुतियों के लिए।

**क्या Aspose.Slides for Java को Linux सर्वर पर डिस्प्ले या डेस्कटॉप वातावरण की आवश्यकता है?**

नहीं। Aspose.Slides को X सर्वर या डिस्प्ले की आवश्यकता नहीं होती, इसलिए यह सर्वरों और कंटेनरों में चलता है। Linux पर, इसे केवल फ़ॉन्ट लाइब्रेरी और [Linux](#linux) में वर्णित फ़ॉन्ट्स की आवश्यकता होती है।

**सही रेंडरिंग के लिए कौन से फ़ॉन्ट्स आवश्यक हैं?**

प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट्स, या उपयुक्त [विकल्प](/slides/hi/java/font-substitution/), उपलब्ध होने चाहिए। Linux और macOS पर, अपने प्रेज़ेंटेशन की निरंतर रेंडरिंग के लिए आवश्यक फ़ॉन्ट पैकेज स्थापित करें।

**Linux पर कस्टम फ़ॉन्ट फ़ॉलबैक या अनुपलब्ध टेक्स्ट के रूप में क्यों रेंडर होता है?**

यदि फ़ॉन्ट फ़ाइल में असंगत या क्षतिग्रस्त नाम-टेबल प्रविष्टियां हैं, तो Linux फ़ॉन्ट-मैचिंग स्टैक (FreeType/fontconfig) गलत रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अनसुलझा रहता है। सुधारे गए नाम-टेबल रिकॉर्ड वाले फ़ॉन्ट संस्करण का उपयोग करना या एक समान विकल्प स्थापित करना समस्या को हल करता है।