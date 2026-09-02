---
title: Sao chép Slide PowerPoint trong Python
linktitle: Sao chép Slide
type: docs
weight: 40
url: /vi/python-net/clone-slides/
keywords:
- sao chép slide
- chép slide
- lưu slide
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Nhanh chóng sao chép hoặc nhân bản các slide PowerPoint bằng Aspose.Slides cho Python qua .NET. Tham khảo các ví dụ mã rõ ràng và mẹo của chúng tôi để tự động tạo PPT trong vài giây, tăng năng suất và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao của một cái gì đó. Aspose.Slides cũng cho phép bạn sao chép (clone) bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình bày hiện tại hoặc bất kỳ bản trình bày mở nào khác. Việc sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không ảnh hưởng đến slide gốc. Có một số cách để sao chép một slide:

- Sao chép tại cuối một bản trình bày.
- Sao chép ở vị trí khác trong một bản trình bày.
- Sao chép tại cuối một bản trình bày khác.
- Sao chép ở vị trí khác trong một bản trình bày khác.
- Sao chép ở vị trí cụ thể trong một bản trình bày khác.

Trong Aspose.Slides for Python via .NET, [slide collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp các phương thức `add_clone` và `insert_clone` để thực hiện các loại sao chép slide này.

## **Cài đặt**

```bash
pip install aspose.slides
```

## **Sao chép tại cuối trong cùng một bản trình bày**

Nếu bạn muốn sao chép một slide trong cùng một bản trình bày và thêm nó vào cuối các slide hiện có, hãy sử dụng phương thức `add_clone`. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy bộ sưu tập slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
3. Gọi phương thức `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền vào slide cần sao chép.
4. Lưu bản trình bày đã sửa đổi.

Trong ví dụ dưới đây, slide đầu tiên (chỉ mục 0) được sao chép và thêm vào cuối bản trình bày.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình bày.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Sao chép slide mong muốn đến cuối bộ sưu tập slide trong cùng một bản trình bày.
    presentation.slides.add_clone(presentation.slides[0])
    # Lưu bản trình bày đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tới vị trí cụ thể trong cùng một bản trình bày**

Nếu bạn muốn sao chép một slide trong cùng một bản trình bày và đặt nó ở vị trí khác, hãy sử dụng phương thức `insert_clone`:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy bộ sưu tập slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
3. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền vào slide cần sao chép và chỉ mục mục tiêu cho vị trí mới.
4. Lưu bản trình bày đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 1 (vị trí 2) được sao chép tới chỉ mục 2 (vị trí 3) trong cùng một bản trình bày.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Sao chép slide mong muốn đến vị trí (chỉ mục) xác định trong cùng một bản trình bày.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Lưu bản trình bày đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tại cuối một bản trình bày khác**

Nếu bạn cần sao chép một slide từ một bản trình bày và thêm nó vào cuối một bản trình bày khác:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích (nơi slide sẽ được thêm).
3. Lấy bộ sưu tập slide từ bản trình bày đích.
4. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản trình bày đích, truyền vào slide từ bản trình bày nguồn.
5. Lưu bản trình bày đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản trình bày nguồn được sao chép tới cuối bản trình bày đích.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation() as target_presentation:
        # Sao chép slide mong muốn từ bản trình bày nguồn đến cuối bộ sưu tập slide trong bản trình bày đích.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tới vị trí cụ thể trong một bản trình bày khác**

Nếu bạn cần sao chép một slide từ một bản trình bày và chèn nó vào một bản trình bày khác ở vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích (nơi slide sẽ được thêm).
3. Lấy bộ sưu tập slide từ bản trình bày đích.
4. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản trình bày đích, truyền vào slide từ bản trình bày nguồn và chỉ mục mục tiêu mong muốn.
5. Lưu bản trình bày đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản trình bày nguồn được sao chép tới chỉ mục 2 (vị trí 3) trong bản trình bày đích.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Chèn một bản sao của slide đầu tiên từ nguồn tại chỉ mục 2 trong bản trình bày đích.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép một Slide cùng Master Slide vào một bản trình bày khác**

Nếu bạn cần sao chép một slide **cùng master** từ một bản trình bày và sử dụng nó trong bản trình bày khác, trước tiên sao chép master slide cần thiết từ bản trình bày nguồn vào bản trình bày đích. Sau đó sử dụng master đích đó khi sao chép slide. Phương thức `add_clone(Slide, MasterSlide)` yêu cầu một **master slide từ bản trình bày đích**, không phải từ nguồn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích.
3. Truy cập slide nguồn cần sao chép và master slide của nó.
4. Lấy [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) từ bộ sưu tập master của bản trình bày đích.
5. Gọi `add_clone` trên [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) của bản trình bày đích, truyền vào master nguồn để sao chép vào đích.
6. Lấy [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) từ bộ sưu tập slide của bản trình bày đích.
7. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản trình bày đích, truyền vào slide nguồn và master đích đã được sao chép.
8. Lưu bản trình bày đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản trình bày nguồn được sao chép tới cuối bản trình bày đích bằng cách sử dụng master được sao chép từ nguồn.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Tạo một thể hiện của lớp Presentation cho bản trình bày đích nơi slide sẽ được sao chép.
    with slides.Presentation() as target_presentation:
        # Lấy slide đầu tiên từ bản trình bày nguồn.
        source_slide = source_presentation.slides[0]
        # Lấy slide chủ được sử dụng bởi slide đầu tiên.
        source_master = source_slide.layout_slide.master_slide
        # Sao chép master slide vào bộ sưu tập master của bản trình bày đích.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Sao chép slide từ bản trình bày nguồn tới cuối bản trình bày đích bằng master đã sao chép.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tại cuối trong một Phần được chỉ định**

Với Aspose.Slides for Python via .NET, bạn có thể sao chép một slide từ một phần của bản trình bày và chèn nó vào một phần khác trong cùng một bản trình bày. Để thực hiện, sử dụng phương thức `add_clone(Slide, Section)` của lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/).

Ví dụ Python sau đây cho thấy cách sao chép một slide và chèn bản sao vào một phần được chỉ định:

```py
import aspose.slides as slides

# Tạo một bản trình bày trống mới.
with slides.Presentation() as presentation:
    # Thêm một slide trống dựa trên bố cục của slide đầu tiên.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Thêm một hình ellipse vào slide mới; slide này sẽ được sao chép sau.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Thêm một slide trống khác dựa trên bố cục của slide đầu tiên.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Tạo một phần có tên "Section2" bắt đầu từ slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Sao chép slide đã tạo trước vào phần "Section2".
    presentation.slides.add_clone(slide, section)
    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Đảm bảo Kích thước Slide Khớp**

Khi sao chép slide sang bản trình bày khác, hãy chắc chắn rằng bản trình bày đích có cùng kích thước slide với bản nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi kích thước các hình dạng đã sao chép — tọa độ và kích thước gốc của chúng được giữ nguyên, điều này có thể khiến nội dung hiển thị sai vị trí hoặc vượt ra ngoài giới hạn slide.

Bạn có thể đặt kích thước slide của bản trình bày đích sao cho khớp với bản nguồn trước khi sao chép master và slide:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Hãy thực hiện việc này trước khi sao chép master và slide.

## **Câu hỏi thường gặp**

**Ghi chú diễn giả và bình luận của người đánh giá có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá được bao gồm trong bản sao. Nếu bạn không muốn chúng, [xóa chúng](/slides/vi/python-net/presentation-notes/) sau khi chèn.

### Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ, một workbook nhúng OLE), liên kết đó được giữ lại dưới dạng một [OLE object](/slides/vi/python-net/manage-ole/). Sau khi di chuyển giữa các file, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

### Tôi có thể kiểm soát vị trí chèn và các phần cho bản sao không?

Có. Bạn có thể chèn bản sao tại một chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/python-net/slide-section/) đã chọn. Nếu phần mục tiêu không tồn tại, hãy tạo nó trước rồi di chuyển slide vào đó.
