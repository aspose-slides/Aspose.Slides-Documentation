---
title: مدیریت ویژگی‌های ارائه در .NET
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/net/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های پیش‌ساخته
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- متادیتای سند
- ویرایش متادیتا
- زبان ویراستاری
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های اصلی ارائه در Aspose.Slides برای .NET را مدیریت کنید و جستجو، برندینگ و گردش کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides for .NET دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides for .NET دسترسی یافته و مدیریت شوند.

Aspose.Slides به شما اجازه می‌دهد که از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) با ویژگی‌های سند ارائه کار کنید. یک نمونه از این رابط توسط [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند که چگونه می‌توان این ویژگی‌ها را خواند، تغییر داد و مدیریت کرد.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل تغییر نیستند، زیرا این فیلدها همیشه مقدار "Aspose Ltd." و "Aspose.Slides for .NET x.x.x" را نمایش می‌دهند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint یک ویژگی برای افزودن ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفید همراه با فایل‌ها ذخیره شوند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های سیستم‌تعریف‌شده (built-in)
- ویژگی‌های کاربر-تعریف‌شده (custom)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند هستند، مانند عنوان سند، نام نویسنده، آمار سند و موارد دیگر.

ویژگی‌های **Custom** توسط کاربران به‌صورت جفت **Name/Value** تعریف می‌شوند که هر دو نام و مقدار توسط کاربر تعیین می‌شود.

با استفاده از Aspose.Slides for .NET، توسعه‌دهندگان می‌توانند به هر دو نوع ویژگی built-in و custom دسترسی داشته و آنها را تغییر دهند.

Microsoft PowerPoint به کاربران اجازه می‌دهد که ویژگی‌های سند را با کلیک بر روی نماد Office و سپس انتخاب **File → Info → Properties** مدیریت کنند. پس از انتخاب **Advanced Properties**، یک گفت‌وگو ظاهر می‌شود که می‌توانید تمام ویژگی‌های سند فایل ارائه را مدیریت کنید.

در گفت‌وگوی **Properties**، چندین تب وجود دارد، مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom**.
هر تب گزینه‌هایی برای پیکربندی انواع خاصی از اطلاعات مرتبط با فایل PowerPoint ارائه می‌دهد. تب **Custom** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده می‌شود.

## **خواندن ویژگی‌های عمومی از یک ارائه‌ رمزگذاری‌شده**

یک رمز عبور بازکردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. هنگامی که یک ارائه با [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) که مقدار `false` دارد رمزگذاری می‌شود، ویژگی‌های سند آن به صورت عمومی باقی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) را به `true` تنظیم کند و متادیتای عمومی را بدون ارائه رمز عبور بازکردن بخواند.

`OnlyLoadDocumentProperties` تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری کند؛ هیچ چیز را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آنها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال زیر حالت بارگذاری را با استفاده از [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) بررسی می‌کند و سپس ویژگی‌های built-in را از طریق [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/documentproperties/) می‌خواند:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، الگوها (masters)، طرح‌ها (layouts)، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل کامل شیء ارائه نیاز دارد، `IsOnlyDocumentPropertiesLoaded` را بررسی کنند.

{{% alert color="warning" title="Security" %}}
متادیتای عمومی ممکن است نام‌های نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را افشا کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. آنها را فقط در صورتی عمومی بگذارید که سامانه‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه‌ رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که با `OnlyLoadDocumentProperties` بارگذاری می‌شود برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مربوطه در داخل ارائه رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آنها نیاز به رمز عبور بازکردن صحیح و بارگذاری کامل دارد.

مثال زیر ارائه را با استفاده از [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) باز می‌کند، ویژگی‌های عمومی built-in را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/isencrypted/) بررسی می‌کند که رمزگذاری حفظ شده است و متادیتای عمومی را بدون رمز عبور مجدداً باز می‌کند تا مقادیر جدید را تأیید کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

اگر یک برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها، همان‌طور که توسط رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) ارائه می‌شود، شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ چاپ آخر)، **LastModifiedBy**، **SharedDoc** (نشان می‌دهد که آیا سند بین تولیدکنندگان مختلف به اشتراک گذاشته شده است)، **PresentationFormat**، **Subject**، **Title** و موارد دیگر هستند.

```cs
using Aspose.Slides;

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// دریافت یک مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// نمایش ویژگی‌های Built-in.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های built-in فایل‌های ارائه به همان سادگی دسترسی به آن‌هاست. شما می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی به‌روز می‌شود. در مثال زیر، نحوهٔ تغییر ویژگی‌های سند built-in یک فایل ارائه را نشان می‌دهیم.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// دریافت مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تنظیم ویژگی‌های Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی ارائه به توسعه‌دهندگان امکان می‌دهد متادیتای اضافی یا اطلاعات خاصی را داخل یک فایل ارائه ذخیره کنند. Aspose.Slides ایجاد و مدیریت این ویژگی‌های سفارشی را به صورت برنامه‌نویسی آسان می‌کند. مثال‌های زیر نشان می‌دهند که چگونه می‌توانید ویژگی‌های سفارشی را به ارائه‌های خود اضافه کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation را ایجاد کنید.
using Presentation presentation = new Presentation();

// دریافت مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// افزودن ویژگی‌های سفارشی.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// ذخیرهٔ ارائه در یک فایل.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides همچنین به توسعه‌دهندگان اجازه می‌دهد به ویژگی‌های سفارشی موجود دسترسی پیدا کرده و مقادیر آن‌ها را به راحتی تغییر دهند. این قابلیت به حفظ متادیتای دقیق کمک می‌کند و به‌روزرسانی‌های پویا بر اساس ورودی کاربر یا منطق تجاری را پشتیبانی می‌نماید. مثال‌های زیر نشان می‌دهند که چگونه می‌توان مقادیر ویژگی سفارشی را داخل یک ارائه استخراج و به‌روزرسانی کرد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد کنید.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// دریافت مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// دسترسی و تغییر ویژگی‌های سفارشی.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // نمایش نام و مقدار ویژگی سفارشی.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // تغییر مقدار ویژگی سفارشی.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// ذخیرهٔ ارائه در یک فایل.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

اپلیکیشن آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با ویژگی‌های سند با استفاده از API Aspose.Slides کار می‌کند:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی built-in را از یک ارائه حذف کنم؟**

ویژگی‌های built-in بخش جدایی‌ناپذیر ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. با این حال، می‌توانید مقادیر آن‌ها را تغییر داده یا در صورت اجازه ویژگی خاص، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً موجود است را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیش‌ازاین ویژگی ندارید، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کنم؟**

بله. از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید و سپس [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) را فراخوانی کنید تا متادیتای ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب، به [Build a Lightweight Presentation Inventory](/slides/fa/net/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور بازکردن آن بخوانم؟**

بله. ارائه باید با `EncryptDocumentProperties` برابر `false` رمزگذاری شده باشد و با `OnlyLoadDocumentProperties` برابر `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‌های‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شدهٔ ویژگی باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور بازکردن صحیح است.