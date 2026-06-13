---
title: استثناها و خطاهای رایج مرتبط با قلم‌ها در لینوکس
type: docs
weight: 200
url: /fa/java/common-errors-involving-fonts/
keywords: "استثنای قلم، خطای قلم، لینوکس، جاوا، Aspose.Slides for Java"
description: "استثناها و خطاهای مربوط به قلم در لینوکس"
---
## **مروری کلی**

هنگامی که Aspose.Slides در لینوکس استفاده می‌شود، ممکن است مشکلات مربوط به قلم‌ها رخ دهد اگر فرآیند جاوا نتواند به پوشه‌های قلم مورد نیاز یا پوشه موقت دسترسی پیدا کند، اگر هیچ قلمی بر روی سیستم نصب نشود، یا اگر کتابخانه‌های سیستمی مورد نیاز مانند fontconfig یا libfreetype وجود نداشته باشند.

این مقاله خطاها و استثناهای رایج مرتبط با قلم‌ها در لینوکس را توصیف می‌کند و راه‌حل‌هایی برای رفع آن‌ها ارائه می‌دهد. همچنین نحوه بررسی دسترسی به پوشه‌های قلم و TEMP، نصب قلم‌ها و کتابخانه‌های مورد نیاز، و استفاده از `FontsLoader` برای بارگذاری قلم‌ها بدون نصب سیستم-wide را توضیح می‌دهد.

## **متن یا تصویر (EMF یا WMF) گمشده هنگام اجرای کد در لینوکس**

این مشکل در سیستم‌هایی که دارای محدودیت‌های زیر هستند، رخ می‌دهد:

1. هنگامی که هیچ قلمی نصب نشده باشد یا پوشه قلم برای فرآیند جاوا قابل دسترسی نباشد
2. هنگامی که پوشه TEMP قابل دسترسی نباشد.

### **راه‌حل**

دسترسی به پوشه TEMP و پوشه قلم‌ها را بررسی و تأیید کنید که اعطا شده است. 

{{% alert color="warning" %}}
در برخی موارد، ممکن است به دلیل محدودیت‌های محیط یا سیاست امنیتی نتوانید دسترسی به پوشه‌ها را اعطا کنید. راه‌حل‌های زیر را امتحان کنید: 
{{% /alert %}}

**راه‌حل جایگزین**

از [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader) برای بارگذاری قلم‌های مورد نیاز بدون نصب آن‌ها استفاده کنید:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

اگر پوشه TEMP قابل دسترسی نیست، از این کد برای تعیین پوشه دیگری به عنوان TEMP برای جاوا استفاده کنید:
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

## **استثنا: InvalidOperationException: عدم یافتن قلم‌های نصب شده بر روی سیستم**

این استثنا زمانی رخ می‌دهد که

1) فرآیند جاوا نتواند به پوشه قلم‌ها دسترسی پیدا کند  
2) هیچ قلمی نصب نشده باشد.

### **راه‌حل**

1. دسترسی به پوشه قلم برای فرآیند جاوا را بررسی و تأیید کنید.
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

## **استثنا: NoClassDefFoundError: عدم توانایی در مقداردهی اولیه کلاس com.aspose.slides.internal.ey.this**

این استثنا بر روی سیستم لینوکسی رخ می‌دهد که فاقد fontconfig و قلم‌ها است. 

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

به‌علاوه، برخی نسخه‌های open‑jdk (به عنوان مثال **alpine JDK**) نیز **به نصب قلم‌ها** نیاز دارند.

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

## **استثنا: UnsatisfiedLinkError: libfreetype.so.6: نمی‌تواند فایل شیء به‌اشتراک‌گذاری شده را باز کند: چنین فایلی یا چنین دایرکتوری وجود ندارد**

این استثنا بر روی سیستم لینوکسی رخ می‌دهد که فاقد کتابخانه libfreetype است. 

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

{{% alert title="نکته" color="primary" %}} 
فراموش نکنید قلم‌ها را نصب کنید یا از FontsLoader استفاده کنید.
{{% /alert %}}