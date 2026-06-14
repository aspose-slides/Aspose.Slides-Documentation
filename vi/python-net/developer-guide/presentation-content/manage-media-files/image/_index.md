---
title: "Tối ưu Quản lý Hình ảnh trong PowerPoint với Python"
linktitle: "Quản lý Hình ảnh"
type: docs
weight: 10
url: /vi/python-net/image/
keywords:
- "thêm hình ảnh"
- "thêm ảnh"
- "thêm bitmap"
- "thay thế hình ảnh"
- "thay thế ảnh"
- "từ web"
- "nền"
- "thêm PNG"
- "thêm JPG"
- "thêm SVG"
- "thêm EMF"
- "thêm WMF"
- "thêm TIFF"
- "PowerPoint"
- "bản thuyết trình"
- "Python"
- "Aspose.Slides"
description: "Tối ưu hoá việc quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho Python thông qua .NET, nâng cao hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh giúp các bản thuyết trình trở nên hấp dẫn và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các nguồn khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào slide theo nhiều cách.

{{% alert  title="Mẹo" color="primary" %}}

Aspose cung cấp các bộ chuyển đổi miễn phí—[JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp bạn nhanh chóng tạo bản thuyết trình từ hình ảnh.

{{% /alert %}}

{{% alert title="Thông tin" color="info" %}}

Nếu bạn muốn thêm hình ảnh dưới dạng đối tượng khung—đặc biệt khi muốn sử dụng các tùy chọn định dạng tiêu chuẩn như thay đổi kích thước hoặc áp dụng hiệu ứng—xem [Thêm Khung Hình Ảnh vào Bài Thuyết Trình với Python](/slides/vi/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Lưu ý" color="warning" %}}

Bạn có thể sử dụng các thao tác I/O hình ảnh và bản thuyết trình để chuyển đổi hình ảnh giữa các định dạng. Xem các trang này: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/python-net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-png/); chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-svg/); và chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides hỗ trợ làm việc với hình ảnh ở các định dạng phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác.

## **Thêm Hình Ảnh Lưu Trữ Cục Bộ Vào Các Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh từ máy tính vào một slide trong bản thuyết trình. Ví dụ Python sau cho thấy cách thêm hình ảnh vào slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Từ Web Vào Các Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có sẵn trên máy tính, bạn có thể chèn trực tiếp từ web.

Ví dụ Python sau cho thấy cách thêm hình ảnh từ URL vào slide:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master là slide cấp cao nhất lưu trữ và kiểm soát thông tin—giao diện, bố cục, v.v.—cho tất cả các slide bên dưới nó. Khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide sử dụng master đó.

Ví dụ Python sau cho thấy cách thêm hình ảnh vào slide master:

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

## **Đặt Hình Ảnh Là Nền Cho Slide**

Bạn có thể muốn sử dụng một hình ảnh làm nền cho một slide cụ thể hoặc nhiều slide. Để biết chi tiết, xem [Đặt Hình Ảnh Là Nền Cho Slide](/slides/vi/python-net/presentation-background/#set-image-as-background-for-slide).

## **Thêm SVG Vào Bản Thuyết Trình**

Bạn có thể chèn bất kỳ hình ảnh nào vào bản thuyết trình bằng phương thức [add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/).

Để tạo đối tượng hình ảnh từ SVG, thực hiện các bước sau:

1. Tạo một [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/) và thêm nó vào bộ sưu tập hình ảnh của bản thuyết trình.  
2. Tạo đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) từ [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/).  
3. Tạo đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) bằng cách sử dụng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/).

Mẫu Python sau cho thấy cách thêm hình ảnh SVG vào bản thuyết trình bằng các bước trên:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Đọc nội dung của tệp SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Tạo đối tượng SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Tạo đối tượng PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Tạo một PictureFrame mới.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Lưu bản thuyết trình ở định dạng PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Chuyển Đổi SVG Thành Tập Hình Dạng**

Aspose.Slides chuyển đổi SVG thành một tập hợp các hình dạng theo cách tương tự như cách PowerPoint xử lý SVG.

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [add_group_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_group_shape/) trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) nhận một [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/) làm đối số đầu tiên.  

Mã mẫu dưới đây cho thấy cách chuyển đổi tệp SVG thành một tập hợp các hình dạng.

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

        # Chuyển đổi hình ảnh SVG thành một nhóm các hình dạng và thu phóng nó theo kích thước slide.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Lưu bản thuyết trình ở định dạng PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Các Slide**

Aspose.Slides for Python cho phép bạn chèn hình ảnh Enhanced Metafile (EMF) vào bản thuyết trình.

Ví dụ Python sau minh họa cách thực hiện:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của bản thuyết trình, bao gồm các hình ảnh được sử dụng bởi các hình dạng slide. Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải bản thuyết trình chứa các hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).  
2. Tải một hình ảnh mới từ tệp vào một mảng byte.  
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.  
4. Ngoài ra, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.  
5. Hoặc thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bản thuyết trình.  
6. Lưu bản thuyết trình đã sửa đổi dưới dạng tệp PPTX.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Khởi tạo lớp Presentation đại diện cho tệp bản thuyết trình.
with slides.Presentation("sample.pptx") as presentation:

    # Cách thứ nhất.
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

    # Lưu bản thuyết trình vào tệp.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Thông tin" color="info" %}}

Với trình chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh văn bản và tạo GIF từ văn bản.

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Độ phân giải gốc của hình ảnh có giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được bảo tồn, nhưng diện mạo cuối cùng phụ thuộc vào cách [picture](/slides/vi/python-net/picture-frame/) được thu phóng trên slide và bất kỳ nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide một lúc là gì?**

Đặt logo trên slide master hoặc layout và thay thế nó trong bộ sưu tập hình ảnh của bản thuyết trình—các cập nhật sẽ lan tới mọi phần tử sử dụng tài nguyên đó.

**SVG đã chèn có thể được chuyển đổi thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm thế nào để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**

[Chỉ định hình ảnh làm nền](/slides/vi/python-net/presentation-background/) trên slide master hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao ngăn bản thuyết trình “phình to” kích thước do quá nhiều hình ảnh?**

Sử dụng lại một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu và giữ các đồ họa lặp lại trên master khi thích hợp.