---
title: إدارة خصائص العرض التقديمي في بايثون
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/python-java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
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
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحكم كامل في خصائص العرض التقديمي في Aspose.Slides للبايثون عبر جافا وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides for Python via Java يدعم **الخصائص المدمجة** و **الخصائص المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم التي يحددها المستخدم.

يتيح لك Aspose.Slides العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . يتم إرجاع مثيل من هذه الفئة بواسطة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) . تُظهر الأمثلة التالية كيفية قراءة، تعديل، وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات تعريف التطبيق والمنتج عند حفظ العروض التقديمية؛ تحدد هذه الحقول البرنامج الذي أنشأ الملف الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. تنقسم إلى فئتين:

- **Built-in properties** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصائيات المستند.
- **Custom properties** تخزن أزواج اسم/قيمة يحددها المستخدم.

يوفر Aspose.Slides for Python via Java إمكانية الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لاستعراض بيانات تعريف المستند. يُقسم الحوار المعلومات إلى علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و **Custom**. استخدم علامة التبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كل من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع `False`، تظل خصائص المستند عامة. يمكن لتطبيق بعد ذلك استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True` وقراءة البيانات العامة دون تزويد كلمة مرور الفتح.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) يتحكم فيما يحمله Aspose.Slides؛ ولا يقوم بفك التشفير. إذا تم تضمين الخصائص في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض مشفراً، يتم تجاهل الخيار ويتم تحميل العرض الكامل.

المثال يتطلب عرضاً مشفراً تُركت خصائص مستنده عامة. يتحقق من وضع التحميل عبر [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) :

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

في هذا الوضع، لا يتم تحميل محتوى الشريحة. لا تتوفر الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض التقديمي. يجب على التطبيقات دائمًا التحقق من [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يكون هناك متطلبات محددة من أنظمة الفهرسة، التصنيف، البحث، أو إدارة المستندات للوصول إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يكون العرض المحمَّل بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True` مخصصًا لقراءة البيانات العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المتغيرة من ذلك الكائن الذي يحمل البيانات العامة فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

المثال يتطلب عرض PPTX مشفر بخصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword)، يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة :

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

إذا لم يُسمح لتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX مشفر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

الفئة [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) تُظهر بيانات التعريف المدمجة عبر طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle)، و [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). يفتح هذا المثال عرضًا موجودًا ويطبع بيانات التعريف المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **تعديل الخصائص المدمجة**

لتحديث بيانات التعريف المدمجة، استخدم طرق setter على الكائن الذي تُرجعه [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). يفتح هذا المثال عرضًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)، [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)، [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)، [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments)، و[setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager)، ثم يحفظ العرض المحدَّث باستخدام [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إدارة قاعدة الارتباط التشعبي**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) تُعيد القاعدة على مستوى المستند للارتباطات التشعبية النسبية. استخدم [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) لتغييرها أو إفراغها. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) الخاص بالارتباط الفردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

المثال يتطلب عرضًا يحتوي على ارتباط نسبي مثل `target.html` وارتباط مطلق مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعين قاعدة جديدة، ويحفظ ويعيد فتح العرض للتحقق من القيمة. ثم يُفرغ القاعدة بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل قاعدة المثال بموقع ملفاتك المرتبطة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

يجب أن تُظهر رسالتا التحقق `True`. إفراغ القاعدة يترك عناوين الارتباطات الفردية دون تغيير.

ارتباط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ وإعادة فتح العرض، يفتح نفس الارتباط `new/target.pptx`. الارتباط المطلق استمر في فتح الملف نفسه. اختبر الرابطين النسبيين في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

الخصائص المخصصة تخزن بيانات تعريف لا توجد لها حقل مدمج مكافئ. طريقة [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) تتيح لك تعيين قيمة باسم الخاصية. يخلق هذا المثال عرضًا، يضيف قيمتي نص وقيمة إصدارة عددية (باستخدام `jpype.JInt` لتمرير عدد صحيح جافا)، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) للتنقل بينها. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) تقبل فهرسًا يبدأ من الصفر وتُعيد الاسم المستخدم في [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). يطبع المثال كل اسم أصلي وقيمته، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يُجري الحلقة أي تغييرات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مثال حي**

جرّب تطبيق الويب [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لتعرف كيف تتعامل مع خصائص المستند باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، فـ Aspose.Slides يحدث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/python-java/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر بدون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع `False`، ويجب تحميله بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل الخصائص فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متناسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.