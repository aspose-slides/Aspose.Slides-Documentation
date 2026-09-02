---
title: Bảo mật bản trình chiếu bằng mật khẩu trong JavaScript
linktitle: Bảo mật mật khẩu
type: docs
weight: 20
url: /vi/nodejs-java/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
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
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong JavaScript bằng Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Mật khẩu đúng là cần thiết để tải và xem nội dung bản trình chiếu, vì vậy bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc chỉnh sửa bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/nodejs-java/write-protected-presentation/).

Các quy trình công việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

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

## **Tải một bản trình chiếu đã được mã hoá**

Đặt [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword) thành mật khẩu mở khóa và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi mật khẩu mở khóa được yêu cầu nhưng mật khẩu cung cấp bị thiếu hoặc không chính xác.

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

Tải bản trình chiếu với mật khẩu mở khóa của nó, gọi [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#removeEncryption), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

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

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/) mà không tạo một thể hiện đầy đủ của bản trình chiếu. Kiểm tra [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) trước khi yêu cầu hoặc xác thực một mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Quy trình làm việc Đường dẫn Tệp**

Ví dụ sau xác thực một mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực cho [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword), và sau đó tải bản trình chiếu đầy đủ:

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

### **Quy trình làm việc Luồng**

Sử dụng [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) để kiểm tra một luồng đọc được của Node.js. Sau khi luồng kiểm tra đã được tiêu thụ, tạo một luồng mới trước khi tải bản trình chiếu đầy đủ bằng [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Ví dụ sau sử dụng một tệp PPT:

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau đối với các bản trình chiếu PPT và PPTX.

## **Kiểm tra xem bản trình chiếu đã tải có được mã hoá hay không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) như đã trình bày ở trên.

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

{{% alert color="warning" title="Bảo mật" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bản trình chiếu.
1. Nhập mật khẩu để bảo vệ chế độ xem.
1. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
1. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo vệ ghi bản trình chiếu](/slides/vi/nodejs-java/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Sự khác biệt giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện đầy đủ của bản trình chiếu.

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động tương tự cho các bản trình chiếu PPT và PPTX.