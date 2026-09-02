---
title: مدیریت اشکال ارائه در اندروید
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/androidjava/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- مخفی‌سازی شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ شکل Interop
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌فرض شکل
- هندسه شکل
- قالب‌بندی‌های چیدمان شکل
- شکل به‌صورت SVG
- شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تنظیم، کلون، حذف، مخفی‌سازی، ترتیب‌دهی مجدد، صادرات، تراز و چرخاندن کنید با Aspose.Slides برای اندروید از طریق جاوا."
---
## **بررسی کلی**

Aspose.Slides for Android via Java اشکال موجود در یک اسلاید را به‌صورت یک ‎[IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/)‎ مرتب نمایش می‌دهد. این مجموعه هم محل یافتن و ویرایش اشکال است و هم منبع ترتیب لایه‑بندی آن‌ها: اندیس `0` به‌معنای پشت‌ترین شکل است و آخرین اندیس به‌معنای جلوی‌ترین شکل.

این مقاله بر این مدل استوار است. ابتدا نحوه شناسایی قابل‌اعتماد یک شکل و تغییر نقطه تنظیمات از پیش تعریف‌شدهٔ آن را توضیح می‌دهد، سپس نحوهٔ کلون، حذف، مخفی‌سازی و تغییر ترتیب شکل‌ها را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی در سطح طرح‌بندی، خروجی SVG، ترازکردن و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید تنها عملیاتی را که جریان کاری‌تان نیاز دارد، استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. شناسه‌ای متناسب با نحوهٔ ساخت و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getName--) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در **پنل انتخاب** PowerPoint به‌راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند اما تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک کنوانسیون نام‌گذاری اتخاذ کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getAlternativeText--) زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسبی که توسط نویسنده افزوده شده، پیشاپیش شکل را شناسایی کند. این متن برای کاربران قابل دیدن است، می‌تواند بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و یکتایی تضمین نمی‌شود. متن دسترس‌پذیری معنادار را به‌صورت ساکت به‌عنوان کلید دیتابیس استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) یک شناسهٔ فقط‑خواندنی است که در داخل یک اسلاید یکتا بوده و با شناسهٔ شکل مورد استفاده در PowerPoint Interop مطابقت دارد. زمانی که با PowerPoint ادغام می‌کنید یا نیاز به مرجع واضح در طول عمر یک شکل دارید، از آن استفاده کنید. یک شکل کلون‑شده یا دوباره‌ساخته، شکل دیگری است و شناسهٔ مخصوص به خود را دریافت می‌کند.

متد مرتبط ‎[getUniqueId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getUniqueId--) شناسه‌ای با دامنهٔ ارائه برمی‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند مجدداً تخصیص یابد. نباید آن را به‌عنوان کلید خارجی دائمی در نظر گرفت. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه ذخیره کنید و اطمینان حاصل کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و ‎ID‎ اسکُوپ اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

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

هنگامی که عملیاتی مختص به یک نوع شکل است، قبل از استفاده از اعضای نوع‑خاص، اینترفیس را بررسی کنید. این مثال تنها در صورتی که شیء نام‌دار یک ‎[IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/)‎ باشد، متن و متن جایگزین را به‌روز می‌کند.

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

اشکال هندسی پیش‌تنظیم‌شده می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های پیکان یا زوایای قوس را کنترل می‌کنند. برای دسترسی به آن‌ها از مجموعهٔ فقط‑خواندنی ‎[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--)‎ استفاده کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر ‎[IAdjustValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/)‎ حاوی مقدار قابل تغییر است.

فقط به یک اندیس ثابت مجموعه تکیه نکنید. در تنظیمات مرور کنید و متد فقط‑خواندنی ‎[getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getType--)‎ را بررسی کنید؛ مقدار ‎ShapeAdjustmentType‎ توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی ‎[getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getName--)‎ اطلاعات شناسایی تکمیلی فراهم می‌کند و به‌ویژه وقتی یک پیش‌تنظیم چند تنظیم با همان نوع معنایی دارد، مفید است.

