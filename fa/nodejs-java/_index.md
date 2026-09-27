---
title: Aspose.Slides برای Node.js از طریق Java
second_title: Aspose.Slides برای Node.js
type: docs
weight: 47
url: /fa/nodejs-java/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides برای Node.js از طریق Java نصب کنید، اولین ارائه را ایجاد کنید و راهنماهای کارهای رایج، مرجع API و پشتیبانی را پیدا کنید."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides برای Node.js از طریق Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java کتابخانه‌ای برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Node.js است، بدون نیاز به Microsoft PowerPoint.

این کتابخانه قادر به بارگذاری و ذخیرهٔ فرمت‌های PPT، PPTX، PPS، POT و ODP، به‌همراه نسخه‌های ماکروپذیر و الگو، و همچنین خروجی به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر است.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کار</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/nodejs-java/installation/">نصب</a></li>
<li><a href="/slides/fa/nodejs-java/create-presentation/">ایجاد اولین ارائهٔ خود</a></li>
<li><a href="/slides/fa/nodejs-java/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/nodejs-java/supported-file-formats/">قالب‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/nodejs-java/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/nodejs-java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای رایج</p>
<ul>
<li><a href="/slides/fa/nodejs-java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/nodejs-java/save-presentation/">ذخیرهٔ یک ارائه</a></li>
<li><a href="/slides/fa/nodejs-java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/nodejs-java/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/nodejs-java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>فرآیندهای Slides</p>
<ul>
<li><a href="/slides/fa/nodejs-java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/nodejs-java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/nodejs-java/manage-media-files/">صدا و ویدئو</a></li>
<li><a href="/slides/fa/nodejs-java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/nodejs-java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/nodejs-java/examples/">مثال‌ها بر حسب عنصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/nodejs-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/nodejs-java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/nodejs-java/known-issues/">مسائل شناخته‌شده</a></li>
<li><a href="https://releases.aspose.com/slides/fa/nodejs-java/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">میز پشتیبانی تجاری</a></li>
</ul>
</div>
</div>

------

## **اولین ارائهٔ شما**

به‌جز Node.js 20 یا بالاتر، بسته به Java Development Kit (JDK)، Python و یک زنجیره‌ابزار ساخت C++ نیز نیاز دارد، چون npm در هنگام نصب پل `java` را کامپایل می‌کند. برای مراحل هر سیستم‌عامل به [نصب](/slides/fa/nodejs-java/installation/) مراجعه کنید. سپس یک پروژه ایجاد کرده و بسته را از npm نصب کنید:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

این کد را به‌عنوان *hello.js* در پوشهٔ پروژه ذخیره کنید:

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

// Aspose.Slides در یک ماشین مجازی جاوا اجرا می‌شود که Node.js را فعال نگه می‌دارد، بنابراین فرآیند را به‌طور صریح پایان دهید.
process.exit(0);
```

با `node hello.js` آن را اجرا کنید. اسکریپت *hello.pptx* را با یک اسلاید حاوی یک جعبهٔ متن ذخیره می‌کند. بدون داشتن لایسنس، فایل ذخیره‌شده حاوی واترمارک ارزیابی است — برای جزئیات به [مجوزدهی](/slides/fa/nodejs-java/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/nodejs-java/create-presentation/) نگاه کنید.