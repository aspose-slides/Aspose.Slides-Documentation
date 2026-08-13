---
title: إدارة علامات الحساسية في عروض PowerPoint التقديمية في .NET
linktitle: علامات الحساسية
type: docs
weight: 50
url: /ar/net/sensitivity-labels/
keywords:
- علامة حساسية
- Microsoft Purview
- حماية المعلومات من Microsoft
- بيانات تعريف MIP
- تمييز المحتوى
- حماية المعلومات
- حوكمة الوثائق
- PowerPoint
- PPTX
- أمان العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل علامات الحساسية في Microsoft Purview في عروض PowerPoint PPTX باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تساعد علامات الحساسية في Microsoft Purview المؤسسات على تصنيف الوثائق وإدارتها. أثناء معالجة العرض التقديمي الآلي، قد تحتاج التطبيقات إلى الحفاظ على علامة موجودة، أو تطبيق علامة مختارة وفق سياسة، أو تحديث حالتها، أو ترحيل بيانات تعريف العلامة التي كتبها سير عمل Microsoft Information Protection (MIP) أقدم.

تكشف Aspose.Slides عن بيانات تعريف علامات الحساسية الحديثة من خلال [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/). تُرجع هذه الخاصية مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض كملف PPTX.

{{% alert color="info" title="ملاحظة" %}}
محددات هوية علامة الحساسية ومعلومات السياسة معرفة وفق تكوين Microsoft Purview الخاص بك. تحقق من توافر العلامة ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات. قيم [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) تصف علامات المحتوى المرتبطة بالعلامة؛ ولا تُضيف نصاً أو أشكالاً مرئية إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص علامة الحساسية**

كل كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) يحتوي على بيانات التعريف التالية:

| الخاصية | الغرض |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/id/) | يحدد هوية علامة الحساسية في سياسة Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/siteid/) | يحدد الموقع المرتبط بسياسة العلامة. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isenabled/) | يوضح ما إذا كانت العلامة مفعّلة. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) | يشير إلى أن العلامة قد أُزيلت. اضبط هذه الخاصية إلى `true` عندما يلزم الاحتفاظ بحالة الإزالة في بيانات التعريف. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | يحدد ما إذا تم تطبيق العلامة تلقائيًا أو عبر قرار المستخدم. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) | يسرد أنواع علامات المحتوى المرتبطة بالعلامة. |

توصف تعدادات [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين العلامة:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) يمثل علامة افتراضية أو مُطَبَّقة تلقائيًا.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) يمثل علامة مطبقة عبر قرار المستخدم، بما في ذلك العلامات المطبقة يدويًا، الموصى بها، والإلزامية.

تحدد تعدادات [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالعلامة:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق العلامة افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم ربط علامة محتوى رأس بالعلامة. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم ربط علامة محتوى تذييل بالعلامة. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم ربط علامة محتوى علامة مائية بالعلامة. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم ربط حماية تشفير بالعلامة. |

يمكن ربط عدة أنواع من العلامات بمعلمة واحدة.

## **قائمة علامات الحساسية الموجودة**

قرأ مجموعة العلامات الحديثة من [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/) وعدها. يوضح المثال التالي كل خاصية وعلامة محتوى مخزَّنة لكل علامة:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **إضافة علامة حساسية مع تمييز المحتوى**

استخدم [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/) مع معرف العلامة، معرف الموقع، حالة التفعيل، وطريقة التعيين. بعد أن تُرجع الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) جديد، أضف قيم العلامات المطلوبة عبر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/).

المثال التالي يضيف علامة مختارة يدويًا مرتبطة بتمييز التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **تحديث علامة حساسية**

خصائص [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) قابلة للقراءة والكتابة، باستثناء المجموعة التي تُرجعها [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) حيث تُعدل عبر عمليات القائمة. بعد تحديد العلامة المطلوبة، يمكنك تحديث معرفها، معرف الموقع، حالة التفعيل، طريقة التعيين، حالة الإزالة، وأنواع علامات المحتوى. احفظ العرض لتثبيت التغييرات.

المثال التالي يُحدِّث حالة التفعيل وطريقة التعيين للعلامة الأولى:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **وضع علامة حساسية كقُمّيت بالإزالة**

للاحتفاظ بحقيقة أن علامة ما أُزيلت، ابحث عن العلامة واضبط [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) إلى `true`. سيبقى الإدخال موجودًا مع تسجيل حالته كـمُزالة. إذا رغبت في حذف الإدخال من المجموعة الحديثة، استخدم [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/removeat/); استخدم [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/clear/) لحذف جميع الإدخالات.

المثال التالي يضع علامة محددة كـمُزالة ويحفظ العرض المحدث:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **قراءة وترحيل علامات الحساسية القديمة في MIP**

يمكن لسير عمل MIP القديم تخزين بيانات تعريف علامة الحساسية في خصائص وثيقة مخصصة بدلاً من مجموعة العلامات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/getsensitivitylabels/). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتُرجع مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/).

لترحيل البيانات، أضِف كل علامة تم إرجاعها إلى مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/). لأن إضافة معرف علامة مكرر يسبب استثناءً، يتحقق المثال من المجموعة الهدف قبل نسخ كل علامة. يمكنك إضافة تحقق إضافي للتأكد من أن كل علامة قديمة لا تزال موجودة في سياسة Purview الحالية.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

الترحيل ينسخ كائنات العلامات التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب مسح جميع خصائص الوثيقة المخصصة، لذا تظل بيانات التعريف غير المتعلقة بالوثيقة كما هي. استخدم [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) لكتابة بيانات تعريف العلامات الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل إنشاء نوع علامة محتوى يؤدي إلى ظهور رأس أو تذييل أو علامة مائية مرئية على الشرائح؟**  
لا. القيم المضافة عبر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) تصف العلامات المرتبطة بعلامة الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض. أضف محتوى الشريحة المناسب منفصلًا إذا كان سير عملك يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة كـمُزالة وحذفها من المجموعة؟**  
تعيين [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) إلى `true` يحتفظ بإدخال العلامة ويسجل حالتها كـمُزالة. استدعاء [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/removeat/) يحذف الإدخال من المجموعة الحديثة. اختر العملية التي تتماشى مع متطلبات احتفاظ مؤسستك ببيانات التعريف.

**هل يمكن للعرض أن يحتوي على بيانات تعريف MIP القديمة وعلامات الحساسية الحديثة معًا؟**  
نعم. يمكن أن تبقى العلامات القديمة في خصائص الوثيقة المخصصة بينما تكون العلامات الحديثة متاحة عبر [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/). استخدم [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/getsensitivitylabels/) لقراءة البيانات القديمة وترحيل العلامات الصالحة التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما تُضاف علامة بنفس المعرف أكثر من مرة؟**  
[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/) يطرح استثناءً من نوع `ArgumentException` عندما تحتوي المجموعة بالفعل على علامة بنفس المعرف. تحقق من قيم [ISensitivityLabel.Id](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/id/) الموجودة قبل الإضافة أو الترحيل.

**أي تنسيق إخراج يجب استخدامه للحفاظ على علامات الحساسية المحدثة؟**  
احفظ العرض كملف PPTX باستدعاء [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/)، كما هو موضح في الأمثلة أعلاه.