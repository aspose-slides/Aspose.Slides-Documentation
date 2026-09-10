---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام Python
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/python-java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات وصفية XML
- معرف العنصر
- إضافة علامة
- قيمة مزدوجة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides للغة Python عبر Java، بما في ذلك إضافة، القراءة، التحديث، التدقيق، وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج سلسلة نصية بسيطة المفتاح‑القيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحمولات XML خاصة بالتطبيق.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يُعرّف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات ذات الصلة.

العرض يحتوي على أجزاء متعددة مرتبطة بعلاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى كما هو معرف في ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([TagCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/)) أو كأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/)). كلاهما متاح عبر فئة [CustomData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
العلامات تخزن أزواج سلسلة نصية بسيطة المفتاح‑القيمة. أجزاء XML المخصصة تخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

طريقة [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- مجموعة [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) في العرض تحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- مجموعة [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) في الشريحة تحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- مجموعة [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) في الشكل تحتوي على أجزاء XML المخصصة المرتبطة بشكل محدد.

استخدم [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAllCustomXmlParts) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ارتباطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [CustomXmlPartCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#add) لإضافة بيانات XML إلى مجموعة أجزاء XML مخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # إضافة تقوم بتعيين معرف تلقائيًا. حدد UUID معين فقط عند الحاجة.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكن للطريقة [add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#add) أيضًا قبول XML كمصفوفة بايت أو كتيار إدخال، وهو مفيد عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة أو شكل محددين بدلاً من العرض بأكمله. يكون ذلك مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح القالب أو معرف سجل خارجي أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المستوى الذي تُضاف إليه الجزء يحدّد مجموعة [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) التي تحتوي على العلاقة لهذا الجزء. البيانات على مستوى العرض مناسبة للبيانات الوصفية العامة للوثيقة، والبيانات على مستوى الشريحة للمعلومات الخاصة بشريحة معينة، والبيانات على مستوى الشكل للبيانات المرتبطة بالعديد من الأشكال الفردية.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAllCustomXmlParts) لاسترجاع جميع أجزاء XML المخصصة من عرض. كل [CustomXmlPart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/) يعرض معرّفه ومحتوى XML ومخططات مساحة الأسماء المرتبطة به.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات مساحة الأسماء الخاصة بها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) يُعيد مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق العروض التي تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرف العنصر**

استخدم [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlAsString) و[setXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlAsString) للعمل مع XML كسلسلة UTF‑8، أو [getXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlData) و[setXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlData) للعمل مع بايتات XML الخام.

طريقة [CustomXmlPart.getItemId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getItemId) تُعيد UUID الذي يحدد جزء XML المخصص في مستند Office Open XML. استخدم [setItemId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setItemId) عندما يتطلب التكامل معرفًا جديدًا.

المثال التالي يحدث محتوى XML والمعرّف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # قراءة XML الحالي كنص.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # تحديث XML كسلسلة UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # توفر getXmlData نفس محتوى XML على هيئة بايتات خام.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # استبدال المعرف عند الحاجة من قبل التكامل.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

عند استدعاء [setXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlAsString) أو [setXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlData)، قدم XML صالحًا وغير فارغ. استخدم أحد التمثيلات أو الآخر حسب ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML المخصصة:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#remove) يزيل جزء XML المخصص من العرض.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#remove) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#removeAt) يزيل الجزء عند فهرس مجموعة محدد.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#clear) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض بالإشارة إلى المرجع:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا كان لديك بالفعل [CustomXmlPart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/) وتريد إزالة هذا الجزء من العرض بدلاً من معالجة مجموعة معينة، استدعِ [CustomXmlPart.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#remove).

يمكنك أيضًا إزالة عنصر حسب الفهرس:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#clear) عندما ينبغي حذف جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#clear) يؤثر فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح المجموعات على مستوى العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، كرّر عبر [getAllCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAllCustomXmlParts) وأزل كل جزء:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **معالجة الأجزاء XML المخصصة المرتبطة أو المشتركة**

في عرض Office Open XML، قد يتم الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من شرائح أو أشكال متعددة إلى نفس الجزء XML الأساسي.

يجب التعامل مع الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام [setXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlAsString) أو [setXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlData) أو [setItemId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setItemId) يغيّر الجزء الأساسي، وبالتالي ينطبق التغيير في كل الأماكن التي يُشار إليها.
- يمكن استخدام [getItemId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getItemId) لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات مستوى الكائن.
- إزالة جزء من مجموعة [getCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getCustomXmlParts) معينة يزيله من تلك المجموعة فقط. استخدم [CustomXmlPart.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#remove) عندما يجب حذف الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات مستوى الكائن لتحديد ما إذا كانت شرائح أو أشكال أخرى ما زالت تشير إليه.

إنّ التحميل الزائد للـ [add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpartcollection/#add) ينشئ جزء XML مخصص جديد من محتوى XML؛ ولا يقبل جزء XML مخصص موجود مسبقًا. وبالتالي، تُلاحظ العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والشكل بحسب `ItemId` ويبلغ عن الأجزاء التي تُشار إليها من أكثر من موقع:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن جزء البيانات الوصفية نفسه قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تُعادل العلامة الطريقة [DocumentProperties.getKeywords](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getKeywords). يُظهر هذا الكود كيف يمكن الحصول على قيمة علامة باستخدام Aspose.Slides للغة Python عبر Java لـ[Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **إضافة علامات إلى العروض**

تسمح Aspose.Slides بإضافة علامات إلى العروض. عادةً ما تتكوّن العلامة من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض بناءً على قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء علامة “North American” وتعيين الدولة ذات الصلة كقيمة لها.

يعرض هذا الكود كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) باستخدام Aspose.Slides للغة Python عبر Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

يمكن أيضًا تعيين علامات لـ[Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

أو لشكل فردي [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **القيود**

العلامات التي تُضاف عبر مجموعة [CustomData.getTags](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customdata/#getTags) تُخزن فقط في ملف PowerPoint. **لا** يتم نقلها إلى هيكل العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرداد معرف مخصص مُعين كعلامة من ملف PDF الموسوم.

**حل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثال، [Shape.setAlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setAlternativeText) بالقيمة `"MyId"`). بعد التصدير إلى PDF، قد يظهر النص البديل في هيكل العلامات في PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل في عملية واحدة؟**

نعم. مجموعة [tag collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/) تدعم عملية [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/#clear) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة حسب اسمها دون المرور عبر المجموعة بأكملها؟**

استخدم [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/#remove) على [tag collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/) لحذف العلامة بواسطة المفتاح الخاص بها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/#getNamesOfTags) على [tag collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAllCustomXmlParts) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم [getXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlAsString) أم [getXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlData) لتحديث جزء XML مخصص؟**

استخدم [getXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlAsString) و[setXmlAsString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlAsString) عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم [getXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#getXmlData) و[setXmlData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/customxmlpart/#setXmlData) عندما يكون XML متاحًا كمصفوفة بايت أو عندما تكون المعالجة الثنائية أكثر ملاءمة. كلا التمثيلين يشيران إلى محتوى XML لنفس جزء XML المخصص.