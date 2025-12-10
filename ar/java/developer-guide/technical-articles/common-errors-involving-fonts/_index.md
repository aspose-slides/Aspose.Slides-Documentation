---
title: استثناءات وأخطاء شائعة تتعلق بالخطوط على لينكس
type: docs
weight: 200
url: /ar/java/technical-articles/common-errors-involving-fonts
keywords: "استثناء الخط، خطأ الخط، لينكس، جافا، Aspose.Slides for Java"
description: "استثناءات الخطوط والأخطاء على لينكس"
---

## **نص أو صور مفقودة (EMF أو WMF) عند تنفيذ الكود على لينكس**

تظهر هذه المشكلة في الأنظمة التي توجد فيها قيود في الحالات التالية:

1. عندما لا تكون هناك خطوط مثبتة أو عندما لا يمكن الوصول إلى مجلد الخطوط لعملية جافا
2. عندما لا يمكن الوصول إلى دليل TEMP.

### **الحل**

تحقق وتأكد من أنه تم منح الوصول إلى دليل TEMP ومجلد الخطوط. 

{{% alert color="warning" %}}
في بعض الحالات، قد لا تتمكن من منح الوصول إلى المجلدات بسبب القيود التي يفرضها البيئة أو سياسات الأمان. جرّب هذه الحلول المؤقتة: 
{{% /alert %}}

**الحل المؤقت**

استخدم [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) لتحميل الخطوط المطلوبة دون تثبيتها:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```


إذا لم يكن بالإمكان الوصول إلى دليل TEMP، استخدم هذا الكود لتحديد دليل آخر كدليل TEMP لجافا:
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


## **الاستثناء: InvalidOperationException: لا يمكن العثور على أي خطوط مثبتة على النظام**

يحدث هذا الاستثناء عندما

1) لا يمكن لعملية جافا الوصول إلى مجلد الخطوط  
2) لم يتم تثبيت أي خطوط.

### **الحل**

1. تحقق وتأكد من أنه تم منح الوصول إلى مجلد الخطوط لعملية جافا.  
2. ثبت بعض الخطوط أو استخدم [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).  
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


   * باستخدام [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader): 
     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```


## **الاستثناء: NoClassDefFoundError: تعذر تهيئة الفئة com.aspose.slides.internal.ey.this**

يحدث هذا الاستثناء على نظام لينكس يفتقر إلى fontconfig والخطوط. 

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


بالإضافة إلى ذلك، بعض إصدارات open-jdk (على سبيل المثال، **alpine JDK**) تحتاج أيضًا إلى **خطوط مثبتة**.

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


## **الاستثناء: UnsatisfiedLinkError: libfreetype.so.6: لا يمكن فتح ملف الكائن المشترك: لا وجود للملف أو الدليل**

يظهر هذا الاستثناء على نظام لينكس يفتقر إلى مكتبة libfreetype. 

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


{{% alert title="TIP" color="primary" %}} 
لا تنس تثبيت الخطوط أو استخدام FontsLoader.
{{% /alert %}}