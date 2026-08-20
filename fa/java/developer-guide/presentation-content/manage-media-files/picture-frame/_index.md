---
title: مدیریت چارچوب‌های تصویر در ارائه‌ها با استفاده از جاوا
linktitle: چارچوب تصویر
type: docs
weight: 10
url: /fa/java/picture-frame/
keywords:
- چارچوب تصویر
- افزودن چارچوب تصویر
- ایجاد چارچوب تصویر
- تصویر تعبیه‌شده
- تصویر پیوست‌شده
- استخراج تصویر
- تصویر نقطه‌ای
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی چارچوب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوست، برش، استخراج و فشرده‌سازی چارچوب‌های تصویر در ارائه‌ها با Aspose.Slides برای جاوا."
---
## **بررسی اجمالی**

یک چارچوب تصویر (Picture Frame) یک شکل اسلاید است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نشان می‌دهد، اشیاء جداگانه‌ای هستند: یک [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) منابع تصویر تعبیه‌شده را از طریق [IImageCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagecollection/) خود در اختیار دارد، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح چارچوب را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) بازگردانده‌شده را نگه دارید و هنگام ایجاد چارچوب‌های تصویر از آن منبع تصویر استفاده کنید.

چارچوب‌های تصویر می‌توانند شامل تصاویر نقطه‌ای مانند PNG یا JPEG و تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر پیوست‌شده (linked) ارجاع دهند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین تعیین نحوه ذخیره‌سازی تصویر قبل از اعمال قالب‌بندی یا بهینه‌سازی مفید است.

## **افزودن و قالب‌بندی یک تصویر تعبیه‌شده**

برای یک تصویر تعبیه‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک چارچوب تصویر با استفاده از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، به‌طوری که ارائه هنگام انتقال به رایانه دیگر به‌صورت خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، چارچوبی با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خطوط و چرخش را اعمال می‌نماید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

چارچوب تصویر هندسه نمایش‌داده‌شده را کنترل می‌کند؛ تغییر اندازه چارچوب باعث تغییر ابعاد پیکسلی اصلی ذخیره‌شده در منبع تصویر تعبیه‌شده نمی‌شود. این تفاوت زمانی مهم می‌شود که بعداً تصویر برش یا فشرده شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) مقیاس نسبی عرض و ارتفاع چارچوب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) فراهم می‌کند. مقدار `1.0` معادل 100٪ از اندازه تصویر اصلی است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز داشته باشد رابطه‌ای با اندازه تصویر منبع حفظ کند به جای محاسبه دستی ابعاد نهایی.

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

مقیاس نسبی تنظیمات مقیاس چارچوب را تغییر می‌دهد؛ تصویر تعبیه‌شده را بازنمونه‌برداری یا فشرده نمی‌کند.

## **تصاویر تعبیه‌شده و پیوست‌شده**

یک تصویر تعبیه‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین امن‌ترین گزینه برای قابلیت حمل و رندر قابل پیش‌بینی است. یک تصویر پیوست‌شده موقعیت خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به جای تعبیه داده‌های تصویر به همان صورت.

تصاویر پیوست‌شده می‌توانند مقدار داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوست‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، قابل دسترسی باشد. اگر مسیر تغییر کند، فایل جا به جا شود یا منبع در دسترس نباشد، تصویر پیوست‌شده ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های جداگانه رندر شوند، تصاویر تعبیه‌شده معمولاً قابل اعتمادتر هستند.

### **افزودن یک تصویر پیوست‌شده**

مثال زیر یک چارچوب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدئو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

هنگامی که مدیریت فایل‌های خارجی هدفمند است از لینک‌ها استفاده کنید. آنها را صرفاً به‌عنوان جایگزین فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائه بزرگتر خودکفا.

## **استخراج تصاویر از چارچوب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) باشد و شامل تصویر تعبیه‌شده باشد. چارچوب‌های تصویر پیوست‌شده ممکن است بایت‌های تصویری نداشته باشند که به همان روش استخراج شوند.

### **استخراج تصویر نقطه‌ای**

