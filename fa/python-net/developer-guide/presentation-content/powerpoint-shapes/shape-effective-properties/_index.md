---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها با Python
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/python-net/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل برش
- قاب متن
- سبک متن
- ارتفاع فونت
- قالب پرکردن
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای Python از طریق .NET ویژگی‌های مؤثر شکل را محاسبه و اعمال می‌کند تا ارائه دقیق PowerPoint حاصل شود."
---
## **مرور کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی مقادیری هستند که مستقیماً در یک سطح قالب‌بندی خاص تنظیم می‌شوند، مانند:

1. خصوصیات بخش (Portion) در یک اسلاید.  
1. سبک‌های متن شکل نمونه (Prototype) در یک لایه‌بندی یا اسلاید اصلی، هنگامی که شکل قاب متن بخش آن یکی داشته باشد.  
1. تنظیمات متنی سراسری در یک ارائه.

مقادر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides برای دریافت قالب‌بندی نهایی «به‌صورت رندر شده» نیاز دارد، زنجیره ارث‌بری را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید این مقادیر را با فراخوانی متد `get_effective` روی شیء قالب‌بندی محلی به دست آورید.

نمونه زیر نشان می‌دهد چگونه مقادیر موثر را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با یک قاب متن و حداقل یک بخش باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
داده‌های قالب‌بندی مؤثر، قالب‌بندی محاسبه‌شده فعلی پس از اعمال ارث‌بری را نشان می‌دهند. در پیاده‌سازی فعلی، برخی از اشیاء داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformateffectivedata/)، ممکن است به‌صورت داخلی کش شوند. فراخوانی دوباره `get_effective` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند داده‌های کش‌شده را تازه‌سازی کند و یک شیء قبلاً به‌دست آمده ممکن است دیگر نمایانگر وضعیت قبلی نباشد. اگر نیاز دارید مقادیر مؤثر را برای استفادهٔ بعدی حفظ کنید، خصوصیات مورد نیاز مانند ارتفاع فونت، رنگ پرکردن، سبک فونت یا تراز را در شیء دادهٔ خود کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر یک دوربین**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک دوربین را دریافت کنید. نوع [ICameraEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/icameraeffectivedata/) یک شیء غیرقابل تغییر است که ویژگی‌های مؤثر دوربین را شامل می‌شود. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر دوربین را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **دریافت ویژگی‌های مؤثر یک نورپرداز (Light Rig)**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک نورپرداز را دریافت کنید. نوع [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilightrigeffectivedata/) یک شیء غیرقابل تغییر است که ویژگی‌های مؤثر نورپرداز را شامل می‌شود. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر نورپرداز را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **دریافت ویژگی‌های مؤثر یک چکشی شکل (Bevel Shape)**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک چکشی شکل را دریافت کنید. نوع [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapebeveleffectivedata/) یک شیء غیرقابل تغییر است که خصوصیات مؤثر Relief برای یک شکل را شامل می‌شود. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر چکشی بالایی یک شکل را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **دریافت ویژگی‌های مؤثر یک قاب متن (Text Frame)**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک قاب متن را دریافت کنید. نوع [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/itextframeformateffectivedata/) شامل خصوصیات قالب‌بندی مؤثر قاب متن است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های قالب‌بندی مؤثر قاب متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با یک قاب متن باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **دریافت ویژگی‌های مؤثر یک سبک متن (Text Style)**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. نوع [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/itextstyleeffectivedata/) شامل خصوصیات مؤثر سبک متن است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر سبک متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با یک قاب متن باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **دریافت مقدار مؤثر ارتفاع فونت**

