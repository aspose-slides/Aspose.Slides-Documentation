---
title: 在 C++ 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/cpp/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat::Xml
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides for C++ 將 PowerPoint 和 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for C++ 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字形式檢視簡報結構、排除產生文件的錯誤、在自動化測試中比較輸出、或整合需要 XML 而非簡報套件的工作流程時，XML 輸出非常有用。

使用 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法，並搭配來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 列舉的 `Xml` 值。您可以將結果直接寫入檔案或寫入串流。

{{% alert color="info" title="注意" %}}
`SaveFormat::Xml` 會建立 PowerPoint XML 簡報。它不會擷取儲存在 PPTX 套件內的各個 Office Open XML 部件。若您需要確切的 PPTX 套件部件，例如 `ppt/presentation.xml` 或個別投影片的 XML 檔案，請直接檢查 PPTX 套件本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 `SaveFormat::Xml` 傳遞給 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管線）時，請使用 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 的串流重載。以下範例將結果寫入 [MemoryStream](https://reference.aspose.com/slides/zh-hant/cpp/system.io/memorystream/)，並將其倒回，以便後續讀取：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// 將 xmlStream 傳遞給工作流程中的下一個元件。
```

## **比較 XML 與簡報及匯出格式**

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 常見用途 |
| --- | --- | --- |
| PowerPoint XML（`.xml`） | PowerPoint XML 簡報 | 檢視結構、排除錯誤、比較產生的輸出，以及基於 XML 的整合 |
| PPT（`.ppt`） | 舊版二進位簡報檔案 | 與較舊的 PowerPoint 工作流程相容 |
| PPTX（`.pptx`）） | 包含多個部件的 Office Open XML 套件 | 一般 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面頁面或多頁影像 | 檢視、列印與存檔 |
| PNG、JPEG 或 SVG | 單一投影片的渲染表示 | 縮圖、預覽與影像資產 |
| HTML 或 HTML5 | 面向網頁的簡報輸出 | 瀏覽器檢視與網站發佈 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢視與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，它代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。  
[支援的檔案格式](/slides/zh-hant/cpp/supported-file-formats/) 表列將 PowerPoint XML 簡報標示為僅能儲存的格式，因此在工作流程需要將匯出的檔案重新載入 Aspose.Slides 以持續編輯時，請勿使用它。

## **常見問題**

**`SaveFormat::Xml` 與儲存 PPTX 檔案相同嗎？**  
否。PPTX 是一個包含多個 Office Open XML 部件的套件，而 `SaveFormat::Xml` 會產生 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**  
可以。將可寫入的串流傳遞給 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)。例如，使用 [MemoryStream](https://reference.aspose.com/slides/zh-hant/cpp/system.io/memorystream/) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**  
否。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需往返編輯，請使用 PPTX 或其他受支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**  
否。XML 轉換會寫入結構化的簡報資料。若需頁面導向的輸出，請使用 PDF 或 TIFF；若需單張投影片影像，請使用 PNG、JPEG 或 SVG。