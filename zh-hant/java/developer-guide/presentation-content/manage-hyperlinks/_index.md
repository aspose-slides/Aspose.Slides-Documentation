---
title: 管理 Java 中的簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 形狀超連結
- 圖像超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 於 PowerPoint 與 OpenDocument 簡報中，透過 Java 範例新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連接至網站或簡報內的某個位置。在 PowerPoint 中，超連結通常具有兩個目的：

* 從文字、形狀或媒體框架開啟網站。
* 從目錄等位置導覽至另一張投影片。

Aspose.Slides for Java 讓您可以新增這些連結、控制其外觀與音效、更新屬性，並移除它們。下列範例示範如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}

您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)編輯簡報。

{{% /alert %}} 

## **新增 URL 超連結**

您可以為文字、形狀或媒體框架指派網站 URL。指派超連結的元素決定點擊區域：文字部份會連結所選文字，而形狀或框架會連結整個投影片物件。

### **將 URL 超連結新增至文字**

若要將文字連結至網站，請將[Hyperlink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/hyperlink/)傳遞給文字部份的[setHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-)方法，如下所示。只有該文字部份會變成可點擊。

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

### **將 URL 超連結新增至形狀與媒體框架**

若要讓形狀或框架可點擊，呼叫其[setHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-)方法。超連結屬於該物件本身，而非其中的文字部份。

相同的做法也適用於圖片、音訊與影片框架：將超連結指派給框架，必要時呼叫[setTooltip](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)。

以下範例讓矩形可點擊：

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

內部超連結允許讀者從目錄跳轉至特定投影片。以下範例使用[setInternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-)，將第一張投影片上的「第 2 頁」文字連結至第二張投影片。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **格式化超連結**

### **顏色**

[IHyperlink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/)的[setColorSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setColorSource-int-)方法決定超連結是使用簡報的超連結顏色，還是使用文字部份的格式。若要套用自訂文字顏色，請選取[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/hyperlinkcolorsource/)並設定部份的填色。此功能於 PowerPoint 2019 之後才支援；較舊版本不會套用此設定。

以下範例在同一張投影片上新增兩個文字超連結。第一個使用紅色文字填色，第二個則保留預設的超連結顏色。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

啟動超連結時可以播放音效，或停止已在播放的音效。使用下列方法設定這些行為：

- [IHyperlink.setSound](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) 指定與超連結相關的音訊。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) 控制在啟動超連結時是否停止先前的音效。

#### **新增超連結音效**

以下範例載入 `sampleaudio.wav`，並將其與第一張投影片上的按鈕關聯。點擊按鈕會播放音效並導向下一張投影片。該投影片上的第二個形狀在點擊時會停止先前的音效，且不執行導向動作。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

