---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در .NET
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/net/convert-powerpoint-to-word/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به Word
- ارائه به Word
- اسلاید به Word
- PPT به Word
- PPTX به Word
- PowerPoint به DOCX
- ارائه به DOCX
- اسلاید به DOCX
- PPT به DOCX
- PPTX به DOCX
- PowerPoint به DOC
- ارائه به DOC
- اسلاید به DOC
- PPT به DOC
- PPTX به DOC
- ذخیره PPT به عنوان DOCX
- ذخیره PPTX به عنوان DOCX
- صدور PPT به DOCX
- صدور PPTX به DOCX
- .NET
- C#
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint PPT و PPTX به اسناد Word قابل ویرایش در C# با استفاده از Aspose.Slides برای .NET، به همراه حفظ دقیق قالب‌بندی، تصاویر و چینش."
---
## **مرور کلی**

این مقاله راه حلی برای توسعه‌دهندگان در تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word با استفاده از Aspose.Slides برای .NET و Aspose.Words برای .NET ارائه می‌دهد. راهنمای گام به گام شما را در تمام مراحل فرآیند تبدیل راهنمایی می‌کند.

## **تبدیل یک ارائه به سند Word**

دستورالعمل‌های زیر را برای تبدیل یک ارائه PowerPoint یا OpenDocument به سند Word دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و فایل ارائه را بارگذاری کنید.
2. نمونه‌ای از کلاس‌های [Document](https://reference.aspose.com/words/net/aspose.words/document/) و [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) ایجاد کنید تا یک سند Word تولید شود.
3. اندازه صفحهٔ سند Word را با استفاده از خصوصیت [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) به اندازه صفحهٔ ارائه تنظیم کنید.
4. حاشیه‌های سند Word را با استفاده از خصوصیت [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) تنظیم کنید.
5. از طریق تمام اسلایدهای ارائه با استفاده از خصوصیت [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) عبور کنید.
    - با استفاده از متد `GetImage` از اینترفیس [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) یک تصویر اسلاید تولید کنید و آن را در یک حافظهٔ موقت ذخیره کنید.
    - تصویر اسلاید را با استفاده از متد `InsertImage` از کلاس [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) به سند Word اضافه کنید.
6. سند Word را در یک فایل ذخیره کنید.

فرض کنید یک ارائه به نام «sample.pptx» داریم که به این شکل است:

![ارائه پاورپوینت](PowerPoint.png)

مثال کد C# زیر نشان می‌دهد چگونه ارائه PowerPoint را به سند Word تبدیل کنیم:

```cs
using Aspose.Slides;
using Aspose.Words;

// یک فایل ارائه را بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// اشیاء Document و DocumentBuilder را ایجاد کنید.
var document = new Document();
var builder = new DocumentBuilder(document);

// اندازه صفحه را در سند Word تنظیم کنید.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// حاشیه‌ها را در سند Word تنظیم کنید.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// از تمام اسلایدهای ارائه عبور کنید.
foreach (var slide in presentation.Slides)
{
    // یک تصویر اسلاید تولید کنید و آن را در یک جریان حافظه ذخیره کنید.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // تصویر اسلاید را به سند Word اضافه کنید.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Save the Word document to a file.
document.Save("output.docx");
```

نتیجه:

![سند Word](Word.png)

{{% alert color="info" %}} 
سعی کنید از [**مبدل آنلاین PPT به Word**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما استفاده کنید تا متوجه شوید چه مزایایی از تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word می‌توانید بهره‌مند شوید. 
{{% /alert %}}

## **سؤالات متداول**

### برای تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word به چه اجزایی نیاز است؟

فقط کافی است بسته‌های NuGet مربوط به [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) و [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) را به پروژهٔ C# خود اضافه کنید. هر دو کتابخانه به صورت API‌های مستقل کار می‌کنند و نیازی به نصب Microsoft Office ندارید.

### آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟

Aspose.Slides برای .NET [تمام فرمت‌های ارائه را پشتیبانی می‌کند](/slides/fa/net/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر انواع فایل‌های رایج. این به این معناست که می‌توانید با ارائه‌های ایجاد شده در نسخه‌های مختلف Microsoft PowerPoint کار کنید.