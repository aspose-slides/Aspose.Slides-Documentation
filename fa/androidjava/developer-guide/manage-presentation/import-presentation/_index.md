---
title: "وارد کردن ارائه‌ها از PDF یا HTML در اندروید"
linktitle: "وارد کردن ارائه"
type: docs
weight: 60
url: /fa/androidjava/import-presentation/
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
- "پاورپوینت"
- "سند باز"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "وارد کردن اسناد PDF و HTML به ارائه‌های پاورپوینت و OpenDocument در جاوا با Aspose.Slides برای اندروید برای پردازش روان و با عملکرد بالا اسلایدها."
---
## **مقدمه**

با استفاده از [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/fa/androidjava/)، می‌توانید ارائه‌ها را از فایل‌های فرمت‌های دیگر وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/) را برای امکان‌پذیری وارد کردن ارائه‌ها از PDFها، اسناد HTML و غیره فراهم می‌کند.

## **وارد کردن پاورپوینت از PDF**

در این حالت، می‌توانید یک PDF را به ارائهٔ پاورپوینت تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) ایجاد کنید.
2. متد [addFromPdf()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) را فراخوانی کنید و فایل PDF را به آن پاس کنید.
3. از متد [save()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره‌سازی فایل در قالب پاورپوینت استفاده کنید.

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
ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید، زیرا این برنامه پیاده‌سازی زنده‌ای از فرآیندی است که در اینجا توضیح داده شده است. 
{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت، می‌توانید یک سند HTML را به ارائهٔ پاورپوینت تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) ایجاد کنید.
2. متد [addFromHtml()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) را فراخوانی کنید و فایل HTML را به آن پاس کنید.
3. از متد [save()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره‌سازی فایل در قالب پاورپوینت استفاده کنید.

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

**آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و می‌توان تشخیص آن‌ها را بهبود داد؟**

جداول می‌توانند در حین وارد کردن شناسایی شوند؛ کلاس [PdfImportOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfimportoptions/) شامل متد [setDetectTables](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) است که امکان تشخیص جدول را فعال می‌کند. کارایی این قابلیت به ساختار PDF وابسته است.