---
title: قالب‌بندی اشکال PowerPoint در JavaScript
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/nodejs-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- چرخاندن شکل
- افکت برجسته‌سازی سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی اشکال PowerPoint در JavaScript با استفاده از Aspose.Slides—تنظیم سبک‌های پر، خط و افکت برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت بر روی کناره‌ها قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تنظیماتی که نحوه پر کردن داخل آنها را کنترل می‌کند، قالب‌بندی کنید.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش کار را نشان می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [line style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [dash style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را قالب‌بندی کنید:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // تنظیم رنگ پر برای شکل مستطیلی.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // اعمال قالب‌بندی به خطوط مستطیل.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // تنظیم رنگ خط مستطیل.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // ذخیره فایل PPTX در دیسک.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The formatted lines in the presentation](formatted-lines.png)

## **قالب‌بندی سبک‌های اتصال**

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به هم متصل می‌کند، از تنظیم **Round** استفاده می‌کند. با این حال، اگر شکل با زوایای تیز رسم می‌کنید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![The join style in the presentation](join-style-powerpoint.png)

کد JavaScript زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```js
    // نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
    let presentation = new aspose.slides.Presentation();
    try {
        // دریافت اولین اسلاید.
        let slide = presentation.getSlides().get_Item(0);

        // افزودن سه AutoShape از نوع Rectangle.
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

        // تنظیم ضخامت خط.
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

        // ذخیره فایل PPTX در دیسک.
        presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را بر یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در ادامه نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/gradientformat/) در دسترس است، اضافه کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک اثر پر کردن گرادیان به یک بیضی اعمال می‌شود:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // افزودن دو نقطه توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // ذخیره فایل PPTX در دیسک.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The ellipse with gradient fill](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما اجازه می‌دهد یک طرح دو‑رنگ—مانند نقطه‌ها، خط‌های افقی، خطوط متقاطع یا شطرنجی—را بر یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده را ارائه می‌دهد که می‌توانید برای بهبود ظاهر ارائه‌های خود بر اشکال اعمال کنید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در ادامه نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک پر کردن الگو به یک مستطیل اعمال می‌شود:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // تنظیم رنگ‌های پس‌زمینه و پیش‌زمینه الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیره فایل PPTX در دیسک.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The rectangle with pattern fill](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طور مؤثر تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در ادامه نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

فرض کنیم فایلی به نام «lotus.png» با تصویر زیر داریم:

![The lotus picture](lotus.png)

کد JavaScript زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تنظیم نوع پر کردن به Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // تنظیم حالت پر کردن تصویر.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // تنظیم تصویر.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ذخیره فایل PPTX در دیسک.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with picture fill](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر—یا `Tile` یا `Stretch`—را تنظیم می‌کند.
- [setTileAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): هم‌راستایی کاشی‌ها در داخل شکل را تعیین می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): تعیین می‌کند آیا کاشی به صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کرده و گزینه‌های کاشی را پیکربندی کنید:

```js
    // نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
    let presentation = new aspose.slides.Presentation();
    try {
        // دریافت اولین اسلاید.
        let firstSlide = presentation.getSlides().get_Item(0);

        // افزودن یک AutoShape مستطیل.
        let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

        // تنظیم نوع پر کردن شکل به Picture.
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

        // ذخیره فایل PPTX در دیسک.
        presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

نتیجه:

![The tile options](tile-options.png)

## **پر کردن رنگ ثابت**

در PowerPoint، پر کردن رنگ ثابت یک گزینه قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک پر کردن رنگ ثابت به یک مستطیل در اسلاید PowerPoint اعمال کنید:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // تنظیم رنگ پر کردن.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // ذخیره فایل PPTX در دیسک.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with solid color fill](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگام استفاده از پر کردن رنگ ثابت، گرادیان، تصویر یا بافت برای اشکال، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان وضوح پر کردن را کنترل کنید. مقدار شفافیت بالاتر شکل را شفاف‌تر می‌کند و اجازه می‌دهد پس‌زمینه یا اشیای زیرین تا حدی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. در ادامه نحوه انجام این کار آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (جزء `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف به یک مستطیل اعمال کنید:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape مستطیل ثابت.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // افزودن یک AutoShape مستطیل شفاف بالای شکل ثابت.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // ذخیره فایل PPTX در دیسک.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The transparent shape](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌دهی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک شکل را به‌صورت ۵ درجه بچرخانید:

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید.
    let slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به میزان 5 درجه.
    shape.setRotation(5);

    // ذخیره فایل PPTX در دیسک.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape rotation](shape-rotation.png)

## **اضافه‌کردن افکت‌های برجسته‌سازی سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی سه‌بعدی را بر اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) اعمال کنید.

برای اضافه‌کردن افکت‌های برجسته‌سازی سه‌بعدی به یک شکل، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه افکت‌های برجسته‌سازی سه‌بعدی را بر یک شکل اعمال کنید:

```js
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

    // ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The 3D bevel effect](3D-bevel-effect.png)

## **اضافه‌کردن افکت‌های چرخش سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش سه‌بعدی را بر اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) اعمال کنید.

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش سه‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه افکت‌های چرخش سه‌بعدی را بر یک شکل اعمال کنید:

```js
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

    // ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The 3D rotation effect](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگه‌دارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض بازگردانید:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // بازنشانی هر شکلی در اسلاید که یک نگهدارنده در چیدمان دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا قالب‌بندی اشکال بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صورت حداقل. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ‌گونه حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را که قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پر، خط و افکت—را مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را در یک گروه قرار دهید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شوند؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک مجموعه اسلایدهای الگو یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم باشد مجدداً اعمال کنید.