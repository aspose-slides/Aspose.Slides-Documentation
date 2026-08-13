---
title: إدارة تسميات الحساسية في عروض PowerPoint التقديمية باستخدام C++
linktitle: تسميات الحساسية
type: docs
weight: 50
url: /ar/cpp/sensitivity-labels/
keywords:
- تسمية حساسية
- Microsoft Purview
- حماية معلومات Microsoft
- بيانات تعريف MIP
- علامات المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العرض التقديمي
- C++
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل تسميات الحساسية من Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تساعد تسميات الحساسية في Microsoft Purview المؤسسات على تصنيف الوثائق وإدارتها. أثناء معالجة العرض التقديمي تلقائيًا، قد تحتاج التطبيق إلى الحفاظ على تسمية موجودة، أو تطبيق تسمية مختارة وفقًا لسياسة، أو تحديث حالتها، أو ترحيل بيانات التعريف الخاصة بالتسمية المكتوبة بواسطة سير عمل Microsoft Information Protection (MIP) الأقدم.

تقوم Aspose.Slides بالكشف عن بيانات التعريف الحديثة لتسميات الحساسية من خلال [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). تُعيد هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/) التي يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="info" title="Note" %}}
معرفات تسميات الحساسية ومعلومات السياسة يتم تعريفها بواسطة إعدادات Microsoft Purview الخاصة بك. تحقق من توفر التسميات ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل بيانات التعريف. القيم في [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) تصف العلامات المحتوى المرتبطة بتسمية؛ فهي لا تضيف نصًا أو أشكالًا مرئية إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص تسميات الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) يحتوي على بيانات التعريف التالية:

| الوصلات | الغرض |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_id/) | تحديد تسمية الحساسية في سياسة Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_siteid/) | تحديد الموقع المرتبط بسياسة التسمية. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | الإشارة إلى ما إذا كانت التسمية مفعلة. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | الإشارة إلى أن التسمية قد أزيلت. اضبط القيمة إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في بيانات التعريف. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | تحديد ما إذا تم تطبيق التسمية تلقائيًا أو عبر قرار المستخدم. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | قائمة بأنواع العلامات المحتوى المرتبطة بالتسمية. |

تصف تعداد [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين التسمية:

- `[SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/)` يمثل تسمية افتراضية أو تم تطبيقها تلقائيًا.
- `[SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/)` يمثل تسمية تم تطبيقها عبر قرار المستخدم، بما في ذلك التسمية المطبقة يدويًا، الموصى بها، والملزمة.

يحدد تعداد [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالتسمية:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التسمية افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | يتم ربط علامة محتوى الرأس بالتسمية. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | يتم ربط علامة محتوى التذييل بالتسمية. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | يتم ربط علامة محتوى العلامة المائية بالتسمية. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | يتم ربط حماية التشفير بالتسمية. |

يمكن ربط أنواع علامات متعددة بتسمية واحدة.

## **قائمة التسميات الحساسة الموجودة**

اقرأ مجموعة التسميات الحديثة من [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) وقم بترقيمها. يوضح المثال التالي كل خاصية وعلامة محتوى مخزنة لكل تسمية:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **إضافة تسمية حساسية مع علامة محتوى**

استخدم [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/) مع معرف التسمية، معرف الموقع، الحالة المفعلة، وطريقة التعيين. بعد أن ترجّع الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

يضيف المثال التالي تسمية مختارة يدويًا مرتبطة بعلامات التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تحديث تسمية حساسية**

يمكن قراءة/كتابة قيم [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) عبر أساليب getter وsetter الخاصة بها، باستثناء أن المجموعة التي تُرجعها [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) تُعدل عبر عمليات القائمة. بعد العثور على التسمية المطلوبة، يمكنك تحديث معرفها، معرف الموقع، الحالة المفعلة، طريقة التعيين، حالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتطبيق التغييرات.

يُظهر المثال التالي تحديث الحالة المفعلة وطريقة التعيين للتسمية الأولى:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **وضع علامة على تسمية الحساسية كملغاة**

لحفظ حقيقة أن التسمية قد أزيلت، ابحث عن التسمية واستدعِ [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) مع `true`. هذا يحتفظ بمدخل التسمية مع تسجيل حالة الإزالة. إذا كنت تحتاج بدلاً من ذلك إلى حذف مدخل من المجموعة الحديثة، استخدم [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/removeat/)؛ واستخدم [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/clear/) لحذف جميع المدخلات.

المثال التالي يضع علامة على تسمية محددة كملغاة ويحفظ العرض التقديمي المحدث:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **قراءة وترحيل تسميات الحساسية القديمة من MIP**

يمكن لسير العمل القائم على MIP القديم تخزين بيانات تعريف تسميات الحساسية في خصائص المستند المخصصة بدلاً من مجموعة التسميات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتعيد مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) .

لترحيل بيانات التعريف، أضف كل تسمية مسترجعة إلى مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/). نظرًا لأن إضافة معرف تسمية مكرر يرفع استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تسمية. يمكنك إضافة مزيد من التحقق للتأكد من أن كل تسمية قديمة لا تزال موجودة في سياسة Purview الحالية.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تنقل العملية كائنات التسمية التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب ذلك مسح جميع خصائص المستند المخصصة، لذا تبقى بيانات التعريف غير المتعلقة بالمستند سليمة. استخدم [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) لكتابة بيانات تعريف التسميات الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل يؤدي إضافة نوع علامة محتوى إلى إنشاء رأس أو تذييل أو علامة مائية مرئية على الشرائح؟**

لا. القيم التي تُضاف عبر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) تصف العلامات المرتبطة بتسمية الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. قم بإضافة محتوى الشريحة المقابل بشكل منفصل إذا كان سير عملك يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة على التسمية كملغاة وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) مع `true` يحتفظ بمدخل التسمية ويسجل حالة الإزالة. استدعاء [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/removeat/) يحذف المدخل من المجموعة الحديثة. اختر العملية التي تتطابق مع متطلبات مؤسستك بشأن الاحتفاظ ببيانات التعريف.

**هل يمكن للعرض التقديمي أن يحتوي على كل من بيانات تعريف MIP القديمة وتسميات الحساسية الحديثة؟**

نعم. يمكن أن تبقى التسميات القديمة في خصائص المستند المخصصة بينما تكون التسميات الحديثة متاحة عبر [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). استخدم [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) لقراءة بيانات التعريف القديمة وترحيل التسميات الصالحة فقط التي ليست موجودة بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما تتم إضافة تسمية بنفس المعرف أكثر من مرة؟**

تُطلق [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/) استثناءً من نوع ArgumentException عندما تكون المجموعة تحتوي بالفعل على تسمية بنفس المعرف. تحقق من قيم [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_id/) الحالية قبل إضافة أو ترحيل التسميات.

**أي تنسيق إخراج يجب استخدامه للحفاظ على تسميات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX عن طريق استدعاء [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/)، كما هو موضح في الأمثلة أعلاه.