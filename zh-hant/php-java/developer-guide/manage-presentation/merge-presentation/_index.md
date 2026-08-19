---
title: 高效在 PHP 中合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/php-java/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併 簡報
- 合併 投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合 簡報
- 結合 投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中透過克隆投影片、控制母片與版面配置、調整投影片內容大小、保留章節，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for PHP via Java 透過克隆投影片的方式，將一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 的投影片合併至另一個。主要操作是 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/)，它可以保留來源投影片的格式，或將複製的投影片附加到目的投影片的母片或版面配置。

本篇說明最常見的合併工作流程：

- 合併全部投影片，同時保留來源格式；
- 合併選取的投影片；
- 套用目的簡報的母片；
- 套用目的簡報的特定版面配置；
- 在合併前正規化不同的投影片大小；
- 將複製的投影片加入章節；
- 在單一端對端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案及多執行緒相關問題。

## **投影片克隆對母片與版面配置的影響**

投影片的外觀大部分繼承自其版面配置與母片。因此，您選擇的克隆重載決定了合併後的投影片如何整合至目的簡報。

以以下方式使用 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/)：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動克隆至目的簡報。Aspose.Slides 會追蹤自動克隆的母片，以避免相同來源母片的投影片重複克隆母片。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加到指定的目的 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找相符的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加至指定的目的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/)。

傳遞給 `addClone` 重載的母片或版面配置必須屬於 **目的** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製到目的簡報。這在匯入的投影片需要保留原始主題、母片與版面配置關聯時最為合適。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

當來源與目的使用不同設計時，結果簡報可能會包含多個母片。這是保留來源格式的正常行為。

## **合併選取的投影片**

您不必克隆所有投影片。以下範例僅從來源簡報匯入特定的投影片索引。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

在克隆前，請驗證投影片索引，特別是當索引來自使用者輸入或外部設定時。

## **使用目的母片合併投影片**

當匯入的投影片應遵循已屬於目的簡報的母片時，使用 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 重載。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides 會依來源版面配置的類型或名稱，在指定的母片下選取合適的版面配置。如果找不到相符的版面且 `allowCloneMissingLayout` 為 `true`，則會克隆來源版面以便加入投影片。若為 `false`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。

在您希望合併失敗，而不是在目的母片中新增版面時，請使用 `false`。

## **使用特定目的版面配置合併投影片**

當您確切知道匯入的投影片應使用哪個目的版面時，使用 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 重載。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

套用目的版面會改變繼承的版面關係，但不會重新設計來源投影片的內容。若來源與目的版面具有不同的佔位元結構，請檢查結果以確認繼承的格式與佔位元行為是否符合預期。

## **合併不同投影片尺寸的簡報**

不同投影片尺寸的簡報可以合併，然而將投影片克隆至尺寸不同的簡報時，內容不會自動重新設計以符合新畫布。形狀可能會出現位移、意外縮放，甚至超出可視範圍。

實務做法是先在克隆前調整來源簡報的尺寸。使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/setsize/) 方法可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/) 則會將內容縮放至符合指定大小。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報以供其他操作，請為合併開啟單獨的實例。

## **將投影片合併至簡報章節**

