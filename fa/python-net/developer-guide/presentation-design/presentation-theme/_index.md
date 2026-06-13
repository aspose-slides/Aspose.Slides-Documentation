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
- رنگ تم
- پالت اضافی
- فونت تم
- استایل تم
- افکت تم
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "تم‌های اصلی ارائه را در Aspose.Slides برای پایتون از طریق .NET مدیریت کنید تا فایل‌های پاورپوینت را با برندینگ یکسان ایجاد، سفارشی‌سازی و تبدیل کنید."
---
## **مقدمه**

یک تم پرزنتیشن ویژگی‌های عناصر طراحی خود را تعریف می‌کند. زمانی که تمی را انتخاب می‌کنید، مجموعه‌ای هماهنگ از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در PowerPoint، یک تم شامل رنگ‌ها، [فونت‌ها](/slides/fa/python-net/powerpoint-fonts/)، [استایل‌های پس‌زمینه](/slides/fa/python-net/presentation-background/)، و افکت‌ها است.

![اجزای تم](theme-constituents.png)

## **تغییر رنگ تم**

یک تم PowerPoint برای عناصر مختلف اسلاید مجموعه‌ای خاص از رنگ‌ها را استفاده می‌کند. اگر پیش‌فرض‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید تم، آن‌ها را تغییر دهید. برای انتخاب رنگ تم جدید، Aspose.Slides مقادیر را در شمارنده [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) ارائه می‌دهد.

این کد Python نشان می‌دهد چگونه رنگ لهیزه تم را تغییر دهیم:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

می‌توانید مقدار مؤثر رنگ حاصل را به صورت زیر به دست آورید:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# خروجی نمونه:
#
# ff8064a2 (رنگ [A=255, R=128, G=100, B=162])
```

برای نشان دادن بیشتر تغییر رنگ، عنصر دیگری می‌سازیم، رنگ لهیزه را از مرحله ابتدایی به آن اختصاص می‌دهیم و سپس رنگ تم را به‌روز می‌کنیم.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

رنگ جدید به‌طور خودکار بر هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از پالت اضافی**

هنگامی که تبدیلات لومینانس را بر رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌های پالت اضافی (2) تولید می‌شوند. سپس می‌توانید آن رنگ‌های تم را تنظیم و بازیابی کنید.

![رنگ‌های پالت اضافی](additional-palette-colors.png)

**1** — رنگ‌های اصلی تم

**2** — رنگ‌های پالت اضافی

این کد Python نشان می‌دهد چگونه رنگ‌های پالت اضافی از رنگ اصلی تم استخراج شده و سپس در اشکال استفاده می‌شوند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # آکسنت 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # آکسنت 4، روشن‌تر 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # آکسنت 4، روشن‌تر 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # آکسنت 4، روشن‌تر 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # آکسنت 4، تیره‌تر 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # آکسنت 4، تیره‌تر 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `ColorScheme`**

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که مقادیر رنگ تم زیر را شامل می‌شود:

`BACKGROUND1`، `BACKGROUND2`، `TEXT1` و `TEXT2`.

با این حال، `Presentation.master_theme.color_scheme` یک [ColorScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/colorscheme/) برمی‌گرداند که رنگ‌های مربوطه را به شکل زیر افشا می‌کند:

`dark1`، `dark2`، `light1` و `light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هیچ تبدیل پویا بین `TEXT`/`BACKGROUND` و `dark`/`light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای یکسان بودن رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به‌صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای این‌که بتوانید فونت‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناسه‌های خاص (مشابه موارد PowerPoint) استفاده می‌کند:

- **+mn-lt** — فونت بدنه لاتین (Minor Latin Font)
- **+mj-lt** — فونت سرعنوان لاتین (Major Latin Font)
- **+mn-ea** — فونت بدنه آسیای شرقی (Minor East Asian Font)
- **+mj-ea** — فونت سرعنوان آسیای شرقی (Major East Asian Font)

این کد Python نشان می‌دهد چگونه فونت لاتین را به یک عنصر تم اختصاص دهیم:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

این مثال Python نشان می‌دهد چگونه فونت تم پرزنتیشن را تغییر دهیم:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

تمام جعبه‌های متن به فونت جدید به‌روز می‌شوند.

{{% alert color="primary" title="TIP" %}}
برای اطلاعات بیشتر، به [فونت‌های اصلی PowerPoint با Python](/slides/fa/python-net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **تغییر استایل پس‌زمینه تم**

به‌صورت پیش‌فرض، PowerPoint ۱۲ پس‌زمینه از پیش تعریف‌شده را ارائه می‌دهد، اما یک ارائه معمولی فقط ۳ مورد از آن‌ها را ذخیره می‌کند.

![todo:image_alt_text](presentation-design_8.png)

به‌عنوان مثال، پس از ذخیره یک ارائه در PowerPoint، می‌توانید کد Python زیر را اجرا کنید تا تعداد پس‌زمینه‌های از پیش تعریف‌شده موجود را تعیین کنید:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
با استفاده از ویژگی `background_fill_styles` از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/) می‌توانید استایل‌های پس‌زمینه را در یک تم PowerPoint اضافه یا دسترسی پیدا کنید.
{{% /alert %}}

این مثال Python نشان می‌دهد چگونه پس‌زمینه ارائه را تنظیم کنیم:

```python
presentation.masters[0].background.style_index = 2  # 0 نشان می‌دهد پر نیست؛ اندیس‌گذاری از 1 شروع می‌شود.
```

{{% alert color="primary" title="TIP" %}}
برای اطلاعات بیشتر، به [مدیریت پس‌زمینه‌های ارائه با Python](/slides/fa/python-net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **تغییر افکت‌های تم**

یک تم PowerPoint معمولاً شامل سه مقدار در هر آرایه استایل است. این آرایه‌ها به سه سطح افکت ترکیب می‌شوند: ظریف، متوسط و شدید. برای مثال، نتیجه اعمال این افکت‌ها بر یک شکل خاص به این شکل است:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از سه ویژگی `FillStyles`، `LineStyles` و `EffectStyles` از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/formatscheme/) می‌توانید عناصر تم را (حتی بیشتر از PowerPoint) به‌صورت انعطاف‌پذیر تغییر دهید.

این کد Python نشان می‌دهد چگونه یک افکت تم را با تغییر بخش‌هایی از آن عناصر تغییر دهیم:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

تغییرات حاصل شامل به‌روزرسانی رنگ پر، نوع پر، افکت سایه و سایر ویژگی‌ها است:

![todo:image_alt_text](presentation-design_11.png)

## **سوالات متداول**

**آیا می‌توانم یک تم را فقط برای یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. Aspose.Slides از تغییر تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید تم محلی را فقط بر آن اسلاید اعمال کنید در حالی که تم مستر دست‌نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/slidethememanager/)).

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به دیگری چیست؟**

[کلون اسلایدها](/slides/fa/python-net/clone-slides/) همراه با مسترشان را به ارائه هدف منتقل کنید. این کار مستر، طرح‌بندی‌ها و تم مربوطه را حفظ می‌کند تا ظاهر یکسان بماند.

**چگونه می‌توانم مقادیر «موثر» را پس از تمام ارث‌بری و بازنویسی‌ها ببینم؟**

از نمای «effective» API در مسیر [/shape-effective-properties/](/slides/fa/python-net/shape-effective-properties/) برای تم/رنگ/فونت/افکت استفاده کنید. این نمایه‌ها ویژگی‌های نهایی حل‌شده پس از اعمال مستر و هر گونه بازنویسی محلی را برمی‌گردانند.