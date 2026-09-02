---
title: مدیریت اشکال ارائه در جاوا
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- تکثیر شکل
- حذف شکل
- مخفی‌کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ شکل interop
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم‌شدهٔ شکل
- هندسهٔ شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به‌صورت SVG
- شکل به SVG
- ترازبندی شکل
- فلیپ شکل
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تنظیم، تکثیر، حذف، مخفی‌کردن، بازنویسی، صادر کردن، ترازبندی و فلیپ کنید با Aspose.Slides برای جاوا."
---
## **بررسی کلی**

Aspose.Slides for Java اشکال موجود در یک اسلاید را به‌صورت یک ‎[IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/)‎ مرتب‌شده نشان می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب لایه‌بندی آن‌ها: شاخص ‎`0`‎ عقب‌ترین شکل است و آخرین شاخص جلوی‌ترین شکل است.

این مقاله بر همین مدل بنا شده است. ابتدا نحوه شناسایی قابل‌اعتماد یک شکل و اصلاح نقاط تنظیم پیش‌تنظیم‌شدهٔ شکل را توضیح می‌دهد، سپس نحوهٔ تکثیر، حذف، مخفی‌کردن و تغییر ترتیب اشکال را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی سطح طرح‌بندی، خروجی SVG، ترازبندی و تنظیمات فلیپ می‌پردازند. هر مثال مستقل است، بدین‌وسیله می‌توانید فقط عملیات‌های مورد نیاز جریان کار خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

شاخص‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مناسب هستند، اما شناسهٔ پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند شاخص آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ نوشتن و نگهداری ارائه انتخاب کنید:

- ‎[Name](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getName--)‎ برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل بررسی است. نام‌ها قابل ویرایش‌اند ولی تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نامگذاری برقرار کنید.
- ‎[AlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getAlternativeText--)‎ زمانی مفید است که توصیف دسترس‌پذیری یا برچسبی که نویسنده اضافه کرده است، پیش از این شکل را شناسایی می‌کند. این متن برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و نیز یکتا نیست. متن دسترس‌پذیری معنادار را به‌عنوان کلید پایگاه‌داده به‌صورت مخفی استفاده نکنید.
- ‎[OfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)‎ یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و با شناسهٔ شکلی که PowerPoint استفاده می‌کند مطابقت دارد. هنگام ادغام با PowerPoint یا زمانی که به یک مرجع واضح در طول حیات یک شکل نیاز دارید از آن استفاده کنید. یک شکل تکثیرشده یا بازساخته یک شکل متفاوت است و شناسهٔ خودش را دریافت می‌کند.

متد مرتبط ‎[getUniqueId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getUniqueId--)‎ یک شناسه با دامنهٔ ارائه برمی‌گرداند، ولی این شناسه برای افزونه‌ها است و می‌تواند بازتخصیص یابد. نباید آن را به‌عنوان کلید خارجی دائم در نظر گرفت. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه داشته و صحت وجود شکل مورد انتظار را تأیید کنید.

مثال زیر با مقایسهٔ دقیق بر پایهٔ نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامهٔ کار با شیء نادرست.

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

هنگامی که عملیاتی مخصوص به نوعی از شکل است، قبل از استفاده از اعضای خاص نوع، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را تنها در صورتی به‌روزرسانی می‌کند که شیء نام‌دار یک ‎[IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/)‎ باشد.

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

## **شناسایی و اصلاح تنظیمات پیش‌تنظیم‌شدهٔ شکل**

