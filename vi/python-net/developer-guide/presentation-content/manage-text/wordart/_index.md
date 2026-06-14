---
title: Tạo và Áp dụng Hiệu ứng WordArt trong Python
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
- hiệu ứng hiển thị
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng đổ ngoài
- hiệu ứng bóng đổ trong
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và tuỳ chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Python qua .NET. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản phong cách, chuyên nghiệp trong Python."
---
## **Tổng quan**

Các hiệu ứng WordArt cho phép bạn thêm văn bản có kiểu dáng hấp dẫn và thu hút vào bản trình bày PowerPoint của mình. Với Aspose.Slides, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình, giống như trong Microsoft PowerPoint—mà không cần cài đặt Office. Bài viết này cung cấp tổng quan về cách làm việc với WordArt, bao gồm cách áp dụng các biến đổi văn bản, kiểu tô màu, viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bản trình bày của bạn trở nên sinh động và hấp dẫn hơn. WordArt cho phép bạn xử lý văn bản như một đối tượng đồ họa. Nó gồm các hiệu ứng hoặc chỉnh sửa đặc biệt được áp dụng lên văn bản để làm cho nó bắt mắt hơn.

**WordArt trong Microsoft PowerPoint**

Để sử dụng WordArt trong Microsoft PowerPoint, bạn phải chọn một trong các mẫu WordArt được định trước. Một mẫu WordArt là một tập hợp các hiệu ứng được áp dụng vào một đoạn văn bản hoặc hình dạng của nó.

**WordArt trong Aspose.Slides**

Trong Aspose.Slides cho Python qua .NET 20.10, chúng tôi đã triển khai hỗ trợ WordArt và thực hiện các cải tiến cho tính năng này trong các phiên bản Aspose.Slides cho Python qua .NET tiếp theo. Với Aspose.Slides cho Python qua .NET, bạn có thể dễ dàng tạo mẫu WordArt của riêng mình (một hiệu ứng hoặc kết hợp các hiệu ứng) trong Python và áp dụng nó cho các đoạn văn bản.

## Tạo mẫu WordArt đơn giản và áp dụng nó vào một đoạn văn bản

**Sử dụng Aspose.Slides** 

Đầu tiên, chúng ta tạo một đoạn văn bản đơn giản bằng mã Python sau: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Tiếp theo, chúng ta đặt chiều cao phông chữ của đoạn văn bản lớn hơn để hiệu ứng trở nên rõ hơn bằng đoạn mã sau:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Sử dụng Microsoft PowerPoint**

Mở menu hiệu ứng WordArt trong Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Từ menu bên phải, bạn có thể chọn một hiệu ứng WordArt đã được định trước. Từ menu bên trái, bạn có thể chỉ định các cài đặt cho một WordArt mới.  

Đây là một số tham số hoặc tùy chọn có sẵn:

![todo:image_alt_text](image-20200930114015-3.png)

**Sử dụng Aspose.Slides**

Ở đây, chúng ta áp dụng màu mẫu SmallGrid cho đoạn văn bản và thêm một viền văn bản đen độ rộng 1 bằng đoạn mã sau:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Văn bản kết quả:

![todo:image_alt_text](image-20200930114108-4.png)

## Áp dụng các hiệu ứng WordArt khác

**Sử dụng Microsoft PowerPoint**

Từ giao diện của chương trình, bạn có thể áp dụng các hiệu ứng này vào văn bản, khối văn bản, hình dạng hoặc yếu tố tương tự:

![todo:image_alt_text](image-20200930114129-5.png)

Ví dụ, các hiệu ứng Shadow, Reflection và Glow có thể được áp dụng cho văn bản; các hiệu ứng 3D Format và 3D Rotation có thể được áp dụng cho khối văn bản; thuộc tính Soft Edges có thể được áp dụng cho đối tượng Shape (nó vẫn có hiệu ứng ngay cả khi không đặt thuộc tính 3D Format).

### Áp dụng hiệu ứng bóng đổ

Ở đây, chúng ta chỉ định các thuộc tính liên quan đến một đoạn văn bản. Chúng ta áp dụng hiệu ứng bóng đổ cho văn bản bằng đoạn mã Python sau:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides hỗ trợ ba loại bóng đổ: OuterShadow, InnerShadow và PresetShadow.  
Với PresetShadow, bạn có thể áp dụng bóng đổ cho văn bản (sử dụng các giá trị và sẵn có).

**Sử dụng Microsoft PowerPoint**

Trong PowerPoint, bạn có thể sử dụng một loại bóng đổ. Đây là một ví dụ:

![todo:image_alt_text](image-20200930114225-6.png)

**Sử dụng Aspose.Slides**

Aspose.Slides thực tế cho phép bạn áp dụng hai loại bóng đổ cùng lúc: InnerShadow và PresetShadow.

**Lưu ý:**

- Khi OuterShadow và PresetShadow được sử dụng cùng nhau, chỉ hiệu ứng OuterShadow được áp dụng.  
- Nếu OuterShadow và InnerShadow được sử dụng đồng thời, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi. Nhưng trong PowerPoint 2007, hiệu ứng OuterShadow được áp dụng.

### Áp dụng hiệu ứng Display cho văn bản

Chúng tôi thêm hiệu ứng Display vào văn bản bằng mẫu mã Python sau:

