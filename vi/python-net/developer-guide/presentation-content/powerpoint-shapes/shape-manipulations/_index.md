---
title: Quản lý hình dạng trong bản trình chiếu bằng Python
linktitle: Thao tác hình dạng
type: docs
weight: 40
url: /vi/python-net/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng Interop
- văn bản thay thế cho hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng sang SVG
- căn chỉnh hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo, chỉnh sửa và tối ưu hóa các hình dạng trong Aspose.Slides cho Python thông qua .NET và cung cấp các bản trình chiếu PowerPoint và OpenDocument hiệu năng cao."
---
## **Tổng quan**

Hướng dẫn này giới thiệu việc thao tác hình dạng trong Aspose.Slides cho Python thông qua .NET. Học các mẫu thực tế để tìm hình dạng (kể cả bằng Văn bản thay thế), sao chép, xóa hoặc ẩn, sắp xếp lại, căn chỉnh và lật, đọc ID và định dạng dựa trên bố cục, và xuất từng hình dạng ra SVG bằng các API [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/).

## **Tìm hình dạng trên các slide**

PowerPoint chỉ xác định hình dạng bằng ID nội bộ. Gán Văn bản thay thế duy nhất cho hình dạng mục tiêu trong PowerPoint, sau đó mở bản trình chiếu bằng Aspose.Slides cho Python, duyệt qua các hình dạng trên slide và chọn hình dạng có Văn bản thay thế khớp. Phương pháp `find_shape` thực hiện cách tiếp cận này và trả về hình dạng phù hợp.

```py
import aspose.slides as slides

# Tìm một hình dạng trên slide bằng văn bản thay thế của nó.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Tìm hình dạng có Văn bản thay thế "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Sao chép hình dạng**

Để sao chép hình dạng từ slide nguồn sang slide mới trong Aspose.Slides, thực hiện các bước sau:

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) từ tệp nguồn.  
1. Lấy slide nguồn theo chỉ mục và bộ sưu tập hình dạng của nó.  
1. Lấy bố cục trống từ slide chủ.  
1. Thêm một slide trống sử dụng bố cục đó và lấy bộ hình dạng của nó.  
1. Sao chép các hình dạng vào slide đích.  
1. Lưu bản trình chiếu dưới dạng PPTX.

Ví dụ mã sau sao chép hình dạng từ slide này sang slide khác.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Lưu bản trình chiếu ra đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa hình dạng**

Aspose.Slides cho phép bạn xóa bất kỳ hình dạng nào khỏi một slide. Ví dụ, để xóa một hình dạng ở slide đầu tiên bằng Văn bản thay thế của nó, thực hiện các bước sau:

1. Tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải tệp.  
1. Truy cập slide đầu tiên trong bộ sưu tập slide.  
1. Tìm hình dạng bằng giá trị Văn bản thay thế.  
1. Xóa hình dạng khỏi bộ sưu tập hình dạng của slide.  
1. Lưu bản trình chiếu ra đĩa ở định dạng PPTX.

```py
import aspose.slides as slides

# Tìm một hình dạng trên slide bằng văn bản thay thế của nó.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Tìm hình dạng có Văn bản thay thế "User Defined".
    shape = find_shape(slide, "User Defined")
    # Xóa hình dạng.
    slide.shapes.remove(shape)
    # Lưu bản trình chiếu ra đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ẩn hình dạng**

Aspose.Slides cho phép bạn ẩn bất kỳ hình dạng nào trên slide. Ví dụ, để ẩn một hình dạng trên slide đầu tiên bằng Văn bản thay thế, thực hiện các bước sau:

1. Tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải tệp.  
1. Truy cập slide đầu tiên trong bộ sưu tập slide.  
1. Tìm hình dạng bằng giá trị Văn bản thay thế.  
1. Ẩn hình dạng.  
1. Lưu bản trình chiếu ra đĩa ở định dạng PPTX.

