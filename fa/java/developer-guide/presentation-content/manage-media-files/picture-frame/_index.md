---
title: مدیریت فریم‌های تصویر در ارائه‌ها با استفاده از جاوا
linktitle: فریم تصویر
type: docs
weight: 10
url: /fa/java/picture-frame/
keywords:
- فریم تصویر
- افزودن فریم تصویر
- ایجاد فریم تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- قاب‌بندی تصویر
- منطقه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی فریم تصویر
- ویژگی‌های فریم تصویر
- مقیاس نسبی
- اثرات تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "فریم‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java اضافه کنید. گردش کار خود را بهبود بخشید و طرح اسلایدها را ارتقا دهید."
---
## **معرفی**

یک فریم تصویر یک شکل است که حاوی یک تصویر است—مانند یک تصویر داخل یک قاب.  

می‌توانید با استفاده از فریم تصویر یک تصویر را به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی فریم تصویر قالب‌بندی کنید.

{{% alert  title="نکته" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد امکان می‌دهد به‌سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک فریم تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage]() ایجاد کنید توسط افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع در دسترس است، ایجاد کنید.  
6. یک فریم تصویر (شامل تصویر) به اسلاید اضافه کنید.  
7. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.  

این کد جاوا نشان می‌دهد که چگونه یک فریم تصویر ایجاد کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک فریم تصویر با ارتفاع و عرض برابر با تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

فریم‌های تصویر به شما امکان می‌دهند به‌سرعت اسلایدهای ارائه مبتنی بر تصاویر را ایجاد کنید. وقتی فریم تصویر را با گزینه‌های ذخیره‌سازی Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک قالب به قالب دیگر مدیریت کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).  

{{% /alert %}}

## **ایجاد فریم تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید فریم تصویر پیچیده‌تری بسازید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) ایجاد کنید توسط افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود.  
5. عرض و ارتفاع نسبی تصویر را در فریم تصویر مشخص کنید.  
6. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.  

این کد جاوا نشان می‌دهد که چگونه فریم تصویر با مقیاس نسبی ایجاد کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // یک فریم تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
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

## **استخراج تصاویر رستر از فریم‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) استخراج کنید و آنها را در قالب PNG، JPG و سایر قالب‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد که چگونه یک تصویر از سند «sample.pptx» استخراج و در قالب PNG ذخیره می‌شود.

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

## **استخراج تصاویر SVG از فریم‌های تصویر**

