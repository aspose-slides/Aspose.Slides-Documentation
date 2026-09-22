---
title: Mở Bản Trình Chiếu trong JavaScript
linktitle: Mở Bản Trình Chiếu
type: docs
weight: 20
url: /vi/nodejs-java/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình chiếu
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình chiếu
- tải PPTX
- tải PPT
- tải ODP
- bản trình chiếu được bảo vệ
- bản trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình chiếu PowerPoint và OpenDocument trong JavaScript, cung cấp mật khẩu mở, kiểm soát tải tài nguyên, và giảm việc sử dụng bộ nhớ với Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/vi/nodejs-java/) có thể tải các bản trình chiếu PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bản trình chiếu được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc một định dạng được hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ Node.js, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bản Trình Chiếu**

Sau khi tải tệp hoặc luồng, bạn có thể [xác định định dạng bản trình chiếu gốc](/slides/vi/nodejs-java/detect-presentation-source-format/) để chọn cách ứng dụng của bạn xử lý nó.

Để mở một bản trình chiếu hiện có, truyền đường dẫn tệp của nó vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Hủy bỏ bản trình chiếu sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ JavaScript sau đây cho thấy cách mở một bản trình chiếu và lấy số lượng slide:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở Bản Trình Chiếu Được Bảo Vệ Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung bản trình chiếu. Để tải đầy đủ bản trình chiếu, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword) và cung cấp các tùy chọn cho hàm tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc sai.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Để biết thêm về phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/nodejs-java/password-protected-presentation/). Nếu một bản trình chiếu được mã hoá được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/nodejs-java/presentation-properties/).

## **Mở Bản Trình Chiếu Lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã JavaScript sau đây minh họa cách tải một bản trình chiếu lớn (ví dụ, 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng bản trình chiếu được hủy. Không di chuyển, ghi đè hoặc xóa tệp nguồn khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào khi tải. Đối với các bản trình chiếu lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/nodejs-java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) chấp nhận một triển khai [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/). Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bản trình chiếu chứa hình ảnh bên ngoài phải được giải quyết theo các quy tắc bảo mật hoặc lưu trữ riêng của ứng dụng.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Tải Bản Trình Chiếu mà không có Đối Tượng Nhị Phân Nhúng**

Một bản trình chiếu có thể chứa dữ liệu nhị phân nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Ví dụ bao gồm:

- Dự án VBA, có sẵn thông qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getVbaProject);
- Dữ liệu OLE nhúng, có sẵn thông qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Dữ liệu điều khiển ActiveX, có sẵn thông qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) thành `true` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bản trình chiếu đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm thiểu nguy cơ các tải trọng nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung đầy đủ.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết rằng một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra một ngoại lệ phân tích cú pháp hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt so với lỗi mật khẩu sai để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu thiếu phông chữ bắt buộc?**

Bản trình chiếu vẫn có thể tải, nhưng quá trình render và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/nodejs-java/font-substitution/) hoặc [provide custom fonts](/slides/vi/nodejs-java/custom-font/) để làm cho đầu ra dự đoán hơn.

**Việc tải một bản trình chiếu có tải cả phương tiện nhúng không?**

Âm thanh và video nhúng sẽ khả dụng qua mô hình đối tượng của bản trình chiếu. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.