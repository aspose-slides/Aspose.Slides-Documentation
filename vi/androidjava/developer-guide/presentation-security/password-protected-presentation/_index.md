---
title: Bảo mật các bản trình chiếu bằng mật khẩu trên Android
linktitle: Bảo vệ bằng mật khẩu
type: docs
weight: 20
url: /vi/androidjava/password-protected-presentation/
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
- gỡ mật khẩu
- gỡ bảo vệ
- gỡ mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- gỡ bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khóa và mở khóa các bản trình chiếu PowerPoint và OpenDocument được bảo vệ bằng mật khẩu một cách dễ dàng với Aspose.Slides cho Android qua Java. Bảo vệ các bản trình chiếu của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bản trình chiếu bằng mật khẩu, nghĩa là bạn đang đặt một mật khẩu áp dụng các hạn chế nhất định lên bản trình chiếu. Để gỡ các hạn chế, phải nhập mật khẩu. Một bản trình chiếu được bảo vệ bằng mật khẩu được xem là bản trình chiếu bị khóa.

Thông thường, bạn có thể đặt mật khẩu để thực thi các hạn chế này trên một bản trình chiếu:

- **Modification**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình chiếu của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người khác sửa, thay đổi hoặc sao chép nội dung trong bản trình chiếu (trừ khi họ cung cấp mật khẩu).

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Ở chế độ chỉ đọc này, người dùng có thể xem nội dung hoặc các yếu tố—liên kết, hoạt ảnh, hiệu ứng và các mục khác—trong bản trình chiếu, nhưng không thể sao chép mục nào hoặc lưu bản trình chiếu.

- **Opening**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình chiếu của mình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác thậm chí xem nội dung của bản trình chiếu (trừ khi họ cung cấp mật khẩu).

  Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bản trình chiếu: Khi người dùng không thể mở bản trình chiếu, họ cũng không thể thực hiện sửa đổi hay thay đổi nó. 

  **Note** rằng khi bạn bảo vệ bản trình chiếu bằng mật khẩu để ngăn việc mở, tệp bản trình chiếu sẽ được mã hoá.

## **Bảo Vệ Bằng Mật Khẩu cho Bản Trình Chiếu trong Aspose.Slides**
**Supported formats**

Aspose.Slides hỗ trợ bảo vệ bằng mật khẩu, mã hoá và các thao tác tương tự cho các bản trình chiếu ở các định dạng sau:

- PPTX và PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Supported operations**

Aspose.Slides cho phép bạn sử dụng bảo vệ bằng mật khẩu trên các bản trình chiếu để ngăn sửa đổi theo các cách sau:

- Mã hoá một bản trình chiếu
- Đặt bảo vệ ghi cho một bản trình chiếu

**Other operations**

Aspose.Slides cho phép bạn thực hiện các tác vụ khác liên quan đến bảo vệ bằng mật khẩu và mã hoá theo các cách sau:

- Giải mã một bản trình chiếu; mở một bản trình chiếu đã được mã hoá
- Gỡ bỏ mã hoá; vô hiệu hoá bảo vệ bằng mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu
- Lấy các thuộc tính của một bản trình chiếu đã mã hoá
- Kiểm tra xem một bản trình chiếu có được mã hoá hay không
- Kiểm tra xem một bản trình chiếu có được bảo vệ bằng mật khẩu hay không.

## **Mã hoá một bản trình chiếu**

Bạn có thể mã hoá một bản trình chiếu bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình chiếu bị khóa, người dùng phải cung cấp mật khẩu. 

Để mã hoá hoặc bảo vệ bằng mật khẩu một bản trình chiếu, bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bản trình chiếu. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản trình chiếu đã được mã hoá.

Mã nguồn mẫu này cho thấy cách mã hoá một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt Bảo Vệ Ghi cho Một Bản Trình Chiếu**

Bạn có thể thêm một dấu hiệu “Không sửa đổi” vào một bản trình chiếu. Bằng cách này, bạn thông báo cho người dùng rằng bạn không muốn họ thay đổi bản trình chiếu.

**Note** rằng quá trình bảo vệ ghi không mã hoá bản trình chiếu. Do đó, người dùng—nếu họ thực sự muốn—có thể sửa đổi bản trình chiếu, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản trình chiếu với tên khác. 

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Mã nguồn mẫu này cho thấy cách đặt bảo vệ ghi cho một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tải một Bản Trình Chiếu Đã Mã Hoá**

Aspose.Slides cho phép bạn tải một tệp đã mã hoá bằng cách truyền mật khẩu của nó. Để giải mã một bản trình chiếu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) không có tham số. Sau đó, bạn sẽ phải nhập mật khẩu đúng để tải bản trình chiếu.

Mã nguồn mẫu này cho thấy cách giải mã một bản trình chiếu: 

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

## **Gỡ Bỏ Mã Hoá khỏi Một Bản Trình Chiếu**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ bằng mật khẩu trên một bản trình chiếu. Bằng cách này, người dùng có thể truy cập hoặc sửa đổi bản trình chiếu mà không bị hạn chế. 

