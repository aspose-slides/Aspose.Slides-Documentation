---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها در .NET
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/net/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده سفارشی
- XML سفارشی
- قسمت XML سفارشی
- متادیتا XML
- ItemId
- افزودن برچسب
- مقدارهای جفت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با Aspose.Slides برای .NET یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint مدیریت کنید، شامل افزودن، خواندن، به‌روزرسانی، بازرسی و حذف قسمت‌های XML سفارشی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص ارائه می‌توانند به‌صورت برچسب یا قسمت‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که قسمت‌های XML سفارشی می‌توانند فراداده ساختار یافته و محتوای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بازرسی و حذف قسمت‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. قسمت‌های XML سفارشی برای ادغام‌هایی مفید هستند که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت جریان کار، فراداده‌های انطباق، داده‌های پیوند الگو یا سایر داده‌های ساختار یافته برنامه‌ای را داخل یک ارائه ذخیره می‌کنند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX―فایلی با پسوند `.pptx`―در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش است که توسط روابط به‌یکدیگر متصل می‌شوند. برای مثال، یک بخش اسلاید حاوی محتوای یک اسلاید است و می‌تواند روابط صریحی به سایر بخش‌ها داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/itagcollection)) یا قسمت‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection)) ذخیره شوند. هر دو از طریق اینترفیس [`ICustomData`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomdata/) در دسترس هستند.

{{% alert color="info" %}}

برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. قسمت‌های XML سفارشی داده‌های XML ساختار یافته را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.

{{% /alert %}}

## **کار با قسمت‌های XML سفارشی**

خاصیت [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomdata/customxmlparts/) مجموعه‌ای از قسمت‌های XML سفارشی مرتبط با یک شیء ارائه خاص را برمی‌گرداند. برای مثال:

- `presentation.CustomData.CustomXmlParts` شامل قسمت‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.CustomData.CustomXmlParts` شامل قسمت‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape.CustomData.CustomXmlParts` شامل قسمت‌های XML سفارشی مرتبط با یک شکل خاص است.

هنگامی که نیاز به بررسی تمام قسمت‌های XML سفارشی در ارائه دارید، از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) استفاده کنید، بدون توجه به محل ارتباط آن‌ها.

### **افزودن یک قسمت XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/add/) برای افزودن داده XML به مجموعهٔ قسمت‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر فراداده ساختار یافته را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

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

// Add یک شناسه را به‌صورت خودکار اختصاص می‌دهد. فقط در صورت نیاز یک GUID خاص تنظیم کنید.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

متد `Add` همچنین می‌تواند XML را به‌صورت آرایه بایت یا جریان (stream) دریافت کند، که وقتی محتوای XML قبلاً به‌صورت باینری در دسترس باشد مفید است.

### **افزودن یک قسمت XML سفارشی به اسلاید یا شکل**

داده XML سفارشی می‌تواند به یک اسلاید یا شکل خاص به‌جای کل ارائه متصل شود. این کار زمانی مفید است که فراداده تنها برای یک شیء، مثل کلید الگو، شناسه رکورد خارجی یا اطلاعات پیوند باشد.

مثال زیر یک قسمت XML سفارشی به یک اسلاید و دیگری به یک شکل اضافه می‌کند:

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

سطحی که یک بخش در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `CustomData.CustomXmlParts` شیء، رابطهٔ آن بخش را دارد. داده‌های سطح ارائه برای فراداده کلی سند مناسب‌اند، داده‌های سطح اسلاید برای اطلاعات متعلق به یک اسلاید خاص، و داده‌های سطح شکل برای فراداده‌های مرتبط با یک شکل منفرد.

### **فهرست و بازرسی تمام قسمت‌های XML سفارشی**

از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) برای بازیابی تمام قسمت‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/) شناسه، محتوای XML و طرح‌سوم‌های فضای‌نام مرتبط را در اختیار می‌گذارد.

مثال زیر تمام قسمت‌های XML سفارشی و طرح‌سوم‌های فضای‌نام آن‌ها را فهرست می‌کند:

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

خاصیت [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/namespaceschemas/) طرح‌سوم‌های XML مرتبط با قسمت XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بازرسی ارائه‌هایی که حاوی XML تولید شده توسط سیستم‌های خارجی هستند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/xmlasstring/) برای کار با XML به‌صورت رشته UTF‑8 یا از [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/xmldata/) برای کار با بایت‌های خام XML استفاده کنید. هر دو خاصیت قابل خواندن و به‌روزرسانی هستند.

خاصیت [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/itemid/) GUIDی را که بخش XML سفارشی را در سند Office Open XML شناسایی می‌کند، در خود دارد. هنگامیکه یکپارچه‌سازی نیاز به شناسه جدید داشته باشد، می‌تواند تغییر یابد.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// خواندن XML فعلی به‌صورت متن.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// به‌روزرسانی XML به‌صورت رشته UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData محتوای XML یکسان را به‌صورت بایت خام ارائه می‌دهد.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// جایگزینی شناسه هنگام نیاز یکپارچه‌سازی.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

