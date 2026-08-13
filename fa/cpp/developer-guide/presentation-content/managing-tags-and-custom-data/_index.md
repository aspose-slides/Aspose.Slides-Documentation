---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از C++
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/cpp/managing-tags-and-custom-data/
keywords:
- خصوصیات سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- بخش XML سفارشی
- فراداده XML
- ItemId
- افزودن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای C++ مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص یک ارائه می‌توانند به‌صورت برچسب یا بخش‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های کلید‑مقدار ساده‌ای از رشته‌ها هستند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاری و بارهای XML خاص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای ادغام‌هایی که اطلاعاتی نظیر شناسه‌های مدیریت سند، وضعیت جریان کار، متادیتای انطباق، داده‌های بایندینگ قالب یا دیگر داده‌های ساختاری برنامه داخل یک ارائه را ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX—فایلی با پسوند `.pptx`—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابطی که برای ذخیره محتوای ارائه و داده‌های مرتبط استفاده می‌شود را تعریف می‌کند.

یک ارائه شامل چندین بخش است که با روابط به هم متصل‌اند. به‌عنوان مثال، یک بخش اسلاید محتویات یک اسلاید واحد را دارد و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itagcollection/)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/)) ذخیره شوند. هر دو از طریق رابط [`ICustomData`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomdata/) در دسترس هستند.

{{% alert color="info" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاری را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomdata/get_customxmlparts/) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. به‌عنوان مثال:

- `presentation->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مربوط به خود ارائه است.
- `slide->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مربوط به اسلاید خاصی است.
- `shape->get_CustomData()->get_CustomXmlParts()` شامل بخش‌های XML سفارشی مربوط به شکل خاصی است.

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، بدون توجه به محل ارتباط آن‌ها، استفاده کنید.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/add/) برای افزودن داده XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر متادیتای ساختاری را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

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

// Add به‌صورت خودکار یک شناسه اختصاص می‌دهد. فقط در صورت لزوم یک GUID مشخص تنظیم کنید.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

متد `Add` همچنین می‌تواند XML را به‌صورت آرایهٔ بایت یا جریان دریافت کند که وقتی محتوای XML قبلاً به شکل باینری در دسترس است، مفید است.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به اسلاید یا شکل خاصی به‌جای کل ارائه مرتبط شوند. این کار زمانی مفید است که متادیتا فقط به یک شیء اشاره داشته باشد، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی به یک اسلاید و دیگری به یک شکل اضافه می‌کند:

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

سطحی که بخش به آن اضافه می‌شود تعیین می‌کند کدام مجموعهٔ `get_CustomData()->get_CustomXmlParts()` شامل رابطه به آن بخش است. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب‌اند، داده‌های سطح اسلاید برای اطلاعاتی که به اسلاید خاصی تعلق دارند، و داده‌های سطح شکل برای متادیتایی که به یک شکل منفرد وابسته است.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/) شناسه، محتوای XML و طرح‌نامه‌های فضاهای نام مرتبط خود را نشان می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرح‌نامه‌های فضاهای نام آن‌ها را فهرست می‌کند:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) طرح‌نامه‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) و `set_XmlAsString` برای کار با XML به‌صورت رشتهٔ UTF‑8، یا از [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_xmldata/) و `set_XmlData` برای کار با بایت‌های خام XML استفاده کنید. هر دو نمایه می‌توانند خوانده و به‌روزرسانی شوند.

متد [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/get_itemid/) GUIDی را برمی‌گرداند که بخش XML سفارشی را در سند Office Open XML شناسایی می‌کند. این شناسه همچنین می‌تواند با `set_ItemId` تغییر یابد هنگامی که یک ادغام به شناسهٔ جدیدی نیاز دارد.

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

// XML فعلی را به‌صورت متن می‌خواند.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML را به‌صورت رشتهٔ UTF-8 به‌روزرسانی می‌کند.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData همان محتوای XML را به‌صورت بایت‌های خام فراهم می‌کند.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// در صورت نیاز یکپارچه‌سازی شناسه را جایگزین می‌کند.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

هنگام اختصاص XML با `set_XmlAsString` یا `set_XmlData`، XML معتبر و غیر خالی فراهم کنید. بسته به اینکه برنامه بیشتر با رشته‌ها یا داده‌های بایت کار می‌کند، یکی از این دو نمایه را استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چند روش برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpart/remove/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/remove/) بخش خاصی را از یک مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/removeat/) بخش را در شاخص مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/clear/) تمام بخش‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را بر اساس مرجع حذف می‌کند:

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

