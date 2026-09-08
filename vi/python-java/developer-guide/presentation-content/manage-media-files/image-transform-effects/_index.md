---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình chiếu với Python
linktitle: Các hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/python-java/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng ảnh
- độ sáng
- độ tương phản
- chuyển đổi xám
- đôi màu
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Áp dụng, nối chuỗi, kiểm tra, xóa và xác thực các hiệu ứng biến đổi ảnh cho khung ảnh với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides biểu thị các hiệu chỉnh ảnh dưới dạng một tập hợp có thứ tự của các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/) của khung và truy cập [Picture.getImageTransform](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImageTransform). [ImageTransformOperationCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại các byte hình ảnh gốc.

Bài viết này minh họa quy trình làm việc hoàn chỉnh cho độ sáng và độ tương phản, biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị hiệu lực, xóa và xác thực vòng quay PPTX.

## **Hiểu quyền sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn mà bản trình chiếu sở hữu.
- [Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/) thuộc về một phần nền hình và tham chiếu tài nguyên ảnh đồng thời lưu trữ tập hợp biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần nền hình, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền cho [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addPictureFrame) hơn một lần, mỗi khung ảnh mới sẽ nhận được `Picture` và tập hợp biến đổi riêng. Áp dụng chuyển đổi xám cho một khung không làm các khung khác cũng chuyển sang xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `Picture.getImageTransform` tương tự cũng được sử dụng bởi các phần nền hình khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng phạm vi và đơn vị tham số hợp lệ**

Các phương pháp được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi hợp lệ và đơn vị |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ thành phần không đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` dùng giá trị từ `0` đến `255`. |
| [addTintEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; amount từ `-100` đến `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Màu thay thế sử dụng giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radius không âm và đo bằng điểm; `grow` là Boolean điều khiển việc nội dung đã làm mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc thu giảm độ trong suốt thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc lớn hơn ngưỡng trở nên mờ đục. |

Đối với việc điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ sung nhau. Ví dụ, độ trong suốt 35 % tương đương với mức điều chế alpha 65 %.

## **Áp dụng độ sáng và độ tương phản**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) trả về một thao tác [BrightnessContrast](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/). Các thiết lập vô hướng của nó được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/#getEffective) trả về các giá trị chỉ đọc đã được tính toán, có thể kiểm tra hoặc ghi lại.

Ví dụ sau tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh của Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản cần giữ khả năng chỉnh sửa sau vòng quay PPTX, hãy sử dụng [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết sự khác biệt này.

## **Áp dụng các biến đổi màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau sử dụng chung một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng chuyển đổi xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ pixel tối, trong khi `color2` ánh xạ pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) thay thế mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), phương pháp này ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm hiệu ứng làm mờ, trong suốt và alpha**

[addBlurEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) ảnh hưởng đến tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `True` khi cạnh đã làm mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) thay vào đó gán một giá trị alpha duy nhất cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) chuyển đổi alpha thành hai mức dựa trên ngưỡng.

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

Các thao tác alpha không tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), làm cho mọi alpha khác 0 trở nên hoàn toàn mờ đục; [addAlphaFloorEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), làm cho mọi alpha dưới 100 % hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), chuyển đổi alpha thành `100% - alpha`.

## **Xây dựng một chuỗi hiệu ứng có thứ tự**

Mỗi phương pháp `add...Effect` thêm một thao tác mới vào cuối tập hợp. Bộ render sử dụng tập hợp như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và tiếp tục như vậy. Do đó, cùng các thao tác nhưng sắp xếp khác nhau có thể tạo ra ảnh khác nhau.

