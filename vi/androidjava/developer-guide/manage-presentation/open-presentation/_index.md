---
title: Mở Bài Thuyết Trình trên Android
linktitle: Mở Bài Thuyết Trình
type: docs
weight: 20
url: /vi/androidjava/open-presentation/
keywords:
- mở PowerPoint
- mở bài thuyết trình
- mở PPTX
- mở PPT
- mở ODP
- tải bài thuyết trình
- tải PPTX
- tải PPT
- tải ODP
- bài thuyết trình được bảo mật
- bài thuyết trình lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách mở các bài thuyết trình PowerPoint và OpenDocument trên Android, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm sử dụng bộ nhớ với Aspose.Slides cho Android thông qua Java."
---
## **Giới thiệu**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/vi/androidjava/) có thể tải các bài thuyết trình PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bài thuyết trình được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu lại ở định dạng gốc hoặc định dạng được hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ heap của Java, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bài Thuyết Trình**

Sau khi tải tệp hoặc luồng, bạn có thể [xác định định dạng bài thuyết trình gốc](/slides/vi/androidjava/detect-presentation-source-format/) để chọn cách ứng dụng của bạn xử lý nó.

Để mở một bài thuyết trình hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Hủy đối tượng presentation sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Java sau cho thấy cách mở một bài thuyết trình và lấy số lượng slide của nó:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở Bài Thuyết Trình Được Bảo Mật Bằng Mật Khẩu**

Mật khẩu mở mã hóa nội dung bài thuyết trình. Để tải toàn bộ bài thuyết trình, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) và cung cấp các tùy chọn cho hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu thiếu hoặc không đúng.

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

Đối với các quy trình phát hiện, xác thực và mã hóa mật khẩu, xem [Password-Protect Presentations](/slides/vi/androidjava/password-protected-presentation/). Nếu một bài thuyết trình đã được mã hóa nhưng được lưu có thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/androidjava/presentation-properties/).

## **Mở Bài Thuyết Trình Lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã Java sau minh họa cách tải một bài thuyết trình lớn (ví dụ, 2 GB):

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
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng presentation được giải phóng. Không di chuyển, ghi đè, hoặc xóa tệp nguồn trong khi phiên bản này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng nhập khi tải. Đối với các bài thuyết trình lớn, do đó đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/androidjava/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) chấp nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iresourceloadingcallback/). Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bài thuyết trình chứa hình ảnh bên ngoài cần được xử lý theo các quy tắc bảo mật hoặc lưu trữ đặc thù của ứng dụng.

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

## **Tải Bài Thuyết Trình mà Không Có Các Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình có thể chứa dữ liệu nhị phân nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, có sẵn thông qua [IPresentation.getVbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- Dữ liệu OLE nhúng, có sẵn thông qua [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- Dữ liệu điều khiển ActiveX, có sẵn thông qua [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) thành `true` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bài thuyết trình đã tải để giữ lại kết quả đã được làm sạch.

Tùy chọn này giảm nguy cơ tiếp xúc với các gói tin nhúng không muốn, nhưng nó không phải là một hệ thống phát hiện phần mềm độc hại hay làm sạch nội dung hoàn chỉnh.

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

## **Câu hỏi thường gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides sẽ ném ra ngoại lệ phân tích hoặc định dạng khi tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ yêu cầu bị thiếu?**

Bài thuyết trình vẫn có thể tải, nhưng việc render và xuất ra có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/androidjava/font-substitution/) hoặc [provide custom fonts](/slides/vi/androidjava/custom-font/) để làm cho đầu ra dự đoán được hơn.

**Việc tải một bài thuyết trình có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video nhúng sẽ khả dụng thông qua mô hình đối tượng của bài thuyết trình. Các tài nguyên bên ngoài được giải quyết dựa trên hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập đến vị trí của chúng.