---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از Node.js
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/nodejs-java/3d-presentation/
keywords:
- پاورپوینت سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برجستگی سه‌بعدی
- گرادینت سه‌بعدی
- متن سه‌بعدی
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن PowerPoint در Node.js با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، برجستگی، پرکردن‌ها و متن سه‌بعدی."
---
## **مروری**

Aspose.Slides for Node.js via Java می‌تواند فرمت‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برجستگی، لبه‌گیری، نورپردازی، مواد، پر کردن با گرادینت یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله در مورد اثرات فرمت‌بندی سه‌بعدی بر اشکال و متن PowerPoint است. این مقاله دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی سه‌بعدی**

از متد [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getThreeDFormat) برای اعمال فرمت‌بندی سه‌بعدی روی یک شکل استفاده کنید. این متد یک شیء [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این متد فرمت‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | چه زمانی استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطه‌ی مشاهده، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش هایلایت‌ها و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setMaterial) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلز. | ظاهر هندسهٔ مشابه را صاف‌تر، نرم‌تر، براق‌تر یا فلزی‌تر کنید. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | فاصلهٔ امتداد شکل به سمت پشت از صورت جلو. | یک شکل صاف را به شیء سه‌بعدی قابل مشاهده تبدیل کنید. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ طرف‌های برجسته‌شده. | عمق را قابل رؤیت کنید یا رنگ طرف‌ها را با پرکردن جلوی هماهنگ کنید. |
| [getDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق سه‌بعدی اضافی استفاده‌شده توسط فرمت‌بندی سه‌بعدی PowerPoint. | عمق را برای اشکال یا متن به‌دقت تنظیم کنید، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های برجسته یا گرد‌شده روی سطوح جلوی و پشت. | اضافه کردن لبهٔ نرم یا قالب‌گیری‌شده به‌جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setContourWidth) | کنتور اطراف شیء سه‌بعدی. | مرز شیء را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌طور قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض جلو ممکن است برجستگی را مخفی کند.
- تنظیمات نور، چون نورپردازی باعث قابل مشاهده شدن سطوح و اضلاع می‌شود.
- تنظیمات ماده، چون سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برجستگی یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی را به سطح جلو اضافه می‌کند و فرمت‌بندی سه‌بعدی اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع برجستگی ۱۰۰ پوینت است. مثال اسلاید را به تصویر PNG با دو برابر اندازهٔ پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید.

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک ضخیم سه‌بعدی نشان می‌دهد:

![مستطیل آبی سه‌بعدی رندر شده با متن سفید سه‌بعدی روی سطح جلو](img_01_01.png)

## **چرخاندن شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation پیکربندی می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنجره چرخش 3‑بعدی PowerPoint با مقادیر چرخش X، Y و Z هایلایت شده](img_02_01.png)

در Aspose.Slides، از طریق [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getCamera) به دوربین دسترسی پیدا می‌کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلوی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌نماید. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره کند:

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

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید. این تغییر باعث تغییر هندسهٔ دو‌بعدی شکل روی اسلاید نمی‌شود، بلکه نقطه‌نظر سه‌بعدی مورد استفادهٔ PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن برجستگی و عمق**

برجستگی باعث می‌شود یک شکل ضخیم به‌نظر برسد با این که به‌سوی پشت صورت جلو امتداد یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های جانبی را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint به‌صورت رنگ برجستگی و خصوصیات ارتفاع برجستگی مطابقت داده شده‌اند](img_02_02.png)

