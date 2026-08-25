---
title: 使用 Python 管理簡報中的影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/python-net/image-transform-effects/
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
- 效果鍊
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python（透過 .NET）套用、串接、檢查、移除並驗證圖片框的影像變換效果。"
---
## **概述**

Aspose.Slides 以有序的影像變換操作集合來表示圖片調整。對於圖片框，從該框的 [Picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/) 開始，存取其 [image_transform](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/image_transform/) 屬性。回傳的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/) 讓您能在不重新寫入原始影像位元組的情況下，追加、列舉、檢查、移除以及清除效果。

本篇文章示範完整的工作流程，涵蓋亮度與對比度、色彩變換、模糊、透明度、有序效果鍊、實際值、移除，以及 PPTX 循環驗證。

## **了解效果所有權與圖像重用**

影像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 儲存或參照簡報擁有的來源影像資料。
- [Picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/) 屬於圖片填充，參考影像資源，同時保存影像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 為投影片形狀，擁有相應的圖片填充、幾何形狀、裁切設定以及其他框層級格式。

因此，影像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 中的位元組。當相同的 `PPImage` 被多次傳遞給 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 時，每個新圖片框都會取得自己的 `Picture` 與自己的變換集合。對一個框套用灰階不會讓其他框變成灰階，即使它們共用相同的嵌入影像資源。

