---
title: 在 Java 中有效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "了解如何在 Java 中透過克隆投影片、控制母片與版面配置、調整投影片內容大小、保留章節，並處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概觀**

Aspose.Slides for Java 透過將投影片從一個 [簡報](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 複製到另一個來合併簡報。主要的操作是 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，它可以保留來源投影片的格式，或將複製的投影片附加到目的簡報的母片或版面配置上。

本文說明最常見的合併工作流程：

- 合併所有投影片並保留其來源格式；
- 合併選取的投影片；
- 套用目的簡報的母片；
- 套用目的簡報的特定版面配置；
- 在合併前將不同的投影片尺寸正規化；
- 將複製的投影片加入到章節；
- 在一次端對端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案與多執行緒相關問題。

## **投影片克隆對母片與版面配置的影響**

投影片的大部分外觀都是從其版面配置與母片繼承而來。因此，您選擇的克隆 overload 會決定合併後的投影片如何整合到目的簡報中。

使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 時可採取以下方式：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製到目的簡報。Aspose.Slides 會追蹤自動複製的母片，避免同一母片因重複投影片而被多次複製。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加到特定的目的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/)。Aspose.Slides 會根據版面類型或名稱在該母片下尋找匹配的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加到特定的目的 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/)。

傳遞給 `addClone` overload 的母片或版面配置必須屬於 **目的** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製到目的簡報。當匯入的投影片應保留原始佈景主題、母片與版面配置關係時，這是最適合的選擇。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

如果來源與目的使用不同的設計，最終簡報可能會包含多個母片。這在刻意保留來源格式時是預期的行為。

## **合併選取的投影片**

不必克隆每一張投影片。以下範例僅從來源簡報匯入指定的投影片索引。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

在克隆前請驗證投影片索引，尤其是來自使用者輸入或外部設定時。

## **使用目的母片合併投影片**

當匯入的投影片應遵循已屬於目的簡報的母片時，請使用 [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) overload。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides 會根據來源版面的類型或名稱，在指定的母片下選取適當的版面配置。如果不存在匹配的版面且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面以便加入投影片；若為 `false`，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。

在希望合併失敗而不是在目的母片中新增版面時，請使用 `false`。

## **使用特定目的版面配置合併投影片**

當您確定匯入的投影片應使用哪個目的版面配置時，請使用 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) overload。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

套用目的版面會改變繼承的版面關係，但不會重新設計來源投影片的內容。若來源與目的版面具有不同的占位元結構，請檢查結果以確認繼承的格式與占位元行為是否符合預期。

## **合併具有不同投影片尺寸的簡報**

不同投影片尺寸的簡報可以合併，但將投影片克隆到尺寸不同的簡報時，內容不會自動重新設計以符合新畫布。形狀可能會移位、比例失常，或超出可見投影片範圍。

實務上可先在克隆前調整來源簡報的尺寸。使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 方法可在變更投影片尺寸的同時縮放現有內容。搭配 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/) 可將內容縮放至符合目標尺寸。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

調整尺寸會在記憶體中修改來源簡報物件。若您需要保留未變更的來源簡報供其他操作使用，請為合併另開一個實例。

## **將投影片合併到簡報章節**

基本的投影片克隆迴圈不會重建來源簡報的章節層次結構。若輸出需要保留章節，請在目的簡報中建立或選取章節，並使用 [addClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 明確將投影片克隆到章節內。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

克隆的投影片會被加入到指定的目的章節。若要保留多個來源章節，可列舉 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSections--)，使用 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSlidesListOfSection--) 取得每個來源章節的投影片清單，於目的簡報中重新建立章節，然後將每張回傳的投影片克隆到相對應的目的章節。詳情請參閱 [管理投影片章節](/slides/zh-hant/java/slide-section/) 其中的完整章節列舉範例，包括空章節與結構變更。

## **安全地合併多個簡報**

以下端對端範例以第一個簡報作為目的簡報，對每個額外的來源正規化投影片尺寸，只在需要複製時才開啟來源，最後一次性保存檔案。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

這是保留匯入投影片來源格式的實用基礎範例。若您的輸出必須統一使用單一目的佈景主題，請將簡單的 `addClone(slide)` 呼叫取代為前述的目的母片或目的版面 overload。

## **實務考量**

### **母片、版面與格式忠實度**

預設的投影片克隆會自動將所需的來源母片帶入目的簡報。Aspose.Slides 會為自動克隆的母片維護內部註冊表，以避免同一母片被重複克隆。手動預先克隆的母片不會被此註冊表追蹤，除非需要對母片結構進行明確控制，否則請避免事先克隆。

不要假設名稱相同的兩個母片或版面在視覺上是等同的。若企業模板必須掌控最終外觀，請明確選擇目的母片或版面，並在合併後驗證結果。

### **備註與評論**

