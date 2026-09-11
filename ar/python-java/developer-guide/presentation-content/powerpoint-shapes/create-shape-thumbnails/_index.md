---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في Python عبر Java
linktitle: مصغرات الشكل
type: docs
weight: 70
url: /ar/python-java/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- تصيير الشكل
- تصيير الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء مصغرات شكل عالية الجودة من شرائح PowerPoint باستخدام Aspose.Slides for Python عبر Java – إنشاء وتصدير مصغرات العروض التقديمية بسهولة."
---
## **المقدمة**

يمكن استخدام Aspose.Slides for Python via Java لإنشاء ملفات عرض حيث تتطابق كل صفحة مع شريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعد Aspose.Slides for Python via Java على إنشاء صور مصغرة لأشكال الشرائح.

تشرح هذه المقالة كيفية إنشاء صور مصغرة للأشكال بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة داخل حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for Python via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) على الشريحة المشار إليها بالمقاس الافتراضي.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال يوضح كيفية إنشاء صورة مصغرة لشكل من شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي.
presentation = Presentation("Thumbnail.pptx")
try:
    # إنشاء صورة بالحجم الكامل.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **إنشاء صورة مصغرة بمعامل تكبير يحدده المستخدم**
لإنشاء صورة مصغرة لشكل شريحة باستخدام Aspose.Slides for Python via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) على الشريحة المشار إليها بأبعاد يحددها المستخدم.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال يوضح كيفية إنشاء صورة مصغرة لشكل بناءً على معامل تكبير معرف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي.
presentation = Presentation("Thumbnail.pptx")
try:
    # إنشاء صورة بمقياس عامل 2 في الاتجاهين.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تتيح طريقة إنشاء صور مصغرة للأشكال هذه للمطورين توليد صورة مصغرة داخل حدود مظهر الشكل. تُأخذ جميع تأثيرات الشكل في الاعتبار. تُقيد صورة الشكل المصغرة بالحدود الخاصة بالشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدود مظهره، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة المصغرة لشكل على الشريحة المشار إليها باستخدام حدود مظهره.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال يعتمد على الخطوات السابقة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي.
presentation = Presentation("Thumbnail.pptx")
try:
    # إنشاء صورة بالحجم الكامل.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **الحصول على الحدود البصرية الفعلية لشكل**
تصف خصائص الإطار لكائن [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)—طرق [getX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getX)، [getY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getY)، [getWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getWidth)، و[getHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getHeight)——المستطيل المخزن في نموذج العرض. قد يمتد المحتوى المُصوّر فعليًا خارج ذلك الإطار أو يشغل مستطيلًا محاذيًا مختلفًا. يمكن أن تُغيّر الدوران، والحدود، ورؤوس السهام، وتخطيط النص وتدفقه الزائد، والهندسة المولدة لـ SmartArt، وغيرها من تأثيرات التصيير المنطقة المشغولة.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getVisualBounds) لحساب تلك المنطقة المشغولة دون إنشاء صورة. تُعيد الطريقة كائن [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) بإحداثيات الشريحة. المستطيل المُعاد ليس مُقتصًا على الشريحة، لذا يمكن أن تكون إحداثياته سالبة عندما يمتد المحتوى خارج أصل الشريحة.

المثال التالي يحصل على الحدود الإطارية والبصرية ويقارنهما:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

يمكن استخدام نفس كائن [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) لمحاذاة الأشكال القريبة إلى اليسار أو اليمين أو الأعلى أو الأسفل؛ حجز مساحة كافية في تخطيط مُولَّد؛ أو كشف محتوى خارج منطقة مسموح بها. تُعد الحدود البصرية مفيدة خاصةً لـ SmartArt، ومربعات النص، والأسهم، والصور، والأشكال المدورة، ومجموعات الأشكال، حيث قد لا يمثل الإطار المُخزّن النتيجة المصوَّرة بالكامل.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getVisualBounds) عندما تحتاج إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) عندما تحتاج إلى تصيير الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapethumbnailbounds/)، يُحدد [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapethumbnailbounds/#Shape) حجم الصورة من حدود الشكل، بما في ذلك إعدادات الحد، بينما يُحدد [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapethumbnailbounds/#Appearance) حجمها من مظهر الشكل ويقيد النتيجة بحدود الشريحة. بالمقابل، تُعيد [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getVisualBounds) المستطيل المحسوب فقط ولا تقصه إلى الشريحة.

## **FAQ**

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#writeAsSvgToBytes) عن طريق حفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود Shape و Appearance عند تصيير الصورة المصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/python-java/shape-effect/) (الظلال، الوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تحديد شكل كخفي؟ هل سيظل يُصوَّر كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علم الإخفاء يؤثر على عرض الشرائح لكنه لا يمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية، والرسوم البيانية، وSmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن ممثل كـ [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. ينبغي عليك [توفير الخطوط المطلوبة](/slides/ar/python-java/custom-font/) (أو [تكوين بدائل الخطوط](/slides/ar/python-java/font-substitution/)) لتجنب السقوط إلى خطوط غير مرغوب فيها وإعادة تدفق النص.