基本的投影片克隆迴圈不會重建來源簡報的章節層級。若輸出需要保留章節，請在目的簡報中建立或選取章節，並使用 [addClone(Slide, Section)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 明確將投影片克隆至該章節。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

複製的投影片會被追加至指定的目的章節。若要保留多個來源章節，請先在目的簡報中重建這些章節，並將每張來源投影片對映至相應的目的章節。

## **安全合併多個簡報**

以下端對端範例以第一個簡報作為目的簡報，對每個額外來源正規化投影片尺寸，僅在複製時開啟來源，最後一次性儲存最終檔案。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

這是一個保留匯入投影片來源格式的實用基礎。若您的輸出必須使用單一目的主題，請將簡單的 `addClone($slide)` 呼叫替換為前述的目的母片或目的版面重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片克隆會自動將所需的來源母片帶入目的簡報。Aspose.Slides 會為自動克隆的母片維護內部登錄，以避免重複克隆同一母片。手動克隆的母片不會被此登錄追蹤，除非您需要明確控制母片結構，否則請避免事先克隆母片。

即使兩個母片或版面名稱相同，也不代表視覺上等同。若企業範本必須控制最終外觀，請明確選擇目的母片或版面，並在合併後驗證結果。

### **備註與評論**

投影片備註與評論與投影片內容關聯，克隆投影片時會一併複製。Aspose.Slides 亦提供專門的 API 供存取[簡報備註](https://docs.aspose.com/slides/zh-hant/php-java/presentation-notes/)與[簡報評論](https://docs.aspose.com/slides/zh-hant/php-java/presentation-comments/)。

若備註頁面的格式重要，請檢查合併後的簡報，因為備註母片屬於簡報層級物件，可能在來源檔案間有所不同。對於審閱工作流程，也請驗證評論作者與線索評論，尤其是合併來自不同作者或範本的檔案時。

### **圖片、音訊、視訊、OLE 物件與外部連結**

投影片可能參考簡報層級的資源，例如圖片、內嵌音訊、內嵌視訊與 OLE 資料。請克隆整張投影片，而非僅複製可見形狀，讓 Aspose.Slides 能保留投影片與資源之間的關聯。

內嵌與連結資源的處理方式不同。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；克隆投影片不會將外部連結自動轉為內嵌內容。請在最終環境測試連結資源的路徑與 URL。

Aspose.Slides 會追蹤自動克隆的母片，但這不等於保證來自不同來源簡報的相同二進位資源必定會被去重。若檔案大小是關鍵，請自行檢查合併後的套件並測量結果，而非依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，請勿僅假設克隆投影片即可確保所有必需字型在目的環境中可用。您可以使用 [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getembeddedfonts/) 來檢查內嵌字型，並依照 [Embed Fonts in Presentations](https://docs.aspose.com/slides/zh-hant/php-java/embedded-font/) 的說明明確管理內嵌。

同時也要確認您有權限內嵌來源檔案使用的字型，因字型授權可能限制內嵌。

### **受密碼保護的簡報**

必須先成功以正確密碼開啟受保護的來源簡報，才能克隆其投影片。請透過 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/setpassword/) 提供密碼。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // 在已解密的簡報上工作。
} finally {
    $source->dispose();
}
```

開啟加密來源並不會自動將相同保護套用至目的簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度圖片、音訊、視訊或其他大型二進位物件的簡報會佔用大量記憶體。[LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) 提供 BLOB 處理與暫存檔使用的控制。請參考 [Open Presentations](https://docs.aspose.com/slides/zh-hant/php-java/open-presentation/#open-large-presentations) 中的 PHP via Java 大檔案範例。

對於大型檔案，盡可能使用檔案路徑載入，於完成合併後立即釋放每個來源簡報，除非工作流程需要檢查點，否則避免反覆儲存中間結果。

### **執行緒安全性**

請勿在多執行緒中載入、修改、儲存或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。這些操作在 PHP via Java 中不支援多執行緒使用。若需要平行合併工作，請於獨立的單執行緒行程中執行，每個行程使用自己的簡報實例，並遵循 [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/zh-hant/php-java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用 [`addClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 且不提供目的母片或版面。Aspose.Slides 會在需要時自動克隆來源母片。

**如何讓匯入的投影片使用目的主題？**

使用接受目的母片的重載。傳入目的簡報中的母片，而非來源的。Aspose.Slides 會嘗試將每個來源投影片對映到該母片下的適當版面。

**何時應使用特定目的版面而非目的母片？**

當所有匯入的投影片都必須使用同一已知版面時使用特定版面。若希望 Aspose.Slides 依據來源版面類型或名稱在該母片的版面中自動選擇，則使用母片。

**不同投影片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動重新設計以適應目的尺寸。若需要可預測的版面配置，請先使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/setsize/) 以及 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成同一檔案嗎？**

可以。載入每個來源簡報，將所需投影片克隆至同一目的簡報，最後以支援的輸出格式儲存。因不同格式的功能支援度不盡相同，請在跨格式合併後驗證複雜內容。請參閱 [Supported File Formats](https://docs.aspose.com/slides/zh-hant/php-java/supported-file-formats/)。

**來源章節會自動保留嗎？**

單純只克隆投影片的基本迴圈不會保留章節。若必須保留章節結構，請先於目的簡報建立相應章節，並使用 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 的章節重載。

**投影片備註與評論會被保留嗎？**

會隨著克隆的投影片一起複製。若工作流程依賴備註母片樣式、評論作者或線索審閱資料，請在合併後驗證結果，因為這些情境涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會怎樣處理？**

內嵌內容會隨克隆的投影片資源關聯一起保留。外部連結仍保持外部狀態，合併後仍需確保其目標檔案或 URL 可存取。

**所有來源的內嵌字型是否都會在合併後可用？**

僅依賴投影片克隆不足以保證字型部署。請檢查目的簡報的內嵌字型，並在排版重要時明確管理字型內嵌或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/setpassword/) 開啟來源，然後正常克隆投影片。輸出保護需另行設定。

**如何處理非常大的簡報？**

使用 BLOB 管理以降低大型二進位物件的記憶體佔用，盡可能以檔案路徑載入大型檔案，及時釋放來源簡報，並僅在需要時儲存最終結果。

**我可以在多個執行緒中合併投影片嗎？**

在 PHP via Java 中不支援在多執行緒中載入、儲存或克隆簡報。若需平行工作，請使用獨立的單執行緒行程，並確保每個行程的簡報實例相互隔離，遵循多執行緒指導原則。