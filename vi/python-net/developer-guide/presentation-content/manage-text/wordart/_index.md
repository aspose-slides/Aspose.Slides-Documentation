---
title: Tạo và Áp dụng các hiệu ứng WordArt trong Python
linktitle: WordArt
type: docs
weight: 110
url: /vi/python-net/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng đổ ngoài
- hiệu ứng bóng đổ trong
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Python thông qua .NET. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản chuyên nghiệp trong Python."
---
## **Tổng quan**

Các hiệu ứng WordArt cho phép bạn định dạng văn bản với các màu nền, đường viền, bóng đổ, phản chiếu, ánh hào quang, biến đổi và định dạng 3D. Bài viết này giải thích cách tạo và tùy chỉnh các hiệu ứng này trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides for Python via .NET, mà không cần cài đặt Microsoft Office.

## **Tạo mẫu WordArt đơn giản và áp dụng nó cho văn bản**

Các ví dụ sau tạo một kiểu WordArt đơn giản bằng cách thiết lập văn bản, phông chữ, mẫu nền và đường viền.

Mỗi ví dụ tạo một bản trình chiếu mới và thêm một hình chữ nhật vào slide đầu tiên; không cần tệp đầu vào. Ví dụ đầu tiên đặt văn bản là "Aspose.Slides". Vị trí và kích thước của hình được đo bằng điểm:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Đặt phông chữ thành Arial Black kích thước 36 điểm để định dạng dễ nhìn hơn:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Áp dụng mẫu [SMALL_GRID](https://reference.aspose.com/slides/vi/python-net/aspose.slides/patternstyle/) với màu nền trước màu cam đậm và nền trắng, sau đó thêm viền văn bản màu đen với độ rộng 1 điểm:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Văn bản kết quả:

![Mẫu WordArt đơn giản](WordArt_template.png)

## **Áp dụng các hiệu ứng WordArt khác**

Các ví dụ sau minh họa cách áp dụng bóng đổ, phản chiếu, ánh hào quang, biến đổi và hiệu ứng 3D cho văn bản.

### **Áp dụng hiệu ứng bóng đổ ngoài**

Hiệu ứng bóng đổ ngoài tạo độ sâu bằng cách đặt bóng phía sau văn bản. Bạn có thể tùy chỉnh màu, hướng, khoảng cách, bán kính làm mờ, tỉ lệ và độ nghiêng của nó.

Ví dụ này gọi [enable_outer_shadow_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) và đặt một bóng đen với bán kính làm mờ 4 điểm, hướng 230 độ và khoảng cách 30 điểm. Giá trị tỉ lệ 100 giữ nguyên kích thước bóng, trong khi độ nghiêng ngang nghiêng nó 20 độ. Biến đổi alpha đặt độ trong suốt của bóng ở mức 32%:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Văn bản kết quả:

![Hiệu ứng bóng đổ ngoài](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Khi bóng đổ ngoài và bóng đổ preset được sử dụng cùng nhau, chỉ bóng đổ ngoài được áp dụng.
- Nếu bóng đổ ngoài và bóng đổ trong được sử dụng đồng thời, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi, trong khi trong PowerPoint 2007, chỉ bóng đổ ngoài được áp dụng.
{{% /alert %}}

### **Áp dụng hiệu ứng phản chiếu**

Phản chiếu tạo một bản sao phản chiếu của văn bản. Điều chỉnh vị trí, tỉ lệ, làm mờ và độ trong suốt để kiểm soát giao diện của nó.

Ví dụ này gọi [enable_reflection_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/effectformat/enable_reflection_effect/) và lật phản chiếu theo chiều dọc với tỉ lệ -100%. Nó sử dụng bán kính làm mờ 0.5 điểm và khoảng cách 4.72 điểm. Độ trong suốt giảm từ 60% xuống 0.9% giữa các vị trí 0% và 60% dọc theo phản chiếu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Văn bản kết quả:

![Hiệu ứng phản chiếu](reflection_effect.png)

### **Áp dụng hiệu ứng hào quang**

Hào quang thêm một đường viền màu mềm xung quanh văn bản. Điều chỉnh màu, độ trong suốt và bán kính để kiểm soát hiệu ứng.

Ví dụ này gọi [enable_glow_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/effectformat/enable_glow_effect/) và áp dụng hào quang màu đỏ với độ trong suốt 54% và bán kính 7 điểm:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Văn bản kết quả:

![Hiệu ứng hào quang](glow_effect.png)

### **Áp dụng biến đổi WordArt**

Biến đổi WordArt uốn cong, kéo dài hoặc biến dạng một khối văn bản.

Đặt [transform](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/transform/) thành [ARCH_UP_POUR](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textshapetype/) để uốn cong toàn bộ khung văn bản lên trên:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Văn bản kết quả:

![Biến đổi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET cung cấp một tập hợp các [loại biến đổi](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textshapetype/) được định nghĩa trước.
{{% /alert %}}

### **Áp dụng hiệu ứng 3D cho hình dạng và văn bản**

Bạn có thể áp dụng hiệu ứng 3D cho một hình dạng hoặc cho văn bản của nó. Các góc cạnh (bevels), đùn (extrusion), chiếu sáng và cài đặt camera kiểm soát giao diện cuối cùng.

Ví dụ sau sử dụng [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/) để thêm các góc cạnh vòng tròn, đùn màu cam và viền đỏ đậm cho hình chữ nhật. Kích thước góc cạnh, chiều cao đùn, độ rộng viền và độ sâu được đo bằng điểm. Một vật liệu nhựa, ánh sáng cân bằng quay 40 độ quanh trục Z, và một camera phối cảnh xác định giao diện của nó:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Hình dạng kết quả:

![Hiệu ứng 3D cho hình dạng](shape_3D_effect.png)

Ví dụ này áp dụng định dạng 3D tương tự cho văn bản thông qua [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/). Các góc cạnh nhỏ hơn tạo hình cho các mép chữ, trong khi đùn và ánh sáng tạo độ sâu cho văn bản:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Văn bản kết quả:

![Hiệu ứng 3D cho văn bản](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Việc áp dụng hiệu ứng 3D cho văn bản hoặc các hình dạng của chúng—và sự tương tác giữa các hiệu ứng này—được điều chỉnh bởi các quy tắc cụ thể. Xem xét một cảnh bao gồm cả văn bản và hình dạng chứa nó. Một hiệu ứng 3D bao gồm mô hình 3D của đối tượng và cảnh mà nó được đặt.

- Nếu một cảnh được đặt cho cả hình dạng và văn bản, cảnh của hình dạng được ưu tiên và cảnh của văn bản bị bỏ qua.
- Nếu hình dạng không có cảnh riêng nhưng có mô hình 3D, thì sẽ sử dụng cảnh của văn bản.
- Nếu hình dạng không có hiệu ứng 3D nào, nó được coi là phẳng, và hiệu ứng 3D chỉ được áp dụng cho văn bản.

These behaviors relate to the [ThreeDFormat.light_rig](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/light_rig/) and [ThreeDFormat.camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/camera/) properties.
{{% /alert %}}

Để giữ văn bản phẳng và dễ đọc trong khi vẫn giữ định dạng 3D của hình dạng, xem [Giữ Văn Bản Phẳng trên Hình 3D](/slides/vi/python-net/3d-presentation/) để so sánh cả hai cài đặt và một ví dụ Python đầy đủ.

## **Câu hỏi thường gặp**

**Có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc chữ viết khác nhau (ví dụ: Ả Rập, Trung Quốc) không?**

Có, Aspose.Slides for Python via .NET hỗ trợ Unicode và hoạt động với tất cả các phông chữ và chữ viết chính. Các hiệu ứng WordArt như bóng đổ, màu nền và đường viền có thể được áp dụng bất kể ngôn ngữ, mặc dù khả năng sẵn có của phông chữ và việc hiển thị có thể phụ thuộc vào phông chữ hệ thống.

**Có thể áp dụng hiệu ứng WordArt cho các yếu tố master slide không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các trình giữ chỗ tiêu đề, chân trang hoặc văn bản nền. Các thay đổi được thực hiện trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến kích thước tệp bản trình chiếu không?**

Hơi có. Các hiệu ứng WordArt như bóng đổ, hào quang và màu nền gradient có thể làm tăng nhẹ kích thước tệp do thêm dữ liệu định dạng, nhưng sự khác biệt thường không đáng kể.

**Có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản trình chiếu không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng cách sử dụng [Slide.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/), hoặc render các hình dạng riêng lẻ bằng [Shape.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình chiếu đầy đủ.