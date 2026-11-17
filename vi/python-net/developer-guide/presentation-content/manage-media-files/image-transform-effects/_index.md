---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình bày với Python
linktitle: Hiệu ứng Biến đổi Ảnh
type: docs
weight: 11
url: /vi/python-net/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- hai màu
- tô màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Áp dụng, xâu chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung ảnh với Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh ảnh dưới dạng một bộ sưu tập có thứ tự các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu bằng [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) của khung và truy cập thuộc tính [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa toàn bộ các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày quy trình đầy đủ cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, các giá trị thực tế, việc xóa, và việc xác minh vòng quay lại PPTX.

## **Hiểu về Quyền sở hữu Hiệu ứng và Việc Tái sử dụng Hình ảnh**

Một tài nguyên hình ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) lưu trữ hoặc tham chiếu dữ liệu hình ảnh nguồn thuộc sở hữu của bản trình bày.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) thuộc về một phần nền hình ảnh và tham chiếu tới một tài nguyên hình ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần nền hình ảnh liên quan, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền cho [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) hơn một lần, mỗi khung ảnh mới sẽ nhận được `Picture` và bộ sưu tập biến đổi riêng của nó. Áp dụng chuyển đổi grayscale cho một khung không làm các khung khác trở thành grayscale, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `Picture.image_transform` tương tự cũng được sử dụng bởi các phần nền hình ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng Dải Giá Trị và Đơn Vị Tham Số Hợp Lệ**

Các phương thức được minh họa sử dụng các dải giá trị và đơn vị ngữ nghĩa sau. Giữ các giá trị trong các dải này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình bày mục tiêu có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Operation | Parameters | Dải giá trị và đơn vị hợp lệ |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` để thành phần không thay đổi. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Không có tham số số. Alpha không thay đổi. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Hai màu cho các pixel tối và sáng. Các kênh RGB và alpha sử dụng `0` đến `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue là `0` bao gồm đến `360` không bao gồm, tính bằng độ; amount là `-100` đến `100`, phần trăm. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue là `0` bao gồm đến `360` không bao gồm, tính bằng độ; saturation và luminance là `-100` đến `100`, phần trăm. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius là không âm và đo bằng points; `grow` là Boolean điều khiển việc nội dung làm mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc thu giảm độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Các giá trị dưới ngưỡng trở nên trong suốt; các giá trị bằng hoặc trên ngưỡng trở nên mờ. |

Đối với điều chế alpha cố định, độ trong suốt và độ mờ là hai mặt complémentaires. Ví dụ, độ trong suốt 35% tương ứng với mức điều chế alpha 65%.

## **Áp dụng Độ sáng và Độ tương phản**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) trả về một thao tác [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Các cài đặt scala của nó được cung cấp khi tạo thao tác. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) trả về các giá trị chỉ đọc đã tính toán có thể được kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó render bản xem trước mà không thay đổi ảnh được nhúng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng hình ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance DrawingML tiêu chuẩn. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau vòng quay PPTX, hãy sử dụng [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp dụng Các Biến đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên hình ảnh. Ví dụ dưới tạo năm khung và áp dụng grayscale, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` áp dụng cho các pixel tối, trong khi `color2` áp dụng cho các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của hiệu ứng có cài đặt phức tạp hơn so với một giá trị scala duy nhất.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), cái mà ánh xạ một màu nguồn sang màu đích và hiển thị cả hai định dạng màu nguồn và đích.

### **Áp dụng Ngưỡng Độ sáng**

Ngưỡng độ sáng có thể giúp các dấu mờ trên một trang quét dễ phân biệt hơn so với nền. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) giữ các sắc thái xám trung gian. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) ánh xạ độ sáng thành đen hoặc trắng, trong khi [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) áp dụng ngưỡng cho độ mờ.

Ngưỡng độ sáng dao động từ 0% đến 100%, bao gồm. Các pixel dưới ngưỡng trở thành đen. Các pixel bằng hoặc trên ngưỡng trở thành trắng. Tăng ngưỡng làm nhiều sắc thái chuyển thành đen hơn vì chúng rơi dưới mức cắt.

Tải về [grayscale-swatches.png](grayscale-swatches.png) vào thư mục làm việc. Mỗi nhãn cho biết mức xám gốc trên thang từ 0 đến 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao vào bản trình bày.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Mở bản trình bày đầu ra trong PowerPoint để so sánh ba khung. Mẫu màu được gắn nhãn 96 có khoảng 38% độ sáng (96 trong số 255). Nó chuyển sang trắng ở ngưỡng 20% và sang đen ở ngưỡng 60%.

![Các mẫu màu xám gốc bên cạnh kết quả đen-trắng tại ngưỡng độ sáng 20% và 60%](luminance-threshold.png)

