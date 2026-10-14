---
title: قالب‌بندی اشکال پاورپوینت در جاوااسکریپت
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/nodejs-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط شکل اسکیچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‌وسفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برجسته‌سازی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اشکال پاورپوینت را در جاوااسکریپت با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

در پاورپوینت، می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل می‌شوند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها به خطوط مرزی‌شان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پر کردن داخلی آنها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای Node.js از طریق Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides، می‌توانید سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. سبک [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه‌ٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

کد زیر نحوه قالب‌بندی یک `AutoShape` مستطیلی را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // پر کردن را از شکل مستطیل حذف کنید.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // قالب‌بندی خطوط مستطیل را اعمال کنید.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // رنگ خط مستطیل را تنظیم کنید.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط شکل شبیه به دست‌نویس باشد. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) استفاده کنید، برای دسترسی به تنظیمات اسکیچ از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) و برای انتخاب مقدار از شمارش [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) از [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) استفاده کنید.

کد جاوااسکریپت زیر نحوه اعمال افکت [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)، خواندن مقدار به‌صورت صریح و حذف افکت با [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به فرمت خط شکل و فرمت اسکیچ آن.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکیچ.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // خواندن افکت اسکیچ اختصاص داده شده مستقیم به شکل.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکیچ.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) برگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) استفاده کنید، `getSketchFormat` را بر روی شیء بازگشتی فراخوانی کنید و سپس متد `getSketchType` آن را صدا بزنید. مقدار مؤثر قالب‌بندی واقعی را پس از حل ارث‌بری نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینهٔ نوع اتصال وجود دارد:

* گرد
* میتر
* بویل

به‌طور پیش‌فرض، وقتی پاورپوینت دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شما شکلی با زوایای تیز ترسیم می‌کنید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد جاوااسکریپت زیر نشان می‌دهد که چگونه سه مستطیل (همانند تصویر بالا) با استفاده از تنظیمات نوع اتصال Meter، Bevel و Round ایجاد شده‌اند:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن سه شکل خودکار از نوع مستطیل.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پر برای هر شکل مستطیل.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // تنظیم عرض خط.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // تنظیم رنگ خط برای هر مستطیل.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // تنظیم سبک اتصال.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // افزودن متن به هر مستطیل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن گرادیان**

در پاورپوینت، پر کردن گرادیان یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را به یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ نقاط توقف گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار از نوع بیضی.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // اضافه کردن دو نقطه توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادرشده متفاوت از آنچه در پاورپوینت دیده می‌شود باشد، به [Choose a Gradient Rendering Style](/slides/fa/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندرینگ را بدون تغییر پر کردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

## **پر کردن الگو**

در پاورپوینت، پر کردن الگو یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد طرحی دو‌رنگ مانند نقطه‌ها، نوارها، خط‌چین‌ها یا شطرنجی را به یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده آن را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. رنگ [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. رنگ [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به الگو.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در پاورپوینت، پر کردن تصویر یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طور مؤثری تصویر به‌عنوان پس‌زمینهٔ شکل استفاده می‌شود.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت مورد نظر دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) از تصویر مورد نظر خود ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

![تصویر لوتوس](lotus.png)

کد جاوااسکریپت زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تنظیم نوع پر کردن به تصویر.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تنظیم حالت پر کردن تصویر.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // تنظیم تصویر.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی‌کردن تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند—`Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): تراز کاشی‌ها را داخل شکل مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به درصد تعریف می‌کند.

نمونهٔ کد زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let firstSlide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار مستطیل.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پر کردن شکل به تصویر.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // اختصاص تصویر به شکل.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ ثابت**

در پاورپوینت، پر کردن رنگ ثابت یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت تک‌رنگ پر می‌کند. این رنگ پشت‌زمینه ساده بدون هیچ گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // تنظیم رنگ پر کردن.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، هنگامی که پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیتی را تنظیم کنید تا شفافیت پر کردن کنترل شود. مقدار شفافیت بالاتر باعث می‌شود شکل شفاف‌تر شود و پس‌زمینه یا اشیای زیرین به‌صورت جزئی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. در اینجا چگونگی انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار مستطیل صلب.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // اضافه کردن یک شکل خودکار مستطیل شفاف بر روی شکل صلب.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به میزان 5 درجه.
    shape.setRotation(5);

    // ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![چرخش شکل](shape-rotation.png)

## **افکت‌های برجسته‌سازی 3D را اضافه کنید**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی 3D را به اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // یک شکل به اسلاید اضافه کنید.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت برجسته‌سازی 3D](3D-bevel-effect.png)

## **افکت‌های چرخش 3D را اضافه کنید**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را به اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به یک اسلاید بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش 3D استفاده کنید.
1. ارائه را ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‌وسفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) مشخص می‌کند که یک شکل فرد چگونه در زمان مشاهده یا پردازش ارائه در حالت سیاه‌وسفید رندر شود. این متد به‌تنهایی نمایش سیاه‌وسفید را فعال نمی‌کند و قالب‌بندی‌های پر کردن، خط یا دیگر ویژگی‌های شکل را در حالت رنگ طبیعی تغییر نمی‌دهد.

از مقداری از شمارش [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال، `Automatic` به برنامه رندر اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به کار می‌گیرد، `Black` و `White` یک رنگ واحد را اعمال می‌کند، `Color` رنگ‌بندی عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‌وسفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطحی برای شکل تعیین نشده است.

کد جاوااسکریپت زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‌وسفید به‌صورت خاکستری نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // پر نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‌وسفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل رنگ پر کردن نارنجی خود را حفظ می‌کند. در جریان کار نمایش سیاه‌وسفید، به دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد یک اسلاید تمام رنگ را حفظ کرده و در عین حال ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌وسفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد جاوااسکریپت زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگهدارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض آنها بازگردانید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // بازنشانی هر شکلی که در اسلاید دارای نگهدارنده‌ای در طرح‌بندی است.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بخش عمده‌ای از فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متاداده ذخیره می‌شوند و تقریباً هیچ حجم اضافه‌ای ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را که قالب‌بندی یکسان دارند در یک اسلاید شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پر، خط و افکت—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک‌های آنها را یکسان در نظر بگیرید و به‌صورت منطقی آن اشکال را گروه‌بندی کنید، که مدیریت سبک‌ها را بعداً ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک مجموعه اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی‌های آنها را در هر جایی که لازم است، دوباره اعمال کنید.