---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /hi/java/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रसंस्करण
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for Java स्थापित करें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों, API संदर्भ और समर्थन के लिए गाइड देखें।"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java एक क्लास लाइब्रेरी है जो जावा एप्लिकेशनों में PowerPoint और OpenDocument प्रस्तुतियों को बनाना, पढ़ना, संपादित करना और रूपांतरित करना संभव बनाती है, बिना Microsoft PowerPoint के।

यह PPT, PPTX, PPS, POT और ODP फ़ाइलें लोड और सेव कर सकती है, जिसमें मैक्रो‑सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और इमेजेज़ में निर्यात करती है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरूआत</p>
<ul>
<li><a href="/slides/hi/java/installation/">स्थापना</a></li>
<li><a href="/slides/hi/java/create-presentation/">अपनी पहली प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/java/getting-started/">शुरूआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/java/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/java/evaluate-aspose-slides/">ट्रायल सीमाएं</a></li>
<li><a href="/slides/hi/java/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/java/open-presentation/">एक प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/java/save-presentation/">एक प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/java/convert-powerpoint-to-pdf/">PDF में बदलें</a></li>
<li><a href="/slides/hi/java/convert-slide/">स्लाइड्स को इमेजेज़ के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/java/manage-text/">टेक्स्ट और शैप्स संपादित करें</a></li>
</ul>
<p>Slides कार्यप्रवाह</p>
<ul>
<li><a href="/slides/hi/java/powerpoint-charts/">चार्ट्स</a></li>
<li><a href="/slides/hi/java/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/java/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/java/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/java/merge-presentation/">प्रस्तुतियों को मिलाएँ</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/java/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub पर उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/java/known-issues/">ज्ञात समस्याएं</a></li>
<li><a href="https://releases.aspose.com/slides/java/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">नि:शुल्क समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतानित समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

Aspose.Slides for Java को Aspose के अपने Maven रिपॉज़िटरी में प्रकाशित किया गया है, Maven Central में नहीं। एक Maven प्रोजेक्ट के लिए फ़ोल्डर बनाएँ और इसमें *pom.xml* सहेजें। यह रिपॉज़िटरी घोषित करता है, लाइब्रेरी जोड़ता है, और चलाने के लिए क्लास का नाम निर्दिष्ट करता है:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

इस कोड को *src/main/java/HelloSlides.java* के रूप में सहेजें:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // एक प्रस्तुति बनाएं। इसमें पहले से ही एक खाली स्लाइड शामिल है।
        Presentation presentation = new Presentation();
        try {
            // पहली स्लाइड प्राप्त करें।
            ISlide slide = presentation.getSlides().get_Item(0);

            // एक क्लाउड आकार जोड़ें और उसमें टेक्स्ट रखें।
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

फिर, JDK 11 या बाद का संस्करण और Apache Maven स्थापित होने पर, प्रोजेक्ट फ़ोल्डर में यह कमांड चलाएँ:

```bash
mvn compile exec:java
```

यह प्रोग्राम *new_presentation.pptx* को प्रोजेक्ट फ़ोल्डर में सहेजता है, जिसमें एक स्लाइड में टेक्स्ट के साथ एक क्लाउड आकार होता है। Linux पर, fontconfig और कम से कम एक फ़ॉन्ट स्थापित होना चाहिए; देखें [स्थापना](/slides/hi/java/installation/#linux)। बिना लाइसेंस के, सेव की गई फ़ाइल में मूल्यांकन वॉटरमार्क रहेगा — देखें [लाइसेंसिंग](/slides/hi/java/licensing/)। प्रस्तुति बनाने और भरने के अधिक तरीकों के लिए, देखें [प्रस्तुति बनाएं](/slides/hi/java/create-presentation/).