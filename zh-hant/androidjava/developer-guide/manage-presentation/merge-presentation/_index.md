---
title: 在 Android 上高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上透過複製投影片、控制母片與版面配置、調整投影片內容大小、保留區段，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概覽**

Aspose.Slides for Android via Java 透過從一個 [簡報](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 複製投影片到另一個簡報的方式合併簡報。主要操作是 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，它可保留來源投影片的格式，或將複製的投影片附加至目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片並保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報的母片；
- 套用目標簡報的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將複製的投影片加入區段；
- 在一次端對端的工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案與多執行緒相關問題。

## **投影片複製對母片與版面配置的影響**

投影片的外觀大部分繼承自其版面配置與母片。因此，選擇的複製重載方式會決定合併投影片在目標簡報中的整合方式。

使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 可採取以下方式：

- `addClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製到目標簡報。Aspose.Slides 會追蹤自動複製的母片，避免重複複製相同的來源母片。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加至特定的目標 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找相符的版面配置。
- `addClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加至特定的目標 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/)。

傳遞給 `addClone` 重載的母片或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製到目標簡報。當匯入的投影片應保留其原始主題、母片與版面配置關係時，這是最合適的選擇。

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

如果來源與目標使用不同的設計，最終簡報可能會包含多個母片。這在有意保留來源格式時是正常現象。

## **合併選取的投影片**

不必複製每張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

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

在從使用者輸入或外部組態取得索引時，請先驗證投影片索引的有效性。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已屬於目標簡報的母片時，請使用 [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 重載。

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

Aspose.Slides 會根據來源版面的類型或名稱，在指定的母片下選取適當的版面配置。若不存在相符的版面且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面以便加入投影片；若為 `false`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxeditexception/)。

若希望合併失敗而不是在目標母片中加入額外版面，請使用 `false`。

## **使用特定目標版面配置合併投影片**

當您明確知道匯入的投影片應使用哪個目標版面配置時，請使用 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 重載。

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

套用目標版面配置會變更繼承的版面關係；不會重新設計來源投影片的內容。若來源與目標版面配置的占位元結構不同，請檢查結果以確認繼承的格式與占位元行為是否符合預期。

## **合併具有不同投影片尺寸的簡報**

尺寸不同的簡報可以合併，但將投影片複製到尺寸不同的簡報時，內容不會自動重新設計以符合新畫布。形狀可能會出現偏移、縮放異常或超出可見投影片範圍。

實務做法是在複製前先調整來源簡報的尺寸。可使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) 方法在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定尺寸。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

調整尺寸會在記憶體中變更來源簡報物件。若需要保留原始來源簡報以供其他操作，請為合併開啟另一個實例。

## **將投影片合併至簡報區段**

