---
title: 有效使用 Python 合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "了解如何在 Python 中透過克隆投影片、控制母片與版面配置、調整投影片內容大小、保留節，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for Python via .NET 透過從一個[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 克隆投影片合併簡報到另一個簡報。主要操作是[SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)，它可以保留來源投影片的格式，或將克隆的投影片附加到目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片，同時保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報的母片；
- 套用目標簡報的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將克隆的投影片加入節；
- 在單一端到端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案以及多執行緒相關問題。

## **投影片克隆對母片與版面配置的影響**

投影片的大部分外觀皆繼承自其版面配置與母片。因此，您選擇的克隆重載決定合併後的投影片如何整合至目標簡報。

使用[SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)的以下方式之一：

- `add_clone(source_slide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動克隆至目標簡報。Aspose.Slides 會自動追蹤已克隆的母片，以免同一母片的多張投影片重複克隆。
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — 將克隆的投影片附加至指定的目標[IMasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/)。Aspose.Slides 會根據版面類型或名稱在該母片下尋找相符的版面配置。
- `add_clone(source_slide, destination_layout)` — 將克隆的投影片直接附加至指定的目標[ILayoutSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilayoutslide/)。

傳遞給 `add_clone` 重載的母片或版面配置必須屬於**目標**簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製到目標簡報。當匯入的投影片應保留其原始主題、母片與版面配置關係時，這是合適的選擇。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

如果來源與目標使用不同設計，產生的簡報可能包含多個母片。這在有意保留來源格式時是預期行為。

## **合併選取的投影片**

您不必克隆每一張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

在克隆前，請驗證投影片索引是否正確，特別是當這些索引來自使用者輸入或外部設定時。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已屬於目標簡報的母片時，使用[add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)重載。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides 會依照來源版面配置的類型或名稱，在指定的母片下選擇適當的版面配置。如果不存在相容的版面配置且 `allow_clone_missing_layout` 為 `True`，則會克隆來源版面配置以便加入投影片。若為 `False`，則拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。

當您希望合併失敗，而不是在目標母片中新增版面配置時，請使用 `False`。

## **使用特定目標版面配置合併投影片**

當您確切知道匯入的投影片應使用哪個目標版面配置時，使用[add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)重載。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

套用目標版面配置會變更繼承的版面關係；它並不會重新設計來源投影片的內容。如果來源與目標版面配置的佔位物結構不同，請檢查結果以確認繼承的格式與佔位物行為是否符合預期。

## **合併不同投影片尺寸的簡報**

尺寸不同的簡報仍可合併，但將投影片克隆至具有不同投影片尺寸的簡報時，內容不會自動重新設計以符合新畫布。形狀可能因此出現位置偏移、比例異常，甚至位於可見投影片區域之外。

實務上，可在克隆前調整來源簡報的尺寸。[SlideSize.set_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/set_size/) 方法可在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定尺寸。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報以供其他操作，請為合併開啟另一個實例。

## **將投影片合併至簡報的節**

基本的投影片克隆迴圈不會重建來源簡報的節層級。如果輸出結果需要保留節，請在目標簡報中建立或選取節，並使用[SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)明確將投影片克隆至該節。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

克隆的投影片會附加至指定的目標節。若要保留多個來源節，請列舉[Presentation.sections](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sections/)，使用[Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/get_slides_list_of_section/)取得每個來源節的投影片清單，於目標簡報中重新建立相同節，然後將各投影片克隆至對應的目標節。完整的節列舉範例（包括空節與結構變更）請參閱[管理投影片節](/slides/zh-hant/python-net/slide-section/)。

## **安全合併多個簡報**

以下端到端範例將第一個簡報作為目標，對每個額外來源的投影片尺寸進行正規化，僅在複製期間開啟來源簡報，最後一次儲存檔案。

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

這是保留匯入投影片來源格式的實用基線。如果您的輸出必須使用單一目標主題，請將簡單的 `add_clone(slide)` 呼叫替換為前面示範的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式保真度**

預設的投影片克隆會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會為自動克隆的母片維護內部註冊表，以避免重複克隆同一母片。手動克隆的母片不會被該註冊表追蹤，因此除非需要明確控制母片結構，否則請避免預先克隆母片。

不要假設名稱相同的兩個母片或版面配置在視覺上等價。如公司模板必須控制最終外觀，請明確選擇目標母片或版面配置，並在合併後驗證結果。

### **備註與評論**

講者備註與投影片評論與投影片內容相關聯，克隆投影片時會一併複製。Aspose.Slides 亦提供專用的 API 供[簡報備註](/slides/zh-hant/python-net/presentation-notes/)與[簡報評論](/slides/zh-hant/python-net/presentation-comments/)使用。

如果備註頁的格式很重要，請驗證合併後的簡報，因為備註母片屬於簡報層級的物件，可能在來源檔案之間有所差異。對於審閱工作流程，也請在合併不同作者或模板的檔案後，驗證評論作者與串接評論。

### **影像、音訊、視訊、OLE 物件與外部連結**

投影片可能會參照簡報層級的資源，例如影像、內嵌音訊、內嵌視訊與 OLE 資料。請克隆整張投影片，而非僅複製可見的圖形，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結的資源應分別處理。連結的音訊、視訊、OLE 物件或超連結仍然依賴其外部目標；克隆投影片不會將外部連結轉為內嵌內容。請在最終開啟合併簡報的環境中測試連結路徑與 URL。

Aspose.Slides 雖然會追蹤自動克隆的母片，但不應將此視為對於不相關來源簡報的相同二進位資源一定會去除重複的通用保證。若檔案大小是關鍵，請檢視合併後的套件並測量結果，而不是依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，請勿僅假設克隆投影片就能保證目的環境中所有必需字型皆可用。您可以使用[FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)檢查內嵌字型，並依照[在簡報中嵌入字型](/slides/zh-hant/python-net/embedded-font/)的說明明確管理嵌入。

同時也請確認您有權限嵌入來源檔案所使用的字型。字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源，才能克隆其投影片。請透過[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 提供密碼。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

開啟加密的來源並不會自動將相同保護套用至目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、視訊或其他大型二進位物件的簡報可能會佔用大量記憶體。[LoadOptions.blob_management_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/blob_management_options/) 提供 BLOB 處理與暫存檔使用的控制。請參考[管理簡報 BLOB](/slides/zh-hant/python-net/manage-blob/)以取得大型檔案的策略。

對於大型檔案，盡可能以檔案路徑載入，於合併完成後立即關閉每個來源簡報，並避免重複儲存中間結果，除非工作流程需要檢查點。使用 `with slides.Presentation(...)` 可確保在上下文離開時釋放簡報資源。

### **執行緒安全性**

請勿同時在多個執行緒中載入、儲存或克隆[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例。將每個合併作業維持在單執行緒中。如果要平行處理獨立的合併工作，請依照[Aspose.Slides 多執行緒指引](/slides/zh-hant/python-net/multithreading/)使用獨立的單執行緒行程與獨立的簡報實例。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用不提供目標母片或版面配置的[add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)。當匯入的投影片需要來源母片時，Aspose.Slides 會自動克隆該母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入目標簡報中的母片，而非來源母片。Aspose.Slides 會嘗試將每個來源投影片對映至該母片下的適當版面配置。

**什麼時候應該使用特定的目標版面配置而不是目標母片？**

當所有匯入的投影片皆應使用同一已知版面配置時，使用特定版面配置。當您希望 Aspose.Slides 依照來源版面類型或名稱在母片的版面配置中自動選擇時，使用母片。

**可以合併尺寸不同的簡報嗎？**

可以，但投影片內容不會自動針對目標尺寸重新設計。若需要可預測的版面配置，請先使用[SlideSize.set_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/set_size/)與[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/)調整來源簡報的尺寸。

**可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**

可以。載入每個來源簡報，將所需的投影片克隆至同一目標，然後以支援的輸出格式儲存。因為不同格式的功能集合不完全相同，請在跨格式合併後驗證複雜內容。參考[支援的檔案格式](/slides/zh-hant/python-net/supported-file-formats/)。

**來源的節會自動保留嗎？**

基本只克隆投影片的迴圈不會保留節。必須在目標簡報中重新建立所需的節，並使用[add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)的節重載來保留節結構。

**講者備註與評論會被保留嗎？**

會與克隆的投影片一起複製。若工作流程依賴備註母片樣式、評論作者或串接審閱資料，請在合併後驗證結果，因為這些情境涉及簡報層級結構。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

內嵌的內容會隨克隆的投影片的資源關聯一起攜帶。外部連結仍保持外部狀態，合併後仍需確保其目標檔案或 URL 可用。

**每個來源的內嵌字型是否保證在合併後的簡報中可用？**

不要僅依賴投影片克隆來部署字型。請檢查目標簡報的內嵌字型，並在排版重要時明確管理字型嵌入或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 開啟檔案，然後正常克隆其投影片。輸出保護需另行設定。

**該如何處理非常大的簡報？**

在大量二進位物件占用記憶體的情況下，使用 BLOB 管理；盡可能以檔案路徑載入，及時關閉來源簡報，並僅在必要時儲存最終結果。使用 `with slides.Presentation(...)` 可確保資源正確釋放。

**可以從多個執行緒合併投影片嗎？**

請勿在多個執行緒同時載入、儲存或克隆[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例。每個合併作業應保持單執行緒；若需平行處理獨立合併工作，請使用獨立的單執行緒程序與獨立的簡報實例。