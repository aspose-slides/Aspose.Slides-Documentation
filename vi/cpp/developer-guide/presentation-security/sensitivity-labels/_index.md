---
title: Quản lý Nhãn Độ Nhạy trong Bản Trình Chiếu PowerPoint bằng C++
linktitle: Nhãn Độ Nhạy
type: docs
weight: 50
url: /vi/cpp/sensitivity-labels/
keywords:
- nhãn độ nhạy
- Microsoft Purview
- Microsoft Information Protection
- siêu dữ liệu MIP
- đánh dấu nội dung
- bảo vệ thông tin
- quản trị tài liệu
- PowerPoint
- PPTX
- bảo mật bản trình chiếu
- C++
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển các nhãn độ nhạy Microsoft Purview trong các bản trình chiếu PowerPoint PPTX bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Những nhãn độ nhạy Microsoft Purview giúp các tổ chức phân loại và quản trị tài liệu. Trong quá trình xử lý tự động bản trình chiếu, một ứng dụng có thể cần giữ nguyên nhãn hiện có, áp dụng nhãn được chọn bởi một chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ hơn.

Aspose.Slides cung cấp siêu dữ liệu nhãn độ nhạy hiện đại thông qua [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Phương thức này trả về một [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/) có thể được kiểm tra và sửa đổi trước khi bản trình chiếu được lưu dưới dạng PPTX.

{{% alert color="primary" title="Note" %}}

Các định danh nhãn độ nhạy và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) mô tả các dấu nội dung liên quan tới nhãn; chúng không tự tạo ra văn bản hay hình dạng hiển thị trên các slide.

{{% /alert %}}

## **Hiểu các thuộc tính của Nhãn Độ Nhạy**

Mỗi [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) chứa các siêu dữ liệu sau:

| Truy cập | Mục đích |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_id/) | Xác định nhãn độ nhạy trong chính sách Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Xác định trang web liên quan tới chính sách nhãn. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Chỉ ra liệu nhãn có được bật hay không. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Chỉ ra rằng nhãn đã bị xóa. Đặt giá trị thành `true` khi trạng thái xóa phải được giữ trong siêu dữ liệu. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Chỉ định nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Liệt kê các loại dấu nội dung liên quan tới nhãn. |

Kiểu liệt kê [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) mô tả cách nhãn được gán:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, đề xuất và bắt buộc.

Kiểu liệt kê [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) xác định dấu nội dung liên quan tới một nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Dấu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Dấu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Dấu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ bằng mã hóa được liên kết với nhãn. |

Nhiều loại dấu có thể được gắn với cùng một nhãn.

## **Liệt kê các Nhãn Độ Nhạy hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) và duyệt qua chúng. Ví dụ sau liệt kê mọi thuộc tính và dấu nội dung được lưu cho mỗi nhãn:

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

## **Thêm một Nhãn Độ Nhạy với Dấu Nội Dung**

Sử dụng [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/) với định danh nhãn, định danh trang web, trạng thái bật và phương pháp gán. Sau khi phương thức trả về [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) mới, thêm các giá trị dấu cần thiết qua [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Ví dụ sau thêm một nhãn được chọn thủ công, liên kết với dấu chân trang và watermark, rồi lưu kết quả dưới dạng PPTX:

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

## **Cập nhật một Nhãn Độ Nhạy**

Các giá trị của [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/) có thể đọc/ghi qua các phương thức getter và setter, ngoại trừ bộ sưu tập được trả về bởi [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) được sửa đổi qua các thao tác danh sách. Sau khi xác định nhãn cần thiết, bạn có thể cập nhật định danh, định danh trang web, trạng thái bật, phương pháp gán, trạng thái xóa và các loại dấu nội dung. Lưu bản trình chiếu để lưu các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương pháp gán của nhãn đầu tiên:

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

## **Đánh dấu một Nhãn Độ Nhạy là Đã Bị Xóa**

Để ghi nhận việc một nhãn đã bị xóa, tìm nhãn và gọi [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) với `true`. Điều này giữ lại mục nhãn đồng thời ghi lại trạng thái đã xóa. Nếu bạn muốn xóa mục khỏi bộ sưu tập hiện đại, sử dụng [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/removeat/); dùng [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/clear/) để xóa mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã bị xóa và lưu bản trình chiếu đã cập nhật:

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

## **Đọc và Di chuyển Nhãn Độ Nhạy MIP Cũ**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn độ nhạy trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Phương thức này phân tích các thuộc tính tùy chỉnh cũ và trả về một mảng các đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn đã trả về vào [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/) hiện đại qua [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/). Vì việc thêm một định danh nhãn trùng lặp sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm kiểm tra bổ sung để xác nhận mỗi nhãn cũ vẫn còn tồn tại trong chính sách Purview hiện tại.

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

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa tất cả các thuộc tính tài liệu tùy chỉnh, vì vậy các siêu dữ liệu tài liệu không liên quan vẫn còn nguyên vẹn. Sử dụng [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Việc thêm một loại dấu nội dung có tạo ra tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm qua [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) mô tả các dấu liên quan tới nhãn độ nhạy. Chúng không tạo ra văn bản hay hình dạng hiển thị trong bản trình chiếu. Hãy thêm nội dung slide tương ứng riêng biệt nếu quy trình của bạn cần hiển thị các dấu đó.

**Sự khác nhau giữa việc đánh dấu một nhãn là đã bị xóa và xóa nó khỏi bộ sưu tập là gì?**

Gọi [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) với `true` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) xóa mục khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu giữ siêu dữ liệu của tổ chức bạn.

**Một bản trình chiếu có thể chứa cả siêu dữ liệu MIP cũ và nhãn độ nhạy hiện đại không?**

Có. Các nhãn cũ có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại có sẵn qua [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Sử dụng [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) để đọc siêu dữ liệu cũ và chỉ di chuyển những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm hơn một lần?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabelcollection/add/) ném ngoại lệ argument khi bộ sưu tập đã chứa nhãn có cùng định danh. Kiểm tra các giá trị [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isensitivitylabel/get_id/) hiện có trước khi thêm hoặc di chuyển nhãn.

**Định dạng đầu ra nào nên được dùng để giữ nguyên các nhãn độ nhạy đã cập nhật?**

Lưu bản trình chiếu dưới dạng PPTX bằng cách gọi [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/), như đã minh họa trong các ví dụ ở trên.