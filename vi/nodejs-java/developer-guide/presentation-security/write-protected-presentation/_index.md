---
title: Bảo vệ ghi các bản trình bày trong JavaScript
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/nodejs-java/write-protected-presentation/
keywords:
- bảo vệ ghi
- bảo vệ ghi PowerPoint
- mật khẩu để sửa đổi
- hạn chế chỉnh sửa bản trình bày
- gỡ bỏ bảo vệ ghi
- xác thực mật khẩu sửa đổi
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Đặt, phát hiện, xác thực và gỡ bỏ mật khẩu bảo vệ ghi trong các bản trình bày PowerPoint PPT và PPTX bằng cách sử dụng Aspose.Slides cho Node.js thông qua Java."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi (write-protection) giới hạn việc sửa đổi một bản trình bày nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình bày được bảo vệ ghi mà không cần mật khẩu. Tùy thuộc vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới một tên khác, vì vậy bảo vệ ghi không nên được xem như một cơ chế bảo mật thông tin.

Mật khẩu mở (opening password) có mục đích khác: nó mã hoá bản trình bày và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình bày hoặc xác thực mật khẩu mở, xem [Bảo mật bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/).

Các quy trình làm việc trong bài viết này áp dụng cho cả bản trình bày PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu dưới dạng PPT, sử dụng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt bảo vệ ghi cho một bản trình bày**

Sử dụng [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) để chỉ định mật khẩu cho việc sửa đổi một bản trình bày. Lưu bản trình bày sẽ duy trì cài đặt bảo vệ.

Ví dụ sau thiết lập bảo vệ ghi cho một bản trình bày PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tải một bản trình bày được bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình bày, không cần mật khẩu để tải bản trình bày. Mật khẩu chỉ có liên quan khi xác thực quyền sửa đổi bản trình bày được bảo vệ.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Không truyền mật khẩu bảo vệ ghi vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword). Phương thức đó nhận mật khẩu mở cho nội dung đã được mã hoá. Nếu một bản trình bày có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải nó và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình bày**

Sử dụng [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) để gỡ bỏ giới hạn sửa đổi, sau đó lưu bản trình bày.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ ghi hay không**

Để kiểm tra một tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) đầy đủ, gọi [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) và kiểm tra [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Phương thức này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/nullablebool/) và trả về `NullableBool.True` khi phát hiện bảo vệ ghi.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Phương thức dựa trên luồng [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) cung cấp cùng thông tin cho một bản trình bày được cung cấp dưới dạng luồng đọc của Node.js.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) để xác thực mật khẩu sửa đổi mà không cần tải toàn bộ bản trình bày. Đầu tiên kiểm tra [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở hoặc xác định liệu nội dung đã được mã hoá có thể được tải hay không. Ngược lại, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) chỉ xác thực mật khẩu mở. Nếu một bản trình bày đầy đủ đã được tải, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) cung cấp kiểm tra bảo vệ ghi tương đương qua trình quản lý bảo vệ của nó.

Trong các ứng dụng sản xuất, không ghi lại mật khẩu hoặc đưa chúng vào các thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo mật bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/)
- [Bản trình bày chỉ đọc](/slides/vi/nodejs-java/read-only-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Bảo vệ ghi có mã hoá một bản trình bày không?**

Không. Nó chỉ hạn chế việc sửa đổi nhưng vẫn cho phép tải và xem nội dung bản trình bày.

**Mật khẩu bảo vệ ghi có bắt buộc để mở một bản trình bày không?**

Không. Chỉ cần mật khẩu mở để tải nội dung bản trình bày đã được mã hoá.

**Một bản trình bày có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở thông qua tùy chọn tải để mở bản trình bày đã được mã hoá, và xác thực mật khẩu bảo vệ ghi riêng khi cần quyền sửa đổi.