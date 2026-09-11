---
title: مدیریت اشکال ارائه در پایتون از طریق جاوا
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/python-java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم‌شدهٔ شکل
- هندسهٔ شکل
- قالب‌بندی چیدمان شکل
- شکل به‌صورت SVG
- تبدیل شکل به SVG
- هم‌راستایی شکل
- وارون کردن شکل
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تنظیم، کلون، حذف، مخفی، دوباره‌چین، صادر، هم‌راستا و وارون کنید با Aspose.Slides برای پایتون از طریق جاوا."
---
## **مرور کلی**

Aspose.Slides for Python via Java اشکال یک اسلاید را به عنوان یک [ShapeCollection] مرتب شده نشان می‌دهد. این مجموعه هم جایی است که می‌توانید اشکال را پیدا و ویرایش کنید و هم منبع ترتیب استک‑گذاری آن‌ها: اندیس `0` پشت‌ترین شکل است، در حالی که آخرین اندیس جلوترین شکل است.

این مقاله بر همین مدل ساخته شده است. ابتدا نحوه شناسایی پایدار یک شکل و تغییر نقاط تنظیم پیش‌فرض آن را توضیح می‌دهد، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و دوباره‌چین کنید. بخش‌های نهایی به قالب‌بندی در سطح لایه، خروجی SVG، هم‌راستایی و تنظیمات وارونگی می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که به فرآیند کاری‌تان نیاز دارد، استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش فایل‌های شناخته‌شده مفید هستند، اما شناسه‌های ثابت نیستند. افزودن، حذف یا دوباره‌چین کردن یک شکل می‌تواند اندیس آن را تغییر دهد. شناسه‌ای را بر حسب نحوهٔ نگارش و نگهداری ارائه انتخاب کنید:

- [Name] برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به راحتی قابل مشاهده است. نام‌ها را می‌توان ویرایش کرد و تضمینی برای یکتا بودن ندارند، بنابراین اگر کد به آن‌ها وابسته است، یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText] زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسب توسط نویسنده پیش از این شکل را شناسایی کرده باشد. این متن برای کاربران قابل رؤیت است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و تضمینی برای یکتا بودن ندارد. متن دسترس‌پذیری معنادار را به‌صورت ساکن برای کلید پایگاه‌داده استفاده نکنید.
- [OfficeInteropShapeId] یک شناسهٔ تنها‌خوان است که در یک اسلاید یکتا است و متناظر با شناسهٔ شکل مورد استفاده در PowerPoint interop می‌باشد. هنگامی که با PowerPoint یکپارچه می‌شوید یا به یک مرجع بی‌ابهام در طول عمر یک شکل نیاز دارید، از آن استفاده کنید. یک شکل کلون‌شده یا دوباره‌ساخته یک شکل متفاوت است و شناسهٔ خود را دریافت می‌کند.

متد مرتبط [getUniqueId] یک شناسهٔ با دامنهٔ ارائه می‌دهد، اما این شناسه برای افزودنی‌هاست و می‌تواند دوباره اختصاص یابد. نباید آن را به‌عنوان کلید خارجی دائمی در نظر گرفت. اگر هویت بلندمدت ضروری است، نگاشت را در داده‌های برنامه نگه داشته و تأیید کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. هنگامی که قالب شکل مورد انتظار را نداشته باشد، کد آن نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

هنگامی که یک عملیات به نوع خاصی از شکل وابسته است، پیش از استفاده از اعضای نوع‑خاص، نوع را بررسی کنید. این مثال متن و متن جایگزین را تنها در صورتی به‌روزرسانی می‌کند که شیء نام‌گذاری‌شده یک [AutoShape] باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

اشکال هندسی پیش‌تنظیم‌شده می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های فلش یا زاویهٔ قوس را کنترل می‌کنند. به آن‌ها از طریق مجموعهٔ فقط‑خوانی [GeometryShape.getAdjustments] دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر [AdjustValue] حاوی مقداری است که می‌توان آن را تغییر داد.

