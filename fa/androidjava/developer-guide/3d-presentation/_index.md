---
title: ایجاد اثرهای سه‌بعدی در ارائه‌ها در اندروید
linktitle: ارائهٔ سه‌بعدی
type: docs
weight: 232
url: /fa/androidjava/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائهٔ سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "اعمال و رندر اثرهای سه‌بعدی برای اشکال و متن PowerPoint در اندروید با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، استخراج، پرکن‌ها، و متن سه‌بعدی."
---
## **مرور کلی**

Aspose.Slides for Android via Java می‌تواند اشکال و متن را با قالب‌بندی سه‌بعدی شبیه به PowerPoint ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرهای سه‌بعدی همچون چرخش، استخراج، لبه‌گیری، نورپردازی، ماده، پرکن‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="توجه" %}}
این مقاله دربارهٔ اثرهای قالب‌بندی سه‌بعدی روی اشکال و متن PowerPoint است. دربارهٔ وارد کردن یا ویرایش فایل‌های مدل سه‌بعدی مستقل بحث نمی‌کند. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرهای سه‌بعدی را در خروجی دو‑بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از روش [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این روش یک شیٔ [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از روش [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این روش قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطهٔ مشاهده، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش برجستگی‌ها و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلز. | به همان شکل هندسی ظاهر صاف‌تر، نرم‌تر، براق یا فلزی بدهید. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | میزان پیشروی شکل به سمت عقب از سطح جلویی. | یک شکل صاف را به شیء سه‌بعدی با ضخامت قابل مشاهده تبدیل کنید. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ جانبی‌های استخراج‌شده. | عمق را قابل رؤیت کنید یا رنگ جانبی را با پرکن جلویی هماهنگ کنید. |
| [getDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافه‌شده که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | عمق را برای اشکال یا متن دقیقاً تنظیم کنید، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های بالایی یا پایین‌سوار بر سطوح جلویی و پشتی. | لبه‌ای نرم یا قالب‌دار به‌جای یک سطح صاف اضافه کنید. |
| [getContourColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خط مرزی اطراف شیء سه‌بعدی. | مرزبندی شیء را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌نظر برسد به‌صورت قانع‌کننده سه‌بعدی باشد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است استخراج را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانایی سطوح و کناره‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

کد نمونه زیر یک مستطیل ایجاد می‌کند، متنی به وجه جلویی آن اضافه می‌نماید و قالب‌بندی سه‌بعدی را اعمال می‌کند. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع استخراج ۱۰۰ پوینت است. این نمونه اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید.

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

تصویر رندر شده اسلاید، مستطیل را به‌عنوان یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی روی وجه جلویی](img_01_01.png)

## **چرخش یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش سه‌بعدی PowerPoint با مقادیر چرخش X, Y و Z مشخص شده](img_02_01.png)

در Aspose.Slides، از طریق [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) به دوربین دسترسی پیدا می‌کنید. این مثال یک مستطیل می‌سازد، نمای جلویی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون اینکه فایلی ذخیره شود:

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

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید. این تنظیمات هندسهٔ شکل دو‑بعدی را در اسلاید تغییر نمی‌دهد؛ فقط نقطهٔ مشاهدهٔ سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

## **افزودن استخراج و عمق**

استخراج باعث می‌شود یک شکل ضخیم به‌نظر برسد چون به سمت پشت وجه جلویی گسترش می‌یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ جانبی‌های استخراج شده را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ استخراج و ارتفاع استخراج نگاشته شده‌اند](img_02_02.png)

از روش [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) برای تنظیم ضخامت و از [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) برای دسترسی به رنگ جانبی‌ها استفاده کنید. این مثال به یک مستطیل استخراج ۱۰۰ پوینت با سمت‌های بنفش می‌دهد و دوربین را چرخانده تا ضخامت آن نمایان شود. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

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

روش [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) عمق یک شکل سه‌بعدی را تنظیم می‌کند. روش [setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ارتفاع اثر استخراج را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکن‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکن تصویر را به وجه جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و استخراج استفاده کنید.

این مثال گرادیان آبی‑به‑نارنجی را به وجه جلویی اعمال می‌کند و برای استخراج ۱۵۰ پوینت رنگ نارنجی تیره استفاده می‌نماید. نقاط توقف گرادیان در ۰ و ۱۰۰ شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادیان را بر روی وجه جلویی حفظ می‌کند و استخراج را جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی رندر شده با پرکن گرادیان آبی به نارنجی و استخراج نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکن شکل اختصاص دهید. این مثال فرض می‌کند فایلی به‌نام "image.jpg" در پوشهٔ کاری موجود باشد. تصویر را به‌صورت کشیده بر روی مستطیل تنظیم می‌کند، استخراج ۱۵۰ پوینت اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌نماید. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

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

تصویر بر روی وجه جلویی رندر می‌شود، در حالی که استخراج به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکن تصویر بر روی وجه جلویی و استخراج نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای اثرهای شبیه WordArt مفید است که حروف نیاز به استخراج، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی مشبک نارنجی‑سفید ایجاد می‌کند، یک قوس بالا را اعمال می‌نماید و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) پیکربندی می‌کند. ارتفاع استخراج و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکن و حاشیهٔ شکل مخفی می‌شوند تا فقط متن قابل رؤیت باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر کرده و ارائه را به‌صورت PPTX ذخیره می‌کند:

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

متن به‌صورت حروف منحنی و استخراج‌شده‌ی سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تغییر شکل کمان‌دار، پرکن الگوی نارنجی و استخراج تاریک](img_02_05.png)

## **حفظ متن صاف روی یک شکل سه‌بعدی**

برای نگه داشتن متن قابل خواندن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) از طریق [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) فراخوانی کنید. زمانی که مقدار `true` باشد، متن از صحنهٔ سه‌بعدی خارج می‌ماند. زمانی که مقدار `false` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نور، ماده و استخراج آن همچنان از طریق [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) پیکربندی شده‌اند. همچنین متفاوت از چرخش معمولی است. [IShape.setRotation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setRotation-float-) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) چرخش سفارشی متن را داخل جعبهٔ مرزی‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصلی کلون می‌نماید. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع استخراج ۴۰ پوینت است. مثال ارائه را به‌صورت PPTX ذخیره کرده و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان استخراج قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ با جهت‌گیری سه‌بعدی و در سمت راست صاف و قابل خواندن](keep_text_flat.png)

