---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong Python
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/python-net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- khung giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
- slide tiêu đề
- tiêu đề và nội dung
- đầu mục phần
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
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý và tùy chỉnh bố cục slide trong Aspose.Slides for Python qua .NET. Khám phá các loại bố cục, kiểm soát khung giữ chỗ, hiển thị chân trang và thao tác với bố cục thông qua các ví dụ mã trong Python."
---
## **Giới thiệu**

Bố cục slide xác định cách sắp xếp các khung giữ chỗ và định dạng cho nội dung trên một slide. Nó điều khiển các khung giữ chỗ nào khả dụng và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bài thuyết trình nhanh chóng và nhất quán—cho dù bạn đang tạo một cái đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Title Slide layout** – Bao gồm hai khung giữ chỗ văn bản: một cho tiêu đề và một cho phụ đề.

**Title and Content layout** – Có một khung giữ chỗ tiêu đề nhỏ hơn ở phần trên và một khung lớn hơn ở phía dưới cho nội dung chính (như văn bản, dấu đầu dòng, biểu đồ, hình ảnh, và các loại khác).

**Blank layout** – Không chứa khung giữ chỗ nào, cho phép bạn kiểm soát hoàn toàn để thiết kế slide từ đầu.

Bố cục slide là một phần của master slide, là slide cấp cao nhất định nghĩa kiểu bố cục cho toàn bộ bài thuyết trình. Bạn có thể truy cập và chỉnh sửa các slide bố cục thông qua master slide—bằng kiểu, tên hoặc ID duy nhất. Ngoài ra, bạn cũng có thể chỉnh sửa trực tiếp một slide bố cục cụ thể trong bài thuyết trình.

Để làm việc với bố cục slide trong Aspose.Slides for Python, bạn có thể sử dụng:

- Các thuộc tính như [layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/layout_slides/) và [masters](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/masters/) dưới lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)
- Các kiểu như [LayoutSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/), và [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về cách làm việc với master slide, hãy xem bài viết [Manage PowerPoint Slide Masters in Python](/slides/vi/python-net/slide-master/).
{{% /alert %}}

## **Thêm bố cục slide vào bài thuyết trình**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các slide bố cục mới vào bài thuyết trình. Aspose.Slides for Python cho phép bạn kiểm tra xem một bố cục cụ thể đã tồn tại chưa, thêm mới nếu cần, và sử dụng nó để chèn slide dựa trên bố cục đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterlayoutslidecollection/).
1. Kiểm tra xem slide bố cục mong muốn đã tồn tại trong bộ sưu tập chưa. Nếu chưa, thêm slide bố cục bạn cần.
1. Thêm một slide trống dựa trên slide bố cục mới.
1. Lưu bài thuyết trình.

Mã Python sau đây minh họa cách thêm một bố cục slide vào bài thuyết trình PowerPoint:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp bài thuyết trình.
with slides.Presentation("sample.pptx") as presentation:
    # Duyệt qua các loại bố cục slide để chọn một slide bố cục.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Trường hợp bài thuyết trình không chứa tất cả các loại bố cục.
        # Tệp bài thuyết trình chỉ chứa các loại bố cục Trống và Tùy chỉnh.
        # Tuy nhiên, các slide bố cục với loại tùy chỉnh có thể có tên nhận dạng được,
        # chẳng hạn như "Title", "Title and Content", v.v., có thể được dùng để chọn slide bố cục.
        # Bạn cũng có thể dựa vào một tập hợp các loại hình dạng khung giữ chỗ.
        # Ví dụ, một slide Tiêu đề chỉ nên có loại khung giữ chỗ Tiêu đề, và tương tự.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Thêm một slide trống sử dụng slide bố cục đã thêm.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Lưu bài thuyết trình vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa các slide bố cục không sử dụng**

Aspose.Slides cung cấp phương thức [remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) từ lớp [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) để cho phép bạn xóa các slide bố cục không cần và không được sử dụng.

Mã Python sau đây cho thấy cách xóa một slide bố cục khỏi bài thuyết trình PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm khung giữ chỗ vào bố cục slide**

Aspose.Slides cung cấp thuộc tính [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/placeholder_manager/), cho phép bạn thêm các khung giữ chỗ mới vào một slide bố cục.

Trình quản lý này chứa các phương thức cho các loại khung giữ chỗ sau:

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutplaceholdermanager/) Phương thức |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Nội dung](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Nội dung (Dọc)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Văn bản](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Văn bản (Dọc)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Hình](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Biểu đồ](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Bảng](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Phương tiện](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Hình ảnh trực tuyến](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Mã Python sau đây minh họa cách thêm các hình khối khung giữ chỗ mới vào slide bố cục Blank:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lấy slide bố cục Trống.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Lấy trình quản lý khung giữ chỗ của slide bố cục.
    placeholder_manager = layout.placeholder_manager

    # Thêm các khung giữ chỗ khác nhau vào slide bố cục Trống.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Thêm một slide mới với bố cục Trống.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các khung giữ chỗ trên slide bố cục](add_placeholders.png)

## **Đặt hiển thị chân trang cho một slide bố cục**

Trong các bài thuyết trình PowerPoint, các thành phần chân trang như ngày, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy thuộc vào bố cục slide. Aspose.Slides for Python cho phép bạn kiểm soát khả năng hiển thị của các khung giữ chỗ chân trang này. Điều này hữu ích khi bạn muốn một số bố cục hiển thị thông tin chân trang trong khi những bố cục khác giữ sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu đến slide bố cục theo chỉ mục của nó.
1. Đặt khung giữ chỗ chân trang của slide thành hiển thị.
1. Đặt khung giữ chỗ số slide của slide thành hiển thị.
1. Đặt khung giữ chỗ ngày‑giờ của slide thành hiển thị.
1. Lưu bài thuyết trình.

Mã Python sau đây cho thấy cách đặt hiển thị của chân trang slide và thực hiện các tác vụ liên quan:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Đặt hiển thị chân trang con cho một slide**

Trong các bài thuyết trình PowerPoint, các thành phần chân trang như ngày, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức master slide để đảm bảo tính nhất quán trên tất cả các slide bố cục. Aspose.Slides for Python cho phép bạn đặt khả năng hiển thị và nội dung của các khung giữ chỗ chân trang này trên master slide và truyền các cài đặt này tới tất cả các slide bố cục con. Cách tiếp cận này đảm bảo thông tin chân trang đồng nhất xuyên suốt bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu đến master slide theo chỉ mục của nó.
1. Đặt các khung giữ chỗ chân trang của master và tất cả các bố cục con thành hiển thị.
1. Đặt các khung giữ chỗ số slide của master và tất cả các bố cục con thành hiển thị.
1. Đặt các khung giữ chỗ ngày‑giờ của master và tất cả các bố cục con thành hiển thị.
1. Lưu bài thuyết trình.

Mã Python sau đây minh họa thao tác này:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Sự khác nhau giữa master slide và layout slide là gì?**

Master slide định nghĩa giao diện tổng thể và định dạng mặc định, trong khi layout slide xác định cách sắp xếp cụ thể các khung giữ chỗ cho các loại nội dung khác nhau.

**Tôi có thể sao chép một layout slide từ một bài thuyết trình sang bài thuyết trình khác không?**

Có, bạn có thể sao chép một layout slide từ bộ sưu tập [layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/layout_slides/) của một bài thuyết trình và chèn nó vào bài thuyết trình khác bằng phương thức `add_clone`.

**Nếu tôi xóa một layout slide mà vẫn còn được một slide khác sử dụng thì sẽ xảy ra gì?**

Nếu bạn cố gắng xóa một layout slide vẫn đang được tham chiếu bởi ít nhất một slide trong bài thuyết trình, Aspose.Slides sẽ ném ra một ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/). Để tránh điều này, hãy sử dụng [remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) để an toàn xóa chỉ các layout slide không còn được sử dụng.