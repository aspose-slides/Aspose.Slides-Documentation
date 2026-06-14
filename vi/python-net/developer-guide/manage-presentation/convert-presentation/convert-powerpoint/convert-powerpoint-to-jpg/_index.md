---
title: Chuyển đổi PPT, PPTX và ODP sang JPG trong Python
linktitle: Chuyển đổi Slides sang Hình Ảnh JPG
type: docs
weight: 60
url: /vi/python-net/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint sang JPG
- chuyển đổi bài thuyết trình sang JPG
- chuyển đổi slide sang JPG
- chuyển đổi PPT sang JPG
- chuyển đổi PPTX sang JPG
- chuyển đổi ODP sang JPG
- PowerPoint sang JPG
- bài thuyết trình sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- ODP sang JPG
- chuyển đổi PowerPoint sang JPEG
- chuyển đổi bài thuyết trình sang JPEG
- chuyển đổi slide sang JPEG
- chuyển đổi PPT sang JPEG
- chuyển đổi PPTX sang JPEG
- chuyển đổi ODP sang JPEG
- PowerPoint sang JPEG
- bài thuyết trình sang JPEG
- slide sang JPEG
- PPT sang JPEG
- PPTX sang JPEG
- ODP sang JPEG
- Python
- Aspose.Slides
description: "Học cách chuyển đổi các slide của bạn từ các bài thuyết trình PowerPoint và OpenDocument thành hình ảnh JPEG chất lượng cao chỉ với một vài dòng mã trong Python. Tối ưu hóa các bài thuyết trình cho việc sử dụng trên web, chia sẻ và lưu trữ. Đọc hướng dẫn đầy đủ ngay!"
---
## **Giới thiệu**

Chuyển đổi các bài thuyết trình PowerPoint và OpenDocument sang hình ảnh JPG giúp việc chia sẻ slide, tối ưu hiệu suất và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides for Python cho phép bạn chuyển đổi file PPTX, PPT và ODP thành các hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với những tính năng này, bạn dễ dàng triển khai trình xem bài thuyết trình của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ slide khỏi việc sao chép hoặc trình diễn bài thuyết trình ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bài thuyết trình hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển Đổi Các Slide Bài Thuyết Trình Sang Hình Ảnh JPG**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy đối tượng slide của loại [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) từ bộ sưu tập [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/).
3. Tạo một hình ảnh của slide bằng cách sử dụng phương thức [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#float-float).
4. Gọi phương thức [IImage.save(filename, format)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/save/#str-imageformat) trên đối tượng hình ảnh. Truyền tên tệp đầu ra và định dạng hình ảnh làm đối số.

{{% alert color="primary" %}}

**Lưu ý:** Việc chuyển đổi PPT, PPTX hoặc ODP sang JPG khác với việc chuyển đổi sang các định dạng khác trong Aspose.Slides Python API. Đối với các định dạng khác, bạn thường sử dụng phương thức [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). Tuy nhiên, đối với chuyển đổi JPG, bạn cần sử dụng phương thức [IImage.save(filename, format)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/save/#str-imageformat).

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Lưu hình ảnh vào đĩa ở định dạng JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Chuyển Đổi Slide Sang JPG Với Kích Thước Tùy Chỉnh**

Để thay đổi kích thước của các hình ảnh JPG kết quả, bạn có thể đặt kích thước ảnh bằng cách truyền vào phương thức [Slide.get_image(image_size)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). Điều này cho phép bạn tạo ra các ảnh với giá trị chiều rộng và chiều cao cụ thể, đảm bảo đầu ra đáp ứng yêu cầu về độ phân giải và tỷ lệ khung hình. Tính linh hoạt này đặc biệt hữu ích khi tạo ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi yêu cầu kích thước ảnh chính xác.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Tạo hình ảnh slide với kích thước được chỉ định.
        with slide.get_image(image_size) as thumbnail:
            # Lưu hình ảnh vào đĩa ở định dạng JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Hiển Thị Bình Luận Khi Lưu Slide Dưới Dạng Hình Ảnh**

Aspose.Slides cho Python cung cấp tính năng cho phép bạn hiển thị bình luận trên các slide của bài thuyết trình khi chuyển đổi chúng thành hình ảnh JPG. Tính năng này đặc biệt hữu ích để bảo tồn các chú thích, phản hồi hoặc thảo luận được cộng tác viên thêm vào các bài thuyết trình PowerPoint. Bằng cách bật tùy chọn này, bạn đảm bảo rằng bình luận sẽ hiển thị trong ảnh đã tạo, giúp dễ dàng xem lại và chia sẻ phản hồi mà không cần mở lại file bài thuyết trình gốc.

Giả sử chúng ta có một file bài thuyết trình, "sample.pptx", với một slide chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Mã Python sau đây chuyển đổi slide thành ảnh JPG đồng thời bảo tồn các bình luận:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Đặt tùy chọn cho bình luận slide.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Chuyển đổi slide đầu tiên thành hình ảnh.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Kết quả:

![Hình JPG có bình luận](image_with_comments.png)

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang hình ảnh, chẳng hạn:

- [Convert PowerPoint to GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/vi/python-net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/vi/python-net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Để xem cách Aspose.Slides chuyển đổi PowerPoint sang hình ảnh JPG, hãy thử các công cụ chuyển đổi trực tuyến miễn phí sau: PowerPoint [PPTX sang JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT sang JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Trình Chuyển Đổi PPTX sang JPG Trực Tuyến Miễn Phí](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose cung cấp một [Ứng dụng Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất hình ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 

Sử dụng cùng các nguyên tắc được mô tả trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, hãy xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/python-net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides hiển thị toàn bộ nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và nhiều hơn nữa. Tuy nhiên, độ chính xác của việc hiển thị có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu.

**Có bất kỳ giới hạn nào về số lượng slide có thể xử lý không?**

Aspose.Slides không đặt bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bài thuyết trình lớn hoặc hình ảnh độ phân giải cao.