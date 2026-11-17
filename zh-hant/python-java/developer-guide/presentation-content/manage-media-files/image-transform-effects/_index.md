---
title: 使用 Python 在簡報中管理影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/python-java/image-transform-effects/
keywords:
- 影像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 顏色取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides (Python 版) 透過 Java，套用、串接、檢查、移除及驗證圖片框的影像變換效果。"
---
## **概觀**

Aspose.Slides 以有序的影像變換操作集合來表示圖片調整。對於圖片框，先取得框架的 [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) ，再呼叫 [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform)。回傳的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) 讓您可以加入、列舉、檢查、移除以及清除效果，而不必重新寫入原始影像位元組。

本文章示範了亮度與對比度、顏色變換、模糊、透明度、有序效果鏈、實際值、移除，以及 PPTX 往返驗證的完整工作流程。

## **了解效果擁有權與影像重複使用**

影像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 會儲存或參考簡報所擁有的來源影像資料。
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) 屬於圖片填充，參考影像資源，同時儲存影像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定與其他框架層級格式。

因此，影像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 中的位元組。當同一個 `PPImage` 多次傳遞給 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) 時，每個新圖片框都會收到自己的 `Picture` 與自己的變換集合。對其中一個框套用灰階不會使其他框也變成灰階，即使它們都重複使用相同的嵌入影像資源。

相同的 `Picture.getImageTransform` 模型也被其他圖片填充使用，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定函式庫版本未即時拒絕所有超出範圍的值，也請維持在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` 至 `100`，百分比；`0` 表示保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | 無 | 無數值參數。Alpha 不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | 兩種顏色用於暗像素與亮像素。`java.awt.Color` 的 RGB 與 alpha 通道值為 `0` 至 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | 色相 `0`（含）至 `360`（未含），單位為度；色量 `-100` 至 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | 色相 `0`（含）至 `360`（未含），單位為度；飽和度與亮度 `-100` 至 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | 取代顏色的通道值為 `0` 至 `255`。現有 alpha 值不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | 半徑為非負值，以點為單位；`grow` 為布林值，決定模糊內容是否可延伸至原始邊界外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | 非負百分比。使用 `0` 至 `100` 表示普通不透明度縮放：`0` 為完全透明，`100` 為保留現有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` 至 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` 至 `100`，百分比 alpha 閾值。低於此值的變為透明；等於或高於此值的變為不透明。 |

對於固定的 alpha 調變，透明度與不透明度互為補數。例如，35% 透明度對應的 alpha 調變量為 65%。

## **套用亮度與對比度**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) 會回傳一個 [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 操作。其純量設定在建立操作時提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) 會回傳計算後唯讀的值，供檢查或記錄使用。

以下範例將亮度提高 15%，對比度提高 20%，然後在不修改嵌入影像的情況下渲染預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 是 Office 2010 的圖片效果延伸，較標準 DrawingML 亮度效果的相容性差。如果需要在 PPTX 往返後仍可編輯亮度與對比度，請使用 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 並在重新開啟檔案後驗證結果。格式限制節說明了此差異的更多細節。

## **套用顏色變換**

顏色效果可以獨立套用到重複使用同一影像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 用於暗像素，`color2` 用於亮像素。這使它成為一個設定比單一純量更複雜的效果範例。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) 會將每個像素的顏色取代為固定顏色，同時保留 alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect)，後者會將一個來源顏色映射到另一個顏色，並公開來源與目標顏色格式。

### **套用亮度閾值**

亮度閾值可以讓掃描頁面的淡淡痕跡更易於與背景區分。[addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) 會保留中間的灰階陰影。[addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) 會將亮度映射為黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 則對不透明度套用閾值。

亮度閾值範圍為 0% 至 100%，含端點。低於閾值的像素變為黑色，等於或高於閾值的像素變為白色。提升閾值會使更多陰影變黑，因為更多像素落在截斷以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至工作目錄。每個標籤顯示 0 到 255 的原始灰階等級。範例將原始圖放在兩個複本旁，並在簡報中儲存每個複本的閾值。

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

在 PowerPoint 中開啟輸出簡報，以比較三個框。標記為 96 的樣本大約有 38% 亮度（96/255）。在 20% 閾值時變白，60% 閾值時變黑。

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) 會影響所有顏色通道，包括 alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `True`。

若要均勻透明度，使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect)。它會乘以每個現有的 alpha 值，使部分透明的像素保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) 則會將所有像素指派為單一 alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 會根據閾值將 alpha 轉為兩個層級。

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

其他無參數的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect)，會將所有非零 alpha 變為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect)，會將所有低於 100% 的 alpha 變為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect)，會將 alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add...Effect` 方法都會將新操作加到集合的末端。渲染器將集合視為有序的流水線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，相同的操作若順序不同，可能產生不同的影像。

