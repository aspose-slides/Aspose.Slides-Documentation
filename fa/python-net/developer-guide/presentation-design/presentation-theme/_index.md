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
- تم خارجی
- THMX
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
description: "تم‌های اصلی ارائه در Aspose.Slides برای Python از طریق .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیائی که از تم آگاه هستند به‌جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعریف‌های اشتراکی ارجاع می‌دهند، بنابراین یک تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) بازنویسی کند، یک طرح‌بندی می‌تواند تم به‌ارث‌برده‌شده خود را از طریق [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) بازنویسی کند، و یک اسلاید تک می‌تواند همان کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کار با تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی استایل‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) ویژگی‌های [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) و [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) تم را باز می‌کند. بررسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه وقتی ارائه‌ای از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های استایل می‌تواند متفاوت باشد.

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و هنگام وجود بازنویسی‌های طرح‌بندی یا اسلاید، از جریان کاری تم مؤثر نشان داده شده در ادامه این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه به تم می‌توانند به یک رنگ منطقی از شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند با مقدار جدید حل می‌شوند. اشیایی که از رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌خواهند.

مثال انتهای به‌انتهایی زیر یک شکل ایجاد می‌کند که از `ACCENT4` استفاده می‌کند، رنگ `accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `ACCENT4` مرتبط است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `accent4` دیگر آن پرکننده را تحت تأثیر قرار نمی‌دهند.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، گونه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش‌گر [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

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

این گونه‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به فضاهای `ColorScheme`**

شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) از `TEXT1`، `BACKGROUND1`، `TEXT2` و `BACKGROUND2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) همان فضاهای تم را به صورت `dark1`، `light1`، `dark2` و `light2` نشان می‌دهد. این نگاشت ثابت است:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