相同的 `Picture.image_transform` 模型也被其他圖片填充使用，例如形狀或投影片背景。下列範例專注於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定函式庫版本不會立即拒絕每個超出範圍的值，也請保持在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、省略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`、`contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | 無 | 無數值參數。Alpha 不變。 |
| [add_duotone_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`、`color2` | 兩個顏色分別對應暗像素與亮像素。RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [add_tint_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`、`amount` | Hue 為 `0`（含）到 `360`（不含）度；amount 為 `-100` 到 `100`，百分比。 |
| [add_hsl_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`、`saturation`、`luminance` | Hue 為 `0`（含）到 `360`（不含）度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 替換顏色的通道值為 `0` 到 `255`。現有的 Alpha 值保持不變。 |
| [add_blur_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`、`grow` | 半徑為非負值，以點為單位；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通的不透明度縮放：`0` 為完全透明，`100` 保留現有 Alpha。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明，等於或高於此值的像素變為不透明。 |

對於固定的 Alpha 調變，透明度與不透明度是互補的。例如，35% 透明度等同於 65% 的 Alpha 調變量。

## **套用亮度與對比度**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) 會回傳一個 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/brightnesscontrast/) 操作。其純量設定在建立操作時即提供。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入影像的情況下渲染預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/brightnesscontrast/) 為 Office 2010 圖片效果擴充，較不具可移植性，較標準的 DrawingML 亮度效果來說。當需要在 PPTX 循環後仍能編輯亮度與對比度時，請使用 [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此差異。

## **套用色彩變換**

即使多個圖片框共用同一影像資源，仍可獨立套用色彩效果。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/duotone/) 包含兩個可獨立編輯的色彩參數：`color1` 映射暗像素，`color2` 映射亮像素。此範例說明了設定比單一純量更複雜的效果。

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

[add_color_replace_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [add_color_change_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)，後者將一個來源色映射到另一個目標色，並公開來源與目標的色彩格式。

## **加入模糊、透明度與 Alpha 效果**

[add_blur_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) 會影響所有色彩通道，包括 Alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `True`。

若需均勻透明度，請使用 [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)。它會乘以每個現有的 Alpha 值，使部分透明的像素仍保持比例差異。[add_alpha_replace_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) 則會將所有像素指派為同一 Alpha 值。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 會根據閾值將 Alpha 轉為兩個等級。

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

其他無參數的 Alpha 操作包括 [add_alpha_ceiling_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)，會將所有非零 Alpha 變為完全不透明；[add_alpha_floor_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)，會將低於 100% 的 Alpha 變為完全透明；以及 [add_alpha_inverse_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)，會將 Alpha 變為 `100% - alpha`。

## **建立有序的效果鍊**

每個 `add_..._effect` 方法會把新操作附加到集合的末端。渲染器將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，同樣的操作若以不同順序排列，會產生不同的影像。

例如，先套用灰階再套用色調會先移除色彩資訊，再對亮度結果上色。先套用色調再套用灰階則會再次移除色調。類似地，Alpha 取代可以覆寫先前操作計算出的 Alpha，而 Alpha 調變則會保留相對差異。

以下範例建立四個操作的鍊，將其儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會強加相容性矩陣限制顏色、Alpha 與模糊操作必須分開鍊。它們可以組合，但組合未必都有用處。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會移除兩個選定的顏色；Alpha ceiling、floor、replace 或 bi‑level 操作會捨棄先前產生的 Alpha 細節。請依據所需的像素處理順序建立鍊，而不要將其項目視為無序的格式旗標。

## **檢查可編輯與實際值**

可編輯的操作是存於 `Picture.image_transform` 中的物件。依效果不同，可能直接公開可寫成員。例如，[Blur](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/blur/) 公开可寫的 `radius` 與 `grow` 屬性；[AlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/alphamodulatefixed/) 公开可寫的 `amount` 屬性；[AlphaBiLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/alphabilevel/) 公开可寫的 `threshold` 屬性。像 [Duotone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/duotone/) 這樣的顏色效果則公開可變的 [ColorFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/colorformat/) 物件。

某些操作，如 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/tint/) 與 [AlphaReplace](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/alphareplace/)，不會將建立時的純量以可寫屬性公開。若要變更這些設定，必須移除該操作並在相同位置加入新操作。

`get_effective()` 回傳的實際資料是計算後的唯讀值。它對於解析主題依賴的顏色以及讀取渲染器使用的正規化值很有幫助，但不是另一個可編輯的介面。以下範例列舉鍊並在相應 API 提供的情況下檢查實際值：

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

未帶參數的效果（如灰階、Alpha ceiling、Alpha inverse）仍會有實際資料物件，只是沒有可列印的純量設定。它們在集合中的存在與位置即是重要資訊。

## **移除或清除影像變換**

使用 [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) 以索引移除單一操作。因為移除後索引會改變，請先搜尋目標索引，再在列舉之後移除。使用 `clear()` 可移除整個鍊。

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

移除或清除變換僅會變更圖片的格式設定。它不會刪除、重新壓縮或以其他方式改變共用的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換源自 DrawingML，因此 PPTX 是效果鍊的首選可編輯格式。即使使用 PPTX，也不是每個操作都有相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊與常見 Alpha 操作）最有可能在 PPTX 循環後存留下來。若有保存需求，請在產生檔案後重新開啟並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的擴充，而非標準 DrawingML 亮度操作。它可用於記憶體內渲染，但無法保證在儲存與重新開啟 PPTX 後仍保留為可編輯的 `BrightnessContrast` 操作。請改用 [add_luminance_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 以獲得持久的亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鍊縮減為支援子集，或以近似方式呈現。不要使用 PPT 作為複雜可編輯鍊的驗證格式。
- 渲染至 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鍊套用於渲染結果。這些輸出不會包含可編輯的 `ImageTransformOperationCollection`；點陣格式會將結果平舖成像素，文件或向量匯出則保存自己的渲染表示。
- 效果不會讓鏈結的影像變成自包含。若圖片是鏈結的，渲染時仍需確保鏈結資源可用。

不同的簡報檢視器可能會對邊緣案例有不同的渲染結果，特別是同時結合多個 Alpha 或色彩量化操作時。對於關鍵輸出，請使用生產環境中相同版本的 Aspose.Slides 同時測試可編輯的循環與最終匯出格式。

## **常見問題集**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些操作屬於圖片填充使用的 `Picture`，底層的 `PPImage` 位元組保持不變。

**重複使用相同影像的兩個圖片框會共享它們的效果嗎？**

不會。重複使用 `PPImage` 只會避免重複存儲影像資料，但每個圖片框通常都有各自的 `Picture` 與影像變換集合。

**顏色、模糊與 Alpha 效果可以一起使用嗎？**

可以。集合接受它們在同一有序鍊中。請考慮每個操作對前一操作輸出的影響，因為取代與閾值操作可能會捨棄先前的顏色或 Alpha 細節。

**為什麼實際值是唯讀的？**

實際資料代表渲染時使用的計算值，包含已解析的顏色。請在變換集合中編輯具有可寫成員的操作；若無，可先移除該操作，再以新參數加入替代品。

**應該使用哪種格式來保存變換鍊？**

使用 PPTX，並在重新開啟檔案後驗證。舊版 PPT 無法完整表達 DrawingML 效果模型，而渲染的匯出格式僅保留外觀，並不包含可編輯的變換操作。