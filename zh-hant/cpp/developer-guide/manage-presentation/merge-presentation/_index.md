---
title: 高效在 C++ 中合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/cpp/merge-presentation/
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
- C++
- Aspose.Slides
description: "了解如何在 C++ 中透過複製投影片、控制母片與版面配置、調整投影片內容大小、保留節以及處理受保護或大型檔案，合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for C++ 透過從一個[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 複製投影片至另一個投影片來合併簡報。主要的操作是[ISlideCollection::AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/)，它可以保留來源投影片的格式，或將複製的投影片附加至目標簡報中的母片或版面配置。

此文章涵蓋最常見的合併工作流程：

- 合併所有投影片同時保留其來源格式；
- 合併選取的投影片；
- 使用目標簡報的母片；
- 使用目標簡報的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將複製的投影片加入節；
- 在一個端對端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案及多執行緒相關問題。

## **投影片複製對母片與版面配置的影響**

投影片的大部分外觀繼承自其版面配置與母片。因此，您選擇的複製重載決定了合併投影片在目標簡報中的整合方式。

使用[ISlideCollection::AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/)的以下方式：

- `AddClone(sourceSlide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動複製至目標簡報。Aspose.Slides 會追蹤自動複製的母片，以免相同來源母片的多個投影片被重複複製。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 將複製的投影片附加至特定的目標[IMasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/)。Aspose.Slides 會根據版面配置類型或名稱在該母片下尋找相符的版面配置。
- `AddClone(sourceSlide, destinationLayout)` — 直接將複製的投影片附加至特定的目標[ILayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/)。

傳遞給 `AddClone` 重載的母片或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每張投影片複製至目標簡報。當匯入的投影片應保留其原始主題、母片與版面配置關係時，這是合適的選擇。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

當來源與目標使用不同的設計時，結果簡報可能包含多個母片。這是在有意保留來源格式時的預期行為。

## **合併選取的投影片**

您不必複製每張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

在從使用者輸入或外部設定取得投影片索引時，請先驗證索引的正確性。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已屬於目標簡報的母片時，請使用[AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 重載。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides 會根據來源版面配置的類型或名稱，在指定的母片下選擇適當的版面配置。若不存在相符的版面配置且 `allowCloneMissingLayout` 為 `true`，則會複製來源版面配置以便加入投影片。若為 `false`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/details_pptxeditexception/)。

在您希望合併失敗而非在目標母片中新增版面配置時，請使用 `false`。

## **使用特定目標版面配置合併投影片**

當您明確知道匯入的投影片應使用哪個目標版面配置時，請使用[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 重載。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

套用目標版面配置會改變繼承的版面配置關係；它不會重新設計來源投影片的內容。若來源與目標版面配置的佔位元件結構不同，請檢查結果以確認繼承的格式與佔位元件行為是否符合預期。

## **合併具有不同投影片尺寸的簡報**

尺寸不同的簡報可以合併，但將投影片複製至尺寸不同的簡報時，內容不會自動重新設計以符合新畫布。因此，形狀可能會出現移位、意外縮放，或超出可見投影片區域。

實務上可先在複製前調整來源簡報的尺寸。[SlideSize::SetSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesize/setsize/) 方法可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定尺寸。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

調整尺寸會在記憶體中變更來源簡報物件。若您需要在其他操作中保持來源簡報原始不變，請為合併開啟另一個實例。

## **將投影片合併至簡報節**

基本的投影片複製迴圈不會重新建立來源簡報的節層級。若輸出結果需要保留節，請在目標簡報中建立或選取節，並使用[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 明確將投影片複製至該節。

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

複製的投影片會附加至指定的目標節。若要保留多個來源節，請在目標簡報中重新建立這些節，並將每個來源投影片對應至相應的目標節。

## **安全合併多個簡報**

以下端對端範例將第一個簡報作為目標，對每個額外的來源正規化投影片尺寸，僅在複製時開啟來源，最後一次儲存檔案。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

這是一個保留匯入投影片來源格式的實用基礎。如果您的輸出必須使用單一目標主題，請將簡單的 `AddClone(slide)` 呼叫替換為先前說明的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片複製會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會為自動複製的母片維護內部登錄，以避免重複複製相同母片。手動複製的母片不會被該登錄追蹤，因此除非需要對母片結構進行明確控制，否則請避免預先複製母片。

不要假設名稱相同的兩個母片或版面配置在視覺上等同。如果企業範本必須控制最終外觀，請明確選擇目標母片或版面配置，並在合併後驗證結果。

### **備註與評論**

講者備註與投影片評論與投影片內容相關聯，且在投影片被複製時會一併複製。Aspose.Slides 亦提供專門的 API 供[簡報備註](https://docs.aspose.com/slides/zh-hant/cpp/presentation-notes/)與[簡報評論](https://docs.aspose.com/slides/zh-hant/cpp/presentation-comments/)使用。

若備註頁的格式很重要，請驗證合併後的簡報，因為備註母片是簡報層級的物件，可能在來源檔案間有所差異。對於審閱工作流程，亦請在合併不同作者或範本的檔案後驗證評論作者與線索評論。

### **圖像、音訊、視訊、OLE 物件與外部連結**

投影片可能參照簡報層級的資源，例如圖像、內嵌音訊、內嵌視訊與 OLE 資料。請複製整張投影片，而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結的資源應分別處理。連結的音訊、視訊、OLE 物件或超連結仍依賴其外部目標；複製投影片不會將外部連結轉為內嵌內容。請在合併後的環境中測試連結資源的路徑與 URL。

Aspose.Slides 明確追蹤自動複製的母片，但這不應被視為來自不相關來源簡報的相同二進位資源一定會被去除重複的通用保證。若檔案大小重要，請檢查合併後的套件並測量結果，而非依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型於簡報層級管理。若排版必須在不同機器上保持一致，請勿假設僅複製投影片即可保證所需字型在目標環境中可用。您可以使用[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 檢查內嵌字型，並依照[在簡報中嵌入字型](https://docs.aspose.com/slides/zh-hant/cpp/embedded-font/) 的說明明確管理字型嵌入。

同時請確認您有權限嵌入來源檔案所使用的字型。字型授權可能限制嵌入。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源簡報，才能複製其投影片。請透過[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 提供密碼。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

開啟加密的來源不會自動將相同的保護套用至目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度圖像、音訊、視訊或其他大型二進位物件的大型簡報可能消耗大量記憶體。[LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) 提供 BLOB 處理與暫存檔使用的控制。請參閱[管理簡報 BLOB](https://docs.aspose.com/slides/zh-hant/cpp/manage-blob/) 取得大型檔案的策略。

對於大型檔案，優先使用檔案路徑載入，盡快釋放已合併的來源簡報，除非工作流程需要檢查點，否則避免重複儲存中間結果。

### **執行緒安全性**

請勿同時從多個執行緒載入、修改、儲存或複製同一個[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)實例。將每個簡報實例限制在單一合併操作中。若平行處理獨立工作，請使用獨立的簡報實例，並遵循[Aspose.Slides 多執行緒指南](https://docs.aspose.com/slides/zh-hant/cpp/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用[`AddClone(sourceSlide)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/)，且不提供目標母片或版面配置。Aspose.Slides 會在匯入的投影片需要時自動複製來源母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入目標簡報的母片，而非來源的母片。Aspose.Slides 會嘗試將每個來源投影片映射至該母片下的適當版面配置。

