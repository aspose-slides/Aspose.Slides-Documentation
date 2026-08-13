---
title: ایجاد افکت‌های 3D در ارائه‌ها بر روی اندروید
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- ارائه 3D
- چرخش 3D
- عمق 3D
- بیرون‌زدن 3D
- گرادیان 3D
- متن 3D
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اعمال و رندر افکت‌های 3D برای اشکال و متن PowerPoint در اندروید با Aspose.Slides. دوربین، نورپردازی، ماده، بیرون‌زدن، پرکردن‌ها و متن 3D را پیکربندی کنید."
---
## **نمای کلی**

Aspose.Slides برای Android از طریق Java می‌تواند قالب‌بندی سه‌بعدی سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، بیرون‌زدن، برجسته‌سازی، نورپردازی، ماده، پرکردن‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی روی اشکال و متن‌های PowerPoint است. دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‑بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این متد یک شیء [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید. این متد قالب‌بندی سه‌بعدی را بر روی قاب متن اعمال می‌کند نه بر روی بدنهٔ شکل.

اعضای مهم API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | کی از آن استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطهٔ دید، نوع دوربین پیش‌تنظیم شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش هایلایت‌ها و سایه‌ها بر سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | جنس سطح، مانند صاف، مات، پلاستیک یا فلز. | جهت دادن ظاهر صاف‌تر، نرم‌تر، براق یا فلزی به همان شکل هندسی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مقدار فاصله‌ای که شکل از سطح جلوی خود به سمت عقب امتداد می‌یابد. | تبدیل یک شکل صاف به یک شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | رنگ طرف‌های بیرون‌زدنی. | نمایان ساختن عمق یا هماهنگ‌کردن رنگ طرف‌ها با پرکردن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق سه‌بعدی اضافی که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات برجسته‌سازی و مواد. |
| [getBevelTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای یک سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | خط مرزی اطراف شیء سه‌بعدی. | تقویت مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای اینکه به‌نظر برسد واقعا سه‌بعدی باشد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است بیرون‌زدن را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث مشاهده واضح سطوح و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح تأثیر می‌گذارد که نور چگونه رندر شود.
- تنظیمات بیرون‌زدن یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

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

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.



![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی روی سطح جلویی](img_01_01.png)

## **چرخش یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تعیین می‌کنید مطابقت دارند.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getCamera--) تنظیم کنید:

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

از دوربین وقتی نیاز دارید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید استفاده کنید. این کار هندسهٔ شکل دو‑بعدی روی اسلاید را تغییر نمی‌دهد. بلکه نقطهٔ دید سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

## **افزودن بیرون‌زدن و عمق**

بیرون‌زدن باعث می‌شود شکل ضخیم به نظر برسد با گسترش آن به پشت سطح جلویی. در PowerPoint، کنترل عمق این ضخامت قابل رؤیت را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های جانبی را تعیین می‌کند.

![کنترل‌های عمق PowerPoint به ویژگی‌های رنگ بیرون‌زدن و ارتفاع بیرون‌زدن نگاشت شده‌اند](img_02_02.png)

برای ضخامت، [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) و برای رنگ طرف‌ها، [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) را تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

زمانی که نیاز دارید مستقیماً با مقدار عمق PowerPoint کار کنید یا عمق را با برجسته‌سازی، ماده و اثرات متن ترکیب کنید، از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) استفاده کنید. در بسیاری از موارد شکل، `setExtrusionHeight` تنظیم واضح‌تری است زیرا به طور مستقیم بیرون‌زدن قابل مشاهده را بیان می‌کند.

## **استفاده از پرکردن گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکردن تصویر را بر روی سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و بیرون‌زدن استفاده کنید.

این مثال یک پرکردن گرادیانی را به شکل اعمال می‌کند و رنگ بیرون‌زدن تیره‌تری به طرف‌ها می‌دهد:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و بیرون‌زدن را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکردن گرادیان آبی‑به‑نارنجی و بیرون‌زدن نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویر، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![مستطیل سه‌بعدی رندر شده با پرکردن عکسی روی سطح جلویی و بیرون‌زدن نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای افکت‌های مشابه WordArt مفید است که در آن حروف خود نیاز به بیرون‌زدن، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکردن الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/) پیکربندی می‌نماید:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
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

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکردن الگوی نارنجی و بیرون‌زدن تیره](img_02_05.png)

## **رفتار خروجی و رندر**

Aspose.Slides هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX قالب‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های با چیدمان ثابت، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌عنوان نتیجهٔ دو‑بعدی در خروجی رسم می‌شود. این موضوع زمانی اعمال می‌شود که اسلایدها را به [PNG](/slides/fa/androidjava/convert-powerpoint-to-png/) رندر می‌کنید، به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) خروجی می‌دهید، به [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/) خروجی می‌دهید، یا فریم‌ها را برای [تبدیل ویدئو](/slides/fa/androidjava/convert-powerpoint-to-video/) تولید می‌کنید.

- تصاویر و PDF های خروجی تعاملی نیستند. پس از خروجی، شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نورrig، ماده، بیرون‌زدن، پرکردن و مقیاس‌بندی اسلاید بستگی دارد.
- اگر نیاز به بازرسی مقادیر قالب‌بندی به‌دست آمده یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) را بخوانید.
- برخی از فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه اینکه به عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

### آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی را به صحنه‌های سه‌بعدی تعاملی که بیننده می‌تواند آن‌ها را چرخاند، تبدیل نمی‌کند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که فرمت آن را پشتیبانی می‌کند، قابل ویرایش می‌ماند.

### تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی است که به یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، بیرون‌زدن، برجسته‌سازی، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

### کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده لازم است؟

حداقل، یک چرخش دوربین و یا بیرون‌زدن یا عمق را تنظیم کنید. در عمل، همچنین یک نورrig و ماده تنظیم کنید تا سطوح رندر شده دارای هایلایت‌ها و سایه‌های واضح باشند.

### آیا می‌توانم اثرات سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟

بله. برای بدنهٔ شکل از [IShape.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) و برای متن از [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) استفاده کنید.

### آیا اثرات سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئویی، اثرات سه‌بعدی را رندر می‌کند. خروجی صادر شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

### آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟

بله. از APIهای قالب‌بندی مؤثر که در [ویژگی‌های مؤثر شکل](/slides/fa/androidjava/shape-effective-properties/) توضیح داده شده‌اند استفاده کنید تا دوربین نهایی، نورrig، برجسته‌سازی و مقادیر سه‌بعدی مرتبط را بخوانید.