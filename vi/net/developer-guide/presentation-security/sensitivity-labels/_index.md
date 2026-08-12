---
title: Quản lý Nhãn Nhạy Cảm trong Bản Trình Bày PowerPoint trên .NET
linktitle: Nhãn Nhạy Cảm
type: docs
weight: 50
url: /vi/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển nhãn nhạy cảm Microsoft Purview trong các bản trình bày PowerPoint PPTX bằng Aspose.Slides cho .NET."
---
## **Overview**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình bày tự động, một ứng dụng có thể cần bảo tồn nhãn hiện có, áp dụng nhãn được lựa chọn bởi chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides cung cấp siêu dữ liệu nhãn nhạy cảm hiện đại thông qua [Presentation.SensitivityLabels](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sensitivitylabels/). Thuộc tính này trả về một [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/) có thể được kiểm tra và sửa đổi trước khi lưu bản trình bày dưới dạng PPTX.

{{% alert color="primary" title="Lưu ý" %}}
Những định danh nhãn nhạy cảm và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Hãy xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/contentmarktypes/) mô tả các đánh dấu nội dung liên quan đến nhãn; chúng không tự động thêm văn bản hay hình dạng hiển thị vào các slide.
{{% /alert %}}

## **Understand Sensitivity Label Properties**

Mỗi [ISensitivityLabel](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/) chứa các siêu dữ liệu sau:

| Property | Purpose |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/id/) | Xác định nhãn nhạy cảm trong chính sách Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/siteid/) | Xác định site liên quan đến chính sách nhãn. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/isenabled/) | Cho biết nhãn có được bật hay không. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/isremoved/) | Cho biết nhãn đã bị xóa. Đặt thuộc tính này thành `true` khi trạng thái xóa phải được giữ trong siêu dữ liệu. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Xác định nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Liệt kê các loại đánh dấu nội dung liên quan đến nhãn. |

Kiểu liệt kê [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelassignmenttype/) mô tả cách nhãn được gán:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, được đề xuất và bắt buộc.

Kiểu liệt kê [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) xác định đánh dấu liên quan đến nhãn:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/vi/net/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại đánh dấu có thể được liên kết với một nhãn.

## **List Existing Sensitivity Labels**

Đọc bộ sưu tập nhãn hiện đại từ [Presentation.SensitivityLabels](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sensitivitylabels/) và duyệt qua nó. Ví dụ sau liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Add a Sensitivity Label with Content Marking**

Sử dụng [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/add/) với định danh nhãn, định danh site, trạng thái bật và phương thức gán. Sau khi phương thức trả về [ISensitivityLabel](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/) mới, thêm các giá trị đánh dấu bắt buộc qua [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Ví dụ dưới đây thêm một nhãn được chọn thủ công có liên quan đến đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Update a Sensitivity Label**

Các thuộc tính của [ISensitivityLabel](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/) đều có thể đọc/ghi, ngoại trừ bộ sưu tập trả về bởi [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/contentmarktypes/) được sửa đổi thông qua các thao tác danh sách của nó. Sau khi tìm được nhãn cần thiết, bạn có thể cập nhật định danh, định danh site, trạng thái bật, phương thức gán, trạng thái xóa và các loại đánh dấu nội dung. Lưu bản trình bày để lưu các thay đổi.

Ví dụ dưới đây cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Mark a Sensitivity Label as Removed**

Để bảo tồn thông tin một nhãn đã bị xóa, tìm nhãn đó và đặt [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/isremoved/) thành `true`. Thao tác này giữ lại mục nhãn trong khi ghi lại trạng thái đã xóa. Nếu bạn muốn xóa mục khỏi bộ sưu tập hiện đại, hãy sử dụng [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/removeat/); dùng [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/clear/) để xóa mọi mục.

Ví dụ dưới đây đánh dấu một nhãn cụ thể là đã xóa và lưu bản trình bày đã cập nhật:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Read and Migrate Legacy MIP Sensitivity Labels**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn nhạy cảm trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Phương thức này phân tích các thuộc tính tùy chỉnh cũ và trả về một mảng các đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn trả về vào [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/) hiện đại thông qua [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/add/). Vì việc thêm một định danh nhãn trùng lặp sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thực hiện kiểm tra bổ sung để xác nhận mỗi nhãn legacy vẫn tồn tại trong chính sách Purview hiện tại.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa tất cả các thuộc tính tài liệu tùy chỉnh, vì vậy các siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) để ghi siêu dữ liệu nhãn hiện đại ra tệp PPTX.

## **FAQ**

**Thêm một loại đánh dấu nội dung có tạo ra tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm qua [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/contentmarktypes/) mô tả các đánh dấu liên quan đến nhãn nhạy cảm. Chúng không tạo ra văn bản hay hình dạng hiển thị trong bản trình bày. Hãy thêm nội dung slide tương ứng riêng biệt nếu quy trình của bạn cần hiển thị các đánh dấu này.

**Sự khác nhau giữa việc đánh dấu một nhãn là đã xóa và xóa nó khỏi bộ sưu tập là gì?**

Đặt [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/isremoved/) thành `true` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/removeat/) sẽ xóa mục khỏi bộ sưu tập hiện đại. Hãy chọn thao tác phù hợp với yêu cầu lưu trữ siêu dữ liệu của tổ chức bạn.

**Một bản trình bày có thể chứa cả siêu dữ liệu MIP legacy và nhãn nhạy cảm hiện đại không?**

Có. Các nhãn legacy có thể còn lại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại được truy cập qua [Presentation.SensitivityLabels](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sensitivitylabels/). Sử dụng [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/getsensitivitylabels/) để đọc siêu dữ liệu legacy và chỉ di chuyển những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabelcollection/add/) ném `ArgumentException` khi bộ sưu tập đã chứa một nhãn có cùng định danh. Kiểm tra các giá trị [ISensitivityLabel.Id](https://reference.aspose.com/slides/vi/net/aspose.slides/isensitivitylabel/id/) hiện có trước khi thêm hoặc di chuyển nhãn.

**Định dạng đầu ra nào nên dùng để bảo tồn các nhãn nhạy cảm đã cập nhật?**

Lưu bản trình bày dưới dạng PPTX bằng cách gọi [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/), như đã minh họa trong các ví dụ ở trên.