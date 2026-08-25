---
title: 在 PHP 中高效合併簡報
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
- 整合 PowerPoint
- 整合 簡報
- 整合 投影片
- 整合 PPT
- 整合 PPTX
- 整合 ODP
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中透過克隆投影片、控制母片與版面配置、調整投影片內容尺寸、保留節以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for PHP via Java 透過從一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 複製投影片到另一個來合併簡報。主要操作是 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/)，它可以保留來源投影片的格式，或將已複製的投影片附加到目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片並保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報中的母片；
- 套用目標簡報中的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將已複製的投影片加入節；
- 在單一端到端工作流程中合併多個簡報；
- 處理母片、資源、備註、註解、媒體、字型、密碼、大檔案以及多執行緒相關問題。

## **投影片克隆對母片與版面配置的影響**

投影片的大部分外觀來源於其版面配置與母片。因此，您選擇的克隆重載會決定合併後的投影片如何整合至目標簡報。

使用 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 其中一種方式：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源的母片會自動複製到目標簡報。Aspose.Slides 會自動追蹤已複製的母片，以避免同一母片重複複製。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將已複製的投影片附加至特定的目標 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找相符的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 直接將已複製的投影片附加至特定的目標 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/)。

傳遞給 `addClone` 重載的母片或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製到目標簡報。當匯入的投影片應保留原始主題、母片與版面配置關係時，這是最合適的選擇。

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

如果來源與目標使用不同的設計，結果簡報可能會包含多個母片。這在刻意保留來源格式時是預期的行為。

## **合併選取的投影片**

您不必全部投影片都複製。以下範例僅從來源簡報匯入特定的投影片索引。

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

在克隆前驗證投影片索引，特別是當索引來源於使用者輸入或外部設定時。

## **使用目標母片合併投影片**

當匯入的投影片應使用已屬於目標簡報的母片時，請使用 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 重載。

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

Aspose.Slides 會依來源版面配置的類型或名稱，在指定的母片下選取相符的版面配置。若不存在合適的版面且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面以便加入投影片；若為 `false`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。

在希望合併失敗而非在目標母片中新增版面時，請使用 `false`。

## **使用特定目標版面配置合併投影片**

當您確定匯入的投影片應使用哪一個目標版面配置時，請使用 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 重載。

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

套用目標版面配置會變更繼承的版面關係，但不會重新設計來源投影片的內容。若來源與目標版面配置的佔位結構不同，請檢查結果以確認繼承的格式與佔位行為是否符合需求。

## **合併具有不同投影片尺寸的簡報**

不同投影片尺寸的簡報可以合併，但將投影片克隆到尺寸不同的簡報時，內容不會自動重新設計以符合新畫布。因此形狀可能會出現位移、比例異常或位於可見投影片區域之外。

實務上可在克隆前先調整來源簡報的尺寸。使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/setsize/) 方法即可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定大小。

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

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報供其他操作使用，請為合併開啟獨立的實例。

## **將投影片合併至簡報節**