以下範例開啟前述建立的簡報，並透過[getSound](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getSound--)與[getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudio/#getBinaryData--)將第一個形狀的超連結音訊讀取至記憶體。

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

### **提示文字與互動設定**

將超連結指派給文字或形狀後，您可以呼叫以下[IHyperlink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/) 方法：

- [setTooltip](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) 設定觀察者在滑鼠停留時顯示的提示文字。
- [setTargetFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) 在適用時指定父 HTML frameset 中的目標框架。
- [setHistory](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) 控制啟動連結時是否將其目的地加入已瀏覽超連結清單。
- [setHighlightClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) 控制點擊時是否將超連結標示為高亮。

## **從簡報中移除超連結**

使用[getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--)可在變更前收集包括文字部份連結在內的所有超連結容器。以下範例同時移除第一張投影片的兩種啟動方式。若只想移除單一類型，只呼叫[removeHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)或[removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)；移除點擊動作不會同時移除滑鼠懸停對應項。

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

若要無條件全部移除，[removeAllHyperlinks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) 會在所選範圍內一次移除兩種啟動方式。若需針對母片、版面配置與備註進行選擇性清理，請參閱[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報之前，請先清點其互動動作與網路連結。[getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 會回傳[IHyperlinkContainer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkcontainer/) 物件，而非單純的 URL 字串。請檢查每個容器的[getHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) 與[getHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)。它們是獨立的：同一容器可同時提供兩種動作，因此完整報告可能需要每個容器最多兩列。

僅在形狀層級檢查超連結可能會遺漏附加於文字部份的連結。請改為查詢相應的範圍，並保留返回的容器，以便稍後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/) 介面可透過[IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) 與[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) 取得。每個範圍支援相同的查詢：

- [getHyperlinkClicks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) 回傳具點擊動作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) 回傳具滑鼠懸停動作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 回傳具任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠懸停連結、內部投影片導覽、文字滑鼠懸停連結與巨集動作。此範例不會執行任何動作。相同的三個查詢在每個範圍皆適用；計數描述的是容器數量，而非動作總數。文字框範圍不會包含其所屬形狀本身的連結。

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

在此範例中，簡報與投影片查詢各回報三個點擊容器、兩個滑鼠懸停容器與三個任一動作容器。文字框查詢在每個類別各回報一個容器。

### **分類動作與目的地**

使用[IHyperlink.getActionType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getActionType--) 可在解讀目的地前先了解動作類型。[HyperlinkActionType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/hyperlinkactiontype/) 的值涵蓋不只網頁導覽：

| 值 | 審核時的意義 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協定。 |
| `JumpSpecificSlide` | 導航至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，於放映情境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網頁 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或為未辨識的動作，需要進一步審查。 |

使用[getExternalUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getExternalUrl--) 讀取外部目的地，使用[getTargetSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getTargetSlide--) 取得特定的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。當[getExternalUrlOriginal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 與正規化後的 URL 不同時，請保留原始值；若有可用的[getTooltip](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlink/#getTooltip--)，也請一併納入。

### **報告、清理與驗證超連結**

以下 Java 範例讀取既有簡報（使用前述建立的檔案），寫入 `hyperlink-audit.json`，套用政策，儲存為 `hyperlink-sanitized.pptx`，再重新開啟以再次檢查兩種啟動方式。它在變更前先收集容器，並以參照相等性避免重複處理同一容器。簡報查詢涵蓋普通投影片；若需整個套件的清點，亦會顯式查詢母片、版面配置、備註，以及備註與講義母片（若存在）。

報告會記錄從 1 起算的投影片索引與[getSlideId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/#getSlideId--)（若可取得）。[ISlideComponent.getSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecomponent/#getSlide--) 提供支援容器的所屬投影片。母片、版面配置與備註沒有普通投影片索引，會以其範圍識別。形狀容器與文字部份格式容器會分別標記；其他容器類型保留其執行時型別名稱。每個容器取得報告本地 ID，以便關聯其兩個動作。報告將動作類型儲存為 Java 列舉定義的整數常數。

此限制性政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作與其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的結論。僅有 HTTPS 並不等同於信任：請為您的應用程式加入主機白名單與其他檢查。原始與正規化的外部 URL 均會被檢查。此範例在不開啟連結或執行動作的前提下審核中繼資料。

若需修正，容器的[getHyperlinkManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) 支援[setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) 與[removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)。此處，受限的外部點擊連結會被替換為固定的 HTTPS 登陸頁面；其他受限的點擊與滑鼠懸停動作則分別移除。將 `replaceExternalClicks` 設為 `false` 即可移除所有政策違規項目。請在部署前決定應用程式擁有的替換頁面。

報告的匯出旗標採用保守的 PDF 審查政策：標記滑鼠懸停動作以及任何非外部連結或特定投影片跳轉的項目為可能不受支援。這僅是審查提示，並非功能測試或保證未標記的連結在匯出後一定可存活。支援的[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/) 匯出可能保留超連結，具體取決於動作、匯出選項與檢視程式。光柵化的[圖片](/slides/zh-hant/java/convert-powerpoint-to-png/)與[影片](/slides/zh-hant/java/convert-powerpoint-to-video/) 無法保留互動超連結；在針對這類輸出進行稽核時請將每個動作都標記。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // 序列化此報告的平面列，無需額外的 JSON 依賴。
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

使用上述建立的輸入檔，報告會包含五筆動作列。檔案滑鼠懸停連結與巨集點擊會被移除，HTTPS 連結與內部投影片導覽則保留。驗證階段顯示零項違規動作。若輸入包含受限的外部點擊 URL，亦會走訪替換分支。容器若同時擁有允許的點擊與受限的滑鼠懸停，則僅保留其點擊動作。

此選擇性清理與[removeAllHyperlinks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) 不同，後者會在所選範圍內不分政策直接移除兩種啟動方式。此處的驗證僅檢查超連結動作；不會移除內嵌 VBA 專案、OLE 物件或其他主動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何連結至某個區段或其第一張投影片？**

PowerPoint 中的區段會將投影片分組，但內部超連結只能指向單一投影片。若要導覽至區段，請連結至該區段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上皆有效嗎？**

可以。母片與版面配置的元素支援超連結。這些元素上的連結在投影片放映時，會在使用該母片或版面配置的所有投影片上生效。

**匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能保留超連結；光柵化的圖片與影片則不會。請參考[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks) 中的匯出考量。