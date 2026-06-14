---
title: Bảo mật bản trình bày bằng mật khẩu trong Java
linktitle: Bảo vệ bằng mật khẩu
type: docs
weight: 20
url: /vi/java/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản trình bày
- mở khóa PowerPoint
- mở khóa bản trình bày
- bảo vệ PowerPoint
- bảo vệ bản trình bày
- đặt mật khẩu
- thêm mật khẩu
- mã hóa PowerPoint
- mã hóa bản trình bày
- giải mã PowerPoint
- giải mã bản trình bày
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản trình bày
- xóa mật khẩu
- xóa bảo vệ
- xóa mã hóa
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- xóa bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng khóa và mở khóa các bản trình bày PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho Java. Bảo mật các bản trình bày của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ mật khẩu cho một bản trình bày, có nghĩa là bạn đang đặt một mật khẩu để thực thi một số hạn chế nhất định trên bản trình bày. Để gỡ bỏ các hạn chế này, cần nhập mật khẩu. Một bản trình bày được bảo vệ bằng mật khẩu được coi là bản trình bày bị khóa.

Thông thường, bạn có thể đặt mật khẩu để thực thi các hạn chế này trên một bản trình bày:

- **Chỉnh sửa**

Nếu bạn muốn chỉ một số người dùng nhất định có thể chỉnh sửa bản trình bày của mình, bạn có thể đặt hạn chế chỉnh sửa. Hạn chế này ngăn người khác chỉnh sửa, thay đổi hoặc sao chép các yếu tố trong bản trình bày trừ khi họ cung cấp mật khẩu. 

Tuy nhiên, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập và mở tài liệu của bạn. Trong chế độ chỉ đọc này, người dùng có thể xem nội dung — bao gồm các siêu liên kết, hoạt ảnh, hiệu ứng và các yếu tố khác — trong bản trình bày, nhưng họ không thể sao chép mục nào hoặc lưu bản trình bày.

- **Mở**

Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình bày của mình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác thậm chí không thể xem nội dung của bản trình bày trừ khi họ cung cấp mật khẩu.

Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng chỉnh sửa bản trình bày của bạn — nếu người không thể mở một bản trình bày, họ không thể chỉnh sửa hoặc thực hiện thay đổi nào.

**Lưu ý:** Khi bạn bảo vệ mật khẩu cho một bản trình bày để ngăn mở, tệp bản trình bày sẽ được mã hóa.

## **Bảo vệ mật khẩu trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hóa và các thao tác tương tự cho các bản trình bày ở các định dạng sau: 

- PPTX và PPT - Bản trình bày Microsoft PowerPoint 
- ODP - Bản trình bày OpenDocument 
- OTP - Mẫu bản trình bày OpenDocument 

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ mật khẩu trên các bản trình bày để ngăn chỉnh sửa theo các cách sau:

- Mã hóa một bản trình bày
- Đặt bảo vệ ghi cho một bản trình bày

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các nhiệm vụ khác liên quan đến bảo vệ mật khẩu và mã hóa theo các cách sau:

- Giải mã một bản trình bày; mở một bản trình bày đã mã hóa
- Gỡ bỏ mã hóa; tắt bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình bày
- Lấy các thuộc tính của một bản trình bày đã mã hóa
- Kiểm tra xem một bản trình bày có được mã hóa không
- Kiểm tra xem một bản trình bày có được bảo vệ bằng mật khẩu không.

## **Bảo vệ một bản trình bày bằng mật khẩu**

Bạn có thể mã hóa một bản trình bày bằng cách đặt mật khẩu. Sau đó, để chỉnh sửa bản trình bày bị khóa, người dùng phải cung cấp mật khẩu. 

Để mã hóa hoặc bảo vệ bằng mật khẩu một bản trình bày, bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bản trình bày. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản trình bày đã được mã hóa. 

Đoạn mã mẫu này cho bạn thấy cách mã hóa một bản trình bày:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt bảo vệ ghi cho một bản trình bày**

Bạn có thể thêm một dấu hiệu ghi “Không chỉnh sửa” vào một bản trình bày. Như vậy, bạn sẽ thông báo cho người dùng rằng bạn không muốn họ thay đổi bản trình bày.  

**Lưu ý** rằng quá trình bảo vệ ghi không mã hóa bản trình bày. Do đó, người dùng — nếu họ thực sự muốn — có thể chỉnh sửa bản trình bày, nhưng để lưu các thay đổi, họ phải tạo một bản trình bày với tên khác. 

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Đoạn mã mẫu này cho bạn thấy cách đặt bảo vệ ghi cho một bản trình bày:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tải một bản trình bày đã mã hóa**

