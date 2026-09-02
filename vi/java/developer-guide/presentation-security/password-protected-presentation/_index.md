---
title: Bảo vệ bản trình chiếu bằng mật khẩu trong Java
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/java/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản trình chiếu
- mở khóa PowerPoint
- mở khóa bản trình chiếu
- bảo vệ PowerPoint
- bảo vệ bản trình chiếu
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bản trình chiếu
- giải mã PowerPoint
- giải mã bản trình chiếu
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản trình chiếu
- xóa mật khẩu
- xóa bảo vệ
- xóa mã hoá
- tắt mật khẩu
- tắt bảo vệ
- xóa bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa dễ dàng các bản trình chiếu PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho Java. Bảo mật các bản trình chiếu của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bản trình chiếu bằng mật khẩu, nghĩa là bạn đặt một mật khẩu để áp dụng một số hạn chế nhất định lên bản trình chiếu. Để gỡ bỏ các hạn chế này, phải nhập mật khẩu. Một bản trình chiếu được bảo vệ bằng mật khẩu được coi là bản trình chiếu bị khóa.

Thông thường, bạn có thể đặt mật khẩu để thực thi các hạn chế này trên một bản trình chiếu:

- **Sửa đổi**

Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình chiếu của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người khác sửa đổi, thay đổi hoặc sao chép các thành phần trong bản trình chiếu của bạn trừ khi họ cung cấp mật khẩu. 

Tuy nhiên, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập và mở tài liệu của bạn. Trong chế độ chỉ đọc này, người dùng có thể xem nội dung — bao gồm các siêu liên kết, hoạt ảnh, hiệu ứng và các thành phần khác — trong bản trình chiếu của bạn, nhưng họ không thể sao chép các mục hoặc lưu bản trình chiếu.

- **Mở**

Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình chiếu của mình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác ngay cả khi xem nội dung của bản trình chiếu trừ khi họ cung cấp mật khẩu.

Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bản trình chiếu của bạn — nếu người dùng không thể mở bản trình chiếu, họ cũng không thể sửa đổi hoặc thực hiện thay đổi nào.

**Lưu ý:** Khi bạn bảo vệ bản trình chiếu bằng mật khẩu để ngăn mở, tệp bản trình chiếu sẽ được mã hoá.

## **Bảo vệ mật khẩu trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hoá và các thao tác tương tự cho các bản trình chiếu ở các định dạng sau: 

- PPTX và PPT - Bản trình chiếu Microsoft PowerPoint 
- ODP - Bản trình chiếu OpenDocument 
- OTP - Mẫu bản trình chiếu OpenDocument 

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ mật khẩu trên các bản trình chiếu để ngăn sửa đổi theo các cách sau:

- Mã hoá một bản trình chiếu
- Đặt bảo vệ ghi cho một bản trình chiếu

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các tác vụ khác liên quan đến bảo vệ mật khẩu và mã hoá theo các cách sau:

- Giải mã một bản trình chiếu; mở một bản trình chiếu đã được mã hoá
- Gỡ bỏ mã hoá; tắt bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu
- Lấy các thuộc tính của một bản trình chiếu đã mã hoá
- Kiểm tra xem một bản trình chiếu có được mã hoá hay không
- Kiểm tra xem một bản trình chiếu có được bảo vệ bằng mật khẩu hay không.

## **Bảo vệ bản trình chiếu bằng mật khẩu**

Bạn có thể mã hoá một bản trình chiếu bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình chiếu đã bị khóa, người dùng phải cung cấp mật khẩu. 

Bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bản trình chiếu. Bạn truyền mật khẩu tới phương thức encrypt và sử dụng phương thức save để lưu bản trình chiếu đã được mã hoá. 

Đoạn mã mẫu dưới đây cho bạn thấy cách mã hoá một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt bảo vệ ghi cho một bản trình chiếu**

Bạn có thể thêm một dấu hiệu “Không sửa đổi” vào bản trình chiếu. Bằng cách này, bạn thông báo cho người dùng rằng bạn không muốn họ thay đổi bản trình chiếu.  

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bản trình chiếu. Do đó, người dùng — nếu họ thực sự muốn — có thể sửa đổi bản trình chiếu, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản trình chiếu với tên khác. 

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Đoạn mã mẫu dưới đây cho bạn thấy cách đặt bảo vệ ghi cho một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tải một bản trình chiếu đã mã hoá**

Aspose.Slides cho phép bạn tải một tệp đã mã hoá bằng cách truyền mật khẩu của nó. Để giải mã một bản trình chiếu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeEncryption--) mà không có tham số. Sau đó bạn sẽ phải nhập mật khẩu đúng để tải bản trình chiếu.

Đoạn mã mẫu dưới đây cho bạn thấy cách giải mã một bản trình chiếu: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bản trình chiếu đã giải mã
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gỡ bỏ mã hoá khỏi một bản trình chiếu**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ mật khẩu trên một bản trình chiếu. Nhờ đó, người dùng có thể truy cập hoặc sửa đổi bản trình chiếu mà không bị hạn chế. 

