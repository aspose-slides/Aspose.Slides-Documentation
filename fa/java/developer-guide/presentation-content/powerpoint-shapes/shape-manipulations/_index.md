---
title: مدیریت اشکال ارائه در جاوا
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه interop شکل
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌فرض شکل
- هندسه شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به عنوان SVG
- شکل به SVG
- هم‌ترازی شکل
- چرخاندن شکل
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای جاوا، اشکال ارائه را شناسایی، تنظیم، کلون، حذف، مخفی، دوباره‌مرتب‌سازی، خروجی، هم‌ترازی و چرخاندن کنید."
---
## **نمای کلی**

Aspose.Slides for Java اشکال موجود در یک اسلاید را به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) ترتیب‌دار نشان می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب لایه‌بندی آن‌ها: ایندکس `0` پشت‌ترین شکل است، در حالی که آخرین ایندکس جلوترین شکل است.

این مقاله همان مدل را دنبال می‌کند. ابتدا نحوه شناسایی مطمئن یک شکل و تغییر نقاط تنظیم پیش‌فرض را توضیح می‌دهد، سپس نحوهٔ کلون، حذف، مخفی‌سازی و دوباره‌مرتب‌سازی اشکال را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی در سطح طرح‌بندی، خروجی SVG، هم‌ترازی و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیات مورد نیاز جریان کاری خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره‌مرتب‌سازی یک شکل می‌تواند ایندکس آن را تغییر دهد. بر اساس نحوهٔ ایجاد و نگهداری ارائه، یک شناسه مناسب انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getName--) برای الگوهای کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند ولی تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getAlternativeText--) وقتی توصیف دسترسی یا برچسبی توسط نویسنده پیش از این شکل را شناسایی می‌کند مفید است. این متن برای کاربران قابل مشاهده است، می‌تواند بومی‌سازی یا برای دسترسی بازنویسی شود و یکتا نیست. از استفادهٔ مخفیانهٔ متن دسترسی معنادار به‌عنوان کلید پایگاه داده خودداری کنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و معادل شناسهٔ شکل استفاده‑شده توسط PowerPoint interop است. زمانی که با PowerPoint یکپارچه می‌شوید یا نیاز به مرجع بی‌ابهام در طول عمر یک شکل دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازآفرینی‌شده شکل دیگری است و شناسهٔ مخصوص به خود را دریافت می‌کند.

روش مرتبط [getUniqueId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getUniqueId--) شناسه‌ای با حوزهٔ ارائه برمی‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند بازنشانی شود. نباید به‌عنوان کلید خارجی دائمی رفتار شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه دارید و اعتبارسنجی کنید که شکل مورد انتظار هنوز وجود دارد.

برای مثال عملی خواندن و به‌روزرسانی عنوان و توضیح متنی جایگزین، به مقاله [مدیریت عناوین و توضیحات متنی جایگزین](/slides/fa/java/presentation-accessibility/) مراجعه کنید. از متن جایگزین برای توضیح معنی تصویر به خوانندگان استفاده کنید و آن را جدا از نام‌های شکلی که کد برای یافتن آن‌ها استفاده می‌کند، نگه دارید.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شمارهٔ interop در سطح اسلاید را گزارش می‌دهد. هنگامی که قالب شکل مورد انتظار را نداشته باشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامهٔ کار با شیء اشتباه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

وقتی عملیاتی مختص به نوعی از شکل باشد، قبل از استفاده از اعضای خاص نوع، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روزرسانی می‌کند که شیء نام‌دار یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

اشکال هندسهٔ پیش‌فرض می‌توانند نقاط تنظیمی را افشا کنند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت پیکان یا زاویهٔ قوس را کنترل می‌کنند. به آن‌ها از طریق مجموعهٔ فقط‑خواندنی [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igeometryshape/#getAdjustments--) دسترسی داشته باشید. این مجموعه توسط شکل فراهم می‌شود، اما هر [IAdjustValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/) حاوی مقدار قابل تغییر است.

فقط به یک ایندکس ثابت مجموعه تکیه نکنید. از طریق تنظیمات پیمایش کنید و متد فقط‑خواندنی [getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getType--) را بررسی کنید؛ مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeadjustmenttype/) توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی [getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getName--) اطلاعات شناسایی اضافه می‌دهد و به‌ویژه وقتی پیش‌فرض بیش از یک تنظیم با همان نوع معنایی دارد مفید است.

