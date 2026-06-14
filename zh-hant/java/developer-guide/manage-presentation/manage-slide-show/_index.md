---
title: 在 Java 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/java/manage-slide-show/
keywords:
- 放映類型
- 由講者呈現
- 由個人瀏覽
- 於資訊站瀏覽
- 放映選項
- 持續循環
- 無旁白放映
- 無動畫放映
- 筆跡顏色
- 顯示投影片
- 自訂放映
- 換頁方式
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中管理投影片放映。輕鬆控制投影片轉場、計時等，支援 PPT、PPTX 與 ODP 格式。"
---
## **簡介**

在 Microsoft PowerPoint 中，**投影片放映** 設定是準備及呈現專業簡報的關鍵工具。本節中最重要的功能之一是 **設定放映**，它允許您根據特定條件和觀眾自訂簡報，確保彈性和便利。使用此功能，您可以選擇放映類型（例如，由講者主持、由個人瀏覽或於資訊站瀏覽）、啟用或停用循環、選取特定投影片顯示，並使用計時。此準備步驟對於提升簡報的效能與專業度至關重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的方法，會回傳類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowsettings/) 的物件，可讓您管理 PowerPoint 簡報中的投影片放映設定。在本文中，我們將探討如何使用此方法來設定與控制投影片放映設定的各種層面。 

## **選取放映類型**

`SlideShowSettings.setSlideShowType` 定義投影片放映的類型，可為以下類別的實例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/browsedbyindividual/)、或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/browsedatkiosk/)。使用此方法可讓您依不同使用情境（例如自動資訊站或手動簡報）調整簡報。

以下程式碼範例建立新簡報，並將放映類型設定為「由個人瀏覽」，且不顯示捲軸。

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **啟用放映選項**

`SlideShowSettings.setLoop` 判斷投影片放映是否應持續循環直至手動停止。這對需要不斷執行的自動化簡報非常有用。`SlideShowSettings.setShowNarration` 判斷是否在投影片放映期間播放語音解說。這對含有語音指引的自動化簡報很有幫助。`SlideShowSettings.setShowAnimation` 判斷是否播放加入投影片物件的動畫。這有助於呈現完整的視覺效果。

以下程式碼範例建立新簡報，並使投影片放映循環播放。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **選取要顯示的投影片**

`SlideShowSettings.setSlides` 方法允許您選取在簡報期間要顯示的投影片範圍。當您只需顯示簡報的一部分而非全部投影片時，此功能非常實用。以下程式碼範例建立新簡報，並將顯示的投影片範圍設為第 `2` 張至第 `9` 張。

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **使用計時換頁**

`SlideShowSettings.setUseTimings` 方法允許您啟用或停用對每張投影片使用預先設定的計時。這對於以預先定義的顯示時長自動播放投影片非常有用。以下程式碼範例建立新簡報，並停用計時功能。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **顯示媒體控制項**

`SlideShowSettings.setShowMediaControls` 方法決定在播放多媒體內容（例如影片或音訊）時，投影片放映期間是否顯示媒體控制項（如播放、暫停、停止）。當您希望在簡報中讓簡報者控制多媒體播放時，這非常有用。

以下程式碼範例建立新簡報，並啟用顯示媒體控制項。

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**我可以將簡報儲存為直接以投影片放映模式開啟嗎？**

可以。將檔案儲存為 PPSX 或 PPSM；這些格式在 PowerPoint 中開啟時會直接進入投影片放映模式。在 Aspose.Slides 中，請於[匯出時](/slides/zh-hant/java/save-presentation/)選擇相應的儲存格式。

**我可以在不刪除檔案內的投影片的情況下，將個別投影片排除於放映之外嗎？**

可以。將投影片標記為[隱藏](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#setHidden-boolean-)。隱藏的投影片仍保留在簡報中，但在投影片放映時不會顯示。

**Aspose.Slides 能播放投影片放映或在螢幕上控制即時簡報嗎？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案；實際的播放由 PowerPoint 等檢視程式負責。