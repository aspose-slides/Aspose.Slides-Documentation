---
title: مدیریت چارچوب‌های تصویر در ارائه‌ها روی اندروید
linktitle: چارچوب تصویر
type: docs
weight: 10
url: /fa/androidjava/picture-frame/
keywords:
- چارچوب تصویر
- افزودن چارچوب تصویر
- ایجاد چارچوب تصویر
- تصویر تعبیه‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی چارچوب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی چارچوب‌های تصویر در ارائه‌ها با Aspose.Slides برای اندروید از طریق جاوا."
---
## **Overview**

یک چارچوب تصویر (Picture Frame) یک شکل اسلاید است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نشان می‌دهد به‌صورت اشیاء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) منابع تصویر تعبیه‌شده را از طریق [IImageCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/) مالک می‌شود، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، کراپ، افکت‌های تصویر و سایر تنظیمات سطح چارچوب را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) بازگردانده‌شده را نگه دارید و هنگام ایجاد چارچوب‌های تصویر از همان منبع تصویر استفاده کنید.

چارچوب‌های تصویر می‌توانند تصاویر رستری مانند PNG یا JPEG و تصاویر برداری SVG را دربرگیرند. همچنین می‌توانند به تصاویر پیوندی ارجاع دهند به‌جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، اندازه فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری در مورد نحوه ذخیره‌سازی تصویر ضروری است.

## **Add and Format an Embedded Image**

برای یک تصویر تعبیه‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک چارچوب تصویر با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگری خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG را اضافه می‌کند، چارچوبی با ابعاد بومی تصویر می‌سازد و قالب‌بندی خطوط و چرخش را اعمال می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

چارچوب تصویر هندسهٔ نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه چارچوب باعث تغییر ابعاد پیکسلی اصلی ذخیره‌شده در منبع تصویر تعبیه‌شده نمی‌شود. این تفاوت زمانی مهم می‌شود که بعدها بخواهید تصویر را کراپ یا فشرده کنید.

## **Use Relative Scale**

[IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) مقیاس عرض و ارتفاع نسبی چارچوب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) در دسترس می‌گذارد. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کار نیاز به حفظ نسبت به اندازهٔ تصویر منبع داشته باشد به‌جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقیاس نسبی تنظیمات مقیاس چارچوب را تغییر می‌دهد؛ اما تصویر تعبیه‌شده را بازنمونه‌گیری یا فشرده نمی‌کند.

## **Embedded and Linked Images**

یک تصویر تعبیه‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شده ایمن‌ترین گزینه است. یک تصویر پیوندی مسیر خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای تعبیهٔ مستقیم داده‌های تصویر.

تصاویر پیوندی می‌توانند میزان دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند قابل دسترسی باشد. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید از طریق ایمیل ارسال، بایگانی یا در محیط‌های جداگانه رندر شوند، تصاویر تعبیه‌شده معمولاً قابل اطمینان‌تر هستند.

### **Add a Linked Image**

مثال زیر یک چارچوب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط با پیوند تصویر سروکار دارد؛ پیوند ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال مخلوط نشده است.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ بزرگتر و خودکفا.

## **Extract Images from Picture Frames**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) باشد و حاوی یک تصویر تعبیه‌شده باشد. چارچوب‌های تصویر پیوندی ممکن است بایت‌های تصویری که به همان شکل می‌توان استخراج کرد را نداشته باشند.

### **Extract a Raster Image**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند و نیازی به بسته‌بند تصویر قدیمی جاوا ندارد. مثال زیر اولین تصویر رستری تعبیه‌شده روی یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

ذخیره‌سازی از طریق [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به فرمت خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های رمزگذاری‌شدهٔ ذخیره‌شده در ارائه نیاز دارید تا یک فایل رستری تبدیل‌شده نه، به جای آن از دادهٔ باینری منبع تصویر استفاده کنید.

### **Extract an SVG Image**

برای یک تصویر SVG، شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) را در دسترس می‌گذارد. این امکان را می‌دهد که دادهٔ SVG را به‌صورت مستقیم دریافت کنید به‌جای اینکه ابتدا تصویر را رستری کنید.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

