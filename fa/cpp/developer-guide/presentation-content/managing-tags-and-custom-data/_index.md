---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با C++
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/cpp/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- قسمت XML سفارشی
- فراداده XML
- ItemId
- افزودن برچسب
- مقادیر جفتی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای C++ مدیریت کنید، شامل افزودن، خواندن، به‌روزرسانی، بررسی و حذف قسمت‌های XML سفارشی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های مخصوص یک ارائه می‌تواند به عنوان برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که بخش‌های XML سفارشی می‌توانند فراداده ساختار یافته و بارهای XML مخصوص برنامه را نگهداری کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای ادغام‌هایی مفید هستند که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت جریان کار، فرادادهٔ تطبیق، داده‌های بستن قالب یا سایر داده‌های ساختار یافتهٔ برنامه‌ای را درون یک ارائه ذخیره می‌کنند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به وسیلهٔ روابط است. به‌عنوان مثال، یک بخش اسلاید محتویات یک اسلاید منفرد را دارد و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌تواند به صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itagcollection/)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/)) ذخیره شود. هر دو از طریق اینترفیس [`ICustomData`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomdata/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های کلید‑مقدار سادهٔ رشته‌ای را ذخیره می‌کنند. بخش‌های XML سفارشی دادهٔ XML ساختار یافته را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomdata/get_customxmlparts/) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. به‌عنوان مثال:

- `presentation->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) استفاده کنید وقتی نیاز دارید همهٔ بخش‌های XML سفارشی ارائه را صرف‌نظر از مکانی که به آن‌ها مربوط می‌شوند، بررسی کنید.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/add/) برای افزودن دادهٔ XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر فرادادهٔ ساختار یافته را به مجموعهٔ داده‌های سفارشی سطح ارائه اضافه می‌کند:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// متد Add به‌صورت خودکار یک شناسه اختصاص می‌دهد. فقط در صورت نیاز یک GUID خاص تنظیم کنید.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

متد `Add` می‌تواند همچنین XML را به شکل آرایهٔ بایت یا جریان دریافت کند که وقتی محتوای XML از پیش به صورت باینری موجود باشد، مفید است.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

دادهٔ XML سفارشی می‌تواند به یک اسلاید یا شکل خاص وابسته باشد نه به تمام ارائه. این در مواردی مفید است که فراداده فقط به یک شیء اشاره دارد، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و دیگری را به یک شکل اضافه می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

سطحی که بخش در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `get_CustomData()->get_CustomXmlParts()` شیء شامل رابطهٔ آن بخش می‌شود. داده‌های سطح ارائه برای فرادادهٔ سرتاسری سند مناسب هستند، داده‌های سطح اسلاید برای اطلاعاتی که به اسلاید خاصی تعلق دارد، و داده‌های سطح شکل برای فرادادهٔ مرتبط با یک شکل منفرد.

### **لیست و بررسی همهٔ بخش‌های XML سفارشی**

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) برای دریافت همهٔ بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/) شناسه، محتوای XML و طرح‌واره‌های فضای‌نام مربوطه را نمایان می‌کند.

مثال زیر همهٔ بخش‌های XML سفارشی و طرح‌واره‌های فضای‌نام آن‌ها را فهرست می‌کند:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) طرح‌واره‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را دارند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) و `set_XmlAsString` برای کار با XML به‌عنوان رشتهٔ UTF‑8، یا از [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_xmldata/) و `set_XmlData` برای کار با بایت‌های خام XML استفاده کنید. هر دو نمایه می‌توانند خوانده و به‌روزرسانی شوند.

متد [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_itemid/) GUID شناسایی‌کنندهٔ بخش XML سفارشی در سند Office Open XML را برمی‌گرداند. این شناسه می‌تواند با `set_ItemId` نیز تغییر یابد وقتی یک ادغام به شناسهٔ جدیدی نیاز دارد.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// XML فعلی را به‌عنوان متن می‌خوانیم.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML را به‌عنوان رشته UTF-8 به‌روزرسانی می‌کنیم.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// در صورت نیاز ادغام، شناسه را جایگزین کنید.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

هنگام اختصاص XML با `set_XmlAsString` یا `set_XmlData`، XML معتبر و غیر خالی ارائه کنید. بسته به اینکه برنامه بیشتر با رشته‌ها یا داده‌های بایت کار می‌کند، یکی از این نمایه‌ها را انتخاب کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چند روش برای حذف دادهٔ XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/remove/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/remove/) بخش خاصی را از یک مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/removeat/) بخش را در ایندکس مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/clear/) همهٔ بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را از طریق ارجاع حذف می‌کند:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

اگر قبلاً یک `ICustomXmlPart` دارید و می‌خواهید آن بخش را از ارائه حذف کنید به‌جای اینکه به یک مجموعهٔ خاص مراجعه کنید، `customXmlPart->Remove()` را صدا بزنید.

همچنین می‌توانید یک مورد را بر اساس ایندکس حذف کنید:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

از `Clear` زمانی استفاده کنید که تمام بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه باید حذف شوند.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` فقط بر روی مجموعهٔ انتخاب‌شده اثر می‌گذارد. به‌عنوان مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف همهٔ بخش‌های XML سفارشی در ارائه، به‌صورت حلقه‌ای `get_AllCustomXmlParts()` را مرور کنید و هر بخش را حذف کنید:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **بررسی بخش‌های XML سفارشی پیوندی یا مشترک**

