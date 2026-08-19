---
title: 在 JavaScript 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/nodejs-java/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併簡報
- 合併投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 組合 PowerPoint
- 組合簡報
- 組合投影片
- 組合 PPT
- 組合 PPTX
- 組合 ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何在 JavaScript 中通過克隆投影片、控制母片與版面配置、調整投影片內容大小、保留節以及處理受保護或大型檔案，來合併 PowerPoint 和 OpenDocument 簡報。"
---
## **概覽**

Aspose.Slides for Node.js via Java 透過將幻燈片從一個[簡報](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)克隆到另一個來合併簡報。主要的操作是[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)，它可以保留來源幻燈片的格式，或將克隆的幻燈片附加到目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有幻燈片，同時保留其來源格式；
- 合併選取的幻燈片；
- 使用目標簡報的母片；
- 使用目標簡報的特定版面配置；
- 在合併前正規化不同的幻燈片尺寸；
- 將克隆的幻燈片加入節；
- 在單一端到端工作流程中合併多個簡報；
- 處理母片、資源、註解、評論、媒體、字型、密碼、大檔案以及多執行緒相關問題。

## **投影片克隆如何影響母片與版面配置**

投影片的大部分外觀會從其版面配置與母片繼承。因此，您選擇的克隆重載方式會決定合併後的投影片如何整合至目標簡報。

使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/)時，可採取以下任一方式：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動克隆到目標簡報。Aspose.Slides 會追蹤自動克隆的母片，避免同一來源母片被重複克隆。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將克隆的投影片附加到特定的目標[MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)。Aspose.Slides 會依版面配置類型或名稱，於該母片下尋找匹配的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 將克隆的投影片直接附加到特定的目標[LayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/)。

傳遞給 `addClone` 重載的母片或版面配置必須屬於**目標**簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製到目標簡報。當匯入的投影片需要保留原始主題、母片與版面配置關係時，這是適當的選擇。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

若來源與目標使用不同的設計，最終簡報可能會包含多個母片。這在刻意保留來源格式時屬於預期行為。

## **合併選取的投影片**

您不必克隆每張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

在克隆之前，請驗證投影片索引，尤其是來自使用者輸入或外部設定時。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已存在於目標簡報的母片時，請使用[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 重載。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides 會根據來源版面配置的類型或名稱，在指定的母片下選取合適的版面配置。若不存在合適的版面配置且 `allowCloneMissingLayout` 為 `true`，則會克隆來源版面配置以便加入投影片；若為 `false`，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxeditexception/)。

當您希望合併失敗而不是在目標母片中新增版面配置時，請使用 `false`。

## **使用特定目標版面配置合併投影片**

當您確定匯入的投影片必須使用特定的目標版面配置時，請使用[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) 重載。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

套用目標版面配置會改變繼承的版面關係；它不會重新設計來源投影片的內容。若來源與目標版面配置的佔位元結構不同，請檢查結果，以確保繼承的格式與佔位元行為符合預期。

## **合併不同幻燈片尺寸的簡報**

不同幻燈片尺寸的簡報可以合併，但將投影片克隆至尺寸不同的簡報不會自動為新畫布重新設計內容。形狀可能會出現移位、比例異常或超出可視範圍的情況。

