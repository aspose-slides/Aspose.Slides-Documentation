---
title: عملیات‌های ارائه کم‌کد در جاوااسکریپت
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/nodejs-java/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ترکیب ارائه‌ها
- پیمایش اسلایدها
- پیمایش اشکال
- پیمایش متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر استفاده نشده
- حذف اسلایدهای طرح‌بندی استفاده نشده
- فشرده‌سازی فونت‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در جاوااسکریپت برای تبدیل و ترکیب ارائه‌ها، پیمایش محتوا، جمع‌آوری اشکال و کاهش اندازه ارائه استفاده کنید."
---
## **بررسی کلی**

فضای‌نامی `aspose.slides` کلاس‌های استاتیک کمکی برای عملیات رایج ارائه را فراهم می‌کند. این کمکی‌ها جریان‌کاری‌های پرکاربرد مدل‌شیء را در روش‌های متمرکز می‌پیچند، به‌طوری که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده نشده را با کد کمتر حذف کنید.

کمک‌های Low-code زمانی مفیدترین هستند که عملیات بر روی یک فایل یا ارائه کامل اعمال می‌شود و گردش‌کار پیش‌فرض با نیازهای شما مطابقت دارد. زمانی که به کنترل دقیق بر اسلایدهای تک‌تک، مسترها، طرح‌بندی‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه نیاز دارید، از مدل شیء کامل [Aspose.Slides object model](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/) استفاده کنید.

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل به فایل. |
| [Merger](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/) | ترکیب فایل‌های ارائه کامل با قالب یکسان. |
| [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/) | دریافت اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) | حذف مسترها و طرح‌بندی‌های استفاده نشده و کاهش داده‌های فونت‌های جاسازی‌شده. |

## **تبدیل یک ارائه**

از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/#autoByExtension) زمانی استفاده کنید که پسوند فایل خروجی برای انتخاب فرمت خروجی کافی باشد. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF ارائه می‌دهد. زمانی که نیاز به بازرسی یا تغییر ارائه پیش از خروجی یا پیکربندی گزینه خروجی‌ای دارید که توسط کمکی انتخاب‌شده در دسترس نیست، از مدل شیء کامل استفاده کنید. برای گردش‌کارها و گزینه‌های مخصوص به هر فرمت، به [Convert Presentation](/nodejs-java/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/#process) برای ترکیب کامل فایل‌های ارائه با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید دارای همان قالب فایل باشند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که همه اسلایدها باید بدون انتخاب یا بازنگری فردی به یک نتیجه اضافه شوند. زمانی که نیاز به ترکیب اسلایدهای انتخابی، اعمال مستر یا طرح‌بندی مقصد، حفظ بخش‌ها به‌صورت صریح یا تطبیق اندازه‌های اسلاید متفاوت دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به [Merge Presentations](/nodejs-java/merge-presentation/) مراجعه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) برای هر نوع عنصر درخواست‌شده از ارائه یک فراخوانی (callback) را فراخوانی می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییر فرمت سراسری ارائه مناسب است. در Node.js، پیاده‌سازی‌های رابط‌های callback را با `java.newProxy` ایجاد کنید.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

به‌صورت پیش‌فرض، پیمایش اشکال و متن سراسری ارائه شامل اسلایدهای عادی، مستر و طرح‌بندی می‌شود. نسخه‌های با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. هنگامی که ترتیب پیمایش، خروج زودهنگام، فیلتر پیش از فراخوانی callback یا کنترل دقیق والد‑فرزندی مهم است، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/#shapes) زمانی استفاده کنید که به یک مجموعه از تمام اشکال در یک ارائه نیاز دارید نه یک فراخوانی برای هر شکل. این مورد زمانی مفید است که همان مجموعه چندبار فیلتر، شمارش یا پردازش شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

در صورتی که هر شکل می‌تواند بلافاصله پردازش شود و نیازی به نگهداری نتیجه جمع‌آوری‌شده ندارید، به جای آن از [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف و داده‌های فونت‌های جاسازی‌شده را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) اسلایدهای طرح‌بندی را که هیچ اسلاید عادی به آن ارجاع نمی‌دهد، حذف می‌کند.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) اسلایدهای مستر که دیگر استفاده نمی‌شوند را حذف می‌کند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) کاراکترهای استفاده‌نشده را از فونت‌های جاسازی‌شده حذف می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طرح‌بندی‌های استفاده‌نشده را قبل از مسترهای استفاده‌نشده حذف کنید تا مستری که پس از پاک‌سازی طرح‌بندی غیرقابل ارجاع می‌شود نیز حذف شود. اگر ممکن است به مسترها، طرح‌بندی‌ها یا داده‌های کامل فونت‌های جاسازی‌شده اصلی بعداً نیاز داشته باشید، ارائه بهینه‌شده را در فایل جدید ذخیره کنید. برای جزئیات بیشتر، به [Slide Master](/nodejs-java/slide-master/) و [Embedded Font](/nodejs-java/embedded-font/) مراجعه کنید.

## **پرسش‌های متداول**

**چه موقع باید از API کم‌کد به جای مدل شیء کامل استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و کنترل دقیق بر عناصر تک‌تک لازم نیست، از کمک‌های کم‌کد استفاده کنید. هنگامی که نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و طرح‌بندی، بازرسی وضعیت میانی یا پیکربندی رفتاری دارید که کمکی آن را افشا نمی‌کند، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را با فرمت‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger.process](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/#process) نیاز دارد که ارائه‌های ورودی در یک فرمت باشند. ابتدا فایل‌های ورودی را به یک فرمت مشترک تبدیل کنید، برای مثال با [Convert.autoByExtension](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/#autoByExtension)، سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach مسترها، طرح‌بندی‌ها و اسلایدهای یادداشت‌ها را پردازش می‌کند؟**

[ForEach.slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#slide) اسلایدهای عادی ارائه را پیمایش می‌کند. عملیات سراسری [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#paragraph) و [ForEach.portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#portion) به‌طور پیش‌فرض شامل اسلایدهای عادی، مستر و طرح‌بندی می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، از نسخه‌های آنها با پارامتر `includeNotes` برابر `true` استفاده کنید.

**تفاوت بین ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape) برای پردازش هر شکل بلافاصله در یک callback استفاده کنید. از [Collect.shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/#shapes) زمانی که به یک نتیجه قابل تکرار نیاز دارید که می‌توانید آن را نگه دارید، فیلتر کنید، شمارش کنید یا چندبار عبور کنید، استفاده کنید.

**آیا Compress همیشه اندازه فایل ارائه را کوچکتر می‌کند؟**

لزماً نیست. نتیجه بستگی دارد به اینکه آیا ارائه شامل طرح‌بندی‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های جاسازی‌شده با کاراکترهای استفاده‌نشده باشد یا خیر. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات مربوط به [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهد.

**آیا تغییرات انجام‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در یک callback از [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/)، برای نوشتن نتیجه باید [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) را صدا بزنید.

## **مقالات مرتبط**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)