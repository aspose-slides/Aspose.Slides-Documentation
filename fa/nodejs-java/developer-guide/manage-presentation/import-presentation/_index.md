---
title: "وارد کردن ارائه‌ها از PDF یا HTML در JavaScript"
linktitle: "وارد کردن ارائه"
type: docs
weight: 60
url: /fa/nodejs-java/import-presentation/
keywords:
- "وارد کردن ارائه"
- "وارد کردن اسلاید"
- "وارد کردن PDF"
- "وارد کردن HTML"
- "PDF به ارائه"
- "PDF به PPT"
- "PDF به PPTX"
- "PDF به ODP"
- "HTML به ارائه"
- "HTML به PPT"
- "HTML به PPTX"
- "HTML به ODP"
- "PowerPoint"
- "OpenDocument"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "با Aspose.Slides برای Node.js، اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument وارد کنید تا پردازش اسلایدی یکپارچه و با عملکرد بالا داشته باشید."
---
## **معرفی**

با استفاده از [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/fa/nodejs-java/)، می‌توانید ارائه‌ها را از فایل‌های با فرمت‌های دیگر وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) را ارائه می‌دهد تا بتوانید ارائه‌ها را از PDFها، اسناد HTML و غیره وارد کنید.

## **وارد کردن پاورپوینت از PDF**

در این حالت، می‌توانید یک PDF را به ارائه پاورپوینت تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/) ایجاد کنید.
2. متد [addFromPdf()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) را صدا بزنید و فایل PDF را به آن پاس دهید.
3. از متد [save()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت پاورپوینت استفاده کنید.

این کد JavaScript عملیات تبدیل PDF به پاورپوینت را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 
ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید زیرا این یک پیاده‌سازی زنده از فرآیند توضیح داده شده در اینجا است. 
{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت، می‌توانید یک سند HTML را به ارائه پاورپوینت تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/) ایجاد کنید.
2. متد [addFromHtml()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) را صدا بزنید و فایل PDF را به آن پاس دهید.
3. از متد [save()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت پاورپوینت استفاده کنید.

این کد JavaScript عملیات تبدیل HTML به پاورپوینت را نشان می‌دهد:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **سوالات متداول**

**آیا جدول‌ها هنگام وارد کردن PDF حفظ می‌شوند و می‌توان تشخیص آن‌ها را بهبود داد؟**

جدول‌ها می‌توانند در طول وارد کردن شناسایی شوند؛ [PdfImportOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfimportoptions/) شامل متد [setDetectTables](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) است که امکان شناسایی جدول را فعال می‌کند. کارایی آن به ساختار PDF بستگی دارد.