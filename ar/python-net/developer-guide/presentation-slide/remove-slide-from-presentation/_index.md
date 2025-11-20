---
title: إزالة الشرائح من العروض التقديمية في بايثون
linktitle: إزالة الشريحة
type: docs
weight: 30
url: /ar/python-net/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "أزل الشرائح بسهولة من عروض PowerPoint وعروض OpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. احصل على أمثلة كود واضحة وحسّن سير عملك."
---

## **نظرة عامة**

إذا لم تعد الشريحة (أو محتوياتها) ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تضم [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، المستودع لجميع الشرائح في العرض التقديمي. باستخدام مرجع أو فهرس إلى كائن [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) معروف، يمكنك إزالة الشريحة المستهدفة.

## **إزالة شريحة باستخدام المرجع**

عند وجود مرجع للشفرة المستهدفة بالفعل، يمكنك إزالتها مباشرة. هذا يوفّر عمليات البحث في الفهرس ويجعل الشيفرة أقصر وأكثر وضوحًا.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع للشفرة التي تريد إزالتها باستخدام معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المعدَّل.

المثال التالي بلغة Python يزيل شريحة باستخدام المرجع:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الوصول إلى شريحة بواسطة فهرسها في مجموعة الشرائح.
    slide = presentation.slides[0]

    # إزالة الشريحة باستخدام المرجع.
    presentation.slides.remove(slide)

    # حفظ العرض التقديمي المعدَّل.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة شريحة باستخدام الفهرس**

إذا كنت تعرف موقع الشريحة في المجموعة، احذفها باستخدام فهرستها. يكون هذا مفيدًا خاصةً في الحلقات أو العمليات الجماعية حيث تكون المواقع معروفة مسبقًا.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. حذف الشريحة باستخدام فهرستها.
1. حفظ العرض التقديمي المعدَّل.

هذا المثال بلغة Python يوضح كيفية حذف شريحة باستخدام الفهرس:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # حذف الشريحة بواسطة فهرستها.
    presentation.slides.remove_at(0)

    # حفظ العرض التقديمي المعدَّل.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة شريحة تخطيط غير مستخدمة**

توفر Aspose.Slides الطريقة `remove_unused_layout_slides` في فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة. المثال التالي بلغة Python يوضح كيفية إزالة تخطيطات غير مستخدمة من عرض PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة شريحة رئيسية غير مستخدمة**

توفر Aspose.Slides الطريقة `remove_unused_master_slides` في فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لحذف الرؤوس غير المرغوب فيها وغير المستخدمة. المثال التالي بلغة Python يوضح كيفية إزالة رؤوس غير مستخدمة من عرض PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**ماذا يحدث لفهارس الشرائح بعد حذف شريحة؟**

بعد الحذف، يعيد [collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) فهرسة نفسها: كل شريحة لاحقة تتحرك بموقع واحد إلى اليسار، لذا تصبح أرقام الفهارس السابقة قديمة. إذا كنت بحاجة إلى مرجع ثابت، استخدم معرّف كل شريحة المستمر بدلاً من فهرسها.

**هل معرف الشريحة مختلف عن فهرسها، وهل يتغير عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موقع الشريحة وسيَتغيّر عندما تُضاف أو تُحذف شرائح. معرّف الشريحة هو معرف ثابت ولا يتغيّر عندما تُحذف شرائح أخرى.

**كيف يؤثر حذف الشريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، سيحتوي ذلك القسم على شريحة أقل فقط. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [remove or reorganize sections](/slides/ar/python-net/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرتبطة بشريحة عند حذفها؟**

[Notes](/slides/ar/python-net/presentation-notes/) و[comments](/slides/ar/python-net/presentation-comments/) مرتبطة بتلك الشريحة المحددة وتُحذف مع حذفها. المحتوى في الشرائح الأخرى لا يتأثر.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/الرؤوس غير المستخدمة؟**

الحذف يزيل الشرائح العادية المحددة من المجموعة. تنظيف التخطيطات/الرؤوس غير المستخدمة يزيل تخطيطات أو رؤوس لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هذان الإجراءان يُكملان بعضهما: عادةً احذف أولاً، ثم نظّف.