---
title: التثبيت
type: docs
weight: 70
url: /ar/php-java/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- ماك أو إس
- باوربوينت
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قم بتثبيت Aspose.Slides لـ PHP عبر Java بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات الكود — ابدأ العمل مع عروض PowerPoint التقديمية اليوم!"
---

## **تكوين البيئة**

1. قم بتثبيت PHP 7، أضف مسار PHP إلى متغير النظام `PATH` واضبط `allow_url_include` إلى `On` في ملف `php.ini`.
1. قم بتثبيت JRE 8. اضبط متغير البيئة `JAVA_HOME` إلى مسار JRE المثبت.
1. قم بتثبيت Apache Tomcat 8.0.

## **تنزيل Aspose.Slides for PHP عبر Java**

`packagist` هو أسهل طريقة لتنزيل [Aspose.Slides for PHP عبر Java](https://packagist.org/packages/aspose/slides).

لتثبيت Aspose.Slides باستخدام Packagist، شغِّل هذا الأمر:
   ```bash
   composer require aspose/slides
   ```


## **تكوين Apache Tomcat**

1. حمّل PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) من http://php-java-bridge.sourceforge.net/pjb/download.php واستخرج ملف `JavaBridge.war` إلى مجلد `webapps` الخاص بـ Tomcat.
1. ابدأ خدمة Apache Tomcat.
1. حمّل [“Aspose.Slides for PHP عبر Java”](https://downloads.aspose.com/slides/php-java) واستخرجه إلى مجلد `aspose.slides`. انسخ ملف `jar/aspose-slides-x.x-php.jar` إلى المجلد `webapps\JavaBridge\WEB-INF\lib`. إذا كنت تستخدم **PHP 8**، استبدل الملف الأصلي `Java.inc` من PHP-Java Bridge بالملف `Java.inc` الموجود في `Java.inc.php8.zip`.
1. أعد تشغيل خدمة Apache Tomcat.
1. شغِّل `example.php` في مجلد `aspose.slides` لتشغيل المثال باستخدام الأمر التالي:
   ```bash
   php example.php
   ```


## **الأسئلة الشائعة**

**كيف يمكنني التحقق من أن Aspose.Slides مدمج بشكل صحيح؟**

قم ببناء مشروعك، أنشئ كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) فارغ واحفظه باسم جديد. إذا تم إنشاء الملف دون إلقاء استثناءات، فقد تم دمج المكتبة بنجاح.

**كيف يمكنني الحد من استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟**

قم بزيادة حدود ذاكرة JVM فقط إلى الحد المطلوب، وأغلق كل كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) في كتلة `finally` لتحرير الذاكرة المؤقتة فوراً. هذا يمنع أخطاء نفاد الذاكرة ويحافظ على استهلاك الذاكرة الكلي قابلاً للتنبؤ به أثناء عمليات الدفعات.

**هل يمكنني استبعاد تنسيقات التصدير غير المرغوب فيها لتقليل حجم ملف JAR النهائي؟**

إصدارات Aspose.Slides الحالية تُوزّع كمكتبة أحادية، لذلك لا يمكنك تعطيل مصادر تصدير محددة مثل PDF أو SVG أثناء بناء البرنامج.