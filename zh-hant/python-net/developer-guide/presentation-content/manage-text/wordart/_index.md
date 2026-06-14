---
title: 在 Python 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/python-net/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 顯示效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中建立與自訂 WordArt 效果。本分步指南協助開發人員使用 Python 在簡報中加入時尚、專業的文字。"
---
## **概觀**

WordArt 效果讓您能在 PowerPoint 簡報中加入視覺吸引、樣式化的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、客製化及管理 WordArt，完全如同在 Microsoft PowerPoint 中操作，且不需要安裝 Office。本文章提供有關 WordArt 的使用概觀，說明如何套用文字變形、填充樣式、輪廓、陰影及其他格式選項，讓簡報內容更具表現力與吸引力。WordArt 允許您將文字視為圖形物件。它由套用於文字的各種效果或特殊修改組成，使文字更具吸引力或顯眼。

**Microsoft PowerPoint 中的 WordArt**

若要在 Microsoft PowerPoint 中使用 WordArt，必須選取其中一個預先定義的 WordArt 範本。WordArt 範本是一組會套用至文字或其形狀的效果。

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for Python via .NET 20.10 中，我們實作了對 WordArt 的支援，並在後續的 Aspose.Slides for Python via .NET 版本中持續改進此功能。

使用 Aspose.Slides for Python via .NET，您可以輕鬆在 Python 中建立自己的 WordArt 範本（單一效果或多種效果的組合），並將其套用於文字。

## 建立簡易 WordArt 範本並套用於文字

**使用 Aspose.Slides**

首先，我們使用以下 Python 程式碼建立一段簡單的文字：

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
接著，我們透過以下程式碼將文字的字型高度設定為較大的值，以讓效果更為明顯：

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表您可以選取預先定義的 WordArt 效果；在左側功能表則可指定新 WordArt 的設定。

以下是部分可用的參數或選項：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

此處，我們使用以下程式碼將 SmallGrid 圖案顏色套用到文字，並加入寬度為 1 的黑色文字邊框：

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

產生的文字如下：

![todo:image_alt_text](image-20200930114108-4.png)

## 套用其他 WordArt 效果

**使用 Microsoft PowerPoint**

在程式介面中，您可以將這些效果套用至文字、文字區塊、形狀或類似元件：

![todo:image_alt_text](image-20200930114129-5.png)

例如，陰影、反射與發光效果可套用於文字；3D 格式與 3D 旋轉效果可套用於文字區塊；柔化邊緣屬性可套用於形狀物件（即使未設定 3D 格式屬性仍會產生效果）。

### 套用陰影效果

此處我們僅針對文字設定相關屬性，並使用以下 Python 程式碼將陰影效果套用至文字：

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

Aspose.Slides API 支援三種陰影類型：OuterShadow、InnerShadow 與 PresetShadow。

使用 PresetShadow 時，您可以套用預設值的文字陰影。

**使用 Microsoft PowerPoint**

PowerPoint 只提供一種陰影類型。以下為範例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 其實允許同時套用兩種陰影：InnerShadow 與 PresetShadow。

**注意事項：**

- 同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。  
- 若同時使用 OuterShadow 與 InnerShadow，實際套用的效果取決於 PowerPoint 版本。例如在 PowerPoint 2013 中，效果會加倍；在 PowerPoint 2007 中則僅套用 OuterShadow 效果。

### 套用顯示效果於文字

我們透過以下 Python 程式碼為文字加入顯示效果：

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

### 套用發光效果於文字

以下程式碼將發光效果套用至文字，使其發亮或突顯：

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

操作結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}  
您可以變更陰影、顯示與發光的參數。這些效果的屬性會分別設定於文字的每個段落。  
{{% /alert %}}  

### 在 WordArt 中使用變形

我們透過以下程式碼使用 Transform 屬性（套用於整個文字區塊）：

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

結果如下：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}  
Microsoft PowerPoint 與 Aspose.Slides for Python via .NET 皆提供一定數量的預先定義變形類型。  
{{% /alert %}}  

**使用 PowerPoint**

前往 **格式** → **文字效果** → **變形** 即可存取預先定義的變形類型。

**使用 Aspose.Slides**

