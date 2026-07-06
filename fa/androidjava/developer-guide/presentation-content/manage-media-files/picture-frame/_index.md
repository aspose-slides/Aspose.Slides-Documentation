---
title: مدیریت قاب‌های تصویر در ارائه‌ها در اندروید
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java اضافه کنید. روند کاری خود را ساده‌سازی کنید و طراحی اسلایدها را بهبود بخشید."
---
## **مقدمه**

قاب تصویر یک شکل است که یک تصویر را در خود دارد — همانند یک عکس در قاب.  

شما می‌توانید یک تصویر را از طریق قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.  

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد — [JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — که به کاربران امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند.  

{{% /alert %}} 

## **ایجاد قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage]() ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائه اصلاح‌شده را به عنوان یک فایل PPTX بنویسید.  

این کد Java نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:  

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image را ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک قاب تصویر با عرض و ارتفاع معادل تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک تصویر به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه اصلاح‌شده را به عنوان یک فایل PPTX بنویسید.  

این کد Java نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:  

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image را ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // یک قاب تصویر با عرض و ارتفاع معادل تصویر اضافه می‌کند
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تنظیم مقیاس نسبی عرض و ارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نحوه استخراج یک تصویر از سند «sample.pptx» و ذخیره آن در قالب PNG را نشان می‌دهد.  

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

زمانی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame] قرار گرفته‌اند، Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تا تصاویر برداری اصلی را با تمام صحت دریافت کنید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame] را شناسایی کنید، بررسی کنید آیا [IPPImage] زیرین محتوای SVG دارد یا نه، و سپس آن تصویر را به‌صورت فایل یا جریان با فرمت SVG اصلی ذخیره کنید.  

مثال کد زیر نحوه استخراج یک تصویر SVG از یک قاب تصویر را نشان می‌دهد:  

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **دریافت شفافیت یک تصویر**

Aspose.Slides به شما اجازه می‌دهد تا اثر شفافیت اعمال‌شده بر یک تصویر را دریافت کنید. این کد Java عمل را نشان می‌دهد:  

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **دریافت روشنایی و کنتراست یک تصویر**

Aspose.Slides به شما اجازه می‌دهد تا اثر روشنایی و کنتراست اعمال‌شده بر یک تصویر را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iluminance/) این اثر تبدیل تصویر را نمایش می‌دهد.  

این کد Java نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:  

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توان بر روی یک قاب تصویر اعمال کرد، فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید یک قاب تصویر را تغییر دهید تا با نیازهای خاص مطابقت داشته باشد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با دادن یک مقدار مثبت یا منفی بچرخانید.  
   * مقدار مثبت تصویر را به‌صورت ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را به‌صورت پاد ساعت‌گرد می‌چرخاند.  
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائه اصلاح‌شده را به عنوان یک فایل PPTX بنویسید.  

