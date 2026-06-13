---
title: مدیریت اشکال ارائه در جاوا اسکریپت
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/nodejs-java/shape-manipulations/
keywords:
- اشکال PowerPoint
- اشکال ارائه
- اشکال در اسلاید
- یافتن اشکال
- کلون کردن اشکال
- حذف اشکال
- مخفی کردن اشکال
- تغییر ترتیب اشکال
- دریافت شناسه Interop اشکال
- متن جایگزین اشکال
- فرمت‌های چیدمان اشکال
- اشکال به‌صورت SVG
- تبدیل اشکال به SVG
- هم‌راستای اشکال
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از جاوا اسکریپت و Aspose.Slides برای Node.js via Java اشکال را ایجاد، ویرایش و بهینه‌سازی کنید و ارائه‌های PowerPoint با عملکرد بالا را تولید کنید."
---
## **مرور کلی**

این مقاله نحوه کار با اشکال در ارائه‌ها با Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چطور یک شکل را در یک اسلاید پیدا کنید، کپی (کلون) کنید، حذف کنید، مخفی کنید، ترتیب آن را تغییر دهید، شناسه Interop شکل را دریافت کنید و متن جایگزین برای شناسایی و پردازش‌های بعدی تنظیم کنید.

همچنین پوشش می‌دهد چطور فرمت‌های چیدمان برای اشکال را به دست آورید، یک شکل را به‌صورت SVG رندر کنید، اشکال را در یک اسلاید هماهنگ کنید و از ویژگی‌های flip برای معکوس افقی و عمودی استفاده کنید. علاوه بر این، مقاله شامل یک بخش کوتاه FAQ درباره ترکیب اشکال، ترتیب لایه‌ها و قفل‌کردن شکل است.

## **پیدا کردن شکل در اسلاید**
این موضوع تکنیک ساده‌ای را برای آسان‌تر کردن یافتن یک شکل خاص در اسلاید بدون استفاده از شناسه داخلی آن توضیح می‌دهد. مهم است که بدانید فایل‌های ارائه PowerPoint تنها با یک شناسهٔ منحصر به‌فرد داخلی می‌توانند اشکال را شناسایی کنند. برای توسعه‌دهندگان پیدا کردن یک شکل با استفاده از این شناسه داخلی می‌تواند دشوار باشد. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متنی جایگزین (Alt Text) هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن یک شکل خاص از متن جایگزین استفاده کنند. می‌توانید در MS PowerPoint متن جایگزین برای اشیائی که قصد تغییر آن‌ها را در آینده دارید، تعریف کنید.

پس از تنظیم متن جایگزین برای هر شکل دلخواه، می‌توانید همان ارائه را با Aspose.Slides for Node.js via Java باز کنید و از طریق تمام اشکال اضافه شده به اسلاید عبور کنید. در هر تکرار می‌توانید متن جایگزین شکل را بررسی کنید و شکل دارای متن جایگزین مطابقت یافته، همان شکل مورد نظر شما خواهد بود. برای نمایش بهتر این تکنیک، ما روشی به نام [findShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) ایجاد کرده‌ایم که این کار را برای پیدا کردن یک شکل خاص در اسلاید انجام می‌دهد و سپس آن شکل را برمی‌گرداند.

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نمایان می‌کند
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // متن جایگزین شکلی که باید یافت شود
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **کلون کردن شکل**
برای کلون کردن یک شکل به اسلاید با Aspose.Slides for Node.js via Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را با استفاده از ایندکس آن به‌دست آورید.
3. به مجموعهٔ شکل‌های اسلاید منبع دسترسی پیدا کنید.
4. اسلاید جدیدی به ارائه اضافه کنید.
5. اشکال را از مجموعهٔ شکل‌های اسلاید منبع به اسلاید جدید کلون کنید.
6. ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مثال زیر یک گروه شکل را به اسلاید اضافه می‌کند.

```javascript
// یک شیء از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف شکل**
Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد هر شکل را حذف کنند. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. شکل با متن جایگزین خاص را پیدا کنید.
4. شکل را حذف کنید.
5. فایل را روی دیسک ذخیره کنید.

```javascript
// شیء Presentation را ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن شکل خودکار از نوع مستطیل
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // ذخیرهٔ ارائه روی دیسک
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مخفی کردن شکل**
Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد هر شکل را مخفی کنند. برای مخفی کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. شکل با متن جایگزین خاص را پیدا کنید.
4. شکل را مخفی کنید.
5. فایل را روی دیسک ذخیره کنید.

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن شکل خودکار از نوع مستطیل
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // ذخیرهٔ ارائه روی دیسک
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر ترتیب اشکال**
Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد ترتیب اشکال را تغییر دهند. تغییر ترتیب مشخص می‌کند کدام شکل در جلو و کدام شکل در پشت قرار می‌گیرد. برای تغییر ترتیب اشکال در هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. یک شکل اضافه کنید.
4. متنی در فریم متن شکل اضافه کنید.
5. شکل دیگری با همان مختصات اضافه کنید.
6. ترتیب اشکال را تغییر دهید.
7. فایل را روی دیسک ذخیره کنید.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دریافت شناسه Interop شکل**
Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد شناسهٔ منحصر به‌فرد یک شکل در محدودهٔ اسلاید را دریافت کنند، بر خلاف روش [getUniqueId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getUniqueId--) که شناسهٔ منحصر به‌فرد را در محدودهٔ ارائه بر می‌گرداند. متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) به کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) اضافه شده است. مقداری که توسط متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) برگردانده می‌شود، متناظر با مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. در زیر نمونه کد آورده شده است.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // دریافت شناسهٔ منحصر به‌فرد شکل در محدودهٔ اسلاید
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم متن جایگزین برای شکل**
Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد AlternateText هر شکل را تنظیم کنند.
اشکال در یک ارائه می‌توانند با استفاده از متد [AlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) یا [Shape Name](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) متمایز شوند.
متدهای [setAlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getAlternativeText--) می‌توانند با استفاده از Aspose.Slides یا Microsoft PowerPoint خوانده یا تنظیم شوند.
با استفاده از این متد می‌توانید یک شکل را برچسب‌گذاری کنید و عملیات‌های مختلفی مانند حذف، مخفی‌کردن یا تغییر ترتیب اشکال روی اسلاید را انجام دهید.
 برای تنظیم AlternateText یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. هر شکل دلخواهی را به اسلاید اضافه کنید.
