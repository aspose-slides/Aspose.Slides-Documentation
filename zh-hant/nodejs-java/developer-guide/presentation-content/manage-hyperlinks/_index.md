---
title: 在 JavaScript 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 影像超連結
- 影片超連結
- 可變的超連結
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，搭配 JavaScript 範例，於 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連接到網站或簡報內的某個位置。在 PowerPoint 中，超連結通常具有兩個目的：

* 從文字、圖形或媒體框架開啟網站。
* 導航至另一張投影片，例如從目錄頁。

Aspose.Slides for Node.js via Java 讓您可以新增這些連結、控制其外觀與聲音、更新其屬性，並將其移除。以下範例示範如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}
您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor)編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或媒體框架。指派超連結的元素決定可點擊區域：文字部分會將選取的文字變成可點擊，而圖形或框架則會將投影片物件變成可點擊。

對於包含相對超連結的簡報，請參閱[管理超連結基礎](/slides/zh-hant/nodejs-java/presentation-properties/#manage-the-hyperlink-base)以閱讀、變更或清除文件層級的基礎。

### **將 URL 超連結新增至文字**

若要將文字連結至網站，將 [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) 傳遞給文字部分的 [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) 方法，如下所示。僅該文字部分會變成可點擊。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將 URL 超連結新增至圖形和媒體框架**

若要使圖形或框架可點擊，呼叫其 [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) 方法。超連結屬於該物件本身，而非其內部的文字部分。

相同的做法也適用於圖片、音訊和影片框架：將超連結指派給框架，必要時呼叫 [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip)。

以下範例讓矩形可點擊：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用超連結建立目錄**

內部超連結允許讀者從目錄跳至特定投影片。以下範例使用 [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) 將第一張投影片上的「Page 2」文字連結至第二張投影片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化超連結**

### **顏色**

[setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) 方法（屬於 [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink)）決定超連結是使用簡報的超連結顏色還是文字部分的格式。若要套用自訂文字顏色，請選取 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) 並設定該部分的填色。本功能於 PowerPoint 2019 中加入；較舊版本不會套用此設定。

以下範例在同一張投影片上新增兩個文字超連結。第一個使用紅色文字填色，第二個則保留預設的超連結顏色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **聲音**

超連結在被觸發時可以播放聲音，或停止已在播放的聲音。使用以下方法來設定這些行為：

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) 指定與超連結關聯的音訊。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) 控制在觸發超連結時是否停止先前的聲音。

#### **新增超連結聲音**

以下範例載入 `sampleaudio.wav` 並將其關聯到第一張投影片上的按鈕。點擊按鈕會播放聲音並導航至下一張投影片。該投影片上的第二個圖形在點擊時會停止先前的聲音，且不執行導航動作。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **擷取超連結聲音**

以下範例開啟上述建立的簡報，並透過 [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) 與 [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) 讀取第一個圖形之超連結音訊至記憶體。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **提示文字與互動設定**

在將超連結指派給文字或圖形之後，您可以呼叫以下 [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) 方法：

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) 設定觀者可顯示作為連結提示的文字。
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) 指定在父 HTML frameset 中的目標框架（適用時）。
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) 控制在觸發連結時是否將其目的地加入已檢視超連結清單。
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) 控制在點擊時是否將超連結高亮顯示。

## **從簡報中移除超連結**

使用 [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 收集超連結容器（包括文字部分的連結）後再進行變更。以下範例移除第一張投影片的兩種激活類型。若只想移除單一類型，僅呼叫 [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) 或 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)；移除點擊動作不會同時移除滑鼠移過的對應動作。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

若需無條件移除，可使用 [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) 在一次呼叫中移除所選範圍內的兩種激活類型。欲進行選擇性清理並涵蓋母片、版面配置與備註，請參閱[報告、淨化與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報之前，請對其互動操作與網路連結進行清點。[getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 回傳超連結容器，而非單純的 URL 字串清單。請檢查每個容器的 [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) 與 [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver)。兩者相互獨立：同一容器可同時提供兩種動作，因此完整報告可能需要每個容器最多兩列。

僅掃描圖形層級的超連結可能會遺漏附加於文字部分的連結。請改為查詢適當的範圍，並保留返回的容器，以便稍後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) 類別可透過 [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) 與 [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) 取得。每個範圍支援相同的查詢：

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) 回傳包含點擊動作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) 回傳包含滑鼠移過動作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 回傳包含任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠移過連結、內部投影片導航、文字滑鼠移過連結，以及巨集動作。此範例不會執行任何這些動作。相同的三個查詢在每個範圍皆可使用；計數描述的是容器數量，而非動作總數。文字框範圍不包括其包圍圖形自身的連結。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在此範例中，簡報與投影片的查詢各回報三個點擊容器、兩個滑鼠移過容器，以及三個任一動作的容器。文字框的查詢則在每個類別中各回報一個容器。