Aspose.Slides cho phép bạn tải một tệp đã mã hóa bằng cách truyền mật khẩu của nó. Để giải mã một bản trình bày, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeEncryption--) không có tham số. Sau đó bạn sẽ phải nhập mật khẩu đúng để tải bản trình bày. 

Đoạn mã mẫu này cho bạn thấy cách giải mã một bản trình bày: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bản trình bày đã giải mã
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Gỡ bỏ mã hóa khỏi một bản trình bày**

Bạn có thể gỡ bỏ mã hóa hoặc bảo vệ mật khẩu trên một bản trình bày. Như vậy, người dùng sẽ có thể truy cập hoặc chỉnh sửa bản trình bày mà không có hạn chế. 

Để gỡ bỏ mã hóa hoặc bảo vệ mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeEncryption--). Đoạn mã mẫu này cho bạn cách gỡ bỏ mã hóa khỏi một bản trình bày:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình bày**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên tệp bản trình bày. Như vậy, người dùng có thể chỉnh sửa tùy ý — và không nhận được cảnh báo khi thực hiện các thao tác đó.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình bày bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--). Đoạn mã mẫu này cho bạn cách gỡ bỏ bảo vệ ghi khỏi một bản trình bày:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy các thuộc tính của một bản trình bày đã mã hóa**

Thông thường, người dùng gặp khó khăn trong việc lấy các thuộc tính tài liệu của một bản trình bày đã được mã hóa hoặc bảo vệ bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ mật khẩu một bản trình bày đồng thời vẫn cho phép người dùng truy cập các thuộc tính của bản trình bày đó.

**Lưu ý** rằng khi Aspose.Slides mã hóa một bản trình bày, các thuộc tính tài liệu của bản trình bày cũng sẽ được bảo vệ bằng mật khẩu theo mặc định. Nhưng nếu bạn cần làm cho các thuộc tính của bản trình bày có thể truy cập được (ngay cả sau khi bản trình bày đã được mã hóa), Aspose.Slides cho phép bạn thực hiện điều đó. 

Nếu bạn muốn người dùng vẫn có khả năng truy cập các thuộc tính của một bản trình bày bạn đã mã hóa, bạn có thể đặt thuộc tính [encryptDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) thành `true`. Đoạn mã mẫu này cho bạn cách mã hóa một bản trình bày đồng thời cung cấp cho người dùng khả năng truy cập các thuộc tính tài liệu của nó:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ bằng mật khẩu hay không**

Trước khi bạn tải một bản trình bày, bạn có thể muốn kiểm tra và xác nhận rằng bản trình bày không được bảo vệ bằng mật khẩu. Như vậy, bạn tránh được các lỗi và vấn đề tương tự, xảy ra khi tải một bản trình bày được bảo vệ bằng mật khẩu mà không có mật khẩu.

Đoạn mã Java này cho bạn thấy cách kiểm tra một bản trình bày để xem nó có được bảo vệ bằng mật khẩu hay không (mà không cần tải bản trình bày):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra xem một bản trình bày có được mã hóa hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được mã hóa hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bản trình bày được mã hóa hoặc `false` nếu không được mã hóa.

Đoạn mã mẫu này cho bạn cách kiểm tra xem một bản trình bày có được mã hóa hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ ghi hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bản trình bày được bảo vệ ghi hoặc `false` nếu không được bảo vệ ghi. 

Đoạn mã mẫu này cho bạn cách kiểm tra xem một bản trình bày có được bảo vệ ghi hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác thực hoặc xác nhận rằng một mật khẩu cụ thể đã được sử dụng**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình bày. Aspose.Slides cung cấp cách để bạn xác thực mật khẩu. 

Đoạn mã mẫu này cho bạn cách xác thực một mật khẩu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kiểm tra xem "pass" có khớp với không
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Nó trả về `true` nếu bản trình bày đã được mã hóa bằng mật khẩu đã chỉ định. Ngược lại, nó trả về `false`. 

{{% alert color="primary" title="Xem thêm" %}} 
- [Chữ ký số trong PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các phương pháp mã hóa nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ các phương pháp mã hóa hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản trình bày của bạn.

**Điều gì xảy ra nếu nhập sai mật khẩu khi cố gắng mở một bản trình bày?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng được sử dụng, thông báo cho bạn rằng truy cập vào bản trình bày bị từ chối. Điều này giúp ngăn chặn việc truy cập trái phép và bảo vệ nội dung bản trình bày.

**Có bất kỳ ảnh hưởng về hiệu năng nào khi làm việc với các bản trình bày được bảo vệ bằng mật khẩu không?**

Quá trình mã hóa và giải mã có thể gây ra một chút tiêu tốn tài nguyên trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng về hiệu năng này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các nhiệm vụ trình bày của bạn.