---
title: الاستثناءات والأخطاء الشائعة المتعلقة بالخطوط على نظام لينكس
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "استثناء خط, خطأ خط, لينكس, Java, Aspose.Slides لـ PHP عبر Java"
description: "استثناءات وأخطاء الخطوط على لينكس"
---

## **نصوص أو صور مفقودة (emf أو wmf) عند تنفيذ الكود على لينكس**

تحدث هذه المشكلة في الأنظمة ذات القيود في هذه الحالات:

1. عندما لا توجد خطوط مثبتة أو عندما لا يمكن الوصول إلى مجلد الخطوط لعملية الجافا
2. عندما لا يمكن الوصول إلى دليل TEMP.

### الحل

تحقق وتأكد من أنه تم منح الوصول إلى دليل TEMP ومجلد الخطوط. 

{{% alert color="warning" %}}

في بعض الحالات، قد لا تتمكن من منح الوصول إلى المجلدات بسبب القيود المفروضة من قبل البيئة أو سياسة الأمان. جرب هذه الحلول البديلة: 

{{% /alert %}}

**الحل البديل**

استخدم [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة دون تثبيتها:

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

إذا لم يكن بالإمكان الوصول إلى دليل TEMP، استخدم هذا الكود لتحديد دليل آخر كدليل TEMP لجافا:
```php

```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **استثناء: InvalidOperationException: لا يمكن العثور على أي خطوط مثبتة على النظام**

يحدث هذا الاستثناء عندما

1) لا يمكن لعملية الجافا الوصول إلى مجلد الخطوط
2) لم يتم تثبيت أي خطوط.

### الحل

1. تحقق وتأكد من أنه تم منح الوصول إلى مجلد الخطوط لعملية جافا.

2. قم بتثبيت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

3. قم بتثبيت الخطوط.

   * أوبونتو: 

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * سنتوس: 

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * باستخدام [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader):

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **استثناء: NoClassDefFoundError: لم يتمكن من تهيئة الفئة com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام لينكس الذي يفتقر إلى fontconfig والخطوط. 

### الحل:

قم بتثبيت fontconfig:

* أوبونتو:

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* سنتوس:

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

بالإضافة إلى ذلك، تتطلب بعض إصدارات open-jdk (على سبيل المثال، **alpine JDK**) أيضًا **خطوط مثبتة**.

* أوبونتو:

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* سنتوس:

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **استثناء: UnsatisfiedLinkError: libfreetype.so.6: لا يمكن فتح ملف الكائن المشترك: لا يوجد مثل هذا الملف أو الدليل**

يحدث هذا الاستثناء على نظام لينكس الذي يفتقر إلى مكتبة libfreetype. 

### الحل:

قم بتثبيت libfreetype وfontconfig:

* أوبونتو: 

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* سنتوس: 

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="نصيحة" color="primary" %}} 

لا تنسى تثبيت الخطوط أو استخدام FontsLoader.

{{% /alert %}}  