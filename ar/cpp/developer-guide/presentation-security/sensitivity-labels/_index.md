---
title: إدارة تسميات الحساسية في عروض PowerPoint التقديمية باستخدام C++
linktitle: تسميات الحساسية
type: docs
weight: 50
url: /ar/cpp/sensitivity-labels/
keywords:
- تسمية حساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات تعريف MIP
- علامة المحتوى
- حماية المعلومات
- حوكمة المستند
- PowerPoint
- PPTX
- أمان العرض التقديمي
- C++
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل تسميات الحساسية من Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تساعد تسميات الحساسية في Microsoft Purview المنظمات على تصنيف المستندات وحكمها. أثناء معالجة العروض التقديمية تلقائيًا، قد تحتاج التطبيقات إلى الحفاظ على تسمية موجودة، أو تطبيق تسمية مختارة وفق سياسة، أو تحديث حالتها، أو ترحيل بيانات تعريف التسمية التي كتبها سير عمل Microsoft Information Protection (MIP) أقدم.

توفر Aspose.Slides بيانات تعريف التسميات الحديثة عبر [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). تُعيد هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي بصيغة PPTX.

{{% alert color="primary" title="Note" %}}
معرفات تسميات الحساسية ومعلومات السياسة تُعرَّف حسب إعداد Microsoft Purview الخاص بك. تحقق من توفر التسمية ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات التعريفية. قيم [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) تصف العلامات المرتبطة بالتسمية؛ وهي لا تضيف نصًا أو أشكالًا مرئية إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص تسميات الحساسية**

كل كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) يحتوي على البيانات التعريفية التالية:

| Accessors | Purpose |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_id/) | تحديد تسمية الحساسية في سياسة Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_siteid/) | تحديد الموقع المرتبط بسياسة التسمية. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | الإشارة إلى ما إذا كانت التسمية مفعَّلة. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | الإشارة إلى أن التسمية قد أُزيلت. ضع القيمة `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات التعريفية. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | تحديد ما إذا تم تطبيق التسمية تلقائيًا أو عبر قرار المستخدم. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | سرد أنواع العلامات المحتوى المرتبطة بالتسمية. |

تصف تعداد [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/) كيفية إسناد التسمية:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية افتراضية أو مُطبَّقة تلقائيًا.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelassignmenttype/) يمثل تسمية مُطبَّقة عبر قرار المستخدم، بما في ذلك التسميات المُطبَّقة يدويًا، المقترحة، والفرضية.

تحدد تعداد [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالتسمية:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التسمية افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى رأسية مرتبطة بالتسمية. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى تذييل مرتبطة بالتسمية. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى علامة مائية مرتبطة بالتسمية. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sensitivitylabelcontenttype/) | توجد حماية تشفير مرتبطة بالتسمية. |

يمكن ربط أنواع علامات متعددة بتسمية واحدة.

## **قائمة تسميات الحساسية الموجودة**

اقرأ مجموعة التسميات الحديثة من [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) وقم بتعدادها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزّنة لكل تسمية:

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

استخدم [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/) مع معرف التسمية، ومعرف الموقع، وحالة التفعيل، وطريقة الإسناد. بعد عودة الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

المثال التالي يضيف تسمية مختارة يدويًا مرتبطة بعلامات تذييل وعلامة مائية، ثم يحفظ النتيجة بصيغة PPTX:

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

قِيَم [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/) قابلة للقراءة والكتابة عبر طُرُق getter وsetter الخاصة بها، باستثناء المجموعة التي تُعيدها [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) حيث تُعدَّل عبر عمليات القائمة. بعد تحديد التسمية المطلوبة، يمكنك تحديث معرفها، ومعرف الموقع، وحالة التفعيل، وطريقة الإسناد، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يُحدِّث حالة التفعيل وطريقة الإسناد للتسمية الأولى:

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

## **وضع علامة إزالة على تسمية حساسية**

للحفاظ على حقيقة أن التسمية قد أزيلت، ابحث عن التسمية واستدعِ [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) مع `true`. هذا يُبقي سجل التسمية مع تسجيل حالة الإزالة. إذا كنت بحاجة إلى حذف السجل من المجموعة الحديثة، استخدم [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/removeat/); واستخدم [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/clear/) لحذف جميع السجلات.

المثال التالي يضع علامة إزالة على تسمية محددة ويُحفظ العرض المحدث:

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

يمكن لسير العمل القائم على MIP الأقدم تخزين بيانات تعريف تسميات الحساسية في خصائص المستند المخصصة بدلاً من مجموعة التسميات الحديثة. اقرأ تلك البيانات عبر [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتُعيد مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/).

لترحيل البيانات، أضف كل تسمية مُستلمة إلى مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/). بما أن إضافة معرف تسمية مكرر يُثير استثناءً، يتحقق المثال من وجود المجموعة الهدف قبل نسخ كل تسمية. يمكنك إضافة مزيد من التحقق لتأكيد أن كل تسمية قديمة لا تزال موجودة في سياسة Purview الحالية.

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

الترحيل ينسخ كائنات التسميات التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب مسح جميع خصائص المستند المخصصة، وبالتالي تظل البيانات التعريفية غير المتعلقة بالمستند سليمة. استخدم [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) لكتابة بيانات تعريف التسميات الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل إنشاء نوع علامة محتوى يضيف رأسًا أو تذيلاً أو علامة مائية مرئية إلى الشرائح؟**

لا. القيم المضافة عبر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) تصف العلامات المرتبطة بتسمية الحساسية. هي لا تنشئ نصًا أو أشكالًا مرئية في العرض. أضف محتوى الشريحة المناسب بشكل منفصل إذا كان سير عملك يتطلب إظهار تلك العلامات.

**ما الفرق بين وضع علامة إزالة على تسمية وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/set_isremoved/) مع `true` يُبقي سجل التسمية ويسجل حالة الإزالة. استدعاء [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/removeat/) يحذف السجل من المجموعة الحديثة. اختر العملية التي تتماشى مع متطلبات احتفاظ مؤسستك بالبيانات التعريفية.

**هل يمكن للعرض التقديمي أن يحتوي على بيانات تعريف MIP القديمة وتسميات حساسية حديثة في آنٍ واحد؟**

نعم. يمكن أن تظل التسميات القديمة في خصائص المستند المخصصة بينما تكون التسميات الحديثة متاحة عبر [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). استخدم [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) لقراءة البيانات القديمة وترحيل التسميات الصالحة التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث إذا أضيفت تسمية بنفس المعرف أكثر من مرة؟**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabelcollection/add/) يرمي استثناءً من نوع ArgumentException عندما تحتوي المجموعة مسبقًا على تسمية بنفس المعرف. تحقق من قيم [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isensitivitylabel/get_id/) الموجودة قبل الإضافة أو الترقي.

**أي تنسيق إخراج يجب استخدامه للحفاظ على تسميات الحساسية المحدثة؟**

احفظ العرض بصيغة PPTX عن طريق استدعاء [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/)، كما هو موضح في الأمثلة أعلاه.