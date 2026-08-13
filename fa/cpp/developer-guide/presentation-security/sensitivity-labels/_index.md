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
- پاورپوینت
- PPTX
- امنیت ارائه
- C++
- Aspose.Slides
description: "برچسب‌های حساسیت Microsoft Purview را در ارائه‌های PowerPoint با فرمت PPTX می‌خوانید، اضافه می‌کنید، به‌روزرسانی می‌کنید، حذف می‌کنید و مهاجرت می‌کنید با Aspose.Slides برای C++."
---
## **نگاهی کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در حین پردازش خودکار ارائه، ممکن است یک برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی را که توسط سیاست انتخاب شده اعمال کند، وضعیت آن را به‌روزرسانی کند، یا متادیتای برچسب نوشته شده توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) را مهاجرت دهد.

Aspose.Slides متادیتای برچسب حساسیت مدرن را از طریق [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) فراهم می‌کند. این متد یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به‌صورت PPTX آن را بررسی و اصلاح کرد.

{{% alert color="info" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. پیش از افزودن یا مهاجرت متادیتا، در محیط خود در دسترس بودن برچسب‌ها و نیازهای سیاست را تأیید کنید. مقادیر [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) توصیف‌کننده علامت‌گذاری‌های محتوا مرتبط با برچسب هستند؛ آنها به تنهایی متن یا شکل‌های قابل‌مشاهده‌ای به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) شامل متادیتاهای زیر است:

| دسترس‌پذیرها | هدف |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_id/) | شناسه برچسب حساسیت در سیاست Purview را شناسایی می‌کند. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_siteid/) | سایت مرتبط با سیاست برچسب را شناسایی می‌کند. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | مشخص می‌کند آیا برچسب فعال است یا خیر. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | مشخص می‌کند برچسب حذف شده است. زمانی که حالت حذف باید در متادیتا نگهداری شود، مقدار را به `true` تنظیم کنید. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | مشخص می‌کند آیا برچسب به صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | فهرست انواع علامت‌گذاری محتوا مرتبط با برچسب را ارائه می‌دهد. |

شمارش SensitivityLabelAssignmentType نحوه اختصاص برچسب را توصیف می‌کند:

- SensitivityLabelAssignmentType::Standard یک برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده را نشان می‌دهد.
- SensitivityLabelAssignmentType::Privileged برچسبی است که از طریق تصمیم کاربر اعمال شده است، شامل برچسب‌های دستی، پیشنهادی و اجباری.

شمارش SensitivityLabelContentType علامت‌گذاری مرتبط با برچسب را شناسایی می‌کند:

| مقدار | معنی |
| --- | --- |
| SensitivityLabelContentType::None | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| SensitivityLabelContentType::Header | علامت‌گذاری محتوا در سرصفحه با این برچسب مرتبط است. |
| SensitivityLabelContentType::Footer | علامت‌گذاری محتوا در پاورقی با این برچسب مرتبط است. |
| SensitivityLabelContentType::Watermark | علامت‌گذاری محتوا در واترمارک با این برچسب مرتبط است. |
| SensitivityLabelContentType::Encryption | حفاظت رمزنگاری با این برچسب مرتبط است. |

چندین نوع علامت‌گذاری می‌توانند به یک برچسب مرتبط شوند.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از طریق [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) خوانده و آن را مرور کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

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

از [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال و روش اختصاص استفاده کنید. پس از بازگشت این متد، برچسب جدید [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) دریافت می‌شود؛ سپس مقادیر علامت‌گذاری مورد نیاز را از طریق [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) اضافه کنید.

مثال زیر برچسبی را که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پاورقی و واترمارک مرتبط است، اضافه می‌کند و سپس نتیجه را به‌صورت PPTX ذخیره می‌نماید:

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

مقادیر [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) از طریق متدهای getter و setter آن‌ها قابل خواندن/نوشتن هستند، به جز مجموعه‌ای که توسط [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) برگردانده می‌شود که از طریق عملیات لیست آن قابل تغییر است. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. برای نگهداری تغییرات ارائه را ذخیره کنید.

مثال زیر وضعیت فعال و روش اختصاص برچسب اول را به‌روزرسانی می‌کند:

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

## **نشانه‌گذاری برچسب حساسیت به‌عنوان حذف‌شده**

برای نگه‌داشتن این‌که یک برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) را با مقدار `true` صدا بزنید. این کار ورودی برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن نیاز به حذف یک ورودی از مجموعه مدرن دارید، از [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/removeat/) استفاده کنید؛ برای حذف همه ورودی‌ها از [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/clear/) استفاده کنید.

مثال زیر یک برچسب خاص را به‌عنوان حذف‌شده علامت‌گذاری می‌کند و ارائه به‌روز شده را ذخیره می‌نماید:

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

## **خواندن و مهاجرت برچسب‌های حساسیت قدیمی MIP**

جریان‌های کاری قدیمی مبتنی بر MIP می‌توانند متادیتای برچسب حساسیت را در ویژگی‌های سفارشی سند به‌جای مجموعه برچسب مدرن ذخیره کنند. این متادیتا را با استفاده از [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیای [ISensitivityLabel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای مهاجرت متادیتا، هر برچسب بازگشتی را به [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/) مدرن از طریق [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) اضافه کنید. چون افزودن شناسه برچسب تکراری باعث ایجاد استثنا می‌شود، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری اضافه کنید تا تأیید شود هر برچسب قدیمی هنوز در سیاست جاری Purview وجود دارد.

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

مهاجرت اشیای برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. نیازی به پاک‌سازی همه ویژگی‌های سفارشی سند نیست، بنابراین متادیتای غیرمرتبط سند دست نخورده می‌ماند. با استفاده از [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) متادیتای برچسب مدرن را به فایل PPTX بنویسید.

## **سوالات متداول**

**آیا افزودن نوع علامت‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل رؤیت بر روی اسلایدها ایجاد می‌کند؟**  
خیر. مقادیری که از طریق [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) اضافه می‌شوند، علامت‌گذاری‌های مرتبط با برچسب حساسیت را توصیف می‌کنند. آن‌ها متن یا شکل‌های قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر جریان کاری شما نیاز به نمایش این علامت‌گذاری‌ها دارد، محتویات مربوطه را به‌طور جداگانه به اسلایدها اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به‌عنوان حذف‌شده و حذف آن از مجموعه چیست؟**  
صدا زدن [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/set_isremoved/) با مقدار `true` ورودی برچسب را حفظ می‌کند و وضعیت حذف آن را ثبت می‌نماید. صدا زدن [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/removeat/) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با نیازهای نگهداری متادیتای سازمان شما مطابقت داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیم و هم برچسب‌های حساسیت مدرن را شامل شود؟**  
بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند، در حالی که برچسب‌های مدرن از طریق [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) استفاده کنید و فقط برچسب‌های معتبر که هنوز در مجموعه مدرن موجود نیستند را مهاجرت کنید.

**چه اتفاقی می‌افتد وقتی یک برچسب با همان شناسه بیش از یک بار اضافه شود؟**  
[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabelcollection/add/) وقتی که مجموعه پیش از این شامل برچسبی با همان شناسه باشد، یک استثنای آرگومان را پرتاب می‌کند. قبل از افزودن یا مهاجرت برچسب‌ها، مقادیر موجود [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isensitivitylabel/get_id/) را بررسی کنید.

**برای حفظ برچسب‌های حساسیت به‌روز شده، کدام فرمت خروجی باید استفاده شود؟**  
ارائه را به‌صورت PPTX ذخیره کنید با صدا زدن [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شده است.