### **分類動作與目的地**

使用 [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) 在解讀目的地之前先判斷動作類型。[HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) 的值涵蓋超出網頁導覽的情況：

| 值 | 審核意義 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 及其協議。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導航，於投影片放映環境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；與網路 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或未識別的動作需進行審查。 |

從 [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) 讀取外部目的地，從 [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) 讀取特定的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 並不代表容器沒有任何動作。當 [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) 回傳的值與正規化 URL 不同時，請保留該值；若有可用的提示文字，亦請納入由 [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) 回傳的內容。

### **報告、淨化與驗證超連結**

以下 JavaScript 範例讀取現有的簡報（使用上述建立的檔案），寫入 `hyperlink-audit.json`，套用政策，儲存為 `hyperlink-sanitized.pptx`，並重新開啟以再次檢查兩種激活類型。它在變更前收集容器，並使用參考相等性避免重複處理同一容器。簡報查詢涵蓋一般投影片；若需全套件清點，亦會明確查詢母片、版面配置、備註，以及備註與講義母片（若存在）。

報告會記錄以 1 為起點的投影片索引與可取得的 [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId)。[getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) 為支援的容器提供其所屬投影片。母片、版面配置與備註沒有普通的投影片索引，會以其範圍進行識別。圖形容器與文字部分格式容器會分別標註；其他容器類型保留其執行時型別名稱。每個容器取得報告本地 ID，以便關聯其兩個動作。報告會將動作類型儲存為 HyperlinkActionType 列舉定義的整數常數。

此刻意限制的應用政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作以及其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的判斷。單靠 HTTPS 並不代表信任：請為您的應用加入主機白名單與其他檢查。會同時檢查原始與正規化的外部 URL。範例在不追蹤連結或執行動作的情況下審核中繼資料。

針對修正，容器的 [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) 支援 [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) 與 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)。此處會將被禁止的外部點擊連結取代為固定的 HTTPS 登錄頁面；其他被禁止的點擊以及被禁止的滑鼠移過動作則分別移除。將 `replaceExternalClicks` 設為 `false` 可改為移除所有政策違規。請在部署前選擇應用自行提供的替代頁面。

報告的匯出標記採用保守的 PDF 審查政策：將滑鼠移過動作以及除外部連結或特定投影片跳轉之外的任何動作標記為可能不支援。這僅是審查提示，並非功能測試或保證未標記的連結一定能在匯出時保留。支援的 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/) 匯出可能會保留超連結，視動作、匯出選項與檢視器而定。點陣 [images](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 與 [video](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 無法保留互動式超連結；在針對這些輸出進行審查時，請將每個動作皆標記。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用上述建立的輸入，報告包含五列動作。檔案滑鼠移過連結與巨集點擊被移除，HTTPS 連結與內部投影片導航則保留。驗證結果顯示零個違規動作。若輸入中包含被禁止的外部點擊 URL，亦會走到替換分支。具有允許的點擊但被禁止的滑鼠移過的容器，仍保留其點擊動作。

此選擇性清理與 [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) 不同，後者會在整個選定範圍內無條件移除兩種激活類型。此處的驗證僅檢查超連結動作；不會移除嵌入的 VBA 專案、OLE 物件或其他活動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何將連結指向某個區段或其第一張投影片？**

PowerPoint 中的區段會將投影片分組，但內部超連結只能針對單一投影片。若要導向區段，請將連結指向該區段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上皆有效嗎？**

可以。母片與版面配置元素支援超連結。這些元素上的連結會在使用相應母片或版面配置的投影片播放時生效。

**匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；點陣圖與影片則無法保留。請參閱[報告、淨化與驗證超連結](#report-sanitize-and-verify-hyperlinks)中的匯出考量。