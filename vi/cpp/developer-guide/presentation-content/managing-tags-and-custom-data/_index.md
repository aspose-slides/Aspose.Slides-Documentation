---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu bằng C++
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
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho C++, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Dữ liệu riêng biệt cho bản trình chiếu có thể được lưu dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và các gói XML riêng của ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh ở mức bản trình chiếu, slide và shape. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình làm việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong bản trình chiếu.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Các tệp PPTX — các tệp có phần mở rộng `.pptx` — được lưu ở định dạng PresentationML, một phần của chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các quan hệ được dùng để lưu nội dung bản trình chiếu và dữ liệu liên quan.

Một bản trình chiếu chứa nhiều phần được kết nối bằng các quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itagcollection/)) hoặc phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/)). Cả hai đều có sẵn qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Thẻ lưu trữ các cặp chuỗi khóa-giá trị đơn giản. Các phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với bản trình chiếu, slide hoặc shape.
{{% /alert %}}

## **Làm việc với các phần XML tùy chỉnh**

Phương thức [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomdata/get_customxmlparts/) trả về bộ sưu tập các phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể. Ví dụ:

- `presentation->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với chính bản trình chiếu.
- `slide->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape->get_CustomData()->get_CustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) khi cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình chiếu bất kể chúng được liên kết ở đâu.

### **Thêm một phần XML tùy chỉnh vào bản trình chiếu**

Dùng [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/add/) để thêm dữ liệu XML vào bộ sưu tập các phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh ở mức bản trình chiếu:

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

// Thêm tự động gán một định danh. Chỉ đặt GUID cụ thể khi cần thiết.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Phương thức `Add` cũng có thể nhận XML dưới dạng mảng byte hoặc stream, hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm một phần XML tùy chỉnh vào slide hoặc shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình chiếu. Điều này hữu ích khi siêu dữ liệu mô tả chỉ một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

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

Mức mà phần được thêm quyết định bộ sưu tập `get_CustomData()->get_CustomXmlParts()` của đối tượng nào chứa quan hệ tới phần đó. Dữ liệu ở mức bản trình chiếu thích hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và kiểm tra toàn bộ các phần XML tùy chỉnh**

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) để lấy tất cả các phần XML tùy chỉnh từ một bản trình chiếu. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và các schema không gian tên của chúng:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) trả về các schema XML liên quan tới phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm tra các bản trình chiếu chứa XML được tạo bởi các hệ thống bên ngoài.

### **Đọc và cập nhật nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) và `set_XmlAsString` để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_xmldata/) và `set_XmlData` để làm việc với các byte XML thô. Cả hai dạng đều có thể đọc và cập nhật.

Phương thức [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/get_itemid/) trả về GUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Định danh này cũng có thể được thay đổi bằng `set_ItemId` khi một tích hợp yêu cầu định danh mới.

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

Khi gán XML bằng `set_XmlAsString` hoặc `set_XmlData`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai cách tùy thuộc vào việc ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpart/remove/) xóa phần XML tùy chỉnh khỏi bản trình chiếu.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/remove/) xóa một phần cụ thể khỏi bộ sưu tập các phần XML tùy chỉnh.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/removeat/) xóa phần tại một chỉ mục bộ sưu tập cụ thể.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/clear/) xóa mọi phần khỏi một bộ sưu tập nhất định.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức bản trình chiếu bằng tham chiếu:

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

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản trình chiếu thay vì xác định một bộ sưu tập cụ thể, gọi `customXmlPart->Remove()`.

Bạn cũng có thể xóa một mục theo chỉ mục:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Xóa sạch tất cả các phần XML tùy chỉnh khỏi một bộ sưu tập**

Sử dụng `Clear` khi tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể cần được xóa.

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

`Clear` chỉ ảnh hưởng đến bộ sưu tập đã chọn. Ví dụ, xóa sạch bộ sưu tập của một slide sẽ không xóa các bộ sưu tập ở mức bản trình chiếu hay shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình chiếu, lặp qua `get_AllCustomXmlParts()` và xóa từng phần:

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

### **Xử lý các phần XML tùy chỉnh được liên kết hoặc chia sẻ**

Trong một bản trình chiếu Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ nhiều đối tượng bản trình chiếu. Ví dụ, một tệp hiện có có thể chứa các quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền.

Một phần được chia sẻ nên được xử lý như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật nó bằng `set_XmlAsString`, `set_XmlData` hoặc `set_ItemId` sẽ thay đổi phần XML tùy chỉnh nền, vì vậy thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `get_ItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các bộ sưu tập mức đối tượng.
- Xóa một phần khỏi một bộ sưu tập `get_CustomXmlParts()` cụ thể sẽ chỉ xóa nó khỏi bộ sưu tập đó. Dùng `ICustomXmlPart::Remove()` khi phần tự nó cần được xóa khỏi bản trình chiếu.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các bộ sưu tập mức đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó không.

Các overload của `Add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` đã tồn tại. Do đó, các quan hệ chia sẻ thường gặp nhất khi tải các bản trình chiếu đã chứa chúng.

Ví dụ sau kiểm tra các bộ sưu tập ở mức bản trình chiếu, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ nhiều nơi:

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

Kiểm tra kiểu này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình chiếu được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều quan hệ.

## **Lấy giá trị của các thẻ**

Trong Slides, một thẻ tương ứng với thuộc tính `IDocumentProperties::get_Keywords`. Đoạn mã mẫu dưới đây cho thấy cách lấy giá trị thẻ với Aspose.Slides cho C++ cho [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Thêm thẻ vào bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại bản trình chiếu theo các quốc gia Bắc Mỹ, bạn có thể tạo thẻ North American và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu dưới đây cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) bằng Aspose.Slides cho C++ :

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

Các thẻ được thêm thông qua bộ sưu tập `get_CustomData()->get_Tags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển vào cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Cách khắc phục**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ `shape->set_AlternativeText(u"MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả các thẻ khỏi bản trình chiếu, slide hoặc shape trong một thao tác không?**

Có. Bộ sưu tập [tag collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/) hỗ trợ thao tác [Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa-giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không duyệt qua toàn bộ bộ sưu tập?**

Sử dụng [Remove(name)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [GetNamesOfTags](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/getnamesoftags/) trên bộ sưu tập thẻ; nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm mọi phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) để lấy tất cả các phần XML tùy chỉnh trong bản trình chiếu.

**Nên dùng `get_XmlAsString`/`set_XmlAsString` hay `get_XmlData`/`set_XmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `get_XmlAsString` và `set_XmlAsString` khi ứng dụng làm việc với văn bản XML UTF-8. Dùng `get_XmlData` và `set_XmlData` khi XML đã có sẵn dưới dạng mảng byte hoặc khi xử lý nhị phân thuận tiện hơn. Cả hai cách đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.