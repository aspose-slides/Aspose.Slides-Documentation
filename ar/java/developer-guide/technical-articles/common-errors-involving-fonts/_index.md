---
title: الاستثناءات والأخطاء الشائعة المتعلقة بالخطوط على لينوكس
type: docs
weight: 200
url: /ar/java/technical-articles/common-errors-involving-fonts
keywords: "استثناء الخط، خطأ الخط، لينوكس، جافا، Aspose.Slides لـ جافا"
description: "استثناءات وأخطاء الخطوط على لينوكس"
---

## **نص أو صور مفقودة (emf أو wmf) عند تنفيذ الكود على لينوكس**

تحدث هذه المشكلة في الأنظمة التي تحتوي على قيود في هذه الحالات:

1. عندما لا توجد خطوط مثبتة أو عندما لا يمكن الوصول إلى مجلد الخطوط لعملية الجافا
2. عندما لا يمكن الوصول إلى دليل TEMP.

### الحل

تحقق وتأكد من منح الوصول إلى دليل TEMP ومجلد الخطوط.

{{% alert color="warning" %}}

في بعض الحالات، قد لا تتمكن من منح الوصول إلى المجلدات بسبب القيود المفروضة من البيئة أو سياسة الأمان. جرب هذه الحلول البديلة:

{{% /alert %}}

**حل بديل**

استخدم [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة دون تثبيتها:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

إذا لم يكن من الممكن الوصول إلى دليل TEMP، استخدم هذا الكود لتحديد دليل آخر كـ TEMP لجافا:
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
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **استثناء: InvalidOperationException: لا يمكن العثور على أي خطوط مثبتة على النظام**

يحدث هذا الاستثناء عندما

1) لا يمكن لعملية الجافا الوصول إلى مجلد الخطوط
2) لم يتم تثبيت أي خطوط.

### الحل

1. تحقق وتأكد من منح الوصول إلى مجلد الخطوط لعملية الجافا.

2. قم بتثبيت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

3. قم بتثبيت الخطوط.

   * أوبونتو:

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * سنتوس:

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * باستخدام [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader):

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **استثناء: NoClassDefFoundError: لم يكن من الممكن تهيئة الفئة com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام لينوكس يفتقر إلى fontconfig والخطوط.

### الحل:

قم بتثبيت fontconfig:

* أوبونتو:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* سنتوس:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

بالإضافة إلى ذلك، فإن بعض إصدارات open-jdk (على سبيل المثال، **alpine JDK**) تتطلب أيضًا **تثبيت الخطوط**.

* أوبونتو:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* سنتوس:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **استثناء: UnsatisfiedLinkError: libfreetype.so.6: لا يمكن فتح ملف الكائن المشترك: لا يوجد مثل هذا الملف أو الدليل**

يحدث هذا الاستثناء على نظام لينوكس يفتقر إلى مكتبة libfreetype.

### الحل:

قم بتثبيت libfreetype وfontconfig:

* أوبونتو:

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* سنتوس:

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="نصيحة" color="primary" %}} 

لا تنسَ تثبيت الخطوط أو استخدام FontsLoader.

{{% /alert %}}  