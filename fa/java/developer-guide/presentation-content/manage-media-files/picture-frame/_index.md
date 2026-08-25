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
- تصویر تعبیه‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید با Aspose.Slides برای جاوا."
---
## **نمای کلی**

قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیای جداگانه‌ای هستند: یک [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) عکس‌های تعبیه‌شده را از طریق [IImageCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagecollection/) خود مالکیت می‌کند، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیشتر از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء بازگشتی [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) را نگه دارید و هنگام ساختن قاب‌های تصویر از همان منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر پیوندی اشاره کنند به‌جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تعیین کنید تصویر چگونه ذخیره شود.

## **افزودن و قالب‌بندی تصویر تعبیه‌شده**

برای یک تصویر تعبیه‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با استفاده از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به رایانه دیگر به‌صورت خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG را اضافه می‌کند، قاب را با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌نماید:

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

قاب تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه قاب، ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر تعبیه‌شده را تغییر نمی‌دهد. این تمایز هنگام برش یا فشرده‌سازی تصویر در آینده مهم می‌شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) مقیاس عرض و ارتفاع نسبی را برای قاب از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) افشا می‌کند. مقدار `1.0` معادل 100٪ اندازه تصویر اصلی است. مقیاس نسبی وقتی به‌کار می‌رود که یک جریان کار نیاز به حفظ نسبت به اندازه تصویر منبع داشته باشد به‌جای محاسبه دستی ابعاد نهایی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ تصویر تعبیه‌شده را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر تعبیه‌شده و پیوندی**

یک تصویر تعبیه‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین امن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شده است. یک تصویر پیوندی مکان خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای تعبیه داده‌های تصویر به همان شیوه.

تصاویر پیوندی می‌توانند مقدار داده تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس باقی بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، ممکن است تصویر پیوندی همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر تعبیه‌شده معمولاً قابل اتکا‌تر هستند.

### **افزودن تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به لینک‌دادن تصویر می‌پردازد؛ لینک‌دادن ویدیو یک جریان کار رسانه‌ای جداگانه است و عمداً در این مثال مخلوط نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. تنها به‌عنوان جایگزینی برای فشرده‌سازی از آن‌ها استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به یک ارائه‌ی خودکفا و بزرگتر.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که یک شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) باشد و حاوی تصویر تعبیه‌شده باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که می‌توان به همان شیوه استخراج کرد را نداشته باشند.

### **استخراج تصویر رستری**

API تصویر مدرن مستقیماً از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) استفاده می‌کند و نیازی به بسته‌بندی تصویر قدیمی جاوا نیست. مثال زیر اولین تصویر رستری تعبیه‌شده در یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

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

ذخیره از طریق [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به قالب خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های رمزگذاری‌شده‌ای که در ارائه ذخیره شده‌اند نیاز دارید، به‌جای فایل رستری تبدیل‌شده، از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) را افشا می‌کند. این به شما امکان می‌دهد داده SVG را مستقیماً دریافت کنید به‌جای رستری‌سازی تصویر ابتدا.

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

نگه‌داشتن محتوای SVG به‌صورت SVG، منبع برداری داخل ارائه را حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبورند آن محتوای برداری را به پیکسل تبدیل کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان نسخه بایت‑به‑بایت از SVG تعبیه‌شده اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند کدام بخش از تصویر داخل قاب قابل مشاهده باشد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه بایت‌های پنهان تصویر تعبیه‌شده را حذف نمی‌کند؛ فقط ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

چون داده تصویر مخفی هنوز موجود است، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگرداندن باشد، نواحی برش داده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای یک عملیات «باز‑برش» در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط سایر قاب‌های تصویر نیز استفاده شود، آن قاب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجه برش‌خورده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستری**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد زمانی `true` برمی‌گرداند که تصویر تغییر اندازه یا برش یافته باشد و زمانی `false` که نیازی به تغییر نباشد.

زمانی که یک وضوح هدف استاندارد کافی باشد، می‌توان از مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturescompression/) استفاده کرد:

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

