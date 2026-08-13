---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình bày bằng C++
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/cpp/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- XML tùy chỉnh
- phần XML tùy chỉnh
- siêu dữ liệu XML
- ItemId
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình bày PowerPoint bằng Aspose.Slides cho C++, bao gồm thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides hoạt động với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Dữ liệu đặc thù cho bản trình bày có thể được lưu dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và tải trọng XML đặc thù cho ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xóa phần XML tùy chỉnh ở mức bản trình bày, slide và hình dạng. Phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình làm việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong một bản trình bày.

## **Lưu trữ Dữ liệu trong Tệp Bản trình bày**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu dưới định dạng PresentationML, là một phần của tiêu chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các mối quan hệ được sử dụng để lưu nội dung bản trình bày và dữ liệu liên quan.

Một bản trình bày chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng với các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itagcollection/)) hoặc phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/)). Cả hai đều khả dụng thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Thẻ lưu trữ các cặp chuỗi khóa-giá trị đơn giản. Phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản trình bày, slide hoặc hình dạng.
{{% /alert %}}

## **Làm việc với Phần XML Tùy chỉnh**

Phương thức [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomdata/get_customxmlparts/) trả về bộ sưu tập các phần XML tùy chỉnh liên kết với một đối tượng bản trình bày cụ thể. Ví dụ:

- `presentation->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với bản trình bày tự nó.
- `slide->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một hình dạng cụ thể.

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình bày bất kể chúng được liên kết ở đâu.

### **Thêm một Phần XML Tùy chỉnh vào Bản trình bày**

Sử dụng [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/add/) để thêm dữ liệu XML vào bộ sưu tập phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ dữ liệu tùy chỉnh cấp bản trình bày:

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

// Add tự động gán một định danh. Chỉ thiết lập GUID cụ thể khi cần thiết.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Phương thức `Add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng, hữu ích khi nội dung XML đã có ở dạng nhị phân.

### **Thêm một Phần XML Tùy chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình bày. Điều này hữu ích khi siêu dữ liệu mô tả chỉ một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

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

Cấp độ mà một phần được thêm quyết định bộ sưu tập `get_CustomData()->get_CustomXmlParts()` của đối tượng nào chứa mối quan hệ tới phần đó. Dữ liệu cấp bản trình bày phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu cấp slide cho thông tin thuộc về một slide cụ thể, và dữ liệu cấp shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và Kiểm tra Tất cả Các Phần XML Tùy chỉnh**

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) để truy xuất tất cả các phần XML tùy chỉnh từ một bản trình bày. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/) hiển thị định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và schema không gian tên của chúng:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm tra các bản trình bày chứa XML do hệ thống bên ngoài tạo ra.

### **Đọc và Cập nhật Nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) và `set_XmlAsString` để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_xmldata/) và `set_XmlData` để làm việc với byte XML thô. Cả hai biểu diễn đều có thể đọc và cập nhật.

Phương thức [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_itemid/) trả về GUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Định danh cũng có thể được thay đổi bằng `set_ItemId` khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

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

// Đọc XML hiện tại dưới dạng văn bản.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Cập nhật XML dưới dạng chuỗi UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData cung cấp cùng nội dung XML dưới dạng byte thô.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Thay thế định danh khi tích hợp yêu cầu.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Khi gán XML bằng `set_XmlAsString` hoặc `set_XmlData`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai biểu diễn tùy theo ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một Phần XML Tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/remove/) xóa phần XML tùy chỉnh khỏi bản trình bày.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/remove/) xóa một phần cụ thể khỏi bộ sưu tập phần XML tùy chỉnh.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/removeat/) xóa phần tại một chỉ mục bộ sưu tập xác định.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/clear/) xóa tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh cấp bản trình bày bằng tham chiếu:

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

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản trình bày thay vì truy cập một bộ sưu tập nhất định, gọi `customXmlPart->Remove()`.

