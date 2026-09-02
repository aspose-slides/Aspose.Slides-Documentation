---
title: مدیریت تم‌های ارائه پاورپوینت در پایتون
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/python-net/presentation-theme/
keywords:
- تم پاورپوینت
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
- سبک تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت تم‌های ارائه در Aspose.Slides برای پایتون از طریق .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به جای این‌که هر ویژگی بصری را به‌صورت مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را یک‌باره به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/masterthememanager/override_theme/) بازنویسی کند، یک لایه می‌تواند تم ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) بازنویسی کند، و یک اسلاید فردی می‌تواند همین کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه و بازنویسی اسلاید.

![اجزاء تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بررسی تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/) ویژگی‌های [color_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/font_scheme/) و [format_scheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/mastertheme/format_scheme/) تم را در اختیار می‌گذارد. بررسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی مفید است که ارائه‌ای از منبع خارجی آمده باشد زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متغیر باشد.

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و در زمانی که بازنویسی‌های لایه یا اسلاید ممکن است موجود باشد، از جریان کاری تم مؤثر نشان داده شده در ادامه این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارۀ [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی مربوطه در [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال زیر یک شکل ایجاد می‌کند که از `ACCENT4` استفاده می‌کند، رنگ `accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `ACCENT4` پیوند دارد، پس از تغییر تم رنگ قابل مشاهده آن به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `accent4` دیگر بر آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، انواع روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق شمارۀ [ColorTransformOperation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/colortransformoperation/) در دسترس قرار می‌دهد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**۱** – رنگ‌های اصلی تم.

**۲** – انواع روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `ACCENT4` ایجاد می‌کند، به پنج مورد از آن‌ها تبدیل روشنائی اعمال می‌کند و نتیجه را ذخیره می‌سازد:

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

این انواع همچنان بر پایه رنگ تم باقی می‌مانند. اگر `accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

شمارۀ [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) از `TEXT1`، `BACKGROUND1`، `TEXT2` و `BACKGROUND2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) همان اسلات‌های تم را به شکل `dark1`، `light1`، `dark2` و `light2` نمایان می‌کند. نگاشت ثابت است:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح‌نامه قلم تم شامل مجموعهٔ قلم اصلی برای عناوین و مجموعهٔ قلم فرعی برای متن بادی است. ویژگی‌های [FontScheme.major](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/major/) و [FontScheme.minor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را افشا می‌کنند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn‑lt` – قلم بادی لاتین (Minor Latin Font)
* `+mj‑lt` – قلم عنوان لاتین (Major Latin Font)
* `+mn‑ea` – قلم بادی شرق آسیایی (Minor East Asian Font)
* `+mj‑ea` – قلم عنوان شرق آسیایی (Major East Asian Font)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بادی که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بادی از قلم فرعی. متنی که به‌صورت صریح نام قلم دارد به‌جای شناسه تم، هنگام تغییر طرح‌نامه قلم تم به‌طور خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند همچنین نگاشت‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجستانی و ثان داشته باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script‑Specific Theme Fonts](/slides/fa/python-net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/python-net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

جریان‌های کاری زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به مستر**

از [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) زمانی که یک فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند بازطراحی کنید، استفاده کنید. مستر را از مجموعهٔ [Presentation.masters](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/masters/) که پیاده‌ساز [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) است، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

متد عملیات زیر را انجام می‌دهد:

1. یک مستر اسلاید جدید بر پایه مستر انتخاب‌شده می‌سازد.
2. تم خارجی را بر روی مستر جدید اعمال می‌کند.
3. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند اختصاص می‌دهد.
4. مستر جدید ساخته‌شده [IMasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/) را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌سازد:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند [PptxException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxexception/) یا یکی از زیرکلاس‌های مربوط به فرمت را ایجاد کند. مسیرهای ورودی توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به سیستم فایل را مدیریت کنید و تنها پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره نمایید.

تنها اسلایدهایی که به مستر انتخاب‌شده وابسته بودند مجدداً تخصیص می‌یابند. اسلایدهایی که به مسترهای دیگر مرتبط هستند مستر و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر قالب‌بندی‌های صریح که به‌صورت مستقیم اختصاص یافته‌اند ممکن است بدون تغییر باقی بمانند. بازنویسی‌های سطح لایه و اسلاید نیز می‌توانند بر مقادیر ارث‌بری‌شده از مستر جدید ارجحیت داشته باشند.

تم ممکن است به قلم‌هایی ارجاع دهد که در محیط زمان اجرا موجود نیستند. برای رندرینگ و خروجی سازگار، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/python-net/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/python-net/font-substitution/) را پیکربندی نمایید.

این یک جریان کاری مستقیم سطح مستر است: متد مسیر فایلی با پسوند `.thmx` را می‌پذیرد و نیازی به ایجاد بازنویسی‌های تم سطح اسلاید یا لایه به‌صورت دستی نیست.

### **اعمال تم‌های مختلف خارجی در یک ارائه چند مستر**

زمانی که مستر مربوطه از پیش شناخته‌شده نیست، آن را از یک اسلاید نماینده از طریق [Slide.layout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/layout_slide/) و [LayoutSlide.master_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/master_slide/) به‌دست آورید. پیش از اعمال هر تمی، مراجع مسترهای اصلی را ذخیره کنید زیرا هر فراخوانی یک مستر جدید در ارائه می‌سازد.

مثال زیر از اسلایدهای دو بخش برای پیدا کردن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را برای هر گروه اعمال می‌کند:

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

فراخوانی اول فقط اسلایدهایی را که به `first_group_master` وابسته بودند تحت تأثیر قرار می‌دهد و فراخوانی دوم فقط اسلایدهایی را که به `second_group_master` وابسته بودند تحت تأثیر می‌گذارد. اسلایدهایی که به هر مستر دیگر تعلق دارند بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائهٔ دیگر منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) به ارائه هدف اضافه کنید، سپس اسلاید را با [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) و مستر کلون‌شده کپی کنید. این کار مستر، لایه‌های آن و تم مرتبط را به‌هم‌راستا می‌گیرد.

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

