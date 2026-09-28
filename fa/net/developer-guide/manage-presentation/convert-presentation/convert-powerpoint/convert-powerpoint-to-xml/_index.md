---
title: "تبدیل ارائه‌های PowerPoint به XML در .NET"
linktitle: "PowerPoint به XML"
type: docs
weight: 145
url: /fa/net/convert-powerpoint-to-xml/
keywords:
  - "تبدیل PowerPoint به XML"
  - "تبدیل ارائه به XML"
  - "PPT به XML"
  - "PPTX به XML"
  - "ODP به XML"
  - "ارائه XML PowerPoint"
  - SaveFormat.Xml
  - "ذخیره ارائه به صورت XML"
  - "صادر کردن ارائه به XML"
  - "جریان XML"
  - .NET
  - C#
  - Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های XML PowerPoint در C# با Aspose.Slides برای .NET."
---
## **بررسی کلی**

Aspose.Slides for .NET می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایشی مبتنی بر متن برای بررسی ساختار ارائه، عیب‌یابی مدارک تولید شده، مقایسه خروجی در تست‌های خودکار، یا ادغام با گردش کاری که به جای بسته ارائه، XML مصرف می‌کند، نیاز داشته باشید.

از متد [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) با مقدار `Xml` از enumeration [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً به یک فایل یا یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این کار بخش‌های جداگانه Office Open XML ذخیره شده در یک بسته PPTX را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مانند `ppt/presentation.xml` یا فایل‌های XML اسلاید جداگانه نیاز دارید، بسته PPTX را مستقیماً بررسی کنید.
{{% /alert %}}

## **تبدیل ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید، سپس مسیر خروجی و `SaveFormat.Xml` را به [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) پاس دهید. منبع می‌تواند هر قالب ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائه PPTX را به فایل XML تبدیل می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **نوشتن خروجی XML به یک جریان**

از overload جریان‌دار متد [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) استفاده کنید هنگامی که XML باید در حافظه بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهنده ذخیره‌سازی یا خط لوله پردازش XML پاس داده شود. مثال زیر نتیجه را به یک [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) می‌نویسد و برای خواندن بعدی به ابتدا باز می‌گرداند:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream را به مؤلفه بعدی در مسیر کار پاس دهید.
```

## **مقایسه XML با قالب‌های ارائه و صادرات**

فرمت خروجی را بر اساس نحوه استفاده از نتیجه انتخاب کنید:

| قالب | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده، و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با گردش‌کارهای قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML حاوی چندین بخش | ویرایش معمول PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با طرح ثابت یا تصاویر TIFF | مشاهده، چاپ و آرشیو |
| PNG، JPEG یا SVG | یک نمایش رندر شده از یک اسلاید منفرد | تصاویر بندانگشتی، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائه برای وب | نمایش در مرورگر و انتشار وب |

برخلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و گردش‌کارهای مبتنی بر داده در نظر گرفته شده است. برخلاف PDF، TIFF، HTML و قالب‌های تصویر اسلاید، این فرمت داده‌های ارائه را نمایش می‌دهد نه اینکه اسلایدها را به‌صورت صفحات یا دارایی‌های بصری رندر کند. جدول [قالب‌های فایل پشتیبانی‌شده](/slides/fa/net/supported-file-formats/) تمام فرمت‌هایی را فهرست می‌کند که Aspose.Slides می‌تواند بارگذاری، وارد، ذخیره یا رندر کند.

## **سوالات متداول**

**آیا `SaveFormat.Xml` همانند ذخیره یک فایل PPTX است؟**

خیر. PPTX یک بسته حاوی چندین بخش Office Open XML است، در حالی که `SaveFormat.Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کنم؟**

بله. یک جریان قابل نوشتن را به [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) پاس دهید. برای مثال، از یک [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادرشده را دوباره بارگذاری کند؟**

بله. فایل XML یا یک جریان را به سازنده [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) پاس دهید. [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) سپس `SourceFormat.Xml` را برمی‌گرداند. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) برای این فرمت `LoadFormat.Unknown` گزارش می‌کند، بنابراین برای تصمیم‌گیری درباره باز شدن فایل XML از آن استفاده نکنید.

**آیا تبدیل XML هر اسلاید را به صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل XML داده‌های ساختار یافتهٔ ارائه را می‌نویسد. برای خروجی صفحه‌محور از PDF یا TIFF استفاده کنید، یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG.