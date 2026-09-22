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
- 快照垂直分割條
- 單一檢視
- 欄位狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放等級與顯示設定。"
---
## **簡介**

正常檢視由三個內容區域組成：投影片本身、側邊內容區域，以及底部內容區域。屬性描述了不同內容區域的定位方式。此資訊允許應用程式將檢視狀態儲存至檔案，以便重新開啟時檢視保持在最後一次儲存時的相同狀態。

已加入屬性 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/) 以提供對簡報正常檢視屬性的存取。

已加入 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewrestoredproperties/) 類別及其衍生類別，還有 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 INormalViewProperties**

表示正常檢視屬性。

屬性 **ShowOutlineIcons** 指定在正常檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好以全視窗的單一內容區域取代具有三個內容區域的標準正常檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示在整個視窗中。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條應顯示的狀態。水平分割條分隔投影片與投影片下方的內容區域，垂直分割條分隔投影片與側邊內容區域。可能的值為 **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 指定當 **VerticalBarState** 和 **HorizontalBarState** 分別設定為 **SplitterBarStateType.Restored** 時，正常檢視中側邊或上方投影片區域的大小。

## **關於還原 INormalViewProperties**

指定正常檢視中投影片區域（若為 RestoredTop 的子項則為寬度，若為 RestoredLeft 的子項則為高度）的大小，當該區域處於可變的還原大小（既非最小化也非最大化）時。

屬性 **DimensionSize** 指定投影片區域的大小（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的視窗大小時，側邊內容區域的大小是否應自動補償新尺寸。

以下範例示範如何存取 **ViewProperties.NormalViewProperties** 以取得簡報的相關屬性。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 復原簡報的檢視屬性
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設縮放值**

Aspose.Slides for Python via .NET 現在支援為簡報設定預設縮放值，讓簡報開啟時即已套用縮放。這可以透過設定簡報的 [view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 來完成。投影片檢視屬性以及 [notes_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/notes_view_properties/) 皆可程式化設定。在本主題中，我們將以範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

設定檢視屬性的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例
2. 設定簡報的 [view properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/) 
3. 將簡報寫入 PPTX 檔案

在以下範例中，我們已為投影片檢視與備註檢視設定了縮放值。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 設定簡報的檢視屬性
    presentation.view_properties.slide_view_properties.scale = 100 # 縮放值（百分比）用於投影片檢視
    presentation.view_properties.notes_view_properties.scale = 100 # 縮放值（百分比）用於備註檢視

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定格線間距**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 來存取整個簡報的檢視設定。屬性 [ViewProperties.grid_spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/grid_spacing/) 可讀取或變更底層編輯格線的間隔。此設定套用於整份簡報，而非單一投影片。格線間距以點為單位，72 點等於一英寸。請使用正值，符合 API 文件的要求。

以下範例開啟現有的 `demo.pptx`，列印目前的格線間距，設定為四分之一英寸的間隔，並儲存結果。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

格線與 [drawing guides](/slides/zh-hant/python-net/drawing-guides/) 不同。格線間距控制規律的間隔，而繪圖指引則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖指引不會更改格線間距。

格線與繪圖指引皆為編輯輔助工具，並不會在 PDF、影像、SVG 或投影片放映中呈現為投影片內容。儲存格線間距並不保證編輯器會顯示格線：其可見性亦取決於檢視器或編輯器的偏好設定。

## **常見問題**

**為什麼重新開啟簡報後格線不可見？**

檔案會儲存格線間距，但編輯器決定是否顯示格線。請檢查編輯器的格線可見性設定。

**清除繪圖指引會改變格線間距嗎？**

不會。繪圖指引與格線間距是獨立的設定。清除指引不會影響已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 僅在簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/slide_view_properties/)）定義，並不會依章節而異。因此，開啟文件時會套用單一組參數於整個文件。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不行。設定儲存在檔案中，為所有使用者共用。檢視應用程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以建立包含預定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 儲存在簡報層級，您可以將它們嵌入範本，並從該範本建立新文件，以保留相同的初始檢視配置。