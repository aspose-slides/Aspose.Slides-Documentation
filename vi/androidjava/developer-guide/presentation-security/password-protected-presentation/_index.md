---
title: Bảo vệ bài thuyết trình bằng mật khẩu trên Android
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/androidjava/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bài thuyết trình
- mở khóa PowerPoint
- mở khóa bài thuyết trình
- bảo vệ PowerPoint
- bảo vệ bài thuyết trình
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bài thuyết trình
- giải mã PowerPoint
- giải mã bài thuyết trình
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bài thuyết trình
- gỡ bỏ mật khẩu
- gỡ bỏ bảo vệ
- gỡ bỏ mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- gỡ bỏ bảo vệ ghi
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Dễ dàng khóa và mở khóa các bài thuyết trình PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho Android bằng Java. Bảo vệ các bài thuyết trình của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bài thuyết trình bằng mật khẩu, bạn đang đặt một mật khẩu để áp đặt các hạn chế nhất định lên bài thuyết trình. Để loại bỏ các hạn chế, người dùng phải nhập mật khẩu. Một bài thuyết trình được bảo vệ bằng mật khẩu được coi là bài thuyết trình bị khóa.

Thông thường, bạn có thể đặt mật khẩu để áp dụng các hạn chế này cho một bài thuyết trình:

- **Sửa đổi**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bài thuyết trình của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người khác sửa đổi, thay đổi hoặc sao chép nội dung trong bài thuyết trình (trừ khi họ cung cấp mật khẩu).

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Ở chế độ chỉ đọc, người dùng có thể xem nội dung hoặc các yếu tố — siêu liên kết, hoạt ảnh, hiệu ứng và các thành phần khác — trong bài thuyết trình, nhưng họ không thể sao chép mục nào hoặc lưu bài thuyết trình.

- **Mở**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bài thuyết trình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác thậm chí xem nội dung của bài thuyết trình (trừ khi họ cung cấp mật khẩu).

  Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bài thuyết trình: Khi người dùng không thể mở một bài thuyết trình, họ cũng không thể thực hiện bất kỳ thay đổi nào trên nó.  

  **Lưu ý** rằng khi bạn bảo vệ một bài thuyết trình bằng mật khẩu để ngăn mở, tệp bài thuyết trình sẽ được mã hoá.

## **Bảo vệ mật khẩu cho Bài thuyết trình trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hoá và các thao tác tương tự cho các bài thuyết trình ở các định dạng sau:

- PPTX và PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ mật khẩu trên bài thuyết trình để ngăn sửa đổi theo các cách sau:

- Mã hoá một bài thuyết trình
- Đặt bảo vệ ghi (write protection) cho một bài thuyết trình

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các tác vụ khác liên quan đến bảo vệ mật khẩu và mã hoá như sau:

- Giải mã một bài thuyết trình; mở một bài thuyết trình đã được mã hoá
- Gỡ bỏ mã hoá; vô hiệu hoá bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình
- Lấy các thuộc tính của một bài thuyết trình đã được mã hoá
- Kiểm tra xem một bài thuyết trình có được mã hoá hay không
- Kiểm tra xem một bài thuyết trình có được bảo vệ bằng mật khẩu hay không.

## **Mã hoá một Bài thuyết trình**

Bạn có thể mã hoá một bài thuyết trình bằng cách đặt mật khẩu. Sau đó, để sửa đổi bài thuyết trình bị khóa, người dùng phải cung cấp mật khẩu.

Để mã hoá hoặc bảo vệ mật khẩu cho một bài thuyết trình, bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bài thuyết trình. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bài thuyết trình đã được mã hoá.

Mã mẫu này cho bạn thấy cách mã hoá một bài thuyết trình:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt Bảo vệ Ghi cho một Bài thuyết trình**

Bạn có thể thêm một dấu “Không sửa đổi” vào một bài thuyết trình. Nhờ đó, bạn có thể thông báo cho người dùng rằng bạn không muốn họ thực hiện thay đổi trên bài thuyết trình.

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bài thuyết trình. Do đó, người dùng — nếu họ muốn — vẫn có thể sửa đổi bài thuyết trình, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản mới với tên khác.

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Mã mẫu này cho bạn thấy cách đặt bảo vệ ghi cho một bài thuyết trình:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tải một Bài thuyết trình đã được Mã hoá**

Aspose.Slides cho phép bạn tải một tệp đã được mã hoá bằng cách truyền mật khẩu của nó. Để giải mã một bài thuyết trình, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) mà không có tham số. Sau đó, bạn sẽ phải nhập mật khẩu đúng để tải bài thuyết trình.

