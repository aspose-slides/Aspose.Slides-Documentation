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
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa dễ dàng các bản trình bày PowerPoint và OpenDocument được bảo mật bằng mật khẩu với Aspose.Slides cho Java. Bảo vệ bản trình bày của bạn."
---
## **Giới thiệu**

Khi bạn bảo mật bằng mật khẩu cho một bản trình bày, nghĩa là bạn đặt một mật khẩu để thực thi các hạn chế nhất định trên bản trình bày. Để gỡ bỏ các hạn chế này, cần nhập mật khẩu. Một bản trình bày được bảo mật bằng mật khẩu được coi là bản trình bày bị khóa.

Thông thường, bạn có thể đặt mật khẩu để thực thi các hạn chế này trên một bản trình bày:

- **Sửa đổi**

Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình bày của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người dùng sửa đổi, thay đổi hoặc sao chép các yếu tố trong bản trình bày trừ khi họ cung cấp mật khẩu. 

Tuy nhiên, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập và mở tài liệu của bạn. Ở chế độ chỉ đọc này, người dùng có thể xem nội dung — bao gồm siêu liên kết, hoạt ảnh, hiệu ứng và các yếu tố khác — trong bản trình bày, nhưng họ không thể sao chép mục nào hoặc lưu bản trình bày.

- **Mở file**

Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình bày của mình, bạn có thể đặt hạn chế mở file. Hạn chế này ngăn người dùng thậm chí xem nội dung của bản trình bày trừ khi họ cung cấp mật khẩu.

Kỹ thuật적으로, hạn chế mở file cũng ngăn người dùng sửa đổi bản trình bày — nếu người dùng không thể mở bản trình bày, họ cũng không thể sửa đổi hoặc thực hiện thay đổi nào.

**Lưu ý:** Khi bạn bảo mật bằng mật khẩu để ngăn mở file, tệp bản trình bày sẽ được mã hoá.

## **Bảo mật bằng mật khẩu trong Aspose.Slides**
**Các định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo mật bằng mật khẩu, mã hoá và các hoạt động tương tự cho các bản trình bày ở các định dạng sau: 

- PPTX và PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Các hoạt động được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo mật bằng mật khẩu trên bản trình bày để ngăn sửa đổi theo các cách sau:

- Mã hoá bản trình bày
- Đặt bảo vệ ghi (write protection) cho bản trình bày

**Các hoạt động khác**

Aspose.Slides cho phép bạn thực hiện các nhiệm vụ khác liên quan đến bảo mật bằng mật khẩu và mã hoá như sau:

- Giải mã bản trình bày; mở một bản trình bày đã mã hoá
- Gỡ bỏ mã hoá; tắt bảo mật bằng mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình bày
- Lấy các thuộc tính của một bản trình bày đã mã hoá
- Kiểm tra xem một bản trình bày có được mã hoá hay không
- Kiểm tra xem một bản trình bày có được bảo mật bằng mật khẩu hay không.

## **Bảo vệ một bản trình bày bằng mật khẩu**

Bạn có thể mã hoá một bản trình bày bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình bày bị khóa, người dùng phải cung cấp mật khẩu. 

Để mã hoá hoặc bảo mật bằng mật khẩu cho một bản trình bày, bạn phải sử dụng phương thức encrypt (từ [IProtectionManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager)) để đặt mật khẩu cho bản trình bày. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản trình bày đã được mã hoá. 

Mã mẫu dưới đây cho thấy cách mã hoá một bản trình bày:

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

## **Đặt bảo vệ ghi cho một bản trình bày**

