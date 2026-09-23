---
title: 在 .NET 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/net/presentation-view-properties/
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
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放層級及顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。與不同內容區域定位相關的屬性。此資訊允許應用程式將檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持在上一次儲存簡報時的相同狀態。

已新增屬性 [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/properties/normalviewproperties) ，以提供對簡報普通檢視屬性的存取。

已新增 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewrestoredproperties) 介面及其衍生類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/splitterbarstatetype) 列舉。

## **關於 INormalViewProperties**

表示普通檢視屬性。

屬性 **ShowOutlineIcons** 指定應用程式在普通檢視模式的任何內容區域顯示大綱內容時，是否應顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否應自動貼合至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好在單一內容區域中顯示全視窗，而非具有三個內容區域的標準普通檢視。若啟用，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

屬性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割條應呈現的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值有：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 和 **RestoredTop** 指定普通檢視中上方或側邊投影片區域的大小，當 **VerticalBarState** 或 **HorizontalBarState** 使用 **SplitterBarStateType.Restored** 值時分別套用。

## **關於 還原 INormalViewProperties**

指定普通檢視中投影片區域的大小（若為 RestoredTop 的子項則為寬度，若為 RestoredLeft 的子項則為高度），當該區域為可變的還原大小（既非最小化亦非最大化）時。

屬性 **DimensionSize** 指定投影片區域的大小（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動調整以補償新的大小。

以下範例示範如何存取簡報的 **ViewProperties.NormalViewProperties** 屬性。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 復原簡報的檢視屬性
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **設定預設縮放值**

Aspose.Slides for .NET 現已支援為簡報設定預設縮放值，使簡報開啟時即已設定縮放。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties) 來完成。投影片檢視屬性以及 [NotesViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/properties/notesviewproperties) 都可以以程式方式設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

為了設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例
1. 設定簡報的檢視 [Properties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties)
1. 將簡報寫入為 PPTX 檔案

以下範例中，我們已為投影片檢視與備註檢視設定縮放值。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 設定簡報的檢視屬性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 投影片檢視的縮放值（以百分比表示）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 備註檢視的縮放值（以百分比表示） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **設定格線間距**

使用 [Presentation.ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 以存取整個簡報的檢視設定。屬性 [IViewProperties.GridSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/gridspacing/) 可讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點 (point) 為單位指定，72 點等於一英吋。請使用正值，符合 API 文件的要求。

以下範例開啟現有的 `demo.pptx`，列印其目前的格線間距，設定為四分之一英吋的間隔，並儲存結果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

格線不同於 [drawing guides](/slides/zh-hant/net/drawing-guides/)。格線間距控制規則的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助工具。它們不會在 PDF、圖像、SVG 或投影片放映中呈現為投影片內容。儲存格線間距並不保證編輯器會顯示格線；其可見性亦取決於檢視或編輯程式的偏好設定。

## **開啟簡報時顯示或隱藏批註**

使用 [Presentation.ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 以存取整個簡報的檢視設定。讀取或變更 [IViewProperties.ShowComments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/showcomments/) 以儲存開啟簡報於 PowerPoint 或其他相容編輯器時是否顯示批註的偏好設定。

此設定僅控制儲存的檢視偏好設定。它不會新增、移除、編輯或解決批註。隱藏批註會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/net/presentation-comments/) 了解會變更批註本身的操作。

以下範例需要一個包含批註的現有 `comments.pptx`。它列印目前的可見性設定，請求隱藏批註，並儲存新的 PPTX 而不移除任何批註。它同時將 [IViewProperties.LastView](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/lastview/) 設為 [ViewType.SlideView](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewtype/) ，以配置初始編輯檢視及批註可見性。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

此設定不會決定批註是否會包含在 PDF、HTML、圖像、備註或講義的匯出中。請分別設定相關的匯出選項。

## **常見問題**

**為何重新開啟簡報後格線仍不可見？**

檔案會儲存格線間距，但是否顯示格線由編輯器自行控制。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會改變已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 於簡報層級定義（[普通檢視](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/normalviewproperties/)/[投影片檢視](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/slideviewproperties/)），而非每個章節。因此，開啟文件時會套用單一套參數於整個文件。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不行。設定儲存於檔案中，且為共享。檢視程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以準備帶有預定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [檢視屬性](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 儲存在簡報層級，您可以將其嵌入範本，並以此建立新文件，以獲得相同的初始檢視配置。