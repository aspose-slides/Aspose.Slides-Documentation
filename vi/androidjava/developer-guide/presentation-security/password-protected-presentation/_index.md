---
title: Bảo vệ bản trình chiếu bằng mật khẩu trên Android
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/androidjava/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hóa PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hóa
- gỡ bỏ mã hóa
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Mã hóa, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Mật khẩu mở khóa mã hóa một bản trình chiếu. Mật khẩu đúng là cần thiết để tải và xem nội dung bản trình chiếu, do đó bảo vệ này mang lại tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hóa nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/androidjava/write-protected-presentation/).

Các quy trình công việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và luồng của chúng quan trọng.

## **Mã hóa bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager.encrypt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) để gán mật khẩu mở khóa. Sau đó sử dụng [IPresentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) để lưu bản trình chiếu đã được mã hóa.

Ví dụ sau mã hóa một bản trình chiếu PPTX:

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

## **Giữ thuộc tính tài liệu công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hóa bản trình chiếu. Phương thức [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) kiểm soát hành vi này độc lập với việc mã hóa nội dung slide. Gửi `false` trước khi gọi [IProtectionManager.encrypt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không có mật khẩu mở khóa.

Ví dụ dưới đây tạo một bản trình chiếu PPTX được mã hóa trong khi để các thuộc tính tài liệu tích hợp công khai:

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

Việc truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) không làm cho các slide, master, layout, shape, media hoặc nội dung bản trình chiếu khác công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã mã hóa, xem [Manage Presentation Properties](/slides/vi/androidjava/presentation-properties/).

## **Tải bản trình chiếu đã mã hóa**

Đặt [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) thành mật khẩu mở khóa và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi yêu cầu mật khẩu mở khóa nhưng mật khẩu cung cấp bị thiếu hoặc không đúng.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Làm việc với bản trình chiếu đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Xóa mã hóa khỏi bản trình chiếu**

Tải bản trình chiếu với mật khẩu mở khóa, gọi [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

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

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/) mà không tạo một thể hiện bản trình chiếu đầy đủ. Kiểm tra [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) trước khi yêu cầu hoặc xác thực mật khẩu. Khi bảo vệ tồn tại, xác thực giá trị đã cung cấp bằng [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Quy trình dựa trên đường dẫn tệp**

Ví dụ dưới đây xác thực mật khẩu mở khóa cho một tệp PPTX, truyền giá trị đã xác thực cho [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), và sau đó tải bản trình chiếu đầy đủ:

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

### **Quy trình dựa trên luồng**

Phiên bản overload dựa trên luồng của [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) cung cấp cùng một quy trình. Đặt lại vị trí của luồng có thể seek trước khi tải bản trình chiếu đầy đủ từ luồng đó.

Ví dụ dưới đây sử dụng một tệp PPT:

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

### **Giá trị trả về của checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau cho các bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hóa không**

Sau khi tải một bản trình chiếu với mật khẩu đúng, kiểm tra [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) để xác nhận bản trình chiếu nguồn đã được mã hóa. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo.isPasswordProtected` như đã trình bày ở trên.

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

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Bảo mật" %}}
Không ghi lại mật khẩu mở khóa hoặc đưa chúng vào các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bản trình chiếu.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và giá trị tùy chỉnh ngay cả khi nội dung bản trình chiếu đã được mã hóa. Mã hóa siêu dữ liệu nhạy cảm cùng với bản trình chiếu. Việc để các thuộc tính công khai nên là một quyết định rõ ràng chỉ khi hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không có mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bản trình chiếu.
1. Nhập mật khẩu để bảo vệ chế độ xem.
1. Tùy chọn, nhập một mật khẩu riêng để bảo vệ chế độ chỉnh sửa.
1. Áp dụng bảo vệ và tải về tệp kết quả.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo vệ ghi bản trình chiếu](/slides/vi/androidjava/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hóa bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hóa nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình chiếu đầy đủ.

**Ứng dụng có thể đọc siêu dữ liệu mà không cần mật khẩu mở khóa không?**

Có, nhưng chỉ khi bản trình chiếu được mã hóa với việc mã hóa thuộc tính tài liệu bị tắt. Ứng dụng sau đó phải sử dụng chế độ tải chỉ các thuộc tính tài liệu được mô tả trong [Manage Presentation Properties](/slides/vi/androidjava/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình chiếu PPT và PPTX.