فقط به یک اندیس ثابت مجموعه تکیه نکنید. از طریق تنظیمات پیمایش کنید و متد فقط‑خوانی [getType] را بررسی کنید، که مقدار [ShapeAdjustmentType] توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خوانی [getName] اطلاعات شناسایی اضافی فراهم می‌کند و به‌ویژه وقتی پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی داشته باشد، مفید است.

از متد مقداری که با معنای تنظیم مطابقت دارد استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| [CornerSize] | اندازهٔ گوشه‌های گرد | [setRawValue] |
| [ArrowTailThickness] | ضخامت دم فلش | [setRawValue] |
| [ArrowheadLength] | طول سر فلش | [setRawValue] |
| [ArrowheadWidth] | عرض سر فلش | [setRawValue] |
| [StartAngle] | زاویهٔ شروع یک قطعه یا قوس | [setAngleValue] |
| [EndAngle] | زاویهٔ انتهای یک قطعه یا قوس | [setAngleValue] |

[getType] و [getName] اطلاعات فقط‑خوانی برمی‌گردانند. [getRawValue] و [setRawValue] با یک عدد صحیح در واحدهای هندسی بومی پیش‌تنظیم کار می‌کنند، در حالی که [getAngleValue] و [setAngleValue] با زاویه‌ای بر حسب درجه کار می‌کنند. تعداد، ترتیب، معنای و بازهٔ معتبر تنظیمات به [ShapeType] پیش‌تنظیم‌شده وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

هنگامی که [getType] مقدار [ShapeAdjustmentType.Custom] بر می‌گرداند، API معنای استانداردی را تشخیص نمی‌دهد. [getName]، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست نخورده بگذارید مگر این که معنی و بازهٔ مورد انتظار شناخته شده باشد. حتی برای انواع شناسایی‌شده، پیش از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یکبار رخ می‌دهد یا نه. مقالهٔ [Connector](/slides/fa/python-java/connector/) این وضعیت را با تنظیمات خم‌دار کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده را می‌سازد. برای هر تنظیم پیمایش می‌کند، نام و نوع آن را گزارش می‌دهد، مقادیر مرتبط با اندازه را با [setRawValue] و زاویه‌ها را با [setAngleValue] تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را نگه می‌دارد؛ ستون راست مستطیل گرد، فلش چهارطرفه و قطعه تنظیم‌شده را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # سرصفحه‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم شده اضافه می‌کند.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بررسی نوع معنایی قبل از تغییر مقدار باعث می‌شود کد هدف خود را واضح بیان کند و فرض اینکه یک اندیس خاص همیشه همان معنا را در شکل‌های پیش‌تنظیم متفاوت داشته باشد، جلوگیری شود.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و دوباره‌چین کردن بلافاصله بر مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر بر اندیس‌های گرفته‌شده قبل از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

[addClone] یک کپی مستقل ایجاد می‌کند و به انتهای مجموعه هدف اضافه می‌گذارد. [insertClone] نیز یک کپی می‌سازد اما آن را در اندیس z‑order مشخصی قرار می‌دهد. بارگذاری‌های پذیرندهٔ مختصات، کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ بارگذاری‌های دارای عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلوی اسلاید کلون می‌کند و یک کلون دوم را در پشت وارد می‌کند. تغییرات در هر یک از کلون‌ها شکل منبع را تغییر نمی‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

کلون کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین آن. زمانی که این مقادیر باید یکتا باشند، شناسه‌های منطقی جدید به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کلون یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove] یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مورد در طول پیمایش ایندکس‌دار، از انتها به جلو پیمایش کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام طراحی‌شده دارد را حذف می‌کند. آن شکل را در اندیس جاری می‌خواند، نه یک مورد ثابت در مجموعه، و نیازی به تبدیل نوع غیرضروری ندارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پس از حذف، تعداد اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال غیرمتأثر نسبت به ذخیره‌سازی اندیس‌ها قابل اطمینان‌تر است. همچنین به کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه‌ای که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Hidden] به `True` شکل را در مجموعه نگه می‌دارد اما مانع نمایش آن در نمایش معمولی اسلاید می‌شود. اندیس، قالب‌بندی و محتوای آن برای کد در دسترس می‌ماند، بنابراین مخفی کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مخفی کردن حذف یا امنیت نیست. شیء می‌تواند توسط کاربر یا کد پیدا و دوباره نمایش داده شود و همچنان بخشی از فایل ارائه می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه رنگ‌آمیزی می‌شوند. [reorder] یک شکل موجود را به اندیس هدف می‌برد بدون اینکه آن را کلون کند. اندیس `0` پشت است؛ [size] منهای یک جلوی است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مستطیل ابتدا ساخته می‌شود و در ابتدا پشت بیضی قرار دارد. جابه‌جایی آن به اندیس نهایی آن را به جلو می‌برد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، Z‑order را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند استک مورد نظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای لایهٔ طرح**

