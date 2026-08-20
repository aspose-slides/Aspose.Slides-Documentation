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
- تکثیر شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- قالب‌های چیدمان شکل
- شکل به عنوان SVG
- شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تکثیر، حذف, مخفی، بازمرتب‌سازی، صادر کردن، تراز کردن و چرخاندن کنید با Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق .NET اشکال موجود در اسلاید را به‌صورت یک [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) مرتب شده نشان می‌دهد. این مجموعه هم جایی است که می‌توانید اشکال را پیدا و تغییر دهید و هم منبع ترتیب لایه‌بندی آن‌ها: شاخص `0` نمایان‌گر پشت‌ترین شکل است، در حالی که آخرین شاخص نمایان‌گر جلوی‌ترین شکل است.

این مقاله این مدل را دنبال می‌کند. ابتدا توضیح می‌دهد چگونه می‌توان یک شکل را به‌صورت قابل اطمینان شناسایی کرد، سپس نشان می‌دهد چگونه می‌توان اشکال را تکثیر، حذف، مخفی و بازمرتب‌سازی کرد. بخش‌های نهایی قالب‌بندی در سطح چیدمان، خروجی SVG، تراز و تنظیمات چرخش را پوشش می‌دهند. هر مثال به‌صورت مستقل است، بنابراین می‌توانید فقط عملیاتی را که گردش کار شما به آن نیاز دارد استفاده کنید.

## **شناسایی و یافتن اشکال**

شاخص‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌گذارهای ثابت نیستند. افزودن، حذف یا بازمرتب‌سازی یک شکل می‌تواند شاخص آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ ایجاد و نگهداری ارائه انتخاب کنید:

