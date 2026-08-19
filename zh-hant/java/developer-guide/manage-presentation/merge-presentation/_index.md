---
title: 高效合併 Java 簡報
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
description: "了解如何在 Java 中透過複製投影片、控制母片與版面配置、調整投影片內容大小、保留區段，並處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概觀**

Aspose.Slides for Java 透過從一個[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 複製投影片至另一個來合併簡報。主要操作是[ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，它可以保留來源投影片的格式，或將複製的投影片附加至目的簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- merge all slides while preserving their source formatting;
- merge selected slides;
- apply a master from the destination presentation;
- apply a specific layout from the destination presentation;
- normalize different slide sizes before merging;
- add cloned slides to a section;
- merge several presentations in one end-to-end workflow;
- handle masters, resources, notes, comments, media, fonts, passwords, large files, and multithreading concerns.

## **投影片複製對母片與版面配置的影響**

投影片的外觀大部分繼承自其版面配置與母片。因此，選擇的複製重載決定合併後的投影片如何整合到目的簡報中。

使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 以以下任一方式：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製到目的簡報。Aspose.Slides 會追蹤自動複製的母片，以避免重複複製相同的母片。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加至特定的目的[IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找匹配的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加至特定的目的[ILayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/)。

傳遞給 `addClone` 重載的母片或版面配置必須屬於**目的**簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製到目的簡報。當匯入的投影片應保留原始佈景主題、母片與版面配置關係時，此為適當的選擇。

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

若來源與目的使用不同的設計，結果簡報可能包含多個母片。這在有意保留來源格式時屬於預期行為。

## **合併選取的投影片**

您不必複製每張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

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

在索引來自使用者輸入或外部設定時，請先驗證投影片索引。

## **使用目的母片合併投影片**

當匯入的投影片應遵循已屬於目的簡報的母片時，使用[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 重載。

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

Aspose.Slides 會依來源版面配置的類型或名稱在指定的母片下選取適當的版面配置。若不存在合適的版面配置且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面配置以允許加入投影片。若為 `false`，則會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。

當您希望合併失敗而不是在目的母片中新增版面配置時，使用 `false`。

## **使用特定目的版面配置合併投影片**

當您確切知道匯入的投影片應使用哪個目的版面配置時，使用[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 重載。

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

套用目的版面配置會變更繼承的版面配置關係；它不會重新設計來源投影片的內容。若來源與目的版面配置的佔位結構不同，請檢查結果以確認繼承的格式與佔位行為是否符合預期。

## **合併不同投影片尺寸的簡報**

不同投影片尺寸的簡報可以合併，但將投影片複製到尺寸不同的簡報不會自動為新畫布重新設計內容。形狀可能因此出現移位、意外縮放，或位於可視投影片區域之外。

實務上可在複製前先調整來源簡報的尺寸。[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 方法可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/) 會將內容縮放以符合所要求的尺寸。

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

調整大小會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報供其他操作使用，請為合併開啟單獨的實例。

## **將投影片合併至簡報區段**

基本的投影片複製迴圈不會重建來源簡報的區段層級。若輸出中區段很重要，請在目的簡報中建立或選取區段，並使用[addClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 明確將投影片複製至該區段。

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

複製的投影片會被追加至指定的目的區段。若要保留多個來源區段，請在目的簡報中重新建立這些區段，並將每張來源投影片映射至相應的目的區段。

## **安全地合併多個簡報**

以下端對端範例以第一個簡報作為目的簡報，對每個額外來源正規化投影片尺寸，僅在複製期間開啟來源，最後一次保存檔案。

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

此範例是保留匯入投影片來源格式的實用基礎。如果輸出必須使用單一目的佈景主題，請將簡單的 `addClone(slide)` 呼叫替換為前述的目的母片或目的版面配置重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片複製會自動將所需的來源母片帶入目的簡報。Aspose.Slides 會為自動複製的母片維護內部登錄，以避免重複複製同一母片。手動複製的母片不會被此登錄追蹤，因此除非需要明確控制母片結構，否則請避免預先複製母片。

不要假設名稱相同的兩個母片或版面配置在視覺上等同。若企業模板必須控制最終外觀，請明確選取目的母片或版面配置，並在合併後驗證結果。

### **備註與評論**

講者備註與投影片評論與投影片內容相關聯，複製投影片時會一併複製。Aspose.Slides 也提供專門的 API 供[簡報備註](https://docs.aspose.com/slides/zh-hant/java/presentation-notes/)與[簡報評論](https://docs.aspose.com/slides/zh-hant/java/presentation-comments/)使用。

若備註頁面的格式很重要，請驗證合併後的簡報，因為備註母片屬於簡報層級物件，可能在來源檔案間有所差異。對於審閱工作流程，合併不同作者或模板的檔案後，也請驗證評論作者與串聯評論。

### **影像、音訊、視訊、OLE 物件與外部連結**

投影片可以參考簡報層級的資源，例如影像、內嵌音訊、內嵌視訊與 OLE 資料。請複製完整投影片，而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結資源應予以不同處理。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；複製投影片不會將外部連結轉為內嵌內容。請在最終開啟合併簡報的環境中測試連結資源的路徑與 URL。

Aspose.Slides 會明確追蹤自動複製的母片，但此功能不應被視為對來自不同來源簡報的相同二進位資源必然去除重複的保證。若檔案大小重要，請檢查合併後的套件並自行測量結果，而非依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器間保持一致，請不要假設僅複製投影片即可保證所有必要字型在目的環境中可用。您可以使用[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 檢查內嵌字型，並依照[Embed Fonts in Presentations](https://docs.aspose.com/slides/zh-hant/java/embedded-font/) 的說明明確管理字型內嵌。

同時請驗證您是否有權限內嵌來源檔案使用的字型。字型授權可能限制內嵌行為。

### **受密碼保護的簡報**

受密碼保護的來源必須先成功開啟，才能複製其投影片。請透過[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 提供密碼。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 在已解密的簡報上工作。
} finally {
    source.dispose();
}
```

開啟已加密的來源並不會自動將相同的保護套用到目的簡報。若需要，請另行設定輸出的保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、視訊或其他大型二進位物件的簡報會佔用大量記憶體。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 提供 BLOB 處理與暫存檔使用的控制。請參考[Manage Presentation BLOBs](https://docs.aspose.com/slides/zh-hant/java/manage-blob/) 取得大型檔案的策略。

對於大型檔案，盡可能使用檔案路徑載入，於合併完成後立即釋放每個來源簡報，並避免除非工作流程需要檢查點，否則頻繁保存中間結果。

### **執行緒安全性**

不要在多個執行緒中同時載入、修改、保存或複製同一個[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)實例。將每個簡報實例限制在單一合併操作內。若平行處理獨立工作，請使用獨立的簡報實例，並遵循[Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/zh-hant/java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用[`addClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，不提供目的母片或版面配置。Aspose.Slides 在需要時會自動複製來源母片。

**如何讓匯入的投影片使用目的主題？**

使用接受目的母片的重載。傳入目的簡報中的母片，而非來源的母片。Aspose.Slides 會嘗試將每張來源投影片映射至該母片下的適當版面配置。

**何時應使用特定的目的版面配置而非目的母片？**

當每張匯入的投影片都應使用已知的單一版面配置時，請使用特定版面配置。若希望 Aspose.Slides 依據來源版面配置的類型或名稱在該母片的版面配置中選擇，則使用母片。

**不同投影片尺寸的簡報能否合併？**

可以，但投影片內容不會自動依目的尺寸重新設計。若需要可預測的放置，請先使用[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 與[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一目的簡報，並以支援的輸出格式保存。因為不同簡報格式的功能集不完全相同，請在跨格式合併後驗證複雜內容。請參考[Supported File Formats](https://docs.aspose.com/slides/zh-hant/java/supported-file-formats/)。

**來源區段會自動保留嗎？**

基本的僅複製投影片的迴圈不會保留。若必須保留區段結構，請在目的簡報中重新建立所需的區段，並使用[addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 的區段重載。

**講者備註與評論會被保留嗎？**

它們會隨複製的投影片一起被複製。對於依賴備註母片樣式、評論作者或串聯審閱資料的工作流程，請驗證合併結果，因為這些情況涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼？**

內嵌的內容會隨複製的投影片資源關聯一起搬移。外部連結仍保持外部狀態，因此其目標檔案或 URL 必須在合併後仍可用。

**所有來源的內嵌字型都保證在合併後的簡報中可用嗎？**

不要僅依賴投影片複製來部署字型。請檢查目的簡報的內嵌字型，並在排版重要時明確管理字型內嵌或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 開啟檔案，然後正常複製其投影片。輸出的保護需另行設定。

**該如何處理非常大的簡報？**

當大型二進位物件佔用記憶體較多時，使用 BLOB 管理；對於非常大的檔案，盡量以檔案路徑載入，及時釋放來源簡報，且僅在需要時保存最終結果。

**我可以從多個執行緒合併投影片嗎？**

不要同時在多個執行緒中使用同一個[Presentation]實例。將每個合併作業限制在各自的簡報實例中。