例如，先灰階再色調會先移除色彩資訊，然後重新上色；先色調再灰階則會再次移除色調。類似地，alpha 取代可以覆寫先前操作計算的 alpha 值，而 alpha 調變則保留其相對差異。

以下範例建立四個操作的鏈，儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會強加相容性矩陣限制顏色、alpha 與模糊操作必須分開鏈。它們可以結合，但組合不一定有用。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會移除兩個選定顏色；而 alpha ceiling、floor、replace 或 bi‑level 操作可能會拋棄先前產生的 alpha 細節。請依照期望的像素處理順序建構鏈，而非把項目當作無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與實際值**

可編輯的操作是儲存在 `Picture.getImageTransform` 中的物件。根據不同效果，它可能會直接公開可寫成員。例如，[Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) 會公開可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) 會公開可寫的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) 會公開可寫的 `threshold`。諸如 [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) 的顏色效果則會公開可變的 [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) 物件。

某些操作類別，包括 [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/)、以及 [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/)，不會將其建立時的純量公開為可寫屬性。若要變更這些設定，請移除該操作並在所需位置加入新替代。

`getEffective` 回傳的實際資料是計算後唯讀的。它對於解析主題相關顏色以及讀取渲染器使用的正規化值很有用，但不是另一個編輯介面。以下範例列舉鏈並在對應的 API 提供時檢查實際值：

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

無參數的效果如灰階、alpha ceiling、alpha inverse 仍會有實際資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置才是重要資訊。

## **移除或清除影像變換**

使用 [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) 依索引移除單一操作。因為移除後索引會移位，請先搜尋目標，列舉完成後再移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) 可以清除整個鏈。

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

移除或清除變換只會改變圖片的格式設定，不會刪除、重新壓縮或以其他方式修改重複使用的 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使是 PPTX，也不是所有操作都有相同的相容性：

- 標準 DrawingML 操作如亮度、灰階、雙調、色調、HSL、模糊與常見 alpha 操作最有機會在 PPTX 往返後仍存活。若有保存需求，請始終重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 是 Office 2010 的延伸，而非標準 DrawingML 亮度操作。它可用於記憶體內渲染，但不保證在儲存與重新開啟 PPTX 後仍為可編輯的 [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/)。請使用 [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 以持久化亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作，將鏈縮減為支援的子集，或近似外觀。請勿將 PPT 作為複雜可編輯鏈的驗證格式。
- 渲染至 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用至渲染結果。這些輸出不包含可編輯的 `ImageTransformOperationCollection`；點陣格式會將結果平鋪成像素，文件/向量匯出則儲存其自身的渲染表示。
- 效果不會使連結影像變成自包含。渲染連結圖片仍然依賴於載入簡報時連結資源的可用性。

不同的簡報消費者在處理邊緣案例時可能會有不同的渲染結果，尤其是多個 alpha 或顏色量化操作結合時。對於關鍵輸出，請使用相同的 Aspose.Slides 版本測試可編輯往返與最終匯出格式。

## **常見問與答**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些操作屬於用於圖片填充的 `Picture`。底層的 `PPImage` 位元組保持不變。

**重複使用相同影像的兩個圖片框會共享它們的效果嗎？**

不會。重複使用 `PPImage` 只避免了影像資料的重複，但每個圖片框通常都有各自的 `Picture` 與影像變換集合。

**顏色、模糊與 alpha 效果可以結合使用嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個操作對先前輸出的影響，因為取代與閾值操作可能會丟棄先前的顏色或 alpha 細節。

**為什麼實際值是唯讀的？**

實際資料代表渲染時使用的計算值，包括解析後的顏色。若操作在集合中有可寫成員，請直接編輯該操作；若沒有，請移除並以新的建立參數加入替代。

**哪種格式才能保留變換鏈？**

使用 PPTX，並透過重新開啟檔案驗證。傳統 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式只能保留外觀，無法保留可編輯的變換操作。