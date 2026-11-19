---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از Node.js
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/nodejs-java/3d-presentation/
keywords:
- 3D پاورپوینت
- ارائه 3D
- چرخش 3D
- عمق 3D
- استخراج 3D
- گرادیان 3D
- متن 3D
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اعمال و رندر افکت‌های 3D برای اشکال و متن PowerPoint در Node.js با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، استخراج، پرکردن‌ها و متن 3D."
---
## **نمای کلی**

Aspose.Slides برای Node.js از طریق Java می‌تواند قالب‌بندی 3D سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های 3D مانند چرخش، استخراج (extrusion)، برش‌های زاویه‌دار (bevels)، نورپردازی، مواد، پرکردن با گرادیان یا تصویر، و متن 3D می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ افکت‌های قالب‌بندی 3D بر روی اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل 3D مستقل نیست. هنگام خروجی گرفتن یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides آن افکت‌های 3D را به خروجی دو‑بعدی تبدیل می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی 3D**

از متد [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی 3D به یک شکل استفاده کنید. این متد یک شیء [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) را برمی‌گرداند که صحنهٔ 3D آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این کار قالب‌بندی 3D را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| API member | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطهٔ دید، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | برای چرخاندن شیء در فضای 3D یا مطابقت با یک پیش‌تنظیم چرخش 3D در PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر هایلایت‌ها و سایه‌ها روی سطح 3D. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | ماده سطح، مانند صاف، مات، پلاستیک یا فلز. | برای ظاهر دادن به هندسهٔ یکسان به صورت صاف‌تر، نرم‌تر، براق یا فلزی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان خروجی شکل از سطح جلویی به سمت عقب. | برای تبدیل یک شکل صاف به شیء 3D با ضخامت قابل مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ سمت‌های استخراج‌شده. | برای نمایش عمق یا هماهنگی رنگ کنار با پرکردن جلویی. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق 3D اضافی که توسط قالب‌بندی 3D PowerPoint استفاده می‌شود. | برای تنظیم دقیق عمق اشکال یا متن، به‌ویژه همراه با تنظیمات برش (bevel) و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های بالا یا پایین گرد یا برجسته بر روی سطوح جلویی و پشتی. | برای افزودن لبه‌ای نرم یا قالب‌دار به‌جای یک سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | خط مرزی اطراف شیء 3D. | برای برجسته کردن مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل 3D**

یک شکل معمولاً قبل از اینکه به‌صورتی قانع‌کننده 3D به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض ممکن است استخراج را پنهان کند.
- تنظیمات نور، چون نورپردازی باعث می‌شود سطوح و کناره‌ها قابل تشخیص باشند.
- تنظیمات ماده، چون سطح روی نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات استخراج یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌نماید و قالب‌بندی 3D را اعمال می‌کند. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع استخراج 100 پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصویر رندر شدهٔ اسلاید نشان می‌دهد که مستطیل به‌عنوان یک بلوک 3D ضخیم نمایش داده می‌شود:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش 3D از پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

در Aspose.Slides، از طریق [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) به دوربین دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلویی اورتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z را به ترتیب 20، 30 و 40 درجه تنظیم می‌نماید. این تنظیمات را در حافظه اعمال می‌کند بدون اینکه فایلی ذخیره شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ مشاهدهٔ شیء توسط کاربر را تغییر دهید. این کار هندسهٔ 2D شکل را در اسلاید تغییر نمی‌دهد، بلکه نقطهٔ دید 3D استفاده شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

### **کپی کردن جهت دوربین از یک شکل قالب**

برای مطابقت جهت یک شکل قالب، پیش‌تنظیم دوربین آن را با [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) بخوانید و زاویه‌های چرخش آن را با [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) دریافت کنید. مثال فایل `template.pptx` را باز می‌کند و جهت دوربین اولین شکل در اسلاید اول را به شکل دوم کپی می‌کند. هر دو شکل قبلاً نور 3D دارند و شکل دوم چرخش دوربین صریحی ندارد.

زاویه‌ها بر حسب درجه هستند. اندیس `0` عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` دوران را نشان می‌دهد. آن‌ها را به ترتیب به [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) پاس بدهید. اگر منبع `null` برگرداند، یعنی چرخش صریحی ندارد، بنابراین زاویه‌های شکل دوم تنظیم نمی‌شوند. چرخش صریح `(0, 0, 0)` سه صفر برمی‌گرداند و باید کپی شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

زمانی که `camera-copy.pptx` را دوباره در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم دوربین و چرخش را دارد که مستطیل سمت چپ دارد. هر دو شکل از نور و عمق استخراج یکسان استفاده می‌کنند.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **افزودن استخراج (Extrusion) و عمق**

استخراج باعث می‌شود یک شکل ضخیم به نظر برسد زیرا از سطح جلویی به سمت پشت گسترش می‌یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ سمت‌های جانبی را مشخص می‌سازد.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

از [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) برای تنظیم ضخامت و از [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) برای دسترسی به رنگ جانبی استفاده کنید. این مثال به یک مستطیل ارتفاع استخراج 100 پوینت با کناره‌های بنفش می‌دهد و دوربین را چرخانده تا ضخامت آن نمایان شود. تنظیمات در حافظه انجام می‌شود بدون ذخیره فایل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

متد [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) عمق یک شکل 3D را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ارتفاع اثر استخراج را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکردن گرادیان یا تصویر همراه با افکت‌های 3D**

قالب‌بندی 3D مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکردن تصویر را بر روی سطح جلویی اعمال کنید و همچنان از همان دوربین، نور، ماده و تنظیمات استخراج استفاده نمایید.

این مثال یک گرادیان آبی‑به‑نارنجی را بر روی سطح جلویی اعمال می‌کند و رنگ نارنجی تیره‌ای به استخراج 150 پوینتی می‌دهد. توقف‌های گرادیان در 0 و 100 شروع و پایان گرادیان را مشخص می‌کنند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و استخراج را به‌صورت جداگانه رندر می‌کند:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

برای استفاده از پرکردن تصویری، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید. این مثال به فایلی به‌نام «image.jpg» در پوشه کاری نیاز دارد. تصویر را به‌ گونه‌ای کش می‌دهد که مستطیل را پر کند، استخراج 150 پوینت اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. تنظیمات در حافظه انجام می‌شود بدون ذخیره یا رندر فایل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که استخراج به‌عنوان سطح جانبی 3D رندر می‌شود:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **اعمال قالب‌بندی 3D به متن**

قالب‌بندی 3D شکل بر روی بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی 3D متن بر روی فریم متن تأثیر می‌گذارد. این برای افکت‌های شبیه WordArt مفید است که حروف خود نیاز به استخراج، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑و‑سفید ایجاد می‌کند، یک قوس بالا را اعمال می‌نماید و تنظیمات 3D را از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) پیکربندی می‌کند. ارتفاع استخراج و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکردن شکل و خط دور شامل نمی‌شود تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متن به‌صورت حروف 3D خمیده، استخراج‌شده رندر می‌شود:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **حفظ متن صاف بر روی یک شکل 3D**

برای اینکه متن قابل خواندن بماند در حالی که ظاهر 3D شکل حفظ شود، از [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) از طریق [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) فراخوانی کنید. وقتی مقدار `true` باشد، متن از صحنهٔ 3D خارج می‌شود. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت 3D آن را دنبال می‌کند.

این تنظیم، قالب‌بندی 3D شکل را حذف نمی‌کند: دوربین، نور، ماده و استخراج آن همچنان از طریق [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) تنظیم شده‌اند. همچنین با چرخش معمولی متفاوت است. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) شکل را در صفحه اسلاید می‌چرخاند، در حالی که [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) چرخش سفارشی متن را درون جعبهٔ مرزی‌اش کنترل می‌کند. ثابت نگه داشتن متن خارج از صحنهٔ 3D هیچ‌یک از این زوایا را ریست نمی‌کند.

مثال خود‌مستقلی زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصل کلون می‌نماید. هر دو شکل همان قالب‌بندی 3D را دارند؛ تنها تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع استخراج 40 پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

در سمت چپ، متن جهت 3D را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل استخراج و جهت 3D قابل مشاهدهٔ یکسانی دارند.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides قالب‌بندی 3D را هنگام ذخیره‌سازی به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑طرح، صحنهٔ 3D به‌صورت تصویر رستر یا به‌عنوان نتیجهٔ 2D در خروجی رسم می‌شود. این موضوع برای رندر اسلایدها به [PNG](/slides/fa/nodejs-java/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی بستگی به ترکیب دوربین، نور، ماده، استخراج، پرکردن و مقیاس اسلاید دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده از ارث‌بری یا تم دارید، ویژگی‌های مؤثر شکل را از طریق [effective shape properties](/slides/fa/nodejs-java/shape-effective-properties/) بخوانید.
- برخی از فرمت‌های خروجی قادر به ذخیره‌سازی قالب‌بندی‌های قابل ویرایش 3D PowerPoint نیستند. در این فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه به‌عنوان تنظیمات قابل ویرایش 3D.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های 3D تعاملی ایجاد کند؟**

Aspose.Slides افکت‌های 3D PowerPoint برای اشکال و متن را ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی شده را صحنهٔ 3D تعاملی نمی‌سازد که کاربر بتواند آن را بچرخاند. در PPTX، قالب‌بندی 3D در PowerPoint به‌صورت قابل ویرایش باقی می‌ماند هنگامی که فرمت آن را پشتیبانی کند.

**تفاوت بین یک مدل 3D و یک افکت 3D چیست؟**

یک مدل 3D شیء جداگانه‌ای است که به ارائه اضافه می‌شود. یک افکت 3D قالب‌بندی‌ای است که به یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، برش زاویه‌دار، نورپردازی و ماده. این مقاله به افکت‌های 3D می‌پردازد.

**کدام تنظیمات برای یک شکل 3D قابل مشاهده لازم هستند؟**

حداقل باید یک چرخش دوربین و یا استخراج یا عمق تنظیم شود. در عمل، تنظیم یک نور و ماده نیز توصیه می‌شود تا سطوح رندر شده روشنایی و سایه‌های واضحی داشته باشند.

**آیا می‌توانم افکت‌های 3D را هم بر روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا افکت‌های 3D هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های 3D را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئو رندر می‌کند. خروجی تولید شده ظاهر رندر شده را دارد، نه یک شیء 3D قابل ویرایش.

**آیا می‌توانم مقادیر نهایی 3D را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توصیف شده در [Shape Effective Properties](/slides/fa/nodejs-java/shape-effective-properties/) برای خواندن نهایی دوربین، نور، برش و مقادیر 3D دیگر استفاده کنید.