اگر قبلاً یک `ICustomXmlPart` دارید و می‌خواهید آن را از ارائه حذف کنید به‌جای اینکه به یک مجموعهٔ خاص مراجعه کنید، `customXmlPart->Remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را بر اساس شاخص حذف کنید:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

از `Clear` وقتی که همهٔ بخش‌های XML سفارشی مرتبط با یک شیء ارائه باید حذف شوند، استفاده کنید.

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

`Clear` فقط بر روی مجموعهٔ انتخاب شده اثر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا مجموعهٔ سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، می‌توانید `get_AllCustomXmlParts()` را مرور کنید و هر بخش را حذف کنید:

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

### **مدیریت بخش‌های XML سفارشی پیوندی یا مشترک**

در یک ارائه Office Open XML، یک بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. به‌عنوان مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به یک بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به‌عنوان یک شیء دادهٔ واحد با ارجاعات متعدد در نظر گرفته شود:

- به‌روزرسانی آن با `set_XmlAsString`، `set_XmlData` یا `set_ItemId` بخش XML سفارشی زیرین را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن بخش ارجاع شده اعمال می‌شود.
- `get_ItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `get_CustomXmlParts()` خاص، آن را فقط از همان مجموعه حذف می‌کند. برای حذف خود بخش از کل ارائه از `ICustomXmlPart::Remove()` استفاده کنید.
- پیش از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع دارند یا نه.

بارگذاری‌های `Add` یک بخش XML سفارشی جدید از محتوای XML ایجاد می‌کند؛ آن‌ها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک بیشتر زمانی دیده می‌شوند که ارائه‌هایی که قبلاً حاوی این روابط هستند، بارگیری می‌شوند.

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

این نوع بررسی قبل از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا ممکن است همان بخش متادیتا در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب متناظر با ویژگی `IDocumentProperties::get_Keywords` است. این نمونه کد نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای C++ برای [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دریافت کنیم:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما اجازه می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، به عنوان مثال `MyTag`;
- مقدار ویژگی سفارشی، به عنوان مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قانون یا ویژگی خاص داشته باشید، می‌توانید برای این هدف برچسب اضافه کنید. به‌عنوان مثال، اگر بخواهید ارائه‌ها را بر اساس کشورهای آمریکای شمالی دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کنید و کشور مرتبط را به عنوان مقدار آن اختصاص دهید.

این نمونه کد نشان می‌دهد چگونه یک برچسب را به یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) با Aspose.Slides برای C++ اضافه کنیم:

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

یا برای یک [Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/) منفرد:

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

برچسب‌های اضافه‌شده از طریق مجموعه `get_CustomData()->get_Tags()` تنها در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب‌های PDF هنگام خروجی گرفتن ارائه به PDF منتقل نمی‌شوند. در نتیجه، شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌خورده بازیابی شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن Alt** شیء ذخیره کنید (به عنوان مثال `shape->set_AlternativeText(u"MyId")`). پس از خروجی گرفتن به PDF، متن Alt ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) یک عملیات [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/clear/) را پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را به‌صورت یکجا حذف می‌کند.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن حذف کنم بدون این که کل مجموعه را پیمایش کنم؟**

از [Remove(name)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/remove/) روی [TagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) برای حذف برچسب بر اساس کلید استفاده کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلتر کردن دریافت کنم؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/getnamesoftags/) روی [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را بدون در نظر گرفتن محل ذخیره‌سازی آن‌ها پیدا کنم؟**

از [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_allcustomxmlparts/) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `get_XmlAsString`/`set_XmlAsString` یا `get_XmlData`/`set_XmlData` برای به‌روزرسانی یک بخش XML سفارشی استفاده کنم؟**

از `get_XmlAsString` و `set_XmlAsString` زمانی استفاده کنید که برنامه با متن XML UTF‑8 کار می‌کند. از `get_XmlData` و `set_XmlData` زمانی استفاده کنید که XML قبلاً به‌صورت آرایهٔ بایت موجود است یا پردازش مبتنی بر باینری راحت‌تر است. هر دو نمایه به محتوای XML یک بخش XML سفارشی اشاره دارند.