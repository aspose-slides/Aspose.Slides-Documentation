---
title: Quản lý ghi chú bài thuyết trình trong .NET
linktitle: Ghi chú bài thuyết trình
type: docs
weight: 110
url: /vi/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh ghi chú bài thuyết trình với Aspose.Slides cho .NET. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bài thuyết trình. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong một bài thuyết trình. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu dáng cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bài thuyết trình.
- Xóa ghi chú khỏi tất cả các slide trong bài thuyết trình.

## **Xóa ghi chú khỏi một slide**
Ghi chú của một slide cụ thể có thể được xóa như trong ví dụ bên dưới:

```c#
// Khởi tạo đối tượng Presentation đại diện cho tệp bài thuyết trình 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Xóa ghi chú của slide đầu tiên
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Lưu bài thuyết trình vào đĩa
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Xóa ghi chú khỏi tất cả các slide**
Ghi chú của tất cả các slide trong một bài thuyết trình có thể được xóa như trong ví dụ bên dưới:

```c#
// Khởi tạo đối tượng Presentation đại diện cho tệp bài thuyết trình 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Xóa ghi chú của tất cả các slide
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Lưu bài thuyết trình vào đĩa
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Thêm kiểu cho ghi chú**
Thuộc tính NotesStyle đã được thêm vào giao diện [IMasterNotesSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslide) tương ứng. Thuộc tính này xác định kiểu dáng của văn bản ghi chú. Việc triển khai được trình bày trong ví dụ bên dưới.

```c#
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Lấy kiểu văn bản MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Đặt bullet ký hiệu cho các đoạn văn cấp độ đầu tiên
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Lưu tệp PPTX vào đĩa
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/net/aspose.slides/notesslidemanager/) và một [property](https://reference.aspose.com/slides/vi/net/aspose.slides/notesslidemanager/notesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.