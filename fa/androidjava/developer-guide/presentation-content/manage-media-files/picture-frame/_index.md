---
title: مدیریت قاب‌های تصویر در ارائه‌ها برای اندروید
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/androidjava/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- تصویر توکار
- تصویر لینک‌دار
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
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها با Aspose.Slides برای اندروید از طریق جاوا ایجاد، قالب‌بندی، لینک‌دار، برش، استخراج و فشرده‌سازی کنید."
---
## **بررسی کلی**

یک قاب تصویر یک شکل اسلاید است که تصویری را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد به‌صورت اشیاء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) منابع تصویر توکار را از طریق [IImageCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/) خود در اختیار دارد، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیشتر از یک بار نشان داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء برگشتی [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستر مانند PNG یا JPEG و همچنین تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر لینک‌دار ارجاع دهند به‌جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تصمیم‌گیری دربارهٔ نحوهٔ ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر توکار**

برای یک تصویر توکار، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ایجاد کنید. تصویر بخشی از بستهٔ ارائه می‌شود، بنابراین وقتی ارائه به رایانهٔ دیگری منتقل شود، خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خطوط و چرخش را اعمال می‌نماید:

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

قاب تصویر هندسهٔ نمایش داده شده را کنترل می‌کند؛ تغییر اندازهٔ قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر توکار را تغییر نمی‌دهد. این تمایز هنگام برش یا فشرده‌سازی تصویر در مراحل بعدی مهم می‌شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) مقیاس‌گذاری عرض و ارتفاع نسبی برای قاب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) در دسترس می‌گذارد. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز به حفظ نسبت به اندازهٔ منبع تصویر داشته باشد به‌جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ این کار ریسپلینگ یا فشرده‌سازی تصویر توکار را انجام نمی‌دهد.

## **تصاویر توکار و لینک‌دار**

یک تصویر توکار داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شده امن‌ترین گزینه است. یک تصویر لینک‌دار مکان خارجی را از طریق متد [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای این‌که داده‌های تصویر را به همان شکل توکار کند.

تصاویر لینک‌دار می‌توانند میزان دادهٔ تصویری ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، قابل دسترس باشد. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر لینک‌دار ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، آرشیو شوند یا در محیط‌های ایزوله رندر شوند، تصاویر توکار معمولاً قابل اطمینان‌تر هستند.

### **افزودن یک تصویر لینک‌دار**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویری محلی اشاره می‌دهد. این مثال فقط به لینک‌دادن تصویر می‌پردازد؛ لینک‌دادن ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل‌های خارجی عمدی باشد. از آن‌ها صرفاً به‌جای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ بزرگتر خودکفا.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) باشد و شامل یک تصویر توکار باشد. قاب‌های تصویر لینک‌دار ممکن است بایت‌های تصویری که بتوان همان‌طور استخراج کرد را نداشته باشند.

### **استخراج یک تصویر رستر**

API تصویر مدرن به‌صورت مستقیم از [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) استفاده می‌کند و نیازی به رپر تصویر جاوا قدیمی ندارد. مثال زیر اولین تصویر رستر توکار روی یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌کند:

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

ذخیرهٔ تصویر از طریق [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) تصویر استخراج‌شده را به قالب خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند به‌جای یک فایل رستری تبدیل‌شده نیاز دارید، از دادهٔ باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) را در دسترس می‌گذارد. این امکان را می‌دهد تا دادهٔ SVG را به‌صورت مستقیم بازیابی کنید به‌جای رسترسازی تصویر ابتدا.

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

نگه‌داشتن محتوای SVG به‌عنوان SVG، منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبورند آن محتوای برداری را به پیکسل رندر کنند. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان یک کپی بایت به بایت از SVG توکار در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از دادهٔ [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/#getSvgData--) استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند کدام بخش از تصویر داخل قاب قابل مشاهده باشد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش ابتدا پیکسل‌های مخفی را از تصویر توکار حذف نمی‌کند؛ فقط منطقهٔ قابل مشاهده را تغییر می‌دهد.

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

چون دادهٔ تصویر مخفی هنوز حضور دارد، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان نواحی برش‌شده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را باز می‌گرداند. این می‌تواند حجم فایل را کم کند، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات بازبرش در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجهٔ برش‌شده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. این متد می‌تواند نواحی برش‌شده را در همان عملیات حذف کند. متد هنگام تغییر اندازه یا برش تصویر `true` و در صورت عدم نیاز به تغییر `false` باز می‌گرداند.

هنگامی که یک مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturescompression/) کافی است، از آن استفاده کنید:

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

