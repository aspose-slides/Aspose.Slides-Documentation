---
title: Bảo vệ mật khẩu cho các bản trình chiếu trong JavaScript
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/nodejs-java/password-protected-presentation/
keywords:
- bản trình chiếu bảo mật bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo mật bằng mật khẩu trong JavaScript với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Cần mật khẩu đúng để tải và xem nội dung bản trình chiếu, do đó bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/nodejs-java/write-protected-presentation/).

Các quy trình làm việc bên dưới áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#encrypt) để chỉ định mật khẩu mở khóa. Sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Giữ thuộc tính tài liệu công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hoá bản trình chiếu. Phương thức [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) điều khiển hành vi này một cách độc lập với việc mã hoá nội dung slide. Gửi `false` trước khi gọi [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#encrypt) khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không cần mật khẩu mở khóa.

Ví dụ sau tạo một bản trình chiếu PPTX đã mã hoá trong khi để các thuộc tính tài liệu tích hợp sẵn công khai:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc gửi `false` tới [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) không làm cho các slide, master, layout, shape, media hoặc nội dung khác của bản trình chiếu công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã mã hoá, xem [Manage Presentation Properties](/slides/vi/nodejs-java/presentation-properties/).

## **Tải bản trình chiếu đã mã hoá**

Đặt [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword) thành mật khẩu mở khóa và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu được cung cấp thiếu hoặc không đúng.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Làm việc với bản trình chiếu đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Gỡ bỏ mã hoá khỏi bản trình chiếu**

Tải bản trình chiếu với mật khẩu mở khóa, gọi [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#removeEncryption), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/) mà không tạo một thể hiện bản trình chiếu hoàn chỉnh. Kiểm tra [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị được cung cấp bằng [PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Quy trình dựa trên đường dẫn tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword), và sau đó tải bản trình chiếu hoàn chỉnh:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Quy trình dựa trên luồng**

Sử dụng [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) để kiểm tra một luồng đọc được của Node.js. Sau khi luồng kiểm tra đã được tiêu thụ, tạo một luồng mới trước khi tải bản trình chiếu hoàn chỉnh bằng [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Ví dụ sau sử dụng tệp PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Giá trị trả về của checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau cho các bản trình chiếu PPT và PPTX.

## **Kiểm tra xem bản trình chiếu đã tải có được mã hoá không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) để xác nhận bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) như đã mô tả ở trên.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc chèn chúng vào các thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, ghi chú và giá trị tùy chỉnh ngay cả khi nội dung bản trình chiếu đã được mã hoá. Hãy mã hoá siêu dữ liệu nhạy cảm cùng với bản trình chiếu. Việc để các thuộc tính công khai nên là quyết định rõ ràng, chỉ thực hiện khi các hệ thống cần lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không có mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ mật khẩu một bản trình chiếu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ khi xem.
4. Tùy chọn nhập một mật khẩu riêng để bảo vệ khi chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp đã tạo.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/vi/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình chiếu hoàn chỉnh.

**Ứng dụng có thể đọc siêu dữ liệu mà không có mật khẩu mở khóa không?**

Có, nhưng chỉ khi bản trình chiếu được mã hoá với tính năng mã hoá thuộc tính tài liệu đã bị tắt. Khi đó, ứng dụng phải sử dụng chế độ tải chỉ các thuộc tính tài liệu được mô tả trong [Manage Presentation Properties](/slides/vi/nodejs-java/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình chiếu PPT và PPTX.