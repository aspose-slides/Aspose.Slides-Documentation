---
title: "إدارة خصائص العرض التقديمي في بايثون"
linktitle: "خصائص العرض التقديمي"
type: docs
weight: 70
url: /ar/python-java/presentation-properties/
keywords:
- "خصائص PowerPoint"
- "خصائص العرض التقديمي"
- "خصائص المستند"
- "الخصائص المدمجة"
- "الخصائص المخصصة"
- "الخصائص المتقدمة"
- "إدارة الخصائص"
- "تعديل الخصائص"
- "بيانات المستند الوصفية"
- "تحرير البيانات الوصفية"
- "لغة التدقيق"
- "اللغة الافتراضية"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "تحكم في خصائص العرض التقديمي باستخدام Aspose.Slides for Python via Java وسهّل عملية البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام واجهة برمجة التطبيقات Aspose.Slides API.

يتيح لك Aspose.Slides العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/). تُرجَع نسخة من هذه الفئة بواسطة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDocumentProperties). تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابة هذين الحقلين عند كل عملية حفظ، لذا فإن العرض التقديمي المحفوظ دائمًا يُظهر "Aspose.Slides for Java" وإصدار المكتبة التي أنشأته. يتم تجاهل أي قيمة تُمرَّر إلى [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#setNameOfApplication) عند كتابة العرض التقديمي.
{{% /alert %}}

## **خصائص المستند في PowerPoint**

يتيح لك Microsoft PowerPoint 2007 إدارة خصائص مستند ملفات العرض التقديمي. انقر على أيقونة Office واختر **Prepare | Properties | Advanced Properties**، كما هو موضح أدناه:

|**اختيار عنصر القائمة Advanced Properties**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/ZrmuCD6.jpg)|

بعد اختيار **Advanced Properties**، يظهر حوار يمكنك من خلاله إدارة خصائص مستند ملف PowerPoint:

|**حوار الخصائص**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/LibmdQd.jpg)|

يحتوي **Properties Dialog** على علامات تبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح لك هذه العلامات بتكوين معلومات مختلفة حول ملفات PowerPoint. استخدم علامة التبويب **Custom** لإدارة الخصائص المخصصة.

## **العمل مع خصائص المستند باستخدام Aspose.Slides for Python via Java**

كما هو موضح سابقًا، يدعم Aspose.Slides for Python via Java كل من خصائص المستند **Built-in** و **Custom**. تمثل الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/) خصائص المستند المرتبطة بملف العرض التقديمي.

استخدم [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDocumentProperties) للوصول إلى هذه الخصائص كما هو موضح أدناه.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما تحمي كلمة المرور الافتتاحية كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بتمرير `false` إلى [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك تمرير `true` إلى [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) وقراءة البيانات الوصفية العامة دون توفير كلمة المرور الافتتاحية.

تتحكم خيار تحميل خصائص المستند فقط في ما يقوم Aspose.Slides بتحميله؛ فهو لا يقوم بفك تشفير أي شيء. إذا تم تضمين الخصائص في عملية التشفير، فستفشل عملية التحميل دون كلمة المرور. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل هذا الخيار ويُحمَّل العرض التقديمي كاملًا.

يتحقق المثال التالي من وضع التحميل عبر [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض التقديمي غير متاحة. يجب على التطبيقات دائمًا التحقق من [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج الكائن الكامل للعرض التقديمي.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين والعناوين والموضوعات والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يتطلب الفهرسة أو التصنيف أو البحث أو أنظمة إدارة الوثائق إمكانية الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُقصد من العرض التقديمي الذي يُحمَّل في وضع خصائص المستند فقط قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من هذا الكائن الذي يحتوي على البيانات الوصفية فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض التقديمي المشفر. لذلك يتطلب تحديثها كلمة المرور الافتتاحية الصحيحة وتحميل كامل.

يفتح المثال التالي العرض التقديمي باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword)، يُحدِّث الخصائص العامة المدمجة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات الوصفية العامة دون كلمة مرور للتحقق من القيم الجديدة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

إذا لم يُسمح للتطبيق بفك تشفير محتوى العرض التقديمي أو تحميله، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر على أنها للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تتضمن الخصائص المدمجة التي تُظهرها [DocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/) ما يلي: **Creator** (المؤلف)، **Description**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل يتم مشاركة المستند بين منتجين مختلفين؟)، **PresentationFormat**، **Subject**، و **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# إنشاء كائن Presentation الذي يمثل العرض التقديمي
presentation = Presentation("Presentation.pptx")
try:
    # إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
    properties = presentation.getDocumentProperties()

    # عرض الخصائص المدمجة
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة سهل بقدر الوصول إليها. استخدم الدالة الضابطة المقابلة لتعيين قيمة جديدة. يُظهر المثال التالي تعديل خصائص المستند المدمجة باستخدام Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
    properties = presentation.getDocumentProperties()

    # تعيين الخصائص المدمجة
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # حفظ العرض التقديمي إلى ملف
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يقوم هذا المثال بتعديل الخصائص المدمجة للعرض التقديمي ويمكن رؤيتها كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/zz1N9de.jpg)|

