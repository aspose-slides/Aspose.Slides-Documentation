---
title: مدیریت تم‌های ارائه PowerPoint در Python
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
- پلت رنگ افزایشی
- قلم تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت تم‌های ارائه در Aspose.Slides برای Python از طریق .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **معرفی**

یک تم ارائه یک مجموعه هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای «آگاه از تم» به این تعاریف مشترک ارجاع می‌دهند به‌جای اینکه هر ویژگی بصری را به‌صورت مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند همزمان بسیاری از اشیا را به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) قابل دسترسی است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/masterthememanager/override_theme/) بازنویسی کند، یک لِی‌آوت می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) بازنویسی کند و یک اسلاید منفرد می‌تواند همین کار را انجام دهد. در عمل، تم موثر برای یک اسلاید از طریق این زنجیره وراثتی حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِی‌آوت و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های پایین‌ترین، رایج‌ترین گردش کارهای تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر موثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/) ویژگی‌های [color_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/font_scheme/) و [format_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/format_scheme/) تم را در اختیار می‌گذارد. بررسی این مجموعه‌ها قبل از تغییر آن‌ها به‌ویژه زمانی مفید است که یک ارائه از منبع خارجی می‌آید زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

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

اگر فایلی چند مستر داشته باشد، فرض نکنید که هر اسلاید همان تم موثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و از گردش کار تم مؤثر که در ادامه مقاله نشان داده شده است استفاده کنید وقتی که امکان بازنویسی لِی‌آوت یا اسلاید وجود داشته باشد.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های «آگاه از تم» می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) تم تغییر کند، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید محاسبه می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال سراسری زیر یک شکل ایجاد می‌کند که از `ACCENT4` استفاده می‌کند، رنگ `accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `ACCENT4` مرتبط است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم در شکل جایگزین کنید، تغییرات بعدی `accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پلت رنگ‌های افزایشی**

PowerPoint با اعمال تبدیلات رنگ، گونه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/colortransformoperation/) در اختیار می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پلت رنگ‌های افزایشی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - گونه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `ACCENT4` ایجاد می‌کند، به پنج‌تا از آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این گونه‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به جایگاه‌های `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) از `TEXT1`، `BACKGROUND1`، `TEXT2` و `BACKGROUND2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) همان جایگاه‌های تم را به صورت `dark1`، `light1`، `dark2` و `light2` نمایش می‌دهد. این نگاشت ثابت است:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

این‌ها نام‌های جایگزین برای همان جایگاه‌های تم هستند؛ آنها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای سرفصل‌ها و یک مجموعه قلم فرعی برای متن اصلی است. ویژگی‌های [FontScheme.major](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/major/) و [FontScheme.minor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را در اختیار می‌گذارند.

شناساگرهای قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم سرفصل لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم سرفصل آسیای شرقی (Major East Asian Font)

مثال زیر یک سرفصل که از قلم لاتین بزرگ تم استفاده می‌کند و یک خط بدنه که از قلم لاتین کوچک تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

سرفصل از قلم بزرگ پیروی می‌کند و متن بدنه از قلم کوچک. متنی که به‌صورت صریح نام قلم دارد به‌جای شناسه تم، هنگام تغییر طرح قلم تم به‌صورت خودکار جابجا نمی‌شود.

مجموعه‌های قلم بزرگ و کوچک می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی باشند، مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، بخش [Script-Specific Theme Fonts](/slides/fa/python-net/script-specific-font-mappings/) را ببینید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/python-net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو گردش کار رایج وجود دارد که هر کدام مشکل متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) به ارائه هدف افزودن کنید، سپس اسلاید را با استفاده از [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) و مستر کلون‌شده کپی کنید. این کار مستر، لِی‌آوت‌های آن و تم مرتبط را به‌هم پیوند می‌دهد.

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

این گردش کار زمانی ترجیح داده می‌شود که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به‌سادگی کپی کردن محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌های رانده‌شده توسط تم، قلم‌ها، پس‌زمینه‌ها و افکت‌ها را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لِی‌آوت فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) و [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده شده توسط آن اسلاید را تغییر می‌دهد بدون این که تم وارث شده توسط اسلایدهای دیگر تغییر کند. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لِی‌آوت**

یک بازنویسی سطح لِی‌آوت برای اسلایدهایی که از آن لِی‌آوت استفاده می‌کنند اعمال می‌شود، مگر این که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/layoutslidethememanager/) لِی‌آوت استفاده شوند:

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

زمانی که بسیاری از لِی‌آوت‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ وقتی یک خانواده لِی‌آوت نیاز به استایل متفاوت دارد، بازنویسی لِی‌آوت را به‌کار ببرید؛ و بازنویسی اسلاید فقط برای استثناهای واقعی کافی است. بازنویسی‌های زیاد در سطح اسلاید باعث می‌شود پیش‌بینی تغییرات تم سراسری دشوارتر شود.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نمایش دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاعات سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.style_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/style_index/) را بررسی کنید. `style_index` از `0` برای عدم وجود پرکننده تم استفاده می‌کند؛ مقادیر مثبت ارجاع به سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعه در پایتون است، جایی که `[0]` اولین آیتم ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح لِی‌آوت یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خاص خود را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تحت تأثیر قرار ندهد. هنگام نیاز به دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`style_index` را به‌عنوان یک ایندکس صفر‑پایه در مجموعه اشتباه نگیرید. همچنین از کدنویسی مستقیم یک عدد سبک از یک فایل و فرض اینکه در فایل دیگر هم‌ظاهر باشد خودداری کنید؛ تعریف‌های سبک تم به‌صورت خاص برای هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانه [FormatScheme.fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/line_styles/) و [FormatScheme.effect_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/effect_styles/) است. تم‌های رایج Office اغلب سه ورودی اصلی سبک دارند که به‌صورت بصری با قالب‌بندی‌های ظریف، متوسط و شدید متناظر هستند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت فرض کند.

![افکت‌های تم ظریف، متوسط و شدید که بر روی همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در پایتون دسترسی می‌گیرید، ایندکس مجموعه صفر‑پایه است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین. ایندکس‌های ارجاع سبک یک شکل مفهومی جداگانه هستند که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌کنند تأثیر می‌گذارد؛ شکل‌های دارای قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود داشته باشند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این جایگاه‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی ثابت و سومین سبک افکت یک سایه خارجی با فاصله ۱۰ پوینت می‌گیرد. نتیجه بصری دقیق هنوز به این‌که هر شکل به کدام جایگاه‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند بستگی دارد.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر آنچه یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی استفاده می‌کند را نشان می‌دهند. برای یک اسلاید، متد [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) را فراخوانی کنید. برای پس‌زمینه، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) استفاده کنید و برای پرکننده، از [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) استفاده کنید.

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

از داده‌های مؤثر برای عیب‌یابی رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) را بررسی کنید، ممکن است بازنویسی‌های مستر، لِی‌آوت، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهند از دست بدهید.

## **سوالات متداول**

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون این‌که مستر را تغییر دهم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی کنید. تغییر فقط به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ سایر اسلایدها تم‌های موجود خود را وراثت می‌کنند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به دیگری چیست؟**

هنگام جابه‌جایی یک اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با استفاده از همان مستر کلون‌شده با متدهای [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) و [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) کپی کنید. این کار مستر، لِی‌آوت‌ها و تم را با هم حفظ می‌کند.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها مشاهده کنم؟**

از [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) برای یک تم اسلاید یا لِی‌آوت و روش‌های داده‑مؤثر مربوطه برای اشیاء قالب‌بندی مانند [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) و [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) استفاده کنید. این APIها مقادیر حل شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.