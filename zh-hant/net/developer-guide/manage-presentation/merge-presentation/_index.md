---
title: 在 .NET 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/net/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併簡報
- 合併投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 整合 PowerPoint
- 整合簡報
- 整合投影片
- 整合 PPT
- 整合 PPTX
- 整合 ODP
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中透過複製投影片、控制母片與版面配置、調整投影片內容大小、保留區段，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概觀**

Aspose.Slides for .NET 透過從一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 複製投影片至另一個投影片，來合併簡報。主要的操作是 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/)，它可以保留來源投影片的格式，或將複製的投影片附加至目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片，同時保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報的母片；
- 套用目標簡報的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將複製的投影片加入區段；
- 在單一端對端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案以及多執行緒相關問題。

## **投影片複製對母片與版面配置的影響**

投影片的大部分外觀來自於其版面配置與母片。因此，您選擇的複製重載方式會決定合併後的投影片如何整合到目標簡報中。

可使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 以以下任一方式：

- `AddClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製到目標簡報。Aspose.Slides 會追蹤自動複製的母片，以免多次使用相同來源母片的投影片重複複製母片。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加至特定的目標 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找相符的版面配置。
- `AddClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加至特定的目標 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/)。

傳遞給 `AddClone` 重載的母片或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併完整簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片全部複製至目標簡報。當匯入的投影片需要保留原始佈景主題、母片與版面配置關係時，這是適當的選擇。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

若來源與目標使用不同的設計，產生的簡報可能會包含多個母片。這在刻意保留來源格式時屬於預期行為。

## **合併選取的投影片**

您不需要複製每張投影片。以下範例僅匯入來源簡報中選取的投影片索引。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

在從使用者輸入或外部設定取得投影片索引時，請先驗證索引的有效性再進行複製。

## **使用目標母片合併投影片**

當匯入的投影片應使用已屬於目標簡報的母片時，請使用 [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 重載。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides 會依來源版面配置的類型或名稱，在指定的母片下尋找相符的版面配置。若不存在合適的版面且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面以加入投影片。若為 `false`，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。

若希望合併失敗而非在目標母片中新增版面，請使用 `false`。

## **使用特定目標版面配置合併投影片**

當您確切知道匯入的投影片應使用哪個目標版面配置時，請使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 重載。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

套用目標版面配置會變更繼承的版面關係；但不會重新設計來源投影片的內容。若來源與目標版面配置的佔位元件結構不同，請檢查結果，以確認繼承的格式與佔位元件行為是否正確。

## **合併不同投影片尺寸的簡報**

不同尺寸的簡報可以合併，但將投影片複製至尺寸不同的簡報時，內容不會自動重新設計以適應新的畫布。因此圖形可能會出現偏移、意外縮放，或位於可見投影片範圍之外。

實務上可在複製前先調整來源簡報的尺寸。使用 [SlideSize.SetSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesize/setsize/) 方法在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/) 可將內容縮放以符合指定大小。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

調整大小會在記憶體中變更來源簡報物件。如果需要保留原始來源簡報以供其他操作，請為合併開啟另一個實例。

## **將投影片合併至簡報區段**

