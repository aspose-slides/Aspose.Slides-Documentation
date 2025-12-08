---
title: إدارة الوسوم والبيانات المخصصة في العروض التقديمية باستخدام بايثون
linktitle: الوسوم والبيانات المخصصة
type: docs
weight: 300
url: /ar/python-net/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- وسم
- بيانات مخصصة
- إضافة وسم
- قيم أزواج
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة الوسوم والبيانات المخصصة في Aspose.Slides for Python عبر .NET، مع أمثلة لعروض PowerPoint وOpenDocument."
---

## **تخزين البيانات في ملفات العروض التقديمية**

تُخزن ملفات PPTX — العناصر التي تحمل الامتداد .pptx — بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* أحد العناصر في العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء — مثل العلامات المعرفة من المستخدم — وفقًا لتعريف ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (المحددة لعرض تقديمي) أو المستخدم كوسوم ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) وأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}}الوسوم هي أساسًا قيم أزواج سلسلة-مفتاح.{{% /alert %}} 

## **الحصول على قيم الوسوم**

في الشرائح، يتطابق الوسم مع الخاصية IDocumentProperties.Keywords. يوضح هذا المثال كيفية الحصول على قيمة وسم باستخدام Aspose.Slides for Python عبر .NET لـ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **إضافة وسوم إلى العروض التقديمية**

Aspose.Slides تتيح لك إضافة وسوم إلى العروض التقديمية. يتكون الوسم عادةً من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة وسوم لتلك العروض. على سبيل المثال، إذا رغبت في تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء وسم لأمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يوضح هذا المثال كيفية إضافة وسم إلى [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) باستخدام Aspose.Slides for Python عبر .NET:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


يمكن أيضًا تعيين وسوم لـ [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


أو لأي شكل فردي [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع الوسوم من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرةً واحدة.

**كيف أحذف وسمًا واحدًا باستخدام اسمه دون التكرار عبر المجموعة بأكملها؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) لحذف الوسم باستخدام مفتاحه.

**كيف يمكنني استرداد القائمة الكاملة لأسماء الوسوم للتحليل أو التصفية؟**

استخدم [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) على [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); تُرجع مصفوفة تحتوي على جميع أسماء الوسوم.