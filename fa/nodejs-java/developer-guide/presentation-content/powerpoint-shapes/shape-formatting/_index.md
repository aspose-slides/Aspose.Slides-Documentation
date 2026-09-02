---
title: قالب‌بندی اشکال PowerPoint در JavaScript
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/nodejs-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برجسته ۳بعدی
- افکت چرخش ۳بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی اشکال PowerPoint در JavaScript با استفاده از Aspose.Slides—تنظیم پرکردن، خط و سبک‌های افکت برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل."
---
## **معرفی**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت‌ها به حاشیه‌هایشان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای Node.js از طریق Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش کار را توضیح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. سبک [سبک خط](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک [سبک خط نقطه‌دار](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // حذف پرکردن از شکل مستطیل.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // اعمال قالب‌بندی بر خطوط مستطیل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تنظیم رنگ برای خط مستطیل.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکچ به خطوط شکل**

یک افکت اسکچ باعث می‌شود خط یک شکل شبیه به دست‌نویس ظاهر شود. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) استفاده کنید، برای دسترسی به تنظیمات اسکچ از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/lineformat/) و برای انتخاب مقدار از لیست [LineSketchType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linesketchtype/) از [SketchFormat.setSketchType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sketchformat/) استفاده کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linesketchtype/) اعمال کنید، مقدار اختصاص داده شده به‌صورت صریح را بخوانید و با [LineSketchType.None](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linesketchtype/) افکت را حذف کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب‌بندی خط شکل و قالب اسکچ آن.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکچ.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // خواندن افکت اسکچ اختصاص داده شده مستقیم به شکل.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکچ.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sketchformat/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برسد، از [LineFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/lineformat/) استفاده کنید، `getSketchFormat` را بر روی شی بازگشتی صدا بزنید و سپس متد `getSketchType` آن را فراخوانی کنید. مقدار مؤثر، قالب‌بندی واقعاً پس از حل ارث‌بری اعمال شده را نشان می‌دهد:

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

در زیر سه گزینه برای نوع اتصال آمده است:

* گرد
* میتر
* بویل

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) وصل می‌کند، از تنظیم **گرد** استفاده می‌کند. اما اگر شکل با زوایای تیز رسم می‌کنید، ممکن است گزینه **میتر** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال میتر، بویل و گرد ایجاد شده‌اند:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن سه شکل خودکار از نوع مستطیل.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پرکن برای هر شکل مستطیل.
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

    // تنظیم رنگ برای خط هر مستطیل.
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

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را به یک شکل اعمال کنید. برای مثال می‌توانید دو یا چند رنگ را به‑گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف‌های گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/gradientformat/) در اختیار است، اضافه کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال افکت پر کردن گرادیان به یک بیضی را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع بیضی.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // افزودن دو نقطهٔ توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک طرح دو رنگی—مانند نقاط، خط‌دارها، خطوط متقاطع یا شطرنجی—را به شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده را فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را ارتقا دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، همچنان می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال پر کردن الگو به یک مستطیل را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پرکردن به الگو.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل قرار دهید—در واقع تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا هر حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم که تصویر زیر را دارد:

![تصویر لوتوس](lotus.png)

کد زیر نحوهٔ پر کردن یک شکل با تصویر را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تنظیم نوع پرکردن به تصویر.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تنظیم حالت پر کردن تصویر.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // تنظیم تصویر.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌شدن را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): تراز کاشی‌ها در داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به نقطه) نسبت به مبدا شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به نقطه) نسبت به مبدا شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let firstSlide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیل.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پرکردن شکل به تصویر.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // اختصاص تصویر به شکل.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ ثابت**

در PowerPoint، پر کردن با رنگ ثابت یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن با رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پرکردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال پر کردن رنگ ثابت به یک مستطیل در اسلاید PowerPoint را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پرکردن به Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // تنظیم رنگ پرکردن.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، وقتی پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را بر اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل شفاف‌تر باشد و پس‌زمینه یا اشیای زیرین تا حدی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مؤلفه `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد زیر نحوهٔ اعمال رنگ پر کردن شفاف به یک مستطیل را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیل جامد.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // افزودن یک شکل خودکار مستطیل شفاف بالای شکل جامد.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint چرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک شکل را به‌طور 5 درجه‌ای بچرخانید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع مستطیل.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به‌ میزان 5 درجه.
    shape.setRotation(5);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجسته ۳بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجستهٔ ۳بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) آنها.

برای افزودن افکت‌های برجستهٔ ۳بعدی به یک شکل، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه افکت‌های برجستهٔ ۳بعدی را به یک شکل اعمال کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ایجاد یک نمونه از کلاس Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل به اسلاید.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // تنظیم ویژگی‌های ThreeDFormat شکل.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // ذخیرهٔ ارائه به عنوان فایل PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت برجسته ۳بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش ۳بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش ۳بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) آنها.

برای اعمال چرخش ۳بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. با استفاده از [setCameraType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/lightrig/#setLightType) چرخش ۳بعدی را تعریف کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه افکت‌های چرخش ۳بعدی را به یک شکل اعمال کنید:

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

نتیجه:

![افکت چرخش ۳بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) تعیین می‌کند که یک شکل به‌صورت فردی هنگام نمایش یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این متد به‌تنهایی حالت سیاه‑سفید را فعال نمی‌کند و قالب‌بندی رنگ، خط یا سایر ویژگی‌های شکل را در حالت رنگی نرمال تغییر نمی‌دهد.

از یک مقدار موجود در enumeration [BlackWhiteMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال `Automatic` اجازه می‌دهد برنامهٔ رندر تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به کار می‌برد، `Black` و `White` رنگ واحدی را تحمیل می‌کنند، `Color` رنگ نرمال را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکل‌ایی اختصاص نیافته است.

کد زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‑سفید به‌صورت خاکستری نشان می‌دهد:

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

    // پرکردن نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگی عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این امکان را می‌دهد تا اسلاید با رنگ کامل را حفظ کرده و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا دیگر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال دارای مکان‌گیرها را در [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض برگردانید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // بازنشانی هر شکل در اسلایدی که یک مکان‌گیر در لایه‌ی طرح‌بندی دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

تنها به‌صورت حداقلی. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و به‌صورت قابل‌توجهی حجم اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را که قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پرکردن، خط و تنظیمات افکت‌ها—را مقایسه کنید. اگر تمام مقادیر متناظر یکسان باشند، سبک آن‌ها را یک‌سان در نظر بگیرید و منطقی آنها را گروه‌بندی کنید؛ این کار مدیریت بعدی سبک‌ها را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کپی کنید و قالب‌بندی آن‌ها را هرجا که لازم بود دوباره اعمال کنید.