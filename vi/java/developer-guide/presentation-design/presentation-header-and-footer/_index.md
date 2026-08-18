---
title: Quản lý Tiêu đề và Chân trang trong Java
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
- tài liệu phát
- ghi chú
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày‑giờ, số slide và tiêu đề trên các slide, trang ghi chú và tài liệu phát bằng Aspose.Slides cho Java."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy theo loại trang. Aspose.Slides cho Java cho phép bạn kiểm soát văn bản và khả năng hiển thị của các trình giữ chỗ này thông qua các giao diện quản lý tiêu đề/chân trang.

Các trình giữ chỗ khả dụng phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mẫu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mẫu tài liệu phát | Có | Có | Có | Có |

Slide trình chiếu thường không có trình giữ chỗ tiêu đề. Tiêu đề chỉ có trên các trang ghi chú và tài liệu phát. Đối với slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Giao diện [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideheaderfootermanager/) điều khiển một slide thường. Giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotesslideheaderfootermanager/) điều khiển một slide ghi chú. Các trình quản lý master và layout cũng có thể truyền cài đặt tới các slide phụ thuộc, trong khi giao diện [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) điều khiển master tài liệu phát.

## **Đặt Chân trang, Ngày/Giờ và Số slide trên Slide Thường**

Đối với slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của mỗi slide, đặt văn bản chân trang và ngày/giờ, kích hoạt các trình giữ chỗ cần thiết, và lưu bản trình chiếu. Số slide được tạo tự động bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`setFooterText`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) và [`setDateTimeText`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) để đặt văn bản, và sử dụng [`setFooterVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), và [`setSlideNumberVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) để hiển thị các trình giữ chỗ tương ứng.

Ví dụ toàn diện dưới đây áp dụng cùng một chân trang, văn bản ngày/giờ và khả năng hiển thị số slide cho tất cả các slide thường:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn chỉ cần cập nhật một slide, truy cập slide đó trực tiếp qua phương thức [`getSlides`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlides--) thay vì duyệt toàn bộ bộ sưu tập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Ghi chú**

Mẫu ghi chú định nghĩa định dạng chung và hành vi của các trình giữ chỗ cho các trang ghi chú. Sử dụng giao diện [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ riêng mẫu ghi chú.

Ví dụ sau đặt tiêu đề, chân trang và văn bản ngày/giờ trên mẫu ghi chú và làm cho tất cả các trình giữ chỗ được hỗ trợ hiển thị trên mẫu đó:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức [`getMasterNotesSlide`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) trả về `null` khi bản trình chiếu không chứa mẫu ghi chú.

## **Áp dụng Cài đặt Mẫu Ghi chú cho Các Slide Ghi chú Con**

Mẫu ghi chú có thể áp dụng cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương thức truyền đạt chuyên biệt trên [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ cấu trúc ghi chú.

Ví dụ, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) và [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) cập nhật tiêu đề mẫu ghi chú và mọi tiêu đề con. Các phương thức tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các phương thức truyền đạt được sử dụng ở trên là [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), và [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Đặt Tiêu đề và Chân trang trên Một Slide Ghi chú Cá nhân**

Một slide ghi chú thuộc về một slide thường cụ thể. Sử dụng giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ riêng trang ghi chú đó.

Phương thức [`addNotesSlide`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) trả về slide ghi chú cho slide hiện tại và tạo mới nếu chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn đầu tiên truyền cài đặt từ mẫu ghi chú rồi sau đó thay đổi một slide ghi chú cá nhân, các cài đặt per‑slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Tài liệu phát**

Các trang tài liệu phát sử dụng master tài liệu phát cho các trình giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Khác với các trang ghi chú, cài đặt tài liệu phát được quản lý thông qua master tài liệu phát thay vì qua các slide tài liệu phát riêng lẻ.

Sử dụng phương thức [`getMasterHandoutSlide`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) để truy cập master tài liệu phát. Nếu không tồn tại, gọi [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) để tạo master tài liệu phát mặc định.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiểu Phạm vi và Kế thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslideheaderfootermanager/) điều khiển một slide layout và có thể truyền cài đặt hỗ trợ tới các slide phụ thuộc.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslideheaderfootermanager/) điều khiển một master slide thường và có thể truyền cài đặt hỗ trợ tới các slide phụ thuộc.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) điều khiển master ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ một trình giữ chỗ tiêu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát và hỗ trợ cả bốn loại trình giữ chỗ.

Sử dụng truyền đạt từ một master hoặc layout khi cùng một cài đặt cần áp dụng trên toàn bộ hierarchy của nó. Sử dụng trình quản lý slide cá nhân hoặc notes‑slide khi bạn cần một cài đặt cục bộ cho một trang duy nhất.

## **FAQ**

**Tôi có thể thêm tiêu đề vào slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ tiêu đề cho các slide thường. Trên các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ tiêu đề chỉ có trên các trang ghi chú và tài liệu phát.

**Nếu trình giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`isFooterVisible`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) báo cáo liệu một trình giữ chỗ chân trang có tồn tại hay không, và [`setFooterVisibility`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) thay đổi khả năng hiển thị của nó.

**Làm thế nào để bắt đầu đánh số slide từ giá trị khác 1?**

Gọi phương thức [`setFirstSlideNumber`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bản trình chiếu. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất sang PDF, hình ảnh hoặc HTML?**

Các yếu tố tiêu đề và chân trang hiển thị sẽ được vẽ cùng với phần còn lại của nội dung trình chiếu trong định dạng đầu ra. Hiển thị của chúng phụ thuộc vào loại trang đang được xuất và cài đặt hiển thị trình giữ chỗ tương ứng.