---
title: Bảo mật bài thuyết trình bằng mật khẩu trên Android
linktitle: Bảo vệ bằng mật khẩu
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
description: "Dễ dàng khóa và mở khóa các bài thuyết trình PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho Android qua Java. Bảo vệ các bài thuyết trình của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bài thuyết trình bằng mật khẩu, nghĩa là bạn đặt mật khẩu để áp dụng một số hạn chế cho bài thuyết trình. Để loại bỏ các hạn chế, phải nhập mật khẩu. Một bài thuyết trình được bảo vệ bằng mật khẩu được coi là bài thuyết trình bị khóa.

Thông thường, bạn có thể đặt mật khẩu để áp dụng các hạn chế này cho một bài thuyết trình:

- **Sửa đổi**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bài thuyết trình của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người khác sửa đổi, thay đổi hoặc sao chép các nội dung trong bài thuyết trình (trừ khi họ cung cấp mật khẩu). 

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Trong chế độ chỉ đọc, người dùng có thể xem nội dung hoặc các yếu tố—liên kết, hoạt ảnh, hiệu ứng và các yếu tố khác—trong bài thuyết trình, nhưng không thể sao chép mục nào hoặc lưu bài thuyết trình. 

- **Mở**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bài thuyết trình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác thậm chí xem nội dung của bài thuyết trình (trừ khi họ cung cấp mật khẩu).

  Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bài thuyết trình: Khi người dùng không thể mở bài thuyết trình, họ không thể thực hiện sửa đổi hay thay đổi bất kỳ gì. 
  
  **Lưu ý** rằng khi bạn bảo vệ một bài thuyết trình bằng mật khẩu để ngăn mở, tệp bài thuyết trình sẽ được mã hoá.

## **Bảo vệ bằng mật khẩu cho Bài thuyết trình trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ bằng mật khẩu, mã hoá và các thao tác tương tự cho các bài thuyết trình ở các định dạng sau: 

- PPTX và PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ bằng mật khẩu trên các bài thuyết trình để ngăn sửa đổi theo các cách sau:

- Mã hoá một bài thuyết trình
- Đặt bảo vệ ghi (write protection) cho một bài thuyết trình

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các tác vụ khác liên quan đến bảo vệ bằng mật khẩu và mã hoá theo các cách sau:

- Giải mã một bài thuyết trình; mở một bài thuyết trình đã được mã hoá
- Gỡ bỏ mã hoá; vô hiệu hoá bảo vệ bằng mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình
- Lấy các thuộc tính của một bài thuyết trình đã được mã hoá
- Kiểm tra xem một bài thuyết trình có được mã hoá hay không
- Kiểm tra xem một bài thuyết trình có được bảo vệ bằng mật khẩu hay không.

## **Mã hoá một Bài thuyết trình**

Bạn có thể mã hoá một bài thuyết trình bằng cách đặt mật khẩu. Sau đó, để sửa đổi bài thuyết trình bị khóa, người dùng phải cung cấp mật khẩu. 

Để mã hoá hoặc bảo vệ bằng mật khẩu một bài thuyết trình, bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bài thuyết trình. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bài thuyết trình đã được mã hoá.

Mã mẫu dưới đây cho thấy cách mã hoá một bài thuyết trình:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt Bảo vệ Ghi cho một Bài thuyết trình**

Bạn có thể thêm một ghi chú “Do not modify” vào một bài thuyết trình. Bằng cách này, bạn thông báo với người dùng rằng bạn không muốn họ thay đổi nội dung của bài thuyết trình.  

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bài thuyết trình. Do đó, người dùng—nếu họ muốn—có thể sửa đổi bài thuyết trình, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản mới với tên khác. 

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Mã mẫu dưới đây cho thấy cách đặt bảo vệ ghi cho một bài thuyết trình:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tải một Bài thuyết trình Được Mã hoá**

Aspose.Slides cho phép bạn tải một bài thuyết trình đã được mã hoá bằng cách truyền mật khẩu đúng qua [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/).

Mã mẫu dưới đây cho thấy cách mở một bài thuyết trình đã được mã hoá: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bài thuyết trình đã giải mã
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gỡ bỏ Mã hoá khỏi một Bài thuyết trình**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ bằng mật khẩu trên một bài thuyết trình. Bằng cách này, người dùng sẽ có thể truy cập hoặc sửa đổi bài thuyết trình mà không có bất kỳ hạn chế nào. 

Để gỡ bỏ mã hoá hoặc bảo vệ bằng mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Mã mẫu dưới đây cho thấy cách gỡ bỏ mã hoá khỏi một bài thuyết trình:

```java
import com.aspose.slides.*;

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

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên một tệp bài thuyết trình. Bằng cách này, người dùng có thể sửa đổi tùy ý—và họ sẽ không nhận cảnh báo khi thực hiện các thao tác như vậy.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--). Mã mẫu dưới đây cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bài thuyết trình:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy Thuộc tính của một Bài thuyết trình Được Mã hoá**

Thông thường, người dùng gặp khó khăn trong việc truy xuất các thuộc tính tài liệu của một bài thuyết trình đã được mã hoá hoặc bảo vệ bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ bằng mật khẩu một bài thuyết trình trong khi vẫn giữ khả năng người dùng truy cập các thuộc tính của nó.

**Lưu ý:** Mặc định, khi Aspose.Slides mã hoá một bài thuyết trình, các thuộc tính tài liệu của bài thuyết trình cũng sẽ được bảo vệ bằng mật khẩu. Nếu bạn cần cho phép truy cập các thuộc tính tài liệu ngay cả sau khi mã hoá, Aspose.Slides cho phép bạn thực hiện điều đó.

Nếu bạn muốn người dùng vẫn có khả năng truy cập các thuộc tính của một bài thuyết trình đã được mã hoá, truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Mã mẫu dưới đây cho thấy cách mã hoá một bài thuyết trình trong khi vẫn cung cấp cho người dùng quyền truy cập các thuộc tính tài liệu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Chỉ Tải Thuộc tính Tài liệu từ một Bài thuyết trình Được Mã hoá**

Để kiểm tra siêu dữ liệu của một bài thuyết trình đã được mã hoá mà không tải các slide hoặc nội dung khác, tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/) và truyền `true` vào [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Ở chế độ này, Aspose.Slides bỏ qua mật khẩu và chỉ tải các thuộc tính tài liệu công khai.

Đoạn mã sau đọc các thuộc tính tài liệu tích hợp và tùy chỉnh thông qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

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

Quy trình này chỉ hoạt động khi các thuộc tính tài liệu được để ở trạng thái không được mã hoá (công khai) khi bài thuyết trình được mã hoá. Nếu các thuộc tính tài liệu bị mã hoá, việc truyền `true` vào `loadOptions.setOnlyLoadDocumentProperties` sẽ gây ra ngoại lệ vì mật khẩu bị bỏ qua trong chế độ này. Để truy cập các thuộc tính tài liệu đã được mã hoá hoặc tải toàn bộ bài thuyết trình, bao gồm các slide và nội dung khác, cung cấp mật khẩu đúng qua [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kiểm tra liệu một Bài thuyết trình có được Bảo vệ bằng Mật khẩu hay không**

Trước khi tải một bài thuyết trình, bạn có thể muốn kiểm tra và xác nhận rằng bài thuyết trình chưa được bảo vệ bằng mật khẩu. Bằng cách này, bạn tránh được lỗi và các vấn đề tương tự phát sinh khi một bài thuyết trình được bảo vệ bằng mật khẩu được tải mà không có mật khẩu.

Mã Java dưới đây cho thấy cách kiểm tra một bài thuyết trình có bị bảo vệ bằng mật khẩu hay không (không tải bài thuyết trình):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra liệu một Bài thuyết trình có được Mã hoá hay không**

Aspose.Slides cho phép bạn kiểm tra một bài thuyết trình có được mã hoá hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bài thuyết trình đã được mã hoá hoặc `false` nếu chưa được mã hoá.

Mã mẫu dưới đây cho thấy cách kiểm tra liệu một bài thuyết trình có được mã hoá hay không:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra liệu một Bài thuyết trình có được Bảo vệ Ghi hay không**

Aspose.Slides cho phép bạn kiểm tra một bài thuyết trình có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bài thuyết trình được bảo vệ ghi hoặc `false` nếu không.

Mã mẫu dưới đây cho thấy cách kiểm tra liệu một bài thuyết trình có được bảo vệ ghi hay không:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác nhận hoặc Kiểm tra Một Mật khẩu Cụ thể Đã Được Sử dụng**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bài thuyết trình. Aspose.Slides cung cấp phương pháp để xác thực mật khẩu. 

Mã mẫu dưới đây cho thấy cách xác thực mật khẩu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // kiểm tra xem "pass" có khớp hay không
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Nó trả về `true` nếu bài thuyết trình đã được bảo vệ ghi bằng mật khẩu đã cho. Ngược lại, nó trả về `false`. 

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/vi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các phương pháp mã hoá nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bài thuyết trình của bạn.

**Điều gì sẽ xảy ra nếu nhập sai mật khẩu khi cố gắng mở một bài thuyết trình?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng, thông báo rằng quyền truy cập vào bài thuyết trình bị từ chối. Điều này giúp ngăn chặn truy cập trái phép và bảo vệ nội dung bài thuyết trình.

**Có bất kỳ tác động nào đến hiệu năng khi làm việc với các bài thuyết trình được bảo vệ bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể gây ra một chút chi phí thêm trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không ảnh hưởng đáng kể tới thời gian xử lý tổng thể của các công việc liên quan đến bài thuyết trình.