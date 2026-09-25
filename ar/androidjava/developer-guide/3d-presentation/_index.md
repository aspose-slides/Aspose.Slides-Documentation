---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية على Android
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/androidjava/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص على Android باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمكنه إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد بنمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئة المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذا المقال يتناول تأثيرات تنسيق ثلاثية الأبعاد على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة، PDF، أو HTML، تقوم Aspose.Slides بدمج تلك التأثيرات ثلاثية الأبعاد في النتيجة الثنائية الأبعاد المصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/) الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم طريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . يطبق هذا تنسيقًا ثلاثيًا الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء الـ API هي:

| عضو API | ما يتحكم به | متى يُستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطة الرؤية، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد الإضاءة المسبق، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطيحاً، نعومة، لمعانًا أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مقدار بُعد الشكل إلى الخلف من الوجه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك يُرى بوضوح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البَثقة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق PowerPoint الثلاثي الأبعاد. | ضبط العمق بدقة للأشكال أو النص، خصوصًا مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرفوعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعشة أو مُقَوَّسة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | المخطط حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا الأبعاد بصورة مقنعة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يُخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن سطح الشكل يؤثر على كيفية عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سُمك.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق هو 100 نقطة. يُظهر المثال الشريحة كصورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية ويحفظ العرض كملف PPTX.

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

الصورة المرسومة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل أزرق ثلاثي الأبعاد مُرَسَّم مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة PowerPoint 3‑D Rotation مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، يمكنك الوصول إلى الكاميرا عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--). يُنشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أورثوغرافيًا، ويضبط دورانات X و Y و Z إلى 20 و30 و40 درجة على التوالي. يقوم بتكوين الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير كيفية رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائي الأبعاد على الشريحة؛ بل يغيّر منظور الـ 3D المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة بُثق وعمق**

البُثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السُمك الظاهر، ويتحكم التحكم في اللون في لون الجوانب.

![تحكمات عمق PowerPoint مرتبطة بلون البُثق وخصائص ارتفاع البُثق](img_02_02.png)

استخدم [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) لتحديد السُمك و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) للوصول إلى لون الجانب. يُعطي هذا المثال المستطيل بُثقًا يبلغ 100 نقطة مع جوانب بنفسجية ويُدوّر الكاميرا لإظهار سُمكه. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

طريقة [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) تُضبط عمق الشكل الثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) تتحكم في ارتفاع تأثير البُثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو متدرج، أو نمط، أو تعبئة صورة على الوجه الأمامي وتظل تستخدم نفس إعدادات الكاميرا، الإضاءة، المادة، والبُثق.

هذا المثال يطبق متدرجًا أزرق‑برتقاليًا على الوجه الأمامي ولونًا برتقاليًا داكنًا على البُثق بطول 150 نقطة. نقاط التوقف للمتدرج عند 0 و100 تمثل بداية ونهاية المتدرج. قيم دوران الكاميرا بالدرجات. تم تصيير الشريحة إلى صورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية:

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

الناتج المرسوم يحتفظ بالمتدرج على الوجه الأمامي ويصوّر البُثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة متدرجة أزرق‑برتقالي وبُثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف باسم "image.jpg" في الدليل العامل. يتم تمديد الصورة لملء المستطيل، تطبيق بُثق 150 نقطة، وضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو تصيير ملف:

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

الصورة تُعرض على الوجه الأمامي، بينما يُصوّر البُثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبُثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بُثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي يُنشئ نصًا بنمط شبكة برتقالي‑أبيض، يطبق قوسًا صاعدًا، ويُكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). ارتفاع البُثق والعمق بالنقاط، ودوران الضوء بالدرجات. يتم إخفاء تعبئة الشكل والحد لتظهر النص فقط. يُصوّر المثال صورة PNG بمقاسين مضاعفين عن أبعاد الشريحة الافتراضية ويحفظ العرض كملف PPTX:

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

النص يُصوَّر كحروف ثلاثية الأبعاد منحنية ومُبَثقة:

![نص ثلاثي الأبعاد مُصوَّر مع تحويل WordArt مقوس، تعبئة بنمط برتقالي، وبُثق داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) عبر [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيهاته ثلاثية الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد الخاص بالشكل: الكاميرا، الإضاءة، المادة، والبُثق لا تزال مُكوَّنة عبر [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). وهو مختلف أيضًا عن الدوران العادي. [IShape.setRotation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setRotation-float-) يدور الشكل في مستوى الشريحة، بينما [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) يتحكم في دوران النص داخل مربع حدوده. إبقاء النص خارج المشهد الثلاثي الأبعاد لا يعيد ضبط أي من هذين الزاويتين.

المثال المستقل التالي ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصل. كلا الشكلين لهما نفس إعدادات الثلاثي الأبعاد؛ تختلف إعدادات النص فقط: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البُثق 40 نقطة. يحفظ العرض كملف PPTX ويصوّر شريحة المقارنة إلى PNG بمقاسين مضاعفين عن الأبعاد الافتراضية.

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

على اليسار، يتبع النص توجيه الثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل للقراءة. كلا المستطيلين يحتفظان بنفس البُثق المرئي وتوجيه الثلاثي الأبعاد.

![مستطيلان ثلاثيان جنبًا إلى جنب: النص يتبع توجيه الثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد ثلاثي الأبعاد إلى صورة أو رسم في النتيجة كـ 2D. ينطبق ذلك عند تصيير الشرائح إلى [PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)، التصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، التصدير إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل الفيديو [video conversion](/slides/ar/androidjava/convert-powerpoint-to-video/).

احرص على ما يلي:

- الصور وملفات PDF المصدرة غير تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البُثق، التعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائمة على السمة، اقرأ [الخصائص الفعّالة للشكل](/slides/ar/androidjava/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

تقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا تجعل الصور المصدرة، ملفات PDF، أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint إذا كان التنسيق يدعم ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي مستقل يُدرج في العرض. تأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البُثق، الحافة، الإضاءة، والمادة. يغطى هذا المقال تأثيرات ثلاثية الأبعاد فقط.

**ما الإعدادات المطلوبة لشكل ثلاثي الأبعاد ظاهر؟**

على الأقل، عيّن دوران كاميرا وإما بُثق أو عمق. عمليًا، يُفضَّل أيضًا إعداد مجموعة إضاءة ومادة حتى تكون الوجوه المرسومة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بتصوير تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تستخدم لتحويل الفيديو. يحتوي الناتج المُصدّر على المظهر المصور، وليس كائنًا ثلاثيًا قابلاً للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموصوفة في [خصائص الشكل الفعّالة](/slides/ar/androidjava/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.