---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در جاوا
linktitle: اندازه صفحه یادداشت
type: docs
weight: 10
url: /fa/java/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت‌ها
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه برگه‌پشت
- پاورپوینت
- ارائه
- PPT
- PPTX
- جاوا
- Aspose.Slides
description: "خواندن و تغییر ابعاد صفحه یادداشت‌ها در Aspose.Slides برای Java، تغییر جهت، تأیید اندازه‌های ذخیره‌شده، و خروجی گرفتن یادداشت‌ها یا برگه‌پشت‌ها به PDF و تصاویر."
---
## **مروری کلی**

از [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getNotesSize--) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [INotesSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotessize/) را برمی‌گرداند که متد [setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) آن ابعاد صفحه را تنظیم می‌کند. اگرچه نمی‌توان شیء تنظیمات را جایگزین کرد، می‌توانید ابعاد جدید را از طریق این متد اختصاص دهید.

عرض و ارتفاع به **نقطه** (points) مشخص می‌شوند، به‌طوری که در هر اینچ ۷۲ نقطه وجود دارد. به‌عنوان مثال، ۹۰۰ × ۶۰۰ نقطه معادل ۱۲.۵ × ۸⅓ اینچ است. این تنظیمات بر تمام ارائه اعمال می‌شوند، نه فقط روی یادداشت‌های یک اسلاید تک.

| تنظیمات | هدف |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getNotesSize--) | کنترل ابعاد صفحه یادداشت‌ها و ابعادی که برای خروجی‌های برگه‌پشت (handout) استفاده می‌شود. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideSize--) | کنترل ابعاد اسلایدهای معمولی ارائه از طریق [ISlideSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/). |

تغییر هر یک از این تنظیمات به‌صورت خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها نیز اسلایدهای معمولی را چرخانده نمی‌کند. برای تغییر اندازه اسلایدهای معمولی به [Slide Size](/slides/fa/java/slide-size/) مراجعه کنید.

مثال‌های زیر از یک فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های خروجی، از ارائه‌ای با حداقل یک اسلاید حاوی یادداشت‌های گوینده استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن ابعاد و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت مقایسه کنید: صفحه‌ای که عرض آن بزرگ‌تر است به‌صورت landscape (افقی) است، صفحه‌ای که ارتفاع بزرگ‌تر است portrait (عمودی) و ابعاد برابر صفحه‌ای مربع را توصیف می‌کند. این مثال ابعاد واقعی را به‌واسطه نقطه چاپ می‌کند، بدون این‌که به اندازه‌کاغذ استانداردی فرض کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
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

## **تغییر به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو طرف، از جمله در اندازه کاغذ سفارشی، را حفظ می‌کند. شرط زیر از تغییر مجدد یک صفحه افقی به عمودی جلوگیری می‌کند و صفحه‌های مربعی را دست‌نخورده می‌گذارد.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حالت عمودی نیز می‌توانید همان اختصاص را زمانی که `size.getWidth() > size.getHeight()` انجام دهید. مگر اینکه بخواهید اندازه کاغذ نیز تغییر کند، از ابعاد A4 یا Letter استفاده نکنید.

## **تنظیم و تأیید یک اندازه سفارشی برای صفحه یادداشت‌ها**

