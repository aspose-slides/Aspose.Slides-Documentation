---
title: إدارة تصنيفات الحساسية في عروض PowerPoint التقديمية باستخدام Python
linktitle: تصنيفات الحساسية
type: docs
weight: 50
url: /ar/python-java/sensitivity-labels/
keywords:
- تصنيف حساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات MIP الوصفية
- تمييز المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Python
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل تصنيفات الحساسية من Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides للغة Python عبر Java."
---
## **نظرة عامة**

تساعد تصنيفات الحساسية في Microsoft Purview المؤسسات على تصنيف وحكم المستندات. أثناء معالجة العروض التقديمية بشكل آلي، قد تحتاج التطبيقات إلى الحفاظ على تصنيف موجود، أو تطبيق تصنيف مختار وفقًا لسياسة، أو تحديث حالته، أو ترحيل بيانات وصفية للتصنيف كتبها سير عمل Microsoft Information Protection (MIP) الأقدم.

Aspose.Slides exposes modern sensitivity label metadata through [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSensitivityLabels). This method returns an [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}
معرِّفات تصنيف الحساسية ومعلومات السياسة يتم تعريفها في تكوين Microsoft Purview الخاص بك. تحقق من توفر التصنيف ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المرتبطة بالتصنيف؛ ولا تضيف نصًا مرئيًا أو أشكالًا إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص تصنيف الحساسية**

