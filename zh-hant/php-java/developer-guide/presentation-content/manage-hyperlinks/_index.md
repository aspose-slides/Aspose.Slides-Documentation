---
title: 在 PHP 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/php-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增 超連結
- 建立 超連結
- 格式化 超連結
- 移除 超連結
- 更新 超連結
- 文字 超連結
- 投影片 超連結
- 圖形 超連結
- 圖片 超連結
- 影片 超連結
- 可變 超連結
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 並搭配 PHP 範例，在 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連接到網站或簡報內的特定位置。在 PowerPoint 中，超連結通常具有兩個用途：

* 從文字、圖形或媒體框架開啟網站。
* 導覽至另一張投影片，例如從目錄。

Aspose.Slides for PHP via Java 讓您能新增這些連結、控制其外觀與音效、更新其屬性，以及移除它們。以下範例說明如何在單一元素上使用超連結，以及如何在簡報、投影片或文字框層級存取超連結。範例假設已初始化 PHP/Java Bridge 以及 Aspose.Slides PHP 包裝器。未提供 PHP 參考頁面的 API 成員會連結至底層的 Java API。

{{% alert color="info" title="Note" %}}
您也可以使用 [免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor) 來編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或媒體框架。指派超連結的元素決定可點擊區域：文字部分會連結所選文字，而圖形或框架則連結整個投影片物件。

對於包含相對超連結的簡報，請參閱 [Manage the Hyperlink Base](/slides/zh-hant/php-java/presentation-properties/#manage-the-hyperlink-base) 以讀取、變更或清除文件層級的基底。

### **將 URL 超連結新增至文字**

要將文字連結到網站，請將 [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) 傳遞給文字部分的 [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) 方法，如下所示。只有該文字部分會變成可點擊的。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **將 URL 超連結新增至圖形與媒體框架**

要使圖形或框架可點擊，呼叫其 [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) 方法。超連結屬於該物件本身，而不是其中的文字部分。

相同的做法同樣適用於圖片、音訊與影片框架：將超連結指派給框架，必要時呼叫 [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/)。

以下範例會使矩形可點擊：

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **使用超連結建立目錄**

內部超連結讓讀者能從目錄跳至特定投影片。以下範例使用 [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) 將第一張投影片上的「Page 2」文字連結至第二張投影片。

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **格式化超連結**

### **顏色**

[setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) 方法 (屬於 [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)) 決定超連結是使用簡報的超連結顏色，還是使用文字部分的格式。若要套用自訂文字顏色，請選取 [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) 並設定該部分的填色。此功能於 PowerPoint 2019 引入，較舊版本不會套用此設定。

以下範例在同一張投影片上新增兩個文字超連結。第一個使用紅色文字填色，第二個保留預設超連結顏色。

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **音效**

超連結可以在啟動時播放音效，或停止已在播放的音效。使用以下方法設定這些行為：

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) 指定與超連結相關聯的音訊。
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) 控制在點擊超連結時是否停止先前的音訊。

#### **加入超連結音效**

以下範例載入 `sampleaudio.wav` 並將其關聯至第一張投影片上的按鈕。點擊按鈕會播放音效並導向下一張投影片。該投影片上的第二個圖形在點擊時會停止先前的音效，且不執行導向動作。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **擷取超連結音效**

以下範例開啟先前建立的簡報，並透過 [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) 和 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) 讀取第一個圖形的超連結音訊至記憶體。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **工具提示與互動設定**

指派超連結至文字或圖形後，您可以呼叫以下 [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) 方法：

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) 設定觀眾可顯示為連結提示的文字。
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) 在適用時指定父 HTML 框架集內的目標框架。
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) 控制在啟動連結時是否將其目的地加入已檢視的超連結清單。
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) 控制點擊時是否突顯超連結。

## **從簡報中移除超連結**

使用 [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) 於變更前收集超連結容器，包含文字部分的連結。以下範例移除第一張投影片的兩種啟動方式。若僅想移除其中一種，僅呼叫 [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) 或 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)；移除點擊動作不會同時移除滑鼠懸停對應項。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若要無條件移除，[removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) 會在一次呼叫中移除所選範圍內的兩種啟動方式。若需選擇性清理且涵蓋母片、版面配置與備註，請參閱 [報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報之前，必須列點其互動動作與網路連結。[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) 會回傳 [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) 物件，而不是純粹的 URL 字串清單。請同時檢查每個容器的 [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) 與 [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)。它們是獨立的：同一容器可同時曝光兩種動作，因此完整報告可能需要每個容器最多兩列。

僅掃描圖形層級的超連結可能會遺漏附加於文字部分的連結。請改為查詢適當的範圍，並保留回傳的容器，以便之後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) 類別可透過 [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/)、[IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) 與 [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) 取得。每個範圍支援相同的查詢：

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) 返回具有點擊動作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) 返回具有滑鼠懸停動作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) 返回具有任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠懸停連結、內部投影片導覽、文字滑鼠懸停連結與巨集動作。這些動作皆不會被執行。三種查詢在每個範圍皆可使用；計數描述的是容器數量，而非動作總數。文字框範圍會排除其所屬圖形本身的連結。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對於此範例，簡報與投影片查詢各報告三個點擊容器、兩個滑鼠懸停容器，以及三個任一動作的容器。文字框查詢則在每個類別中報告一個容器。

