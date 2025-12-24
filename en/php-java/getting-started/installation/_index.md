---
title: Installation
type: docs
weight: 70
url: /php-java/installation/
keywords:
- install Aspose.Slides
- download Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Quickly install Aspose.Slides for PHP via Java. Step-by-step guide, system requirements, and code samples — start working with PowerPoint presentations today!"
---

## **Configure Environment**

1. Install PHP 7, add the PHP path to the system `PATH` variable and set `allow_url_include` to `On` in the `php.ini` file.
1. Install JRE 8. Set the `JAVA_HOME` environment variable to the path of the installed JRE.
1. Install Apache Tomcat 8.0.

## **Download Aspose.Slides for PHP via Java** 

`packagist` is the easiest way to download [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

To install Aspose.Slides using Packagist, run this command: 
   ```bash
   composer require aspose/slides
   ```

## **Configure Apache Tomcat**

1. Download PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) from http://php-java-bridge.sourceforge.net/pjb/download.php and extract `JavaBridge.war` file to tomcat `webapps` folder.
1. Start Apache Tomcat service.
1. Download [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) and extract it to `aspose.slides` folder. Copy `jar/aspose-slides-x.x-php.jar` file to `webapps\JavaBridge\WEB-INF\lib` folder. If you are using **PHP 8**, replace the original `Java.inc` from PHP-Java Bridge with the `Java.inc` from `Java.inc.php8.zip`.
1. Restart Apache Tomcat service.
1. Run `example.php` in `aspose.slides` folder to run the example with this command:
   ```bash
   php example.php
   ```

## **FAQ**

**How can I verify that Aspose.Slides is integrated correctly?**

Build your project, instantiate a blank [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) and save it under a new name. If the file is created without throwing exceptions, the library has been integrated successfully.

**How can I limit memory consumption when processing large presentations?**

Raise JVM memory limits only as high as needed, and close each [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance in a `finally` block to release the cache promptly. This prevents out‑of‑memory errors and keeps overall memory usage predictable during batch operations.

**Can I exclude unwanted export formats to shrink the final JAR size?**

Current Aspose.Slides releases are shipped as a single monolithic library, so you cannot disable specific exporters such as PDF or SVG at build time.