基本的投影片複製迴圈不會重新建立來源簡報的區段層級。若輸出需要保留區段，請在目標簡報中建立或選取區段，並使用 [addClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 明確將投影片複製至該區段。

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

複製的投影片會附加至指定的目標區段。若需保留多個來源區段，請在目標簡報中重新建立這些區段，並將每張來源投影片對應至相應的目標區段。

## **安全合併多個簡報**

以下端對端範例以第一個簡報作為目標，對每個額外的來源正規化投影片尺寸，僅在複製期間開啟來源，並在最後一次儲存檔案。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

這是保留匯入投影片來源格式的實用基礎。如果輸出必須使用單一目標主題，請將簡單的 `addClone(slide)` 呼叫換成先前示範的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式保真度**

預設的投影片複製會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會為自動複製的母片維護內部註冊表，以避免重複複製同一母片。手動複製的母片不會被此註冊表追蹤，除非需要明確控制母片結構，否則請避免事先複製母片。

不要認為名稱相同的兩個母片或版面配置在視覺上等同。若企業模板必須控制最終外觀，請明確選擇目標母片或版面配置，並在合併後驗證結果。

### **備註與評論**

演講者備註與投影片評論與投影片內容相關聯，會在投影片被複製時一起複製。Aspose.Slides 亦提供專門的 API 用於 [簡報備註](https://docs.aspose.com/slides/zh-hant/androidjava/presentation-notes/) 與 [簡報評論](https://docs.aspose.com/slides/zh-hant/androidjava/presentation-comments/)。

若備註頁面的格式很重要，請驗證合併後的簡報，因為備註母片是簡報層級的物件，可能在來源檔案之間有所差異。對於審閱流程，也請在合併來自不同作者或模板的檔案後，驗證評論作者與串列評論。

### **圖片、音訊、視訊、OLE 物件與外部連結**

投影片可能引用簡報層級的資源，如圖片、嵌入式音訊、嵌入式視訊與 OLE 資料。請複製整張投影片，而非僅複製可見的圖形，讓 Aspose.Slides 能維持投影片與其資源的關聯。

嵌入式與連結式資源的處理方式應不同。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；複製投影片不會將外部連結轉為嵌入內容。請在最終開啟合併簡報的環境中測試連結資源的路徑與 URL。

Aspose.Slides 會追蹤自動複製的母片，但不應視為對不相關來源簡報之相同二進位資源一定會被去除重複的保證。若文件大小重要，請檢查合併後的套件並自行測量結果，而非依賴隱式的去重機制。

### **嵌入字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器間保持一致，請勿僅依賴投影片複製就假設所有必要字型已在目標環境中可用。您可以使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 檢查嵌入字型，並依照 [在簡報中嵌入字型](https://docs.aspose.com/slides/zh-hant/androidjava/embedded-font/) 的說明明確管理嵌入。

同時也要確認您有權利嵌入來源檔案所使用的字型。字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源，才能複製其投影片。請透過 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 提供密碼。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 在已解密的簡報上進行操作。
} finally {
    source.dispose();
}
```

開啟加密來源不會自動將相同保護套用到目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度圖片、音訊、視訊或其他大型二進位物件的簡報會消耗大量記憶體。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 提供 BLOB 處理與暫存檔使用的控制。請參考 [管理簡報 BLOB](https://docs.aspose.com/slides/zh-hant/androidjava/manage-blob/) 以取得大型檔案的最佳做法。

對於大型檔案，盡可能使用檔案路徑載入，於合併完成後立即釋放每個來源簡報，且除非工作流程需要檢查點，否則避免多次儲存中間結果。

### **執行緒安全性**

請勿在多執行緒同時載入、修改、儲存或複製同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。每個簡報實例應僅用於單一合併作業。若平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides 多執行緒指引](https://docs.aspose.com/slides/zh-hant/androidjava/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用 [`addClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，不要提供目標母片或版面配置。Aspose.Slides 會在需要時自動複製來源母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入目標簡報的母片，而非來源母片。Aspose.Slides 會嘗試將每張來源投影片對應至該母片下的適當版面配置。

**何時應使用特定的目標版面配置而非目標母片？**

當每張匯入的投影片都必須使用同一已知版面配置時使用版面配置；當希望 Aspose.Slides 依據來源版面類型或名稱在該母片的版面中自動選擇時，使用母片。

**不同投影片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動重新設計以符合目標尺寸。若需要可預測的版面，請先使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) 與 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成同一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一目標簡報，並以支援的輸出格式儲存。由於簡報格式的功能集合不完全相同，請在跨格式合併後驗證複雜內容。請參閱 [支援的檔案格式](https://docs.aspose.com/slides/zh-hant/androidjava/supported-file-formats/)。

**來源區段會自動保留嗎？**

基本只複製投影片的迴圈不會保留區段。若需要保留區段結構，請在目標簡報重新建立必要的區段，並使用 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 的區段重載。

**演講者備註與評論會被保留嗎？**

它們會隨複製的投影片一起被複製。對於依賴備註母片樣式、評論作者或串列審閱資料的工作流程，請驗證合併結果，因為這些情境涉及簡報層級結構與投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

嵌入式內容會隨複製的投影片資源關聯一起帶入。外部連結仍保持外部狀態，合併後其目標檔案或 URL 必須仍然可用。

**所有來源的嵌入字型是否都會在合併簡報中可用？**

不要僅依賴投影片複製來部署字型。請檢查目標簡報的嵌入字型，並在排版重要時明確管理字型嵌入或外部字型的可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 開啟檔案，然後正常複製投影片。輸出保護需另行設定。

**如何處理非常大的簡報？**

在大型二進位物件佔用記憶體的情況下使用 BLOB 管理，對於極大檔案盡量使用檔案路徑載入，及時釋放來源簡報，且僅在必要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**

請勿在多執行緒同時使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。每個合併作業應使用獨立的簡報實例。