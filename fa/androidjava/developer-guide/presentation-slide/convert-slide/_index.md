---
title: تبدیل اسلایدهای ارائه به تصاویر روی اندروید
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/androidjava/convert-slide/
keywords:
- تبدیل اسلاید
- استخراج اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- پاورپوینت
- سند باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "اسلایدهای ارائه از فرمت‌های PPT، PPTX و ODP را به PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌های تصویری در اندروید با Aspose.Slides تبدیل کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java می‌تواند اسلایدهای تک‌تک از ارائه‌های PowerPoint و OpenDocument را به صورت PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویری رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگیری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندر را با کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) پیکربندی کنید.
4. متد [ISlide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage--) را صدا بزنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) برمی‌گرداند.
5. متد [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) را صدا بزنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) مشخص کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندر استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش یا به فایل ذخیره شود.

مثال زیر در زبان Java اسلاید اول را رندر کرده و به عنوان تصویر PNG ذخیره می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از متد [ISlide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) که یک مقدار [Size](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides.android/size/) می‌گیرد استفاده کنید تا اسلاید را با ابعاد پیکسلی دقیق رندر کنید.

مثال زیر یک تصویر JPEG با ابعاد 1820 × 1040 ایجاد می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

به‌طور پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. برای کنترل مکان نمایش یادداشت‌ها و نظرات، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) را به متد [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) پاس دهید.

مثال زیر یادداشت‌های کوتاه شده را زیر اسلاید و نظرات را در سمت راست آن قرار می‌دهد:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
برای تبدیل اسلاید به تصویر، مقدار [BottomFull](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notespositions/) را به متد [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) پاس ندهید. یادداشت‌ها می‌توانند متنی بیش از اندازهٔ ثابت تصویر داشته باشند. به جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) به شما اجازه می‌دهد اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را کنترل کنید.

مثال زیر اسلاید اول را به عنوان تصویر TIFF با اندازه 2160 × 2880 در 300 DPI رندر می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل تمام اسلایدها به تصاویر**

از مجموعه اسلایدها عبور کنید تا کل ارائه را به مجموعه‌ای از تصاویر تبدیل کنید. اسلایدهای مخفی نیز شامل می‌شوند مگر اینکه صراحتاً آنها را نادیده بگیرید.

مثال زیر هر اسلاید را به عنوان تصویر JPEG با ضریب مقیاس افقی و عمودی ۲ رندر می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ایجاد خروجی متافایل پیشرفته**

متافایل پیشرفته (EMF) زمانی مفید است که گرافیک‌های مبتنی بر بردار باید با Microsoft Office یا دیگر برنامه‌های ویندوزی که از متافایل‌های ویندوز پشتیبانی می‌کنند، مبادله شود. برخلاف تصویر مبتنی بر پیکسل، یک EMF می‌تواند عملیات رسم برداری را حفظ کند که بدون از دست دادن وضوح مقیاس‌پذیر است. اما EMF عمدتاً یک فرمت سازگاری برای برنامه‌های دارای پشتیبانی از متافایل ویندوز است و نه یک فرمت تبادل عمومی. علاوه بر این، محتویات پیچیده اسلاید، مانند تصاویر بیت‌مپ و برخی افکت‌ها، ممکن است به صورت عناصر رسترشده در داخل بسته‌گر متافایل برداری ذخیره شوند.

### **استخراج یک اسلاید به EMF**

متد [ISlide.writeAsEmf](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) یک [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) را به جریان هدف در فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگیری می‌کند، اسلاید اول را انتخاب می‌کند و آن را به یک جریان فایل EMF می‌نویسد:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

صاحب جریان‌ای که به [ISlide.writeAsEmf](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) پاس می‌شود، مسئول بستن آن است، همان‌طور که در بالا نشان داده شد.

### **تبدیل یک تصویر SVG به EMF و افزودن آن به ارائه**

از [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) برای تبدیل محتویات SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [IImageCollection.addImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) به ارائه اضافه شوند و با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) را از علامت‌گذاری SVG ایجاد می‌کند، آن را به EMF در حافظه تبدیل می‌کند، متافایل را بر اسلاید اول درج می‌کند و ارائه را ذخیره می‌کند:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) مالکیت جریان مقصد را بر عهده نمی‌گیرد. یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین قبل از فراخوانی `toByteArray` نیازی به بازنشانی موقعیت نیست. آرایه بایتی بازگردانده‌شده پس از بسته شدن جریان همچنان معتبر است.

تولید EMF در نسخه‌های پشتیبانی‌شده Android و پیکربندی‌های دستگاه موجود است، اما رندر ممکن است هنگامی که فونت‌ها یا وابستگی‌های گرافیکی در دسترس نیستند، متفاوت باشد. فونت‌های استفاده‌شده در محتویات منبع را نصب کنید یا جایگزین‌های مناسب را پیکربندی کنید، راهنمای [installation guide](/slides/fa/androidjava/install-aspose-slides-for-android-via-java/) را برای Aspose.Slides for Android via Java دنبال کنید و نتیجه را در برنامه مصرف‌کننده EMF هدف معتبرسازی کنید. برنامه‌های غیر ویندوزی اغلب پشتیبانی محدودی برای نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندر رنگی ایموجی**

{{% alert title="Note" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی استفاده‌شده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشد. به عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصویر خروجی ظاهر شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**

خیر. متد [ISlide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage--) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را استخراج نمی‌کند.

**آیا می‌توان اسلایدهای پنهان را به عنوان تصویر استخراج کرد؟**

بله. اسلایدهای پنهان می‌توانند مانند اسلایدهای عادی رندر شوند. آنها را در حلقه پردازش شامل کنید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.