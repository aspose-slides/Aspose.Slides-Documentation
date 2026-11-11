---
title: Quản lý ghi chú bản trình bày trong JavaScript
linktitle: Ghi chú bản trình bày
type: docs
weight: 110
url: /vi/nodejs-java/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình bày trong JavaScript với Aspose.Slides cho Node.js. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để nâng cao năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa bỏ các slide ghi chú trong một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong một bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển hướng, và kiểm tra hành vi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/nodejs-java/notes-size/).

## **Xóa Ghi chú khỏi Slide**
Ghi chú từ một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của slide đầu tiên
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Lưu bản trình bày vào đĩa
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Ghi chú khỏi Bản trình bày**
Ghi chú từ tất cả các slide trong một bản trình bày có thể được xóa như trong ví dụ dưới đây:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của tất cả các slide
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Lưu bản trình bày vào đĩa
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm NotesStyle**
Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) đã được thêm vào lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterNotesSlide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterNotesSlide) tương ứng. Thuộc tính này xác định kiểu cho văn bản ghi chú. Ví dụ thực hiện được trình bày dưới đây.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Lấy kiểu văn bản MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Đặt dấu đầu dòng ký hiệu cho các đoạn ở cấp độ đầu tiên
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslidemanager/) và một [method](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt bản sao PowerPoint.