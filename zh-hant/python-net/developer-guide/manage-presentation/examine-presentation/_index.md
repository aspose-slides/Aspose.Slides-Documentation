---
title: 在 Python 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/python-net/examine-presentation/
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
- Aspose.Slides
description: "使用 Python 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概述**

Aspose.Slides 能夠辨識簡報的格式，並在不建立完整簡報物件模型的情況下讀取文件的中繼資料。這在需要分類檔案、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時非常有用。

本文示範如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/) 以及 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 進行輕量檢查，並透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 進行目標更新。

## **檢查簡報格式**

使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 檢查檔案，而不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。[PresentationInfo.load_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/load_format/) 屬性會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **建立輕量簡報清單**

當處理大量簡報檔案時，您可能需要一個緊湊的清單以供驗證、索引或文件管理系統使用。在此情況下，使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 讀取文件中繼資料。此方式不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 所公開的擴充屬性提供以下清單值：

| 屬性 | 清單值 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/slides/zh-hant/) | 投影片總數。 |
| [hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/hidden_slides/) | 隱藏投影片數量。 |
| [notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/notes/) | 包含備註的投影片數量。 |
| [paragraphs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/paragraphs/) | 段落總數（若有提供）。 |
| [words](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/words/) | 總字數。 |
| [multimedia_clips](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/multimedia_clips/) | 音訊與視訊剪輯的總數。 |

以下範例在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件的情況下讀取這些值，並印出緊湊的清單。它同時結合 [heading_pairs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/heading_pairs/) 與 [titles_of_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/titles_of_parts/) 以顯示內容群組，如字型、配色主題與投影片標題。

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/headingpair/) 提供群組名稱與該群組的項目數量。[DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/titles_of_parts/) 為平面、有序的集合，因此須依每個 heading pair 指定的連續標題數量來消耗。

### **儲存的中繼資料與格式限制**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 回傳的清單屬性反映來源文件中可使用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型來重新計算此呼叫的值。缺少的屬性會以預設值表示；如果最後一次儲存檔案的應用程式未更新文件屬性，儲存的值可能已過時。

- **PPTX:** 此格式提供投影片、備註、隱藏投影片、段落、字數與多媒體計數等擴充文件屬性，以及 heading pairs 與 part titles。可用性取決於文件產生者寫入了哪些屬性。
- **PPT:** 此二進位格式可以儲存相對應的文件摘要屬性。如果屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其儲存的或預設值，而不是從投影片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，如頁面、段落與字數計數，但這些值未對應所有 PowerPoint 專屬的擴充屬性。隱藏投影片、備註投影片、多媒體、 heading-pair 與 part-title 中繼資料可能不存在，清單屬性可能回傳預設值。不要將零值或空集合視為該內容不存在的權威證明。

請在清單與初步檢查時使用輕量中繼資料方法。若結果必須反映記憶體中的變更，或需要驗證實際簡報內容，則需載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例的情況下變更。使用 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/update_document_properties/) 套用變更，然後用 [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/write_binded_presentation/) 寫入已繫結的簡報。

下圖顯示原始的文件屬性。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

下圖顯示更新後的文件屬性。

![PowerPoint 簡報的已變更文件屬性](output_properties.png)

## **相關連結**

欲了解相關安全檢查與保護設定，請參閱以下文章：

- [密碼保護簡報](/slides/zh-hant/python-net/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/python-net/write-protected-presentation/)

## **常見問答**

**如何檢查字型是否已嵌入以及哪些字型已嵌入？**

載入簡報並使用 [Presentation.fonts_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/)。呼叫 [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 取得已嵌入的字型，呼叫 [FontsManager.get_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 取得簡報使用的字型。比較兩者結果即可找出需要呈現但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及其數量？**

當已存儲的文件中繼資料足夠時，可透過 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 及 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 讀取 [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/hidden_slides/)。此方式適用於輕量清單。如果簡報在記憶體中已被修改，則已存儲的中繼資料可能缺失或過時，或需要驗證即時值，則需遍歷 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 並檢查每張投影片的 [Slide.hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/) 屬性。

**我能否偵測是否使用自訂投影片大小與方向，且是否與預設值不同？**

可以。載入簡報後讀取 [Presentation.slide_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slide_size/)。檢查 [SlideSize.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/type/)、[SlideSize.size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/size/) 與 [SlideSize.orientation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/orientation/)，將目前設定與預期的預設值與尺寸進行比較。

**是否有快速方法檢查圖表是否參考外部資料來源？**

可以。找出每個 [Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)，並檢查 [ChartData.data_source_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/)。若為外部工作簿，請讀取 [ChartData.external_workbook_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。資料來源類型與路徑可辨識外部參考，但要驗證目標是否可用需另行檢查資源。

**如何評估可能拖慢渲染或 PDF 匯出的「大型」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 以及每張投影片的 [BaseSlide.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/shapes/) 集合。以形狀數量以及大型影像、效果、動畫或多媒體的存在作為篩選指標，並在將投影片視為確定的效能瓶頸前，先測量代表性的渲染或匯出時間。