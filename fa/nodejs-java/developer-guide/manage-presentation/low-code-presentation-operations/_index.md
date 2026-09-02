---
title: عملیات ارائه با کد کم در جاوااسکریپت
linktitle: API کد کم
type: docs
weight: 50
url: /fa/nodejs-java/low-code-presentation-operations/
keywords:
- API ارائه با کد کم
- تبدیل ارائه
- ادغام ارائه‌ها
- مرور اسلایدها
- مرور شکل‌ها
- مرور متن
- جمع‌آوری شکل‌ها
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر استفاده‌نشده
- حذف اسلایدهای لایه استفاده‌نشده
- فشرده‌سازی فونت‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "از API کد کم Aspose.Slides در جاوااسکریپت برای تبدیل و ادغام ارائه‌ها، مرور محتوا، جمع‌آوری شکل‌ها و کاهش حجم ارائه استفاده کنید."
---
## **مروری**

فضای‌نام `aspose.slides` کلاس‌های کمکی ایستاتیک برای عملیات رایج ارائه‌ها را فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدل‑شیء پرکاربرد را در متدهای متمرکز می‌پیچند، به طوری که می‌توانید فایل‌ها را تبدیل یا ادغام کنید، عناصر ارائه را پردازش کنید، شکل‌ها را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمک‌کننده‌های کم‌کد زمانی مفیدترین هستند که عملیات بر روی یک فایل یا ارائه کامل اعمال می‌شود و جریان کاری پیش‌فرض با نیازهای شما مطابقت دارد. هنگام نیاز به کنترل دقیق بر اسلایدها، مسترها، لایه‌ها، شکل‌ها، تنظیمات صادرات یا رابطه بین عناصر ارائه، از **[مدل شیء Aspose.Slides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/)** کامل استفاده کنید.

جدول زیر خلاصه‌ای از کمک‌کننده‌های موجود را ارائه می‌دهد:

| کمک‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/) | ترکیب کامل فایل‌های ارائه‌ای با همان قالب. |
| [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) | اجرای عملی برای هر اسلاید، شکل، پاراگراف یا قسمت متن. |
| [Collect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/) | به‌دست آوردن شکل‌ها از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) | حذف مسترها و لایه‌های استفاده‌نشده و کاهش داده‌های فونت‌های توکار. |

## **تبدیل یک ارائه**

از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/#autoByExtension) زمانی استفاده کنید که پسوند فایل خروجی به تنهایی برای انتخاب فرمت صادرات کافی باشد. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌نماید و نتیجه را می‌نویسد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF را فراهم می‌کند. هنگامی که نیاز به بازرسی یا تغییر ارائه قبل از صادرات یا تنظیم گزینه‌ای دارید که توسط کمک‌کننده در دسترس نیست، از مدل شیء کامل استفاده کنید. برای گردش‌کارها و گزینه‌های خاص هر فرمت، به **[تبدیل ارائه](/slides/fa/nodejs-java/convert-presentation/)** مراجعه کنید.

## **ادغام ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/#process) برای ترکیب کامل فایل‌های ارائه‌ای با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

این کمک‌کننده زمانی مناسب است که تمام اسلایدها باید بدون انتخاب یا بازنگری جداگانه به یک نتیجه اضافه شوند. هنگامی که نیاز به ادغام اسلایدهای انتخابی، اعمال مستر یا لایه مقصد، حفظ بخش‌ها به‌صورت صریح یا تطبیق اندازه‌های مختلف اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به **[ادغام ارائه‌ها](/slides/fa/nodejs-java/merge-presentation/)** نگاه کنید.

## **تکرار بر روی عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) برای هر نوع عنصر درخواست‌شدهٔ ارائه یک کال‌بک فراخوانی می‌کند. این کار حلقه‌های تو در توی جمع‌آوری را حذف می‌کند و برای بازرسی یا تغییرات سراسری مفید است. در Node.js، پیاده‌سازی‌های این کال‌بک‌ها را می‌توانید با `java.newProxy` ایجاد کنید.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#slide)، [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#paragraph) و [ForEach.portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#portion) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌صورت پیش‌فرض، عبور سراسری بر شکل‌ها و متن شامل اسلایدهای عادی، مستر و لایه می‌شود. بارگذاری‌های دیگری با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب عبور، خروج زودهنگام، فیلترینگ قبل از فراخوانی کال‌بک یا کنترل والد‑فرزندی دقیق مهم باشد، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری شکل‌ها**