در صورتی که هدف خاصی وجود دارد، می‌توان به‌جای مقدار پیش‌تعریف‌شده، یک مقدار DPI مثبت سفارشی ارسال کرد.

فشرده‌سازی برای تصاویر رستری در نظر گرفته شده است. محتوای SVG و متافایل توسط این کارکرد فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش حذف‌شده را نمی‌توان از ارائه بهینه‌شده بازگرداند. یک وضوح هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا صادر خواهد شد، انتخاب کنید نه این‌که کمترین DPI را به‌صورت سراسری اعمال کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک گردش کار کامل که شامل روشنایی، کنتراست، تبدیلات رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتبی، بازرسی، حذف و تأیید دوطرفه باشد، به [Image Transform Effects](/java/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسه قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/) کنترل می‌کند کدام عملیات ویرایشی برای یک قاب تصویر غیرفعال باشند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این نیازی به بازنمونه‌گیری یا تغییر دائمی نسبت تصویر منبع ایجاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

وقتی حالت پر کردن تصویر «stretch» باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) مستطیل پر کردن را نسبت به جعبه محدودهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی می‌سازند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش از تصویر منبع قابل مشاهده باشد؛ مقادیر stretch‑offset مستطیلی را تغییر می‌دهند که داخل آن پر شدن تصویر کشیده می‌شود.

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

از stretch‑offset برای جایگذاری پر کردن استفاده کنید. از ویژگی‌های برش زمانی استفاده کنید که هدف مخفی کردن لبه‌های تصویر منبع باشد.

## **نکات مربوط به ذخیره‌سازی، حجم فایل و خروجی**

معامله‌های اصلی زمانی آسان‌تر می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی قاب‑تصویر جداگانه درنظر گرفته شوند:

- **تصاویر تعبیه‌شده** ارائه را خودکفا می‌کند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه است، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌ها وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش صراحتاً حذف یا در طول فشرده‌سازی حذف نشوند، تعبیه می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری بزرگ به‌طور قابل‌توجهی کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از دانستن اندازه نهایی تصویر روی اسلاید انجام شود.
- **تصاویر SVG** باید زمانی که حفظ بردار مهم است به‌صورت SVG باقی بمانند. SVG تعبیه‌شده را مستقیماً استخراج کنید وقتی به منبع برداری خود نیاز دارید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) موجود استفاده کنند به‌جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر‌ترین است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌صورت محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازه نمایش واقعیشان فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که ویرایش بعدی لازم نباشد و از لینک‌های خارجی تا زمانی که مدیریت وابستگی بخشی از طرح استقرار باشد، اجتناب کنید.

## **سؤالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) نمایانگر منبع تصویری است که به ارائه مرتبط است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) شکل روی اسلایدی است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح‑قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را تعبیه یا پیوند دهم؟**

زمانی که ارائه باید قابل حمل، بایگانی یا رندر شود بدون دسترسی به منابع خارجی، تصاویر را تعبیه کنید. فقط وقتی نگهداری فایل‌های تصویر خارج از PPTX هدفمند باشد و مکان‌های خارجی به‌صورت قابل‌اعتماد نگهداری شوند، از لینک استفاده کنید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را انجام نمی‌دهد. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر با حذف نواحی برش استفاده کنید وقتی می‌توانید این پیکسل‌ها را به‌صورت دائمی حذف کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

خیر. فشرده‌سازی می‌تواند وضوح رستری ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌های تصویر را از بین می‌برد. اگر ویرایش‌های با وضوح بالا بعداً مورد نیاز است، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG کار کرد؟**

زمانی که حفظ فرمت برداری مهم است، محتوای SVG را به‌صورت SVG نگه دارید. می‌توان [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) تعبیه‌شده را مستقیم استخراج کرد. رندر یک اسلاید به قالب رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب‑تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` در برابر [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که قاب تصویر ندارند را به‌صورت مناسب پردازش کند.