---
title: 以 C++ 取得與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "使用 C++ 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概覽**

Aspose.Slides 能夠辨識簡報的格式，且在不建立完整簡報物件模型的情況下讀取文件中繼資料。當您需要對檔案進行分類、建立清單，或在決定是否載入與處理簡報內容之前先檢查屬性時，這非常有用。

本文示範如何透過[PresentationFactory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/)與[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/)執行輕量檢查，並使用[IDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/)進行目標更新。

## **檢查簡報格式**

使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)實例的情況下檢查檔案。[IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_loadformat/) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **建立輕量簡報清單**

當您處理大量簡報檔案時，可能需要緊湊的清單以進行驗證、索引或文件管理系統。在此情境下，使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/) 物件，然後呼叫[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 讀取文件中繼資料。此做法不會建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)實例，也不需要遍歷完整的簡報物件模型。

由[IDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/) 所公開的延伸屬性提供以下清單值：

| 方法 | 清單值 |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_slides/) | 投影片總數。 |
| [get_HiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | 隱藏投影片的數量。 |
| [get_Notes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_notes/) | 含備註的投影片數量。 |
| [get_Paragraphs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | 可用時的段落總數。 |
| [get_Words](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_words/) | 單字總數。 |
| [get_MultimediaClips](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | 音訊與視訊剪輯的總數。 |

以下範例在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件的情況下讀取上述值，並列印緊湊的清單。它同時結合[IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_headingpairs/) 與[IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) 以顯示字型、佈景主題、投影片標題等內容群組。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

每個[IHeadingPair](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iheadingpair/) 皆透過[IHeadingPair::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iheadingpair/get_name/) 提供群組名稱，並透過[IHeadingPair::get_Count](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iheadingpair/get_count/) 提供該群組的項目數量。[IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) 會回傳平面、已排序的陣列，因此請依每個標題對所指定的連續標題數量來消費。

### **已儲存的中繼資料與格式限制**

由[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 回傳的清單屬性反映來源文件中可用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性會以預設值表示，而儲存的值若未在最後一次儲存檔案的應用程式中更新，則可能已過時。

- **PPTX:** 此格式提供投影片、備註、隱藏投影片、段落、單字與多媒體計數等延伸文件屬性，以及標題對與部件標題。可用性取決於文件產生者寫入了哪些屬性。  
- **PPT:** 二進位格式可以儲存相應的文件摘要屬性。若屬性缺失或未由文件產生者刷新，Aspose.Slides 會回傳其儲存的或預設值，而不是從投影片重新計算。  
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，例如頁數、段落與單字計數，但這些值並不對應每個 PowerPoint 專屬的延伸屬性。隱藏投影片、備註投影片、多媒體、標題對與部件標題的中繼資料可能不存在，清單屬性可能回傳預設值。請勿將零值或空陣列視為對應內容不存在的權威依據。

對於清單與初步檢查，請使用輕量中繼資料方法。當結果必須反映記憶體中的變更，或需要驗證實際簡報內容時，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 回傳的屬性亦可在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例的情況下進行變更。使用[IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) 套用變更，然後使用[IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) 將綁定的簡報寫出。

以下影像顯示原始文件屬性。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

以下影像顯示已更新的文件屬性。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **相關連結**

有關安全性檢查與保護設定，請參閱以下文章：

- [Password-Protect Presentations](/slides/zh-hant/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh-hant/cpp/write-protected-presentation/)

## **常見問題**

**如何檢查是否已嵌入字型以及是哪一些字型？**

載入簡報並使用[Presentation::get_FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/)。呼叫[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 取得已嵌入的字型，並呼叫[FontsManager::GetFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getfonts/) 取得簡報使用的字型。將兩個結果比較，即可找出需要渲染但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及其數量？**

當儲存的文件中繼資料足夠時，透過[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 以及[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 讀取[IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/get_hiddenslides/)。此方法適用於輕量清單。若簡報已在記憶體中被修改，儲存的中繼資料可能缺漏或過時，或需驗證即時值，則請遍歷[Presentation::get_Slides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slides/) 並檢查每張投影片的[Slide::get_Hidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/get_hidden/) 方法。

**我能否偵測是否使用了自訂投影片尺寸與方向，且是否與預設不同？**

可以。載入簡報並讀取[Presentation::get_SlideSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slidesize/)。檢查[ISlideSize::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/get_type/)、[ISlideSize::get_Size](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/get_size/)、以及[ISlideSize::get_Orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/get_orientation/) 以將目前設定與預設尺寸、方向進行比較。

**有沒有快速方法查看圖表是否參考外部資料來源？**

有。找出每個[Chart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/) 並檢查[ChartData::get_DataSourceType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)。若為外部活頁簿，讀取[ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)。資料來源類型與路徑即顯示外部參考，但是否可取得目標需另行檢查資源可用性。

**如何評估可能拖慢渲染或 PDF 輸出的「重量」投影片？**

沒有單一的複雜度屬性。遍歷[Presentation::get_Slides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slides/) 與每張投影片的[IBaseSlide::get_Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslide/get_shapes/) 集合。使用形狀數量、是否包含大型影像、特效、動畫或多媒體作為篩選訊號，並在將投影片視為確定的效能瓶頸前，先測量代表性的渲染或匯出時間。