## **إضافة خصائص مستند مخصص**

يتيح Aspose.Slides for Python via Java للمطورين أيضًا إضافة خصائص مستند مخصصة إلى العروض التقديمية. يضيف المثال أدناه ثلاث خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، لذا يحتفظ العرض التقديمي المحفوظ باثنتين منها. تُفهرس الخصائص المخصصة بترتيب أبجدي، وليس بترتيب إضافتها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # جلب خصائص المستند
    properties = presentation.getDocumentProperties()

    # إضافة خصائص مخصصة
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # جلب اسم الخاصية في الفهرس المحدد
    property_name = properties.getCustomPropertyName(2)

    # إزالة الخاصية المحددة
    properties.removeCustomProperty(property_name)

    # حفظ العرض التقديمي
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**خصائص المستند المخصصة المضافة**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/HdKcxI9.png)|

## **الوصول إلى الخصائص المخصصة وتعديلها**

يتيح Aspose.Slides for Python via Java للمطورين أيضًا الوصول إلى قيم الخصائص المخصصة. يُظهر المثال التالي كيفية الوصول إلى جميع الخصائص المخصصة وتعديلها في عرض تقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
    properties = presentation.getDocumentProperties()

    # الوصول إلى الخصائص المخصصة وتعديلها
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # عرض أسماء وقيم الخصائص المخصصة
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # تعديل قيم الخصائص المخصصة
        properties.set_Item(property_name, f"New Value {i + 1}")

    # حفظ العرض التقديمي إلى ملف
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يُعدِّل هذا المثال الخصائص المخصصة لعرض [PPTX](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية خصائص العرض التقديمي المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/Ze7YHvi.jpg)|

|**الخصائص المخصصة بعد التعديل**|
| :- |
|![خصائص مستند PowerPoint](https://i.imgur.com/Tofu0CL.jpg)|

## **خصائص المستند المتقدمة**

{{% alert color="info" title="Note" %}}
تمت إضافة الطرق الجديدة [readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)، و[writeBindedPresentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/)، كما تغير سلوك الطريقة [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#setLastSavedTime).
{{% /alert %}}

تمت إضافة الطريقتين الجديدتين [readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties) و[updateDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان لك بتغيير وتحديث الخصائص دون تحميل العرض التقديمي بالكامل.

يمكن تنفيذ سير عمل شائع لتحميل الخصائص وتغيير قيمها وتحديث المستند كما يلي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# قراءة معلومات العرض التقديمي
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# الحصول على الخصائص الحالية
properties = presentation_info.readDocumentProperties()

# تعيين القيم الجديدة لحقلي المؤلف والعنوان
properties.setAuthor("New Author")
properties.setTitle("New Title")

# تحديث العرض التقديمي بالقيم الجديدة
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

يمكن إنشاء قالب جديد من الصفر ثم الاستخدام لتحديث عروض تقديمية متعددة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **تعيين لغة التدقيق**

توفر Aspose.Slides الطريقة [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#setLanguageId) لتعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد النحوية في العرض التقديمي.

يعرض لك هذا الشيفرة Python كيفية تعيين لغة التدقيق لملف PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # تعيين معرف لغة التدقيق

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **تعيين اللغة الافتراضية**

يعرض لك هذا الشيفرة Python كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # يضيف شكلًا مستطيلًا يحتوي على نص
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # يفحص لغة الجزء الأول
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **مثال حي**

جرّب تطبيق الويب [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لتعرف كيف تعمل مع خصائص المستند عبر Aspose.Slides API:

[![عرض وتحرير بيانات PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو فحصها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات المستند المخزونة دون إنشاء نسخة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/python-java/examine-presentation/) للحصول على مثال تقارير كامل وقيود خاصة بالصيغ.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة المرور الافتتاحية؟**

نعم. يجب أن يكون تشفير خصائص المستند قد تم تعطيله قبل تشفير العرض التقديمي، ويجب تحميل العرض التقديمي في وضع خصائص المستند فقط.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX المشفر تحميل العرض التقديمي بالكامل مع كلمة المرور الافتتاحية الصحيحة.