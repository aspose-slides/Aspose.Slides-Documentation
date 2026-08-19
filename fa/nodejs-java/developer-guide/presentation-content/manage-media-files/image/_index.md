---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/nodejs-java/image/
keywords:
- افزودن تصویر
- افزودن picture
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر لینک‌شده
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- تبدیل SVG به شکل‌ها
- منابع خارجی SVG
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نحوه افزودن، استفاده مجدد، لینک کردن، جایگزینی و مدیریت تصاویر رستری و SVG در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js via Java را بیاموزید."
---
## **معرفی**

Aspose.Slides for Node.js via Java چندین روش برای کار با تصاویر فراهم می‌کند و هر کدام هدف متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، آن را در یک قاب تصویر نمایش دهید، به عنوان پس‌زمینه اسلاید استفاده کنید، به تصویر خارجی لینک دهید، یک منبع تصویر مشترک را جایگزین کنید، یا محتوای SVG را به شکل‌های قابل ویرایش تبدیل کنید.  
این مقاله بر روی منابع تصویر و نحوه استفاده آنها در یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و سایر قالب‌بندی‌های اعمال شده به یک قاب تصویر منفرد، به [Picture Frame](/slides/fa/nodejs-java/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

ملاحظات API زیر به‌طور نزدیک مربوط هستند اما قابل تعویض نیستند:

- مجموعهٔ [presentation image collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) منابع تصویر مورد استفاده در ارائه را ذخیره می‌کند. برای افزودن داده‌های تصویر و دریافت منبع [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/)، از [ImageCollection.addImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) استفاده کنید.
- یک [picture frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) یک شکل است که تصویر را بر روی اسلاید، طرح‌بندی یا مستر نمایش می‌دهد. برای قرار دادن یک منبع تصویر بر روی اسلاید، از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) استفاده کنید.
- پس‌زمینهٔ اسلاید از تصویر به عنوان بخشی از پر کردن اسلاید استفاده می‌کند نه به‌عنوان یک شکل. بنابراین همانند یک picture frame رفتار نمی‌کند.
- [PPImage.replaceImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همه از جایگزین استفاده می‌کنند.
- تبدیل SVG به شکل‌ها، شکل‌های قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

بنابراین یک جریان کاری معمول به‌این شکل است: داده‌های تصویر را به مجموعهٔ تصاویر اضافه کنید، یک [PPImage] دریافت کنید، و سپس از آن منبع در یک یا چند picture frame یا پر‌کردن استفاده کنید.

## **افزودن تصویر جاسازی‌شده**

برای درج یک تصویر محلی، فایل را بارگذاری کنید، به مجموعهٔ تصاویر اضافه کنید، و یک picture frame ایجاد کنید که از منبع [PPImage] برگردانده شده استفاده می‌کند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصویری که به این روش اضافه می‌شود در ارائه جاسازی می‌شود، بنابراین فایل نتیجه به موجود بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

وقتی تصویری از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را دانلود کنید، به مجموعهٔ تصاویر ارائه اضافه کنید، و از منبع تصویر برگشتی به همان روش یک تصویر محلی استفاده کنید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

در برنامه‌های با زمان اجرای طولانی، به جای ایجاد مکرر زیرساخت شبکه‌ای غیرضروری، یک کلاینت HTTP یا استراتژی مدیریت اتصال مناسب برنامه را مجدداً استفاده کنید. همچنین هنگام عدم اطمینان به منبع، URLهای خارجی، اندازه‌های پاسخ و نوع محتوا را اعتبارسنجی کنید.

## **استفاده مجدد از تصاویر در اسلایدها**

اگر تصویر یکسان بیش از یک بار مورد نیاز باشد، یک بار آن را به ارائه اضافه کنید و [PPImage] بازگردانده شده را هنگام ایجاد picture frameهای بیشتر استفاده کنید. این کار از بارگذاری مکرر داده‌های منبع جلوگیری می‌کند و رابطهٔ بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌سازد.

برای گرافیک‌هایی که باید به‌طور خودکار در اسلایدهای متعدد ظاهر شوند، مانند لوگوی شرکت، به جای اضافه کردن یک شکل معادل به هر اسلاید، قرار دادن picture frame بر روی یک [slide master](/slides/fa/nodejs-java/slide-master/) یا layout را در نظر بگیرید.

## **استفاده از تصویر به‌عنوان پس‌زمینهٔ اسلاید**

تصویر پس‌زمینه به پر کردن اسلاید اختصاص می‌یابد؛ به‌عنوان یک شکل picture-frame اضافه نمی‌شود. این مفید است وقتی که تصویر باید تمام پس‌زمینهٔ اسلاید را پوشش دهد و نباید به‌عنوان یک شیء عادی اسلاید دست‌کاری شود.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای گزینه‌های پس‌زمینهٔ بیشتر، شامل پس‌زمینه‌های مستر و layout، به [Presentation Background](/slides/fa/nodejs-java/presentation-background/) مراجعه کنید.

## **تصاویر جاسازی‌شده و لینک‌شده**

تصاویر جاسازی‌شده و لینک‌شده تعادلات متفاوتی از نظر قابلیت حمل و اندازهٔ فایل دارند:

- **تصویر جاسازی‌شده:** دادهٔ تصویر در داخل ارائه ذخیره می‌شود. ارائه مستقل است، اما اندازهٔ فایل شامل دادهٔ تصویر است.
- **تصویر لینک‌شده:** ارائه مسیر یا URL یک تصویر خارجی را ذخیره می‌کند. این می‌تواند اندازهٔ ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه در دسترس باقی بماند.

یک تصویر لینک‌شده می‌تواند با اختصاص مسیر یا URL خارجی از طریق [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) به‌جای جاسازی دادهٔ تصویر ایجاد شود.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از تصاویر لینک‌شده فقط زمانی استفاده کنید که محیط استقرار بتواند به‌طور قابل اعتماد به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر جاسازی‌شده معمولاً امن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکون‌ها، نمودارها و سایر گرافیک‌هایی که باید بدون از دست دادن جزئیات همانند تصاویر رستری مقیاس‌پذیر باشند مفید است. Aspose.Slides هم به‌عنوان منبع تصویر و هم به‌عنوان منبعی برای شکل‌های قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) ایجاد کنید، به مجموعهٔ تصاویر اضافه کنید، و منبع تصویر حاصل را در یک picture frame قرار دهید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصاویر، برگه‌های سبک یا فونت‌های خارجی ارجاع دهد. برای این موارد، [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) سازنده‌هایی فراهم می‌کند که یک [ExternalResourceResolver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/externalresourceresolver/) و یک base URI را می‌پذیرند. رزولور می‌تواند یک URI نسبی را به یک URI مطلق مجاز نگاشت کند و یک جریان برای منبع درخواست‌شده برگرداند.

