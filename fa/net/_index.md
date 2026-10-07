---
title: "Aspose.Slides برای .NET"
second_title: "Aspose.Slides برای .NET"
type: docs
weight: 10
url: /fa/net/
keywords:
- "مستندات"
- "پردازش ارائه"
- "تبدیل ارائه"
- "PowerPoint"
- "OpenDocument"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "از اینجا شروع کنید: نصب Aspose.Slides برای .NET، ایجاد اولین ارائه، و یافتن راهنمایی‌ها برای وظایف عمومی، استقرار و مستندات API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET یک کتابخانهٔ کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های .NET است، بدون نیاز به Microsoft PowerPoint یا Office Automation.

این کتابخانه فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره می‌کند، از جمله نسخه‌های دارای ماکرو و قالب، و به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر صادر می‌سازد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/net/installation/">نصب</a></li>
<li><a href="/slides/fa/net/create-presentation/">ایجاد اولین ارائه خود</a></li>
<li><a href="/slides/fa/net/system-requirements/">نیازمندی‌های سیستم</a></li>
<li><a href="/slides/fa/net/getting-started/">راهنمای شروع</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/net/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/net/features-overview/">نمای کلی امکانات</a></li>
<li><a href="/slides/fa/net/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/net/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>وظایف عمومی</p>
<ul>
<li><a href="/slides/fa/net/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/net/save-presentation/">ذخیرهٔ یک ارائه</a></li>
<li><a href="/slides/fa/net/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/net/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/net/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان کار Slides</p>
<ul>
<li><a href="/slides/fa/net/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/net/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/net/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/net/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/net/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>نمونه‌ها</p>
<ul>
<li><a href="/slides/fa/net/examples/">نمونه‌ها بر حسب عنصر اسلاید</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">نمونه‌ها در GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>استقرار و پشتیبانی</b></p>
<hr>
<p>استقرار</p>
<ul>
<li><a href="/slides/fa/net/net6/">چند‌پلتفرمی (.NET 6+)</a></li>
<li><a href="/slides/fa/net/how-to-run-aspose-slides-in-docker/">اجرا در Docker</a></li>
<li><a href="/slides/fa/net/deploy-fonts/">فونت‌ها</a></li>
<li><a href="/slides/fa/net/security/">امنیت</a></li>
</ul>
<p>مراجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">مستندات API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/net/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="/slides/fa/net/api-limitations/">محدودیت‌های متادیتای خروجی</a></li>
<li><a href="https://products.aspose.com/slides/net/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/net/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پرداختی</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **اولین ارائهٔ شما**

یک برنامهٔ کنسولی با .NET SDK 6 یا بالاتر ایجاد کنید:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

سپس یک بسته برای پلتفرم خود اضافه کنید:

- در ویندوز: `dotnet add package Aspose.Slides.NET`
- در لینوکس و macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — برای پیش‌نیازهای لینوکس و سیستم‌هایی که به جای آن به Aspose.Slides.NET نیاز دارند، بخش [نصب](/slides/fa/net/installation/) را ببینید.

محتویات *Program.cs* را با این کد جایگزین کنید و `dotnet run` را اجرا کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

برنامه *hello.pptx* را با یک اسلاید حاوی یک کادر متن ذخیره می‌کند. بدون داشتن لایسنس، فایل ذخیره‌شده یک واترمارک ارزیابی دارد — برای جزئیات به [مجوزدهی](/slides/fa/net/licensing/) مراجعه کنید. برای روش‌های بیشتر ایجاد و پر کردن ارائه، به [ایجاد ارائه‌ها](/slides/fa/net/create-presentation/) نگاه کنید.