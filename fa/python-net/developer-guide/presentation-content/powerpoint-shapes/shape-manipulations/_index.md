---
title: مدیریت اشکال در ارائه‌ها با استفاده از Python
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/python-net/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل بر روی اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop Shape
- متن جایگزین شکل
- فرمت‌های طرح‌بندی شکل
- شکل به صورت SVG
- تبدیل شکل به SVG
- ترازبندی شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در Aspose.Slides برای Python از طریق .NET ایجاد، ویرایش و بهینه‌سازی کنید و ارائه‌های PowerPoint و OpenDocument با کارایی بالا را ارائه دهید."
---
## **نمای کلی**

این راهنما به معرفی دستکاری اشکال در Aspose.Slides برای Python از طریق .NET می‌پردازد. الگوهای عملی برای یافتن اشکال (از جمله با متن جایگزین)، تکثیر، حذف یا مخفی‌سازی، مرتب‌سازی، تنظیم مکان و وارونه‌سازی، خواندن شناسه‌ها و قالب‌بندی مبتنی بر طرح، و استخراج اشکال جداگانه به SVG با استفاده از APIهای [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) و [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را بیاموزید.

## **یافتن اشکال در اسلایدها**

PowerPoint اشکال را فقط با شناسه‌های داخلی شناسایی می‌کند. یک متن Alt منحصربفرد به شکل هدف در PowerPoint اختصاص دهید، سپس ارائه را با Aspose.Slides برای Python باز کنید، بر روی اشکال اسلایدها تکرار کنید و شکلی که متن Alt آن مطابق است انتخاب کنید. متد `find_shape` این روش را پیاده‌سازی می‌کند و شکل مطابقت‌یافته را بر می‌گرداند.

```py
import aspose.slides as slides

# یک شکل را در اسلاید با متن جایگزین آن پیدا می‌کند.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # شکل با متن جایگزین "Shape1" را پیدا کنید.
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **کلون کردن اشکال**

برای کلون کردن اشکال از یک اسلاید منبع به اسلاید جدید در Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) از فایل منبع ایجاد کنید.
1. اسلاید منبع را با استفاده از ایندکس دریافت کنید و مجموعه اشکال آن را به دست آورید.
1. یک طرح‌بندی خالی از اسلاید اصلی (master) بازیابی کنید.
1. یک اسلاید خالی با استفاده از آن طرح‌بندی اضافه کنید و اشکال آن را دریافت کنید.
1. اشکال را به اسلاید هدف کلون کنید.
1. ارائه را به‌صورت PPTX ذخیره کنید.

کد مثال زیر اشکال را از یک اسلاید به اسلاید دیگر کلون می‌کند.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اشکال**

Aspose.Slides به شما امکان حذف هر شکلی را از یک اسلاید می‌دهد. به عنوان مثال، برای حذف یک شکل از اسلاید اول با استفاده از متن جایگزین آن، مراحل زیر را انجام دهید:

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کرده و فایل را بارگذاری کنید.
1. اسلاید اول را از مجموعه اسلایدها دسترسی پیدا کنید.
1. شکل را با مقدار متن جایگزین پیدا کنید.
1. شکل را از مجموعه اشکال اسلاید حذف کنید.
1. ارائه را در فرمت PPTX بر روی دیسک ذخیره کنید.

```py
import aspose.slides as slides

# یک شکل را در اسلاید با متن جایگزین آن پیدا می‌کند.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # شکل با متن جایگزین "User Defined" را پیدا کنید.
    shape = find_shape(slide, "User Defined")
    # شکل را حذف کنید.
    slide.shapes.remove(shape)
    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **مخفی کردن اشکال**

Aspose.Slides به شما امکان مخفی کردن هر شکلی را بر روی اسلاید می‌دهد. به عنوان مثال، برای مخفی کردن یک شکل در اسلاید اول با استفاده از متن جایگزین آن، مراحل زیر را دنبال کنید:

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کرده و فایل را بارگذاری کنید.
1. اسلاید اول را از مجموعه اسلایدها دسترسی پیدا کنید.
1. شکل را با مقدار متن جایگزین پیدا کنید.
1. شکل را مخفی کنید.
1. ارائه را در فرمت PPTX بر روی دیسک ذخیره کنید.

```py
# یک شکل را در اسلاید با متن جایگزین آن پیدا می‌کند.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # شکل با متن جایگزین "User Defined" را پیدا کنید.
    shape = find_shape(slide, "User Defined")
    # شکل را مخفی کنید.
    shape.hidden = True
    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر ترتیب اشکال**

Aspose.Slides به توسعه‌دهندگان اجازه می‌دهد اشکال را دوباره ترتیب دهند (تغییر z-order). ترتیب‌دهی تعیین می‌کند کدام شکل در جلو یا پشت ظاهر می‌شود. برای مثال، برای ترتیب‌دهی دو شکل در اسلاید اول، مراحل زیر را اجرا کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. اولین شکل را اضافه کنید (مثلاً یک مستطیل).
1. دومین شکل را اضافه کنید (مثلاً یک مثلث).
1. اشکال را با جابجایی شکل دوم به موقعیت اولین در مجموعه، ترتیب دهید.
1. ارائه را بر روی دیسک ذخیره کنید.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # دو شکل به اسلاید اضافه کنید.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # شکل دوم را به موقعیت اول منتقل کنید.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت شناسه Interop Shape**

Aspose.Slides به شما امکان می‌دهد شناسه‌ی منحصربفرد یک شکل را در محدوده اسلاید دریافت کنید، برخلاف ویژگی `unique_id` که در کل ارائه یکتا است. ویژگی `office_interop_shape_id` در کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) موجود است. مقدار آن معادل `Id` شیء `Microsoft.Office.Interop.PowerPoint.Shape` است. یک قطعه کد نمونه در زیر نمایش داده شده است.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # شناسه یکتای شکل را در اسلاید دریافت کنید.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **تنظیم متن جایگزین برای اشکال**

Aspose.Slides به توسعه‌دهندگان اجازه می‌دهد متن جایگزین برای هر شکلی تنظیم کنند. می‌توانید از متن جایگزین برای شناسایی و مکان‌یابی اشکال در یک ارائه استفاده کنید. ویژگی متن جایگزین می‌تواند از طریق Aspose.Slides و Microsoft PowerPoint خوانده و نوشته شود. با برچسب‌گذاری اشکال با این ویژگی، می‌توانید بعداً آن‌ها را حذف، مخفی یا ترتیب‌دهی کنید.

برای تنظیم متن جایگزین یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. یک شکل به اسلاید اضافه کنید.
1. متن جایگزین را تنظیم کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # یک شکل اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # متن جایگزین برای شکل تنظیم کنید.
    shape.alternative_text = "User Defined"
    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به فرمت‌های طرح‌بندی برای اشکال**

Aspose.Slides یک API ساده برای دسترسی به فرمت‌های طرح‌بندی برای اشکال فراهم می‌کند. این بخش نشان می‌دهد چگونه به فرمت‌های طرح‌بندی دسترسی پیدا کنید.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **رندر کردن اشکال به عنوان SVG**

Aspose.Slides از رندر کردن اشکال به صورت SVG پشتیبانی می‌کند. متد `write_as_svg` (و بارگذاری‌های آن) در کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) به شما امکان می‌دهد محتویات یک شکل را به عنوان تصویر SVG ذخیره کنید. قطعه کد زیر نشان می‌دهد چگونه یک شکل را به فایل SVG صادر کنید.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # اولین شکل را در اولین اسلاید دریافت کنید.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **ترازبندی شکل**

با استفاده از متد `align_shape` در کلاس [SlidesUtil](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/) می‌توانید:

* اشکال را نسبت به حاشیه‌های اسلاید ترازبندی کنید (مثال 1 را ببینید).
* اشکال را نسبت به یکدیگر ترازبندی کنید (مثال 2 را ببینید).

مقداردهی [ShapesAlignmentType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapesalignmenttype/) گزینه‌های ترازبندی موجود را تعریف می‌کند.

**مثال 1**

این کد Python نشان می‌دهد چگونه اشکالی با ایندکس‌های 1، 2 و 4 را به لبه بالایی اسلاید ترازبندی کنید:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**مثال 2**

این مثال Python نشان می‌دهد چگونه تمام اشکال یک مجموعه را نسبت به شکل پایین‌ترین در آن مجموعه ترازبندی کنید:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **ویژگی‌های وارونه‌سازی**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeframe/) کنترل افقی و عمودی انعکاس اشکال را از طریق ویژگی‌های `flip_h` و `flip_v` فراهم می‌کند. هر دو ویژگی از نوع [NullableBool](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) هستند و مقادیر `TRUE` برای وارونه‌سازی، `FALSE` برای عدم وارونه‌سازی یا `NOT_DEFINED` برای استفاده از رفتار پیش‌فرض را می‌پذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/frame/) یک شکل قابل دسترسی هستند.

برای تغییر تنظیمات وارونه‌سازی، یک نمونه جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeframe/) با موقعیت و اندازهٔ جاری شکل، مقادیر دلخواه برای `flip_h` و `flip_v` و زاویهٔ چرخش ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/frame/) شکل و ذخیرهٔ ارائه، تبدیل‌های انعکاسی را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول حاوی یک شکل با تنظیمات وارونه‌سازی پیش‌فرض است، همان‌طور که در زیر نشان داده شده است.

![شکل قابل وارونه‌سازی](shape_to_be_flipped.png)

قطعه کد زیر ویژگی‌های وارونه‌سازی جاری شکل را دریافت کرده و آن را هم به صورت افقی و هم عمودی وارونه می‌کند.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # دریافت ویژگی وارونه‌سازی افقی شکل.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # دریافت ویژگی وارونه‌سازی عمودی شکل.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # وارونه‌سازی افقی و عمودی.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل وارونه‌شده](flipped_shape.png)

## **پرسش‌های متداول**

**آیا می‌توانم اشکال را (اتحاد/تقاطع/تفریق) در یک اسلاید مانند یک ویرایشگر دسکتاپ ترکیب کنم؟**

یک API عملیات منطقی داخلی وجود ندارد. می‌توانید با ساختن شکل جدیدی که مرزهای مورد نظر را شامل می‌شود—به عنوان مثال محاسبهٔ هندسهٔ نتیجه‌گیری با استفاده از [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) و ایجاد یک شکل جدید با همان زمینه—تقریباً این کار را انجام دهید و در صورت نیاز اشکال اصلی را حذف کنید.

**چگونه می‌توانم ترتیب لایه (z-order) را کنترل کنم تا یک شکل همیشه «در بالا» بماند؟**

ترتیب درج/جابه‌جایی را در مجموعهٔ [shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/shapes/) اسلاید تنظیم کنید. برای نتایج قابل پیش‌بینی، پس از تمام تغییرات اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم یک شکل را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های حفاظت در سطح شکل را تنظیم کنید (مانند قفل انتخاب، حرکت، تغییر اندازه، ویرایش متن). در صورت نیاز، این محدودیت‌ها را در مستر یا طرح‌بندی نیز اعمال کنید. توجه داشته باشید این محافظت سطح UI است و ویژگی امنیتی نیست؛ برای حفاظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح فایل مانند توصیه‌های فقط‑خواندنی یا پسورد ترکیب کنید.