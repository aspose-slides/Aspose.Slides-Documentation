---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از جاوا
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/java/picture-frame/
keywords:
- قاب تصویر
- اضافه کردن قاب تصویر
- ایجاد قاب تصویر
- اضافه کردن تصویر
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
- افکت تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا اضافه کنید. جریان کار خود را بهینه کنید و طراحی اسلایدها را ارتقا دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که شامل یک تصویر می‌شود — شبیه یک عکس داخل قاب است.

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب، می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد — [JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — که به کاربران اجازه می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند.
{{% /alert %}} 

## **ایجاد قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. از طریق اندیس، ارجاع اسلاید را دریافت کنید.  
3. یک شیء [IPPImage]() ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مورد ارجاع قرار گرفته است، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلید اضافه کنید.  
7. ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.  

این کد جاوا نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```java
// یک شیء از کلاس Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک شیء از کلاس Image را نمونه‌سازی می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // قاب تصویری را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
قاب‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه مبتنی بر تصاویر ایجاد کنید. زمانی که قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر مدیریت کنید. ممکن است این صفحات را بخواهید مشاهده کنید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/), تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/), تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).
{{% /alert %}} 

## **ایجاد قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. از طریق اندیس، ارجاع اسلاید را دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.  

این کد جاوا نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر قالب PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // نمونه‌سازی کلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // افزودن قاب تصویر با ارتفاع و عرض معادل تصویر
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تنظیم مقیاس نسبی عرض و ارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // نوشتن فایل PPTX روی دیسک
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) استخراج کنید و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. نمونه کد زیر نشان می‌دهد چگونه یک تصویر را از سند "sample.pptx" استخراج و در قالب PNG ذخیره کنید.

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

هنگامی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides for Java به شما امکان می‌دهد تا تصاویر برداری اصلی را با تمام دقت بازیابی کنید. با مرور مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame] را شناسایی کنید، بررسی کنید آیا [IPPImage] زیرین محتویات SVG دارد، و سپس آن تصویر را به صورت فایل یا جریان در قالب SVG بومی ذخیره کنید.

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

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

## **دریافت شفافیت تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیت اعمال شده بر یک تصویر را دریافت کنید. این کد جاوا عملیات را نشان می‌دهد:

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

## **دریافت روشنایی و کنتراست تصویر**

Aspose.Slides به شما امکان می‌دهد اثر روشنایی و کنتراست اعمال شده بر یک تصویر را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iluminance/) این اثر تبدیل تصویر را نشان می‌دهد.

این کد جاوا نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

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

Aspose.Slides گزینه‌های قالب‌بندی متعددی ارائه می‌دهد که می‌توان به یک قاب تصویر اعمال کرد. با استفاده از این گزینه‌ها، می‌توانید قاب تصویر را طوری تغییر دهید که با نیازهای خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. از طریق اندیس، ارجاع اسلاید را دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مورد ارجاع قرار گرفته است، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی بچرخانید.  
   * مقدار مثبت تصویر را به جهت ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را به جهت پاد ساعت‌گرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.  

این کد جاوا فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```java
// یک شیء از کلاس Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک شیء از کلاس Image را نمونه‌سازی می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // برخی قالب‌بندی‌ها را بر روی PictureFrameEx اعمال می‌کند
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose به تازگی یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر هرگز نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، یا [ایجاد شبکه‌ها از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) داشته باشید، می‌توانید از این سرویس استفاده کنید.
{{% /alert %}}

## **افزودن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید به‌جای درون‌برد فایل‌ها مستقیم به ارائه‌ها. این کد جاوا نشان می‌دهد چگونه یک تصویر و ویدیو را به یک جای‌گیر اضافه کنید:

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

## **برش تصاویر**

این کد جاوا نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:

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

    // قاب تصویر را به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // تصویر را برش می‌دهد (مقادیر درصدی)
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

## **حذف نواحی برش‌خورده تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر داخل قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را برمی‌گرداند اگر برش لازم نباشد.

این کد جاوا عملیات را نشان می‌دهد:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // قاب تصویر را از اولین اسلاید دریافت می‌کند
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // نواحی برش‌خورده تصویر قاب تصویر را حذف می‌کند و تصویر برش‌خورده را بر می‌گرداند
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame] پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه حاصل افزایش می‌یابد.

