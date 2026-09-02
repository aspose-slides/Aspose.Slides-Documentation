---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها برای اندروید
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/androidjava/image/
keywords:
- اضافه کردن تصویر
- اضافه کردن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر پیوندی
- پس‌زمینه
- اضافه کردن PNG
- اضافه کردن JPG
- اضافه کردن SVG
- SVG به اشکال
- منابع SVG خارجی
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه تصاویر رستر و SVG را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java اضافه، مجدداً استفاده، لینک، جایگزین و مدیریت کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java راهکارهای متعددی برای کار با تصاویر فراهم می‌کند و هر کدام هدف متفاوتی دارند. می‌توانید تصویری را در یک ارائه ذخیره کنید، آن را در یک فریم تصویر نمایش دهید، به‌عنوان پس‌زمینه اسلاید استفاده کنید، به تصویر خارجی لینک بدهید، یک منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر روی منابع تصویر و نحوه استفاده از آن‌ها در یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و سایر فرمت‌بندی‌های اعمال‌شده به یک فریم تصویر منفرد، به [فریم تصویر](/slides/fa/androidjava/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر به‌هم‌پیوندیده هستند ولی قابل تعویض نیستند:

- [کلکسیون تصویر ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/) منابع تصویری را که توسط ارائه استفاده می‌شود ذخیره می‌کند. برای افزودن داده تصویر و دریافت منبع [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از [ImageCollection.addImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imagecollection/) استفاده کنید.
- یک [فریم تصویر](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) یک شکل است که تصویر را روی اسلاید، چیدمان یا مستر نمایش می‌دهد. برای قرار دادن یک منبع تصویر روی اسلاید از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) استفاده کنید.
- پس‌زمینه اسلاید از تصویر به‌عنوان بخشی از پرکننده اسلاید استفاده می‌کند نه به‌عنوان یک شکل. بنابراین رفتار فریم تصویر را ندارد.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همه آن جایگزینی را دریافت می‌کنند.
- تبدیل SVG به اشکال، اشکال قابل ویرایشی برای اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

یک جریان کاری متداول به این صورت است: داده تصویر را به کلکسیون اضافه کنید، یک [IPPImage] دریافت کنید و سپس آن منبع را در یک یا چند فریم تصویر یا پرکننده استفاده کنید.

## **افزودن تصویر جاسازی‌شده**

برای درج یک تصویر محلی، فایل را بارگذاری کنید، به کلکسیون تصویر اضافه کنید و یک فریم تصویر ایجاد کنید که از `IPPImage` بازگردانده شده استفاده می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصویری که به این شکل اضافه می‌شود در ارائه جاسازی می‌شود، بنابراین فایل نهایی به موجود بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

زمانی که تصویر از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را دانلود کنید، به کلکسیون تصویر ارائه اضافه کنید و منبع تصویر بازگردانده‌شده را همانند تصویر محلی استفاده کنید.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در برنامه‌های طولانی‌مدت، به‌جای ایجاد مکرر زیرساخت‌های شبکه، یک کلاینت HTTP یا استراتژی مدیریت اتصال مناسب برنامه را بازاستفاده کنید. همچنین URLهای خارجی، اندازه پاسخ‌ها و نوع محتوای آنها را هنگامی که منبع مورد اعتماد نیست، اعتبارسنجی کنید.

## **استفاده مجدد از تصاویر در اسلایدها**

اگر یک تصویر بیش از یک بار مورد نیاز باشد، یک‌بار به ارائه اضافه کنید و هنگام ایجاد فریم‌های تصویر دیگر، همان [IPPImage] را دوباره استفاده کنید. این کار از بارگذاری مکرر داده‌های منبع جلوگیری می‌کند و رابطه بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌سازد.

برای گرافیک‌هایی که باید به‌صورت خودکار در بسیاری از اسلایدها ظاهر شوند، مانند لوگوی شرکت، می‌توانید فریم تصویر را بر روی یک [مستر اسلاید](/slides/fa/androidjava/slide-master/) یا چیدمان قرار دهید، به جای افزودن یک شکل معادل به هر اسلاید.

## **استفاده از تصویر به عنوان پس‌زمینه اسلاید**

یک تصویر پس‌زمینه به پرکننده اسلاید اختصاص می‌یابد؛ به‌عنوان یک شکل فریم تصویر افزوده نمی‌شود. این کار زمانی مفید است که تصویر باید پس‌زمینه اسلاید را پوشش دهد و نیازی به دستکاری به‌عنوان یک شیء معمولی اسلاید ندارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای گزینه‌های پس‌زمینه بیشتر، شامل پس‌زمینه‌های مستر و چیدمان، به [پس‌زمینه ارائه](/slides/fa/androidjava/presentation-background/) مراجعه کنید.

## **تصاویر جاسازی‌شده و تصاویر پیوندی**

تصاویر جاسازی‌شده و پیوندی تبادلات مختلفی از نظر قابلیت حمل و اندازه فایل دارند:

- **تصویر جاسازی‌شده:** داده تصویر داخل ارائه ذخیره می‌شود. ارائه خودکفا است، اما اندازه فایل شامل داده تصویر است.
- **تصویر پیوندی:** ارائه مسیر یا URL به تصویر خارجی را ذخیره می‌کند. این می‌تواند اندازه ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه در دسترس باشد.

یک تصویر پیوندی می‌تواند با اختصاص مسیر یا URL خارجی از طریق [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/) به‌جای جاسازی داده تصویر ایجاد شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از تصاویر پیوندی فقط زمانی استفاده کنید که محیط استقرار بتواند به‌طور قابل اعتماد به منبع خارجی دسترسی پیدا کند. برای ارائه‌هایی که باید آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر جاسازی‌شده معمولاً ایمن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکون‌ها، نمودارها و سایر گرافیک‌هایی که باید بدون کاهش جزئیات مقیاس شوند، مناسب است. Aspose.Slides هم به‌عنوان منبع تصویر و هم به‌عنوان منبع برای اشکال قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) ایجاد کنید، آن را به کلکسیون تصویر اضافه کنید و منبع تصویر حاصل را در یک فریم تصویر قرار دهید.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصاویر، سبک‌نامه‌ها یا فونت‌های خارجی ارجاع دهد. برای این موارد، [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) سازندهایی دارد که یک [IExternalResourceResolver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iexternalresourceresolver/) و یک URI پایه می‌پذیرند. حل‌کننده می‌تواند URI نسبی را به یک URI مطلق مجاز نگاشت کند و برای منبع درخواست‌شده یک جریان (stream) بازگرداند.

