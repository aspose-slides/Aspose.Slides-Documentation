---
title: إزالة الشرائح من العروض التقديمية في Python
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/python-java/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بإزالة الشرائح بسهولة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Python عبر Java. احصل على أمثلة شفرة واضحة وعزز سير عملك."
---
## **مقدمة**

إذا أصبحت الشريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تُضمّن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام مرجع أو فهرس لكائن [Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها. 

## **إزالة شريحة باستخدام المرجع**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
3. إزالة الشريحة المشار إليها من العرض التقديمي.
4. حفظ العرض التقديمي المعدل. 

هذا الكود بلغة Python يوضح لك كيفية إزالة شريحة عبر مرجعها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("demo.pptx")
try:
    # الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح.
    slide = presentation.getSlides().get_Item(0)

    # إزالة الشريحة عبر مرجعها.
    presentation.getSlides().remove(slide)

    # حفظ العرض التقديمي المعدل.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **إزالة شريحة باستخدام الفهرس**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إزالة الشريحة من العرض التقديمي عبر موضع فهرستها.
3. حفظ العرض التقديمي المعدل. 

هذا الكود بلغة Python يوضح لك كيفية إزالة شريحة عبر فهرسها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("demo.pptx")
try:
    # إزالة شريحة عبر فهرستها.
    presentation.getSlides().removeAt(0)

    # حفظ العرض التقديمي المعدل.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) (من الفئة [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/)) للسماح لك بحذف شرائح التخطيط غير المرغوبة وغير المستخدمة. يُظهر لك هذا الكود بلغة Python كيفية إزالة شريحة تخطيط من عرض PowerPoint:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إزالة شرائح الماستر غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedMasterSlides) (من الفئة [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوبة وغير المستخدمة. يُظهر لك هذا الكود بلغة Python كيفية إزالة شريحة ماستر من عرض PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اسئلة شائعة**

**ماذا يحدث لمؤشرات الشرائح بعد حذف شريحة؟**

بعد الحذف، تُعيد [collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) فهرستها: كل شريحة لاحقة تنتقل إلى اليسار بموقع واحد، وبالتالي تصبح أرقام الفهارس السابقة غير صالحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرّف الدائم لكل شريحة بدلاً من فهرسها.

**هل معرّف الشريحة يختلف عن فهرسها، وهل يتغيّر عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة وسيتغيّر عندما تُضاف أو تُحذف شرائح. معرّف الشريحة هو معرف دائم ولا يتغيّر عندما تُحذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة جزءًا من قسم، سيحتوي ذلك القسم ببساطة على شريحة أقل. يظل هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/python-java/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرفقة بشريحة عند حذفها؟**

[Notes](/slides/ar/python-java/presentation-notes/) و [comments](/slides/ar/python-java/presentation-comments/) مرتبطان بتلك الشريحة المحددة ويتم حذفهما معها. لا يتأثر المحتوى على الشرائح الأخرى.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/الماسترات غير المستخدمة؟**

يقوم الحذف بإزالة شرائح عادية محددة من المجموعة. بينما يزيل تنظيف التخطيطات/الماسترات غير المستخدمة شرائح التخطيط أو الماستر التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً ما يتم الحذف أولاً، ثم التنظيف.