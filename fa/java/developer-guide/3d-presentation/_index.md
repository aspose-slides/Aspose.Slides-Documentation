---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از Java
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/java/3d-presentation/
keywords:
- پاورپوینت سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متن‌های PowerPoint در Java با Aspose.Slides. دوربین، نورپردازی، ماده، برآمدگی، پرکنش‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **مرور کلی**

Aspose.Slides برای Java می‌تواند فرمت‌بندی‌های سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و ارائه دهد. این مقاله به افکت‌های سه‌بعدی مانند چرخش، برآمدگی، لبه‌دارها، نورپردازی، ماده، پرکنش‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله در مورد افکت‌های فرمت‌بندی سه‌بعدی روی اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام صادرات یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این افکت‌های سه‌بعدی را به خروجی دو‌بعدی صادراتی رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی سه‌بعدی**

از روش [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getThreeDFormat--) برای اعمال فرمت‌بندی سه‌بعدی به یک شکل استفاده کنید. این روش شیء [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از روش [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این روش فرمت‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | آن چه را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطه‌نظر، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخاندن شی در فضای سه‌بعدی یا تطبیق با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش نورهای برجسته و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلز. | جعل ظاهر شبیه به صاف‌تر، نرم‌تر، براق یا فلزی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | میزان برآمدگی شکل از سطح جلویی. | تبدیل یک شکل صاف به یک شیء سه‌بعدی قابل مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ طرف‌های برآمده. | نمایان کردن عمق یا هماهنگ‌سازی رنگ طرف‌ها با پرکنش جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافه‌شده توسط فرمت‌بندی PowerPoint. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده روی سطوح جلو و پشت. | افزودن لبهٔ نرم یا قالب‌گیری به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خط دور شیء سه‌بعدی. | تأکید بر مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌صورت قابل قبول سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلو ممکن است برآمدگی را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل مشاهده شدن وجوه و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تاثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند و فرمت‌بندی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه است و ارتفاع برآمدگی ۱۰۰ پوینت می‌باشد. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید.

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

تصویر رندر شده اسلاید مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنجرهٔ 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تنظیم می‌کنید مطابقت دارد.

![پنجرهٔ 3‑D Rotation در PowerPoint با مقدارهای چرخش X، Y و Z مشخص شده](img_02_01.png)

در Aspose.Slides، از طریق [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getCamera--) به دوربین دسترسی پیدا می‌کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلویی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌نماید. این تنظیمات شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره شود:

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

از دوربین زمانی استفاده کنید که نیاز به تغییر نحوهٔ مشاهدهٔ شیء توسط بیننده دارید. این کار هندسهٔ دو‌بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ فقط نقطه‌نظر سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

## **افزودن برآمدگی و عمق**

برآمدگی یک شکل را با گسترش آن به پشت سطح جلویی ضخیم می‌سازد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های جانبی را تعیین می‌نماید.

![کنترل‌های عمق در PowerPoint به رنگ برآمدگی و ویژگی‌های ارتفاع برآمدگی مرتبط شده‌اند](img_02_02.png)

از [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) برای تنظیم ضخامت و از [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال به یک مستطیل برآمدگی ۱۰۰ پوینتی با طرف‌های بنفش می‌دهد و دوربین را برای نشان دادن ضخامت می‌چرخاند. این تنظیمات شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

متد [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setDepth-double-) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ارتفاع اثر برآمدگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکنش‌های گرادیان یا تصویر با افکت‌های سه‌بعدی**

فرمت‌بندی سه‌بعدی مستقل از پرکنش شکل است. می‌توانید رنگ ثابت، گرادیان، الگو یا پرکنش تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی بر سطح جلویی اعمال می‌کند و به برآمدگی ۱۵۰ پوینتی رنگ نارنجی تیره می‌دهد. نقاط توقف گرادیان در ۰ و ۱۰۰ شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

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

![مستطیل سه‌بعدی رندر شده با پرکنش گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکنش تصویر، تصویر را به ارائه اضافه کنید و به پرکنش شکل اختصاص دهید. این مثال به فایلی به نام "image.jpg" در پوشهٔ کاری نیاز دارد. تصویر را به‌طوری کش می‌کند که مستطیل را پر کند، برآمدگی ۱۵۰ پوینتی اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. این تنظیمات شکل را در حافظه پیکربندی می‌کند بدون ذخیره یا رندر فایل:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![مستطیل سه‌بعدی رندر شده با پرکنش عکس بر روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی سه‌بعدی بر متن**

فرمت‌بندی سه‌بعدی شکل بر بدنهٔ شکل اثر می‌گذارد. فرمت‌بندی سه‌بعدی متن بر قاب متن اثر می‌کند. این برای افکت‌های شبیه به WordArt مفید است که حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑و‑سفید ایجاد می‌کند، یک قوس بالایی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) پیکربندی می‌نماید. ارتفاع برآمدگی و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه است. پرکنش و خطوط مرزی شکل پنهان هستند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید:

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

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکنش الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **حفظ متن به‌صورت صاف بر روی یک شکل سه‌بعدی**

برای حفظ خوانایی متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) از طریق [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getTextFrameFormat--) صدا بزنید. زمانی که مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی باقی می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم فرمت‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برآمدگی آن همچنان از طریق [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getThreeDFormat--) پیکربندی شده‌اند. همچنین متفاوت از چرخش معمولی است. [IShape.setRotation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setRotation-float-) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) چرخش سفارشی متن را در داخل جعبهٔ محدودش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال زیر که به‌صورت خود‌کفایت است، یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار نسخهٔ اصلی کلون می‌نماید. هر دو شکل همان فرمت‌بندی سه‌بعدی را دارند؛ تنها تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع برآمدگی ۴۰ پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌نماید.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان برآمدگی قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ جهت‌گیری سه‌بعدی را دنبال می‌کند و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides فرمت‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌عنوان خروجی دو‌بعدی رسم می‌شود. این برای رندر اسلایدها به [PNG](/slides/fa/java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدئو](/slides/fa/java/convert-powerpoint-to-video/) نیز صادق است.

نکات مهم:

- تصاویر و PDFهای صادراتی تعاملی نیستند. پس از صادرات شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، برآمدگی، پرکنش و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر فرمت‌بندی ارث‌بری یا مبتنی بر تم دارید، از [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) استفاده کنید.
- برخی فرمت‌های خروجی نمی‌توانند فرمت‌بندی سه‌بعدی PowerPoint را به‌صورت قابل ویرایش ذخیره کنند؛ در این قالب‌ها نتیجه بصری رندر می‌شود نه به عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های تعاملی سه‌بعدی ایجاد کند؟**

Aspose.Slides افکت‌های سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحات HTML صادرشده را به صحنه‌های تعاملی سه‌بعدی که بیننده می‌تواند آن‌ها را بچرخاند، تبدیل نمی‌کند. در PPTX، فرمت‌بندی سه‌بعدی در PowerPoint به‌صورت ویرایشی باقی می‌ماند در صورتی که فرمت آن را پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و افکت سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی مستقل است که به ارائه اضافه می‌شود. یک افکت سه‌بعدی فرمت‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه، نورپردازی و ماده. این مقاله به افکت‌های سه‌بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم شود. در عمل، تنظیم نور و ماده نیز توصیه می‌شود تا وجوه رندر شده نکات روشنایی و سایه واضح داشته باشند.

**آیا می‌توانم افکت‌های سه‌بعدی را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getThreeDFormat--) و برای متن از [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید.

**آیا افکت‌های سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدئو رندر می‌کند. خروجی صادرات‌شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای فرمت‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) برای خواندن دوربین نهایی، نور، لبه و سایر مقادیر سه‌بعدی استفاده کنید.