حل‌کننده منابع خارجی را در حین پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به سند خودکفا بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را داخل SVG خود جاسازی کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر پیوندی.

زمانی که فایل‌های SVG از منابع غیر قابل اعتماد می‌آیند، схем‌ها، مکان‌های فایل و میزبان‌هایی را که حل‌کننده می‌تواند به آن‌ها دسترسی داشته باشد، محدود کنید. حل‌کننده‌های شبکه نیز باید زمان‌سنجی‌ها، محدودیت‌های اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به اشکال قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کند، مشابه دستور مربوطه در PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

برای انجام تبدیل، از overload متد [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) استفاده کنید که یک [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) را می‌پذیرد.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از تبدیل SVG به اشکال زمانی استفاده کنید که نیاز به ویرایش عناصر برداری به‌عنوان اشکال PowerPoint باشد. اگر فقط نیاز به نمایش SVG باشد، نگه داشتن آن به‌عنوان تصویر ساده‌تر است و از ایجاد تعداد زیادی شکل جداگانه جلوگیری می‌کند.

## **جایگزینی یک منبع تصویر موجود**

هنگامی که می‌خواهید یک منبع تصویر موجود را جایگزین کنید، از [IPPImage.replaceImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) استفاده کنید. این کار به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر چندین فریم تصویر، پس‌زمینه، مستر یا چیدمان از همان منبع تصویر استفاده می‌کنند، جایگزینی آن منبع تمام این استفاده‌ها را به‌روزرسانی می‌کند. اگر فقط یک فریم تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، تصویر دیگری را به آن فریم اختصاص دهید.

`replaceImage` همچنین overloadهایی دارد که یک آرایه بایت یا یک [IPPImage] دیگر را می‌پذیرند.

## **راهنمای عملی مدیریت تصویر**

### **کنترل حجم ارائه**

تصاویر رستر بزرگ می‌توانند حجم ارائه را بی‌دلیل افزایش دهند. از تصاویر منبع با ابعاد متناسب با اندازه نمایش موردنظر استفاده کنید، در صورت امکان منابع تصویر مشترک را مجدداً استفاده کنید و از جاسازی نسخه‌های تکراری یک گرافیک با وضوح کامل جلوگیری کنید.

