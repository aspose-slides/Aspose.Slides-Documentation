---
title: Quản lý các hiệu ứng biến đổi ảnh trong bài thuyết trình bằng Python
linktitle: Các hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/python-net/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- màu xám
- đôi sắc
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides biểu diễn việc điều chỉnh hình ảnh như một bộ sưu tập có thứ tự của các phép biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picture/) của khung và truy cập thuộc tính [image_transform](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picture/image_transform/). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại dữ liệu ảnh gốc.

Bài viết này trình bày một quy trình hoàn chỉnh cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, xóa và xác minh vòng quay PPTX.

## **Hiểu về sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) lưu hoặc tham chiếu dữ liệu ảnh nguồn được sở hữu bởi bản trình chiếu.
- [Picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picture/) thuộc về một phần nền ảnh và tham chiếu tới một tài nguyên ảnh đồng thời lưu bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần nền ảnh, hình học, cài đặt cắt và các định dạng ở mức khung.

Do đó, các phép biến đổi ảnh không thay đổi byte trong [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền vào [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) hơn một lần, mỗi khung ảnh mới sẽ nhận được `Picture` và bộ sưu tập biến đổi của riêng nó. Áp dụng chuyển đổi màu xám cho một khung không làm cho các khung khác cũng chuyển thành màu xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `Picture.image_transform` cũng được các phần nền ảnh khác sử dụng, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng phạm vi và đơn vị tham số hợp lệ**

Các phương pháp được minh họa sử dụng các phạm vi và đơn vị ngữ nghĩa sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu mục tiêu có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [add_duotone_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha sử dụng giá trị từ `0` đến `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; amount từ `-100` đến `100`, phần trăm. |
| [add_hsl_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [add_color_replace_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [add_blur_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius không âm và đo bằng điểm; `grow` là Boolean kiểm soát việc nội dung mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc thu nhỏ độ mờ thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên đục. |

Đối với điều chỉnh alpha cố định, trong suốt và độ mờ là các khái niệm bổ sung nhau. Ví dụ, độ trong suốt 35% tương đương với mức độ điều chỉnh alpha 65%.

## **Áp dụng độ sáng và độ tương phản**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) trả về một phép toán [BrightnessContrast](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/brightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo phép toán. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) trả về các giá trị chỉ đọc đã tính toán có thể được kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít khả năng di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau một vòng quay PPTX, hãy sử dụng [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp dụng các biến đổi màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau dùng chung một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng chuyển đổi màu xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Đây là một ví dụ hữu ích cho một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[add_color_replace_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [add_color_change_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm hiệu ứng làm mờ, trong suốt và alpha**

[add_blur_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) ảnh hưởng đến tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `True` khi viền mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với trong suốt đồng đều, sử dụng [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn duy trì tỷ lệ khác nhau. [add_alpha_replace_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) thay vào đó gán một giá trị alpha duy nhất cho tất cả các pixel. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) chuyển đổi alpha thành hai mức dựa trên ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [add_alpha_ceiling_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), làm cho mọi alpha khác 0 trở nên hoàn toàn đục; [add_alpha_floor_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), làm cho mọi alpha dưới 100% hoàn toàn trong suốt; và [add_alpha_inverse_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), chuyển đổi alpha thành `100% - alpha`.

## **Xây dựng chuỗi hiệu ứng có thứ tự**

Mỗi phương thức `add_..._effect` thêm một phép toán mới vào cuối bộ sưu tập. Trình render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của phép toán 0 trở thành đầu vào của phép toán 1, và cứ tiếp tục. Do đó, cùng một tập hợp các phép toán nhưng sắp xếp khác nhau có thể tạo ra hình ảnh khác nhau.

Ví dụ, chuyển đổi màu xám rồi tint sẽ đầu tiên loại bỏ thông tin màu sắc rồi sau đó tô lại kết quả luminance. Tint rồi màu xám sẽ lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các phép toán trước, trong khi điều chỉnh alpha sẽ giữ lại sự chênh lệch tương đối của chúng.

Ví dụ sau xây dựng một chuỗi bốn phép toán, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại và thứ tự của các phép toán, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các phép toán màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Việc thay thế màu cố định sẽ loại bỏ sự đa dạng RGB do các hiệu ứng màu trước tạo ra; màu xám sau duotone sẽ loại bỏ hai màu đã chọn; và các phép toán alpha ceiling, floor, replacement hoặc bi‑level có thể xóa bỏ chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì xem các mục như các cờ định dạng không có thứ tự.

## **Kiểm tra giá trị có thể chỉnh sửa và giá trị thực tế**

Một phép toán có thể chỉnh sửa là đối tượng được lưu trong `Picture.image_transform`. Tùy theo hiệu ứng, nó có thể cung cấp các thành viên ghi được trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/blur/) cung cấp các thuộc tính ghi được `radius` và `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/alphamodulatefixed/) cung cấp thuộc tính ghi được `amount`, và [AlphaBiLevel](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/alphabilevel/) cung cấp thuộc tính ghi được `threshold`. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/duotone/) cung cấp các đối tượng [ColorFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/colorformat/) có thể thay đổi.

Một số phép toán, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/tint/), và [AlphaReplace](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/alphareplace/), không cung cấp các vô hướng tạo ra dưới dạng thuộc tính ghi. Để thay đổi các cài đặt này, hãy xóa phép toán và thêm một phép toán thay thế tại vị trí yêu cầu.

Dữ liệu thực tế trả về bởi `get_effective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị đã chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị thực tế nơi API cung cấp chúng:

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

Các hiệu ứng không có tham số như màu xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng nào để in. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc xóa sạch các biến đổi ảnh**

Sử dụng [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) để xóa một phép toán theo chỉ mục. Vì các chỉ mục sẽ dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Dùng `clear()` để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) đã được tái sử dụng.

## **Xem xét định dạng bản trình chiếu và mục tiêu xuất**

Các biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưu tiên cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi phép toán đều có tính di động giống nhau:

- Các phép toán DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các phép toán alpha thông thường có khả năng tồn tại cao nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải phép toán luminance chuẩn DrawingML. Nó có thể được dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn là phép toán `BrightnessContrast` có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên [add_luminance_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các phép toán không hỗ trợ, giảm chuỗi về một tập hợp con được hỗ trợ, hoặc xấp xỉ giao diện. Không sử dụng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác sẽ áp dụng chuỗi hỗ trợ vào giao diện được render. Các đầu ra này không chứa một `ImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất khẩu tài liệu hoặc vector lưu trữ đại diện render riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh được liên kết trở nên tự chứa. Render một hình ảnh được liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các bên tiêu thụ bản trình chiếu khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi nhiều phép toán alpha hoặc màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm thử cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các phép toán thuộc về `Picture` được dùng bởi phần nền ảnh. Dữ liệu byte `PPImage` cơ sở vẫn không thay đổi.

**Hai khung ảnh dùng chung cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Việc tái sử dụng một `PPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `Picture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập chấp nhận chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi phép toán sẽ ảnh hưởng như thế nào đến đầu ra của phép toán trước, vì các phép toán thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị thực tế lại chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán được dùng để render, bao gồm cả màu đã được giải quyết. Hãy chỉnh sửa phép toán lưu trong bộ sưu tập biến đổi ở nơi có thành viên ghi được; nếu không, xóa nó và thêm một phép toán thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn đầy đủ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ giữ lại giao diện mà không giữ lại các phép toán biến đổi có thể chỉnh sửa.