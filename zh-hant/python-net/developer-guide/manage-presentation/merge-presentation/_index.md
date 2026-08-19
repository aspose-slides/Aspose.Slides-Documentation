---
title: 使用 Python 高效合併簡報
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
description: "了解如何透過克隆投影片、控制母片與版面配置、調整投影片內容大小、保留分節，並處理受保護或大型檔案，以在 Python 中合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概覽**

Aspose.Slides for Python via .NET 透過克隆幻燈片，將一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 合併到另一個簡報中。主要操作是 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)，可保留來源幻燈片的格式，或將克隆的幻燈片附加到目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有幻燈片，同時保留其來源格式；
- 合併選定的幻燈片；
- 套用來自目標簡報的母片；
- 套用目標簡報中的特定版面配置；
- 在合併前正規化不同的幻燈片尺寸；
- 將克隆的幻燈片加入到分節；
- 在單一端到端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大型檔案與多執行緒相關問題。

## **投影片克隆對母片與版面配置的影響**

投影片的大部分外觀繼承自其版面配置與母片。因此，您選擇的克隆重載決定了合併後的投影片在目標簡報中的整合方式。

使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 有以下方式：

- `add_clone(source_slide)` — 保留來源投影片的版面配置與格式。必要時，來源母片會自動被克隆到目標簡報。Aspose.Slides 會追蹤自動克隆的母片，避免重複克隆相同的母片。
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — 將克隆的投影片附加到特定的目標 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/)。Aspose.Slides 會根據版面配置類型或名稱，在該母片下尋找匹配的版面配置。
- `add_clone(source_slide, destination_layout)` — 直接將克隆的投影片附加到特定的目標 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilayoutslide/)。

傳遞給 `add_clone` 重載的母片或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製到目標簡報中。當匯入的投影片應保留原始主題、母片與版面配置關係時，這是合適的選擇。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

如果來源與目標使用不同的設計，結果簡報可能會包含多個母片。這是在有意保留來源格式時的預期行為。

## **合併選定的投影片**

您不必克隆每一張投影片。以下範例僅從來源簡報匯入選定的投影片索引。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

