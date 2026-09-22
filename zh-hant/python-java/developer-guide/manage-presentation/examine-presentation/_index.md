---
title: "在 Python via Java 中取得與更新簡報資訊"
linktitle: "簡報資訊"
type: docs
weight: 30
url: /zh-hant/python-java/examine-presentation/
keywords:
- "簡報格式"
- "簡報屬性"
- "文件屬性"
- "取得屬性"
- "讀取屬性"
- "變更屬性"
- "修改屬性"
- "更新屬性"
- "檢視 PPTX"
- "檢視 PPT"
- "檢視 ODP"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Java"
- "Aspose.Slides"
description: "使用 Python via Java 探索 PowerPoint 與 OpenDocument 簡報的投影片、結構與中繼資料，快速洞察並提升內容稽核效率。"
---
## **概觀**

Aspose.Slides 可以在不建立完整簡報物件模型的情況下辨識簡報的格式並讀取其文件中繼資料。當您需要對檔案分類、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時，這非常有用。

範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行階段。每個範例會在 JVM 尚未啟動時啟動 JVM。請提供範例中使用路徑的現有簡報檔案。

本文示範如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/) 與 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 進行輕量檢查，以及透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 進行目標更新。

## **檢查簡報格式**

如果您已經載入簡報，請參閱 [Determine the Original Presentation Format](/slides/zh-hant/python-java/detect-presentation-source-format/) 以在載入後偵測格式，並了解舊版 PPT、PPS 與 POT 串流的限制。

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 來檢查檔案而不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#getLoadFormat) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

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

## **建立輕量級簡報清單**

當您處理大量簡報檔案時，可能需要緊湊的清單以進行驗證、索引或文件管理系統。在此情境下，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取文件中繼資料。此方式不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 暴露的延伸屬性提供以下清單值：

| 方法 | 清單值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getSlides) | 投影片的總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getNotes) | 含有備註的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getParagraphs) | 段落的總數（若可用）。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getWords) | 字數的總計。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getMultimediaClips) | 音訊與視訊剪輯的總數。 |

以下範例在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件的情況下讀取這些值，並列印緊湊的清單。它同時結合 [getHeadingPairs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHeadingPairs) 與 [getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getTitlesOfParts) 顯示字型、佈景主題、投影片標題等內容群組。

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

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/headingpair/) 都提供群組名稱與該群組中的項目數量。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getTitlesOfParts) 會回傳平面、已排序的陣列，因此請依每個標題配對所指定的連續標題數量來消費。

### **儲存的中繼資料與格式限制**

由 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的清單屬性反映來源文件中可取得的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性會以預設值表示；若最後一次儲存檔案的應用程式未更新文件屬性，儲存的值可能已過時。

- **PPTX:** 此格式提供投影片、備註、隱藏投影片、段落、字數與多媒體計數等延伸文件屬性，亦包含標題配對與部件標題。可用性取決於文件產生者寫入了哪些屬性。
- **PPT:** 二進位格式可儲存相對應的文件摘要屬性。若屬性缺失或未由文件產生者刷新，Aspose.Slides 會回傳其儲存的或預設值，而不會從投影片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊（如頁面、段落、字數），但這些值未必對應每個 PowerPoint 專屬的延伸屬性。隱藏投影片、備註投影片、多媒體、標題配對與部件標題的中繼資料可能不存在，清單屬性可能回傳預設值。請勿將零值或空陣列視為對應內容不存在的權威證明。

在建立清單與初步檢查時使用輕量中繼資料方法。若結果必須反映記憶體中的變更，或需要驗證實際簡報內容，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例的情況下變更。使用 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) 套用變更，然後使用 [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) 寫入已繫結的簡報。

以下圖片顯示 PowerPoint 簡報的原始文件屬性。

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

以下圖片顯示 PowerPoint 簡報的已變更文件屬性。

![PowerPoint 簡報的已變更文件屬性](output_properties.png)

## **實用連結**

如需相關的安全檢查與保護設定，請參閱以下文章：

- [密碼保護簡報](/slides/zh-hant/python-java/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/python-java/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及哪些字型被嵌入？**

載入簡報並使用 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager)。呼叫 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 取得已嵌入的字型，呼叫 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFonts) 取得簡報使用的字型。將兩個結果比較，即可找出需要渲染但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及有多少張？**

當保存的文件中繼資料足夠時，透過 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 再呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getHiddenSlides)。此方式適合輕量清單。如果簡報已在記憶體中修改、保存的中繼資料可能缺失或過時，或需驗證即時值，請遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 並檢查每張投影片的 [Slide.getHidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getHidden) 方法。

**我能偵測是否使用自訂投影片尺寸與方向，且它們是否與預設不同嗎？**

可以。載入簡報後呼叫 [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideSize)。使用 [SlideSize.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getType)、[SlideSize.getSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getSize) 與 [SlideSize.getOrientation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#getOrientation) 與預設設定與尺寸做比較。

**有沒有快速方法檢查圖表是否參考外部資料來源？**

有。定位每個 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 並呼叫 [ChartData.getDataSourceType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getDataSourceType)。若為外部活頁簿，呼叫 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。資料來源類型與路徑即可辨識外部參考，但確認目標是否可用需另行檢查資源。

**我該如何評估可能導致渲染或 PDF 匯出變慢的「重量」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 以及每張投影片的 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getShapes) 集合。使用形狀數量以及大型影像、特效、動畫或多媒體的存在作為篩選訊號，並在將投影片視為已確認的效能瓶頸前，先測量代表性的渲染或匯出時間。