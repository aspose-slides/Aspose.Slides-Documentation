---
title: Aspose.Slides برای Node.js از طریق Java
second_title: Aspose.Slides برای Node.js
type: docs
weight: 47
url: /fa/nodejs-java/
keywords:
- مستندسازی
- پردازش ارائه
- تبدیل ارائه
- پاورپوینت
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "از اینجا شروع کنید: نصب Aspose.Slides برای Node.js از طریق Java، ایجاد اولین ارائه، و یافتن راهنماها برای وظایف رایج، مرجع API و پشتیبانی."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides برای Node.js از طریق Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides برای Node.js از طریق Java یک کتابخانه برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Node.js است، بدون Microsoft PowerPoint.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، شامل نسخه‌های دارای ماکرو و قالب، و می‌تواند به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر صادر شود.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع</p>
<ul>
<li><a href="/slides/fa/nodejs-java/installation/">نصب</a></li>
<li><a href="/slides/fa/nodejs-java/create-presentation/">ایجاد اولین ارائه</a></li>
<li><a href="/slides/fa/nodejs-java/getting-started/">راهنمای شروع</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/nodejs-java/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/nodejs-java/evaluate-aspose-slides/">محدودیت‌های آزمایشی</a></li>
<li><a href="/slides/fa/nodejs-java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>وظایف رایج</p>
<ul>
<li><a href="/slides/fa/nodejs-java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/nodejs-java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/nodejs-java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/nodejs-java/convert-slide/">رندری اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/nodejs-java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان کارهای Slides</p>
<ul>
<li><a href="/slides/fa/nodejs-java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/nodejs-java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/nodejs-java/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/nodejs-java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/nodejs-java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>نمونه‌ها</p>
<ul>
<li><a href="/slides/fa/nodejs-java/examples/">نمونه‌ها بر اساس عناصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/nodejs-java/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

علاوه بر Node.js 20 یا بالاتر، این بسته به یک Java Development Kit (JDK)، Python و یک ابزار ساخت C++ نیاز دارد، زیرا npm در طول نصب پل `java` خود را کامپایل می‌کند. برای مراحل در هر سیستم‌عامل، به [Installation](/slides/fa/nodejs-java/installation/) مراجعه کنید. سپس یک پروژه ایجاد کنید و بسته را از npm نصب کنید:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

این کد را به‌ عنوان *hello.js* در پوشهٔ پروژه ذخیره کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides در یک ماشین مجازی Java اجرا می‌شود که Node.js را فعال نگه می‌دارد، بنابراین فرآیند را به صورت صریح پایان دهید.
process.exit(0);
```

آن را با `node hello.js` اجرا کنید. این اسکریپت *hello.pptx* را با یک اسلاید حاوی یک جعبه متن ذخیره می‌کند. بدون لایسنس، فایل ذخیره‌شده یک واترمارک ارزیابی دارد — برای جزئیات به [مجوزدهی](/slides/fa/nodejs-java/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/nodejs-java/create-presentation/) مراجعه کنید.