اسلایدهای عادی، اسلایدهای لایهٔ طرح و اسلایدهای اصلی دارای مجموعهٔ اشکال جداگانه‌ای هستند. یک شکل در مجموعهٔ لایهٔ طرح همان شیء یک شکل با موقعیت مشابه در اسلاید عادی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک لایهٔ طرح، اشکال لایه را بررسی کنید.

مثال زیر برای هر شکل لایهٔ طرح [FillFormat] و [LineFormat] را می‌خواند بدون این‌که فرض کند هر شکل یک [AutoShape] است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

ویرایش یک لایه می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. پیش از تغییر یک شکل لایه، تعیین کنید آیا یک اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلاید استفاده‌کننده از آن لایه را تست کنید.

## **خروجی یک شکل به SVG**

متد `writeAsSvg` از [Shape] محتوای رندرشدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همسایه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

در حین رندر، ارائه باز بماند. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مالک جریان است و باید آن را ببندد.

## **هم‌راستایی اشکال**

[SlideUtil.alignShapes] می‌تواند همهٔ اشکال یا ایندکس‌های مجموعهٔ انتخاب‌شده را هم‌راستا کند. [ShapesAlignmentType] لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. `align_to_slide` را به `True` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `False` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر هم‌راستا شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید هم‌راستا می‌کند. ارجاع‌های شکل بازگردانده‌شده بلافاصله قبل از هم‌راستایی به اندیس‌های جاریشان تبدیل می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هم‌راستایی موقعیت‌ها را تغییر می‌دهد، نه Z‑order. هم‌راستایی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعریف فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، اندیس‌ها را دوباره محاسبه کنید.

## **وارون کردن یک شکل**

کلاس [ShapeFrame] موقعیت، اندازه، تنظیمات وارونگی افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر [getFlipH] و [getFlipV] از [NullableBool] استفاده می‌کنند: `True` وارونگی را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون وارونگی است.

![شکل قبل از وارونگی](shape_to_be_flipped.png)

مثال تنها مقادیر فریم دیگر را حفظ می‌کند و فقط دو تنظیم وارونگی را تعویض می‌نماید. این مهم است زیرا اختصاص یک [Frame] جدید تمام فریم را جایگزین می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شود.

![شکل پس از وارونگی](flipped_shape.png)

## **سوالات متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش کوتاه‌مدتی که مجموعه قبل از استفاده تغییر نمی‌کند. برای قالب‌های نویسنده‌شده، یک قرارداد معتبر [Name] یا [AlternativeText] را ترجیح دهید؛ برای کارهای interop scoped به اسلاید، از [OfficeInteropShapeId] استفاده کنید.

**آیا مخفی کردن یک شکل آن را از Z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس در مجموعه می‌ماند. می‌تواند یافت، دوباره‌چین، ویرایش یا دوباره قابل مشاهده شود.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

[addClone] کلون را به انتهای مجموعه اضافه می‌کند که جلو Z‑order است. برای انتخاب اندیس اولیه از [insertClone] استفاده کنید یا پس از افزودن تمام اشکال از [reorder] بهره ببرید.

**آیا می‌توانم از یک اندیس ثابت برای شناسایی تنظیم پیش‌تنظیم یک شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً از طریق [GeometryShape.getAdjustments] پیمایش کنید و [AdjustValue.getType] را بررسی کنید؛ هنگامی که همان نوع معنایی بیش از یکبار ظاهر می‌شود، از [AdjustValue.getName] به‌عنوان اطلاعات تکمیلی استفاده کنید.