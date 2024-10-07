---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "إزالة شريحة, حذف شريحة, باوربوينت, عرض تقديمي, بايثون, Aspose.Slides"
description: "إزالة شريحة من باوربوينت حسب المرجع أو الفهرس في بايثون"

---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (المرجع أو الفهرس) لكائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة شريحة حسب المرجع**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تريد إزالتها من خلال معرفها أو فهرسها.
1. إزالة الشريحة المرجعية من العرض التقديمي.
1. حفظ العرض التقديمي المعدل.

تظهر لك هذه الشيفرة بلغة بايثون كيفية إزالة شريحة من خلال مرجعها:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # يصل إلى شريحة من خلال فهرسها في مجموعة الشرائح
    slide = pres.slides[0]

    # يزيل شريحة من خلال مرجعها
    pres.slides.remove(slide)

    # يحفظ العرض التقديمي المعدل
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شريحة حسب الفهرس**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إزالة الشريحة من العرض التقديمي من خلال موضع فهرسها.
1. حفظ العرض التقديمي المعدل.

تظهر لك هذه الشيفرة بلغة بايثون كيفية إزالة شريحة من خلال فهرسها:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # يزيل شريحة من خلال فهرسها
    pres.slides.remove_at(0)

    # يحفظ العرض التقديمي المعدل
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شريحة تخطيط غير مستخدمة**

توفر Aspose.Slides طريقة `remove_unused_layout_slides(pres)` (من فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح التخطيطية غير المرغوب فيها وغير المستخدمة. توضح لك هذه الشيفرة بلغة بايثون كيفية إزالة شريحة تخطيطية من عرض تقديمي باوربوينت:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شريحة ماستر غير مستخدمة**

توفر Aspose.Slides طريقة `remove_unused_master_slides(pres)` (من فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوب فيها وغير المستخدمة. توضح لك هذه الشيفرة بلغة بايثون كيفية إزالة شريحة ماستر من عرض تقديمي باوربوينت:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```