Bạn cũng có thể xóa một mục theo chỉ mục:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Xóa Tất cả Các Phần XML Tùy chỉnh khỏi Bộ sưu tập**

Sử dụng `Clear` khi tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản trình bày cụ thể cần được xóa.

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

`Clear` chỉ ảnh hưởng tới bộ sưu tập đã chọn. Ví dụ, xóa bộ sưu tập của một slide không xóa các bộ sưu tập cấp bản trình bày hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình bày, lặp qua `get_AllCustomXmlParts()` và xóa từng phần:

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

### **Xử lý Các Phần XML Tùy chỉnh Được Liên kết Hoặc Chia sẻ**

Trong một bản trình bày Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình bày. Ví dụ, một tệp hiện có có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh cơ sở.

Một phần được chia sẻ nên được xem như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật nó bằng `set_XmlAsString`, `set_XmlData` hoặc `set_ItemId` sẽ thay đổi phần XML tùy chỉnh cơ sở, vì vậy thay đổi sẽ áp dụng ở mọi nơi mà phần đó được tham chiếu.
- `get_ItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra bộ sưu tập cấp đối tượng.
- Xóa một phần khỏi một bộ sưu tập `get_CustomXmlParts()` cụ thể sẽ chỉ xóa nó khỏi bộ sưu tập đó. Sử dụng `ICustomXmlPart::Remove()` khi phần tự nó nên được xóa khỏi toàn bộ bản trình bày.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các bộ sưu tập cấp đối tượng để xác định liệu các slide hoặc shape khác vẫn đang tham chiếu đến nó hay không.

Các overload của `Add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` hiện có. Do đó, các mối quan hệ chia sẻ thường gặp nhất khi tải các bản trình bày đã chứa chúng.

Ví dụ sau kiểm tra các bộ sưu tập cấp bản trình bày, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một nơi:

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

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình bày được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều mối quan hệ.

## **Lấy Giá trị của Thẻ**

Trong slides, một thẻ tương ứng với thuộc tính `IDocumentProperties::get_Keywords`. Mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho C++ cho [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Thêm Thẻ vào Bản trình bày**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình bày. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ, `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ, `My Tag Value`.

Nếu bạn cần phân loại các bản trình bày dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình bày từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia tương ứng làm giá trị.

Mã mẫu này cho thấy cách thêm một thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) bằng Aspose.Slides cho C++ :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/) :

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

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/) riêng lẻ :

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

### **Giới hạn**

Thẻ được thêm thông qua bộ sưu tập `get_CustomData()->get_Tags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF đã được gắn thẻ.

**Giải pháp thay thế**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape->set_AlternativeText(u"MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi bản trình bày, slide hoặc shape trong một thao tác không?**

Có. Bộ sưu tập thẻ ([tag collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/)) hỗ trợ thao tác [Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/clear/) để xóa toàn bộ các cặp khóa-giá trị cùng lúc.

**Làm sao xóa một thẻ duy nhất bằng tên mà không phải lặp qua toàn bộ bộ sưu tập?**

Sử dụng `Remove(name)` trên [TagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/) để xóa thẻ bằng khóa của nó.

**Làm thế nào để lấy danh sách đầy đủ các tên thẻ cho mục đích phân tích hoặc lọc?**

Sử dụng `GetNamesOfTags` trên bộ sưu tập thẻ; nó trả về một mảng chứa tất cả tên thẻ.

**Làm sao tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) để truy xuất mọi phần XML tùy chỉnh trong bản trình bày.

**Nên dùng `get_XmlAsString`/`set_XmlAsString` hay `get_XmlData`/`set_XmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `get_XmlAsString` và `set_XmlAsString` khi ứng dụng làm việc với văn bản XML UTF‑8. Dùng `get_XmlData` và `set_XmlData` khi XML đã có dưới dạng mảng byte hoặc khi xử lý dạng nhị phân thuận tiện hơn. Hai biểu diễn đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.