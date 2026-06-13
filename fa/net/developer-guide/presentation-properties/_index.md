---
title: مدیریت ویژگی‌های ارائه‌نامه در .NET
linktitle: ویژگی‌های ارائه‌نامه
type: docs
weight: 70
url: /fa/net/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه‌نامه
- ویژگی‌های سند
- ویژگی‌های ساختاری
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- متادیتای سند
- ویرایش متادیتا
- زبان تصحیح
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه‌نامه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های ارائه‌نامه را در Aspose.Slides برای .NET بهینه کنید و جستجو، برندینگ و جریان کار را در فایل‌های پاورپوینت و OpenDocument خود ساده‌سازی کنید."
---
## **مقدمه**

Aspose.Slides for .NET دو نوع ویژگی سند را پشتیبانی می‌کند: **ساختاری** و **سفارشی**. هر دو نوع ویژگی به‌راحتی می‌توانند با استفاده از API Aspose.Slides for .NET دسترسی پیدا کرده و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه‌نامه را از طریق رابط کاربری [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) می‌دهد. یک نمونه از این رابط از طریق ویژگی [Presentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="primary" %}} 

لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل تغییر نیستند، زیرا این فیلدها همیشه مقدار “Aspose Ltd.” و “Aspose.Slides for .NET x.x.x” را نمایش می‌دهند.

{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه‌نامه**

Microsoft PowerPoint امکان افزودن ویژگی‌ها به فایل‌های ارائه‌نامه را فراهم می‌کند. این ویژگی‌های سند اطلاعات مفیدی را همراه با فایل‌ها ذخیره می‌کنند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (ساختاری)
- ویژگی‌های تعریف‌شده توسط کاربر (سفارشی)

ویژگی‌های **ساختاری** شامل اطلاعات کلی درباره سند هستند، مانند عنوان سند، نام نویسنده، آمار سند و غیره.

ویژگی‌های **سفارشی** به‌صورت جفت **نام/مقدار** تعریف می‌شوند که هر دو توسط کاربر مشخص می‌شوند.

با استفاده از Aspose.Slides for .NET، توسعه‌دهندگان می‌توانند هم ویژگی‌های ساختاری و هم سفارشی را دسترسی و تغییر دهند.

Microsoft PowerPoint به کاربران اجازه می‌دهد ویژگی‌های سند را با کلیک بر آیکون Office، سپس انتخاب **File → Info → Properties** مدیریت کنند. پس از انتخاب **Advanced Properties**، دیالوگی ظاهر می‌شود که می‌توانید تمام ویژگی‌های سند فایل ارائه‌نامه را مدیریت کنید.

در دیالوگ **Properties**، چندین برگه وجود دارد، از جمله **عمومی**, **خلاصه**, **آمار**, **محتوا**, و **سفارشی**.
هر برگه گزینه‌هایی برای پیکربندی انواع خاصی از اطلاعات مرتبط با فایل PowerPoint فراهم می‌کند. برگه **سفارشی** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده می‌شود.

## **دسترسی به ویژگی‌های ساختاری**

این ویژگی‌ها که توسط رابط کاربری [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) در دسترس هستند، شامل: **Creator** (نویسنده), **Description**, **Keywords**, **Created** (تاریخ ایجاد), **Modified** (تاریخ تغییر), **Printed** (آخرین تاریخ چاپ), **LastModifiedBy**, **SharedDoc** (نشان می‌دهد آیا سند بین تولیدکنندگان مختلف به اشتراک گذاشته شده است)، **PresentationFormat**, **Subject**, **Title** و موارد دیگر می‌باشند.

```cs
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه‌نامه است.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

## **تغییر ویژگی‌های ساختاری**

تغییر ویژگی‌های ساختاری فایل‌های ارائه‌نامه به همان سادگی دسترسی به آن‌هاست. می‌توانید به سادگی یک مقدار متنی به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی به‌روزرسانی می‌شود. در مثال زیر نحوه تغییر ویژگی‌های ساختاری سند یک فایل ارائه‌نامه را نشان می‌دهیم.

```cs
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه‌نامه است.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// دریافت یک مرجع به شیء نوع IDocumentProperties مرتبط با ارائه‌نامه.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تنظیم ویژگی‌های ساختاری.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// ذخیره ارائه‌نامه در یک فایل.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **افزودن ویژگی‌های سفارشی به ارائه‌نامه**

ویژگی‌های سفارشی ارائه‌نامه به توسعه‌دهندگان امکان ذخیره‌سازی داده‌های متادیتای اضافی یا اطلاعات خاص داخل فایل ارائه‌نامه را می‌دهد. Aspose.Slides ایجاد و مدیریت این ویژگی‌های سفارشی را به‌صورت برنامه‌نویسی ساده می‌کند. مثال‌های زیر نشان می‌دهند چگونه ویژگی‌های سفارشی را به ارائه‌نامه‌های خود اضافه کنید.

```cs
// نمونه‌سازی کلاس Presentation.
using Presentation presentation = new Presentation();

// دریافت مرجع به شیء نوع IDocumentProperties مرتبط با ارائه‌نامه.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// افزودن ویژگی‌های سفارشی.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// ذخیره ارائه‌نامه در یک فایل.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides همچنین به توسعه‌دهندگان اجازه می‌دهد ویژگی‌های سفارشی موجود را دسترسی داشته و مقادیر آن‌ها را به‌راحتی تغییر دهند. این قابلیت به حفظ متادیتای دقیق کمک کرده و به‌روزرسانی‌های پویا بر اساس ورودی کاربر یا منطق کسب‌وکار را پشتیبانی می‌کند. مثال‌های زیر نشان می‌دهند چگونه مقادیر ویژگی سفارشی را داخل یک ارائه‌نامه بازیابی و به‌روزرسانی کنید.

```cs
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
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

// ذخیره ارائه‌نامه در یک فایل.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

برنامه آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با استفاده از API Aspose.Slides با ویژگی‌های سند کار کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سؤالات متداول**

**چگونه می‌توان یک ویژگی ساختاری را از یک ارائه‌نامه حذف کرد؟**

ویژگی‌های ساختاری بخش جدایی‌ناپذیر ارائه‌نامه هستند و نمی‌توان آن‌ها را کاملاً حذف کرد. با این حال می‌توانید مقدار آن‌ها را تغییر دهید یا در صورتی که ویژگی اجازه دهد، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی ویژگی پیش از اضافه کردن ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه‌نامه را بدون بارگذاری کامل ارائه‌نامه دسترسی داشت؟**

بله، می‌توانید ویژگی‌های ارائه‌نامه را بدون بارگذاری کامل با استفاده از متد `GetPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/) دسترسی داشته باشید. سپس با استفاده از متد `ReadDocumentProperties` ارائه‌شده توسط رابط کاربری [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) ویژگی‌ها را به‌صورت کارآمد بخوانید و حافظه و عملکرد را بهبود بخشید.