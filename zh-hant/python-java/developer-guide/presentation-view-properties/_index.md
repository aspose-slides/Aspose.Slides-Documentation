---
title: 在 Python via Java 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/python-java/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 垂直分割條貼齊
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 來設定 PowerPoint 簡報的普通檢視版面配置、投影片與備註的縮放、格線間距以及評論可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視中，投影片位於左側縮圖或大綱窗格與下方備註窗格之間。Aspose.Slides for Python via Java 透過 [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) 暴露簡報已儲存的編輯偏好設定。這些設定包括窗格版面配置、縮放層級、格線間距與評論顯示方式。

## **關於 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 取得 [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) 類別。  
[setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 控制是否在大綱中於投影片標題旁顯示圖示。  
[setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 讓側邊窗格在使用者縮小時自動貼齊至最小化狀態。  
[setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 表示偏好在整個視窗中僅顯示單一窗格。

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) 控制側邊窗格與投影片之間的分割條。  
[setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) 控制備註窗格上方的分割條。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **關於 還原 NormalViewProperties**

當分割條被還原時，[getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 提供側邊窗格的已儲存大小，而 [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 提供上方投影片區域的已儲存大小。兩者皆回傳 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) 的實例。其 [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) 控制編輯器在視窗大小變更時是否自動調整尺寸。

此範例會更新現有簡報。它還原水平分割條，將由 [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 取得的尺寸設定為 80% 並啟用自動調整，並將垂直分割條最大化。它也會呼叫 [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 以在大綱檢視中顯示圖示。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定預設縮放值**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 與 [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) 為編輯器儲存獨立的縮放設定。這些設定不會影響投影片尺寸、投影片放映播放或影像匯出解析度。

此範例開啟一個既有簡報，呼叫 [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) 以將投影片適配編輯視窗。對於備註頁面，會停用自動縮放並呼叫 [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) 將縮放固定為 80%。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定格線間距**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) 設定整個簡報中編輯格線之間的距離。它接受正值（單位為點），每英吋 72 點。此範例列印現有簡報的當前間距，並透過將間隔設定為 18 點來儲存四分之一英吋的格線。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

格線會以固定間隔重複。[Drawing guides](/slides/zh-hant/python-java/drawing-guides/) 標示個別的水平或垂直位置。兩者皆為編輯輔助工具，只會在顯示它們的編輯器中出現。投影片放映與匯出成 PDF、影像或 SVG 時皆不會包含這些指引。

## **在開啟簡報時顯示或隱藏評論**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) 儲存相容編輯器在開啟簡報時使用的偏好設定。針對已有評論的簡報，此範例列印目前設定，並儲存一份隱藏評論的副本。它同時呼叫 [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) 並以 [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) 作為參數，使副本以投影片檢視開啟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

隱藏評論會保留其文字、作者、位置、回覆與狀態。若要變更評論本身，請參閱 [Presentation Comments](/slides/zh-hant/python-java/presentation-comments/)。匯出設定會決定評論是否出現在 PDF、HTML、影像、備註或講義中。

## **常見問題**

**為什麼重新開啟簡報時格線會消失？**  
簡報會儲存格線間隔。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖指引會改變格線間距嗎？**  
不會。新增、移動或清除指引都不會影響格線間隔。

**簡報的不同區段可以有不同的檢視設定嗎？**  
不能。[Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) 會套用於整個簡報。

**我能為不同使用者儲存不同的檢視設定嗎？**  
檔案僅儲存一組檢視屬性供所有使用者使用。編輯器可能會套用使用者本機的偏好設定。

**我能在範本中儲存檢視設定嗎？**  
可以。從範本建立的簡報會繼承其已儲存的檢視設定。