این کد Java فرایند قالب‌بندی قاب تصویر را نشان می‌دهد:  

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image را ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک قاب تصویر با عرض و ارتفاع معادل تصویر اضافه می‌کند
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // برخی قالب‌بندی‌ها را بر روی PictureFrameEx اعمال می‌کند
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose به‌تازگی یک [ابزار ساخت کلاژ رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به [ترکیب تصویرهای JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG داشته باشید، یا [ایجاد شبکه‌ای از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) داشته باشید، می‌توانید از این سرویس استفاده کنید.  

{{% /alert %}}

## **افزودن تصویر به‌عنوان پیوند**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق پیوند اضافه کنید به‌جای اینکه فایل‌ها را مستقیماً در ارائه جاسازی کنید. این کد Java نشان می‌دهد چگونه یک تصویر و ویدیو را به یک‌نگهدارنده (placeholder) اضافه کنید:  

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **قلم‌برداری (برش) تصاویر**

این کد Java نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:  

```java
Presentation pres = new Presentation();
// یک شیء تصویر جدید ایجاد می‌کند
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک PictureFrame به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // تصویر را برش می‌دهد (مقدارهای درصدی)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // نتیجه را ذخیره می‌کند
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف نواحی برش خورده یک تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورت عدم نیاز به برش برمی‌گرداند.  

این کد Java عملیات را نشان می‌دهد:  

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // قاب تصویر را از اسلاید اول دریافت می‌کند
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ناحیه‌های برش‌خورده تصویر قاب تصویر را حذف می‌کند و تصویر برش‌خورده را بر می‌گرداند
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) پردازش‌شده استفاده شده باشد، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش خواهد یافت.

این متد فایل‌های متا WMF/EMF را در عملیات برش به تصویر PNG رستر تبدیل می‌کند.  

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در یک ارائه را با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس ابعاد شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را نیز دارد.  

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format > Compress Pictures > Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های Java زیر نشان می‌دهند چگونه یک تصویر را در یک ارائه با تعیین وضوح هدف فشرده کنید و در صورت نیاز نواحی برش‌خورده را حذف کنید:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // فشرده‌سازی تصویر با وضوح هدف 150 DPI (وضوح وب) و حذف نواحی برش‌خورده.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یا به‌صورت مستقیم با استفاده از مقدار DPI سفارشی:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // فشرده‌سازی تصویر به 150 DPI (وضوح وب)، حذف نواحی برش‌خورده.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

این متد تصویر را بر مبنای اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تر تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند حذف شوند تا حجم فایل بهینه شود.  
اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوهٔ پردازش JPEGهای با وضوح بالا در PowerPoint.  

{{% /alert %}}

## **قفل کردن نسبت عرض به ارتفاع**

اگر می‌خواهید یک شکل حاوی تصویر نسبت عرض به ارتفاع خود را حتی پس از تغییر ابعاد تصویر حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

این کد Java نشان می‌دهد چگونه نسبت عرض به ارتفاع یک شکل را قفل کنید:  

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // تنظیم شکل برای حفظ نسبت عرض به ارتفاع هنگام تغییر اندازه
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* فقط نسبت عرض به ارتفاع شکل را حفظ می‌کند و نه تصویر داخل آن.  

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) می‌توانید یک مستطیل پرکننده (fill rectangle) را مشخص کنید.  

زمانی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع برای برازش به مستطیل پرکننده مشخص‌شده مقیاس‌بندی می‌شود. هر لبهٔ مستطیل پرکننده با درصدی از لبهٔ مربوطهٔ جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی (inset) و درصد منفی یک بیرون رفتگی (outset) را تعیین می‌کند.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک `AutoShape` مستطیل اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبهٔ مربوطهٔ جعبه مرزی شکل مشخص کنید.  
9. ارائه اصلاح‌شده را به عنوان یک فایل PPTX بنویسید.  

این کد Java فرایندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:  

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک نمونه از کلاس ImageEx را ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک AutoShape با نوع Rectangle اضافه می‌کند
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // نوع پر کردن شکل را تنظیم می‌کند
    aShape.getFillFormat().setFillType(FillType.Picture);

    // حالت پر کردن تصویر شکل را تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تصویر را برای پر کردن شکل تعیین می‌کند
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // افست‌های تصویر را نسبت به لبهٔ مربوطهٔ جعبه مرزی شکل مشخص می‌کند
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**  

Aspose.Slides هم تصاویر رستر (مانند PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame] اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده به طور کلی با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.  

**افزودن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد فایل PPTX دارد؟**  

جاسازی مستقیم (embed) تصاویر بزرگ باعث افزایش حجم فایل و مصرف حافظه می‌شود؛ استفاده از پیوند تصاویر به حفظ کوچک‌بودن اندازه ارائه کمک می‌کند اما نیاز به دسترسی مداوم به فایل‌های خارجی دارد. Aspose.Slides امکان افزودن تصاویر به‌صورت پیوندی را برای کاهش حجم فایل فراهم می‌کند.  

**چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازه ناخواسته قفل کنم؟**  

از [قفل‌های شکل] (shape locks) برای یک [PictureFrame] استفاده کنید (مثلاً حرکت یا تغییر اندازه را غیرفعال کنید). مکانیزم قفل‌گذاری برای انواع مختلف اشکال از جمله [PictureFrame] پشتیبانی می‌شود.  

**آیا صحت برداری SVG هنگام خروجی‌گیری ارائه به PDF/تصاویر حفظ می‌شود؟**  

Aspose.Slides امکان استخراج SVG از یک [PictureFrame] به صورت بردار اصلی را فراهم می‌کند. هنگام [خروجی به PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/androidjava/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی به رستر تبدیل شود؛ این که SVG اصلی به صورت بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.