از متد مقداری استفاده کنید که با معنی تنظیم منطبق باشد:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ضخامت دم پیکان | `setRawValue` |
| `ArrowheadLength` | طول سر پیکان | `setRawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `setRawValue` |
| `StartAngle` | زاویهٔ شروع دایره یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاویهٔ پایان دایره یا قوس | `setAngleValue` |

`getType` و `getName` فقط‑خواندنی هستند. `getRawValue` و `setRawValue` با یک عدد در واحدهای هندسی بومی پیش‌تنظیم کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با زاویه بر حسب درجه کار می‌نمایند. تعداد، ترتیب، معنی و بازهٔ معتبر تنظیمات به ‎ShapeType‎ پیش‌تنظیم‑شده وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است، ممکن است برای پیش‌تنظیم دیگری نامعتبر یا اثر متفاوتی داشته باشد.

هنگامی که ‎`getType`‎ مقدار ‎`ShapeAdjustmentType.Custom`‎ را برمی‌گرداند، API معنای معنایی استانداردی را تشخیص نمی‌دهد. ‎`getName`‎، نوع پیش‌تنظیم و مقدار فعلی را بررسی کنید و تنظیم را دست نخورده بگذارید مگر اینکه معنی و بازهٔ مورد انتظار شناخته شده باشد. حتی برای انواع شناخته‌شده، قبل از انتخاب مقدار، بررسی کنید که آیا همان نوع بیش از یک بار رخ می‌دهد یا نه. مقاله ‎[Connector](/slides/fa/androidjava/connector/)‎ این وضعیت را با تنظیمات خم‌کاری‌اتصالات نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده را می‌سازد. برای هر تنظیم، نام و نوع آن را گزارش می‌کند، مقادیر مرتبط با اندازه را با `setRawValue` و زوایا را با `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسه پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد، پیکان چهار‌سویه و دایرهٔ شعاعی تنظیم‌شده را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // سرعنوان‌های ستون‌های پیش‌فرض و تنظیم‌شده شکل‌ها را اضافه می‌کند.
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

بررسی نوع معنایی قبل از تغییر مقدار، کد را در مورد قصدش واضح می‌سازد و از فرض اینکه یک اندیس خاص در همهٔ پیش‌تنظیم‌ها همان معنی را دارد، جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و تغییر ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر به اندیس‌های ثبت‑شده پیش از آن عمل نباید تکیه کرد.

### **کلون یک شکل**

[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) یک کپی مستقل می‌سازد و به انتهای مجموعه مقصد اضافه می‌کند. [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) نیز یک کپی می‌سازد اما آن را در اندیس z‑order مشخصی قرار می‌دهد. بارگذاری‌های پذیرفتن مختصات کپی را بدون تغییر اندازه حرکت می‌دهند؛ بارگذاری‌های پذیرندهٔ عرض و ارتفاع می‌توانند اندازهٔ آن را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را در جلو کلون می‌کند و یک کلون دوم را در پشت درج می‌کند. تغییرات روی هر دو کلون منبع شکل را تحت تأثیر قرار نمی‌دهد.

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

کلون محتوا و قالب‌بندی شکل را کپی می‌کند، شامل نام و متن جایگزین. زمانی که این مقادیر باید یکتا باشند، شناسه‌های منطقی جدید به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما کلون یک آیتم جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مطابقت طی iteration بر اساس اندیس، از انتها به جلو عبور کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال تمام اشکالی را که نام معین دارند حذف می‌کند. شکل را در اندیس جاری می‌خواند، نه یک آیتم ثابت مجموعه، و شکل را بدون نیاز به cast اضافی استفاده می‌کند.

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

پس از حذف، شمارش اشکال و اندیس‌های اشکال پسین تغییر می‌کند. مراجع به اشکال بدون تغییر نسبت به اندیس‌های ذخیره‌شده قابل‌اعتمادتر هستند. همچنین اتصالات، انیمیشن‌ها و ویژگی‌های دیگر ارائه که ممکن است به شیء حذف‌شده ارجاع دهند را در نظر بگیرید؛ حذف یک شکل قابل‌مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی‌سازی یک شکل**

تنظیم ‎[Hidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setHidden-boolean-)‎ به `true` شکل را در مجموعه نگه می‌دارد اما مانع نمایش آن در نمایش معمولی اسلاید می‌شود. اندیس، قالب‌بندی و محتوای آن برای کد در دسترس می‌مانند، بنابراین مخفی‌سازی برای عناصر اختیاری که ممکن است بعدها دوباره بازگردانده شوند، مناسب است.

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

