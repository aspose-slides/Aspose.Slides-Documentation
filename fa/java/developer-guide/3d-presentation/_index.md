---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از Java
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/java/3d-presentation/
keywords:
- PowerPoint 3D
- ارائه 3D
- چرخش 3D
- عمق 3D
- استخراج 3D
- گرادیانت 3D
- متن 3D
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "اعمال و رندر افکت‌های 3D برای اشکال و متن PowerPoint در Java با Aspose.Slides. پیکربندی دوربین، نورپردازی، مواد، استخراج، پرکن‌ها و متن 3D."
---
## **نمای کلی**

Aspose.Slides for Java می‌تواند قالب‌بندی ۳D مشابه PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های ۳D شامل چرخش، استخراج (extrusion)، bevel‌ها، نورپردازی، مواد، پرکن‌های گرادیانت یا تصویر و متن ۳D می‌پردازد.

{{% alert color="primary" %}}
این مقاله درباره افکت‌های فرمت‌بندی ۳D در اشکال و متن PowerPoint است. این درباره افزودن یا ویرایش فایل‌های مدل ۳D مستقل نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این افکت‌های ۳D را در خروجی ۲D رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی ۳D**

از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/).`getThreeDFormat()` برای اعمال فرمت‌بندی ۳D به یک شکل استفاده کنید. شیء فرمت برگردانده‌شده صحنهٔ ۳D آن شکل را کنترل می‌کند.