Để gỡ bỏ mã hoá hoặc bảo vệ mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Đoạn mã mẫu dưới đây cho bạn cách gỡ bỏ mã hoá khỏi một bản trình chiếu:

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

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi trên tệp bản trình chiếu. Nhờ đó, người dùng có thể sửa đổi theo ý muốn — và họ sẽ không nhận được cảnh báo khi thực hiện các thao tác này.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Đoạn mã mẫu dưới đây cho bạn cách gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy thuộc tính của bản trình chiếu đã mã hoá**

Thông thường, người dùng gặp khó khăn trong việc truy xuất các thuộc tính tài liệu của một bản trình chiếu đã được mã hoá hoặc bảo vệ bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ bản trình chiếu bằng mật khẩu đồng thời vẫn giữ khả năng người dùng truy cập các thuộc tính của nó.

**Lưu ý:** Mặc định, khi Aspose.Slides mã hoá một bản trình chiếu, các thuộc tính tài liệu của bản trình chiếu cũng được bảo vệ bằng mật khẩu. Nếu bạn cần cho phép truy cập các thuộc tính tài liệu ngay cả sau khi mã hoá, Aspose.Slides cho phép bạn làm điều đó.

Nếu bạn muốn người dùng vẫn có khả năng truy cập các thuộc tính của một bản trình chiếu đã mã hoá, truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Đoạn mã mẫu dưới đây cho bạn cách mã hoá một bản trình chiếu trong khi vẫn cung cấp cho người dùng quyền truy cập các thuộc tính tài liệu của nó:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Chỉ tải các thuộc tính tài liệu từ một bản trình chiếu đã mã hoá**

Để kiểm tra siêu dữ liệu của một bản trình chiếu đã mã hoá mà không tải các slide hoặc nội dung khác, tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) và truyền `true` vào [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Trong chế độ này, Aspose.Slides bỏ qua mật khẩu và chỉ tải các thuộc tính tài liệu có thể truy cập công khai.

Ví dụ mã sau đọc các thuộc tính tài liệu tích hợp và tùy chỉnh thông qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Đọc các thuộc tính tài liệu tích hợp.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Đọc các thuộc tính tài liệu tùy chỉnh.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Quá trình làm việc này chỉ hoạt động khi các thuộc tính tài liệu được để ở trạng thái không mã hoá (công khai) khi bản trình chiếu được mã hoá. Nếu các thuộc tính tài liệu được mã hoá, việc truyền `true` vào `loadOptions.setOnlyLoadDocumentProperties` sẽ gây ra ngoại lệ vì mật khẩu bị bỏ qua trong chế độ này. Để truy cập các thuộc tính tài liệu đã mã hoá hoặc tải đầy đủ bản trình chiếu, bao gồm các slide và nội dung khác, cung cấp mật khẩu đúng thông qua [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kiểm tra xem một bản trình chiếu có được bảo vệ bằng mật khẩu hay không**

Trước khi tải một bản trình chiếu, bạn có thể muốn kiểm tra và xác nhận rằng bản trình chiếu không bị bảo vệ bằng mật khẩu. Nhờ đó, bạn tránh được các lỗi và các vấn đề tương tự, phát sinh khi tải một bản trình chiếu được bảo vệ bằng mật khẩu mà không có mật khẩu.

Đoạn mã Java dưới đây cho bạn cách kiểm tra một bản trình chiếu để xem nó có được bảo vệ bằng mật khẩu hay không (không tải bản trình chiếu thực tế):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra xem một bản trình chiếu có được mã hoá hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được mã hoá hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bản trình chiếu được mã hoá hoặc `false` nếu không được mã hoá.

Đoạn mã mẫu dưới đây cho bạn cách kiểm tra xem một bản trình chiếu có được mã hoá hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bản trình chiếu được mã hoá hoặc `false` nếu không được mã hoá.

Đoạn mã mẫu dưới đây cho bạn cách kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác thực hoặc xác nhận rằng một mật khẩu cụ thể đã được sử dụng**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình chiếu. Aspose.Slides cung cấp công cụ để bạn xác thực mật khẩu. 

Đoạn mã mẫu dưới đây cho bạn cách xác thực một mật khẩu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kiểm tra xem "pass" có khớp với
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Nó trả về `true` nếu bản trình chiếu đã được mã hoá bằng mật khẩu được chỉ định. Ngược lại, nó trả về `false`.

{{% alert color="primary" title="See also" %}} 
- [Chữ ký số trong PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các phương thức mã hoá được Aspose.Slides hỗ trợ là gì?**

Aspose.Slides hỗ trợ các phương thức mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho bản trình chiếu của bạn.

**Điều gì xảy ra nếu nhập mật khẩu sai khi cố gắng mở một bản trình chiếu?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng được sử dụng, thông báo cho bạn rằng quyền truy cập vào bản trình chiếu bị từ chối. Điều này giúp ngăn ngừa truy cập trái phép và bảo vệ nội dung bản trình chiếu.

**Có ảnh hưởng gì đến hiệu năng khi làm việc với bản trình chiếu được bảo vệ bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể gây ra một chút overhead trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng đến hiệu năng này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ bản trình chiếu.