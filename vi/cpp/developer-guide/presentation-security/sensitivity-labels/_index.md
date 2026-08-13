---
title: Quản lý nhãn nhạy cảm trong bản trình bày PowerPoint bằng C++
linktitle: Nhãn nhạy cảm
type: docs
weight: 50
url: /vi/cpp/sensitivity-labels/
keywords:
- nhãn nhạy cảm
- Microsoft Purview
- Microsoft Information Protection
- siêu dữ liệu MIP
- đánh dấu nội dung
- bảo vệ thông tin
- quản trị tài liệu
- PowerPoint
- PPTX
- bảo mật bản trình bày
- C++
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển nhãn nhạy cảm Microsoft Purview trong các bản trình bày PowerPoint PPTX với Aspose.Slides cho C++."
---
## **Tổng quan**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Khi xử lý bản trình bày tự động, một ứng dụng có thể cần giữ nguyên nhãn hiện có, áp dụng nhãn được chọn bởi chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được viết bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides cung cấp siêu dữ liệu nhãn nhạy cảm hiện đại thông qua [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Phương thức này trả về một [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/) có thể được kiểm tra và chỉnh sửa trước khi bản trình bày được lưu dưới dạng PPTX.

{{% alert color="info" title="Note" %}}
Các định danh nhãn nhạy cảm và thông tin chính sách được định nghĩa bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị của [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) mô tả các đánh dấu nội dung liên quan tới nhãn; chúng không tự động tạo văn bản hoặc hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu các thuộc tính của nhãn nhạy cảm**

Mỗi [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) chứa các siêu dữ liệu sau:

| Trình truy cập | Mục đích |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_id/) | Xác định nhãn nhạy cảm trong chính sách Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Xác định trang web liên quan đến chính sách nhãn. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Chỉ ra nhãn có được bật hay không. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Chỉ ra rằng nhãn đã bị xóa. Đặt giá trị thành `true` khi trạng thái xóa phải được giữ trong siêu dữ liệu. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Xác định nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Liệt kê các loại đánh dấu nội dung liên quan đến nhãn. |

[enumeration SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) mô tả cách nhãn được gán:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng thông qua quyết định của người dùng, bao gồm các nhãn được áp dụng thủ công, được đề xuất và bắt buộc.

[enumeration SensitivityLabelContentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) xác định đánh dấu liên quan tới nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại đánh dấu có thể được liên kết với một nhãn.

## **Liệt kê các nhãn nhạy cảm hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) và duyệt nó. Ví dụ dưới đây liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

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

## **Thêm nhãn nhạy cảm với đánh dấu nội dung**

Sử dụng [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/) với định danh nhãn, định danh site, trạng thái bật và phương pháp gán. Sau khi phương thức trả về đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) mới, thêm các giá trị đánh dấu cần thiết qua [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Ví dụ dưới đây thêm một nhãn được người dùng chọn thủ công, liên quan tới đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

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

## **Cập nhật nhãn nhạy cảm**

Các giá trị của [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) có thể đọc/ghi qua các phương thức getter và setter, ngoại trừ bộ sưu tập trả về bởi [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) được sửa đổi qua các thao tác danh sách. Sau khi xác định được nhãn cần thiết, bạn có thể cập nhật định danh, định danh site, trạng thái bật, phương pháp gán, trạng thái xóa và các loại đánh dấu nội dung. Lưu bản trình bày để lưu các thay đổi.

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

## **Đánh dấu nhãn nhạy cảm là đã bị xóa**

Để giữ lại thông tin rằng một nhãn đã bị xóa, tìm nhãn và gọi [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) với `true`. Điều này giữ lại mục nhãn đồng thời ghi lại trạng thái xóa. Nếu bạn muốn xóa mục khỏi bộ sưu tập hiện đại, sử dụng [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/removeat/); dùng [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/clear/) để xóa mọi mục.

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

## **Đọc và di chuyển các nhãn nhạy cảm MIP cũ**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn nhạy cảm trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Phương thức này phân tích các thuộc tính tùy chỉnh cổ và trả về một mảng các đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn đã trả về vào [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/) hiện đại qua [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/). Vì việc thêm một định danh nhãn trùng sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm kiểm tra xác nhận rằng mỗi nhãn cũ vẫn tồn tại trong chính sách Purview hiện tại.

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

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xoá toàn bộ thuộc tính tài liệu tùy chỉnh, vì vậy các siêu dữ liệu không liên quan vẫn được giữ nguyên. Sử dụng [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **FAQ**

**Does adding a content marking type create a visible header, footer, or watermark on slides?**  
Không. Các giá trị được thêm qua [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) mô tả các đánh dấu liên quan tới nhãn nhạy cảm. Chúng không tạo ra văn bản hoặc hình dạng hiển thị trong bản trình bày. Thêm nội dung slide tương ứng riêng nếu quy trình của bạn phải hiển thị các đánh dấu này.

**What is the difference between marking a label as removed and deleting it from the collection?**  
Gọi [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) với `true` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) xóa mục khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu trữ siêu dữ liệu của tổ chức bạn.

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**  
Có. Các nhãn cũ có thể còn trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại được truy cập qua [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Sử dụng [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) để đọc siêu dữ liệu cũ và chỉ di chuyển những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**What happens when a label with the same identifier is added more than once?**  
[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/) ném ngoại lệ argument khi bộ sưu tập đã chứa nhãn có cùng định danh. Kiểm tra các giá trị [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_id/) hiện có trước khi thêm hoặc di chuyển nhãn.

**Which output format should be used to preserve updated sensitivity labels?**  
Lưu bản trình bày dưới dạng PPTX bằng cách gọi [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/), như đã minh họa trong các ví dụ trên.