---
title: جاسازی فونت‌ها در ارائه‌ها با استفاده از Java
linktitle: جاسازی فونت
type: docs
weight: 40
url: /fa/java/embedded-font/
keywords:
- افزودن فونت
- جاسازی فونت
- جاسازی فونت
- دریافت فونت جاسازی‌شده
- افزودن فونت جاسازی‌شده
- حذف فونت جاسازی‌شده
- فشرده‌سازی فونت جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java جاسازی کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **مقدمه**

**فونت‌های جاسازی‌شده در PowerPoint** زمانی مفید هستند که می‌خواهید ارائه‌ی شما در هر سیستم یا دستگاهی به‌درستی نمایش داده شود. اگر به‌دلیل خلاقیت در کار خود از یک فونت شخص ثالث یا غیر استاندارد استفاده کرده‌اید، دلایل بیشتری برای جاسازی فونت دارید. در غیر اینصورت (بدون فونت‌های جاسازی‌شده)، متن‌ها یا اعداد اسلایدها، چیدمان، سبک‌ها و غیره ممکن است تغییر کنند یا به مستطیل‌های گیج‌کننده تبدیل شوند.  

کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager)، [FontData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontdata/)، [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) و رابط‌های آنها اکثر ویژگی‌ها و متدهایی را که برای کار با فونت‌های جاسازی‌شده در ارائه‌های PowerPoint نیاز دارید، شامل می‌شوند.  

## **دریافت و حذف فونت‌های جاسازی‌شده**

Aspose.Slides متد [getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (که توسط کلاس [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) ارائه می‌شود) را برای دریافت (یا شناسایی) فونت‌های جاسازی‌شده در یک ارائه فراهم می‌کند. برای حذف فونت‌ها، از متد [removeEmbeddedFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (که توسط همان کلاس ارائه می‌شود) استفاده می‌شود.  

این کد Java نشان می‌دهد چگونه فونت‌های جاسازی‌شده را از یک ارائه دریافت و حذف کنید:

```java
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // یک اسلاید حاوی فریم متنی که از فونت جاسازی‌شده "FunSized" استفاده می‌کند را رندر می‌کند
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // تصویر را با فرمت JPEG روی دیسک ذخیره می‌کند
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // تمام فونت‌های جاسازی‌شده را دریافت می‌کند
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // فونت "Calibri" را پیدا می‌کند
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // فونت "Calibri" را حذف می‌کند
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // ارائه را رندر می‌کند؛ فونت "Calibri" با یک فونت موجود جایگزین می‌شود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // تصویر را با فرمت JPEG روی دیسک ذخیره می‌کند
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // ارائه را بدون فونت جاسازی‌شده "Calibri" روی دیسک ذخیره می‌کند
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اضافه‌کردن فونت‌های جاسازی‌شده**

با استفاده از enum [EmbedFontCharacters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedfontcharacters/) و دو overload از متد [addEmbeddedFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)، می‌توانید قانون (جاسازی) مورد نظر خود را برای جاسازی فونت‌ها در یک ارائه انتخاب کنید. این کد Java نشان می‌دهد چگونه فونت‌ها را در یک ارائه جاسازی و اضافه کنید:

```java
// ارائه را بارگذاری می‌کند
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

برای امکان فشرده‌سازی فونت‌های جاسازی‌شده در یک ارائه و کاهش حجم فایل آن، Aspose.Slides متد [compressEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (که توسط کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) ارائه می‌شود) را فراهم می‌کند.  

این کد Java نشان می‌دهد چگونه فونت‌های جاسازی‌شده‌ی PowerPoint را فشرده کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فونت خاص در ارائه با وجود جاسازی، هنگام رندرینگ هنوز جایگزین خواهد شد؟**  

اطلاعات [substitution information](/slides/fa/java/font-substitution/) را در مدیریت‌گر فونت و قوانین [fallback/substitution rules](/slides/fa/java/fallback-font/) بررسی کنید: اگر فونت در دسترس نباشد یا محدود شده باشد، از یک فونت جایگزین استفاده خواهد شد.  

**آیا جاسازی فونت‌های "سیستمی" مانند Arial/Calibri ارزش دارد؟**  

معمولاً نه—این فونت‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های "باریک" (Docker، سرور لینوکس بدون فونت‌های پیش‌نصب شده)، جاسازی فونت‌های سیستمی می‌تواند خطر جایگزین شدن ناخواسته را از بین ببرد.