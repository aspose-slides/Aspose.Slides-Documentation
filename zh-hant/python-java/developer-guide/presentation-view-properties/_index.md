---
title: 在 Python via Java 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/python-java/presentation-view-properties/
keywords:
- 檢視屬性
- 一般檢視
- 大綱內容
- 大綱圖示
- 垂直分割條自動貼齊
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
description: "探索 Aspose.Slides for Python via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片——調整版面配置、縮放層級與顯示設定。"
---
## **簡介**

一般檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。一般檢視屬性描述這些內容區域的位置。此資訊讓應用程式能將檢視狀態儲存至檔案，以便重新開啟時，檢視與上次儲存簡報時的狀態相同。

已新增 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 方法，以提供存取簡報的一般檢視屬性。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/) 類別以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 NormalViewProperties**

代表一般檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定在一般檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定當側邊區域足夠小時，垂直分割線是否應自動收合。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準一般檢視。啟用後，應用程式可能會選擇在整個視窗中顯示其中一個內容區域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開；垂直分割條將投影片與側邊內容區域分開。可能的值有： [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 和 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定在將 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/splitterbarstatetype/#Restored) 值套用至 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 時，一般檢視的側邊或上方投影片區域的大小。

## **關於還原 NormalViewProperties**

指定當區域為可變還原大小（既非最小化也非最大化）時，一般檢視的投影片區域（若為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子項則為寬度，若為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子項則為高度）的尺寸。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定投影片區域的大小（同上）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在調整包含該檢視之視窗大小時，側邊內容區域是否應自動補償新的尺寸。

以下範例示範如何存取簡報的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)。

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

Aspose.Slides for Python via Java 支援設定預設縮放值，讓簡報開啟時即套用。這可透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/) 來達成。可程式化設定 [getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 與 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNotesViewProperties)。本主題將示範如何為 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 設定 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)（使用 [Aspose.Slides](/slides/zh-hant/)）。

{{% /alert %}}

設定檢視屬性，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/)。
1. 將簡報寫入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

在下方範例中，我們同時為投影片檢視與備註檢視設定縮放值。

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

## **常見問題**

**我能為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 於簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），不是依章節切分。因此單一組參數在檔案開啟時套用於整個文件。

**我能為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，且為共用。檢視程式可能會遵守使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以建立包含預先定義 View Properties 的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getViewProperties) 儲存在簡報層級，您可以將其嵌入範本，然後以該範本建立新文件，從而取得相同的初始檢視設定。