برای متن، از [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` استفاده کنید. این به جای بدنهٔ شکل، فرمت‌بندی ۳D را به قاب متن اعمال می‌کند.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | چه زمان استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطه‌نظر، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضا‌ی ۳D یا تطبیق با پیش‌تنظیم چرخش ۳D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر برجستگی‌ها و سایه‌ها روی سطح ۳D. |
| [getMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مواد سطحی مانند صاف، مات، پلاستیک یا فلز. | باعث می‌شود همان شکل هندسی صاف‌تر، نرم‌تر، براق یا فلزی به نظر برسد. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | میزان گسترش شکل به سمت عقب از سطح جلویی آن. | تبدیل یک شکل صاف به شیء ۳D واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ سمت‌های استخراج‌شده. | عمق را قابل مشاهده می‌کند یا رنگ سمت‌ها را با پرکن جلویی هماهنگ می‌سازد. |
| [getDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ۳D اضافی مورد استفاده در فرمت‌بندی ۳D PowerPoint. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با bevel و تنظیمات مواد. |
| [getBevelTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های بالایی یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خطوط دور شیء ۳D. | برجسته‌سازی مرز شیء در خروجی رندردار. |

## **ایجاد یک شکل ۳D**

یک شکل معمولاً قبل از اینکه به‌ظاهر واقعی ۳D باشد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است استخراج را پنهان کند.  
- تنظیمات نور، زیرا نورپردازی باعث خوانایی سطوح و طرف‌ها می‌شود.  
- تنظیمات مواد، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.  
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، فرمت‌بندی ۳D را اعمال می‌نماید، ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

تصویر رندردار اسلاید، مستطیل را به‌عنوان یک بلوک ضخیم ۳D نشان می‌دهد:

![مستطیل آبی ۳D رندر شده با متن سفید ۳D روی وجه جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش ۳D از طریق پانل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z به چرخشی که از طریق API دوربین تنظیم می‌کنید، متناظر هستند.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق فرمت ۳D برگردانده‌شده توسط `shape.getThreeDFormat()` تنظیم کنید:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ نمایش شیء توسط بیننده را تغییر دهید. این تنظیمات هندسهٔ ۲D شکل را در اسلاید تغییر نمی‌دهند؛ بلکه نقطه‌نظر ۳D مورد استفاده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهند.

## **اضافه کردن Extrusion و Depth**

Extrusion باعث می‌شود یک شکل به‌صورت ضخیم ظاهر شود با گسترش به پشت سطح جلویی. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تعیین می‌کند و کنترل رنگ رنگ سمت‌های کنار را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ extrusion و ارتفاع extrusion نگاشته شده‌اند](img_02_02.png)

ارتفاع extrusion را برای ضخامت و رنگ extrusion را برای رنگ سمت‌ها تنظیم کنید:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

از تنظیم عمق زمانی استفاده کنید که بخواهید مستقیماً با مقدار عمق PowerPoint کار کنید یا عمق را همراه با bevel، material و افکت‌های متن ترکیب کنید. در بسیاری از سناریوهای شکل، ارتفاع extrusion واضح‌تر است زیرا مستقیماً ضخامت قابل مشاهده را بیان می‌کند.

## **استفاده از پرکن‌های Gradient یا Picture همراه با افکت‌های ۳D**

فرمت‌بندی ۳D مستقل از پرکن شکل است. می‌توانید یک رنگ ثابت، گرادیانت، الگو یا پرکن تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و extrusion استفاده نمایید.

این مثال یک پرکن گرادیانت به شکل اعمال می‌کند و رنگ extrusion تاریک‌تری به سمت‌ها می‌دهد:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

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

خروجی رندردار گرادیانت را بر روی سطح جلویی حفظ می‌کند و extrusion را به‌صورت جداگانه رندر می‌نماید:

![مستطیل ۳D رندر شده با پرکن گرادیانت آبی تا نارنجی و extrusion نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و به پرکن شکل اختصاص دهید:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که extrusion به‌عنوان سطح جانبی ۳D رندر می‌شود:

![مستطیل ۳D رندر شده با پرکن تصویر بر روی سطح جلو و extrusion نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی ۳D به متن**

فرمت‌بندی ۳D شکل بر بدنهٔ شکل تأثیر می‌گذارد. فرمت‌بندی ۳D متن بر قاب متن تأثیر دارد. این برای افکت‌های شبیه WordArt مفید است که حروف نیاز به extrusion، material، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکن الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات ۳D را بر [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/) پیکربندی می‌کند:

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
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
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

متن به‌صورت حروف منحنی و استخراج‌شده ۳D رندر می‌شود:

![متن ۳D رندر شده با تبدیل WordArt قوسی، پرکن الگوی نارنجی و extrusion تاریک](img_02_05.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX فرمت‌بندی ۳D را حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑طرح، صحنهٔ ۳D به‌عنوان ۲D رستریزه یا در خروجی کشیده می‌شود. این در موارد زیر اعمال می‌شود: رندر اسلایدها به [PNG](/slides/fa/java/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/java/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدئو](/slides/fa/java/convert-powerpoint-to-video/).

نکات مهم:

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از خروجی، کاربر نمی‌تواند شیء را بچرخاند.  
- ظاهر نهایی به ترکیب دوربین، نور، ماده، extrusion، پرکن و مقیاس اسلاید بستگی دارد.  
- اگر نیاز به بررسی مقادیر فرمت‌بندی ارث‌بری یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) را بخوانید.  
- برخی فرمت‌های خروجی نمی‌توانند فرمت‌بندی ۳D قابل ویرایش PowerPoint را ذخیره کنند؛ در این فرمت‌ها، نتیجه بصری رندردار می‌شود نه به‌عنوان تنظیمات ۳D قابل ویرایش.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های ۳D تعاملی ایجاد کند؟**  
Aspose.Slides افکت‌های ۳D PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحات HTML صادرشده را به صحنه‌های ۳D تعاملی تبدیل نمی‌کند که بیننده بتواند آنها را بچرخاند. در PPTX، فرمت‌بندی ۳D به‌صورت قابل ویرایش در PowerPoint باقی می‌ماند که فرمت آن را پشتیبانی می‌کند.

**تفاوت بین مدل ۳D و افکت ۳D چیست؟**  
یک مدل ۳D شیء جداگانه‌ای است که به ارائه اضافه می‌شود. افکت ۳D فرمت‌بندی‌ای است که به یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، extrusion، bevel، نورپردازی و ماده. این مقاله به افکت‌های ۳D می‌پردازد.

**کدام تنظیمات برای یک شکل ۳D قابل مشاهده ضروری هستند؟**  
حداقل باید چرخش دوربین و یا extrusion یا depth تنظیم شود. در عمل، تنظیم نور و ماده نیز جهت داشتن برجستگی‌ها و سایه‌های واضح توصیه می‌شود.

**آیا می‌توانم افکت‌های ۳D را هم به اشکال و هم به متن اعمال کنم؟**  
بله. برای بدنهٔ شکل از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/).`getThreeDFormat()` و برای متن از [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` استفاده کنید.

**آیا افکت‌های ۳D هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**  
بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئو، افکت‌های ۳D را رندر می‌کند. خروجی شامل ظاهر رندردار است، نه شیء ۳D قابل ویرایش.

**آیا می‌توانم مقادیر نهایی ۳D را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**  
بله. از API‌های فرمت مؤثر توضیح داده‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) برای خواندن دوربین نهایی، نور، bevel و مقادیر ۳D مرتبط استفاده کنید.