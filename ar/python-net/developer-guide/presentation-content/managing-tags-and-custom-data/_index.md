---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
keywords: "العلامات، البيانات المخصصة، قيمة العلامات، إضافة علامات، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة علامات وبيانات مخصصة إلى عروض PowerPoint في بايثون"
---

## تخزين البيانات في ملفات العروض التقديمية

تُخزن ملفات PPTX - العناصر التي تحمل امتداد .pptx - بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML الهيكلية للبيانات الموجودة في العروض التقديمية.

مع كون *الشريحة* واحدة من العناصر في العروض التقديمية، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء - مثل العلامات المعرفة من قبل المستخدم - المحددة بواسطة ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (المحددة لعروض تقديمية معينة) أو المستخدمين كعلامات ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

العلامات هي بشكل أساسي قيم أزواج مفتاح نصي.

{{% /alert %}} 

## الحصول على قيم العلامات

في الشرائح، تت correspond العلامة إلى خاصية IDocumentProperties.Keywords. يُظهر لك هذا الكود النموذجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ بايثون عبر .NET لـ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## إضافة علامات إلى العروض التقديمية

يسمح لك Aspose.Slides بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم خاصية مخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية محددة، يمكنك الاستفادة من إضافة علامات إلى تلك العروض التقديمية. على سبيل المثال، إذا كنت تريد تصنيف جميع العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكية شمالية ثم تعيين البلدان ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

هذا الكود النموذجي يظهر لك كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) باستخدام Aspose.Slides لـ بايثون عبر .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

أو أي [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) فردية:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "نصي"
    shape.custom_data.tags.add("tag", "value")
```