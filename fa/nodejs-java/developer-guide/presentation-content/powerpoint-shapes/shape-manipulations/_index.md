---
title: مدیریت اشکال ارائه در جاوا اسکریپت
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/nodejs-java/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- قالب‌های چینش شکل
- شکل به صورت SVG
- تبدیل شکل به SVG
- هم‌ترازی شکل
- معکوس کردن شکل
- PowerPoint
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، کلون، حذف، مخفی، دوباره ترتیب دهید، صادر کنید، هم‌ترازی کنید و معکوس کنید با Aspose.Slides برای Node.js از طریق Java."
---
## **مروری**

Aspose.Slides برای Node.js از طریق Java اشکال موجود در یک اسلاید را به صورت یک [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) مرتب نمایش می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و ویرایش کنید و هم منبع ترتیب چیدمان آن‌ها است: اندیس `0` شکل پشت‌ترین است، در حالی که آخرین اندیس شکل جلوی‌ترین است.

این مقاله این مدل را دنبال می‌کند. ابتدا نحوه شناسایی یک شکل به‌صورت قابل اطمینان توضیح داده می‌شود، سپس نشان می‌دهد چگونه می‌توان شکل‌ها را کلون، حذف، مخفی و دوباره ترتیب داد. بخش‌های نهایی به قالب‌بندی سطح طرح بندی، خروجی SVG، هم‌ترازی و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که جریان کاری‌تان به آن نیاز دارد، استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره ترتیب دادن یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ ایجاد و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getname/) برای قالب‌های کنترل‌شده توسط توسعه‌دهندگان مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل مشاهده است. نام‌ها قابل ویرایشند و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getalternativetext/) زمانی مفید است که توضیح دسترسی یا برچسبی که توسط نویسنده اضافه شده، قبلاً شکل را شناسایی می‌کند. این متن برای کاربران قابل مشاهده است، ممکن است محلی‌سازی یا برای دسترسی بازنویسی شود و تضمین یکتایی ندارند. متن دسترسی معنادار را به‌صورت بی‌صدا به عنوان کلید پایگاه داده استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و به شناسهٔ شکلی که PowerPoint برای ارتباط استفاده می‌کند، متناظر است. وقتی با PowerPoint یکپارچه می‌شوید یا به یک مرجع غیرقابل ابهام در طول عمر یک شکل نیاز دارید، از آن استفاده کنید. یک شکل کلون‌شده یا دوباره‌ساخته، شکل متفاوتی است و شناسهٔ خود را دریافت می‌کند.

متد مرتبط [getUniqueId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getuniqueid/) یک شناسه با دامنهٔ ارائه باز می‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند مجدداً اختصاص یابد. نباید آن را به‌عنوان کلید خارجی دائمی در نظر گرفت. اگر هویت طولانی‌مدت ضروری است، نگاشتها را در داده‌های برنامه نگه داشته و اعتبارسنجی کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتایج را گزارش می‌کند به جای اینکه با شیء اشتباه ادامه دهد.

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

هنگامی که عملیاتی به یک نوع شکل خاص محدود می‌شود، قبل از استفاده از اعضای نوع‑خصوصی، کلاس زمان اجرا را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌برده یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) باشد.

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

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و دوباره‌ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر بر اندیس‌های ثبت‑شده قبل از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

[addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/addclone/) یک کپی مستقل ایجاد کرده و آن را به انتهای مجموعه هدف اضافه می‌کند. [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/insertclone/) نیز یک کپی می‌سازد اما آن را در یک اندیس z‑order مشخص قرار می‌دهد. overloadهایی که مختصات را می‌پذیرند، کلون را بدون تغییر اندازه‌اش جابه‌جا می‌کنند؛ overloadهایی با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و یک کلون دوم را در عقب وارد می‌کند. تغییرات روی هر دو کلون، شکل منبع را تغییر نمی‌دهد.

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

کلون کردن محتوا و قالب‌بندی شکل را—including نام و متن جایگزین—کپی می‌کند. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدید به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شود، اما یک کلون همچنان یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین تطبیق در طول یک iteration اندیس‌دار، از انتها به سمت ابتدا پیمایش کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام مشخصی داشته باشد را حذف می‌کند. شکل را در اندیس جاری می‌خواند و فرضی به‌خصوص دربارهٔ نوع شکل ندارد.

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