**什麼時候應該使用特定的目標版面配置而非目標母片？**

當每張匯入的投影片皆應使用已知的單一版面配置時，請使用特定版面配置。當您希望 Aspose.Slides 依據來源版面配置的類型或名稱在該母片的版面配置中挑選時，請使用母片。

**可以合併不同投影片尺寸的簡報嗎？**

可以，但投影片內容不會自動為目標尺寸重新設計。若需要預測的版面配置，請先使用[SlideSize::SetSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesize/setsize/) 以及 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併為同一檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一目標，並以支援的輸出格式儲存。因為簡報格式的功能集不完全相同，請在跨格式合併後驗證複雜內容。請參閱[支援的檔案格式](https://docs.aspose.com/slides/zh-hant/cpp/supported-file-formats/)。

**來源節會自動保留嗎？**

基本僅複製投影片的迴圈不會保留。若必須保留節結構，請在目標中重新建立所需節，並使用[AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 的節重載。

**講者備註與評論會被保留嗎？**

它們會隨複製的投影片一起複製。對於依賴備註母片樣式、評論作者或線索審閱資料的工作流程，請驗證合併結果，因為這些情況涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

內嵌內容會隨複製的投影片的資源關聯一併保留。外部連結仍保持外部，合併後仍需確保其目標檔案或 URL 可用。

**是否保證所有來源的內嵌字型都會在合併簡報中可用？**

不要僅依賴投影片複製來部署字型。請檢查目標的內嵌字型，並在排版重要時明確管理字型嵌入或外部字型的可用性。

**如何合併受密碼保護的檔案？**

使用正確的[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 開啟檔案，然後正常複製投影片。輸出保護需另行設定。

**該如何處理非常大型的簡報？**

在大型二進位物件佔用記憶體的情況下使用 BLOB 管理，對於極大檔案優先以檔案路徑載入，及時釋放來源簡報，且僅在必要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**

請勿對同一個[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)實例同時使用多執行緒。將每個合併作業限制在各自的簡報實例中。