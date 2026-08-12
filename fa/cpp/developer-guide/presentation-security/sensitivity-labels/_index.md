---
title: مدیریت برچسب‌های حساسیت در ارائه‌های پاورپوینت با C++
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/cpp/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- علامت‌گذاری محتوا
- حفاظت از اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- C++
- Aspose.Slides
description: "برچسب‌های حساسیت Microsoft Purview را در ارائه‌های PPTX پاورپوینت بخوانید، اضافه، به‌روز کنید، حذف کنید و منتقل کنید با Aspose.Slides برای C++."
---
## **بررسی کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کنند اسناد را دسته‌بندی و حاکمیت کنند. در حین پردازش خودکار ارائه، برنامه ممکن است نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط یک سیاست انتخاب شده است اعمال کند، وضعیت آن را به‌روزرسانی کند، یا فراداده برچسب نوشته‌شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را منتقل کند.

Aspose.Slides متادیتای برچسب حساسیت مدرن را از طریق [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان آن را قبل از ذخیره ارائه به‌عنوان PPTX بررسی و اصلاح کرد.

{{% alert color="primary" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. پیش از افزودن یا انتقال متادیتا، در محیط خود در دسترس بودن برچسب‌ها و الزامات سیاست را تأیید کنید. مقادیر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) توصیف‌کنندهٔ علامت‌های محتوا مرتبط با یک برچسب هستند؛ آن‌ها به تنهایی متن یا اشکالی قابل مشاهده بر روی اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) شامل متادیتای زیر است:

| دستورات دسترسی | هدف |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_id/) | شناسا‌گر برچسب حساسیت در سیاست Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_siteid/) | شناسا‌گر سایت مرتبط با سیاست برچسب. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | نشان می‌دهد آیا برچسب فعال است یا خیر. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | نشان می‌دهد برچسب حذف شده است. مقدار را به `true` تنظیم کنید زمانی که وضعیت حذف باید در متادیتا نگه داشته شود. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | مشخص می‌کند برچسب به صورت خودکار یا توسط تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | فهرست انواع علامت‌گذاری محتوا مرتبط با برچسب. |

شمارش [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelassignmenttype/) توصیف می‌کند برچسب چگونه اختصاص داده شده است:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelassignmenttype/) برچسب پیش‌فرض یا اعمال‌شده به‌صورت خودکار را نشان می‌دهد.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelassignmenttype/) برچسبی را نشان می‌دهد که از طریق تصمیم کاربر اعمال شده است، شامل برچسب‌های دستی، پیشنهادی و اجباری.

شمارش [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) علامت‌گذاری مرتبط با برچسب را شناسایی می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در سرصفحه مرتبط با برچسب است. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در پاصفحه مرتبط با برچسب است. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در واترمارک مرتبط با برچسب است. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sensitivitylabelcontenttype/) | محافظت رمزنگاری مرتبط با برچسب است. |

چندین نوع علامت‌گذاری می‌توانند به یک برچسب مرتبط باشند.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) بخوانید و آن را مرور کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

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

## **افزودن برچسب حساسیت با علامت‌گذاری محتوا**

از [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از اینکه متد برچسب جدید [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) را بازگرداند، مقادیر علامت‌گذاری مورد نیاز را از طریق [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) اضافه کنید.

مثال زیر برچسبی را که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پاصفحه و واترمارک مرتبط است، اضافه می‌کند و سپس نتیجه را به‌عنوان PPTX ذخیره می‌کند:

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

## **به‌روزرسانی برچسب حساسیت**

مقادیر [ISensitivityLabel] از طریق متدهای getter و setter قابل خواندن/نوشتن هستند، به‌جز این‌که مجموعه‌ای که توسط [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) برگردانده می‌شود از طریق عملیات لیست آن اصلاح می‌گردد. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. برای ثابت نگه داشتن تغییرات، ارائه را ذخیره کنید.

مثال زیر وضعیت فعال بودن و روش اختصاص اولین برچسب را به‌روزرسانی می‌کند:

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

## **علامت‌گذاری برچسب حساسیت به عنوان حذف شده**

برای حفظ این واقعیت که برچسبی حذف شده است، برچسب را پیدا کنید و با مقدار `true` متد [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) را فراخوانی کنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف ورودی از مجموعه مدرن دارید، از [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/removeat/) استفاده کنید؛ برای حذف تمام ورودی‌ها از [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/clear/) استفاده کنید.

مثال زیر یک برچسب خاص را به عنوان حذف شده علامت‌گذاری کرده و ارائه به‌روزرسانی‌شده را ذخیره می‌کند:

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

## **خواندن و انتقال برچسب‌های حساسیت Legacy MIP**

گردش کارهای مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به‌جای مجموعه برچسب مدرن ذخیره کنند. آن متادیتا را با [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیای [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای انتقال متادیتا، هر برچسب بازگردانده‌شده را از طریق [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) به [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/) مدرن اضافه کنید. چون افزودن شناسه برچسب تکراری منجر به استثنا می‌شود، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری اضافه کنید تا تأیید کنید هر برچسب Legacy هنوز در سیاست Purview فعلی موجود است.

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

انتقال، اشیای برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. این کار نیازی به پاک‌سازی تمام ویژگی‌های سفارشی سند ندارد، بنابراین متادیتای غیرمرتبط سند دست‌نخورده می‌ماند. برای نوشتن متادیتای برچسب مدرن به یک فایل PPTX از [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) استفاده کنید.

## **سوالات متداول**

**آیا افزودن یک نوع علامت‌گذاری محتوا یک سرصفحه، پاصفحه یا واترمارک قابل مشاهده روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) اضافه می‌شوند، توصیف‌کنندهٔ علامت‌های مرتبط با برچسب حساسیت هستند. آن‌ها متن یا اشکال قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز به رندر کردن این علامت‌ها دارد، محتویات مربوط به اسلاید را جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به عنوان حذف شده و حذف آن از مجموعه چه‌ست؟**

فراخوانی [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) با مقدار `true` ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. فراخوانی [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/removeat/) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با الزامات نگهداری متادیتای سازمان شما مطابقت داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP Legacy و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های Legacy می‌توانند در ویژگی‌های سفارشی سند باقی بمانند در حالی که برچسب‌های مدرن از طریق [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) قابل دسترسی هستند. از [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) برای خواندن متادیتای Legacy استفاده کنید و فقط برچسب‌های معتبر که قبلاً در مجموعه مدرن وجود ندارند را منتقل کنید.

**وقتی یک برچسب با همان شناسه بیش از یک‌بار اضافه شود چه اتفاقی می‌افتد؟**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) هنگامیکه مجموعه از پیش شامل برچسبی با همان شناسه باشد، یک استثنای آرگومان پرتاب می‌کند. قبل از افزودن یا انتقال برچسب‌ها، مقادیر [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_id/) موجود را بررسی کنید.

**کدام فرمت خروجی باید برای حفظ برچسب‌های حساسیت به‌روزرسانی‌شده استفاده شود؟**

ارائه را به‌عنوان PPTX ذخیره کنید با فراخوانی [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شده است.