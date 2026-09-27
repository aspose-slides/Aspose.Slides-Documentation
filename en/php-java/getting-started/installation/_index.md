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
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Install Aspose.Slides for PHP via Java on Linux and Windows: set up PHP, Java, Apache Tomcat, and PHP/Java Bridge, add the package with Composer, and verify the setup with a short script."
---

## **Overview**

Aspose.Slides for PHP via Java runs in two processes. Your PHP script uses PHP classes that pass every call through PHP/Java Bridge to Aspose.Slides, which runs on Java inside Apache Tomcat. This article explains how to set up both sides, install the package with Composer, and run a short script to verify the installation.

## **Prerequisites**

- **PHP 7.0 to 8.3**, with `allow_url_include = On` in `php.ini`. Your scripts load the bridge's client library, `Java.inc`, from Tomcat over HTTP. On PHP 8.4 and later, `Java.inc` stops with the error "end() expects exactly 1 argument" whenever PHP's `xml` extension is loaded, and the Windows builds of PHP always load it.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 or later.** A JRE is enough.
- **Apache Tomcat 9.** PHP/Java Bridge is built on the `javax.servlet` API, which Tomcat 10 and later no longer provide, so the bridge does not start there.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, its latest release. Its web application, `JavaBridge.war`, runs in Tomcat.

This article runs Tomcat and your PHP scripts on the same computer. Aspose.Slides opens and saves files inside Tomcat, so every path that your scripts pass to it must be valid there.

## **Install on Linux**

These commands install everything in your home folder on Ubuntu 24.04. On other distributions, install the same packages with the distribution's package manager.

1. Install PHP, Composer, Java, and the download tools, then turn on `allow_url_include` for the PHP command line:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Download Apache Tomcat 9 and PHP/Java Bridge, put the bridge's `JavaBridge.war` into Tomcat's `webapps` folder, and start Tomcat. Tomcat unpacks the WAR file into `webapps/JavaBridge` as it starts:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Create a project folder and install Aspose.Slides for PHP via Java from [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Stop Tomcat, copy the Aspose.Slides JAR file from the package to the bridge's `WEB-INF/lib` folder, replace the bridge's `Java.inc` with the PHP 8 version from the package, and start Tomcat again:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   On PHP 7, skip the `Java.inc` replacement. Tomcat takes a few seconds to start, and it must be running whenever your scripts use Aspose.Slides.

## **Install on Windows**

1. Install [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) and add its folder to the `PATH` environment variable. Copy `php.ini-production` to `php.ini` in the same folder. In `php.ini`, set `allow_url_include = On` and uncomment the `extension_dir = "ext"`, `extension=openssl`, and `extension=zip` lines. Composer needs `openssl` to download packages, and `zip` to unpack them unless 7-Zip is installed or an `unzip` command is on `PATH`.
1. Install [Composer](https://getcomposer.org/download/).
1. Install Java and set the `JAVA_HOME` environment variable to its folder. Tomcat does not start without it.
1. In Command Prompt, download Apache Tomcat 9 and PHP/Java Bridge, put the bridge's `JavaBridge.war` into Tomcat's `webapps` folder, and start Tomcat. Tomcat's scripts find Tomcat through the `CATALINA_HOME` variable, so keep using the same Command Prompt window for the next steps. Tomcat unpacks the WAR file into `webapps\JavaBridge` as it starts:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Create a project folder and install Aspose.Slides for PHP via Java from [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Stop Tomcat, copy the Aspose.Slides JAR file from the package to the bridge's `WEB-INF\lib` folder, replace the bridge's `Java.inc` with the PHP 8 version from the package, and start Tomcat again:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   On PHP 7, skip the `Java.inc` replacement. Tomcat takes a few seconds to start, and it must be running whenever your scripts use Aspose.Slides.

## **Verify the Installation**

Save this script as *hello.php* in the project folder. It creates a presentation with one text box and saves it next to the script:

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

Run it from the project folder:

```bash
php hello.php
```

The script writes *hello.pptx*, with one slide that holds the text box. Without a license, the slide also carries an evaluation watermark; see [Licensing](/slides/php-java/licensing/).

The script includes `aspose.slides.php` directly: Composer's autoloader cannot load these classes, because they are all defined in that one file. It also passes an absolute path to `save`, because Aspose.Slides runs inside Tomcat and resolves a relative path against Tomcat's working folder, not your script's.

## **FAQ**

**How can I verify that Aspose.Slides is integrated correctly?**

Run the script in [Verify the Installation](#verify-the-installation). If it writes *hello.pptx* without errors, PHP, PHP/Java Bridge, and Aspose.Slides are working together.

**Why does my script stop with "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP could not load `Java.inc` from Tomcat. If the message before it says that the `http://` wrapper is disabled, set `allow_url_include = On` in the `php.ini` file that your PHP command line loads; `php --ini` shows which file that is. If it says "Connection refused", Tomcat is not running yet: start it, or wait a few seconds until it has started.

**How can I limit memory consumption when processing large presentations?**

Raise JVM memory limits only as high as needed, and close each [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance in a `finally` block to release the cache promptly. This prevents out‑of‑memory errors and keeps overall memory usage predictable during batch operations.

**Can I exclude unwanted export formats to shrink the final JAR size?**

Current Aspose.Slides releases are shipped as a single monolithic library, so you cannot disable specific exporters such as PDF or SVG at build time.
