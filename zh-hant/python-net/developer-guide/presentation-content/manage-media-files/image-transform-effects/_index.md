---
title: 使用 Python 在簡報中管理圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/python-net/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，對圖片框套用、串接、檢查、移除並驗證圖像變換效果。"
---
## **概覽**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，從框的 [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) 開始，存取其 [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) 屬性。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) 允許在不重新寫入原始圖像位元組的情況下追加、列舉、檢查、移除和清除效果。

本文章示範完整的工作流程，包括亮度與對比、色彩變換、模糊、透明度、有序效果鏈、有效值、移除，以及 PPTX 循環驗證。

## **了解效果所有權與影像重用**

影像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 儲存或參照簡報擁有的來源影像資料。
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) 屬於圖片填充，參照影像資源，同時保存圖像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框層級的格式。

因此，圖像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 中的位元組。當同一個 `PPImage` 多次傳遞給 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 時，每個新圖片框都會獲得自己的 `Picture` 和自己的變換集合。對其中一個框套用灰階不會使其他框變為灰階，即使它們共用相同的內嵌影像資源。

相同的 `Picture.image_transform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下示例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定版本的函式庫不立即拒絕所有超出範圍的值，也請保持在這些範圍內；目標簡報格式可能會在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | 無 | 無數值參數。Alpha 保持不變。 |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 兩個顏色分別對應暗色與亮色像素。RGB 與 alpha 通道使用 `0` 到 `255`。 |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | 色相 `0`（含）至 `360`（未含）度；`amount` 為 `-100` 到 `100` 百分比。 |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | 色相 `0`（含）至 `360`（未含）度；飽和度與亮度為 `-100` 到 `100` 百分比。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 替換顏色的通道值為 `0` 到 `255`。現有的 alpha 值保持不變。 |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | 半徑為非負值，以點為單位；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通的不透明度縮放：`0` 為完全透明，`100` 保留現有 alpha。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` 到 `100`，百分比 alpha 閾值。低於此值的像素變為透明；等於或高於此值的像素變為不透明。 |

對於固定的 alpha 調變，透明度與不透明度是互補的。例如，35% 透明度相當於 65% 的 alpha 調變量。

## **套用亮度與對比**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) 會回傳一個 [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 操作。其純量設定在建立操作時提供。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比提升 20%，然後在不修改內嵌圖像的情況下產生預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 圖片效果擴充，較標準的 DrawingML 亮度效果可移植性差。若亮度與對比在 PPTX 循環後必須保持可編輯，請使用 [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此差異。

## **套用色彩變換**

色彩效果可獨立套用於重用同一影像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 對應暗像素，`color2` 對應亮像素。這使它成為一個設定較為複雜的範例。

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) 會將每個像素的顏色取代為固定顏色，同時保留 alpha。它不同於 [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)，後者將一個來源顏色映射到另一個顏色，並暴露來源與目標的顏色格式。

### **套用亮度閾值**

亮度閾值可讓掃描頁面的淡淡痕跡更易於與背景區分。[add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) 保留中間的灰階階調。[add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) 將亮度映射為黑或白，而 [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 則對不透明度套用閾值。

亮度閾值範圍為 0% 到 100%，包含兩端。低於閾值的像素變為黑色，等於或高於閾值的像素變為白色。提升閾值會讓更多階調變為黑色，因為更多像素落在截止點以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至工作目錄。每個標籤顯示原始灰階等級（0‑255）。範例將原圖與兩個副本並排放置，並在簡報中保存每個副本的閾值。

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

在 PowerPoint 開啟輸出簡報以比較三個框。標記為 96 的色塊約有 38% 亮度（96/255）。在 20% 閾值時會變為白色，60% 閾值時會變為黑色。

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **新增模糊、透明度與 Alpha 效果**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) 會影響所有色彩通道，包括 alpha。當模糊邊緣可能延伸超出原始圖片邊界時，將 `grow` 設為 `True`。

若需均勻透明度，請使用 [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)。它會乘以每個現有的 alpha 值，使部分透明的像素保持比例差異。[add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) 則直接指定所有像素的單一 alpha 值。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 會根據閾值將 alpha 轉換為兩個等級。

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