- [Shape.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل مشاهده است. نام‌ها قابلیت ویرایش دارند و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری برقرار کنید.
- [Shape.alternative_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/alternative_text/) زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسب ارائه‌دهنده پیش از این شکل را شناسایی کند. این متن برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و یکتا نیست. متن دسترس‌پذیری معنادار را به‌صورت ساکن کلید پایگاه داده استفاده نکنید.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/office_interop_shape_id/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتاست و به شناسهٔ شکل مورد استفاده توسط PowerPoint interop مربوط می‌شود. هنگام ادغام با PowerPoint یا زمانی که به یک مرجع غیر مبهم در طول زمان حیات یک شکل نیاز دارید از آن استفاده کنید. یک شکل کپی‌شده یا بازساخته شکل متفاوتی است و شناسهٔ مخصوص خود را دریافت می‌کند.

ویژگی مرتبط [Shape.unique_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/unique_id/) دامنهٔ ارائه دارد، اما برای افزونه‌ها در نظر گرفته شده و می‌تواند مجدداً تخصیص یابد. نباید به‌عنوان کلید خارجی دائمی رفتار شود. اگر هویت بلندمدت ضروری است، نگاشت را در دادهٔ برنامه نگه دارید و اعتبارسنجی کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با مقایسهٔ دقیق `name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شکل مورد انتظار را نداشته باشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامهٔ کار با شیء نادرست.

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

هنگامی که یک عملیات به نوع خاصی از شکل تعلق دارد، پیش از استفاده از اعضای مخصوص نوع، نوع را بررسی کنید. این مثال متن و متن جایگزین را تنها در صورتیکه شیء نام‌گذاری‌شده یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) باشد به‌روزرسانی می‌کند.

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

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، تکثیر، حذف و بازمرتب‌سازی بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر داد، دیگر به شاخص‌های ثبت‌شده پیش از آن عملیات تکیه نکنید.

### **تکثیر یک شکل**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_clone/) یک نسخهٔ مستقل ایجاد می‌کند و آن را به انتهای مجموعهٔ هدف اضافه می‌نماید. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/insert_clone/) نیز یک کپی می‌سازد اما آن را در یک شاخص z‑order مشخص قرار می‌دهد. overloadهایی که مختصات می‌پذیرند کپی را بدون تغییر اندازه جابه‌جا می‌کنند؛ overloadهایی که عرض و ارتفاع می‌گیرند می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلوی اسلاید تکثیر می‌کند و یک تکثیر دوم را در پشت قرار می‌دهد. تغییرات هر دو تکثیر بر شکل منبع تأثیری نمی‌گذارد.

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

تکثیر محتوا و قالب‌بندی شکل را شامل می‌شود، از جمله نام و متن جایگزین آن. وقتی این مقادیر باید یکتا باشند شناسه‌های منطقی جدید به تکثیر اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شود، اما تکثیر یک مورد جدید در مجموعه با هویت جدید شکل است.

### **حذف اشکال**

[ShapeCollection.remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین تطبیق در طول تکرار بر پایهٔ شاخص، از انتها به سمت ابتدا عبور کنید تا هر شاخص باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام تعیین‌شده داشته باشد را حذف می‌کند. از `slide.shapes[index]` می‌خواند، نه یک مورد ثابت مجموعه، و شکل را بدون تبدیل غیرضروری به نوع دیگری می‌گیرد.

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

پس از حذف، شمارش شکل‌ها و شاخص‌های اشکال بعدی تغییر می‌کند. ارجاعات به اشکال غیرقابل‌تغییر از شاخص‌های ذخیره‌شده قابل‌اعتمادتر هستند. همچنین به اتصال‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند توجه کنید؛ حذف یک شکل قابل‌مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Shape.hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/hidden/) به `True` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش اسلاید عادی جلوگیری می‌کند. شاخص، قالب‌بندی و محتوای آن برای کد در دسترس می‌ماند، بنابراین مخفی‌سازی برای عناصر اختیاری که ممکن است بعدها بازگردانده شوند مناسب است.

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

مخفی‌سازی حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد پیدا و بازنمایی شود و بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر پایهٔ ترتیب مجموعه رنگ می‌شوند. [ShapeCollection.reorder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/reorder/) یک شکل موجود را به شاخص هدف منتقل می‌کند بدون این‌که آن را تکثیر کند. شاخص `0` پشت‌ترین است؛ `len(slide.shapes) - 1` جلوی‌ترین.

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

مستطیل ابتدا ایجاد می‌شود و ابتدایی پشت دایره قرار دارد. جابه‌جایی آن به شاخص نهایی آن را به جلوی صفحه می‌برد. پس از افزودن یا تکثیر تمام اشکال مرتبط، Z‑Order را نهایی کنید، زیرا این عملیات موارد جدیدی را به مجموعه اضافه یا درج می‌کنند و می‌توانند ترتیب مورد نظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای چیدمانی**

اسلایدهای عادی، اسلایدهای چیدمانی و اسلایدهای استاد مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ چیدمان همان شیء شکل مشابه در اسلاید عادی نیست. وقتی نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک چیدمان دارید، اشکال چیدمان را بررسی کنید.

مثال زیر هر شکل چیدمان را با استفاده از [Shape.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/fill_format/) و [Shape.line_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/line_format/) می‌خواند بدون این‌که فرض کند هر شکل یک `AutoShape` است.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

ویرایش یک چیدمان می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. پیش از تغییر یک شکل چیدمان، تعیین کنید آیا اسلاید عادی آن شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن چیدمان استفاده می‌کند را تست کنید.

## **صادرات یک شکل به SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) محتوای رندر‌شده یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینهٔ کامل اسلاید یا اشکال همسایه.

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

در حین رندر کردن ارائه را باز بمانید. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به ترکیب کامل نیاز دارید، اسلاید را به‌جای یک شکل جداگانه صادر کنید. فراخوانی‌کننده مالک جریان است و باید آن را بسته.

## **تراز کردن اشکال**

متد [SlideUtil.align_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/align_shapes/) می‌تواند همهٔ اشکال یا شاخص‌های انتخاب‌شدهٔ مجموعه را تراز کند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapesalignmenttype/) سمت، خط مرکزی یا حالت توزیع را مشخص می‌کند. مقدار `align_to_slide` را به `True` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `False` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. شاخص‌های فعلی آن‌ها دقیقاً پیش از تراز حلّ شد.

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

تراز موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به اندازه کافی شکل برای تعیین فواصل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، شاخص‌ها را دوباره محاسبه کنید.

## **چرخاندن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی، و چرخش را ذخیره می‌کند. مقادیر `flip_h` و `flip_v` از [NullableBool](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) استفاده می‌کنند: `TRUE` چرخش را فعال می‌کند، `FALSE` آن را غیرفعال می‌کند، و `NOT_DEFINED` حالت تعریف‌نشده یا پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![شکل قبل از چرخش](shape_to_be_flipped.png)

مثال تمام مقادیر دیگر فریم را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است چون اختصاص یک [Shape.frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/frame/) جدید تمام فریم را بازنویسی می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل بعد از چرخش](flipped_shape.png)

## **سوالات متداول**

**آیا باید از شاخص مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه قبل از استفاده از شاخص تغییر نخواهد کرد. برای قالب‌های ساخته‌شده ترجیحاً از یک قرارداد معتبر `name` یا `alternative_text` استفاده کنید، یا برای کارهای scoped به اسلاید `office_interop_shape_id` بکار ببرید.

**آیا مخفی‌سازی یک shape آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی در همان شاخص در مجموعه باقی می‌ماند. می‌تواند پیدا، بازمرتب‌سازی، ویرایش یا مجدداً قابل مشاهده شود.

**چرا یک شکل تکثیرشده در جلوی شکل دیگری ظاهر شد؟**

`add_clone` تکثیر را به انتهای مجموعه اضافه می‌کند که جلوی Z‑Order است. برای انتخاب شاخص اولیه از `insert_clone` استفاده کنید یا پس از افزودن تمام اشکال از `reorder` بهره ببرید.