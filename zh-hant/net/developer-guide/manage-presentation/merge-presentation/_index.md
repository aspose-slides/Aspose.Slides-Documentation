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
- 結合 PowerPoint
- 結合簡報
- 結合投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中透過複製投影片、控制母片與版面配置、調整投影片內容大小、保留節並處理受保護或大型檔案，以合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概觀**

Aspose.Slides for .NET 透過從一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 複製投影片並合併簡報至另一個。主要的操作是 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/)，它可以保留來源投影片的格式，或將複製的投影片附加至目的簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片並保留來源格式；
- 合併選取的投影片；
- 套用目的簡報的母片；
- 套用目的簡報的特定版面配置；
- 在合併前標準化不同的投影片尺寸；
- 將複製的投影片加入節；
- 在一次端對端的工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案及多執行緒相關問題。

## **投影片複製如何影響母片與版面配置**

投影片的大部分外觀繼承自其版面配置與母片。因此，您選擇的複製重載決定了合併後的投影片如何整合到目的簡報中。

使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 可採取下列方式：

- `AddClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製到目的簡報。Aspose.Slides 會追蹤自動複製的母片，避免重複使用相同來源母片的投影片時再次複製該母片。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加到特定的目的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/)。Aspose.Slides 會根據版面配置類型或名稱在該母片下尋找相符的版面配置。
- `AddClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加到特定的目的 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/)。

傳遞給 `AddClone` 重載的母片或版面配置必須屬於 **目的** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製到目的簡報。當匯入的投影片需要保留原始主題、母片與版面配置關係時，這是適合的選擇。

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

如果來源與目的使用不同的設計，產生的簡報可能會包含多個母片。這是因為有意保留來源格式時的正常情況。

## **合併選取的投影片**

您不必複製每張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

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

在從使用者輸入或外部設定取得索引時，請先驗證投影片索引的有效性。

## **使用目的母片合併投影片**

當匯入的投影片應遵循已屬於目的簡報的母片時，使用 [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 重載。

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

Aspose.Slides 會根據來源版面配置的類型或名稱，在指定的母片下選取適當的版面配置。若不存在相符的版面配置且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面配置以便加入投影片；若為 `false`，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。

如果您希望合併失敗而不是在目的母片中新增版面配置，請使用 `false`。

## **使用特定目的版面配置合併投影片**

當您明確知道匯入的投影片應使用哪個目的版面配置時，使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 重載。

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

套用目的版面配置會改變繼承的版面配置關係，但不會重新設計來源投影片內容。若來源與目的版面配置的占位結構不同，請檢查結果，以確認繼承的格式與占位行為是否符合預期。

## **合併尺寸不同的簡報**

尺寸不同的簡報可以合併，但將投影片複製到尺寸不同的簡報時，內容不會自動為新畫布重新設計。形狀可能會出現位移、意外縮放，或超出可見投影片範圍。

實用的作法是先調整來源簡報的尺寸後再進行複製。[SlideSize.SetSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesize/setsize/) 方法可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/) 會將內容縮放以符合目標尺寸。

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

調整尺寸會在記憶體中變更來源簡報物件。若您在其他作業中仍需保留原始來源簡報，請為合併開啟單獨的實例。

## **將投影片合併至簡報節**

基本的投影片複製迴圈不會重建來源簡報的節層級。若輸出需要保留節結構，請在目的簡報中建立或選取節，並使用 [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 明確將投影片複製至該節。

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

複製的投影片會附加至指定的目的節。若要保留多個來源節，請列舉 [Presentation.Sections](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sections/)，以 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/getslideslistofsection/) 取得每個來源節的投影片清單，於目的簡報重新建立相同節，然後將取得的投影片逐一複製至對應的目的節。完整的節列舉範例（含空節與結構變更）請參閱 [Manage Slide Sections](/slides/zh-hant/net/slide-section/)。

## **安全地合併多個簡報**

以下端對端範例將第一個簡報作為目的，對每個後續來源正規化投影片尺寸，僅在複製期間保持來源開啟，最後一次儲存完整檔案。

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

這是一個保留匯入投影片來源格式的實用基礎。如果您的輸出必須使用單一目的主題，請將簡單的 `AddClone(slide)` 呼叫取代為前述的目的母片或目的版面配置重載。

## **實務考量**

### **母片、版面配置與格式保真度**

預設的投影片複製會自動將必要的來源母片帶入目的簡報。Aspose.Slides 會在內部註冊自動複製的母片，以避免重複複製同一母片。手動預先複製的母片不會被此登錄追蹤，除非您需要對母片結構進行明確控制，否則請避免提前複製母片。

不要假設名稱相同的兩個母片或版面配置在視覺上等同。若企業範本必須掌控最終外觀，請明確選擇目的母片或版面配置，並在合併後驗證結果。

### **備註與評論**

