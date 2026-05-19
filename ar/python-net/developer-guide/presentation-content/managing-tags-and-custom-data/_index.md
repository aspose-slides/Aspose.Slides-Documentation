---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام Python
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/python-net/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم مزدوجة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides for Python via .NET، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint التقديمية. وتوضح بإيجاز كيف يتم تخزين البيانات في ملفات PPTX، وتلاحظ أن البيانات الخاصة بالعرض يمكن أن توجد كعلامات وأجزاء XML مخصصة، وتصف العلامات بأنها أزواج من السلاسل ذات المفتاح والقيمة.

كما تُظهر كيفية قراءة قيم العلامات وكيفية إضافة علامات إلى عرض تقديمي أو شريحة فردية أو شكل. بالإضافة إلى ذلك، تغطي المقالة مهام إدارة العلامات الشائعة مثل مسح جميع العلامات، إزالة علامة بالاسم، واسترجاع قائمة أسماء العلامات.

## **تخزين البيانات في ملفات العروض التقديمية**

تُخزن ملفات PPTX—العناصر ذات امتداد .pptx—في تنسيق PresentationML، وهو جزء من مواصفات Office Open XML. يُعرّف تنسيق Office Open XML البنية للبيانات الموجودة في العروض التقديمية.

مع اعتبار *شريحة* أحد العناصر في العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة وفق ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (الخاصة بالعرض) أو التي يضيفها المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itagcollection/)) وأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم أزواج المفتاح والسلسلة. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع خاصية IDocumentProperties.Keywords. يوضح شفرة المثال كيف تحصل على قيمة العلامة باستخدام Aspose.Slides for Python via .NET لـ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **إضافة علامات إلى العروض التقديمية**

يتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية معينة، قد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة “North American” ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يظهر شفرة المثال كيف تضيف علامة إلى [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) باستخدام Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

أو أي [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) فردي:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **القيود**

العلامات المضافة عبر مجموعة `custom_data.tags` تُخزن فقط داخل ملف PowerPoint. ولا تُنقل إلى بنية علامات PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من PDF المُوسوم.

**حل بديل**: يمكنك تخزين معرف مخصص في **نص بديل** للكائن (مثلاً، `shape.alternative_text = "MyId"`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون التجول عبر المجموعة بأكملها؟**

استخدم العملية [remove(name)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/) لحذف العلامة باستخدام مفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [get_names_of_tags](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/get_names_of_tags/) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.