---
title: Mở bài thuyết trình trên Android
linktitle: Mở bài thuyết trình
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
- bài thuyết trình được bảo vệ
- bài thuyết trình lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách mở các bài thuyết trình PowerPoint và OpenDocument trên Android, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm sử dụng bộ nhớ với Aspose.Slides cho Android qua Java."
---
## **Giới thiệu**

[Aspose.Slides cho Android qua Java](https://products.aspose.com/slides/vi/androidjava/) có thể tải các bài thuyết trình PowerPoint và OpenDocument từ tệp và luồng. Sau khi tải bài thuyết trình, bạn có thể kiểm tra cấu trúc, chỉnh sửa slide, quản lý tài nguyên và lưu lại ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn bên ngoài bộ nhớ heap của Java, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở bài thuyết trình**

Để mở một bài thuyết trình hiện có, truyền đường dẫn tệp vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Hãy giải phóng (dispose) đối tượng presentation sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Java dưới đây cho thấy cách mở một bài thuyết trình và lấy số lượng slide:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở bài thuyết trình có mật khẩu**

Mật khẩu mở mã hoá nội dung bài thuyết trình. Để tải toàn bộ bài thuyết trình, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) và cung cấp các tùy chọn cho hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

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

Đối với việc phát hiện, xác thực mật khẩu và quy trình mã hoá, xem mục [Password-Protect Presentations](/slides/vi/androidjava/password-protected-presentation/). Nếu một bài thuyết trình được mã hoá nhưng được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó vẫn có thể đọc được mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/androidjava/presentation-properties/).

## **Mở bài thuyết trình lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã Java dưới đây minh họa cách tải một bài thuyết trình lớn (ví dụ, 2 GB):

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

{{% alert color="info" title="Ghi chú" %}}
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng presentation được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào khi tải. Đối với các bài thuyết trình lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/androidjava/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.

{{% /alert %}}

## **Kiểm soát tài nguyên bên ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) chấp nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iresourceloadingcallback/). Callback này có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi bài thuyết trình chứa hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ riêng của ứng dụng.

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

## **Tải bài thuyết trình mà không có các đối tượng nhị phân được nhúng**

Một bài thuyết trình có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Một số ví dụ:

- Dự án VBA, truy cập qua [IPresentation.getVbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- Dữ liệu OLE được nhúng, truy cập qua [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- Dữ liệu điều khiển ActiveX, truy cập qua [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) thành `true` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bài thuyết trình đã tải để giữ lại kết quả đã được làm sạch.

Tùy chọn này giảm nguy cơ tiếp xúc với các payload được nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

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

## **FAQ**

**Làm thế nào để biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra ngoại lệ phân tích hoặc định dạng trong quá trình tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể thông báo nguyên nhân một cách chính xác.

**Điều gì sẽ xảy ra nếu thiếu các phông chữ bắt buộc?**

Bài thuyết trình vẫn có thể được tải, nhưng quá trình render và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/androidjava/font-substitution/) hoặc [provide custom fonts](/slides/vi/androidjava/custom-font/) để đầu ra ổn định hơn.

**Việc tải một bài thuyết trình có đồng thời tải các phương tiện được nhúng không?**

Âm thanh và video được nhúng sẽ khả dụng thông qua mô hình đối tượng của bài thuyết trình. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.