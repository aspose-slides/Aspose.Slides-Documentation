---
title: Quản lý các hiệu ứng biến đổi hình ảnh trong bản trình bày với Python
linktitle: Hiệu ứng biến đổi hình ảnh
type: docs
weight: 11
url: /vi/python-java/image-transform-effects/
keywords:
- biến đổi hình ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- hai màu
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Áp dụng, nối chuỗi, kiểm tra, xoá và xác thực các hiệu ứng biến đổi hình ảnh cho các khung ảnh với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn việc điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) và truy cập [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xoá và xóa các hiệu ứng mà không cần ghi lại lại byte ảnh gốc.

Bài viết này trình bày quy trình đầy đủ cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, việc loại bỏ và kiểm chứng vòng quay PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Tái Sử Dụng Hình Ảnh**

Một tài nguyên hình ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) lưu hoặc tham chiếu dữ liệu hình ảnh nguồn mà bản trình bày sở hữu.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) thuộc về phần tô màu hình ảnh và tham chiếu tới một tài nguyên hình ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần tô màu hình ảnh liên quan, hình học, thiết lập cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi byte trong [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền vào [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) hơn một lần, mỗi khung ảnh mới sẽ nhận được `Picture` và bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi grayscale cho một khung không làm các khung khác cũng chuyển sang grayscale, mặc dù tất cả đều tái sử dụng cùng một tài nguyên hình ảnh được nhúng.

Mô hình `Picture.getImageTransform` tương tự cũng được sử dụng bởi các phần tô màu hình ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử Dụng Phạm Vi Tham Số và Đơn Vị Hợp Lệ**

Các phương thức được minh họa sử dụng các phạm vi và đơn vị ngữ nghĩa sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị vượt phạm vi; định dạng bản trình bày mục tiêu có thể chuẩn hoá, bỏ hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Hai màu cho các pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` sử dụng giá trị từ `0` đến `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; amount từ `-100` đến `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Màu thay thế sử dụng giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Bán kính là không âm và đo bằng điểm; `grow` là kiểu Boolean điều khiển việc nội dung mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Phần trăm không âm. Sử dụng `0` đến `100` cho việc điều chỉnh độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng sẽ trong suốt; giá trị bằng hoặc trên ngưỡng sẽ không trong suốt. |

Đối với điều chế alpha cố định, độ trong suốt và độ mờ là các giá trị bổ trợ. Ví dụ, 35% độ trong suốt tương ứng với mức điều chế alpha là 65%.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) trả về một thao tác [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) trả về các giá trị chỉ đọc đã tính toán có thể được kiểm tra hoặc ghi lại.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi cần giữ độ sáng và độ tương phản có thể chỉnh sửa sau vòng quay PPTX, hãy sử dụng [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) và kiểm chứng kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp Dụng Các Biến Đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên hình ảnh. Ví dụ sau tạo năm khung và áp dụng grayscale, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), cái mà ánh xạ một màu nguồn sang màu đích và hiển thị cả định dạng màu nguồn và đích.

### **Áp Dụng Ngưỡng Độ Sáng**

Một ngưỡng độ sáng có thể làm cho các dấu mờ trên trang quét dễ phân biệt hơn so với nền. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) giữ lại các mức xám trung gian. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) ánh xạ độ sáng thành đen hoặc trắng, trong khi [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) áp dụng ngưỡng cho độ trong suốt.

Ngưỡng độ sáng dao động từ 0% đến 100%, bao gồm. Các pixel dưới ngưỡng trở thành đen. Các pixel bằng hoặc trên ngưỡng trở thành trắng. Tăng ngưỡng sẽ làm nhiều sắc thái hơn trở thành đen vì chúng nằm dưới mức cắt.

Tải xuống [grayscale-swatches.png](grayscale-swatches.png) về thư mục làm việc. Mỗi nhãn cho biết mức xám gốc trên thang 0 đến 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao trong bản trình bày.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mở bản trình bày đầu ra trong PowerPoint để so sánh ba khung. Mẫu có nhãn 96 có khoảng 38% độ sáng (96 trên 255). Nó chuyển sang trắng ở ngưỡng 20% và sang đen ở ngưỡng 60%.

![Các mẫu màu xám gốc bên cạnh kết quả đen‑trắng ở ngưỡng độ sáng 20% và 60%](luminance-threshold.png)

## **Thêm Hiệu Ứng Làm Mờ, Độ Trong Suốt và Alpha**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) ảnh hưởng đến tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `True` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, hãy sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỉ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) thay vào đó gán một giá trị alpha cho tất cả các pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), làm cho mọi alpha khác 0 trở nên hoàn toàn không trong suốt; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), làm cho mọi alpha dưới 100% trở nên hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), thay đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Bộ vẽ sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục như vậy. Do đó, cùng một tập hợp thao tác nhưng sắp xếp khác nhau có thể tạo ra hình ảnh khác.

Ví dụ, grayscale rồi tint đầu tiên loại bỏ thông tin sắc màu rồi màu lại kết quả độ sáng. Tint rồi grayscale lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định sẽ loại bỏ biến thể RGB do các hiệu ứng màu trước tạo ra; grayscale sau duotone sẽ loại bỏ hai màu đã chọn; và các thao tác ceiling, floor, replacement hoặc bi‑level alpha có thể loại bỏ chi tiết alpha đã tạo ra trước. Xây dựng chuỗi dựa trên thứ tự xử lý pixel mong muốn thay vì xem các mục như các cờ định dạng không có thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh được đưa qua grayscale rồi tint, và tint rồi grayscale. Hai hình ảnh grayscale cuối cùng có các tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm Tra Các Giá Trị Có Thể Chỉnh Sửa và Hiệu Quả**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `Picture.getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể trực tiếp mở ra các thành viên có thể ghi. Ví dụ, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) mở ra các giá trị `radius` và `grow` có thể ghi, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) mở ra `amount` có thể ghi, và [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) mở ra `threshold` có thể ghi. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) mở ra các đối tượng [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) có thể thay đổi.

