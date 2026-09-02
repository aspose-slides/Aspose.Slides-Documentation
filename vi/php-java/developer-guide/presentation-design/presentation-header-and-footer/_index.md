---
title: Quản lý Tiêu đề và Chân trang của Bản trình chiếu trong PHP
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/php-java/presentation-header-and-footer/
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
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý các vị trí giữ chỗ chân trang, ngày‑giờ, số slide và tiêu đề trên slide, trang ghi chú và tài liệu phát tay với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

PowerPoint sử dụng các vị trí giữ chỗ tiêu đề và chân trang khác nhau tùy thuộc vào loại trang. Aspose.Slides cho PHP thông qua Java cho phép bạn kiểm soát văn bản và hiển thị của các vị trí này thông qua các lớp quản lý tiêu đề/chân trang.

Các vị trí giữ chỗ có sẵn phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mẫu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mẫu tài liệu | Có | Có | Có | Có |

Một slide trình chiếu thông thường không có vị trí giữ chỗ tiêu đề. Tiêu đề có sẵn trên các trang ghi chú và tài liệu. Đối với các slide thường, hãy sử dụng các vị trí giữ chỗ chân trang, ngày/giờ và số slide thay thế.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Lớp [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideheaderfootermanager/) điều khiển một slide thường. Lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslideheaderfootermanager/) điều khiển một slide ghi chú. Trình quản lý mẫu và bố cục cũng có thể truyền các cài đặt tới các slide phụ thuộc, trong khi lớp [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) điều khiển mẫu tài liệu.

## **Đặt Chân trang, Ngày/Giờ và Số Slide trên Slide Thường**

Đối với các slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của từng slide, đặt văn bản chân trang và ngày/giờ, bật các vị trí giữ chỗ cần thiết và lưu bản trình chiếu. Số slide được tạo ra bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`setFooterText`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) và [`setDateTimeText`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) để đặt văn bản, và sử dụng [`setFooterVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) và [`setSlideNumberVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) để hiển thị các vị trí giữ chỗ tương ứng.

Ví dụ toàn diện dưới đây áp dụng cùng một chân trang, văn bản ngày/giờ và hiển thị số slide cho tất cả các slide thường:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu bạn cần cập nhật chỉ một slide, hãy truy cập slide đó trực tiếp thông qua phương thức [`getSlides`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getslides/) thay vì duyệt qua toàn bộ bộ sưu tập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Ghi chú**

Mẫu ghi chú định nghĩa định dạng chung và hành vi vị trí giữ chỗ cho các trang ghi chú. Sử dụng lớp [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ mẫu ghi chú.

Ví dụ dưới đây đặt tiêu đề, chân trang và văn bản ngày/giờ trên mẫu ghi chú và làm cho tất cả các vị trí giữ chỗ được hỗ trợ hiển thị trên mẫu đó:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Phương thức [`getMasterNotesSlide`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) trả về `null` khi bản trình chiếu không chứa mẫu ghi chú.

## **Áp dụng Cài đặt Mẫu Ghi chú cho Các Slide Ghi chú Con**

Mẫu ghi chú có thể áp dụng các cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương thức truyền đạt chuyên dụng trên [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ cây ghi chú.

Ví dụ, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) và [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) cập nhật tiêu đề mẫu ghi chú và tất cả tiêu đề con. Các phương thức tương đương cũng có cho chân trang, ngày/giờ và số slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các phương thức truyền đạt được sử dụng ở trên là [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), và [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Đặt Tiêu đề và Chân trang trên Slide Ghi chú Cá nhân**

Slide ghi chú thuộc về một slide thường cụ thể. Sử dụng lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương thức [`addNotesSlide`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslidemanager/addnotesslide/) trả về slide ghi chú cho slide hiện tại và tạo một slide nếu chưa tồn tại. Ví dụ dưới đây cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu bạn đầu tiên truyền các cài đặt từ mẫu ghi chú và sau đó thay đổi một slide ghi chú cá nhân, các cài đặt riêng lẻ cho từng slide sẽ cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Tài liệu**

Các trang tài liệu sử dụng mẫu tài liệu cho các vị trí giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Không giống như các trang ghi chú, cài đặt tài liệu được quản lý thông qua mẫu tài liệu thay vì qua các slide tài liệu riêng lẻ.

Sử dụng phương thức [`getMasterHandoutSlide`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) để truy cập mẫu tài liệu. Nếu không có, gọi [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) để tạo mẫu tài liệu mặc định.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hiểu Phạm vi và Kế thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslideheaderfootermanager/) điều khiển một slide bố cục và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslideheaderfootermanager/) điều khiển mẫu slide thường và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslideheaderfootermanager/) điều khiển mẫu ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ vị trí giữ chỗ tiêu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) thay đổi mẫu tài liệu và hỗ trợ tất cả bốn loại vị trí giữ chỗ.

Sử dụng việc truyền từ một mẫu hoặc bố cục khi cùng một cài đặt cần áp dụng trên toàn bộ cây của nó. Sử dụng trình quản lý slide riêng lẻ hoặc slide‑ghi‑chú khi bạn cần một cài đặt cục bộ cho một trang.

## **FAQ**

**Tôi có thể thêm tiêu đề vào slide thường không?**

Không. PowerPoint không định nghĩa vị trí giữ chỗ tiêu đề cho slide thường. Trên slide thường, sử dụng các vị trí giữ chỗ chân trang, ngày/giờ và số slide. Vị trí giữ chỗ tiêu đề có sẵn trên các trang ghi chú và tài liệu.

**Nếu vị trí giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`isFooterVisible`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) báo cáo liệu vị trí giữ chỗ chân trang có tồn tại hay không, và [`setFooterVisibility`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) thay đổi khả năng hiển thị của nó.

**Làm thế nào để bắt đầu đánh số slide từ giá trị khác 1?**

Gọi phương thức [`setFirstSlideNumber`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/setfirstslidenumber/) của bản trình chiếu. Các vị trí giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã được cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất ra PDF, hình ảnh hoặc HTML?**

Các yếu tố tiêu đề và chân trang hiển thị sẽ được kết xuất cùng phần nội dung còn lại của bản trình chiếu trong định dạng đầu ra. Hiển thị của chúng phụ thuộc vào loại trang đang được xuất và các cài đặt khả năng hiển thị của vị trí giữ chỗ tương ứng.