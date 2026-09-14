---
title: Quản lý Nhãn Nhạy cảm trong Bản trình chiếu PowerPoint bằng Python
linktitle: Nhãn Nhạy cảm
type: docs
weight: 50
url: /vi/python-java/sensitivity-labels/
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
- bảo mật bản trình chiếu
- Python
- Aspose.Slides
description: "Đọc, thêm, cập nhật, loại bỏ và di chuyển nhãn nhạy cảm Microsoft Purview trong các bản trình chiếu PowerPoint PPTX bằng Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý tự động bản trình chiếu, một ứng dụng có thể cần giữ lại nhãn hiện có, áp dụng nhãn được chọn bởi chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides cung cấp siêu dữ liệu nhãn nhạy cảm hiện đại thông qua [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSensitivityLabels). Phương thức này trả về một [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/) có thể được kiểm tra và chỉnh sửa trước khi bản trình chiếu được lưu dưới dạng PPTX.

{{% alert color="info" title="Note" %}}
Các định danh nhãn nhạy cảm và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị của [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) mô tả các đánh dấu nội dung liên kết với một nhãn; chúng không tự tạo ra văn bản hay hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu các thuộc tính của Nhãn Nhạy cảm**

| Phương thức | Mục đích |
| --- | --- |
| [getId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getId) và [setId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setId) | Lấy hoặc đặt định danh nhãn nhạy cảm trong chính sách Purview. |
| [getSiteId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getSiteId) và [setSiteId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Lấy hoặc đặt trang web liên kết với chính sách nhãn. |
| [isEnabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#isEnabled) và [setEnabled](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Lấy hoặc đặt trạng thái bật của nhãn. |
| [isRemoved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#isRemoved) và [setRemoved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Lấy hoặc đặt xem nhãn đã bị loại bỏ hay chưa. Đặt giá trị thành `True` khi trạng thái loại bỏ phải được giữ lại trong siêu dữ liệu. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) và [setAssignmentMethodType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Lấy hoặc đặt xem nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [getContentMarkTypes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Lấy các loại đánh dấu nội dung liên kết với nhãn. |

Lớp [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelassignmenttype/) định nghĩa cách một nhãn được gán:

- [Standard](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.
- [Privileged](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng thông qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, đề xuất và bắt buộc.

Lớp [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) định nghĩa đánh dấu liên kết với một nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [None](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [Header](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung đầu trang được liên kết với nhãn. |
| [Footer](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang được liên kết với nhãn. |
| [Watermark](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark được liên kết với nhãn. |
| [Encryption](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại đánh dấu có thể được liên kết với một nhãn.

## **Liệt kê các Nhãn Nhạy cảm hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSensitivityLabels) và liệt kê nó. Ví dụ sau liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Thêm Nhãn Nhạy cảm với Đánh dấu Nội dung**

Sử dụng [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#add) với định danh nhãn, định danh trang, trạng thái bật và phương thức gán. Sau khi phương thức trả về [SensitivityLabel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/) mới, thêm các giá trị đánh dấu cần thiết thông qua danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Ví dụ sau thêm một nhãn được chọn thủ công liên kết với các đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cập nhật Nhãn Nhạy cảm**

Các giá trị của [SensitivityLabel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) được sửa đổi thông qua các thao tác danh sách của nó. Sau khi tìm được nhãn cần thiết, bạn có thể cập nhật định danh, định danh trang, trạng thái bật, phương thức gán, trạng thái loại bỏ và các loại đánh dấu nội dung. Lưu bản trình chiếu để lưu các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đánh dấu Nhãn Nhạy cảm là Đã bị Loại bỏ**

Để giữ lại thông tin rằng một nhãn đã bị loại bỏ, tìm nhãn và gọi [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setRemoved) với `True`. Điều này giữ lại mục nhãn đồng thời ghi lại trạng thái đã bị loại bỏ. Nếu bạn muốn xóa một mục khỏi bộ sưu tập hiện đại, sử dụng [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); dùng [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#clear) để xóa mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã bị loại bỏ và lưu bản trình chiếu đã cập nhật:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đọc và Di chuyển Nhãn Nhạy cảm MIP Legacy**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn nhạy cảm trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Phương thức này phân tích các thuộc tính tùy chỉnh legacy và trả về một mảng các đối tượng [SensitivityLabel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn trả về vào [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/) hiện đại thông qua [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#add). Vì việc thêm định danh nhãn trùng lặp sẽ gây ra ngoại lệ, ví dụ này kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để xác nhận mỗi nhãn legacy vẫn tồn tại trong chính sách Purview hiện tại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa tất cả các thuộc tính tài liệu tùy chỉnh, vì vậy siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Thêm loại đánh dấu nội dung có tạo ra tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**  
Không. Các giá trị được thêm qua danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) mô tả các đánh dấu liên kết với nhãn nhạy cảm. chúng không tạo ra văn bản hoặc hình dạng hiển thị trong bản trình chiếu. Thêm nội dung slide tương ứng riêng biệt nếu quy trình của bạn cần hiển thị các đánh dấu đó.

**Sự khác biệt giữa việc đánh dấu một nhãn là đã bị loại bỏ và việc xóa nó khỏi bộ sưu tập là gì?**  
Gọi [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#setRemoved) với `True` giữ lại mục nhãn và ghi lại trạng thái đã bị loại bỏ. Gọi [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) xóa mục khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu giữ siêu dữ liệu của tổ chức bạn.

**Bản trình chiếu có thể chứa cả siêu dữ liệu MIP legacy và nhãn nhạy cảm hiện đại không?**  
Có. Các nhãn legacy có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại có sẵn qua [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSensitivityLabels). Sử dụng [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getSensitivityLabels) để đọc siêu dữ liệu legacy và chỉ di chuyển những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**  
[SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabelcollection/#add) ném ngoại lệ khi bộ sưu tập đã chứa nhãn có cùng định danh. Kiểm tra các giá trị hiện có được trả về bởi [SensitivityLabel.getId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sensitivitylabel/#getId) trước khi thêm hoặc di chuyển nhãn.

**Định dạng đầu ra nào nên được sử dụng để giữ lại các nhãn nhạy cảm đã cập nhật?**  
Lưu bản trình chiếu dưới dạng PPTX bằng cách gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/), như đã minh họa trong các ví dụ ở trên.