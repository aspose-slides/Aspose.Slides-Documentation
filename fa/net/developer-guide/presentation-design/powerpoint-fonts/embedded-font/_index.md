---
title: یکپارچه‌سازی قلم‌ها در ارائه‌ها با .NET
linktitle: یکپارچه‌سازی قلم
type: docs
weight: 40
url: /fa/net/embedded-font/
keywords:
- افزودن قلم
- یکپارچه‌سازی قلم
- یکپارچه‌سازی قلم
- دریافت قلم یکپارچه‌شده
- افزودن قلم یکپارچه‌شده
- حذف قلم یکپارچه‌شده
- فشرده‌سازی قلم یکپارچه‌شده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قلم‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET یکپارچه کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **مقدمه**

**یکپارچه‌سازی قلم‌ها در PowerPoint** اطمینان می‌دهد که ارائه شما ظاهر موردنظر خود را در سیستم‌های مختلف حفظ کند. چه از قلم‌های منحصر به فرد برای خلاقیت استفاده کنید و چه از قلم‌های استاندارد، یکپارچه‌سازی قلم‌ها از به هم‌ریختگی متن و طرح جلوگیری می‌کند.

اگر به دلیل خلاقیت در کار خود از قلم‌های شخص ثالث یا غیر استاندارد استفاده کرده‌اید، دلایل بیشتری برای یکپارچه‌سازی قلم خود دارید. در غیر این صورت (بدون قلم‌های یکپارچه‌شده)، متن‌ها یا اعداد روی اسلایدها، طرح، استایل و غیره ممکن است تغییر کنند یا به مستطیل‌های مبهم تبدیل شوند. 

از کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/fa/net/aspose.slides/fontdata/)، و [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) برای مدیریت قلم‌های یکپارچه‌شده استفاده کنید.

## **دریافت و حذف قلم‌های یکپارچه‌شده**

قلم‌های یکپارچه‌شده را به راحتی از یک ارائه دریافت یا حذف کنید با استفاده از متدهای [GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts) و [RemoveEmbeddedFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/removeembeddedfont).

این کد C# نشان می‌دهد چگونه قلم‌های یکپارچه‌شده را از یک ارائه دریافت و حذف کنید:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // اسلایدی را رندر می‌کند که شامل فریم متنی است که از "FunSized" یکپارچه استفاده می‌کند
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // قلم "Calibri" را پیدا می‌کند
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // قلم "Calibri" را حذف می‌کند
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // ارائه را رندر می‌کند؛ قلم "Calibri" با یک قلم موجود جایگزین می‌شود
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // ارائه را بدون قلم یکپارچه "Calibri" روی دیسک ذخیره می‌کند
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **افزودن قلم‌های یکپارچه‌شده**

با استفاده از enum [EmbedFontCharacters](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedfontcharacters/) و دو overload متد [AddEmbeddedFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/addembeddedfont/) می‌توانید قانون (یکپارچه‌سازی) دلخواه خود را برای یکپارچه‌سازی قلم‌ها در یک ارائه انتخاب کنید. این کد C# نشان می‌دهد چگونه قلم‌ها را در یک ارائه یکپارچه و اضافه کنید:

```c#
// ارائه را بارگذاری می‌کند
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// ارائه را روی دیسک ذخیره می‌کند
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **فشرده‌سازی قلم‌های یکپارچه‌شده**

با استفاده از [CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/compressembeddedfonts/) قلم‌های یکپارچه‌شده را فشرده کنید تا حجم فایل بهینه شود.

کد مثال برای فشرده‌سازی:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک قلم خاص در ارائه باوجود یکپارچه‌سازی همچنان در هنگام رندر جایگزین می‌شود؟**

اطلاعات [جایگزینی](/slides/fa/net/font-substitution/) را در مدیریت قلم و [قواعد fallback/جایگزینی](/slides/fa/net/fallback-font/) بررسی کنید: اگر قلم در دسترس نباشد یا محدود شده باشد، یک fallback استفاده می‌شود.

**آیا یکپارچه‌سازی قلم‌های "سیستمی" مانند Arial/Calibri ارزش دارد؟**

معمولاً نه—این قلم‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های «نازک» (Docker، سرور لینوکسی بدون قلم‌های پیش‌نصب شده)، یکپارچه‌سازی قلم‌های سیستمی می‌تواند خطر جایگزینی‌های ناخواسته را حذف کند.