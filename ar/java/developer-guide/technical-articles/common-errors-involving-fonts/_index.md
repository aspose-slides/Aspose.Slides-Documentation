---
title: "استثناءات وأخطاء شائعة تتعلق بالخطوط على لينكس"
type: docs
weight: 200
url: /ar/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناء الخط, خطأ الخط, لينكس, جافا, Aspose.Slides for Java"
description: "استثناءات الأخطاء المتعلقة بالخطوط على لينكس"
---
## **نظرة عامة**

عند استخدام Aspose.Slides على Linux، قد تحدث مشكلات متعلقة بالخطوط إذا لم يتمكن عملية Java من الوصول إلى مجلدات الخطوط المطلوبة أو الدليل المؤقت، أو إذا لم يتم تثبيت أي خطوط على النظام، أو إذا كانت مكتبات النظام المطلوبة مثل fontconfig أو libfreetype مفقودة.

تصف هذه المقالة الأخطاء والاستثناءات الشائعة المتعلقة بالخطوط على Linux وتقدم حلولًا لحلها. توضح كيفية التحقق من إمكانية الوصول إلى مجلدات الخطوط وTEMP، وتثبيت الخطوط والمكتبات المطلوبة، واستخدام `FontsLoader` لتحميل الخطوط دون تثبيتها على مستوى النظام.

## **نص أو صور مفقولة (EMF أو WMF) عند تنفيذ الشيفرة على Linux**

هذه المشكلة تحدث في الأنظمة التي لديها قيود في الحالات التالية:

1. عند عدم تثبيت أي خطوط أو عندما لا يمكن الوصول إلى مجلد الخطوط لعملية java
2. عند عدم إمكانية الوصول إلى دليل TEMP.

### **الحل**

تحقق وتأكد من أنه تم منح الوصول إلى دليل TEMP ومجلد الخطوط.

{{% alert color="warning" %}}
في بعض الحالات، قد لا تتمكن من منح الوصول إلى المجلدات بسبب القيود التي يفرضها البيئة أو سياسات الأمان. جرّب هذه حلول التفادي:
{{% /alert %}}

**حل بديل**

استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة دون تثبيتها:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

إذا لم يكن بإمكانك الوصول إلى دليل TEMP، استخدم هذا الكود لتحديد دليل آخر كدليل TEMP لعملية Java:
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

1) لا تتمكن عملية Java من الوصول إلى مجلد الخطوط  
2) لم يتم تثبيت أي خطوط.

### **الحل**

1. تحقق وتأكد من أنه تم منح الوصول إلى مجلد الخطوط لعملية Java.  
2. ثبت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader).  
3. ثبت الخطوط.

   * Ubuntu:  

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS:  

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * باستخدام [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **استثناء: InternalError: InvocationTargetException**

عند تحويل ملف PPTX إلى PDF على Linux، قد تفشل العملية مع الخطأ `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. إذا كان الخطأ الأساسي يشير إلى `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`، فإن تكوين خطوط Linux غير متوفر أو لم يتم تهيئة ذاكرة التخزين المؤقت الخاصة به.

### **الحل**

قم بتثبيت fontconfig وإعادة بناء ذاكرة التخزين المؤقت للخطوط:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **استثناء: NoClassDefFoundError: تعذر تهيئة الفئة com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى fontconfig و الخطوط.

### **الحل**

ثبت fontconfig:

* Ubuntu:  

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:  

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

بالإضافة إلى ذلك، بعض إصدارات open-jdk (على سبيل المثال، **alpine JDK**) أيضًا **تتطلب تثبيت الخطوط**.

* Ubuntu:  

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:  

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **استثناء: UnsatisfiedLinkError: libfreetype.so.6: لا يمكن فتح ملف كائن مشترك: لا يوجد مثل هذا الملف أو الدليل**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى مكتبة libfreetype.

### **الحل**

ثبت libfreetype و fontconfig:

* Ubuntu:  

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS:  

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="نصيحة" color="info" %}} 
لا تنس تثبيت الخطوط أو استخدام FontsLoader.
{{% /alert %}}