```py
# Tìm một hình dạng trên slide bằng văn bản thay thế của nó.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Tìm hình dạng có Văn bản thay thế "User Defined".
    shape = find_shape(slide, "User Defined")
    # Ẩn hình dạng.
    shape.hidden = True
    # Lưu bản trình chiếu ra đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay đổi thứ tự của các hình dạng**

Aspose.Slides cho phép các nhà phát triển sắp xếp lại các hình dạng (thay đổi thứ tự z). Việc sắp xếp lại quyết định hình dạng nào xuất hiện phía trước hoặc phía sau. Ví dụ, để sắp xếp lại hai hình dạng trên slide đầu tiên, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).  
1. Truy cập slide đầu tiên.  
1. Thêm hình dạng đầu tiên (ví dụ: một hình chữ nhật).  
1. Thêm hình dạng thứ hai (ví dụ: một hình tam giác).  
1. Sắp xếp lại các hình dạng bằng cách di chuyển hình dạng thứ hai lên vị trí đầu tiên trong bộ sưu tập.  
1. Lưu bản trình chiếu ra đĩa.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Thêm hai hình dạng vào slide.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Di chuyển hình dạng thứ hai lên vị trí đầu tiên.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy ID Interop của hình dạng**

Aspose.Slides cho phép bạn lấy mã định danh duy nhất của một hình dạng ở cấp slide, khác với thuộc tính `unique_id` chỉ duy nhất trên toàn bộ bản trình chiếu. Thuộc tính `office_interop_shape_id` có trên lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/). Giá trị của nó tương ứng với `Id` của đối tượng `Microsoft.Office.Interop.PowerPoint.Shape`. Đoạn mã mẫu được hiển thị bên dưới.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Lấy định danh duy nhất của hình dạng trong slide.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Đặt Văn bản thay thế cho hình dạng**

Aspose.Slides cho phép các nhà phát triển đặt văn bản thay thế cho bất kỳ hình dạng nào. Bạn có thể sử dụng văn bản thay thế để xác định và định vị hình dạng trong bản trình chiếu. Thuộc tính văn bản thay thế có thể đọc và ghi thông qua cả Aspose.Slides và Microsoft PowerPoint. Bằng cách gắn thẻ các hình dạng với thuộc tính này, bạn có thể sau này xóa, ẩn hoặc sắp xếp lại chúng trên một slide.

Để đặt văn bản thay thế cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).  
1. Truy cập slide đầu tiên.  
1. Thêm một hình dạng vào slide.  
1. Đặt văn bản thay thế.  
1. Lưu bản trình chiếu ra đĩa.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Thêm một hình dạng.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Đặt văn bản thay thế cho hình dạng.
    shape.alternative_text = "User Defined"
    # Lưu bản trình chiếu ra đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Định dạng Bố cục cho các hình dạng**

Aspose.Slides cung cấp API đơn giản để truy cập định dạng bố cục cho các hình dạng. Phần này minh họa cách truy cập định dạng bố cục.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Kết xuất hình dạng dưới dạng SVG**

Aspose.Slides hỗ trợ kết xuất các hình dạng dưới dạng SVG. Phương thức `write_as_svg` (và các overload của nó) trên lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) cho phép bạn lưu nội dung của một hình dạng dưới dạng ảnh SVG. Đoạn mã dưới đây cho thấy cách xuất một hình dạng ra tệp SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Lấy hình dạng đầu tiên trên slide đầu tiên.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Căn chỉnh hình dạng**

Sử dụng phương thức `align_shape` trong lớp [SlidesUtil](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/), bạn có thể:

* Căn chỉnh các hình dạng tương đối với lề của slide (xem Ví dụ 1).  
* Căn chỉnh các hình dạng tương đối với nhau (xem Ví dụ 2).

Kiểu liệt kê [ShapesAlignmentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapesalignmenttype/) định nghĩa các tùy chọn căn chỉnh có sẵn.

**Ví dụ 1**

Mã Python này cho thấy cách căn chỉnh các hình dạng có chỉ số 1, 2 và 4 với mép trên của slide:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Ví dụ 2**

Ví dụ Python này cho thấy cách căn chỉnh tất cả các hình dạng trong một bộ sưu tập tương đối với hình dạng thấp nhất trong bộ sưu tập đó:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeframe/) cung cấp khả năng kiểm soát việc lật ngang và dọc của các hình dạng thông qua các thuộc tính `flip_h` và `flip_v`. Cả hai thuộc tính đều có kiểu [NullableBool](https://reference.aspose.com/slides/vi/python-net/aspose.slides/nullablebool/), cho phép giá trị `TRUE` để lật, `FALSE` để không lật, hoặc `NOT_DEFINED` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/frame/) của một hình dạng.

Để sửa đổi cài đặt lật, một thể hiện mới của [ShapeFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeframe/) được xây dựng bằng vị trí và kích thước hiện tại của hình dạng, các giá trị mong muốn cho `flip_h` và `flip_v`, và góc quay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/frame/) của hình dạng và lưu bản trình chiếu sẽ áp dụng các biến đổi phản chiếu và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình dạng duy nhất với cài đặt lật mặc định, như hình dưới đây.

![The shape to be flipped](shape_to_be_flipped.png)

Đoạn mã sau lấy các thuộc tính lật hiện tại của hình dạng và lật nó cả ngang lẫn dọc.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Lấy thuộc tính lật ngang của hình dạng.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Lấy thuộc tính lật dọc của hình dạng.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Lật ngang và dọc.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Tôi có thể kết hợp các hình dạng (union/intersect/subtract) trên một slide như trong trình chỉnh sửa trên máy tính để bàn không?**

Hiện không có API phép toán Boolean tích hợp. Bạn có thể gần đúng bằng cách tự xây dựng đường viền mong muốn—ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/)) và tạo một hình dạng mới với contour đó, tùy chọn xóa các hình dạng gốc.

**Làm sao tôi kiểm soát thứ tự xếp chồng (z-order) để một hình dạng luôn ở “trên cùng”?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/shapes/) của slide. Để có kết quả dự đoán được, hãy hoàn thiện z-order sau khi thực hiện tất cả các sửa đổi khác trên slide.

**Tôi có thể “khóa” một hình dạng để ngăn người dùng chỉnh sửa nó trong PowerPoint không?**

Có. Đặt các cờ bảo vệ mức hình dạng [/slides/vi/python-net/applying-protection-to-presentation/](#) (ví dụ: khóa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, cũng có thể áp dụng hạn chế trên master hoặc layout. Lưu ý đây là bảo vệ ở mức giao diện người dùng, không phải tính năng bảo mật; để bảo vệ mạnh hơn, kết hợp với các hạn chế ở mức tệp như đề xuất chỉ đọc hoặc mật khẩu [/slides/vi/python-net/password-protected-presentation/](#).