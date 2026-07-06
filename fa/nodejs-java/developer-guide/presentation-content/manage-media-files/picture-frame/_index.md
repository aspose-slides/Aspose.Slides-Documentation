---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از JavaScript
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/nodejs-java/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض به ارتفاع
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java اضافه کنید. جریان کار خود را بهینه‌سازی کنید و طراحی اسلایدها را ارتقا دهید."
---
## **مقدمه**

یک قاب تصویر شکلی است که حاوی یک تصویر می‌باشد — مشابه یک عکس در یک قاب.

می‌توانید از طریق یک قاب تصویر، تصویری را به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.

{{% alert  title="نکته" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد — [JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — که به افراد امکان می‌دهد به سرعت ارائه‌هایی را از تصاویر ایجاد کنند. 

{{% /alert %}} 

## **ایجاد قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک شیء `PPImage` را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.
4. عرض و ارتفاع تصویر را مشخص کنید.
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `addPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.
6. یک قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.
7. ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد JavaScript نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک شیء از کلاس Image ایجاد می‌کند
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

قاب‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه را بر پایه تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر دستکاری کنید.

## **ایجاد قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک قاب تصویر پیچیده‌تر بسازید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.
6. ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد JavaScript نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک شیء از کلاس Image ایجاد می‌کند
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // تنظیم مقیاس نسبی عرض و ارتفاع
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFrame) استخراج کنید و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره نمایید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در قالب PNG ذخیره کنید.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

زمانی که یک ارائه شامل گرافیک‌های SVG است که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) قرار دارند، Aspose.Slides برای Node.js از طریق Java به شما اجازه می‌دهد تصاویر برداری اصلی را با کامل‌ترین دقت بازیابی کنید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا شیء زیرین [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) محتوی SVG دارد یا نه، و سپس آن تصویر را به صورت فایل یا جریان در فرمت SVG بومی ذخیره کنید.

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **به‌دست آوردن شفافیت تصویر**

Aspose.Slides به شما اجازه می‌دهد اثر شفافیت اعمال شده به یک تصویر را دریافت کنید. این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **به‌دست آوردن روشنایی و کنتراست تصویر**

Aspose.Slides به شما اجازه می‌دهد روشنایی و کنتراست اثر اعمال شده به یک تصویر را دریافت کنید. کلاس [Luminance](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/luminance/) این تحول تصویر را نمایش می‌دهد.

این کد JavaScript نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را برای قاب تصویر فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را طوری تغییر دهید که با نیازمندی‌های خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.
4. عرض و ارتفاع تصویر را مشخص کنید.
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) که توسط شیء [Shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.
7. رنگ خط قاب تصویر را تنظیم کنید.
8. عرض خط قاب تصویر را تنظیم کنید.
9. قاب تصویر را با دادن مقدار مثبت یا منفی چرخش دهید.
   * مقدار مثبت تصویر را ساعتگرد می‌چرخاند. 
   * مقدار منفی تصویر را پادساعتگرد می‌چرخاند.
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.
11. ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد JavaScript فرایند قالب‌بندی قاب تصویر را نشان می‌دهد:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک شیء از کلاس Image ایجاد می‌کند
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // اعمال برخی قالب‌بندی‌ها به PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="نکته" color="primary" %}}

Aspose به‌تازگی یک [ساختارگر کلاژ رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر ever نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG داشته باشید، یا [ایجاد شبکه از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid)، می‌توانید از این سرویس استفاده کنید. 

{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از حجم بزرگ ارائه، می‌توانید به‌جای جاسازی مستقیم فایل‌ها، تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید. این کد JavaScript نشان می‌دهد چگونه یک تصویر و ویدیو را در یک محل‌نگه‌دار (placeholder) اضافه کنید:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **قاب‌بُری تصویر**

این کد JavaScript نشان می‌دهد چگونه یک تصویر موجود را در اسلاید قاب‌بُری کنید:

```javascript
var pres = new aspose.slides.Presentation();
// ایجاد شیء تصویر جدید
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // اضافه کردن PictureFrame به یک اسلاید
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // برش تصویر (مقدارهای درصدی)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // ذخیرهٔ نتیجه
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف نواحی قاب‌گذاری شده تصویر**

اگر می‌خواهید نواحی قاب‌گذاری شده یک تصویر موجود در قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر قاب‌گذاری‌شده یا تصویر اصلی را در صورتی که قاب‌گذاری ضروری نباشد، بازمی‌گرداند.

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // قاب تصویر را از اسلاید اول دریافت می‌کند
    var picFrame = slide.getShapes().get_Item(0);
    // نواحی برش‌خورده تصویر قاب تصویر را حذف می‌کند و تصویر برش‌خورده را بازمی‌گرداند
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="یادداشت" color="warning" %}} 

متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) تصویر قاب‌گذاری‌شده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش می‌یابد.

