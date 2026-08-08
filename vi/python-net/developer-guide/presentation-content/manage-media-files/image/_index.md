---
title: Tối ưu quản lý hình ảnh trong PowerPoint bằng Python
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/python-net/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tối ưu hóa việc quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho Python qua .NET, nâng cao hiệu suất và tự động hóa quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bản trình bày sinh động và hấp dẫn hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các nguồn khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào slide theo nhiều cách.

{{% alert title="Mẹo" color="primary" %}}
Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp bạn nhanh chóng tạo bản trình bày từ hình ảnh.
{{% /alert %}}

{{% alert title="Thông tin" color="info" %}}
Nếu bạn muốn thêm hình ảnh dưới dạng đối tượng khung—đặc biệt khi bạn dự định sử dụng các tùy chọn định dạng tiêu chuẩn như thay đổi kích thước hoặc áp dụng hiệu ứng—xem mục [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/vi/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Lưu ý" color="warning" %}}
Bạn có thể sử dụng các hoạt động I/O của hình ảnh và bản trình bày để chuyển đổi hình ảnh giữa các định dạng. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/python-net/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-png/); chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-svg/); và chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides hỗ trợ làm việc với hình ảnh ở các định dạng phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác.

## **Thêm Hình Ảnh Được Lưu Trữ Cục Bộ Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh từ máy tính vào một slide trong bản trình bày. Ví dụ Python sau minh họa cách thêm hình ảnh vào slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Từ Web Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có sẵn trên máy tính, bạn có thể chèn trực tiếp từ web.

Ví dụ Python sau cho thấy cách thêm hình ảnh từ URL vào slide:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tải xuống byte ảnh thô.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Vào Master Slide**

Master slide là slide cấp cao nhất lưu trữ và kiểm soát thông tin—chủ đề, bố cục, v.v.—cho tất cả các slide bên dưới nó. Khi bạn thêm một hình ảnh vào master slide, hình ảnh đó sẽ xuất hiện trên mọi slide sử dụng master đó.

Ví dụ Python sau minh họa cách thêm hình ảnh vào master slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Là Nền Slide**

Bạn có thể sử dụng một bức ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Setting Images as Backgrounds for Slides](/slides/vi/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bản Trình Bày**

Nội dung SVG có thể được thêm vào bản trình bày bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/). Hình ảnh SVG kết quả sau đó có thể được thêm vào bộ sưu tập hình ảnh của bản trình bày và dùng để tạo khung hình.

Ví dụ Python sau nhập một chuỗi SVG tự chứa. Tất cả hình ảnh, kiểu dáng và các tài nguyên khác được sử dụng bởi SVG này được nhúng trực tiếp trong nội dung SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Chuyển Đổi SVG Thành Tập Hình Dạng**

Aspose.Slides chuyển đổi SVG thành một tập các hình dạng tương tự như cách PowerPoint xử lý SVG.

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [add_group_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_group_shape/) trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) nhận một [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/) làm đối số đầu tiên.  

Mã mẫu dưới đây cho thấy cách chuyển đổi tệp SVG thành một tập các hình dạng.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Đọc nội dung tệp SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Tạo đối tượng SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Lấy kích thước slide.
        slide_size = presentation.slide_size.size

        # Chuyển đổi ảnh SVG thành một nhóm các shape và điều chỉnh kích thước theo slide.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Lưu bản trình bày ở định dạng PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**

Aspose.Slides for Python cho phép bạn chèn hình ảnh Enhanced Metafile (EMF) vào bản trình bày.

Ví dụ Python sau minh họa cách thực hiện:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế hình ảnh lưu trong bộ sưu tập hình ảnh của bản trình bày, bao gồm cả những hình được sử dụng bởi các shape trên slide. Phần này đề cập đến một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một đối tượng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải bản trình bày chứa các hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Đọc một hình ảnh mới từ tệp vào một mảng byte.
1. Thay thế hình ảnh mục tiêu bằng hình mới sử dụng mảng byte.
1. Ngoài ra, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) và thay thế hình mục tiêu bằng đối tượng này.
1. Hoặc thay thế hình mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bản trình bày.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation("sample.pptx") as presentation:

    # Cách đầu tiên.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Cách thứ hai.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Cách thứ ba.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Lưu bản trình bày vào tệp.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Thông tin" color="info" %}}
Với trình chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh văn bản và tạo GIF từ văn bản.
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được bảo tồn, nhưng diện mạo cuối cùng phụ thuộc vào cách [picture](/slides/vi/python-net/picture-frame/) được thu phóng trên slide và bất kỳ nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng lúc là gì?**

Đặt logo trên master slide hoặc layout và thay thế nó trong bộ sưu tập hình ảnh của bản trình bày—các cập nhật sẽ lan tới mọi thành phần sử dụng tài nguyên đó.

**SVG được chèn có thể chuyển đổi thành các shape có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các shape, sau đó từng phần sẽ trở nên có thể chỉnh sửa với các thuộc tính shape tiêu chuẩn.

**Làm sao để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**

[Assign the image as the background](/slides/vi/python-net/presentation-background/) trên master slide hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao ngăn bản trình bày trở nên quá lớn vì có quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi phù hợp.