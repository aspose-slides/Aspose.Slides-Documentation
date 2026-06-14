---
title: Quản lý Ghi chú Bản trình chiếu trong C++
linktitle: Ghi chú Bản trình chiếu
type: docs
weight: 110
url: /vi/cpp/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú master
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình chiếu với Aspose.Slides cho C++. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bản trình chiếu. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình chiếu. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình chiếu.
- Xóa ghi chú khỏi tất cả các slide trong bản trình chiếu.

## **Xóa ghi chú khỏi một slide cụ thể**
Ghi chú của một slide cụ thể có thể được xóa như trong ví dụ bên dưới:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Xóa ghi chú khỏi tất cả các slide**
Ghi chú của tất cả các slide trong một bản trình chiếu có thể được xóa như trong ví dụ bên dưới:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Thêm kiểu ghi chú**
Thuộc tính NotesStyle đã được thêm vào giao diện IMasterNotesSlide và lớp MasterNotesSlide tương ứng. Thuộc tính này xác định kiểu cho văn bản ghi chú. Việc thực hiện được minh họa trong ví dụ dưới đây.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/notesslidemanager/) và một [phương thức](https://reference.aspose.com/slides/vi/cpp/aspose.slides/notesslidemanager/get_notesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 đến các phiên bản mới hơn) và ODP; ghi chú được hỗ trợ trong những định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.