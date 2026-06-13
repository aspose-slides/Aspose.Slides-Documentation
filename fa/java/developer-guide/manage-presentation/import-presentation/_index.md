---
title: وارد کردن ارائه‌ها از PDF یا HTML در Java
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/java/import-presentation/
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
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "به راحتی اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument در Java با Aspose.Slides وارد کنید برای پردازش اسلایدهای با عملکرد بالا و بدون مشکل."
---
## **مقدمه**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را از فایل‌های دیگر فرمت‌ها وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/) را فراهم می‌کند که به شما اجازه می‌دهد ارائه‌ها را از اسناد PDF و HTML وارد کنید.

## **وارد کردن پاورپوینت از PDF**

در این حالت، می‌توانید یک PDF را به ارائه پاورپوینت تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) ایجاد کنید. 
2. متد [addFromPdf()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) را فراخوانی کنید و فایل PDF را به آن پاس بدهید. 
3. از متد [save()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در قالب پاورپوینت استفاده کنید.

این کد Java عملیات تبدیل PDF به پاورپوینت را نشان می‌دهد:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید، زیرا پیاده‌سازی زنده‌ای از فرایند توضیح داده شده در اینجا است. 
{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت، می‌توانید یک سند HTML را به ارائه پاورپوینت تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) ایجاد کنید. 
2. متد [addFromHtml()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) را فراخوانی کنید و فایل HTML را به آن پاس بدهید. 
3. از متد [save()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در قالب پاورپوینت استفاده کنید.

این کد Java عملیات تبدیل HTML به پاورپوینت را نشان می‌دهد: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟**

جداول می‌توانند در حین وارد کردن شناسایی شوند؛ کلاس [PdfImportOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfimportoptions/) شامل متد [setDetectTables](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) است که تشخیص جداول را فعال می‌کند. کارایی بستگی به ساختار PDF دارد.

{{% alert title="Note" color="warning" %}} 
همچنین می‌توانید از Aspose.Slides برای تبدیل HTML به سایر فرمت‌های محبوب استفاده کنید: 

* [HTML به تصویر](https://products.aspose.com/slides/fa/java/conversion/html-to-image/)
* [HTML به JPG](https://products.aspose.com/slides/fa/java/conversion/html-to-jpg/)
* [HTML به XML](https://products.aspose.com/slides/fa/java/conversion/html-to-xml/)
* [HTML به TIFF](https://products.aspose.com/slides/fa/java/conversion/html-to-tiff/)

{{% /alert %}}