---
title: Quản lý Nhãn Độ nhạy trong Bản trình chiếu PowerPoint bằng Java
linktitle: Nhãn Độ nhạy
type: docs
weight: 50
url: /vi/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Đọc, thêm, cập nhật, xóa và di chuyển nhãn độ nhạy Microsoft Purview trong các bản trình bày PowerPoint PPTX với Aspose.Slides cho Java."
---
## **Tổng quan**

Microsoft Purview sensitivity labels giúp các tổ chức phân loại và quản lý tài liệu. Trong quá trình xử lý bản trình bày tự động, một ứng dụng có thể cần giữ lại nhãn hiện có, áp dụng nhãn được chọn bởi chính sách, cập nhật trạng thái của nó, hoặc di chuyển siêu dữ liệu nhãn được ghi bởi quy trình Microsoft Information Protection (MIP) cũ.

Aspose.Slides cung cấp siêu dữ liệu nhãn độ nhạy hiện đại thông qua [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Phương thức này trả về một [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/) có thể được kiểm tra và sửa đổi trước khi bản trình bày được lưu dưới dạng PPTX.

{{% alert color="primary" title="Lưu ý" %}}
Các định danh nhãn độ nhạy và thông tin chính sách do cấu hình Microsoft Purview của bạn xác định. Hãy xác thực tính khả dụng của nhãn và yêu cầu chính sách trong môi trường của bạn trước khi thêm hoặc di chuyển siêu dữ liệu. Các giá trị của [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) mô tả các đánh dấu nội dung liên quan đến một nhãn; chúng không tự động tạo văn bản hoặc hình dạng hiển thị trên các slide.
{{% /alert %}}

## **Hiểu các Thuộc tính Nhãn Độ nhạy**

Mỗi [ISensitivityLabel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/) chứa các siêu dữ liệu sau:

| Phương thức | Mục đích |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getId--) và [ISensitivityLabel.setId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Lấy hoặc đặt định danh nhãn độ nhạy trong chính sách Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getSiteId--) và [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Lấy hoặc đặt site liên kết với chính sách nhãn. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#isEnabled--) và [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Lấy hoặc đặt trạng thái nhãn có được bật hay không. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#isRemoved--) và [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Lấy hoặc đặt trạng thái nhãn đã bị xóa. Đặt giá trị thành `true` khi cần giữ lại trạng thái xóa trong siêu dữ liệu. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) và [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Lấy hoặc đặt cách nhãn được áp dụng tự động hay qua quyết định của người dùng. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Lấy các loại đánh dấu nội dung liên quan đến nhãn. |

Lớp [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelassignmenttype/) định nghĩa cách nhãn được gán:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn mặc định hoặc được áp dụng tự động.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelassignmenttype/) đại diện cho nhãn được áp dụng qua quyết định của người dùng, bao gồm nhãn được áp dụng thủ công, đề xuất và bắt buộc.

Lớp [SensitivityLabelContentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) định nghĩa loại đánh dấu liên quan tới nhãn:

| Giá trị | Ý nghĩa |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) | Nhãn được áp dụng mặc định hoặc tự động. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung tiêu đề được liên kết với nhãn. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung chân trang được liên kết với nhãn. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) | Đánh dấu nội dung watermark được liên kết với nhãn. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sensitivitylabelcontenttype/) | Bảo vệ mã hoá được liên kết với nhãn. |

Nhiều loại đánh dấu có thể được gắn vào cùng một nhãn.

## **Liệt kê Các Nhãn Độ nhạy Hiện có**

Đọc bộ sưu tập nhãn hiện đại từ [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) và duyệt qua nó. Ví dụ dưới đây liệt kê mọi thuộc tính và đánh dấu nội dung được lưu cho mỗi nhãn:

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

## **Thêm Nhãn Độ nhạy với Đánh dấu Nội dung**

Sử dụng [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) với định danh nhãn, định danh site, trạng thái bật và phương pháp gán. Sau khi phương thức trả về đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/) mới, thêm các giá trị đánh dấu yêu cầu qua danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Ví dụ dưới đây thêm một nhãn được người dùng chọn thủ công, liên kết với các đánh dấu chân trang và watermark, sau đó lưu kết quả dưới dạng PPTX:

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

## **Cập nhật Nhãn Độ nhạy**

