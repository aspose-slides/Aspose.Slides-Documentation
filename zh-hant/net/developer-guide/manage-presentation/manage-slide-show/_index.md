---
title: 在 .NET 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/net/manage-slide-show/
keywords:
- 顯示類型
- 由講者呈現
- 由個人瀏覽
- 在資訊站瀏覽
- 顯示選項
- 持續迴圈
- 不含旁白的顯示
- 不含動畫的顯示
- 筆刷顏色
- 顯示投影片
- 自訂顯示
- 自動換頁
- 手動
- 使用時間設定
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何在 Aspose.Slides for .NET 中管理投影片放映。輕鬆控制 PPT、PPTX 和 ODP 格式的投影片過渡、時間設定及其他功能。"
---
## **簡介**

在 Microsoft PowerPoint 中，**Slide Show** 設定是準備與展示專業簡報的關鍵工具。此區段最重要的功能之一是 **Set Up Show**，它讓您能依照特定的條件與觀眾自訂簡報，確保彈性與便利。使用此功能，您可以選擇播放類型（例如由講者呈現、由個人瀏覽或在 kiosk 中瀏覽）、啟用或停用迴圈、指定要顯示的投影片，並使用時間設定。此步驟對於提升簡報的效果與專業度至關重要。

`SlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的屬性，類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slideshowsettings/)，可讓您在 PowerPoint 簡報中管理投影片放映設定。本篇文章將說明如何使用此屬性來配置與控制投影片放映的各種層面。

## **選擇顯示類型**

`SlideShowSettings.SlideShowType` 定義投影片放映的類型，可為以下類別的實例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/browsedatkiosk/)。使用此屬性可依不同使用情境（例如自動化 kiosk 或手動簡報）調整簡報。

以下程式碼範例建立新簡報，並將顯示類型設定為「Browsed by an individual」且不顯示捲動條。

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **啟用顯示選項**

`SlideShowSettings.Loop` 決定投影片放映是否在手動停止前持續循環。這對需要不間斷運行的自動化簡報非常有用。`SlideShowSettings.ShowNarration` 決定放映時是否播放語音旁白，適用於提供觀眾語音指引的自動化簡報。`SlideShowSettings.ShowAnimation` 決定是否播放投影片物件上的動畫，以完整呈現簡報的視覺效果。

以下程式碼範例建立新簡報，並讓投影片放映循環。

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **選擇要顯示的投影片**

`SlideShowSettings.Slides` 屬性允許您選取在簡報期間要顯示的投影片範圍。當只需展示簡報的部份內容而非全部投影片時，這非常實用。以下程式碼範例建立新簡報，並將顯示範圍設定為第 `2` 張至第 `9` 張投影片。

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **使用自動換頁**

`SlideShowSettings.UseTimings` 屬性允許您啟用或停用每張投影片的預設時間設定。這對於依預先定義的顯示時長自動切換投影片很有幫助。以下程式碼範例建立新簡報，並停用時間設定。

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **顯示媒體控制項**

`SlideShowSettings.ShowMediaControls` 屬性決定當播放多媒體內容（例如影片或音訊）時，投影片放映期間是否顯示媒體控制項（播放、暫停、停止等）。這在您希望讓簡報者能控制媒體播放時非常有用。

以下程式碼範例建立新簡報，並啟用媒體控制項顯示。

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**我可以將簡報儲存為直接以投影片放映模式開啟嗎？**

可以。將檔案儲存為 PPSX 或 PPSM；這兩種格式在 PowerPoint 中開啟時會直接進入投影片放映。於 Aspose.Slides 中，請於[在匯出時](/slides/zh-hant/net/save-presentation/)選擇相對應的儲存格式。

**我可以在不刪除投影片的情況下，將個別投影片排除於放映之外嗎？**

可以。將投影片標記為[Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/)。隱藏的投影片仍會保留在簡報中，但不會在投影片放映時顯示。

**Aspose.Slides 能否直接播放投影片放映或控制螢幕上的即時簡報？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放由 PowerPoint 等檢視程式負責。