### **分類動作與目的地**

使用 [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) 於解讀目的地之前先判斷動作類型。[HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) 的值涵蓋的不僅是網頁導覽：

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 及其協議。 |
| `JumpSpecificSlide` | 內部導向至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，於投影片放映環境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的投影片放映或啟動自訂投影片放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網路 URL 分別審查。 |
| `StartStopMedia` | 啟動或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導向動作，或為未辨識的動作，需要審查。 |

從 [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) 讀取外部目的地，從 [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) 讀取特定內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若 [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 回傳的值與正規化後的 URL 不同，請保留原始值；如有可用的工具提示，亦請包含由 [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) 回傳的文字。

### **報告、清理與驗證超連結**

以下 PHP 範例讀取既有簡報（使用上面建立的檔案）、寫入 `hyperlink-audit.json`、套用政策、儲存 `hyperlink-sanitized.pptx`，並重新開啟以再次檢查兩種啟動方式。它在變更前收集容器，並使用參考相等性避免重複處理同一容器。簡報查詢涵蓋普通投影片；若要全套件清單，亦會明確查詢母片、版面配置、備註，以及備註與講義母片（若存在）。

報告會記錄以一為基礎的投影片索引與 [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--)（若可用）。[ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) 提供受支援容器的所屬投影片。母片、版面配置與備註沒有普通投影片索引，會以其範圍辨識。圖形容器與文字部分格式容器會分別標記；其他容器類型保留其執行時類型名稱。每個容器取得報告本地 ID，以便將其兩個動作關聯。報告將動作類型以 PHP 列舉定義的整數常數儲存。

此刻意限制的應用政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作以及其他 URL 協議。這些拒絕屬於政策決策，非 Aspose.Slides 安全性判斷。僅有 HTTPS 並不等同於信任：請為您的應用程式加入主機白名單與其他檢查。原始與正規化的外部 URL 都會被檢查。範例在不跟隨連結或執行動作的情況下審核中介資料。

若需補救，容器的 [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) 支援 [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)、[removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) 與 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)。此處，受限的外部點擊連結會被固定的 HTTPS 登陸頁面取代；其他受限的點擊與受限的滑鼠懸停動作則分別被移除。將 `$replaceExternalClicks` 設為 `false` 可以改為移除所有政策違規。請在部署前選擇應用程式擁有的取代頁面。

報告的匯出旗標採用保守的 PDF 審查政策：將滑鼠懸停動作及任何非外部連結或特定投影片跳轉的動作標記為可能不受支援。這只是審查提示，非功能測試或保證未標記的連結在匯出時一定會存活。支援的 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/) 匯出可能會保留超連結，取決於動作、匯出選項與檢視器。點陣 [圖像](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 無法保留互動超連結；在針對這些輸出進行審核時請將每個動作皆標記。

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

使用上述建立的輸入時，報告包含五筆動作列。檔案滑鼠懸停連結與巨集點擊被移除，而 HTTPS 連結與內部投影片導覽則保留。驗證結果顯示零筆違規動作。若輸入包含受限的外部點擊 URL，亦會觸發取代分支。具有允許點擊且受限滑鼠懸停的容器會保留其點擊動作。

此選擇性清理與 [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) 不同，後者會在所選範圍內無條件移除兩種啟動方式。此處的驗證僅檢查超連結動作，不會移除嵌入的 VBA 專案、OLE 物件或其他主動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何連結至區段或其第一張投影片？**

PowerPoint 的區段會將投影片分組，但內部超連結只能針對單一投影片。若要導向至區段，請將連結指向該區段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片與版面配置的元素支援超連結。使用對應母片或版面配置的投影片在投影片放映期間，這些連結皆可使用。

**匯出為 PDF、HTML、圖像或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；點陣圖像與影片則無法保留。請參閱 [報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks) 中的匯出考量。