از [Collect.shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/#shapes) زمانی استفاده کنید که به یک مجموعهٔ تمام شکل‌های یک ارائه نیاز دارید نه یک کال‌بک برای هر شکل. این روش زمانی مفید است که همان مجموعه به‌صورت مکرر فیلتر، شمارش یا پردازش شود.

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

در صورتی که هر شکل می‌تواند بلافاصله پردازش شود و نیازی به نگه‌داری نتیجه جمع‌آوری‌شده ندارید، به جای آن از [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کرده و داده‌های فونت‌های توکار را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) لایه‌هایی را که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد، حذف می‌کند.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) مسترهایی را که دیگر استفاده نمی‌شوند، حذف می‌کند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) کاراکترهای استفاده‌نشدۀ فونت‌های توکار را حذف می‌کند.

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

ابتدا لایه‌های استفاده‌نشده را حذف کنید، سپس مسترهای استفاده‌نشده؛ به این ترتیب مستری که پس از پاک‌سازی لایه‌ها دیگر ارجاع ندارد، نیز حذف می‌شود. برای حفظ مسترها، لایه‌ها یا داده‌های کامل فونت‌های توکار، ارائه بهینه‌شده را در فایلی جدید ذخیره کنید. برای جزئیات بیشتر، به **[مستری اسلاید](/slides/fa/nodejs-java/slide-master/)** و **[فونت توکار](/slides/fa/nodejs-java/embedded-font/)** مراجعه کنید.

## **پرسش‌های متداول**

**چه موقع باید از API کم‌کد به‌جای مدل شیء کامل استفاده کنم؟**  
وقتی یک عملیات استاندارد بر روی یک فایل یا ارائهٔ کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد نیست، از کمک‌کننده‌های کم‌کد استفاده کنید. برای انتخاب اسلایدهای خاص، کنترل روابط مستر و لایه، بازرسی وضعیت میانی یا تنظیم رفتاری که توسط کمک‌کننده ارائه نمی‌شود، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**  
خیر. متد [Merger.process](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/merger/#process) نیاز دارد که همهٔ ارائه‌های ورودی یک قالب داشته باشند. ابتدا فایل‌های ورودی را با نمونه‌ای مانند [Convert.autoByExtension](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/convert/#autoByExtension) به قالب مشترک تبدیل کنید، سپس آن‌ها را ادغام کنید.

**آیا ForEach مستر، لایه و اسلایدهای یادداشت را پردازش می‌کند؟**  
متد [ForEach.slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#slide) فقط اسلایدهای عادی ارائه را مرور می‌کند. عملیات سراسری [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#paragraph) و [ForEach.portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#portion) به‌صورت پیش‌فرض شامل اسلایدهای عادی، مستر و لایه هستند. برای شامل کردن اسلایدهای یادداشت، از بارگذاری‌هایی که پارامتر `includeNotes` را به `true` تنظیم می‌کنند، استفاده کنید.

**فرق بین ForEach.shape و Collect.shapes چیست؟**  
اگر می‌خواهید هر شکل را بلافاصله با کال‌بک پردازش کنید، از [ForEach.shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/#shape) استفاده کنید. اگر به یک نتیجهٔ قابل تکرار (قابل نگهداری، فیلتر یا شمارش) نیاز دارید، از [Collect.shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/collect/#shapes) استفاده کنید.

**آیا Compress همیشه اندازهٔ فایل ارائه را کاهش می‌دهد؟**  
لزومی نیست. نتیجه بستگی به این دارد که آیا ارائه شامل لایه‌ها یا مسترهای استفاده‌نشده یا فونت‌های توکار با کاراکترهای غیرمصرف است یا نه. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات مربوط به [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) ممکن است اندازهٔ فایل را کاهش ندهد.

**آیا تغییرات اعمال‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**  
خیر. این کمک‌کننده‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از تغییر عناصر در کال‌بک [ForEach](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/)، برای نوشتن نتیجه باید متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) را فراخوانی کنید.

## **مقالات مرتبط**

- [تبدیل ارائه](/slides/fa/nodejs-java/convert-presentation/)
- [ادغام ارائه‌ها](/slides/fa/nodejs-java/merge-presentation/)
- [مستری اسلاید](/slides/fa/nodejs-java/slide-master/)
- [مدیریت جعبهٔ متن](/slides/fa/nodejs-java/manage-textbox/)
- [فونت توکار](/slides/fa/nodejs-java/embedded-font/)