هر دو مقدار را به‌صورت همزمان اختصاص دهید، سپس با [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را ذخیره کنید. این مثال یک صفحه landscape با ابعاد ۹۰۰ × ۶۰۰ نقطه تنظیم می‌کند، آن را به‌صورت PPTX ذخیره می‌نماید و سپس برای بررسی مقدارهای ذخیره‑شده فایل را دوباره باز می‌کند. مقایسه tolerance 0.01 نقطه برای مقادیر اعشاری دارد؛ این ضمانت دقت برای هر قالب فایلی نیست.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
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

نتیجهٔ مورد انتظار `900.0 x 600.0 points` و `Size preserved: true` است. بررسی یک ارائهٔ تازه بازشده، فایل ذخیره‌شده را تأیید می‌کند، نه فقط تنظیمات در‑حافظه.

## **صادر کردن یادداشت‌ها و برگه‌پشت‌ها**

ابعاد صفحه ناحیهٔ قابل استفاده برای طرح‌های یادداشت یا برگه‌پشت را تعریف می‌کند. این تنظیمات به‌تنهایی این طرح‌ها را فعال نمی‌کنند: گزینه‌های خروجی نیز باید پیکربندی شوند. خروجی اسلایدهای معمولی همچنان از ابعاد اسلاید استفاده می‌کند.

### **صادر کردن یادداشت‌ها به PDF و PNG**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) را به [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) اختصاص دهید تا یادداشت‌ها در PDF گنجانده شوند. این مثال همچنین اسلاید اول حاوی یادداشت‌ها را با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) و [RenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/) به PNG رندر می‌کند.

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌های اضافی که جا نمی‌شوند قطع می‌شوند. PDF از صفحات ۹۰۰ × ۶۰۰ نقطه‌ای استفاده می‌کند. در مقیاس تصویر 1 × 1 که در زیر بکار رفته است، PNG برابر ۹۰۰ × ۶۰۰ پیکسل است. نقاط هندسهٔ صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی رستر هستند که ابعادشان نیز به مقیاس رندر وابسته است.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

برای خروجی PDF با یادداشت‌های طولانی، حالت [BottomFull](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notespositions/) صفحات بیشتری را در صورت نیاز اضافه می‌کند. از این حالت برای فراخوانی تک‑اسلایدی تصویر بالا که از آن پشتیبانی نمی‌شود، استفاده نکنید. پس از تغییر اندازه، خروجی را برای برش یادداشت‌ها و جای‌گذاری اشیای master‑یادداشت بررسی کنید؛ تغییر ابعاد صفحه به‌تنهایی تضمین نمی‌کند که همه محتوا جا بگیرد. برای جزئیات بیشتر دربارهٔ خروجی یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/java/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **صادر کردن برگه‌پشت‌ها به PDF**

برای چندین تصویر بندانگشتی اسلاید در یک صفحه، از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید. مثال زیر صفحه‌ای ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند و از [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) برای قرار دادن تا چهار اسلاید در هر صفحه بهره می‌گیرد. پیش‌تنظیم افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن می‌آید.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

تغییر اندازه صفحه ناحیهٔ قابل استفاده برای شبکهٔ برگه‌پشت را تغییر می‌دهد بدون اینکه ابعاد اسلایدهای منبع را تغییر دهد. برای تصاویر برگه‌پشت، از [Presentation.getImages](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) همراه با طرح برگه‌پشت استفاده کنید، نه متد تصویر اسلاید تک‌تکی. در Aspose.Slides، رندر برگه‌پشت سطح ارائه از ابعاد صفحه یادداشت استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید تک‌تکی صفحهٔ برگه‌پشت را تولید نمی‌کند. برای گزینه‌های طرح به [Handout Mode](/slides/fa/java/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازه صفحه در نمایشگرها، خروجی و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ خروجی و اندازهٔ کاغذ چاپی را جداگانه در نظر بگیرید:

- **نمایشگرهای ارائه:** یک نمایشگر می‌تواند یادداشت‌ها را بر اساس قوانین چیدمان خود نمایش یا چاپ کند. اگر برنامهٔ دیگری فایل را ذخیره کند، آن را دوباره باز کنید و ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است آنها را نرمال‌سازی کند.
- **قالب‌های خروجی:** مثال‌های PDF یادداشت و برگه‌پشت بالا از ابعاد صفحه تنظیم‌شده استفاده می‌کنند. تصاویر رستری از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. خروجی اسلایدهای معمولی از اندازهٔ صفحه یادداشت استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات «متناسب با صفحه» می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازه کاغذ خاص، تنظیمات چاپگر را مطابقت دهید و پیش‌نمایش چاپ را بررسی کنید.

## **سوالات متداول**

**آیا می‌توانم اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحه یادداشت یک تنظیم سطح ارائه است. اسلایدهای فردی می‌توانند محتوای یادداشت متفاوتی داشته باشند، اما این ویژگی اندازهٔ صفحه جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهای من را تغییر نداد؟**

صفحات یادداشت و اسلایدهای معمولی ابعاد مستقل دارند. برای تغییر اندازهٔ خود اسلایدها از تنظیمات اندازهٔ اسلاید معمولی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ‌شده من اندازهٔ متفاوتی دارد؟**

اولین بار ارائهٔ ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌ها را مقایسه کنید. اگر این ابعاد تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامهٔ دیگری تنظیمات صفحه را تغییر داده است یا نه. اگر نه، طرح خروجی، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.