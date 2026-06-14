---
title: Sao chép các slide PowerPoint trong Python
linktitle: Sao chép slide
type: docs
weight: 40
url: /vi/python-net/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Nhanh chóng sao chép hoặc nhân bản các slide PowerPoint bằng Aspose.Slides cho Python qua .NET. Thực hiện các ví dụ mã rõ ràng và mẹo của chúng tôi để tự động tạo PPT trong vài giây, nâng cao năng suất và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao chính xác hoặc bản sao gương của một thứ gì đó. Aspose.Slides cũng cho phép bạn sao chép (clone) bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu mở nào khác. Việc sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không ảnh hưởng đến slide gốc. Có một số cách để sao chép một slide:

- Sao chép vào cuối một bản trình chiếu.
- Sao chép vào vị trí khác trong cùng một bản trình chiếu.
- Sao chép vào cuối một bản trình chiếu khác.
- Sao chép vào vị trí khác trong một bản trình chiếu khác.
- Sao chép vào vị trí cụ thể trong một bản trình chiếu khác.

Trong Aspose.Slides cho Python thông qua .NET, [slide collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp các phương thức `add_clone` và `insert_clone` để thực hiện các loại sao chép slide này.

## **Sao chép vào Cuối trong cùng một Bản trình chiếu**

Nếu bạn muốn sao chép một slide trong cùng một bản trình chiếu và thêm nó vào cuối các slide hiện có, hãy sử dụng phương thức `add_clone`. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy bộ sưu tập slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
3. Gọi phương thức `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền slide cần sao chép.
4. Lưu bản trình chiếu đã sửa đổi.

Trong ví dụ dưới đây, slide đầu tiên (chỉ mục 0) được sao chép và thêm vào cuối bản trình chiếu.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình chiếu.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Sao chép slide mong muốn vào cuối bộ sưu tập slide trong cùng một bản trình chiếu.
    presentation.slides.add_clone(presentation.slides[0])
    # Lưu bản trình chiếu đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép đến Vị trí Cụ thể trong cùng một Bản trình chiếu**

Nếu bạn muốn sao chép một slide trong cùng một bản trình chiếu và đặt nó ở vị trí khác, hãy sử dụng phương thức `insert_clone`:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy bộ sưu tập slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
3. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền slide cần sao chép và chỉ mục mục tiêu cho vị trí mới của nó.
4. Lưu bản trình chiếu đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 (vị trí 1) được sao chép tới chỉ mục 1 (vị trí 2) trong cùng một bản trình chiếu.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình chiếu.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Sao chép slide mong muốn vào vị trí (chỉ mục) đã chỉ định trong cùng một bản trình chiếu.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Lưu bản trình chiếu đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép vào Cuối của một Bản trình chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và thêm nó vào cuối một bản trình chiếu khác:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu nguồn (bản chứa slide cần sao chép).
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu đích (nơi slide sẽ được thêm).
3. Lấy bộ sưu tập slide từ bản trình chiếu đích.
4. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản đích, truyền slide từ bản nguồn.
5. Lưu bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản trình chiếu nguồn được sao chép vào cuối bản trình chiếu đích.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình chiếu nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Tạo một thể hiện của lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation() as target_presentation:
        # Sao chép slide mong muốn từ bản trình chiếu nguồn vào cuối bộ sưu tập slide trong bản trình chiếu đích.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Lưu bản trình chiếu đích vào đĩa.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tới Vị trí Cụ thể trong một Bản trình chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và chèn nó vào một bản trình chiếu khác ở vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu nguồn (bản chứa slide cần sao chép).
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu đích (nơi slide sẽ được thêm).
3. Lấy bộ sưu tập slide từ bản trình chiếu đích.
4. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản đích, truyền slide từ bản nguồn và chỉ mục mục tiêu mong muốn.
5. Lưu bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản trình chiếu nguồn được sao chép tới chỉ mục 1 (vị trí 2) trong bản trình chiếu đích.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình chiếu nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Tạo một thể hiện của lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Chèn một bản sao của slide đầu tiên từ nguồn vào chỉ mục 2 trong bản trình chiếu đích.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Lưu bản trình chiếu đích vào đĩa.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép một Slide cùng với Slide Master của nó vào một Bản trình chiếu Khác**

Nếu bạn cần sao chép một slide **cùng với master** từ một bản trình chiếu và sử dụng nó trong bản khác, trước tiên sao chép master slide cần thiết từ bản nguồn vào bản đích. Sau đó sử dụng master đích khi sao chép slide. Phương thức `add_clone(Slide, MasterSlide)` yêu cầu một **master slide từ bản trình chiếu đích**, không phải từ bản nguồn.

Để sao chép một slide cùng với master, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu nguồn.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình chiếu đích.
3. Truy cập slide nguồn cần sao chép và master slide của nó.
4. Lấy [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) từ bộ sưu tập master của bản trình chiếu đích.
5. Gọi `add_clone` trên [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/), truyền master nguồn để sao chép vào bản đích.
6. Lấy [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) từ bộ sưu tập slide của bản trình chiếu đích.
7. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền slide nguồn và master đã sao chép của bản đích.
8. Lưu bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, slide có chỉ mục 0 trong bản nguồn được sao chép vào cuối bản đích sử dụng master đã được sao chép từ nguồn.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation để đại diện cho tệp bản trình chiếu nguồn.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Tạo một thể hiện của lớp Presentation cho bản trình chiếu đích nơi slide sẽ được sao chép.
    with slides.Presentation() as target_presentation:
        # Lấy slide đầu tiên từ bản trình chiếu nguồn.
        source_slide = source_presentation.slides[0]
        # Lấy master slide được sử dụng bởi slide đầu tiên.
        source_master = source_slide.layout_slide.master_slide
        # Sao chép master slide vào bộ sưu tập master của bản trình chiếu đích.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Sao chép slide từ bản trình chiếu nguồn vào cuối bản trình chiếu đích bằng master đã sao chép.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Lưu bản trình chiếu đích vào đĩa.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép vào Cuối trong Phần được chỉ định**

Với Aspose.Slides cho Python thông qua .NET, bạn có thể sao chép một slide từ một phần của bản trình chiếu và chèn nó vào một phần khác trong cùng một bản trình chiếu. Để thực hiện điều này, sử dụng phương thức `add_clone(Slide, Section)` của lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/).

Ví dụ Python dưới đây cho thấy cách sao chép một slide và chèn bản sao vào một phần cụ thể:

```py
import aspose.slides as slides

# Tạo một bản trình chiếu trống mới.
with slides.Presentation() as presentation:
    # Thêm một slide trống dựa trên bố cục của slide đầu tiên.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Thêm một hình ellipse vào slide mới; slide này sẽ được sao chép sau.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Thêm một slide trống khác dựa trên bố cục của slide đầu tiên.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Tạo một phần có tên "Section2" bắt đầu tại slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Sao chép slide đã tạo trước vào phần "Section2".
    presentation.slides.add_clone(slide, section)
    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ghi chú người nói và bình luận của người xem có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá đều được bao gồm trong bản sao. Nếu bạn không muốn chúng, hãy [remove them](/slides/vi/python-net/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết với nguồn bên ngoài (ví dụ: một workbook được nhúng OLE), liên kết đó vẫn được giữ dưới dạng một [OLE object](/slides/vi/python-net/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính sẵn có của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản sao không?**

Có. Bạn có thể chèn bản sao vào chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/python-net/slide-section/) đã chọn. Nếu phần đích chưa tồn tại, hãy tạo trước rồi di chuyển slide vào đó.