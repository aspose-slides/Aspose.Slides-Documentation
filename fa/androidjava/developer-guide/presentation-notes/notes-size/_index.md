---
title: تغییر اندازه و جهت صفحه یادداشت در Android
linktitle: اندازه صفحه یادداشت
type: docs
weight: 10
url: /fa/androidjava/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه برگه تکثیر
- PowerPoint
- ارائه
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "ابعاد صفحه یادداشت‌ها را در Aspose.Slides برای Android با استفاده از Java بخوانید و تغییر دهید، جهت را سوئیچ کنید، اندازه‌های ذخیره‌شده را تأیید کنید، و یادداشت‌ها یا برگه‌های تکثیر را به PDF و تصاویر صادر کنید."
---
## **بررسی کلی**

از [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getNotesSize--) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [INotesSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotessize/) را بر می‌گرداند که متد [setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) ابعاد صفحه را تنظیم می‌کند. اگرچه نمی‌توان شیء تنظیمات را جایگزین کرد، می‌توانید ابعاد جدید را از طریق این متد اختصاص دهید.

عرض و ارتفاع بر حسب **نقطه** (point) مشخص می‌شوند و هر اینچ ۷۲ نقطه دارد. برای مثال، ۹۰۰ × ۶۰۰ نقطه معادل ۱۲.۵ × ۸⅓ اینچ است. این تنظیمات برای کل ارائه اعمال می‌شود، نه برای یادداشت‌های یک اسلاید به‌تنهایی.

| تنظیم | هدف |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getNotesSize--) | ابعاد صفحه یادداشت‌ها و ابعادی که برای خروجی دستیاب استفاده می‌شود را کنترل می‌کند. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideSize--) | ابعاد اسلایدهای معمولی ارائه را از طریق [ISlideSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/) کنترل می‌کند. |

تغییر هر یک از این تنظیمات به‌طور خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها نیز اسلایدهای عادی را چرخانده نمی‌کند. برای تغییر اندازه اسلایدهای عادی به [Slide Size](/slides/fa/androidjava/slide-size/) مراجعه کنید.

مثال‌های زیر از یک فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های خروجی، از ارائه‌ای که حداقل یک اسلاید دارای یادداشت‌های گوینده است استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت مقایسه کنید: صفحه‌ای که عرض آن بیشتر است افقی (landscape) است، صفحه‌ای که ارتفاع آن بیشتر است عمودی (portrait) و ابعاد مساوی صفحه مربع را توصیف می‌کند. این مثال ابعاد واقعی را بر حسب نقطه چاپ می‌کند، بدون این‌که فرضی در مورد اندازه استاندارد کاغذ باشد.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **تبدیل به افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را با هم تعویض کنید. این کار طول هر دو طرف، از جمله اندازه کاغذ سفارشی را حفظ می‌کند. شرط زیر از تبدیل یک صفحه‌ای که قبلاً افقی است به عمودی جلوگیری می‌کند و صفحه مربع را تغییر نمی‌دهد.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای جهت عمودی، همان انتساب را زمانی که `size.getWidth() > size.getHeight()` استفاده کنید. مگر اینکه بخواهید اندازه کاغذ را نیز تغییر دهید، از ابعاد A4 یا Letter استفاده نکنید.

## **تنظیم و تأیید اندازه سفارشی صفحه یادداشت‌ها**

هر دو بعد را به‌صورت همزمان اختصاص دهید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را ذخیره کنید. این مثال یک صفحه افقی ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند، آن را به صورت PPTX ذخیره می‌کند و سپس فایل ذخیره‌شده را دوباره باز می‌کند تا مقادیر ذخیره‌شده را بررسی کند. مقایسه با تحمل ۰.۰۱ نقطه برای مقادیر شناور انجام می‌شود؛ این به معنای دقت مطلق برای هر قالب فایل نیست.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

نتیجهٔ مورد انتظار `900.0 x 600.0 points` و `Size preserved: true` است. بررسی ارائه‌ای که تازه باز شده است، تضمین می‌کند که مقدار ذخیره‌شده در فایل، نه تنها تنظیمات در حافظه، صحیح باشد.

## **خروجی یادداشت‌ها و برگه‌های تکثیر**

ابعاد صفحه ناحیهٔ قابل استفاده برای طرح‌های یادداشت یا برگهٔ تکثیر را تعریف می‌کند. این ابعاد به‌تنهایی این طرح‌ها را فعال نمی‌سازند: باید گزینه‌های خروجی را نیز پیکربندی کنید. خروجی اسلایدهای عادی همچنان از ابعاد اسلاید استفاده می‌کند.

