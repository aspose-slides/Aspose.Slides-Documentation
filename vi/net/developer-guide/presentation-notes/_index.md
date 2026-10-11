---
title: Quản lý ghi chú bản trình bày trong .NET
linktitle: Ghi chú bản trình bày
type: docs
weight: 110
url: /vi/net/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú master
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình bày với Aspose.Slides cho .NET. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để nâng cao năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ xóa các slide ghi chú khỏi một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu dáng cho các slide ghi chú trong bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng có thể áp dụng định dạng cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển hướng, và kiểm tra hành vi xuất, xem [Kích thước trang ghi chú](/slides/vi/net/notes-size/).

## **Xóa ghi chú khỏi một slide**
Ghi chú của một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
Presentation presentation = new Presentation("AccessSlides.pptx");

// Xóa ghi chú của slide đầu tiên
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Lưu bản trình bày vào đĩa
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Xóa ghi chú khỏi tất cả các slide**
Ghi chú của tất cả các slide trong bản trình bày có thể được xóa như trong ví dụ dưới đây:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
Presentation presentation = new Presentation("AccessSlides.pptx");

// Xóa ghi chú của tất cả các slide
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Lưu bản trình bày vào đĩa
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Thêm kiểu dáng ghi chú**
Thuộc tính NotesStyle đã được thêm vào giao diện [IMasterNotesSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslide) và lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslide) tương ứng. Thuộc tính này xác định kiểu dáng của văn bản ghi chú. Việc triển khai được minh họa trong ví dụ dưới đây.

```c#
using Aspose.Slides;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Lấy kiểu văn bản của MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Đặt bullet ký hiệu cho các đoạn văn cấp độ đầu tiên
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Lưu tệp PPTX vào đĩa
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Câu hỏi thường gặp**

### Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/net/aspose.slides/notesslidemanager/) và một [property](https://reference.aspose.com/slides/vi/net/aspose.slides/notesslidemanager/notesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

### Có sự khác biệt nào về hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?

Thư viện nhắm tới một loạt rộng các định dạng Microsoft PowerPoint (97–mới hơn) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc có cài đặt PowerPoint hay không.