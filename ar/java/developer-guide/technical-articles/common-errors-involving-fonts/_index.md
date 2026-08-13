---
title: الاستثناءات والأخطاء الشائعة المتعلقة بالخطوط على Linux
type: docs
weight: 200
url: /ar/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناء الخط، خطأ الخط، Linux، Java، Aspose.Slides for Java"
description: "استثناءات وأخطاء الخطوط على Linux"
---
## **نظرة عامة**

عند استخدام Aspose.Slides على Linux، قد تحدث مشكلات تتعلق بالخطوط إذا لم يتمكن عملية Java من الوصول إلى مجلدات الخطوط المطلوبة أو إلى الدليل المؤقت، إذا لم يتم تثبيت أي خطوط على النظام، أو إذا كانت مكتبات النظام المطلوبة مثل fontconfig أو libfreetype مفقودة.

تصف هذه المقالة الأخطاء والاستثناءات الشائعة المتعلقة بالخطوط على Linux وتوفر حلولاً لحلها. توضح كيفية التحقق من إمكانية الوصول إلى مجلدات الخطوط و TEMP، وتثبيت الخطوط والمكتبات المطلوبة، واستخدام `FontsLoader` لتحميل الخطوط دون تثبيتها على مستوى النظام.

## **النص أو الصور المفقودة (EMF أو WMF) عند تنفيذ الكود على Linux**

يحدث هذا المشكلة في الأنظمة التي توجد بها قيود في الحالات التالية:

1. عندما لا تكون هناك خطوط مثبتة أو عندما لا يمكن الوصول إلى مجلد الخطوط لعملية Java
2. عندما لا يمكن الوصول إلى الدليل TEMP.

### **الحل**

تحقق وتأكد من أنه تم منح الوصول إلى الدليل TEMP ومجلد الخطوط.

{{% alert color="warning" %}}

في بعض الحالات، قد لا تتمكن من منح الوصول إلى المجلدات بسبب القيود التي يفرضها البيئة أو سياسة الأمان. جرّب حلولًا بديلة:

{{% /alert %}}

**حل بديل**

استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة دون تثبيتها:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

إذا لم يمكن الوصول إلى الدليل TEMP، استخدم هذا الكود لتحديد دليل آخر كـ TEMP لعملية Java:
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

## **استثناء: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

يحدث هذا الاستثناء عندما

1) لا تتمكن عملية Java من الوصول إلى مجلد الخطوط  
2) لا يتم تثبيت أي خطوط.

### **الحل**

1. تحقق وتأكد من أنه تم منح الوصول إلى مجلد الخطوط لعملية Java.

2. ثبّت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader).

3. ثبّت الخطوط.

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

## **استثناء: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى fontconfig والخطوط.

### **الحل**

ثبّت fontconfig:

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

بالإضافة إلى ذلك، تتطلب بعض إصدارات open‑jdk (مثلاً **alpine JDK**) **وجود خطوط مثبتة**.

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

## **استثناء: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

يحدث هذا الاستثناء على نظام Linux يفتقر إلى مكتبة libfreetype.

### **الحل**

ثبّت libfreetype و fontconfig:

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

{{% alert title="TIP" color="info" %}} 

لا تنس تثبيت الخطوط أو استخدام FontsLoader.

{{% /alert %}}