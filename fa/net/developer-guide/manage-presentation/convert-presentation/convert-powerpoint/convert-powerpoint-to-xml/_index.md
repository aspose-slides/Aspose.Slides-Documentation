---
title: تبدیل ارائه‌های PowerPoint به XML در .NET
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/net/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه PowerPoint XML
- SaveFormat.Xml
- ذخیره ارائه به صورت XML
- صادرات ارائه به XML
- جریان XML
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در C# با Aspose.Slides برای .NET."
---
## **بررسی کلی**

Aspose.Slides for .NET می‌تواند ارائه‌های PowerPoint را به قالب PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمای متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار یا ادغام با جریان کاری که به جای بسته ارائه از XML استفاده می‌کند، نیاز داشته باشید.

از متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) با مقدار `Xml` از enum [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً در یک فایل یا یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این روش بخش‌های منفرد Office Open XML که داخل یک بسته PPTX ذخیره شده‌اند را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مثل `ppt/presentation.xml` یا فایل‌های XML اسلایدهای منفرد نیاز دارید، بسته PPTX را مستقیماً بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat.Xml` را به متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) پاس بدهید. منبع می‌تواند هر قالب ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائه PPTX را به فایل XML تبدیل می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **نوشتن خروجی XML به یک جریان**

از overload جریان متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) استفاده کنید وقتی که XML باید در حافظه بماند یا به مؤلفه‌ای دیگر مانند سرویس وب، ارائه‌دهندهٔ ذخیره‌سازی یا زنجیرهٔ پردازش XML پاس داده شود. مثال زیر نتیجه را به یک [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) می‌نویسد و برای خواندن بعدی موقعیت‌اش را باز می‌گرداند:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream را به مؤلفهٔ بعدی در جریان کاری پاس دهید.
```

## **مقایسه XML با قالب‌های ارائه و خروجی**

فرمت خروجی را بر حسب نحوهٔ استفادهٔ نهایی انتخاب کنید:

| قالب | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسهٔ خروجی تولید شده و ادغام مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائهٔ باینری قدیمی | سازگاری با جریان‌های کاری قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بستهٔ Office Open XML شامل چندین بخش | ویرایش معمولی PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با طرح ثابت یا تصویر چندصفحه‌ای | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمایش رندر شدهٔ یک اسلاید تک | تصاویر کوچک، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائهٔ مبتنی بر وب | مشاهده در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و جریان‌های کاری داده‑محور هدف‌گذاری شده است. بر خلاف PDF، TIFF، HTML و قالب‌های تصویر اسلاید، این خروجی دادهٔ ارائه را نشان می‌دهد نه رندر اسلایدها به عنوان صفحات یا دارایی‌های تصویری. جدول [قالب‌های فایل پشتیبانی‌شده](/slides/fa/net/supported-file-formats/) نشان می‌دهد که PowerPoint XML Presentation فقط به عنوان قالب ذخیره‌سازی وجود دارد، بنابراین هنگامیکه یک جریان کاری باید فایل صادرشده را دوباره در Aspose.Slides بارگذاری کند برای ویرایش ادامه یافته از آن استفاده نکنید.

## **پرسش‌های متداول**

**آیا `SaveFormat.Xml` همانند ذخیرهٔ یک فایل PPTX است؟**

خیر. PPTX یک بستهٔ شامل چندین بخش Office Open XML است، در حالی که `SaveFormat.Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کنم؟**

بله. یک جریان قابل نوشتن را به متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) پاس دهید. برای مثال، می‌توانید از یک [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادرشده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره‌سازی پشتیبانی می‌شود و برای بارگذاری قابل استفاده نیست. برای ویرایش دورانی از PPTX یا قالب ارائهٔ دیگری که پشتیبانی می‌شود استفاده کنید.

**آیا تبدیل XML هر اسلاید را به یک صفحه یا تصویر تبدیل می‌کند؟**

خیر. تبدیل XML داده‌های ساختاریافتهٔ ارائه را می‌نویسد. برای خروجی صفحه‑محور از PDF یا TIFF و برای تصویر اسلایدهای منفرد از PNG، JPEG و SVG استفاده کنید.