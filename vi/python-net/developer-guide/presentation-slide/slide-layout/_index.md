---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong Python
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/python-net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- phần giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không dùng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- đầu đề mục
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- hình ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho Python thông qua .NET, thêm phần giữ chỗ, xóa các bố cục không dùng và kiểm soát hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các phần giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các phần giữ chỗ tiêu đề và phụ đề.
- **Title and Content**: Chứa một phần giữ chỗ tiêu đề và một phần giữ chỗ nội dung đa mục đích.
- **Blank**: Không chứa phần giữ chỗ nội dung nào và hữu ích khi mỗi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản thuyết trình có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/) xác định chủ đề, định dạng chia sẻ, nền và các đối tượng chung.
1. Một [layout slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/) thuộc về một master và xác định một sắp xếp cụ thể của các phần giữ chỗ.
1. Một [normal slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục lại kế thừa từ master của nó. Giá trị được đặt trực tiếp trên normal slide sẽ ghi đè lên giá trị được kế thừa ở cấp độ đó. Khi một normal slide được tạo, các hình dạng phần giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các phần giữ chỗ đó thuộc về normal slide.

Thêm các phần giữ chỗ cần thiết vào bố cục trước khi tạo slide từ nó. Thêm một phần giữ chỗ khác vào bố cục sau này sẽ không tự động thêm hình dạng phần giữ chỗ tương ứng vào các normal slide đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của phần giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem xét bản thuyết trình kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Đầu tiên, gán lại các slide phụ thuộc của nó vào một bố cục khác, hoặc chỉ xóa những bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/python-net/slide-master/).

Để ẩn logo kế thừa hoặc các hình dạng trang chiếu master trang trí trên một slide hoặc qua một bố cục chung, xem [Control the Visibility of Master Graphics](/slides/vi/python-net/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và áp dụng một bố cục slide**

Sử dụng kiểu bố cục khi bản thuyết trình tuân theo các định nghĩa bố cục PowerPoint tiêu chuẩn. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được địa phương hóa, vì vậy việc lựa chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ dưới đây tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không khả dụng, nó sẽ cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản thuyết trình có thể chỉ chứa các bố cục tùy chỉnh. Bố cục được chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua thuộc tính [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/).

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

Thay đổi bố cục của một slide không loại bỏ các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí phần giữ chỗ, định dạng kế thừa và sự tương ứng giữa các phần giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục khác nhau đáng kể.

## **Thêm một Layout Slide**

Lựa chọn và tạo mới là các thao tác riêng biệt. Ví dụ trước đã chọn một bố cục hiện có; nó không tạo mới. Để tạo một bố cục, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterlayoutslidecollection/add/) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ dưới đây luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Chỉ thêm một bố cục khi mẫu thực sự cần một cấu trúc có thể tái sử dụng khác. Nếu đã có bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm phần giữ chỗ vào Layout Slide**

Thuộc tính [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/placeholder_manager/) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng phần giữ chỗ vào một bố cục.

| Phần giữ chỗ PowerPoint              | Phương thức `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------------- |
| ![Nội dung](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Nội dung (Dọc)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Văn bản](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Văn bản (Dọc)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Hình ảnh](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Biểu đồ](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Bảng](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Phương tiện](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Hình ảnh trực tuyến](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Ví dụ dưới đây xác minh bố cục **Blank** tồn tại, thêm bốn phần giữ chỗ vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã chỉnh sửa. Thứ tự này có ý định: các phần giữ chỗ được thêm trước khi slide bình thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng phần giữ chỗ tương ứng trên slide đó.

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

![Các phần giữ chỗ trên layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các phần giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một phần giữ chỗ bố cục mới được thêm vào sẽ không được tự động bổ sung vào các normal slide đã tồn tại. Hãy thử nghiệm các thay đổi bố cục trên một bản sao của bản thuyết trình và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Layout Slide không dùng**

Sử dụng phương thức [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) để xóa các bố cục mà không có normal slide nào tham chiếu. Phương thức này giữ lại các bố cục vẫn đang được sử dụng.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Để xóa một bố cục cụ thể, trước tiên hãy sử dụng thuộc tính [has_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/has_depending_slides/) hoặc phương thức [get_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/get_depending_slides/). Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/remove/). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/).

## **Kiểm soát hiển thị Footer trên Layout Slide**

Một layout có các phần giữ chỗ footer, số slide và ngày‑giờ riêng. Sử dụng thuộc tính [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/header_footer_manager/) để điều khiển các phần giữ chỗ này cho một layout. Điều này hữu ích khi, ví dụ, các layout nội dung nên hiển thị footer nhưng các layout tiêu đề thì không.

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

## **Kiểm soát hiển thị Footer trên Master và các Layout con của nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng thuộc tính [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/header_footer_manager/). Các phương pháp lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các layout slide cũng như normal slide phụ thuộc; chúng không chỉ nhắm mục tiêu một normal slide duy nhất.

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

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide xác định chủ đề và định dạng chung của bản thuyết trình. Một layout slide thuộc về một master và xác định một sắp xếp có thể tái sử dụng của các phần giữ chỗ. Các normal slide sử dụng các bố cục này và lưu trữ nội dung riêng của từng slide.

**Tôi có thể sao chép Layout Slide từ một bản thuyết trình sang bản thuyết trình khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Khi sao chép giữa các bản thuyết trình, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác được layout nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của layout trừ khi chúng ghi đè định dạng hoặc đối tượng ảnh hưởng ở mức cục bộ. Vì vậy, hình học phần giữ chỗ và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [get_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/get_depending_slides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc sử dụng [remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) để chỉ xóa các layout không được tham chiếu.