Một số lớp thao tác, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), và [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), không mở ra các vô hướng tạo ra dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xoá thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu hiệu quả do `getEffective` trả về được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị chuẩn hoá mà bộ vẽ sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị hiệu quả tại nơi API cung cấp chúng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Các hiệu ứng không có tham số như grayscale, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng để in. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Hết Các Biến Đổi Hình Ảnh**

Sử dụng [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) để xoá một thao tác theo chỉ mục. Vì chỉ mục dịch chuyển sau khi xoá, hãy tìm mục tiêu trước và xoá nó sau khi liệt kê. Sử dụng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) để xoá toàn bộ chuỗi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Xoá hoặc xóa hết các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) đã được tái sử dụng.

## **Xem Xét Định Dạng Bản Trình Bày và Đích Xuất**

Các biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có cơ hội tồn tại tốt nhất sau vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi yêu cầu bảo tồn.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể được dùng cho việc vẽ trong bộ nhớ, nhưng không được đảm bảo vẫn tồn tại dưới dạng [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên ưu tiên [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi thành một tập con hỗ trợ, hoặc xấp xỉ giao diện. Không sử dụng PPT làm định dạng kiểm chứng cho một chuỗi chỉnh sửa phức tạp.
- Xuất ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi hỗ trợ cho giao diện được vẽ. Các đầu ra này không chứa một `ImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành pixel, và các xuất khẩu tài liệu/vector lưu trữ đại diện vẽ riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh liên kết tự chứa. Việc vẽ một hình ảnh liên kết vẫn phụ thuộc vào tài nguyên liên kết tồn tại khi bản trình bày được tải.

Các người tiêu dùng bản trình bày khác nhau có thể vẽ các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc giảm màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng với cùng một phiên bản Aspose.Slides được sử dụng trong môi trường sản xuất.

## **CÂU HỎI THƯỜNG GẶP**

**Các hiệu ứng biến đổi hình ảnh có thay đổi dữ liệu hình ảnh được nhúng không?**

Không. Các thao tác thuộc về `Picture` được sử dụng bởi phần tô màu hình ảnh. Các byte `PPImage` nền tảng vẫn không thay đổi.

**Hai khung ảnh tái sử dụng cùng một hình ảnh có chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `PPImage` tránh việc trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `Picture` và bộ sưu tập biến đổi ảnh riêng.

**Các hiệu ứng màu, làm mờ và alpha có thể được kết hợp không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác sẽ ảnh hưởng như thế nào đến kết quả của thao tác trước, vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo ra trước đó.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã tính toán được sử dụng cho việc vẽ, bao gồm các màu đã giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi ở nơi có thành viên có thể ghi; nếu không, hãy xoá nó và thêm một thao tác thay thế với các tham số tạo mới.

**Nên sử dụng định dạng nào để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. Định dạng PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất ra hình ảnh chỉ giữ lại giao diện thay vì các thao tác biến đổi có thể chỉnh sửa.