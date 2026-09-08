---
title: 使用 Python 在簡報中管理圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/python-java/image-transform-effects/
keywords:
- 圖像變換
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
description: "使用 Aspose.Slides for Python (via Java) 套用、鏈接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，從框架的 [Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/) 開始，並存取 [Picture.getImageTransform](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImageTransform)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/) 允許您追加、列舉、檢查、移除和清除效果，而無需重新寫入原始圖像位元組。

本文示範了亮度與對比、顏色變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的完整工作流程。

## **了解效果所有權與圖像重用**

圖像資源與顯示該資源的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 儲存或參照簡報所擁有的來源圖像資料。
- [Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/) 屬於圖片填充，參照圖像資源，同時儲存圖像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁剪設定以及其他框架層級的格式設定。

因此，圖像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 中的位元組。當相同的 `PPImage` 被多次傳遞給 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addPictureFrame) 時，每個新圖片框都會取得自己的 `Picture` 以及自己的變換集合。對一個框套用灰階不會使其他框變為灰階，即使它們共用相同的內嵌圖像資源。

相同的 `Picture.getImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定函式庫版本未立即拒絕所有超出範圍的值，也請將值限制在此範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍和單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` 至 `100`，百分比；`0` 表示保持該元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | 無 | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | 兩種顏色分別用於深色與淺色像素。`java.awt.Color` 的 RGB 與 alpha 通道使用 `0` 至 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | 色相 `0`（含）至 `360`（未含），單位為度；色調幅度 `-100` 至 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | 色相 `0`（含）至 `360`（未含），單位為度；飽和度與亮度 `-100` 至 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | 替換顏色的通道值為 `0` 至 `255`。現有的 alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | 半徑為非負值，單位為點；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | 非負百分比。使用 `0` 至 `100` 進行普通不透明度調整：`0` 為完全透明，`100` 保持現有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` 至 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` 至 `100`，百分比 alpha 閾值。低於閾值的變為透明，等於或高於閾值的變為不透明。 |

對於固定的 alpha 調製，透明度與不透明度是互補的。例如，35% 透明度對應的 alpha 調製量為 65%。

## **套用亮度與對比**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) 會返回一個 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/brightnesscontrast/) 操作。其純量設定在建立操作時提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/brightnesscontrast/#getEffective) 會返回計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提高 15%，對比提高 20%，然後在不修改內嵌圖像的情況下渲染預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/brightnesscontrast/) 是 Office 2010 圖片效果擴充，較標準 DrawingML 亮度效果的可移植性差。當需要在 PPTX 循環後仍能編輯亮度與對比時，請使用 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此區別。

## **套用顏色變換**

顏色效果可獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 作用於暗像素，`color2` 作用於亮像素。這使其成為一個設定較單一純量更複雜的範例。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) 會將每個像素的顏色取代為固定顏色，同時保留 alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect)，後者會將一個來源顏色映射到另一個目標顏色，並同時暴露來源與目標顏色格式。

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) 會影響所有顏色通道，包括 alpha。當模糊邊緣可能延伸超出原始圖片範圍時，將 `grow` 設為 `True`。

若需均勻透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect)。它會將每個現有的 alpha 值相乘，使部分透明像素保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) 則會將所有像素的 alpha 設為同一值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 根據閾值將 alpha 轉為兩個層級。

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

其他無參數的 alpha 操作還包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect)，將所有非零 alpha 變為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect)，將所有低於 100% 的 alpha 變為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect)，將 alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add...Effect` 方法會將新操作追加到集合的末端。渲染器會將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，以不同順序排列相同操作可能產生不同圖像。

例如，先套用灰階再套用色調會先移除色彩資訊，然後重新著色亮度結果。先套用色調再套用灰階則會再次移除色調。類似地，Alpha 取代可以覆寫先前操作計算的 alpha，而 Alpha 調製則保留其相對差異。

以下範例建立四個操作的鏈、儲存為 PPTX、重新開啟簡報、檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會施加限制矩陣，將顏色、alpha 與模糊操作限制在不同鏈中。它們可以結合使用，但組合未必都有意義。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；在雙調之後再套用灰階會移除兩個選定的顏色；而 alpha ceiling、floor、replace 或 bi‑level 操作可能會捨棄先前產生的 alpha 細節。請依照欲達成的像素處理順序建立鏈，而非將項目視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的操作即儲存在 `Picture.getImageTransform` 中的物件。依效果不同，可能直接公開可寫成員。例如，[Blur](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blur/) 會公開可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/alphamodulatefixed/) 會公開可寫的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/alphabilevel/) 會公開可寫的 `threshold`。[Duotone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/duotone/) 等顏色效果則會暴露可變的 [ColorFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colorformat/) 物件。

某些操作類別（如 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tint/) 與 [AlphaReplace](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/alphareplace/)）不會將建立時的純量暴露為可寫屬性。若要變更這些設定，必須移除該操作並在所需位置加入替代操作。

`getEffective` 回傳的有效資料是計算後的唯讀值。它對於解析主題相關顏色以及讀取渲染器使用的正規化值很有幫助，但並非另一個編輯介面。以下範例列舉鏈並在 API 提供時檢查有效值：

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

雖然灰階、alpha ceiling、alpha inverse 等無參數效果仍會有有效資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除圖像變換**

使用 [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) 以索引移除單一操作。因為移除後索引會變動，請先搜尋目標再於列舉後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#clear) 可移除整個鏈。

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

移除或清除變換僅會改變圖片格式設定，並不會刪除、重新壓縮或以其他方式改變被重用的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換來源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是所有操作的可移植性完全相同：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊與常見 alpha 操作）最有可能在 PPTX 循環後仍然存活。若有保存需求，請始終重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/brightnesscontrast/) 屬於 Office 2010 擴充，而非標準 DrawingML 亮度操作。可用於記憶體渲染，但無法保證在儲存並重新開啟 PPTX 後仍保持為可編輯的 [BrightnessContrast]。請改用 [addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 以獲得持久的亮度與對比調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援子集，或以近似方式呈現外觀。請勿將 PPT 用作複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `ImageTransformOperationCollection`；光柵格式會將結果平鋪成像素，文件/向量匯出則存儲自身的渲染表示。
- 效果不會使連結圖像變成自包含。渲染連結圖片仍依賴於載入簡報時可取得該連結資源。

不同的簡報瀏覽器在邊緣情況下可能呈現不同，尤其是同時結合多個 alpha 或顏色量化操作時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**圖像變換效果會修改內嵌圖像資料嗎？**

不會。這些操作屬於圖片填充使用的 `Picture`，底層的 `PPImage` 位元組保持不變。

**重用相同圖像的兩個圖片框會共享它們的效果嗎？**

不會。重用 `PPImage` 可避免重複的圖像資料，但每個圖片框通常都有獨立的 `Picture` 與圖像變換集合。

**可以同時結合顏色、模糊與 alpha 效果嗎？**

可以。集合接受它們在同一條有序鏈中。請考慮每個操作對前一個操作輸出的影響，因為取代與閾值操作可能會捨棄先前的顏色或 alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。請在變換集合中編輯可寫成員的操作；若操作本身不提供可寫屬性，則必須移除後再以新參數加入替代操作。

**應該使用哪種格式來保留變換鏈？**

使用 PPTX 並在儲存後重新開啟以驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，而視覺匯出格式僅保留外觀，而非可編輯的變換操作。