این متد در عملیات قاب‌گذاری، فایل‌های متافایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) یک تصویر در ارائه را فشرده کنید.
این متد تصویر را با کاهش اندازه‌اش بر اساس اندازه شکل و وضوح مشخص‌شده، و با گزینه حذف نواحی قاب‌گذاری‌شده فشرده می‌کند.

این تنظیم مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint عمل می‌کند.

مثال‌های JavaScript زیر نشان می‌دهند چگونه با تعیین وضوح هدف و حذف اختیاری نواحی قاب‌گذاری‌شده، یک تصویر در ارائه را فشرده کنید:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // نتیجه فشرده‌سازی را بررسی کنید.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یا با استفاده از مقدار DPI پیش‌تعریف‌شده دیگر:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // فشرده‌سازی تصویر به 96 DPI (وضوح ایمیل)، حذف نواحی برش‌خورده.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="یادداشت" color="warning" %}} 

این متد تصویر را به وضوح پایین‌تری بر اساس اندازه شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی قاب‌گذاری‌شده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.
اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، مشابه رفتار PowerPoint با JPEGهای با وضوح بالا.

{{% /alert %}}

## **قفل کردن نسبت عرض به ارتفاع**

اگر می‌خواهید یک شکل حاوی تصویر حتی پس از تغییر ابعاد تصویر، نسبت عرض به ارتفاع خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.

این کد JavaScript نشان می‌دهد چگونه نسبت عرض به ارتفاع یک شکل را قفل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // تنظیم شکل برای حفظ نسبت عرض به ارتفاع هنگام تغییر اندازه
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="یادداشت" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* فقط نسبت عرض به ارتفاع شکل را حفظ می‌کند و نه تصویر داخل آن.

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از متدهای [setStretchOffsetLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)، [setStretchOffsetTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)، [setStretchOffsetRight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) و [setStretchOffsetBottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) از کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat) می‌توانید یک مستطیل پر را تعیین کنید.

زمانی که کشش برای یک تصویر مشخص شود، یک مستطیل منبع مقیاس‌بندی می‌شود تا در مستطیل پر مشخص شده جا بگیرد. هر لبهٔ مستطیل پر توسط درصدی نسبت به لبهٔ متناظر جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی و درصد منفی یک برآمدگی را مشخص می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک `AutoShape` مستطیل اضافه کنید. 
4. یک تصویر ایجاد کنید.
5. نوع پر کردن شکل را تنظیم کنید.
6. حالت پر کردن تصویر شکل را تنظیم کنید.
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.
8. افست‌های تصویر را از لبهٔ متناظر جعبه مرزی شکل مشخص کنید
9. ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد JavaScript فرایندی را نشان می‌دهد که در آن ویژگی StretchOff مورد استفاده قرار می‌گیرد:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک شیء از کلاس ImageEx ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // یک AutoShape مستطیلی به اسلاید اضافه می‌کند
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // نوع پر کردن شکل را تنظیم می‌کند
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // حالت پر کردن تصویر شکل را تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // تصویر را برای پر کردن شکل تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // افست‌های تصویر را نسبت به لبهٔ متناظر جعبه مرزی شکل مشخص می‌کند
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سئوالات متداول**

**چگونه می‌توانم متوجه شوم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**اضافه کردن ده‌ها تصویر بزرگ چگونه بر حجم و عملکرد PPTX تأثیر می‌گذارد؟**

جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به کاهش حجم ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازهٔ تصادفی قفل کنم؟**

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن جابجایی یا تغییر اندازه). مکانیزم قفل‌کردن برای انواع مختلف شکل‌ها، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/)، پشتیبانی می‌شود.

**آیا دقت برداری SVG هنگام صادر کردن ارائه به PDF/تصاویر حفظ می‌شود؟**

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) را به عنوان بردار اصلی فراهم می‌کند. هنگام [صادرات به PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/nodejs-java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی رستر شود؛ اما این حقیقت که SVG اصلی به عنوان بردار ذخیره شده است از رفتار استخراج تأیید می‌شود.