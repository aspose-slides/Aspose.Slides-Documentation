---
title: Aspose.Slides for JasperReports को स्थापित करना
type: docs
weight: 40
url: /hi/jasperreports/installing-aspose-slides-for-jasperreports/
description: "अपने JasperReports संस्करण से मिलते-जुलते Aspose.Slides for JasperReports जार चुनें, और उन्हें JasperReports, एक Maven प्रोजेक्ट या JasperReports Server में जोड़ें।"
---
## **अपने JasperReports संस्करण के लिए जार चुनें**

Aspose.Slides for JasperReports को ZIP फ़ाइल के रूप में [download page](https://releases.aspose.com/slides/jasperreport/) से वितरित किया जाता है। इसकी *lib* फ़ोल्डर में JasperReports संस्करणों की श्रेणी के अनुसार एक उप‑फ़ोल्डर होता है। उस उप‑फ़ोल्डर से जार लें जो आप जिस JasperReports संस्करण का उपयोग करते हैं, उसे कवर करता है:

| JasperReports संस्करण | *lib* का उपफ़ोल्डर |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

JasperReports 6.17.0 या बाद के संस्करणों, जिसमें JasperReports 7 शामिल है, के लिए कोई उप‑फ़ोल्डर नहीं है। *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* उप‑फ़ोल्डर में कोई जार नहीं है, केवल यह नोट है कि उन संस्करणों के लिए समर्थन Aspose.Slides for JasperReports 17.6 में समाप्त हो गया था।

प्रत्येक उप‑फ़ोल्डर में दो जार होते हैं; उनके नामों में *xx.x* उत्पाद संस्करण को दर्शाता है:

- *aspose.slides.jasperreports.library-xx.x.jar* JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` और `ASHtmlExporter`) के एक्सपोर्टर और `License` क्लास को शामिल करता है।
- *aspose.slides.jasperreports.server-xx.x.jar* JasperReports Server के एक्सपोर्ट एक्शन को शामिल करता है। यह लाइब्रेरी जार पर आधारित है, इसलिए सर्वर को हमेशा समान उप‑फ़ोल्डर से दोनों जार की आवश्यकता होती है।

## **JasperReports या अपने एप्लिकेशन में लाइब्रेरी जार जोड़ें**

मिलते‑जुलते उप‑फ़ोल्डर से *aspose.slides.jasperreports.library-xx.x.jar* को JasperReports के *lib* फ़ोल्डर या अपने एप्लिकेशन के क्लासपाथ में कॉपी करें। इसके बाद आपका एप्लिकेशन कोड में एक्सपोर्टर बना सकता है।

{{% alert color="info" title="Note" %}}
Linux पर JasperReports को रिपोर्ट भरने के लिये fontconfig और कम से कम एक स्थापित फ़ॉन्ट की आवश्यकता होती है। फ़ॉन्ट न होने पर भरना विफल रहता है और त्रुटि "Error initializing graphic environment" दिखती है।
{{% /alert %}}

## **Maven प्रोजेक्ट में लाइब्रेरी जार जोड़ें**

जैरो ZIP में आता है, Maven रिपॉज़िटरी से नहीं। Maven बिल्ड में उपयोग करने के लिये इसे अपने स्थानीय Maven रिपॉज़िटरी में इंस्टॉल करें। संस्करण 26.6 के लिये, जार वाली फ़ोल्डर में यह कमांड चलाएँ:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

फिर इसे *pom.xml* के निर्भरताओं में जोड़ें, उस JasperReports संस्करण के साथ जो जार के उप‑फ़ोल्डर में सम्मिलित है:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

ग्रुप और आर्टिफैक्ट IDs इंस्टॉल कमांड में आप जो चुनते हैं वही हैं; केवल मिलनी चाहिए। JasperReports 6.16.0 उपयोग करने वाला एक पूर्ण प्रोजेक्ट आप [Your first export](/slides/hi/jasperreports/#your-first-export) में पा सकते हैं।

## **JasperReports Server में जार जोड़ें**

मिलते‑जुलते उप‑फ़ोल्डर से दोनों जार को JasperReports Server वेब एप्लिकेशन के *WEB-INF/lib* फ़ोल्डर में कॉपी करें, फिर जैसा कि [Integration with JasperServer](/slides/hi/jasperreports/integration-with-jasperserver/) में बताया गया है, एक्सपोर्टर पंजीकृत करें।