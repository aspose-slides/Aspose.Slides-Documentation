---
title: 高效於 Python via Java 合併簡報
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
description: "學習如何在 Python via Java 中透過複製投影片、控制母片與版面、調整投影片內容大小、保留節，以及處理受保護或大型檔案，來合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概覽**

Aspose.Slides for Python via Java 透過從一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 複製投影片至另一個投影片來合併簡報。主要操作是 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone)，它可以保留來源投影片的格式，或將複製的投影片附加到目標簡報的母片或版面配置。

本文說明最常見的合併工作流程：

- 合併所有投影片並保留其來源格式；
- 合併選取的投影片；
- 套用目標簡報的母片；
- 套用目標簡報的特定版面；
- 在合併前正規化不同的投影片尺寸；
- 將複製的投影片加入節；
- 在一個端到端工作流程中合併多個簡報；
- 處理母片、資源、備註、評論、媒體、字型、密碼、大檔案與多執行緒相關問題。

## **投影片複製對母片與版面的影響**

投影片的大部分外觀繼承自其版面與母片。因此，您選擇的複製覆載方法會決定合併後的投影片如何整合至目標簡報。

使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 可採取以下任一方式：

- `addClone(source_slide)` — 保留來源投影片的版面與格式。必要時，來源母片會自動複製至目標簡報。Aspose.Slides 會追蹤自動複製的母片，以避免同一母片被重複複製。
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — 將複製的投影片附加至特定的目標 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/)。Aspose.Slides 會依版面類型或名稱在該母片下尋找相符的版面。
- `addClone(source_slide, destination_layout)` — 直接將複製的投影片附加至特定的目標 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/)。

傳遞給 `addClone` 覆載的母片或版面必須屬於 **目標** 簡報，而非來源簡報。

## **合併整個簡報並保留來源格式**

最簡單的合併方式是將來源簡報的每一張投影片複製至目標簡報。當匯入的投影片應保留原始主題、母片與版面關係時，這是適當的選擇。

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

如果來源與目標使用不同的設計，結果簡報可能會包含多個母片。這在有意保留來源格式時是預期的行為。

## **合併選取的投影片**

您不必複製每一張投影片。以下範例僅從來源簡報匯入選取的投影片索引。

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

在投影片索引來自使用者輸入或外部設定時，請先驗證索引的有效性。

## **使用目標母片合併投影片**

當匯入的投影片應遵循已屬於目標簡報的母片時，請使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 覆載。

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

Aspose.Slides 會依來源版面的類型或名稱，在指定的母片下選取適當的版面。如果不存在相符的版面且 `allow_clone_missing_layout` 為 `True`，則會複製來源版面以加入投影片；若為 `False`，則拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxeditexception/)。

當您希望合併失敗而不是在目標母片中新增版面時，請使用 `False`。

## **使用特定目標版面合併投影片**

當您清楚知道匯入的投影片應使用哪個目標版面時，請使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 覆載。

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

套用目標版面會變更繼承的版面關係；不會重新設計來源投影片的內容。如果來源與目標版面具有不同的佔位區結構，請檢查結果以確認繼承的格式與佔位區行為是否符合預期。

## **合併具有不同投影片尺寸的簡報**

不同投影片尺寸的簡報可以合併，但將投影片複製至尺寸不同的簡報時不會自動重新設計其內容以適應新畫布。形狀可能會出現偏移、比例不正常或超出可見投影片區域。

實務上，建議在複製前先調整來源簡報的尺寸。可使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setSize) 方法在變更投影片尺寸的同時縮放現有內容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/) 會將內容縮放至符合指定尺寸。

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

調整尺寸會在記憶體中變更來源簡報物件。若您需要保留原始來源簡報以供其他操作，請為合併另開一個實例。

## **將投影片合併至簡報節**

基本的投影片複製迴圈不會重新建立來源簡報的節層次結構。若輸出結果需要保留節，請在目標簡報中建立或選取節，並使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 明確將投影片複製至該節。

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

複製的投影片會附加至指定的目標節。若要保留多個來源節，請遍歷 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSections)，使用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection) 取得每個來源節的投影片清單，於目標簡報中重新建立相同節，並將每張投影片複製至對應的目標節。請參考 [管理投影片節](/slides/zh-hant/python-java/slide-section/) 取得完整的節列舉範例，涵蓋空節與結構變更。

## **安全地合併多個簡報**

以下端對端範例以第一個簡報作為目標，為每個其他來源正規化投影片尺寸，僅在複製期間開啟來源，最後一次儲存最終檔案。

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

這是一個保留匯入投影片來源格式的實用基線。如果您的輸出必須使用單一目標主題，請將簡單的 `addClone(slide)` 呼叫替換為前述的目標母片或目標版面覆載。

## **實務考量**

### **母片、版面與格式忠實度**

預設的投影片複製會自動將所需的來源母片帶入目標簡報。Aspose.Slides 會為自動複製的母片維護內部註冊表，以避免重複複製同一母片。手動複製的母片不會被此註冊表追蹤，因此除非需要明確控制母片結構，否則請避免預先複製母片。

不要假設兩個具有相同名稱的母片或版面在視覺上是等價的。如果企業範本必須控制最終外觀，請明確選擇目標母片或版面，並在合併後驗證結果。

### **備註與評論**