با استفاده از Aspose.Slides می‌توانید ارتفاع فونت مؤثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع فونت مؤثر یک بخش پس از تنظیم مقادیر محلی ارتفاع فونت در سطوح مختلف ساختار ارائه تغییر می‌کند.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت قالب‌بندی پرکردن مؤثر برای یک جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پرکردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. نوع [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ifillformateffectivedata/) شامل خصوصیات قالب‌بندی پرکردن مؤثر است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون اولویت بالاتری دارد و قالب‌بندی ستون نسبت به قالب‌بندی تمام جدول اولویت بالاتری دارد.

در نتیجه، خصوصیات [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. کد نمونهٔ زیر نشان می‌دهد چگونه قالب‌بندی پرکردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) باشد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **سئوالات متداول**

**آیا `get_effective` یک تصویر لحظه‌ای (snapshot) برمی‌گرداند؟**

همیشه نیست. داده‌های مؤثر، قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری را نشان می‌دهند، اما برخی از اشیاء داده مؤثر می‌توانند به‌صورت داخلی کش شوند. فراخوانی بعدی `get_effective` ممکن است قالب‌بندی را بازمحاسبه کرده و داده‌های کش‌شده را تازه‌سازی کند، بنابراین شیء قبلاً به‌دست آمده نباید به‌عنوان یک تصویر ثابت در نظر گرفته شود.

**چه زمانی باید دوباره ویژگی‌های مؤثر را بخوانم؟**

پس از تغییر قالب‌بندی محلی، استایل‌های والد، قالب‌بندی لایه‌بندی، قالب‌بندی اصلی یا مقادیر پیش‌فرض سطح ارائه، `get_effective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله مراتب قالب‌بندی را مجدداً ارزیابی کرده و نتیجهٔ مؤثر جاری را برمی‌گرداند.

**آیا تغییر یا حذف یک اسلاید لایه‌بندی/اصلی، ویژگی‌های مؤثری که قبلاً دریافت شده‌اند را تحت تأثیر قرار می‌دهد؟**

بله، اما این تغییر در فراخوانی بعدی `get_effective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثر قبلاً به‌دست آمده ممکن است منسوخ شوند. پس از فراخوانی دوباره `get_effective`، Aspose.Slides درخت قالب‌بندی را بازارزیابی می‌کند و فونت‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیاء داده مؤثر تغییر دهم؟**

نه. اشیاء داده مؤثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیاء قالب‌بندی محلی انجام دهید و سپس مقادیر مؤثر را دوباره دریافت کنید.

**اگر یک ویژگی در سطح شکل، لایه‌بندی/اصلی یا تنظیمات سراسری تنظیم نشده باشد، چه می‌شود؟**

مقدار مؤثر بر اساس مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از دادهٔ مؤثر فعلی می‌شود.

**آیا می‌توانم از مقدار فونت مؤثر تشخیص دهم که کدام سطح اندازه یا نوع‌قلم را فراهم کرده است؟**

به‌طور مستقیم نه. داده‌های مؤثر فقط مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متنی در سطوح لایه‌بندی، اصلی و ارائه بررسی کنید تا اولین تعریف صریح را بیابید.

**چرا گاهی مقادیر مؤثر شبیه به مقادیر محلی به نظر می‌رسند؟**

چون مقدار محلی به‌عنوان نهایی باقی مانده (نیاز به ارث‌بری سطح بالاتر نبوده). در این موارد مقدار مؤثر با مقدار محلی یکسان است.

**چه زمانی باید از ویژگی‌های مؤثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

زمانی که به نتیجهٔ «به‌صورت رندر شده» پس از اعمال تمام ارث‌بری‌ها نیاز دارید، از دادهٔ مؤثر استفاده کنید، مثلاً برای هم‌ترازی رنگ‌ها، تورفتگی‌ها یا اندازه‌ها. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات قالب‌بندی بعدی حفظ کنید، خصوصیات مورد نیاز را در شیء خود کپی کنید. اگر قصد دارید قالب‌بندی را در یک سطح خاص تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس، در صورت نیاز، دادهٔ مؤثر را دوباره بخوانید تا نتیجه را تأیید کنید.