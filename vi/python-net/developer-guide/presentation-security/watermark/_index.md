---
title: Thêm Watermark vào Bản Trình Chiếu trong Python
linktitle: Watermark
type: docs
weight: 40
url: /vi/python-net/watermark/
keywords:
- dấu watermark
- dấu watermark văn bản
- dấu watermark hình ảnh
- thêm dấu watermark
- thay đổi dấu watermark
- xóa dấu watermark
- xoá dấu watermark
- thêm dấu watermark vào PPT
- thêm dấu watermark vào PPTX
- thêm dấu watermark vào ODP
- xóa dấu watermark khỏi PPT
- xóa dấu watermark khỏi PPTX
- xóa dấu watermark khỏi ODP
- xoá dấu watermark khỏi PPT
- xoá dấu watermark khỏi PPTX
- xoá dấu watermark khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý các dấu watermark văn bản và hình ảnh trong bản trình chiếu PowerPoint và OpenDocument bằng Python để chỉ ra bản nháp, thông tin bảo mật, bản quyền và nhiều hơn nữa."
---
## **Giới thiệu**

**Một dấu watermar​k** trong một bản trình chiếu là một dấu văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, watermar​k được dùng để chỉ rằng bản trình chiếu là bản nháp (ví dụ: watermar​k “Draft”), chứa thông tin mật (ví dụ: watermar​k “Confidential”), chỉ ra công ty sở hữu (ví dụ: watermar​k “Tên Công Ty”), xác định tác giả của bản trình chiếu, v.v. Watermar​k giúp ngăn chặn vi phạm bản quyền bằng cách cho biết bản trình chiếu không nên được sao chép. Watermar​k được sử dụng trong cả định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermar​k vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/python-net/), có nhiều cách để tạo watermar​k trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermar​k dạng văn bản, bạn nên sử dụng lớp [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), và để thêm watermar​k dạng hình ảnh, dùng lớp [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) hoặc lấp đầy một hình watermar​k bằng hình ảnh. `PictureFrame` triển khai lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), cho phép bạn sử dụng mọi thiết lập linh hoạt của đối tượng shape. Vì `TextFrame` không phải là shape và các thiết lập của nó bị giới hạn, nên nó được đóng gói trong một đối tượng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/).

Có hai cách áp dụng watermar​k: cho một slide riêng lẻ hoặc cho tất cả các slide của bản trình chiếu. Slide Master được dùng để áp dụng watermar​k cho toàn bộ slide — watermar​k được thêm vào Slide Master, thiết kế hoàn toàn ở đó và được áp dụng cho mọi slide mà không ảnh hưởng đến quyền chỉnh sửa watermar​k trên các slide riêng lẻ.

Watermar​k thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermar​k (hoặc chứ thực là shape cha của watermar​k) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể bị khóa trên slide thường hoặc trên Slide Master. Khi shape watermar​k bị khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho watermar​k để trong tương lai, nếu muốn xóa, bạn có thể tìm nó trong danh sách shapes của slide bằng tên.

Bạn có thể thiết kế watermar​k theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, vị trí phía trước, v.v. Chúng ta sẽ xem cách sử dụng các đặc điểm này trong các ví dụ dưới đây.

## **Watermar​k Văn Bản**

### **Thêm Watermar​k Văn Bản vào Một Slide**