其他無參數的 alpha 操作包括 [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)，會使所有非零 alpha 完全不透明；[add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)，會使低於 100% 的 alpha 完全透明；以及 [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)，會將 alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add_..._effect` 方法都會將新操作追加到集合的末端。渲染器會將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，以此類推。因此，以不同順序排列相同操作可能產生不同影像。

例如，先做灰階再做色調會先移除色彩資訊再重新上色；相反的順序則會再次移除色調。類似地，Alpha 取代可以覆寫先前操作計算的 alpha，而 Alpha 調變則保留它們的相對差異。

以下範例建立四個操作的鏈，儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會施加相容性矩陣限制顏色、alpha 與模糊操作必須分開鏈。它們可以組合，雖然組合不一定有用。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會移除兩個選定顏色；Alpha ceiling、floor、replace 或 bi‑level 操作會拋棄先前建立的 alpha 細節。請依照所需的像素處理順序建立鏈，而不是把項目視為無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![相同圖像先經過灰階再經過色調，與先經過色調再經過灰階。兩個最終的灰階圖像呈現不同的色調。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此 Aspose.Slides for .NET 26.11 示意渲染中，220° 色調以 25% 施加時，灰階圖像保持不變。先施加相同的色調再做灰階會產生不同的色調。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `Picture.image_transform` 中的物件。依效果不同，它可能直接暴露可寫成員。例如，[Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) 暴露可寫的 `radius` 與 `grow` 屬性；[AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) 暴露可寫的 `amount` 屬性；[AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) 暴露可寫的 `threshold` 屬性。像 [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) 這類色彩效果則暴露可變的 [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) 物件。

某些操作，包括 [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/)、以及 [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/)，不會將建立時的純量以可寫屬性暴露。若要變更這些設定，請移除該操作並在所需位置加入替代操作。

`get_effective()` 回傳的有效資料是計算後的唯讀值。它對於解析主題依賴的顏色以及讀取渲染器使用的正規化值很有幫助，但不構成另一個編輯介面。以下範例列舉鏈並在 API 提供時檢查有效值：

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

無參數的效果如灰階、alpha ceiling、alpha inverse 仍會有有效資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置才是重要資訊。

## **移除或清除圖像變換**

使用 [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) 依索引移除單一操作。因為移除後索引會變動，請先搜尋目標再於列舉後移除。使用 `clear()` 可以移除整條鏈。

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

移除或清除變換僅會改變圖片的格式設定。它不會刪除、重新壓縮或以其他方式改變被重用的 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換源自 DrawingML，所以 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是每個操作都具完全相同的可移植性：

- 標準 DrawingML 操作如亮度、灰階、雙調、色調、HSL、模糊與一般 alpha 操作最有機會在 PPTX 循環後存活。若需保留，請重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 為 Office 2010 擴充，而非標準 DrawingML 亮度操作。它可用於記憶體渲染，但無法保證在儲存與重新開啟 PPTX 後仍以可編輯的 `BrightnessContrast` 形式存在。請使用 [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 以取得持久的亮度與對比調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援子集，或以近似方式呈現。不要將 PPT 作為驗證複雜可編輯鏈的格式。
- 輸出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺格式時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `ImageTransformOperationCollection`；點陣格式會將結果平鋪成像素，文件或向量匯出則儲存自己的渲染表示。
- 效果不會使連結的圖像變成自包含。若圖片是連結的，渲染時仍需該連結資源在載入簡報時可取得。

不同的簡報觀看器在處理邊緣案例時可能表現不同，尤其是同時結合多個 alpha 或顏色量化操作時。對於關鍵輸出，請使用與正式環境相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**圖像變換效果會修改內嵌圖像資料嗎？**

不會。這些操作屬於由圖片填充使用的 `Picture`。底層的 `PPImage` 位元組保持不變。

**兩個重用同一圖像的圖片框會共享它們的效果嗎？**

不會。重用 `PPImage` 可避免重複的影像資料，但每個圖片框通常都有各自的 `Picture` 與圖像變換集合。

**可以同時結合顏色、模糊與 alpha 效果嗎？**

可以。集合接受它們在同一條有序鏈中。請考慮每個操作對前一個輸出的影響，因為取代與閾值操作可能會丟棄先前的顏色或 alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。若操作在變換集合中有可寫成員，請在那裡編輯；若沒有，請移除該操作並以新建立參數加入替代品。

**應該使用哪種格式來保留變換鏈？**

使用 PPTX，並透過重新開啟檔案驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式只保留外觀，無法保留可編輯的變換操作。