使用 `TextShapeType` 列舉即可選取變形類型。

### 套用 3D 效果於文字與形狀

以下範例程式碼將 3D 效果套用至文字形狀：

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

產生的文字與形狀如下：

![todo:image_alt_text](image-20200930114816-9.png)

我們使用以下 Python 程式碼將 3D 效果套用至文字：

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

操作結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}}  
文字或其形狀套用 3D 效果以及效果之間的相互作用遵循特定規則。

以文字與包含該文字之形狀的場景為例。3D 效果包含 3D 物件表示以及物件所在的場景。

- 當形狀與文字皆設定了場景時，形狀的場景具有較高優先權，文字的場景會被忽略。  
- 當形狀未設定自身場景但具有 3D 表示時，會使用文字的場景。  
- 其他情況——若形狀本身未有 3D 效果，則形狀保持平面，3D 效果僅套用於文字。

相關說明可參考 [ThreeDFormat.LightRig]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/{{% endraw %}}) 與 [ThreeDFormat.Camera]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/{{% endraw %}}) 屬性。  
{{% /alert %}}  

## **套用外部陰影效果於文字**
Aspose.Slides for Python via .NET 提供 [**IOuterShadow**]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/ioutershadow/{{% endraw %}}) 與 [**IInnerShadow**]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/iinnershadow/{{% endraw %}}) 類別，允許您對 TextFrame 中的文字套用陰影效果。請依照以下步驟操作：

1. 建立 [Presentation]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/{{% endraw %}}) 類別的執行個體。  
2. 以索引取得投影片的參考。  
3. 在投影片中加入類型為 Rectangle 的 AutoShape。  
4. 取得與 AutoShape 關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 實例化 OuterShadow 類別。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectanglelAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫入 PPTX 檔案。

以下 Python 範例程式碼示範如上步驟，說明如何對文字套用外部陰影效果：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # 取得投影片的參考
    sld = pres.slides[0]

    # 新增一個矩形類型的 AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 為矩形新增 TextFrame
    ashp.add_text_frame("Aspose TextBox")

    # 停用形狀填充，以便取得文字的陰影
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 新增外部陰影並設定所有必要參數
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #將簡報寫入磁碟
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **套用內部陰影效果於形狀**
請依照以下步驟操作：

1. 建立 [Presentation]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/{{% endraw %}}) 類別的執行個體。  
2. 取得投影片的參考。  
3. 加入類型為 Rectangle 的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫入 [PPTX]({{% raw %}}https://docs.fileformat.com/presentation/pptx/{{% endraw %}}) 檔案。

以下範例程式碼（依上述步驟）示範如何在 Python 中於兩個形狀之間新增連接線：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # 取得投影片的參考
    slide = presentation.slides[0]

    # 新增一個矩形類型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 為矩形新增 TextFrame
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # 啟用 inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 設定所有必要的參數
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # 將 ColorType 設為 Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # 設定 Scheme 顏色
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # 儲存簡報
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**是否能將 WordArt 效果套用於不同字型或文字系統（例如阿拉伯文、中文）？**  
可以，Aspose.Slides 支援 Unicode，並可與所有主流字型與文字系統配合使用。無論語言為何，都可套用陰影、填色與輪廓等 WordArt 效果，惟字型的可用性與呈現可能取決於系統安裝的字型。

**是否能將 WordArt 效果套用於投影片母片元素？**  
可以，您能將 WordArt 效果套用於母片投影片上的形狀，包括標題佔位符、頁腳或背景文字。對母版版面的變更會在所有相關投影片中反映。

**WordArt 效果會影響簡報檔案大小嗎？**  
會有微小影響。陰影、發光、漸層填充等效果會因為額外的格式資訊而略增檔案大小，但差異通常可以忽略不計。

**是否可以在不儲存簡報的情況下預覽 WordArt 效果的結果？**  
可以，您可使用 [Shape]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/{{% endraw %}}) 或 [Slide]({{% raw %}}https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/{{% endraw %}}) 類別的 `get_image` 方法將包含 WordArt 的投影片渲染為圖像（如 PNG、JPEG），從而在記憶體或螢幕上預覽結果，無需先儲存完整的簡報。