基本的投影片複製迴圈不會重建來源簡報的區段層級。若輸出結果需要保留區段，請在目標簡報中建立或選取區段，並使用 [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 明確將投影片複製至該區段。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

複製的投影片會被附加至指定的目標區段。若要保留多個來源區段，請在目標中重新建立這些區段，並將每張來源投影片對映至相對應的目標區段。

## **安全地合併多個簡報**

以下端對端範例將第一個簡報作為目標，對每個後續來源的投影片尺寸進行正規化，只在複製期間保持來源開啟，最後一次儲存最終檔案。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

此範例可作為保留匯入投影片來源格式的基礎。如果輸出必須使用單一目標主題，請將簡單的 `AddClone(slide)` 呼叫取代為前述的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片複製會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會維護一個內部註冊表，追蹤自動複製的母片，以避免重複複製相同的母片。手動複製的母片不會被此註冊表追蹤，因此除非您需要對母片結構進行明確控制，否則避免事先複製母片。

不要假設名稱相同的兩個母片或版面配置在視覺上是等效的。如需企業範本控制最終外觀，請明確選擇目標母片或版面配置，並在合併後檢查結果。

### **備註與評論**

演講者備註與投影片評論與投影片內容相關聯，會在投影片複製時一起複製。Aspose.Slides 亦提供專用 API 針對 [presentation notes](https://docs.aspose.com/slides/zh-hant/net/presentation-notes/) 與 [presentation comments](https://docs.aspose.com/slides/zh-hant/net/presentation-comments/)。

如果備註頁面的格式很重要，請驗證合併後的簡報，因為備註母片是簡報層級的物件，可能在來源檔案間不同。對於審閱工作流程，也需在合併來自不同作者或範本的檔案後，驗證評論作者與串聯評論。

### **影像、音訊、視訊、OLE 物件與外部連結**

投影片可以參照簡報層級的資源，如影像、內嵌音訊、內嵌視訊與 OLE 資料。請複製整個投影片，而非僅複製可見的圖形，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌資源與連結資源應分別處理。連結的音訊、視訊、OLE 物件或超連結仍依賴其外部目標；複製投影片不會將外部連結轉換為內嵌內容。請在最終開啟合併簡報的環境中測試連結資源的路徑與 URL。

Aspose.Slides 明確追蹤自動複製的母片，但這不應視為對來自不同來源簡報之相同二進位資源必定會去除重複的保證。若檔案大小重要，請檢查合併後的封裝檔並測量結果，而非依賴隱含的去重功能。

### **內嵌字型與字型可用性**

字型在簡報層級管理。如果排版必須在不同機器上保持一致，請勿假設僅複製投影片就能保證所有必要字型在目標環境中可用。您可使用 [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts/) 檢查內嵌字型，並依照 [Embed Fonts in Presentations](https://docs.aspose.com/slides/zh-hant/net/embedded-font/) 中的說明明確管理字型內嵌。

同時確認您有權限內嵌來源檔案所使用的字型。字型授權可能限制內嵌。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源簡報，才能複製其投影片。請透過 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 提供密碼。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

開啟加密的來源簡報不會自動對目標簡報套用相同的保護。若需要，請另外設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、視訊或其他大型二進位物件的大型簡報會佔用大量記憶體。[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/blobmanagementoptions/) 提供 BLOB 處理與暫存檔使用的控制項。請參考 [Manage Presentation BLOBs](https://docs.aspose.com/slides/zh-hant/net/manage-blob/) 瞭解大型檔案策略。

對於大型檔案，盡可能從檔案路徑載入，合併完畢即釋放每個來源簡報，且除非工作流程需要檢查點，否則避免多次儲存中間結果。

### **執行緒安全性**

請勿同時從多個執行緒載入、修改、儲存或複製同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。將每個簡報實例限制在單一合併操作中。若平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/zh-hant/net/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用 [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 且不提供目標母片或版面配置。當匯入的投影片需要來源母片時，Aspose.Slides 會自動複製該母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入來自目標簡報的母片，而非來源簡報。Aspose.Slides 會嘗試將每張來源投影片對映至該母片下的適當版面配置。

**什麼時候應該使用特定目標版面配置而非目標母片？**

若每張匯入的投影片皆應使用已知的單一版面配置，請使用特定版面配置。若希望 Aspose.Slides 根據來源版面類型或名稱在該母片的版面中自動挑選，則使用母片。

**不同投影片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動重新設計以符合目標尺寸。若需要可預測的版面，請先調整來源簡報，例如使用 [SlideSize.SetSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesize/setsize/) 與 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/)。

**我可以將 PPT、PPTX 與 ODP 簡報合併為一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一個目標簡報，然後以支援的輸出格式儲存。由於不同的簡報格式支援的功能集合不完全相同，交叉格式合併後請驗證複雜內容。請參考 [Supported File Formats](https://docs.aspose.com/slides/zh-hant/net/supported-file-formats/)。

**來源區段會自動保留嗎？**

僅使用基本的投影片複製迴圈不會保留區段。若必須保留區段結構，請在目標簡報中重新建立必要的區段，並使用 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 的區段重載。

**演講者備註與評論會被保留嗎？**

它們會隨複製的投影片一起被複製。對於依賴備註母片樣式、評論作者或串聯審閱資料的工作流程，請驗證合併結果，因為這些情況涉及簡報層級結構與投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼？**

內嵌內容會隨複製的投影片資源關係一起保留。外部連結仍保持外部狀態，合併後仍需確保其目標檔案或 URL 可用。

**每個來源的內嵌字型是否保證在合併簡報中可用？**

不要僅依賴投影片複製來部署字型。當排版重要時，請檢查目標簡報的內嵌字型，並明確管理字型內嵌或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 開啟，然後照常複製其投影片。輸出保護另行設定。

**如何處理非常大的簡報？**

當大型二進位物件佔用大量記憶體時，請使用 BLOB 管理；對於極大檔案，優先使用檔案路徑載入，及時釋放來源簡報，且僅在需要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**

請勿同時在多個執行緒中使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。將每個合併操作限制於各自的簡報實例中。