---
title: PHP में प्रस्तुतियाँ बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/php-java/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नई प्रस्तुति
- PPT बनाएं
- नया PPT
- PPTX बनाएं
- नया PPTX
- ODP बनाएं
- नया ODP
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके प्रस्तुतियों को बनाएं — PPT, PPTX, और ODP फ़ाइलें उत्पन्न करें और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिकली सहेजें।"
---
## **सारांश**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनाई जाए, उसकी पहली स्लाइड में टेक्स्ट बॉक्स कैसे जोड़ा जाए, और परिणाम को फ़ाइल के रूप में कैसे सहेजा जाए। यह यह भी दिखाता है कि खाली प्रस्तुति कैसे बनाई और सहेजी जाए, तथा समर्थित फ़ॉर्मेट में मौजूदा प्रस्तुति को कैसे खोला जाए और किसी अन्य फ़ॉर्मेट में सहेजा जाए। अंत में एक संक्षिप्त FAQ सामान्य प्रश्नों जैसे फ़ॉर्मेट, टेम्पलेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर और VBA समर्थन को कवर करता है।

शुरू करने से पहले, Composer के माध्यम से PHP के लिए Aspose.Slides for Java स्थापित करें और Apache Tomcat में PHP/Java Bridge चालू करें। पूर्ण सेटअप के लिए [स्थापना](/slides/hi/php-java/installation/) देखें। नीचे के उदाहरण मानते हैं कि Tomcat `localhost:8080` पर चल रहा है और Composer `vendor` फ़ोल्डर स्क्रिप्ट के पास स्थित है।

## **PowerPoint प्रस्तुति बनाएं**

एक प्रस्तुति बनाकर उसकी पहली स्लाइड पर टेक्स्ट बॉक्स रखने के लिए निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ। नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
1. उस स्लाइड को प्राप्त करें जो [Presentation::getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getslides/) द्वारा लौटाए गए कलेक्शन में इंडेक्स 0 के द्वारा उपलब्ध है।
1. [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addautoshape/) मेथड से एक आयत जोड़ें और उसके टेक्स्ट को [TextFrame::setText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/settext/) से सेट करें।
1. प्रस्तुति को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/save/) मेथड से PPTX फ़ाइल के रूप में सहेजें।

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

दो `require_once` पंक्तियाँ Tomcat से PHP/Java Bridge क्लाइंट और Composer पैकेज से Aspose.Slides क्लासेस को लोड करती हैं। आयत का ऊपर‑बाएँ कोना स्लाइड के बाएँ किनारे से 50 पॉइंट और ऊपर के किनारे से 50 पॉइंट दूर है, और आयत की चौड़ाई 400 पॉइंट तथा ऊँचाई 100 पॉइंट है। सहेजी गई फ़ाइल में वह आयत और उसका टेक्स्ट वाली एक स्लाइड होती है। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में मूल्यांकन वॉटरमार्क जोड़ता है; देखें [लाइसेंसिंग](/slides/hi/php-java/licensing/)।

{{% alert color="info" title="Note" %}}

Aspose.Slides फ़ाइलों को Tomcat के भीतर पढ़ता और लिखता है, न कि आपके PHP प्रोसेस में, इसलिए `"hello.pptx"` जैसे रिलेटिव पाथ को Tomcat के कार्यशील फ़ोल्डर के संदर्भ में हल किया जाता है। इस पृष्ठ के उदाहरण `__DIR__` के साथ पूर्ण पाथ बनाते हैं, ताकि फ़ाइलें स्क्रिप्ट के पास पढ़ी और सहेजी जा सकें।

{{% /alert %}}

## **एक प्रस्तुति बनाकर सहेजें**

एक खाली प्रस्तुति बनाकर उसे सहेजने के लिए, [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं और उसे [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) एनेमरेशन के किसी भी फ़ॉर्मेट में सहेजें। परिणामस्वरूप एक खाली स्लाइड वाली प्रस्तुति प्राप्त होगी।

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एक प्रस्तुति खोलें और सहेजें**

एक प्रस्तुति को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदलने के लिए, उसके पाथ को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कंस्ट्रक्टर में पास करके खोलें, फिर लक्षित फ़ॉर्मेट में सहेजें। Aspose.Slides फ़ाइल स्वयं से इनपुट फ़ॉर्मेट (जैसे PPT, PPTX या ODP) का पता लगाता है।

नीचे का उदाहरण स्क्रिप्ट के पास स्थित *Sample.odp* नामक OpenDocument प्रस्तुति को अपेक्षित करता है और उसे PPTX के रूप में सहेजता है।

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### नई प्रस्तुति को किन फ़ॉर्मेट में सहेजा जा सकता है?

आप [PPTX, PPT, और ODP](/slides/hi/php-java/save-presentation/) में सहेज सकते हैं, तथा [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/php-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/php-java/convert-powerpoint-to-html/), [SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) और [छवियों](/slides/hi/php-java/convert-powerpoint-to-png/) जैसे अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

### क्या मैं टेम्पलेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?

हां। टेम्पलेट को लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/php-java/supported-file-formats/) हैं।

### प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो कैसे नियंत्रित करूँ?

[स्लाइड आकार](/slides/hi/php-java/slide-size/) सेट करें (जैसे 4:3, 16:9 प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और निर्देशांक किस इकाई में मापे जाते हैं?

पॉइंट्स में: 1 इंच बराबर 72 यूनिट।

### बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB प्रबंधन रणनीतियों](/slides/hi/php-java/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी भंडारण को सीमित करें, और केवल इन‑मेमोरी स्ट्रीम के बजाय फ़ाइल‑आधारित कार्यप्रवाह को प्राथमिकता दें।

### क्या मैं समानांतर में प्रस्तुतियों को बना/सहेज सकता हूँ?

आप एक ही [Presentation](/slides/hi/php-java/multithreading/) इंस्टेंस को [एकाधिक थ्रेड](/slides/hi/php-java/multithreading/) से नहीं चला सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग-अलग, अलग‑थलग इंस्टेंस चलाएँ।

### परीक्षण वॉटरमार्क और सीमाओं को कैसे हटाऊँ?

प्रति प्रोसेस एक बार [लाइसेंस लागू](/slides/hi/php-java/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखना आवश्यक है, और यदि कई थ्रेड शामिल हैं तो लाइसेंस सेटअप को समन्वयित करें।

### क्या मैं बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?

हां। [डिजिटल हस्ताक्षर](/slides/hi/php-java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

### क्या बनायी गई प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हां। आप [VBA प्रोजेक्ट बनाना/संपादित करना](/slides/hi/php-java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसी मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।