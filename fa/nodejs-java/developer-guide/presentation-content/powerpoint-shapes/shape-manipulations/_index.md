---
title: مدیریت شکل‌های ارائه در جاوا اسکریپت
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/nodejs-java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- پیدا کردن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه شکل Interop
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌فرض شکل
- هندسه شکل
- قالب‌بندی‌های چیدمان شکل
- شکل به صورت SVG
- تبدیل شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌های ارائه را با Aspose.Slides برای Node.js via Java شناسایی، تنظیم، کلون، حذف، مخفی، بازنویسی، خروجی، تراز و چرخاندن کنید."
---
## **مرور کلی**

Aspose.Slides for Node.js via Java شکل‌ها را بر روی اسلاید به صورت یک [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) مرتب شده نمایش می‌دهد. این مجموعه هم محل یافتن و تغییر شکل‌ها است و هم منبع ترتیب لایه‌بندی آن‌ها: شاخص `0` پشت‌ترین شکل است، در حالی که آخرین شاخص جلوی‌ترین شکل است.

این مقاله بر همین مدل استوار است. ابتدا نحوه شناسایی مطمئن یک شکل و تغییر نقاط تنظیم پیش‌فرض آن را توضیح می‌دهد، سپس نحوه کلون‌گذاری، حذف، مخفی‌سازی و بازنویسی ترتیب شکل‌ها را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی در سطح لایه، خروجی SVG، تراز و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید تنها عملیاتی را که جریان کاری شما به آن نیاز دارد استفاده کنید.

## **شناسایی و یافتن شکل‌ها**

شاخص‌های مجموعه هنگام پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا بازنویسی یک شکل می‌تواند شاخص آن را تغییر دهد. یک شناسه بسته به نحوه‌سازنده و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getname/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند اما تضمینی برای یکتا بودن ندارند، بنابراین اگر کد به آن‌ها وابسته است یک روش نام‌گذاری تعیین کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getalternativetext/) زمانی مفید است که یک توصیف دسترسی یا برچسب ارائه‌شده توسط نویسنده قبلاً شکل را شناسایی می‌کند. این متن برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترسی بازنویسی شود و تضمینی برای یکتا بودن ندارد. متن دسترسی معنادار را به‌صورت ساکن برای کلید پایگاه‌داده استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) یک شناسه فقط‑خواندنی است که درون یک اسلاید یکتا بوده و به شناسهٔ شکل مورد استفاده در PowerPoint interop مربوط می‌شود. هنگام یک‌پارچه‌سازی با PowerPoint یا زمانی که به یک مرجع بدون ابهام در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته، شکل دیگری است و شناسهٔ اختصاصی خود را دریافت می‌کند.

متد مربوطهٔ [getUniqueId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getuniqueid/) شناسه‌ای با دامنهٔ ارائه بازمی‌گرداند، اما این شناسه برای اضافه‑کردن‌های (add‑ins) منظور شده و می‌تواند دوباره اختصاص یابد. نباید به‌عنوان کلید خارجی دائمی در نظر گرفته شود. اگر هویت درازمدت ضروری است، نگاشت را در داده‌های برنامه نگه دارید و اطمینان حاصل کنید که شکل مورد انتظار هنوز موجود است.

مثال زیر با مقایسهٔ دقیق به‌نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نیست، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء نادرست.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

زمانی که عملیاتی مختص یک نوع شکل است، قبل از استفاده از اعضای مخصوص نوع، کلاس زمان اجرا را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی بروزرسانی می‌کند که شیء نام‌گذاری‌شده یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) باشد.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

شکل‌های ژئومتری پیش‌فرض می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مثل اندازهٔ گوشه، نسبت پیکان یا زاویهٔ قوس را کنترل می‌کنند. به آن‌ها از طریق مجموعهٔ فقط‑خواندنی [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/geometryshape/) دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، ولی هر [AdjustValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/adjustvalue/) شامل مقداری است که می‌تواند تغییر یابد.

فقط به یک شاخص ثابت مجموعه وابسته نشوید. از طریق تنظیمات پیمایشی کنید و متد فقط‑خواندنی [getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/adjustvalue/) را بررسی کنید؛ مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapeadjustmenttype/) توصیف می‌کند تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی [getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/adjustvalue/getname/) اطلاعات شناسایی بیشتری فراهم می‌کند و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از متدی استفاده کنید که با معنای تنظیم مطابقت دارد:

