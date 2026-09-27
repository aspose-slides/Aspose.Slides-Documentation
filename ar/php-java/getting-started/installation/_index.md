---
title: التثبيت
type: docs
weight: 70
url: /ar/php-java/installation/
keywords:
- تثبيت Aspose.Slides
- تحميل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تثبيت Aspose.Slides لبرمجة PHP عبر Java على لينكس وويندوز: إعداد PHP و Java و Apache Tomcat و PHP/Java Bridge، إضافة الحزمة باستخدام Composer، والتحقق من الإعداد باستخدام سكريبت قصير."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يعمل في عمليتين. يستخدم سكريبت PHP الخاص بك فئات PHP التي تمرر كل استدعاء عبر PHP/Java Bridge إلى Aspose.Slides، الذي يعمل على Java داخل Apache Tomcat. يشرح هذا المقال كيفية إعداد الجانبين، وتثبيت الحزمة باستخدام Composer، وتشغيل سكريبت قصير للتحقق من التثبيت.

## **المتطلبات المسبقة**

- **PHP 7.0 إلى 8.3**، مع `allow_url_include = On` في `php.ini`. تقوم السكريبتات الخاصة بك بتحميل مكتبة العميل للجسر، `Java.inc`، من Tomcat عبر HTTP. في PHP 8.4 وما بعده، يتوقف `Java.inc` مع الخطأ "end() expects exactly 1 argument" كلما تُحمَّل امتداد `xml` في PHP، وتقوم إصدارات Windows من PHP دائمًا بتحميله.
- **[Composer](https://getcomposer.org/)**
- **Java 8 أو أحدث**. JRE كافية.
- **Apache Tomcat 9**. تم بناء PHP/Java Bridge على واجهة برمجة التطبيقات `javax.servlet`، التي لم يعد Tomcat 10 وما بعده يوفرها، لذا لا يبدأ الجسر هناك.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**، أحدث إصداره. تطبيق الويب الخاص به، `JavaBridge.war`، يعمل في Tomcat.

هذا المقال يشغّل Tomcat وسكريبتات PHP الخاصة بك على نفس الحاسوب. يفتح Aspose.Slides ويحفظ الملفات داخل Tomcat، لذا يجب أن يكون كل مسار تمرره السكريبتات صالحًا هناك.

## **التثبيت على Linux**

هذه الأوامر تثبت كل شيء في مجلد المنزل لديك على Ubuntu 24.04. على التوزيعات الأخرى، قم بتثبيت نفس الحزم باستخدام مدير الحزم الخاص بالتوزيعة.

1. قم بتثبيت PHP و Composer و Java وأدوات التحميل، ثم فعّل `allow_url_include` لسطر أوامر PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. قم بتنزيل Apache Tomcat 9 و PHP/Java Bridge، ضع ملف `JavaBridge.war` الخاص بالجسر في مجلد `webapps` الخاص بـ Tomcat، ثم شغّل Tomcat. يقوم Tomcat بفك ملف WAR إلى `webapps/JavaBridge` عند بدء التشغيل:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. أنشئ مجلد مشروع وقم بتثبيت Aspose.Slides for PHP via Java من [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. أوقف Tomcat، انسخ ملف JAR الخاص بـ Aspose.Slides من الحزمة إلى مجلد `WEB-INF/lib` للجسر، استبدل `Java.inc` الخاص بالجسر بالإصدار المتوافق مع PHP 8 من الحزمة، ثم شغّل Tomcat مرة أخرى:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/ar/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/ar/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

في PHP 7، احذف استبدال `Java.inc`. يستغرق Tomcat بضع ثوانٍ للبدء، ويجب أن يكون قيد التشغيل كلما استخدمت السكريبتات الخاصة بك Aspose.Slides.

## **التثبيت على Windows**

1. قم بتثبيت [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) وأضف مجلده إلى متغير البيئة `PATH`. انسخ `php.ini-production` إلى `php.ini` في نفس المجلد. في `php.ini`، اضبط `allow_url_include = On` وأزل التعليق عن الأسطر `extension_dir = "ext"`، `extension=openssl`، و `extension=zip`. يحتاج Composer إلى `openssl` لتحميل الحزم، و `zip` لفك ضغطها ما لم يتم تثبيت 7‑Zip أو وجود أمر `unzip` في `PATH`.

2. قم بتثبيت [Composer](https://getcomposer.org/download/).

3. قم بتثبيت Java واضبط متغير البيئة `JAVA_HOME` على مجلده. لا يبدأ Tomcat بدونه.

4. في موجه الأوامر، قم بتنزيل Apache Tomcat 9 و PHP/Java Bridge، ضع ملف `JavaBridge.war` الخاص بالجسر في مجلد `webapps` الخاص بـ Tomcat، ثم شغّل Tomcat. تجد سكريبتات Tomcat Tomcat عبر المتغير `CATALINA_HOME`، لذا استمر باستخدام نافذة موجه الأوامر نفسها للخطوات التالية. يقوم Tomcat بفك ملف WAR إلى `webapps\JavaBridge` عند بدء التشغيل:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. أنشئ مجلد مشروع وقم بتثبيت Aspose.Slides for PHP via Java من [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. أوقف Tomcat، انسخ ملف JAR الخاص بـ Aspose.Slides من الحزمة إلى مجلد `WEB-INF\lib` للجسر، استبدل `Java.inc` الخاص بالجسر بالإصدار المتوافق مع PHP 8 من الحزمة، ثم شغّل Tomcat مرة أخرى:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

في PHP 7، احذف استبدال `Java.inc`. يستغرق Tomcat بضع ثوانٍ للبدء، ويجب أن يكون قيد التشغيل كلما استخدمت السكريبتات الخاصة بك Aspose.Slides.

## **تحقق من التثبيت**

احفظ هذا السكريبت كملف *hello.php* في مجلد المشروع. ينشئ عرضًا تقديميًا يحتوي على صندوق نص واحد ويحفظه بجانب السكريبت:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ar/lib/aspose.slides.php");

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

شغّله من مجلد المشروع:

```bash
   php hello.php
```

يقوم السكريبت بإنشاء *hello.pptx*، مع شريحة واحدة تحتوي على صندوق النص. بدون ترخيص، تحمل الشريحة علامة مائية للتقييم؛ راجع [Licensing](/slides/ar/php-java/licensing/).

يتضمن السكريبت `aspose.slides.php` مباشرةً: لا يستطيع محمل Composer التلقائي تحميل هذه الفئات، لأنها جميعًا معرفّة في هذا الملف الواحد. كما يمرّر مسارًا مطلقًا إلى `save`، لأن Aspose.Slides يعمل داخل Tomcat ويحل المسار النسبي بالنسبة لمجلد عمل Tomcat، وليس بالنسبة للسكريبت الخاص بك.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق من أن Aspose.Slides مدمج بشكل صحيح؟**

شغّل السكريبت في [تحقق من التثبيت](#verify-the-installation). إذا كتب *hello.pptx* دون أخطاء، فإن PHP و PHP/Java Bridge و Aspose.Slides تعمل معًا.

**لماذا يتوقف السكريبت الخاص بي بالرسالة "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"؟**

لم يتمكن PHP من تحميل `Java.inc` من Tomcat. إذا كانت الرسالة السابقة تشير إلى أن المغلف `http://` معطل، فعّل `allow_url_include = On` في ملف `php.ini` الذي يستخدمه سطر أوامر PHP؛ يظهر الأمر `php --ini` الملف المستخدم. إذا كانت الرسالة تقول "Connection refused"، فإن Tomcat لم يبدأ بعد: ابدأه، أو انتظر بضع ثوانٍ حتى يبدأ.

**كيف يمكنني الحد من استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟**

قم بزيادة حدود ذاكرة JVM فقط إلى الحد المطلوب، وأغلق كل كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) في كتلة `finally` لإطلاق الذاكرة بسرعة. هذا يمنع أخطاء نفاد الذاكرة ويحافظ على استخدام الذاكرة الكلي متوقعًا أثناء عمليات الدُفعة.

**هل يمكنني استبعاد تنسيقات التصدير غير المرغوب فيها لتقليل حجم JAR النهائي؟**

الإصدارات الحالية من Aspose.Slides تُوزّع كمكتبة واحدة متكاملة، لذا لا يمكنك تعطيل مُصدّرين محددين مثل PDF أو SVG أثناء عملية البناء.