---
title: 在 .NET 中擷取與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/net/presentation-view-properties/
keywords:
  - 檢視屬性
  - 常規檢視
  - 大綱內容
  - 大綱圖示
  - 垂直分割線貼齊
  - 單一檢視
  - 條狀狀態
  - 尺寸大小
  - 自動調整
  - 預設縮放
  - PowerPoint
  - OpenDocument
  - 簡報
  - .NET
  - C#
  - Aspose.Slides
description: "探索 Aspose.Slides for .NET 的檢視屬性，以自訂 PPT、PPTX 與 ODP 幻燈片格式──調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

常規檢視由三個內容區域組成：幻燈片本身、側邊內容區以及底部內容區。屬性與不同內容區域的位置相關。此資訊允許應用程式將檢視狀態儲存至檔案，以便重新開啟時，檢視與上次儲存簡報時的狀態相同。

已新增屬性[IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/properties/normalviewproperties) 以提供對簡報常規檢視屬性的存取。

[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inormalviewrestoredproperties) 介面及其衍生類別、[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/splitterbarstatetype) 列舉已新增。

## **關於 INormalViewProperties**

表示常規檢視屬性。

屬性**ShowOutlineIcons** 指定當在常規檢視模式的任何內容區域顯示大綱內容時，應用程式是否顯示圖示。

屬性**SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割線是否應自動縮回至最小化狀態。

屬性**PreferSingleView** 指定使用者是否偏好在完整視窗中只顯示單一內容區域，而非具有三個內容區域的標準常規檢視。啟用後，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

屬性**VerticalBarState**與**HorizontalBarState** 指定水平或垂直分割條應顯示的狀態。水平分割條將幻燈片與其下方的內容區域分開，垂直分割條將幻燈片與側邊內容區域分開。可能的值為：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized**與**SplitterBarStateType.Restored**。

屬性**RestoredLeft**與**RestoredTop** 指定常規檢視中頂部或側邊幻燈片區域的大小，當**VerticalBarState**與**HorizontalBarState**分別套用**SplitterBarStateType.Restored**值時。

## **關於還原 INormalViewProperties**

指定常規檢視中幻燈片區域的大小（若為 RestoredTop 的子項則為寬度，若為 RestoredLeft 的子項則為高度），當該區域尺寸為可變的還原大小（既非最小化亦非最大化）時。

屬性**DimensionSize** 指定幻燈片區域的大小（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

屬性**AutoAdjust** 指定在調整應用程式內包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動調整以適應新大小。

以下範例示範如何存取簡報的**ViewProperties.NormalViewProperties**屬性。
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides for .NET 現已支援為簡報設定預設縮放值，讓簡報開啟時即已套用縮放。這可透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties)來完成。幻燈片檢視屬性以及[NotesViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/properties/notesviewproperties)也能以程式方式設定。本主題將以範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

為設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例
1. 設定簡報的檢視[Properties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties)
1. 將簡報寫入為 PPTX 檔案

以下範例中，我們已設定幻燈片檢視與註解檢視的縮放值。
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 設定簡報的檢視屬性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 以百分比表示的幻燈片檢視縮放值
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 以百分比表示的備註檢視縮放值

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **設定格線間距**

使用 [Presentation.ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 可存取整個簡報的檢視設定。屬性[IViewProperties.GridSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iviewproperties/gridspacing/) 可讀取或變更基礎編輯格線的間隔。此設定套用於整個簡報，而非單獨的投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，符合 API 文件的要求。

以下範例開啟現有的 `demo.pptx`，列印其目前的格線間距，設定四分之一英吋的間隔，並儲存結果。
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

格線不同於[drawing guides](/slides/zh-hant/net/drawing-guides/)。格線間距控制規則的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助工具，且不會在 PDF、影像、SVG 或投影片放映中以幻燈片內容呈現。儲存格線間距並不保證編輯器會顯示格線，其可見性亦取決於檢視器或編輯器的設定。

## **常見問題**

**為何重新開啟簡報後格線不可見？**

檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會改變已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/) 定義於簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/slideviewproperties/)），而非各章節。因此，開啟文件時僅有單一組參數套用於整個簡報。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中並為所有使用者共享。檢視器應用程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以製作帶有預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。由於[檢視屬性](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/viewproperties/)儲存在簡報層級，您可以將其嵌入範本，並以相同的初始檢視設定建立新文件。