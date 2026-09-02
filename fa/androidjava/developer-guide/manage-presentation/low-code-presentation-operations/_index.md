---
title: عملیات ارائه کم‌کد در اندروید
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/androidjava/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف مسترهای استفاده‌نشده
- حذف چیدمان‌های استفاده‌نشده
- فشرده‌سازی فونت‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در اندروید برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **نمای کلی**

پکیج [com.aspose.slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) کلاس‌های کمکی ایستاتیک برای عملیات رایج ارائه اسلاید فراهم می‌کند. این کمکی‌ها گردش‌کارهای متداول مدل شیء را در متدهای متمرکز می‌پیچند، تا بتوانید فایل‌ها را تبدیل یا ادغام کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف نمایید.

کمکی‌های کم‌کد زمانی مفیدند که عملیات بر تمام پرونده یا ارائه اعمال می‌شود و گردش‌کار پیش‌فرض نیازهای شما را برآورده می‌کند. هنگامی که نیاز به کنترل دقیق‌تر بر اسلایدهای فردی، مسترها، چیدمان‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه دارید، از مدل کامل [Aspose.Slides object model](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را نشان می‌دهد:

| دستیار | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/) | تبدیل یک ارائه به فرمت دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/) | ترکیب کامل پرونده‌های ارائه‌ای با همان فرمت. |
| [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/) | دریافت اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) | حذف مسترها و چیدمان‌های استفاده‌نشده و کاهش داده‌های فونت جاسازی‌شده. |

## **تبدیل یک ارائه**

زمانی که پسوند فایل خروجی به اندازه کافی برای انتخاب فرمت خروجی کافی است، از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) استفاده کنید. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF ارائه می‌دهد. زمانی که نیاز دارید پیش از خروجی‌گیری ارائه را بررسی یا تغییر دهید یا گزینهٔ خروجی‌ای که توسط کمکی موجود فراهم نشده است را پیکربندی کنید، از مدل کامل شیء استفاده کنید. برای گردش‌کارها و گزینه‌های مخصوص هر فرمت، به [Convert Presentation](/androidjava/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

برای ترکیب کامل پرونده‌های ارائه‌ای با یک فراخوانی، از [Merger.process](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) استفاده کنید. ارائه‌های ورودی باید دارای یک فرمت فایل مشابه باشند.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که تمام اسلایدها باید بدون انتخاب یا بازنگری جداگانه به یک نتیجه افزوده شوند. وقتی نیاز به ادغام اسلایدهای انتخابی، اعمال مستر یا چیدمان مقصد، حفظ بخش‌ها به‌صورت صریح یا هماهنگی اندازه‌های مختلف اسلاید دارید، از مدل کامل شیء استفاده کنید. برای این سناریوها، به [Merge Presentations](/androidjava/merge-presentation/) مراجعه کنید.

## **تکرار بر عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) برای هر نوع عنصر درخواست‌شدهٔ ارائه یک فراخوانی بازگشتی را اجرا می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییر فرمت سراسری ارائه مناسب است.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌طور پیش‌فرض، پیمایش اشکال و متن سراسری شامل اسلایدهای عادی، مستر و چیدمان می‌شود. بارگذاری‌های با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب پیمایش، خروج زودتر، فیلتر قبل از فراخوانی بازگشتی یا کنترل دقیق والد‑فرزندی مهم باشد، بهتر است از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

وقتی به مجموعه‌ای از تمام اشکال یک ارائه نیاز دارید و نه یک فراخوانی برای هر شکل، از [Collect.shapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) استفاده کنید. این روش وقتی مفید است که همان مجموعه چندین بار فیلتر، شمارش یا پردازش شود.

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

در صورتی که هر شکل بلافاصله قابل پردازش باشد و نیازی به نگهداری نتیجهٔ جمع‌آوری‌شده ندارید، به جای آن از [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف و داده‌های فونت جاسازی‌شده را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) اسلایدهای چیدمان را که هیچ اسلاید عادی به آنها ارجاع نمی‌دهد، حذف می‌کند.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) مسترهای استفاده‌نشده را حذف می‌کند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) کاراکترهای استفاده‌نشدهٔ فونت‌های جاسازی‌شده را حذف می‌کند.

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

قبل از حذف مسترهای استفاده‌نشده، ابتدا چیدمان‌های استفاده‌نشده را حذف کنید؛ به‌طوری‌که مستری که پس از پاک‌سازی چیدمان دیگر مرجعی نداشته باشد، نیز حذف شود. اگر ممکن است بعداً به مسترها، چیدمان‌ها یا دادهٔ کامل فونت‌های جاسازی‌شده اصلی نیاز داشته باشید، ارائهٔ بهینه‌شده را در فایل جدیدی ذخیره کنید. برای جزئیات بیشتر، به [Slide Master](/androidjava/slide-master/) و [Embedded Font](/androidjava/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمانی باید به جای مدل کامل شیء، API کم‌کد را استفاده کنم؟**

وقتی یک عملیات استاندارد بر کل پرونده یا ارائه اعمال می‌شود و نیاز به کنترل دقیق بر عناصر فردی ندارید، از کمکی‌های کم‌کد استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و چیدمان، بازرسی وضعیت میانی یا پیکربندی رفتارهایی دارید که کمکی آن را افشا نمی‌کند، از مدل کامل شیء استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در فرمت‌های فایل متفاوت ترکیب کند؟**

خیر. متد [Merger.process](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) به ارائه‌های ورودی با همان فرمت نیاز دارد. ابتدا فایل‌های ورودی را با مثال [Convert.autoByExtension](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) به فرمت مشترک تبدیل کنید و سپس آن‌ها را ادغام کنید.

**آیا ForEach اسلایدهای مستر، چیدمان و یادداشت‌ها را پردازش می‌کند؟**

متد [ForEach.slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) فقط اسلایدهای عادی ارائه را تکرار می‌کند. عملیات‌های سراسری [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) و [ForEach.portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) به‌صورت پیش‌فرض شامل اسلایدهای عادی، مستر و چیدمان می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، از بارگذاری‌های آن‌ها با مقدار `includeNotes` برابر با `true` استفاده کنید.

**تفاوت بین ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) برای پردازش فوری هر شکل از طریق یک فراخوانی استفاده کنید. وقتی به یک نتیجهٔ قابل تکرار نیاز دارید که بتوان آن را نگه‌داشت، فیلتر یا شمارش کرد، از [Collect.shapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) استفاده کنید.

**آیا Compress همیشه اندازهٔ فایل ارائه را کوچکتر می‌کند؟**

لزومی ندارد. نتیجه بستگی به این دارد که آیا ارائه شامل چیدمان‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های جاسازی‌شده با کاراکترهای استفاده‌نشده می‌باشد یا خیر. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) ممکن است اندازهٔ فایل را کاهش ندهند.

**آیا تغییرات انجام‌شده توسط ForEach یا Compress به‌طور خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها روی شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در فراخوانی [ForEach](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/)، برای نوشتن نتیجه باید متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) فراخوانی شود.

## **مقالات مرتبط**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)