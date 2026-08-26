---
title: Bảo vệ mật khẩu cho bản trình chiếu bằng Java
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/java/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- Java
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong Java với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Mật khẩu đúng là bắt buộc để tải và xem nội dung bản trình chiếu, vì vậy bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/java/write-protected-presentation/).

Các quy trình công việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager.encrypt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) để gán một mật khẩu mở khóa. Sau đó sử dụng [IPresentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

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

## **Tải bản trình chiếu đã được mã hoá**

Đặt [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) thành mật khẩu mở khóa và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu được cung cấp thiếu hoặc không đúng.

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

## **Xóa mã hoá khỏi bản trình chiếu**

Tải bản trình chiếu bằng mật khẩu mở khóa của nó, gọi [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

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

Sử dụng [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/) mà không tạo một thể hiện hoàn chỉnh của bản trình chiếu. Kiểm tra [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) trước khi yêu cầu hoặc xác thực mật khẩu. Khi bảo vệ tồn tại, xác thực giá trị đã cung cấp bằng [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Quy trình làm việc theo Đường dẫn Tệp**

Ví dụ sau xác thực một mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực cho [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), và sau đó tải bản trình chiếu hoàn chỉnh:

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

### **Quy trình làm việc với Luồng**

Phiên bản overload dựa trên luồng của [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) cung cấp cùng một quy trình công việc. Đặt lại vị trí của một luồng có thể di chuyển trước khi tải bản trình chiếu hoàn chỉnh từ luồng đó.

Ví dụ sau sử dụng một tệp PPT:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau đối với các bản trình chiếu PPT và PPTX.

## **Kiểm tra bản trình chiếu đã tải có được mã hoá hay không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo.isPasswordProtected` như đã mô tả ở trên.

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
Không ghi lại mật khẩu mở khóa hoặc đưa chúng vào các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.
{{% /alert %}}

## **Bảo vệ mật khẩu cho bản trình chiếu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Tùy chọn nhập một mật khẩu riêng biệt để bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/vi/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình chiếu và là bắt buộc để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải tất cả các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem bảo vệ bằng mật khẩu mở khóa có tồn tại hay không, và xác thực mật khẩu trước khi tạo một thể hiện hoàn chỉnh của bản trình chiếu.

**Các quy trình xác thực mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và dựa trên luồng hoạt động giống nhau đối với các bản trình chiếu PPT và PPTX.