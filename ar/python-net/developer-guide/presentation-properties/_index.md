---
title: إدارة خصائص العروض التقديمية باستخدام بايثون
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/python-net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مضمنة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تحكم في خصائص العروض التقديمية في Aspose.Slides للبايثون عبر .NET وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint الخاصة بك."
---

## **حول خصائص العرض التقديمي**

كما وصفنا سابقًا أن Aspose.Slides for Python عبر .NET يدعم نوعين من خصائص المستند، وهما الخصائص **المضمنة** و **المخصصة**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides for Python عبر .NET. توفر Aspose.Slides for Python عبر .NET فئة [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي من خلال الخاصية [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . يمكن للمطورين استخدام الخاصية [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) التي ي exposeها كائن **Presentation** للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

{{% alert color="primary" %}} 
يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقول **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Python عبر .NET x.x.x ستُعرض في هذه الحقول.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص بتخزين معلومات مفيدة جنبًا إلى جنب مع المستندات (ملفات العرض التقديمي). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة بالنظام (المضمنة)
- خصائص معرفة من قبل المستخدم (المخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يحددها المستخدمون كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Python عبر .NET، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وتعديلها وكذلك الخصائص المخصصة. يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يسمح لك بإدارة خصائص المستند لملف PowerPoint. في **حوار الخصائص**، يمكنك رؤية العديد من الصفحات مثل **General, Summary, Statistics, Contents and Custom**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام علامة تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المضمنة**
تتضمن هذه الخصائص التي ي exposeها كائن **IDocumentProperties** ما يلي: **Creator(Author)**، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخيرة)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل تم مشاركته بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation التي تمثل العرض التقديمي
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # إنشاء مرجع إلى الكائن المرتبط بالعرض التقديمي
    documentProperties = pres.document_properties

    # عرض الخصائص المضمنة
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


## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العرض التقديمي سهل بنفس قدر سهولة الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية ترغب فيها ستتم تعديل قيمة الخاصية. في المثال الموضح أدناه، قد أبرزنا كيفية تعديل خصائص المستند المضمنة لملف العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation التي تمثل العرض التقديمي
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # إنشاء مرجع إلى الكائن المرتبط بالعرض التقديمي
    documentProperties = presentation.document_properties

    # تعيين الخصائص المضمنة
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # حفظ العرض التقديمي إلى ملف
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة خصائص عرض تقديمي مخصصة**

تتيح Aspose.Slides for Python عبر .NET أيضًا للمطورين إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يتم إعطاء مثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعرض تقديمي.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation
with slides.Presentation() as presentation:
    # الحصول على خصائص المستند
    documentProperties = presentation.document_properties

    # إضافة خصائص مخصصة
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # الحصول على اسم الخاصية عند الفهرس المحدد
    getPropertyName = documentProperties.get_custom_property_name(2)

    # إزالة الخاصية المحددة
    documentProperties.remove_custom_property(getPropertyName)

    # حفظ العرض التقديمي
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الوصول إلى وتعديل الخصائص المخصصة**

تتيح Aspose.Slides for Python عبر .NET أيضًا للمطورين الوصول إلى قيم الخصائص المخصصة. يتم إعطاء مثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # إنشاء مرجع إلى كائن document_properties المرتبط بالعرض التقديمي
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

توفر Aspose.Slides الخاصية `Language_Id` (المعروضة عبر الفئة [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض لك هذا الكود Python كيفية تعيين لغة التدقيق لملف PowerPoint:
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

يعرض لك هذا الكود Python كيفية تعيين اللغة الافتراضية لعرض تقديمي كامل في PowerPoint:
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


## **مثال مباشر**

جرّب تطبيق الويب [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) للرؤية كيفية التعامل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**كيف يمكنني إزالة خاصية مضمنة من عرض تقديمي؟**

الخصائص المضمنة هي جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل باستخدام طريقة [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) من الفئة [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). ثم استخدم طريقة [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) المقدمة من الفئة [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.