نگه‌داشتن محتوای SVG به‌صورت SVG، منبع برداری داخل ارائه را حفظ می‌کند. صادرات رستری مانند PNG یا JPEG مجبور است آن محتوای برداری را به پیکسل رندر کند. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان یک کپی بایت‌به‌بایت از SVG تعبیه‌شده در نظر گرفته شوند؛ در صورت نیاز به منبع برداری اصلی، از دادهٔ [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **Crop an Image**

کروپ کردن بخشی از تصویر را که داخل چارچوب قابل مشاهده است تغییر می‌دهد. مقادیر کراپ در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) به‌صورت درصدی از ابعاد تصویر منبع محاسبه می‌شوند. کراپ کردن در ابتدا پیکسل‌های مخفی را از تصویر تعبیه‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر یک چارچوب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر کراپ را اعمال می‌نماید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

از آنجا که دادهٔ تصویر مخفی همچنان موجود است، می‌توان کراپ را بعدها بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر کاهش حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان ناحیه‌های کراپ‌شده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **Remove Cropped Image Data**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل کراپ فعلی را حذف می‌کند و منبع تصویر حاصل را بازمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «باز‑کراپ» در دسترس نیستند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط چارچوب‌های تصویر دیگر نیز استفاده شود، آن چارچوب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی کراپ‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. کراپ کردن محتوای WMF یا EMF با این متد نتیجهٔ کراپ‌شده را به PNG رستری می‌کند.

## **Compress Raster Images**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر رستری را نسبت به سایزی که تصویر نمایش داده می‌شود، کاهش می‌دهد. همچنین می‌تواند نواحی کراپ‌شده را در همان عملیات حذف کند. این متد زمانی که تصویر تغییر اندازه یا کراپ شده باشد `true` و در غیر این صورت `false` برمی‌گرداند.

زمانی که یک وضوح هدف استاندارد کافی است، می‌توانید از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturescompression/) استفاده کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

به‌جای مقدار پیش‌تعریف‌شده می‌توان یک مقدار DPI مثبت سفارشی نیز ارسال کرد وقتی هدف خاصی مورد نیاز است.

فشرده‌سازی برای تصاویر رستری در نظر گرفته شده است. محتوای SVG و متافایل توسط این کارکرد فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح کمتر و نواحی کراپ‌شده حذف‌شده نمی‌توانند از ارائه بهینه‌سازی‌شده بازیابی شوند. برای هدف‌گذاری وضوح، بزرگ‌ترین اندازه‌ای را که تصویر در واقع نمایش یا صادرات خواهد شد در نظر بگیرید نه این‌که کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **Inspect Image Effects**

افکت‌های تصویر بر روی تصویری که چارچوب استفاده می‌کند ذخیره می‌شوند. مجموعهٔ تبدیل تصویر می‌تواند شامل افکت‌هایی مانند مدولاسیون آلفای ثابت برای شفافیت و لومن برای روشنایی و کنتراست باشد. مثال زیر به‌صورت ایمن هر دو نوع افکت را از اولین چارچوب تصویر روی یک اسلاید می‌خواند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

این افکت‌ها نحوهٔ رندر تصویر در چارچوب را تغییر می‌دهند؛ بایت‌های تصویر تعبیه‌شدهٔ اصلی را بازنویسی نمی‌کنند.

## **Lock Picture Frame Geometry**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/) کنترل می‌کنند که کدام عملیات ویرایشی برای یک چارچوب تصویر غیرفعال باشند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قفل بر روی شکل چارچوب تصویر اعمال می‌شود. این قفل موجب بازنمونه‌گیری یا تغییر دائمی نسبت ابعاد تصویر منبع نمی‌شود.

## **Adjust the StretchOffset Values**