در صورت نیاز به هدف خاص می‌توانید مقدار DPI مثبت سفارشی را به‌جای مقدار پیش‌تعریف‌شده پاس دهید.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتوای SVG و متافایل توسط این فرآیند فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و حذف نواحی برش‌شده غیرقابل بازیابی از ارائه بهینه‌شده هستند. هدف وضوح را بر پایهٔ بزرگ‌ترین اندازه‌ای که تصویر واقعاً دیده یا صادر می‌شود، نه پایین‌ترین DPI سراسری، انتخاب کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ‌ها، تاری، افکت‌های آلفا، زنجیره‌های مرتب‌شده، بازرسی، حذف و تأیید دورانی، مراجعه کنید به [Image Transform Effects](/slides/fa/androidjava/image-transform-effects/).

## **قفل کردن هندسهٔ قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/) تعیین می‌کند که کدام عملیات ویرایشی برای قاب تصویر غیرفعال شود. به عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این قفل منبع تصویر را مجبور به ریسپلینگ یا تغییر دائمی به همان نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر stretch است، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) مستطیل پر را نسبت به کادر محدودهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی می‌سازند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده باشد؛ offsetهای کشش مستطیل را که تصویر قابل مشاهده در آن کشیده می‌شود تغییر می‌دهند.

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

از offsetهای کشش برای جایگذاری پر استفاده کنید. هنگام هدف‌گذاری بر مخفی‌سازی لبه‌های تصویر منبع، از ویژگی‌های برش استفاده کنید.

## **نگهداری، حجم فایل و ملاحظات صادرات**

تجارت‌های اصلی وقتی که ذخیره‌سازی تصویر و قالب‌بندی قاب تصویر جداگانه در نظر گرفته شوند، آسان‌تر مدیریت می‌شوند:

- **تصاویر توکار** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌دار** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمان حذف صریح نواحی برش‌شده یا حذف در زمان فشرده‌سازی همچنان توکار می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بیش‌ازحد بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از دانستن اندازهٔ نهایی موردنظر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی که حفظ بردار مهم است. SVG توکار را مستقیماً زمانی که به خود منبع برداری نیاز دارید استخراج کنید. صادرات اسلایدهای رستر همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** باید در صورت امکان از منبع [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) موجود مجدداً استفاده کنند نه اینکه هر بار همان فایل را به جریان کاری ارائه بارگذاری کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و دیاگرام‌ها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازهٔ واقعی نمایش‌شان فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که بعداً نیاز به ویرایش نداشته باشید و از لینک‌های خارجی مگر اینکه مدیریت وابستگی بخشی از طرح استقرار باشد، خودداری کنید.

## **پرسش‌های متداول**

**تفاوت بین یک قاب تصویر و یک منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب مانند اندازه، چرخش, مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**کدامیک را باید توکار یا لینک کنم؟**

زمانی که ارائه باید قابل حمل، آرشیو یا بدون دسترسی به منابع خارجی رندر شود، تصویرها را توکار کنید. فقط زمانی که نگهداری فایل‌های تصویر خارج از PPTX عمدی باشد و مکان‌های خارجی به‌طور قابل اطمینان نگهداری شوند، تصویرها را لینک کنید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این‌کار را انجام نمی‌دهد. تنظیمات برش معمولی بخش‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را حفظ می‌کند. برای کاهش حجم، از [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر همراه با حذف نواحی برش‌شده استفاده کنید.

**آیا پس از فشرده‌سازی می‌توان کیفیت تصویر را بازگرداند؟**

خیر. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده دادهٔ تصویری را از بین می‌برد. اگر در آینده به ویرایش با وضوح بالا نیاز باشد، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG برخورد کرد؟**

وقتی که حفظ صحت برداری مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) توکار را مستقیماً استخراج کنید. رندر کردن اسلاید به فرمتی رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توانم از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کنم؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. یک بررسی `instanceof` علیه [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) تبدیل‌های نامعتبر را جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که شامل قاب تصویر نیستند به‌درستی مدیریت کند.