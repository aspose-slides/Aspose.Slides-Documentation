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
- منطقه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java اضافه کنید. روند کار خود را بهینه‌سازی کنید و طراحی اسلایدها را ارتقا دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که حاوی تصویر است—مانند تصویری در یک قاب.  

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت‌بندی کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به افراد امکان می‌دهد ارائه‌ها را به‌سرعت از تصاویر ایجاد کنند. 
{{% /alert %}} 

## **ایجاد قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء `PPImage` را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `addPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائه‌ی تغییر یافته را به عنوان یک فایل PPTX بنویسید.  

این کد JavaScript نشان می‌دهد که چگونه یک قاب تصویر ایجاد کنید:

```javascript
// یک نمونه از کلاس Presentation که فایل PPTX را نشان می‌دهد را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک نمونه از کلاس Image را ایجاد می‌کند
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // قاب تصویری را با ارتفاع و عرض معادل تصویر اضافه می‌کند
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

قاب‌های تصویر به شما امکان می‌دهند که به‌سرعت اسلایدهای ارائه را بر پایه تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک قالب به قالب دیگر مدیریت کنید.

## **ایجاد قاب تصویر با مقیاس نسبی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی تغییر یافته را به عنوان یک فایل PPTX بنویسید.  

این کد JavaScript نشان می‌دهد که چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```javascript
// نمونه‌سازی کلاس Presentation که نشان‌دهنده PPTX است
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // نمونه‌سازی کلاس Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // افزودن Picture Frame با ارتفاع و عرض معادل تصویر
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // تنظیم مقیاس نسبی عرض و ارتفاع
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFrame) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و به قالب PNG ذخیره کنید.

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

زمانی که یک ارائه شامل گرافیک‌های SVG قرار گرفته در اشکال [PictureFrame] باشد، Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد که تصاویر برداری اصلی را با تمام وضوح بازیابی کنید. با مرور مجموعه اشکال اسلاید می‌توانید هر [PictureFrame] را شناسایی کنید، بررسی کنید آیا [PPImage] زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را به‌صورت بومی در فرمت SVG بر روی دیسک یا جریان ذخیره کنید.  

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

## **دریافت شفافیت تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیت اعمال‌شده به یک تصویر را دریافت کنید. این کد JavaScript عملیات را نشان می‌دهد:

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

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی ارائه می‌دهد که می‌توان بر روی یک قاب تصویر اعمال کرد. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را به‌گونه‌ای تغییر دهید که با نیازمندی‌های خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) را با اضافه کردن یک تصویر به [ImagesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ارائه‌شده توسط شیء [Shapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) مرتبط با اسلاید مرجع ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخش دهید.  
   * مقدار مثبت تصویر را به‌صورت ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را به‌صورت پادساعت‌گرد می‌چرخاند.  
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی تغییر یافته را به عنوان یک فایل PPTX بنویسید.  

این کد JavaScript نشان‌دهنده‌ی فرآیند قالب‌بندی قاب تصویر است:

```javascript
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک نمونه از کلاس Image را ایجاد می‌کند
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // قاب تصویری را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // برخی قالب‌بندی‌ها را بر روی PictureFrameEx اعمال می‌کند
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

{{% alert title="Tip" color="primary" %}} 
Aspose به‌تازگی یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داد. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، یا [ایجاد شبکه‌ها از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) دارید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **اضافه کردن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید به‌جای اینکه فایل‌ها را مستقیماً در ارائه جاسازی کنید. این کد JavaScript نشان می‌دهد چگونه یک تصویر و ویدیو را به یک مکان‌نگهدار اضافه کنید:

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

## **برش تصویر**

این کد JavaScript نشان می‌دهد چگونه یک تصویر موجود در یک اسلاید را برش دهید:

```javascript
var pres = new aspose.slides.Presentation();
// یک شیء تصویر جدید ایجاد می‌کند
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
    // یک PictureFrame به اسلاید اضافه می‌کند
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // تصویر را برش می‌دهد (مقادیر درصدی)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // نتیجه را ذخیره می‌کند
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف نواحی برش‌خورده تصویر**

اگر می‌خواهید نواحی برش‌خورده‌ی تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را برمی‌گرداند اگر برش لازم نباشد.  

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // قاب تصویر را از اسلاید اول دریافت می‌کند
    var picFrame = slide.getShapes().get_Item(0);
    // نواحی برش‌خورده تصویر قاب تصویر را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه‌ی نهایی افزایش خواهد یافت.  

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) یک تصویر را در یک ارائه فشرده کنید. این متد تصویر را با کاهش اندازه‌اش بر اساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند، با گزینه حذف نواحی برش‌خورده.  

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های JavaScript زیر نشان می‌دهند چگونه یک تصویر را در یک ارائه با تعیین وضوح هدف فشرده کنید و به‌صورت اختیاری نواحی برش‌خورده را حذف کنید:

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

    // تصویر را به 96 DPI (وضوح ایمیل) فشرده کنید، نواحی برش‌خورده را حذف کنید.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی پردازش PowerPoint برای JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل کردن نسبت تصویر**

