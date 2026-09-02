---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/java/image/
keywords:
- افزودن تصویر
- افزودن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر پیوندشده
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- SVG به اشکال
- منابع SVG خارجی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "نحوهٔ افزودن، بازاستفاده، پیونددهی، جایگزینی و مدیریت تصاویر رستر و SVG در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا را بیاموزید."
---
## **مقدمه**

Aspose.Slides for Java چندین روش برای کار با تصاویر ارائه می‌دهد و هر کدام هدف متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، آن را در یک فریم تصویر نمایش دهید، به عنوان پس‌زمینهٔ اسلاید استفاده کنید، به یک تصویر خارجی پیوند دهید، منبع تصویر اشتراک‌گذاری‌شده را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر منابع تصویر و نحوهٔ استفادهٔ آن‌ها در سراسر یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و سایر قالب‌بندی‌های اعمال‌شده به یک فریم تصویر منفرد، به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر به‌هم پیوسته‌اند اما قابل تعویض نیستند:

- مجموعهٔ تصویر ارائه ([presentation image collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagecollection/)) منابع تصویری که توسط ارائه استفاده می‌شوند را ذخیره می‌کند. برای افزودن دادهٔ تصویر و دریافت یک منبع [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) از [ImageCollection.addImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imagecollection/) استفاده کنید.
- یک [picture frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) شکلی است که یک تصویر را در اسلاید، لایه یا مستر نمایش می‌دهد. برای قرار دادن یک منبع تصویر روی اسلاید از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) استفاده کنید.
- پس‌زمینهٔ اسلاید از تصویر به‌عنوان بخشی از پرکردن اسلاید استفاده می‌کند، نه به‌عنوان شکل. بنابراین رفتار آن شبیه فریم تصویر نیست.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همهٔ آنها از جایگزین استفاده می‌کنند.
- تبدیل SVG به اشکال، اشکال قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

به‌این‌ترتیب یک جریان کاری معمول این است: دادهٔ تصویر را به مجموعهٔ تصویر اضافه کنید، یک [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) دریافت کنید و سپس آن منبع را در یک یا چند فریم تصویر یا پرکردن‌ها استفاده کنید.

## **افزودن تصویر جاسازی‌شده**

برای درج یک تصویر محلی، فایل را بارگذاری کنید، به مجموعهٔ تصویر اضافه کنید و یک فریم تصویر ایجاد کنید که از `IPPImage` بازگشتی استفاده می‌کند.

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

تصویری که به این روش اضافه می‌شود در ارائه جاسازی می‌شود، بنابراین فایل حاصل به در دسترس بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

وقتی یک تصویر از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را دانلود کنید، به مجموعهٔ تصویر ارائه اضافه کنید و منبع تصویر بازگشتی را همانند تصویر محلی استفاده کنید.

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

در برنامه‌های طولانی‌مدت، به‌جای ایجاد مکرر زیرساخت‌های شبکهٔ نامورد، یک کلاینت HTTP یا استراتژی مدیریت اتصال مناسب برای برنامه را مجدداً استفاده کنید. همچنین URLهای راه‌دور، اندازهٔ پاسخ‌ها و نوع محتوا را وقتی منبع مورد اعتماد نیست، اعتبارسنجی کنید.

## **استفاده مجدد از تصاویر در اسلایدها**

اگر همان تصویر بیش از یک‌بار مورد نیاز است، یک‌بار به ارائه اضافه کنید و هنگام ایجاد فریم‌های تصویر دیگر، [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) بازگشتی را بازاستفاده کنید. این کار از بارگذاری مکرر دادهٔ منبع جلوگیری می‌کند و رابطهٔ بین منبع تصویر مشترک و استفاده‌ها را روشن می‌سازد.

برای گرافیک‌هایی که باید به‌صورت خودکار در اسلایدهای متعدد ظاهر شوند، مانند لوگوی شرکت، قرار دادن فریم تصویر روی یک [slide master](/slides/fa/java/slide-master/) یا لایه به‌جای افزودن شکل معادل به هر اسلاید را در نظر بگیرید.

## **استفاده از تصویر به‌عنوان پس‌زمینهٔ اسلاید**

یک تصویر پس‌زمینه به پرکردن اسلاید اختصاص می‌یابد؛ به‌عنوان شکل فریم تصویر اضافه نمی‌شود. این کار مفید است وقتی تصویر باید کل پس‌زمینه اسلاید را پوشش دهد و نباید مانند یک شیء معمولی اسلاید دستکاری شود.

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

