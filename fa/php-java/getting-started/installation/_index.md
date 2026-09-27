---
title: نصب
type: docs
weight: 70
url: /fa/php-java/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- لینوکس
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "نصب Aspose.Slides برای PHP از طریق Java بر روی لینوکس و ویندوز: تنظیم PHP، Java، Apache Tomcat و PHP/Java Bridge، افزودن بسته با Composer، و تأیید تنظیمات با یک اسکریپت کوتاه."
---
## **Overview**

Aspose.Slides for PHP via Java در دو فرآیند اجرا می‌شود. اسکریپت PHP شما از کلاس‌های PHP استفاده می‌کند که هر فراخوانی را از طریق PHP/Java Bridge به Aspose.Slides می‌فرستند؛ این کتابخانه روی Java داخل Apache Tomcat اجرا می‌شود. این مقاله نحوه پیکربندی هر دو طرف، نصب بسته با Composer و اجرای یک اسکریپت کوتاه برای تأیید نصب را توضیح می‌دهد.

## **Prerequisites**

- **PHP 7.0 تا 8.3**، با `allow_url_include = On` در `php.ini`. اسکریپت‌های شما کتابخانه مشتری پل، `Java.inc` را از Tomcat از طریق HTTP بارگذاری می‌کنند. در PHP 8.4 و بالاتر، `Java.inc` با خطای «end() expects exactly 1 argument» متوقف می‌شود هر زمان که افزونه `xml` PHP بارگذاری شود و نسخه‌های ویندوز PHP همیشه آن را بارگذاری می‌کند.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 یا بالاتر.** یک JRE کافی است.
- **Apache Tomcat 9.** PHP/Java Bridge بر پایه API `javax.servlet` ساخته شده است؛ Tomcat 10 و بالاتر این API را ارائه نمی‌دهند، بنابراین پل در آنجا اجرا نمی‌شود.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**، آخرین نسخه منتشر شده. برنامه وب آن، `JavaBridge.war`، در Tomcat اجرا می‌شود.

این مقاله Tomcat و اسکریپت‌های PHP شما را بر روی همان کامپیوتر اجرا می‌کند. Aspose.Slides فایل‌ها را داخل Tomcat باز و ذخیره می‌کند، بنابراین هر مسیری که اسکریپت‌های شما به آن می‌دهند باید در آنجا معتبر باشد.

## **Install on Linux**

این دستورات همه چیز را در پوشهٔ خانگی شما بر روی Ubuntu 24.04 نصب می‌کند. در توزیع‌های دیگر، بسته‌های مشابه را با مدیر بستهٔ توزیع نصب کنید.

