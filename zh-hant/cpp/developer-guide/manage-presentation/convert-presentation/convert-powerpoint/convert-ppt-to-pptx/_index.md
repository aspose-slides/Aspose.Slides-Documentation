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
description: "使用 Aspose.Slides 在 C++ 中將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 C++ 範例、錯誤處理與完整度說明。"
---
## **概觀**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for C++ 可以在沒有 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其儲存為 PPTX。本文章說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需要驗證的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入來源檔案，然後以 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 作為參數呼叫 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)。在不再需要時釋放 presentation 以釋放其資源。

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

副檔名本身不會決定輸出格式；必須使用 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 參數來指定。若需保留原始 PPT 檔案，請將輸入與輸出路徑設定為不同的位置。

## **批次轉換多個 PPT 檔案**

以下範例會轉換目錄中每一個 `.ppt` 檔案。每個檔案獨立處理，單一轉換失敗不會阻止其餘批次執行。

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

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。檔案損毀、未提供正確密碼的受保護檔案、無法存取的路徑，以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/cpp/password-protected-presentation/) 了解如何載入加密檔案。

## **完整度與舊版功能**

轉換通常會保留投影片、母版、版面配置、文字、圖形、影像、表格與圖表。但 PPT 與 PPTX 並未以完全相同的方式表達所有功能。若某個舊版功能在 PPTX 中沒有對應，或本函式庫不支援，可能會被正規化、略過，或以不同方式顯示。

當檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、不常見字型或 VBA 巨集時，請務必檢查轉換後的檔案。純 PPTX 檔案不是支援巨集的格式，若 VBA 必須保留，請使用相應的巨集支援工作流程。此外，請確認所需字型與外部資源已存在於將要開啟或渲染轉換後簡報的環境中。

對於重要文件，建議以程式方式重新開啟產生的 PPTX，檢查關鍵投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要將成功呼叫 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 視為每個舊版功能都能在 PPTX 中完整再現的證明。

## **何時使用 PPTX**

當簡報需要在目前的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或需以較易檢查與復原的格式保存時，請使用 PPTX。保留原始 PPT 作為存檔或回滾副本，直到轉換後的簡報通過您的完整度檢查為止。

如果您需要 PDF、HTML、影像、XPS 或其他輸出格式，請參考 [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) 中針對特定格式的說明，而不要假設所有目標格式都能保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若只是偶爾轉換單一檔案或快速比較，可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用程式層級的錯誤處理，請使用 C++ API。

## **相關文章**

- [Save Presentations in C++](/cpp/save-presentation/)
- [Supported File Formats](/cpp/supported-file-formats/)
- [Open Presentations in C++](/cpp/open-presentation/)

## **常見問題**

**Can I convert PPT to PPTX without Microsoft PowerPoint installed?**

可以。Aspose.Slides for C++ 能在不安裝 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**Will PPT-to-PPTX conversion preserve all content exactly?**

會保留大部分常見的簡報內容，但對於每個舊版或未支援的功能，無法保證完全相同的再現。若檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或不常見字型，請仔細檢查產生的檔案。

**Can I convert a password-protected PPT file?**

可以，只要在載入檔案時提供正確的密碼。若密碼缺失或不正確，載入動作會失敗。

**Should I delete the PPT file after conversion?**

請保留原始檔案，直到您在相關檢視器與工作流程中驗證 PPTX 無誤為止。這樣可在舊版功能轉換異常時提供回滾的副本。