Mã mẫu này cho bạn thấy cách giải mã một bài thuyết trình:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bài thuyết trình đã được giải mã
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Gỡ bỏ Mã hoá khỏi một Bài thuyết trình**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ mật khẩu trên một bài thuyết trình. Nhờ đó, người dùng có thể truy cập hoặc sửa đổi bài thuyết trình mà không còn bị hạn chế.

Để gỡ bỏ mã hoá hoặc bảo vệ mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Mã mẫu này cho bạn thấy cách gỡ bỏ mã hoá khỏi một bài thuyết trình:

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

## **Gỡ bỏ Bảo vệ Ghi khỏi một Bài thuyết trình**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng cho một tệp bài thuyết trình. Nhờ đó, người dùng có thể sửa đổi thoải mái và sẽ không nhận được cảnh báo khi thực hiện các thao tác như vậy.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Mã mẫu này cho bạn thấy cách gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy các Thuộc tính của một Bài thuyết trình Đã được Mã hoá**

Thông thường, người dùng gặp khó khăn khi lấy các thuộc tính tài liệu của một bài thuyết trình đã được mã hoá hoặc bảo vệ bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ mật khẩu một bài thuyết trình đồng thời giữ cho người dùng có thể truy cập các thuộc tính của bài thuyết trình đó.

**Lưu ý** rằng khi Aspose.Slides mã hoá một bài thuyết trình, các thuộc tính tài liệu của bài thuyết trình cũng sẽ được bảo vệ bằng mật khẩu theo mặc định. Nhưng nếu bạn cần cho phép người dùng truy cập các thuộc tính của bài thuyết trình (ngay cả sau khi bài thuyết trình đã được mã hoá), Aspose.Slides cho phép bạn thực hiện chính xác điều đó.

Nếu bạn muốn người dùng vẫn có thể truy cập các thuộc tính của một bài thuyết trình đã được mã hoá, bạn có thể đặt thuộc tính [encryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) thành `true`. Mã mẫu này cho bạn thấy cách mã hoá một bài thuyết trình đồng thời cung cấp cho người dùng khả năng truy cập các thuộc tính tài liệu của nó:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một Bài thuyết trình có được Bảo vệ bằng Mật khẩu hay không**

Trước khi tải một bài thuyết trình, bạn có thể muốn kiểm tra và xác nhận rằng bài thuyết trình chưa được bảo vệ bằng mật khẩu. Nhờ đó, bạn tránh được các lỗi và các vấn đề tương tự, thường xuất hiện khi một bài thuyết trình được bảo vệ bằng mật khẩu được tải mà không có mật khẩu.

Đoạn mã Java này cho bạn thấy cách kiểm tra một bài thuyết trình để xem nó có được bảo vệ bằng mật khẩu hay không (không cần tải bài thuyết trình):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra xem một Bài thuyết trình có được Mã hoá hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bài thuyết trình có được mã hoá hay không. Để thực hiện tác vụ này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bài thuyết trình được mã hoá và `false` nếu không.

Mã mẫu này cho bạn thấy cách kiểm tra xem một bài thuyết trình có được mã hoá hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một Bài thuyết trình có được Bảo vệ Ghi hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bài thuyết trình có được bảo vệ ghi hay không. Để thực hiện tác vụ này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bài thuyết trình được bảo vệ ghi và `false` nếu không.

Mã mẫu này cho bạn thấy cách kiểm tra xem một bài thuyết trình có được bảo vệ ghi hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác thực hoặc Xác nhận rằng Đã Sử dụng Mật khẩu Cụ thể**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bài thuyết trình. Aspose.Slides cung cấp công cụ để bạn xác thực một mật khẩu.

Mã mẫu này cho bạn thấy cách xác thực mật khẩu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kiểm tra xem "pass" có khớp với
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Nó trả về `true` nếu bài thuyết trình đã được mã hoá bằng mật khẩu đã chỉ định. Ngược lại, nó trả về `false`. 

{{% alert color="primary" title="Xem thêm" %}} 
- [Chữ ký số trong PowerPoint](/slides/vi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides hỗ trợ các phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bài thuyết trình của bạn.

**Điều gì xảy ra nếu nhập mật khẩu không đúng khi cố gắng mở một bài thuyết trình?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng, thông báo rằng việc truy cập vào bài thuyết trình đã bị từ chối. Điều này giúp ngăn chặn truy cập trái phép và bảo vệ nội dung bài thuyết trình.

**Có ảnh hưởng nào đến hiệu năng khi làm việc với các bài thuyết trình được bảo vệ bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể gây ra một chút độ trễ nhẹ trong các thao tác mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ liên quan đến bài thuyết trình.