اگر می‌خواهید یک شکل حاوی تصویر حتی پس از تغییر ابعاد تصویر، نسبت تصویر خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

این کد JavaScript نشان می‌دهد چگونه نسبت تصویر یک شکل را قفل کنید:

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
    // تنظیم شکل برای حفظ نسبت ابعاد هنگام تغییر اندازه
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* فقط نسبت شکل را حفظ می‌کند و نه تصویر موجود در آن. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از متدهای [setStretchOffsetLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)، [setStretchOffsetTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) و [setStretchOffsetBottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) از کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PictureFillFormat) می‌توانید یک مستطیل پرکننده مشخص کنید.  

هنگامی که برای یک تصویر کشیده شدن تعریف می‌شود، یک مستطیل منبع به‌طور مقیاس‌دار برای پر کردن مستطیل پرکننده‌ی مشخص‌شده تنظیم می‌شود. هر لبه‌ی مستطیل پرکننده توسط درصدی نسبت به لبه‌ی متناظر جعبه‌حدود شکل تعریف می‌شود. درصد مثبت یک تو رفتگی داخلی و درصد منفی یک برآمدگی خارجی را مشخص می‌کند.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک `AutoShape` به شکل مستطیل اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. تصویری تنظیم کنید تا شکل را پر کند.  
8. افست‌های تصویر را نسبت به لبه‌های متناظر جعبه‌حدود شکل مشخص کنید.  
9. ارائه‌ی تغییر یافته را به عنوان یک فایل PPTX بنویسید.  

این کد JavaScript فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:

```javascript
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک نمونه از کلاس ImageEx را ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // یک AutoShape به شکل Rectangle اضافه می‌کند
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // نوع پر شدن شکل را تنظیم می‌کند
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // حالت پر شدن تصویر برای شکل را تنظیم می‌کند
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

## **سؤالات متداول**

**چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شود؟**  
Aspose.Slides هر دو نوع تصویر رستر (PNG، JPEG، BMP، GIF و غیره) و تصاویر برداری (به عنوان مثال SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.  

**افزودن ده‌ها تصویر بزرگ چه تاثیری بر اندازه و کارایی PPTX دارد؟**  
جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ استفاده از لینک برای تصاویر باعث کم‌حجم‌تر شدن ارائه می‌شود اما نیاز دارد فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک‌دار برای کاهش حجم فایل را فراهم می‌کند.  

**چگونه می‌توانم یک شیء تصویر را از جابه‌جایی یا تغییر اندازه ناخواسته قفل کنم؟**  
از [قفل‌های شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) استفاده کنید (به عنوان مثال، غیرفعال کردن جابه‌جایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای انواع مختلف شکل‌ها، از جمله [PictureFrame] پشتیبانی می‌شود.  

**آیا صحت بردار SVG هنگام خروجی به PDF/تصاویر حفظ می‌شود؟**  
Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame] را به‌صورت بردار اصلی فراهم می‌کند. هنگام خروجی به PDF یا فرمت‌های رستر، نتیجه ممکن است بسته به تنظیمات خروجی به‌صورت رستر باشد؛ اما این که SVG اصلی به‌صورت بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.