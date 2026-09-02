---
title: Quản lý Placeholder cho Bản trình chiếu trong Python
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/python-net/manage-placeholder/
keywords:
  - trình giữ chỗ
  - trình giữ chỗ văn bản
  - trình giữ chỗ hình ảnh
  - trình giữ chỗ biểu đồ
  - trình giữ chỗ nội dung
  - văn bản nhắc
  - PowerPoint
  - bản trình chiếu
  - Python
  - Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, và hiểu về kế thừa placeholder với Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

Một placeholder là một hình dạng dự trữ vị trí cho một loại nội dung cụ thể trong mẫu bản trình bày. Các ví dụ phổ biến bao gồm placeholder tiêu đề, thân, hình ảnh, biểu đồ và placeholder nội dung đa mục đích. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ một slide bố cục hoặc slide chủ.

Aspose.Slides cung cấp thông tin placeholder thông qua thuộc tính [Shape.placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/placeholder/). Thuộc tính trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholder/) hoặc `None` cho một hình dạng bình thường. Sử dụng [Placeholder.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholder/type/) để xác định placeholder dự kiến chứa gì.

Lớp hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholder/type/) và lớp hình dạng tại thời gian chạy thay vì giả định rằng mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholder/type/) mô tả vai trò của một placeholder; nó không đảm bảo lớp hình dạng tại thời gian chạy. Luôn luôn thực hiện kiểm tra kiểu trước khi truy cập các thành viên đặc thù cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholders tạo thành một hệ thống phân cấp:

1. Một slide chủ định nghĩa các kiểu dùng lại và, trong một số trường hợp, các placeholder ở mức master.
2. Một slide bố cục định nghĩa cách sắp xếp được sử dụng bởi một hoặc nhiều slide bình thường và có thể kế thừa từ slide chủ.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [Shape.get_base_placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_base_placeholder/) để di chuyển lên một cấp trong hệ thống này. Một placeholder slide thường trả về placeholder của bố cục; một placeholder bố cục có thể trả về placeholder của slide chủ. Phương thức trả về `None` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Việc chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Việc chỉnh sửa bố cục hoặc slide chủ liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay đổi văn bản trong Placeholder**

Placeholder tiêu đề, tiêu đề trung tâm, phụ đề, thân và văn bản thường hỗ trợ văn bản. Kiểm tra [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) trước khi sử dụng thuộc tính [text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/text_frame/) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Mẫu này tránh việc xử lý các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện như các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào một chỉ mục hình dạng dễ bị phá vỡ.

## **Đặt văn bản nhắc trên Layout**

Văn bản nhắc là chỉ dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Nhấn vào để thêm tiêu đề*. Đặt văn bản nhắc tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout thông qua [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/) và duyệt qua [LayoutSlide.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/shapes/).

Ví dụ sau thay đổi nhắc tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Văn bản nhắc không phải là nội dung slide bình thường. Nó được dự định cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, văn bản nhắc sẽ không còn hiển thị. Thay đổi nhắc cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Picture Placeholder**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/), thay thế hình ảnh qua [PictureFillFormat.picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/picture/) và [Picture.image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picture/image/).
- Nếu vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) và loại bỏ placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình bày:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape.placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/placeholder/) là chỉ đọc. Nó giữ vị trí dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc duy trì mối quan hệ placeholder là cần thiết, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù của hình ảnh, xem [Manage Picture Frames](/slides/vi/python-net/picture-frame/). Các thao tác này thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Chart và Content Placeholder**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và lớp runtime, thay đổi tiêu đề và lưu tập tin:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Một placeholder nội dung chung thường có [PlaceholderType.OBJECT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một công cụ khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra lớp hình dạng thực tế để biết nó chứa gì. Các layout chuyên dụng cũng có thể hiển thị [PlaceholderType.CHART](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/), hoặc [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder AutoShape trống thành một [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/) chỉ bằng cách thay đổi [Placeholder.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/placeholder/type/); kiểu này chỉ đọc. Để điền một biểu đồ hoặc khu vực nội dung trống bằng lập trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó loại bỏ placeholder trống. Ví dụ sau thực hiện việc này cho một biểu đồ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm khu vực của placeholder nhưng không kế thừa từ placeholder của layout. Sử dụng các bài viết quản lý biểu đồ chuyên biệt [/slides/vi/python-net/powerpoint-charts/] khi cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ hoàn chỉnh: Cập nhật nội dung Văn bản hoặc Hình ảnh**

Ví dụ end‑to‑end dưới đây mở một mẫu, tìm kiếm slide đầu tiên để phát hiện placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố ý tránh giả định chỉ số hình dạng hoặc xử lý mọi placeholder như cùng một lớp hình dạng.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [Shape.get_base_placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_base_placeholder/) để lấy nó. Một hình dạng cục bộ bình thường trả về `None` vì nó không thuộc cấu trúc placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder trong layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản nhắc thông qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình bày, hãy duyệt các slide và cập nhật từng placeholder tiêu đề.

**Làm thế nào để quản lý các placeholder ngày, số slide, header và footer?**

Sử dụng các trình quản lý header và footer tại phạm vi slide, layout, master, notes hoặc handout thích hợp. Xem [Manage Presentation Header and Footer](/slides/vi/python-net/presentation-header-and-footer/) để có các ví dụ đầy đủ.