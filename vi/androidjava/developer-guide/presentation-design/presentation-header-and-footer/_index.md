---
title: Quản lý tiêu đề và chân trang cho bản trình chiếu trên Android
linktitle: Tiêu đề và Chân trang
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
- tài liệu phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày‑giờ, số slide và tiêu đề trên slide, trang ghi chú và tài liệu phát tay với Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy theo loại trang. Aspose.Slides for Android via Java cho phép bạn kiểm soát văn bản và khả năng hiển thị của các trình giữ chỗ này thông qua các giao diện quản lý tiêu đề/chân trang.

Các trình giữ chỗ khả dụng phụ thuộc vào phạm vi:

| Phạm vi | Đầu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Master ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Master tài liệu phát tay | Có | Có | Có | Có |

Một slide trình chiếu thông thường không có trình giữ chỗ đầu đề. Đầu đề chỉ có trên các trang ghi chú và tài liệu phát tay. Đối với slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide thay thế.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Giao diện [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideheaderfootermanager/) điều khiển một slide thường. Giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) điều khiển một slide ghi chú. Các trình quản lý master và layout cũng có thể truyền các cài đặt tới các slide phụ thuộc, trong khi giao diện [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) điều khiển master tài liệu phát tay.

## **Đặt Chân trang, Ngày/Giờ và Số Slide trên Các Slide Thường**

Đối với các slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của mỗi slide, đặt văn bản chân trang và ngày/giờ, bật các trình giữ chỗ cần thiết, và lưu bản trình chiếu. Số slide được tạo tự động bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`setFooterText`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) và [`setDateTimeText`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) để đặt văn bản, và sử dụng [`setFooterVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), và [`setSlideNumberVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) để hiển thị các trình giữ chỗ tương ứng.

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

Nếu bạn chỉ cần cập nhật một slide, hãy truy cập trực tiếp slide đó thông qua phương thức [`getSlides`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--) thay vì lặp qua toàn bộ bộ sưu tập.

## **Đặt Đầu đề và Chân trang trên Master Ghi chú**

Master ghi chú định nghĩa định dạng chung và hành vi của các trình giữ chỗ trên các trang ghi chú. Sử dụng giao diện [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ riêng master ghi chú.

Ví dụ sau đặt đầu đề, chân trang và văn bản ngày/giờ trên master ghi chú và làm cho tất cả các trình giữ chỗ được hỗ trợ hiển thị trên master đó:

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

Phương thức [`getMasterNotesSlide`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) trả về `null` khi bản trình chiếu không chứa master ghi chú.

## **Áp dụng Cài đặt Master Ghi chú cho Các Slide Ghi chú Con**

Master ghi chú có thể áp dụng cài đặt đầu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương pháp truyền đạt riêng trên [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ cấu trúc ghi chú.

Ví dụ, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) và [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) cập nhật đầu đề master và mọi đầu đề con. Các phương pháp tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

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

Các phương pháp truyền đạt được sử dụng ở trên là [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), và [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Đặt Đầu đề và Chân trang trên Một Slide Ghi chú Riêng lẻ**

Một slide ghi chú thuộc về một slide thường cụ thể. Sử dụng giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương thức [`addNotesSlide`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) trả về slide ghi chú cho slide hiện tại và tạo mới nếu chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

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

Nếu bạn đầu tiên truyền các cài đặt từ master ghi chú rồi sau đó thay đổi một slide ghi chú riêng lẻ, các cài đặt theo slide sau sẽ cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Đầu đề và Chân trang trên Master Tài liệu Phát tay**

Các trang tài liệu phát tay sử dụng master tài liệu phát tay cho các trình giữ chỗ đầu đề, chân trang, ngày/giờ và số trang. Khác với các trang ghi chú, cài đặt tài liệu phát tay được quản lý qua master tài liệu phát tay chứ không phải qua các slide tài liệu phát tay riêng lẻ.

Sử dụng phương thức [`getMasterHandoutSlide`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) để truy cập master tài liệu phát tay. Nếu không tồn tại, gọi [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) để tạo master tài liệu phát tay mặc định.

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

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) điều khiển một slide layout và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) điều khiển một master slide thông thường và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) điều khiển master ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ trình giữ chỗ đầu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát tay và hỗ trợ tất cả bốn loại trình giữ chỗ.

Sử dụng việc truyền từ master hoặc layout khi cùng một cài đặt cần áp dụng xuyên suốt cây cấu trúc. Sử dụng một slide riêng lẻ hoặc trình quản lý slide‑ghi chú khi bạn cần cài đặt cục bộ cho một trang.

## **Câu hỏi thường gặp**

**Tôi có thể thêm đầu đề vào slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ đầu đề cho các slide thường. Trên các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ đầu đề chỉ khả dụng trên các trang ghi chú và tài liệu phát tay.

**Nếu trình giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`isFooterVisible`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) báo cáo liệu có tồn tại trình giữ chỗ chân trang hay không, và [`setFooterVisibility`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) thay đổi khả năng hiển thị của nó.

**Làm sao để bắt đầu đánh số slide từ giá trị khác 1?**

Gọi phương thức [`setFirstSlideNumber`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bản trình chiếu. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã được cập nhật.

**Các đầu đề và chân trang sẽ như thế nào khi xuất ra PDF, hình ảnh hoặc HTML?**

Các phần tử đầu đề và chân trang hiển thị sẽ được vẽ cùng với phần nội dung còn lại của bản trình chiếu trong định dạng đầu ra. Ngoại hình của chúng phụ thuộc vào loại trang đang được xuất và các cài đặt khả năng hiển thị của trình giữ chỗ tương ứng.