برای گزینه‌های پس‌زمینهٔ اضافی، از جمله پس‌زمینه‌های مستر و لایه، به [Presentation Background](/slides/fa/java/presentation-background/) مراجعه کنید.

## **تصاویر جاسازی‌شده و پیوندشده**

تصاویر جاسازی‌شده و پیوندشده تعادل‌های متفاوتی از نظر قابلیت حمل و حجم فایل دارند:

- **تصویر جاسازی‌شده:** دادهٔ تصویر داخل ارائه ذخیره می‌شود. ارائه خودکفایی دارد، اما حجم فایل شامل دادهٔ تصویر است.
- **تصویر پیوندشده:** ارائه مسیر یا URL یک تصویر خارجی را ذخیره می‌کند. این می‌تواند حجم ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز کردن یا رندر کردن در دسترس باشد.

یک تصویر پیوندشده می‌تواند از طریق [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/) مسیر یا URL خارجی را اختصاص دهد نه اینکه دادهٔ تصویر را جاسازی کند.

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

از تصاویر پیوندشده فقط زمانی استفاده کنید که محیط استقرار بتواند به‌صورت قابل اطمینان به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر جاسازی‌شده معمولاً ایمن‌ترند.

## **کار با تصاویر SVG**

SVG یک قالب برداری است، بنابراین برای آیکون‌ها، نمودارها و گرافیک‌های دیگر که باید بدون از دست دادن جزئیات مقیاس شوند مفید است. Aspose.Slides هم به‌عنوان منبع تصویر و هم به‌عنوان منبعی برای اشکال قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) ایجاد کنید، به مجموعهٔ تصویر اضافه کنید و منبع تصویر حاصل را در یک فریم تصویر قرار دهید.

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

یک SVG می‌تواند به تصاویر، سبک‌نامه‌ها یا قلم‌های خارجی ارجاع دهد. برای این موارد، [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) سازنده‌هایی دارد که یک [IExternalResourceResolver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iexternalresourceresolver/) و یک URI پایه می‌پذیرند. حل‌کننده می‌تواند URI نسبی را به یک URI مطلق مجاز نگاشت کند و برای منبع درخواست‌شده یک جریان بازگرداند.

حل‌کننده منابع خارجی را در حین پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به سندی خودکفا بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را داخل SVG خود جاسازی کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر پیوندشده.

وقتی فایل‌های SVG از منابع غیرقابل اعتماد می‌آیند، طرح‌ها، مسیرهای فایل و میزبان‌هایی را که حل‌کننده می‌تواند به آن‌ها دسترسی داشته باشد محدود کنید. حل‌کننده‌های شبکه باید همچنین زمان‌سنجی، محدودیت‌های اندازهٔ پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به اشکال قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کند، مشابه فرمان مربوطه در PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

برای انجام تبدیل، از overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) که یک [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) می‌گیرد، استفاده کنید.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

زمانی که عناصر برداری فردی نیاز به ویرایش به‌عنوان اشکال PowerPoint دارند، از تبدیل SVG‑به‑اشکال استفاده کنید. اگر فقط نیاز به نمایش SVG باشد، نگه داشتن آن به‌صورت تصویر ساده‌تر است و از ایجاد اشکال متعدد جداگانه جلوگیری می‌کند.

## **جایگزینی یک منبع تصویر موجود**

زمانی که می‌خواهید یک منبع تصویر موجود را جایگزین کنید، از [IPPImage.replaceImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) استفاده کنید. این کار به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

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

اگر چندین فریم تصویر، پس‌زمینه، مستر یا لایه از همان منبع تصویر استفاده می‌کنند، جایگزینی آن منبع تمام استفاده‌ها را به‌روزرسانی می‌کند. اگر فقط یک فریم تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، یک تصویر متفاوت به آن فریم اختصاص دهید.

`replaceImage` همچنین overloadهایی دارد که یک آرایه بایت یا یک [IPPImage] دیگر را می‌پذیرد.

## **راهنمای عملی مدیریت تصویر**

### **کنترل حجم ارائه**