این متد فایل‌های متافایل WMF/EMF را در عملیات برش به تصویر رستر PNG تبدیل می‌کند.
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر را در یک ارائه با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) فشرده کنید. این متد تصویر را با کاهش اندازه آن بر اساس اندازه شکل و وضوح مشخص شده فشرده می‌کند و گزینه حذف نواحی برش‌خورده را دارد.

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌کند.

مثال‌های زیر در جاوا نشان می‌دهند چگونه یک تصویر را در یک ارائه با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده فشرده کنید:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // نتیجه فشرده‌سازی را بررسی می‌کند.
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

    // تصویر را به 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
این متد تصویر را به وضوح پایین‌تر بر اساس اندازه شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین، کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی پردازش PowerPoint برای JPEGهای با وضوح بالا.
{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید شکلی که شامل یک تصویر است نسبت ابعاد خود را حتی پس از تغییر ابعاد تصویر حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم ویژگی *Lock Aspect Ratio* استفاده کنید.

این کد جاوا نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

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

    // شکل را طوری تنظیم کنید که هنگام تغییر اندازه نسبت ابعاد حفظ شود
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* تنها نسبت ابعاد شکل را حفظ می‌کند نه تصویر داخل آن.
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--), و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat) می‌توانید یک مستطیل پرکننده تعیین کنید.

هنگامی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع به‌صورت مقیاس‌دار برای پر کردن مستطیل پرکننده مشخص‌شده تنظیم می‌شود. هر لبه از مستطیل پرکننده توسط یک درصد افست نسبت به لبه مربوطه از جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک داخلی (inset) و درصد منفی یک بیرونی (outset) را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. از طریق اندیس، ارجاع اسلاید را دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پرکردن شکل را تنظیم کنید.  
6. حالت پرکردن تصویر شکل را تنظیم کنید.  
7. تصویر تنظیم‌شده‌ای را برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبه مربوطه از جعبه مرزی شکل مشخص کنید.  
9. ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.  

این کد جاوا فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:

```java
// یک شیء از کلاس Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شیء از کلاس ImageEx را نمونه‌سازی می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک AutoShape به شکل Rectangle اضافه می‌کند
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // نوع پرکننده شکل را تنظیم می‌کند
    aShape.getFillFormat().setFillType(FillType.Picture);

    // حالت پرکننده تصویر شکل را تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تصویر را برای پر کردن شکل تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // افست‌های تصویر را نسبت به لبه مربوطه از جعبه مرزی شکل مشخص می‌کند
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**  
Aspose.Slides هم تصاویر رستر (PNG, JPEG, BMP, GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame] اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چه تاثیری بر حجم و عملکرد فایل PPTX دارد؟**  
درون‌برد تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به کاهش حجم ارائه کمک می‌کند اما نیاز دارد که فایل‌های خارجی همچنان در دسترس باشند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از حرکت/تغییر اندازه تصادفی قفل کنم؟**  
از [قفل‌های شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) برای یک [PictureFrame] استفاده کنید (مثلاً غیرفعال کردن حرکت یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در یک مقاله جداگانه‌ی [حفاظت](/slides/fa/java/applying-protection-to-presentation/) توصیف شده است و برای انواع مختلف شکل‌ها، از جمله [PictureFrame]، پشتیبانی می‌شود.

**آیا دقت برداری SVG هنگام استخراج ارائه به PDF/تصاویر حفظ می‌شود؟**  
Aspose.Slides امکان استخراج SVG از یک [PictureFrame] به‌عنوان بردار اصلی را فراهم می‌کند. هنگام [صادرات به PDF](/slides/fa/java/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به رستر تبدیل شود؛ این که SVG اصلی به‌عنوان بردار ذخیره شده است توسط رفتار استخراج تأیید می‌شود.