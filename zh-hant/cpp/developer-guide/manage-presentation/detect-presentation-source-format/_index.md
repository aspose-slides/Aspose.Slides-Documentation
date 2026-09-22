---
title: 在 C++ 中判斷原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/cpp/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides for C++ 讀取已載入簡報的原始格式，比較偵測 API，並處理檔案、串流與舊版格式。"
---
## **概述**

載入投影片後，呼叫 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sourceformat/) 以確定其原始格式。此方法同樣可透過 [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_sourceformat/) 取得。當後續處理依賴於目前實例載入時的格式時，請使用它。

來源格式不同於為輸出檔案所選擇的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)。將檔案另存為其他格式不會改變現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要一個現有的 `sample.pptx` 檔案。它載入該檔案，並使用 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sourceformat/) 來選擇應用程式的處理原則，而非依檔名。變更輸入路徑即可測試其他格式。範例會列印所選的原則；請將訊息取代為您的應用程式邏輯。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **辨識支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sourceformat/) 列舉區分以下簡報格式。下方的副檔名為慣用副檔名，並非原始檔名的還原。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 支援巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 支援巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 支援巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個現有的 `sample.pps` 檔案。將其位元組讀入記憶體串流可模擬未帶檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 建構函式僅接受串流。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT、PPS 與 POT 使用相同的底層二進位格式。透過檔案路徑載入時，副檔名可協助區分投影片放映或範本。若未提供檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat::Ppt`；上述的 PPS 範例亦會報告 `Ppt`。

若您的應用程式必須保留此區別，請另行保留原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為識別任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在載入完整簡報物件模型之前檢查檔案時，請使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/getpresentationinfo/) 與 [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_loadformat/)。當實例已存在時，請使用 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sourceformat/)。

此範例需要 `sample.pptx`，並對兩項檢查皆印出 `Pptx`。在正式環境中，請依據處理階段選擇適當的 API；已載入的簡報不需再次檢查僅為取得來源格式。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

結果屬於不同的列舉型別：[LoadFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sourceformat/)。請勿透過轉換其數值來比較，亦不要假設每種格式的偵測結果相同。PowerPoint XML 在載入前可能會被報告為 `LoadFormat::Unknown`，載入後則為 `SourceFormat::Xml`。

## **保持來源與輸出格式分離**

此範例需要 `sample.pptx` 並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `Pptx`。只有從 ODP 輸出載入的新實例會報告 `Odp`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

使用 `MakeObject<Presentation>()` 從頭建立的簡報會報告 `SourceFormat::Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並不表示已載入 PPTX 檔案。若此區別重要，請另行追蹤您的應用程式是建立還是載入了該實例。

## **將來源格式對映到副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sourceformat/) 值對映至慣用副檔名，而不解析輸入檔名。fallback 機制可避免在未識別的值上默默指派副檔名。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

此對映不會轉換檔案或復原在串流載入期間遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 [SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)，或使用 [Save Presentations in Their Original Format](/slides/zh-hant/cpp/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立簡報並在工作目錄寫入三個檔案，若同名檔案會被覆寫。它分別以路徑與記憶體串流重新開啟每個輸出。對於 PPTX 與 ODP，兩種方式皆報告儲存的格式。對於 PPS，透過路徑載入會報告 `Pps`，而以不帶檔名的相同位元組載入則報告 `Ppt`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

下表彙總了具有相同副檔名之簡報的來源格式辨識：

| 儲存格式 | 依檔案路徑的 SourceFormat | 依無檔名串流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

舊版 PPS/POT 內容在無檔名串流中會正規化為 `Ppt`。此表說明格式辨識情況，並非在轉換過程中保留每個簡報功能的保證。

## **常見問題**

**儲存為 ODP 會改變從 PPTX 載入的簡報的來源格式嗎？**

不會。現有實例仍報告 `Pptx`。從已儲存的 ODP 檔載入的實例則報告 `Odp`。

**串流能否永遠區分舊版簡報、投影片放映與範本嗎？**

不會。 PPT、PPS 與 POT 共享相同的二進位格式。若需要此區別，請另行保留檔名或子類型中繼資料。

**如果簡報已經載入，應該使用哪個 API？**

請參考 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sourceformat/)。在載入前檢查檔案時，使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/getpresentationinfo/)。