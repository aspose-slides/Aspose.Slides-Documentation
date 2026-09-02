---
title: إدارة خصائص العرض التقديمي باستخدام Python
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/python-net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات المستند الوصفية
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for Python عبر .NET وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint الخاصة بك."
---
## **مقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام واجهة برمجة تطبيقات Aspose.Slides.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي من خلال الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/). يتم إرجاع كائن من هذه الفئة بواسطة الخاصية [Presentation.document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/document_properties/). تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقلَي **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Python via .NET x.x.x سيتم عرضهما في هذين الحقلين.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. هذه الخصائص الوثائقية تتيح تخزين بعض المعلومات المفيدة مع المستندات (ملفات العرض التقديمي). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة نظاميًا (Built-in)
- خصائص يحددها المستخدم (Custom)

تحتوي الخصائص **Built-in** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. أما الخصائص **Custom** فهي تلك التي يحددها المستخدمون على شكل أزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Python via .NET، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها. يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك فعله هو النقر على أيقونة Office ثم عنصر القائمة **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد تحديد عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint. في **Properties Dialog**، يمكنك أن ترى العديد من صفحات التبويب مثل **General, Summary, Statistics, Contents and Custom**. تسمح جميع صفحات التبويب هذه بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المدمجة**

تشمل هذه الخصائص التي يُظهرها كائن **IDocumentProperties**: **Creator(Author)**، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل تم مشاركته بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation الذي يمثل العرض التقديمي
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # إنشاء مرجع للكائن المرتبط بـ Presentation
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

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل بقدر وصولك إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية ترغب بها وسيتم تعديل قيمة الخاصية. في المثال أدناه، أظهرنا كيفية تعديل خصائص المستند المدمجة لملف العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation الذي يمثل العرض التقديمي
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # إنشاء مرجع للكائن المرتبط بـ Presentation
    documentProperties = presentation.document_properties

    # تعيين الخصائص المدمجة
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # احفظ العرض التقديمي إلى ملف
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة خصائص عرض تقديمي مخصصة**

يتيح Aspose.Slides for Python via .NET للمطورين أيضًا إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation
with slides.Presentation() as presentation:
    # الحصول على خصائص المستند
    documentProperties = presentation.document_properties

    # إضافة خصائص مخصصة
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # الحصول على اسم الخاصية عند الفهرس المحدد
    getPropertyName = documentProperties.get_custom_property_name(2)

    # إزالة الخاصية المختارة
    documentProperties.remove_custom_property(getPropertyName)

    # حفظ العرض التقديمي
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى وتعديل الخصائص المخصصة**

يتيح Aspose.Slides for Python via .NET للمطورين أيضًا الوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation الذي يمثل ملف PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # إنشاء مرجع لكائن document_properties المرتبط بالعرض التقديمي
    documentProperties = presentation.document_properties

    # الوصول إلى الخصائص المخصصة وتعديلها
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # عرض أسماء وقيم الخصائص المخصصة
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # تعديل قيم الخصائص المخصصة
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # احفظ العرض التقديمي إلى ملف
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` تُعيد القيمة عبر القائمة ذات العنصر الواحد التي تم تمريرها كوسيطها الثاني، وتتم تحويل القيمة المخزنة إلى نوع العنصر الموجود مسبقًا في تلك القائمة. يستخدم المثال أعلاه `[""]`، لذا يقرأ خصائص نصية؛ لقراءة خاصية مخزنة كعدد، مرّر عنصرًا نائبًا رقميًا مثل `[0]`—وإلا سيتسبب الاستدعاء في رفع استثناء `InvalidCastException`.

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية `Language_Id` (المُظهره من خلال فئة [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/)) للسماح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد النحوية في PowerPoint.

يعرض لك هذا الكود Python كيفية تعيين لغة التدقيق لعرض PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
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

يعرض لك هذا الكود Python كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

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

جرّب التطبيق عبر الإنترنت [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لتعرف كيف تتعامل مع خصائص المستند عبر واجهة برمجة تطبيقات Aspose.Slides:

[![عرض وتحرير بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص **Built-in** هي جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها بالكامل. مع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، فسيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصة مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) ثم [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة البيانات الوصفية المخزنة للمستند دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/python-net/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بالتنسيق.