Ví dụ, chuyển đổi xám rồi tint sẽ đầu tiên loại bỏ thông tin sắc màu và sau đó tô lại kết quả luminance. Tint rồi chuyển đổi xám sẽ lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè giá trị alpha được tính bởi các thao tác trước, trong khi việc điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ sau xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Tập hợp không áp đặt một ma trận tương thích buộc các thao tác màu, alpha và blur phải nằm trong các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Việc thay thế màu cố định loại bỏ các biến thể RGB do các hiệu ứng màu trước tạo ra; chuyển đổi xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể bỏ đi chi tiết alpha được tạo ra trước đó. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì xem các mục như các cờ định dạng không có thứ tự.

## **Kiểm tra giá trị có thể chỉnh sửa và giá trị hiệu lực**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `Picture.getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể hiển thị các thành viên ghi được trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blur/) cho phép ghi `radius` và `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/alphamodulatefixed/) cho phép ghi `amount`, và [AlphaBiLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/alphabilevel/) cho phép ghi `threshold`. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/duotone/) cho phép chỉnh sửa các đối tượng [ColorFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colorformat/).

Một số lớp thao tác, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tint/), và [AlphaReplace](https://reference.aspose.com/slides/vi/python-java/aspose.slides/alphareplace/), không để lộ các tham số khởi tạo dưới dạng thuộc tính ghi được. Để thay đổi các cài đặt này, cần xóa thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu hiệu lực được trả về bởi `getEffective` là đã tính toán và chỉ đọc. Nó hữu ích để giải quyết màu phụ thuộc vào giao diện chủ đề và đọc các giá trị đã chuẩn hoá mà bộ render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị hiệu lực ở những nơi API cung cấp chúng:

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

Các hiệu ứng không tham số như grayscale, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu hiệu lực, nhưng không có thiết lập vô hướng nào để in ra. Sự hiện diện và vị trí của chúng trong tập hợp là thông tin quan trọng.

## **Xóa hoặc xóa sạch các biến đổi ảnh**

Sử dụng [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, trước tiên hãy tìm chỉ mục mục tiêu và xóa nó sau khi liệt kê. Dùng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#clear) để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) đã được tái sử dụng.

## **Xem xét định dạng bản trình chiếu và mục tiêu xuất**

Các biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thường có khả năng tồn tại tốt nhất sau vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra tập hợp khi yêu cầu bảo toàn.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance chuẩn DrawingML. Nó có thể dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn tồn tại dưới dạng [BrightnessContrast](https://reference.aspose.com/slides/vi/python-java/aspose.slides/brightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên [addLuminanceEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân ra đời trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không được hỗ trợ, giảm chuỗi về một tập con được hỗ trợ hoặc xấp xỉ giao diện. Không dùng PPT làm định dạng xác thực cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi đã hỗ trợ vào giao diện được render. Các đầu ra này không chứa một `ImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành các pixel, và các xuất tài liệu/vector lưu trữ cách biểu diễn render riêng của chúng.
- Hiệu ứng không làm cho một ảnh liên kết tự chứa. Render một ảnh được liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các trình duyệt bản trình chiếu khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `Picture` được sử dụng bởi phần nền hình. Các byte `PPImage` nền tảng không bị thay đổi.

**Hai khung ảnh sử dụng cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Việc tái sử dụng một `PPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `Picture` và tập hợp biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Tập hợp cho phép chúng trong một chuỗi có thứ tự. Cần xem xét mỗi thao tác ảnh hưởng đến đầu ra của thao tác trước đó vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo.

**Tại sao các giá trị hiệu lực lại chỉ đọc?**

Dữ liệu hiệu lực đại diện cho các giá trị đã tính toán dùng để render, bao gồm màu đã được giải quyết. Chỉnh sửa thao tác được lưu trong tập hợp biến đổi nếu có thành viên có thể ghi; nếu không, hãy xóa và thêm một thao tác thay thế với các tham số khởi tạo mới.

**Định dạng nào nên dùng để bảo toàn một chuỗi biến đổi?**

Dùng PPTX và xác thực tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ bảo toàn giao diện chứ không chứa các thao tác biến đổi có thể chỉnh sửa.