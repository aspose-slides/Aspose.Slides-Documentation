---
title: إدارة خصائص العرض التقديمي في Python
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
description: "إدارة خصائص العرض التقديمي في Aspose.Slides لPython عبر Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides for Python via Java يدعم الخصائص **المدمجة** و **المخصصة** للوثائق. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف والعنوان والقيم التي يحددها المستخدم.

Aspose.Slides يسمح لك بالعمل مع خصائص مستند العرض التقديمي عبر فئة [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/). يتم إرجاع كائن من هذه الفئة بواسطة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). توضح الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
Aspose.Slides يدير بيانات تعريف التطبيق والمنتج عند حفظ العروض التقديمية؛ تحدد هذه الحقول البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية جنبًا إلى جنب مع محتوى العرض التقديمي. تنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصائيات المستند.
- **الخصائص المخصصة** تخزن أزواج الاسم/القيمة التي يحددها المستخدم.

Aspose.Slides for Python via Java يوفر إمكانية الوصول إلى الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفقد بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و **Custom**. استخدم علامة تبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما تحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع `False`، تبقى خصائص المستند عامة. يمكن للتطبيق بعد ذلك استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True` وقراءة البيانات العامة دون تقديم كلمة مرور الفتح.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) يتحكم فيما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك التشفير. إذا تم تضمين الخصائص في عملية التشفير، فإن تحميلها بدون كلمة المرور يفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار وتُحمَّل النسخة الكاملة من العرض.

يتطلب المثال عرضًا تقديميًا مشفرًا تم ترك خصائص المستند فيه عامة. يتحقق من وضع التحميل عبر [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، المخططات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. شفر الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة الوثائق الوصول إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

لملف PPTX مشفر، يُقصد من العرض الذي يُحمَّل بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True` قراءة البيانات العامة. لا يستطيع Aspose.Slides حفظ الخصائص المعدلة من ذلك الكائن المتاح للبيانات العامة لأن الخصائص العامة يجب أن تبقى متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب التحديث كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرض PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword)، يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

الفئة [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) تكشف عن بيانات التعريف المدمجة من خلال طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle)، و [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

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

### **تقرير رقم المراجعة ووقت التحرير**

لتوليد صف واحد لكل ملف PPTX في مجلد `presentations`، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) الخاصة به دون تحميل الشرائح للتحرير. تُعيد واجهة Python عبر Java مدة التحرير بالميليثانية. يقوم المثال بتنسيقها كساعات ودقائق وثوانٍ، مع عدد أيام للمدة التي تبلغ 24 ساعة أو أكثر.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

لعرض تم تسجيل وقت تحريره بـ 1 يوم، ساعتين، و5 دقائق، يعرض التقرير الن output التالي.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[ getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) يقرأ قيمة يمكن للتطبيقات تعديلها باستخدام [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber). رقم المراجعة وحده لا يمكنه تحديد عدد مرات حفظ العرض أو إعادة بناء تاريخ الإصدارات.

[ getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) يقرأ مدة التحرير المسجلة في الملف. القيمة `00:00:00` تعني أن المدة المخزنة صفر، حتى لو قام شخص ما بتحرير العرض.

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، استخدم طرق setter على الكائن الذي تُرجعه [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)، [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)، [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)، [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments)، و [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager)، ثم يحفظ العرض المحدث باستخدام [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.

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

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) تُرجع القاعدة على مستوى المستند للارتباطات التشعبية النسبية. استخدم [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) لتغييرها أو إفراغها. يكون ذلك مفيدًا عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) لارتباط تشعبي فردي: تغيير القاعدة لا يُعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على رابط نسبي مثل `target.html`، ورابط مطلق مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يُعيّن عنوان قاعدة جديد، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعد ذلك يُفرغ القاعدة بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة المثال بموقع ملفاتك المرتبطة.

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

يجب أن تُظهر رسائل التحقق الاثنين `True`. إفراغ القاعدة يترك عناوين الروابط التشعبية الفردية كما هي.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ وإعادة فتح العرض، فتح نفس الرابط `new/target.pptx`. استمر الرابط المطلق في فتح الملف نفسه. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مدمج مقابل. تسمح طريقة [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) بتعيين قيمة وفقًا لاسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وإصدار عدد صحيح (باستخدام `jpype.JInt` لتمرير عدد صحيح جافا)، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

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

## **الوصول إلى وتعديل الخصائص المخصصة**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) للتكرار عليها. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) تقبل فهرسًا يبدأ من الصفر وتُرجع الاسم المستخدم بواسطة [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). يطبع المثال كل اسم وقيمة أصلية، يُستبدل كل قيمة بسلسلة مُرقّمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، فإن الحلقة لا تُجري أي تغييرات.

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

## **مثال عملي**

جرّب تطبيق الويب [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لتكتشف كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال القيمة الحالية بالجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . انظر إلى [إنشاء جرد عرض تقديمي خفيف](/slides/ar/python-java/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع `False`، ويجب تحميله بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع `True`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل البيانات العامة والبيانات المشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل باستخدام كلمة مرور الفتح الصحيحة.