هنگامی که یک ارائه شامل گرافیک‌های SVG باشد که درون اشکال [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای Java به شما اجازه می‌دهد تا تصاویر برداری اصلی را با صحت کامل بازیابی کنید. با عبور از مجموعه اشکال اسلاید می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید که آیا [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) زیرین دارای محتوای SVG است یا خیر، و سپس آن تصویر را در قالب SVG بومی به دیسک یا جریان ذخیره کنید.

کد مثال زیر نشان می‌دهد که چگونه یک تصویر SVG را از فریم تصویر استخراج کنید:

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

Aspose.Slides به شما امکان می‌دهد تا اثر شفافی که بر روی یک تصویر اعمال شده است را دریافت کنید. این کد جاوا این عملیات را نشان می‌دهد:

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

## **قالب‌بندی فریم تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را برای فریم تصویر ارائه می‌دهد. با استفاده از این گزینه‌ها می‌توانید فریم تصویر را طوری تغییر دهید که با الزامات خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) ایجاد کنید توسط افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مرجع در دسترس است، ایجاد کنید.  
6. فریم تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط فریم تصویر را تنظیم کنید.  
8. عرض خط فریم تصویر را تنظیم کنید.  
9. فریم تصویر را با مقدار مثبت یا منفی چرخانده کنید.  
   * مقدار مثبت تصویر را ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را پادساعت‌گرد می‌چرخاند.  
10. فریم تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.  

این کد جاوا فرآیند قالب‌بندی فریم تصویر را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک فریم تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // برخی قالب‌بندی‌ها را روی PictureFrameEx اعمال می‌کند
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

{{% alert title="نکته" color="primary" %}}

Aspose به‌تازگی یک [ابزار ساخت کلاژ رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به ادغام تصاویر JPG/JPEG یا PNG دارید، یا می‌خواهید گریدهایی از عکس‌ها بسازید، می‌توانید از این سرویس استفاده کنید.  

{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای کاهش حجم بزرگ ارائه‌ها، می‌توانید به‌جای جاسازی مستقیم فایل‌ها، تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید. این کد جاوا نشان می‌دهد که چگونه یک تصویر و ویدیو را به یک جای‌دار اضافه کنید:

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

## **قاب‌بندی تصاویر**

این کد جاوا نشان می‌دهد که چگونه یک تصویر موجود در اسلاید را قاب‌بندی کنید:

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

    // یک فریم تصویر به اسلاید اضافه می‌کند
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

## **حذف نواحی برش‌خورده یک تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر موجود در یک فریم را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورتی که برش لازم نباشد، برمی‌گرداند.

این کد جاوا این عملیات را نشان می‌دهد:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // فریم تصویر را از اولین اسلاید دریافت می‌کند
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // نواحی برش‌خورده تصویر فریم تصویر را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="توجه" color="warning" %}} 

متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش خواهد یافت.

این متد در عملیات برش، پرونده‌های متافایل WMF/EMF را به تصویر رستر PNG تبدیل می‌کند.  

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) یک تصویر را در ارائه فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح تعیین‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را نیز دارد.

این کار به‌طور مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint عمل می‌کند.

مثال‌های جاوا زیر نشان می‌دهند که چگونه می‌توانید یک تصویر را با تعیین وضوح هدف فشرده کنید و در صورت نیاز نواحی برش‌خورده را حذف کنید:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌کند.
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

یا با مقدار DPI سفارشی به‌صورت مستقیم:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // تصویر را به 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌کند.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="توجه" color="warning" %}} 

این متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تر تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی پردازش PowerPoint برای JPEGهای با وضوح بالا.  

{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید یک شکل حاوی تصویر حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم ویژگی *Lock Aspect Ratio* استفاده کنید.  

این کد جاوا نشان می‌دهد که چگونه نسبت ابعاد یک شکل را قفل کنید:

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

    // شکل را تنظیم می‌کند تا نسبت ابعاد را هنگام تغییر اندازه حفظ کند
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="توجه" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* تنها نسبت ابعاد شکل را حفظ می‌کند و نه تصویر موجود در آن.  

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از واسط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat)، می‌توانید یک مستطیل پرکننده تعریف کنید.  

هنگامی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع به‌گونه‌ای مقیاس می‌شود که در مستطیل پرکننده تعریف‌شده جای گیرد. هر لبه از مستطیل پرکننده با درصدی از لبه متناظر جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی را مشخص می‌کند و درصد منفی یک برون‌رفتگی.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبه متناظر جعبه مرزی شکل مشخص کنید.  
9. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.  

این کد جاوا فرآیندی را نشان می‌دهد که در آن ویژگی StretchOff به‌کار گرفته می‌شود:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک نمونه از کلاس ImageEx ایجاد می‌کند
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

    // افست‌های تصویر نسبت به لبه متناظر جعبه مرزی شکل را مشخص می‌کند
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

**چگونه می‌توانم بفهمم که کدام قالب‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**  

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مانند SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست قالب‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**اضافه کردن ده‌ها تصویر بزرگ چه تأثیری بر حجم PPTX و عملکرد دارد؟**  

جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به‌جای جاسازی آن‌ها به‌کاهش حجم ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویری را از جابه‌جایی/تغییر اندازه ناخواسته قفل کنم؟**  

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) استفاده کنید (مثلاً غیر فعال کردن جابه‌جایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقالهٔ جداگانهٔ [حفاظت از ارائه](/slides/fa/java/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال از جمله [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا صحت برداری SVG هنگام استخراج ارائه به PDF/تصاویر حفظ می‌شود؟**  

Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) را به‌عنوان بردار اصلی فراهم می‌کند. هنگام [صادر کردن به PDF](/slides/fa/java/convert-powerpoint-to-pdf/) یا [قالب‌های رستر](/slides/fa/java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به‌صورت رستر باشد؛ اما این که SVG اصلی به‌عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.