پس از حذف، تعداد اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال بدون تغییر نسبت به اندیس‌های ذخیره‌شده قابل اطمینان‌تر است. همچنین به متصل‌کننده‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/sethidden/) بر `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش اسلاید عادی جلوگیری می‌کند. اندیس، قالب‌بندی و محتوای آن برای کد قابل دسترس باقی می‌مانند، بنابراین مخفی کردن برای عناصر اختیاری که ممکن است بعدها بازگردانده شوند مناسب است.

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

مخفی کردن حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و بخشی از فایل ارائه باقی می‌ماند.

### **تغییر ترتیب Z**

اشکال هم‌پوشانی‌شده به ترتیب مجموعه رنگ می‌شوند. [reorder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/reorder/) یک شکل موجود را به یک اندیس هدف بدون کلون کردن منتقل می‌کند. اندیس `0` پشت است؛ `size() - 1` جلو.

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

مستطیل ابتدا ایجاد می‌شود و به‌طور پیش‌فرض پشت بیضی قرار دارد. جابه‌جایی آن به اندیس نهایی، آن را به جلو می‌برد. پس از افزودن یا کلون تمام اشکال مرتبط، ترتیب Z را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند پشتهٔ موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای قالب**

اسلایدهای معمولی، اسلایدهای قالب و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ قالب، همان شیء شکل مشابه در اسلاید معمولی نیست. وقتی نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک قالب دارید، اشکال قالب را بررسی کنید.

مثال زیر [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getfillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getlineformat/) هر شکل قالب را می‌خواند بدون اینکه فرض کند هر شکل یک `AutoShape` است.

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

ویرایش یک قالب می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. پیش از تغییر یک شکل قالب، تعیین کنید آیا یک اسلاید معمولی شیء را به ارث می‌برد یا حاوی بازنویسی محلی است و هر اسلایدی که از آن قالب استفاده می‌کند را تست کنید.

## **خروجی یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همجوار.

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

هنگام رندر ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد خروجی بگیرید. فراخواننده مالک جریان است و باید آن را ببندد.

## **هم‌ترازی اشکال**

متدهای [SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/alignshapes/) می‌توانند یا تمام اشکال یا اندیس‌های انتخاب‌شدهٔ مجموعه را هم‌تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapesalignmenttype/) لبه، مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را بر `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ بر `false` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یک‑دیگر هم‌تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید هم‌تراز می‌کند. ارجاع‌های شکل بازگردانده‌شده بلافاصله قبل از هم‌ترازی به اندیس‌های فعلی خود تبدیل می‌شوند.

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

هم‌ترازی مکان‌ها را تغییر می‌دهد، نه ترتیب Z. هم‌ترازی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعریف فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر می‌دهید، اندیس‌ها را دوباره محاسبه کنید.

## **معکوس کردن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از [NullableBool](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

پیشنهاد ارائه زیر شامل یک شکل بدون چرخش است.

![شکل پیش از معکوس کردن](shape_to_be_flipped.png)

این مثال همه مقادیر فریم دیگر را همان‌جا نگه می‌دارد و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است زیرا اختصاص یک [Frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/setframe/) جدید تمام فریم را بازنویسی می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شوند.

![شکل پس از معکوس کردن](flipped_shape.png)

## **سوالات متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که قبل از استفاده از اندیس، مجموعه تغییر نمی‌کند، مناسب است. برای قالب‌های نویسنده‌شده یک قرارداد معتبر `Name` یا `AlternativeText` را ترجیح دهید، یا برای کارهای interop scoped به اسلاید `OfficeInteropShapeId` را استفاده کنید.

**آیا مخفی کردن یک شکل آن را از ترتیب Z حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس مجموعه باقی می‌ماند. می‌تواند پیدا شود، دوباره‌ترتیب شود، ویرایش شود یا دوباره قابل مشاهده شود.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوترین موقعیت در ترتیب Z است. برای انتخاب اندیس اولیه از `insertClone` استفاده کنید یا پس از افزودن همهٔ اشکال از `reorder` بهره بگیرید.