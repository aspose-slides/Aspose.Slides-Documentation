---
title: وارد کردن ارائه‌ها از PDF یا HTML در .NET
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument در .NET با Aspose.Slides وارد کنید تا پردازش اسلایدها به‌صورت یکپارچه و با عملکرد بالا انجام شود."
---
## **مقدمه**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را از فایل‌های فرمت‌های دیگر وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/) را فراهم می‌کند که امکان وارد کردن ارائه‌ها از اسناد PDF و HTML را می‌دهد.

## **وارد کردن پاورپوینت از PDF**

در این حالت شما می‌توانید یک فایل PDF را به ارائه‌ی PowerPoint تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. 
2. متد [AddFromPdf](https://reference.aspose.com/slides/fa/net/aspose.slides.slidecollection/addfrompdf/methods/1) را فراخوانی کنید و فایل PDF را پاس دهید. 
3. از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides.presentation/save/methods/5) برای ذخیره فایل در فرمت PowerPoint استفاده کنید.

این کد C# عملیات تبدیل PDF به PowerPoint را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
ممکن است بخواهید برنامه‌ی وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید زیرا این برنامه یک پیاده‌سازی زنده از فرآیند توضیح داده‌شده‌است. 
{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت شما می‌توانید یک سند HTML را به ارائه‌ی PowerPoint تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. 
2. متد [AddFromHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) را فراخوانی کنید و فایل HTML را پاس دهید. 
3. از متد [Save](https://apireference.aspose.com/slides/fa/net/aspose.slides.presentation/save/methods/5) برای ذخیره فایل به‌عنوان سند PowerPoint استفاده کنید.

این کد C# عملیات تبدیل HTML به PowerPoint را نشان می‌دهد: 

```c#
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

**آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و می‌توان تشخیص آن‌ها را بهبود داد؟**

جداول می‌توانند در زمان وارد کردن شناسایی شوند؛ کلاس [PdfImportOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.import/pdfimportoptions/) شامل پارامتر [DetectTables](https://reference.aspose.com/slides/fa/net/aspose.slides.import/pdfimportoptions/detecttables/) است که امکان شناسایی جداول را فعال می‌کند. میزان اثربخشی آن به ساختار PDF بستگی دارد.

{{% alert title="Note" color="warning" %}} 
همچنین می‌توانید از Aspose.Slides برای تبدیل HTML به فرمت‌های محبوب دیگر استفاده کنید: 

* [HTML به تصویر](https://products.aspose.com/slides/fa/net/conversion/html-to-image/)
* [HTML به JPG](https://products.aspose.com/slides/fa/net/conversion/html-to-jpg/)
* [HTML به XML](https://products.aspose.com/slides/fa/net/conversion/html-to-xml/)
* [HTML به TIFF](https://products.aspose.com/slides/fa/net/conversion/html-to-tiff/)

{{% /alert %}}