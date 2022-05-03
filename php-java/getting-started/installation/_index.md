---
title: Installation
type: docs
weight: 70
url: /php-java/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, PHP"
description: "Install Aspose.Slides for PHP via Java in Windows, Linux or macOS"
---

## **Configure environment**

1. Install PHP 7, add path to php\bin to system path variable and set `allow_url_include` to `On` in `php.ini` file.
1. Install JRE 8. Set the `JAVA_HOME` enviroment variable as a path to the installed JRE location.
1. Install Apache Tomcat 8.0.

## **Download Aspose.Slides for PHP via Java** 

`packagist` is the easiest way to download [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

To install Aspose.Slides using Packagist, run this command: `composer require aspose/slides`

## **Configure Apache Tomcat**

1. Download PHP/Java Bridge (php-java-bridge_x.x.x_documentation.zip) from http://php-java-bridge.sourceforge.net/pjb/download.php and extract `JavaBridge.war` file to tomcat `webapps` folder.
1. Start Apache Tomcat service.
1. Download [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) and extract it to aspose.slides folder. Copy `jar/aspose-slides-x.x-jdk16.jar` file to `webapps\JavaBridge\WEB-INF\lib` folder.
1. Restart Apache Tomcat service.
1. Run `example.php` in `aspose.slides` folder to run the example with this command:
```
php example.php
```
