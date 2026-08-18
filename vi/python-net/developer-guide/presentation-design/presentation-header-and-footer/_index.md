---
title: Quản lý tiêu đề và chân trang cho bài thuyết trình bằng Python
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/python-net/presentation-header-and-footer/
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày giờ, số slide và tiêu đề trên slide, trang ghi chú và tài liệu phát tay với Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy thuộc vào loại trang. Aspose.Slides cho Python thông qua .NET cho phép bạn kiểm soát văn bản và khả năng hiển thị của các trình giữ chỗ này thông qua các lớp quản lý tiêu đề/chân trang.

Các trình giữ chỗ có sẵn phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mẫu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mẫu tài liệu phát tay | Có | Có | Có | Có |

Slide trình chiếu thường không có trình giữ chỗ tiêu đề. Tiêu đề có sẵn trên các trang ghi chú và tài liệu phát tay. Đối với các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide thay thế.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Lớp [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slideheaderfootermanager/) kiểm soát một slide thường. Lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslideheaderfootermanager/) kiểm soát một slide ghi chú. Các trình quản lý master và layout cũng có thể truyền các thiết lập tới các slide phụ thuộc, trong khi lớp [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) kiểm soát master tài liệu phát tay.

## **Đặt Chân trang, Ngày/Giờ và Số slide trên Slide Thường**

Đối với các slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của mỗi slide, đặt văn bản chân trang và ngày/giờ, bật các trình giữ chỗ cần thiết, và lưu bản trình chiếu. Số slide được tạo tự động bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`set_footer_text`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) và [`set_date_time_text`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) để đặt văn bản, và sử dụng [`set_footer_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), và [`set_slide_number_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) để hiển thị các trình giữ chỗ tương ứng.

Ví dụ toàn diện dưới đây áp dụng cùng một chân trang, văn bản ngày/giờ và khả năng hiển thị số slide cho tất cả các slide thường:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn chỉ cần cập nhật một slide, hãy truy cập trực tiếp slide đó thông qua bộ sưu tập [`slides`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) thay vì lặp qua toàn bộ bộ sưu tập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Ghi chú**

Mẫu ghi chú xác định định dạng chung và hành vi của các trình giữ chỗ cho các trang ghi chú. Sử dụng lớp [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ mẫu ghi chú.

Ví dụ sau đặt tiêu đề, chân trang và văn bản ngày/giờ trên mẫu ghi chú và làm cho tất cả các trình giữ chỗ được hỗ trợ hiển thị trên mẫu đó:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Một bản trình chiếu có thể không chứa mẫu ghi chú, vì vậy hãy kiểm tra giá trị trả về có phải `None` trước khi thay đổi.

## **Áp dụng Cài đặt Mẫu Ghi chú cho Các Slide Ghi chú Con**

Mẫu ghi chú có thể áp dụng các cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương pháp truyền cụ thể trên [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/) khi các cài đặt giống nhau cần được áp dụng trên toàn bộ hệ thống ghi chú.

Ví dụ, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) và [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) cập nhật tiêu đề mẫu ghi chú và tất cả các tiêu đề con. Các phương pháp tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Các phương pháp truyền được sử dụng ở trên là [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), và [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Đặt Tiêu đề và Chân trang trên Slide Ghi chú Cá nhân**

Một slide ghi chú thuộc về một slide thường cụ thể. Sử dụng lớp [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương pháp [`add_notes_slide`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslidemanager/add_notes_slide/) trả về slide ghi chú cho slide hiện tại và tạo mới nếu chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn đầu tiên truyền các cài đặt từ mẫu ghi chú và sau đó thay đổi một slide ghi chú cá nhân, các cài đặt riêng cho mỗi slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu đề và Chân trang trên Mẫu Tài liệu Phát tay**

Các trang tài liệu phát tay sử dụng master tài liệu phát tay cho các trình giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Không giống như các trang ghi chú, cài đặt tài liệu phát tay được quản lý thông qua master tài liệu phát tay thay vì từng slide cá nhân.

Sử dụng thuộc tính [`master_handout_slide`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) để truy cập master tài liệu phát tay. Nếu nó không tồn tại, gọi [`set_default_master_handout_slide`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) để tạo master tài liệu phát tay mặc định.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiểu Phạm vi và Kế thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slideheaderfootermanager/) thay đổi các cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslideheaderfootermanager/) kiểm soát một slide layout và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslideheaderfootermanager/) kiểm soát một master slide thường và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/) kiểm soát mẫu ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ trình giữ chỗ tiêu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát tay và hỗ trợ tất cả bốn loại trình giữ chỗ.

Sử dụng truyền từ một master hoặc layout khi cùng một cài đặt cần áp dụng xuyên suốt cấu trúc của nó. Sử dụng một slide cá nhân hoặc trình quản lý notes-slide khi bạn cần một cài đặt cục bộ cho một trang.

## **Câu hỏi thường gặp**

**Tôi có thể thêm tiêu đề vào slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ tiêu đề cho slide thường. Trên các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ tiêu đề chỉ khả dụng trên các trang ghi chú và tài liệu phát tay.

**Nếu trình giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`is_footer_visible`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) báo cáo liệu trình giữ chỗ chân trang có tồn tại hay không, và [`set_footer_visibility`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) thay đổi khả năng hiển thị của nó.

**Làm sao để bắt đầu đánh số slide từ giá trị khác 1?**

Đặt thuộc tính [`first_slide_number`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/first_slide_number/) của bản trình chiếu. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi số đã cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất ra PDF, hình ảnh hoặc HTML?**

Các yếu tố tiêu đề và chân trang hiển thị sẽ được vẽ cùng với phần còn lại của nội dung bản trình chiếu trong định dạng đầu ra. Sự xuất hiện của chúng phụ thuộc vào loại trang đang được xuất và các cài đặt khả năng hiển thị của trình giữ chỗ tương ứng.