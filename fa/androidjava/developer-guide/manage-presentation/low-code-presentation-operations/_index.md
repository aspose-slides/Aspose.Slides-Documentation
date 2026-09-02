---
title: عملیات ارائه با کد کم در اندروید
linktitle: API کد کم
type: docs
weight: 50
url: /fa/androidjava/low-code-presentation-operations/
keywords:
- API ارائه کد کم
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر استفاده‌نشده
- حذف اسلایدهای چیدمان استفاده‌نشده
- فشرده‌سازی فونت‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "از API کد کم Aspose.Slides در اندروید برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **مرور کلی**

پکیج [com.aspose.slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) کلاس‌های کمکی استاتیک برای عملیات‌های معمول ارائه فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدل‌شیء که به‌طور مکرر استفاده می‌شوند را در متدهای متمرکز می‌پیچند، به‌طوری‌که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمکی‌های کم‌کد زمانی مفیدترینند که عملیات بر روی کل فایل یا ارائه اعمال شود و جریان کاری پیش‌فرض با نیازهای شما مطابقت داشته باشد. وقتی به کنترل دقیق بر اسلایدهای منفرد، مسترها، چیدمان‌ها، اشکال، تنظیمات صادر کردن یا روابط بین عناصر ارائه نیاز دارید، از مدل کامل [Aspose.Slides object model](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمک‌کننده‌های موجود را ارائه می‌دهد:

| کمکی | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/) | ترکیب کامل فایل‌های ارائه با یک قالب یکسان. |
| [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/) | استخراج اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) | حذف مسترها و چیدمان‌های استفاده‌نشده و کاهش داده‌های فونت توکار. |

## **تبدیل ارائه**

از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) زمانی استفاده کنید که پسوند فایل خروجی برای انتخاب فرمت صادرات کافی باشد. این متد ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. وقتی قبل از صادرات نیاز به بررسی یا اصلاح ارائه دارید یا می‌خواهید گزینه‌ای پیکربندی کنید که توسط کمکی که انتخاب کرده‌اید در دسترس نیست، از مدل کامل شیء استفاده کنید. برای گردش کارها و گزینه‌های خاص قالب، به [Convert Presentation](/slides/fa/androidjava/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) برای ترکیب کامل فایل‌های ارائه با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که تمام اسلایدها بدون انتخاب یا نگاشت جداگانه باید به یک نتیجه اضافه شوند. وقتی نیاز به ترکیب اسلایدهای انتخابی، اعمال مستر یا چیدمان مقصد، حفظ بخش‌ها به‌صورت صریح یا هماهنگ‌سازی اندازه‌های متفاوت اسلاید دارید، از مدل کامل شیء استفاده کنید. برای این سناریوها به [Merge Presentations](/slides/fa/androidjava/merge-presentation/) نگاه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) یک کال‌بک را برای هر نوع عنصر درخواست‌شده از ارائه فراخوانی می‌کند. این کار از حلقه‌های تو در توی مجموعه‌ها جلوگیری می‌کند و برای بازرسی یا تغییر فرمت سطح کل ارائه مناسب است.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) برای بررسی عناصر مربوطه استفاده می‌کند:

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

به‌صورت پیش‌فرض، عبور از اشکال و متن در سراسر ارائه شامل اسلایدهای عادی، مستر و چیدمان است. overloadهایی با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب عبور، خروج زودهنگام، فیلتر قبل از فراخوانی کال‌بک یا کنترل دقیق والد‑فرزند مهم باشد، می‌توانید به‌جای این روش از حلقه‌های مستقیم مجموعه استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.shapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) وقتی نیاز به مجموعه‌ای از تمام اشکال در یک ارائه دارید استفاده کنید؛ نه یک کال‌بک برای هر شکل. این روش زمانی مفید است که همان مجموعه چند بار فیلتر، شمارش یا پردازش شود.

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

در صورتی که هر شکل بلافاصله قابل پردازش باشد و نیازی به نگهداری نتایج جمع‌آوری‌شده نیست، به‌جای آن از [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کرده و داده‌های فونت توکار را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) اسلایدهای چیدمان را حذف می‌کند که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) مسترهای استفاده‌نشده را حذف می‌کند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) نویسه‌های استفاده‌نشده را از فونت‌های توکار حذف می‌کند.

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

ابتدا چیدمان‌های استفاده‌نشده را قبل از مسترهای استفاده‌نشده حذف کنید؛ به‌طوری‌که مستری که پس از پاک‌سازی چیدمان‌ها دیگر ارجاع ندارند نیز حذف شود. اگر ممکن است بعداً به مسترها، چیدمان‌ها یا داده‌های کامل فونت توکار اصلی نیاز داشته باشید، ارائه بهینه‌شده را در فایل جدید ذخیره کنید. برای جزئیات بیشتر به [Slide Master](/slides/fa/androidjava/slide-master/) و [Embedded Font](/slides/fa/androidjava/embedded-font/) مراجعه کنید.

## **پرسش‌های متداول**

**چه زمانی باید از API کم‌کد به‌جای مدل کامل شیء استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی کل فایل یا ارائه اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد نیست، از کمکی‌های کم‌کد استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و چیدمان، بازرسی وضعیت میانی یا پیکربندی رفتاری که کمکی آن را ارائه نمی‌دهد، دارید، از مدل کامل شیء استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**

خیر. متد [Merger.process](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) نیاز دارد که ارائه‌های ورودی هم‌قالب باشند. ابتدا فایل‌های ورودی را به قالب مشترک تبدیل کنید، برای مثال با [Convert.autoByExtension](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)، سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach اسلایدهای مستر، چیدمان و یادداشت‌ها را پردازش می‌کند؟**

متد [ForEach.slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) فقط اسلایدهای عادی ارائه را مرور می‌کند. عملیات‌های سطح‑کل [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) به‌طور پیش‌فرض شامل اسلایدهای عادی، مستر و چیدمان می‌شوند. برای شامل‌کردن اسلایدهای یادداشت‌ها می‌توانید overloadهای آن‌ها را با مقدار `includeNotes` برابر `true` فراخوانی کنید.

**تفاوت بین ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) برای پردازش هر شکل بلافاصله از طریق کال‌بک استفاده کنید. وقتی به یک نتیجه قابل پیمایش نیاز دارید که بتوانید آن را نگه دارید، فیلتر کنید، شمارش کنید یا چند بار پیمایش کنید، از [Collect.shapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) استفاده کنید.

**آیا Compress همیشه اندازه فایل ارائه را کوچک‌تر می‌کند؟**

لزماً نیست. نتیجه بستگی دارد به این که آیا ارائه شامل چیدمان‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های توکار با نویسه‌های استفاده‌نشده باشد. اگر هیچ‌یک از این موارد موجود نباشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط ForEach یا Compress به‌طور خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از تغییر عناصر در کال‌بک [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/)، برای نوشتن نتیجه باید از [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) استفاده کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/androidjava/convert-presentation/)
- [Merge Presentations](/slides/fa/androidjava/merge-presentation/)
- [Slide Master](/slides/fa/androidjava/slide-master/)
- [Manage Text Box](/slides/fa/androidjava/manage-textbox/)
- [Embedded Font](/slides/fa/androidjava/embedded-font/)