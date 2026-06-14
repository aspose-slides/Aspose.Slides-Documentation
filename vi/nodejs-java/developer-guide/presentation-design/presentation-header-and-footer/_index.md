---
title: Quản lý đầu đề và chân trang cho bản trình bày bằng JavaScript
linktitle: Đầu đề & Chân trang
type: docs
weight: 140
url: /vi/nodejs-java/presentation-header-and-footer/
keywords:
- đầu đề
- văn bản đầu đề
- chân trang
- văn bản chân trang
- đặt đầu đề
- đặt chân trang
- tài liệu phát
- ghi chú
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng JavaScript và Aspose.Slides cho Node.js để thêm và tùy chỉnh đầu đề và chân trang trong các bản trình bày PowerPoint và OpenDocument, tạo giao diện chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý cài đặt đầu đề và chân trang trong các bản trình bày PowerPoint. Đầu đề và chân trang được xử lý ở mức master của bản trình bày, và API cung cấp các phương thức để đặt văn bản chân trang, thay đổi hiển thị của chân trang, và cập nhật văn bản đầu đề trên các slide ghi chú master.

Bạn cũng có thể quản lý đầu đề và chân trang cho các slide tài liệu phát và ghi chú. Điều này bao gồm việc thay đổi hiển thị và văn bản của các placeholder đầu đề, chân trang, số slide và ngày‑giờ cho master ghi chú, tất cả các slide ghi chú con, hoặc một slide ghi chú riêng lẻ.

## **Quản lý Đầu đề và Chân trang trong Bản trình bày**
Ghi chú của một số slide cụ thể có thể bị xóa như đã minh họa trong ví dụ dưới đây:

```javascript
// Tải bản trình bày
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Đặt chân trang
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Truy cập và cập nhật đầu đề
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Lưu bản trình bày
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Quản lý Đầu đề và Chân trang trong Slide Tài liệu phát và Ghi chú**
Aspose.Slides cho Node.js thông qua Java hỗ trợ Đầu đề và Chân trang trong các slide Tài liệu phát và Ghi chú. Vui lòng thực hiện các bước sau:

- Tải một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa video.
- Thay đổi cài đặt Đầu đề và Chân trang cho master ghi chú và tất cả các slide ghi chú.
- Đặt các placeholder Chân trang của slide ghi chú master và tất cả các slide con hiển thị.
- Đặt các placeholder Ngày và giờ của slide ghi chú master và tất cả các slide con hiển thị.
- Thay đổi cài đặt Đầu đề và Chân trang chỉ cho slide ghi chú đầu tiên.
- Đặt placeholder Đầu đề của slide ghi chú hiển thị.
- Đặt văn bản cho placeholder Đầu đề của slide ghi chú.
- Đặt văn bản cho placeholder Ngày‑giờ của slide ghi chú.
- Ghi tệp bản trình bày đã sửa đổi.

Đoạn mã mẫu được cung cấp trong ví dụ dưới đây.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Thay đổi cài đặt Đầu đề và Chân trang cho master ghi chú và tất cả các slide ghi chú
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// làm cho slide ghi chú master và tất cả các placeholder Footer con hiển thị
        headerFooterManager.setFooterAndChildFootersVisibility(true);// làm cho slide ghi chú master và tất cả các placeholder Header con hiển thị
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// làm cho slide ghi chú master và tất cả các placeholder SlideNumber con hiển thị
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// làm cho slide ghi chú master và tất cả các placeholder Ngày và giờ con hiển thị
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// đặt văn bản cho slide ghi chú master và tất cả các placeholder Header con
        headerFooterManager.setFooterAndChildFootersText("Footer text");// đặt văn bản cho slide ghi chú master và tất cả các placeholder Footer con
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// đặt văn bản cho slide ghi chú master và tất cả các placeholder Ngày và giờ con
    }
    // Thay đổi cài đặt Đầu đề và Chân trang chỉ cho slide ghi chú đầu tiên
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// làm cho placeholder Header của slide ghi chú này hiển thị
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// làm cho placeholder Footer của slide ghi chú này hiển thị
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// làm cho placeholder SlideNumber của slide ghi chú này hiển thị
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// làm cho placeholder Date-time của slide ghi chú này hiển thị
        headerFooterManager.setHeaderText("New header text");// đặt văn bản cho placeholder Header của slide ghi chú
        headerFooterManager.setFooterText("New footer text");// đặt văn bản cho placeholder Footer của slide ghi chú
        headerFooterManager.setDateTimeText("New date and time text");// đặt văn bản cho placeholder Date-time của slide ghi chú
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Có thể thêm "header" vào các slide thông thường không?**

Trong PowerPoint, "Header" chỉ tồn tại cho ghi chú và tài liệu phát; trên các slide thông thường, các thành phần được hỗ trợ là chân trang, ngày/giờ và số slide. Trong Aspose.Slides điều này cũng giống nhau: header chỉ dành cho Notes/Handout, và trên slide—Footer/DateTime/SlideNumber.

**Nếu bố cục không có khu vực chân trang—tôi có thể "bật" chế độ hiển thị không?**

Có. Kiểm tra trạng thái hiển thị thông qua trình quản lý header/footer và bật nó lên nếu cần. Các chỉ báo và phương thức API này được thiết kế cho trường hợp placeholder bị thiếu hoặc ẩn.

**Làm sao để số slide bắt đầu từ một giá trị khác 1?**

Đặt [first slide number](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) của bản trình bày; sau đó, tất cả các số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Điều gì xảy ra với đầu đề/chân trang khi xuất sang PDF/hình ảnh/HTML?**

Chúng được hiển thị như các thành phần văn bản thông thường của bản trình bày. Nghĩa là, nếu các thành phần này hiển thị trên slide/trang ghi chú, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với phần nội dung còn lại.