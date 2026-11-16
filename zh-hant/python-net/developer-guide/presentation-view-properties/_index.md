---
title: 在 Python 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/python-net/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 垂直分割線貼齊
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 來設定 PowerPoint 簡報中普通檢視的版面配置、投影片與備註的縮放、格線間距以及註解可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視中，投影片顯示在側邊預覽窗格（縮圖或大綱）與下方備註窗格之間。Aspose.Slides for Python via .NET 透過 [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 透露已儲存的編輯偏好設定。這些包括窗格佈局、縮放等級、格線間距以及註解可見性。

## **關於 NormalViewProperties**

使用 [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) 來存取 [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) 物件。[show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) 控制是否在大綱中於投影片標題旁顯示圖示。[snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) 讓側邊窗格在使用者縮小時自動貼齊至最小化狀態。[prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) 表示在完整視窗中顯示單一窗格的偏好。

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) 控制側邊窗格與投影片之間的分割線。[horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) 控制備註窗格上方的分割線。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 的 `MINIMIZED`、`MAXIMIZED` 或 `RESTORED` 值。

<!-- visual-explanation:presentation-view-properties:start -->
[![概念性編輯器將側邊面板、投影片區域與底部區域分開，並標示垂直與水平分割線。](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*在普通檢視中，垂直分割線控制側邊窗格的寬度。水平分割線控制備註窗格上方的空間。*
<!-- visual-explanation:presentation-view-properties:end -->

## **關於 還原 NormalViewProperties**

當分割線被還原時，[restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) 提供側邊窗格的已儲存大小，而 [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) 提供上方投影片區域的已儲存大小。兩者皆公開 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/)。其 [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) 屬性接受 0 到 100 的百分比，且 [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) 控制編輯器在視窗調整大小時是否自動調整尺寸。

此範例更新現有的簡報。它還原水平分割線，將 [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) 設為 80% 並啟用自動調整，且將垂直分割線最大化。它同時為大綱檢視啟用 [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/)。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設縮放值**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) 與 [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) 為編輯器存放獨立的縮放設定。這些設定不會影響投影片尺寸、投影片播放或影像匯出的解析度。

此範例開啟現有簡報，並啟用 [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) 以使投影片符合編輯視窗。對於備註頁面，它停用自動縮放，並將 [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) 設為固定的 80% 縮放。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **設定格線間距**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) 設定整個簡報編輯格線之間的距離。它接受正數點值，1 吋等於 72 點。本範例列印現有簡報的目前間距，並透過將間隔設定為 18 點來儲存四分之一吋的格線。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

格線以固定間隔重複。[Drawing guides](/slides/zh-hant/python-net/drawing-guides/) 標示個別的水平或垂直位置。兩者皆為編輯輔助，僅在顯示的編輯器中出現。投影片放映與匯出為 PDF、影像或 SVG 時會省略它們。

## **開啟簡報時顯示或隱藏註解**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) 儲存相容編輯器在開啟簡報時使用的偏好設定。對於包含註解的現有簡報，此範例列印目前設定，並儲存一個隱藏註解的副本。它亦將 [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) 設為 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/)，使副本以投影片檢視開啟。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

隱藏註解會保留其文字、作者、位置、回覆與狀態。如需變更註解本身，請參閱 [Presentation Comments](/slides/zh-hant/python-net/presentation-comments/)。匯出設定會控制註解是否出現在 PDF、HTML、影像、備註或講義中。

## **常見問題**

**重新開啟簡報時為何看不到格線？**

簡報會儲存格線間隔。若要看到格線，請在編輯器中啟用格線顯示。

**清除繪圖參考線會改變格線間距嗎？**

不會。新增、移動或清除參考線均不會改變格線間隔。

**簡報的不同章節可以有不同的檢視設定嗎？**

不會。[Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 套用於整個簡報。

**我可以為不同使用者儲存不同的檢視設定嗎？**

檔案僅儲存一組檢視屬性供所有人使用。編輯器亦可能套用使用者本機的偏好設定。

**我可以在範本中儲存檢視設定嗎？**

可以。從該範本建立的簡報會繼承其儲存的檢視設定。