برای تصاویر رستری که قبلاً در فریم‌های تصویر قرار گرفته‌اند، می‌توان با [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) داده تصویر را بر اساس وضوح و تنظیمات برش انتخاب‌شده کاهش داد. این پردازش مربوط به فریم تصویر است نه مدیریت کلکسیون تصویر، بنابراین برای عملیات فرمت‌بندی مرتبط به [فریم تصویر](/slides/fa/androidjava/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای جاسازی‌شده و پیوندی**

جاسازی باعث می‌شود ارائه قابل حمل باشد چون تمام داده‌های تصویر مورد نیاز همراه فایل می‌آیند. پیوند می‌تواند حجم فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. از پیوندها فقط زمانی استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **استفاده مجدد از برند مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، از یک منبع تصویر استفاده کنید و آن را مجدداً به کار ببرید. اگر گرافیک به طراحی ارائه مرتبط است نه محتوی اسلایدها، آن را روی مستر یا چیدمان قرار دهید تا به اسلایدهای مربوطه ارث‌بری شود.

### **حفظ قابلیت حمل منابع SVG**

یک SVG خودکفا حرکت و رندر سازگاری آسان‌تری نسبت به SVGی که به فایل‌ها یا منابع شبکه خارجی وابسته است دارد. در صورت امکان، قبل از وارد کردن SVG، منابع مورد نیاز را جاسازی کنید. فقط زمانی SVG را به اشکال تبدیل کنید که نیاز به ویرایش عناصر برداری به‌صورت جداگانه باشد.

### **استفاده از API تصویر مدرن و چندپلتفرمی**

برای کد جدید Android via Java، به جای API عمومی قدیمی مبتنی بر `android.graphics.Bitmap`، از APIهای Aspose.Slides [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/images/) استفاده کنید. برای راهنمای مهاجرت به [API مدرن](/slides/fa/androidjava/modern-api/) مراجعه کنید.

WMF و EMF نیاز به ملاحظات ویژه‌ای دارند. وقتی این فرمت‌ها از طریق یک [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) عبور می‌کنند، [ImageCollection.addImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imagecollection/) متافایل را به نمایه PNG رستر تبدیل می‌کند قبل از وارد کردن. اگر حفظ داده‌های متافایل مهم است، به‌جای overload مبتنی بر جریان [ImageCollection.addImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imagecollection/) استفاده کنید. تولید محتواهای EMF از صفحات گسترده یا محصولات دیگر یک جریان کاری یکپارچه جداگانه است و در محدوده این مقاله نیست.

## **سوالات متداول**

**تفاوت بین کلکسیون تصویر و فریم تصویر چیست؟**

کلکسیون تصویر منابع تصویر قابل استفاده مجدد را ذخیره می‌کند. فریم تصویر یک شکل اسلاید است که یکی از این منابع را نمایش می‌دهد و فرمت‌بندی‌های خاص تصویر مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین روش برای جایگزینی لوگوی یکسان در همه مکان‌ها چیست؟**

اگر لوگو به‌عنوان یک منبع تصویر مشترک موجود باشد، آن منبع را با استفاده از [IPPImage.replaceImage] جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو روی مستر یا چیدمان نیز می‌تواند محتوای تکراری اسلایدها را کاهش دهد.

**چرا یک تصویر پیوندی در کامپیوتر دیگری ناپدید می‌شود؟**

یک تصویر پیوندی به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر پیوندی در دسترس نخواهد بود. زمانی که ارائه باید خودکفا باشد، تصویر را جاسازی کنید.

**آیا می‌توان یک SVG درج‌شده را به‌عنوان اشکال PowerPoint ویرایش کرد؟**

بله. SVG را با استفاده از [IShapeCollection.addGroupShape] تبدیل کنید؛ گروه حاصل شامل اشکال قابل ویرایش اسلاید است نه یک تصویر SVG واحد.

**چگونه می‌توان حجم ارائه‌های حاوی تصاویر زیاد را کم کرد؟**

از منابع تصویر مشترک مجدداً استفاده کنید، از منابع رستر بیش از حد بزرگ جلوگیری کنید، در صورت مناسب تصاویر رستر مناسب را فشرده کنید، برندهای تکراری را روی مستر یا چیدمان نگه دارید و فقط زمانی که وابستگی خارجی قابل قبول باشد، از تصاویر پیوندی استفاده کنید.