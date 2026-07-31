---
title: استثناها و خطاهای رایج مربوط به قلم‌ها در لینوکس
type: docs
weight: 200
url: /fa/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "استثناء قلم، خطای قلم، لینوکس، جاوا، Aspose.Slides for Java"
description: "استثناها و خطاهای قلم در لینوکس"
---
## **مروری کلی**

هنگامی که Aspose.Slides در لینوکس استفاده می‌شود، ممکن است مشکلات مرتبط با قلم‌ها رخ دهد اگر فرآیند جاوا نتواند به پوشه‌های قلم مورد نیاز یا دایرکتوری موقت دسترسی پیدا کند، اگر هیچ قلمی بر روی سیستم نصب نشده باشد، یا اگر کتابخانه‌های سیستمی مورد نیاز مانند fontconfig یا libfreetype موجود نباشند.

این مقاله خطاها و استثنائات رایج مربوط به قلم‌ها در لینوکس را توصیف می‌کند و راه‌حل‌هایی برای رفع آن‌ها ارائه می‌دهد. همچنین توضیح می‌دهد چگونه دسترسی به پوشه‌های قلم و TEMP را بررسی کنید، قلم‌ها و کتابخانه‌های مورد نیاز را نصب کنید و از `FontsLoader` برای بارگذاری قلم‌ها بدون نصب سراسری استفاده کنید.

## **متن یا تصویر گمشده (EMF یا WMF) هنگام اجرای کد در لینوکس**

این مشکل در سیستم‌هایی که محدودیت‌های زیر وجود دارد رخ می‌دهد:

1. وقتی هیچ قلمی نصب نشده باشد یا پوشه قلم برای فرآیند جاوا دسترسی‌پذیر نباشد
2. وقتی دایرکتوری TEMP دسترسی‌پذیر نباشد.

### **راه‌حل**

دسترسی به دایرکتوری TEMP و پوشه قلم‌ها را بررسی و تأیید کنید.

{{% alert color="warning" %}}
در برخی موارد ممکن است به دلایل محدودیت‌های محیطی یا سیاست‌های امنیتی نتوانید دسترسی به پوشه‌ها را فراهم کنید. برای این وضعیت راه‌حل‌های زیر را امتحان کنید:
{{% /alert %}}

**راه‌حل موقت**

از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) برای بارگذاری قلم‌های مورد نیاز بدون نصب آن‌ها استفاده کنید:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

اگر دسترسی به دایرکتوری TEMP امکان‌پذیر نباشد، از این کد برای تعیین دایرکتوری دیگری به عنوان TEMP برای جاوا استفاده کنید:
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

## **استثنا: InvalidOperationException: عدم یافتن هیچ قلمی نصب شده بر روی سیستم**

این استثنا زمانی رخ می‌دهد که

1) فرآیند جاوا نتواند به پوشه قلم‌ها دسترسی پیدا کند
2) هیچ قلمی نصب نشده باشد.

### **راه‌حل**

1. دسترسی به پوشه قلم برای فرآیند جاوا را بررسی و تأیید کنید.

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

## **استثنا: NoClassDefFoundError: عدم امکان مقداردهی اولیه کلاس com.aspose.slides.internal.ey.this**

این استثنا در سیستمی که فاقد fontconfig و قلم‌ها است رخ می‌دهد.

### **راه‌حل**

نصب fontconfig:

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

علاوه بر این، برخی نسخه‌های open‑jdk (به عنوان مثال **alpine JDK**) نیز **به قلم‌های نصب‌شده نیاز دارند**.

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

## **استثنا: UnsatisfiedLinkError: libfreetype.so.6: عدم امکان باز کردن فایل شیء مشترک: چنین فایلی یا دایرکتوری وجود ندارد**

این استثنا در سیستمی که فاقد کتابخانه libfreetype است رخ می‌دهد.

### **راه‌حل**

نصب libfreetype و fontconfig:

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
فراموش نکنید قلم‌ها را نصب کنید یا از FontsLoader استفاده نمایید.
{{% /alert %}}