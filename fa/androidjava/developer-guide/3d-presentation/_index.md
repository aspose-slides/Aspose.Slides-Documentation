---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها بر روی Android
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن PowerPoint در Android با Aspose.Slides. دوربین، نورپردازی، ماده، استخراج، پرکنش‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Android via Java می‌تواند قالب‌بندی سه‌بعدی سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، استخراج (extrusion)، برجسته‌سازی (bevel)، نورپردازی، مواد، پرکنش گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}

این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر روی اشکال و متن در PowerPoint است. دربارهٔ وارد کردن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را در خروجی دو‑بعدی رندر می‌کند.

{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این متد یک شیء [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این متد قالب‌بندی سه‌بعدی را به فریم متن اعمال می‌کند، نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | آنچه کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطهٔنظر، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضا سه‌بعدی یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش نقاط برجسته و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مواد سطح، مانند صاف، مات، پلاستیک یا فلز. | ایجاد ظاهر کمتر حجیم، نرم‌تر، براق یا فلزی برای همان هندسه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | فاصلهٔ استخراج شکل از سطح جلویی آن. | تبدیل یک شکل صاف به شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ سمت‌های استخراج‌شده. | نمایش عمق یا هماهنگ‌سازی رنگ جانبی با پرکنش جلویی. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافه‌شده توسط قالب‌بندی PowerPoint. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات برجسته و مواد. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به‌جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خطوط پیرامون شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌نظر برسد که واقعاً سه‌بعدی است، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است استخراج را مخفی کند.
- تنظیمات نور، زیرا نورپردازی سطوح و جانبی را قابل‌مشاهده می‌کند.
- تنظیمات مواد، زیرا سطح اثر نور را تعیین می‌کند.
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل می‌سازد، متنی را به سطح جلویی آن اضافه می‌کند و قالب‌بندی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه است و ارتفاع استخراج ۱۰۰ پوینت است. این مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت بلوک ضخیم سه‌بعدی نشان می‌دهد:

![مستطیل سه‌بعدی آبی با متن سه‌بعدی سفید روی سطح جلویی](img_01_01.png)

## **چرخش یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنجرهٔ 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z به چرخشی که از طریق API دوربین تنظیم می‌کنید، متناظر است.

![پنجره 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z هایلایت‌شده](img_02_01.png)

در Aspose.Slides، دوربین را از طریق [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) دسترسی می‌یابید. این مثال یک مستطیل می‌سازد، نمای جلویی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره شود:

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

از دوربین زمانی استفاده کنید که نیاز به تغییر نحوهٔ نمایش شیء توسط بیننده دارید. این تنظیمات شکل دو‑بعدی را در اسلاید تغییر نمی‌دهد؛ تنها نقطهٔنظر سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

### **کپی‌کردن جهت دوربین از یک شکل الگو**

برای مطابقت جهت یک شکل الگو، پیش‌تنظیم دوربین آن را با [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) و زاویه‌های چرخش آن را با [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) بخوانید. مثال `template.pptx` را باز می‌کند و جهت دوربین اولین شکل در اسلاید اول را به شکل دوم کپی می‌کند. هر دو شکل دارای نور سه‌بعدی هستند و شکل دوم چرخش دوربین صریحی ندارد.

زاویه‌ها بر حسب درجه هستند. اندیس `0` عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` چرخش است. به ترتیب این مقادیر را به [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) پاس می‌دهید. اگر منبع `null` برگرداند، چرخش صریحی ندارد؛ در این صورت زاویه‌های شکل دوم تنظیم نمی‌شوند. چرخش صریح `(0, 0, 0)` سه صفر برمی‌گرداند و باید کپی شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هنگامی که `camera-copy.pptx` را در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم دوربین و چرخش را دارد که مستطیل سمت چپ دارد. هر دو شکل از یک نور و عمق استخراج استفاده می‌کنند.

![مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین مشابه، نمایش از بالا و سمت راست](camera-orientation.png)

## **افزودن استخراج و عمق**

استخراج یک شکل را به‌صورت ضخیم می‌کند با اینکه آن را پشت سطح جلویی می‌کشد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ جانبی‌ها را تعیین می‌کند.

![کنترل‌های عمق در PowerPoint به ویژگی‌های رنگ استخراج و ارتفاع استخراج نگاشت می‌شوند](img_02_02.png)

از [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) برای تنظیم ضخامت و از [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) برای دسترسی به رنگ جانبی‌ها استفاده کنید. این مثال به مستطیل ارتفاع استخراج ۱۰۰ پوینت با سمت‌های بنفش می‌دهد و دوربین را می‌چرخاند تا ضخامت آن را نشان دهد. شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

متد [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ارتفاع اثر استخراج را کنترل می‌کند، همان‌گونه که در این مثال نشان داده شده است.

## **استفاده از پرکنش گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکنش شکل است. می‌توانید یک رنگ جامد، گرادیان، الگو یا پرکنش تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و استخراج استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی را به سطح جلویی اعمال می‌کند و به استخراج ۱۵۰ پوینت رنگ نارنجی تیره می‌دهد. نقاط توقف گرادیان در ۰ و ۱۰۰ شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و استخراج را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی با پرکنش گرادیان آبی‑به‑نارنجی و استخراج نارنجی](img_02_03.png)

برای استفاده از پرکنش تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکنش شکل اختصاص دهید. این مثال به فایلی به نام `"image.jpg"` در پوشهٔ کاری نیاز دارد. تصویر را برای پر کردن مستطیل کشیده، استخراج ۱۵۰ پوینت اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون ذخیره یا رندر فایل:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

تصویر بر سطح جلویی رندر می‌شود، در حالی که استخراج به‌عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل سه‌بعدی با پرکنش عکس بر سطح جلویی و استخراج نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر فریم متن تأثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به استخراج، ماده، نور و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکهٔ نارنجی‑سفید ایجاد می‌کند، یک قوس بالایی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) پیکربندی می‌کند. ارتفاع استخراج و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکنش شکل و خط مرزی مخفی هستند تا فقط متن قابل‌مشاهده باشد. مثال تصویر PNG با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

متن به‌صورت حروف منحنی و استخراج‌شدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل قوسی WordArt، پرکنش الگوی نارنجی و استخراج تیره](img_02_05.png)

## **حفظ متن صاف بر روی یک شکل سه‌بعدی**

برای حفظ قابلیت خواندن متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) از طریق [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) استفاده کنید. وقتی مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نور، ماده و استخراج آن همچنان از طریق [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) تنظیم شده‌اند. همچنین متفاوت از چرخش معمولی است. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) شکل را در صفحه اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) چرخش سفارشی متن را درون جعبه مرزبندی‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را ریست نمی‌کند.

مثال خودمستقلی زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصل کلون می‌گیرد. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ تنها تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع استخراج ۴۰ پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

در سمت چپ، متن جهت سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواناتر است. هر دو مستطیل همان استخراج قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ جهت سه‌بعدی را دنبال می‌کند و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به قالب‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به قالب‌های ثابت، صحنهٔ سه‌بعدی به‌صورت تصویر دو‑بعدی رستر یا رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/androidjava/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدیو](/slides/fa/androidjava/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDF‌های صادرشده تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، استخراج، پرکنش و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) را بخوانید.
- برخی از قالب‌های خروجی قادر به ذخیرهٔ قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint نیستند. در این قالب‌ها، نتیجهٔ بصری رندر می‌شود نه اینکه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصویرها، PDFها یا صفحات HTML را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که از این فرمت پشتیبانی می‌کند، قابل ویرایش می‌ماند.

**تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که در ارائه وارد می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر روی یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، برجسته‌سازی، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل‌مشاهده لازم است؟**

حداقل باید چرخش دوربین و یا استخراج/عمق را تنظیم کنید. در عمل، همچنین نورپردازی و ماده را تنظیم کنید تا سطوح رندر شده نکات برجسته و سایه واضحی داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) و برای متن از [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدیو، اثرات سه‌بعدی را رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی پس از اعمال ارث‌بری و تنظیمات تم را بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، برجسته‌سازی و مقادیر سه‌بعدی مرتبط استفاده کنید.