---
title: إدارة تسميات الحساسية في عروض PowerPoint التقديمية باستخدام Python
linktitle: تسميات الحساسية
type: docs
weight: 50
url: /ar/python-net/sensitivity-labels/
keywords:
- تسمية حساسية
- Microsoft Purview
- حماية المعلومات من مايكروسوفت
- بيانات تعريف MIP
- تعليم المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العروض التقديمية
- Python
- Aspose.Slides
description: "قراءة، إضافة، تحديث، إزالة، وترحيل تسميات الحساسية من Microsoft Purview في عروض PowerPoint PPTX التقديمية باستخدام Aspose.Slides للـ Python عبر .NET."
---
## **نظرة عامة**

تساعد تسميات الحساسية في Microsoft Purview المنظمات على تصنيف المستندات وحوكمتها. أثناء معالجة العروض التقديمية تلقائيًا، قد يحتاج التطبيق إلى الحفاظ على تسمية موجودة، أو تطبيق تسمية مختارة بواسطة سياسة، أو تحديث حالتها، أو ترحيل بيانات تعريف التسمية التي كتبها سير عمل Microsoft Information Protection (MIP) الأقدم.

يوفر Aspose.Slides للـ Python عبر .NET بيانات تعريف تسميات الحساسية الحديثة من خلال [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sensitivity_labels/). تُعيد هذه الخاصية [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="primary" title="ملاحظة" %}}

معرفات تسميات الحساسية ومعلومات السياسة تُحدد بواسطة تكوين Microsoft Purview الخاص بك. تحقق من توفر التسميات ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل بيانات التعريف. قيم [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/content_mark_types/) تصف علامات المحتوى المرتبطة بالتسمية؛ ولا تُضيف بحد ذاتها نصًا مرئيًا أو أشكالًا إلى الشرائح.

{{% /alert %}}

## **فهم خصائص تسمية الحساسية**

كل [SensitivityLabel](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/) يحتوي على البيانات التعريفية التالية:

| الخاصية | الغرض |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/id/) | يحدد تسمية الحساسية في سياسة Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/site_id/) | يحدد الموقع المرتبط بسياسة التسمية. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/is_enabled/) | يشير إلى ما إذا كانت التسمية مفعلة. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/is_removed/) | يشير إلى أن التسمية تمت إزالتها. عيّن هذه الخاصية إلى `True` عندما يجب الاحتفاظ بحالة الإزالة في البيانات التعريفية. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | يحدد ما إذا تم تطبيق التسمية تلقائيًا أو عبر قرار المستخدم. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | قائمة بأنواع علامات المحتوى المرتبطة بالتسمية. |

تصف تعداد [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين التسمية:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية افتراضية أو تم تطبيقها تلقائيًا.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية تم تطبيقها عبر قرار المستخدم، بما في ذلك التسمية المطبقة يدويًا، والمقترحة، والملزمة.

التعداد [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) يحدد العلامة المرتبطة بالتسمية:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التسمية افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى الرأس بالتسمية. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى التذييل بالتسمية. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى العلامة المائية بالتسمية. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcontenttype/) | ترتبط الحماية بالتشفير بالتسمية. |

يمكن ربط أنواع متعددة من العلامات بتسمية واحدة.

## **قائمة تسميات الحساسية الموجودة**

اقرأ مجموعة التسميات الحديثة من [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sensitivity_labels/) وقم بعمل تعداد لها. المثال التالي يدرج كل خاصية وعلامة محتوى مخزنة لكل تسمية:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **إضافة تسمية حساسية مع علامة محتوى**

استخدم [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/add/) مع معرف التسمية، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين. مرّر معرف الموقع ككائن Python `uuid.UUID`. بعد أن تُعيد الطريقة كائن [SensitivityLabel](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة إلى [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

المثال التالي يضيف تسمية مختارة يدويًا مرتبطة بعلامات التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث تسمية حساسية**

خصائص [SensitivityLabel](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/content_mark_types/) التي يتم تعديلها عبر عمليات القائمة الخاصة بها. بعد تحديد التسمية المطلوبة، يمكنك تحديث معرفها، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يحدّث حالة التفعيل وطريقة التعيين للتسمية الأولى:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **وضع علامة إزالة لتسمية حساسية**

للحفاظ على حقيقة أن التسمية قد أُزيلت، ابحث عن التسمية واضبط [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/is_removed/) إلى `True`. هذا يحتفظ بإدخال التسمية مع تسجيل حالة الإزالة. إذا كنت بحاجة إلى حذف إدخال من المجموعة الحديثة، استخدم [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); واستخدم [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/clear/) لحذف جميع الإدخالات.

المثال التالي يضع علامة إزالة لتسمية معينة ويحفظ العرض المحدث:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **قراءة وترحيل تسميات حساسية MIP القديمة**

يمكن لسير العمل القائم على MIP القديم تخزين بيانات تعريف تسميات الحساسية في خصائص المستند المخصصة بدلاً من مجموعة التسميات الحديثة. اقرأ تلك البيانات باستخدام [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتُعيد كائنات [SensitivityLabel](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/).

لترحيل البيانات، أضف كل تسمية مُسترجعة إلى مجموعة [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/) الحديثة عبر [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/add/). نظرًا لأن إضافة معرف تسمية مكرر يثير استثناءً، يتحقق المثال من مجموعة الوجهة قبل نسخ كل تسمية. يمكنك إضافة مزيد من التحقق لتأكيد أن كل تسمية قديمة لا تزال موجودة في سياسة Purview الحالية.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

ترحيل النسخ ينقل كائنات التسميات التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب مسح جميع الخصائص المخصصة للمستند، لذا تظل البيانات التعريفية غير المرتبطة سليمة. استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) مع [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) لكتابة بيانات تعريف التسميات الحديثة إلى ملف PPTX.

## **الأسئلة الشائعة**

**هل إضافة نوع علامة محتوى يؤدي إلى إنشاء رأس أو تذييل أو علامة مائية مرئية على الشرائح؟**

لا. القيم التي تُضاف عبر [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/content_mark_types/) تصف العلامات المرتبطة بتسمية الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض. أضف محتوى الشريحة المقابل بشكل منفصل إذا كان سير عملك يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة إزالة لتسمية وحذفها من المجموعة؟**

تعيين [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/is_removed/) إلى `True` يحافظ على إدخال التسمية ويسجل حالة الإزالة. استدعاء [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) يحذف الإدخال من المجموعة الحديثة. اختر العملية التي تتوافق مع متطلبات مؤسستك للاحتفاظ بالبيانات التعريفية.

**هل يمكن أن يحتوي عرض تقديمي على كل من بيانات MIP القديمة وتسميات الحساسية الحديثة؟**

نعم. يمكن أن تبقى التسميات القديمة في خصائص المستند المخصصة بينما تتوفر التسميات الحديثة عبر [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sensitivity_labels/). استخدم [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) لقراءة البيانات القديمة وترحيل التسميات الصالحة فقط التي ليست موجودة بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما تُضاف تسمية بنفس المعرف أكثر من مرة؟**

تُطلق [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabelcollection/add/) استثناءً عندما تحتوي المجموعة بالفعل على تسمية بنفس المعرف. تحقق من قيم [SensitivityLabel.id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sensitivitylabel/id/) الموجودة قبل إضافة أو ترحيل التسميات.

**ما صيغة الإخراج التي يجب استخدامها للحفاظ على تسميات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX باستدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) مع [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/)، كما هو موضح في الأمثلة أعلاه.