---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از جاوا
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/java/picture-frame/
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
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا اضافه کنید. جریان کاری خود را ساده‌سازی کنید و طراحی اسلایدها را بهبود دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که یک تصویر را در خود دارد—مانند یک تصویر درون قاب.

می‌توانید یک تصویر را از طریق قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.

{{% alert  title="Tip" color="info" %}} 
Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به افراد اجازه می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنند. 
{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک شیء [IPPImage]() را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. یک قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. ارائه‌ی اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد جاوا نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // نمونه‌سازی کلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // افزودن یک قاب تصویر با ارتفاع و عرض معادل تصویر
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
قاب‌های تصویر به شما امکان می‌دهند به‌سرعت اسلایدهای ارائه بر پایه تصاویر ایجاد کنید. هنگامی که قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک قالب به قالب دیگر دستکاری کنید. ممکن است این صفحه‌ها برای شما مفید باشند: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/). 
{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد جاوا نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

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
    
    // تعیین مقیاس نسبی عرض و ارتفاع
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

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PictureFrame) استخراج کرده و در قالب‌های PNG، JPG و دیگر قالب‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در قالب PNG ذخیره کنید.

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

زمانی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای Java به شما امکان می‌دهد تصاویر برداری اصلی را با تمام صحت به‌دست آورید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) زیرین محتوی SVG دارد یا خیر، و سپس آن تصویر را به‌صورت SVG اصلی بر روی دیسک یا در یک جریان ذخیره کنید.

مثال کد زیر نحوه استخراج تصویر SVG از یک قاب تصویر را نشان می‌دهد:

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

        // متد getSvgImage مقدار null را برمی‌گرداند وقتی تصویر یک تصویر رستر باشد.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **دریافت شفافیت یک تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیت اعمال‌شده بر یک تصویر را دریافت کنید. این کد جاوا این عملیات را نشان می‌دهد:

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

## **دریافت روشنایی و کنتراست یک تصویر**

Aspose.Slides به شما امکان می‌دهد روشنایی و کنتراست اعمال‌شده بر یک تصویر را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iluminance/) این اثر تبدیل تصویر را نمایش می‌دهد.

این کد جاوا نحوه دریافت تنظیمات روشنایی و کنتراست از یک قاب تصویر را نشان می‌دهد:

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

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توان بر روی یک قاب تصویر اعمال کرد، فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را طوری تغییر دهید که با نیازهای خاص مطابقت داشته باشد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) مرتبط با شیء ارائه ایجاد کنید تا برای پر کردن شکل استفاده شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. ضخامت خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی می‌چرخانید.  
   * مقدار مثبت تصویر را ساعتگرد می‌چرخاند.  
   * مقدار منفی تصویر را پادساعتگرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد جاوا فرایند قالب‌بندی قاب تصویر را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;
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
    
    // اعمال برخی قالب‌بندی‌ها به PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose به‌تازگی یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) ایجاد کرده است. اگر نیاز به ترکیب تصاویر JPG/JPEG یا PNG، یا ایجاد گرید از عکس‌ها دارید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدئوها) را از طریق لینک اضافه کنید به‌جای آنکه فایل‌ها را مستقیماً درون ارائه جاسازی کنید. این کد جاوا نشان می‌دهد چگونه یک تصویر و ویدئو را به یک جایگزین افزود:

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

این کد جاوا نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// ایجاد شیء تصویر جدید
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // افزودن یک PictureFrame به اسلاید
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // برش تصویر (مقدارهای درصدی)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // ذخیره نتایج
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف نواحی برش‌خورده یک تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر موجود در قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورتی که برش لازم نباشد، برمی‌گرداند.

این کد جاوا این عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دریافت PictureFrame از اولین اسلاید
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // حذف نواحی برش‌خورده تصویر PictureFrame و برگرداندن تصویر برش‌خورده
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // ذخیره نتایج
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش خواهد یافت.  

این متد در عملیات برش، فایل‌های متایفیل WMF/EMF را به تصویر رستر PNG تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در ارائه را با استفاده از متد [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را نیز دارد.

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌کند.

مثال‌های جاوا زیر نشان می‌دهند چگونه یک تصویر را با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده فشرده کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // فشرده‌سازی تصویر با وضوح هدف 150 DPI (وضوح وب) و حذف نواحی برش‌خورده.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // نتیجه فشرده‌سازی را بررسی کنید.
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

یا به‌طور مستقیم با مقدار DPI سفارشی:

```java
import com.aspose.slides.*;

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
این متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متایفیل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، همانند رفتار PowerPoint برای JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید یک شکل حاوی تصویر پس از تغییر ابعاد تصویر نسبت ابعاد خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید. 

این کد جاوا نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

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

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویر داخل آن. 
{{% /alert %}}

## **استفاده از خاصیت StretchOff**

با استفاده از خصوصیات [StretchOffsetLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPictureFillFormat) می‌توانید یک مستطیل پر را مشخص کنید. 

هنگامی که کشش برای یک تصویر مشخص شود، یک مستطیل منبع مقیاس‌دهی می‌شود تا به مستطیل پر تعیین‌شده بگنجد. هر لبه‌ی مستطیل پر با یک درصد جابجایی نسبت به لبه‌ی متناظر جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی داخلی و درصد منفی یک برون‌رفتگی را نشان می‌دهد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. تصویری را برای پر کردن شکل اضافه کنید.  
8. جابجایی‌های تصویر را نسبت به لبه‌ی متناظر جعبه مرزی شکل مشخص کنید.  
9. ارائه‌ی اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد جاوا فرایندی را که در آن خاصیت StretchOff استفاده می‌شود، نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // نمونه‌سازی کلاس ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // افزودن یک AutoShape از نوع Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // تنظیم نوع پر کردن شکل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // تنظیم حالت پر کردن تصویر برای شکل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تنظیم تصویر برای پر کردن شکل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // مشخص‌کردن جابجایی‌های تصویر نسبت به لبه‌ی متناظر جعبه مرزی شکل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //نوشتن فایل PPTX بر روی دیسک
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤال‌های متداول**

### چگونه می‌توانم بفهمم چه قالب‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مانند SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) اختصاص یافته است، پشتیبانی می‌کند. فهرست قالب‌های پشتیبانی‌شده معمولاً با توانمندی‌های موتور تبدیل اسلاید و تصویر هم‌پوشانی دارد.

### افزودن ده‌ها تصویر بزرگ چگونه بر اندازه و عملکرد PPTX تأثیر می‌گذارد؟

جاسازی تصاویر بزرگ اندازه فایل و مصرف حافظه را افزایش می‌دهد؛ لینک دادن به تصاویر به کاهش اندازه ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

### چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازه ناخواسته محافظت کنم؟

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال‌سازی جابجایی یا تغییر اندازه). مکانیزم قفل‌گذاری در مقاله‌ی جداگانه‌ی [حفاظت](/slides/fa/java/applying-protection-to-presentation/) توصیف شده است و برای انواع مختلف شکل‌ها از جمله [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) پشتیبانی می‌شود.

### آیا صحت برداری SVG هنگام صادرات ارائه به PDF/تصاویر حفظ می‌شود؟

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) به‌صورت بردار اصلی را فراهم می‌کند. هنگام [صادرات به PDF](/slides/fa/java/convert-powerpoint-to-pdf/) یا [قالب‌های رستر](/slides/fa/java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به رستر تبدیل شود؛ اما این که SVG اصلی به‌عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.