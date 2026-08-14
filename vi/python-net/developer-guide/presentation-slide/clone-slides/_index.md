---
title: Sao chép slide PowerPoint trong Python
linktitle: Sao chép Slide
type: docs
weight: 40
url: /vi/python-net/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Nhanh chóng sao chép hoặc tạo bản sao các slide PowerPoint với Aspose.Slides cho Python qua .NET. Thực hiện các ví dụ mã rõ ràng và mẹo của chúng tôi để tự động tạo PPT trong vài giây, tăng năng suất và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao chép của một vật nào đó. Aspose.Slides cũng cho phép bạn sao chép (clone) bất kỳ slide nào và sau đó chèn slide đã được sao chép vào bản trình bày hiện tại hoặc bất kỳ bản trình bày mở nào khác. Việc sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không ảnh hưởng đến slide gốc. Có một số cách để sao chép một slide:

- Sao chép vào cuối một bản trình bày.
- Sao chép vào vị trí khác trong một bản trình bày.
- Sao chép vào cuối một bản trình bày khác.
- Sao chép vào vị trí khác trong một bản trình bày khác.
- Sao chép vào một vị trí cụ thể trong một bản trình bày khác.

Trong Aspose.Slides for Python via .NET, [slide collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp các phương thức `add_clone` và `insert_clone` để thực hiện các loại sao chép slide này.

## **Cài đặt**

```bash
pip install aspose.slides
```

## **Sao chép vào cuối trong cùng bản trình bày**

Nếu bạn muốn sao chép một slide trong cùng bản trình bày và thêm nó vào cuối các slide hiện có, hãy sử dụng phương thức `add_clone`. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy collection slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Gọi phương thức `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền slide cần sao chép.
1. Lưu bản trình bày đã chỉnh sửa.

Trong ví dụ dưới đây, slide đầu tiên (chỉ số 0) được sao chép và thêm vào cuối bản trình bày.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Sao chép slide mong muốn tới cuối collection slide trong cùng bản trình bày.
    presentation.slides.add_clone(presentation.slides[0])
    # Lưu bản trình bày đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tới vị trí cụ thể trong cùng bản trình bày**

Nếu bạn muốn sao chép một slide trong cùng bản trình bày và đặt nó ở vị trí khác, hãy sử dụng phương thức `insert_clone`:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy collection slide từ đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/), truyền slide cần sao chép và chỉ số mục tiêu cho vị trí mới của nó.
1. Lưu bản trình bày đã chỉnh sửa.

Trong ví dụ dưới đây, slide ở chỉ số 1 (vị trí 2) được sao chép tới chỉ số 2 (vị trí 3) trong cùng bản trình bày.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Sao chép slide mong muốn tới vị trí (chỉ số) xác định trong cùng bản trình bày.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Lưu bản trình bày đã sửa đổi vào đĩa.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép vào cuối của bản trình bày khác**

Nếu bạn cần sao chép một slide từ một bản trình bày và thêm nó vào cuối một bản trình bày khác:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích (nơi slide sẽ được thêm).
1. Lấy collection slide từ bản trình bày đích.
1. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản đích, truyền slide từ bản nguồn.
1. Lưu bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, slide ở chỉ số 0 trong bản trình bày nguồn được sao chép tới cuối bản trình bày đích.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation() as target_presentation:
        # Sao chép slide mong muốn từ bản trình bày nguồn tới cuối collection slide trong bản trình bày đích.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép tới vị trí cụ thể trong bản trình bày khác**

Nếu bạn cần sao chép một slide từ một bản trình bày và chèn nó vào một bản trình bày khác ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích (nơi slide sẽ được thêm).
1. Lấy collection slide từ bản trình bày đích.
1. Gọi phương thức `insert_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản đích, truyền slide từ bản nguồn và chỉ số mục tiêu mong muốn.
1. Lưu bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, slide ở chỉ số 0 trong bản trình bày nguồn được sao chép tới chỉ số 2 (vị trí 3) trong bản trình bày đích.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Chèn một bản sao của slide đầu tiên từ nguồn vào chỉ số 2 trong bản trình bày đích.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép một slide cùng master slide vào bản trình bày khác**

Nếu bạn cần sao chép một slide **với master của nó** từ một bản trình bày và sử dụng nó trong bản khác, trước tiên sao chép master slide cần thiết từ bản nguồn vào bản đích. Sau đó sử dụng master đích đó khi sao chép slide. Phương thức `add_clone(Slide, MasterSlide)` yêu cầu **master slide từ bản trình bày đích**, không phải từ bản nguồn.

Để sao chép một slide cùng master, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày nguồn (bản chứa slide cần sao chép).
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cho bản trình bày đích.
1. Truy cập slide nguồn cần sao chép và master slide của nó.
1. Lấy [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) từ collection master của bản trình bày đích.
1. Gọi `add_clone` trên [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) của bản đích, truyền master nguồn để sao chép vào bản đích.
1. Lấy [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) từ collection slide của bản trình bày đích.
1. Gọi `add_clone` trên [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của bản đích, truyền slide nguồn và master đích đã được sao chép.
1. Lưu bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, slide ở chỉ số 0 trong bản nguồn được sao chép tới cuối bản đích bằng master đã được sao chép từ nguồn.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp bản trình bày nguồn.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Khởi tạo lớp Presentation cho bản trình bày đích nơi slide sẽ được sao chép.
    with slides.Presentation() as target_presentation:
        # Lấy slide đầu tiên từ bản trình bày nguồn.
        source_slide = source_presentation.slides[0]
        # Lấy master slide được sử dụng bởi slide đầu tiên.
        source_master = source_slide.layout_slide.master_slide
        # Sao chép master slide vào collection master của bản trình bày đích.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Sao chép slide từ bản trình bày nguồn tới cuối bản trình bày đích bằng master đã sao chép.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Lưu bản trình bày đích vào đĩa.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép vào cuối trong một phần đã chỉ định**

Với Aspose.Slides for Python via .NET, bạn có thể sao chép một slide từ một phần của bản trình bày và chèn nó vào một phần khác trong cùng bản trình bày. Để thực hiện điều này, sử dụng phương thức `add_clone(Slide, Section)` của lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/).

Ví dụ Python sau cho thấy cách sao chép một slide và chèn bản sao vào một phần đã chỉ định:

```py
import aspose.slides as slides

# Tạo một bản trình bày trắng mới.
with slides.Presentation() as presentation:
    # Thêm một slide trống dựa trên bố cục của slide đầu tiên.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Thêm một hình ellipse vào slide mới; slide này sẽ được sao chép sau này.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Thêm một slide trống khác dựa trên bố cục của slide đầu tiên.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Tạo một phần có tên "Section2" bắt đầu tại slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Sao chép slide đã tạo trước vào phần "Section2".
    presentation.slides.add_clone(slide, section)
    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Đảm bảo kích thước slide khớp**

Khi sao chép slide vào bản trình bày khác, hãy chắc chắn rằng bản trình bày đích có cùng kích thước slide với bản nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi tỷ lệ các hình dạng đã sao chép — tọa độ và kích thước gốc của chúng được giữ nguyên, có thể khiến nội dung bị lệch hoặc vượt ra ngoài ranh giới slide.

Bạn có thể đặt kích thước slide của bản trình bày đích sao cho khớp với bản nguồn trước khi sao chép master và slide:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Thực hiện việc này trước khi sao chép master và slide.

## **FAQ**

### Ghi chú người thuyết trình và nhận xét của người xem có được sao chép không?

Có. Trang ghi chú và nhận xét được bao gồm trong bản sao. Nếu bạn không muốn chúng, [xóa chúng](/slides/vi/python-net/presentation-notes/) sau khi chèn.

### Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết với nguồn bên ngoài (ví dụ: một workbook được nhúng OLE), liên kết đó được giữ lại dưới dạng một [OLE object](/slides/vi/python-net/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

### Tôi có thể kiểm soát vị trí chèn và phần cho bản sao không?

Có. Bạn có thể chèn bản sao vào một chỉ số slide cụ thể và đặt nó vào một [section](/slides/vi/python-net/slide-section/) đã chọn. Nếu phần mục tiêu không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào phần đó.