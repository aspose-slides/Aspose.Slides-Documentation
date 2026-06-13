---
title: مدیریت قاب‌های تصویر در ارائه‌ها بر روی Android
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/androidjava/picture-frame/
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
- اثر تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java اضافه کنید. گردش کار خود را ساده‌سازی کنید و طراحی اسلایدها را بهبود ببخشید."
---
## **معرفی**

قاب تصویر شکل‌ای است که شامل یک تصویر می‌شود—مانند یک تصویر داخل قاب.

می‌توانید از طریق یک قاب تصویر، تصویری را به اسلاید اضافه کنید. به این ترتیب می‌توانید با قالب‌بندی قاب تصویر، تصویر را نیز قالب‌بندی کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose ابزارهای تبدیل رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به کاربران امکان می‌دهد به سرعت از تصاویر، ارائه ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage]() را با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. با استفاده از متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر بسازید.  
6. یک قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد که چگونه یک قاب تصویر ایجاد کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image را ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک قاب تصویر پیچیده‌تر بسازید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) را با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد که چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // نمونه‌سازی کلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // اضافه کردن قاب تصویر با ارتفاع و عرض معادل تصویر
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تنظیم مقیاس نسبی عرض و ارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نحوه استخراج یک تصویر از سند «sample.pptx» و ذخیره آن به فرمت PNG را نشان می‌دهد.

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

زمانی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) قرار دارند، Aspose.Slides برای Android via Java به شما امکان می‌دهد که تصاویر برداری اصلی را با تمام دقت استخراج کنید. با مرور مجموعهٔ اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) زیرین محتوی SVG دارد یا نه، و سپس آن تصویر را به صورت فایل SVG بومی روی دیسک یا در یک جریان ذخیره کنید.

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

