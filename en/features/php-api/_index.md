---
title: Use Slides from PHP
description: Process presentations from PHP using the Java-backed Slides library.
type: docs
url: /features/php-api/
weight: 400
feature_id: php-api
feature_group: languages
translationKey: slides-feature-php-api
feature_catalogue_version: 3
feature_guides:
- /slides/php-java/installation/
---

## **Overview**

Use the PHP via Java binding to access presentation creation, editing and rendering from a PHP application. It uses the Java library underneath, so deployment includes both the PHP environment and the Java runtime required by the binding.

## **Usage example**

This example uses **Aspose.Slides for PHP via Java** with the documented PHP-to-Java bridge. First complete the [installation guide](/slides/php-java/installation/), including the Composer package, bridge server and PHP configuration. Save this script beside the project's *vendor* folder and run it with PHP. It creates a slide and writes *hello.pptx* beside the script.

```php
<?php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $title = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $title->getTextFrame()->setText("Hello from PHP");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The absolute output path is important: the Java process opens and saves the files, so it must be able to access that directory. The coordinates and dimensions are in points. Evaluation output also carries a watermark.

## **FAQ**

### **Is this a native PHP extension?**

It is a PHP binding to the Java library. Follow the PHP via Java setup guide for the bridge and runtime configuration.

### **Why does PHP via Java need a Java runtime?**

The PHP classes forward calls through the PHP-to-Java bridge to the presentation library running in the JVM. Configure both environments using the [installation guide](/slides/php-java/installation/); PHP alone does not provide the presentation engine.

### **Where should I configure the PHP-to-Java bridge?**

Configure it in the PHP environment and the bridge server before running presentation scripts. The [installation guide](/slides/php-java/installation/) covers the PHP include setting, bridge endpoint and Java-side library placement. Paths passed to the library must be accessible to that Java process.

## **Guides**

- [Installation (PHP via Java)](/slides/php-java/installation/)
