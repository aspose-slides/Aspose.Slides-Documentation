---
title: 在 JavaScript 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/nodejs-java/manage-slide-show/
keywords:
- 顯示類型
- 由講者呈現
- 個人瀏覽
- 資訊站瀏覽
- 顯示選項
- 持續循環
- 無旁白顯示
- 無動畫顯示
- 筆跡顏色
- 顯示投影片
- 自訂放映
- 提前切換投影片
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理投影片放映。輕鬆控制投影片切換、計時及其他功能，支援 PPT、PPTX 與 ODP 格式。"
---
## **Introduction**

在 Microsoft PowerPoint 中，**Slide Show** 設定是準備與呈現專業簡報的關鍵工具。此區段中最重要的功能之一是 **Set Up Show**，它讓您能根據特定情況與觀眾調整簡報，確保靈活性與便利性。使用此功能，您可以選擇播放類型（例如由講者呈現、由個人瀏覽或在資訊站瀏覽），啟用或停用循環播放，選擇要顯示的特定投影片，並使用計時。此準備步驟對於提升簡報的效果與專業程度至關重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的方法，會回傳類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowsettings/) 的物件，您可以透過它管理 PowerPoint 簡報的投影片放映設定。本文將探討如何使用此方法來設定與控制投影片放映設定的各項功能。 

## **Select Show Type**

`SlideShowSettings.setSlideShowType` 定義投影片放映的類型，可為以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/browsedatkiosk/)。使用此方法可讓您依不同使用情境（例如自動資訊站或手動簡報）調整簡報。

以下程式碼範例建立一個新簡報，並將放映類型設為「Browsed by an individual」且不顯示捲軸。

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Enable Show Options**

`SlideShowSettings.setLoop` 決定投影片放映是否應循環播放直至手動停止。此功能對於需要持續執行的自動簡報相當有用。`SlideShowSettings.setShowNarration` 決定是否在放映期間播放語音旁白。對於包含語音指引的自動簡報相當實用。`SlideShowSettings.setShowAnimation` 決定是否播放投影片物件的動畫。這有助於完整呈現簡報的視覺效果。

以下程式碼範例建立一個新簡報，並將投影片放映設定為循環。

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Select Slides to Show**

`SlideShowSettings.setSlides` 方法允許您選擇在簡報期間要顯示的投影片範圍。當您只需顯示簡報的部分內容而非全部投影片時，此功能相當有用。以下程式碼範例建立一個新簡報，並將投影片範圍設定為顯示第 `2` 張至第 `9` 張投影片。

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Use Advance Slides**

`SlideShowSettings.setUseTimings` 方法允許您啟用或停用每張投影片的預設計時功能。此功能可自動依預先定義的顯示時間切換投影片。以下程式碼範例建立一個新簡報，並停用計時使用。

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Show Media Controls**

`SlideShowSettings.setShowMediaControls` 方法決定在播放多媒體內容（例如影片或音訊）時，投影片放映過程中是否顯示媒體控制項（如播放、暫停、停止）。當您希望讓簡報者在簡報期間控制媒體播放時，此功能相當實用。

以下程式碼範例建立一個新簡報，並啟用顯示媒體控制項。

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

可以。將檔案儲存為 PPSX 或 PPSM；這兩種格式在 PowerPoint 中開啟時會直接以投影片放映模式啟動。在 Aspose.Slides 中，於[during export](/slides/zh-hant/nodejs-java/save-presentation/)選擇相對應的儲存格式。

**Can I exclude individual slides from the show without deleting them from the file?**

可以。將投影片標記為 [hidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/sethidden/)。隱藏的投影片仍保留於簡報中，但在投影片放映時不會顯示。

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

否。Aspose.Slides 只負責編輯、分析與轉換簡報檔案；實際的播放由 PowerPoint 等檢視程式負責。