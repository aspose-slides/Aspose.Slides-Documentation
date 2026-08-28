---
title: تبدیل اسلایدهای ارائه به تصاویر در جاوااسکریپت
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/nodejs-java/convert-slide/
keywords:
- تبدیل اسلاید
- صدور اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیتی‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌های تصویری در جاوااسکریپت با Aspose.Slides تبدیل کنید."
---
## **معرفی**

Aspose.Slides برای Node.js از طریق Java می‌تواند اسلایدهای جداگانهٔ ارائه‌های PowerPoint و OpenDocument را به صورت PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویری رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس‌های [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) پیکربندی کنید.
4. متد [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) برمی‌گرداند.
5. متد [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) را فراخوانی کنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش یا در فایلی ذخیره شود.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از بارگذاری [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) که یک مقدار `java.awt.Dimension` می‌پذیرد استفاده کنید تا اسلاید را با ابعاد پیکسلی دقیق رندر کنید.

مثال زیر یک تصویر JPEG با ابعاد ۱۸۲۰ × ۱۰۴۰ ایجاد می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

به‌صورت پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) را به متد [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) بدهید تا مکان نمایش یادداشت‌ها و نظرات را کنترل کنید.

مثال زیر یادداشت‌های کوتاه‌شده را زیر اسلاید و نظرات را سمت راست آن قرار می‌دهد:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="هشدار" color="warning" %}}
برای تبدیل اسلاید به تصویر، مقدار [BottomFull](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notespositions/) را به متد [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) پاس ندهید. یادداشت‌ها ممکن است متنی بیش از اندازه ثابت تصویر داشته باشند. به‌جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) به شما امکان کنترل اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را می‌دهد.

مثال زیر اسلاید اول را به عنوان تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ و ۳۰۰ DPI رندر می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="هشدار" color="warning" %}}
پشتیبانی از TIFF در نسخه‌های جاوا قبل از JDK 9 تضمین نمی‌شود.
{{% /alert %}}

## **تبدیل تمام اسلایدها به تصاویر**

از مجموعه اسلایدها عبور کنید تا کل ارائه را به یک سری تصویر تبدیل کنید. اسلایدهای مخفی نیز گنجانده می‌شوند مگر این‌که به صراحت آن‌ها را نادیده بگیرید.

مثال زیر هر اسلاید را به عنوان تصویر JPEG با عوامل مقیاس افقی و عمودی برابر ۲ رندر می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ایجاد خروجی Enhanced Metafile (EMF)**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های مبتنی بر بردار باید با Microsoft Office یا سایر برنامه‌های ویندوزی که از متافایل‌های ویندوز پشتیبانی می‌کنند، مبادله شوند. بر خلاف تصویر مبتنی بر پیکسل، EMF می‌تواند عملیات رسم برداری را که با مقیاس‌پذیری بدون کاهش وضوح همراه است، حفظ کند. با این حال، EMF عمدتاً یک قالب سازگاری برای برنامه‌های پشتیبان متافایل ویندوز است و نه قالب تبادل عمومی. علاوه بر این، محتوای پیچیدهٔ اسلاید، مانند تصاویر بیت‌مپ و برخی افکت‌ها، ممکن است به‌صورت عناصر رستر شده در داخل محفظهٔ متافایل برداری ذخیره شوند.

### **صادر کردن یک اسلاید به EMF**

متد [Slide.writeAsEmf](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#writeAsEmf) یک اسلاید را به یک جریان هدف در قالب EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اسلاید اول را انتخاب می‌کند و آن را به یک جریان فایل EMF می‌نویسد:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

صاحب جریان پاس‌داده شده به [Slide.writeAsEmf](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#writeAsEmf) کالر است و مسئول بستن آن می‌باشد، همان‌طور که در بالا نشان داده شد.

### **تبدیل یک تصویر SVG به EMF و افزودن آن به یک ارائه**

از [SvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/#writeAsEmf) برای تبدیل محتوای SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [ImageCollection.addImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه شوند و با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) از نشانه‌گذاری SVG ایجاد می‌کند، آن را به یک EMF حافظه‌موقت تبدیل می‌کند، متافایل را بر روی اسلاید اول درج می‌کند و ارائه را ذخیره می‌نماید:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/#writeAsEmf) مالکیت جریان مقصد را بر عهده نمی‌گیرد. یک `java.io.ByteArrayOutputStream` تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین قبل از فراخوانی `toByteArray` نیازی به بازنشانی موقعیت نیست. آرایه بایت بازگشتی پس از بسته شدن جریان معتبر می‌ماند.

تولید EMF در سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides برای Node.js از طریق Java و پیکربندی JDK در دسترس است، اما رندر ممکن است در پلتفرم‌های مختلف زمانی که قلم‌ها یا وابستگی‌های گرافیکی موجود نباشند، متفاوت باشد. قلم‌های مورد استفاده در محتوای منبع را نصب کنید یا جایگزین‌های مناسب تنظیم کنید، [نیازهای پلتفرم](/slides/fa/nodejs-java/system-requirements/) را برای Aspose.Slides برای Node.js از طریق Java دنبال کنید و نتیجه را در برنامه مصرف‌کننده EMF هدف اعتبارسنجی کنید. برنامه‌های لینوکس و macOS اغلب پشتیبانی محدود یا ناسازگاری برای نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندر رنگی ایموجی**

{{% alert title="نکته" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصویر، قلم‌های ایموجی مورد استفاده در ارائه باید نصب و در سیستمی که تبدیل را انجام می‌دهد، قابل دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این قلم موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**

خیر. متد [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را صادر نمی‌کند.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند مانند اسلایدهای معمولی رندر شوند. آن‌ها را در حلقه پردازش شامل کنید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر اثرها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر اثرات گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.