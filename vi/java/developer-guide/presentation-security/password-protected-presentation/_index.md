---
title: Bảo vệ bản trình bày bằng mật khẩu trong Java
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/java/password-protected-presentation/
keywords:
- bản trình bày được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình bày
- kiểm tra mật khẩu bản trình bày
- mở bản trình bày đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình bày
- Java
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình bày PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong Java với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình bày. Mật khẩu đúng cần thiết để tải và xem nội dung bản trình bày, vì vậy biện pháp này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình bày được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình bày, xem [Write-Protect Presentations](/slides/vi/java/write-protected-presentation/).

Các quy trình công việc dưới đây áp dụng cho cả bản trình bày PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng là quan trọng.

## **Mã hoá bản trình bày bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager.encrypt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) để chỉ định mật khẩu mở khóa. Sau đó sử dụng [IPresentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) để lưu bản trình bày đã được mã hoá.

Ví dụ sau mã hoá một bản trình bày PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Giữ Thuộc tính Tài liệu Công khai**

Mặc định, Aspose.Slides bao gồm thuộc tính tài liệu trong quá trình mã hoá bản trình bày. Phương thức [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) kiểm soát hành vi này một cách độc lập với việc mã hoá nội dung slide. Gửi `false` trước khi gọi [IProtectionManager.encrypt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu phải đọc siêu dữ liệu mà không cần mật khẩu mở khóa.

Ví dụ sau tạo một bản trình bày PPTX đã được mã hoá đồng thời để lại các thuộc tính tài liệu tích hợp công khai:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc truyền `false` cho [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) không làm cho các slide, master, layout, shape, media hoặc nội dung bản trình bày khác trở nên công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã được mã hoá, xem [Manage Presentation Properties](/slides/vi/java/presentation-properties/).

## **Tải một Bản trình bày Đã mã hoá**

Đặt [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) thành mật khẩu mở khóa và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu được cung cấp thiếu hoặc không đúng.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Làm việc với bản trình bày đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Gỡ Mã hoá khỏi Bản trình bày**

Tải bản trình bày bằng mật khẩu mở khóa, gọi [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) và lưu lại kết quả. Bản trình bày đã lưu sau đó có thể được tải mà không cần mật khẩu.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xác thực Mật khẩu Mở khóa Trước khi Tải**

Sử dụng [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/) mà không cần tạo một thể hiện bản trình bày đầy đủ. Kiểm tra [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Quy trình làm việc Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho một tệp PPTX, truyền giá trị đã xác thực cho [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), và sau đó tải toàn bộ bản trình bày:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Quy trình làm việc Luồng**

Phiên bản quá tải luồng của [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) cung cấp cùng một quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải toàn bộ bản trình bày từ luồng đó.

Ví dụ sau sử dụng tệp PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Giá trị Trả về của checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) trả về `true` chỉ khi bản trình bày có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình bày không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau cho các bản trình bày PPT và PPTX.

## **Kiểm tra xem Bản trình bày Đã tải có Được mã hoá hay không**

Sau khi tải một bản trình bày bằng mật khẩu đúng, kiểm tra [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) để xác nhận rằng bản trình bày nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo.isPasswordProtected` như đã mô tả ở trên.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các tin nhắn chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình bày ngay lập tức.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và giá trị tùy chỉnh mặc dù nội dung bản trình bày đã được mã hoá. Hãy mã hoá siêu dữ liệu nhạy cảm cùng với bản trình bày. Để các thuộc tính công khai nên là quyết định rõ ràng chỉ khi hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không cần mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ Bản trình bày bằng Mật khẩu Trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình bày.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/vi/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Sự khác biệt giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình bày và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ slide không?**

Có. Lấy thông tin bản trình bày, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình bày đầy đủ.

**Ứng dụng có thể đọc siêu dữ liệu mà không cần mật khẩu mở khóa không?**

Có, nhưng chỉ khi bản trình bày được mã hoá với việc mã hoá thuộc tính tài liệu bị tắt. Ứng dụng sau đó phải sử dụng chế độ tải chỉ thuộc tính tài liệu được mô tả trong [Manage Presentation Properties](/slides/vi/java/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình bày PPT và PPTX.