API تصویر مدرن به‌صورت مستقیم از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) استفاده می‌کند و نیازی به بسته‌بند تصویر جاوا قدیمی ندارد. مثال زیر اولین تصویر نقطه‌ای تعبیه‌شده روی یک اسلاید را پیدا می‌کند و به صورت PNG ذخیره می‌نماید:

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

ذخیره‌سازی با استفاده از [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به فرمت خروجی مورد درخواست تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده ذخیره‌شده در ارائه به جای فایل نقطه‌ای تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) را نمایان می‌سازد. این امکان را می‌دهد که داده‌های SVG را مستقیماً دریافت کنید به‌جای اینکه ابتدا تصویر را به نقطه‌ای تبدیل کنید.

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

نگه‌داشتن محتوای SVG به‌عنوان SVG منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های نقطه‌ای مانند PNG یا JPEG الزاما آن محتوای برداری را به پیکسل‌ها رندر می‌کند. خروجی اسلاید به صورت PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک نسخه بایت به بایت از SVG تعبیه‌شده اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از دادهٔ تعبیه‌شده‌ی [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **برش یک تصویر**

برش بخشی از تصویر را که داخل چارچوب قابل مشاهده است تغییر می‌دهد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) به صورت درصدی از ابعاد تصویر منبع هستند. برش در ابتدا پیکسل‌های پنهان را از تصویر تعبیه‌شده حذف نمی‌کند؛ فقط ناحیه قابل مشاهده را تغییر می‌دهد.

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

از آنجا که داده‌های تصویر پنهان هنوز موجود هستند، برش می‌تواند بعدها بدون از دست رفتن پیکسل‌های اصلی تغییر یابد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، نواحی برش‌خورده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش فعلی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما بهینه‌سازی مخربی است: پس از ذخیره‌سازی ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات بازگردانی برش در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط چارچوب‌های تصویر دیگر نیز استفاده شود، آن چارچوب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجه برش را به PNG نقطه‌ای تبدیل می‌کند.

## **فشرده‌سازی تصاویر نقطه‌ای**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر نقطه‌ای را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد زمانی که تصویر تغییر اندازه یا برش یافت `true` و زمانی که نیازی به تغییر نبود `false` برمی‌گرداند.

هنگامی که رزولوشن هدف استاندارد کافی است، از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturescompression/) استفاده کنید:

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

یک مقدار DPI مثبت سفارشی می‌تواند به‌جای مقدار پیش‌تعریف‌شده هنگام نیاز به هدف خاص پاس داده شود.

فشرده‌سازی برای تصاویر نقطه‌ای در نظر گرفته شده است. محتوای SVG و متافایل توسط این جریان کار فشرده‌سازی نقطه‌ای کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌خورده حذف‌شده نمی‌توانند از ارائه بهینه‌شده بازیابی شوند. رزولوشن هدف را بر اساس بزرگ‌ترین اندازه‌ای که تصویر واقعا مشاهده یا صادر خواهد شد انتخاب کنید نه این‌که کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **بررسی افکت‌های تصویر**

افکت‌های تصویر بر روی تصویری که چارچوب استفاده می‌کند ذخیره می‌شوند. مجموعهٔ تبدیل تصویر می‌تواند شامل افکت‌هایی مانند ماژولاسیون آلفای ثابت برای شفافیت و روشنایی برای تنظیم روشنایی و کنتراست باشد. مثال زیر به‌صورت ایمن هر دو نوع افکت را از اولین چارچوب تصویر روی یک اسلاید می‌خواند:

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

این افکت‌ها نحوهٔ رندر تصویر در چارچوب را تغییر می‌دهند؛ آنها بایت‌های تصویر تعبیه‌شدهٔ اصلی را بازنویسی نمی‌کنند.

## **قفل‌کردن هندسه چارچوب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/) کنترل می‌کند که کدام عملیات ویرایشی برای یک چارچوب تصویر غیرفعال هستند. برای مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت طول و عرض شکل را هنگام تغییر سایز حفظ می‌کند.

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

