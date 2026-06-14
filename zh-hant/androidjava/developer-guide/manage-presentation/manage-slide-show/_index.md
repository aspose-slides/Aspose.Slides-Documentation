---
title: 在 Android 上管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/androidjava/manage-slide-show/
keywords:
- 顯示類型
- 由簡報者播放
- 個人瀏覽
- 資訊站瀏覽
- 顯示選項
- 持續循環
- 無旁白顯示
- 無動畫顯示
- 筆刷顏色
- 顯示投影片
- 自訂顯示
- 自動換片
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上透過 Java 使用 Aspose.Slides 管理投影片放映。輕鬆控制 PPT、PPTX 與 ODP 格式的投影片切換、計時等功能。"
---
## **簡介**

在 Microsoft PowerPoint 中，**Slide Show** 設定是準備與呈現專業簡報的關鍵工具。本節中最重要的功能之一是 **Set Up Show**，它讓您能依照特定情境與觀眾客製化簡報，確保彈性與便利。透過此功能，您可以選擇顯示類型（例如由簡報者播放、由個人瀏覽，或在資訊站瀏覽），啟用或停用循環播放，選取要顯示的特定投影片，並使用計時。此步驟對於提升簡報的效能與專業度至關重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的方法，會傳回 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowsettings/) 型別的物件，讓您能在 PowerPoint 簡報中管理投影片放映設定。本篇文章將探討如何使用此方法來配置與控制投影片放映設定的各項功能。

## **選取顯示類型**

`SlideShowSettings.setSlideShowType` 定義投影片放映的類型，可為以下類別的實例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/browsedatkiosk/)。使用此方法可依不同使用情境（如自動資訊站或手動簡報）調整簡報。

以下程式碼範例建立新簡報，並將顯示類型設定為「Browsed by an individual」且不顯示捲軸。

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **啟用顯示選項**

`SlideShowSettings.setLoop` 決定投影片放映是否以迴圈方式重複，直至手動停止。此功能適用於需持續運行的自動簡報。`SlideShowSettings.setShowNarration` 決定是否在放映期間播放語音說明，適合包含語音導覽的自動簡報。`SlideShowSettings.setShowAnimation` 決定是否播放投影片物件所加入的動畫，以完整呈現視覺效果。

以下程式碼範例建立新簡報，並將投影片放映設為迴圈播放。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **選取要顯示的投影片**

`SlideShowSettings.setSlides` 方法允許您指定在簡報期間要顯示的投影片範圍。當只需展示簡報的部分內容而非全部投影片時，此功能相當有用。以下程式碼範例建立新簡報，並將顯示範圍設定為第 `2` 張至第 `9` 張投影片。

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **使用自動換片**

`SlideShowSettings.setUseTimings` 方法允許您啟用或停用每張投影片的預設計時功能，適用於自動依預先設定的顯示時間切換投影片的情境。以下程式碼範例建立新簡報，並停用計時功能。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **顯示媒體控制項**

`SlideShowSettings.setShowMediaControls` 方法決定在播放多媒體內容（如影片或音訊）時，投影片放映期間是否顯示媒體控制項（播放、暫停、停止等）。當您希望在簡報過程中讓簡報者能自行控制媒體播放時，此功能十分實用。

以下程式碼範例建立新簡報，並啟用顯示媒體控制項。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **常見問題**

**我可以將簡報儲存為直接在投影片放映模式開啟嗎？**

可以。將檔案儲存為 PPSX 或 PPSM；這些格式在 PowerPoint 中開啟時會直接進入投影片放映模式。於 Aspose.Slides 中，請於 [during export](/slides/zh-hant/androidjava/save-presentation/) 時選擇相應的儲存格式。

**我可以在不刪除檔案中投影片的情況下，將個別投影片排除在放映之外嗎？**

可以。將投影片標記為 [hidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#setHidden-boolean-)。隱藏的投影片仍保留在簡報中，但不會在投影片放映時顯示。

**Aspose.Slides 能否在螢幕上播放投影片放映或控制即時簡報？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放由如 PowerPoint 等檢視應用程式負責。