مخفی‌سازی حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره نمایان شود و همچنان بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه نقاشی می‌شوند. ‎[reorder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‎ یک شکل موجود را به یک اندیس هدف بدون کلون کردن منتقل می‌کند. اندیس `0` پشت‌ترین است؛ `size() - 1` جلوی‌ترین.

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

ابتدا مستطیل ایجاد می‌شود و ابتدا پشت بیضی قرار می‌گیرد. انتقال آن به اندیس نهایی، آن را به جلو می‌آورد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، Z‑Order را نهایی کنید؛ زیرا این عملیات آیتم‌های جدیدی را به مجموعه اضافه یا درج می‌کنند و می‌توانند پشتهٔ موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای عادی، اسلایدهای طرح‌بندی و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی همان شیء شکل در اسلاید عادی نیست. وقتی نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک طرح‌بندی دارید، اشکال طرح‌بندی را بررسی کنید.

مثال زیر برای هر شکل طرح‌بندی ‎[FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getFillFormat--)‎ و ‎[LineFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getLineFormat--)‎ را می‌خواند بدون این که فرض کند هر شکل یک `AutoShape` است.

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

ویرایش یک طرح‌بندی می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند، تأثیر بگذارد. قبل از تغییر یک شکل طرح‌بندی، تعیین کنید آیا یک اسلاید عادی شیء را به ارث می‌برد یا دارای بازنویسی محلی است و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند را آزمون کنید.

## **صادرات یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) محتوای رندر‌شدهٔ یک شکل را به یک stream می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ کامل اسلاید یا اشکال همسایه.

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

در زمان رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی مانند فونت‌ها و تصویرها وابسته است. اگر به کل ترکیب‌بندی نیاز دارید، به‌جای یک شکل منفرد اسلاید را صادر کنید. فراخواننده مالک stream است و باید آن را ببندد.

## **تراز کردن اشکال**

متد ‎[SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)‎ می‌تواند تمام اشکال یا اندیس‌های مجموعهٔ انتخابی را تراز کند. ‎[ShapesAlignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapesalignmenttype/)‎ نوع لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. مقدار `alignToSlide` را به `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `false` تنظیم کنید تا اشکال منتخب نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید تراز می‌کند. ارجاع‌های شکل برگشتی بلافاصله قبل از تراز به اندیس‌های فعلی‌شان تبدیل می‌شوند.

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

تراز کردن موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعریف فواصل به تعداد کافی شکل نیاز دارد. اگر پیش از فراخوانی متد مجموعه را تغییر می‌دهید، اندیس‌ها را مجدداً محاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس ‎[ShapeFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/)‎ موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از ‎[NullableBool](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/nullablebool/)‎ استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت ناشناخته/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![The shape before flipping](shape_to_be_flipped.png)

مثال تنها مقادیر فریم دیگر را حفظ می‌کند و تنها دو تنظیم چرخش را جایگزین می‌نماید. این مهم است زیرا اختصاص یک ‎[Frame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)‎ جدید، فریم کامل را بازنویسی می‌کند.

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

شکل ذخیره‌شده به‌صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شود.

![The shape after flipping](flipped_shape.png)

## **پرسش‌های متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه پیش از استفاده از اندیس تغییر نمی‌کند. برای قالب‌های نوشته‌شده ترجیحاً از یک کنوانسیون معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای اسکوپ‌دار اسلاید از `OfficeInteropShapeId`.

**آیا مخفی‌سازی یک شکل آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس در مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره ترتیب داد، ویرایش کرد یا دوباره نمایان ساخت.

**چرا یک شکل کلون‌شده در جلو شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی Z‑Order است. برای انتخاب اندیس اولیه از `insertClone` استفاده کنید یا پس از افزودن تمام اشکال از `reorder` بهره ببرید.

**آیا می‌توانم از یک اندیس ثابت برای شناسایی تنظیم پیش‌تنظیم‌شدهٔ یک شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چینش مجموعه. ترجیحاً به ‎`IGeometryShape.getAdjustments`‎ مرور کنید و `IAdjustValue.getType` را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، از `IAdjustValue.getName` به عنوان اطلاعات تکمیلی استفاده کنید.