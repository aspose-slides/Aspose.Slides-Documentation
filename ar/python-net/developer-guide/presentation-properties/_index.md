---
title: خصائص العرض
type: docs
weight: 70
url: /ar/python-net/presentation-properties/
keywords: "خصائص PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "خصائص عرض PowerPoint في بايثون"
---


## **مثال مباشر**
حاول [**البيانات التعريفية لـ Aspose.Slides**](https://products.aspose.app/slides/metadata) استخدام التطبيق عبر الإنترنت لرؤية كيفية العمل مع خصائص المستندات عبر واجهة برمجة تطبيقات Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **حول خصائص العرض**
كما وصفنا سابقًا، يدعم Aspose.Slides لبايثون عبر .NET نوعين من خصائص المستندات، وهما **المضمنة** و**المخصصة**. لذا، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام Aspose.Slides لبايثون عبر واجهة برمجة التطبيقات من .NET. يوفر Aspose.Slides لبايثون عبر .NET فئة [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) التي تمثل خصائص المستندات المرتبطة بملف العرض من خلال خاصية [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). يمكن للمطورين استخدام خاصية [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) المعروضة بواسطة كائن **Presentation** للوصول إلى خصائص مستندات ملفات العرض كما هو موضح أدناه:



{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم ضد حقول **Application** و**Producer**، لأن Aspose Ltd. وAspose.Slides لبايثون عبر .NET x.x.x ستظهر ضد هذه الحقول.

{{% /alert %}} 


## **إدارة خصائص العرض**
تقدم Microsoft PowerPoint ميزة إضافة بعض الخصائص إلى ملفات العرض. تسمح هذه الخصائص المفيدة بتخزين بعض المعلومات المفيدة جنبًا إلى جنب مع المستندات (ملفات العرض). هناك نوعان من خصائص المستندات على النحو التالي:

- خصائص محددة من النظام (مضمنة)
- خصائص محددة من المستخدم (مخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند، وما إلى ذلك. الخصائص **المخصصة** هي تلك التي تم تحديدها من قبل المستخدمين كـ **اسم/قيمة**، حيث يتم تحديد كل من الاسم والقيمة بواسطة المستخدم. باستخدام Aspose.Slides لبايثون عبر .NET، يمكن للمطورين الوصول إلى القيم الخاصة بالخصائص المضمنة وكذلك الخصائص المخصصة وتعديلها. تسمح Microsoft PowerPoint 2007 بإدارة خصائص المستندات لملفات العرض. كل ما عليك فعله هو النقر على أيقونة المكتب ومن ثم اختيار **إعداد | خصائص | خصائص متقدمة** من قائمة Microsoft PowerPoint 2007. بعد اختيارك لعنصر قائمة **خصائص متقدمة**، ستظهر نافذة حوار تسمح لك بإدارة خصائص المستندات لملف PowerPoint. في **نافذة خصائص**، يمكنك أن ترى أن هناك العديد من صفحات التبويب مثل **عام، ملخص، إحصائيات، محتويات ومخصص**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام علامة **مخصص** لإدارة الخصائص المخصصة لملفات PowerPoint.
## **الوصول إلى الخصائص المضمنة**
تشمل هذه الخصائص كما تعرضها كائن **IDocumentProperties**: **Creator(المؤلف)**، **الوصف**، **الكلمات المفتاحية**، **تم الإنشاء** (تاريخ الإنشاء)، **تم التعديل** (تاريخ التعديل)، **تم الطباعة** (تاريخ آخر طباعة)، **آخر تعديل بواسطة**، **الكلمات المفتاحية**، **SharedDoc** (هل تم مشاركتها بين منتجين مختلفين؟)، **PresentationFormat**، **الموضوع** و**العنوان**
```py
import aspose.slides as slides

# إنشاء مثيل لفئة العرض (Presentation) التي تمثل العرض
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # إنشاء مرجع للكائن المرتبط بالعرض 
    documentProperties = pres.document_properties

    # عرض الخصائص المضمنة
    print("الفئة : " + documentProperties.category)
    print("الحالة الحالية : " + documentProperties.content_status)
    print("تاريخ الإنشاء : " + str(documentProperties.created_time))
    print("المؤلف : " + documentProperties.author)
    print("الوصف : " + documentProperties.comments)
    print("الكلمات المفتاحية : " + documentProperties.keywords)
    print("آخر تعديل بواسطة : " + documentProperties.last_saved_by)
    print("المشرف : " + documentProperties.manager)
    print("تاريخ التعديل : " + str(documentProperties.last_saved_time))
    print("تنسيق العرض : " + documentProperties.presentation_format)
    print("تاريخ آخر طباعة : " + str(documentProperties.last_printed))
    print("هل تم المشاركة بين المنتجين : " + str(documentProperties.shared_doc))
    print("الموضوع : " + documentProperties.subject)
    print("العنوان : " + documentProperties.title)
```
## **تعديل الخصائص المضمنة**
تعديل الخصائص المضمنة لملفات العرض سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال المقدم أدناه، أوضحنا كيف يمكننا تعديل خصائص الوثيقة المضمنة لملف العرض.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة العرض التي تمثل العرض
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # إنشاء مرجع للكائن المرتبط بالعروض 
    documentProperties = presentation.document_properties

    # تعيين الخصائص المضمنة
    documentProperties.author = "Aspose.Slides لـ .NET"
    documentProperties.title = "تعديل خصائص العرض"
    documentProperties.subject = "موضوع Aspose"
    documentProperties.comments = "وصف Aspose"
    documentProperties.manager = "مدير Aspose"

    # حفظ العرض في ملف
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة خصائص عرض مخصصة**
يسمح Aspose.Slides لبايثون عبر .NET أيضًا للمطورين بإضافة القيم المخصصة لخصائص مستند العرض. المثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعروض تقديمية.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة العرض
with slides.Presentation() as presentation:
    # الحصول على خصائص المستند
    documentProperties = presentation.document_properties

    # إضافة الخصائص المخصصة
    documentProperties.set_custom_property_value("خصية مخصصة جديدة", 12)
    documentProperties.set_custom_property_value("اسمي", "مدثر")
    documentProperties.set_custom_property_value("مخصص", 124)

    # الحصول على اسم الخاصية عند فهرس معين
    getPropertyName = documentProperties.get_custom_property_name(2)

    # إزالة الخاصية المحددة
    documentProperties.remove_custom_property(getPropertyName)

    # حفظ العرض
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى وتعديل الخصائص المخصصة**
يسمح Aspose.Slides لبايثون عبر .NET أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعروض تقديمية.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة العرض التي تمثل PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # إنشاء مرجع لكائن document_properties المرتبط بالعرض
    documentProperties = presentation.document_properties

    # الوصول إلى وتعديل الخصائص المخصصة
    for i in range(documentProperties.count_of_custom_properties):
        # عرض أسماء وقيم الخصائص المخصصة
        print("اسم الخاصية المخصصة : " + documentProperties.get_custom_property_name(i))
        print("قيمة الخاصية المخصصة : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # تعديل قيم الخصائص المخصصة
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "قيمة جديدة " + str(i + 1))
    # حفظ العرض في ملف
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه**
يوفر Aspose.Slides لبايثون عبر .NET وسيلة للتحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه. المثال أدناه يوضح كيفية التحقق مما إذا كان العرض قد تم إنشاؤه أو تعديله.

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides خاصية `Language_Id` (المعروضة بواسطة فئة [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) للسماح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فحص الإملاء والنحو بها في PowerPoint.

هذا الكود بايثون يوضح لك كيفية تعيين لغة التدقيق لعرض PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # تعيين معرف لغة التدقيق
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **تعيين اللغة الافتراضية**

هذا الكود بايثون يوضح لك كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "نص جديد"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```