---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از Java
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متن PowerPoint در Java با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، استخراج، پرکنه‌ها و متن سه‌بعدی."
---
## **مروری**

Aspose.Slides for Java می‌تواند قالب‌بندی‌های سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله اثرات سه‌بعدی نظیر چرخش، استخراج، برجستگی‌ها، نورپردازی، ماده، پرکردن‌های گرادیان یا تصویر، و متن سه‌بعدی را پوشش می‌دهد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام استخراج یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو بعدی استخراج‌شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

برای اعمال قالب‌بندی سه‌بعدی به یک شکل، از روش [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) استفاده کنید. این روش یک شیء [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از روش [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این روش قالب‌بندی سه‌بعدی را به چهارچوب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | کنترل آن | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطه دید، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ ظاهر شدن برجستگی‌ها و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | ماده سطح، مانند صاف، مات، پلاستیک یا فلز. | به همان هندسه ظاهری صاف‌تر، نرم‌تر، براق یا فلزی بدهید. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مسافت انتساب شکل به سمت عقب از وجه جلویی آن. | یک شکل صاف را به یک شیء سه‌بعدی واضحاً ضخیم تبدیل کنید. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ طرف‌های استخراج‌شده. | عمق را قابل مشاهده کنید یا رنگ طرف‌ها را با پرکردن جلویی هماهنگ کنید. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافی که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | عمق را برای اشکال یا متن به‌دقت تنظیم کنید، به‌ویژه همراه با تنظیمات برجستگی و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گردیده بر روی وجوه جلو و پشت. | یک لبه نرم یا قالب‌دار اضافه کنید به‌جای یک وجه صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | حاشیهٔ دور شیء سه‌بعدی. | مرز شیء را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای اینکه به‌ظاهر به‌طور قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است استخراج را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل خواندن شدن وجوه و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تاثیر می‌گذارد.
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به وجه جلویی آن اضافه می‌کند و قالب‌بندی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع استخراج ۱۰۰ نقطه است. این مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید.

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

تصویر رندر شده اسلاید، مستطیل را به‌صورت یک بلاک ضخیم سه‌بعدی نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی وجه جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z مرتبط با چرخشی هستند که از طریق API دوربین تعیین می‌کنید.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، با استفاده از [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) به دوربین دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلویی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌نماید. این شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

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

از دوربین هنگام نیاز به تغییر نحوهٔ دیدن شیء توسط مخاطب استفاده کنید. این کار هندسهٔ شکل دو‌بعدی روی اسلاید را تغییر نمی‌دهد. بلکه دیدگاه سه‌بعدی که توسط PowerPoint و Aspose.Slides هنگام رندر استفاده می‌شود را تغییر می‌دهد.

### **کپی‌کردن جهت دوربین از یک شکل قالب**

برای تطبیق جهت یک شکل قالب، پیش‌تنظیم دوربین آن را با [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) و زاویه‌های چرخش آن را با [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) بخوانید. این مثال `template.pptx` را باز می‌کند و جهت دوربین را از اولین شکل در اولین اسلاید به شکل دوم کپی می‌کند. هر دو شکل قبلاً نورپردازی سه‌بعدی دارند و شکل دوم چرخش واضح دوربین ندارد.

زاویه‌ها بر حسب درجه هستند. اندیس `0` عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` دوران است. آنها را به ترتیب به [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) پاس دهید. اگر منبع `null` برگرداند، چرخش واضحی ندارد، بنابراین زاویه‌های شکل دوم را تنظیم نشده بگذارید. یک چرخش واضح `(0, 0, 0)` سه صفر برمی‌گرداند و باید کپی شود.

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

وقتی `camera-copy.pptx` را دوباره در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم دوربین و چرخش را دارد که مستطیل سمت چپ دارد. هر دو شکل از همان نورپردازی و عمق استخراج استفاده می‌کنند.

![یک مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین منطبق، مشاهده‌شده از بالا و سمت راست](camera-orientation.png)

## **اضافه کردن استخراج و عمق**

استخراج باعث می‌شود یک شکل ضخیم به نظر برسد با گسترش آن به پشت وجه جلویی. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ وجوه کناری را تنظیم می‌نماید.

![کنترل‌های عمق PowerPoint به ویژگی‌های رنگ استخراج و ارتفاع استخراج نگاشت شده](img_02_02.png)

از [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) برای تنظیم ضخامت و از [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال به یک مستطیل استخراج ۱۰۰ نقطه‌ای با طرف‌های بنفش می‌دهد و دوربین را می‌چرخاند تا ضخامت آن مشخص شود. این شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

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

متد [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ارتفاع اثر استخراج را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکردن گرادیان یا تصویر همراه با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید رنگ ثابت، گرادیان، الگو یا پرکردن تصویری را بر روی وجه جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و استخراج استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی را بر روی وجه جلویی اعمال می‌کند و رنگ نارنجی تیره‌ای به استخراج ۱۵۰ نقطه‌ای می‌دهد. نقاط توقف گرادیان در ۰ و ۱۰۰ شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه است. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادیان را بر روی وجه جلویی حفظ می‌کند و استخراج را به‌صورت جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی رندر شده با پرکردن گرادیان آبی‑به‑نارنجی و استخراج نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویری به‌جای آن، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید. این مثال به فایل موجودی به نام "image.jpg" در پوشهٔ کاری نیاز دارد. تصویر را برای پر کردن مستطیل کشیده می‌کند، استخراج ۱۵۰ نقطه‌ای اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون ذخیره یا رندر فایل:

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

تصویر بر روی وجه جلویی رندر می‌شود، در حالی که استخراج به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکردن عکس بر روی وجه جلویی و استخراج نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تاثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر چارچوب متن تاثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به استخراج، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑و‑سفید ایجاد می‌کند، یک قوس صعودی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) پیکربندی می‌نماید. ارتفاع استخراج و عمق بر حسب نقطه هستند و چرخش نور بر حسب درجه. پرکردن و حاشیهٔ شکل مخفی شده‌اند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید:

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

متن به‌صورت حروف منحنی و استخراج‌شدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکردن الگوی نارنجی و استخراج تاریک](img_02_05.png)

## **متن را روی شکل سه‌بعدی صاف نگه‌دارید**

برای حفظ قابلیت خواندن متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) از طریق [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) فراخوانی کنید. وقتی مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی باقی می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و استخراج آن همچنان از طریق [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) پیکربندی شده‌اند. همچنین این تنظیم متفاوت از چرخش معمولی است. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) چرخش سفارشی متن را داخل جعبهٔ محدودهٔ آن کنترل می‌کند. نگه‌داشتن متن خارج از صحنهٔ سه‌بعدی هیچ یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال خودکفی زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصل کپی می‌نماید. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع استخراج ۴۰ نقطه است. مثال ارائه را به صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آسان‌تر است. هر دو مستطیل همان استخراج قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ جهت‌گیری سه‌بعدی را دنبال می‌کند و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار خروجی و رندر**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت، صحنهٔ سه‌بعدی به‌صورت رستری یا به‌صورت تصویری دو‌بعدی در خروجی ترسیم می‌شود. این موضوع زمانی اعمال می‌شود که اسلایدها را به [PNG](/slides/fa/java/convert-powerpoint-to-png/) رندر می‌کنید، به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) خروجی می‌دهید، به [HTML](/slides/fa/java/convert-powerpoint-to-html/) خروجی می‌دهید، یا فریم‌ها را برای [video conversion](/slides/fa/java/convert-powerpoint-to-video/) تولید می‌کنید.

به نکات زیر توجه کنید:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی، شیء نمی‌تواند توسط مخاطب چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، استخراج، پرکردن و مقیاس‌بندی اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، [effective shape properties](/slides/fa/java/shape-effective-properties/) را بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه اینکه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی را به صحنه‌های سه‌بعدی تعاملی که مخاطب بتواند آنها را بچرخاند تبدیل نمی‌کند. در PPTX، قالب‌بندی سه‌بعدی همچنان قابل ویرایش در PowerPoint است زمانیکه فرمت از آن پشتیبانی می‌کند.

**تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر روی یک شکل یا متن عادی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، برجستگی، نورپردازی و ماده. این مقاله به اثرات سه‌دار

**کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده لازم است؟**

در حداقل، یک چرخش دوربین و یا استخراج یا عمق را تنظیم کنید. در عمل، همچنین یک نورپردازی و ماده تنظیم کنید تا وجوه رندر شده برجستگی‌ها و سایه‌های واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را بر هر دو شکل و متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) و برای متن از [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئو رندر می‌کند. خروجی استخراج‌شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر شرح داده شده در [Shape Effective Properties](/slides/fa/java/shape-effective-properties/) برای خواندن مقادیر نهایی دوربین، نورپردازی، برجستگی و مقادیر مرتبط سه‌بعدی استفاده کنید.