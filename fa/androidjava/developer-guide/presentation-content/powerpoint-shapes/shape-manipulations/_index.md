---
title: مدیریت اشکال ارائه در اندروید
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/androidjava/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل بر روی اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم‌شدهٔ شکل
- هندسهٔ شکل
- قالب‌بندی‌های چیدمان شکل
- شکل به‌صورت SVG
- شکل به SVG
- تراز کردن شکل
- وارونه کردن شکل
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تنظیم، کلون، حذف، مخفی، مرتب‌سازی، خروجی، تراز و وارونه کنید با Aspose.Slides برای اندروید از طریق جاوا."
---
## **نمای کلی**

Aspose.Slides for Android via Java اشکال را بر روی اسلاید به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) مرتب‌شده نمایش می‌دهد. این مجموعه هم محلی است که در آن می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب لایه‌بندی آن‌ها: ایندکس `0` پایین‌ترین شکل است و آخرین ایندکس بالاترین شکل را نشان می‌دهد.

این مقاله بر این مدل استوار است. ابتدا نحوه شناسایی قابل اطمینان یک شکل و اصلاح نقاط تنظیم پیش‌فرض آن را توضیح می‌دهد، سپس نحوهٔ کلون‌کردن، حذف، مخفی‌کردن و تغییر ترتیب اشکال را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی سطح چیدمان، خروجی SVG، ترازبندی و تنظیمات وارونه کردن می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید تنها عملیات مورد نیاز فرایند خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

ایندکس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند ایندکس آن را تغییر دهد. یک شناسه بر اساس نحوهٔ نگارش و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getName--) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در **پنل انتخاب** PowerPoint به‌راحتی قابل بررسی است. نام‌ها قابل ویرایش‌اند و تضمین نمی‌شود یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری ایجاد کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getAlternativeText--) زمانی مفید است که توضیح دسترس‌پذیری یا برچسبی که نویسنده فراهم کرده پیش از این شکل را شناسایی کند. این متن برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و یکتا نیست. متن دسترسی معنادار را به‌صورت بی‌خبر به کلید دیتابیس تبدیل نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا است و به شناسهٔ شکلی که PowerPoint برای تعامل استفاده می‌کند، منطبق می‌شود. هنگام ادغام با PowerPoint یا زمانی که به یک مرجع روشن در طول عمر شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته یک شکل متفاوت است و شناسهٔ مخصوص خود را دریافت می‌کند.

روش مرتبط [getUniqueId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getUniqueId--) یک شناسه با دامنهٔ ارائه باز می‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند دوباره اختصاص یابد. نباید به عنوان یک کلید خارجی دائمی در نظر گرفته شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه دارید و اطمینان حاصل کنید که شکل مورد انتظار هنوز وجود دارد.

برای مثال عملی از خواندن و به‌روزرسانی هم عنوان متن جایگزین و هم توضیح آن، به [Manage Alternative Text Titles and Descriptions](/slides/fa/androidjava/presentation-accessibility/) مراجعه کنید. از متن جایگزین برای توضیح معنای بصری به خوانندگان استفاده کنید و آن را جدا از نام‌های شکلی که کد برای یافتن اشکال استفاده می‌کند، نگه دارید.

مثال زیر با مقایسهٔ دقیق با نام جستجو می‌کند و شناسهٔ interop سطح اسلاید را گزارش می‌دهد. وقتی قالب شکل مورد انتظار را ندارد، کد به جای ادامه با شیء نادرست، همان نتیجه را گزارش می‌کند.

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

هنگامی که عملیاتی مخصوص نوعی شکل است، قبل از استفاده از اعضای خاص نوع، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی که شیء نام‌گذاری شده یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) باشد، به‌روزرسانی می‌کند.

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

## **شناسایی و اصلاح تنظیمات پیش‌فرض شکل**

اشکال هندسی پیش‌تنظیم‌شده می‌توانند نقاط تنظیمی را عرضه کنند که ویژگی‌هایی همچون اندازهٔ گوشه، نسبت پیکان یا زاویهٔ قوس را کنترل می‌کنند. از مجموعهٔ فقط‑خواندنی [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) برای دسترسی به آن‌ها استفاده کنید. خود مجموعه توسط شکل ارائه می‌شود، اما هر [IAdjustValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/) شامل مقداری است که می‌توان آن را تغییر داد.