این‌ها نام‌های جایگزین برای همان فضاهای تم هستند؛ آنها مقادیری نیستند که به‌صورت پویا از یک شکل به شکل دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح‌نامه قلم تم شامل یک مجموعه قلم اصلی برای سرفصل‌ها و یک مجموعه قلم فرعی برای متن بدنه است. ویژگی‌های [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) و [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را نشان می‌دهند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم سرفصل لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم سرفصل آسیای شرقی (Major East Asian Font)
* `+mn-cs` - قلم بدنه اسکریپت پیچیده (Minor Complex Script Font)
* `+mj-cs` - قلم سرفصل اسکریپت پیچیده (Major Complex Script Font)

مثال زیر یک سرفصل ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

سرفصل از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌جای شناسه تم، نام قلم صریح داشته باشد، هنگام تغییر طرح‌نامه قلم تم به‌طور خودکار تغییر نمی‌کند.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری خاص، مانند سیریلیک، عربی، ژاپنی، گرجی و ثان، باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script-Specific Theme Fonts](/slides/fa/python-net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/python-net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

### **حل ارجاع‌های قلم تم**

هنگام بررسی متن، ممکن است [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) شامل یک ارجاع تم مانند `+mn-lt` به‌جای نام خانوادگی قلم باشد. با فراخوانی [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) همراه با شیء مناسب [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) می‌توانید آن ارجاع را حل کنید. پیشوندهای `+mj` و `+mn` مجموعه‌های قلم اصلی و فرعی را انتخاب می‌کنند؛ پسوندهای `-lt`، `-ea` و `-cs` به ترتیب قلم‌های لاتین، آسیای شرقی و اسکریپت پیچیده را انتخاب می‌کنند.

تم مؤثر را از طریق [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) برای شیئی که تم آن به متن بررسی‌شده اعمال می‌شود، دریافت کنید. برای متن معمولی در یک اسلاید، از `slide.create_theme_effective` استفاده کنید تا زمینه شامل تم به‌ارث‌برده‌شده اسلاید و بازنویسی‌های محلی باشد. هنگام بررسی یک طرح‌بندی یا مستر، از تم مؤثر خود آن استفاده کنید. فرض نکنید که تم اولین مستر بر تمام اسلایدها اعمال می‌شود.

مثال زیر بخشی از متن را که صریحاً به قلم لاتین فرعی ارجاع می‌دهد ایجاد می‌کند. یک طرح‌نامه قلم اسلاید را از طریق [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) مقداردهی اولیه می‌کند و خانواده‌های لاتین اصلی و فرعی را به ترتیب به `Arial` و `Calibri` تنظیم می‌کند تا نتیجه بدون نیاز به فایل ورودی تکرارپذیر باشد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

خروجی `+mn-lt -> Calibri` به‌همراه `Verdana -> Verdana` است. ارجاع ذخیره‌شده بدون تغییر می‌ماند، در حالی که نام خانوادگی صریح به‌همان صورت برگردانده می‌شود. اگر بخش از `+mj-lt` استفاده می‌کرد، در این تم به `Arial` حل می‌شد.

حل یک ارجاع تم، خانواده قلم مشخص‌شده توسط تم را شناسایی می‌کند. این کار در دسترس بودن قلم یا فایل قلم نهایی پس از جایگزینی یا fallback گلیف را بررسی نمی‌کند. برای این مراحل جداگانه، به [Font Selection Sequence](/slides/fa/python-net/font-selection-sequence/) و [Font Substitution](/slides/fa/python-net/font-substitution/) مراجعه کنید.

## **کپی یا اعمال یک تم**

جریان‌های کاری زیر مشکلات مختلف مربوط به تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) وقتی که یک فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند را دوباره‌استایل کنید، استفاده کنید. مستر موردنظر را از مجموعه [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (یعنی [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) انتخاب کنید و مسیر فایل تم را به این متد پاس دهید.

این متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.
1. تم خارجی را به مستر جدید اعمال می‌کند.
1. مستر جدید را به همه اسلایدهایی که پیش‌تر به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.
1. یک شیء [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) تازه‌ساخته را برمی‌گرداند.

مثال زیر تم خارجی را به اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند منجر به بروز [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) یا یکی از زیرکلاس‌های مربوط به قالب شود. مسیرهای ارائه‌شده توسط کاربران را اعتبار سنجی کنید، خطاهای دسترسی به فایل‌سیستم را مدیریت کنید و ارائه را فقط پس از اعمال موفق تم ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند، بازتخصیص می‌یابند. اسلایدهای مرتبط با سایر مسترها تم و مسترهای فعلی خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه به تم نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و قالب‌بندی‌های صریح ممکن است بدون تغییر بمانند. بازنویسی‌های سطح طرح‌بندی و اسلاید نیز می‌توانند بر مقادیر به‌ارث‌برده از مستر جدید اولویت داشته باشند.

تم ممکن است به قلم‌هایی ارجاع دهد که در محیط اجرا موجود نیستند. برای رندرینگ و خروجی‌گیری سازگار، قلم‌های موردنیاز را نصب کنید، از طریق [منابع قلم سفارشی](/slides/fa/python-net/custom-font/) فراهم کنید یا [جایگزینی قلم](/slides/fa/python-net/font-substitution/) را پیکربندی کنید.

این یک جریان کاری مستقیم در سطح مستر است: متد یک مسیر فایل `.thmx` می‌گیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا طرح‌بندی نیست.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چندمستری**

وقتی مستری که باید مورد استفاده قرار گیرد از پیش شناخته شده نیست، آن را از یک اسلاید نماینده از طریق [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) و [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) به‌دست آورید. قبل از اعمال هر تمی، مراجع مسترهای اصلی را ذخیره کنید چون هر فراخوانی یک مستر دیگر در ارائه می‌سازد.

مثال زیر از اسلایدهای دو بخش برای پیدا کردن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را به هر گروه اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

فراخوانی اول فقط بر اسلایدهایی که به `first_group_master` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `second_group_master` وابسته بودند. اسلایدهایی که به هر مستر دیگری تعلق دارند، دوباره‌استایل نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه دیگری منتقل کنید و طرح اولیه آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) به ارائه هدف کلون کنید، سپس اسلاید را با [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) و مستر کلون‌شده کلون کنید. این کار مستر، طرح‌بندی‌های آن و تم مرتبط را به‌صورت یک‌جا منتقل می‌کند.

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

این جریان کاری ترجیح داده می‌شود هنگامی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به‌سادگی کلون کردن محتوا روی مستری نامرتبط در مقصد می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و طرح‌بندی فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) و [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم به‌ارث‌برده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر به‌ارث‌برده، [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

یک بازنویسی سطح طرح‌بندی بر اسلایدهایی که از آن طرح‌بندی استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خودش را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) طرح‌بندی استفاده شوند:

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

زمانی که بسیاری از طرح‌بندی‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ زمانی که یک خانواده طرح‌بندی به استایل متفاوتی نیاز دارد، از بازنویسی طرح‌بندی استفاده کنید؛ و تنها برای استثنای واقعی از بازنویسی اسلاید استفاده کنید. بازنویسی‌های اسلایدی بیش از حد، اعمال تغییرات تم سراسری بعدی را دشوار می‌کند.

## **به‌روزرسانی استایل‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در UI خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که در این مجموعه فیزیکی ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و مراجع استایل دیگر ترکیب کند.

![گالری استایل پس‌زمینه PowerPoint برای تم یک ارائه](presentation-design_8.png)

قبل از استفاده از یک استایل پس‌زمینه، مجموعه ذخیره‌شده و [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) فعلی را بررسی کنید. `style_index` از `0` برای عدم وجود پرکننده تم استفاده می‌کند؛ مقادیر مثبت مراجع استایل پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعه پایتون است، که در آن `[0]` به اولین مورد ذخیره‌شده اشاره دارد. فرض نکنید هر ارائه دارای همان تعداد استایل پرکننده پس‌زمینه باشد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تم مرجع شده توسط مستر و هر بازنویسی پس‌زمینه در سطح طرح‌بندی یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خودش را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلید را تغییر نداده باشد. برای دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`style_index` را به‌عنوان یک ایندکس صفرپایه مجموعه در نظر نگیرید. همچنین از کدنویسی عدد استایل از یک فایل و فرض داشتن همان ظاهر در فایل دیگر خودداری کنید؛ تعریف‌های استایل تم برای هر ارائه متفاوت است.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌نامه قالب تم شامل مجموعه‌های جداگانه‌ی [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) و [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) است. تم‌های معمول در Office اغلب سه ورودی استایل اصلی دارند که به‌صورت بصری به فرمت‌های Subtle، Moderate و Intense مطابقت دارند، اما کد باید هر مجموعه را بررسی کند نه اینکه تعداد ثابت فرض شود.

![افکت‌های تم Subtle، Moderate و Intense که بر روی همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در پایتون دسترسی می‌کنید، ایندکس مجموعه صفرپایه است: `[0]` اولین استایل ذخیره‌شده و `[2]` سومین استایل است. ایندکس‌های ارجاع استایل یک شکل مفهومی جداگانه است که توسط [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) نمایش داده می‌شود. تغییر یک استایل تم بر شکل‌هایی که به آن استایل ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های استایل موردنیاز وجود دارند، اولین استایل خط را تغییر می‌دهد، سومین استایل پرکننده را تغییر می‌دهد، سایه‌ی بیرونی را در سومین استایل افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این فضاها ارجاع می‌دهند، اولین استایل خط تم به‌سرخ تغییر می‌یابد، سومین استایل پرکننده تم به سبز جنگلی ثابت تبدیل می‌شود و سومین استایل افکت یک سایه بیرونی با فاصله 10 پوینت دریافت می‌کند. نتیجه بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام فضاها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا خیر.

![استایل‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **انتخاب استایل‌های پرکننده و خط تم برای یک شکل**

یک شکل می‌تواند پرکننده و حاشیهٔ خود را به‌صورت جداگانه از طریق [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) و [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) انتخاب کند. برای هر دو ویژگی، ایندکس `1` اولین ورودی در مجموعهٔ مربوطهٔ تم (`fill_styles[0]` یا `line_styles[0]`) را انتخاب می‌کند و ایندکس `2` دومین ورودی را انتخاب می‌کند.

مثال زیر دو پرکننده (طلایی و آبی آسمانی) و دو حاشیه (آبی تیره 6 pt و قرمز تیره 12 pt) را در تم پیش‌فرض یک ارائهٔ جدید تعریف می‌کند. اسلاید را در سه مرحله ذخیره می‌کند تا بتوانید نتایج را در PowerPoint مقایسه کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| استایل‌های اولیه | تغییر حاشیهٔ راست | ویرایش اولین پرکنندهٔ تم |
|:---:|:---:|:---:|
| ![مستطیل‌های طلایی و آبی آسمانی با حاشیه‌های نازک آبی تیره](theme-style-initial.png) | ![مستطیل آبی آسمانی اکنون حاشیهٔ ضخیم قرمز تیره دارد](theme-style-line-changed.png) | ![مستطیل چپ اکنون سبز شده و هر دو حاشیه تغییر نکرده‌اند](theme-style-fill-changed.png) |

انتخاب یک استایل خط متفاوت فقط حاشیهٔ مستطیل راست را تغییر می‌دهد. ویرایش اولین پرکنندهٔ تم تمام شکل‌هایی را که از آن استفاده می‌کنند به‌روز می‌کند. در اینجا فقط مستطیل چپ سبز می‌شود.

در یک شکل موجود، یک رنگ پرکننده محلی، رنگ خط یا عرض خط می‌تواند آن بخش از استایل تم را بازنویسی کند. اگر تغییر یک ایندکس استایل تأثیری نداشته باشد، قالب‌بندی مستقیم شکل را بررسی کنید ([direct formatting](/slides/fa/python-net/shape-formatting/)).

## **تشخیص اینکه آیا یک پرکنندهٔ ثابت مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند مستقیماً روی یک شیء ذخیره شود یا از یک پاراگراف، طرح‌بندی، مستر، استایل تم یا سطح دیگری از قالب‌بندی به‌ارث‌برده شود. برای حل این سلسله‌مراتب به [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) مراجعه کنید تا یک شیء [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) غیرقابل تغییر به دست آید. ابتدا [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/) را بررسی کنید. فقط وقتی مقدار آن `FillType.SOLID` باشد، باید ویژگی‌های پرکنندهٔ ثابت را بخوانید.

برای یک پرکنندهٔ ثابت، [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) مقدار نهایی RGB پس از وراثت، جست‌وجوی تم و اعمال تبدیلات رنگی را بر می‌گرداند. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) اسلات منطقی [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) متناظر را باز می‌گرداند، مانند `TEXT1` یا `ACCENT6`. مقدار `SchemeColor.NOT_DEFINED` به این معنی است که پرکنندهٔ ثابت مؤثر بر پایهٔ یک رنگ اسکیم نیست. در یک جریان کاری که پرکننده‌ها یا رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکنندهٔ مستقیم RGB را شناسایی می‌کند.

از مقدار محلی [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) به‌تنهایی برای دسته‌بندی یک پرکننده استفاده نکنید. به‌عنوان مثال، یک بخش متن ممکن است اسکیم‌رنگ محلی داشته باشد که `NOT_DEFINED` باشد، در حالی که پرکنندهٔ مؤثر آن از تم به ارث می‌برد و به `TEXT1` یا `ACCENT6` حل می‌شود. برعکس، `solid_fill_scheme_color` به شما می‌گوید کدام اسلات منطقی تم رنگ نهایی را تولید کرده، اما نمی‌داند این اسلات از کدام سطح (شیء، پاراگراف، طرح‌بندی، مستر یا دیگر) آمده است.

مثال زیر یک ارائه را بارگذاری می‌کند، هم پرکننده‌های شکل‌ها و هم پرکننده‌های بخش‌های متن را بررسی می‌کند، هر مقدار RGB نهایی و اسکیم‌رنگ مربوطه را چاپ می‌کند و پرکننده‌های ثابت را که تغییرات رنگ تم را پیگیری نمی‌کنند، علامت می‌زند:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

شاخه `NOT_DEFINED` یک فهرست حسابرسی از پرکننده‌های ثابت ارائه می‌دهد که به تغییرات اسلات‌های رنگ تم پاسخ نمی‌دهند. این اشیا را هنگام نیاز به پیروی از یک پالت برند جدید بررسی کنید. مقدار RGB گزارش‌شده هنوز ظاهر فعلی را نشان می‌دهد، در حالی که مقدار اسکیم توضیح می‌دهد آیا این ظاهر به تم متصل است یا خیر.

اشیای مؤثر‑قالب یک تصویر ثابت هستند. پس از تغییر تم ارائه، یک بازنویسی تم یا هر قالب‌بندی به‌ارث‌برده دیگری، دوباره `get_effective` را فراخوانی کنید و یک شیء جدید `IFillFormatEffectiveData` بخوانید قبل از مقایسه یا گزارش رنگ‌ها.

## **خواندن مقادیر تم مؤثر**

اشیای تم خام به شما می‌گویند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، از [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) فراخوانی کنید. برای پس‌زمینه، از [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) استفاده کنید و برای یک پرکننده، از [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه استفاده کنید. اگر فقط [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) را بررسی کنید، ممکن است یک بازنویسی در مستر، طرح‌بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

نه. متد [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته هستند، بازتخصیص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تمهای فعلی خود را حفظ می‌کنند.

**آیا می‌توانم تم را به یک اسلاید منفرد بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر به‌صورت محلی به آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر همچنان تمهای موجود خود را به‌ارث می‌برند.

**امن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگامی که اسلایدی را جابه‌جا می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را با [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) به مقصد کلون کنید و سپس اسلاید را با آن مستر توسط [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) کلون کنید. این کار مستر، طرح‌بندی‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

برای یک اسلاید یا تم طرح‌بندی از [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) استفاده کنید و برای اشیای قالب مانند [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) و [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) متدهای مؤثر‑داده مربوطه را به‌کار ببرید. این API‌ها مقادیر حل‌شده را پس از اعمال وراثت و بازنویسی‌ها باز می‌گردانند.