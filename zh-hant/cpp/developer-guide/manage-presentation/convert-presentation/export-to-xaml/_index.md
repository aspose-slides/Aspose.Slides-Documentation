---
title: 在 C++ 中將簡報匯出為 XAML
linktitle: 簡報至 XAML
type: docs
weight: 30
url: /zh-hant/cpp/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 至 XAML
- 匯出 PPTX 至 XAML
- 匯出 ODP 至 XAML
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint 和 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保持您的版面配置完好無損。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包含 XAML 的簡要介紹、展示如何以預設設定將簡報儲存為 XAML，以及示範如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 自訂匯出行為，包括匯出隱藏投影片。文章亦回答有關備援字型、XAML 堆疊相容性與隱藏投影片匯出行為的幾個常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計師中處理 XAML 檔案，或直接編寫與編輯標記。

## **使用預設選項將簡報匯出為 XAML**

以下 C++ 範例示範如何以預設設定將簡報匯出為 XAML：

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

預設情況下，匯出的投影片會儲存在目前工作目錄的 `pres` 子資料夾中，該目錄由 [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/zh-hant/cpp/system.io/directory/getcurrentdirectory/) 所回傳。資料夾會自動建立，任何所需的影像也會儲存在同處。

輸出資料夾名稱取自來源檔案名稱（不含副檔名）。以 `pres.pptx` 為例，輸出檔案命名為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml`，依此類推。即使您傳入絕對路徑的輸入簡報，輸出資料夾仍相對於目前工作目錄建立，而非與輸入檔案同階層。

## **使用自訂選項將簡報匯出為 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/ixamloptions/) 介面可控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請實作 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/ixamloutputsaver/) 並將您的實作實例傳遞給 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 的 [set_OutputSaver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) 方法。

若要在 XAML 輸出中包含隱藏投影片，請將 `true` 傳遞給 [set_ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 方法，範例如下 C++ 程式碼：

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **捕獲所有產生的 XAML 檔案**

XAML 匯出可能會為每張匯出的投影片產生一個 XAML 文件，外加分離的影像與支援資源。將自訂的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/ixamloutputsaver/) 傳遞給 [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) 以接收這些檔案，而非使用預設的檔案系統儲存程式。使用接受 XAML 選項的 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 之重載開始匯出。

### **了解回呼生命週期**

匯出器會對每個產生的檔案分別呼叫 [IXamlOutputSaver::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/)：

- `path` 標示檔案，可能包含相對目錄。請保留此資訊，因為 XAML 可能會以相對路徑參照資源。
- `data` 包含檔案的位元組。影像與其他二進位資源不可被解碼為文字。
- 儲存器必須在回傳前保留或持久化資料。範例中將每個位元組陣列複製到應用程式擁有的記憶體中。
- 只有在簡報的儲存作業回傳且所有回呼皆成功完成時，才視為匯出成功。切勿吞掉儲存錯誤或啟動未觀察的背景寫入；若持久化發生在之後，必須在該步驟也成功後才報告整體成功。

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 亦會套用於自訂儲存器。預設值 `false` 會排除隱藏投影片的 XAML 文件。設定為 `true` 則會包含它們以及匯出所需的所有資源。資源數量取決於簡報本身，請勿假設每張投影片僅有一次回呼或回呼順序固定。

### **匯出至記憶體並檢查檔案**

以下完整範例會載入 `pres.pptx`，將每個檔案收集到 [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/zh-hant/cpp/system.collections.generic/dictionary/)，並印出其名稱、類型與位元組數。名稱會完整保留。若出現重複名稱，集合會失敗，而不會靜默覆寫檔案。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

                // 僅在需要文字檢查時才解碼 XAML。
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

從您的應用程式呼叫 `InMemoryXamlExample::Run`。檢查時可使用副檔名判斷；請保留所有檔案，包括不熟悉的資源類型。儲存或傳輸時務必保持位元組不變。若需要對 XAML 進行文字處理，僅使用 UTF-8 編碼的 [Encoding::GetString](https://reference.aspose.com/slides/zh-hant/cpp/system.text/encoding/getstring/)。

### **將收集的檔案打包成 ZIP 壓縮檔**

此獨立範例會收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。唯一的壓縮檔名稱可區分同時執行的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱在正規化後衝突或不安全，整個套件會在寫入前被拒絕。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save 會完成 ZIP 目錄的寫入；在報告成功前先關閉檔案。
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

從您的應用程式呼叫 `ZipXamlExample::Run`。範例使用 C++ 執行環境的 `Aspose::Zip::ZipFile` 產生本機壓縮檔；匯出器本身不會寫入鬆散的 XAML 或影像檔案。若要儲存至遠端，請將寫入壓縮檔的階段改為上傳收集到的位元組陣列。可使用匯出工作識別碼加上完整的相對檔案名稱作為 Blob 金鑰，或將工作識別碼、相對名稱與二進位資料一起存入資料庫列。僅在所有上傳完成或資料庫交易提交後才發佈工作。若持久化失敗，請清除部分輸出。

對於大型簡報，自訂儲存器可以直接將每個檔案寫入應用程式儲存，以避免在記憶體中保留整個匯出的副本。匯出器仍會在呼叫儲存器之前先將所有產生的檔案收集於記憶體。從匯出器的觀點來看，請保持每次回呼為同步：在目的端接受位元組後才返回，並讓失敗傳遞給呼叫端。

### **保留資源名稱並驗證參照**

- 當目的端需要時正規化路徑分隔符，但仍須保留相對目錄。除非確認每個產生的名稱皆唯一且資源參照仍有效，否則不要僅使用 [Path::GetFileName](https://reference.aspose.com/slides/zh-hant/cpp/system.io/path/getfilename/)。
- 依目的端執行的名稱驗證規則。寫入鬆散檔案時，拒絕根目錄路徑與路徑遍歷段，使用 [Path::GetFullPath](https://reference.aspose.com/slides/zh-hant/cpp/system.io/path/getfullpath/) 解析目的路徑，並確認其仍位於預期的匯出目錄之下（包含目錄分隔符的包含性檢查）。使用不含符號連結的應用程式可控目錄，以免寫入被重新導向。
- 為每個匯出工作使用獨立的儲存器與命名空間。依據分隔符正規化結果以及目的端的大小寫敏感規則檢測衝突。
- 發佈前，將每個 XAML 文件當作 XML 解析，檢查其基於檔案的資源參照，如影像的 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以其所在 XAML 檔案的目錄為基礎解析，正規化得到的儲存名稱，並確認相應的字典鍵、ZIP 條目或儲存物件是否存在。外部 URI 與 XAML 標記表達式須與相對檔名分開處理。

例如，若 `pres/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `pres/images/image1.png` 的路徑儲存該資源。僅保留 `image1.png` 會導致關聯失效。若使用物件儲存，請在工作前綴下保留相同的目錄結構，並讓這些資源 URL 可供 XAML 消費者存取。重新開啟完成的 ZIP 檔以驗證條目名稱與資源位元組，並在目標 XAML 環境中載入示例投影片，以確認影像能正確解析。

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**  
使用 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 的 [set_DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)。在匯出時若缺少原始字型，系統會使用此備援字型。此設定並不保證產生的 XAML 會引用備援字型，亦不保證該字型在目標機器上可用。請確保 XAML 所參照的字型在顯示環境中已安裝。

**匯出的 XAML 只適用於 WPF，還是也可以在其他 XAML 堆疊中使用？**  
Aspose.Slides 透過公用 API 匯出 WPF XAML。對其他 XAML 堆疊（如 UWP、Xamarin.Forms）的相容性未得到保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片？如何防止它們預設被匯出？**  
預設情況下不會包含隱藏投影片。您可以透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 的 [set_ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 進行控制；若不需要匯出隱藏投影片，請保持此選項為停用狀態。