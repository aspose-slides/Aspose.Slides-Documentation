---
title: إدارة تسميات الحساسية في عروض PowerPoint التقديمية في .NET
linktitle: تسميات الحساسية
type: docs
weight: 50
url: /ar/net/sensitivity-labels/
keywords:
- تسمية حساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات MIP الوصفية
- وضع علامة المحتوى
- حماية المعلومات
- حوكمة المستند
- PowerPoint
- PPTX
- أمان العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "قراءة، إضافة، تحديث، إزالة، وترحيل تسميات الحساسية في Microsoft Purview داخل عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تساعد تسميات الحساسية في Microsoft Purview المؤسسات على تصنيف المستندات وإدارتها. أثناء معالجة العرض التقديمي بشكل آلي، قد يحتاج التطبيق إلى الحفاظ على تسمية موجودة، أو تطبيق تسمية مختارة بواسطة سياسة، أو تحديث حالتها، أو ترحيل بيانات تسمية مكتوبة بواسطة سير عمل Microsoft Information Protection (MIP) أقدم.

Aspose.Slides تعرِض بيانات تعريف تسميات الحساسية الحديثة من خلال [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/). تُرجع هذه الخاصية مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="primary" title="Note" %}}
معرفات تسميات الحساسية ومعلومات السياسة تُعرَّف وفق إعدادات Microsoft Purview الخاصة بك. والتحقق من توفر التسميات ومتطلبات السياسات في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) تصف علامات المحتوى المرتبطة بالتسمية؛ ولا تُضيف بنفسها نصًا أو أشكالًا مرئية إلى الشرائح.
{{% /alert %}}

## **فهم خصائص تسمية الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الخاصية | الغرض |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/id/) | يحدد تسمية الحساسية في سياسة Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/siteid/) | يحدد الموقع المرتبط بسياسة التسمية. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isenabled/) | يشير إلى ما إذا كانت التسمية ممكّنة. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) | يشير إلى أن التسمية قد تمت إزالتها. اضبط هذه الخاصية إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | يحدد ما إذا تم تطبيق التسمية تلقائيًا أو عبر قرار المستخدم. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) | يسرد أنواع العلامات المحتوى المرتبطة بالتسمية. |

تصف تعداد [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) طريقة تعيين التسمية:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية افتراضية أو تم تطبيقها تلقائيًا.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية تم تطبيقها عبر قرار المستخدم، بما في ذلك التسميات المطبقة يدويًا، والمقترحة، والإلزامية.

تحديد تعداد [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) للعلامة المرتبطة بالتسمية:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التسمية بشكل افتراضي أو تلقائي. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى الرأس مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى التذييل مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى العلامة المائية مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/net/aspose.slides/sensitivitylabelcontenttype/) | الحماية بالتشفير مرتبطة بالتسمية. |

يمكن ربط أنواع علامات متعددة بتسمية واحدة.

## **قائمة تسميات الحساسية الموجودة**

اقرأ مجموعة التسميات الحديثة من [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/) وعدها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزّنة لكل تسمية:

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

## **إضافة تسمية حساسية مع علامة محتوى**

استخدم [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/) مع معرف التسمية، ومعرف الموقع، وحالة التمكين، وطريقة التعيين. بعد أن تُعيد الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) جديد، أضف قيم العلامات المطلوبة عبر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/).

المثال التالي يضيف تسمية مختارة يدويًا مرتبطة بعلامتي تذييل وعلامة مائية، ثم يحفظ النتيجة كملف PPTX:

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

## **تحديث تسمية حساسية**

خصائص [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/) قابلة للقراءة/الكتابة، باستثناء أن المجموعة التي تُرجعها [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) تُعدّل عبر عمليات القائمة الخاصة بها. بعد العثور على التسمية المطلوبة، يمكنك تحديث معرفها، ومعرف الموقع، وحالة التمكين، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يحدّث حالة التمكين وطريقة التعيين للتسمية الأولى:

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

## **وضع علامة على تسمية الحساسية كمزالة**

للحفاظ على حقيقة إزالة التسمية، اعثر على التسمية واضبط [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) إلى `true`. هذا يحتفظ بمدخل التسمية مع تسجيل حالتها كمنزالة. إذا كنت تحتاج إلى حذف مدخل من المجموعة الحديثة، استخدم [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/removeat/)؛ واستخدم [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/clear/) لحذف جميع المدخلات.

المثال التالي يضع علامة على تسمية محددة كمزالة ويحفظ العرض المحدث:

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

## **قراءة وترحيل تسميات الحساسية القديمة الخاصة بـ MIP**

يمكن لسير العمل القائم على MIP القديم تخزين بيانات تعريف تسميات الحساسية في خصائص مستند مخصصة بدلًا من مجموعة التسميات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/getsensitivitylabels/). الطريقة تحلل الخصائص المخصصة القديمة وتُرجع مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل تسمية مُسترجعة إلى [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/). نظرًا لأن إضافة معرف تسمية مكرر يثير استثناء، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تسمية. يمكنك إضافة مزيد من التحقق للتأكد من أن كل تسمية قديمة لا تزال موجودة في سياسة Purview الحالية.

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

الترحيل ينسخ كائنات التسميات المُحللة إلى المجموعة الحديثة. لا يتطلب مسح جميع خصائص المستند المخصصة، لذا تظل البيانات الوصفية غير المتعلقة بالمستند سليمة. استخدم [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) لكتابة بيانات تعريف التسميات الحديثة إلى ملف PPTX.

## **الأسئلة الشائعة**

**هل إنشاء نوع علامة محتوى يضيف رأسًا أو تذييلًا أو علامة مائية مرئية على الشرائح؟**

لا. القيم المضافة عبر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/contentmarktypes/) تصف العلامات المرتبطة بتسمية الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف محتوى الشريحة المقابل بشكل منفصل إذا كان سير عملك يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة على التسمية كمزالة وحذفها من المجموعة؟**

ضبط [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/isremoved/) إلى `true` يبقي مدخل التسمية ويسجل حالتها كمنزالة. استدعاء [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/removeat/) يحذف المدخل من المجموعة الحديثة. اختر العملية التي تتوافق مع متطلبات مؤسستك للاحتفاظ بالبيانات الوصفية.

**هل يمكن للعرض التقديمي احتواء كل من بيانات MIP القديمة وتسميات الحساسية الحديثة؟**

نعم. يمكن أن تبقى التسميات القديمة في خصائص المستند المخصصة بينما تكون التسميات الحديثة متوفرة عبر [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sensitivitylabels/). استخدم [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/getsensitivitylabels/) لقراءة البيانات القديمة وترحيل التسميات الصالحة فقط التي لم توجد مسبقًا في المجموعة الحديثة.

**ماذا يحدث عندما يُضاف معرف تسمية مكرر أكثر من مرة؟**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabelcollection/add/) يرمي `ArgumentException` عندما تحتوي المجموعة مسبقًا على تسمية بنفس المعرف. تحقق من قيم [ISensitivityLabel.Id](https://reference.aspose.com/slides/ar/net/aspose.slides/isensitivitylabel/id/) الموجودة قبل الإضافة أو الترحيل.

**ما هو تنسيق الإخراج الذي يُجب استخدامها للحفاظ على تسميات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX باستدعاء [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/)، كما هو موضح في الأمثلة أعلاه.