زمانی که حالت پرکردن تصویر «stretch» باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) مستطیل پر کردن را نسبت به جعبهٔ محدود‌کنندهٔ چارچوب تصویر تعریف می‌کنند. درصدهای مثبت یک حاشیهٔ داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیهٔ خارجی ایجاد می‌نمایند.

این متفاوت از کراپ است. مقادیر کراپ تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده است؛ در حالی که stretch‑offset مستطیل را که تصویر پر شده در آن کشیده می‌شود، تغییر می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از stretch‑offset برای جای‌گذاری پرکردن استفاده کنید. وقتی هدف مخفی کردن لبه‌های تصویر منبع است، از خصوصیات کراپ بهره بگیرید.

## **Storage, File Size, and Export Considerations**

معاملات اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی چارچوب تصویر به‌صورت جداگانه در نظر گرفته شوند:

- **Embedded images** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **Linked images** می‌توانند بستهٔ ارائه را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی در مسیرهای ذخیره‌شده وابسته می‌شود.
- **Cropping** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی کراپ‌شده به‌طور صریح حذف یا در حین فشرده‌سازی حذف نشوند، تعبیه می‌مانند.
- **Compression** می‌تواند حجم فایل را برای تصاویر رستری بزرگ به‌طرز قابل‌توجهی کاهش دهد، اما وضوح منبع را فدا می‌کند. این کار باید پس از دانستن اندازهٔ نهایی تصویر روی اسلاید اعمال شود.
- **SVG images** باید به‌عنوان SVG باقی بمانند زمانی که حفظ بردار مهم است. وقتی به منبع برداری خود نیاز دارید، SVG تعبیه‌شده را به‌صورت مستقیم استخراج کنید. صادرات اسلاید به صورت رستری همیشه تصویر رندر‌شده را به پیکسل تبدیل می‌کند.
- **Repeated images** در صورت امکان باید یک منبع [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) موجود را بازاستفاده کنند به‌جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتواهای برداری نگه دارید، عکس‌ها را متناسب با اندازهٔ نمایش واقعی‌شان فشرده کنید، پیکسل‌های کراپ‌شده را تنها زمانی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی تا زمانی که مدیریت وابستگی بخشی از طراحی استقرار باشد، اجتناب کنید.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

یک [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) نمایانگر منبع تصویری است که با ارائه مرتبط است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح چارچوب مانند اندازه، چرخش, مقادیر کراپ، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**Should I embed or link images?**

وقتی ارائه باید قابل حمل، بایگانی یا رندر بدون دسترسی به منابع خارجی باشد، تصویر را تعبیه کنید. فقط زمانی که نگهداری فایل‌های تصویر خارج از PPTX هدفمند است و مکان‌های خارجی می‌توانند به‌طور قابل‌اعتماد نگهداری شوند، تصویر را پیوند دهید.

**Does cropping reduce PPTX file size?**

خود کراپ اندازهٔ فایل PPTX را کاهش نمی‌دهد. تنظیمات کراپ معمولی قسمت‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را حفظ می‌کند. برای حذف دائمی پیکسل‌ها می‌توانید از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر با حذف نواحی کراپ‌شده استفاده کنید.

**Can I restore image quality after compression?**

نه. فشرده‌سازی می‌تواند وضوح رستری ذخیره‌شده را کاهش دهد و حذف نواحی کراپ‌شده دادهٔ تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا بعداً لازم باشد، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**How should SVG images be handled?**

وقتی وفاداری برداری مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) تعبیه‌شده را به‌صورت مستقیم استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG SVG را به پیکسل تبدیل می‌کند.

**How can I avoid unsafe casts when reading existing slides?**

قبل از استفاده از اعضای مخصوص چارچوب تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` در برابر [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) باعث می‌شود از تبدیل‌های نامعتبر جلوگیری کنید و کد بتواند اسلایدهایی که شامل چارچوب تصویر نیستند را به‌درستی مدیریت کند.