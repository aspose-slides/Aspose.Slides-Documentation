---
title: Tạo Hình Thu Nhỏ cho Các Shape trong Bản Trình Chiếu bằng Python qua Java
linktitle: Hình Thu Nhỏ Shape
type: docs
weight: 70
url: /vi/python-java/create-shape-thumbnails/
keywords:
- hình thu nhỏ shape
- hình ảnh shape
- render shape
- kết xuất shape
- phạm vi trực quan
- phạm vi shape
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo các hình thu nhỏ shape chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho Python qua Java – dễ dàng tạo và xuất các hình thu nhỏ của bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Python via Java có thể được sử dụng để tạo các tệp thuyết trình, trong đó mỗi trang tương ứng với một slide. Các slide có thể được xem bằng cách mở tệp thuyết trình bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển cần xem hình ảnh của các shape riêng lẻ trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides for Python via Java giúp họ tạo ra các hình thu nhỏ của các shape trong slide.

Bài viết này giải thích cách tạo hình thu nhỏ của shape theo các cách khác nhau:

- Tạo hình thu nhỏ của shape bên trong một slide.
- Tạo hình thu nhỏ của shape cho một shape trong slide với kích thước do người dùng xác định.
- Tạo hình thu nhỏ của shape trong phạm vi hiển thị của shape.

## **Tạo hình thu nhỏ của shape từ một slide**
Để tạo hình thu nhỏ của shape từ bất kỳ slide nào bằng Aspose.Slides for Python via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide bằng ID hoặc chỉ mục của nó.
1. [Lấy hình ảnh thu nhỏ của shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) trên slide đã tham chiếu với tỉ lệ mặc định.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh mà bạn muốn.

Đoạn mã mẫu dưới đây cho bạn thấy cách tạo hình thu nhỏ của shape từ một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
presentation = Presentation("Thumbnail.pptx")
try:
    # Tạo ảnh ở tỷ lệ đầy đủ.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Lưu ảnh vào đĩa ở định dạng PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Tạo hình thu nhỏ với hệ số co dãn do người dùng xác định**
Để tạo hình thu nhỏ của shape trong một slide bằng Aspose.Slides for Python via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide bằng ID hoặc chỉ mục của nó.
1. [Lấy hình ảnh thu nhỏ của shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) trên slide đã tham chiếu với kích thước do người dùng xác định.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh mà bạn muốn.

Đoạn mã mẫu dưới đây cho bạn thấy cách tạo hình thu nhỏ của shape dựa trên hệ số co dãn đã định nghĩa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
presentation = Presentation("Thumbnail.pptx")
try:
    # Tạo ảnh được phóng to gấp 2 lần theo cả hai hướng.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Lưu ảnh vào đĩa ở định dạng PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Tạo hình thu nhỏ dựa trên phạm vi hiển thị của shape**
Phương pháp này cho phép các nhà phát triển tạo hình thu nhỏ trong phạm vi hiển thị của shape, tính đến tất cả các hiệu ứng của shape. Hình thu nhỏ của shape được giới hạn bởi phạm vi của slide. Để tạo hình thu nhỏ của một shape trong slide trong phạm vi hiển thị của nó, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của shape trên slide đã tham chiếu bằng phạm vi hiển thị của nó.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh mà bạn muốn.

Đoạn mã mẫu dựa trên các bước trên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
presentation = Presentation("Thumbnail.pptx")
try:
    # Tạo ảnh ở tỷ lệ đầy đủ.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Lưu ảnh vào đĩa ở định dạng PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Lấy phạm vi hiển thị thực tế của một shape**

Các thuộc tính khung của [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/)—các phương thức [getX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getWidth) và [getHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getHeight)—miêu tả hình chữ nhật được lưu trong mô hình thuyết trình. Nội dung thực tế được render có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật khác thẳng hàng trục. Việc xoay, viền, đầu mũi tên, bố cục và tràn nội dung văn bản, hình học SmartArt được tạo ra, và các hiệu ứng render khác đều có thể thay đổi khu vực chiếm dụng.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getVisualBounds) để tính toán khu vực chiếm dụng mà không cần tạo hình ảnh. Phương thức này trả về một [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể là số âm khi nội dung mở rộng ra ngoài gốc slide.

Ví dụ sau lấy và so sánh khung và phạm vi hiển thị:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Cùng một [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) có thể được dùng để căn chỉnh các shape lân cận sang trái, phải, trên hoặc dưới; dự trữ đủ không gian trong bố cục đã tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Phạm vi hiển thị đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, shape bị xoay và nhóm shape, nơi khung lưu trữ có thể không đại diện cho kết quả render đầy đủ.

Sử dụng [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getVisualBounds) khi bạn cần tọa độ cho việc bố cục hoặc xác thực và không cần bitmap. Sử dụng [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) khi bạn cần render shape. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapethumbnailbounds/#Shape) định kích thước ảnh dựa trên khung shape, bao gồm cài đặt viền, trong khi [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapethumbnailbounds/#Appearance) định kích thước dựa trên hiển thị của shape và giới hạn kết quả trong phạm vi slide. Ngược lại, [Shape.getVisualBounds](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getVisualBounds) chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể dùng khi lưu hình thu nhỏ của shape?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/), và các định dạng khác. Các shape cũng có thể được [xuất ra dạng vector SVG](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#writeAsSvgToBytes) bằng cách lưu nội dung shape dưới dạng SVG.

**Sự khác nhau giữa phạm vi Shape và Appearance khi render một hình thu nhỏ là gì?**

`Shape` sử dụng hình học của shape; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/python-java/shape-effect/) (bóng, ánh hào, v.v.).

**Nếu một shape được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn được render thành hình thu nhỏ không?**

Một shape ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu mà không ngăn việc tạo ảnh cho shape.

**Các shape nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/) và [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ của shape văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/python-java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/python-java/font-substitution/)) để tránh việc fallback không mong muốn và thay đổi bố cục văn bản.