| نوع تنظیم | منظور | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | ضخامت دم پیکان | `setRawValue` |
| `ArrowheadLength` | طول سر پیکان | `setRawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `setRawValue` |
| `StartAngle` | زاویهٔ شروع یک دایرهٔ قطعی یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | زاویهٔ پایان یک دایرهٔ قطعی یا قوس | `setAngleValue` |

`getType` و `getName` اطلاعات فقط‑خواندنی بازمی‌گردانند. `getRawValue` و `setRawValue` با عددی در واحدهای ژئومتری بومی پیش‌تنظیم کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با زاویهٔ درجه‌ای کار می‌کنند. عدد، ترتیب، معنا و بازهٔ معتبر تنظیمات به [GeometryShape.getShapeType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/geometryshape/) پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای دیگری نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `getType` مقدار `ShapeAdjustmentType.Custom` را برمی‌گرداند، API معنای معنایی استانداردی را نمی‌شناسد. `getName`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست‌نخورده بگذارید مگر اینکه معنای مورد انتظار و بازهٔ آن شناخته شده باشد. حتی برای انواع شناخته‌شده، پیش از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک بار ظاهر می‌شود یا نه. مقالهٔ [Connector](/slides/fa/nodejs-java/connector/) این وضعیت را با تنظیمات انحنای connector نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده را ایجاد می‌کند. تمام تنظیمات را پیمایش می‌کند، نام و نوع آن‌ها را گزارش می‌دهد، مقادیر مربوط به اندازه را با `setRawValue` و زاویه‌ها را با `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون سمت چپ ژئومتری پیش‌فرض را نگه می‌دارد؛ ستون سمت راست مستطیل گرد تنظیم‌شده، پیکان چهار‑طرفه و دایرهٔ قطعی را نشان می‌دهد.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // سرنویس‌ها را برای ستون‌های پیش‌فرض و تنظیم‌شده شکل اضافه می‌کند.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بررسی نوع معنایی قبل از تغییر مقدار، کد را دربارهٔ نیت خود صریح می‌سازد و از این‌که فرض کنیم یک شاخص خاص در تمام شکل‌های پیش‌تنظیم‌شده همان معنا را دارد، جلوگیری می‌کند.

## **تغییر مجموعهٔ شکل‌ها**

متدهای افزودن، کلون‌گذاری، حذف و بازنویسی بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب شکل‌ها را تغییر دهد، دیگر به شاخص‌های گرفته‌شده قبل از آن عملیات تکیه نکنید.

### **کلون یک شکل**

[addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/addclone/) یک نسخهٔ مستقل ایجاد می‌کند و به انتهای مجموعه هدف اضافه می‌گردد. [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/insertclone/) نیز یک نسخه می‌سازد اما آن را در شاخص z‑order مشخصی قرار می‌دهد. overload‑هایی که مختصات می‌پذیرند، کلون را بدون تغییر اندازه منتقل می‌کنند؛ overload‑هایی با عرض و ارتفاع می‌توانند آن را نیز دوباره‌سازند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و یک کلون دوم را در عقب وارد می‌کند. تغییرات بر روی هر دو کلون، شکل منبع را تغییر نمی‌دهد.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلون‌گذاری محتوا و قالب‌بندی شکل را شامل می‌شود، از جمله نام و متن جایگزین آن. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع استفاده‌شده توسط شکل‌های پیچیده توسط ارائه مدیریت می‌شوند، اما کلون همچنان یک مورد جدید در مجموعه با هویت جدید شکل است.

### **حذف شکل‌ها**

[remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین تطبیق در طول یک حلقهٔ شاخصی، از انتها به سمت ابتدا عبور کنید تا هر شاخص باقی‌مانده معتبر بماند.

این مثال هر شکل با نام تعیین‌شده را حذف می‌کند. شکل حاضر در شاخص جاری را می‌خواند و فرضی دربارهٔ نوع خاص شکل ندارد.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بعد از حذف، تعداد شکل‌ها و شاخص‌های شکل‌های بعدی تغییر می‌کند. ارجاع به شکل‌های بدون تغییر، نسبت به ذخیرهٔ شاخص‌های ثابت قابل اطمینان‌تر است. همچنین به connector‌ها، انیمیشن‌ها و دیگر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی‌سازی یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/sethidden/) بر روی `true` شکل را در مجموعه نگه می‌دارد اما مانع نمایش آن در اسلاید شو عادی می‌شود. شاخص، قالب‌بندی و محتوی آن همچنان برای کد در دسترس است، بنابراین مخفی‌سازی برای عناصری که ممکن است بعداً بازگردانده شوند مناسب است.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مخفی‌سازی حذف یا امنیت نیست. شیء همچنان توسط کاربر یا کد قابل کشف و دوباره نمایان می‌شود و بخشی از فایل ارائه می‌ماند.

