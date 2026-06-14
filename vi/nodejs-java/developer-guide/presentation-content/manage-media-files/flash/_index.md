---
title: Trích xuất các đối tượng Flash từ bản trình bày trong JavaScript
linktitle: Flash
type: docs
weight: 10
url: /vi/nodejs-java/flash/
keywords:
- trích xuất flash
- đối tượng flash
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách trích xuất các đối tượng Flash từ các slide PowerPoint và OpenDocument trong JavaScript với Aspose.Slides, kèm theo các mẫu mã đầy đủ và các thực tiễn tốt nhất."
---
## **Tổng quan**

Bài viết này giải thích cách trích xuất các đối tượng Flash từ bản trình bày bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách tìm một điều khiển Flash theo tên trong bộ sưu tập điều khiển của slide và làm việc với dữ liệu đối tượng SWF được nhúng.

## **Trích xuất đối tượng Flash từ bản trình bày**

Aspose.Slides for Node.js via Java cung cấp khả năng trích xuất các đối tượng flash từ bản trình bày. Bạn có thể truy cập điều khiển flash theo tên và trích xuất nó từ bản trình bày, bao gồm việc lưu trữ dữ liệu đối tượng SWF.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Các định dạng bản trình bày nào được hỗ trợ khi trích xuất nội dung Flash?**

[Aspose.Slides supports](/slides/vi/nodejs-java/supported-file-formats/) các định dạng PowerPoint chính như PPT và PPTX, vì nó có thể tải các container này và truy cập các điều khiển, bao gồm các phần tử ActiveX liên quan tới Flash.

**Tôi có thể chuyển đổi bản trình bày có Flash sang HTML5 và vẫn giữ được tính tương tác của Flash không?**

Không. Aspose.Slides không thực thi nội dung SWF hoặc chuyển đổi tính tương tác của nó. Mặc dù hỗ trợ xuất sang [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/vi/nodejs-java/export-to-html5/), Flash sẽ không hoạt động trong các trình duyệt hiện đại do kết thúc hỗ trợ. Đường đi được khuyến nghị là thay thế Flash bằng các giải pháp thay thế như video hoặc hoạt ảnh HTML5 trước khi xuất.

**Về mặt bảo mật, Aspose.Slides có thực thi các tệp SWF khi đọc bản trình bày không?**

Không. Aspose.Slides coi Flash là dữ liệu nhị phân được nhúng trong tệp và không thực thi nội dung SWF trong quá trình xử lý.

**Tôi nên xử lý như thế nào với các bản trình bày chứa Flash cùng với các tệp nhúng khác qua OLE?**

Aspose.Slides hỗ trợ [extracting embedded OLE objects](/slides/vi/nodejs-java/manage-ole/), vì vậy bạn có thể xử lý tất cả nội dung nhúng liên quan trong một lượt, bao gồm cả các điều khiển Flash và các tài liệu nhúng OLE khác.