Để gỡ bỏ mã hoá hoặc bảo vệ bằng mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Mã nguồn mẫu này cho thấy cách gỡ bỏ mã hoá khỏi một bản trình chiếu:

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

## **Gỡ Bỏ Bảo Vệ Ghi khỏi Một Bản Trình Chiếu**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên một tệp bản trình chiếu. Bằng cách này, người dùng có thể sửa đổi tùy ý—và họ sẽ không nhận được cảnh báo khi thực hiện các thao tác đó.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Mã nguồn mẫu này cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy Thuộc Tính của Một Bản Trình Chiếu Được Mã Hoá**

Thông thường, người dùng gặp khó khăn trong việc truy xuất các thuộc tính tài liệu của một bản trình chiếu đã được mã hoá hoặc bảo vệ bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ bằng mật khẩu một bản trình chiếu đồng thời vẫn cho phép người dùng truy cập các thuộc tính của nó.

**Note:** Mặc định, khi Aspose.Slides mã hoá một bản trình chiếu, các thuộc tính tài liệu của bản trình chiếu cũng được bảo vệ bằng mật khẩu. Nếu bạn cần cho phép các thuộc tính tài liệu vẫn có thể truy cập ngay cả sau khi mã hoá, Aspose.Slides cho phép bạn thực hiện điều đó.

Nếu bạn muốn người dùng vẫn có thể truy cập các thuộc tính của một bản trình chiếu đã mã hoá, truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Mã nguồn mẫu này cho thấy cách mã hoá một bản trình chiếu đồng thời vẫn cung cấp cho người dùng quyền truy cập vào các thuộc tính tài liệu:

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

## **Chỉ Tải Thuộc Tính Tài Liệu từ Một Bản Trình Chiếu Được Mã Hoá**

Để kiểm tra siêu dữ liệu của một bản trình chiếu đã mã hoá mà không tải các slide hoặc nội dung khác, tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/) và truyền `true` vào [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Trong chế độ này, Aspose.Slides bỏ qua mật khẩu và chỉ tải các thuộc tính tài liệu công khai.

Ví dụ mã sau đọc các thuộc tính tài liệu tích hợp và tùy chỉnh thông qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Quy trình này chỉ hoạt động khi các thuộc tính tài liệu đã được để ở trạng thái không mã hoá (công khai) khi bản trình chiếu được mã hoá. Nếu các thuộc tính tài liệu bị mã hoá, truyền `true` vào `loadOptions.setOnlyLoadDocumentProperties` sẽ gây ra ngoại lệ vì mật khẩu bị bỏ qua trong chế độ này. Để truy cập các thuộc tính tài liệu đã mã hoá hoặc tải toàn bộ bản trình chiếu, bao gồm các slide và nội dung khác, hãy cung cấp mật khẩu đúng qua [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kiểm Tra Một Bản Trình Chiếu Có Được Bảo Vệ Bằng Mật Khẩu Hay Không**

Trước khi tải một bản trình chiếu, bạn có thể muốn kiểm tra và xác nhận rằng bản trình chiếu không được bảo vệ bằng mật khẩu. Bằng cách này, bạn tránh được các lỗi và vấn đề tương tự xảy ra khi một bản trình chiếu được bảo vệ bằng mật khẩu được tải mà không có mật khẩu.

Mã Java này cho thấy cách kiểm tra một bản trình chiếu để xem nó có được bảo vệ bằng mật khẩu hay không (không tải bản trình chiếu):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm Tra Một Bản Trình Chiếu Có Được Mã Hoá Hay Không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được mã hoá hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bản trình chiếu được mã hoá hoặc `false` nếu không được mã hoá.

Mã nguồn mẫu này cho thấy cách kiểm tra một bản trình chiếu có được mã hoá hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm Tra Một Bản Trình Chiếu Có Được Bảo Vệ Ghi Hay Không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bản trình chiếu được bảo vệ ghi hoặc `false` nếu không.

Mã nguồn mẫu này cho thấy cách kiểm tra một bản trình chiếu có được bảo vệ ghi hay không:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác Thực Hoặc Xác Nhận Mật Khẩu Cụ Thể Đã Được Sử Dụng**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình chiếu. Aspose.Slides cung cấp cách để bạn xác thực mật khẩu. 

Mã nguồn mẫu này cho thấy cách xác thực một mật khẩu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kiểm tra xem "pass" có khớp với
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Nó trả về `true` nếu bản trình chiếu đã được mã hoá bằng mật khẩu được chỉ định. Nếu không, nó trả về `false`. 

{{% alert color="primary" title="Xem thêm" %}} 
- [Chữ ký số trong PowerPoint](/slides/vi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides hỗ trợ các phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản trình chiếu của bạn.

**Điều gì sẽ xảy ra nếu nhập sai mật khẩu khi cố gắng mở một bản trình chiếu?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu sai, thông báo rằng truy cập vào bản trình chiếu bị từ chối. Điều này giúp ngăn ngừa truy cập trái phép và bảo vệ nội dung bản trình chiếu.

**Có ảnh hưởng nào đến hiệu năng khi làm việc với các bản trình chiếu được bảo vệ bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể tạo ra một chút chi phí phụ trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không gây ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ liên quan đến bản trình chiếu.