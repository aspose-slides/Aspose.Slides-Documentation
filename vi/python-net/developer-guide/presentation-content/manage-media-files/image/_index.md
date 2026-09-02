---
title: Tối ưu quản lý hình ảnh trong bản trình chiếu bằng Python
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/python-net/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung hình
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- nguồn tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý các hình ảnh raster và SVG trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

Aspose.Slides cho Python thông qua .NET cung cấp một số cách làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong khung hình, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh dùng chung, hoặc chuyển đổi nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào các tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình chiếu. Đối với việc cắt, độ trong suốt, hiệu ứng, kéo giãn và các định dạng khác được áp dụng cho một khung hình riêng lẻ, hãy xem [Picture Frame](/slides/vi/python-net/picture-frame/).

## **Hiểu mô hình hình ảnh**

Các khái niệm API sau đây có liên quan chặt chẽ nhưng không thể hoán đổi cho nhau:

- [Bộ sưu tập hình ảnh bản trình chiếu](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/) lưu trữ các tài nguyên hình ảnh được bản trình chiếu sử dụng. Sử dụng [ImageCollection.add_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/add_image/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/).
- [Khung hình ảnh](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipictureframe/) là một hình dạng hiển thị hình ảnh trên slide, bố cục hoặc master. Sử dụng [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) để đặt một tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của việc lấp đầy slide thay vì là một hình dạng. Do đó nó không hoạt động như một khung hình.
- [IPPImage.replace_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/replace_image/) thay thế một tài nguyên hình ảnh. Nếu nhiều phần tử trong bản trình chiếu sử dụng tài nguyên đó, chúng đều sẽ dùng tài nguyên thay thế.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Do đó một quy trình điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [IPPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung hình hoặc việc lấp đầy.

## **Thêm hình ảnh được nhúng**

Để chèn một hình ảnh cục bộ, đọc tệp, thêm dữ liệu của nó vào bộ sưu tập hình ảnh và tạo một khung hình sử dụng `IPPImage` trả về.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Hình ảnh được thêm theo cách này sẽ được nhúng trong bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống các byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu và sử dụng tài nguyên hình ảnh trả về theo cùng cách như hình ảnh cục bộ.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

Trong các ứng dụng chạy lâu, nên tái sử dụng client HTTP hoặc pool kết nối khi thích hợp thay vì tạo kết nối mới cho mỗi yêu cầu. Ngoài ra, hãy xác thực URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không đáng tin cậy.

## **Tái sử dụng hình ảnh trên nhiều slide**

Nếu cùng một hình ảnh cần được sử dụng hơn một lần, hãy thêm nó vào bản trình chiếu một lần và tái sử dụng [IPPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/) khi tạo các khung hình bổ sung. Điều này tránh tải lại dữ liệu nguồn cùng một lần và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung hình trên một [slide master](/slides/vi/python-net/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử dụng hình ảnh làm nền slide**

Hình ảnh nền được gán vào phần lấp đầy của slide; nó không được thêm như một hình dạng khung hình. Điều này hữu ích khi hình ảnh cần phủ toàn bộ nền slide và không nên được thao tác như một đối tượng slide thông thường.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, hãy xem [Presentation Background](/slides/vi/python-net/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Hình ảnh nhúng và hình ảnh liên kết có các cân nhắc khác nhau về khả năng di chuyển và kích thước tệp:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu trong bản trình chiếu. Bản trình chiếu là tự chứa, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình chiếu lưu đường dẫn hoặc URL tới hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải vẫn có thể truy cập khi bản trình chiếu được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài thông qua [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/vi/python-net/aspose.slides/islidespicture/link_path_long/) thay vì nhúng dữ liệu hình ảnh.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể tin cậy truy cập tài nguyên bên ngoài. Đối với các bản trình chiếu phải hoạt động offline hoặc được chuyển đổi giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, do đó nó hữu ích cho các biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như ảnh raster. Aspose.Slides hỗ trợ SVG cả như tài nguyên hình ảnh và như nguồn để tạo các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG làm hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh và đặt tài nguyên hình ảnh kết quả vào một khung hình.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Chuyển đổi SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự lệnh PowerPoint tương ứng.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng overload [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_group_shape/) chấp nhận một [ISvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/isvgimage/) để thực hiện việc chuyển đổi.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Sử dụng chuyển đổi SVG thành hình dạng khi các phần tử vector riêng lẻ cần được chỉnh sửa như các hình dạng PowerPoint. Nếu SVG chỉ cần được hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh việc tạo ra nhiều hình dạng riêng biệt.

## **Thay thế tài nguyên hình ảnh hiện có**

Sử dụng [IPPImage.replace_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/replace_image/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Nếu nhiều khung hình, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một khung hình cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chia sẻ.

`replace_image` cũng cung cấp các overload chấp nhận một [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) hoặc một [IPPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/) khác.

## **Hướng dẫn thực tế về quản lý hình ảnh**

### **Kiểm soát kích thước bản trình chiếu**

Các hình ảnh raster lớn có thể làm cho bản trình chiếu trở nên quá lớn không cần thiết. Sử dụng hình ảnh nguồn với kích thước phù hợp với kích thước hiển thị dự kiến, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các hình ảnh raster đã được đặt trong khung hình, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/compress_image/) có thể giảm dữ liệu hình ảnh dựa trên độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung hình chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy xem [Picture Frame](/slides/vi/python-net/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Việc nhúng làm cho bản trình chiếu dễ di chuyển vì tất cả dữ liệu hình ảnh cần thiết đi kèm với tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chia sẻ**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu hơn là nội dung slide, hãy đặt nó trên master hoặc layout để các slide thích hợp kế thừa.

### **Giữ tài nguyên SVG di động**

Một SVG tự chứa dễ dàng di chuyển và render nhất quán hơn so với SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành các hình dạng chỉ khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh đa nền tảng hiện đại**

Đối với mã Python mới thông qua .NET, hãy sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/python-net/aspose.slides/images/) thay vì các API hình ảnh đã lỗi thời `aspose.pydrawing.Image` hoặc `aspose.pydrawing.Bitmap`. Xem [Modern API](/slides/vi/python-net/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần lưu ý đặc biệt. Khi các định dạng này được truyền qua một [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/add_image/) chuyển đổi metafile sang đại diện PNG raster trước khi chèn. Nếu việc giữ nguyên dữ liệu metafile quan trọng, hãy sử dụng overload [ImageCollection.add_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/add_image/) dựa trên stream thay thế. Tạo nội dung EMF từ bảng tính hoặc các sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa bộ sưu tập hình ảnh và khung hình là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Khung hình là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp định dạng riêng cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [IPPImage.replace_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ippimage/replace_image/). Đối với thương hiệu trên toàn bộ bản trình chiếu, việc đặt logo trên master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Một hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập từ máy tính khác, hình ảnh liên kết có thể không có sẵn. Nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**Có thể chỉnh sửa SVG đã chèn thành các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_group_shape/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm sao tôi có thể giữ bản trình chiếu với nhiều hình ảnh nhỏ hơn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh các nguồn raster quá lớn không cần thiết, nén các hình raster phù hợp khi cần, giữ các thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài là chấp nhận được.