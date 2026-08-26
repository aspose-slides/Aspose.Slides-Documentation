---
title: Bảo vệ ghi chú các bản trình chiếu trên Android
linktitle: Bảo vệ ghi chú
type: docs
weight: 25
url: /vi/androidjava/write-protected-presentation/
keywords:
- bảo vệ ghi chú
- bảo vệ ghi chú PowerPoint
- mật khẩu chỉnh sửa
- hạn chế chỉnh sửa bản trình chiếu
- xóa bỏ bảo vệ ghi chú
- xác thực mật khẩu chỉnh sửa
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Đặt, phát hiện, xác thực và xóa bỏ mật khẩu bảo vệ ghi chú trong các bản trình chiếu PowerPoint PPT và PPTX bằng Aspose.Slides cho Android thông qua Java."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi chú hạn chế việc sửa đổi một bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem một bản trình chiếu được bảo vệ ghi chú mà không cần mật khẩu. Tùy vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới một tên khác, vì vậy bảo vệ ghi chú không nên được xem như một cơ chế bảo mật.

Mật khẩu mở có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình chiếu hoặc xác thực mật khẩu mở, xem [Password-Protect Presentations](/slides/vi/androidjava/password-protected-presentation/).

Các quy trình trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu thành PPT, sử dụng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Thiết lập bảo vệ ghi chú cho bản trình chiếu**

Sử dụng [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) để chỉ định mật khẩu cho việc sửa đổi một bản trình chiếu. Lưu bản trình chiếu sẽ lưu lại cài đặt bảo vệ.

Ví dụ sau thiết lập bảo vệ ghi chú cho một bản trình chiếu PPTX:

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

## **Tải một bản trình chiếu được bảo vệ ghi chú**

Vì bảo vệ ghi chú không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền sửa đổi bản trình chiếu đã được bảo vệ.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Không truyền mật khẩu bảo vệ ghi chú vào [ILoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Phương thức này nhận mật khẩu mở cho nội dung đã mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải nó và xử lý mật khẩu bảo vệ ghi chú riêng biệt.

## **Xóa bỏ bảo vệ ghi chú khỏi bản trình chiếu**

Sử dụng [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) để loại bỏ hạn chế sửa đổi, sau đó lưu bản trình chiếu.

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

## **Kiểm tra xem bản trình chiếu có được bảo vệ ghi chú không**

Để kiểm tra một tệp mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) hoàn chỉnh, gọi [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) và kiểm tra [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Phương thức này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/nullablebool/) và trả về `NullableBool.True` khi phát hiện bảo vệ ghi chú.

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

Phiên bản nhận luồng của [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) cung cấp cùng thông tin cho một bản trình chiếu được cung cấp dưới dạng luồng.

## **Xác thực mật khẩu bảo vệ ghi chú**

Sử dụng [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) để xác thực mật khẩu sửa đổi mà không tải toàn bộ bản trình chiếu. Kiểm tra [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) trước để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi chú.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) chỉ xác thực mật khẩu bảo vệ ghi chú. Nó không xác thực mật khẩu mở và không xác định liệu nội dung đã mã hoá có thể được tải hay không. Ngược lại, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) chỉ xác thực mật khẩu mở. Nếu một bản trình chiếu hoàn chỉnh đã được tải, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) cung cấp kiểm tra bảo vệ ghi chú tương đương thông qua trình quản lý bảo vệ.

Trong các ứng dụng thực tế, không ghi lại mật khẩu hoặc đưa chúng vào thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Password-Protect Presentations](/slides/vi/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/vi/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Bảo vệ ghi chú có mã hoá bản trình chiếu không?**

Không. Nó hạn chế việc sửa đổi nhưng vẫn cho phép tải và xem nội dung bản trình chiếu.

**Mật khẩu bảo vệ ghi chú có bắt buộc để mở bản trình chiếu không?**

Không. Chỉ mật khẩu mở mới cần để tải nội dung đã mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi chú không?**

Có. Cung cấp mật khẩu mở qua tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi chú riêng khi cần quyền sửa đổi.