Bạn có thể thêm một dấu “Không chỉnh sửa” vào bản trình bày. Cách này cho phép bạn thông báo cho người dùng rằng bạn không muốn họ thay đổi bản trình bày.  

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bản trình bày. Do đó, người dùng — nếu họ thực sự muốn — có thể sửa đổi bản trình bày, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản trình bày với tên khác. 

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức [setWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Mã mẫu dưới đây cho thấy cách đặt bảo vệ ghi cho một bản trình bày:

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

## **Tải một bản trình bày đã mã hoá**

Aspose.Slides cho phép bạn tải một bản trình bày đã mã hoá bằng cách truyền mật khẩu đúng qua [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/). 

Mã mẫu dưới đây cho thấy cách tải một bản trình bày đã mã hoá: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // làm việc với bản trình bày đã giải mã
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gỡ bỏ mã hoá khỏi một bản trình bày**

Bạn có thể gỡ bỏ mã hoá hoặc bảo mật bằng mật khẩu trên một bản trình bày. Cách này cho phép người dùng truy cập hoặc sửa đổi bản trình bày mà không có hạn chế. 

Để gỡ bỏ mã hoá hoặc bảo mật bằng mật khẩu, bạn phải gọi phương thức [removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Mã mẫu dưới đây cho thấy cách gỡ bỏ mã hoá khỏi một bản trình bày:

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

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình bày**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên một tệp bản trình bày. Cách này cho phép người dùng sửa đổi tùy ý — và họ sẽ không nhận được cảnh báo khi thực hiện các thao tác đó.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình bày bằng cách sử dụng phương thức [removeWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Mã mẫu dưới đây cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản trình bày:

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

## **Lấy thuộc tính của một bản trình bày đã mã hoá**

Thông thường, người dùng gặp khó khăn khi truy xuất các thuộc tính tài liệu của một bản trình bày đã được mã hoá hoặc bảo mật bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp cơ chế cho phép bạn bảo mật bằng mật khẩu một bản trình bày đồng thời vẫn cho phép người dùng truy cập các thuộc tính của nó.

**Lưu ý:** Mặc định, khi Aspose.Slides mã hoá một bản trình bày, các thuộc tính tài liệu của bản trình bày cũng sẽ được bảo mật bằng mật khẩu. Nếu bạn cần cho phép truy cập các thuộc tính tài liệu ngay cả sau khi mã hoá, Aspose.Slides cho phép bạn làm điều đó.

Nếu bạn muốn người dùng vẫn có khả năng truy cập các thuộc tính của một bản trình bày đã mã hoá, truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Mã mẫu dưới đây cho thấy cách mã hoá một bản trình bày đồng thời vẫn cung cấp cho người dùng quyền truy cập các thuộc tính tài liệu:

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

## **Chỉ tải thuộc tính tài liệu từ một bản trình bày đã mã hoá**

Để kiểm tra siêu dữ liệu của một bản trình bày đã mã hoá mà không tải các slide hoặc nội dung khác, tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) và truyền `true` vào [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Ở chế độ này, Aspose.Slides sẽ bỏ qua mật khẩu và chỉ tải các thuộc tính tài liệu công khai.

Đoạn mã sau đọc các thuộc tính tài liệu tích hợp và tùy chỉnh thông qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Quy trình này chỉ hoạt động khi các thuộc tính tài liệu được để ở trạng thái không mã hoá (công khai) khi bản trình bày được mã hoá. Nếu các thuộc tính tài liệu bị mã hoá, việc truyền `true` vào `loadOptions.setOnlyLoadDocumentProperties` sẽ gây ra ngoại lệ vì mật khẩu bị bỏ qua trong chế độ này. Để truy cập các thuộc tính tài liệu đã mã hoá hoặc tải toàn bộ bản trình bày, bao gồm các slide và nội dung khác, hãy cung cấp mật khẩu đúng qua [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kiểm tra xem một bản trình bày có được bảo mật bằng mật khẩu không**

Trước khi tải một bản trình bày, bạn có thể muốn kiểm tra và xác nhận rằng bản trình bày chưa được bảo mật bằng mật khẩu. Cách này giúp tránh các lỗi và vấn đề tương tự phát sinh khi tải một bản trình bày bảo mật mà không có mật khẩu.

Mã Java dưới đây cho thấy cách kiểm tra một bản trình bày để xác định xem nó có được bảo mật bằng mật khẩu hay không (không tải bản trình bày thực tế):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kiểm tra xem một bản trình bày có được mã hoá không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được mã hoá hay không. Để thực hiện nhiệm vụ này, bạn có thể sử dụng thuộc tính [isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isEncrypted--) , trả về `true` nếu bản trình bày được mã hoá hoặc `false` nếu không được mã hoá. 

Mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình bày có được mã hoá không:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kiểm tra xem một bản trình bày có được bảo vệ ghi không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình bày có được bảo vệ ghi hay không. Để thực hiện nhiệm vụ này, bạn có thể sử dụng thuộc tính [isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , trả về `true` nếu bản trình bày được bảo vệ ghi hoặc `false` nếu không. 

Mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình bày có được bảo vệ ghi không:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Xác thực hoặc xác nhận rằng một mật khẩu cụ thể đã được sử dụng**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình bày. Aspose.Slides cung cấp công cụ để bạn xác thực một mật khẩu. 

Mã mẫu dưới đây cho thấy cách xác thực một mật khẩu:

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

Nó trả về `true` nếu bản trình bày đã được bảo vệ ghi bằng mật khẩu được chỉ định. Ngược lại, nó trả về `false`. 

{{% alert color="info" title="Xem thêm" %}} 
- [Digital Signature in PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Phương pháp mã hoá nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản trình bày của bạn.

**Điều gì sẽ xảy ra nếu nhập sai mật khẩu khi cố mở một bản trình bày?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng, thông báo rằng quyền truy cập vào bản trình bày bị từ chối. Điều này giúp ngăn chặn việc truy cập trái phép và bảo vệ nội dung bản trình bày.

**Có ảnh hưởng gì đến hiệu năng khi làm việc với các bản trình bày được bảo mật bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể tạo ra một chút chi phí bổ sung trong quá trình mở và lưu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ liên quan đến bản trình bày.