講者備註與投影片評論與投影片內容相關聯，克隆投影片時會一併複製。Aspose.Slides 亦提供專屬的 API 用於 [簡報備註](/slides/zh-hant/java/presentation-notes/) 與 [簡報評論](/slides/zh-hant/java/presentation-comments/)。

若備註頁的格式很重要，請驗證合併後的簡報，因為備註母片屬於簡報層級物件，可能在來源檔案間有所差異。針對審閱工作流程，合併來自不同作者或模板的檔案後，也請檢查評論作者與串接評論。

### **影像、音訊、影片、OLE 物件與外部連結**

投影片可能會引用簡報層級的資源，例如影像、內嵌音訊、內嵌影片與 OLE 資料。請克隆整張投影片，而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關聯。

對於嵌入與連結的資源，應該分別處理。連結的音訊、影片、OLE 物件或超連結仍然依賴其外部目標；克隆投影片不會將外部連結自動轉為嵌入內容。請在最終開啟簡報的環境中測試連結路徑與 URL。

雖然 Aspose.Slides 會追蹤自動克隆的母片，但此機制不應被視為對來自不同來源簡報的相同二進位資源一定會去除重複的通用保證。若檔案大小是關鍵，請自行檢查合併後的套件並測量結果，而非依賴隱含的去重。

### **嵌入字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器間保持一致，請勿僅依賴投影片克隆來保證所有必需字型在目的環境中可用。您可以使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 檢查嵌入的字型，並依照 [在簡報中嵌入字型](/slides/zh-hant/java/embedded-font/) 的說明明確管理嵌入。

同時請確認您有權利嵌入來源檔案使用的字型。字型授權可能限制嵌入。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源簡報，才能克隆其投影片。請透過 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 提供密碼。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 使用已解密的簡報。
} finally {
    source.dispose();
}
```

開啟加密來源不會自動將相同的保護套用到目的簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、影片或其他大型二進位物件的簡報會佔用大量記憶體。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 提供 BLOB 處理與暫存檔使用的控制。請參考 [管理簡報 BLOB](/slides/zh-hant/java/manage-blob/) 了解大型檔案的策略。

針對大檔案，盡可能使用檔案路徑載入，於合併完畢後立即釋放每個來源簡報，且除非工作流程需要檢查點，否則避免頻繁儲存中間結果。

### **執行緒安全性**

不要在多個執行緒中同時載入、修改、儲存或克隆同一個 [簡報](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例。每個簡報實例應僅用於單一合併作業。如需平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides 多執行緒指引](/slides/zh-hant/java/multithreading/)。

## **常見問答**

**如何保留每個來源簡報的原始設計？**

使用不提供目的母片或版面的 `addClone`，Aspose.Slides 會在需要時自動複製來源母片。

**如何讓匯入的投影片使用目的佈景主題？**

使用接受目的母片的 overload。傳入目的簡報的母片，而非來源的母片。Aspose.Slides 會嘗試將每張來源投影片對映到該母片下的適當版面。

**什麼時候該使用特定目的版面而非目的母片？**

當所有匯入的投影片都必須使用同一已知版面時使用版面 overload；若希望 Aspose.Slides 依據來源版面類型或名稱在母片的版面中自動選取，則使用母片 overload。

**不同投影片尺寸的簡報能合併嗎？**

可以，但投影片內容不會自動重新設計以符合目的尺寸。若需要可預測的位置，請先使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 及 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片克隆到同一個目的簡報，最後以支援的輸出格式保存。因為不同格式的功能集合可能不完全相同，請在跨格式合併後驗證複雜內容。參見 [支援的檔案格式](/slides/zh-hant/java/supported-file-formats/)。

**來源章節會自動保留嗎？**

基本的僅克隆投影片的迴圈不會。若需保留章節結構，請在目的簡報中重新建立章節，並使用 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 的章節 overload。

**講者備註與評論會被保留嗎？**

會隨克隆的投影片一起複製。對於依賴備註母片樣式、評論作者或串接審閱資料的工作流程，請驗證合併結果，因為這些情境涉及簡報層級結構與投影片層級內容。

**音訊、影片、OLE 物件與超連結會怎樣處理？**

嵌入的內容會隨克隆的投影片資源關聯一起帶入。外部連結仍保持外部狀態，合併後仍須確保其目標檔案或 URL 可存取。

**所有來源的嵌入字型都會在合併簡報中可用嗎？**

不要僅依賴投影片克隆來部署字型。請檢查目的簡報的嵌入字型，並在排版重要時明確管理字型嵌入或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 開啟檔案，然後正常克隆其投影片。輸出保護需另行設定。

**該如何處理非常大的簡報？**

在大型二進位物件佔用記憶體時使用 BLOB 管理，盡可能以檔案路徑載入，及時釋放來源簡報，並僅在需要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**

不要在多執行緒中共用同一個 [簡報](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例。每個合併作業應使用獨立的簡報實例。