از متدی استفاده کنید که معنای تنظیم را بازتاب دهد:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ضخامت دم پیکان | `setRawValue` |
| `ArrowheadLength` | طول سر پیکان | `setRawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `setRawValue` |
| `StartAngle` | زاویهٔ شروع یک دایرهٔ قطبی یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاویهٔ پایان یک دایرهٔ قطبی یا قوس | `setAngleValue` |

`getType` و `getName` اطلاعات فقط‑خواندنی برمی‌گردانند. `getRawValue` و `setRawValue` با یک عدد صحیح در واحدهای هندسهٔ بومی پیش‌فرض کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با زاویه برحسب درجه کار می‌کنند. تعداد، ترتیب، معنا و بازهٔ معتبر تنظیمات بستگی به [ShapeType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igeometryshape/#getShapeType--) پیش‌فرض دارد. مقدار معتبر برای یک پیش‌فرض ممکن است برای پیش‌فرض دیگر نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `getType` مقدار `ShapeAdjustmentType.Custom` را برمی‌گرداند، API معنای استانداردی برای آن تشخیص نمی‌دهد. `getName`، نوع پیش‌فرض و مقدار موجود را بررسی کنید و تنظیم را دست نخورده بگذارید مگر این که معنی و بازهٔ مورد انتظار شناخته شده باشد. حتی برای انواع شناخته‌شده، پیش از انتخاب مقدار بررسی کنید آیا همان نوع بیش از یک بار ظاهر می‌شود یا نه. مقالهٔ [Connector](/slides/fa/java/connector/) این وضعیت را با تنظیمات خم شدن کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌فرض را ایجاد می‌کند. تمام تنظیمات را پیمایش می‌کند، نام و نوع آن‌ها را گزارش می‌دهد، مقادیر مربوط به اندازه را از طریق `setRawValue` و زاویه‌ها را از طریق `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون سمت چپ هندسهٔ پیش‌فرض را نگه می‌دارد؛ ستون سمت راست مستطیل گرد تنظیم‌شده، پیکان چهار‑طرفه و دایرهٔ قطبی را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // سرصفحه‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم‌شده اضافه می‌کند.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بررسی نوع معنایی پیش از تغییر مقدار، کد را واضح‌تر می‌کند و از فرض اینکه یک ایندکس خاص در میان اشکال پیش‌فرض مختلف همان معنا را دارد، جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و دوباره‌مرتب‌سازی بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر به ایندکس‌های گرفته‌شده پیش از آن عملیات وابسته نباشید.

### **کلون یک شکل**

[addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) یک کپی مستقل ایجاد می‌کند و به انتهای مجموعه هدف اضافه می‌نماید. [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) نیز یک کپی می‌سازد اما آن را در ایندکس‑z‑order مشخصی قرار می‌دهد. overloadهای پذیرندهٔ مختصات، کلون را بدون تغییر اندازه منتقل می‌کنند؛ overloadهای دارای عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و کلون دوم را در انتها (پشت) درج می‌کند. تغییرات بر هر یک از کلون‌ها بر شکل منبع تأثیری نمی‌گذارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلون محتوا و قالب‌بندی شکل را—including نام و متن جایگزین—کپی می‌کند. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شود، اما کلون همچنان یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مورد مطابق در حین iteration با ایندکس، از انتها به سمت ابتدا پیمایش کنید تا هر ایندکس باقی‌مانده معتبر بماند.

این مثال هر شکل با نام مشخصی را حذف می‌کند. شکل را در ایندکس فعلی می‌خواند، نه یک آیتم ثابت مجموعه، و بدون نیاز به تبدیل غیرضروری شکل عمل می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پس از حذف، تعداد اشکال و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکالی که حذف نشده‌اند، نسبت به ذخیرهٔ ایندکس‌ها قابل اطمینان‌تر است. همچنین به کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه داشته باشید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تحت تأثیر قرار دهد.

