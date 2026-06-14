---
title: "Trích xuất các đối tượng Flash từ bản trình chiếu trên Android"
linktitle: "Flash"
type: docs
weight: 10
url: /vi/androidjava/flash/
keywords:
- "trích xuất flash"
- "đối tượng flash"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu cách trích xuất các đối tượng Flash từ các slide PowerPoint và OpenDocument trong Java với Aspose.Slides cho Android, kèm ví dụ mã đầy đủ và các thực tiễn tốt nhất."
---
## **Tổng quan**

Bài viết này giải thích cách trích xuất các đối tượng Flash từ bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tìm một điều khiển Flash theo tên trong bộ sưu tập controls của một slide và làm việc với dữ liệu đối tượng SWF được nhúng.

## **Trích xuất đối tượng Flash từ bản trình chiếu**

Aspose.Slides for Android via Java cung cấp tính năng để trích xuất các đối tượng flash từ một bản trình chiếu. Bạn có thể truy cập điều khiển flash theo tên và trích xuất nó từ bản trình chiếu, bao gồm việc lưu dữ liệu đối tượng SWF.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các định dạng bản trình chiếu nào được hỗ trợ khi trích xuất nội dung Flash?**

[Aspose.Slides supports](/slides/vi/androidjava/supported-file-formats/) các định dạng PowerPoint chính như PPT và PPTX, vì nó có thể tải các container này và truy cập các control của chúng, bao gồm các thành phần ActiveX liên quan đến Flash.

**Tôi có thể chuyển đổi bản trình chiếu có Flash sang HTML5 và giữ lại tính tương tác của Flash không?**

Không. Aspose.Slides không thực thi nội dung SWF hoặc chuyển đổi tính tương tác của nó. Mặc dù việc xuất sang [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/vi/androidjava/export-to-html5/) được hỗ trợ, Flash sẽ không chạy trong các trình duyệt hiện đại do kết thúc hỗ trợ. Đường hướng được đề xuất là thay thế Flash bằng các giải pháp thay thế như video hoặc hoạt ảnh HTML5 trước khi xuất.

**Về mặt bảo mật, Aspose.Slides có thực thi các tệp SWF khi đọc bản trình chiếu không?**

Không. Aspose.Slides xem Flash như dữ liệu nhị phân được nhúng trong tệp và không thực thi nội dung SWF trong quá trình xử lý.

**Làm thế nào để tôi xử lý các bản trình chiếu có chứa Flash cùng với các tệp nhúng khác qua OLE?**

Aspose.Slides hỗ trợ [extracting embedded OLE objects](/slides/vi/androidjava/manage-ole/), vì vậy bạn có thể xử lý tất cả nội dung nhúng liên quan trong một lần, xử lý các điều khiển Flash và các tài liệu nhúng OLE khác cùng lúc.