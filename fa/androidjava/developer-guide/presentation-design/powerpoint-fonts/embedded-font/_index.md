---
title: "جاسازی فونت‌ها در ارائه‌ها روی اندروید"
linktitle: "جاسازی فونت"
type: docs
weight: 40
url: /fa/androidjava/embedded-font/
keywords:
- "افزودن فونت"
- "جاسازی فونت"
- "جاسازی فونت"
- "دریافت فونت جاسازی‌شده"
- "افزودن فونت جاسازی‌شده"
- "حذف فونت جاسازی‌شده"
- "فشرده‌سازی فونت جاسازی‌شده"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید از طریق Java جاسازی کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **مقدمه**

**فونت‌های جاسازی‌شده در PowerPoint** برای زمانی که می‌خواهید ارائه‌تان در هر سیستم یا دستگاهی به‌درستی نمایش داده شود، مفید هستند. اگر به‌دلیل خلاقیت در کار خود از یک فونت شخص ثالث یا غیر استاندارد استفاده کرده‌اید، دلایل بیشتری برای جاسازی فونت دارید. در غیر این صورت (بدون فونت‌های جاسازی‌شده)، متن یا اعداد اسلایدهای شما، چیدمان، استایل و غیره ممکن است تغییر کرده یا به مستطیل‌های گیج‌کننده تبدیل شوند.

کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) کلاس [FontData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontdata/) کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) و رابط‌های آن‌ها شامل بیشتر ویژگی‌ها و متدهایی هستند که برای کار با فونت‌های جاسازی‌شده در ارائه‌های PowerPoint به آن‌ها نیاز دارید.

## **دریافت و حذف فونت‌های جاسازی‌شده**

کلاس Aspose.Slides متد [getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (که توسط کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) در دسترس است) را فراهم می‌کند تا بتوانید فونت‌های جاسازی‌شده در یک ارائه را دریافت (یا شناسایی) کنید. برای حذف فونت‌ها، از متد [removeEmbeddedFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (که توسط همان کلاس در دسترس است) استفاده می‌شود.

این کد Java نشان می‌دهد چگونه می‌توانید فونت‌های جاسازی‌شده را از یک ارائه دریافت و حذف کنید:
```java
// یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // یک اسلاید حاوی فریم متنی که از "FunSized" جاسازی‌شده استفاده می‌کند را رندر می‌کند
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // ذخیره تصویر در دیسک به فرمت JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // دریافت تمام فونت‌های جاسازی‌شده
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // یافتن فونت "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // حذف فونت "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // رندر ارائه؛ فونت "Calibri" با یک فونت موجود جایگزین می‌شود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // ذخیره تصویر در دیسک به فرمت JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // ذخیره ارائه بدون فونت جاسازی‌شده "Calibri" در دیسک
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن فونت‌های جاسازی‌شده**

با استفاده از enum [EmbedFontCharacters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedfontcharacters/) و دو overload متد [addEmbeddedFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) می‌توانید قانون موردنظر خود برای جاسازی فونت‌ها در یک ارائه را انتخاب کنید. این کد Java نشان می‌دهد چگونه می‌توانید فونت‌ها را در یک ارائه جاسازی و افزودن کنید:
```java
// پرزنتیشن را بارگذاری می‌کند
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

    // ارائه را در دیسک ذخیره می‌کند
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

برای این که بتوانید فونت‌های جاسازی‌شده در یک ارائه را فشرده‌سازی کرده و حجم فایل آن را کاهش دهید، Aspose.Slides متد [compressEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (که توسط کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) در دسترس است) را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه می‌توانید فونت‌های جاسازی‌شده PowerPoint را فشرده‌سازی کنید:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم متوجه شوم که یک فونت خاص در ارائه حتی با وجود جاسازی، هنگام رندر جایگزین خواهد شد؟**

اطلاعات [اطلاعات جایگزینی](/slides/fa/androidjava/font-substitution/) را در مدیر فونت بررسی کنید و به [قواعد پشتیبان/جایگزینی](/slides/fa/androidjava/fallback-font/) مراجعه کنید: اگر فونت در دسترس نباشد یا محدود باشد، یک فونت جایگزین استفاده می‌شود.

**آیا ارزش دارد که فونت‌های "سیستمی" مانند Arial/Calibri را جاسازی کنیم؟**

معمولاً نه — این فونت‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های "باریک" (Docker، یک سرور لینوکسی بدون فونت‌های پیش‌نصب‌شده)، جاسازی فونت‌های سیستمی می‌تواند خطر جایگزینی‌های غیرمنتظره را از بین ببرد.