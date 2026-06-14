---
title: 在 Python 中管理簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/python-net/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 實色
- 漸層顏色
- 圖像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 檔案中設定動態背景，並提供程式碼技巧以提升您的簡報效果。"
---
## **簡介**

實心顏色、漸層和圖像通常用於投影片背景。您可以為 **普通投影片**（單張投影片）或 **母版投影片**（一次套用至多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **設定實色背景於普通投影片**

Aspose.Slides 允許您為簡報中的特定投影片設定實色作為背景——即使簡報使用母版投影片。此變更僅套用於所選的投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/backgroundtype/) 設為 `OWN_BACKGROUND`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `SOLID`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/) 上的 `solid_fill_color` 屬性來指定實色背景顏色。
5. 儲存已修改的簡報。

以下 Python 範例示範如何將藍色實色設為普通投影片的背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 將投影片的背景顏色設定為藍色。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # 將簡報儲存至磁碟。
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **設定實色背景於母版投影片**

Aspose.Slides 允許您為簡報中的母版投影片設定實色作為背景。母版投影片作為控制所有投影片格式的範本，因此當您為母版投影片的背景選擇實色時，會套用到每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 將母版投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/backgroundtype/)（透過 `masters`）設為 `OWN_BACKGROUND`。
3. 將母版投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `SOLID`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/) 上的 `solid_fill_color` 屬性來指定實色背景顏色。
5. 儲存已修改的簡報。

以下 Python 範例示範如何將實色（森林綠）設定為母版投影片的背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # 將母版投影片的背景顏色設定為森林綠。
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # 將簡報儲存至磁碟。
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **設定投影片的漸層背景**

漸層是一種透過顏色逐漸變化所產生的圖形效果。作為投影片背景使用時，漸層能讓簡報看起來更具藝術感與專業感。Aspose.Slides 允許您將漸層顏色設定為投影片的背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/backgroundtype/) 設為 `OWN_BACKGROUND`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `GRADIENT`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/) 上的 `gradient_format` 屬性來配置您偏好的漸層設定。
5. 儲存已修改的簡報。

以下 Python 範例示範如何將漸層顏色設為投影片的背景：

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 套用漸層效果至背景。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 將簡報儲存至磁碟。
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **設定影像為投影片背景**

除了實色與漸層填充外，Aspose.Slides 還允許您使用影像作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/backgroundtype/) 設為 `OWN_BACKGROUND`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PICTURE`。
4. 載入您想用作投影片背景的影像。
5. 將影像加入簡報的影像集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/) 上的 `picture_fill_format` 屬性將影像指定為背景。
7. 儲存已修改的簡報。

以下 Python 範例示範如何將影像設定為投影片的背景：

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 設定背景圖像屬性。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 載入圖像。
    with slides.Images.from_file("Tulips.jpg") as image:
        # 將圖像加入簡報的圖像集合。
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # 將簡報儲存至磁碟。
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

以下程式碼範例示範如何將背景填充類型設為平鋪圖片並修改平鋪屬性：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # 設定用於背景填充的圖像。
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # 設定圖片填充模式為平鋪，並調整平鋪屬性。
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
閱讀更多：[**平鋪圖片作為紋理**](/slides/zh-hant/python-net/shape-formatting/#tile-picture-as-texture)
{{% /alert %}}

### **變更背景影像透明度**

您可能想調整投影片背景影像的透明度，以使投影片內容更突出。以下 Python 程式碼示範如何變更投影片背景影像的透明度：

```python
transparency_value = 30  # 例如。

# 取得圖片變形操作的集合。
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# 尋找已存在的固定比例透明度效果。
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# 設定新的透明度值。
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ibackgroundeffectivedata/) 類別，用於取得投影片的有效背景值。此類別公開有效的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 類別的 `background` 屬性，您可以取得投影片的有效背景。

以下 Python 範例示範如何取得投影片的有效背景值：

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 取得有效的背景，考慮母版、版面配置和主題。
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **常見問題**

**我可以重設自訂背景並恢復佈景主題/版面配置的背景嗎？**

可以。移除投影片的自訂填充，背景將再次從相應的 [layout](/slides/zh-hant/python-net/slide-layout/)/[master](/slides/zh-hant/python-net/slide-master/) 投影片繼承（即 [theme background](/slides/zh-hant/python-net/presentation-theme/)）。

**如果之後變更簡報的佈景主題，背景會發生什麼變化？**

如果投影片有自己的填充，則保持不變。若背景是繼承自 [layout](/slides/zh-hant/python-net/slide-layout/)/[master](/slides/zh-hant/python-net/slide-master/)，則會更新以匹配 [new theme](/slides/zh-hant/python-net/presentation-theme/)。