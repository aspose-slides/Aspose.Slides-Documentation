---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها در .NET
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/net/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- بخش XML سفارشی
- فراداده XML
- ItemId
- افزودن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یادگیری نحوه مدیریت برچسب‌ها و داده‌های XML سفارشی در ارائه‌های PowerPoint با Aspose.Slides برای .NET، شامل افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های مربوط به ارائه می‌توانند به‌صورت برچسب‌ها یا بخش‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده‌اند، در حالی که بخش‌های XML سفارشی می‌توانند فراداده‌های ساختاری و بارهای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل ارائه می‌دهد. بخش‌های XML سفارشی برای یکپارچه‌سازی‌هایی مفید هستند که اطلاعاتی نظیر شناسه‌های مدیریت سند، وضعیت جریان‌کار، فراداده‌های انطباق، داده‌های اتصال الگو یا سایر داده‌های ساختاری برنامه را داخل یک ارائه ذخیره می کنند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX — فایل‌هایی با پسوند `.pptx` — در قالب PresentationML که بخشی از مشخصات Office Open XML است، ذخیره می‌شوند. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش است که توسط روابط به هم مرتبط هستند. به عنوان مثال، یک بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/itagcollection)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection)) ذخیره شوند. هر دو از طریق اینترفیس [`ICustomData`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomdata/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاری را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

ویژگی [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomdata/customxmlparts/) مجموعه‌ای از بخش‌های XML سفارشی مرتبط با یک شیء ارائه خاص را بر می‌گرداند. به عنوان مثال:

- `presentation.CustomData.CustomXmlParts` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.CustomData.CustomXmlParts` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape.CustomData.CustomXmlParts` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

هنگامی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، می‌توانید از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) استفاده کنید.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/add/) برای افزودن داده‌های XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیرخالی باشد.

مثال زیر فراداده‌های ساختاری را به مجموعهٔ داده‌های سفارشی سطح ارائه اضافه می‌کند:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add به‌طور خودکار یک شناسه اختصاص می‌دهد. فقط در صورت نیاز یک GUID خاص تنظیم کنید.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

متد `Add` می‌تواند XML را به‌صورت آرایهٔ بایت یا جریان نیز دریافت کند؛ این حالت وقتی مفید است که محتوای XML از پیش به‌صورت باینری موجود باشد.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به یک اسلاید یا شکل خاص نسبت داده شوند نه به کل ارائه. این کار زمانی مفید است که فراداده تنها یک شیء را توصیف می‌کند، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات اتصال.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و دیگری را به یک شکل اضافه می‌کند:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

سطحي که یک بخش اضافه می‌شود تعیین می‌کند کدام مجموعهٔ `CustomData.CustomXmlParts` آن رابطه را شامل می‌شود. داده‌های سطح ارائه برای فراداده‌های سراسری سند، داده‌های سطح اسلاید برای اطلاعاتی که به یک اسلاید خاص تعلق دارد، و داده‌های سطح شکل برای فراداده‌های وابسته به یک شکل فردی مناسب‌اند.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) برای دریافت تمام بخش‌های XML سفارشی یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/) شناسه، محتوای XML و طرحواره‌های فضای‌نام مرتبط را نشان می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرحواره‌های فضای‌نام آن‌ها را فهرست می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

ویژگی [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/namespaceschemas/) طرحواره‌های XML مرتبط با بخش XML سفارشی را بر می‌گرداند. این اطلاعات هنگام بررسی ارائه‌هایی که حاوی XML تولید شده توسط سیستم‌های خارجی هستند، مفید است.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/xmlasstring/) برای کار با XML به صورت رشتهٔ UTF‑8 استفاده کنید، یا از [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/xmldata/) برای کار با بایت‌های خام XML. هر دو ویژگی قابل خواندن و به‌روزرسانی‌اند.

ویژگی [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/itemid/) GUIDی را شامل می‌شود که بخش XML سفارشی را در سند Office Open XML شناسایی می‌کند. هنگام نیاز یکپارچه‌سازی به شناسهٔ جدید می‌توان آن را تغییر داد.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// XML جاری را به‌صورت متن بخوانید.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// XML را به‌عنوان رشته UTF-8 به‌روزرسانی کنید.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// در صورت نیاز یکپارچه‌سازی، شناسه را جایگزین کنید.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

هنگام اختصاص `XmlAsString` یا `XmlData`، XML معتبر و غیرخالی ارائه دهید. بسته به این که برنامه اصلیاً با رشته یا داده بایت کار می‌کند، یکی از این دو نمایندگی را استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چند روش برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/remove/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/remove/) یک بخش خاص را از مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/removeat/) بخش را در شاخص مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/clear/) تمام بخش‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را با ارجاع حذف می‌کند:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

