---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /hi/php-java/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रोसेसिंग
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for PHP via Java स्थापित करें, पहला प्रस्तुतीकरण बनाएँ, और सामान्य कार्यों के मार्गदर्शक, API संदर्भ और समर्थन खोजें।"
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java PHP अनुप्रयोगों में PowerPoint और OpenDocument प्रस्तुति को बनाने, पढ़ने, संपादित करने और रूपांतरित करने के लिए एक क्लास लाइब्रेरी है, बिना Microsoft PowerPoint या Office Automation के।

यह PPT, PPTX, PPS, POT और ODP को लोड और सेव करता है, जिसमें मैक्रो‑सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown तथा छवियों में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरुआत कैसे करें</p>
<ul>
<li><a href="/slides/hi/php-java/installation/">स्थापना</a></li>
<li><a href="/slides/hi/php-java/create-presentation/">अपना पहला प्रस्तुतीकरण बनाएँ</a></li>
<li><a href="/slides/hi/php-java/getting-started/">शुरुआती गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/php-java/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/php-java/evaluate-aspose-slides/">परीक्षण सीमाएँ</a></li>
<li><a href="/slides/hi/php-java/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/php-java/open-presentation/">प्रस्तुतीकरण खोलें</a></li>
<li><a href="/slides/hi/php-java/save-presentation/">प्रस्तुतीकरण सहेजें</a></li>
<li><a href="/slides/hi/php-java/convert-powerpoint-to-pdf/">PDF में रूपांतरित करें</a></li>
<li><a href="/slides/hi/php-java/convert-slide/">स्लाइड को छवि के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/php-java/manage-text/">पाठ और आकृतियों को संपादित करें</a></li>
</ul>
<p>Slides वर्कफ़्लो</p>
<ul>
<li><a href="/slides/hi/php-java/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/php-java/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/php-java/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/php-java/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/php-java/merge-presentation/">प्रस्तुतीकरण मिलाएँ</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/php-java/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">रिलीज नोट्स</a></li>
<li><a href="/slides/hi/php-java/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">उत्पाद पृष्ठ</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">नि:शुल्क समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतानित समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपका पहला प्रस्तुतीकरण**

Aspose.Slides for PHP via Java Java के भीतर Apache Tomcat पर चलता है, और आपके PHP स्क्रिप्ट PHP/Java Bridge के माध्यम से इसे पहुंचते हैं। [स्थापना](/slides/hi/php-java/installation/) PHP 8.3 या उससे पहले, Java, Tomcat तथा ब्रिज को सेटअप करता है, और फिर Packagist से पैकेज को प्रोजेक्ट फ़ोल्डर में इंस्टॉल करता है:

```bash
composer require aspose/slides
```

फिर पैकेज की JAR फ़ाइल को ब्रिज में कॉपी करें और Tomcat को रीस्टार्ट करें, जैसा कि [Linux पर इंस्टॉल](/slides/hi/php-java/installation/#install-on-linux) के चरण 4 या [Windows पर इंस्टॉल](/slides/hi/php-java/installation/#install-on-windows) के चरण 6 में दर्शाया गया है। Tomcat चल रहा हो, तो इस स्क्रिप्ट को *hello.php* नाम से प्रोजेक्ट फ़ोल्डर में सहेजें और `php hello.php` चलाएँ:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

इस स्क्रिप्ट से *hello.pptx* स्वयं के साथ ही सहेजा जाता है, जिसमें एक स्लाइड पर टेक्स्ट बॉक्स रहता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वाटरमार्क जुड़ा रहता है — देखें [लाइसेंसिंग](/slides/hi/php-java/licensing/). प्रस्तुतीकरण बनाने और भरने के और तरीकों के लिए देखें [प्रस्तुतीकरण बनाएं](/slides/hi/php-java/create-presentation/).