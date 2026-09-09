---
title: 在 Python 透過 Java 取得與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/python-java/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Python 透過 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構和中繼資料，以獲得更快速的洞見和更聰明的內容稽核。"
---
## **概觀**

Aspose.Slides 可以在不建立完整的 Presentation 物件模型的情況下，識別簡報的格式並讀取其文件中繼資料。這在您需要對檔案分類、建立清單，或在決定是否載入與處理簡報內容之前檢查屬性時非常有用。

這些範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。每個範例若 JVM 尚未啟動，會自行啟動它。請在範例使用的路徑提供現有的簡報檔案。

本文示範如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/) 及 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 進行輕量檢查，以及透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 進行目標化更新。

## **檢查簡報格式**

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例的情況下檢查檔案。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#getLoadFormat) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **建立輕量簡報清單**

當您處理大量簡報檔案時，可能需要一個緊湊的清單以供驗證、索引或文件管理系統使用。在此情況下，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取文件中繼資料。此方式不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 所公開的擴充屬性提供以下清單值：

| 方法 | 清單值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getSlides) | 投影片總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getNotes) | 包含註解的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getParagraphs) | 段落總數（若有提供）。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getWords) | 字數總計。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getMultimediaClips) | 音訊與影片剪輯的總數。 |

以下範例在未建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件的情況下讀取這些值，並列印緊湊的清單。它同時結合 [getHeadingPairs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHeadingPairs) 與 [getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getTitlesOfParts) 以顯示內容群組，例如字型、佈景主題與投影片標題。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/headingpair/) 提供群組名稱以及該群組的項目數量。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getTitlesOfParts) 會回傳一個平面且有序的陣列，因此請依照每個 HeadingPair 所指定的連續標題數量來取用。

### **已儲存的中繼資料與格式限制**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的清單屬性反映來源文件中可取得的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算此呼叫的值。缺少的屬性會以預設值表示，若最後儲存檔案的應用程式未更新其文件屬性，則已儲存的值可能已過時。

- **PPTX：** 此格式提供投影片、註解、隱藏投影片、段落、字數與多媒體計數等擴充文件屬性，並包含 heading pairs 與 part titles。可用性取決於文件產生者寫入了哪些屬性。
- **PPT：** 此二進位格式可以儲存對應的文件摘要屬性。若屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其已儲存或預設值，而非依投影片計算。
- **ODP：** OpenDocument 中繼資料提供一般文件統計資訊，例如頁面、段落與字數計算，但這些值無法對應每個 PowerPoint 專屬的擴充屬性。隱藏投影片、註解投影片、多媒體、heading‑pair 與 part‑title 中繼資料可能不存在，清單屬性可能回傳預設值。請勿將零值或空陣列視為該內容一定不存在的權威證明。

在建立清單與初步檢查時，請使用輕量的中繼資料方法。當結果必須反映記憶體中的變更，或需要驗證實際簡報內容時，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例的情況下進行變更。使用 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) 套用變更，然後以 [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) 寫入已綁定的簡報。

下圖顯示原始的文件屬性。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

下圖顯示已更新的文件屬性。

![PowerPoint 簡報的已變更文件屬性](output_properties.png)

## **實用連結**

欲了解相關的安全性檢查與保護設定，請參閱以下文章：

- [密碼保護簡報](/slides/zh-hant/python-java/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/python-java/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些字型？**

載入簡報並使用 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager)。呼叫 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 取得已嵌入的字型，呼叫 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFonts) 取得簡報使用的字型。比較兩個結果即可找出渲染所需但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及數量？**

當已儲存的文件中繼資料足以判斷時，可透過 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 與 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHiddenSlides)。此方式適用於輕量清單。若簡報在記憶體中已被修改，已儲存的中繼資料可能遺失或過時，或需驗證即時值，則請遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 並檢查每張投影片的 [Slide.getHidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getHidden) 方法。

**我能偵測是否使用自訂投影片大小與方向，且它們是否與預設不同嗎？**

可以。載入簡報並呼叫 [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideSize)。使用 [SlideSize.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getType)、[SlideSize.getSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getSize) 與 [SlideSize.getOrientation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getOrientation) 來比較目前設定與預期的預設與尺寸。

**是否有快速方法檢查圖表是否參考外部資料來源？**

可以。找出每個 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 並呼叫 [ChartData.getDataSourceType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getDataSourceType)。若為外部試算表，請呼叫 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。資料來源類型與路徑可辨識外部參照，但要確認目標是否可用則需另行檢查資源。

**我該如何評估可能導致渲染或 PDF 輸出變慢的「繁重」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 以及每張投影片的 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getShapes) 集合。以形狀數量以及大型影像、特效、動畫或多媒體的存在作為篩選訊號，並在將投影片視為已確認的效能瓶頸前，先測量具代表性的渲染或匯出時間。