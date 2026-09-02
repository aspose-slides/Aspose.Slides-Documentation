---
title: Quản lý tiêu đề và chân trang của bản trình chiếu trong JavaScript
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày-gio, số slide và tiêu đề trên slide, trang ghi chú và tài liệu phát tay với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy thuộc vào loại trang. Aspose.Slides cho Node.js thông qua Java cho phép bạn kiểm soát văn bản và khả năng hiển thị của các trình giữ chỗ này thông qua các lớp quản lý tiêu đề/chân trang.

Các trình giữ chỗ khả dụng phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mở đầu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mở đầu tài liệu phát tay | Có | Có | Có | Có |

Một slide trình chiếu thông thường không có trình giữ chỗ tiêu đề. Tiêu đề khả dụng trên các trang ghi chú và tài liệu phát tay. Đối với các slide thông thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide thay thế.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Lớp [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideheaderfootermanager/) kiểm soát một slide thường. Lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) kiểm soát một slide ghi chú. Các trình quản lý master và layout cũng có thể truyền các cài đặt tới các slide phụ thuộc, trong khi lớp [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) kiểm soát master tài liệu phát tay.

## **Đặt Chân trang, Ngày/Giờ và Số slide trên Slide Thông thường**

Đối với các slide thông thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của từng slide, đặt văn bản chân trang và ngày/giờ, bật các trình giữ chỗ cần thiết và lưu bản trình chiếu. Số slide được tạo tự động bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`setFooterText`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) và [`setDateTimeText`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) để đặt văn bản, và sử dụng [`setFooterVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) và [`setSlideNumberVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) để hiển thị các trình giữ chỗ tương ứng.

Ví dụ toàn diện sau áp dụng cùng một chân trang, văn bản ngày/giờ và khả năng hiển thị số slide cho tất cả các slide thông thường:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn chỉ cần cập nhật một slide, truy cập slide đó trực tiếp thông qua phương thức [`getSlides`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) thay vì duyệt qua toàn bộ bộ sưu tập.

## **Đặt Tiêu đề và Chân trang trên Mở đầu Ghi chú**

Mở đầu ghi chú định nghĩa định dạng chung và hành vi trình giữ chỗ cho các trang ghi chú. Sử dụng lớp [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ riêng mở đầu ghi chú.

Ví dụ sau đặt tiêu đề, chân trang và văn bản ngày/giờ trên mở đầu ghi chú và bật tất cả các trình giữ chỗ được hỗ trợ trên master đó:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức [`getMasterNotesSlide`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) trả về `null` khi bản trình chiếu không chứa mở đầu ghi chú.

## **Áp dụng Cài đặt Mở đầu Ghi chú cho Các Slide Ghi chú Con**

Một mở đầu ghi chú có thể áp dụng cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương thức truyền đạt chuyên biệt trên [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ hierarchy ghi chú.

Ví dụ, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) và [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) cập nhật tiêu đề master và tất cả các tiêu đề con. Các phương thức tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các phương thức truyền đạt được sử dụng ở trên là [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) và [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Đặt Tiêu đề và Chân trang trên Một Slide Ghi chú Cá nhân**

Một slide ghi chú thuộc về một slide thường cụ thể. Sử dụng lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương thức [`addNotesSlide`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) trả về slide ghi chú cho slide hiện tại và tạo mới nếu nó chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn trước tiên truyền đạt cài đặt từ mở đầu ghi chú và sau đó thay đổi một slide ghi chú cá nhân, các cài đặt theo slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu đề và Chân trang trên Mở đầu Tài liệu Phát tay**

Các trang tài liệu phát tay sử dụng mở đầu tài liệu phát tay cho các trình giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Khác với các trang ghi chú, cài đặt tài liệu phát tay được quản lý qua mở đầu tài liệu phát tay chứ không phải qua các slide tài liệu phát tay riêng lẻ.

Sử dụng [`getMasterHandoutSlide`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) để truy cập mở đầu tài liệu phát tay. Nếu không tồn tại, gọi [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) để tạo master tài liệu phát tay mặc định.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiểu Phạm vi và Kế thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) điều khiển một layout slide và có thể truyền các cài đặt hỗ trợ tới các slide phụ thuộc.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) điều khiển một master slide thường và có thể truyền các cài đặt hỗ trợ tới các slide phụ thuộc.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) điều khiển mở đầu ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ trình giữ chỗ tiêu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát tay và hỗ trợ cả bốn loại trình giữ chỗ.

Sử dụng truyền đạt từ một master hoặc layout khi cùng một cài đặt cần áp dụng xuyên suốt hierarchy của nó. Sử dụng một slide cá nhân hoặc trình quản lý slide‑ghi‑chú khi bạn cần cài đặt cục bộ cho một trang.

## **Câu hỏi thường gặp**

**Tôi có thể thêm tiêu đề vào một slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ tiêu đề cho slide thường. Trên slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ tiêu đề chỉ khả dụng trên các trang ghi chú và tài liệu phát tay.

**Nếu một trình giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`isFooterVisible`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) báo cáo xem có trình giữ chỗ chân trang hay không, và [`setFooterVisibility`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) thay đổi khả năng hiển thị của nó.

**Làm thế nào để bắt đầu đánh số slide từ một giá trị khác 1?**

Gọi phương thức [`setFirstSlideNumber`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) của bản trình chiếu. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất ra PDF, hình ảnh hoặc HTML?**

Các phần tử tiêu đề và chân trang hiển thị sẽ được vẽ cùng với phần còn lại của nội dung bản trình chiếu trong định dạng đầu ra. Ngoại hình của chúng phụ thuộc vào loại trang đang được xuất và các cài đặt khả năng hiển thị của trình giữ chỗ tương ứng.