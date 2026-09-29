---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/java/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- समर्थित प्लेटफ़ॉर्म
- जावा संस्करण
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
- प्रस्तुति
- Java
- Aspose.Slides
description: "इंस्टॉल करने से पहले Aspose.Slides for Java को क्या चाहिए, जाँचें: समर्थित जावा संस्करण और ऑपरेटिंग सिस्टम, तथा वह फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स जो Linux को आवश्यक हैं।"
---
## **परिचय**

Aspose.Slides for Java एक स्वतंत्र लाइब्रेरी है: इसे Microsoft PowerPoint या Microsoft Office की आवश्यकता नहीं होती। यह एकल JAR फ़ाइल है, जो Aspose के Maven रिपॉज़िटरी में प्रकाशित होती है। JAR फ़ाइल में केवल Java क्लासेस और संसाधन होते हैं, इसमें कोई नेविगेटिव लाइब्रेरी नहीं होती, और यह अन्य लाइब्रेरीज़ पर कोई निर्भरता घोषित नहीं करती। इसलिए यह फ़ाइल सभी ऑपरेटिंग सिस्टम और प्रोसेसर पर चलती है, जिनके लिए समर्थित Java रनटाइम उपलब्ध है।

यह लेख समर्थित Java संस्करणों और ऑपरेटिंग सिस्टमों, तथा Linux को आवश्यक फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स की सूची देता है, और अंत में एक छोटा प्रोग्राम प्रदान करता है जो आपका सेटअप जांचता है। लाइब्रेरी को प्रोजेक्ट में जोड़ने के लिए देखें [स्थापना](/slides/hi/java/installation/)।

## **समर्थित जावा संस्करण**

Aspose.Slides for Java Java 8 या बाद के संस्करण पर, JDK या JRE के साथ चलता है। इसमें दीर्घकालिक समर्थन वाले रिलीज़ Java 8, 11, 17, 21, और 25, साथ ही बाद के रिलीज़ जैसे Java 26 और Java 27 शामिल हैं। Java रनटाइम किसी भी विक्रेता से आ सकता है, उदाहरण के लिए Eclipse Temurin, Amazon Corretto, Oracle, या किसी Linux वितरण के OpenJDK पैकेज।

Aspose.Slides को इन संस्करणों में किसी भी JVM विकल्प, जैसे `--add-opens`, की आवश्यकता नहीं होती। Java 11 पर, JVM एक चेतावनी प्रिंट करता है जो "WARNING: An illegal reflective access operation has occurred" से शुरू होती है; यह चेतावनी परिणाम को प्रभावित नहीं करती।

{{% alert color="warning" title="Warning" %}}
Java 6 और Java 7 को अप्रचलित घोषित किया गया है। Aspose.Slides for Java 26.9 अभी भी इन पर चलती है लेकिन एक डिप्रिकेशन चेतावनी दिखाती है। संस्करण 26.10 से प्रारंभ करके, न्यूनतम आवश्यक संस्करण Java 8 है, और Java 6 व Java 7 अब समर्थित नहीं हैं।
{{% /alert %}}

