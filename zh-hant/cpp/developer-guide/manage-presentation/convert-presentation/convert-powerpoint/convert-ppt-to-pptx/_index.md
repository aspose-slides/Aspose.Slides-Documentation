---
title: 在 C++ 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/cpp/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 C++ 範例、錯誤處理與相容性說明。"
---
## **概述**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for C++ 能在不需要 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其儲存為 PPTX。本文說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 並傳入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)。在不再需要時釋放 Presentation 以釋放其資源。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

僅憑檔案副檔名不會決定輸出格式；必須使用 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 參數。若需要保留原始 PPT 檔案，請確保輸入與輸出路徑不同。

## **一次轉換多個 PPT 檔案**

以下範例會將某個目錄中的每個 `.ppt` 檔案轉換。每個檔案獨立處理，單一轉換失敗不會阻止其餘批次的執行。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

對於正式環境的工作負載，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔案名稱寫入重試或審查佇列。損壞的檔案、未提供正確密碼即開啟的受保護檔案、無法存取的路徑以及不支援的內容皆可能導致轉換失敗。請參考 [Password-Protected Presentations](/slides/zh-hant/cpp/password-protected-presentation/) 以載入加密檔案。

## **相容性與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、圖片、表格與圖表。然而，PPT 與 PPTX 並未以完全相同的方式呈現所有功能。若某項舊版功能在 PPTX 中沒有對應項目，或是程式庫未支援，可能會被正規化、略過或以不同方式顯示。

當轉換後的檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、不常見字型或 VBA 巨集時，請仔細檢查。純 PPTX 檔案並非巨集啟用格式，若必須保留 VBA，請使用相應的巨集啟用工作流程。另外，亦須確認在開啟或呈現轉換後的簡報的環境中，已存在所需的字型與外部資源。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵的投影片數量與內容，並在目標檢視器中比較其外觀與投影片放映行為。不要將成功的 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 呼叫視為所有舊版功能皆有完全對應的 PPTX 之證明。

## **何時使用 PPTX**

當簡報需在目前的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或以較易檢視與復原的格式保存時，請使用 PPTX。保留原始 PPT 作為歸檔或回復備份，直到轉換後的簡報通過您的相容性檢查為止。

如果需要 PDF、HTML、圖片、XPS 或其他輸出格式，請參考 [Convert Presentations to Multiple Formats](/slides/zh-hant/cpp/convert-presentation/) 中的特定格式指引，而不要假設所有目標都會保留可編輯的 PowerPoint 功能。

## **線上轉換器**

對於偶爾的檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用層面的錯誤處理，請使用 C++ API。

## **相關文章**
- [在 C++ 中儲存簡報](/slides/zh-hant/cpp/save-presentation/)
- [支援的檔案格式](/slides/zh-hant/cpp/supported-file-formats/)
- [在 C++ 中開啟簡報](/slides/zh-hant/cpp/open-presentation/)

## **FAQ**

**是否可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX？**

可以。Aspose.Slides for C++ 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉 PPTX 轉換會完整保留所有內容嗎？**

它會保留一般的簡報內容，但無法保證每個舊版或未支援的功能都能完整對應。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或不常見字型時，請仔細檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。缺少或錯誤的密碼會導致載入失敗。

**轉換完成後是否應該刪除 PPT 檔案？**

請保留原始檔案，直到您在相關檢視器與工作流程中驗證過 PPTX 為止。若有舊版功能轉換結果不同，這樣可作為回復備份。