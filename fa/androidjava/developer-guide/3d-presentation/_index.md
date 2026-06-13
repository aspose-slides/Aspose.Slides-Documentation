---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها برای Android
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/androidjava/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برجستگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "افکت‌های سه‌بعدی برای اشکال و متن‌های PowerPoint را در Android با Aspose.Slides اعمال و رندر کنید. دوربین، نورپردازی، ماده، برجستگی، پرکننده‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **مرور کلی**

Aspose.Slides برای Android از طریق Java می‌تواند قالب‌بندی سه‌بعدی سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برجستگی، لبه‌گیری، نورپردازی، مواد، پرکننده‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی در اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از روش [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای اعمال قالب‌بندی سه‌بعاد به یک شکل استفاده کنید. این روش [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از روش [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این روش قالب‌بندی سه‌بعدی را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | چه موقع استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطهٔ دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | برای چرخش شیء در فضا یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | تنظیمات پیش‌فرض نور، جهت و چرخش نور. | تغییر ظاهر هایلایت‌ها و سایه‌ها بر سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادهٔ سطح، مثل صاف، مات، پلاستیک یا فلز. | برای ظاهر مسطح، نرم، براق یا فلزی کردن همان هندسه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | عمق پیشروی شکل به سمت عقب از سطح جلویی. | تبدیل یک شکل صاف به شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ سمت‌های برجسته‌شده. | برای نمایان‌سازی عمق یا هماهنگ کردن رنگ کناره‌ها با پرکنندهٔ جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافه‌ای که PowerPoint استفاده می‌کند. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با لبه‌گیری و تنظیمات ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به‌جای یک سطح صاف تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خط مرزی اطراف شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندره‌شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌صورت قابل قبول سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است برجستگی را مخفی کند.
- تنظیمات نور، زیرا نور باعث دیده شدن واضح سطوح و کناره‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برجستگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی اضافه می‌نماید، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصویر رندره‌شدهٔ اسلاید، مستطیل را به شکل یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل “3‑D Rotation” پیکربندی می‌شود. مقادیر چرخش X، Y و Z به چرخشی که از طریق API دوربین تنظیم می‌کنید، متناظر هستند.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) تنظیم کنید:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که نیاز به تغییر دیدن شیء توسط مشاهده‌گر دارید. این تنظیمات شکل دو‌بعدی روی اسلاید را تغییر نمی‌دهد؛ فقط نقطهٔ دید سه‌بعدی مورد استفاده PowerPoint و Aspose.Slides را هنگام رندرینگ تغییر می‌دهد.

## **افزودن برجستگی و عمق**

برجستگی یک شکل را با گسترش آن به پشت سطح جلویی ضخیم می‌کند. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تعیین می‌کند و کنترل رنگ رنگ کناره‌ها را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ برجستگی و ارتفاع برجستگی مپ می‌شوند](img_02_02.png)

برای ضخامت از [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) و برای رنگ کناره‌ها از [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) استفاده کنید:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) زمانی استفاده کنید که بخواهید مستقیماً با مقدار عمق PowerPoint کار کنید یا عمق را با لبه‌گیری، ماده و اثرات متن ترکیب نمایید. در بسیاری از سناریوهای شکل، `setExtrusionHeight` تنظیم واضح‌تری است زیرا مستقیماً برجستگی قابل مشاهده را بیان می‌کند.

## **استفاده از پرکننده گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکنندهٔ تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برجستگی استفاده کنید.

این مثال یک پرکنندهٔ گرادیان به شکل اعمال می‌کند و رنگ برجستگی را تیره‌تر می‌کند:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

خروجی رندره‌شده گرادیان را روی سطح جلویی حفظ می‌کند و برجستگی را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ گرادیان آبی‑به‑نارنجی و برجستگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکنندهٔ شکل اختصاص دهید:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که برجستگی به‌عنوان سطح کناری سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ تصویر روی سطح جلویی و برجستگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بدنهٔ شکل را تحت تأثیر قرار می‌دهد. قالب‌بندی سه‌بعدی متن فریم متن را تحت تأثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برجستگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متن را با پرکنندهٔ الگو ایجاد می‌کند، تبدیل WordArt اعمال می‌نماید و تنظیمات سه‌بعدی را روی [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/) پیکربندی می‌کند:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متن به‌صورت حروف منحنی و برجستهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکنندهٔ الگوی نارنجی و برجستگی تیره](img_02_05.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت رستر یا رسم شده به خروجی به‌عنوان نتیجهٔ دو‌بعدی تبدیل می‌شود. این امر هنگام رندر اسلایدها به [PNG](/slides/fa/androidjava/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [video conversion](/slides/fa/androidjava/convert-powerpoint-to-video/) اعمال می‌شود.

به نکات زیر توجه کنید:

- تصاویر و PDF‌های خروجی تعاملی نیستند. پس از خروجی، شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، لامپ، ماده، برجستگی، پرکننده و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده از ارث‌بری یا تم دارید، [effective shape properties](/slides/fa/androidjava/shape-effective-properties/) را بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDF یا صفحات HTML صادر شده را به صحنهٔ سه‌بعدی تعاملی که بیننده بتواند آن را چرخاند، تبدیل نمی‌کند. در PPTX، قالب‌بندی سه‌بعدی همچنان ویرایش‌پذیر در PowerPoint می‌ماند، مشروط بر این که فرمت آن را پشتیبانی کند.

**فرق بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی شیء سه‌بعدی جداگانه‌ای است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی است که بر یک شکل یا متن عادی PowerPoint اعمال می‌شود، مانند چرخش، برجستگی، لبه‌گیری، نورپردازی و ماده. این مقاله به‌طور خاص به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل رؤیت لازم است؟**

حداقل باید چرخش دوربین و یا برجستگی یا عمق را تنظیم کنید. در عمل، همچنین تنظیم لامپ و ماده توصیه می‌شود تا سطوح رندر شده واضح و دارای هایلایت و سایه باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) و برای متن از [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدئو، اثرات سه‌بعدی را رندر می‌کند. خروجی حاوی ظاهر رندر شده است، نه شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [Shape Effective Properties](/slides/fa/androidjava/shape-effective-properties/) برای خواندن دوربین نهایی، لامپ، لبه‌گیری و مقادیر سه‌بعدی مرتبط استفاده کنید.