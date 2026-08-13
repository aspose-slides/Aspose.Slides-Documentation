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
- بُثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص على Android باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبُثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لنظام Android عبر Java إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البُثق، الحواف المائلة، الإضاءة، المادة، التعبئة المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" %}}
هذه المقالة تتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عندما تقوم بتصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المصدر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على الشكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/) التي تتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم طريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم به | متى يتم الاستخدام |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطة العرض، نوع الكاميرا المعد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد ضوء مسبق، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإبرازات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطحة، غير لامعة، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطحًا، نعومة، لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | المسافة التي يمتد فيها الشكل إلى الخلف من واجهته الأمامية. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق 3D في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خصوصًا مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | حدود حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في المخرجات المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بأقوى صورة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البُثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البُثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى واجهته الأمامية، يطبق تنسيق ثلاثي الأبعاد، يحفظ العرض التقديمي كـ PPTX، ويعرض الشريحة كصورة PNG.

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

الصورة المعروضة للشفرة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُظهر مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides أثناء العرض.

## **إضافة بُثق وعمق**

البُثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السمك الظاهر، ويتحكم التحكم في اللون في لون الوجوه الجانبية.

![تحكمات العمق في PowerPoint مرتبطة بلون البُثق وخصائص ارتفاع البُثق](img_02_02.png)

اضبط [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) للسمك و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) للون الجوانب:

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

استخدم [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) عندما تحتاج إلى التعامل مباشرة مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في العديد من حالات الأشكال، تكون `setExtrusionHeight` الإعداد الأكثر وضوحًا لأنه يعبر مباشرة عن البُثق الظاهر.

## **استخدام تعبئة متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو متدرج، أو نمط، أو صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا، الإضاءة، المادة، والبُثق.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون بُثق أغمق للجوانب:

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

![مستطيل ثلاثي الأبعاد مُظهر مع تعبئة متدرجة من الأزرق إلى البرتقالي وبُثق بالبرتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها كعبئة الشكل:

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

![مستطيل ثلاثي الأبعاد مُظهر مع تعبئة صورة على الوجه الأمامي وبُثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

يؤثر تنسيق 3D للشكل على جسم الشكل. يؤثر تنسيق 3D للنص على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى بُثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمطية، يطبق تحويل WordArt، ويضبط إعدادات 3D على [ITextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/):

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

![نص ثلاثي الأبعاد مُظهر مع تحويل WordArt مقوس، تعبئة نمطية برتقالية، وبُثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق 3D عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عند عرض الشرائح إلى [PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)، التصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، التصدير إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، أو إنشاء إطارات للتحويل إلى [video conversion](/slides/ar/androidjava/convert-powerpoint-to-video/).

ضع في اعتبارك ما يلي:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على تركيبة الكاميرا، إضاءة اللقطة، المادة، البُثق، التعبئة، وتكبير الشريحة.
- إذا احتجت إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمات، اقرأ [effective shape properties](/slides/ar/androidjava/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق 3D القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من الحفاظ عليها كإعدادات 3D قابلة للتحرير.

## **الأسئلة الشائعة**

### هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟

إن Aspose.Slides ينشئ ويعرض تأثيرات PowerPoint ثلاثية الأبعاد للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يظل تنسيق 3D قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

### ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟

النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبّق على شكل PowerPoint عادي أو نص، مثل الدوران، البُثق، الحافة، الإضاءة، والمادة. هذا المقال يغطي التأثيرات ثلاثية الأبعاد.

### ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟

على الأقل، اضبط دوران الكاميرا وإما البُثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة اللقطة والمادة حتى تكون الوجوه المُعروضة ذات إضاءات وظلال واضحة.

### هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

### هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور، PDF، HTML، أو إطارات الفيديو؟

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم للتحويل إلى فيديو. يحتوي الناتج المُصدّر على المظهر المعروض، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

### هل يمكنني قراءة القيم النهائية لتنسيق ثلاثي الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/androidjava/shape-effective-properties/) لقراءة الكاميرا النهائية، إضاءة اللقطة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.