```py 
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

### Áp dụng hiệu ứng Glow cho văn bản

Chúng tôi áp dụng hiệu ứng Glow cho văn bản để làm cho nó sáng hoặc nổi bật bằng đoạn mã sau:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Bạn có thể thay đổi các tham số cho bóng đổ, Display và Glow. Các thuộc tính của hiệu ứng được đặt riêng biệt cho từng phần của văn bản.
{{% /alert %}} 

### Sử dụng biến đổi trong WordArt

Chúng tôi sử dụng thuộc tính Transform (áp dụng cho toàn bộ khối văn bản) bằng đoạn mã sau:

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Kết quả:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Cả Microsoft PowerPoint và Aspose.Slides cho Python qua .NET đều cung cấp một số loại biến đổi được định trước.
{{% /alert %}} 

**Sử dụng PowerPoint**

Để truy cập các loại biến đổi được định trước, thực hiện: **Format** -> **TextEffect** -> **Transform**

**Sử dụng Aspose.Slides**

Để chọn một loại biến đổi, sử dụng enum TextShapeType.

### Áp dụng hiệu ứng 3D cho Văn bản và Hình dạng

Chúng tôi đặt hiệu ứng 3D cho một hình dạng văn bản bằng mẫu mã sau:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Văn bản và hình dạng kết quả:

![todo:image_alt_text](image-20200930114816-9.png)

Chúng tôi áp dụng hiệu ứng 3D cho văn bản bằng đoạn mã Python sau:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Việc áp dụng các hiệu ứng 3D cho văn bản hoặc hình dạng của chúng và cách các hiệu ứng tương tác dựa trên một số quy tắc.

Hãy xem xét một cảnh cho một đoạn văn bản và hình dạng chứa đoạn văn bản đó. Hiệu ứng 3D bao gồm biểu diễn đối tượng 3D và cảnh mà đối tượng được đặt vào.

- Khi cảnh được thiết lập cho cả hình và văn bản, cảnh của hình được ưu tiên cao hơn—cảnh của văn bản bị bỏ qua.  
- Khi hình không có cảnh riêng nhưng có biểu diễn 3D, thì sẽ sử dụng cảnh của văn bản.  
- Ngược lại—khi hình ban đầu không có hiệu ứng 3D—hình sẽ phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các mô tả này liên quan đến các thuộc tính [ThreeDFormat.LightRig](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/) và [ThreeDFormat.Camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/).
{{% /alert %}} 

## **Áp dụng hiệu ứng Outer Shadow cho Văn bản**
Aspose.Slides cho Python qua .NET cung cấp các lớp [**IOuterShadow**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/ioutershadow/) và [**IInnerShadow**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/iinnershadow/) cho phép bạn áp dụng hiệu ứng bóng đổ vào văn bản được chứa trong TextFrame. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).  
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.  
3. Thêm một AutoShape loại Rectangle vào slide.  
4. Truy cập TextFrame liên kết với AutoShape.  
5. Đặt FillType của AutoShape thành NoFill.  
6. Khởi tạo lớp OuterShadow  
7. Đặt BlurRadius cho bóng đổ.  
8. Đặt Direction cho bóng đổ  
9. Đặt Distance cho bóng đổ.  
10. Đặt RectanglelAlign thành TopLeft.  
11. Đặt PresetColor của bóng đổ thành Black.  
12. Lưu bản trình chiếu dưới dạng tệp PPTX.

Mã mẫu này trong Python—một triển khai các bước trên—cho bạn thấy cách áp dụng hiệu ứng outer shadow cho một đoạn văn bản:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Lấy tham chiếu của slide
    sld = pres.slides[0]

    # Thêm một AutoShape loại Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Thêm TextFrame vào hình Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Tắt việc tô màu cho hình dạng trong trường hợp muốn lấy bóng đổ của văn bản
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Thêm bóng đổ ngoài và đặt tất cả các tham số cần thiết
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Ghi bản trình chiếu ra đĩa
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Áp dụng hiệu ứng Inner Shadow cho Hình dạng**
Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).  
2. Lấy tham chiếu của slide.  
3. Thêm một AutoShape loại Rectangle.  
4. Bật InnerShadowEffect.  
5. Đặt tất cả các tham số cần thiết.  
6. Đặt ColorType là Scheme.  
7. Đặt Scheme Color.  
8. Lưu bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).

Mã mẫu này (dựa trên các bước trên) cho bạn thấy cách thêm một connector giữa hai hình dạng trong Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Lấy tham chiếu của một slide
    slide = presentation.slides[0]

    # Thêm một AutoShape loại Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Thêm TextFrame vào Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Bật inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Đặt tất cả các tham số cần thiết
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Đặt ColorType là Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Đặt Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Lưu bản trình chiếu
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc script khác nhau (ví dụ: Arabic, Chinese) không?**

Có, Aspose.Slides hỗ trợ Unicode và hoạt động với mọi phông chữ và script chính. Các hiệu ứng WordArt như bóng đổ, tô màu và viền có thể được áp dụng bất kể ngôn ngữ, dù việc có sẵn phông chữ và việc render có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt lên các yếu tố của slide master không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên slide master, bao gồm các placeholder tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Các hiệu ứng WordArt ảnh hưởng đến kích thước tệp của bản trình chiếu không?**

Một chút. Các hiệu ứng WordArt như bóng đổ, glow và tô màu gradient có thể làm tăng nhẹ kích thước tệp do siêu dữ liệu định dạng được thêm vào, nhưng sự chênh lệch thường không đáng kể.

**Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản trình chiếu không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng phương thức `get_image` từ các lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) hoặc [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình chiếu đầy đủ.