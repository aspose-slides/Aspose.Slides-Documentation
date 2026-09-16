---
title: 在 Android 上管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/androidjava/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 設定超連結格式
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變更超連結
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，透過 Java 範例在 PowerPoint 與 OpenDocument 簡報中新增、設定、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連接至網站或簡報內的某個位置。在 PowerPoint 中，超連結通常用於兩個目的：

* 從文字、圖形或媒體框架開啟網站。
* 從目錄等跳轉至另一張投影片。

Aspose.Slides for Android via Java 允許您新增這些連結、控制其外觀與音效、更新屬性以及移除它們。以下範例說明如何在單一元素上操作超連結，並展示如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="注意" %}}
您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或媒體框架。指派超連結的元素決定可點擊的範圍：文字部份會將選取的文字設為可點擊，而圖形或框架則將整個投影片物件設為可點擊。

### **將 URL 超連結加入文字**

若要將文字連結至網站，將一個[Hyperlink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/hyperlink/)傳遞給文字部份的[setHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-)方法，如下所示。只有該文字部份會變成可點擊。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將 URL 超連結加入圖形與媒體框架**

若要使圖形或框架可點擊，呼叫其[setHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-)方法。此超連結屬於物件本身，而非其內部的文字部份。

相同方式適用於圖片、音訊與視訊框架：將超連結指派給框架，並在需要時呼叫[setTooltip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)。

以下範例讓一個矩形可點擊：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用超連結建立目錄**

內部超連結允許讀者從目錄跳至特定投影片。以下範例使用[setInternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-)，將第一張投影片上的「Page 2」文字連結至第二張投影片。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定超連結格式**

### **顏色**

[IHyperlink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/)的[setColorSource](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-)方法決定超連結是使用簡報的超連結顏色，還是使用文字部份的格式。若要套用自訂文字顏色，請選擇[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/hyperlinkcolorsource/)並設定部份的填色。此功能於 PowerPoint 2019 之後加入；較舊版本不支援此設定。

以下範例在同一張投影片上加入兩個文字超連結。第一個使用紅色文字填色，第二個保留預設超連結顏色。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **音效**

超連結在啟動時可播放音效，或在已播放音效時停止。使用以下方法進行設定：

- [IHyperlink.setSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) 指定與超連結相關聯的音訊。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) 控制啟動超連結時是否停止先前的音效。

#### **加入超連結音效**

以下範例載入 `sampleaudio.wav` 並將其與第一張投影片上的按鈕關聯。點擊按鈕時會播放音效並跳至下一張投影片。該投影片上的第二個圖形在點擊時會停止先前的音效，且不執行跳轉。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **擷取超連結音效**