قفل بر روی شکل چارچوب تصویر اعمال می‌شود. این قفل تصویر منبع را مجبور به بازنمونه‌برداری یا تغییر دائمی به همان نسبت طول و عرض نمی‌کند.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر به‌صورت کشش (stretch) باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) مستطیل پرش را نسبت به جعبه حدی چارچوب تصویر تعریف می‌کنند. درصدهای مثبت یک تورفتگی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک برآمدگی ایجاد می‌کنند.

این با برش متفاوت است. مقادیر برش بخشی از تصویر منبع را که قابل مشاهده است انتخاب می‌کند؛ مقادیر stretch offset مستطیلی را که پرکردن تصویر قابل مشاهده به آن کشیده می‌شود تغییر می‌دهند.

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

از stretch offset برای موقعیت‌گذاری پر کردن استفاده کنید. زمانی که هدف پنهان کردن لبه‌های تصویر منبع باشد از ویژگی‌های برش استفاده کنید.

## **نکات مربوط به ذخیره‌سازی، حجم فایل و صادرات**

معامله‌های اصلی زمانی که ذخیره‌سازی تصویر و قالب‌بندی چارچوب تصویر به‌صورت جداگانه در نظر گرفته شوند، مدیریت آسان‌تری دارند:

- **تصاویر تعبیه‌شده** ارائه را خودکفا می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور بیشترین قابلیت اطمینان را دارند، اما تصاویر نقطه‌ای بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوست‌شده** می‌توانند بسته را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌های مشخص وابسته است.
- **برش** در ابتدا تخریبی نیست. پیکسل‌های پنهان تا زمانی که نواحی برش‌خورده به‌صورت صریح حذف یا در حین فشرده‌سازی برداشته نشوند، تعبیه می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را به‌طور قابل‌توجهی برای تصاویر نقطه‌ای بزرگ کاهش دهد، اما وضوح منبع را از بین می‌برد. باید پس از دانستن اندازهٔ موردنظر تصویر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی حفظ بردار مهم است. هنگام نیاز به منبع برداری اصلی، SVG تعبیه‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید نقطه‌ای همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** در صورت امکان باید از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) موجود استفاده کنند، نه اینکه بارها همان فایل را در جریان کاری ارائه بارگذاری کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثرتر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازهٔ نمایش واقعی‌شان فشرده کنید، پیکسل‌های برش‌خورده را فقط در صورتی که ویرایش بعدی لازم نیست حذف کنید و از لینک‌های خارجی خودداری کنید مگر اینکه مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **FAQ**

**تفاوت بین چارچوب تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح چارچوب مانند اندازه، چرخش, مقادیر برش, افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را تعبیه یا پیوست کنم؟**

تصاویر را زمانی تعبیه کنید که ارائه باید قابل حمل، بایگانی یا رندر شود بدون دسترسی به منابع خارجی. تصاویر را فقط زمانی پیوست کنید که نگه‌داشتن فایل‌های تصویر خارج از PPTX هدفمند باشد و مکان‌های خارجی به‌طور قابل‌اعتمادی نگهداری شوند.

**آیا برش باعث کاهش حجم فایل PPTX می‌شود؟**

خود به‌خود نه. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را حفظ می‌کند. زمانی که می‌توانید این پیکسل‌ها را برای همیشه حذف کنید، از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر همراه با حذف نواحی برش استفاده کنید.

**آیا می‌توانم کیفیت تصویر را پس از فشرده‌سازی بازیابی کنم؟**

نه. فشرده‌سازی می‌تواند وضوح نقطه‌ای ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌های تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا در آینده ممکن است لازم باشد، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG برخورد کرد؟**

وقتی حفظ صحت بردار مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) تعبیه‌شده می‌تواند به‌صورت مستقیم استخراج شود. رندر کردن یک اسلاید به فرمت نقطه‌ای مانند PNG یا JPEG، SVG را به عنوان بخشی از تصویر اسلاید نقطه‌ای می‌کند.

**چگونه می‌توانم از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کنم؟**

قبل از استفاده از اعضای خاص چارچوب تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` نسبت به [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) از تبدیل‌های نادرست جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که شامل چارچوب تصویر نیستند را مدیریت کند.