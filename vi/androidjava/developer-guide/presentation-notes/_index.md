---
title: Quản lý ghi chú bản trình chiếu trên Android
linktitle: Ghi chú bản trình chiếu
type: docs
weight: 110
url: /vi/androidjava/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình chiếu với Aspose.Slides cho Android qua Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để nâng cao năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bản trình chiếu. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình chiếu. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng có thể áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình chiếu.
- Xóa ghi chú khỏi tất cả các slide trong bản trình chiếu.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển đổi hướng, và kiểm tra hành vi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/androidjava/notes-size/).

## **Xóa Ghi chú khỏi Slide**

Ghi chú từ một slide cụ thể có thể được xóa như được thể hiện trong ví dụ bên dưới:

```java
import com.aspose.slides.*;

// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của slide đầu tiên
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Lưu bản trình chiếu vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa Ghi chú khỏi Bản trình chiếu**

Ghi chú từ tất cả các slide trong bản trình chiếu có thể được xóa như được thể hiện trong ví dụ bên dưới:

```java
import com.aspose.slides.*;

// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của tất cả các slide
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Lưu bản trình chiếu vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Kiểu Ghi chú**

Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) đã được thêm vào giao diện [IMasterNotesSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterNotesSlide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/MasterNotesSlide) tương ứng. Thuộc tính này chỉ định kiểu cho văn bản ghi chú. Việc triển khai được minh họa trong ví dụ bên dưới.

```java
import com.aspose.slides.*;

// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Lấy kiểu văn bản của MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Đặt ký hiệu bullet cho các đoạn văn cấp độ đầu tiên
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notesslidemanager/) và một [phương thức](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 đến các phiên bản mới hơn) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.