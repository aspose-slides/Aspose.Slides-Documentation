---
title: 在 Python 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/python-net/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 垂直分割條自動吸附
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放層級與顯示設定。"
---
## **簡介**

正常檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。與不同內容區域位置相關的屬性。此資訊讓應用程式能將檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持在上次儲存時的相同狀態。

已加入屬性 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/) 以提供對簡報正常檢視屬性的存取。

已加入 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewrestoredproperties/) 類別及其子類別，[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 INormalViewProperties**

表示正常檢視屬性。

屬性 **ShowOutlineIcons** 指定在正常檢視模式的任一內容區域顯示大綱內容時，應否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好在整個視窗中顯示單一內容區域，而非具有三個內容區域的標準正常檢視。啟用後，應用程式可能會選擇在整個視窗中顯示其中一個內容區域。

屬性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值為 **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 和 **RestoredTop** 指定在 **VerticalBarState** 和 **HorizontalBarState** 分別設定為 **SplitterBarStateType.Restored** 時，正常檢視中側邊或上方投影片區域的尺寸。

## **關於 Restoring INormalViewProperties**

指定在變動還原大小（既非最小化亦非最大化）的情況下，正常檢視中投影片區域（作為 RestoredTop 的子項時為寬度，作為 RestoredLeft 的子項時為高度）的尺寸。

屬性 **DimensionSize** 指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視之視窗大小時，側邊內容區域的大小是否應自行補償新尺寸。

以下範例說明如何存取 **ViewProperties.NormalViewProperties** 屬性以取得簡報的相關資訊。

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

Aspose.Slides for Python via .NET 現在支援為簡報設定預設縮放值，使簡報開啟時已自動設定縮放。這可以透過設定簡報的 [view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 來完成。投影片檢視屬性以及 [notes_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/notes_view_properties/) 都可以以程式方式設定。本主題將示範如何在 Aspose.Slides 中設定簡報的檢視屬性。

設定檢視屬性的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例
2. 設定簡報的 [view properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/)
3. 將簡報寫入為 PPTX 檔案

在以下範例中，我們同時設定了投影片檢視與備註檢視的縮放值。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 設定簡報的檢視屬性
    presentation.view_properties.slide_view_properties.scale = 100 # 投影片檢視的縮放值（百分比）
    presentation.view_properties.notes_view_properties.scale = 100 # 備註檢視的縮放值（百分比）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定格線間距**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 以存取整份簡報的檢視設定。屬性 [ViewProperties.grid_spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/grid_spacing/) 可讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點為單位，72 點等於 1 英吋。請使用正值，依 API 文件規定。

以下範例開啟既有的 `demo.pptx`，列印目前的格線間距，將間隔設定為四分之一英吋，並儲存結果。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

格線與 [drawing guides](/slides/zh-hant/python-net/drawing-guides/) 不同。格線間距控制的是規則的間隔，而繪圖參考線是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆屬於編輯輔助工具，並不會以投影片內容的形式呈現在 PDF、影像、SVG 或投影片放映中。儲存格線間距並不保證編輯器一定會顯示格線：其可見性同樣取決於檢視或編輯器的偏好設定。

## **開啟簡報時顯示或隱藏評論**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 以存取簡報層級的檢視設定。讀取或變更 [ViewProperties.show_comments](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/show_comments/) 以儲存開啟簡報時是否顯示評論的偏好。

此設定僅控制儲存的檢視偏好，並不會新增、移除、編輯或解決評論。隱藏評論會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/python-net/presentation-comments/) 以了解會變更評論本身的操作。

以下範例需要一個已存在且包含評論的 `comments.pptx`。它會列印目前的可見性設定，要求隱藏評論，並將新 PPTX 儲存而不移除任何評論。同時會將 [ViewProperties.last_view](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/last_view/) 設為 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewtype/) 以在評論可見性的同時設定初始編輯檢視。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

此設定不會決定評論是否會包含在 PDF、HTML、影像、備註或講義的匯出中。請分別設定相關匯出專屬的選項。

## **常見問題**

**為什麼重新開啟簡報後格線不見了？**  
檔案會儲存格線間距，但實際是否顯示格線由編輯器控制。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**  
不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會影響已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**  
[View settings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 是在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/)、[Slide View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/slide_view_properties/)），不會依章節分別設定，因此整份文件在開啟時會套用同一套參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**  
不能。設定儲存在檔案中，所有使用者共用同一組檢視屬性。檢視程式可能會遵循使用者個人的偏好，但檔案本身僅含一組檢視屬性。

**我可以建立包含預先定義檢視屬性的範本，讓新簡報以相同方式開啟嗎？**  
可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 儲存在簡報層級，所以您可以將它們嵌入範本，然後以此範本建立新文件，讓它們擁有相同的初始檢視配置。