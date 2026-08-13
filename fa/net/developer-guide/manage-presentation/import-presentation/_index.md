---
title: "وارد کردن ارائه‌ها از PDF یا HTML در .NET"
linktitle: "وارد کردن ارائه"
type: docs
weight: 60
url: /fa/net/import-presentation/
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
- ".NET"
- "C#"
- "Aspose.Slides"
description: "به‌راحتی اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument در .NET با Aspose.Slides وارد کنید تا پردازش اسلایدهای بدون درز و با عملکرد بالا فراهم شود."
---
## **مقدمه**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را از فایل‌های دیگر فرمت‌ها وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/) را ارائه می‌دهد که امکان وارد کردن ارائه‌ها از اسناد PDF و HTML را فراهم می‌کند.

## **وارد کردن PowerPoint از PDF**

در این حالت، می‌توانید یک فایل PDF را به یک ارائه PowerPoint تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. 
2. متد [AddFromPdf](https://reference.aspose.com/slides/fa/net/aspose.slides.slidecollection/addfrompdf/methods/1) را صدا بزنید و فایل PDF را به آن پاس دهید. 
3. از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides.presentation/save/methods/5) برای ذخیره کردن فایل در قالب PowerPoint استفاده کنید.

این کد C# عملیات تبدیل PDF به PowerPoint را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 

ممکن است بخواهید برنامه وب **Aspose free** [PDF به PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید زیرا این یک پیاده‌سازی زنده از فرآیند توضیح داده شده در اینجا است. 

{{% /alert %}} 

## **وارد کردن PowerPoint از HTML**

در این حالت، می‌توانید یک سند HTML را به یک ارائه PowerPoint تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. 
2. متد [AddFromHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) را صدا بزنید و فایل HTML را به آن پاس دهید. 
3. از متد [Save](https://apireference.aspose.com/slides/fa/net/aspose.slides.presentation/save/methods/5) برای ذخیره کردن فایل به عنوان یک سند PowerPoint استفاده کنید.

این کد C# عملیات تبدیل HTML به PowerPoint را نشان می‌دهد: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

### آیا جدول‌ها هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟

جدول‌ها می‌توانند در طول وارد کردن شناسایی شوند؛ [PdfImportOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.import/pdfimportoptions/) شامل پارامتر [DetectTables](https://reference.aspose.com/slides/fa/net/aspose.slides.import/pdfimportoptions/detecttables/) است که امکان تشخیص جدول‌ها را فراهم می‌کند. کارایی آن بستگی به ساختار PDF دارد.

{{% alert title="تذکر" color="warning" %}} 

شما همچنین می‌توانید از Aspose.Slides برای تبدیل HTML به سایر فرمت‌های فایل محبوب استفاده کنید: 

* [HTML به تصویر](https://products.aspose.com/slides/fa/net/conversion/html-to-image/)
* [HTML به JPG](https://products.aspose.com/slides/fa/net/conversion/html-to-jpg/)
* [HTML به XML](https://products.aspose.com/slides/fa/net/conversion/html-to-xml/)
* [HTML به TIFF](https://products.aspose.com/slides/fa/net/conversion/html-to-tiff/)

{{% /alert %}}