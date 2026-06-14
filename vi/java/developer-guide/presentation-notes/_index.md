---
title: Quản lý ghi chú bài thuyết trình trong Java
linktitle: Ghi chú bài thuyết trình
type: docs
weight: 110
url: /vi/java/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tùy chỉnh ghi chú bài thuyết trình với Aspose.Slides cho Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho slide ghi chú trong một bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

## **Xóa ghi chú khỏi một slide**
Ghi chú của một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```java
// Tạo một đối tượng Presentation đại diện cho file bài thuyết trình
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của slide đầu tiên
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Lưu bài thuyết trình vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa ghi chú khỏi một bản trình bày**
Ghi chú của tất cả các slide trong một bản trình bày có thể được xóa như trong ví dụ dưới đây:

```java
// Tạo một đối tượng Presentation đại diện cho file bài thuyết trình
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của tất cả các slide
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Lưu bài thuyết trình vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm kiểu ghi chú**
[getNotesStyle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method đã được thêm vào giao diện [IMasterNotesSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMasterNotesSlide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/MasterNotesSlide) tương ứng. Thuộc tính này chỉ định kiểu cho văn bản ghi chú. Việc triển khai được minh họa trong ví dụ dưới đây.

```java
// Tạo một đối tượng Presentation đại diện cho file bài thuyết trình
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Lấy kiểu văn bản của MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Đặt ký hiệu dấu đầu dòng cho các đoạn văn cấp độ thứ nhất
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

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notesslidemanager/) và một [method](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện này hoạt động không?**

Thư viện nhắm tới một loạt các định dạng Microsoft PowerPoint (từ 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.