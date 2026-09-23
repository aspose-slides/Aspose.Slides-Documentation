---
title: 在 Python via Java 中檢索並更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/python-java/presentation-view-properties/
keywords:
- 檢視屬性
- 一般檢視
- 大綱內容
- 大綱圖示
- 自動貼齊垂直分割條
- 單一檢視
- 條狀狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java 的檢視屬性，以自訂 PPT、PPTX 和 ODP 投影片——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

一般檢視包含三個內容區域：投影片本身、側邊內容區域以及底部內容區域。一般檢視屬性描述這些內容區域的定位。此資訊允許應用程式將檢視狀態儲存至檔案，讓重新開啟時檢視與最後一次儲存簡報時的狀態相同。

已新增方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 以提供存取簡報的一般檢視屬性。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/) 與 [NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/) 類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 NormalViewProperties**

表示一般檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 與 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定當在一般檢視模式的任何內容區域顯示大綱內容時，應用程式是否顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 與 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小化狀態。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 與 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定使用者是否偏好在全視窗中僅顯示單一內容區域，而非具有三個內容區域的標準一般檢視。啟用後，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割條應呈現的狀態。水平分割條將投影片與投影片下方的內容區域分開；垂直分割條將投影片與側邊內容區域分開。可能的值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Maximized) 與 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定一般檢視中上方或側邊投影片區域的尺寸，當 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored) 值分別套用於 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 時。

## **關於 還原 NormalViewProperties**

指定一般檢視中投影片區域的尺寸（當為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子項時為寬度，當為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子項時為高度），此區域為可變的還原大小（既非最小化亦非最大化）。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定投影片區域的大小（當為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子項時為寬度，當為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子項時為高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動補償新的尺寸。

以下範例示範如何為簡報存取 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)。

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
Aspose.Slides for Python via Java 支援設定預設縮放值，讓簡報開啟時即套用。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/) 來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNotesViewProperties) 都可以以程式方式配置。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)。
{{% /alert %}}

若要設定檢視屬性，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)。
1. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例中，我們為投影片檢視與備註檢視同時設定縮放值。

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
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # 筆記檢視的縮放百分比。

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定格線間距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 以存取整份簡報的檢視設定。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getGridSpacing) 與 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setGridSpacing) 方法可讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點為單位指定，72 點等於一英吋。請使用正值，依 API 文件的要求。

以下範例開啟現有的 `demo.pptx`，列印其目前的格線間距，設定為四分之一英吋的間隔，並儲存結果。

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

格線與 [drawing guides](/slides/zh-hant/python-java/drawing-guides/) 不同。格線間距控制固定的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會變更格線間距。

格線與繪圖參考線皆為編輯輔助工具。它們不會以投影片內容呈現在 PDF、影像、SVG 或投影片放映中。儲存格線間距並不保證編輯器會顯示格線；其可見性亦取決於檢視器或編輯器的偏好設定。

## **開啟簡報時顯示或隱藏評論**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 以存取整份簡報的檢視設定。使用 [ViewProperties.getShowComments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getShowComments) 與 [ViewProperties.setShowComments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setShowComments) 讀取或變更在 PowerPoint 或其他相容編輯器開啟簡報時是否顯示評論的儲存偏好。

此設定僅控制儲存的檢視偏好。它不會新增、移除、編輯或解決評論。隱藏評論會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/python-java/presentation-comments/) 了解變更評論本身的操作。

以下範例需要一個包含評論的現有 `comments.pptx`。它列印目前的可見性設定，要求隱藏評論，並儲存新的 PPTX 而不移除任何評論。它同時使用 [ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setLastView) 搭配 [ViewType.SlideView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewtype/#SlideView) 來配置初始編輯檢視與評論可見性的設定。

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

此設定不會決定評論是否會包含在 PDF、HTML、影像、備註或講義的匯出中。請分別設定相關的匯出特定選項。

## **常見問題**

**為何重新開啟簡報後格線不可見？**  
檔案會儲存格線間距，但顯示與否由編輯器控制。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**  
不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會更改已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**  
[檢視設定](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 定義於簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），而非依章節，因此開啟時整個文件僅套用同一組參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**  
不能。設定儲存在檔案中，且為共享。檢視程式可能會尊重使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以準備一個預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**  
可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 儲存在簡報層級，您可以將其嵌入範本，並以此建立新文件，使其具有相同的初始檢視設定。