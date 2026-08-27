---
title: مدیریت اشکال ارائه در پایتون
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/python-net/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- پنهان‌کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- نقطهٔ تنظیم شکل
- تنظیم پیش‌فرض شکل
- هندسهٔ شکل
- قالب‌های چیدمان شکل
- شکل به صورت SVG
- شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه اشکال ارائه را با Aspose.Slides برای Python از طریق .NET شناسایی، تنظیم، کلون، حذف، مخفی، دوباره‌ترتیب‌بندی، خروجی، تراز و چرخاندن کنید."
---
## **نمای کلی**

Aspose.Slides for Python via .NET اشکال موجود در یک اسلاید را به‌صورت یک [مجموعه‌ اشکال](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) مرتبی نمایش می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب انباشته‑سازی آن‌ها: ایندکس `0` عقب‌ترین شکل است، در حالی که آخرین ایندکس جلوترین شکل است.

این مقاله همان مدل را دنبال می‌کند. ابتدا توضیح می‌دهد چگونه یک شکل را به‌صورت قابل اطمینان شناسایی و نقاط تنظیم پیش‌فرض شکل را تغییر دهید، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و دوباره ترتیب‌بندی کنید. بخش‌های نهایی به قالب‌بندی در سطح چیدمان، خروجی SVG، تراز و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که در جریان کارتان نیاز دارید استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره ترتیب‌بندی یک شکل می‌تواند ایندکس آن را تغییر دهد. بسته به نحوهٔ ایجاد و نگهداری ارائه، شناسه‌ای انتخاب کنید:

