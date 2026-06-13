---
title: جاسازی فونت‌ها در ارائه‌ها با Python
linktitle: جاسازی فونت
type: docs
weight: 40
url: /fa/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET جاسازی کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **معرفی**

**جاسازی فونت‌ها در PowerPoint** اطمینان می‌دهد که ارائه شما ظاهر موردنظر خود را در سیستم‌های مختلف حفظ کند. چه از فونت‌های منحصر به فرد برای خلاقیت استفاده کنید و چه فونت‌های استاندارد، جاسازی فونت‌ها از بروز اختلال در متن و چیدمان جلوگیری می‌کند.

اگر به دلیل خلاقیت در کارتان از فونتی شخص ثالث یا غیر استاندارد استفاده کرده‌اید، دلایل بیشتری برای جاسازی فونت خود دارید. در غیر این صورت (بدون فونت‌های جاسازی‌شده)، متن‌ها یا اعداد روی اسلایدها، چیدمان، سبک‌ها و غیره ممکن است تغییر کنند یا به مستطیل‌های گیج‌کننده تبدیل شوند.

از کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontdata/)، و [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) برای مدیریت فونت‌های جاسازی‌شده استفاده کنید.

## **دریافت و حذف فونت‌های جاسازی‌شده**

به راحتی می‌توانید با استفاده از متدهای [get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و [remove_embedded_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/remove_embedded_font/) فونت‌های جاسازی‌شده را از یک ارائه دریافت یا حذف کنید.

این کد Python نشان می‌دهد که چگونه فونت‌های جاسازی‌شده را از یک ارائه دریافت و حذف کنید:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است، ایجاد می‌شود.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # اسلایدی که شامل فریم متنی است و از فونت جاسازی شده 'FunSized' استفاده می‌کند، رندر می‌شود.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # تمام فونت‌های جاسازی‌شده را دریافت کنید.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # فونت 'Calibri' را پیدا کنید.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # فونت 'Calibri' را حذف کنید.
    fonts_manager.remove_embedded_font(font_data)

    # اسلاید را رندر کنید؛ فونت 'Calibri' با یک فونت موجود جایگزین خواهد شد.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # ارائه را بدون فونت جاسازی‌شده 'Calibri' روی دیسک ذخیره کنید.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **اضافه کردن فونت‌های جاسازی‌شده**

با استفاده از enum [EmbedFontCharacters](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/embedfontcharacters/) و دو overload از متد [add_embedded_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/add_embedded_font/) می‌توانید قانون (جاسازی) دلخواه خود را برای جاسازی فونت‌ها در یک ارائه انتخاب کنید. این کد Python نشان می‌دهد که چگونه فونت‌ها را به یک ارائه جاسازی و اضافه کنید:
```python
import aspose.slides as slides

# یک ارائه را بارگذاری کنید.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

با فشرده‌سازی فونت‌های جاسازی‌شده با استفاده از [compress_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) حجم فایل را بهینه کنید. مثال کد برای فشرده‌سازی:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک فونت خاص در ارائه با وجود جاسازی همچنان در هنگام رندر جایگزین می‌شود؟**

اطلاعات [اطلاعات جایگزینی](/slides/fa/python-net/font-substitution/) را در مدیر فونت‌ها و [قوانین پیش‌فرض/جایگزینی](/slides/fa/python-net/fallback-font/) را بررسی کنید: اگر فونت موجود نباشد یا محدود باشد، یک فونت جایگزین استفاده خواهد شد.

**آیا جاسازی فونت‌های «سیستمی» مانند Arial/Calibri ارزش دارد؟**

معمولاً نه — این فونت‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت انتقال کامل در محیط‌های «نازک» (Docker، یک سرور لینکس بدون فونت‌های پیش‌نصب‌شده)، جاسازی فونت‌های سیستمی می‌تواند خطر جایگزینی‌های ناخواسته را از بین ببرد.