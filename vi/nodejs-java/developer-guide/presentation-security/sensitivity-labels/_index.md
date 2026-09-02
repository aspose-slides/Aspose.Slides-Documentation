---
title: Quản lý Nhãn Độ nhạy trong Bài thuyết trình PowerPoint bằng JavaScript
linktitle: Nhãn Độ nhạy
type: docs
weight: 50
url: /vi/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xoá và di chuyển các nhãn độ nhạy Microsoft Purview trong các bản trình chiếu PowerPoint PPTX bằng Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình chiếu tự động, một ứng dụng có thể cần bảo tồn nhãn hiện có, áp dụng nhãn được chọn theo chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides for Node.js via Java cung cấp siêu dữ liệu nhãn độ nhạy hiện đại thông qua [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Phương thức này trả về một [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/) có thể được kiểm tra và chỉnh sửa trước khi bản trình chiếu được lưu dưới dạng PPTX.

{{% alert color="primary" title="Note" %}}
Các định danh nhãn độ nhạy và thông tin chính sách được xác định bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị của [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) mô tả các đánh dấu nội dung liên quan đến nhãn; chúng không tự động tạo văn bản hay hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu Thuộc tính Nhãn Độ nhạy**

Mỗi [SensitivityLabel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/) chứa các siêu dữ liệu sau:

| Phương thức | Mục đích |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getId) và [SensitivityLabel.setId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Lấy hoặc đặt định danh nhãn độ nhạy trong chính sách Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) và [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Lấy hoặc đặt site liên quan tới chính sách nhãn. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) và [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Lấy hoặc đặt trạng thái bật của nhãn. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) và [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Lấy hoặc đặt liệu nhãn đã bị xoá hay chưa. Đặt giá trị thành `true` khi trạng thái xoá cần được giữ lại trong siêu dữ liệu. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) và [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Lấy hoặc đặt liệu nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Lấy các loại đánh dấu nội dung liên quan tới nhãn. |

Lớp [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) định nghĩa cách một nhãn được gán:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) biểu thị nhãn mặc định hoặc được áp dụng tự động.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) biểu thị nhãn được áp dụng thông qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, đề xuất và bắt buộc.

Lớp [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) định nghĩa các đánh dấu liên quan tới một nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung tiêu đề liên quan tới nhãn. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang liên quan tới nhãn. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark liên quan tới nhãn. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá liên quan tới nhãn. |

Nhiều loại đánh dấu có thể được liên kết với một nhãn.

## **Liệt kê Nhãn Độ nhạy hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) và liệt kê nó. Ví dụ sau liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Nhãn Độ nhạy với Đánh dấu Nội dung**

Sử dụng [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) với định danh nhãn, định danh site, trạng thái bật và phương thức gán. Sau khi phương thức trả về [SensitivityLabel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/), thêm các giá trị đánh dấu cần thiết thông qua danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Ví dụ sau thêm một nhãn được chọn thủ công có liên quan tới đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cập nhật Nhãn Độ nhạy**

Các giá trị của [SensitivityLabel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) được chỉnh sửa thông qua các thao tác danh sách của nó. Sau khi tìm được nhãn cần thiết, bạn có thể cập nhật định danh, định danh site, trạng thái bật, phương thức gán, trạng thái xoá và các loại đánh dấu nội dung. Lưu bản trình chiếu để ghi lại các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đánh dấu Nhãn Độ nhạy là Đã Xoá**

Để bảo tồn thông tin rằng một nhãn đã bị xoá, tìm nhãn và gọi [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) với `true`. Điều này giữ lại mục nhãn đồng thời ghi lại trạng thái đã xoá. Nếu bạn muốn xoá một mục khỏi bộ sưu tập hiện đại, sử dụng [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); dùng [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) để xoá mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã xoá và lưu bản trình chiếu đã cập nhật:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đọc và Di chuyển Nhãn Độ nhạy MIP Cũ**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn độ nhạy trong các thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Phương thức này phân tích các thuộc tính tùy chỉnh cũ và trả về một mảng các đối tượng [SensitivityLabel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm từng nhãn trả về vào [SensitivityLabelCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/) hiện đại thông qua [SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Vì việc thêm một định danh nhãn trùng sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để xác nhận mỗi nhãn cũ vẫn tồn tại trong chính sách Purview hiện tại.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa tất cả các thuộc tính tài liệu tùy chỉnh, vì vậy các siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Thêm một loại đánh dấu nội dung có tạo tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm thông qua danh sách trả về bởi [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) mô tả các đánh dấu liên quan tới nhãn độ nhạy. Chúng không tạo ra văn bản hay hình dạng hiển thị trong bản trình chiếu. Thêm nội dung slide tương ứng riêng biệt nếu quy trình của bạn cần hiển thị các đánh dấu đó.

**Sự khác biệt giữa việc đánh dấu một nhãn là đã xoá và việc xoá nó khỏi bộ sưu tập là gì?**

Gọi [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) với `true` giữ lại mục nhãn và ghi lại trạng thái đã xoá. Gọi [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) xoá mục khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu giữ siêu dữ liệu của tổ chức bạn.

**Một bản trình chiếu có thể chứa cả siêu dữ liệu MIP cũ và nhãn độ nhạy hiện đại không?**

Có. Các nhãn cũ có thể vẫn tồn tại trong các thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại có sẵn qua [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Sử dụng [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) để đọc siêu dữ liệu cũ và chỉ di chuyển các nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Đi gì sẽ xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) gây ra ngoại lệ khi bộ sưu tập đã chứa một nhãn có cùng định danh. Kiểm tra các giá trị hiện có trả về bởi [SensitivityLabel.getId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sensitivitylabel/#getId) trước khi thêm hoặc di chuyển nhãn.

**Định dạng đầu ra nào nên được sử dụng để bảo tồn các nhãn độ nhạy đã cập nhật?**

Lưu bản trình chiếu dưới dạng PPTX bằng cách gọi [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/), như đã minh họa trong các ví dụ ở trên.