كل [SensitivityLabel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [getId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setId) | الحصول على معرِّف تصنيف الحساسية في سياسة Purview أو تعيينه. |
| [getSiteId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setSiteId) | الحصول على الموقع المرتبط بسياسة التصنيف أو تعيينه. |
| [isEnabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setEnabled) | معرفة ما إذا كان التصنيف مفعلاً أو تعيين هذه الحالة. |
| [isRemoved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setRemoved) | معرفة ما إذا كان التصنيف قد أُزيل أو تعيين القيمة إلى `True` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | الحصول على طريقة تطبيق التصنيف (تلقائيًا أو بقرار المستخدم) أو تعيينها. |
| [getContentMarkTypes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | الحصول على أنواع العلامات المرتبطة بالتصنيف. |

الفئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelassignmenttype/) تُعرّف كيفية تعيين التصنيف:

- [Standard](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل تصنيفًا افتراضيًا أو مُطبقًا تلقائيًا.
- [Privileged](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل تصنيفًا تم تطبيقه بقرار المستخدم، بما في ذلك التصنيفات المُحددة يدويًا، والموصى بها، والملزمة.

الفئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) تُعرّف العلامة المرتبطة بالتصنيف:

| القيمة | المعنى |
| --- | --- |
| [None](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التصنيف افتراضيًا أو تلقائيًا. |
| [Header](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى الرأس مرتبطة بالتصنيف. |
| [Footer](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى التذييل مرتبطة بالتصنيف. |
| [Watermark](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى العلامة المائية مرتبطة بالتصنيف. |
| [Encryption](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcontenttype/) | حماية التشفير مرتبطة بالتصنيف. |

يمكن أن تكون أنواع علامات متعددة مرتبطة بتصنيف واحد.

## **قائمة تصنيفات الحساسية الموجودة**

اقرأ مجموعة التصنيفات الحديثة من [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSensitivityLabels) وقم بتعدادها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزنة لكل تصنيف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **إضافة تصنيف حساسية مع علامة محتوى**

استخدم [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#add) مع معرِّف التصنيف، ومعرِّف الموقع، وحالة التفعيل، وطريقة التعيين. بعد أن تُعيد الطريقة كائن [SensitivityLabel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/) جديد، أضف قيم العلامات المطلوبة من خلال القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

المثال التالي يضيف تصنيفًا مختارًا يدويًا مرتبطًا بعلامات التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديث تصنيف الحساسية**

قِيَم [SensitivityLabel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) والتي تُعدَّل عبر عمليات القائمة. بعد تحديد التصنيف المطلوب، يمكنك تحديث معرِّفه، ومعرِّف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع العلامات. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يحدِّث حالة التفعيل وطريقة التعيين للتصنيف الأول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **وضع علامة على تصنيف الحساسية كـ "مُزال"**

للحفاظ على حقيقة إزالة التصنيف، ابحث عن التصنيف واستدعِ [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setRemoved) مع القيمة `True`. هذا يحتفظ بإدخال التصنيف مع تسجيل حالته كـ "مُزال". إذا رغبت في حذف إدخال من المجموعة الحديثة، استخدم [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#removeAt)؛ واستخدم [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#clear) لحذف جميع الإدخالات.

المثال التالي يضع علامة "مُزال" على تصنيف محدد ويحفظ العرض المحدث:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قراءة وترحيل تصنيفات الحساسية القديمة من MIP**

يمكن لسير عمل MIP القديم تخزين بيانات تصنيف الحساسية في خصائص المستند المخصَّصة بدلاً من مجموعة التصنيفات الحديثة. اقرأ تلك البيانات باستخدام [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getSensitivityLabels). تقوم الطريقة بتحليل الخصائص المخصَّصة القديمة وتعيد مصفوفة من كائنات [SensitivityLabel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل تصنيف مُسترجَع إلى [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/) الحديثة عبر [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#add). نظرًا لأن إضافة مُعرِّف تصنيف مكرر يثير استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تصنيف. يمكنك إضافة تحقق إضافي للتأكد من أن كل تصنيف قديم لا يزال موجودًا في سياسة Purview الحالية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الترحيل ينسخ كائنات التصنيف المُحلَّلة إلى المجموعة الحديثة. لا يتطلب مسح جميع خصائص المستند المخصَّصة، وبالتالي تظل البيانات الوصفية غير المرتبطة بالمستند سليمة. استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) لكتابة بيانات التصنيف الحديثة إلى ملف PPTX.

## **الأسئلة المتداولة**

**هل إنشاء نوع علامة محتوى يضيف رأسًا أو تذييلًا أو علامة مائية مرئية على الشرائح؟**

لا. القيم المُضافة عبر القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المرتبطة بالتصنيف، ولا تُنشئ نصًا أو أشكالًا مرئية في العرض. إذا كان سير عملك يحتاج إلى عرض تلك العلامات، أضف محتوى الشرائح الموافق بشكل منفصل.

**ما الفرق بين وضع علامة على التصنيف كـ "مُزال" وحذفه من المجموعة؟**

استدعاء [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#setRemoved) مع `True` يظل يحتفظ بإدخال التصنيف ويسجل حالته كـ "مُزال". استدعاء [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) يحذف الإدخال من المجموعة الحديثة. اختر العملية التي تتوافق مع متطلبات احتفاظ المنظمة بالبيانات الوصفية.

**هل يمكن للعرض التقديمي أن يحتوي على بيانات MIP القديمة بالإضافة إلى تصنيفات الحساسية الحديثة؟**

نعم. يمكن أن تبقى التصنيفات القديمة في خصائص المستند المخصَّصة بينما تكون التصنيفات الحديثة متاحة عبر [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSensitivityLabels). استخدم [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getSensitivityLabels) لقراءة البيانات القديمة وترحيل التصنيفات الصالحة التي لم تُضاف بعد إلى المجموعة الحديثة.

**ماذا يحدث إذا تم إضافة تصنيف بنفس المعرف أكثر من مرة؟**

يُطلق [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabelcollection/#add) استثناءً عندما تحتوي المجموعة بالفعل على تصنيف بنفس المعرف. تحقق من القيم الموجودة المُسترجَعة عبر [SensitivityLabel.getId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sensitivitylabel/#getId) قبل الإضافة أو الترحيل.

**أي تنسيق إخراج يجب استخدامه للحفاظ على تصنيفات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX باستدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.