از [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) برای تنظیم ضخامت و از [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال به مستطیل برجستگی ۱۰۰ پوینتی با رنگ‌های بنفش برای طرف‌ها می‌دهد و دوربین را می‌چرخاند تا ضخامت آن را نشان دهد. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره کند:

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

متد [ThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setDepth) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ارتفاع اثر برجستگی را کنترل می‌کند، همان‌گونه که در این مثال نشان داده شده است.

## **استفاده از پرکردن گرادینت یا تصویر با اثرات سه‌بعدی**

فرمت‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید به سطح جلو یک رنگ ثابت، گرادینت، الگو یا تصویر اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برجستگی استفاده کنید.

این مثال گرادینت آبی‑به‑نارنجی را روی سطح جلو و رنگ نارنجی تیره را به برجستگی ۱۵۰ پوینتی اعمال می‌کند. توقف‌های گرادینت در علامت‌های ۰ و ۱۰۰ شروع و پایان گرادینت را مشخص می‌کنند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر اندازهٔ پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادینت را روی سطح جلو حفظ می‌کند و برجستگی را به‌طور جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکردن گرادینت از آبی به نارنجی و برجستگی نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکردن شکل اختصاص دهید. این مثال به فایلی به‌نام «image.jpg» در دایرکتوری کاری نیاز دارد. تصویر را برای پر کردن مستطیل کش می‌دهد، برجستگی ۱۵۰ پوینتی اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایل ذخیره یا رندر کند:

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

تصویر بر روی سطح جلو رندر می‌شود، در حالی که برجستگی به‌صورت سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکردن تصویر بر روی سطح جلو و برجستگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی سه‌بعدی بر متن**

فرمت‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. فرمت‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برجستگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑و‑سفید ایجاد می‌کند، یک قوس رو به بالا اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) پیکربندی می‌کند. ارتفاع برجستگی و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکردن شکل و کنتور مخفی هستند تا فقط متن قابل رؤیت باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند:

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

متن به‌صورت حروف خمیده و برجستهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکردن الگوی نارنجی و برجستگی تیره](img_02_05.png)

## **متن را روی یک شکل سه‌بعدی صاف نگه دارید**

برای اینکه متن خوانا بماند در حالی که ظاهر سه‌بعدی شکل حفظ شود، از [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) از طریق [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) استفاده کنید. وقتی مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم فرمت‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برجستگی همچنان از طریق [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getThreeDFormat) پیکربندی شده‌اند. همچنین متفاوت از چرخش معمولی است. [Shape.setRotation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setRotation) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) چرخش سفارشی متن را داخل جعبهٔ مرزبندی آن کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را ریست نمی‌کند.

مثال خودمختار زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصلی کپی می‌کند. هر دو شکل همان فرمت‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع برجستگی ۴۰ پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواناتر است. هر دو مستطیل همان برجستگی قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ با جهت‌گیری سه‌بعدی دنبال می‌شود و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides فرمت‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های با چیدمان ثابت، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌عنوان نتیجهٔ ۲D در خروجی رسم می‌شود. این هنگام رندر اسلایدها به [PNG](/slides/fa/nodejs-java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل به ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای صادر شده تعاملی نیستند. پس از صادرات شیء توسط بیننده قابل چرخش نیست.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، برجستگی، پرکردن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر فرمت‌بندی به ارث‌برده یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/nodejs-java/shape-effective-properties/) را بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند فرمت‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این فرمت‌ها، نتیجهٔ بصری به‌جای حفظ به‌عنوان تنظیمات سه‌بعدی ویرایشی رندر می‌شود.

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDFها یا صفحات HTML صادر شده را به‌صورت صحنه‌های تعاملی سه‌بعدی که کاربر می‌تواند آن‌ها را بچرخاند، تبدیل نمی‌کند. در PPTX، فرمت‌بندی سه‌بعدی در PowerPoint به‌صورت ویرایشی باقی می‌ماند، به شرطی که فرمت آن را پشتیبانی کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی فرمت‌بندی است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برجستگی، لبه‌گیری، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای دیده‌شدن یک شکل سه‌بعدی ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا برجستگی/عمق تنظیم شود. در عمل، همچنین تنظیم نورپردازی و ماده توصیه می‌شود تا سطوح رندر شده دارای هلیت‌ها و سایه‌های واضح باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر اشکال و هم بر متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getThreeDFormat) استفاده کنید و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل به ویدئو رندر می‌کند. خروجی صادر شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای فرمت‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/nodejs-java/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، لبه و مقادیر مرتبط با سه‌بعدی استفاده کنید.