投影片說明與評論與投影片內容相關聯，複製投影片時會同步複製。Aspose.Slides 亦提供專屬 API 供 [presentation notes](/slides/zh-hant/net/presentation-notes/) 與 [presentation comments](/slides/zh-hant/net/presentation-comments/) 使用。

如果備註頁面的格式很重要，請驗證合併後的簡報，因為備註母片屬於簡報層級物件，可能在不同來源檔案之間有所差異。對於審閱流程，亦須在合併不同作者或範本的檔案後，驗證評論作者與緒線評論。

### **圖片、音訊、視訊、OLE 物件與外部連結**

投影片可以參照簡報層級的資源，例如圖片、內嵌音訊、內嵌視訊與 OLE 資料。請複製整張投影片，而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結資源應分別處理。連結的音訊、視訊、OLE 物件或超連結仍然依賴外部目標；複製投影片不會將外部連結轉為內嵌內容。請在最終開啟簡報的環境中測試連結資源的路徑與 URL。

Aspose.Slides 明確追蹤自動複製的母片，但這不代表對於不相關來源簡報中相同的二進位資源一定會自動去重。如需控制輸出檔案大小，請檢查合併後的套件並自行測量結果，而非依賴隱式去重。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，請不要僅依賴投影片複製就假設所有必要字型已在目的環境中可用。您可以使用 [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts/) 檢查內嵌字型，並依照 [Embed Fonts in Presentations](/slides/zh-hant/net/embedded-font/) 的說明明確管理字型內嵌。

此外，請確認您有權限內嵌來源檔案所使用的字型。字型授權可能限制內嵌行為。

### **受密碼保護的簡報**

受密碼保護的來源必須先成功開啟，才能複製其投影片。請透過 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 提供密碼。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

開啟加密來源不會自動將相同保護套用至目的簡報。若需保護輸出，請另行設定。

### **大型簡報與記憶體使用量**

包含高解析度圖片、音訊、視訊或其他大型二進位物件的簡報會占用大量記憶體。[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/blobmanagementoptions/) 提供 BLOB 處理與暫存檔使用的控制。大型檔案的策略請參考 [Manage Presentation BLOBs](/slides/zh-hant/net/manage-blob/)。

對於大型檔案，盡可能使用檔案路徑載入，合併完成後立即釋放每個來源簡報，除非工作流程需要檢查點，否則避免反覆儲存中間結果。

### **執行緒安全性**

請勿在多個執行緒中同時載入、修改、儲存或複製同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。每個簡報實例應僅限於單一合併作業。若平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides multithreading guidance](/slides/zh-hant/net/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用不提供目的母片或版面配置的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/)。Aspose.Slides 會在需要時自動複製來源母片。

**如何讓匯入的投影片使用目的主題？**

使用接受目的母片的重載。傳入目的簡報的母片，而非來源母片。Aspose.Slides 會嘗試將每個來源投影片對映至該母片下的適當版面配置。

**何時應使用特定的目的版面配置，而非目的母片？**

當所有匯入的投影片必須使用同一已知版面配置時，使用特定版面配置。若希望 Aspose.Slides 依據來源版面配置的類型或名稱在該母片的版面配置中自動選取，則使用母片。

**可以合併尺寸不同的簡報嗎？**

可以，但投影片內容不會自動為目的尺寸重新設計。如需可預測的布局，請先使用 [SlideSize.SetSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesize/setsize/) 及 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/) 調整來源簡報。

**可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一目的簡報，並以支援的輸出格式儲存。因為不同格式的簡報功能集可能不完全相同，跨格式合併後請驗證複雜內容。參考 [Supported File Formats](/slides/zh-hant/net/supported-file-formats/)。

**來源節會自動保留嗎？**

基本的僅複製投影片的迴圈不會保留節。若需保留節結構，請在目的簡報中重新建立相應節，並使用 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 的節重載。

**說明與評論會被保留嗎？**

會隨複製的投影片一起複製。對於依賴說明母片樣式、評論作者或緒線審閱資料的工作流程，請驗證合併結果，因為這些情境涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

內嵌的內容會隨複製的投影片資源關係一起帶入。外部連結仍保持外部狀態，必須在合併後仍能存取其目標檔案或 URL。

**所有來源的內嵌字型是否保證在合併後可用？**

不要僅依賴投影片複製來部署字型。請檢查目的簡報的內嵌字型，並在排版重要時明確管理字型內嵌或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 開啟檔案，然後照常複製投影片。輸出保護需另行設定。

**如何處理非常大的簡報？**

當大型二進位物件佔用大量記憶體時，使用 BLOB 管理；盡可能以檔案路徑載入大型檔案；在完成合併後立即釋放來源簡報；僅在需要時儲存最終結果。

**可以從多個執行緒合併投影片嗎？**

請勿在多個執行緒中同時使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。每個合併作業應使用獨立的簡報實例。