說話者備註與投影片評論與投影片內容相關聯，複製投影片時會一併複製。Aspose.Slides 亦提供專門的 API 用於[簡報備註](/slides/zh-hant/python-java/presentation-notes/)與[簡報評論](/slides/zh-hant/python-java/presentation-comments/)。

如果備註頁面的格式重要，請驗證合併後的簡報，因為備註母片屬於簡報層級物件，可能在來源檔案間有所差異。對於審閱工作流程，亦需在合併不同作者或範本的檔案後驗證評論作者與串接評論。

### **圖像、音訊、視訊、OLE 物件與外部連結**

投影片可能引用簡報層級的資源，如圖像、內嵌音訊、內嵌視訊與 OLE 資料。請複製整張投影片而非僅複製可見形狀，讓 Aspose.Slides 能維持投影片與其資源的關係。

嵌入式與連結資源的處理方式不同。連結的音訊、視訊、OLE 物件或超連結仍依賴其外部目標；複製投影片不會將外部連結轉為嵌入式內容。請在合併後的執行環境中測試連結資源的路徑與 URL。

Aspose.Slides 雖會追蹤自動複製的母片，但不應將此視為跨來源簡報的相同二進位資源必然會去除重複的保證。若檔案大小是關鍵，請檢查合併後的套件並測量結果，而非依賴隱含的去重機制。

### **嵌入字型與字型可用性**

字型在簡報層級管理。若排版必須在不同機器間保持一致，僅複製投影片並不能保證所有必要字型在目標環境中可用。您可使用 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 檢查嵌入字型，並依照[在簡報中嵌入字型](/slides/zh-hant/python-java/embedded-font/) 的說明明確管理嵌入。

同時也要確認您有權限嵌入來源檔案所使用的字型。字型授權可能限制嵌入行為。

### **受密碼保護的簡報**

必須先成功開啟受密碼保護的來源，才能複製其投影片。請透過 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 提供密碼。

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
    # 使用已解密的簡報。
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

開啟加密來源並不會自動將相同保護套用至目標簡報。若需要，請另外設定輸出保護。

### **大型簡報與記憶體使用**

包含高解析度圖像、音訊、視訊或其他大型二進位物件的簡報可能佔用大量記憶體。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 提供 BLOB 處理與暫存檔使用的控制。請參考[管理簡報 BLOB](/slides/zh-hant/python-java/manage-blob/) 以取得大型檔案處理策略。

對於大型檔案，優先使用檔案路徑載入，盡快在完成合併後釋放每個來源簡報，且除非工作流程需要檢查點，否則避免多次儲存中間結果。

### **執行緒安全性**

請勿在多執行緒中同時載入、修改、儲存或複製同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。每個簡報實例僅限於單一合併作業。若平行處理獨立工作，請使用獨立的簡報實例，並遵循 [Aspose.Slides 多執行緒指引](/slides/zh-hant/python-java/multithreading/)。

## **常見問題**

**如何保留每個來源簡報的原始設計？**

使用不提供目標母片或版面的 `addClone`。當匯入的投影片需要來源母片時，Aspose.Slides 會自動複製該母片。

**如何讓匯入的投影片使用目標主題？**

使用接受目標母片的覆載。傳入目標簡報的母片，而非來源母片。Aspose.Slides 會嘗試將每張來源投影片對映至該母片下的適當版面。

**何時應使用特定目標版面而非目標母片？**

當每張匯入的投影片皆應使用同一已知版面時，使用特定版面。若希望 Aspose.Slides 依來源版面的類型或名稱在該母片的版面中自動選擇，則使用母片。

**可以合併不同投影片尺寸的簡報嗎？**

可以，但投影片內容不會自動重新設計以符合目標尺寸。若需要可預測的版面配置，請先使用 [SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setSize) 及 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/) 重新調整來源簡報。

**可以將 PPT、PPTX 與 ODP 簡報合併成同一檔案嗎？**

可以。載入每個來源簡報，將所需投影片複製至同一目標，並以支援的輸出格式儲存。因為不同格式的功能集合不完全相同，跨格式合併後請驗證複雜內容。參考[支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)。

**來源節會自動保留嗎？**

基本的僅複製投影片的迴圈不會保留節。請在目標中重新建立所需節，並在需要保留節結構時使用 `addClone` 的節覆載。

**說話者備註與評論會被保留嗎？**

會隨複製的投影片一起複製。若工作流程依賴備註母片樣式、評論作者或串接審閱資料，請在合併後驗證結果，因為這些情況涉及簡報層級結構以及投影片層級內容。

**音訊、視訊、OLE 物件與超連結會發生什麼事？**

嵌入的內容會隨複製的投影片資源關係一起保留。外部連結仍保持為外部，合併後仍需確保其目標檔案或 URL 可用。

**所有來源的嵌入字型是否保證在合併簡報中可用？**

不要僅依賴投影片複製來部署字型。請檢查目標的嵌入字型，並在排版重要時明確管理字型嵌入或外部字型可用性。

**如何合併受密碼保護的檔案？**

使用正確的 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 開啟檔案，然後如同一般流程複製投影片。輸出保護需另行設定。

**如何處理非常大型的簡報？**

在大型二進位物件佔用記憶體的情況下使用 BLOB 管理，盡可能以檔案路徑載入，及時釋放來源簡報，且僅在需要時儲存最終結果。

**可以從多個執行緒合併投影片嗎？**

不要在多執行緒中同時使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。每個合併作業應使用各自獨立的簡報實例。