1. PHP، Composer، Java و ابزارهای دانلود را نصب کنید، سپس برای خط فرمان PHP `allow_url_include` را فعال کنید:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Apache Tomcat 9 و PHP/Java Bridge را دانلود کنید، `JavaBridge.war` پل را در پوشهٔ `webapps` Tomcat قرار دهید و Tomcat را راه‌اندازی کنید. Tomcat فایل WAR را هنگام شروع به `webapps/JavaBridge` استخراج می‌کند:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. یک پوشهٔ پروژه ایجاد کنید و Aspose.Slides for PHP via Java را از [Packagist](https://packagist.org/packages/aspose/slides) نصب کنید:

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Tomcat را متوقف کنید، فایل JAR Aspose.Slides را از بسته به پوشهٔ `WEB-INF/lib` پل کپی کنید، `Java.inc` پل را با نسخهٔ PHP 8 موجود در بسته جایگزین کنید و دوباره Tomcat را راه‌اندازی کنید:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/fa/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/fa/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   در PHP 7، جایگزینی `Java.inc` را نادیده بگیرید. Tomcat چند ثانیه طول می‌کشد تا شروع شود و هر زمان که اسکریپت‌های شما از Aspose.Slides استفاده می‌کنند باید در حال اجرا باشد.

## **Install on Windows**

1. [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) را نصب کنید و پوشهٔ آن را به متغیر محیطی `PATH` اضافه کنید. `php.ini-production` را به `php.ini` در همان پوشه کپی کنید. در `php.ini` مقدار `allow_url_include = On` را تنظیم کنید و خطوط `extension_dir = "ext"`, `extension=openssl`, و `extension=zip` را از حالت کامنت خارج کنید. Composer برای دانلود بسته‌ها به `openssl` نیاز دارد و برای استخراج آن‌ها به `zip` یا 7‑Zip یا دستور `unzip` روی `PATH` نیاز است.
2. [Composer](https://getcomposer.org/download/) را نصب کنید.
3. Java را نصب کنید و متغیر محیطی `JAVA_HOME` را به پوشهٔ آن تنظیم کنید. بدون این متغیر Tomcat راه‌اندازی نخواهد شد.
4. در Command Prompt، Apache Tomcat 9 و PHP/Java Bridge را دانلود کنید، `JavaBridge.war` پل را در پوشهٔ `webapps` Tomcat قرار دهید و Tomcat را راه‌اندازی کنید. اسکریپت‌های Tomcat مسیر Tomcat را از متغیر `CATALINA_HOME` می‌خوانند، بنابراین برای مراحل بعدی از همان پنجرهٔ Command Prompt استفاده کنید. Tomcat هنگام شروع فایل WAR را به `webapps\JavaBridge` استخراج می‌کند:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. یک پوشهٔ پروژه ایجاد کنید و Aspose.Slides for PHP via Java را از [Packagist](https://packagist.org/packages/aspose/slides) نصب کنید:

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Tomcat را متوقف کنید، فایل JAR Aspose.Slides را از بسته به پوشهٔ `WEB-INF\lib` پل کپی کنید، `Java.inc` پل را با نسخهٔ PHP 8 موجود در بسته جایگزین کنید و دوباره Tomcat را راه‌اندازی کنید:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   در PHP 7، جایگزینی `Java.inc` را انجام ندهید. Tomcat چند ثانیه زمان می‌برد تا شروع شود و باید هر زمانی که اسکریپت‌های شما از Aspose.Slides استفاده می‌کنند در حال اجرا باشد.

## **Verify the Installation**

این اسکریپت را با نام *hello.php* در پوشهٔ پروژه ذخیره کنید. یک ارائه با یک جعبهٔ متن ایجاد می‌کند و در کنار اسکریپت ذخیره می‌شود:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fa/lib/aspose.slides.php");

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

اسکریپت را از پوشهٔ پروژه اجرا کنید:

```bash
php hello.php
```

اسکریپت فایل *hello.pptx* را می‌نویسد؛ این فایل یک اسلاید دارد که جعبهٔ متن در آن قرار دارد. بدون لایسنس، اسلاید همچنین دارای واترمارک ارزیابی است؛ به [Licensing](/slides/fa/php-java/licensing/) مراجعه کنید.

اسکریپت `aspose.slides.php` را به‌صورت مستقیم شامل می‌شود: بارگذاری‌کنندهٔ Composer قادر به بارگذاری این کلاس‌ها نیست، زیرا همهٔ آن‌ها در یک فایل تعریف شده‌اند. همچنین مسیر مطلق به `save` منتقل می‌شود، زیرا Aspose.Slides داخل Tomcat اجرا می‌شود و مسیرهای نسبی را نسبت به پوشهٔ کاری Tomcat حل می‌کند، نه نسبت به اسکریپت شما.

## **FAQ**

**چگونه می‌توانم تأیید کنم که Aspose.Slides به‌درستی ادغام شده است؟**

اسکریپت در بخش [Verify the Installation](#verify-the-installation) را اجرا کنید. اگر بدون خطا فایل *hello.pptx* تولید شد، PHP، PHP/Java Bridge و Aspose.Slides به‌درستی با هم کار می‌کنند.

**چرا اسکریپتم با پیام «Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'» متوقف می‌شود؟**

PHP نتوانست `Java.inc` را از Tomcat بارگذاری کند. اگر پیش از آن پیام می‌گوید wrapper `http://` غیرفعال است، در فایلی که خط فرمان PHP شما بارگذاری می‌کند `allow_url_include = On` تنظیم کنید؛ `php --ini` نشان می‌دهد کدام فایل بارگذاری می‌شود. اگر پیام «Connection refused» را دریافت کردید، Tomcat هنوز کار نمی‌کند: آن را راه‌اندازی کنید یا چند ثانیه صبر کنید تا شروع شود.

**چگونه می‌توان مصرف حافظه را هنگام پردازش ارائه‌های بزرگ محدود کرد؟**

حدود حافظهٔ JVM را فقط به اندازهٔ لازم افزایش دهید و هر نمونهٔ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) را در بلوک `finally` بستن تا کش به‌سرعت آزاد شود. این کار از خطاهای «out‑of‑memory» جلوگیری می‌کند و مصرف کلی حافظه را در عملیات دسته‌ای پیش‌بینی‌پذیر می‌سازد.

**آیا می‌توان فرمت‌های خروجی ناخواسته را برای کوچک کردن اندازهٔ نهایی JAR حذف کرد؟**

نسخه‌های فعلی Aspose.Slides به‌صورت یک کتابخانهٔ تک‌پاره توزیع می‌شوند؛ بنابراین نمی‌توانید هنگام ساخت، خروجی‌های خاصی مانند PDF یا SVG را غیرفعال کنید.