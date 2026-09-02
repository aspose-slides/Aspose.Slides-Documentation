---
title: Quản lý Nhãn Độ nhạy trong Bản trình bày PowerPoint bằng Python
linktitle: Nhãn Độ nhạy
type: docs
weight: 50
url: /vi/python-net/sensitivity-labels/
keywords:
- nhãn độ nhạy
- Microsoft Purview
- Microsoft Information Protection
- siêu dữ liệu MIP
- đánh dấu nội dung
- bảo vệ thông tin
- quản lý tài liệu
- PowerPoint
- PPTX
- bảo mật bản trình bày
- Python
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển các nhãn độ nhạy Microsoft Purview trong các bản trình bày PowerPoint PPTX bằng Aspose.Slides for Python via .NET."
---
## **Tổng quan**

Các nhãn độ nhạy của Microsoft Purview giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình bày tự động, một ứng dụng có thể cần giữ nguyên nhãn hiện có, áp dụng nhãn được chọn bởi chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides for Python via .NET cung cấp siêu dữ liệu nhãn độ nhạy hiện đại thông qua [Presentation.sensitivity_labels](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sensitivity_labels/). Thuộc tính này trả về một [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/) có thể được kiểm tra và sửa đổi trước khi bản trình bày được lưu dưới dạng PPTX.

{{% alert color="primary" title="Note" %}}
Các định danh nhãn độ nhạy và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) mô tả các ký hiệu nội dung liên kết với một nhãn; chúng không tự động tạo văn bản hay hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu các Thuộc tính Nhãn Độ nhạy**

Mỗi [SensitivityLabel](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/) chứa các siêu dữ liệu sau:

| Thuộc tính | Mục đích |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/id/) | Xác định nhãn độ nhạy trong chính sách Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/site_id/) | Xác định trang web liên kết với chính sách nhãn. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Cho biết nhãn có được bật hay không. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/is_removed/) | Cho biết nhãn đã bị xóa. Đặt thuộc tính này thành `True` khi trạng thái xóa phải được giữ trong siêu dữ liệu. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Chỉ định nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Liệt kê các loại ký hiệu nội dung liên kết với nhãn. |

Kiểu liệt kê [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelassignmenttype/) mô tả cách một nhãn được gán:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng thông qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, được đề xuất và bắt buộc.

Kiểu liệt kê [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) xác định ký hiệu liên kết với một nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) | Ký hiệu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) | Ký hiệu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) | Ký hiệu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại ký hiệu có thể được liên kết với một nhãn.

## **Liệt kê các Nhãn Độ nhạy hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [Presentation.sensitivity_labels](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sensitivity_labels/) và liệt kê chúng. Ví dụ sau liệt kê mọi thuộc tính và ký hiệu nội dung được lưu cho mỗi nhãn:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Thêm Nhãn Độ nhạy kèm Ký hiệu Nội dung**

Sử dụng [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/add/) với định danh nhãn, định danh trang, trạng thái bật và phương thức gán. Truyền định danh trang dưới dạng đối tượng Python `uuid.UUID`. Sau khi phương thức trả về [SensitivityLabel](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/) mới, thêm các giá trị ký hiệu cần thiết vào [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Ví dụ sau thêm một nhãn được chọn thủ công, liên kết với ký hiệu chân trang và watermark, và sau đó lưu kết quả dưới dạng PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập nhật Nhãn Độ nhạy**

Các thuộc tính của [SensitivityLabel](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) được sửa đổi thông qua các thao tác danh sách của nó. Sau khi xác định được nhãn cần thiết, bạn có thể cập nhật định danh, định danh trang, trạng thái bật, phương thức gán, trạng thái xóa và các loại ký hiệu nội dung. Lưu bản trình bày để ghi lại các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Đánh dấu Nhãn Độ nhạy là Đã Xóa**

Để giữ lại thông tin rằng một nhãn đã bị xóa, tìm nhãn và đặt [SensitivityLabel.is_removed](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/is_removed/) thành `True`. Điều này giữ lại mục nhãn đồng thời ghi lại trạng thái đã xóa. Nếu bạn muốn xóa một mục khỏi bộ sưu tập hiện đại, hãy sử dụng [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); sử dụng [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/clear/) để xóa mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã xóa và lưu bản trình bày đã cập nhật:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Đọc và Di chuyển Nhãn Độ nhạy Legacy MIP**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn độ nhạy trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Phương thức này phân tích các thuộc tính tùy chỉnh legacy và trả về các đối tượng [SensitivityLabel](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn trả về vào [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/) hiện đại thông qua [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/add/). Vì việc thêm một định danh nhãn trùng lặp sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để xác nhận mỗi nhãn legacy vẫn tồn tại trong chính sách Purview hiện tại.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa toàn bộ thuộc tính tài liệu tùy chỉnh, vì vậy siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) cùng với [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Thêm một loại ký hiệu nội dung có tạo tiêu đề, chân trang hoặc watermark hiển thị trên các slide không?**

Không. Các giá trị được thêm qua [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) mô tả các ký hiệu liên quan đến nhãn độ nhạy. Chúng không tạo ra văn bản hay hình dạng hiển thị trong bản trình bày. Nếu quy trình của bạn cần hiển thị các ký hiệu đó, hãy thêm nội dung slide tương ứng riêng biệt.

**Sự khác nhau giữa việc đánh dấu một nhãn là đã xóa và việc xóa nó khỏi bộ sưu tập là gì?**

Đặt [SensitivityLabel.is_removed](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/is_removed/) thành `True` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) sẽ xóa mục khỏi bộ sưu tập hiện đại. Hãy chọn thao tác phù hợp với yêu cầu lưu trữ siêu dữ liệu của tổ chức bạn.

**Một bản trình bày có thể chứa cả siêu dữ liệu MIP legacy và nhãn độ nhạy hiện đại không?**

Có. Các nhãn legacy có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại có sẵn qua [Presentation.sensitivity_labels](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sensitivity_labels/). Sử dụng [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) để đọc siêu dữ liệu legacy và chỉ di chuyển các nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Đi gì sẽ xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabelcollection/add/) gây ra ngoại lệ khi bộ sưu tập đã chứa một nhãn có cùng định danh. Kiểm tra các giá trị [SensitivityLabel.id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sensitivitylabel/id/) hiện có trước khi thêm hoặc di chuyển nhãn.

**Định dạng xuất nào nên được sử dụng để giữ lại các nhãn độ nhạy đã cập nhật?**

Lưu bản trình bày dưới dạng PPTX bằng cách gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) cùng với [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/), như đã minh họa trong các ví dụ ở trên.