رزولور منابع خارجی را در طول پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به یک سند خودمستقل بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را در خود SVG جاسازی کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر لینک‌شده.

هنگامی که فایل‌های SVG از منابع غیرقابل اعتماد می‌آیند، طرح‌ها، مکان‌های فایل و میزبان‌هایی که رزولور می‌تواند به آن‌ها دسترسی داشته باشد محدود کنید. رزولورهای شبکه باید همچنین زمان‌سنجی، محدودیت‌های اندازهٔ پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به شکل‌های قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از شکل‌های قابل ویرایش اسلاید تبدیل کند، مشابه فرمان مربوطه در PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

از overload [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) که یک تصویر SVG می‌پذیرند برای انجام تبدیل استفاده کنید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از تبدیل SVG به شکل‌ها زمانی استفاده کنید که عناصر برداری منفرد نیاز به ویرایش به‌عنوان شکل‌های PowerPoint داشته باشند. اگر فقط نیاز به نمایش SVG باشد، نگه‌داری آن به‌صورت تصویر ساده‌تر است و از ایجاد شکل‌های جداگانهٔ متعدد جلوگیری می‌کند.

## **جایگزینی یک منبع تصویر موجود**

هنگام نیاز به جایگزینی یک منبع تصویر موجود از [PPImage.replaceImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) استفاده کنید. این به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر چندین picture frame، پس‌زمینه، مستر یا layout از یک منبع تصویر یکسان استفاده کنند، جایگزین کردن آن منبع تمام استفاده‌ها را به‌روز می‌کند. اگر فقط یک picture frame باید تغییر کند، به جای جایگزینی منبع مشترک، تصویر متفاوتی به آن frame اختصاص دهید.

[PPImage.replaceImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) همچنین overloadهایی ارائه می‌دهد که یک آرایه بایت یا یک [PPImage] دیگر را می‌پذیرند.

## **راهنمایی‌های عملی مدیریت تصویر**

### **کنترل اندازهٔ ارائه**

