---
title: مدیریت تم‌های ارائه PowerPoint در پایتون
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/python-net/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- قلم تم
- استایل تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "تم‌های ارائه اصلی را در Aspose.Slides برای پایتون از طریق .NET به‌کار بگیرید تا فایل‌های PowerPoint را با برندینگ یکسان ایجاد، سفارشی‌سازی و تبدیل کنید."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیاء آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به‌جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را به‌طور همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم را در سطوح پایین‌تر نیز داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/masterthememanager/override_theme/) بازنویسی کند، یک لایه می‌تواند تم به‌دست‌آمده خود را از طریق [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) بازنویسی کند و یک اسلاید جداگانه می‌تواند همین کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی استایل‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/) ویژگی‌های [color_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/font_scheme/) و [format_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/format_scheme/) تم را در معرض نمایش می‌گذارد. بررسی این مجموعه‌ها قبل از تغییر آن‌ها به‌ویژه وقتی مفید است که یک ارائه از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های استایل می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند استایل پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

اگر یک فایل از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مربوط است را بررسی کنید و هنگام وجود بازنویسی‌های لایه یا اسلاید از جریان کاری تم مؤثر نشان داده‌شده در ادامه این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند نسبت به مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `ACCENT4` استفاده می‌کند، رنگ `accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

از آنجا که مستطیل به `ACCENT4` همچنان مرتبط است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، انواع روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/colortransformoperation/) در اختیار می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولیدشده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - انواع روشن‌تر و تیره‌تر تولیدشده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `ACCENT4` ایجاد می‌کند، به پنج مورد از آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

این انواع همچنان بر پایه رنگ تم باقی می‌مانند. اگر `accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به سلول‌های `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) از `TEXT1`، `BACKGROUND1`، `TEXT2` و `BACKGROUND2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) همان سلول‌های تم را به‌صورت `dark1`، `light1`، `dark2` و `light2` در معرض نمایش می‌گذارد. این نگاشت ثابت است:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

این‌ها نام‌های دیگری برای همان سلول‌های تم هستند؛ مقادیری که به‌صورت پویا از یک شکل به شکل دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح‌نامه قلم تم شامل یک مجموعه قلم اصلی برای سرعنوان‌ها و یک مجموعه قلم فرعی برای متن بدنه است. ویژگی‌های [FontScheme.major](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/major/) و [FontScheme.minor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را نمایش می‌دهند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم لاتین فرعی)
* `+mj-lt` - قلم سرعنوان لاتین (قلم لاتین اصلی)
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم آسیای شرقی فرعی)
* `+mj-ea` - قلم سرعنوان آسیای شرقی (قلم آسیای شرقی اصلی)

مثال زیر یک سرعنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌جای شناسه تم نام قلم صریح دارد، هنگام تغییر طرح‌نامه قلم تم به‌طور خودکار سوئیچ نمی‌شود.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/python-net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کاری رایج وجود دارد که مشکلات متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) به ارائه هدف کلون کنید، سپس اسلاید را با استفاده از [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) و مستر کلون شده کلون کنید. این کار مستر، لایه‌های آن و تم مربوطه را به‌هم پیوسته نگه می‌دارد.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

این روش ترجیحی است زمانی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به‌سادگی کلون کردن محتوا روی یک مستر نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایه فعلی خود باقی بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی کنید. روش‌های [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) و [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

یک بازنویسی سطح لایه برای اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/layoutslidethememanager/) لایه استفاده شوند:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

وقتی تعداد زیادی لایه و اسلاید باید یک طراحی پایه مشترک داشته باشند، از تم سطح مستر یا ارائه استفاده کنید؛ برای یک خانواده لایه که نیاز به استایل متفاوت دارد، بازنویسی لایه؛ و برای استثنای واقعی فقط بازنویسی اسلاید. بازنویسی‌های بیش از حد سطح اسلاید، تغییرات تم کلی بعدی را پیش‌بینی‌ناپذیر می‌کند.

## **به‌روزرسانی استایل‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و مراجع استایل دیگر ترکیب کند.

![گالری استایل پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک استایل پس‌زمینه، مجموعه ذخیره‌شده و ویژگی [Background.style_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/style_index/) فعلی را بررسی کنید. `style_index` برای عدم وجود پرکننده تم مقدار `0` دارد؛ مقادیر مثبت به مراجع استایل پس‌زمینه تم اشاره می‌کنند. این متفاوت از اندیس‌گذاری مستقیم یک مجموعه پایتون است که در آن `[0]` به اولین آیتم ذخیره‌شده اشاره دارد. فرض نکنید هر ارائه همان تعداد استایل پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌دهد، یک مرجع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده شده و به هر بازنویسی پس‌زمینه در لایه یا سطح اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خود را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تحت‌تأثیر قرار ندهد. برای دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`style_index` را به‌عنوان یک اندیس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی سخت‑کد شده یک شماره استایل از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را داشته باشد خودداری کنید؛ تعاریف استایل تم به‌صورت مخصوص به هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌نامه قالب تم شامل مجموعه‌های جداگانهٔ [FormatScheme.fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/line_styles/) و [FormatScheme.effect_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/effect_styles/) است. تم‌های معمولی آفیس اغلب سه ورودی استایل اصلی دارند که از نظر بصری به ترتیب به سطوح ظریف، متوسط و شدید متناظر هستند، اما کد باید هر مجموعه را به‌جای فرض تعداد ثابت بررسی کند.

![افکت‌های تم ظریف، متوسط و شدید اعمال‌شده بر یک شکل مشابه](presentation-design_10.png)

زمانی که این مجموعه‌ها را در پایتون دسترسی می‌یابید، اندیس مجموعه صفر‑پایه است: `[0]` اولین استایل ذخیره‌شده و `[2]` سومین استایل است. اندیس‌های اشاره‌گر استایل یک شکل مفهوم جداگانه‌ای است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک استایل تم بر اشکالی که به آن استایل ارجاع می‌دهند اثر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های استایل لازم موجود هستند، اولین استایل خط را تغییر می‌دهد، سومین استایل پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین استایل افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

برای اشکالی که به این سلول‌ها ارجاع می‌دهند، اولین استایل خط تم به قرمز، سومین استایل پرکننده تم به سبز جنگلی صلب و سومین استایل افکت یک سایه خارجی با فاصله ۱۰ پوینت می‌گیرد. نتیجه بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام سلول استایل ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند یا نه.

![استایل‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

شیءهای خام تم چیزی را نشان می‌دهند که در سطح خاصی تعریف شده است. مقادیر مؤثر چیزی را نشان می‌دهند که یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعاً استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) را فراخوانی کنید. برای یک پس‌زمینه، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) و برای یک پرکننده، از [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل را از یک اسلاید می‌خواند:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

از داده‌های مؤثر برای تشخیص، اعتبارسنجی و مقایسه رندر استفاده کنید. اگر فقط به [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) نگاه کنید، ممکن است بازنویسی‌های مستر، لایه، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهند از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شده آن را مقداردهی کنید. تغییر فقط به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر همچنان تم‌های موجود خود را وراثت می‌گیرند.

**امن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابجایی اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با همان مستر با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) و [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) کلون کنید. این کار مستر، لایه‌ها و تم را به‌هم متصل نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر پس از وراثت و بازنویسی‌ها را ببینم؟**

برای یک اسلاید یا تم لایه از [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) استفاده کنید و برای اشیاء قالب مانند [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) و [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) از متدهای داده مؤثر مربوطه استفاده کنید. این APIها مقادیر حل‑شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.