هنگام اختصاص `XmlAsString` یا `XmlData`، XML معتبر و غیر خالی فراهم کنید. بسته به اینکه برنامه عمدتاً با رشته یا داده بایت کار می‌کند، یکی از این دو نمایندگی را استفاده کنید.

### **حذف یک قسمت XML سفارشی**

Aspose.Slides چند روش برای حذف داده XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpart/remove/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/remove/) بخش خاصی را از یک مجموعهٔ قسمت‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/removeat/) بخش را در یک ایندکس مشخص از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection/clear/) تمام بخش‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک قسمت XML سفارشی سطح ارائه را بر اساس ارجاع حذف می‌کند:

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

اگر قبلاً یک `ICustomXmlPart` داشته باشید و بخواهید آن قسمت را مستقیم از ارائه حذف کنید، نه از یک مجموعهٔ خاص، متد `customXmlPart.Remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را بر اساس ایندکس حذف کنید:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **پاک‌سازی تمام قسمت‌های XML سفارشی از یک مجموعه**

از `Clear` زمانی استفاده کنید که تمام قسمت‌های XML سفارشی مرتبط با یک شیء ارائه خاص باید حذف شوند.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` فقط روی مجموعهٔ منتخب تأثیر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر قسمت XML سفارشی در ارائه، می‌توانید از `AllCustomXmlParts` عبور کنید و هر بخش را حذف نمایید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **مدیریت قسمت‌های XML سفارشی مرتبط یا مشترک**

در یک ارائه Office Open XML، یک قسمت XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان قسمت XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به‌عنوان یک شیء داده با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی `XmlAsString`، `XmlData` یا `ItemId` بخش XML زیرین را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن بخش ارجاع داده شود، اعمال می‌شود.
- `ItemId` می‌تواند برای شناسایی همان قسمت XML سفارشی هنگام بازرسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `CustomXmlParts` خاص، فقط آن بخش را از آن مجموعه حذف می‌کند. وقتی هدف حذف کل بخش از ارائه است، از `ICustomXmlPart.Remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع می‌دهند یا نه.

بارگذاری‌های `Add` یک قسمت XML سفارشی جدید از محتویات XML می‌سازند؛ آنها امکان پذیرش یک `ICustomXmlPart` موجود را ندارند. بنابراین، روابط مشترک بیشتر هنگام بارگذاری ارائه‌هایی که از پیش شامل این روابط هستند، مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بازرسی کرده و بخش‌هایی را گزارش می‌کند که از بیش از یک مکان ارجاع داده شده‌اند:

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

این نوع بازرسی پیش از تغییر یا حذف داده XML سفارشی در ارائه‌هایی که توسط سیستم‌های خارجی ایجاد شده‌اند، مفید است، زیرا همان بخش فراداده ممکن است در بیش از یک رابطه مشارکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل خاصیت `IDocumentProperties.Keywords` است. این نمونه کد نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای .NET برای [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) دریافت کنیم:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک خصوصیت سفارشی، برای مثال `MyTag`؛
- مقدار آن خصوصیت، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قانون یا خصوصیت خاص دارید، می‌توانید برای آن هدف برچسب اضافه کنید. برای مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به‌عنوان مقدار آن تنظیم کنید.

این نمونه کد نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) اضافه شود با استفاده از Aspose.Slides برای .NET:

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

برچسب‌های اضافه شده از طریق مجموعه `CustomData.Tags` فقط در فایل PowerPoint ذخیره می‌شوند. آنها **به** ساختار برچسب PDF منتقل نمی‌شوند زمانی که ارائه به PDF صادر می‌شود. در نتیجه، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده نمی‌تواند از PDF برچسب‌دار استخراج شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن Alt** شیء ذخیره کنید (برای مثال، `shape.AlternativeText = "MyId"`). پس از صادر کردن به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توان تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کرد؟**

بله. [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) از عمل [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که همهٔ جفت‌های کلید‑مقدار را یک‌باره حذف می‌کند.

**چگونه می‌توان یک برچسب واحد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کرد؟**

از [Remove(name)](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/remove/) روی [TagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلیدش حذف کنید.

**چگونه می‌توان فهرست کاملی از نام‌های برچسب‌ها را برای تحلیل یا فیلترینگ بدست آورد؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/getnamesoftags/) روی [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه همهٔ قسمت‌های XML سفارشی را بدون توجه به محل ذخیره‌شان پیدا کنم؟**

از [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/allcustomxmlparts/) برای بازیابی تمام قسمت‌های XML سفارشی در ارائه استفاده کنید.

**کدامیک را باید برای به‌روزرسانی یک قسمت XML سفارشی استفاده کنم: `XmlAsString` یا `XmlData`؟**

از `XmlAsString` زمانی استفاده کنید که برنامه با متن XML UTF‑8 کار می‌کند. از `XmlData` زمانی استفاده کنید که XML از پیش به‌صورت آرایه بایت موجود است یا پردازش باینری برای شما راحت‌تر است. هر دو خاصیت محتویات XML همان قسمت XML سفارشی را نشان می‌دهند.