اشکال هندسی پیش‌تنظیم‌شده می‌توانند نقاط تنظیمی را در اختیار بگذارند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت تیر یا زاویهٔ قوس را کنترل می‌کند. از طریق مجموعهٔ فقط‑خواندنی ‎[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igeometryshape/#getAdjustments--)‎ به آن دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، ولی هر ‎[IAdjustValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/)‎ شامل یک مقدار است که می‌توان آن را تغییر داد.

فقط به یک شاخص ثابت مجموعه تکیه نکنید. از طریق تنظیمات پیمایش کنید و متد فقط‑خواندنی ‎[getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getType--)‎ را بررسی کنید؛ مقدار ‎[ShapeAdjustmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeadjustmenttype/)‎ توضیح می‌دهد تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی ‎[getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getName--)‎ اطلاعات شناسایی اضافی می‌دهد و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی داشته باشد مفید است.

از متدی استفاده کنید که معنای تنظیم را منعکس می‌کند:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ضخامت دم تیر | `setRawValue` |
| `ArrowheadLength` | طول سر تیر | `setRawValue` |
| `ArrowheadWidth` | عرض سر تیر | `setRawValue` |
| `StartAngle` | زاویهٔ شروع کیک یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاویهٔ انتها کیک یا قوس | `setAngleValue` |

`getType` و `getName` اطلاعات فقط‑خواندنی بازمی‌گردانند. `getRawValue` و `setRawValue` با یک عدد صحیح در واحدهای هندسی بومی پیش‌تنظیم کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با زاویهٔ درجه‌ای کار می‌کنند. تعداد، ترتیب، معنا و بازهٔ معتبر تنظیمات به ‎[ShapeType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igeometryshape/#getShapeType--)‎ پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگری نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `getType` مقدار ‎`ShapeAdjustmentType.Custom`‎ را برمی‌گرداند، API معنای استانداردی برای آن تشخیص نمی‌دهد. `getName`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست‌نخورده بگذارید مگر این‌که معنای مورد انتظار و بازهٔ آن شناخته شود. حتی برای انواع شناخته‌شده هم قبل از انتخاب مقدار، بررسی کنید آیا همان نوع بیش از یک بار ظاهر می‌شود یا نه. مقاله ‎[Connector](/slides/fa/java/connector/)‎ این وضعیت را با تنظیمات خم‌کردن کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و اصلاح‌شدهٔ سه شکل پیش‌تنظیم‌شده را ایجاد می‌کند. تمام تنظیمات را پیمایش می‌کند، نام و نوع را گزارش می‌دهد، مقادیر مرتبط با اندازه را با `setRawValue` تغییر می‌دهد، زاویه‌ها را با `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را نگه می‌دارد؛ ستون راست مستطیل گرد تنظیم‌شده، تیر چهارطرفه و کیک را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // سرعنوان‌های ستون‌های شکل پیش‌فرض و تنظیم‌شده را اضافه می‌کند.
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

بررسی نوع معنایی قبل از تغییر مقدار کد را صریح می‌کند و از فرض اینکه یک شاخص خاص در همهٔ پیش‌تنظیم‌ها معنای یکسانی دارد جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، تکثیر، حذف و بازنویسی بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن نیازی به استفاده از شاخص‌های قبلی ندارید.

### **تکثیر یک شکل**

[addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) یک کپی مستقل ایجاد می‌کند و به‌صورت انتهایی به مجموعه هدف اضافه می‌­شود. [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) نیز یک کپی می‌سازد ولی در شاخص z‑order مشخصی قرار می‌دهد. بارگذاری‌های پذیرش مختصات کپی را بدون تغییر اندازه جابجا می‌کند؛ بارگذاری‌های همراه با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلوی اسلاید تکثیر می‌کند و یک کپی دوم را در عقب وارد می‌کند. تغییرات بر هر دو کپی منجر به تغییر شکل منبع نمی‌شود.

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

تکثیر محتوا و قالب‌بندی شکل را کپی می‌کند، شامل نام و متن جایگزین. هنگام نیاز به یکتایی این مقادیر، شناسه‌های منطقی جدیدی به کپی اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کپی همچنان یک آیتم جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مورد هم‌زمان در طول پیمایش ایندکس‌شده، از انتها به ابتدا عبور کنید تا هر ایندکس باقی‌مانده معتبر بماند.

این مثال تمام اشکالی را که نام تعیین‌شده دارند حذف می‌کند. شکل را در ایندکس جاری می‌خواند، نه یک آیتم ثابت مجموعه، و نیازی به تبدیل نوع غیرضروری شکل ندارد.

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

پس از حذف، شمارش اشکال و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاعات به اشکال تحت‌تاثیر حذف کمتر پایدارند؛ بهتر است به ایندکس‌های ذخیره‌شده به‌جای اشکال مستقیم تکیه نکنید. همچنین به کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی‌کردن یک شکل**

تعیین مقدار ‎[Hidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setHidden-boolean-)‎ به ‎`true`‎ شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش‌نامهٔ عادی جلوگیری می‌کند. ایندکس، قالب‌بندی و محتوای آن برای کد در دسترس باقی می‌مانند، بنابراین مخفی‌کردن برای عناصر اختیاری که ممکن است بعدها بازگردانده شوند مناسب است.

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

مخفی‌کردن حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده به ترتیب مجموعه نقاشی می‌شوند. [reorder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) یک شکل موجود را به یک ایندکس هدف بدون تکثیر منتقل می‌کند. شاخص ‎`0`‎ عقب است؛ ‎`size() - 1`‎ جلو.

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

در ابتدا مستطیل ساخته می‌شود و پشت بیضی قرار می‌گیرد. جابه‌جایی آن به ایندکس نهایی آن را به جلو می‌برد. پس از افزودن یا تکثیر تمام اشکال مرتبط، Z‑Order را نهایی کنید، زیرا این عملیات آیتم‌های جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند پشتهٔ موردنظر را تغییر دهند.

## **بررسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای عادی، اسلایدهای طرح‌بندی و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی همان شیء شکل در اسلاید عادی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط طرح‌بندی، اشکال طرح‌بندی را بررسی کنید.

مثال زیر ‎[FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFillFormat--)‎ و ‎[LineFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getLineFormat--)‎ هر شکل طرح‌بندی را می‌خواند بدون فرض اینکه هر شکل یک ‎`AutoShape`‎ باشد.

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

ویرایش یک طرح‌بندی می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر شکل طرح‌بندی، تعیین کنید آیا اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از این طرح‌بندی استفاده می‌کند را آزمایش کنید.

## **خروجی یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همجوار.

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

در هنگام رندر، ارائه باید باز باشد. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به ترکیب کامل نیاز دارید، اسلاید را به‌جای یک شکل منفرد خروجی بگیرید. صاحب جریان است و باید آن را بسته.

## **ترازبندی اشکال**

متد ‎[SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)‎ گزینه‌های ترازبندی تمام اشکال یا ایندکس‌های انتخاب‌شدهٔ مجموعه را دارد. ‎[ShapesAlignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapesalignmenttype/)‎ لبه، مرکز یا حالت توزیع را مشخص می‌کند. مقدار ‎`alignToSlide`‎ را به ‎`true`‎ تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به ‎`false`‎ تنظیم کنید تا اشکال انتخابی نسبت به یک‌دیگر ترازبندی شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید ترازبندی می‌کند. ارجاعات به شکل‌ها بلافاصله قبل از ترازبندی به ایندکس فعلیشان تبدیل می‌شوند.

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

ترازبندی موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. ترازبندی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعریف فاصله به تعداد کافی شکل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر می‌دهید، ایندکس‌ها را دوباره محاسبه کنید.

## **فلیپ یک شکل**

کلاس ‎[ShapeFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/)‎ موقعیت، اندازه، تنظیمات فلیپ افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر ‎`getFlipH`‎ و ‎`getFlipV`‎ از ‎[NullableBool](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/)‎ استفاده می‌کنند: ‎`True`‎ فلیپ را فعال می‌کند، ‎`False`‎ غیرفعال می‌کند و ‎`NotDefined`‎ حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون فلیپ است.

![The shape before flipping](shape_to_be_flipped.png)

مثال فقط دو تنظیم فلیپ را تغییر می‌دهد و سایر مقادیر ‎Frame‎ را دست‌نخورده می‌گذارد. این مهم است زیرا اختصاص یک ‎[Frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame/)‎ جدید تمام فریم را جایگزین می‌کند.

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

![The shape after flipping](flipped_shape.png)

## **سؤالات متداول**

**آیا باید از شاخص مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه قبل از استفاده از شاخص تغییر نمی‌کند. برای الگوهای نوشته‌شده یک قرارداد معتبر ‎Name یا ‎AlternativeText‎ و برای کارهای interop scoped به ‎OfficeInteropShapeId‎ ترجیح دهید.

**آیا مخفی‌کردن یک شکل آن را از Z‑Order حذف می‌کند؟**

نه. یک شکل مخفی در همان ایندکس مجموعه باقی می‌ماند. می‌توان آن را یافت، بازنویسی، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل تکثیر‌شده جلوی شکل دیگری ظاهر شد؟**

‎`addClone`‎ کپی را به انتهای مجموعه (پشت صحنهٔ Z‑Order) اضافه می‌کند، که جلوی Z‑Order است. برای انتخاب ایندکس اولیه از ‎`insertClone`‎ یا پس از افزودن همهٔ اشکال از ‎`reorder`‎ استفاده کنید.

**آیا می‌توان از یک شاخص ثابت برای شناسایی تنظیم پیش‌تنظیم‌شدهٔ یک شکل استفاده کرد؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چینش مجموعه. ترجیحاً از ‎`IGeometryShape.getAdjustments`‎ پیمایش کنید و ‎`IAdjustValue.getType`‎ را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، از ‎`IAdjustValue.getName`‎ به‌عنوان اطلاعات اضافی استفاده کنید.