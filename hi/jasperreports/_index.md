---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /hi/jasperreports/
keywords:
- दस्तावेज़ीकरण
- JasperReports
- JasperReports Server
- रिपोर्ट निर्यात
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for JasperReports स्थापित करें, पहला रिपोर्ट PowerPoint पर निर्यात करें, और निर्यात, JasperReports Server एकीकरण और समर्थन के लिए गाइड्स खोजें।"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports JasperReports Library और JasperReports Server में PowerPoint निर्यातक जोड़ता है, ताकि Java अनुप्रयोग और रिपोर्ट सर्वर भरे हुए रिपोर्ट को प्रस्तुतियों के रूप में Microsoft PowerPoint के बिना सहेज सकें।

यह भरे हुए रिपोर्ट को PPT और PPTX, प्रति रिपोर्ट पृष्ठ एक स्लाइड, तथा PDF और HTML में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरूआत</p>
<ul>
<li><a href="/slides/hi/jasperreports/installing-aspose-slides-for-jasperreports/">स्थापना</a></li>
<li><a href="/slides/hi/jasperreports/product-overview/">उत्पाद अवलोकन</a></li>
<li><a href="/slides/hi/jasperreports/system-requirements/">सिस्टम आवश्यकताएँ</a></li>
<li><a href="/slides/hi/jasperreports/getting-started/">शुरू करने के निर्देश</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/jasperreports/supported-file-formats/">समर्थित फ़ाइल फॉर्मेट</a></li>
<li><a href="/slides/hi/jasperreports/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/jasperreports/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ निर्माण</b></p>
<hr>
<p>निर्यात</p>
<ul>
<li><a href="/slides/hi/jasperreports/ppt-pptx-pdf-and-html-export/">PPT, PPTX, PDF और HTML में निर्यात</a></li>
<li><a href="/slides/hi/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">फ़ॉन्ट मैप करना</a></li>
<li><a href="/slides/hi/jasperreports/integration-with-jasperserver/">JasperReports Server एकीकरण</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/jasperreports/demos-setup/">डेमो प्रोजेक्ट</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ & समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">फ़्री समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">पेड समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपका पहला निर्यात**

इन चरणों में एक‑लाइन रिपोर्ट को संकलित किया जाता है, उसे भरा जाता है, और JasperReports 6.16.0 से Maven Central के माध्यम से PPTX में निर्यात किया जाता है। आपको JDK 11 या उसके बाद का संस्करण तथा Apache Maven चाहिए।

1. [download page](https://releases.aspose.com/slides/jasperreport/) से ZIP डाउनलोड करके अनज़िप करें। इसके *lib* फ़ोल्डर में JasperReports संस्करणों की रेंज के अनुसार उप‑फ़ोल्डर होते हैं, और प्रत्येक में उस रेंज के लिए jar रहता है। JasperReports 6.16.0 के लिए *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* को खाली प्रोजेक्ट फ़ोल्डर में कॉपी करें।

2. jar ZIP में ही आता है, Maven रिपॉज़िटरी से नहीं, इसलिए इसे स्थानीय Maven रेपो में इंस्टॉल करें। प्रोजेक्ट फ़ोल्डर में यह कमांड चलाएँ:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. इस *pom.xml* को प्रोजेक्ट फ़ोल्डर में सहेजें। यह JasperReports 6.16.0 और आपने जो jar इंस्टॉल किया है, उसे जोड़ता है, तथा चलाने के लिए क्लास का नाम निर्दिष्ट करता है। JasperReports 6.16.0 एक पैच किया हुआ iText बिल्ड घोषित करता है जो Maven Central में नहीं है, इसलिए फ़ाइल इसे बाहर रखती है; Aspose निर्यातकों को इसकी आवश्यकता नहीं होती।

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. इस रिपोर्ट डिज़ाइन को *hello.jrxml* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें। यह शीर्षक बैंड में एक पंक्ति का टेक्स्ट प्रिंट करता है:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. इस कोड को *src/main/java/HelloExport.java* के रूप में सहेजें। यह डिज़ाइन को संकलित करता है, एक खाली रेकॉर्ड से भरता है, और `ASPptxExporter` के साथ परिणाम निर्यात करता है:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // रिपोर्ट डिज़ाइन को संकलित करें और उसे एक खाली रिकॉर्ड से भरें।
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // भरे हुए रिपोर्ट को PPTX में निर्यात करें।
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. प्रोजेक्ट फ़ोल्डर में यह कमांड चलाएँ:

```bash
mvn compile exec:java
```

प्रोग्राम *hello.pptx* को प्रोजेक्ट फ़ोल्डर में सहेजता है, जिसमें एक स्लाइड होती है जिसमें रिपोर्ट का टेक्स्ट होता है। कंपाइलर नोट करता है कि कोड एक पुरानी API का उपयोग कर रहा है: निर्यातक अपना इनपुट और आउटपुट `JRExporterParameter` के माध्यम से लेते हैं, और वे नवीन `setExporterInput` तथा `setExporterOutput` कॉन्फ़िगरेशन को स्वीकार नहीं करते। Linux पर, fontconfig और कम से कम एक फ़ॉन्ट इंस्टॉल होना चाहिए, नहीं तो रिपोर्ट भरना विफल रहेगा। बिना लाइसेंस के, प्रत्येक स्लाइड के केंद्र में एक मूल्यांकन वॉटरमार्क दिखेगा — देखें [Licensing](/slides/hi/jasperreports/licensing/). PPT, PDF या HTML में निर्यात करने के लिए देखें [PPT, PPTX, PDF and HTML Export](/slides/hi/jasperreports/ppt-pptx-pdf-and-html-export/).