فقط به یک ایندکس ثابت مجموعه تکیه نکنید. در تنظیمات مرور کنید و متد فقط‑خواندنی [getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getType--) را بررسی کنید، که مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeadjustmenttype/) توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی [getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getName--) اطلاعات شناسایی بیشتری فراهم می‌کند و به‌ویژه هنگامی که یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از متد مقداردهی‌ای که با معنای تنظیم مطابقت دارد استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ضخامت دم پیکان | `setRawValue` |
| `ArrowheadLength` | طول سر پیکان | `setRawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `setRawValue` |
| `StartAngle` | زاویهٔ شروع یک دایره یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاویهٔ پایان یک دایره یا قوس | `setAngleValue` |

`getType` و `getName` اطلاعات فقط‑خواندنی باز می‌گردانند. `getRawValue` و `setRawValue` با یک عدد صحیح در واحدهای هندسی بومی پیش‌تنظیم کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با زاویه‌ای به درجه کار می‌کنند. تعداد، ترتیب، معنای و بازهٔ معتبر تنظیمات به [ShapeType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `getType` مقدار `ShapeAdjustmentType.Custom` را برمی‌گرداند، API معنای معنایی استانداردی را تشخیص نمی‌دهد. `getName`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و مگر اینکه معنای مورد انتظار و بازهٔ آن را بدانید، تنظیم را دست‌نخورده بگذارید. حتی برای نوع‌های شناخته‌شده، قبل از انتخاب مقدار، بررسی کنید که آیا همان نوع بیش از یک بار رخ داده است یا نه. مقالهٔ [Connector](/slides/fa/androidjava/connector/) این وضعیت را با تنظیمات انعطاف‌پذیری اتصال‌گر نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و اصلاح‌شدهٔ سه شکل پیش‌تنظیم‌شده را می‌سازد. در هر تنظیم مرور می‌کند، نام و نوع آن را گزارش می‌دهد، مقادیر مرتبط با اندازه را از طریق `setRawValue` تغییر می‌دهد، زوایا را از طریق `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون سمت چپ هندسهٔ پیش‌فرض را حفظ می‌کند؛ ستون سمت راست مستطیل گرد، پیکان چهارطرفه و دایرهٔ قطعه را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // سرفصل‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم‌شده اضافه می‌کند.
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

بررسی نوع معنایی قبل از تغییر مقدار، کد را در مورد هدفش صریح می‌سازد و از فرض اینکه یک ایندکس مجموعه خاص همیشه معنای یکسانی در اشکال پیش‌تنظیم مختلف دارد، جلوگیری می‌کند.

## **اصلاح مجموعهٔ اشکال**

متدهای افزودن، کلون‌کردن، حذف و ترتیب‌دادن بلافاصله بر روی مجموعه اعمال می‌شوند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن به ایندکس‌های گرفته‑شده قبل از عملیات اعتماد نکنید.

### **کلون‌کردن یک شکل**

[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) یک نسخهٔ مستقل می‌سازد و به انتهای مجموعه هدف اضافه می‌کند. [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) نیز یک نسخه می‌سازد ولی آن را در یک ایندکس z‑order مشخص قرار می‌دهد. Overload‑های پذیرندهٔ مختصات، کلون را بدون تغییر اندازه حرکت می‌دهند؛ overload‑های با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و یک کلون دوم را در انتها (پشت) وارد می‌کند. تغییرات در هر دو کلون، شکل منبع را تحت تأثیر قرار نمی‌دهد.

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

کلون کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین آن. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابعی که توسط اشکال پیچیده استفاده می‌شوند توسط ارائه مدیریت می‌شوند، اما کلون یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مورد در حین پیمایش ایندکس‌شده، از انتها به سمت ابتدا پیمایش کنید تا هر ایندکس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام معینی دارد را حذف می‌کند. شکل را در ایندکس فعلی می‌خواند، نه یک مورد ثابت از مجموعه، و نیازی به تبدیل نوع غیرضروری شکل ندارد.

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

