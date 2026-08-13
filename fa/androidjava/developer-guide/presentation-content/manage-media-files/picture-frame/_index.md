---
title: مدیریت قاب‌های تصویر در ارائه‌ها بر روی Android
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
- تصویر رستری
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
- Android
- Java
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java اضافه کنید. جریان کاری خود را ساده کنید و طراحی اسلایدها را بهبود بخشید."
---
## **مقدمه**

یک قاب تصویر شکلی است که حاوی یک تصویر است—مانند یک تصویر در داخل یک قاب.  

شما می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.  

{{% alert title="نکته" color="info" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد اجازه می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند.  
{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage]() ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مربوط به شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را تعیین کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. یک قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.  

این کد Java نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.IOException;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک قاب تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مربوط به شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.  

این کد Java نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
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

## **استخراج تصاویر رستری از قاب‌های تصویر**

می‌توانید تصاویر رستری را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PictureFrame) استخراج کنید و در فرمت‌های PNG، JPG و سایر فرمت‌ها ذخیره نمایید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند "sample.pptx" استخراج کرده و در فرمت PNG ذخیره کنید.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

زمانی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تصاویر برداری اصلی را با تمام دقت بازیابی کنید. هنگامی که یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) داشته باشید که [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) شامل محتوای SVG است، می‌توانید آن تصویر SVG را بخوانید و به‌صورت بومی در فرمت SVG بر روی دیسک یا جریان ذخیره کنید.  

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:  

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

Aspose.Slides به شما امکان می‌دهد افکت شفافیت اعمال‌شده به یک تصویر را به‌دست آورید. این کد Java این عملیات را نشان می‌دهد:  

```java
import com.aspose.slides.*;

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

Aspose.Slides به شما امکان می‌دهد افکت روشنایی و کنتراست اعمال‌شده به یک تصویر را به‌دست آورید. اینترفیس [ILuminance](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iluminance/) نمایان‌گر این اثر تبدیل تصویر است.  

این کد Java نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:  

```java
import com.aspose.slides.*;

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

Aspose.Slides گزینه‌های قالب‌بندی متعددی ارائه می‌دهد که می‌توان بر یک قاب تصویر اعمال کرد. با استفاده از این گزینه‌ها، می‌توانید قاب تصویر را طوری تغییر دهید که متناسب با نیازهای خاص باشد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) مربوط به شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را تعیین کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. یک قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. ضخامت خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخانده کنید.  
   * یک مقدار مثبت تصویر را به‌صورت ساعتگرد می‌چرخاند.  
   * یک مقدار منفی تصویر را به‌صورت پادساعتگرد می‌چرخاند.  
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.  

این کد Java فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:  

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمونه از کلاس Image ایجاد می‌کند
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // یک قاب تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
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

{{% alert title="نکته" color="info" %}} 
Aspose به‌تازگی یک [ابزار ساخت کولیج رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، یا [ایجاد شبکه‌ها از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) دارید، می‌توانید از این سرویس استفاده کنید.  
{{% /alert %}} 

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدئوها) را از طریق لینک‌ها اضافه کنید به‌جای اینکه فایل‌ها را مستقیماً در ارائه جاسازی کنید. این کد Java نشان می‌دهد چگونه یک تصویر و ویدئو را به یک محل‌نگهدارنده اضافه کنید:  

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

این کد Java نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// یک شیء تصویر جدید ایجاد می‌کند
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک PictureFrame به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // تصویر را برش می‌دهد (مقادیر درصدی)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // نتیجه را ذخیره می‌کند
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف نواحی برش داده شده یک تصویر**

اگر می‌خواهید نواحی برش داده‌شده یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌داده‌شده یا تصویر اصلی را در صورت عدم نیاز به برش باز می‌گرداند.  

این کد Java عملیات را نشان می‌دهد:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // قاب تصویر را از اولین اسلاید دریافت می‌کند
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // نواحی برش‌خورده تصویر قاب را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="توجه" color="warning" %}} 
متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌داده‌شده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش خواهد یافت.  

این متد در عملیات برش، فایل‌های متافایل WMF/EMF را به تصویر رستری PNG تبدیل می‌کند.  
{{% /alert %}} 

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در ارائه را با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) فشرده کنید.  
این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح تعیین‌شده، و با امکان حذف نواحی برش‌داده‌شده، فشرده می‌کند.  

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format > Compress Pictures > Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های Java زیر نشان می‌دهند چگونه یک تصویر را در یک ارائه با مشخص کردن وضوح هدف و به‌طور اختیاری حذف نواحی برش‌داده‌شده فشرده کنید:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // فشرده‌سازی تصویر با وضوح هدف 150 DPI (وضوح وب) و حذف نواحی برش‌خورده.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // بررسی نتیجه فشرده‌سازی.
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

یا به‌طور مستقیم با استفاده از مقدار DPI سفارشی:  

```java
import com.aspose.slides.*;

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

{{% alert title="توجه" color="warning" %}} 
این متد تصویر را به وضوح پایین‌تری بر اساس اندازه شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی برش‌داده‌شده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین، کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی عملکرد PowerPoint با JPEGهای با وضوح بالا.  
{{% /alert %}} 

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید یک شکل حاوی تصویر نسبت ابعاد خود را حتی پس از تغییر ابعاد تصویر حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

این کد Java نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:  

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // تنظیم شکل برای حفظ نسبت ابعاد هنگام تغییر اندازه
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="توجه" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویر داخل آن.  
{{% /alert %}} 

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از اینترفیس [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPictureFillFormat) می‌توانید یک مستطیل پرکننده تعیین کنید.  

وقتی کشیدگی برای یک تصویر مشخص می‌شود، یک مستطیل منبع برای تناسب با مستطیل پرکننده تعیین‌شده مقیاس می‌شود. هر لبه از مستطیل پرکننده با یک جابجایی درصدی از لبه متناظر جعبه محدوده شکل تعریف می‌شود. یک درصد مثبت نشان‌دهنده تو رفتگی داخلی و یک درصد منفی نشان‌دهنده بیرون‌زدگی است.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. جابه‌جایی‌های تصویر را از لبه متناظر جعبه محدوده شکل مشخص کنید.  
9. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.  

این کد Java فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
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

    // حالت پر کردن تصویر برای شکل را تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تصویر را برای پر کردن شکل تنظیم می‌کند
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // افست‌های تصویر را نسبت به لبه متناظر جعبه مرزی شکل مشخص می‌کند
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

### چگونه می‌توانم متوجه شوم که چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟

Aspose.Slides هم تصاویر رستری (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.  

### افزودن ده‌ها تصویر بزرگ چطور بر اندازه و عملکرد فایل PPTX تأثیر می‌گذارد؟

جاسازی تصویرهای بزرگ باعث افزایش حجم فایل و مصرف حافظه می‌شود؛ لینک‌کردن تصاویر به‌حفظ اندازهٔ ارائه کمک می‌کند اما نیاز دارد که فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصویر به‌صورت لینک برای کاهش حجم فایل را فراهم می‌کند.  

### چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازهٔ تصادفی قفل کنم؟

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) استفاده کنید (به‌عنوان مثال، غیرفعال کردن جابجایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای انواع مختلف شکل‌ها پشتیبانی می‌شود، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/).  

### آیا دقت برداری SVG هنگام خروجی گرفتن ارائه به PDF/تصاویر حفظ می‌شود؟

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) به‌صورت بردار اصلی را فراهم می‌کند. هنگام [خروجی به PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) یا [فرمت‌های رستری](/slides/fa/androidjava/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی به رستر تبدیل شود؛ این حقیقت که SVG اصلی به‌عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.