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
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف مسترهای استفاده‌نشده
- حذف طرح‌بندی‌های استفاده‌نشده
- فشرده‌سازی فونت‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "از API کد کم Aspose.Slides در جاوا برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش اندازه ارائه استفاده کنید."
---
## **مرور کلی**

پکیج [com.aspose.slides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) کلاس‌های کمکی استاتیک برای عملیات رایج ارائه فراهم می‌کند. این کمکی‌ها فرآیندهای پرکاربرد مدل شیء را در متدهای متمرکز می‌پیچند، به طوری که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمک‌کننده‌های کم‌کد هنگامی مفیدترین هستند که عملیات بر روی کل فایل یا ارائه اعمال می‌شود و جریان کار پیش‌فرض با نیازهای شما مطابقت دارد. زمانی که به کنترل دقیق بر روی اسلایدهای منفرد، مسترها، طرح‌بندی‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه نیاز دارید، از مدل کامل شیء [Aspose.Slides object model](https://reference.aspose.com/slides/fa/java/com.aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را ارائه می‌دهد:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/) | تبدیل یک ارائه به فرمت دیگر با فراخوانی مستقیم file-to-file. |
| [Merger](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/) | ترکیب کامل فایل‌های ارائه با فرمت یکسان. |
| [ForEach](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/) | بازگرداندن اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) | حذف مسترها و طرح‌بندی‌های استفاده‌نشده و کاهش داده‌های فونت توکار. |

## **تبدیل یک ارائه**

از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) زمانی استفاده کنید که پسوند فایل خروجی برای انتخاب فرمت خروجی کافی باشد. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF ارائه می‌دهد. زمانی که نیاز به بررسی یا تغییر ارائه پیش از خروجی یا پیکربندی گزینه‌ای دارید که توسط کمکی انتخاب‌شده در دسترس نیست، از مدل کامل شیء استفاده کنید. برای جریان‌های کاری و گزینه‌های مخصوص به فرمت، به [تبدیل ارائه](/java/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) برای ترکیب کامل فایل‌های ارائه با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان فرمت فایل را داشته باشند.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

کمک‌کننده مناسب است زمانی که تمام اسلایدها باید بدون انتخاب یا بازنقشه‌برداری جداگانه به یک نتیجه اضافه شوند. زمانی که نیاز به ترکیب اسلایدهای انتخابی، اعمال مستر یا طرح‌بندی مقصد، حفظ بخش‌ها به‌صورت صریح، یا تطبیق اندازه‌های اسلاید متفاوت دارید، از مدل کامل شیء استفاده کنید. برای این سناریوها، به [ترکیب ارائه‌ها](/java/merge-presentation/) مراجعه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/) برای هر نوع عنصر ارائه درخواست‌شده یک فراخوانی بازخورد (callback) اعمال می‌کند. این کار از حلقه‌های تو در تو جلوگیری می‌کند و برای بازرسی یا تغییرات فرمت‌بندی در سراسر ارائه مناسب است.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌طور پیش‌فرض، پیمایش اشکال و متن در سراسر ارائه شامل اسلایدهای عادی، مستر و طرح‌بندی می‌شود. بارگذاری‌های دیگر با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. زمانی که ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از فراخوانی بازخشت یا کنترل دقیق والد‑فرزند مهم است، از حلقه‌های مستقیم مجموعه استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.shapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) زمانی استفاده کنید که به مجموعه‌ای از تمام اشکال در یک ارائه نیاز دارید نه یک بازخشت برای هر شکل. این برای مواقعی مفید است که همان مجموعه چندین بار فیلتر، شمارش یا پردازش می‌شود.

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

به جای آن وقتی هر شکل می‌تواند بلافاصله پردازش شود و نیازی به نگه‌دار کردن نتیجه جمع‌آوری‌شده ندارید، از [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کند و داده‌های فونت توکار را کاهش دهد:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) اسلایدهای طرح‌بندی را که هیچ اسلاید عادی به آن ارجاع نمی‌دهد حذف می‌کند.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) مسترهای دیگر استفاده‌نشده را حذف می‌کند.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) کاراکترهای استفاده‌نشده از فونت‌های توکار را حذف می‌کند.

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

قبل از حذف مسترهای استفاده‌نشده، طرح‌بندی‌های استفاده‌نشده را حذف کنید تا مستری که پس از پاک‌سازی طرح‌بندی به‌طور غیرمستقیم خالی شد، نیز حذف شود. اگر ممکن است بعداً به مسترها، طرح‌بندی‌ها یا داده‌های کامل فونت‌های توکار اصلی نیاز داشته باشید، ارائه بهینه‌شده را در یک فایل جدید ذخیره کنید. برای جزئیات بیشتر، به [مستر اسلاید](/java/slide-master/) و [فونت توکار](/java/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمانی باید از API کم‌کد به جای مدل کامل شیء استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد نیست، از کمک‌کننده‌های کم‌کد استفاده کنید. وقتی باید اسلایدهای خاصی را انتخاب کنید، روابط مستر و طرح‌بندی را کنترل کنید، وضعیت میانی را بررسی کنید یا رفتارهایی را پیکربندی کنید که کمکی در معرض آن‌ها قرار نمی‌دهد، از مدل کامل شیء استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در فرمت‌های فایل مختلف ترکیب کند؟**

نه. [Merger.process](https://reference.aspose.com/slides/fa/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) نیاز دارد که ارائه‌های ورودی همان فرمت را داشته باشند. ابتدا فایل‌های ورودی را با مثال [Convert.autoByExtension](https://reference.aspose.com/slides/fa/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) به یک فرمت مشترک تبدیل کنید و سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach اسلایدهای مستر، طرح‌بندی و یادداشت‌ها را پردازش می‌کند؟**

[ForEach.slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) بر روی اسلایدهای عادی ارائه تکرار می‌کند. [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و [ForEach.portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) به‌طور پیش‌فرض اسلایدهای عادی، مستر و طرح‌بندی را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، از بارگذاری‌های آن‌ها با `includeNotes` برابر `true` استفاده کنید.

**تفاوت Between ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) برای پردازش هر شکل به‌صورت فوری از طریق یک بازخشت استفاده کنید. از [Collect.shapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) وقتی به نتیجه‌ای قابل تکرار نیاز دارید که می‌تواند حفظ، فیلتر یا چندبار شمارش شود، استفاده کنید.

**آیا Compress همیشه فایل ارائه را کوچکتر می‌کند؟**

ضروری نیست. نتیجه به این بستگی دارد که آیا ارائه شامل طرح‌بندی‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های توکار با کاراکترهای استفاده‌نشده است یا خیر. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات مربوط به [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهد.

**آیا تغییرات ایجادشده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

نه. این کمک‌کننده‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در یک بازخشت [ForEach](https://reference.aspose.com/slides/fa/java/com.aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/)، برای نوشتن نتیجه باید از [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) استفاده کنید.

## **مقالات مرتبط**

- [تبدیل ارائه](/java/convert-presentation/)
- [ترکیب ارائه‌ها](/java/merge-presentation/)
- [مستر اسلاید](/java/slide-master/)
- [مدیریت جعبه متن](/java/manage-textbox/)
- [فونت توکار](/java/embedded-font/)