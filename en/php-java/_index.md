---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /php-java/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Start here: install Aspose.Slides for PHP via Java, create a first presentation, and find the guides for common tasks, the API reference and support."
is_root: true
---

<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java is a class library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in PHP applications, without Microsoft PowerPoint or Office Automation.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/php-java/installation/">Installation</a></li>
<li><a href="/slides/php-java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/php-java/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/php-java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/php-java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/php-java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/php-java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/php-java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/php-java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/php-java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/php-java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/php-java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/php-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/php-java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/php-java/presentation-design/">Slide design</a></li>
<li><a href="/slides/php-java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/php-java/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Release notes</a></li>
<li><a href="/slides/php-java/known-issues/">Known issues</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Aspose.Slides for PHP via Java runs on Java inside Apache Tomcat, and your PHP scripts reach it through PHP/Java Bridge. [Installation](/slides/php-java/installation/) sets up PHP 8.3 or earlier, Java, Tomcat and the bridge, and then installs the package from Packagist in a project folder:

```bash
composer require aspose/slides
```

Then copy the package's JAR file into the bridge and restart Tomcat, as in step 4 of [Install on Linux](/slides/php-java/installation/#install-on-linux) or step 6 of [Install on Windows](/slides/php-java/installation/#install-on-windows). With Tomcat running, save this script as *hello.php* in the project folder and run `php hello.php`:

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

The script saves *hello.pptx* next to itself, with one slide holding a text box. Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/php-java/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/php-java/create-presentation/).