Để thêm watermar​k văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một khung văn bản vào shape này. Khung văn bản được đại diện bằng lớp [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/). Kiểu này không kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), lớp có một bộ thuộc tính rộng để định vị watermar​k một cách linh hoạt. Do đó, đối tượng [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) được đóng gói trong một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Để thêm văn bản watermar​k vào shape, sử dụng phương pháp [add_text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/add_text_frame/#str) như dưới đây.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Lớp TextFrame](/slides/vi/python-net/text-formatting/)
{{% /alert %}}

### **Thêm Watermar​k Văn Bản vào Toàn Bộ Bản Trình Chiếu**

Nếu bạn muốn thêm watermar​k văn bản vào toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/). Phần còn lại của logic giống như khi thêm watermar​k vào một slide riêng lẻ — tạo một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và sau đó thêm watermar​k vào nó bằng phương pháp [add_text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Slide Master](/slides/vi/python-net/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suốt cho Shape Watermar​k**

Mặc định, shape hình chữ nhật được định kiểu bằng màu nền và màu viền. Các dòng mã sau làm cho shape trong suốt.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Đặt Phông Chữ cho Watermar​k Văn Bản**

Bạn có thể thay đổi phông chữ của watermar​k văn bản như dưới đây.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Đặt Màu Văn Bản Watermar​k**

Để đặt màu cho văn bản watermar​k, sử dụng đoạn mã này:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Căn Giữa Watermar​k Văn Bản**

Bạn có thể căn giữa watermar​k trên slide, và để làm điều đó, thực hiện như sau:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

Hình ảnh bên dưới cho thấy kết quả cuối cùng.

![Watermar​k văn bản](text_watermark.png)

## **Watermar​k Hình Ảnh**

### **Thêm Watermar​k Hình Ảnh vào Bản Trình Chiếu**

Để thêm watermar​k hình ảnh vào một slide của bản trình chiếu, bạn có thể thực hiện như sau:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Khóa Watermar​k Không Được Chỉnh Sửa**

Nếu cần ngăn watermar​k bị chỉnh sửa, sử dụng thuộc tính [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/auto_shape_lock/) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các phần tử khác, khóa văn bản khỏi chỉnh sửa và nhiều hơn nữa:

```py
# Khóa shape watermark khỏi việc chỉnh sửa
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Đưa Watermar​k Lên Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương pháp [ShapeCollection.reorder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Để thực hiện, bạn cần gọi phương pháp này từ danh sách các slide của bản trình chiếu và truyền tham chiếu shape cùng số thứ tự vào phương pháp. Bằng cách này, bạn có thể đưa một shape lên phía trước hoặc đưa nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi bạn cần đặt watermar​k ở phía trước bản trình chiếu:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Đặt Góc Xoay cho Watermar​k**

Dưới đây là ví dụ mã về cách điều chỉnh góc xoay của watermar​k sao cho nó được đặt chéo trên slide:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Đặt Tên cho Watermar​k**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để chỉnh sửa hoặc xóa. Để đặt tên cho shape watermar​k, gán nó cho thuộc tính [AutoShape.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Xóa Watermar​k**

Để xóa shape watermar​k, sử dụng phương pháp [AutoShape.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/name/) để tìm nó trong danh sách shapes của slide. Sau đó, truyền shape watermar​k vào phương pháp [ShapeCollection.remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ví Dụ Thực Tế**

Bạn có thể thử công cụ **Aspose.Slides miễn phí** [Thêm Watermar​k](https://products.aspose.app/slides/vi/watermark) và [Xóa Watermar​k](https://products.aspose.app/slides/vi/watermark/remove-watermark) trực tuyến.

![Công cụ trực tuyến để thêm và xóa watermar​k](online_tools.png)

## **Câu Hỏi Thường Gặp**

**Watermar​k là gì và tại sao tôi nên sử dụng?**

Watermar​k là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide giúp bảo vệ sở hữu trí tuệ, tăng nhận diện thương hiệu hoặc ngăn việc sử dụng trái phép bản trình chiếu.

**Tôi có thể thêm watermar​k vào tất cả các slide trong một bản trình chiếu không?**

Có, Aspose.Slides cho phép bạn thêm watermar​k vào mọi slide của bản trình chiếu. Bạn có thể lặp qua tất cả các slide và áp dụng các cài đặt watermar​k cho từng slide.

**Làm thế nào để điều chỉnh độ trong suốt của watermar​k?**

Bạn có thể điều chỉnh độ trong suốt của watermar​k bằng cách sửa các cài đặt lấp đầy ([FillFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/)) của shape. Điều này giúp watermar​k nhẹ nhàng và không làm phân tán sự chú ý khỏi nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho watermar​k?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và các định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermar​k văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế bản trình chiếu và duy trì tính nhất quán thương hiệu.

**Làm sao để thay đổi vị trí hoặc hướng của watermar​k?**

Bạn có thể điều chỉnh vị trí và hướng của watermar​k bằng cách sửa các thuộc tính tọa độ, kích thước và góc xoay của [shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/).