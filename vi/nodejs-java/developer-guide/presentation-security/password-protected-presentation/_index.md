---
title: Bảo mật bản trình bày bằng mật khẩu trong JavaScript
linktitle: Bảo vệ Mật khẩu
type: docs
weight: 20
url: /vi/nodejs-java/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản trình bày
- mở khóa PowerPoint
- mở khóa bản trình bày
- bảo vệ PowerPoint
- bảo vệ bản trình bày
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bản trình bày
- giải mã PowerPoint
- giải mã bản trình bày
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản trình bày
- gỡ mật khẩu
- gỡ bảo vệ
- gỡ mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- gỡ bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng khóa và mở khóa các bản trình bày PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho Node.js qua Java. Bảo vệ các bản trình bày của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bản trình bày bằng mật khẩu, nghĩa là bạn đang đặt một mật khẩu để áp dụng một số hạn chế cho bản trình bày. Để gỡ bỏ các hạn chế, cần nhập mật khẩu. Một bản trình bày được bảo vệ bằng mật khẩu được coi là bản trình bày bị khóa.

Thông thường, bạn có thể đặt mật khẩu để áp dụng các hạn chế này cho bản trình bày:

- **Sửa đổi**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình bày của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người dùng sửa đổi, thay đổi hoặc sao chép nội dung trong bản trình bày (trừ khi họ cung cấp mật khẩu).

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Trong chế độ chỉ đọc này, người dùng có thể xem nội dung hoặc các yếu tố—liên kết, hoạt ảnh, hiệu ứng và các thứ khác—trong bản trình bày, nhưng họ không thể sao chép mục nào hoặc lưu bản trình bày.

- **Mở**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình bày của mình, bạn có thể đặt một hạn chế mở. Hạn chế này ngăn người dùng ngay cả khi xem nội dung của bản trình bày (trừ khi họ cung cấp mật khẩu).

  Kỹ thuật-wise, hạn chế mở cũng ngăn người dùng sửa đổi bản trình bày: Khi người dùng không thể mở một bản trình bày, họ không thể thực hiện sửa đổi hoặc thay đổi nó. 

  **Lưu ý** rằng khi bạn bảo vệ bản trình bày bằng mật khẩu để ngăn mở, tệp bản trình bày sẽ được mã hoá.

## **Cách bảo vệ bản trình bày bằng mật khẩu trực tuyến**

1. Truy cập trang [**Khóa Aspose.Slides**](https://products.aspose.app/slides/vi/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Nhấp vào **Thả hoặc tải lên tệp của bạn**.

3. Chọn tệp bạn muốn bảo vệ bằng mật khẩu trên máy tính của bạn. 

4. Nhập mật khẩu bạn muốn cho việc bảo vệ chỉnh sửa; Nhập mật khẩu bạn muốn cho việc bảo vệ xem. 

5. Nếu bạn muốn người dùng xem bản trình bày của bạn dưới dạng bản sao cuối cùng, chọn ô **Đánh dấu là cuối cùng**.

6. Nhấp vào **BẢO VỆ NGAY.** 

7. Nhấp vào **TẢI XUỐNG NGAY.**

## **Bảo vệ mật khẩu cho bản trình bày trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hoá và các thao tác tương tự cho các bản trình bày ở các định dạng sau:

- PPTX và PPT - Bản trình bày Microsoft PowerPoint
- ODP - Bản trình bày OpenDocument
- OTP - Mẫu bản trình bày OpenDocument

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ mật khẩu trên bản trình bày để ngăn sửa đổi theo các cách sau:

- Mã hoá một bản trình bày
- Đặt bảo vệ ghi cho một bản trình bày

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các nhiệm vụ khác liên quan đến bảo vệ mật khẩu và mã hoá theo các cách sau:

- Giải mã một bản trình bày; mở một bản trình bày đã mã hoá
- Gỡ bỏ mã hoá; tắt bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình bày
- Lấy các thuộc tính của một bản trình bày đã mã hoá
- Kiểm tra xem một bản trình bày có được mã hoá hay không
- Kiểm tra xem một bản trình bày có được bảo vệ bằng mật khẩu hay không.

## **Mã hoá một bản trình bày**

Bạn có thể mã hoá một bản trình bày bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình bày bị khóa, người dùng phải cung cấp mật khẩu. 

Để mã hoá hoặc bảo vệ mật khẩu cho một bản trình bày, bạn cần sử dụng phương thức encrypt (từ [ProtectionManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager)) để đặt mật khẩu cho bản trình bày. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản trình bày đã được mã hoá.

Đoạn mã mẫu dưới đây cho thấy cách mã hoá một bản trình bày:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Đặt bảo vệ ghi cho một bản trình bày**

Bạn có thể thêm một dấu hiệu ghi “Không chỉnh sửa” vào bản trình bày. Cách này cho phép bạn thông báo với người dùng rằng bạn không muốn họ thay đổi bản trình bày.  

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bản trình bày. Do đó, người dùng—nếu họ thực sự muốn—có thể sửa đổi bản trình bày, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản trình bày với tên khác. 

Để đặt bảo vệ ghi, bạn cần sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) . Đoạn mã mẫu dưới đây cho thấy cách đặt bảo vệ ghi cho một bản trình bày:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Giải mã một bản trình bày; Mở một bản trình bày đã mã hoá**

