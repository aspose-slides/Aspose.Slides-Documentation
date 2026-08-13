---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از جاوا
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآوردگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن‌های PowerPoint در جاوا با Aspose.Slides. دوربین، نورپردازی، متریال، برآوردگی، پرکننده‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **نمای کلی**

Aspose.Slides for Java می‌تواند فرمت‌بندی سه‌بعدی شبیه PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآوردگی، لبه‌زنی، نورپردازی، متریال، پرکننده‌های گرادیان یا تصویر و متن سه‌بعدی می‌پردازد.

{{% alert color="info" %}}
این مقاله دربارهٔ اثرات فرمت‌بندی سه‌بعدی بر اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام خروجی‌گیری یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی سه‌بعدی**

از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/).`getThreeDFormat()` برای اعمال فرمت‌بندی سه‌بعدی به یک شکل استفاده کنید. شیء فرمت بازگشتی صحنه سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` استفاده کنید. این متد فرمت‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

عضوهای مهم API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | چه زمانی استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطه‌نظر، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر نورهای برجسته و سایه‌ها بر سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | متریال سطح، مانند صاف، مات، پلاستیک یا فلز. | ساختن همان هندسه به‌صورت صاف‌تر، نرم‌تر، براق یا فلزی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | چقدر شکل از سطح جلوی خود به‌پشت کشیده می‌شود. | تغییر یک شکل صاف به یک شیء سه‌بعدی با ضخامت قابل‌مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ طرف‌های برآوردگی‌شده. | قالب عمق را قابل‌مشاهده کنید یا رنگ طرف‌ها را با پرکننده جلوی هم‌ساز کنید. |
| [getDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافه‌ای که توسط فرمت‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه‌زنی و متریال. |
| [getBevelTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده در سطوح جلویی و پشتی. | اضافه‌کردن لبه‌ای نرم یا قالب شده به‌جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خط بیرونی اطراف شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌ظاهر واقعی سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است برآوردگی را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل‌خواندن شدن سطوح و طرف‌ها می‌شود.
- تنظیمات متریال، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برآوردگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلو اضافه می‌نماید، فرمت‌بندی سه‌بعدی اعمال می‌کند، ارائه را به شکل PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

تصویر رندر شدهٔ اسلاید نشان‌دهندهٔ مستطیل به‌عنوان یک بلوک سه‌بعدی ضخیم است:

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی بر روی سطح جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل چرخش سه‌بعدی پیکربندی می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش سه‌بعدی PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق فرمت سه‌بعدی بازگشتی توسط `shape.getThreeDFormat()` تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید. این کار شکل دو‌بعدی اسلاید را تغییر نمی‌دهد؛ فقط نقطه‌نظر سه‌بعدی مورد استفاده PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **اضافه کردن برآوردگی و عمق**

برآوردگی یک شکل را با گسترش دادن آن به‌پشت سطح جلو ضخیم می‌کند. در PowerPoint، کنترل عمق این ضخامت قابل‌مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌ها را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint مرتبط با ویژگی‌های رنگ برآوردگی و ارتفاع برآوردگی](img_02_02.png)

ارتفاع برآوردگی را برای ضخامت و رنگ برآوردگی را برای رنگ طرف‌ها تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

از تنظیم عمق زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint داشته باشید یا عمق را همراه با لبه‌زنی، متریال و اثرات متنی ترکیب کنید. در بسیاری از سناریوهای شکل، ارتفاع برآوردگی تنظیم واضح‌تری است زیرا مستقیماً ضخامت قابل‌مشاهده را بیان می‌کند.

## **استفاده از پرکننده‌های گرادیان یا تصویر با اثرات سه‌بعدی**

فرمت‌بندی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا تصویر را بر روی سطح جلو اعمال کنید و همچنان از همان تنظیمات دوربین، نور، متریال و برآوردگی استفاده کنید.

این مثال یک پرکنندهٔ گرادیان را بر روی شکل اعمال می‌کند و رنگ برآوردگی تیره‌تری برای طرف‌ها تنظیم می‌نماید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

خروجی رندر شده گرادیان را روی سطح جلو حفظ می‌کند و برآوردگی را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکننده گرادیان آبی به نارنجی و برآوردگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و به پرکنندهٔ شکل اختصاص دهید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

تصویر بر روی سطح جلو رندر می‌شود، در حالی که برآوردگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکننده تصویر بر روی سطح جلو و برآوردگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی سه‌بعدی بر متن**

فرمت‌بندی سه‌بعدی شکل بر بدنهٔ شکل اثر می‌کوبد. فرمت‌بندی سه‌بعدی متن بر قاب متن اثر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برآوردگی، متریال، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکنندهٔ الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/) پیکربند می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

متن به‌صورت حروف منحنی و برآوردگی‌شده سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt منحنی، پرکننده الگوی نارنجی و برآوردگی تاریک](img_02_05.png)

## **رفتار صادرات و رندر**

Aspose.Slides فرمت‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی‌گیری به فرمت‌های ثابت، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌عنوان خروجی دو‌بعدی کشیده می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/java/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل به ویدئو](/slides/fa/java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای صادر شده تعاملی نیستند. بعد از خروجی‌گیری، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، متریال، برآوردگی، پرکننده و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر فرمت‌بندی به‌دست‌آمده یا مبتنی بر تم دارید، از [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) استفاده کنید.
- برخی فرمت‌های خروجی قادر به ذخیرهٔ فرمت‌بندی سه‌بعدی قابل ویرایش PowerPoint نیستند. در این فرمت‌ها نتیجه بصری رندر می‌شود نه این که به‌عنوان تنظیمات سه‌بعدی قابل ویرایش باقی بماند.

## **سوالات متداول**

### آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDFها یا صفحات HTML صادر شده را به صحنه‌های تعاملی سه‌بعدی که کاربر بتواند بچرخاند تبدیل نمی‌کند. در فرمت PPTX، فرمت‌بندی سه‌بعدی در PowerPoint به‌صورت قابل ویرایش باقی می‌ماند در صورتی که فرمت آن را پشتیبانی کند.

### تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟

یک مدل سه‌بعدی شیء سه‌بعدی جداگانه‌ای است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی فرمت‌بندی است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآوردگی، لبه‌زنی، نورپردازی و متریال. این مقاله به اثرات سه‌بعدی می‌پردازد.

### چه تنظیماتی برای داشتن یک شکل سه‌بعدی قابل‌مشاهده لازم است؟

حداقل باید یک چرخش دوربین و یا برآوردگی/عمق تنظیم کنید. در عمل، تنظیم نورپردازی و متریال نیز ضروری است تا سطوح رندر شده برجستگی‌ها و سایه‌های واضحی داشته باشند.

### آیا می‌توانم اثرات سه‌بعدی را هم بر اشکال و هم بر متن اعمال کنم؟

بله. از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/).`getThreeDFormat()` برای بدنهٔ شکل و از [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` برای متن استفاده کنید.

### آیا اثرات سه‌بعدی هنگام خروجی به تصویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل به ویدئو، اثرات سه‌بعدی را رندر می‌کند. خروجی حاوی ظاهر رندر شده است، نه شیء سه‌بعدی قابل ویرایش.

### آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تم‌ها بخوانم؟

بله. از APIهای فرمت‌بندی مؤثر که در [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) توضیح داده شده‌اند استفاده کنید تا دوربین نهایی، نورپردازی، لبه‌زنی و مقادیر سه‌بعدی مرتبط را بخوانید.