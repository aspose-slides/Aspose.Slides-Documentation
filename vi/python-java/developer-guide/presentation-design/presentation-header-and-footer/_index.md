---
title: Quản lý tiêu đề và chân trang bản trình chiếu trong Python qua Java
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/python-java/presentation-header-and-footer/
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
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các trình giữ chỗ chân trang, ngày-giờ, số slide và tiêu đề trên các slide, trang ghi chú và tài liệu phát tay bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

PowerPoint sử dụng các trình giữ chỗ tiêu đề và chân trang khác nhau tùy thuộc vào loại trang. Aspose.Slides for Python via Java cho phép bạn kiểm soát văn bản và khả năng hiển thị của các trình giữ chỗ này thông qua các lớp quản lý tiêu đề/chân trang.

Các trình giữ chỗ có sẵn phụ thuộc vào phạm vi:

| Phạm vi | Tiêu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thường | Không | Có | Có | Có |
| Mẫu ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Mẫu tài liệu | Có | Có | Có | Có |

Slide trình chiếu thường không có trình giữ chỗ tiêu đề. Tiêu đề có sẵn trên các trang ghi chú và tài liệu. Đối với các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide thay thế.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. The [SlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideheaderfootermanager/) class controls one regular slide. The [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslideheaderfootermanager/) class controls one notes slide. Master and layout managers can also propagate settings to dependent slides, while the [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) class controls the handout master.

## **Đặt Chân Trang, Ngày/Giờ và Số Slide trên Các Slide Thường**

Đối với các slide thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của mỗi slide, đặt văn bản chân trang và ngày/giờ, bật các trình giữ chỗ cần thiết, và lưu bản trình chiếu. Số slide được tạo ra bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [setFooterText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) và [setDateTimeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) để đặt văn bản, và sử dụng [setFooterVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), và [setSlideNumberVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) để hiển thị các trình giữ chỗ tương ứng.

Ví dụ toàn diện dưới đây áp dụng cùng một chân trang, văn bản ngày/giờ và khả năng hiển thị số slide cho tất cả các slide thường:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu bạn chỉ cần cập nhật một slide, truy cập slide đó trực tiếp qua phương thức [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) thay vì lặp qua toàn bộ bộ sưu tập.

## **Đặt Tiêu Đề và Chân Trang trên Mẫu Ghi Chú**

Mẫu ghi chú xác định định dạng chung và hành vi của trình giữ chỗ cho các trang ghi chú. Sử dụng lớp [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/) khi bạn muốn chỉ thay đổi mẫu ghi chú.

Ví dụ sau đặt tiêu đề, chân trang và văn bản ngày/giờ trên mẫu ghi chú và làm cho tất cả các trình giữ chỗ được hỗ trợ hiển thị trên mẫu đó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phương thức `getMasterNotesSlide` trả về `None` khi bản trình chiếu không chứa mẫu ghi chú.

## **Áp Dụng Cài Đặt Mẫu Ghi Chú cho Các Slide Ghi Chú Con**

Mẫu ghi chú có thể áp dụng cài đặt tiêu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương thức lan truyền chuyên biệt trên [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/) khi các cài đặt giống nhau cần được áp dụng trên toàn bộ cấu trúc ghi chú.

Ví dụ, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) và [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) cập nhật tiêu đề mẫu ghi chú và tất cả tiêu đề con. Các phương thức tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các phương thức lan truyền được sử dụng ở trên là [setFooterAndChildFootersText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), và [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Đặt Tiêu Đề và Chân Trang trên Một Slide Ghi Chú Riêng Lẻ**

Slide ghi chú thuộc về một slide thường cụ thể. Sử dụng lớp [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương thức [addNotesSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslidemanager/#addNotesSlide) trả về slide ghi chú cho slide hiện tại và tạo một slide nếu nó chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu bạn đầu tiên lan truyền cài đặt từ mẫu ghi chú rồi sau đó thay đổi một slide ghi chú riêng lẻ, các cài đặt theo slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt Tiêu Đề và Chân Trang trên Mẫu Tài Liệu**

Các trang tài liệu sử dụng mẫu tài liệu cho các trình giữ chỗ tiêu đề, chân trang, ngày/giờ và số trang. Không giống như các trang ghi chú, cài đặt tài liệu được quản lý thông qua mẫu tài liệu thay vì qua các slide tài liệu riêng lẻ.

Sử dụng phương thức `getMasterHandoutSlide` để truy cập mẫu tài liệu. Nếu không có, gọi `setDefaultMasterHandoutSlide` để tạo mẫu tài liệu mặc định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hiểu Phạm Vi và Kế Thừa**

Chọn trình quản lý tiêu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thường.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslideheaderfootermanager/) kiểm soát một slide bố trí và có thể lan truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslideheaderfootermanager/) kiểm soát một mẫu slide thường và có thể lan truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslideheaderfootermanager/) kiểm soát mẫu ghi chú và có thể lan truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ trình giữ chỗ tiêu đề ngoài chân trang, ngày/giờ và số slide.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) thay đổi mẫu tài liệu và hỗ trợ cả bốn loại trình giữ chỗ.

Sử dụng lan truyền từ một mẫu hoặc bố trí khi cùng một cài đặt cần được áp dụng trên toàn bộ cấu trúc của nó. Sử dụng một slide riêng lẻ hoặc trình quản lý slide‑ghi chú khi bạn cần một cài đặt cục bộ cho một trang.

## **Câu Hỏi Thường Gặp**

**Có thể thêm tiêu đề vào slide thường không?**

Không. PowerPoint không định nghĩa trình giữ chỗ tiêu đề cho các slide thường. Trên các slide thường, hãy sử dụng các trình giữ chỗ chân trang, ngày/giờ và số slide. Trình giữ chỗ tiêu đề có sẵn trên các trang ghi chú và tài liệu.

**Nếu trình giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [isFooterVisible](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) báo cáo liệu có trình giữ chỗ chân trang hay không, và [setFooterVisibility](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) thay đổi khả năng hiển thị của nó.

**Làm thế nào để bắt đầu đánh số slide từ giá trị khác 1?**

Gọi phương thức [setFirstSlideNumber](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#setFirstSlideNumber) của bản trình chiếu. Các trình giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã được cập nhật.

**Điều gì xảy ra với tiêu đề và chân trang khi xuất ra PDF, hình ảnh hoặc HTML?**

Các thành phần tiêu đề và chân trang hiển thị sẽ được vẽ cùng với phần nội dung còn lại của bản trình chiếu trong định dạng xuất ra. Ngoại hình của chúng phụ thuộc vào loại trang đang được xuất và cài đặt khả năng hiển thị của các trình giữ chỗ tương ứng.