این جریان کاری ترجیحی است زمانی که اسلاید منبع باید همان ظاهر را در مقصد داشته باشد. تنها کلون‌کردن محتوا روی مستری نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و لایهٔ فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. روش‌های [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) و [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

یک بازنویسی سطح لایه بر اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/layoutslidethememanager/) لایه مورد استفاده قرار گیرند:

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

از تم مستر یا سطح ارائه زمانی استفاده کنید که بسیاری از لایه‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند؛ از بازنویسی لایه وقتی یک خانواده لایه به سبک متفاوتی نیاز دارد؛ و از بازنویسی اسلاید فقط برای استثنای واقعی. بازنویسی‌های بیش از حد سطح اسلاید تغییرات سراسری تم را در آینده پیش‌بینی‌پذیر نمی‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینهٔ تم**

پرکننده‌های پس‌زمینهٔ تم در [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در UI خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌صورت فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و ارجاع‌های سبک دیگر ترکیب کند.

![گالری سبک‌های پس‌زمینهٔ PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.style_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/style_index/) را بررسی کنید. `style_index` از `0` برای عدم وجود پرکنندهٔ تم استفاده می‌کند؛ مقادیر مثبت ارجاع به سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعهٔ پایتون است، جایی که `[0]` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکنندهٔ پس‌زمینهٔ موجود را گزارش می‌دهد، یک ارجاع پس‌زمینهٔ تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده می‌شود و به هر بازنویسی پس‌زمینه در سطح لایه یا اسلاید بستگی دارد. اگر یک اسلاید پس‌زمینهٔ خود را داشته باشد، تنها تغییر پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. زمانی که نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری دارید، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`style_index` را به‌عنوان یک ایندکس صفر‑محور مجموعه در نظر نگیرید. همچنین از کدنویسی عدد سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعریف‌های سبک تم به‌صورت خاص برای هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به بخش [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌نامه فرمت تم شامل مجموعه‌های جداگانهٔ [FormatScheme.fill_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/line_styles/) و [FormatScheme.effect_styles](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/effect_styles/) است. تم‌های معمولی دفتر کار اغلب شامل سه ورودی اصلی سبک هستند که به‌صورت بصری به فرمت‌های ملایم، متوسط و قوی متناظر می‌شوند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت را فرض کند.

![افکت‌های ملایم، متوسط و شدید تم که بر روی همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگام دسترسی به این مجموعه‌ها در پایتون، ایندکس مجموعه صفر‑محور است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین است. ایندکس‌های مرجع سبک یک شکل مفهوم جداگانه‌ای است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک مورد نیاز را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که این اسلات‌ها را ارجاع می‌دهند، اولین سبک خط تم به قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی جامد تغییر می‌یابد و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ ۱۰ نقطه به‌دست می‌آورد. نتیجهٔ بصری دقیق هنوز به این‌که هر شکل چه اسلاتی را ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا خیر، وابسته است.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

شیء تم خام به شما می‌گوید که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) را فراخوانی کنید. برای پس‌زمینه، از [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) استفاده کنید و برای پرکننده، از [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و پرکنندهٔ اولین شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) را بررسی کنید، ممکن است یک بازنویسی در مستر، لایه، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا اعمال تم خارجی بر همهٔ اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. متد [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) تنها اسلایدهایی را که به مستر انتخاب‌شده وابستگی دارند، بازتخصیص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر فقط در همان اسلاید محلی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**سالم‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابجایی یک اسلاید و حفظ ظاهر منبع، مستر منبع را با استفاده از [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/add_clone/) به مقصد اضافه کنید و سپس اسلاید را با همان مستر کلون‌شده با استفاده از [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) کپی کنید. این کار مستر، لایه‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) برای تم اسلاید یا لایه استفاده کنید و برای اشیای فرمت مانند [Background.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/background/get_effective/) و [FillFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/get_effective/) متدهای دادهٔ مؤثر مربوطه را فراخوانی کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.