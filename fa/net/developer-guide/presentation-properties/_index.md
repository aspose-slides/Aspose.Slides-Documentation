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
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- ویرایش ویژگی‌ها
- متادیتای سند
- ویرایش متادیتا
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای .NET به‌صورت جامع مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه کنید."
---
## **مقدمه**

Aspose.Slides for .NET دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides for .NET دسترسی پیدا کرده و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط ویژگی [Presentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، ویرایش کنید و مدیریت نمایید.

{{% alert color="info" title="Note" %}}

لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل ویرایش نیستند، زیرا این فیلدها همیشه «Aspose Ltd.» و «Aspose.Slides for .NET x.x.x» را نشان می‌دهند.

{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی افزودن ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند امکان ذخیره‌سازی اطلاعات مفید همراه با فایل‌ها را می‌دهند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (custom)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند هستند، مانند عنوان سند، نام نویسنده، آمار سند و موارد دیگر.

ویژگی‌های **Custom** توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند، که در آن هر دو، نام و مقدار، توسط کاربر تعیین می‌شود.

با استفاده از Aspose.Slides for .NET، توسعه‌دهندگان می‌توانند به هر دو نوع ویژگی‌های built-in و custom دسترسی داشته و آن‌ها را ویرایش کنند.

Microsoft PowerPoint به کاربران امکان مدیریت ویژگی‌های سند را با کلیک بر روی آیکون Office و سپس انتخاب **File → Info → Properties** می‌دهد. پس از انتخاب **Advanced Properties**، یک دیالوگ ظاهر می‌شود که در آن می‌توانید تمام ویژگی‌های سند فایل ارائه را مدیریت کنید.

در دیالوگ **Properties**، چندین برگه وجود دارد، از جمله **General**، **Summary**، **Statistics**، **Contents** و **Custom**.
هر برگه گزینه‌هایی برای پیکربندی انواع خاصی از اطلاعات مرتبط با فایل PowerPoint فراهم می‌کند. برگه **Custom** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها، همان‌طور که توسط رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) نشان داده می‌شود، شامل: **Creator** (Author)، **Description**، **Keywords**، **Created** (Creation Date)، **Modified** (Modification Date)، **Printed** (Last Print Date)، **LastModifiedBy**، **SharedDoc** (نشان می‌دهد آیا سند بین تولیدکنندگان مختلف به اشتراک گذاشته شده است)، **PresentationFormat**، **Subject**، **Title** و موارد دیگر می‌باشند.

```cs
using Aspose.Slides;

// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// یک مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است دریافت کنید.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// ویژگی‌های داخلی را نمایش دهید.
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

## **ویرایش ویژگی‌های Built-in**

ویرایش ویژگی‌های built-in فایل‌های ارائه به همان اندازه ساده است که دسترسی به آنها. می‌توانید به سادگی یک مقدار رشته‌ای را به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی به‌روزرسانی خواهد شد. در مثال زیر، نحوه ویرایش ویژگی‌های سند built-in یک فایل ارائه را نشان می‌دهیم.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// یک مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است دریافت کنید.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// ویژگی‌های داخلی را تنظیم کنید.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// ارائه را در یک فایل ذخیره کنید.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی ارائه به توسعه‌دهندگان امکان می‌دهد متادیتای اضافی یا اطلاعات خاصی را درون یک فایل ارائه ذخیره کنند. Aspose.Slides ایجاد و مدیریت این ویژگی‌های سفارشی را به‌صورت برنامه‌نویسی آسان می‌کند. مثال‌های زیر نشان می‌دهند چگونه ویژگی‌های سفارشی را به ارائه‌های خود اضافه کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation را ایجاد کنید.
using Presentation presentation = new Presentation();

// یک مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است دریافت کنید.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// ویژگی‌های سفارشی را اضافه کنید.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// ارائه را در یک فایل ذخیره کنید.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **دسترسی و ویرایش ویژگی‌های سفارشی**

Aspose.Slides همچنین به توسعه‌دهندگان امکان می‌دهد تا به ویژگی‌های سفارشی موجود دسترسی پیدا کرده و مقادیر آنها را به‌راحتی ویرایش کنند. این قابلیت به حفظ متادیتای دقیق کمک کرده و به‌روزرسانی‌های پویا بر پایه ورودی کاربر یا منطق کسب‌وکار را پشتیبانی می‌کند. مثال‌های زیر نشان می‌دهند چگونه مقادیر ویژگی‌های سفارشی را درون یک ارائه بازیابی و به‌روزرسانی کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد کنید.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// یک مرجع به شیء از نوع IDocumentProperties که به ارائه مرتبط است دریافت کنید.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// دسترسی و ویرایش ویژگی‌های سفارشی.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // نام و مقدار ویژگی سفارشی را نمایش دهید.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // مقدار ویژگی سفارشی را ویرایش کنید.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// ارائه را در یک فایل ذخیره کنید.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**مشاهده و ویرایش متادیتای PowerPoint**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides با ویژگی‌های سند کار می‌کنید:

[![مشاهده و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی built-in را از یک ارائه حذف کنم؟**

ویژگی‌های built-in بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت امکان، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی خواهد شد. نیازی به حذف یا بررسی پیش از اضافه کردن ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه، به ویژگی‌های آن دسترسی داشته باشم؟**

بله. از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) و سپس [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) استفاده کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به مقالهٔ [Build a Lightweight Presentation Inventory](/slides/fa/net/examine-presentation/) مراجعه کنید.