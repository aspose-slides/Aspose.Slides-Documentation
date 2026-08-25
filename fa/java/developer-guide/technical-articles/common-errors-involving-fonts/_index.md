---
title: استثناها و خطاهای عمومی مرتبط با قلم‌ها در لینوکس
type: docs
weight: 200
url: /fa/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناهای قلم، خطای قلم، لینوکس، جاوا، Aspose.Slides برای جاوا"
description: "استثناها و خطاهای قلم در لینوکس"
---
## **بررسی کلی**

هنگامی که Aspose.Slides روی لینوکس استفاده می‌شود، ممکن است مشکلات مرتبط با قلم‌ها پیش آید اگر فرایند جاوا نتواند به پوشه‌های قلم مورد نیاز یا دایرکتوری موقت دسترسی پیدا کند، اگر بر روی سیستم هیچ قلمی نصب نشده باشد، یا اگر کتابخانه‌های سیستمی مورد نیاز مانند fontconfig یا libfreetype موجود نباشند.

این مقاله خطاها و استثناهای رایج مرتبط با قلم‌ها در لینوکس را توصیف می‌کند و راه‌حل‌هایی برای رفع آن‌ها ارائه می‌دهد. این مقاله توضیح می‌دهد که چگونه دسترسی به پوشه‌های قلم و دایرکتوری TEMP را بررسی کنید، قلم‌ها و کتابخانه‌های مورد نیاز را نصب کنید و از `FontsLoader` برای بارگذاری قلم‌ها بدون نصب سراسری استفاده کنید.

## **متن یا تصویر (EMF یا WMF) مفقود هنگام اجرای کد بر روی لینوکس**

این مشکل در سیستم‌هایی با محدودیت‌های زیر رخ می‌دهد:

1. وقتی هیچ قلمی نصب نشده باشد یا پوشهٔ قلم برای فرایند جاوا قابل دسترسی نباشد
2. وقتی دایرکتوری TEMP قابل دسترسی نباشد

### **راه‌حل**

دسترسی به دایرکتوری TEMP و پوشهٔ قلم‌ها را بررسی و تأیید کنید که اعطا شده است. 

{{% alert color="warning" %}}

در برخی موارد ممکن است به دلایل محدودیت‌های محیطی یا سیاست‌های امنیتی نتوانید دسترسی به پوشه‌ها را فراهم کنید. راه‌حل‌های زیر را امتحان کنید: 

{{% /alert %}}

**راه‌حل جایگزین**

از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) برای بارگذاری قلم‌های مورد نیاز بدون نصب آن‌ها استفاده کنید:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

اگر دسترسی به دایرکتوری TEMP امکان‌پذیر نیست، از کد زیر برای تعیین دایرکتوری دیگری به عنوان TEMP برای جاوا استفاده کنید:
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

1) فرایند جاوا نتواند به پوشهٔ قلم‌ها دسترسی پیدا کند  
2) هیچ قلمی نصب نشده باشد.

### **راه‌حل**

1. دسترسی به پوشهٔ قلم برای فرایند جاوا را بررسی و تأیید کنید که اعطا شده است.  
2. برخی قلم‌ها را نصب کنید یا از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) استفاده کنید.  
3. نصب قلم‌ها.

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

   * استفاده از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **استثنا: InternalError: InvocationTargetException**

هنگام تبدیل یک فایل PPTX به PDF در لینوکس، ممکن است تبدیل با خطای `java.lang.InternalError: java.lang.reflect.InvocationTargetException` شکست بخورد. اگر خطای زیر ظاهر شود `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`، بدین معنی است که پیکربندی قلم‌های لینوکس در دسترس نیست یا کش آن هنوز ساخته نشده است.

### **راه‌حل**

fontconfig را نصب کنید و کش قلم‌ها را بازسازی کنید:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **استثنا: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

این استثنا در سیستم لینوکسی رخ می‌دهد که فاقد fontconfig و قلم‌هاست.

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

علاوه بر این، برخی نسخه‌های open-jdk (مانند **alpine JDK**) همچنین **به قلم‌های نصب‌شده نیاز دارند**.

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

این استثنا در سیستم لینوکسی رخ می‌دهد که فاقد کتابخانه libfreetype است.

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