Aspose.Slides cho phép bạn tải một tệp đã mã hoá bằng cách truyền mật khẩu của nó. Để giải mã một bản trình bày, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) mà không có tham số. Sau đó bạn sẽ phải nhập mật khẩu đúng để tải bản trình bày.

Đoạn mã mẫu dưới đây cho thấy cách giải mã một bản trình bày: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bản trình bày đã giải mã
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gỡ bỏ mã hoá; Tắt bảo vệ mật khẩu**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ mật khẩu trên một bản trình bày. Cách này cho phép người dùng truy cập hoặc sửa đổi bản trình bày mà không có hạn chế. 

Để gỡ bỏ mã hoá hoặc bảo vệ mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) . Đoạn mã mẫu dưới đây cho thấy cách gỡ bỏ mã hoá khỏi một bản trình bày:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình bày**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên tệp bản trình bày. Cách này cho phép người dùng sửa đổi theo ý muốn—và họ sẽ không nhận được cảnh báo khi thực hiện các tác vụ như vậy.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình bày bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Đoạn mã mẫu dưới đây cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản trình bày:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Lấy các thuộc tính của một bản trình bày đã mã hoá**

Thông thường, người dùng gặp khó khăn khi lấy các thuộc tính tài liệu của một bản trình bày đã được mã hoá hoặc bảo vệ mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ mật khẩu bản trình bày đồng thời vẫn cho phép người dùng truy cập các thuộc tính của bản trình bày đó.

**Lưu ý** rằng khi Aspose.Slides mã hoá một bản trình bày, các thuộc tính tài liệu của bản trình bày cũng được bảo vệ mật khẩu theo mặc định. Nhưng nếu bạn cần cho phép truy cập các thuộc tính của bản trình bày (ngay cả sau khi bản trình bày đã được mã hoá), Aspose.Slides cho phép bạn làm chính xác việc đó. 

Nếu bạn muốn người dùng vẫn có khả năng truy cập các thuộc tính của một bản trình bày bạn đã mã hoá, bạn có thể đặt thuộc tính [encryptDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) thành `true`. Đoạn mã mẫu dưới đây cho thấy cách mã hoá một bản trình bày đồng thời cung cấp phương tiện để người dùng truy cập các thuộc tính tài liệu của nó:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ bằng mật khẩu trước khi tải nó**

Trước khi tải một bản trình bày, bạn có thể muốn kiểm tra và xác nhận rằng bản trình bày chưa được bảo vệ bằng mật khẩu. Cách này giúp bạn tránh các lỗi và vấn đề tương tự, những lỗi thường xuất hiện khi một bản trình bày được bảo vệ bằng mật khẩu được tải mà không có mật khẩu.

Đoạn mã JavaScript dưới đây cho thấy cách kiểm tra một bản trình bày để xem nó có được bảo vệ bằng mật khẩu hay không (không cần tải bản trình bày):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra xem một bản trình bày có được mã hoá hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được mã hoá hay không. Để thực hiện thao tác này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , trả về `true` nếu bản trình bày được mã hoá hoặc `false` nếu không được mã hoá.

Đoạn mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình bày có được mã hoá hay không:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ ghi hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được bảo vệ ghi hay không. Để thực hiện thao tác này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , trả về `true` nếu bản trình bày được bảo vệ ghi hoặc `false` nếu không.

Đoạn mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình bày có được bảo vệ ghi hay không:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Xác thực hoặc xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ một bản trình bày**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình bày. Aspose.Slides cung cấp phương tiện để bạn xác thực một mật khẩu. 

Đoạn mã mẫu dưới đây cho thấy cách xác thực một mật khẩu:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // kiểm tra nếu "pass" khớp với
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Nó trả về `true` nếu bản trình bày đã được mã hoá bằng mật khẩu được chỉ định. Ngược lại, nó trả về `false`. 

{{% alert color="primary" title="Xem thêm" %}} 
- [Chữ ký số trong PowerPoint](/slides/vi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides hỗ trợ các phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản trình bày của bạn.

**Điều gì xảy ra nếu nhập mật khẩu sai khi cố gắng mở một bản trình bày?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu sai được sử dụng, thông báo rằng quyền truy cập vào bản trình bày bị từ chối. Điều này giúp ngăn chặn truy cập trái phép và bảo vệ nội dung bản trình bày.

**Có bất kỳ ảnh hưởng về hiệu năng nào khi làm việc với các bản trình bày được bảo vệ bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể gây ra một chút chi phí bổ sung trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không ảnh hưởng đáng kể tới thời gian xử lý chung của các tác vụ liên quan đến bản trình bày.