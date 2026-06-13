---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از Node.js
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/nodejs-java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متن PowerPoint در Node.js با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، برآمدگی، پرکن‌ها و متن سه‌بعدی."
---
## **نمای کلی**

Aspose.Slides برای Node.js از طریق Java می‌تواند قالب‌بندی‌های سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآمدگی، لبه‌زنی، نورپردازی، مواد، پرکردن گرادیان یا تصویر و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن PowerPoint است. دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام صادرات یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides آن اثرات سه‌بعدی را در خروجی دو‑بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. شیٔ بازگردانده‌شدهٔ [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` استفاده کنید. این روش قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چیزی که کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطهٔ مشاهده، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا تطبیق با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر نقاط نورانی و سایه‌ها بر سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setMaterial) | جنس سطح، مانند صاف، مات، پلاستیک یا فلز. | تبدیل هندسهٔ یکسان به ظاهر صاف‌تر، نرم‌تر، براق یا فلزی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | فاصلهٔ گسترش شکل به عقب از سطح جلویی. | تبدیل یک شکل صاف به یک شیء سه‌بعدی به طور واضح ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ سمت‌های برآمده. | نشان دادن عمق یا هماهنگ‌سازی رنگ سمت‌ها با پرکن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق سه‌بعدی اضافی استفاده‌شده توسط قالب‌بندی PowerPoint. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌ریزی‌شده به‌جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#setContourWidth) | خطوط مرزی دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه واقعی به‌نظر برسد به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است برآمدگی را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانا شدن سطوح و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌نماید، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید بر روی سطح جلوی آن](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنجرهٔ 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z معادل چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![قاب چرخش سه‌بعدی PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق قالب‌بندی سه‌بعدی بازگشت‌یافته توسط `shape.getThreeDFormat()` تنظیم کنید:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

هنگامی که نیاز دارید نحوهٔ دیدن شیء توسط مشاهده‌کننده را تغییر دهید از دوربین استفاده کنید. این تنظیم هندسهٔ دو‑بعدی شکل را روی اسلاید تغییر نمی‌دهد؛ فقط نقطهٔ مشاهدهٔ سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن برآمدگی و عمق**

برآمدگی یک شکل را با گسترش به پشت سطح جلویی ضخیم می‌کند. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ سمت‌های برآمده را تعیین می‌کند.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی نگاشته شده‌اند](img_02_02.png)

ارتفاع برآمدگی را برای ضخامت و رنگ برآمدگی را برای رنگ سمت‌ها تنظیم کنید:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

از تنظیم عمق زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint دارید یا می‌خواهید عمق را همراه با لبه، ماده و اثرات متنی ترکیب کنید. در بسیاری از سناریوهای شکل، ارتفاع برآمدگی واضح‌تر است زیرا به‌صورت مستقیم ضخامت قابل رؤیت را بیان می‌کند.

## **استفاده از پرکن‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکن تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

این مثال یک پرکن گرادیان را به شکل اعمال می‌کند و رنگ برآمدگی تاریک‌تری برای سمت‌ها تعیین می‌نماید:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکن گرادیان آبی به نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکن شکل اختصاص دهید:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌صورت سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکن تصویر بر روی سطح جلوی آن و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل به بدنهٔ شکل تعلق دارد. قالب‌بندی سه‌بعدی متن به قاب متن تعلق دارد. این ویژگی برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکن الگو ایجاد می‌کند، یک تبدیل WordArt اعمال می‌نماید و تنظیمات سه‌بعدی را بر روی [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` پیکربندی می‌کند:

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

متن به‌صورت حروف منحنی و برآمدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوس‌دار، پرکن الگوی نارنجی، و برآمدگی تیره](img_02_05.png)

## **رفتار صادرات و رندر**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت پیکسل یا رسم شده در خروجی به‌عنوان نتیجهٔ دو‑بعدی قرار می‌گیرد. این رفتار هنگام رندر اسلایدها به [PNG](/slides/fa/nodejs-java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدیو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) اعمال می‌شود.

نکات مهم:

- تصاویر و PDF‌های صادرشده تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نورگیر، ماده، برآمدگی، پرکن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده از ارث‌بری یا تم دارید، مستندات [ویژگی‌های مؤثر شکل](/slides/fa/nodejs-java/shape-effective-properties/) را مطالعه کنید.
- برخی از فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی PowerPoint قابل ویرایش را ذخیره کنند. در این فرمت‌ها، نتیجهٔ بصری به‌صورت رندر شده ذخیره می‌شود نه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**  
Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصویرها، PDF‌ها یا صفحات HTML را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که فرمت آن را پشتیبانی می‌کند، قابل ویرایش باقی می‌ماند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**  
یک مدل سه‌بعدی شیء مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه‌زنی، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**  
حداقل باید چرخش دوربین و یا برآمدگی یا عمق را تنظیم کنید. در عمل، همچنین تنظیم نورگیر و ماده توصیه می‌شود تا سطوح رندر شده نقاط روشن و سایه واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر اشکال و هم بر متن اعمال کنم؟**  
بله. برای بدنهٔ شکل از [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` و برای متن از [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**  
بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدیو رندر می‌کند. خروجی صادر شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**  
بله. از API‌های قالب‌بندی مؤثر توضیح داده‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/nodejs-java/shape-effective-properties/) برای خواندن مقادیر نهایی دوربین، نورگیر، لبه و سایر مقادیر سه‌بعدی استفاده کنید.