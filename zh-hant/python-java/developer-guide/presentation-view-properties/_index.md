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
- 貼齊垂直分割條
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
description: "探索 Aspose.Slides for Python via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片—調整版面配置、縮放層級與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、一個側邊內容區域以及一個底部內容區域。普通檢視屬性描述這些內容區域的位置。此資訊允許應用程式將其檢視狀態儲存至檔案，以便重新開啟時檢視仍維持在上次儲存簡報時的相同狀態。

已新增方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 以提供對簡報普通檢視屬性的存取。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/) 與 [NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/) 類別以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 NormalViewProperties**

表示普通檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定當在普通檢視模式的任一內容區域顯示大綱內容時，應用程式是否顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定當側邊區域足夠小時，垂直分割條是否應自動貼齊至最小化狀態。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定使用者是否偏好以全視窗單一內容區域取代具三個內容區域的標準普通檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示於整個視窗中。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開；垂直分割條將投影片與側邊內容區域分開。可能的值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Maximized) 與 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定普通檢視中頂部或側邊投影片區域的尺寸，當 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored) 值分別套用於 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 時。

## **關於復原 NormalViewProperties**

指定普通檢視中投影片區域的尺寸（若為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子項則為寬度，若為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子項則為高度），當該區域為可變的復原大小（既非最小化也非最大化）時。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定投影片區域的大小（若為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子項則為寬度，若為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子項則為高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動調整以補償新的尺寸。

以下範例顯示如何存取簡報的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # 還原簡報的檢視屬性。
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定預設縮放值**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 支援設定預設縮放值，使其在簡報開啟時即已套用。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/) 來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNotesViewProperties) 都可程式化設定。在本主題中，我們將示範如何為 Aspose.Slides 中的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 設定 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)。
{{% /alert %}}

要設定檢視屬性，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)。
1. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例中，我們同時設定投影片檢視與備註檢視的縮放值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 設定簡報的檢視屬性。
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # 投影片檢視的縮放百分比。
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # 備註檢視的縮放百分比。

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定格線間距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 取得整個簡報的檢視設定。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getGridSpacing) 與 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setGridSpacing) 方法可讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點 (point) 為單位，72 點等於一英吋。請使用正值，符合 API 文件的要求。

下列範例會開啟既有的 `demo.pptx`、印出其目前的格線間距、設定為四分之一英吋的間隔，然後儲存結果。

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

格線不同於 [drawing guides](/slides/zh-hant/python-java/drawing-guides/)。格線間距控制固定的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會變更格線間距。

格線與繪圖參考線皆為編輯輔助工具。它們不會在 PDF、圖像、SVG 或投影片放映中以投影片內容呈現。儲存格線間距並不保證編輯器會顯示格線：其可見性亦取決於檢視器或編輯器的設定。

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**  
檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可見性設定。

**Does clearing drawing guides change the grid spacing?**  
不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會改變已儲存的格線間隔。

**Can I set different view settings for different sections of a presentation?**  
[View settings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 定義於簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），而非每個章節，因此在開啟文件時，整個文件皆套用同一組參數。

**Can I predefine different view states for different users?**  
不能。設定儲存在檔案中，屬於共享的。觀賞應用程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**Can I prepare a template with predefined View Properties so new presentations open the same way?**  
可以。由於 [view properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 儲存在簡報層級，您可以將其嵌入模板，並以此建立新文件，讓其具有相同的初始檢視設定。