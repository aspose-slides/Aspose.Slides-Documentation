---
title: استثناها و خطاهای رایج مرتبط با قلم‌ها در لینوکس
type: docs
weight: 200
url: /fa/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناهای قلم، خطای قلم، لینوکس، جاوا، Aspose.Slides for Java"
description: "استثناها و خطاهای قلم در لینوکس"
---
## **مروری کلی**

هنگامی که Aspose.Slides بر روی لینوکس استفاده می‌شود، ممکن است مشکلات مرتبط با قلم‌ها بروز کند اگر فرآیند جاوا نتواند به پوشه‌های قلم مورد نیاز یا دایرکتوری موقت دسترسی پیدا کند، اگر هیچ قلمی بر روی سیستم نصب نشده باشد، یا اگر کتابخانه‌های سیستمی مورد نیاز مانند fontconfig یا libfreetype موجود نباشند.

این مقاله خطاها و استثناهای رایج مرتبط با قلم‌ها در لینوکس را توصیف می‌کند و راه‌حل‌هایی برای رفع آن‌ها ارائه می‌دهد. همچنین نحوهٔ بررسی دسترسی به پوشه‌های قلم و TEMP، نصب قلم‌ها و کتابخانه‌های مورد نیاز و استفاده از `FontsLoader` برای بارگذاری قلم‌ها بدون نصب آن‌ها در سطح سیستم توضیح داده می‌شود.

## **متن یا تصاویر گمشده (EMF یا WMF) هنگام اجرای کد در لینوکس**

این مشکل در سیستم‌هایی با محدودیت‌های زیر رخ می‌دهد:

1. وقتی هیچ قلمی نصب نشده باشد یا دسترسی به پوشهٔ قلم برای فرآیند جاوا امکان‌پذیر نباشد
2. وقتی دسترسی به دایرکتوری TEMP ممکن نباشد.

### **راه‌حل**

دسترسی به دایرکتوری TEMP و پوشهٔ قلم‌ها را بررسی و تأیید کنید. 

{{% alert color="warning" %}}

در برخی موارد ممکن است به دلایل محدودیت‌های محیطی یا سیاست‌های امنیتی نتوانید دسترسی به پوشه‌ها را بدهید. برای رفع این مشکل از روش‌های زیر استفاده کنید: 

{{% /alert %}}

**راه‌حل جایگزین**

از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) برای بارگذاری قلم‌های مورد نیاز بدون نصب آن‌ها استفاده کنید:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

اگر دسترسی به دایرکتوری TEMP ممکن نیست، از کد زیر برای تعیین دایرکتوری دیگری به‌عنوان TEMP برای جاوا استفاده کنید:
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

## **استثنا: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

این استثنا زمانی رخ می‌دهد که

1) فرآیند جاوا نتواند به پوشهٔ قلم‌ها دسترسی پیدا کند  
2) هیچ قلمی نصب نشده باشد.

### **راه‌حل**

1. دسترسی به پوشهٔ قلم برای فرآیند جاوا را بررسی و تأیید کنید.

2. برخی قلم‌ها را نصب کنید یا از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) استفاده کنید.

3. قلم‌ها را نصب کنید.

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

   * با استفاده از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **استثنا: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

این استثنا در سیستمی رخ می‌دهد که فاقد fontconfig و قلم‌ها باشد. 

### **راه‌حل**

fontconfig را نصب کنید:

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

علاوه بر این، برخی نسخه‌های open‑jdk (مثلاً **alpine JDK**) نیز **به نصب قلم‌ها نیاز دارند**.

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

## **استثنا: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

این استثنا در سیستمی رخ می‌دهد که فاقد کتابخانه libfreetype باشد. 

### **راه‌حل**

libfreetype و fontconfig را نصب کنید:

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

فراموش نکنید قلم‌ها را نصب کنید یا از FontsLoader استفاده کنید.

{{% /alert %}}