### **تغییر Z‑Order**

شکل‌های هم‌پوشانی‑یافته به ترتیب مجموعه رنگ می‌شوند. [reorder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/reorder/) یک شکل موجود را به شاخص هدف می‌برد بدون اینکه کلون شود. شاخص `0` پشت‌ترین است؛ `size() - 1` جلوی‌ترین.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مستطیل ابتدا ساخته می‌شود و در ابتدا پشت بیضی قرار دارد. انتقال آن به شاخص نهایی آن را به جلو می‌برد. پس از افزودن یا کلون‌گذاری تمام شکل‌های مرتبط، ز‑اُردر را نهایی کنید، زیرا این عملیات‌ها موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و ممکن است استک موردنظر شما را تغییر دهند.

## **بازرسی شکل‌ها در اسلایدهای Layout**

اسلایدهای معمولی، اسلایدهای layout و اسلایدهای master مجموعهٔ شکل‌های جداگانه‌ای دارند. یک شکل در مجموعهٔ layout، همان شیء شکل در اسلاید معمولی با موقعیت مشابه نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک layout، شکل‌های layout را بازرسی کنید.

مثال زیر برای هر شکل layout، [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getfillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getlineformat/) را می‌خواند بدون اینکه فرض کند هر شکل یک `AutoShape` است.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

ویرایش یک layout می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تاثیر بگذارد. پیش از تغییر یک شکل layout، تعیین کنید آیا یک اسلاید معمولی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد، و هر اسلایدی که از آن layout استفاده می‌کند را تست کنید.

## **خروجی یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل تنها همان شکل است، نه پس‌زمینهٔ کل اسلاید یا شکل‌های هم‌جوار.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

در حین رندر، ارائه را باز بگذارید. خروجی به قالب‌بندی شکل و منابعی چون فونت‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل جداگانه خروجی بگیرید. مالک جریان و مسئول بستن آن است.

## **تراز کردن شکل‌ها**

متدهای [SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/alignshapes/) می‌توانند همهٔ شکل‌ها یا شاخص‌های انتخابی مجموعه را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapesalignmenttype/) لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. `alignToSlide` را روی `true` قرار دهید تا از لبه‌های اسلاید استفاده شود؛ روی `false` برای تراز نسبی شکل‌های انتخاب‌شده نسبت به یکدیگر.

این مثال سه شکل را به لبهٔ بالا اسلاید align می‌کند. ارجاع‌های شکل‌های بازگشتی بلافاصله قبل از تراز به شاخص‌های فعلیشان تبدیل می‌شوند.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تراز موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. تراز نسبی معمولاً حداقل به دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعیین فاصله به تعداد کافی شکل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، شاخص‌ها را بازمحاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از نوع [NullableBool](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![شکل قبل از چرخش](shape_to_be_flipped.png)

مثال فقط تنظیمات چرخش را تغییر می‌دهد و سایر مقادیر frame را همان‌طور می‌گذارد. این مهم است زیرا اختصاص یک [Frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/setframe/) جدید، کل frame را بازنویسی می‌کند.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

شکل ذخیره‌شده به‌صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از چرخش](flipped_shape.png)

## **سوالات متداول**

**آیا باید از شاخص مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازشی کوتاه‌مدت که مجموعه قبل از استفاده از شاخص تغییر نمی‌کند. برای قالب‌های authored، یک قرارداد معتبر `Name` یا `AlternativeText` را ترجیح دهید، یا برای کارهای interop scoped به اسلاید از `OfficeInteropShapeId` استفاده کنید.

**آیا مخفی‌سازی یک شکل آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی همچنان در مجموعه با همان شاخص باقی می‌ماند. می‌توان آن را پیدا کرد، بازنویسی کرد، ویرایش یا دوباره نمایان کرد.

**چرا یک شکل کلون‌شده در جلو شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوترین لایهٔ Z‑Order است. برای انتخاب شاخص اولیه از `insertClone` استفاده کنید یا پس از افزودن همهٔ شکل‌ها از `reorder` بهره بگیرید.

**آیا می‌توانم از یک شاخص ثابت برای شناسایی تنظیم پیش‌تنظیم شکل استفاده کنم؟**

تنها پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً `GeometryShape.getAdjustments` را پیمایش کنید و `AdjustValue.getType` را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، از `AdjustValue.getName` به‌عنوان اطلاعات تکمیلی استفاده کنید.