Maven प्रोजेक्ट और [स्थापना](/slides/hi/java/installation/) में कमांड्स को JDK 11 या बाद का चाहिए। Java 8 के साथ, अपना प्रोग्राम नीचे दिखाए अनुसार संकलित और चलाएँ जैसा कि [अपना सेटअप जांचें](#check-your-setup) में बताया गया है।

## **समर्थित ऑपरेटिंग सिस्टम**

चूँकि JAR फ़ाइल में कोई नेविगेटिव कोड नहीं है, Aspose.Slides for Java Windows, Linux, और macOS पर, किसी भी प्रोसेसर आर्किटेक्चर पर चलता है जो Java रनटाइम समर्थित करता है, जैसे x64 और ARM64। Windows पर Java रनटाइम ही एकमात्र आवश्यकता है। Linux पर, Java की फ़ॉन्ट समर्थन को भी [लिनक्स](#linux) में वर्णित फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स की आवश्यकता होती है।

## **लिनक्स**

Aspose.Slides for Java टेक्स्ट को लेआउट और ड्रॉ करने के लिए Java रनटाइम की फ़ॉन्ट समर्थन का उपयोग करता है। Linux पर यह समर्थन fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट की आवश्यकता रखता है। Linux वितरणों की आधिकारिक कंटेनर इमेज़ अक्सर किसी भी को नहीं रखती। बिना इनके, [Create Presentations](/slides/hi/java/create-presentation/) में पहला उदाहरण प्रस्तुति को सहेजते समय विफल हो जाता है, एक खाली फ़ाइल छोड़ता है, और यह त्रुटि रिपोर्ट करता है:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

आधिकारिक `eclipse-temurin` कंटेनर इमेज़, Ubuntu और Alpine Linux दोनों के लिए, पहले से ही fontconfig और DejaVu फ़ॉन्ट्स शामिल करती हैं, इसलिए उनके लिए कुछ भी स्थापित करने की आवश्यकता नहीं है। अन्य सिस्टमों पर, नीचे दिए पैकेजेस स्थापित करें। Debian, Ubuntu, और Red Hat कमांड्स `sudo` का उपयोग करते हैं; Dockerfile में, इन्हें `RUN` निर्देश में बिना `sudo` चलाएँ। DejaVu फ़ॉन्ट्स Aspose.Slides को चलाने के लिए पर्याप्त हैं; आपके प्रेजेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट्स [फ़ॉन्ट्स](#fonts) में कवर किए गए हैं।

### **डेबियन और उबुंटू**

यदि आप Debian या Ubuntu पैकेजों से Java को डिफ़ॉल्ट `apt-get` सेटिंग्स के साथ स्थापित करते हैं, जैसा कि [स्थापना](/slides/hi/java/installation/#linux) में कमांड दर्शाता है, तो Java पैकेज fontconfig लाइब्रेरी, DejaVu फ़ॉन्ट्स, और HarfBuzz लाइब्रेरी को भी स्थापित करते हैं, और कुछ और आवश्यक नहीं है।

यदि आप किसी अन्य स्रोत से Java रनटाइम उपयोग करते हैं, जैसे Eclipse Temurin आर्काइव, तो fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile अक्सर Debian या Ubuntu Java पैकेज, जैसे `openjdk-21-jdk-headless` या `default-jdk-headless`, को `--no-install-recommends` विकल्प के साथ स्थापित करता है, जो इन सभी तीन को छोड़ देता है। ऊपर के कमांड से fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें, और साथ में HarfBuzz भी स्थापित करें:

```bash
sudo apt-get install -y libharfbuzz0b
```

बिना HarfBuzz के, ये Java पैकेज `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` संदेश प्रिंट करते हैं, और सहेजना `UnsatisfiedLinkError` से विफल हो जाता है जो बताता है कि `libharfbuzz.so.0` नहीं खोला जा सकता।

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux के `java-<version>-openjdk-headless` पैकेज fontconfig लाइब्रेरी स्थापित नहीं करते। इसे DejaVu फ़ॉन्ट्स के साथ स्थापित करें:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

पूरा `java-<version>-openjdk` पैकेज fontconfig और फ़ॉन्ट्स को निर्भरताओं के रूप में स्थापित करता है, और Amazon Linux 2023 के Amazon Corretto पैकेज, जैसे `java-21-amazon-corretto-headless`, भी ऐसा ही करते हैं।

### **Alpine Linux**

Alpine Linux पर आधारित Dockerfile में, fontconfig और DejaVu फ़ॉन्ट्स स्थापित करें:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

वर्तमान Alpine रिलीज़ में, `ttf-dejavu` पैकेज `font-dejavu` स्थापित करता है। Java को `openjdk<version>-jre` या `openjdk<version>-jdk` पैकेज, जैसे `openjdk25-jdk`, के साथ स्थापित करें। Alpine Linux के `openjdk<version>-jre-headless` पैकेज में Java की फ़ॉन्ट लाइब्रेरी नहीं होती, इसलिए इनके साथ प्रोग्राम `UnsatisfiedLinkError: no fontmanager in system library path` के साथ विफल होता है, भले ही फ़ॉन्ट्स स्थापित हों।

### **फ़ॉन्ट्स**

टेक्स्ट को सही फ़ॉन्ट्स और मीट्रिक के साथ रेंडर करने के लिए, आपके प्रेज़ेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट्स या उपयुक्त प्रतिस्थापन, सिस्टम पर स्थापित होने चाहिए या आपके एप्लिकेशन द्वारा लोड किए जाने चाहिए। देखें [फ़ॉन्ट्स डिप्लॉय करें](/slides/hi/java/deploy-fonts/), [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/), और [कस्टम फ़ॉन्ट्स](/slides/hi/java/custom-font/)।

## **अपना सेटअप जांचें**

यह पुष्टि करने के लिए कि लाइब्रेरी और उसके आवश्यकताएँ उपस्थित हैं, एक प्रोग्राम चलाएँ जो प्रस्तुति को सहेजता है और स्लाइड को इमेज में रेंडर करता है। सहेजना और रेंडर करना Java रनटाइम की फ़ॉन्ट समर्थन का उपयोग करता है, जो ऊपर बताई गई Linux आवश्यकताओं द्वारा प्रदान किया जाता है।

नीचे दिया कोड *CheckSetup.java* नाम से उस फ़ोल्डर में सहेजें जिसमें Aspose.Slides JAR फ़ाइल है। JAR फ़ाइल डाउनलोड करने के लिए देखें [Use the JAR File without Maven](/slides/hi/java/installation/#use-the-jar-file-without-maven)।

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // पहली स्लाइड पर टेक्स्ट वाले एक आयत जोड़ें और प्रेज़ेंटेशन को सहेजें।
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // स्लाइड को प्रत्येक पॉइंट पर एक पिक्सेल के साथ रेंडर करें और इमेज को सहेजें।
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

JDK 11 या बाद के साथ, नीचे दिए कमांड से उस फ़ोल्डर में प्रोग्राम चलाएँ। यदि आपकी JAR फ़ाइल का नाम अलग है, तो कमांड में नाम बदलें।

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Java 8 के साथ, या यदि सिस्टम में केवल JRE है, तो JDK से `javac` के साथ प्रोग्राम संकलित करें और फिर संकलित क्लास चलाएँ। Linux और macOS पर चलाएँ:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Windows पर, वही `javac` कमांड चलाएँ, और फिर क्लास को सेमीकोलन को क्लास पाथ सेपरेटर के रूप में उपयोग करके चलाएँ। कोट्स रखें, ताकि PowerShell सेमीकोलन को कमांड के अंत के रूप में न ले: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

प्रोग्राम पहले स्लाइड में टेक्स्ट के साथ एक आयत जोड़ता है और प्रस्तुति को *hello.pptx* के रूप में [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड से सहेजता है। फिर वह स्लाइड को [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#getImage-float-float-) से रेंडर करता है और परिणाम को *hello.png* के रूप में [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड से [ImageFormat.Png](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) फॉर्मेट में सहेजता है। 1 के स्केल फैक्टर एक पिक्सेल प्रति पॉइंट रेंडर करते हैं, इसलिए डिफ़ॉल्ट 720 × 540 पॉइंट स्लाइड 720 × 540 पिक्सेल इमेज बन जाता है, और टेक्स्ट आयत के भीतर दिखाई देता है। बिना लाइसेंस के, दोनों फ़ाइलों में मूल्यांकन वॉटरमार्क भी रहेगा; देखें [Licensing](/slides/hi/java/licensing/)। यदि कोई आवश्यकता अनुपलब्ध है, तो प्रोग्राम [Linux](#linux) में वर्णित त्रुटियों में से किसी एक के साथ बंद हो जाता है।

## **डेवलपमेंट टूल्स**

आप किसी भी समर्थित Java संस्करण के JDK के साथ Aspose.Slides का उपयोग करने वाले एप्लिकेशन बना सकते हैं। Apache Maven को Aspose के Maven रिपॉज़िटरी के साथ उपयोग करें, जैसा कि [स्थापना](/slides/hi/java/installation/) में बताया गया है, या कोई भी अन्य बिल्ड टूल जो Maven रिपॉज़िटरी का उपयोग कर सके। आप JAR फ़ाइल को अपने IDE या बिल्ड टूल के क्लास पाथ में स्वयं भी जोड़ सकते हैं।

## **FAQ**

**क्या रूपांतरण और रेंडरिंग के लिए मुझे Microsoft PowerPoint स्थापित करने की आवश्यकता है?**

नहीं, PowerPoint आवश्यक नहीं है। Aspose.Slides एक स्वतंत्र इंजन है [प्रेज़ेंटेशन बनाने](/slides/hi/java/create-presentation/), संशोधित करने, [रूपांतरित करने](/slides/hi/java/convert-presentation/), और [रेंडर करने](/slides/hi/java/convert-powerpoint-to-png/) के लिए।

**क्या Aspose.Slides for Java को Linux सर्वर पर डिस्प्ले या डेस्कटॉप वातावरण की आवश्यकता है?**

नहीं। Aspose.Slides को X सर्वर या डिस्प्ले की आवश्यकता नहीं है, इसलिए यह सर्वर और कंटेनर दोनों में चलता है। Linux पर इसे केवल फ़ॉन्ट लाइब्रेरी और फ़ॉन्ट्स की आवश्यकता होती है जैसा कि [लिनक्स](#linux) में बताया गया है।

**सही रेंडरिंग के लिए कौन से फ़ॉन्ट्स आवश्यक हैं?**

प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट्स, या उपयुक्त [प्रतिस्थापन](/slides/hi/java/font-substitution/), उपलब्ध होने चाहिए। Linux और macOS पर, स्थिर रेंडरिंग के लिए उन फ़ॉन्ट पैकेजों को स्थापित करें जिनकी आपके प्रेज़ेंटेशन को आवश्यकता है।

**Linux पर कस्टम फ़ॉन्ट को फॉलबैक या गायब टेक्स्ट के रूप में क्यों रेंडर किया जाता है?**

यदि फ़ॉन्ट फ़ाइल में नाम‑टेबल एंट्रीज़ असंगत या भ्रष्ट हैं, तो Linux फ़ॉन्ट‑मैचिंग स्टैक (FreeType/fontconfig) वैध रिकॉर्ड नहीं चुन पाता, जिससे फ़ॉन्ट अनरिज़ॉल्व्ड रहता है। सुधारित नाम‑टेबल रिकॉर्ड वाला फ़ॉन्ट संस्करण उपयोग करने या एक सुसंगत प्रतिस्थापन स्थापित करने से समस्या हल होती है।