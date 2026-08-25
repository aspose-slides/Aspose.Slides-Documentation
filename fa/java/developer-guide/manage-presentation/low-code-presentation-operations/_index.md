---
title: عملیات ارائه با کد کم در جاوا
linktitle: API کد کم
type: docs
weight: 50
url: /fa/java/low-code-presentation-operations/
keywords:
- API ارائه کد کم
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار شکل‌ها
- تکرار متن
- جمع‌آوری شکل‌ها
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر غیرقابل استفاده
- حذف اسلایدهای طرح‌بندی غیرقابل استفاده
- فشرده‌سازی فونت‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در جاوا برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری شکل‌ها و کاهش اندازهٔ ارائه استفاده کنید."
---
## **بررسی‌کلی**

پکیج [com.aspose.slides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) کلاس‌های کمکی ایستاتیك برای عملیات رایج روی ارائه‌ها فراهم می‌كند. این کمك‌ها گردش‌کارهای مدل‌اشیاءی که به‌صورت مكرّر استفاده می‌شوند را در روش‌های متمركز می‌پیچند، به‌طوری‌كه بتوانید فایل‌ها را تبدیل یا ادغام کنید، عناصر ارائه را پردازش کنید، شکل‌ها را جمع‌آوری کنید و محتوای غيراستفاده را با كد كمتری حذف کنید.

كمك‌های «كد کم» زمانی بیش از حد مفید می‌شوند كه عملیات بر روی یک فایل یا ارائه‌ی كامل اعمال می‌شود و گردش‌کار پيش‌فرض با نیازهای شما مطابقت دارد. هنگام نیاز به کنترل جزئی بر اسلایدهای فردی، مسترها، طرح‌بندی‌ها، شكل‌ها، تنظیمات خروجی یا روابط بین عناصر ارائه، از مدل‌اشیاء كامل [Aspose.Slides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از كمك‌های موجود را ارائه می‌دهد:

| كمك | موارد استفاده |
| --- | --- |
| [تبدیل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/) | تبدیل یک ارائه به فرمت دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [ادغام](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/) | ترکیب فایل‌های ارائه كامل با فرمت یکسان. |
| [ForEach](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/) | انجام یک عمل برای هر اسلاید، شكل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/) | بازیابی شكل‌ها از تمام ارائه برای پردازش یا تحلیل مكرّر. |
| [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) | حذف مسترها و طرح‌بندی‌های غيراستفاده و کاهش داده‌های فونت جاسازی‌شده. |

## **تبدیل یک ارائه**

هنگامی كه پسوند فایل خروجی به تنهایی برای انتخاب فرمت خروجی کافی است، از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) استفاده کنید. این متد ارائه‌ی منبع را باز می‌كند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌كند و نتیجه را می‌نویسد.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌كند. هنگام نیاز به بررسی یا تغییر ارائه قبل از خروجی یا تنظیم گزینه‌ای که توسط كمك انتخابی در دسترس نیست، از مدل‌اشیاء كامل استفاده کنید. برای گردش‌کارها و گزینه‌های مخصوص فرمت به صفحهٔ [Convert Presentation](/slides/fa/java/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

برای ترکیب فایل‌های ارائه كامل با یک فراخوانی، از [Merger.process](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) استفاده کنید. ارائه‌های ورودی باید دارای همان فرمت فایل باشند.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

این کمك زمانی مناسب است كه تمام اسلایدها بدون انتخاب یا بازنگری فردی به یک نتیجه اضافه شوند. وقتی نیاز به ادغام اسلایدهای انتخابی، اعمال مستر یا طرح‌بندی مقصد، حفظ بخش‌ها به‌صورت صریح یا سازگاری اندازه‌های متفاوت اسلاید دارید، از مدل‌اشیاء كامل استفاده کنید. برای این سناریوها به صفحهٔ [Merge Presentations](/slides/fa/java/merge-presentation/) نگاه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/) برای هر نوع عنصر درخواست‌شده فراخوانی‌گری را اجرا می‌كند. این کار از حلقه‌های تودرتوی جمع‌آوری جلوگیری می‌كند و برای بررسی یا تغییر فرمت در سطح تمام ارائه مناسب است.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) برای بررسی عناصر مربوطه استفاده می‌كند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