### **خروجی یادداشت‌ها به PDF و PNG**

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) را به [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) اختصاص دهید تا یادداشت‌ها در PDF گنجانده شوند. این مثال همچنین اولین اسلاید دارای یادداشت‌ها را به PNG رندر می‌کند با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) و [RenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/).

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌شوند می‌توانند قطع شوند. PDF از صفحات ۹۰۰ × ۶۰۰ نقطه‌ای استفاده می‌کند. در مقیاس تصویر ۱ × ۱ که در زیر به کار رفته، PNG دارای ۹۰۰ × ۶۰۰ پیکسل است. نقاط شکل هندسی صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی شطرنجی را توصیف می‌کنند که ابعاد آن نیز به مقیاس رندر بستگی دارد.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

برای خروجی PDF با یادداشت‌های طولانی، حالت [BottomFull](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notespositions/) صفحات اضافه را در صورت نیاز فراهم می‌کند. این حالت را همراه با فراخوانی تصویر تک‌اسلاید بالا استفاده نکنید، چرا که آن فراخوانی از این حالت پشتیبانی نمی‌کند. پس از تغییر اندازه، خروجی را برای قطع شدن یادداشت‌ها و مکان‌گذاری اشیای موجود در notes‑master بررسی کنید؛ تغییر تنها ابعاد صفحه نباید به‌عنوان تضمین اینکه تمام محتوا جا می‌شود تلقی شود. برای اطلاعات بیشتر درباره خروجی یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/androidjava/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **خروجی برگه‌های تکثیر به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handoutlayoutingoptions/) برای نمایش چند تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر صفحه‌ای ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند و از [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) برای چینش حداکثر چهار اسلاید در هر صفحه استفاده می‌کند. پیش‌تنظیم افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن می‌آید.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

تغییر اندازه صفحه ناحیهٔ قابل استفاده برای شبکهٔ برگه‌های تکثیر را بدون تغییر ابعاد اسلایدهای منبع تغییر می‌دهد. برای تصاویر برگه‌ها، به جای متد تصویر یک اسلاید، از [Presentation.getImages](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) همراه با طرح برگه استفاده کنید. در Aspose.Slides، رندرینگ برگه‌ها در سطح ارائه از ابعاد صفحه یادداشت استفاده می‌کند، در حالی که فراخوانی تصویر یک اسلاید تک‌تک صفحهٔ برگه تولید نمی‌کند. گزینه‌های طرح را در [Handout Mode](/slides/fa/androidjava/convert-powerpoint-in-handout-mode/) ببینید.

## **اندازه صفحه در نمایشگرها، خروجی و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ خروجی و اندازهٔ کاغذ چاپی را متمایز نگه دارید:

- **نمایشگرهای ارائه:** یک نمایشگر می‌تواند یادداشت‌ها را با قوانین طرح خود نمایش یا چاپ کند. اگر برنامهٔ دیگری فایل را ذخیره کرده، آن را باز کنید و دوباره ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است اندازه‌ها را نرمال‌سازی کند.
- **قالب‌های خروجی:** مثال‌های PDF برای یادداشت‌ها و برگه‌های تکثیر بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر شطرنجی از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای جزئی ممکن است در خروجی تصویر گرد شوند. خروجی اسلایدهای عادی از اندازهٔ صفحهٔ یادداشت استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات «متناسب با صفحه» می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازهٔ کاغذ مشخص، تنظیمات چاپگر را منطبق کنید و پیش‌نمایش چاپ را بررسی کنید.

## **پرسش‌های متداول**

**آیا می‌توان اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کرد؟**

اندازهٔ صفحهٔ یادداشت یک تنظیم سطح ارائه است. اسلایدهای منفرد می‌توانند محتوای یادداشت متفاوت داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهایم را تغییر نداد؟**

صفحات یادداشت و اسلایدهای عادی ابعاد مستقل دارند. برای تغییر اندازهٔ خود اسلایدها از تنظیمات اندازهٔ اسلاید معمولی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ‌شده من اندازهٔ متفاوتی دارد؟**

ابتدا ارائهٔ ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌ها را مقایسه کنید. اگر تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامهٔ دیگری اندازهٔ صفحه را تغییر داده است یا خیر. اگر نه، طرح خروجی، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.