---
title: مدیریت قاب‌های تصویر در ارائه‌ها در Android
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/androidjava/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- تصویر جاسازی‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها با Aspose.Slides برای Android از طریق Java ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید."
---
## **بررسی کلی**

قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد، اشیاء جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) مالک منابع تصویر جاسازی‌شده از طریق [IImageCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/)، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی وقتی که یک تصویر بیش از یک بار نمایش داده شود مفید است. تصویر را یک‌بار به ارائه اضافه کنید، شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) برگردانده‌شده را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را دربر بگیرند. همچنین می‌توانند به تصاویر پیوندی ارجاع دهند به جای ذخیره بایت‌های تصویر در ارائه. انتخاب این گزینه بر قابلیت حمل، اندازه فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری درباره نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کرده و یک قاب تصویر با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین وقتی ارائه به رایانه دیگری منتقل شود، همچنان خودمختار می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، یک قاب با ابعاد بومی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌نماید:

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

قاب تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز زمانی که پس از آن بخواهید تصویر را برش یا فشرده کنید، مهم می‌شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) مقیاس عرض و ارتفاع نسبی قاب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) در دسترس قرار می‌دهد. مقدار `1.0` معادل 100٪ اندازه اصلی تصویر است. مقیاس نسبی وقتی که یک گردش کار نیاز به حفظ نسبت به اندازه تصویر منبع داشته باشد مفید است، به جای محاسبه دستی ابعاد نهایی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ آن تصویر جاسازی‌شده را بازنمونه‌گیری یا فشرده‌سازی نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شده ایمن‌ترین گزینه است. یک تصویر پیوندی به‌جای جاسازی داده‌های تصویر، مکان خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند.

تصاویر پیوندی می‌توانند میزان داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اعتمادتر هستند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک گردش کار رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی عمدی باشد. تنها به عنوان جایگزین فشرده‌سازی از آن‌ها استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائه بزرگ خودمختار.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از ارائه موجود، اطمینان حاصل کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) است و حاوی تصویر جاسازی‌شده می‌باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری نداشته باشند که به همان روش استخراج شوند.

### **استخراج تصویر رستر**

API تصویر مدرن به‌صورت مستقیم از [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) استفاده می‌کند و نیازی به بسته‌بند تصویر قدیمی جاوا نیست. مثال زیر اولین تصویر رستر جاسازی‌شده را در یک اسلاید پیدا می‌کند و به‌صورت PNG ذخیره می‌کند:

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

ذخیره از طریق [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به قالب خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده ذخیره‌شده در ارائه به‌جای یک فایل رستر تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) را نشان می‌دهد. این امکان را می‌دهد تا داده‌های SVG را مستقیماً به‌دست آورید بدون اینکه ابتدا تصویر را به رستر تبدیل کنید.

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

حفظ محتویات SVG به‌صورت SVG منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبورند آن محتویات برداری را به پیکسل تبدیل کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک کپی بایت به بایت دقیق SVG جاسازی‌شده در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **برش یک تصویر**

برش تعیین می‌کند کدام بخش از تصویر در داخل قاب قابل مشاهده باشد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ تنها ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌کند:

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

از آنجا که داده‌های تصویر مخفی همچنان موجودند، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر اندازه فایل مهم‌تر از قابلیت بازگردانی باشد، می‌توان نواحی برش‌خورده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش کنونی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند اندازه فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات برگرداندن برش در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده می‌شود، آن قاب‌ها هنوز به منبع موجود خود احتیاج دارند، بنابراین حذف نواحی برش لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجه برش‌شده را به PNG رسترسازی می‌کند.

## **فشرده‌سازی تصاویر رستر**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی که تصویر تغییر اندازه یا برش داده شود `true` و در غیر این صورت `false` برمی‌گرداند.

هنگامی که یک وضوح هدف استاندارد کافی است، می‌توانید از مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturescompression/) استفاده کنید:

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