在克隆前務必驗證投影片索引，尤其是來自使用者輸入或外部設定時。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已屬於目標簡報的母片時，使用 [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 重載。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides 會根據來源版面配置的類型或名稱，在指定的母片下選取合適的版面配置。若不存在相符的版面配置且 `allow_clone_missing_layout` 為 `True`，則會克隆來源版面配置以加入投影片；若為 `False`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。

當您希望合併失敗而不是在目標母片中新增版面配置時，請使用 `False`。

## **使用特定目標版面配置合併投影片**

當您明確知道匯入的投影片應使用哪個目標版面配置時，使用 [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 重載。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

套用目標版面配置會改變繼承的版面配置關係；不會重新設計來源投影片的內容。若來源與目標版面配置的佔位結構不同，請檢查結果，以確認繼承的格式與佔位行為是否符合預期。

## **合併不同投影片尺寸的簡報**

尺寸不同的簡報仍可合併，但將投影片克隆到尺寸不同的簡報時，內容不會自動針對新畫布重新設計。形狀可能會出現位移、比例異常或超出可見範圍。

實務上可先在克隆前調整來源簡報的尺寸。使用 [SlideSize.set_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/set_size/) 方法在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定大小。

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

## **將投影片合併到簡報分節**

基本的投影片克隆迴圈不會重建來源簡報的分節層級。若分節在最終輸出中很重要，請在目標簡報中建立或選取分節，並使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 明確將投影片克隆到該分節。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

克隆的投影片會附加到指定的目標分節。若要保留多個來源分節，請使用 [SectionCollection.append_empty_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/append_empty_section/) 在目標中重新建立相應分節，並將每個來源投影片對應至相應的目標分節。

## **安全合併多個簡報**

以下端到端範例以第一個簡報作為目標，對每個額外來源正規化投影片尺寸，僅在複製期間開啟來源，最後一次性儲存檔案。

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

這是一個保留匯入投影片來源格式的實用基礎。若您的輸出必須使用單一目標主題，請將簡單的 `add_clone(slide)` 呼叫替換為前面示範的目標母片或目標版面配置重載。

## **實務考量**

### **母片、版面配置與格式忠實度**

預設的投影片克隆會自動將所需的來源母片帶入目標簡報。Aspose.Slides 為自動克隆的母片維持內部登錄，以避免重複克隆同一母片。手動克隆的母片不會被此登錄追蹤，因此除非需要明確控制母片結構，否則請避免事先克隆母片。

不要假設名稱相同的兩個母片或版面配置在視覺上等同。如果企業模板必須控制最終外觀，請明確選取目標母片或版面配置，並在合併後驗證結果。

### **備註與評論**

投影片備註與評論與投影片內容關聯，克隆投影片時會一起複製。Aspose.Slides 亦提供專門的 API 供 [presentation notes](https://docs.aspose.com/slides/zh-hant/python-net/presentation-notes/) 與 [presentation comments](https://docs.aspose.com/slides/zh-hant/python-net/presentation-comments/) 使用。

若備註頁的格式很重要，請驗證合併後的簡報，因為備註母片屬於簡報層級物件，可能在不同來源檔案間有所差異。對於審閱流程，亦請在合併不同作者或模板的檔案後，檢查評論作者與串討論情形。

### **圖片、音訊、影片、OLE 物件與外部連結**

投影片可能參照簡報層級的資源，如圖片、內嵌音訊、內嵌影片與 OLE 資料。請克隆整張投影片，而非僅複製可見圖形，讓 Aspose.Slides 能維持投影片與其資源的關聯。

內嵌與連結的資源應分別處理。連結的音訊、影片、OLE 物件或超連結仍依賴其外部目標；克隆投影片不會將外部連結轉為內嵌內容。請在最終開啟的環境中測試連結路徑與 URL。

Aspose.Slides 會追蹤自動克隆的母片，但這不代表來自不同來源簡報的相同二進位資源一定會自動去除重複。若輸出檔案大小是考量，請自行檢查合併後的套件並測量結果，而非依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，請勿僅依賴投影片克隆就假設所有必要字型已在目標環境可用。您可使用 [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 來檢查內嵌字型，並依照 [Embed Fonts in Presentations](https://docs.aspose.com/slides/zh-hant/python-net/embedded-font/) 中的說明明確管理內嵌。

同時請確認您有權限將來源檔案使用的字型內嵌。字型授權可能會限制內嵌。

### **受密碼保護的簡報**

必須先成功以密碼開啟受保護的來源簡報，才能克隆其投影片。請透過 [LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 提供密碼。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

開啟加密來源並不會自動將相同保護套用至目標簡報。若需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

含有高解析度圖片、音訊、影片或其他大型二進位物件的簡報會佔用大量記憶體。[LoadOptions.blob_management_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/blob_management_options/) 提供 BLOB 處理與暫存檔使用的控制。請參考 [Manage Presentation BLOBs](https://docs.aspose.com/slides/zh-hant/python-net/manage-blob/) 以取得大型檔案的策略。

對於大檔案，盡可能使用檔案路徑載入，於合併完成後立即關閉每個來源簡報，且除非工作流程需要檢查點，否則避免頻繁儲存中間結果。使用 `with slides.Presentation(...)` 可確保在離開上下文時釋放簡報資源。

### **執行緒安全性**

請勿同時在多個執行緒中載入、儲存或克隆同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。每個合併操作應保持單執行緒。若要平行處理多個獨立的合併工作，請使用獨立的單執行緒行程與獨立的簡報實例，詳情請參閱 [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/zh-hant/python-net/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用 [`add_clone(source_slide)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 並且不提供目標母片或版面配置。Aspose.Slides 會在需要時自動克隆來源母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的重載。傳入目標簡報的母片，而非來源母片。Aspose.Slides 會嘗試將每個來源投影片映射至該母片下的適當版面配置。

**什麼時候應使用特定的目標版面配置而非目標母片？**

當所有匯入的投影片都應使用同一已知版面配置時使用特定版面配置；當您希望 Aspose.Slides 根據來源版面配置的類型或名稱在該母片的版面配置中自動挑選時，則使用母片。

**不同投影片尺寸的簡報可以合併嗎？**

可以，但投影片內容不會自動為目標尺寸重新設計。若需要預測的版面位置，請先使用 [SlideSize.set_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/set_size/) 與 [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**

可以。載入每個來源簡報，將所需投影片克隆至同一目標，最後以支援的輸出格式儲存。因為不同檔案格式的功能支援程度不盡相同，請在跨格式合併後驗證複雜內容。參見 [Supported File Formats](https://docs.aspose.com/slides/zh-hant/python-net/supported-file-formats/)。

**來源分節會自動保留嗎？**

基本的僅克隆投影片的迴圈不會保留分節。若需要保留分節，請在目標簡報中重新建立相應分節，並使用 [add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 的分節重載。

**投影片備註與評論會被保留嗎？**

會隨克隆的投影片一起複製。若工作流程依賴於備註母片樣式、評論作者或串討論資料，請在合併後驗證結果，因為這些情況涉及簡報層級結構與投影片層級內容。

**音訊、影片、OLE 物件與超連結會發生什麼事？**

內嵌的內容會隨克隆的投影片的資源關聯一起保留。外部連結仍保持外部狀態，合併後仍需確保其目標檔案或 URL 可用。

**是否保證所有來源的內嵌字型在合併後的簡報中可用？**

不要僅依賴投影片克隆來部署字型。請檢查目標簡報的內嵌字型，並在排版重要時明確管理字型內嵌或外部字型的可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 開啟檔案，然後照常克隆投影片。輸出保護需另行設定。

**如何處理非常大的簡報？**

在大量二進位物件佔用記憶體時使用 BLOB 管理，對於非常大的檔案盡可能使用檔案路徑載入，及時關閉來源簡報，且僅在必要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**

請勿在多個執行緒中同時載入、儲存或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。每個合併操作應保持單執行緒；若需平行化獨立的合併工作，請使用獨立的單執行緒行程與獨立的簡報實例。