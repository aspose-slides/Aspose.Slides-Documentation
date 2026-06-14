---
title: Quản lý tiêu đề và chân trang cho bản trình chiếu trên Android
linktitle: Tiêu đề & Chân trang
type: docs
weight: 140
url: /vi/androidjava/presentation-header-and-footer/
keywords:
- tiêu đề
- văn bản tiêu đề
- chân trang
- văn bản chân trang
- đặt tiêu đề
- đặt chân trang
- bản sao
- ghi chú
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Android qua Java để thêm và tùy chỉnh tiêu đề và chân trang trong các bản trình chiếu PowerPoint và OpenDocument, tạo vẻ chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các cài đặt tiêu đề và chân trang trong bản trình bày PowerPoint. Tiêu đề và chân trang được xử lý ở mức master của bản trình bày, và API cung cấp các phương thức để đặt văn bản chân trang, thay đổi trạng thái hiển thị của chân trang, và cập nhật văn bản tiêu đề trên các slide ghi chú master.

Bạn cũng có thể quản lý tiêu đề và chân trang cho các slide bản sao và ghi chú. Điều này bao gồm việc thay đổi trạng thái hiển thị và văn bản của các placeholder tiêu đề, chân trang, số slide và ngày‑giờ cho notes master, tất cả các slide ghi chú con, hoặc một slide ghi chú riêng lẻ.

## **Quản lý tiêu đề và chân trang trong một bản trình bày**

Ghi chú của một số slide cụ thể có thể bị xóa như được minh họa trong ví dụ dưới đây:

```java
// Tải bản trình chiếu
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Đặt chân trang
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Truy cập và Cập nhật tiêu đề
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
// Phương thức để đặt Văn bản Header/Footer
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

## **Quản lý tiêu đề và chân trang trên các slide bản sao và ghi chú**

Aspose.Slides cho Android via Java hỗ trợ Tiêu đề và Chân trang trong các slide bản sao và ghi chú. Vui lòng thực hiện các bước sau:

- Tải một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa video.
- Thay đổi cài đặt Tiêu đề và Chân trang cho notes master và tất cả các slide ghi chú.
- Đặt các placeholder Chân trang của master notes slide và tất cả các placeholder con hiển thị.
- Đặt các placeholder Ngày và giờ của master notes slide và tất cả các placeholder con hiển thị.
- Thay đổi cài đặt Tiêu đề và Chân trang chỉ cho slide ghi chú đầu tiên.
- Đặt placeholder Tiêu đề của slide ghi chú hiển thị.
- Đặt văn bản cho placeholder Tiêu đề của slide ghi chú.
- Đặt văn bản cho placeholder Ngày‑giờ của slide ghi chú.
- Ghi file bản trình bày đã sửa đổi.

Đoạn mã mẫu được cung cấp trong ví dụ dưới đây.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Thay đổi cài đặt Header và Footer cho notes master và tất cả các notes slide
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // làm cho master notes slide và tất cả các placeholder Footer con hiển thị
        headerFooterManager.setFooterAndChildFootersVisibility(true); // làm cho master notes slide và tất cả các placeholder Header con hiển thị
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // làm cho master notes slide và tất cả các placeholder SlideNumber con hiển thị
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // làm cho master notes slide và tất cả các placeholder Date và time con hiển thị

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // đặt văn bản cho master notes slide và tất cả các placeholder Header con
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // đặt văn bản cho master notes slide và tất cả các placeholder Footer con
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // đặt văn bản cho master notes slide và tất cả các placeholder Date và time con
    }

    // Thay đổi cài đặt Header và Footer chỉ cho notes slide đầu tiên
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // làm cho placeholder Header của notes slide này hiển thị

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // làm cho placeholder Footer của notes slide này hiển thị

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // làm cho placeholder SlideNumber của notes slide này hiển thị

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // làm cho placeholder Date-time của notes slide này hiển thị

        headerFooterManager.setHeaderText("New header text"); // đặt văn bản cho placeholder Header của notes slide
        headerFooterManager.setFooterText("New footer text"); // đặt văn bản cho placeholder Footer của notes slide
        headerFooterManager.setDateTimeText("New date and time text"); // đặt văn bản cho placeholder Date-time của notes slide
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể thêm "header" vào các slide thông thường không?**

Trong PowerPoint, "Header" chỉ tồn tại cho ghi chú và bản sao; trên các slide thông thường, các yếu tố được hỗ trợ là chân trang, ngày/giờ và số slide. Trong Aspose.Slides cũng có cùng giới hạn này: header chỉ dành cho Notes/Handout, và trên các slide—Footer/DateTime/SlideNumber.

**Nếu bố cục không có khu vực chân trang—tôi có thể "bật" hiển thị nó không?**

Có. Kiểm tra trạng thái hiển thị qua trình quản lý header/footer và bật lên nếu cần. Các chỉ báo và phương thức API này được thiết kế cho các trường hợp placeholder bị thiếu hoặc ẩn.

**Làm thế nào để số slide bắt đầu từ giá trị khác 1?**

Đặt [số slide đầu tiên](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bản trình bày; sau đó, toàn bộ đánh số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Điều gì xảy ra với tiêu đề/chân trang khi xuất sang PDF/hình ảnh/HTML?**

Chúng được render dưới dạng các yếu tố văn bản thông thường của bản trình bày. Nghĩa là, nếu các yếu tố này hiển thị trên các slide/trang ghi chú, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với phần nội dung còn lại.