---
title: Bảo vệ ghi các bản trình chiếu trong Java
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/java/write-protected-presentation/
keywords:
- bảo vệ ghi
- PowerPoint bảo vệ ghi
- mật khẩu để sửa đổi
- hạn chế chỉnh sửa bản trình chiếu
- gỡ bỏ bảo vệ ghi
- xác thực mật khẩu sửa đổi
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Đặt, phát hiện, xác thực và gỡ bỏ mật khẩu bảo vệ ghi trong các bản trình chiếu PowerPoint PPT và PPTX bằng cách sử dụng Aspose.Slides cho Java."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi (write‑protection) hạn chế việc sửa đổi một bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình chiếu được bảo vệ ghi mà không cần mật khẩu. Tùy thuộc vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu dưới một tên khác, vì vậy bảo vệ ghi không nên được coi là cơ chế bảo mật.

Mật khẩu mở (opening password) có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình chiếu hoặc xác thực mật khẩu mở, xem [Bảo vệ bản trình chiếu bằng mật khẩu](/slides/vi/java/password-protected-presentation/).

Các quy trình trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu thành PPT, sử dụng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt bảo vệ ghi trên bản trình chiếu**

Sử dụng [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) để chỉ định mật khẩu cho việc sửa đổi một bản trình chiếu. Lưu bản trình chiếu sẽ giữ lại cài đặt bảo vệ.

Ví dụ sau đặt bảo vệ ghi cho một bản trình chiếu PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tải bản trình chiếu được bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền sửa đổi bản trình chiếu được bảo vệ.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Không truyền mật khẩu bảo vệ ghi cho [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Phương thức này nhận mật khẩu mở cho nội dung đã mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải nó và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Gỡ bỏ bảo vệ ghi khỏi bản trình chiếu**

Sử dụng [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) để gỡ bỏ hạn chế sửa đổi, sau đó lưu bản trình chiếu.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không**

Để kiểm tra một tệp mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đầy đủ, gọi [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) và kiểm tra [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Phương thức này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/) và trả về `NullableBool.True` khi phát hiện bảo vệ ghi.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Phiên bản overload nhận luồng của [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) cung cấp cùng thông tin cho một bản trình chiếu được cung cấp dưới dạng luồng.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) để xác thực mật khẩu sửa đổi mà không cần tải toàn bộ bản trình chiếu. Đầu tiên kiểm tra [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở hoặc xác định liệu nội dung đã mã hoá có thể được tải hay không. Ngược lại, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) chỉ xác thực mật khẩu mở. Nếu một bản trình chiếu đầy đủ đã được tải, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ của nó.

Trong các ứng dụng thực tế, không ghi log mật khẩu hoặc bao gồm chúng trong các thông báo chẩn đoán. Tránh các yêu cầu xác thực lặp lại không cần thiết, và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="See also" %}}
- [Bảo vệ bản trình chiếu bằng mật khẩu](/slides/vi/java/password-protected-presentation/)
- [Bản trình chiếu chỉ đọc](/slides/vi/java/read-only-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Bảo vệ ghi có mã hoá một bản trình chiếu không?**

Không. Nó chỉ hạn chế việc sửa đổi nhưng vẫn để nội dung bản trình chiếu có thể tải và xem.

**Mật khẩu bảo vệ ghi có bắt buộc để mở một bản trình chiếu không?**

Không. Chỉ một mật khẩu mở là cần thiết để tải nội dung bản trình chiếu đã mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở qua tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng biệt khi cần quyền sửa đổi.