### **مخفی‌سازی یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setHidden-boolean-) به `true` شکل را در مجموعه باقی می‌گذارد اما مانع نمایش آن در نمایش اسلاید معمولی می‌شود. ایندکس، قالب‌بندی و محتوا همچنان برای کد در دسترس‌اند، بنابراین مخفی‌سازی برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مخفی‌سازی حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و بخشی از فایل ارائه می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر حسب ترتیب مجموعه نقاشی می‌شوند. [reorder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) یک شکل موجود را به ایندکس هدف بدون کلون کردن منتقل می‌کند. ایندکس `0` پشت است؛ `size() - 1` جلوی است.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مستطیل ابتدا ساخته می‌شود و در ابتدا پشت بیضی قرار دارد. جابجایی آن به ایندکس نهایی، آن را به جلو می‌آورد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، Z‑order را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا درج می‌کند و می‌تواند ترتیب هدف را تغییر دهد.

## **بررسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای معمولی، اسلایدهای طرح‌بندی و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی همان شیء یک شکل مشابه در اسلاید معمولی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک طرح‌بندی، اشکال طرح‌بندی را بررسی کنید.

مثال زیر برای هر شکل طرح‌بندی، [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFillFormat--) و [LineFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getLineFormat--) را می‌خواند بدون اینکه فرض کند هر شکل یک `AutoShape` است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

ویرایش یک طرح‌بندی می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند اثر بگذارد. قبل از تغییر یک شکل طرح‌بندی، تعیین کنید آیا یک اسلاید معمولی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند آزمایش کنید.

## **خروجی SVG برای یک شکل**

[writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) محتوای رندرشدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همسایه.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

در زمان رندر، ارائه باید باز باشد. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، به جای خروجی شکل، اسلاید را خروجی بگیرید. فراخواننده مالک جریان است و باید آن را ببندد.

## **هم‌ترازی اشکال**

متد [SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) نسخه‌های overloadی دارد که یا تمام اشکال یا ایندکس‌های مجموعه انتخاب‌شده را هم‌تراز می‌کند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapesalignmenttype/) لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. مقدار `alignToSlide` را به `true` تنظیم کنید تا لبه‌های اسلاید استفاده شوند؛ به `false` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر هم‌تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید هم‌تراز می‌کند. مراجع شکل بازگردانده‌شده بلافاصله پیش از هم‌ترازی به ایندکس‌های جاری خود تبدیل می‌شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هم‌ترازی موقعیت‌ها را تغییر می‌دهد، نه Z‑order. هم‌ترازی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعریف فواصل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، ایندکس‌ها را دوباره محاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از [NullableBool](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![شکل پیش از چرخاندن](shape_to_be_flipped.png)

مثال همه مقادیر دیگر قاب را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌سازد. این مهم است چون اختصاص یک [Frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جدید، کل قاب را بازنویسی می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

شکل ذخیره‌شده به صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از چرخاندن](flipped_shape.png)

## **پرسش‌های متداول**

**آیا باید از ایندکس مجموعه به‌عنوان شناسهٔ یک شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه پیش از استفاده از ایندکس تغییر نخواهد کرد. برای قالب‌های ایجادشده، یک قرارداد معتبر برای `Name` یا `AlternativeText` ترجیحاً استفاده کنید، یا برای کارهای interop در سطح اسلاید از `OfficeInteropShapeId` بهره ببرید.

**آیا مخفی‌سازی یک شکل آن را از Z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان ایندکس مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره‌مرتب‌سازی، ویرایش یا دوباره نمایان کرد.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی Z‑order است. برای انتخاب ایندکس اولیه از `insertClone` یا پس از افزودن تمام اشکال از `reorder` استفاده کنید.

**آیا می‌توانم از یک ایندکس ثابت برای شناسایی تنظیم پیش‌فرض یک شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌فرض و چیدمان مجموعه. ترجیحاً از طریق `IGeometryShape.getAdjustments` پیمایش کنید و `IAdjustValue.getType` را بررسی کنید؛ وقتی همان نوع معنایی بیشتر از یک بار ظاهر می‌شود، از `IAdjustValue.getName` برای اطلاعات تکمیلی استفاده کنید.