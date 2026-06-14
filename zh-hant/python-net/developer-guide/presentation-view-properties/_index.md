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
- 自動對齊垂直分割條
- 單一檢視
- 列狀狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式──調整版面配置、縮放級別與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區以及底部內容區。與不同內容區域定位相關的屬性。此資訊允許應用程式將檢視狀態儲存至檔案，讓重新開啟時檢視保持在最後一次儲存投影片時的相同狀態。

已新增屬性 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/) 以提供對簡報的普通檢視屬性的存取。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/normalviewrestoredproperties/) 類別及其衍生類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 INormalViewProperties** 

代表普通檢視屬性。

屬性 **ShowOutlineIcons** 指定應用程式在普通檢視模式的任何內容區域呈現大綱內容時，是否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否傾向於在完整視窗中僅顯示單一內容區域，而非具有三個內容區域的標準普通檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區分開。可能的值為：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** 與 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 指定普通檢視中上方或側邊投影片區域的大小，當 **VerticalBarState** 與 **HorizontalBarState** 分別設定為 **SplitterBarStateType.Restored** 時適用。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域的大小（若為 RestoredTop 的子項則為寬度，若為 RestoredLeft 的子項則為高度），當區域處於可變的還原大小（既非最小化亦非最大化）時使用。

屬性 **DimensionSize** 指定投影片區域的尺寸（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的應用程式視窗大小時，側邊內容區域的大小是否應自動調整以符合新尺寸。

以下範例示範如何存取簡報的 **ViewProperties.NormalViewProperties** 屬性。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 復原簡報的檢視屬性
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設縮放值**

Aspose.Slides for Python via .NET 現已支援為簡報設定預設縮放值，使簡報開啟時即已設定縮放。這可以透過設定簡報的 [view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 來達成。投影片檢視屬性以及 [notes_view_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/notes_view_properties/) 皆可以程式方式設定。在本主題中，我們將以範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

為了設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體
1. 設定簡報的 [view properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/) 
1. 將簡報寫入為 PPTX 檔案

以下範例中，我們已為投影片檢視與備註檢視設定縮放值。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 設定簡報的檢視屬性
    presentation.view_properties.slide_view_properties.scale = 100 # 投影片檢視的縮放值（百分比）
    presentation.view_properties.notes_view_properties.scale = 100 # 備註檢視的縮放值（百分比）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 在簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/slide_view_properties/)）定義，而非依章節，因此在開啟時整個文件皆使用同一組參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，會被所有使用者共用。檢視程式可能會尊重使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以建立帶有預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。由於 [檢視屬性](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/view_properties/) 儲存在簡報層級，您可以將其嵌入範本，然後以該範本建立新文件，便能擁有相同的初始檢視設定。