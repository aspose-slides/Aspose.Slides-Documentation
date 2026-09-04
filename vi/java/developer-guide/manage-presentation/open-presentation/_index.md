---
title: Mở Bản Trình Bày trong Java
linktitle: Mở Bản Trình Bày
type: docs
weight: 20
url: /vi/java/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình bày
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình bày
- tải PPTX
- tải PPT
- tải ODP
- bản trình bày được bảo vệ
- bản trình bày lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Java
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình bày PowerPoint và OpenDocument trong Java, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm việc sử dụng bộ nhớ với Aspose.Slides cho Java."
---
## **Giới thiệu**

[Aspose.Slides cho Java](https://products.aspose.com/slides/vi/java/) có thể tải các bản trình bày PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bản trình bày được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc một định dạng khác được hỗ trợ.

Hành vi tải có thể được tuỳ chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ heap của Java, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bản Trình Bày**

Để mở một bản trình bày hiện có, truyền đường dẫn tệp của nó vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Hủy đối tượng bản trình bày sau khi sử dụng để các tay cầm tệp, dữ liệu tạm và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Java sau đây minh họa cách mở một bản trình bày và lấy số lượng slide:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở Bản Trình Bày Được Bảo Vệ Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung bản trình bày. Để tải đầy đủ bản trình bày, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) và cung cấp các tùy chọn cho hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Đối với các quy trình phát hiện, xác thực và mã hoá mật khẩu, xem [Password-Protect Presentations](/slides/vi/java/password-protected-presentation/). Nếu một bản trình bày được mã hoá được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/java/presentation-properties/).

## **Mở Bản Trình Bày Lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã Java sau đây minh họa cách tải một bản trình bày lớn (ví dụ, 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn vẫn bị khóa cho đến khi đối tượng bản trình bày được hủy. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào khi tải. Đối với các bản trình bày lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/). Callback có thể cung cấp dữ liệu thay thế, chuyển hướng một tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bản trình bày chứa ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ đặc thù của ứng dụng.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Tải Bản Trình Bày Không Có Đối Tượng Nhị Phân Được Nhúng**

Một bản trình bày có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Ví dụ bao gồm:

- VBA projects, available through [IPresentation.getVbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getVbaProject--);
- embedded OLE data, available through [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX control data, available through [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) thành `true` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bản trình bày đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm thiểu nguy cơ tiếp xúc với các payload được nhúng không mong muốn, nhưng nó không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra một ngoại lệ phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt so với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì sẽ xảy ra nếu các phông chữ cần thiết bị thiếu?**

Bản trình bày vẫn có thể tải, nhưng việc render và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/java/font-substitution/) hoặc [provide custom fonts](/slides/vi/java/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình bày có đồng thời tải các phương tiện được nhúng không?**

Âm thanh và video được nhúng sẽ khả dụng thông qua mô hình đối tượng của bản trình bày. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.