---
title: 在 Python via Java 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/python-java/merge-presentation/
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
- Java
- Aspose.Slides
description: "了解如何在 Python via Java 中透過克隆投影片、控制母版與版面配置、調整投影片內容大小、保留區段，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for Python via Java 透過從一個 [簡報](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 克隆投影片到另一個簡報來合併簡報。主要操作是 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone)，它可以保留來源投影片的格式，或將克隆的投影片附加到目標簡報的母版或版面配置上。

本文介紹最常見的合併工作流程：

- 合併所有投影片，同時保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報的母版；
- 套用目標簡報的特定版面配置；
- 在合併前正規化不同的投影片尺寸；
- 將克隆的投影片加入區段；
- 在單一端對端工作流程中合併多個簡報；
- 處理母版、資源、備註、評論、媒體、字型、密碼、大檔案以及多執行緒相關議題。

## **投影片克隆如何影響母版與版面配置**

投影片的大部分外觀都是從其版面配置與母版繼承而來。因此，您選擇的克隆重載決定了合併後的投影片如何整合到目標簡報中。

使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 的以下方式：

- `addClone(source_slide)` — 保留來源投影片的版面配置與格式。必要時，來源母版會自動克隆到目標簡報。Aspose.Slides 會追蹤自動克隆的母版，以避免重複克隆相同母版的投影片。
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — 將克隆的投影片附加到特定的目標 [母版投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/)。Aspose.Slides 會根據版面類型或名稱在該母版下尋找匹配的版面配置。
- `addClone(source_slide, destination_layout)` — 直接將克隆的投影片附加到特定的目標 [版面投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/)。

傳遞給 `addClone` 重載的母版或版面配置必須屬於 **目標** 簡報，而非來源簡報。

## **合併完整簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製到目標簡報。當匯入的投影片應保留原始主題、母版與版面配置關係時，這是適當的選擇。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

如果來源與目標使用不同的設計，最終簡報可能會包含多個母版。這是在有意保留來源格式時的正常情況。

## **合併選取的投影片**

您不必克隆所有投影片。以下範例僅從來源簡報匯入選取的投影片索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

在從使用者輸入或外部設定取得索引時，請先驗證投影片索引的正確性。

## **使用目標母版合併投影片**

當匯入的投影片應遵循已存在於目標簡報的母版時，使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 的相應重載。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides 會根據來源版面的類型或名稱，在指定的母版下選擇適當的版面配置。若不存在相容的版面配置且 `allow_clone_missing_layout` 為 `True`，則會克隆來源版面配置，以便加入投影片；若為 `False`，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxeditexception/)。

當您希望合併失敗而不是在目標母版中新增額外版面配置時，請使用 `False`。

## **使用特定目標版面配置合併投影片**

當您確切知道匯入的投影片應使用哪個目標版面配置時，使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 的對應重載。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

套用目標版面配置會改變繼承的版面關係；它不會重新設計來源投影片的內容。如果來源與目標版面配置的占位結構不同，請檢查結果，以確保繼承的格式與占位行為符合預期。

## **合併具有不同投影片尺寸的簡報**

尺寸不同的簡報可以合併，但將投影片克隆到尺寸不同的簡報時，內容不會自動為新畫布重新排版。因此，形狀可能會移位、縮放異常，或位於可見投影片區域之外。

實務上可在克隆前先調整來源簡報的尺寸。[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setSize) 方法能在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/) 會將內容縮放至符合目標尺寸。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報供其他操作使用，請為合併開啟獨立的實例。

## **將投影片合併到簡報區段**

基本的投影片克隆迴圈不會重新建立來源簡報的區段階層。如果輸出需要保留區段，請在目標簡報中建立或選取區段，並使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 明確將投影片克隆至該區段。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

克隆的投影片會被附加到指定的目標區段。若要保留多個來源區段，請列舉 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSections)，使用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection) 取得每個來源區段的投影片，於目標簡報中重新建立對應區段，然後將每張投影片克隆至對應的目標區段。請參考 [管理投影片區段](/slides/zh-hant/python-java/slide-section/) 取得完整的區段列舉範例，涵蓋空區段與結構變更。

## **安全合併多個簡報**

以下端到端範例使用第一個簡報作為目標，對其餘每個來源正規化投影片尺寸，只在需要時開啟來源簡報，最後一次性保存最終檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

這是一個保留匯入投影片來源格式的實用基準。如果您的輸出必須使用單一目標主題，請將簡單的 `addClone(slide)` 呼叫替換為前述的目標母版或目標版面配置重載。

## **實務考量**

### **母版、版面配置與格式保真度**

預設的投影片克隆會自動將所需的來源母版帶入目標簡報。Aspose.Slides 會為自動克隆的母版建立內部註冊表，以避免重複克隆相同母版。手動克隆的母版不會被此註冊表追蹤，除非需要明確控制母版結構，否則請避免預先克隆母版。

不要假設名稱相同的兩個母版或版面配置在視覺上等同。若企業範本必須控制最終外觀，請明確選取目標母版或版面配置，並在合併後驗證結果。

### **備註與評論**