Các giá trị của [ISensitivityLabel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/) có thể đọc/ghi, ngoại trừ danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) được sửa đổi thông qua các thao tác danh sách của nó. Sau khi xác định nhãn cần thiết, bạn có thể cập nhật định danh, định danh site, trạng thái bật, phương pháp gán, trạng thái xóa và các loại đánh dấu nội dung. Lưu bản trình bày để lưu các thay đổi.

Ví dụ dưới đây cập nhật trạng thái bật và phương pháp gán của nhãn đầu tiên:

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

## **Đánh dấu Nhãn Độ nhạy là Đã xóa**

Để giữ lại thông tin một nhãn đã bị xóa, tìm nhãn và gọi [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) với `true`. Thao tác này giữ lại mục nhập nhãn đồng thời ghi nhận trạng thái đã xóa. Nếu bạn muốn xóa mục nhập khỏi bộ sưu tập hiện đại, sử dụng [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); dùng [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#clear--) để xóa mọi mục.

Ví dụ dưới đây đánh dấu một nhãn cụ thể là đã xóa và lưu bản trình bày đã cập nhật:

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

## **Đọc và Di chuyển Nhãn Độ nhạy MIP Cũ**

Các quy trình dựa trên MIP cũ có thể lưu siêu dữ liệu nhãn độ nhạy trong thuộc tính tài liệu tùy chỉnh thay vì bộ sưu tập nhãn hiện đại. Đọc siêu dữ liệu đó bằng [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Phương thức này phân tích các thuộc tính tùy chỉnh cổ và trả về một mảng các đối tượng [ISensitivityLabel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/).

Để di chuyển siêu dữ liệu, thêm mỗi nhãn đã trả về vào [ISensitivityLabelCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/) hiện đại thông qua [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Vì việc thêm một định danh nhãn trùng sẽ gây ngoại lệ, ví dụ kiểm tra bộ sưu tập đích trước khi sao chép mỗi nhãn. Bạn có thể thêm xác thực bổ sung để đảm bảo mỗi nhãn cũ vẫn tồn tại trong chính sách Purview hiện tại.

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

Quá trình di chuyển sao chép các đối tượng nhãn đã phân tích vào bộ sưu tập hiện đại. Nó không yêu cầu xóa hết các thuộc tính tài liệu tùy chỉnh, vì vậy các siêu dữ liệu tài liệu không liên quan vẫn được giữ nguyên. Sử dụng [IPresentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) cùng với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) để ghi siêu dữ liệu nhãn hiện đại vào tệp PPTX.

## **Câu hỏi thường gặp**

**Việc thêm một loại đánh dấu nội dung có tạo tiêu đề, chân trang hoặc watermark hiển thị trên slide không?**

Không. Các giá trị được thêm qua danh sách trả về bởi [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) mô tả các đánh dấu liên quan tới nhãn độ nhạy. Chúng không tạo văn bản hoặc hình dạng hiển thị trong bản trình bày. Hãy thêm nội dung slide tương ứng riêng nếu quy trình của bạn cần hiển thị các đánh dấu đó.

**Sự khác nhau giữa việc đánh dấu một nhãn là đã xóa và xóa nó khỏi bộ sưu tập là gì?**

Gọi [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) với `true` giữ lại mục nhập nhãn và ghi nhận trạng thái đã xóa. Gọi [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) xóa mục nhập khỏi bộ sưu tập hiện đại. Chọn thao tác phù hợp với yêu cầu lưu giữ siêu dữ liệu của tổ chức bạn.

**Một bản trình bày có thể chứa cả siêu dữ liệu MIP cũ và nhãn độ nhạy hiện đại không?**

Có. Các nhãn cũ có thể vẫn tồn tại trong thuộc tính tài liệu tùy chỉnh trong khi các nhãn hiện đại được truy cập qua [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Sử dụng [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) để đọc siêu dữ liệu cũ và chỉ di chuyển các nhãn hợp lệ chưa có trong bộ sưu tập hiện đại.

**Điều gì xảy ra khi một nhãn có cùng định danh được thêm nhiều lần?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) sẽ ném ngoại lệ khi bộ sưu tập đã chứa một nhãn có cùng định danh. Kiểm tra các giá trị hiện có trả về bởi [ISensitivityLabel.getId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isensitivitylabel/#getId--) trước khi thêm hoặc di chuyển nhãn.

**Định dạng đầu ra nào nên được dùng để bảo toàn các nhãn độ nhạy đã cập nhật?**

Lưu bản trình bày dưới dạng PPTX bằng cách gọi [IPresentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/), như đã minh họa trong các ví dụ ở trên.