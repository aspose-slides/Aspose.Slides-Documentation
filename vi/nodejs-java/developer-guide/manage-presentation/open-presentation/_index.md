---
title: Mở Bản Trình Bày trong JavaScript
linktitle: Mở Bản Trình Bày
type: docs
weight: 20
url: /vi/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình bày PowerPoint và OpenDocument bằng JavaScript, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm việc sử dụng bộ nhớ với Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

[Aspose.Slides cho Node.js qua Java](https://products.aspose.com/slides/vi/nodejs-java/) có thể tải các bản trình bày PowerPoint và OpenDocument từ tệp và luồng. Sau khi bản trình bày được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu lại ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/) . Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ Node.js, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở bản trình bày**

Để mở một bản trình bày hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) . Giải phóng (dispose) bản trình bày sau khi sử dụng để các trình xử lý tệp, dữ liệu tạm và các tài nguyên khác được giải phóng kịp thời.

Ví dụ JavaScript sau đây cho thấy cách mở một bản trình bày và lấy số lượng slide:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở bản trình bày có bảo vệ bằng mật khẩu**

Mật khẩu mở mã hoá nội dung bản trình bày. Để tải toàn bộ bản trình bày, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword) và cung cấp các tùy chọn cho hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) . Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

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

Để biết cách phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/nodejs-java/password-protected-presentation/). Nếu một bản trình bày được mã hoá nhưng được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/nodejs-java/presentation-properties/).

## **Mở bản trình bày lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã JavaScript sau đây minh họa việc tải một bản trình bày lớn (ví dụ, 2 GB):

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
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho tới khi đối tượng Presentation được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với các bản trình bày lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/nodejs-java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm soát tài nguyên bên ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) chấp nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/) . Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi bản trình bày chứa hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ đặc thù của ứng dụng.

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

## **Tải bản trình bày mà không có các đối tượng nhị phân nhúng**

Một bản trình bày có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Ví dụ bao gồm:

- Dự án VBA, có sẵn qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getVbaProject);
- Dữ liệu OLE nhúng, có sẵn qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Dữ liệu điều khiển ActiveX, có sẵn qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) thành `true` để loại bỏ dữ liệu nhị phân này trong quá trình tải. Lưu bản trình bày đã tải để lưu kết quả đã được làm sạch.

Tùy chọn này giảm thiểu nguy cơ tiếp xúc với các payload nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung đầy đủ.

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

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra một ngoại lệ phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ yêu cầu bị thiếu?**

Bản trình bày vẫn có thể được tải, nhưng quá trình render và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/nodejs-java/font-substitution/) hoặc [provide custom fonts](/slides/vi/nodejs-java/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình bày có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video nhúng sẽ khả dụng thông qua mô hình đối tượng của bản trình bày. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.