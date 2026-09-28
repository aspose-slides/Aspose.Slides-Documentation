---
title: डेमो सेटअप
type: docs
weight: 70
url: /hi/jasperreports/demos-setup/
description: "Aspose.Slides for JasperReports डाउनलोड से डेमो प्रोजेक्ट सेट अप करें, वे जिस एक्सपोर्टर क्लास का उपयोग करते हैं उसे बदलें, और उन्हें Ant के साथ बनाएं।"
---
## **डेमो क्या हैं**

Aspose.Slides for JasperReports डाउनलोड के *samples* फ़ोल्डर में आठ डेमो प्रोजेक्ट हैं: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* और *xmldatasource*। ये मानक JasperReports डेमो हैं, जिन्हें एक `ppt` बिल्ड टार्गेट जोड़ने के लिए बदला गया है जो भरे हुए रिपोर्ट को PPT में निर्यात करता है। डाउनलोड में कोई निर्यातित प्रेजेंटेशन नहीं होता; आप उन्हें डेमो बनाकर उत्पन्न करते हैं।

## **बिल्ड करने से पहले एक्सपोर्टर क्लास बदलें**

जैसे ही दिया गया है, डेमो का Java कोड `com.aspose.slides.jasperreports.JRPptExporter` का उपयोग करता है, जो वर्तमान jar फ़ाइलों में नहीं है, इसलिए डेमो संकलित नहीं होते। डेमो के एप्लिकेशन क्लास में (उदाहरण के लिए, *shapes* डेमो में *ShapesApp.java*), `JRPptExporter` को `ASPptExporter` से बदलें, जो उसी पैकेज में PPT एक्सपोर्टर है। *fonts* डेमो पूरे पैकेज को इम्पोर्ट करता है, इसलिए केवल कोड में क्लास नाम बदलता है।

डेमो JasperReports के उन क्लासों का भी उपयोग करते हैं जिन्हें बाद के JasperReports संस्करणों ने हटा दिया, जैसे `JExcelApiExporter` और `JRExporterParameter.FONT_MAP`। ऊपर बताए परिवर्तन के साथ, डेमो इस प्रकार संकलित होते हैं:

| JasperReports संस्करण | संकलित होने वाले डेमो |
| :- | :- |
| 5.5.1 | सभी आठ |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **डेमो बनाएं**

प्रत्येक डेमो का *build.xml* JasperReports प्रोजेक्ट की फ़ोल्डर संरचना की अपेक्षा करता है: यह *../../../build/classes* और *../../../lib* में स्थित jar फ़ाइलों के विरुद्ध संकलित होता है, जो डेमो फ़ोल्डर के सापेक्ष हैं।

1. डेमो फ़ोल्डर को अपने JasperReports प्रोजेक्ट फ़ोल्डर में *demo/samples* में कॉपी करें।
2. डाउनलोड के *lib* उपफ़ोल्डर से *aspose.slides.jasperreports.library-xx.x.jar* को, जो आपके JasperReports संस्करण के अनुरूप है, JasperReports प्रोजेक्ट के *lib* फ़ोल्डर में कॉपी करें। देखें [Installing Aspose.Slides for JasperReports](/slides/hi/jasperreports/installing-aspose-slides-for-jasperreports/)।
3. अपने JasperReports संस्करण की jar और उसकी निर्भरता वाली jar फ़ाइलें उसी *lib* फ़ोल्डर में रखें। डेमो फ़ाइलों के अलावा, *build.xml* केवल *build/classes* और *lib* के अंतर्गत jar फ़ाइलों को क्लासपाथ में जोड़ता है, और *build/classes* में केवल JasperReports क्लासेज़ तब होते हैं जब आप स्रोत से JasperReports को संकलित करते हैं।
4. *charts*, *subreport* और *text* डेमो JasperReports के HSQLDB सैंपल डेटाबेस (`jdbc:hsqldb:hsql://localhost`) को पढ़ते हैं, इसलिए डाउनलोड के *samples/Readme.txt* में बताई गई तरह पहले उसका सर्वर शुरू करें। अन्य डेमो को डेटाबेस की आवश्यकता नहीं है।
5. डेमो फ़ोल्डर में, एप्लिकेशन को संकलित करें, रिपोर्ट डिज़ाइन को संकलित करें, उसे भरें, और PPT में निर्यात करें:

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` टार्गेट भरे हुए रिपोर्ट के साथ-साथ प्रस्तुति फ़ाइल लिखता है, जिसका नाम रिपोर्ट के समान होता है (उदाहरण के लिए, *LandscapeReport.ppt*)।

दो डेमो को ऊपर बताए गए चरणों से अधिक की आवश्यकता होती है:

- *images* डेमो निर्यात करते समय `http://jasperreports.sourceforge.net/jasperreports.png` से एक चित्र लोड करता है। यह पता अब HTTPS पर रीडायरेक्ट करता है, इसलिए *ImagesReport.jrxml* में पते को `https://` में बदलने तक `ppt` चरण कोई प्रस्तुति नहीं लिखता। JasperReports 6.4.0 के साथ, HTTPS पर भी उस चित्र का निर्यात विफल हो जाता है।
- *xmldatasource* रिपोर्ट Arial फ़ॉन्ट का उपयोग करती है। यदि सिस्टम में Arial उपलब्ध नहीं है, तो `ant fill` यह संदेश देता है कि फ़ॉन्ट "JVM के लिए उपलब्ध नहीं है" और कोई भरा हुआ रिपोर्ट नहीं बनाता, इसलिए `ant ppt` निर्यात करने के लिए कुछ नहीं पाता। बिल्ड फिर भी सफलता की रिपोर्ट देता है, इसलिए प्रत्येक चरण के आउटपुट की जाँच करें।