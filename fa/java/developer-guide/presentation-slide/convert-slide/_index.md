---
title: تبدیل اسلایدهای ارائه به تصاویر در جاوا
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/java/convert-slide/
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
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های تصویری PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌ها در جاوا با Aspose.Slides تبدیل کنید."
---
## **مقدمه**

Aspose.Slides برای Java می‌تواند اسلایدهای جداگانه را از ارائه‌های PowerPoint و OpenDocument به‌صورت فرمت‌های تصویری PNG، JPEG، GIF، TIFF و سایر فرمت‌ها رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس‌های [RenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) پیکربندی کنید.
4. متد [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage--) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) برمی‌گرداند.
5. متد [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) را صدا بزنید و قالب خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) تعیین کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش شود یا به‌صورت فایل ذخیره گردد.

مثال زیر در Java اولین اسلاید را رندر کرده و به‌صورت تصویر PNG ذخیره می‌کند:

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

از نسخه overload متد [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) که یک مقدار [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) می‌پذیرد، برای رندر اسلاید با ابعاد پیکسلی دقیق استفاده کنید.

مثال زیر یک تصویر JPEG با اندازه 1820 × 1040 ایجاد می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

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

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

به‌صورت پیش‌فرض، تصاویر اسلاید شامل یادداشت یا نظر نمی‌شوند. یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) را به متد [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) پاس دهید تا محل نمایش یادداشت‌ها و نظرات را کنترل کنید.

مثال زیر یادداشت‌های کوتاه‌شده را زیر اسلاید و نظرات را در سمت راست آن قرار می‌دهد:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

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
برای تبدیل اسلاید به تصویر، مقدار [BottomFull](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notespositions/) را به متد [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) پاس ندهید. یادداشت‌ها ممکن است متن بیشتری نسبت به اندازه ثابت تصویر داشته باشند. به‌جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) به شما امکان کنترل اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را می‌دهد.

مثال زیر اولین اسلاید را به‌صورت تصویر TIFF با اندازه 2160 × 2880 و وضوح 300 DPI رندر می‌کند:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

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

{{% alert title="Warning" color="warning" %}}
پشتیبانی از TIFF در نسخه‌های Java پیش از JDK 9 تضمین نمی‌شود.
{{% /alert %}}

## **تبدیل تمام اسلایدها به تصاویر**

از مجموعه اسلایدها عبور کنید تا تمام ارائه به‌صورت مجموعه‌ای از تصاویر تبدیل شود. اسلایدهای مخفی نیز گنجانده می‌شوند مگر اینکه صراحتاً آن‌ها را نادیده بگیرید.

مثال زیر هر اسلاید را به‌صورت تصویر JPEG با عوامل مقیاس افقی و عمودی برابر ۲ رندر می‌کند:

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

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های مبتنی بر بردار باید با Microsoft Office یا سایر برنامه‌های ویندوزی که از متافایل‌های ویندوز پشتیبانی می‌کنند، تبادل شوند. برخلاف تصویر مبتنی بر پیکسل، یک EMF می‌تواند عملیات رسم برداری را حفظ کند که بدون از دست دادن وضوح مقیاس می‌شود. با این حال، EMF عمدتاً یک قالب سازگاری برای برنامه‌هایی است که از متافایل ویندوزی پشتیبانی می‌کنند، نه یک قالب تبادل جهانی. علاوه بر این، محتوای پیچیده اسلاید مانند تصاویر بیت‌مپ و برخی افکت‌ها ممکن است به‌صورت عناصر رستر داخل کانتینر متافایل برداری ذخیره شوند.

### **صدور یک اسلاید به EMF**

متد [ISlide.writeAsEmf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) یک [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) را به‌صورت جریان هدف در قالب EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اولین اسلاید را انتخاب می‌نماید و آن را به‌یک جریان فایل EMF می‌نویسد:

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

صاحب این فراخوانی، جریان پاس‌داده‌شده به [ISlide.writeAsEmf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) را در اختیار دارد و مسئول بستن آن است، همان‌طور که در بالا نشان داده شد.

### **تبدیل تصویر SVG به EMF و افزودن آن به یک ارائه**

از [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) برای تبدیل محتوای SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [IImageCollection.addImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) به ارائه اضافه شوند و با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) از کد SVG می‌سازد، آن را به EMF در حافظه تبدیل می‌کند، متافایل را در اولین اسلاید درج می‌کند و ارائه را ذخیره می‌نماید:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) مالکیت جریان مقصد را بر عهده نمی‌گیرد. یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین قبل از فراخوانی `toByteArray` نیازی به بازنشانی موقعیت نیست. آرایه بایتی بازگشتی پس از بست شدن جریان همچنان معتبر است.

تولید EMF بر روی سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides for Java و پیکربندی JDK انتخاب‌شده در دسترس است، اما رندرینگ می‌تواند بین پلتفرم‌ها متفاوت باشد وقتی که فونت‌ها یا وابستگی‌های گرافیکی در دسترس نباشند. فونت‌های مورد استفاده در محتوای منبع را نصب کنید یا جایگزین‌های مناسب پیکربندی کنید، [نیازمندی‌های پلتفرم](/slides/fa/java/system-requirements/) را برای Aspose.Slides for Java دنبال کنید و نتیجه را در برنامه هدف مصرف‌کننده EMF ارزیابی نمایید. برنامه‌های Linux و macOS اغلب پشتیبانی محدود یا ناسازگاری برای نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندر ایموجی‌های رنگی**

{{% alert title="Note" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی استفاده‌شده در ارائه باید نصب و در سیستمی که تبدیل را انجام می‌دهد در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**

خیر. متد [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage--) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را صادر نمی‌کند.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی رندر شوند. آن‌ها را در حلقه پردازش گنجانده کنید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.