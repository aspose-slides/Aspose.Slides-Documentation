---
title: Quản lý tiêu đề và chân trang cho bản trình chiếu bằng Python
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
- bản phát tay
- ghi chú
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Sử dụng Aspose.Slides for Python qua .NET để thêm và tùy chỉnh tiêu đề và chân trang trong các bản trình chiếu PowerPoint và OpenDocument, mang lại vẻ ngoài chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides for Python cho phép bạn kiểm soát các placeholder tiêu đề và chân trang trên toàn bộ bản trình chiếu với phạm vi chính xác. Văn bản chân trang, ngày/giờ và số slide trên các slide được quản lý từ cấp master và có thể áp dụng toàn cục hoặc điều chỉnh từng slide. Tiêu đề được hỗ trợ trên notes và handouts, nơi bạn có thể bật/tắt hiển thị và đặt văn bản cho tiêu đề, chân trang, ngày/giờ và số trang thông qua trình quản lý tiêu đề & chân trang riêng trên master notes slide hoặc các notes slide riêng lẻ. Bài viết này trình bày các mẫu chính để cập nhật các placeholder này và lan truyền các thay đổi một cách nhất quán trong toàn bộ deck.

## **Quản lý Văn bản Tiêu đề và Chân trang**

Trong phần này, bạn sẽ học cách quản lý nội dung tiêu đề và chân trang trong một bản trình chiếu—bật hoặc chỉnh sửa chân trang, ngày và giờ, và số slide. Chúng tôi sẽ tóm tắt ngắn gọn các phạm vi áp dụng các cài đặt này (toàn bộ bản trình chiếu, các slide riêng lẻ, và chế độ xem notes/handout) và chỉ ra cách sử dụng API Aspose.Slides để cập nhật chúng một cách nhanh chóng và nhất quán.

Đoạn mã mẫu dưới đây mở một bản trình chiếu, bật và đặt văn bản chân trang, cập nhật văn bản tiêu đề trên master notes slide, và lưu tệp.

```py
import aspose.slides as slides

# Hàm để đặt văn bản tiêu đề.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Tải bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    # Đặt chân trang.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Truy cập và cập nhật tiêu đề.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Lưu bản trình chiếu.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản lý Tiêu đề và Chân trang trên Slides Ghi chú**

Trong phần này, bạn sẽ học cách quản lý tiêu đề và chân trang cụ thể cho notes slides trong Aspose.Slides. Chúng tôi sẽ đề cập đến việc bật các placeholder liên quan, đặt văn bản cho chân trang, ngày/giờ và số trang, và áp dụng các thay đổi này một cách nhất quán trên master notes và các notes page riêng lẻ.

Thực hiện các bước sau:

1. Tải một tệp bản trình chiếu.
2. Lấy master notes slide và [trình quản lý tiêu đề & chân trang](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. Trên master notes slide, bật hiển thị Tiêu đề, Chân trang, Số slide và Ngày‑giờ cho master và tất cả các notes slide con.
4. Trên master notes slide, đặt văn bản cho Tiêu đề, Chân trang và Ngày‑giờ cho master và tất cả các notes slide con.
5. Lấy notes slide cho slide đầu tiên của bản trình chiếu và [trình quản lý tiêu đề & chân trang](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Chỉ đối với notes slide đầu tiên này, đảm bảo Tiêu đề, Chân trang, Số slide và Ngày‑giờ đều hiển thị (bật bất kỳ mục nào đang bị tắt).
7. Chỉ đối với notes slide đầu tiên này, đặt văn bản cho Tiêu đề, Chân trang và Ngày‑giờ.
8. Lưu bản trình chiếu ở định dạng PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Hiển thị slide ghi chú master và tất cả các placeholder tiêu đề, chân trang, số slide và ngày/giờ của các slide con.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Đặt văn bản trên slide ghi chú master và tất cả các placeholder tiêu đề, chân trang và ngày/giờ của các slide con.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Thay đổi cài đặt tiêu đề, chân trang, số slide và ngày/giờ chỉ cho slide ghi chú đầu tiên.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Đảm bảo các placeholder tiêu đề, chân trang, số slide và ngày/giờ được hiển thị.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Đặt văn bản trên các placeholder tiêu đề, chân trang và ngày/giờ của slide ghi chú.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Lưu bản trình chiếu.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể thêm “tiêu đề” vào các slide thường không?**

Trong PowerPoint, “Header” chỉ tồn tại cho notes và handouts; trên các slide thường, các yếu tố được hỗ trợ là chân trang, ngày/giờ và số slide. Trong Aspose.Slides điều này cũng tương tự: tiêu đề chỉ dành cho Notes/Handout, và trên các slide—Chân trang/DateTime/SlideNumber.

**Nếu bố cục không có khu vực chân trang — tôi có thể “bật” hiển thị không?**

Có. Kiểm tra tính hiển thị qua trình quản lý tiêu đề/chân trang và bật nó nếu cần. Các chỉ báo và phương thức API này được thiết kế cho trường hợp placeholder bị thiếu hoặc bị ẩn.

**Làm sao để số slide bắt đầu từ một giá trị khác 1?**

Đặt [số slide đầu tiên của bản trình chiếu](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/first_slide_number/); sau đó, tất cả các số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Điều gì xảy ra với tiêu đề/chân trang khi xuất sang PDF/hình ảnh/HTML?**

Chúng được render như các yếu tố văn bản thông thường của bản trình chiếu. Nghĩa là, nếu các yếu tố này hiển thị trên slide hoặc notes page, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với phần nội dung còn lại.