## **Thêm Hiệu ứng Làm mờ, Độ trong suốt và Alpha**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) ảnh hưởng tới mọi kênh màu, bao gồm alpha. Đặt `grow` thành `True` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) thay vào đó gán một giá trị alpha cho tất cả các pixel. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Các thao tác alpha không có tham số khác bao gồm [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), làm cho mọi alpha khác 0 trở nên hoàn toàn mờ; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), làm cho mọi alpha dưới 100% trở nên hoàn toàn trong suốt; và [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), đổi alpha thành `100% - alpha`.

## **Xây dựng Chuỗi Hiệu ứng Có Thứ tự**

Mỗi phương thức `add_..._effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ thế. Do đó, cùng các thao tác nhưng theo thứ tự khác nhau có thể tạo ra hình ảnh khác nhau.

Ví dụ, grayscale rồi tint sẽ đầu tiên loại bỏ thông tin màu và sau đó chỉnh lại màu độ sáng; tint rồi grayscale sẽ lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ dưới xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả loại thao tác và thứ tự của chúng, và render kết quả đã mở lại:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và blur thành các chuỗi riêng biệt. Chúng có thể kết hợp, nhưng không phải mọi kết hợp đều hữu ích. Thay thế màu cố định sẽ loại bỏ sự biến đổi RGB do các hiệu ứng màu trước tạo ra; grayscale sau duotone sẽ loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể loại bỏ chi tiết alpha được tạo trước. Hãy xây dựng chuỗi dựa trên thứ tự xử lý pixel mong muốn thay vì coi các mục như các cờ định dạng không có thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh được xử lý qua grayscale rồi tint, và tint rồi grayscale. Hai hình ảnh grayscale cuối cùng có tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong bản render minh họa Aspose.Slides for .NET 26.11 này, một tint 220° ở 25% không làm thay đổi ảnh grayscale. Áp dụng cùng một tint trước grayscale tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm tra Các Giá trị Có thể Chỉnh sửa và Giá trị Thực tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `Picture.image_transform`. Tùy thuộc vào hiệu ứng, nó có thể hiển thị các thành viên có thể ghi trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) hiển thị các thuộc tính ghi được `radius` và `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) hiển thị thuộc tính ghi được `amount`, và [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) hiển thị thuộc tính ghi được `threshold`. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) hiển thị các đối tượng [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) có thể sửa đổi.

Một số thao tác, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), và [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), không hiển thị các giá trị scala tạo ra dưới dạng thuộc tính ghi được. Để thay đổi các cài đặt đó, hãy xóa thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu thực tế trả về bởi `get_effective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị đã chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới liệt kê chuỗi và kiểm tra các giá trị thực tế ở những nơi API cung cấp chúng:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Các hiệu ứng không có tham số như grayscale, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu thực tế, nhưng không có cài đặt scala nào để in ra. Sự có mặt và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc Xóa toàn bộ Biến đổi Ảnh**

Sử dụng [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng `clear()` để xóa toàn bộ chuỗi.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Xóa hoặc xóa toàn bộ các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại, hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) được tái sử dụng.

## **Xem xét Định dạng Bản trình bày và Đích xuất**

Các biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha chung có khả năng tồn tại tốt nhất sau vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 thay vì thao tác luminance DrawingML tiêu chuẩn. Nó có thể được dùng cho render trong bộ nhớ, nhưng không được đảm bảo còn tồn tại dưới dạng thao tác `BrightnessContrast` có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên ưu tiên [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân có lịch sử lâu hơn mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi về một tập con được hỗ trợ, hoặc xấp xỉ diện mạo. Không sử dụng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ lên diện mạo đã render. Các đầu ra này không chứa một `ImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu hoặc vector lưu trữ đại diện render riêng của chúng.
- Các hiệu ứng không làm cho một ảnh được liên kết tự chứa. Render một ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình bày được tải.

Các người tiêu thụ bản trình bày khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được sử dụng trong sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `Picture` được sử dụng bởi phần nền ảnh. Các byte `PPImage` nền tảng vẫn không thay đổi.

**Hai khung ảnh tái sử dụng cùng một hình ảnh có chia sẻ các hiệu ứng không?**

Không. Việc tái sử dụng một `PPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `Picture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy xem xét mỗi thao tác ảnh hưởng đến đầu ra của thao tác trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo trước.

**Tại sao các giá trị thực tế chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán được dùng để render, bao gồm các màu đã được giải quyết. Hãy chỉnh sửa thao tác được lưu trong bộ sưu tập biến đổi ở nơi có thành viên ghi được; nếu không, xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo lưu một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ giữ lại diện mạo chứ không có các thao tác biến đổi có thể chỉnh sửa.