基本的投影片克隆迴圈不會重新建立來源簡報的節層級。若輸出結果需要保留節，請在目標簡報中建立或選取節，並使用 [addClone(Slide, Section)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 明確將投影片克隆至該節。

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

已克隆的投影片會被附加至指定的目標節。若要保留多個來源節，請列舉 [Presentation::getSections](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSections)，使用 [Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSlidesListOfSection) 取得每個來源節的投影片清單，於目標簡報重新建立相同節，並將每張投影片克隆至對應的目標節。完整的節列舉範例請參考 [管理投影片節](/slides/zh-hant/php-java/slide-section/)，其中也說明了空節與結構變更的處理方式。

## **安全地合併多個簡報**

以下端到端範例將第一個簡報作為目標，對每個後續來源簡報正規化投影片尺寸，只在需要時才開啟來源，最後一次性儲存最終檔案。

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

這是一個保留匯入投影片來源格式的實用基礎。如果您的輸出必須使用單一目標主題，請將簡單的 `addClone($slide)` 呼叫替換為前面說明的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式相容性**

預設的投影片克隆會自動將必要的來源母片帶入目標簡報。Aspose.Slides 內部會維護一個自動克隆母片的登錄表，以避免重複克隆同一母片。手動事先克隆的母片不會被此登錄表追蹤，除非您需要對母片結構有明確控制，否則請避免事前克隆。

不要假設名稱相同的母片或版面配置在視覺上完全等同。若企業範本必須掌控最終外觀，請明確選擇目標母片或版面配置，並在合併後驗證結果。

### **備註與註解**

講者備註與投影片註解與投影片內容相關聯，克隆投影片時會一併複製。Aspose.Slides 亦提供專門的 API 用於 [簡報備註](/slides/zh-hant/php-java/presentation-notes/) 與 [簡報註解](/slides/zh-hant/php-java/presentation-comments/)。

若備註頁面格式重要，請驗證合併後的簡報，因為備註母片是簡報層級的物件，可能在不同來源檔案間有所差異。對於審閱工作流程，也請檢查註解作者與串接註解，特別是合併來自不同作者或範本的檔案時。

### **影像、音訊、視訊、OLE 物件與外部連結**

投影片可能引用簡報層級的資源，如影像、內嵌音訊、內嵌視訊與 OLE 資料。請克隆整張投影片，而非僅複製可見的圖形，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結資源的處理方式不同。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；克隆投影片不會將外部連結自動轉為內嵌內容。請在最終使用的環境中測試連結路徑與 URL 是否可用。

Aspose.Slides 會追蹤自動克隆的母片，但這不代表來自無關來源簡報的相同二進位資源必定會被去重。如需控制輸出檔案大小，請自行檢查合併後的套件並測量結果，而不要依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器間保持一致，請不要僅依賴投影片克隆就認為所有必要字型已在目標環境可用。您可以使用 [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getembeddedfonts/) 檢查內嵌字型，並依照 [在簡報中嵌入字型](/slides/zh-hant/php-java/embedded-font/) 的說明手動管理字型嵌入。

同時也請確認您有權限將來源檔案使用的字型嵌入。字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先正確開啟受密碼保護的來源簡報，才能克隆其投影片。請透過 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/setpassword/) 提供密碼。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // 使用已解密的簡報進行操作。
} finally {
    $source->dispose();
}
```

開啟加密的來源不會自動將相同的保護套用至目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、視訊或其他大型二進位物件的簡報會佔用大量記憶體。[LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) 提供 BLOB 處理與暫存檔使用的控制。相關大型檔案範例請參考 [開啟簡報](/slides/zh-hant/php-java/open-presentation/#open-large-presentations)。

對於大型檔案，盡可能使用檔案路徑載入，於合併完畢後立即釋放每個來源簡報，並避免頻繁儲存中間結果，除非工作流程需要檢查點。

### **執行緒安全性**

請勿在多執行緒中載入、修改、儲存或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。這些操作在 PHP via Java 中並不支援多執行緒使用。如需平行合併工作，請在獨立的單執行緒程序中執行，每個程序使用自己的簡報實例，並遵循 [Aspose.Slides 多執行緒指引](/slides/zh-hant/php-java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用 [SlideCollection::addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 並且不提供目標母片或版面配置。Aspose.Slides 會在需要時自動克隆來源母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載，傳入目標簡報中的母片，而非來源母片。Aspose.Slides 會嘗試將每個來源投影片映射至該母片下的適當版面配置。

**何時應使用特定目標版面配置而非目標母片？**

當所有匯入投影片均應使用同一已知版面配置時使用特定版面；若希望 Aspose.Slides 依來源版面類型或名稱在該母片的版面中自動挑選，則使用母片。

**不同投影片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動為目標尺寸重新設計。若需可預測的排列方式，請先使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/setsize/) 及 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**可以將 PPT、PPTX 與 ODP 簡報合併成同一檔案嗎？**

可以。載入每個來源簡報，將所需投影片克隆至同一目標簡報，最後以支援的格式儲存。因為不同簡報格式的功能集合不盡相同，請在跨格式合併後驗證複雜內容。參考 [支援的檔案格式](/slides/zh-hant/php-java/supported-file-formats/)。

**來源節會自動保留嗎？**

不會，基本的僅克隆投影片的迴圈不會保留節結構。若必須保留節，請在目標簡報中重新建立相應節，並使用 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 的節重載。

**講者備註與註解會被保留嗎？**

會與克隆的投影片一起複製。若工作流程依賴備註母片樣式、註解作者或串接審閱資料，請在合併後驗證結果，因為這些情境涉及簡報層級結構與投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

內嵌的內容會隨克隆的投影片一起保留其資源關聯。外部連結仍保持外部屬性，合併後仍需確保其目標檔案或 URL 可用。

**所有來源的內嵌字型是否保證在合併後可用？**

僅依賴投影片克隆並不能保證字型部署。請檢查目標簡報的內嵌字型，並在排版重要時明確管理字型嵌入或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/setpassword/) 開啟檔案，然後照常克隆投影片。輸出保護需另行設定。

**該如何處理非常大型的簡報？**

在大型二進位物件佔用記憶體時使用 BLOB 管理，盡可能以檔案路徑載入，快速釋放來源簡報，並僅在必要時儲存最終結果。

**可以從多個執行緒合併投影片嗎？**

在 PHP via Java 中不支援在多執行緒中載入、儲存或克隆簡報。若需平行處理，請使用獨立的單執行緒程序，並確保每個程序內的簡報實例彼此隔離。