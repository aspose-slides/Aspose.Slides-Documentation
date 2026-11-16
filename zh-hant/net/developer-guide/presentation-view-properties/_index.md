---
title: 取得並更新 .NET 中的簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/net/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 鎖定垂直分隔條
- 單一檢視
- 分隔列狀態
- 尺寸維度
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中設定普通檢視佈局、投影片與備註的縮放、格線間距以及註解可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視中，投影片位於左側的縮圖或大綱窗格與下方的備註窗格之間。Aspose.Slides for .NET 透過 [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 透露已儲存的編輯偏好設定。這些設定包括窗格版面配置、縮放比例、格線間距以及註解可見性。

## **關於 INormalViewProperties**

使用 [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) 取得 [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) 介面。[ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) 控制大綱中投影片標題旁是否顯示圖示。[SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) 讓側邊窗格在使用者縮小時自動卡到最小化狀態。[PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) 表示偏好在完整視窗中僅顯示一個窗格。

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) 控制側邊窗格與投影片之間的分隔條。[HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) 控制備註窗格上方的分隔條。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **關於還原 INormalViewProperties**

當分隔條被還原時，[RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) 提供側邊窗格的已儲存大小，而 [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) 提供上方投影片區域的已儲存大小。兩者皆公開 [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/)。其 [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) 屬性接受 0 到 100 的百分比，而 [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) 控制編輯器在視窗大小變更時是否自動調整尺寸。

此範例會更新現有的簡報。它還原水平分隔條，將 [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) 設為 80% 並啟用自動調整，並將垂直分隔條最大化。同時也為大綱檢視啟用 [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/)。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **設定預設縮放值**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) 與 [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) 為編輯器儲存獨立的縮放設定。這些設定不會影響投影片尺寸、投影片放映播放或影像匯出的解析度。

此範例開啟現有簡報，並啟用 [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) 以自動將投影片適配編輯視窗。對於備註頁面，它停用自動縮放，並將 [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) 設為固定的 80% 縮放。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **設定格線間距**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) 設定整份簡報編輯格線之間的距離。它接受以點 (points) 為單位的正值，1 吋等於 72 點。此範例列印現有簡報的目前間距，並透過將間隔設定為 18 點來儲存四分之一吋的格線。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

格線會以固定間隔重複。[Drawing guides](/slides/zh-hant/net/drawing-guides/) 標示個別的水平或垂直位置。兩者皆為編輯輔助工具，僅在顯示此類資訊的編輯器中出現。投影片放映與匯出為 PDF、影像或 SVG 時均不會包含它們。

## **開啟簡報時顯示或隱藏註解**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) 儲存相容編輯器在開啟簡報時使用的偏好設定。對於已包含註解的現有簡報，此範例列印目前設定，並儲存一個隱藏註解的副本。它同時將 [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) 設為 [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/)，讓副本以投影片檢視開啟。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

隱藏註解會保留其文字、作者、位置、回覆與狀態。若要變更註解本身，請參閱 [Presentation Comments](/slides/zh-hant/net/presentation-comments/)。匯出設定控制註解是否出現在 PDF、HTML、影像、備註或講義中。

## **常見問題**

**為何重新開啟簡報時格線會消失？**

簡報會儲存格線間隔。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖指引會改變格線間距嗎？**

不會。新增、移動或清除指引不會改變格線間隔。

**簡報的不同區段可以有不同的檢視設定嗎？**

不能。[Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 會套用於整份簡報。

**我可以為不同使用者儲存不同的檢視設定嗎？**

檔案只儲存一組檢視屬性，供所有人使用。編輯器也可能套用使用者本機的偏好設定。

**我可以在範本中儲存檢視設定嗎？**

可以。從範本建立的簡報會繼承其已儲存的檢視設定。