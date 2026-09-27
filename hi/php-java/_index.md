---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /hi/php-java/
keywords:
- प्रलेखन
- प्रस्तुति प्रसंस्करण
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "शुरू करें: Aspose.Slides for PHP via Java स्थापित करें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों, API संदर्भ और समर्थन के लिए मार्गदर्शिकाएँ खोजें।"
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java एक क्लास लाइब्रेरी है जो PHP अनुप्रयोगों में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और रूपांतरित करने के लिए उपयोग की जाती है, बिना Microsoft PowerPoint या Office Automation के।

यह PPT, PPTX, PPS, POT और ODP फ़ाइलें लोड और सहेजता है, जिसमें मैक्रो‑सक्षम और टेम्प्लेट वेरिएंट शामिल हैं, तथा PDF, XPS, HTML, SVG, TIFF, Markdown और इमेजेज़ में एक्सपोर्ट करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरूआत</p>
<ul>
<li><a href="/slides/hi/php-java/installation/">स्थापना</a></li>
<li><a href="/slides/hi/php-java/create-presentation/">अपनी पहली प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/php-java/getting-started/">शुरूआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/php-java/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/php-java/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/php-java/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/php-java/open-presentation/">एक प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/php-java/save-presentation/">एक प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/php-java/convert-powerpoint-to-pdf/">PDF में बदलें</a></li>
<li><a href="/slides/hi/php-java/convert-slide/">स्लाइड को इमेजेज़ के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/php-java/manage-text/">टेक्स्ट और आकार संपादित करें</a></li>
</ul>
<p>Slides वर्कफ़्लो</p>
<ul>
<li><a href="/slides/hi/php-java/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/php-java/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/php-java/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/php-java/presentation-design/">स्लाइड डिजाइन</a></li>
<li><a href="/slides/hi/php-java/merge-presentation/">प्रस्तुतियों को मिलाएं</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/php-java/examples/">स्लाइड एलेमेंट द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/php-java/known-issues/">ज्ञात समस्याएं</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">मुफ़्त समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">सशुल्क समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

Aspose.Slides for PHP via Java Apache Tomcat के भीतर Java पर चलता है, और आपके PHP स्क्रिप्ट्स इसे PHP/Java Bridge के माध्यम से पहुंचते हैं। [स्थापना](/slides/hi/php-java/installation/) PHP 8.3 या उससे पहले, Java, Tomcat और ब्रिज को सेटअप करता है, और फिर Packagist से पैकेज को प्रोजेक्ट फ़ोल्डर में इंस्टॉल करता है:

```bash
composer require aspose/slides
```

फिर पैकेज की JAR फ़ाइल को ब्रिज में कॉपी करें और Tomcat को पुनः प्रारंभ करें, जैसे कि [Linux पर इंस्टॉल](/slides/hi/php-java/installation/#install-on-linux) के चरण 4 में या [Windows पर इंस्टॉल](/slides/hi/php-java/installation/#install-on-windows) के चरण 6 में बताया गया है। Tomcat चल रहा हो तो इस स्क्रिप्ट को प्रोजेक्ट फ़ोल्डर में *hello.php* के रूप में सहेजें और `php hello.php` चलाएँ:

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

स्क्रिप्ट *hello.pptx* को खुद के पास सहेजता है, जिसमें एक स्लाइड में टेक्स्ट बॉक्स होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में एक मूल्यांकन वाटरमार्क होता है — देखें [लाइसेंसिंग](/slides/hi/php-java/licensing/). अधिक तरीकों से प्रस्तुति बनाना और भरना जानने के लिए देखें [प्रस्तुति बनाएं](/slides/hi/php-java/create-presentation/).