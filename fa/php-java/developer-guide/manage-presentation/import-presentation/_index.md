---
title: وارد کردن ارائه‌ها از PDF یا HTML در PHP
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/php-java/import-presentation/
keywords:
- وارد کردن ارائه
- وارد کردن اسلاید
- وارد کردن PDF
- وارد کردن HTML
- PDF به ارائه
- PDF به PPT
- PDF به PPTX
- PDF به ODP
- HTML به ارائه
- HTML به PPT
- HTML به PPTX
- HTML به ODP
- پاورپوینت
- سند باز
- PHP
- Aspose.Slides
description: "PDF و اسناد HTML را به ارائه‌های PowerPoint و OpenDocument در PHP با Aspose.Slides وارد کنید تا پردازش اسلایدهای یکپارچه و با عملکرد بالا فراهم شود."
---
## **معرفی**

با استفاده از [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/fa/php-java/)، می‌توانید ارائه‌ها را از فایل‌های دیگر فرمت‌ها وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) را فراهم می‌کند تا بتوانید ارائه‌ها را از PDFها، اسناد HTML و غیره وارد کنید.

## **وارد کردن پاورپوینت از PDF**

در این حالت، می‌توانید یک PDF را به ارائه پاورپوینت تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) ایجاد کنید.
2. متد [addFromPdf()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) را فراخوانی کنید و فایل PDF را پاس کنید.
3. از متد [save()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت پاورپوینت استفاده کنید.

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="نکته" color="primary" %}} 

ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید زیرا یک پیاده‌سازی زنده از فرآیند توضیح داده شده در اینجا است. 

{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت، می‌توانید یک سند HTML را به ارائه پاورپوینت تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) ایجاد کنید.
2. متد [addFromHtml()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) را فراخوانی کنید و فایل PDF را پاس کنید.
3. از متد [save()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت پاورپوینت استفاده کنید.

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟**

جداول می‌توانند در زمان وارد کردن شناسایی شوند؛ کلاس [PdfImportOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfimportoptions/) شامل متد [setDetectTables](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfimportoptions/#setDetectTables) است که شناسایی جدول را فعال می‌کند. کارایی آن به ساختار PDF بستگی دارد.

{{% alert title="توجه" color="warning" %}} 

شما همچنین می‌توانید از Aspose.Slides برای تبدیل HTML به فرمت‌های فایل محبوب دیگر استفاده کنید: 

* [HTML to image](https://products.aspose.com/slides/fa/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/fa/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/fa/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/fa/php-java/conversion/html-to-tiff/)

{{% /alert %}}