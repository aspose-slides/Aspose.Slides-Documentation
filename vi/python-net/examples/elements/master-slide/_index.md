---
title: Slide Master
type: docs
weight: 30
url: /vi/python-net/examples/elements/master-slide/
keywords:
- slide master
- thêm slide master
- truy cập slide master
- xóa slide master
- slide master không sử dụng
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý slide master trong Python với Aspose.Slides: tạo, chỉnh sửa, sao chép và định dạng chủ đề, nền, placeholder để thống nhất các slide trong PowerPoint và OpenDocument."
---
Các slide master hình thành cấp độ cao nhất của cây kế thừa slide trong PowerPoint. Một **master slide** định nghĩa các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Layout slides** kế thừa từ master slides, và **normal slides** kế thừa từ layout slides.

Bài viết này minh họa cách tạo, sửa đổi và quản lý master slides bằng Aspose.Slides for Python via .NET.

## **Thêm một Master Slide**

Ví dụ này cho thấy cách tạo một master slide mới bằng cách sao chép master slide mặc định.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Sao chép slide master mặc định.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Mẹo 1:** Master slides cung cấp cách áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung trên tất cả các slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và normal slide phụ thuộc.
> 💡 **Mẹo 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào một master slide đều được kế thừa bởi layout slides và, theo đó, tất cả các normal slide sử dụng những layout đó.
> Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động hiển thị trên slide cuối cùng.

![Ví dụ Kế Thừa Master](master-slide-banner.png)

## **Truy cập một Master Slide**

Bạn có thể truy cập các master slide bằng cách sử dụng collection `Presentation.masters`. Dưới đây là cách lấy và làm việc với chúng:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Truy cập slide master đầu tiên.
        first_master_slide = presentation.masters[0]
```

## **Xóa một Master Slide**

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Xóa theo chỉ mục.
        presentation.masters.remove_at(0)

        # Hoặc xóa theo tham chiếu.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa các Master Slide không sử dụng**

Một số bản trình bày chứa các master slide không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Xóa tất cả các slide master không sử dụng (ngay cả những slide được đánh dấu Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Mẹo:** Sử dụng `remove_unused(True)` để dọn dẹp các master slide không sử dụng và giảm thiểu kích thước bản trình bày.