در صورت نیاز به هدف خاص، می‌توان مقدار DPI مثبت سفارشی را به‌جای مقدار پیش‌تعریف‌شده پاس داد.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتویات SVG و متافایل توسط این جریان فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح کمتر و نواحی برش حذف‌شده را نمی‌توان از ارائه بهینه‌شده بازیافت کرد. به‌جای اعمال کم‌ترین DPI به‌صورت سراسری، وضوح هدف را بر مبنای بزرگ‌ترین اندازه‌ای که تصویر واقعا مشاهده یا استخراج خواهد شد انتخاب کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، تضاد، تبدیل رنگ، بلور، افکت‌های آلفا، زنجیره‌های مرتب‌شده، بازرسی، حذف و تأیید دور‌دور، به [Image Transform Effects](/androidjava/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسه قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/) کنترل می‌کند که کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال شوند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این کار منبع تصویر را به‌صورت بازنمونه‌گیری یا تغییر دائمی نسبت ابعاد منتقل نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پرکردن تصویر به حالت کشیدگی (stretch) باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) مستطیل پرکردن را نسبت به جعبه مرزی قاب تصویر تعریف می‌کنند. درصدهای مثبت یک تورفتگی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک بیرون‌زدگی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش تصویر منبع قابل مشاهده باشد؛ در حالی که مقادیر کشیدگی مستطیل را که تصویر قابل مشاهده در آن کشیده می‌شود تغییر می‌دهند.

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

از stretch‑offset برای قرار دادن پرکردن استفاده کنید. برای مخفی‌سازی لبه‌های تصویر منبع از ویژگی‌های برش استفاده کنید.

## **ملاحظات ذخیره‌سازی، اندازه فایل و خروجی**

معامله‌های اصلی زمانی که ذخیره‌سازی تصویر و قالب‌بندی قاب تصویر به‌صورت جداگانه در نظر گرفته شوند، مدیریت ساده‌تر می‌شوند:

- **تصاویر جاسازی‌شده** ارائه را خودمختار می‌سازند و برای به اشتراک‌گذاری و رندر سمت سرور قابل اعتمادترین گزینه هستند، اما تصاویر رستر بزرگ باعث افزایش اندازه PPTX و مصرف حافظه می‌شوند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش به‌صورت صریح حذف یا در زمان فشرده‌سازی حذف نشوند، درون تصویر جاسازی‌شده باقی می‌مانند.
- **فشرده‌سازی** می‌تواند اندازه فایل را به‌طور قابل توجهی برای تصاویر رستر بزرگ‌حجم کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از دانستن اندازه نهایی مورد نظر در اسلاید انجام شود.
- **تصاویر SVG** باید به‌صورت SVG باقی بمانند وقتی که حفظ وکتور مهم است. هنگام نیاز به منبع برداری، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندر‌شده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) موجود استفاده کنند به‌جای بارگذاری مکرر همان فایل در گردش کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتویات وکتور نگه دارید، عکس‌ها را مطابق با اندازه واقعی نمایش فشرده کنید، پیکسل‌های برش‌خورده را فقط وقتی حذف کنید که بعداً نیاز به ویرایش ندارید و از پیوندهای خارجی صرف‌نظر کنید مگر اینکه مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **سوالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب را مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها ذخیره می‌کند.

**کدامیک را باید جاسازی یا پیوند دهم؟**

زمانی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را جاسازی کنید. فقط وقتی که نگه داشتن فایل‌های تصویر خارج از PPTX هدفمند باشد و مکان‌های خارجی به‌صورت قابل‌اعتماد حفظ شوند، از پیوند استفاده کنید.

**آیا برش اندازه فایل PPTX را کاهش می‌دهد؟**

خود برش این‌کار را نمی‌کند. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند ولی پیکسل‌های زیرین را نگه می‌دارد. برای حذف فیزیکی پیکسل‌ها می‌توانید از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر همراه با حذف نواحی برش استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌های تصویر را از بین می‌برد. اگر بعداً به ویرایش با وضوح بالا نیاز دارید، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**تصاویر SVG چگونه باید مدیریت شوند؟**

هنگامی که حفظ دقت برداری مهم است، محتویات SVG را به‌صورت SVG نگه دارید. می‌توانید [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به قالب رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای مخصوص قاب تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` نسبت به [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که قاب تصویر ندارند را به‌درستی مدیریت کند.