演講者備註與投影片評論與投影片內容相關，克隆投影片時會一併複製。Aspose.Slides 亦提供專用 API 供[簡報備註](/slides/zh-hant/python-java/presentation-notes/)與[簡報評論](/slides/zh-hant/python-java/presentation-comments/)使用。

若備註頁面的格式很重要，請驗證合併後的簡報，因為備註母版是簡報層級的物件，可能在來源檔案間有所差異。於審閱工作流程中，亦請在合併來自不同作者或範本的檔案後，驗證評論作者與串接評論。

### **影像、音訊、視訊、OLE 物件與外部連結**

投影片可能引用簡報層級的資源，例如影像、內嵌音訊、內嵌視訊與 OLE 資料。請克隆整張投影片，而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關聯。

對於內嵌與連結資源的處理方式應有所區別。連結的音訊、視訊、OLE 物件或超連結仍依賴外部目標；克隆投影片不會將外部連結轉為內嵌內容。請在最終簡報開啟的環境中測試連結路徑與 URL。

Aspose.Slides 會追蹤自動克隆的母版，但這不代表來自不同來源簡報的相同二進位資源一定會被去重。如需控制輸出檔案大小，請自行檢查合併後的套件並測量結果，而非依賴隱含的去重機制。

### **內嵌字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器上保持一致，僅克隆投影片並不保證所有必要字型皆已在目標環境中可用。您可以使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 檢查內嵌字型，並依照[在簡報中嵌入字型](/slides/zh-hant/python-java/embedded-font/) 的說明明確管理字型嵌入。

同時請確認您被允許嵌入來源檔案使用的字型，因為字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先成功以密碼開啟受保護的來源簡報，才能克隆其投影片。請透過 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 提供密碼。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # 處理已解密的簡報。
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

開啟加密來源並不會自動將相同保護套用至目標簡報。若有需要，請另行設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度影像、音訊、視訊或其他大型二進位物件的簡報可能佔用大量記憶體。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 提供 BLOB 處理與暫存檔使用的控制。請參考[管理簡報 BLOB](/slides/zh-hant/python-java/manage-blob/) 以取得大型檔案的處理策略。

對於大型檔案，盡可能使用檔案路徑載入，於合併完成後立即釋放每個來源簡報，除非工作流程需要檢查點，否則避免頻繁儲存中間結果。

### **執行緒安全性**

切勿同時在多執行緒中載入、修改、儲存或克隆同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。請將每個簡報實例限制於單一合併作業。若平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides 多執行緒指引](/slides/zh-hant/python-java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**  
使用不提供目標母版或版面配置的 `addClone`。當匯入的投影片需要母版時，Aspose.Slides 會自動克隆來源母版。

**如何讓匯入的投影片使用目標主題？**  
使用接受目標母版的重載。傳入目標簡報中的母版，而非來源母版。Aspose.Slides 會嘗試將每張來源投影片映射至該母版下的適當版面配置。

**什麼時候應該使用特定目標版面配置而不是目標母版？**  
當每張匯入的投影片都必須使用同一已知版面配置時使用版面配置；當您希望 Aspose.Slides 依據來源版面的類型或名稱在母版的版面配置中自動選擇時，使用母版。

**不同投影片尺寸的簡報可以合併嗎？**  
可以，但投影片內容不會自動為目標尺寸重新設計。需要可預測的版面時，請先使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setSize) 以及 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**我可以將 PPT、PPTX 與 ODP 簡報合併成一個檔案嗎？**  
可以。載入每個來源簡報，將需要的投影片克隆到同一目標簡報，最後以支援的輸出格式儲存。由於不同簡報格式的功能集合不完全相同，跨格式合併後請驗證複雜內容。請參考[支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)。

**來源區段會自動保留嗎？**  
不會，僅透過基本的投影片克隆迴圈不會保留區段結構。若必須保留區段，請在目標簡報中重新建立區段，並使用 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 的區段重載。

**演講者備註與評論會被保留嗎？**  
會隨克隆的投影片一起複製。對於依賴備註母版樣式、評論作者或串接審閱資料的工作流程，請在合併後驗證結果，因為這些情況涉及簡報層級結構與投影片層級內容。

**音訊、視訊、OLE 物件與超連結會怎樣處理？**  
內嵌的內容會隨克隆的投影片資源關係一起帶入。外部連結仍保持外部狀態，合併後仍需確保目標環境中能存取其檔案或 URL。

**所有來源的內嵌字型是否一定會出現在合併後的簡報中？**  
不要僅依賴投影片克隆來部署字型。請檢查目標簡報的內嵌字型，並在需要時明確管理字型嵌入或外部字型可用性。

**如何合併受密碼保護的檔案？**  
使用正確的 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 開啟來源檔案，然後照常克隆投影片。輸出保護需另行設定。

**如何處理非常大的簡報？**  
在大型二進位物件佔用記憶體的情況下使用 BLOB 管理，盡可能以檔案路徑載入，及時釋放來源簡報，並僅在必要時儲存最終結果。

**我可以從多個執行緒合併投影片嗎？**  
不要在多執行緒中同時使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。每個合併作業應使用獨立的簡報實例。