以下範例開啟先前建立的簡報，並透過[getSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getSound--)與[getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudio/#getBinaryData--)將第一個圖形的超連結音訊讀入記憶體。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **工具提示與互動設定**

在將超連結指派給文字或圖形後，您可以呼叫以下[IHyperlink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/)方法：

- [setTooltip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) 設定觀者在鼠標懸停時顯示的提示文字。
- [setTargetFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) 在適用時指定父 HTML frameset 中的目標框架。
- [setHistory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) 控制啟動連結時是否將其目的地加入已瀏覽超連結清單。
- [setHighlightClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) 控制點擊時是否以高亮方式顯示超連結。

## **從簡報中移除超連結**

使用[getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--)收集包括文字部份連結在內的所有超連結容器，之後再進行變更。以下範例同時移除第一張投影片的兩種啟動方式。若只想移除其中一種，僅呼叫[removeHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)或[removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)；移除點擊動作不會同時移除滑鼠暈過動作。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

若要無條件移除，[removeAllHyperlinks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) 會一次性在選定範圍內移除兩種啟動方式。若需針對母片、版面配置與備註進行選擇性清理，請參考[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報之前，先記錄其互動動作與網路連結。[getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 會回傳[IHyperlinkContainer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkcontainer/) 物件，而非單純的 URL 字串。請同時檢查每個容器的[getHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) 以及[getHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)。它們彼此獨立：同一容器可同時暴露兩種動作，因此完整報告需要每個容器最多兩列。

僅在圖形層級檢查超連結可能會遺漏附加在文字部份的連結。請查詢正確的範圍，並保留回傳的容器，以便之後更新或移除其動作。

### **查詢簡報、投影片與文字框層級**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/) 介面可透過[IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) 與 [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) 取得。每個範圍支援相同的查詢：

- [getHyperlinkClicks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) 回傳具有點擊動作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) 回傳具有滑鼠暈過動作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 回傳同時具備任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠暈過連結、內部投影片導向、文字滑鼠暈過連結與巨集動作。它不會執行任何動作。相同的三種查詢在每個層級皆可使用；計數代表容器數量，而非動作總數。文字框層級會排除其所在圖形本身的連結。

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在此範例中，簡報與投影片查詢各報告三個點擊容器、兩個滑鼠暈過容器，以及三個具任一動作的容器。文字框查詢則在每個類別中各報告一個容器。

### **分類動作與目的地**

使用[IHyperlink.getActionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getActionType--) 先判斷動作，再解析目的地。 [HyperlinkActionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/hyperlinkactiontype/) 的值涵蓋超出網頁導向的多種情況：

| 值 | 審核說明 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協定。 |
| `JumpSpecificSlide` | 內部導向至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導向，於放映情境下解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網頁 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導向動作，或未識別的動作，需要進一步審查。 |

使用[getExternalUrl](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) 讀取外部目的地，使用[getTargetSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) 讀取特定的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若[ getExternalUrlOriginal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 回傳的值與正規化後的 URL 不同，請保留原始值；若有[ getTooltip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlink/#getTooltip--)，亦請一併記錄。

### **報告、清理與驗證超連結**

以下 Java 範例讀取先前建立的簡報（使用前面的檔案），寫入 `hyperlink-audit.json`，套用政策，儲存為 `hyperlink-sanitized.pptx`，並再次開啟以檢查兩種啟動方式。它在變更前先收集容器，並使用參考相等性避免重複處理同一容器。簡報查詢涵蓋普通投影片；若需全套件盤點，亦會明確查詢母片、版面配置、備註以及備註與講義母片（若存在）。

報告會記錄以 1 為起始的投影片索引與[getSlideId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getSlideId--)（若可取得）。[ISlideComponent.getSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecomponent/#getSlide--) 為支援的容器提供所屬投影片。母片、版面配置與備註沒有普通投影片索引，會以其範圍識別。圖形容器與文字部份格式容器分別標記；其他容器類型保留其執行時類型名稱。每個容器取得報告本地 ID，以便關聯其兩個動作。報告以 Java 列舉定義的整數常數儲存動作類型。

此限制性政策僅允許絕對 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作以及其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全判斷。僅 HTTPS 並不保證安全：請為您的應用程式加入主機白名單與其他檢查。原始與正規化的外部 URL 皆會被檢查。範例僅審核中繼資料，不會跟隨連結或執行動作。

若需修正，容器的[getHyperlinkManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) 支援[setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) 與[removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)。此處將被禁止的外部點擊連結取代為固定的 HTTPS 登錄頁面；其他被禁止的點擊與滑鼠暈過動作獨立移除。將 `replaceExternalClicks` 設為 `false` 即可移除所有政策違規。請在部署前選擇應用程式擁有的取代頁面。

報告的匯出標記採用保守的 PDF 審核政策：將滑鼠暈過動作與所有非外部連結或特定投影片跳躍的動作標記為可能不受支援。這僅是審核提示，並非功能測試或保證未標記的連結在匯出後仍可使用。受支援的[PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/) 匯出可能保留超連結，取決於動作、匯出選項與檢視器。光柵化的[影像](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)與[視訊](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 無法保留互動超連結；在針對這類輸出審核時請將每個動作皆標記。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // 在不使用額外 JSON 依賴的情況下，序列化此報告的平面列。
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

使用先前建立的輸入檔，報告包含五筆動作列。檔案滑鼠暈過連結與巨集點擊被移除，HTTPS 連結與內部投影片導向則保留下來。驗證階段顯示零項違規動作。若輸入包含被禁止的外部點擊 URL，亦會走到取代流程。允許點擊且被禁止的滑鼠暈過會保留其點擊動作。

此選擇性清理不同於[removeAllHyperlinks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--)，後者會在選取範圍內無條件移除兩種啟動方式。此處的驗證僅檢查超連結動作；不會移除嵌入的 VBA 專案、OLE 物件或其他主動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何連結至某個分段或其第一張投影片？**

PowerPoint 的分段會將投影片分組，但內部超連結只能指向單一投影片。若要導向整個分段，請連結至該分段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上有效嗎？**

可以。母片與版面配置的元素支援超連結。於投影片放映時，使用相應母片或版面配置的投影片皆會保有這些連結。

**匯出為 PDF、HTML、影像或視訊時，超連結會被保留嗎？**

受支援的 PDF 與 HTML 匯出可能保留超連結；光柵影像與視訊則無法保留。相關匯出注意事項請參見[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。