Aspose.Slides به شما امکان می‌دهد که اثر شفافیت اعمال‌شده به یک تصویر را دریافت کنید. این کد Java عملیات را نشان می‌دهد:

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

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توان بر روی یک قاب تصویر اعمال کرد، فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید یک قاب تصویر را طوری تغییر دهید که با نیازهای خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) را با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. با استفاده از متد [AddPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مرجع ارائه می‌شود، یک `PictureFrame` بر اساس عرض و ارتفاع تصویر بسازید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخش دهید.  
   * مقدار مثبت تصویر را به سمت ساعتگرد می‌چرخاند.  
   * مقدار منفی تصویر را به سمت پادساعتگرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

این کد Java فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image را ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // قاب تصویر را با ارتفاع و عرض معادل تصویر اضافه می‌کند
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // برخی قالب‌بندی‌ها را بر روی PictureFrameEx اعمال می‌کند
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose به‌تازگی یک ابزار رایگان «Collage Maker» ([اینجا](https://products.aspose.app/slides/fa/collage)) ارائه کرد. اگر نیاز به ترکیب تصاویر JPG/JPEG یا PNG، یا ایجاد شبکه‌های تصویری از عکس‌ها دارید، می‌توانید از این سرویس استفاده کنید. 

{{% /alert %}}

## **افزودن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن حجم ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک‌های خارجی اضافه کنید به‌جای این‌که فایل‌ها را مستقیماً در ارائه تعبیه کنید. این کد Java نشان می‌دهد که چگونه یک تصویر و ویدیو را در یک نگهدارنده اضافه کنید:

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

این کد Java نشان می‌دهد که چگونه یک تصویر موجود در اسلاید را برش دهید:

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

## **حذف نواحی برش‌خوردهٔ یک تصویر**

اگر می‌خواهید نواحی برش‌خوردهٔ تصویری که در یک قاب قرار دارد را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورت عدم نیاز به برش باز می‌گرداند.

این کد Java عملیات را نشان می‌دهد:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // قاب تصویر را از اسلاید اول دریافت می‌کند
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // نواحی برش‌خوردهٔ تصویر قاب تصویر را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعهٔ تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائهٔ نهایی افزایش می‌یابد.

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) یک تصویر را در ارائه فشرده کنید. این متد تصویر را بر اساس اندازهٔ شکل و وضوح مشخص‌شده فشرده می‌کند، با گزینهٔ حذف نواحی برش‌خورده.

این رفتار مشابه ویژگی **Picture Format > Compress Pictures > Resolution** در PowerPoint است.

مثال‌های Java زیر نشان می‌دهند که چگونه یک تصویر در ارائه را با تعیین وضوح هدف فشرده کنید و به‌صورت اختیاری نواحی برش‌خورده را حذف کنید:

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

یا به‌صورت مستقیم با مقدار DPI سفارشی:

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

این متد تصویر را بر اساس اندازهٔ شکل و DPI ارائه‌شده به وضوح پایین‌تر تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند حذف شوند تا حجم فایل بهینه شود.  
اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوهٔ برخورد PowerPoint با JPEGهای با وضوح بالا.

{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید شکلی که شامل یک تصویر است حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم ویژگی *Lock Aspect Ratio* استفاده کنید.

این کد Java نشان می‌دهد که چگونه نسبت ابعاد یک شکل را قفل کنید:

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

    // شکل را طوری تنظیم کنید که نسبت ابعاد آن در هنگام تغییر اندازه حفظ شود
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* تنها نسبت ابعاد شکل را حفظ می‌کند، نه تصویری که درون آن قرار دارد.

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از اینترفیس [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) می‌توانید یک مستطیل پرکننده مشخص کنید.

زمانی که کشش برای یک تصویر مشخص شود، یک مستطیل منبع به‌صورت مقیاس‌دار تا متناسب با مستطیل پرکنندهٔ تعیین‌شده گسترش می‌یابد. هر لبهٔ مستطیل پرکننده با یک درصد جابجایی نسبت به لبهٔ متناظر جعبه محدود کنندهٔ شکل تعریف می‌شود. یک درصد مثبت نشان‌دهندهٔ تورم داخلی و درصد منفی نشان‌دهندهٔ گسترش خارجی است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک `AutoShape` مستطیل اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پرکنندهٔ شکل را تنظیم کنید.  
6. حالت پرکنندهٔ تصویر شکل را تنظیم کنید.  
7. تصویری تنظیم کنید تا شکل را پر کند.  
8. جابجایی‌های تصویر را نسبت به لبهٔ متناظر جعبه محدود کنندهٔ شکل تعیین کنید.  
9. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

این کد Java فرآیندی را نشان می‌دهد که در آن ویژگی StretchOff استفاده می‌شود:

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
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

    // یک AutoShape به شکل Rectangle اضافه می‌کند
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // نوع پر کردن شکل را تنظیم می‌کند
    aShape.getFillFormat().setFillType(FillType.Picture);

    // حالت پر کردن تصویر شکل را تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تصویر را برای پر کردن شکل تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // جابجایی‌های تصویر را نسبت به لبهٔ متناظر جعبه مرزی شکل مشخص می‌کند
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

## **سوالات متداول**

**چگونه می‌توانم متوجه شوم که کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با توانایی‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چه تأثیری بر حجم و عملکرد PPTX دارد؟**

جذب (Embedding) تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به‌حفظ حجم ارائه کمک می‌کند اما نیاز دارد که فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از جابه‌جایی/تغییر اندازهٔ ناخواسته قفل کنم؟**

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) (مثلاً غیرفعال کردن جابه‌جایی یا تغییر اندازه) استفاده کنید. مکانیزم قفل‌گذاری برای انواع مختلف شکل‌ها، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا دقت برداری SVG هنگام خروجی‌گیری ارائه به PDF/تصاویر حفظ می‌شود؟**

Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) به‌عنوان بردار اصلی را فراهم می‌کند. هنگام [خروجی‌گیری به PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/androidjava/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی‌گیری رستر شود؛ اما این‌که SVG اصلی به‌صورت بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.