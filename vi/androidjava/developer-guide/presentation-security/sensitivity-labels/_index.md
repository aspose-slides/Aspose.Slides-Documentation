---
title: Quản lý Nhãn Độ Nhạy trong Bản Trình Bày PowerPoint trên Android
linktitle: Nhãn Độ Nhạy
type: docs
weight: 50
url: /vi/androidjava/sensitivity-labels/
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
- bảo mật bản trình bày
- Android
- Java
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển các nhãn độ nhạy Microsoft Purview trong các bản trình bày PowerPoint PPTX bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình bày tự động, một ứng dụng có thể cần giữ nguyên nhãn hiện có, áp dụng nhãn được chọn bởi một chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ hơn.

Aspose.Slides for Android via Java cung cấp siêu dữ liệu nhãn độ nhạy hiện đại thông qua [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Phương thức này trả về một [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/) mà có thể được kiểm tra và sửa đổi trước khi bản trình bày được lưu dưới dạng PPTX.

{{% alert color="info" title="Lưu ý" %}}
Các định danh nhãn độ nhạy và thông tin chính sách được định nghĩa bởi cấu hình Microsoft Purview của bạn. Xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị của [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) mô tả các dấu hiệu nội dung liên quan đến một nhãn; chúng không tự tạo văn bản hay hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu Thuộc tính Nhãn Độ Nhạy**

Mỗi [ISensitivityLabel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/) chứa các siêu dữ liệu sau:

| Phương thức | Mục đích |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getId--) và [ISensitivityLabel.setId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Lấy hoặc đặt định danh nhãn độ nhạy trong chính sách Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) và [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Lấy hoặc đặt site liên quan đến chính sách nhãn. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) và [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Lấy hoặc đặt trạng thái bật/tắt của nhãn. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) và [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Lấy hoặc đặt liệu nhãn đã bị xóa hay chưa. Đặt giá trị thành `true` khi trạng thái xóa phải được giữ trong siêu dữ liệu. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) và [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Lấy hoặc đặt liệu nhãn được áp dụng tự động hay thông qua quyết định của người dùng. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Lấy các loại dấu hiệu nội dung liên quan đến nhãn. |

Lớp [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) định nghĩa cách mà một nhãn được gán:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng thông qua quyết định người dùng, bao gồm các nhãn được áp dụng thủ công, được đề xuất và bắt buộc.

Lớp [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) định nghĩa dấu hiệu liên quan đến một nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Dấu hiệu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Dấu hiệu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Dấu hiệu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại dấu hiệu có thể được gắn vào cùng một nhãn.

## **Liệt kê Các Nhãn Độ Nhạy Hiện Có**

Đọc bộ sưu tập nhãn hiện đại từ [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) và duyệt chúng. Ví dụ sau liệt kê mọi thuộc tính và dấu hiệu nội dung được lưu cho mỗi nhãn:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Nhãn Độ Nhạy với Đánh Dấu Nội Dung**

Sử dụng [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) với định danh nhãn, định danh site, trạng thái bật và phương thức gán. Sau khi phương thức trả về [ISensitivityLabel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/) mới, thêm các giá trị dấu hiệu cần thiết qua danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Ví dụ sau thêm một nhãn được chọn thủ công có dấu hiệu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cập Nhật Nhãn Độ Nhạy**

Các giá trị của [ISensitivityLabel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) được sửa đổi qua các thao tác danh sách. Sau khi xác định nhãn cần thiết, bạn có thể cập nhật định danh, định danh site, trạng thái bật, phương thức gán, trạng thái xóa và các loại dấu hiệu nội dung. Lưu bản trình bày để lưu các thay đổi.

Ví dụ sau cập nhật trạng thái bật và phương thức gán của nhãn đầu tiên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đánh Dấu Nhãn Độ Nhạy là Đã Xóa**

Để bảo tồn thông tin rằng một nhãn đã bị xóa, tìm nhãn và gọi [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) với `true`. Điều này giữ lại mục nhãn trong khi ghi lại trạng thái đã xóa. Nếu bạn muốn xóa mục khỏi bộ sưu tập hiện đại, sử dụng [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); dùng [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) để xóa mọi mục.

Ví dụ sau đánh dấu một nhãn cụ thể là đã xóa và lưu bản trình bày đã cập nhật:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đọc và Di Chuyển Nhãn Độ Nhạy Legacy MIP**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn độ nhạy trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Phương thức này phân tích các thuộc tính tùy chỉnh legacy và trả về một mảng các đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn đã trả về vào [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/) hiện đại thông qua [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Vì việc thêm một định danh nhãn trùng lặp sẽ gây ra ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để xác nhận mỗi nhãn legacy vẫn tồn tại trong chính sách Purview hiện tại.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Không cần xóa tất cả thuộc tính tài liệu tùy chỉnh, vì vậy siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [IPresentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Thêm một loại dấu hiệu nội dung có tạo ra tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm qua danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) mô tả các dấu hiệu liên quan đến nhãn độ nhạy. Chúng không tạo ra văn bản hay hình dạng hiển thị trong bản trình bày. Nếu quy trình của bạn cần hiển thị các dấu hiệu đó, hãy thêm nội dung slide tương ứng riêng biệt.

**Sự khác biệt giữa việc đánh dấu một nhãn là đã xóa và việc xóa nó khỏi bộ sưu tập là gì?**

Gọi [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) với `true` giữ lại mục nhãn và ghi lại trạng thái đã xóa. Gọi [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) sẽ xóa mục khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu trữ siêu dữ liệu của tổ chức bạn.

**Một bản trình bày có thể chứa cả siêu dữ liệu MIP legacy và nhãn độ nhạy hiện đại không?**

Có. Các nhãn legacy có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại có thể truy cập qua [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Sử dụng [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) để đọc siêu dữ liệu legacy và chỉ di chuyển những nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) sẽ ném ngoại lệ nếu bộ sưu tập đã chứa nhãn có cùng định danh. Kiểm tra các giá trị hiện có trả về bởi [ISensitivityLabel.getId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isensitivitylabel/#getId--) trước khi thêm hoặc di chuyển nhãn.

**Định dạng xuất nào nên dùng để bảo tồn các nhãn độ nhạy đã cập nhật?**

Lưu bản trình bày dưới dạng PPTX bằng cách gọi [IPresentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/), như đã minh họa trong các ví dụ ở trên.