اگر پیشاپیش یک `ICustomXmlPart` دارید و می‌خواهید آن را از ارائه حذف کنید نه از یک مجموعهٔ خاص، کافی است `customXmlPart.Remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را بر اساس شاخص حذف کنید:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

زمانی که تمام بخش‌های XML سفارشی مرتبط با یک شیء ارائه باید حذف شوند، از `Clear` استفاده کنید.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` فقط بر روی مجموعهٔ انتخابی اثر می‌گذارد. به عنوان مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف همهٔ بخش‌های XML سفارشی در ارائه، می‌توانید از `AllCustomXmlParts` پیمایش کنید و هر بخش را حذف کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **مدیریت بخش‌های XML سفارشی پیوند شده یا مشترک**

در یک ارائه Office Open XML، همان بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به عنوان یک شیء دادهٔ واحد با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی `XmlAsString`، `XmlData` یا `ItemId` بخش زیرین XML سفارشی را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن بخش ارجاع شده است اعمال می‌شود.
- `ItemId` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `CustomXmlParts` خاص، تنها آن را از همان مجموعه حذف می‌کند. برای حذف کل بخش از ارائه از `ICustomXmlPart.Remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا مشخص شود آیا اسلایدها یا اشکال دیگر هنوز به آن ارجاع دارند یا نه.

بازنشانی `Add` فقط یک بخش XML سفارشی جدید از محتوای XML می‌سازد؛ ورودی یک `ICustomXmlPart` موجود را نمی‌پذیرد. بنابراین، روابط مشترک بیشتر هنگام بارگذاری ارائه‌هایی که قبلاً شامل چنین روابطی هستند، مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر پایهٔ `ItemId` بررسی می‌کند و بخش‌هایی که از بیش از یک مکان ارجاع شده‌اند گزارش می‌دهد:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

این نوع بررسی پیش از تغییر یا حذف داده‌های XML سفارشی در ارائه‌هایی که توسط سیستم‌های خارجی ایجاد شده‌اند، مفید است، چرا که همان بخش فراداده ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب متناظر با ویژگی `IDocumentProperties.Keywords` است. این نمونه کد نشان می‌دهد که چگونه مقدار یک برچسب را با Aspose.Slides برای .NET از یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) دریافت کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً از دو مورد تشکیل می‌شود:

- نام یک ویژگی سفارشی، برای مثال `MyTag`;
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قانون یا ویژگی خاص دارید، می‌توانید برای این منظور برچسب‌ها اضافه کنید. به عنوان مثال، برای دسته‌بندی ارائه‌های کشورهای آمریکای شمالی می‌توانید یک برچسب «North American» ایجاد کنید و کشور مربوطه را به عنوان مقدار آن تعیین کنید.

این نمونه کد نشان می‌دهد که چگونه یک برچسب را به یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) با استفاده از Aspose.Slides برای .NET اضافه کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/net/aspose.slides/slide) نیز تنظیم شوند:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/shape) منفرد:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **محدودیت‌ها**

برچسب‌های افزوده شده از طریق مجموعهٔ `CustomData.Tags` فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب‌های PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راهکار:** می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** شیء ذخیره کنید (به عنوان مثال، `shape.AlternativeText = "MyId"`). پس از صادرات به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) از عملیات [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌کند.

**چگونه می‌توانم یک برچسب را تنها با نام آن حذف کنم بدون این که کل مجموعه را پیمایش کنم؟**

از [Remove(name)](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/remove/) بر روی [TagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلیدش حذف کنید.

**چگونه می‌توانم فهرست کامل نام برچسب‌ها را برای تجزیه و تحلیل یا فیلترینگ بازیابی کنم؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/getnamesoftags/) بر روی مجموعهٔ برچسب‌ها استفاده کنید؛ این متد آرایه‌ای از تمام نام برچسب‌ها را بر می‌گرداند.

**چگونه می‌توانم همهٔ بخش‌های XML سفارشی را پیدا کنم بدون توجه به محل ذخیره‌سازی آن‌ها؟**

از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) برای دریافت تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا برای به‌روزرسانی یک بخش XML سفارشی باید از `XmlAsString` یا `XmlData` استفاده کنم؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند، از `XmlAsString` استفاده کنید. وقتی XML پیشاپیش به صورت آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است، از `XmlData` استفاده کنید. هر دو ویژگی محتوای XML یک بخش XML سفارشی را نشان می‌دهند.