## **رفتار خروجی و رندر**

Aspose.Slides هنگام ذخیره در فرمت‌های PowerPoint مانند PPTX قالب‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑چیدمان، صحنهٔ سه‌بعدی به‌صورت دو‑بعدی در خروجی رستر یا ترسیم می‌شود. این هنگام رندر اسلایدها به [PNG](/slides/fa/androidjava/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدئو](/slides/fa/androidjava/convert-powerpoint-to-video/) اعمال می‌شود.

به نکات زیر توجه کنید:

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از خروجی، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، استخراج، پرکن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست‌آمده از ارث‌بری یا تم دارید، APIهای [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) را بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی ویرایش‌پذیر PowerPoint را ذخیره کنند. در این فرمت‌ها، نتیجهٔ بصری به‌جای حفظ تنظیمات سه‌بعدی ویرایش‌پذیر رندر می‌شود.

## **FAQ**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرهای سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML صادرشده را به صحنهٔ سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند اگر فرمت آن را پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی است که به یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، لبه‌گیری، نورپردازی و ماده. این مقاله به اثرهای سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا استخراج یا عمق را تنظیم کنید. در عمل، همچنین باید نور و ماده تنظیم شوند تا سطح رندر شده دارای برجستگی‌ها و سایه‌های واضح باشد.

**آیا می‌توانم اثرهای سه‌بعدی را هم بر روی اشکال و هم بر روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat] استفاده کنید و برای متن از [ITextFrameFormat.getThreeDFormat] استفاده کنید.

**آیا اثرهای سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرهای سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل به ویدئو رندر می‌کند. خروجی صادرشده ظاهر رندر شده را دارد، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) برای خواندن دوربین، نور، لبه و سایر مقادیر سه‌بعدی نهایی استفاده کنید.