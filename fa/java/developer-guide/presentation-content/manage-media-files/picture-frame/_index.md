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
- Java
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، پیونددهی، برش، استخراج و فشرده‌سازی کنید با Aspose.Slides برای جاوا."
---
## **مروری**

یک قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد به‌صورت اشیای جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [IImageCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagecollection/) مالکیت می‌کند، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) موقعیت، اندازه، فرمت خطوط، چرخش, برش, افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی وقتی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) بازگردانده شده را حفظ کنید و هنگام ایجاد قاب‌های تصویر از همان منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر پیوندی ارجاع دهند به‌جای ذخیره‌سازی بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تصمیم‌گیری درباره نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به رایانه دیگر خودکفا می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر ایجاد می‌کند و فرمت خطوط و چرخش را اعمال می‌سازد:

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

قاب تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازهٔ قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییری نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً تصویر برش یا فشرده شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) مقیاس عرض و ارتفاع نسبی برای قاب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) در دسترس می‌گذارد. مقدار `1.0` معادل ۱۰۰٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک گردش کار نیاز به حفظ نسبت به اندازهٔ تصویر منبع داشته باشد به‌جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ این کار تصویر جاسازی‌شده را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین امن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌پذیر است. یک تصویر پیوندی مکان خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای جاسازی داده‌های تصویر به همان روش.

تصاویر پیوندی می‌توانند مقدار داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامهٔ بازکننده یا رندر کنندهٔ ارائه قابل دسترسی بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌تر هستند.

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

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به ارائه‌ای بزرگتر که خودکفا باشد.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) باشد و شامل تصویر جاسازی‌شده باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که به همان روش قابل استخراج هستند، نداشته باشند.

### **استخراج یک تصویر رستر**

API جدید تصویر مستقیماً از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) استفاده می‌کند و نیازی به wrapperهای قدیمی جاوا نیست. مثال زیر اولین تصویر رستر جاسازی‌شده در یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌سازد:

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

ذخیره‌سازی از طریق [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به قالب خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شدهٔ ذخیره‌شده در ارائه نیاز داشته باشید نه به فایل رستر تبدیل‌شده، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) را افشا می‌کند. این امکان را می‌دهد که داده‌های SVG را مستقیماً بازیابی کنید به‌جای رستر کردن تصویر ابتدا.

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

نگه‌داشتن محتوای SVG به‌عنوان SVG منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبورند آن محتوای برداری را به پیکسل رندر کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندرینگ است، بنابراین گرافیک‌های خروجی نباید به‌عنوان نسخه بیتی‌به‌بیتی از SVG اصلی در نظر گرفته شوند؛ در زمان نیاز به منبع برداری اصلی از دادهٔ [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند کدام بخش از تصویر داخل قاب قابل مشاهده باشد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش در ابتدا پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر به‌صورت امن یک قاب تصویر پیدا می‌کند و مقادیر برش را اعمال می‌کند:

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

از آنجا که داده‌های تصویر مخفی هنوز حضور دارند، برش می‌تواند بعداً بدون از دست رفتن پیکسل‌های اصلی تغییر کند. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، می‌توان نواحی برش‌شده را همان‌طور که در بخش بعدی توضیح داده می‌شود، فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویر خارج از مستطیل برش فعلی را حذف کرده و منبع تصویر حاصل را بر می‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «برداشتن برش» در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجهٔ برش‌شده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌شده را در همان عملیات حذف کند. این متد زمانی که تصویر تغییر اندازه یا برش داده شود `true` و زمانی که تغییری لازم نباشد `false` برمی‌گرداند.

هنگام نیاز به وضوح هدف استاندارد، می‌توانید از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturescompression/) استفاده کنید:

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

به‌جای مقدار پیش‌تعریف‌شده می‌توان مقدار DPI مثبت سفارشی را در صورتی که هدف خاصی مورد نیاز باشد، ارسال کرد.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتویات SVG و متافایل توسط این فرآیند فشرده نمی‌شوند. همچنین به خاطر داشته باشید که وضوح پایین‌تر و نواحی برش‌شده حذف‌شده را نمی‌توان از ارائه بهینه‌شده بازیابی کرد. هدف وضوح را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا خروجی خواهد شد، انتخاب کنید نه این‌که به‌صورت سراسری کمترین DPI را اعمال کنید.

## **مدیریت اثرات تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتب، بازرسی، حذف و تأیید دور‌دور، به بخش [Image Transform Effects](/slides/fa/java/image-transform-effects/) مراجعه کنید.

## **قفل‌کردن هندسهٔ قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/) تعیین می‌کنند کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال شوند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این قفل منبع تصویر را مجبور به بازنمونه‌گیری یا تغییر دائمی به همان نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پرکردن تصویر کشیده (stretch) باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) مستطیل پرکردن را نسبت به کادر مرزی قاب تصویر تعریف می‌کند. درصدهای مثبت حاشیه‌ای از لبه ایجاد می‌کند، در حالی که درصدهای منفی گسترشی ایجاد می‌کند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده باشد؛ مقادیر stretch‑offset مستطیلی را تغییر می‌دهند که در آن پرکردن تصویر کشیده می‌شود.

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

برای قرار دادن پرکردن از stretch‑offset استفاده کنید. برای مخفی کردن لبه‌های تصویر منبع از ویژگی‌های برش استفاده کنید.

## **نگهداری، حجم فایل و ملاحظات خروجی**

تجارت‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی قاب‑تصویر جداگانه مورد بررسی قرار گیرند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صراحتاً حذف یا در زمان فشرده‌سازی حذف نشوند، جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از دانستن اندازهٔ نهایی تصویر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند زمانی که حفظ بردار مهم است. وقتی به منبع برداری واقعی نیاز دارید، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های رستری اسلاید همیشه اسلاید رندر‌شده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** بهتر است به جای بارگذاری مکرر همان فایل، از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) موجود استفاده کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای برداری نگه دارید، عکاسی‌ها را بر مبنای اندازهٔ واقعی نمایش فشرده کنید، پیکسل‌های برش‌شده را فقط زمانی حذف کنید که ویرایش بعدی ضروری نباشد و از پیوندهای خارجی صرف‌نظر کنید مگر این‌که مدیریت وابستگی بخشی از طرح استقرار باشد.

## **سؤالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) نمایانگر منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح‑قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی یا پیوند دهم؟**

زمانی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را جاسازی کنید. فقط زمانی که نگهداری فایل‌های تصویر خارج از PPTX هدفمند باشد و مکان‌های خارجی به‌طور قابل اعتماد نگهداری شوند، تصاویر را پیوند دهید.

**آیا برش باعث کاهش حجم PPTX می‌شود؟**

خود برش این کار را نمی‌کند. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر با حذف نواحی برش‌شده استفاده کنید وقتی می‌توانید این پیکسل‌ها را به‌طور دائمی حذف کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده دادهٔ تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا بعداً لازم باشد، تصویر منبع اصلی را خارج از ارائه حفظ کنید.

**چگونه باید با تصاویر SVG برخورد کرد؟**

هنگامی که حفظ وفاداری برداری مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` نسبت به [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که شامل قاب تصویر نیستند به‌درستی مدیریت کند.