به‌صورت پیش‌فرض، عبور از شكل‌ها و متن در سراسر ارائه شامل اسلایدهای عادی، مستر و طرح‌بندی می‌شود. بارگذاری‌های دارای پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش كند. هنگامی که ترتیب عبور، خروج زودهنگام، فیلتر قبل از فراخوانی یا کنترل دقیق والد‑فرزندی مهم است، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری شكل‌ها**

هنگامی كه به یک مجموعه از تمام شكل‌ها در یک ارائه نیاز دارید نه یک فراخوانی برای هر شكل، از [Collect.shapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) استفاده کنید. این روش زمانی مفید است كه مجموعهٔ یکسان نیاز به فیلتر، شمارش یا پردازش بیش از یک بار داشته باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

به جای آن می‌توانید از [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) استفاده کنید وقتی هر شكل می‌تواند بلافاصله پردازش شود و نیازی به نگهداری نتیجهٔ جمع‌آوری‌شده نیست.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) می‌تواند عناصر ساختاری غيراستفاده را حذف و داده‌های فونت جاسازی‌شده را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) اسلایدهای طرح‌بندی را حذف می‌كند که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) مسترهایی را حذف می‌كند که دیگر استفاده نمی‌شوند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) کاراکترهای غيراستفاده در فونت‌های جاسازی‌شده را حذف می‌كند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ابتدا طرح‌بندی‌های غيراستفاده را حذف کنید و سپس مسترهای غيراستفاده را؛ به این ترتیب مستری که پس از تمیزکردن طرح‌بندی‌ها دیگر ارجاع داده نمی‌شود، نیز حذف می‌شود. ارائه بهینه‌شده را در فایل جدیدی ذخیره کنید اگر ممکن است بعدها به مسترها، طرح‌بندی‌ها یا داده‌های كامل فونت جاسازی‌شده نیاز داشته باشید. برای جزئیات بیشتر به صفحات [Slide Master](/slides/fa/java/slide-master/) و [Embedded Font](/slides/fa/java/embedded-font/) مراجعه کنید.

## **پرسش‌های متداول**

**چه زمانی باید به‌جای مدل‌اشیاء كامل از API كد‑كم استفاده كنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق روی عناصر فردی نیست، از كمك‌های كد‑كم استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و طرح‌بندی، بررسی وضعیت میانی یا تنظیم رفتاری دارید که توسط كمك نمایان نیست، از مدل‌اشیاء كامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در فرمت‌های متفاوت ترکیب كند؟**

نه. متد [Merger.process](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) فقط ورودی‌های با فرمت یکسان را می‌پذیرد. ابتدا فایل‌های ورودی را به یک فرمت مشترک تبدیل کنید، برای مثال با استفاده از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)، سپس فایل‌های تبدیل‌شده را ادغام كنید.

**آیا ForEach مستر، طرح‌بندی و اسلایدهای یادداشت را پردازش می‑كند؟**

متد [ForEach.slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) فقط اسلایدهای عادی ارائه را پیمایش می‌كند. عملیات‌های سطح‑کلان [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) به‌صورت پیش‌فرض شامل اسلایدهای عادی، مستر و طرح‌بندی می‌شوند. برای شامل کردن اسلایدهای یادداشت، بارگذاری‌های آن‌ها را با `includeNotes` برابر `true` صدا بزنید.

**تفاوت بین ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) برای پردازش فوری هر شكل از طریق یک فراخوانی استفاده کنید. زمانی که به یک نتیجهٔ قابل تکرار نیاز دارید که بتوانید آن را نگه‌دارید، فیلتر کنید یا چندبار شمارش و پیمایش کنید، از [Collect.shapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) استفاده کنید.

**آیا Compress همیشه فایل ارائه را کوچک‌تر می‌كند؟**

لزوم کوچک‌تر شدن فایل به این بستگی دارد که آیا ارائه شامل طرح‌بندی‌های غيراستفاده، مسترهای غيراستفاده یا فونت‌های جاسازی‌شده با کاراکترهای غيراستفاده است یا نه. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) ممکن است اندازهٔ فایل را کاهش ندهند.

**آیا تغییرات ایجاد شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این كمك‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌كنند. پس از تغییر عناصر در یک فراخوانی [ForEach] یا اجرای [Compress]، برای نوشتن نتیجه باید از متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) استفاده کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/java/convert-presentation/)
- [Merge Presentations](/slides/fa/java/merge-presentation/)
- [Slide Master](/slides/fa/java/slide-master/)
- [Manage Text Box](/slides/fa/java/manage-textbox/)
- [Embedded Font](/slides/fa/java/embedded-font/)