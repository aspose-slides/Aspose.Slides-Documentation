---
title: Quản lý Tiêu đề và Chân trang Bản trình chiếu trong Java
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/java/presentation-header-and-footer/
keywords:
- tiêu đề
- văn bản tiêu đề
- chân trang
- văn bản chân trang
- đặt tiêu đề
- đặt chân trang
- tài liệu phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Java để thêm và tùy chỉnh tiêu đề và chân trang trong các bản trình chiếu PowerPoint và OpenDocument, mang lại giao diện chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các cài đặt tiêu đề và chân trang trong bản trình chiếu PowerPoint. Tiêu đề và chân trang được xử lý ở cấp độ master của bản trình chiếu và API cung cấp các phương thức để đặt văn bản chân trang, thay đổi hiển thị chân trang và cập nhật văn bản tiêu đề trên các slide ghi chú master.

Bạn cũng có thể quản lý tiêu đề và chân trang cho các slide tài liệu phát tay và ghi chú. Điều này bao gồm việc thay đổi hiển thị và văn bản của các placeholder tiêu đề, chân trang, số slide và ngày‑giờ cho notes master, tất cả các slide ghi chú con, hoặc một slide ghi chú riêng lẻ.

## **Quản lý Tiêu đề và Chân trang trong Bản trình chiếu**
Ghi chú của một số slide cụ thể có thể được xóa như được minh họa trong ví dụ dưới đây:

```java
// Tải bản trình chiếu
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Đặt chân trang
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Truy cập và cập nhật tiêu đề
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Lưu bản trình chiếu
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Phương thức để đặt văn bản Tiêu đề/Chân trang
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Quản lý Tiêu đề và Chân trang trên Slide Tài liệu Phát tay và Ghi chú**
Aspose.Slides for Java hỗ trợ Tiêu đề và Chân trang trong slide Tài liệu phát tay và ghi chú. Vui lòng thực hiện các bước sau:

- Tải một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) có chứa video.
- Thay đổi cài đặt Tiêu đề và Chân trang cho notes master và tất cả các slide ghi chú.
- Đặt các placeholder Chân trang của master notes slide và tất cả các placeholder con hiển thị.
- Đặt các placeholder Ngày và Giờ của master notes slide và tất cả các placeholder con hiển thị.
- Thay đổi cài đặt Tiêu đề và Chân trang chỉ cho slide ghi chú đầu tiên.
- Đặt placeholder Tiêu đề của slide ghi chú hiển thị.
- Đặt văn bản cho placeholder Tiêu đề của slide ghi chú.
- Đặt văn bản cho placeholder Ngày‑giờ của slide ghi chú.
- Ghi file bản trình chiếu đã sửa đổi.

Đoạn mã mẫu được cung cấp trong ví dụ dưới đây.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Thay đổi cài đặt Tiêu đề và Chân trang cho master ghi chú và tất cả các slide ghi chú
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // hiển thị master notes slide và tất cả các placeholder Footer con
        headerFooterManager.setFooterAndChildFootersVisibility(true); // hiển thị master notes slide và tất cả các placeholder Header con
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // hiển thị master notes slide và tất cả các placeholder SlideNumber con
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // hiển thị master notes slide và tất cả các placeholder Ngày và giờ con

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // đặt văn bản cho master notes slide và tất cả các placeholder Header con
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // đặt văn bản cho master notes slide và tất cả các placeholder Footer con
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // đặt văn bản cho master notes slide và tất cả các placeholder Ngày và giờ con
    }

    // Thay đổi cài đặt Tiêu đề và Chân trang chỉ cho slide ghi chú đầu tiên
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // hiển thị placeholder Header của slide ghi chú này

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // hiển thị placeholder Footer của slide ghi chú này

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // hiển thị placeholder SlideNumber của slide ghi chú này

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // hiển thị placeholder Ngày-giờ của slide ghi chú này

        headerFooterManager.setHeaderText("New header text"); // đặt văn bản cho placeholder Header của slide ghi chú
        headerFooterManager.setFooterText("New footer text"); // đặt văn bản cho placeholder Footer của slide ghi chú
        headerFooterManager.setDateTimeText("New date and time text"); // đặt văn bản cho placeholder Ngày-giờ của slide ghi chú
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể thêm “header” vào các slide thường không?**

Trong PowerPoint, “Header” chỉ tồn tại cho ghi chú và tài liệu phát tay; trên các slide thường, các thành phần được hỗ trợ là chân trang, ngày/giờ và số slide. Trong Aspose.Slides, điều này tương tự: header chỉ dành cho Notes/Handout, và trên slide—Footer/DateTime/SlideNumber.

**Nếu bố cục không chứa khu vực chân trang — tôi có thể “bật” hiển thị của nó không?**

Có. Kiểm tra trạng thái hiển thị thông qua trình quản lý header/footer và bật nó nếu cần. Các chỉ báo và phương thức API này được thiết kế cho các trường hợp placeholder bị thiếu hoặc ẩn.

**Làm thế nào để đặt số slide bắt đầu từ giá trị khác 1?**

Đặt [số slide đầu tiên](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bản trình chiếu; sau đó, toàn bộ đánh số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Điều gì xảy ra với tiêu đề/chân trang khi xuất ra PDF/hình ảnh/HTML?**

Chúng được hiển thị như các yếu tố văn bản thông thường của bản trình chiếu. Nghĩa là, nếu các yếu tố này hiển thị trên các slide/trang ghi chú, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với các nội dung còn lại.