تصاویر رستر بزرگ می‌توانند حجم ارائه را بی‌دلیل زیاد کنند. از تصاویر منبع با ابعاد مناسب برای اندازهٔ نمایش مورد نظر استفاده کنید، در صورت امکان منابع تصویر مشترک را بازاستفاده کنید و از جاسازی نسخه‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که قبلاً در فریم تصویر قرار گرفته‌اند، [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) می‌تواند دادهٔ تصویر را بر اساس وضوح انتخابی و تنظیمات برش کاهش دهد. این پردازش مربوط به فریم تصویر است نه مدیریت مجموعهٔ تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید.

### **انتخاب بین محتویات جاسازی‌شده و پیوندشده**

جاسازی باعث می‌شود ارائه قابل حمل باشد چون تمام داده‌های تصویری مورد نیاز همراه فایل هستند. پیوند می‌تواند حجم فایل را کاهش دهد، اما وابستگی خارجی معرفی می‌کند. از پیوندها فقط زمانی استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **استفاده مجدد از برندهای مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، از یک منبع تصویر استفاده کنید و آن را بازاستفاده کنید. اگر گرافیک متعلق به طراحی ارائه است نه به محتوای اسلاید، آن را روی مستر یا لایه قرار دهید تا توسط اسلایدهای مربوطه به‌ارث برسد.

### **حفظ قابلیت حمل منابع SVG**

یک SVG خودکفا جابه‌جایی و رندر ثابت‌تری دارد نسبت به SVGی که به فایل‌ها یا منابع شبکهٔ خارجی وابسته است. در صورت امکان، قبل از وارد کردن SVG، منابع مورد نیاز را جاسازی کنید. تبدیل SVG به اشکال فقط وقتی انجام شود که عناصر برداری فردی نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر مدرن چندپلتفرمی**

برای کد جدید جاوا، به‌جای API عمومی قدیمی مبتنی بر `java.awt.image.BufferedImage`، از APIهای Aspose.Slides [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/fa/java/com.aspose.slides/images/) استفاده کنید. برای راهنمای مهاجرت به [Modern API](/slides/fa/java/modern-api/) مراجعه کنید.

WMF و EMF نیاز به ملاحظات خاص دارند. وقتی این قالب‌ها از طریق یک [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) عبور می‌کنند، [ImageCollection.addImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imagecollection/) قبل از ورود، متافایل را به نمایهٔ PNG رستر تبدیل می‌کند. اگر حفظ دادهٔ متافایل مهم است، به‌جای overloadی که مستقیماً داده را تبدیل می‌کند، overload مبتنی بر جریان [ImageCollection.addImage] را استفاده کنید. تولید محتوی EMF از صفحات‌گسترده یا محصولات دیگر یک جریان کاری یکپارچه‌سازی جداگانه است و در محدودهٔ این مقاله قرار نمی‌گیرد.

## **سوالات متداول**

**تفاوت مجموعهٔ تصویر و فریم تصویر چیست؟**

مجموعهٔ تصویر منابع تصویری قابل‌استفاده مجدد را ذخیره می‌کند. فریم تصویر یک شکل اسلاید است که یکی از آن منابع را نمایش می‌دهد و قالب‌بندی مخصوص تصویر مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین روش برای جایگزینی یک لوگو در همهٔ مکان‌ها چیست؟**

اگر لوگو قبلاً به‌عنوان یک منبع تصویر مشترک وجود دارد، آن منبع را با [IPPImage.replaceImage] جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو روی مستر یا لایه می‌تواند محتوای اسلایدهای تکراری را نیز کاهش دهد.

**چرا یک تصویر پیوندشده در کامپیوتر دیگر ناپدید می‌شود؟**

یک تصویر پیوندشده به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر پیوندشده قابل مشاهده نخواهد بود. هنگامی که ارائه باید خودکفا باشد، تصویر را جاسازی کنید.

**آیا می‌توان یک SVG وارد‌شده را به‌عنوان اشکال PowerPoint ویرایش کرد؟**

بله. با استفاده از [IShapeCollection.addGroupShape] SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کنید؛ گروه حاصل حاوی اشکال ویرایش‌پذیر است نه یک تصویر SVG واحد.

**چگونه می‌توانم ارائه‌های دارای تصاویر زیاد را کوچکتر نگه دارم؟**

منابع تصویر مشترک را بازاستفاده کنید، از منابع رستر بزرگ غیرضروری پرهیز کنید، در صورت مناسب تصاویر رستر را فشرده کنید، برندهای تکراری را روی مستر یا لایه بگذارید و فقط زمانی که وابستگی خارجی قابل قبول است از تصاویر پیوندشده استفاده کنید.