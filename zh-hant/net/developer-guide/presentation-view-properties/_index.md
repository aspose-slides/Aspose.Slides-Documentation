---
title: 在 .NET 中擷取與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/net/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 捕捉垂直分割條
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的檢視屬性，以自訂 PPT、PPTX 和 ODP 投影片格式—調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

正常檢視包含三個內容區域：投影片本身、側邊內容區域以及底部內容區域。此處的屬性與不同內容區域的定位有關。此資訊使應用程式能將檢視狀態儲存至檔案，讓重新開啟時檢視維持在上次儲存時的相同狀態。

已新增屬性 [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/properties/normalviewproperties) 以提供對簡報的正常檢視屬性的存取。

已新增介面 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewrestoredproperties) 及其衍生類別，並新增列舉 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/splitterbarstatetype)。

## **關於 INormalViewProperties**

表示正常檢視屬性。

屬性 **ShowOutlineIcons** 指定在正常檢視模式的任一內容區域顯示大綱內容時，是否應顯示圖示。

屬性 **SnapVerticalSplitter** 指定側邊區域足夠小時，垂直分割條是否應自動貼齊至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準正常檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值為 **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 與 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 指定正常檢視中上方或側邊投影片區域的尺寸，當 **VerticalBarState** 與 **HorizontalBarState** 的值為 **SplitterBarStateType.Restored** 時套用。

## **關於還原 INormalViewProperties**

指定正常檢視中投影片區域（在 RestoredTop 為寬度、在 RestoredLeft 為高度）的尺寸，當區域為可變還原大小（既非最小化亦非最大化）時使用。

屬性 **DimensionSize** 指定投影片區域的大小（在 restoredTop 為寬度、在 restoredLeft 為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動補償新尺寸。

以下範例說明如何存取簡報的 **ViewProperties.NormalViewProperties** 屬性。

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 還原簡報的檢視屬性
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **設定預設縮放值**

Aspose.Slides for .NET 現在支援設定簡報的預設縮放值，以便在開啟簡報時已自動套用縮放。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties) 來完成。投影片檢視屬性以及 [NotesViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/properties/notesviewproperties) 都可程式化設定。在本章節中，我們將透過範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

設定檢視屬性請依照以下步驟進行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例
2. 設定簡報的檢視 [Properties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties)
3. 將簡報寫出為 PPTX 檔案

在下方範例中，我們已為投影片檢視與註解檢視設定了縮放值。

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 設定簡報的檢視屬性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 投影片檢視的縮放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 註解檢視的縮放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 定義於簡報層級（[正常檢視](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/normalviewproperties/)/[投影片檢視](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/slideviewproperties/)），而非每個章節。因此，在檔案開啟時會以單一參數組套用於整個文件。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，且為共享的。檢視程式可能會尊重使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以建立包含預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [檢視屬性](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 儲存於簡報層級，您可以將它們嵌入範本中，之後從該範本建立的新文件會具有相同的初始檢視配置。