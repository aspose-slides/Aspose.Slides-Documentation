---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/nodejs-java/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت تصویر را در PowerPoint و OpenDocument با JavaScript و Aspose.Slides برای Node.js به‌صورت بهینه‌سازی شده، عملکرد را بهبود داده و جریان کار شما را خودکار می‌کند."
---
## **معرفی**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در Microsoft PowerPoint، می‌توانید تصاویر را از یک فایل، اینترنت یا مکان‌های دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تا از طریق روش‌های مختلف، تصاویر را به اسلایدهای ارائه‌های خود اضافه کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به کاربران امکان می‌دهد به‌سرعت از تصاویر ارائه‌ها را ایجاد کنند.

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید تصویری را به‌عنوان یک شیء فریم اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد برای تغییر اندازه، افزودن افکت‌ها و غیره استفاده کنید—به [قاب تصویر](https://docs.aspose.com/slides/fa/nodejs-java/picture-frame/) مراجعه کنید.

{{% /alert %}} 

Aspose.Slides از عملیات با تصاویر در این قالب‌های محبوب پشتیبانی می‌کند: JPEG، PNG، GIF و سایرین.

## **افزودن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر موجود در رایانه خود را به اسلایدی در یک ارائه اضافه کنید. این کد نمونه در JavaScript نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن تصاویر از جریان به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در رایانه شما موجود نیست، می‌توانید تصویر را مستقیم از وب اضافه کنید.

این کد نمونه نشان می‌دهد چگونه تصویری را از وب به اسلاید در JavaScript اضافه کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var sld = pres.getSlides().get_Item(0);
    // یک فایل اکسل را به جریان می‌خواند
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // یک شیء داده برای جاسازی ایجاد می‌کند
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // یک شکل فریم شیء Ole اضافه می‌کند
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن تصاویر به اسلاید مسترها**

اسلاید مستر بالاترین اسلاید است که اطلاعات (تم، طرح‌بندی و غیره) تمام اسلایدهای زیر مجموعه خود را ذخیره و کنترل می‌کند. بنابراین، وقتی تصویری را به اسلاید مستر اضافه کنید، آن تصویر در هر اسلاید زیر آن اسلاید مستر ظاهر می‌شود.

این کد نمونه JavaScript نشان‌دهنده نحوه افزودن تصویر به اسلاید مستر است:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلاید**

ممکن است تصمیم بگیرید تصویری را به‌عنوان پس‌زمینه اسلاید خاص یا چند اسلاید استفاده کنید. در این صورت، باید به *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](https://docs.aspose.com/slides/fa/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **افزودن SVG به ارائه‌ها**

می‌توانید هر تصویری را با استفاده از متد [addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) که متعلق به کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) است، به یک ارائه اضافه یا وارد کنید.

برای ایجاد یک شیء تصویر مبتنی بر تصویر SVG، می‌توانید به این شکل عمل کنید:

1. ایجاد شیء SvgImage برای وارد کردن آن به ImageShapeCollection
2. ایجاد شیء PPImage از ISvgImage
3. ایجاد شیء PictureFrame با استفاده از کلاس PPImage

این کد نمونه نشان می‌دهد چگونه مراحل فوق را برای افزودن تصویر SVG به یک ارائه پیاده‌سازی کنید:
```javascript
// نمونه‌سازی کلاس Presentation که فایل PPTX را نمایندگی می‌کند
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

تبدیل SVG به مجموعه‌ای از شکل‌ها در Aspose.Slides شبیه به عملکرد PowerPoint برای کار با تصاویر SVG است:

![PowerPoint Popup Menu](img_01_01.png)

عملکرد توسط یکی از overloadهای متد [addGroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) فراهم می‌شود که یک شیء [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SvgImage) را به‌عنوان اولین آرگومان می‌گیرد.

این کد نمونه نشان می‌دهد چگونه از متد توصیف‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:

```javascript
// ایجاد ارائه جدید
var presentation = new aspose.slides.Presentation();
try {
    // خواندن محتوای فایل SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // ایجاد شیء SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // دریافت اندازه اسلاید
    var slideSize = presentation.getSlideSize().getSize();
    // تبدیل تصویر SVG به گروهی از شکل‌ها و مقیاس‌بندی آن به اندازه اسلاید
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // ذخیره ارائه در قالب PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **افزودن تصاویر به‌صورت EMF در اسلایدها**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد تصاویر EMF را از برگه‌های Excel تولید کنید و تصاویر را به‌صورت EMF در اسلایدها با Aspose.Cells اضافه کنید.

این کد نمونه نشان می‌دهد چگونه کار توصیف‌شده را انجام دهید:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// ذخیره کتاب کار به جریان
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما امکان می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه (از جمله آن‌هایی که توسط شکل‌های اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چند رویکرد برای به‌روزرسانی تصاویر در مجموعه نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی تصویر با استفاده از داده‌های بایت خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. فایل ارائه‌ای که حاوی تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. یک تصویر جدید را از فایل به یک آرایه بایت بارگذاری کنید.
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
4. در رویکرد دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در رویکرد سوم، تصویر هدف را با تصویری که قبلاً در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```js
// نمونه‌سازی کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // روش اول.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // روش دوم.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // روش سوم.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // ذخیره ارائه در یک فایل.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

با استفاده از مبدل رایگان Aspose FREE [متن به GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به سادگی متن‌ها را انیمیشن کنید، GIF از متن‌ها بسازید و غیره.

{{% /alert %}}

## **پرسش‌های متداول**

**آیا وضوح تصویر اصلی پس از درج دست نخورده می‌ماند؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این‌که چگونه [تصویر](/slides/fa/nodejs-java/picture-frame/) در اسلاید مقیاس‌بندی شده و هرگونه فشرده‌سازی هنگام ذخیره‌سازی اعمال شده است، بستگی دارد.

**بهترین روش برای جایگزینی لوگوی یکسان در چندین اسلاید به‌صورت یکجا چیست؟**

لوگو را بر روی اسلاید مستر یا یک طرح‌بندی قرار دهید و در مجموعه تصویر ارائه آن را جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، منتقل خواهد شد.

**آیا می‌توان SVG واردشده را به شکل‌های قابل ویرایش تبدیل کرد؟**

بله. می‌توانید SVG را به یک گروه از شکل‌ها تبدیل کنید، پس از آن بخش‌های جداگانه با خصوصیات استاندارد شکل قابل ویرایش خواهند شد.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه چند اسلاید به‌صورت یکجا تنظیم کنم؟**

[تخصیص تصویر به‌عنوان پس‌زمینه](/slides/fa/nodejs-java/presentation-background/) بر روی اسلاید مستر یا طرح‌بندی مربوطه—هر اسلایدی که از آن مستر/طرح‌بندی استفاده می‌کند، پس‌زمینه را به ارث خواهد برد.

**چگونه می‌توانم از بزرگ شدن بیش از حد اندازه ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

به‌جای استفاده از چند نسخه، یک منبع تصویر را دوباره استفاده کنید، وضوح‌های معقولی انتخاب کنید، هنگام ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید که مناسب باشد.