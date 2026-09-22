---
title: 使用 Python 取得與更新簡報資訊
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
description: "使用 Python 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快的洞察與更智慧的內容稽核。"
---
## **概覽**

Aspose.Slides 能夠辨識簡報的格式，並在不建立完整簡報物件模型的情況下讀取其文件中繼資料。當您需要對檔案進行分類、建立清單，或在決定是否載入與處理簡報內容之前檢查屬性時，這非常有用。

本文展示如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/) 與 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 進行輕量級檢查，以及如何透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 進行目標更新。

## **檢查簡報格式**

如果您已經載入簡報，請參閱 [Determine the Original Presentation Format](/slides/zh-hant/python-net/detect-presentation-source-format/) 以了解載入後的偵測方式以及舊版 PPT、PPS 與 POT 串流的限制。

使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例的情況下檢查檔案。[PresentationInfo.load_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/load_format/) 屬性會回報偵測到的格式，如 PPTX、PPT 或 ODP。

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **建立輕量級簡報清單**

當您處理大量簡報檔案時，可能需要一個緊湊的清單來進行驗證、索引或文件管理系統。在此情境下，使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 讀取文件中繼資料。此方法不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 提供的擴充屬性提供以下清單值：

| 屬性 | 庫存值 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/slides/zh-hant/) | 幻燈片總數。 |
| [hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/hidden_slides/) | 隱藏幻燈片的數量。 |
| [notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/notes/) | 包含備註的幻燈片數量。 |
| [paragraphs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/paragraphs/) | 段落總數（若有提供）。 |
| [words](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/words/) | 字數總計。 |
| [multimedia_clips](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/multimedia_clips/) | 音訊與視訊剪輯總數。 |

以下範例在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件的情況下讀取這些值，並輸出緊湊的清單。它同時結合 [heading_pairs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/heading_pairs/) 與 [titles_of_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/titles_of_parts/) 以顯示如字型、主題與幻燈片標題等內容群組。

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

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/headingpair/) 提供一個群組名稱與該群組中的項目數量。[DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/titles_of_parts/) 為平坦且有序的集合，因此請根據每個 heading pair 指定的連續標題數量來讀取。

### **儲存的中繼資料與格式限制**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 回傳的清單屬性反映來源文件中可用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算此呼叫的值。缺少的屬性會以預設值表示；若最後儲存檔案的應用程式未更新其文件屬性，儲存的值可能已過時。

- **PPTX:** 此格式提供幻燈片、備註、隱藏幻燈片、段落、單字與多媒體計數的擴充文件屬性，以及 heading pairs 與 part titles。可用性取決於文件製作者寫入了哪些屬性。
- **PPT:** 此二進位格式可以儲存相應的文件摘要屬性。若屬性缺失或未由文件製作者重新整理，Aspose.Slides 會回傳其儲存的或預設的值，而不是從幻燈片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，例如頁面、段落與字數計數，但這些值並不對應每個 PowerPoint 特有的擴充屬性。隱藏幻燈片、備註幻燈片、多媒體、heading‑pair 與 part‑title 中繼資料可能不可用，清單屬性可能回傳預設值。不要將零值或空集合視為相應內容缺失的權威證明。

對於清單與初步檢查，請使用輕量級的中繼資料方法。當結果必須反映記憶體中的變更或需要驗證實際簡報內容時，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 回傳的屬性亦可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例的情況下變更。使用 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/update_document_properties/) 套用變更，然後使用 [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/write_binded_presentation/) 寫入繫結的簡報。

下圖顯示原始文件屬性。

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

## **實用連結**

有關相關的安全檢查與保護設定，請參閱以下文章：

- [受密碼保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/)
- [寫入保護的簡報](/slides/zh-hant/python-net/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些字型？**

載入簡報後使用 [Presentation.fonts_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/)。呼叫 [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 取得已嵌入的字型，並呼叫 [FontsManager.get_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 取得簡報使用的字型。比較兩者結果即可找出渲染所需但未嵌入的字型。

**如何快速判斷檔案是否有隱藏幻燈片以及其數量？**

當儲存的文件中繼資料足夠時，可透過 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 與 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 讀取 [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/hidden_slides/)。這適用於輕量級清單。若簡報在記憶體中已被修改，儲存的中繼資料可能缺失或過時，或需驗證即時值，則必須遍歷 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 並檢查每張幻燈片的 [Slide.hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/) 屬性。

**我能偵測是否使用自訂投影片大小與方向，且是否與預設不同嗎？**

可以。載入簡報後讀取 [Presentation.slide_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slide_size/)。檢查 [SlideSize.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/type/)、[SlideSize.size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/size/) 與 [SlideSize.orientation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/orientation/) 以將目前設定與預設的配置與尺寸作比較。

**是否有快速方法查看圖表是否引用外部資料來源？**

可以。定位每個 [Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/) 並檢查 [ChartData.data_source_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/)。若為外部工作簿，則讀取 [ChartData.external_workbook_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。資料來源類型與路徑可識別外部參考，但驗證目標是否可用需另行資源檢查。

**如何評估可能會減慢渲染或 PDF 匯出的「大型」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 與每張幻燈片的 [BaseSlide.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/shapes/) 集合。利用形狀數量以及大型影像、特效、動畫或多媒體的存在作為篩選訊號，並在將幻燈片視為確定的效能瓶頸之前，測量具代表性的渲染或匯出時間。