تصاویر رستری بزرگ می‌توانند اندازهٔ ارائه را به‌طور غیرضروری بزرگ کنند. از تصاویر منبع با ابعاد مناسب برای اندازهٔ نمایش موردنظر استفاده کنید، در صورت امکان منابع تصویر مشترک را مجدداً به کار ببرید، و از جاسازی نسخه‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که قبلاً در picture frameها قرار گرفته‌اند، [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) می‌تواند دادهٔ تصویر را بر اساس وضوح انتخاب‌شده و تنظیمات برش کاهش دهد. این پردازش picture-frame است نه مدیریت مجموعهٔ تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [Picture Frame](/slides/fa/nodejs-java/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای جاسازی‌شده و لینک‌شده**

جاسازی، ارائه را قابل حمل می‌سازد زیرا تمام داده‌های تصویر موردنیاز همراه فایل می‌روند. لینک کردن می‌تواند اندازهٔ فایل را کاهش دهد، اما یک وابستگی خارجی ایجاد می‌کند. فقط زمانی از لینک‌ها استفاده کنید که این وابستگی قابل قبول و ثابت باشد.

### **استفاده مجدد از برندینگ مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، یک منبع تصویر استفاده کنید و آن را مجدداً به کار ببرید. اگر گرافیک متعلق به طراحی ارائه باشد نه به محتوای اسلاید، آن را بر روی یک مستر یا layout قرار دهید تا توسط اسلایدهای مربوط به‌ارث برده شود.

### **سازگار نگه داشتن منابع SVG**

یک SVG خودمستقل انتقال و رندر مداوم‌تری نسبت به SVGی که به فایل‌ها یا منابع شبکه‌ای خارجی وابسته است دارد. در صورت امکان، منابع مورد نیاز را پیش از وارد کردن SVG جاسازی کنید. تبدیل SVG به شکل‌ها تنها وقتی انجام شود که عناصر برداری منفرد نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر مدرن چندپلتفرمی**

برای کدهای جدید Node.js via Java، به‌جای API عمومی قدیمی مبتنی بر `java.awt.image.BufferedImage`، از APIهای Aspose.Slides [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/images/) استفاده کنید. برای راهنمای مهاجرت به [Modern API](/slides/fa/nodejs-java/modern-api/) مراجعه کنید.

WMF و EMF نیاز به ملاحظات ویژه دارند. وقتی این فرمت‌ها از طریق یک [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) عبور می‌کنند، [ImageCollection.addImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) قبل از افزودن، متافایل را به یک نمایندگی PNG رستری تبدیل می‌کند. اگر حفظ داده‌های متافایل مهم باشد، به‌جای آن از overload مبتنی بر جریان [ImageCollection.addImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) استفاده کنید. تولید محتوای EMF از صفحات گسترده یا سایر محصولات یک جریان ادغام جداگانه است و خارج از دامنهٔ این مقاله می‌باشد.

## **سؤالات متداول**

**What is the difference between the image collection and a picture frame?**  
مجموعهٔ تصویر منابع تصویر قابل استفاده مجدد را ذخیره می‌کند. یک picture frame یک شکل اسلاید است که یکی از این منابع را نمایش می‌دهد و قالب‌بندی مخصوص تصویر مانند برش و افکت‌ها را فراهم می‌کند.

**What is the best way to replace the same logo everywhere?**  
اگر لوگو قبلاً به عنوان یک منبع تصویر اشتراک‌گذاری شده باشد، آن منبع را با [PPImage.replaceImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) جایگزین کنید. برای برندینگ در سرتاسر ارائه، قرار دادن لوگو بر روی یک مستر یا layout نیز می‌تواند محتویات اسلایدهای تکراری را کاهش دهد.

**Why does a linked image disappear on another computer?**  
یک تصویر لینک‌شده به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر لینک‌شده ممکن است در دسترس نباشد. هنگام نیاز به ارائهٔ خودمستقل، تصویر را جاسازی کنید.

**Can an inserted SVG be edited as PowerPoint shapes?**  
بله. SVG را با [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) تبدیل کنید؛ گروه حاصل شامل شکل‌های قابل ویرایش اسلاید به‌جای یک تصویر SVG است.

**How can I keep presentations with many images smaller?**  
از منابع تصویر مشترک مجدداً استفاده کنید، از منابع رستری بزرگ غیرضروری خودداری کنید، در صورت مناسب تصاویر رستری را فشرده کنید، برندینگ تکراری را بر روی مسترها یا layoutها قرار دهید، و فقط زمانی از تصاویر لینک‌شده استفاده کنید که وابستگی خارجی قابل قبول باشد.