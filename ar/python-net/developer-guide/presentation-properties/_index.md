---
title: إدارة خصائص العرض التقديمي باستخدام بايثون
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/python-net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- الخصائص المدمجة
- الخصائص المخصصة
- الخصائص المتقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بإدارة خصائص العرض التقديمي في Aspose.Slides للغة بايثون عبر .NET وتسهيل البحث والعلامة التجارية وتدفق العمل في ملفات PowerPoint الخاصة بك."
---

## **حول خصائص العرض التقديمي**

كما وصفنا سابقًا أن Aspose.Slides للغة بايثون عبر .NET يدعم نوعين من خصائص المستند، وهما الخصائص **المدمجة** والخصائص **المخصصة**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين باستخدام واجهة برمجة تطبيقات Aspose.Slides للغة بايثون عبر .NET. توفر Aspose.Slides للغة بايثون عبر .NET فئة [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي عبر خاصية [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). يمكن للمطورين استخدام خاصية [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) التي تعرضها كائن **Presentation** للوصول إلى خصائص المستند للملفات العرضية كما هو موضح أدناه:

{{% alert color="primary" %}} 
يرجى ملاحظة أنه لا يمكن تعيين قيم للحقلين **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides للغة بايثون عبر .NET x.x.x سيظهران مقابل هذين الحقلين.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يتيح Microsoft PowerPoint ميزة إضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص بتخزين معلومات مفيدة إلى جانب المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة من النظام (مدمجة)
- خصائص معرفة من المستخدم (مخصصة)

تحتوي الخصائص **المدمجة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند، وما إلى ذلك. أما الخصائص **المخصصة** فهي تلك التي يحددها المستخدم كأزواج **الاسم/القيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides للغة بايثون عبر .NET، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها. يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint. في **حوار الخصائص**، يمكنك رؤية العديد من الصفحات مثل **General, Summary, Statistics, Contents and Custom**. جميع هذه الصفحات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم صفحة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المدمجة**
تتضمن هذه الخصائص التي تعرضها كائن **IDocumentProperties** ما يلي: **Creator(Author)**، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل العرض التقديمي
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # إنشاء إشارة إلى الكائن المرتبط بالعرض التقديمي
    documentProperties = pres.document_properties

    # عرض الخصائص المدمجة
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل كما هو الحال في الوصول إليها. يمكنك ببساطة إسناد قيمة نصية إلى أي خاصية مرغوبة وستتم تعديل قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند المدمجة لملف العرض.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل العرض التقديمي
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # إنشاء إشارة إلى الكائن المرتبط بالعرض التقديمي
    documentProperties = presentation.document_properties

    # تعيين الخصائص المدمجة
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # حفظ العرض التقديمي إلى ملف
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة خصائص عرض تقديمي مخصصة**

يسمح Aspose.Slides للغة بايثون عبر .NET للمطورين أيضًا بإضافة القيم المخصصة لخصائص مستند العرض التقديمي. المثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن Presentation
with slides.Presentation() as presentation:
    # الحصول على خصائص المستند
    documentProperties = presentation.document_properties

    # إضافة خصائص مخصصة
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # الحصول على اسم الخاصية عند فهرس معين
    getPropertyName = documentProperties.get_custom_property_name(2)

    # إزالة الخاصية المحددة
    documentProperties.remove_custom_property(getPropertyName)

    # حفظ العرض التقديمي
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides للغة بايثون عبر .NET للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # إنشاء إشارة إلى كائن document_properties المرتبط بالعرض التقديمي
    documentProperties = presentation.document_properties

    # الوصول إلى الخصائص المخصصة وتعديلها
    for i in range(documentProperties.count_of_custom_properties):
        # عرض أسماء وقيم الخصائص المخصصة
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # تعديل قيم الخصائص المخصصة
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # حفظ العرض التقديمي إلى ملف
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين لغة التدقيق**

توفر Aspose.Slides خاصية `Language_Id` (المعروضة بواسطة فئة [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) لتتيح لك تعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

هذا الكود بايثون يوضح كيفية تعيين لغة التدقيق لمستند PowerPoint:

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

هذا الكود بايثون يوضح كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **مثال حي**

جرّب تطبيق **Aspose.Slides Metadata** عبر الإنترنت لرؤية كيفية التعامل مع خصائص المستند باستخدام Aspose.Slides API:

[![عرض وتحرير بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا حاجة لإزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض دون تحميله بالكامل باستخدام طريقة [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) من فئة [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). ثم استخدم طريقة [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) المقدمة من فئة [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.