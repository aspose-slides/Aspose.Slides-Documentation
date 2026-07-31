---
title: الاستثناءات والأخطاء الشائعة المتعلقة بالخطوط على Linux
type: docs
weight: 200
url: /ar/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناء الخط، خطأ الخط، Linux، Java، Aspose.Slides for Java"
description: "استثناءات الأخطاء المتعلقة بالخطوط على Linux"
---
## **نظرة عامة**

عند استخدام Aspose.Slides على نظام Linux، قد تظهر مشكلات متعلقة بالخطوط إذا لم يتمكن عملية Java من الوصول إلى مجلدات الخطوط المطلوبة أو إلى المجلد المؤقت، أو إذا لم تكن هناك خطوط مثبتة على النظام، أو إذا كانت مكتبات النظام الضرورية مثل fontconfig أو libfreetype مفقودة.

تصف هذه المقالة الأخطاء والاستثناءات الشائعة المتعلقة بالخطوط على Linux وتقدم حلولًا لحلها. كما توضح كيفية فحص الوصول إلى مجلدات الخطوط وملف TEMP، وتثبيت الخطوط والمكتبات المطلوبة، واستخدام `FontsLoader` لتحميل الخطوط بدون تثبيتها على مستوى النظام.

## **نص أو صور مفقودة (EMF أو WMF) عند تشغيل الكود على Linux**

تحدث هذه المشكلة في الأنظمة التي لديها قيود في الحالات التالية:

1. عدم وجود خطوط مثبتة أو عدم قدرة عملية Java على الوصول إلى مجلد الخطوط
2. عدم إمكانية الوصول إلى مجلد TEMP.

### **الحل**

تحقق وتأكد من أنه تم منح الوصول إلى مجلد TEMP ومجلد الخطوط.

{{% alert color="warning" %}}

في بعض الحالات قد لا تتمكن من منح الوصول إلى المجلدات بسبب قيود البيئة أو سياسات الأمان. جرّب الحلول التالية:

{{% /alert %}}

**حل بديل**

استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة بدون تثبيتها:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

إذا لم يكن بالإمكان الوصول إلى مجلد TEMP، استخدم هذا الكود لتحديد مجلد آخر كـ TEMP لـ Java:
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

## **الاستثناء: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

يحدث هذا الاستثناء عندما

1) لا تستطيع عملية Java الوصول إلى مجلد الخطوط  
2) لا توجد خطوط مثبتة.

### **الحل**

1. تحقق وتأكد من أنه تم منح الوصول إلى مجلد الخطوط لعملية Java.  
2. قم بتثبيت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader).  
3. تثبيت الخطوط.

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

## **الاستثناء: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى fontconfig والخطوط.

### **الحل**

قم بتثبيت fontconfig:

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

بالإضافة إلى ذلك، بعض إصدارات open‑jdk (على سبيل المثال، **alpine JDK**) تتطلب أيضًا وجود خطوط مثبتة.

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

## **الاستثناء: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى مكتبة libfreetype.

### **الحل**

قم بتثبيت libfreetype وfontconfig:

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

{{% alert title="نصيحة" color="primary" %}} 

لا تنس تثبيت الخطوط أو استخدام FontsLoader.

{{% /alert %}}  