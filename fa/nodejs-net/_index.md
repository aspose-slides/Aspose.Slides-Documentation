---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /fa/nodejs-net/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- پاورپوینت
- OpenDocument
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides for Node.js via .NET را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای کارهای رایج، مجوزدهی، مرجع API و پشتیبانی را پیدا کنید."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET یک کتابخانه برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Node.js است، بدون نیاز به Microsoft PowerPoint یا Office Automation. این کتابخانه Aspose.Slides for .NET را از طریق پلِ edge‑js اجرا می‌کند، بنابراین API جاوااسکریپت آن دقیقاً مشابه API .NET است و از نام‌های عضو camelCase استفاده می‌کند.

این کتابخانه می‌تواند پرونده‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، شامل انواع ماکرو فعال و قالبی، و می‌تواند به PDF، XPS، HTML، TIFF، Markdown و تصاویر خروجی دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/nodejs-net/installation/">نصب</a></li>
<li><a href="/slides/fa/nodejs-net/create-presentation/">ایجاد اولین ارائهٔ خود</a></li>
<li><a href="/slides/fa/nodejs-net/developer-guide/">راهنمای توسعه‌دهنده</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/nodejs-net/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/nodejs-net/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای رایج</p>
<ul>
<li><a href="/slides/fa/nodejs-net/open-presentation/">باز کردن و ذخیرهٔ یک ارائه</a></li>
<li><a href="/slides/fa/nodejs-net/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/nodejs-net/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/nodejs-net/manage-text/">ویرایش متن</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/net/">مستندات API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/fa/nodejs-net/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="https://releases.aspose.com/slides/fa/nodejs-net/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائهٔ شما**

شما به Node.js نسخهٔ 22 یا 24 و .NET SDK نسخهٔ 8 یا بالاتر نیاز دارید؛ در لینوکس همچنین باید چند بستهٔ سیستمی نصب شوند. صفحهٔ [نصب](/slides/fa/nodejs-net/installation/) این موارد و سکوهایی که تست شده‌اند را فهرست می‌کند. یک پروژه ایجاد کنید، یک override اضافه کنید که به npm بگوید کدام نسخهٔ edge‑js نصب شود، و بسته را نصب کنید:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

یک بار برای هر ماشین، بسته‌های .NET که کتابخانه به آن‌ها وابسته است را بازیابی کنید. فایل `deps.csproj` را از بخش [Restore the .NET Dependencies](/slides/fa/nodejs-net/installation/#restore-the-net-dependencies) در پوشه‌ای به نام `deps` داخل پوشهٔ پروژه ذخیره کنید، سپس اجرا کنید:

```sh
dotnet restore deps/deps.csproj
```

این کد را به نام *hello.js* در پوشهٔ پروژه ذخیره کنید:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// یک ارائهٔ جدید شامل یک اسلاید خالی است.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // موقعیت و اندازه بر حسب نقاط (۱/۷۲ اینچ) هستند: x، y، عرض، ارتفاع.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // آبجکت .NET که پشتیبان ارائه است را آزاد کنید.
    presentation.dispose();
}
```

از پوشهٔ پروژه اجرا کنید:

```sh
node hello.js
```

اسکریپت `Saved hello.pptx` را چاپ می‌کند و *hello.pptx* را با یک اسلاید که شامل یک مستطیل با متن است ذخیره می‌سازد. بدون داشتن مجوز، فایل ذخیره‌شده یک واترمارک ارزیابی دارد — برای جزئیات به صفحهٔ [مجوزدهی](/slides/fa/nodejs-net/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به صفحهٔ [ایجاد یک ارائه](/slides/fa/nodejs-net/create-presentation/) نگاه کنید.