實用的做法是在克隆前先調整來源簡報的尺寸。`[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` 方法可在變更幻燈片尺寸的同時縮放現有內容。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesizescaletype/)` 會將內容縮放至符合指定大小。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報以供其他操作，請為合併開啟另一個實例。

## **將投影片合併至簡報節**

基本的克隆迴圈不會重建來源簡報的節層級。若輸出需要保留節結構，請在目標簡報中建立或選取節，並使用 `[addClone(Slide, Section)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` 明確將投影片克隆至該節。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

克隆的投影片會附加到指定的目標節。若要保留多個來源節，請在目標中重建這些節，並將每個來源投影片對映至相應的目標節。

## **安全合併多個簡報**

以下端到端範例使用第一個簡報作為目標，將每個額外來源的幻燈片尺寸正規化，僅在複製期間保持來源開啟，最終一次性保存檔案。

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

這是一個保留匯入投影片來源格式的實用基礎。若您的輸出必須使用單一目標主題，請將簡單的 `addClone(sourceSlide)` 呼叫替換為前述的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片克隆會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會維護自動克隆母片的內部註冊表，以避免重複克隆同一母片。手動克隆的母片不會被該註冊表追蹤，因此除非需要對母片結構進行明確控制，否則請避免預先克隆母片。

即使兩個母片或版面配置名稱相同，也不要假設它們在外觀上等價。若企業範本必須控制最終外觀，請明確選取目標母片或版面配置，並在合併後驗證結果。

### **註解與評論**

講者備註與投影片評論與投影片內容關聯，克隆投影片時會一併複製。Aspose.Slides 也提供專門的 API 供[簡報備註](https://docs.aspose.com/slides/zh-hant/nodejs-java/presentation-notes/)與[簡報評論](https://docs.aspose.com/slides/zh-hant/nodejs-java/presentation-comments/)使用。

若備註頁的格式很重要，請驗證合併後的簡報，因為備註母片是簡報層級的物件，來源檔案間可能不同。對於審閱工作流程，亦請在合併不同作者或範本的檔案後，驗證評論作者與串接評論的正確性。

### **圖片、音訊、視訊、OLE 物件與外部連結**

投影片可能會引用簡報層級的資源，如圖片、內嵌音訊、內嵌視訊與 OLE 資料。請克隆整張投影片，而非僅複製可見圖形，讓 Aspose.Slides 能維護投影片與資源之間的關聯。

內嵌與連結的資源應分別處理。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；克隆投影片不會將外部連結自動轉為內嵌內容。請在最終開啟的環境中測試連結路徑與 URL。

雖然 Aspose.Slides 會追蹤自動克隆的母片，但這不代表來自不同來源簡報的相同二進位資源一定會被去重。若輸出檔案大小重要，請檢查合併後的封裝並自行測量結果，而非依賴隱性去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，請勿僅依賴投影片克隆就假設所有必要字型均已在目標環境中可用。您可以使用 `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)` 檢查內嵌字型，並依照[在簡報中嵌入字型](https://docs.aspose.com/slides/zh-hant/nodejs-java/embedded-font/)的說明明確管理字型嵌入。

同時也請確認您有權限嵌入來源檔案使用的字型；字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源，才能克隆其投影片。請透過 `[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` 提供密碼。

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // 處理已解密的簡報。
} finally {
    source.dispose();
}
```

開啟加密的來源不會自動將相同的保護套用至目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用量**

包含高解析度圖片、音訊、視訊或其他大型二進位物件的簡報會消耗大量記憶體。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--)` 提供 BLOB 處理與暫存檔使用的控制。請參考[管理簡報 BLOB](https://docs.aspose.com/slides/zh-hant/nodejs-java/manage-blob/)以了解大型檔案的策略。

對於大型檔案，盡可能使用檔案路徑載入，於合併完成後立即釋放每個來源簡報，除非工作流程需要檢查點，否則避免重複儲存中間結果。

### **執行緒安全性**

請勿在多個執行緒中載入、儲存或克隆同一個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)實例。這些操作不支援多執行緒使用。若需要平行處理多個獨立的合併工作，請使用多個單執行緒的程序，各自擁有獨立的簡報實例，並遵循[Aspose.Slides 多執行緒指導方針](https://docs.aspose.com/slides/zh-hant/nodejs-java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用[`addClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)，且不提供目標母片或版面配置。Aspose.Slides 會在需要時自動克隆來源母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入目標簡報中的母片，而非來源母片。Aspose.Slides 會嘗試將每個來源投影片映射至該母片下的適當版面配置。

**何時應使用特定的目標版面配置而非目標母片？**

當每張匯入的投影片都必須使用同一已知版面配置時，使用特定版面配置；當希望 Aspose.Slides 根據來源版面配置的類型或名稱，在該母片的多個版面配置之間自動選擇時，則使用母片。

**不同幻燈片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動為目標尺寸重新設計。若需要預測的版面位置，請先調整來源簡報，例如使用 `[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` 與 `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesizescaletype/)`。

**我可以將 PPT、PPTX 與 ODP 簡報合併成同一個檔案嗎？**

可以。載入每個來源簡報，將所需的投影片克隆至同一目標簡報，並以支援的輸出格式保存。因為不同簡報格式的功能集合不完全相同，請在跨格式合併後驗證複雜內容。請參閱[支援的檔案格式](https://docs.aspose.com/slides/zh-hant/nodejs-java/supported-file-formats/)。

**來源節會自動保留嗎？**

不會，基本的僅克隆投影片的迴圈不會保留節結構。若必須保留節，請在目標中重新建立所需節，並使用 `[addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` 的節重載。

**講者備註與評論會被保留嗎？**

會隨克隆的投影片一起複製。對於依賴備註母片樣式、評論作者或串接審閱資料的工作流程，請驗證合併結果，因為這些情況涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

內嵌的內容會隨克隆的投影片的資源關聯一起保留。外部連結仍然保持外部狀態，合併後仍需確保其目標檔案或 URL 可用。

**是否保證所有來源的內嵌字型都會出現在合併後的簡報中？**

不要僅依賴投影片克隆來部署字型。請檢查目標簡報的內嵌字型，並在排版重要時明確管理字型嵌入或外部字型的可用性。

**如何合併受密碼保護的檔案？**

使用正確的 `[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` 開啟檔案，然後正常克隆其投影片。輸出保護需另行配置。

**如何處理非常大的簡報？**

在大型二進位物件主導記憶體使用時，使用 BLOB 管理，盡可能以檔案路徑載入大型檔案，及時釋放來源簡報，且僅在必要時保存最終結果。

**我可以從多個執行緒合併投影片嗎？**

不要在多個執行緒中載入、保存或克隆簡報實例。若需平行合併工作，請使用獨立的單執行緒程序及獨立的簡報實例。