پس از حذف، تعداد اشکال و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکالی که تحت تأثیر حذف نیستند، نسبت به ایندکس‌های ذخیره‌شده قابل اطمینان‌تر است. همچنین اتصال‌گرها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند را در نظر بگیرید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی‌کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) روی `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش اسلاید معمولی جلوگیری می‌کند. ایندکس، قالب‌بندی و محتوا برای کد در دسترس می‌مانند، بنابراین مخفی‌کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

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

مخفی‌کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره نمایش داده شود و همچنان بخشی از پروندهٔ ارائه است.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه رنگ می‌شوند. [reorder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) یک شکل موجود را به یک ایندکس هدف منتقل می‌کند بدون اینکه آن را کلون کند. ایندکس `0` پشت، `size() - 1` جلو است.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مستطیل ابتدا ساخته می‌شود و به‌صورت پیش‌فرض پشت بیضی قرار دارد. انتقال آن به ایندکس نهایی، آن را به جلو می‌برد. بعد از افزودن یا کلون‌کردن تمام اشکال مرتبط، ترتیب z‑order را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند پشتهٔ مورد نظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای چیدمان**

اسلایدهای معمولی، اسلایدهای چیدمان و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ چیدمان همان شیء شکل در اسلاید معمولی با موقعیت مشابه نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک چیدمان، اشکال چیدمان را بررسی کنید.

مثال زیر `FillFormat` و `LineFormat` هر شکل چیدمان را می‌خواند بدون اینکه فرض کند هر شکل یک `AutoShape` است.

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

ویرایش یک چیدمان می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند، تأثیر بگذارد. پیش از تغییر یک شکل چیدمان، تعیین کنید آیا اسلاید معمولی آن را به ارث می‌برد یا شامل یک بازنویسی محلی است و همهٔ اسلایدهای استفاده‌کننده از آن چیدمان را تست کنید.

## **خروجی یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینهٔ تمام اسلاید یا اشکال همسایه.

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

در حین رندر، ارائه باید باز باشد. خروجی به قالب‌بندی شکل و به منابعی همچون قلم‌ها و تصاویر وابسته است. اگر به کل ترکیبیت نیاز دارید، اسلاید را به‌جای شکل فردی خروجی بگیرید. فراخواننده مالک جریان است و باید آن را ببندد.

## **تراز اشکال**

متد [SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) overloadهای مختلفی دارد که یا تمام اشکال یا ایندکس‌های مجموعهٔ انتخاب‌شده را تراز می‌کند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapesalignmenttype/) لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `false` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. ارجاع‌های شکل برگردانده‌شده بلافاصله قبل از تراز به ایندکس‌های فعلیشان تبدیل می‌شوند.

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

تراز موقعیت‌ها را تغییر می‌دهد، نه ترتیب z‑order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعریف فاصله به تعداد کافی شکل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، ایندکس‌ها را بازمحاسبه کنید.

## **وارونه کردن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات وارونه افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از [NullableBool](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/nullablebool/) استفاده می‌کنند: `True` وارونه را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` وضعیت نامعین/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون وارونه است.

![The shape before flipping](shape_to_be_flipped.png)

مثال فقط مقادیر دیگر چارچوب را حفظ کرده و تنها دو تنظیم وارونه را جایگزین می‌کند. این مهم است چون اختصاص یک [Frame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جدید، تمام چارچوب را بازنویسی می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی منعکس می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![The shape after flipping](flipped_shape.png)

## **سؤالات متدوال**

**آیا باید از ایندکس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش کوتاه‌مدتی که مجموعه قبل از استفاده از ایندکس تغییر نخواهد کرد. برای قالب‌های ساخته‌شده ترجیحاً از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای interop در سطح اسلاید `OfficeInteropShapeId` را به‌کار ببرید.

**آیا مخفی‌کردن یک شکل آن را از z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان ایندکس در مجموعه باقی می‌ماند. می‌توان آن را یافت، ترتیب‌داد، ویرایش یا دوباره قابل نمایش کرد.

**چرا یک شکل کلون‌شده جلو شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه (جلو z‑order) اضافه می‌کند. برای انتخاب ایندکس اولیه می‌توان از `insertClone` استفاده کرد یا پس از افزودن تمام اشکال از `reorder` بهره برد.

**آیا می‌توان از یک ایندکس ثابت برای شناسایی تنظیم پیش‌تنظیم یک شکل استفاده کرد؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و ساختار مجموعه. ترجیحاً از `IGeometryShape.getAdjustments` مرور کنید و `IAdjustValue.getType` را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، از `IAdjustValue.getName` به‌عنوان اطلاعات تکمیلی استفاده کنید.