- [Shape.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و به‌راحتی در پانل انتخاب PowerPoint قابل مشاهده است. نام‌ها قابل ویرایش‌اند اما تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک قرارداد نام‌گذاری تعیین کنید.
- [Shape.alternative_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/alternative_text/) وقتی توضیح‌دستیابی یا برچسبی توسط نویسنده قبلاً شکل را شناسایی می‌کند مفید است. برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و تضمین یکتایی ندارد. متن دسترسی‌پذیری معنادار را به‌صورت خاموش به‌عنوان کلید دیتابیس استفاده نکنید.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/office_interop_shape_id/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا است و به شناسهٔ شکل استفاده‌شده توسط PowerPoint interop مربوط می‌شود. هنگام ادغام با PowerPoint یا وقتی به مرجع واضحی در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‑شده یا دوباره‑ساخته‌شده یک شکل متفاوت است و شناسهٔ خود را دریافت می‌کند.

ویژگی مرتبط [Shape.unique_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/unique_id/) دامنهٔ ارائه دارد، اما برای افزونه‌ها در نظر گرفته شده و می‌تواند بازتخصیص یابد. نباید به‌عنوان کلید خارجی دائمی استفاده شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه‌دارید و صحت وجود شکل مورد انتظار را تأیید کنید.

مثال زیر با مقایسه دقیق `name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نیست، کد همان نتایج را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

هنگامی که عملیاتی خاص به نوعی از شکل مربوط است، قبل از استفاده از اعضای نوع‑خاص، نوع را بررسی کنید. این مثال فقط در صورتی که شیء نام‌گذاری‌شده یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) باشد، متن و متن جایگزین را به‌روزرسانی می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **شناسایی و اصلاح تنظیمات پیش‌فرض شکل**

اشکال هندسی پیش‌فرض می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های پیکان یا زاویهٔ قوس را کنترل می‌کنند. از مجموعه فقط‑خواندنی [GeometryShape.adjustments](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/adjustments/) برای دسترسی به آن‌ها استفاده کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر [AdjustValue](https://reference.aspose.com/slides/fa/python-net/aspose.slides/adjustvalue/) شامل مقداری است که می‌توان آن را تغییر داد.

به‌تنهایی به یک ایندکس ثابت وابسته نشوید. در میان تنظیمات پیمایش کنید و ویژگی فقط‑خواندنی [AdjustValue.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/adjustvalue/type/) را بررسی کنید؛ مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeadjustmenttype/) توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. ویژگی فقط‑خواندنی [AdjustValue.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/adjustvalue/name/) اطلاعات شناسایی اضافی می‌دهد و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی داشته باشد، مفید است.

از ویژگی مقدار متناسب با معنای تنظیم استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CORNER_SIZE` | اندازهٔ گوشه‌های گرد | [raw_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | ضخامت انتهای پیکان | `raw_value` |
| `ARROWHEAD_LENGTH` | طول سر پیکان | `raw_value` |
| `ARROWHEAD_WIDTH` | عرض سر پیکان | `raw_value` |
| `START_ANGLE` | زاویهٔ شروع دایره یا قوس | [angle_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | زاویهٔ پایان دایره یا قوس | `angle_value` |

`type` و `name` قابل انتساب نیستند. `raw_value` عدد صحیح خواندنی/نوشتنی در واحدهای هندسی بومی پیش‌تنظیم است، در حالی که `angle_value` زاویهٔ خواندنی/نوشتنی بر حسب درجه است. تعداد، ترتیب، معنای و محدودهٔ معتبر تنظیمات به [GeometryShape.shape_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/shape_type/) پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `type` برابر `ShapeAdjustmentType.CUSTOM` باشد، API معنای معنایی استانداردی را تشخیص نمی‌دهد. `name`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست نخورده بگذارید مگر اینکه معنای مورد انتظار و محدودهٔ آن شناخته شده باشد. حتی برای انواع شناخته‌شده، پیش از انتخاب مقدار بررسی کنید آیا همان نوع بیش از یک بار ظاهر می‌شود یا خیر. مقالهٔ [Connector](/slides/fa/python-net/connector/) این وضعیت را با تنظیمات انحنا برای «متصل‌کننده» نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده ایجاد می‌کند. به‌صورت حلقه‌ای از هر تنظیم عبور می‌کند، `name` و `type` آن را گزارش می‌دهد، مقادیر مرتبط با اندازه را با `raw_value` تغییر می‌دهد، زاویه‌ها را با `angle_value` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد، پیکان چهارطرفه و دایرهٔ قطعی تنظیم‌شده را نشان می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # سرصفحه‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم‌شده اضافه کنید.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

بررسی نوع معنایی قبل از تغییر مقدار، کد را نسبت به قصدش واضح می‌سازد و از فرض اینکه ایندکس خاصی در تمام پیش‌تنظیم‌ها همان معنای را دارد، جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و دوباره‑ترتیب‌بندی بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن به ایندکس‌های ضبط‑شدهٔ قبل از آن عملیات وابسته نباشید.

### **کلون یک شکل**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_clone/) یک نسخهٔ مستقل ایجاد می‌کند و به انتهای مجموعه هدف اضافه می‌نماید. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/insert_clone/) نیز یک نسخه ایجاد می‌کند اما آن را در ایندکس z‑order مشخص‌ شده قرار می‌دهد. بارگذاری‌های پذیرندهٔ مختصات کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ بارگذاری‌های دارای عرض و ارتفاع می‌توانند اندازهٔ آن را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، یک مستطیل برچسب‌دار را در جلو کلون می‌کند و یک کلون دوم را در پشت وارد می‌کند. تغییرات در هر کلون شکل منبع را تحت تأثیر قرار نمی‌دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

کلون‌کردن محتوا و قالب‌بندی شکل، از جمله نام و متن جایگزین آن را کپی می‌کند. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کلون یک مورد جدید در مجموعه با هویت شکل جدید باقی می‌ماند.

### **حذف اشکال**

[ShapeCollection.remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مورد مطابقت‌دار در طول پیمایش ایندکسی، از انتها به ابتدا عبور کنید تا هر ایندکس باقی‌مانده همچنان معتبر بماند.

این مثال هر شکلی را که دارای نام معین باشد حذف می‌کند. از `slide.shapes[index]` می‌خواند، نه یک مورد ثابت از مجموعه، و نیازی به تبدیل غیرضروری نوع شکل نیست.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

پس از حذف، شمارش شکل‌ها و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال بدون تأثیر بیشتر از ایندکس‌های ذخیره‌شده قابل اطمینان‌تر است. همچنین به متصل‌کننده‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه‌ای که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید تغییر ایجاد کند.

### **مخفی کردن یک شکل**

تنظیم [Shape.hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/hidden/) به `True` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش عادی اسلاید جلوگیری می‌کند. ایندکس، قالب‌بندی و محتویات آن برای کد در دسترس باقی می‌مانند، بنابراین مخفی کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

مخفی کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره نمایان شود و بخشی از فایل ارائه می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‑یافته بر اساس ترتیب مجموعه کشیده می‌شوند. [ShapeCollection.reorder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/reorder/) شکل موجود را به ایندکس هدف بدون کلون منتقل می‌کند. ایندکس `0` عقب است؛ `len(slide.shapes) - 1` جلو.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

در ابتدا مستطیل ساخته می‌شود و پشت بیضی قرار دارد. جابه‌جایی آن به ایندکس نهایی، آن را به‌سوی جلو می‌برد. پس از افزودن یا کلون تمام اشکال مرتبط، Z‑Order را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند پشتهٔ مورد نظر را تغییر دهند.

## **بررسی اشکال در اسلایدهای چیدمان**

اسلایدهای معمولی، اسلایدهای چیدمان و اسلایدهای اصلی مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ چیدمان همان شیء نیست که شکل مشابهی در اسلاید معمولی داشته باشد. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک چیدمان، اشکال چیدمان را بررسی کنید.

مثال زیر برای هر شکل چیدمان، [Shape.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/fill_format/) و [Shape.line_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/line_format/) را می‌خواند بدون این‌که فرض کند هر شکل یک `AutoShape` است.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

ویرایش یک چیدمان می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. پیش از تغییر شکل چیدمان، تعیین کنید آیا اسلاید معمولی شیء را به ارث می‌برد یا اورراید لوکال دارد و هر اسلایدی که از آن چیدمان استفاده می‌کند را تست کنید.

## **صادرات یک شکل به SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همسایه.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

در حین رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به ترکیب کامل نیاز دارید، اسلاید را به‌جای شکل منفرد صادر کنید. فراخواننده مالک جریان است و باید آن را بسته باشد.

## **تراز کردن اشکال**

متدهای [SlideUtil.align_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/align_shapes/) می‌توانند تمام اشکال یا ایندکس‌های انتخابی مجموعه را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapesalignmenttype/) لبه، مرکز یا حالت توزیع را مشخص می‌کند. `align_to_slide` را به `True` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `False` تنظیم کنید تا اشکال انتخابی نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. ایندکس‌های فعلی آن‌ها درست قبل از تراز resolved می‌شوند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

ترازبندی موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. ترازبندی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعیین فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را اصلاح می‌کنید، ایندکس‌ها را دوباره محاسبه کنید.

## **چرخاندن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `flip_h` و `flip_v` از نوع [NullableBool](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) استفاده می‌کنند: `TRUE` چرخش را فعال می‌کند، `FALSE` غیرفعال می‌کند و `NOT_DEFINED` حالت پیش‌فرض یا نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![The shape before flipping](shape_to_be_flipped.png)

مثال همه مقادیر دیگر فریم را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است چون اختصاص یک [Shape.frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/frame/) جدید تمام فریم را بازنویسی می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

شکل ذخیره‌شده به‌صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![The shape after flipping](flipped_shape.png)

## **سوالات متداول**

**آیا باید از ایندکس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدت که مجموعه قبل از استفاده از ایندکس تغییر نمی‌کند. برای قالب‌های نویسنده‌شده از یک قرارداد معتبر `name` یا `alternative_text` استفاده کنید یا برای کارهای interop scoped به اسلاید از `office_interop_shape_id` بهره ببرید.

**آیا مخفی کردن یک شکل آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی در همان ایندکس در مجموعه باقی می‌ماند. می‌توانید آن را پیدا کنید، دوباره ترتیب‑بندی کنید، ویرایش کنید یا دوباره نمایش دهید.

**چرا یک شکل کلون‌شده در جلوی شکل دیگری ظاهر شد؟**

`add_clone` کلون را به انتهای مجموعه اضافه می‌کند که جلوترین قسمت Z‑Order است. برای انتخاب ایندکس اولیه از `insert_clone` یا پس از افزودن تمام اشکال از `reorder` استفاده کنید.

**آیا می‌توانم از یک ایندکس ثابت برای شناسایی تنظیم پیش‌فرض شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً از طریق پیمایش `GeometryShape.adjustments` و بررسی `AdjustValue.type` عمل کنید؛ وقتی همان نوع معنایی بیش از یک‌بار ظاهر می‌شود، از `AdjustValue.name` به‌عنوان اطلاعات تکمیلی استفاده کنید.