در یک ارائه Office Open XML، یک بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. به‌عنوان مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به‌عنوان یک شیء دادهٔ واحد با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی آن با `set_XmlAsString`، `set_XmlData` یا `set_ItemId` بخش XML زیرین را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن بخش ارجاع شده باشد اعمال می‌شود.
- `get_ItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `get_CustomXmlParts()` خاص، آن را فقط از همان مجموعه حذف می‌کند. برای حذف خود بخش از ارائه از `ICustomXmlPart::Remove()` استفاده کنید.
- پیش از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا بفهمید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع دارند یا نه.

بارگذاری‌ها (`Add`) یک بخش XML سفارشی جدید از محتوای XML ایجاد می‌کنند؛ آن‌ها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک اغلب هنگام بارگذاری ارائه‌هایی که قبلاً این روابط را دارند، مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بررسی می‌کند و بخش‌هایی که از بیش از یک مکان ارجاع شده‌اند گزارش می‌دهد:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

این نوع بررسی پیش از تغییر یا حذف دادهٔ XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا همان بخش فراداده ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب متناظر با ویژگی `IDocumentProperties::get_Keywords` است. این نمونه کد نشان می‌دهد چطور مقدار یک برچسب را با Aspose.Slides برای C++ از [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دریافت کنید:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما اجازه می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، به عنوان مثال `MyTag`؛
- مقدار ویژگی سفارشی، به عنوان مثال `My Tag Value`.

اگر نیاز دارید ارائه‌ها را بر اساس قانون یا ویژگی خاصی طبقه‌بندی کنید، می‌توانید برای این منظور برچسب اضافه کنید. به‌عنوان مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به‌عنوان مقدار آن تعیین کنید.

این نمونه کد نشان می‌دهد چطور یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) با Aspose.Slides برای C++ اضافه کنید:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/) نیز تنظیم شوند:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/) فردی:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه `get_CustomData()->get_Tags()` اضافه می‌شوند فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار استخراج شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** (Alt Text) شیء ذخیره کنید (به عنوان مثال، `shape->set_AlternativeText(u"MyId")`). پس از صادر کردن به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) از عملیات [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که همهٔ جفت‌های کلید‑مقدار را یک‌باره حذف می‌نماید.

**چگونه می‌توانم یک برچسب منفرد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از [Remove(name)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/remove/) روی [TagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید آن حذف کنید.

**چگونه می‌توانم فهرست کاملی از نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلترگیری بدست آورم؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/getnamesoftags/) روی [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) استفاده کنید؛ این متد یک آرایه از همهٔ نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم همهٔ بخش‌های XML سفارشی را بدون درنظر گرفتن محل ذخیرهٔ آن‌ها پیدا کنم؟**

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) برای دریافت همهٔ بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `get_XmlAsString`/`set_XmlAsString` یا `get_XmlData`/`set_XmlData` برای به‌روزرسانی یک بخش XML سفارشی استفاده کنم؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند از `get_XmlAsString` و `set_XmlAsString` استفاده کنید. وقتی XML قبلاً به‌صورت آرایهٔ بایت موجود است یا پردازش باینری برای برنامه راحت‌تر است، از `get_XmlData` و `set_XmlData` استفاده کنید. هر دو نمایه به محتوای XML همان بخش سفارشی اشاره دارند.