---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong Python
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/python-net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
- slide tiêu đề
- tiêu đề và nội dung
- tiêu đề phần
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Python qua .NET, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của mình.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và tiêu đề phụ.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung đa năng.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu Kế thừa Bố cục**

Một bài thuyết trình có ba mức liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
1. Một [layout slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/) thuộc về một master và xác định một sắp xếp cụ thể của các placeholder.
1. Một [normal slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục lại kế thừa từ master. Giá trị được đặt trực tiếp trên một normal slide sẽ ghi đè giá trị kế thừa ở cấp đó. Khi một normal slide được tạo, các hình dạng placeholder của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các placeholder đó thuộc về normal slide.

Thêm các placeholder cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một placeholder khác vào bố cục sau này sẽ không tự động thêm hình dạng placeholder tương ứng vào các normal slide đã tồn tại.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học placeholder hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem xét bản trình bày kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Đầu tiên hãy gán lại các slide phụ thuộc của nó sang một bố cục khác, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp trên cùng của cấu trúc này, xem [Slide Master](/slides/vi/python-net/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng kiểu bố cục khi bài thuyết trình tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được bản địa hoá, vì vậy việc lựa chọn dựa trên tên ít tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không có, nó cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bài thuyết trình có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên qua thuộc tính [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Thay đổi bố cục của một slide không xóa các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển giữa các bố cục có sự khác biệt đáng kể.

## **Thêm Slide Bố cục**

Việc chọn và tạo là các thao tác riêng biệt. Ví dụ trước chọn một bố cục đã tồn tại; nó không tạo mới. Để tạo một bố cục, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterlayoutslidecollection/add/) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Chỉ thêm bố cục khi mẫu thực sự cần một cấu trúc có thể tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào Slide Bố cục**

Thuộc tính [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/placeholder_manager/) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng placeholder vào một bố cục.

| Placeholder PowerPoint | `LayoutPlaceholderManager` Phương thức |
| ---------------------- | --------------------------------------- |
| ![Nội dung](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Nội dung (Chiều dọc)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Văn bản](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Văn bản (Chiều dọc)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Hình ảnh](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Biểu đồ](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Bảng](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Phương tiện](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Ví dụ sau kiểm tra xem bố cục **Blank** tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã chỉnh sửa. Thứ tự này có chủ đích: các placeholder được thêm trước khi slide bình thường được tạo, do đó Aspose.Slides có thể tạo các hình dạng placeholder tương ứng trên slide đó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các placeholder trên slide bố cục](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder bố cục mới được thêm sẽ không tự động được chèn vào các slide bình thường hiện có. Hãy thử các thay đổi bố cục trên một bản sao của bài thuyết trình và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Slide Bố cục Không sử dụng**

Sử dụng phương thức [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) để xóa các bố cục mà không có slide bình thường nào tham chiếu. Phương thức này để lại các bố cục vẫn đang được sử dụng.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Để xóa một bố cục cụ thể, đầu tiên dùng thuộc tính [has_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/has_depending_slides/) hoặc phương thức [get_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/get_depending_slides/) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/remove/). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Footer trên Slide Bố cục**

Một bố cục có riêng footer, số slide và placeholder ngày‑giờ. Sử dụng thuộc tính [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/header_footer_manager/) để điều khiển các placeholder này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung cần hiển thị footer nhưng các bố cục tiêu đề thì không.

Ví dụ sau chọn một bố cục một cách an toàn và làm cho các phần footer của nó hiển thị:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm soát Hiển thị Footer trên Master và Các Bố cục Con của Nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cấp độ master, sử dụng thuộc tính [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/header_footer_manager/). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các slide bố cục và slide bình thường phụ thuộc; chúng không chỉ nhắm vào một slide bình thường duy nhất.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **CÂU HỎI THƯỜNG GẶP**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide xác định chủ đề và định dạng chung của bài thuyết trình. Một layout slide thuộc về một master và xác định một sắp xếp có thể tái sử dụng của các placeholder. Các slide bình thường sử dụng các bố cục này và lưu trữ nội dung riêng của từng slide.

**Tôi có thể sao chép một Layout Slide từ một bài thuyết trình sang bài thuyết trình khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Khi sao chép giữa các bài thuyết trình, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà layout nguồn sử dụng.

**Điều gì xảy ra khi tôi sửa đổi một Layout đang được sử dụng?**

Các slide phụ thuộc kế thừa các thay đổi của bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng tại chỗ. Vì vậy hình học placeholder và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [get_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/get_depending_slides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném lỗi [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/). Đầu tiên hãy gán lại các slide phụ thuộc, hoặc sử dụng [remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) để chỉ xóa những bố cục không được tham chiếu.