4. کاری با شکل تازه اضافه‌شده انجام دهید.
5. از بین اشکال عبور کنید تا شکل مورد نظر را پیدا کنید.
6. AlternativeText را تنظیم کنید.
7. فایل را روی دیسک ذخیره کنید.

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن شکل خودکار از نوع مستطیل
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // ذخیرهٔ ارائه روی دیسک
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به فرمت‌های چیدمان برای شکل**
Aspose.Slides for Node.js via Java یک API ساده برای دسترسی به فرمت‌های چیدمان یک شکل فراهم می‌کند. این مقاله نشان می‌دهد چگونه می‌توانید به فرمت‌های چیدمان دسترسی پیدا کنید.

در زیر نمونه کد آورده شده است.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **رندر کردن شکل به‌صورت SVG**
اکنون Aspose.Slides for Node.js via Java از رندر کردن یک شکل به‌صورت SVG پشتیبانی می‌کند. متد [writeAsSvg](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (و نسخهٔ overload آن) به کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) اضافه شده است. این متد اجازه می‌دهد محتوای شکل را به‌صورت فایل SVG ذخیره کنید. قطعه کد زیر نشان می‌دهد چگونه شکل اسلاید را به یک فایل SVG صادر کنید.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **هم‌راستای کردن اشکال**
Aspose.Slides امکان هم‌راستای کردن اشکال را نسبت به حاشیه‌های اسلاید یا نسبت به یکدیگر فراهم می‌کند. برای این منظور، متد overload شده [SlidesUtil.alignShape()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) اضافه شده است. شمارش [ShapesAlignmentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapesAlignmentType) گزینه‌های هم‌راستای ممکن را تعریف می‌کند.

**مثال 1**

کد منبع زیر اشکال با ایندکس‌های 1، 2 و 4 را در مرز بالایی اسلاید هم‌راستا می‌کند.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**مثال 2**

مثال زیر نشان می‌دهد چگونه تمام مجموعهٔ اشکال را نسبت به پایین‌ترین شکل در مجموعه هم‌راستا کنیم.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ویژگی‌های Flip**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapeframe/) کنترل معکوس افقی و عمودی اشکال را از طریق ویژگی‌های `flipH` و `flipV` فراهم می‌کند. هر دو ویژگی از نوع `byte` هستند و مقدار `1` برای معکوس، `0` برای عدم معکوس و `-1` برای استفاده از رفتار پیش‌فرض را می‌پذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getFrame) شکل قابل دسترسی هستند.

برای تغییر تنظیمات معکوس، یک نمونه جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapeframe/) با موقعیت و اندازهٔ فعلی شکل، مقادیر دلخواه برای `flipH` و `flipV` و زاویهٔ چرخش ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getFrame) شکل و ذخیرهٔ ارائه، تبدیل‌های معکوس را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن شامل یک شکل واحد با تنظیمات معکوس پیش‌فرض است، همان‌طور که در زیر نشان داده شده است.

![The shape to be flipped](shape_to_be_flipped.png)

کد زیر ویژگی‌های معکوس فعلی شکل را دریافت کرده و آن را هم به‌صورت افقی و هم عمودی معکوس می‌کند.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // دریافت ویژگی وارون افقی شکل.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // دریافت ویژگی وارون عمودی شکل.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // وارون افقی.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // وارون عمودی.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The flipped shape](flipped_shape.png)

## **FAQ**

**آیا می‌توانم اشکال را (اتحاد/تقاطع/تفریق) در اسلاید مشابه یک ویرایشگر دسکتاپ ترکیب کنم؟**

هیچ API داخلی برای عملیات بولی وجود ندارد. می‌توانید با ساختن طرح دلخواه خود، مثل محاسبهٔ شکل‌گیری نهایی (از طریق [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/geometrypath/)) و ایجاد یک شکل جدید با آن کانتور، به‌صورت تقریبی این کار را انجام دهید؛ در صورت نیاز می‌توانید اشکال اصلی را حذف کنید.

**چگونه می‌توانم ترتیب لایه‌ها (z-order) را کنترل کنم تا شکل همیشه «بالا» باشد؟**

ترتیب افزودن/جابه‌جایی را در مجموعهٔ [shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getShapes) اسلاید تغییر دهید. برای نتایج قابل پیش‌بینی، پس از تمام تغییرات دیگر اسلاید، ترتیب z-order را نهایی کنید.

**آیا می‌توانم یک شکل را قفل کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های محافظت در سطح شکل (مانند قفل انتخاب، جابه‌جایی، تغییر اندازه یا ویرایش متن) را تنظیم کنید. در صورت نیاز، محدودیت‌ها را بر روی مستر یا طرح اعمال کنید. توجه داشته باشید این حفاظت سطح رابط کاربری است و نه ویژگی امنیتی؛ برای حفاظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح فایل مانند [توصیه‌های فقط‑خواندنی یا رمزهای عبور](/slides/fa/nodejs-java/password-protected-presentation/) ترکیب کنید.