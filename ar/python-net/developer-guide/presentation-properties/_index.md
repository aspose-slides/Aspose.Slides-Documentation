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
- الخصائص المضمنة
- الخصائص المخصصة
- الخصائص المتقدمة
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
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Python via .NET وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint الخاصة بك."
---
## **مقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مضمنة** و **مخصصة**. يمكن الوصول إلى هذين النوعين من الخصائص وإدارتهما بسهولة باستخدام Aspose.Slides API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/) . يتم إرجاع مثال من هذه الفئة بواسطة الخاصية [Presentation.document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/document_properties/) . تظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقل **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Python via .NET x.x.x سيتم عرضهما في هذه الحقول.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص المستندية بتخزين معلومات مفيدة مع المستندات (ملفات العرض التقديمي). هناك نوعان من الخصائص المستندية كما يلي

- خصائص النظام المعرفة (مضمنة)
- خصائص المستخدم المعرفة (مخصصة)

تحتوي الخصائص **مضمنة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. الخصائص **مخصصة** هي تلك التي يحددها المستخدمون كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Python via .NET، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وتعديلها وكذلك الخصائص المخصصة. يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستندات لملفات العرض التقديمي. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار العنصر **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد اختيار العنصر **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint. في **Properties Dialog**، يمكنك رؤية العديد من صفحات التبويب مثل **General, Summary, Statistics, Contents and Custom**. تسمح كل هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة المرور الفتحة كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي باستخدام [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) مع ضبط القيمة إلى `False`، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك ضبط [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/only_load_document_properties/) إلى `True` وقراءة البيانات الوصفية العامة دون توفير كلمة المرور الفتحة.

الـ `only_load_document_properties` يتحكم فيما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك تشفير أي شيء. إذا تم تضمين الخصائص في التشفير، فستفشل عملية التحميل بدون كلمة المرور. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض التقديمي بالكامل.

يوضح المثال التالي كيفية التحقق من وضع التحميل عبر [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ثم قراءة الخصائص المضمنة عبر [Presentation.document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض التقديمي غير متاحة. يجب على التطبيقات دائمًا التحقق من `is_only_document_properties_loaded` قبل تنفيذ عملية تتطلب نموذج الكائنات الكامل للعرض التقديمي.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين، العناوين، الموضوعات، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تكون أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات تحتاج إلى الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

في ملف PPTX مشفر، يُقصد من عرض تقديمي تم تحميله باستخدام `only_load_document_properties` قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من ذلك الكائن الذي يحتوي فقط على البيانات الوصفية لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض التقديمي المشفر. لذلك يتطلب تحديثها كلمة المرور الفتحة الصحيحة وتحميلًا كاملاً.

يفتح المثال التالي العرض التقديمي باستخدام [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/)، ثم يحدّث الخصائص المضمنة العامة، ويحفظ النتيجة. بعد ذلك يستخدم [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/is_encrypted/) للتحقق من أن التشفير ما زال محفوظًا ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتحقق من القيم الجديدة:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض التقديمي، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقراءة فقط.

## **الوصول إلى الخصائص المضمنة**
تتضمن هذه الخصائص التي يُظهرها كائن **IDocumentProperties**: **Creator (Author)**، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل العرض التقديمي
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # إنشاء مرجع للكائن المرتبط بالعرض التقديمي
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

تعديل الخصائص المضمنة لملفات العرض التقديمي سهل كالولوج إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وستتغير قيمة الخاصية. في المثال أدناه، أظهرنا كيفية تعديل خصائص المستند المضمنة لملف العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل العرض التقديمي
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # إنشاء مرجع للكائن المرتبط بالعرض التقديمي
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

يتيح Aspose.Slides for Python via .NET للمطورين أيضًا إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation
with slides.Presentation() as presentation:
    # الحصول على خصائص المستند
    documentProperties = presentation.document_properties

    # إضافة خصائص مخصصة
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # الحصول على اسم الخاصية في فهرس معين
    getPropertyName = documentProperties.get_custom_property_name(2)

    # إزالة الخاصية المحددة
    documentProperties.remove_custom_property(getPropertyName)

    # حفظ العرض التقديمي
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى وتعديل الخصائص المخصصة**

كما يسمح Aspose.Slides for Python via .NET للمطورين بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
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
    # حفظ العرض التقديمي إلى ملف
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

تُعيد الدالة `get_custom_property_value` القيمة عبر القائمة ذات العنصر الواحد التي تُمرَّر كوسيط ثانٍ، ويتم تحويل القيمة المخزنة إلى نوع العنصر الموجود مسبقًا في تلك القائمة. يستخدم المثال أعلاه `[""]`، لذا يقرأ خصائص نصية؛ لقراءة خاصية مخزنة كعدد، مرّر عنصرًا نائبًا رقميًا مثل `[0]`—وإلا ستُطلق الاستدعاء استثناء `InvalidCastException`.

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية `Language_Id` (المُعرَّفة بواسطة الفئة [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/)) لتسمح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض لك هذا الكود بلغة Python كيفية تعيين لغة التدقيق لملف PowerPoint:

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

يُظهر لك هذا الكود بلغة Python كيفية تعيين اللغة الافتراضية لعرض تقديمي كامل في PowerPoint:

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

جرّب التطبيق عبر الإنترنت [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لرؤية كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![عرض وتحرير بيانات PowerPoint الوصفية](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمنة من عرض تقديمي؟**

الخصائص المضمنة جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) ثم [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة البيانات الوصفية المخزنة للمستند دون إنشاء مثال [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) . انظر [Build a Lightweight Presentation Inventory](/slides/ar/python-net/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بالصيغة.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة المرور الفتحة؟**

نعم. يجب أن يكون العرض التقديمي قد تم تشفيره مع ضبط `encrypt_document_properties` إلى `False`، ويجب تحميله مع ضبط `only_load_document_properties` إلى `True`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا فإن تحديث ملف PPTX مشفر يتطلب تحميل العرض التقديمي بالكامل مع كلمة المرور الفتحة الصحيحة.