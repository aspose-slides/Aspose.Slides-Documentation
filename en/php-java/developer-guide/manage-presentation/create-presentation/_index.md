---
title: Create Presentations in PHP
linktitle: Create Presentation
type: docs
weight: 10
url: /php-java/create-presentation/
keywords:
- create presentation
- new presentation
- create PPT
- new PPT
- create PPTX
- new PPTX
- create ODP
- new ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Create presentations with Aspose.Slides for PHP via Java — produce PPT, PPTX, and ODP files and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation in Aspose.Slides, add a text box to its first slide, and save the result as a file. It also shows how to create and save an empty presentation, and how to open an existing presentation in a supported format and save it in another format. A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, install Aspose.Slides for PHP via Java with Composer and start PHP/Java Bridge in Apache Tomcat. See [Installation](/slides/php-java/installation/) for the complete setup. The examples below expect Tomcat to be running on `localhost:8080` and the Composer `vendor` folder to be next to the script.

## **Create a PowerPoint Presentation**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the collection returned by [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), by its index, 0.
1. Add a rectangle with the [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) method and set its text with [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).
1. Save the presentation as a PPTX file with the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) method.

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

The two `require_once` lines load the PHP/Java Bridge client from Tomcat and the Aspose.Slides classes from the Composer package. The rectangle's top-left corner is 50 points from the left edge and 50 points from the top edge of the slide, and the rectangle is 400 points wide and 100 points high. The saved file contains one slide with that rectangle and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/php-java/licensing/).

{{% alert color="info" title="Note" %}}

Aspose.Slides reads and writes files inside Tomcat, not in your PHP process, so a relative path such as `"hello.pptx"` is resolved against Tomcat's working folder. The examples on this page build absolute paths with `__DIR__`, so the files are read from and saved next to the script.

{{% /alert %}}

## **Create and Save a Presentation**

To create an empty presentation and save it, create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and save it in any format of the [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) enumeration. The result is a presentation with one empty slide.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Open and Save a Presentation**

To convert a presentation from one format to another, open it by passing its path to the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) constructor, then save it in the target format. Aspose.Slides detects the input format, such as PPT, PPTX, or ODP, from the file itself.

The example below expects an OpenDocument presentation named *Sample.odp* next to the script and saves it as PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/php-java/save-presentation/), and export to [PDF](/slides/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/php-java/convert-powerpoint-to-xps/), [HTML](/slides/php-java/convert-powerpoint-to-html/), [SVG](/slides/php-java/render-a-slide-as-an-svg-image/), and [images](/slides/php-java/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/php-java/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/php-java/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/php-java/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance from [multiple threads](/slides/php-java/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/php-java/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/php-java/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/php-java/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
