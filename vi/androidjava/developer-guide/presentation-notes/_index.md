---
title: Quản lý Ghi chú Bản trình bày trên Android
linktitle: Ghi chú Bản trình bày
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình bày với Aspose.Slides cho Android bằng Java. Làm việc mượt mà với ghi chú PowerPoint và OpenDocument để nâng cao năng suất của bạn."
---
## **Overview**

Aspose.Slides hỗ trợ xóa các slide ghi chú khỏi một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng có thể áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:
- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

## **Xóa Ghi chú khỏi một Slide**
Ghi chú của một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```java
// Tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của slide đầu tiên
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Lưu bản trình bày vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa Ghi chú khỏi một Bản trình bày**
Ghi chú của tất cả các slide trong một bản trình bày có thể được xóa như trong ví dụ dưới đây:

```java
// Tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Xóa ghi chú của tất cả các slide
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Lưu bản trình bày vào đĩa
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Kiểu cho Ghi chú**
Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) đã được thêm vào giao diện [IMasterNotesSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterNotesSlide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/MasterNotesSlide) tương ứng. Thuộc tính này xác định kiểu của văn bản ghi chú. Việc triển khai được thể hiện trong ví dụ dưới đây.

```java
// Tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Lấy kiểu văn bản của MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Đặt biểu tượng gạch đầu dòng cho các đoạn văn cấp độ đầu tiên
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notesslidemanager/) và một [method](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện làm việc không?**

Thư viện hỗ trợ một loạt rộng các định dạng Microsoft PowerPoint (từ 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt bản sao PowerPoint.