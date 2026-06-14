---
title: Slide Bố cục
type: docs
weight: 20
url: /vi/python-net/examples/elements/layout-slide/
keywords:
- slide bố cục
- thêm slide bố cục
- truy cập slide bố cục
- xóa slide bố cục
- slide bố cục không dùng
- sao chép slide bố cục
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Sử dụng Python để quản lý slide bố cục với Aspose.Slides: tạo, áp dụng, sao chép, đổi tên và tùy chỉnh các placeholder và giao diện trong bản trình bày cho PPT, PPTX và ODP."
---
Bài viết này hướng dẫn cách làm việc với **Layout Slides** trong Aspose.Slides cho Python thông qua .NET. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide bình thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các layout không sử dụng để giảm kích thước bản trình bày.

## **Thêm Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để xác định định dạng có thể tái sử dụng.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Tạo một layout slide với loại và tên được chỉ định.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các thành phần chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Tip 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.  
> Ảnh chụp màn hình bên dưới hiển thị hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Các slide kế thừa nội dung Layout](layout-slide-result.png)


## **Truy cập Layout Slide**

Có thể truy cập layout slides bằng chỉ mục hoặc bằng loại layout (ví dụ: `Blank`, `Title`, `SectionHeader`, v.v.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Truy cập theo chỉ mục.
        first_layout_slide = presentation.layout_slides[0]

        # Truy cập theo loại layout.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Xóa Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu không còn cần thiết.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Lấy một layout slide theo loại và xóa nó.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa các Layout Slide không sử dụng**

Để giảm kích thước bản trình bày, bạn có thể muốn xóa các layout slide không được bất kỳ slide bình thường nào sử dụng.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Tự động xóa tất cả các layout slide không được bất kỳ slide nào tham chiếu.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép Layout Slide**

Bạn có thể sao chép một layout slide bằng phương thức `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Lấy một layout slide hiện có theo loại.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Sao chép layout slide đến cuối bộ sưu tập layout slide.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Tóm tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát toàn diện việc tạo, quản lý và tối ưu hóa layout slides.