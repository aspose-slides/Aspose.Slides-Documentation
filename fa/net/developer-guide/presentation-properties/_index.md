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
- تغییر ویژگی‌ها
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
description: "درک کامل ویژگی‌های ارائه در Aspose.Slides برای .NET و بهینه‌سازی جستجو، برندینگ و جریان کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **معرفی**

Aspose.Slides for .NET دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides for .NET دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) کار کنید. نمونه‌ای از این رابط توسط ویژگی [Presentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" %}} 
لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** نمی‌توانند تغییر کنند، زیرا این فیلدها همیشه «Aspose Ltd.» و «Aspose.Slides for .NET x.x.x» را نشان می‌دهند.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند امکان ذخیره اطلاعات مفید همراه با فایل‌ها را می‌دهند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (custom)

ویژگی‌های **Built-in** اطلاعات کلی درباره سند را شامل می‌شوند، مانند عنوان سند، نام نویسنده، آمار سند، و غیره.

ویژگی‌های **Custom** توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند که هر دو نام و مقدار توسط کاربر مشخص می‌شود.

با استفاده از Aspose.Slides for .NET، توسعه‌دهندگان می‌توانند به هر دو ویژگی built-in و custom دسترسی پیدا کرده و آن‌ها را تغییر دهند.

Microsoft PowerPoint به کاربران امکان مدیریت ویژگی‌های سند را با کلیک بر روی آیکن Office و سپس انتخاب **File → Info → Properties** می‌دهد. پس از انتخاب **Advanced Properties**، دیالوگی ظاهر می‌شود که در آن می‌توانید همه ویژگی‌های سند فایل ارائه را مدیریت کنید.

در دیالوگ **Properties**، چندین برگه وجود دارد، مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom**. هر برگه گزینه‌هایی برای پیکربندی انواع خاصی از اطلاعات مربوط به فایل PowerPoint فراهم می‌کند. برگه **Custom** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها، که توسط رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) در دسترس قرار می‌گیرند، شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **SharedDoc** (نشان می‌دهد آیا سند بین تولیدکنندگان مختلف به اشتراک گذاشته شده است)، **PresentationFormat**، **Subject**، **Title** و موارد دیگر می‌باشند.

```cs
using Aspose.Slides;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// دریافت یک ارجاع به شیء از نوع IDocumentProperties مرتبط با ارائه.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// نمایش ویژگی‌های داخلی.
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

تغییر ویژگی‌های built-in فایل‌های ارائه به همان آسانی که به آن‌ها دسترسی دارید امکان‌پذیر است. شما می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی به‌روزرسانی می‌شود. در مثال زیر، نحوه تغییر ویژگی‌های سند built-in یک فایل ارائه را نشان می‌دهیم.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// دریافت یک ارجاع به شیء از نوع IDocumentProperties مرتبط با ارائه.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تنظیم ویژگی‌های داخلی.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی ارائه به توسعه‌دهندگان امکان می‌دهد تا متادیتای اضافی یا اطلاعات خاصی را درون فایل ارائه ذخیره کنند. Aspose.Slides ایجاد و مدیریت این ویژگی‌های سفارشی را به‌صورت برنامه‌نویسی ساده می‌کند. مثال‌های زیر نشان می‌دهند چگونه ویژگی‌های سفارشی را به ارائه‌های خود اضافه کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation.
using Presentation presentation = new Presentation();

// دریافت یک ارجاع به شیء از نوع IDocumentProperties مرتبط با ارائه.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// افزودن ویژگی‌های سفارشی.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// ذخیره ارائه در یک فایل.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides همچنین به توسعه‌دهندگان اجازه می‌دهد تا به ویژگی‌های سفارشی موجود دسترسی پیدا کرده و مقادیر آن‌ها را به راحتی تغییر دهند. این قابلیت به حفظ متادیتای دقیق کمک می‌کند و به‌روزرسانی‌های پویا بر اساس ورودی کاربر یا منطق کسب‌وکار را پشتیبانی می‌کند. مثال‌های زیر نشان می‌دهند چگونه مقادیر ویژگی سفارشی را درون یک ارائه بازیابی و به‌روزرسانی کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// دریافت یک ارجاع به شیء از نوع IDocumentProperties مرتبط با ارائه.
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

// ذخیره ارائه در یک فایل.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides با ویژگی‌های سند کار می‌کنید:

[![نمایش و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***FAQ**

### چگونه می‌توان یک ویژگی built-in را از یک ارائه حذف کرد؟

ویژگی‌های built-in جزئی اساسی از ارائه هستند و نمی‌توان آن‌ها را به‌ طور کامل حذف کرد. اما می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورتی که ویژگی خاص اجازه دهد، به مقدار خالی تنظیم کنید.

### چه اتفاقی می‌افتد اگر یک ویژگی سفارشی که پیش از این موجود است را اضافه کنم؟

اگر یک ویژگی سفارشی که پیش از این موجود است را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

### آیا می‌توانم بدون بارگذاری کامل ارائه، به ویژگی‌های ارائه دسترسی داشته باشم؟

بله، می‌توانید بدون بارگذاری کامل ارائه، به ویژگی‌های ارائه دسترسی پیدا کنید با استفاده از متد `GetPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/). سپس، متد `ReadDocumentProperties` ارائه‌شده توسط رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) را به‌کار ببرید تا ویژگی‌ها را به‌صورت کارآمد بخوانید، حافظه را ذخیره کرده و عملکرد را بهبود بخشید.