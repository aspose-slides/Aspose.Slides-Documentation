---
title: 在 C++ 中處理簡報警告
type: docs
weight: 70
url: /zh-hant/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損毀
- 相容性問題
- 字型置換
- 數位簽章
- 簡報載入
- 簡報呈現
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for C++ 載入、呈現、轉換和儲存簡報時，收集、分類並處理警告。"
---
## **概述**

Aspose.Slides 可以在載入、呈現、轉換或儲存簡報時回報可復原的問題。範例包括受損的來源記錄、無法保留的內容、字型置換，以及目標格式的限制。警告回呼讓應用程式記錄這些情況，並決定目前的操作是否可以繼續。

實作[IWarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iwarningcallback/)介面，並檢查透過[IWarningInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iwarninginfo/)提供的[IWarningInfo::get_WarningType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/)與[IWarningInfo::get_Description](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iwarninginfo/get_description/)方法。回傳[ReturnAction::Continue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/returnaction/)以接受警告，或 `ReturnAction::Abort` 以停止操作。

使用[LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_warningcallback/)處理開啟簡報時產生的警告。呈現與匯出選項類別繼承[SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_warningcallback/)，可接收來自投影片呈現、轉換與儲存的警告。因為警告本身不會指明應用程式的操作，請在建立合併報告時，將每個回呼實例與操作階段關聯。

## **警告與例外**

警告描述的是 Aspose.Slides 在回呼返回`ReturnAction::Continue` 時可以復原的情況。例外則表示請求的操作無法正常完成；例外不會被轉換成警告，也無法透過警告政策處理。

返回`ReturnAction::Abort` 會請求警告分派器透過拋出例外來終止目前的操作。公開的例外類型取決於操作與簡報格式。例如，載入時可能拋出[PptxReadException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxreadexception/)或[PptReadException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出[PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/)。請在操作邊界處理例外，並使用警告報告判斷是否因應用程式政策而終止，而不是僅依賴單一例外子類別或訊息。回呼在返回`ReturnAction::Abort` 前會記錄警告，確保原因仍可供應用程式使用。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/warningtype/)列舉提供以下類別：

| 警告類型 | 意義 | 典型策略 |
| --- | --- | --- |
| `SourceFileCorruption` | 來源簡報包含的損壞可能導致以原始格式儲存的文件無法使用。 | 中止。 |
| `DataLoss` | 文字、圖表、影像或其他資料在載入或儲存後可能遺失。 | 中止。 |
| `MajorFormattingLoss` | 簡報可能失去重要的格式設定。 | 在嚴格驗證模式下中止；否則記錄並繼續。 |
| `MinorFormattingLoss` | 可能出現有限的格式差異。 | 記錄以供診斷並繼續。 |
| `CompatibilityIssue` | 結果在某些應用程式或較舊版本中可能無法開啟或正確運作。 | 記錄並繼續，除非相容性是必須的。 |
| `UnexpectedContent` | 來源包含未支援或未辨識的內容，其影響可能尚不清楚。 | 記錄並繼續，或在嚴格政策下視為錯誤。 |

類別應驅動政策決策。將警告描述儲存供診斷使用，但不要在應用程式邏輯中依賴其文字內容，因為訊息文字會因警告情境與產品版本而異。

## **收集與分類警告**

以下範例使用一個應用程式層級的報告，涵蓋完整處理管線。不同的回呼實例分別標記載入、呈現、PDF 轉換與 PPTX 儲存階段的警告。政策在來源損毀或資料遺失時中止，選擇性在重大格式遺失時中止，其他警告則繼續。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

當可接受重大格式差異時，將 `abortOnMajorFormattingLoss` 設為 `false`。相容性問題、次要格式遺失與未預期內容仍會保留在報告中，即使操作繼續。若應用程式必須拒絕上述任何類別，請擴充 `WarningPolicy::GetAction`。

## **常見警告情境**

警告可能在工作流程的不同階段出現：

- **數位簽章:** 已簽署的簡報在載入時可能產生警告，指出其簽章將在處理過程中遺失。Aspose.Slides 透過[IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/)回報此 `DataLoss` 情況。載入階段的回呼讓應用程式拒絕檔案或明確接受報告的遺失。
- **字型置換:** 在投影片呈現或匯出時，若遇到不可用的字型，系統會以替代字型呈現。字型置換警告會以 `DataLoss` 回報，因此上述嚴格政策會在字型置換仍被視為遺失時中止。若要觀察此行為，請使用包含執行環境未安裝之字型的簡報作為輸入。警告描述會指出置換的字型；在重試前配置所需字型或[字型置換規則](/slides/zh-hant/cpp/font-substitution/)。
- **未支援或未預期內容:** 載入器可能遇到簡報記錄或功能尚未辨識。此類警告可能使用 `UnexpectedContent`，或在已知資料或格式受到影響時使用更嚴重的類別。
- **格式相容性:** 儲存為其他簡報格式時，可能遺漏某些功能或產生在某些應用程式中行為不同的結果。例如，將含有超過八條水平或垂直繪圖參考線的簡報儲存為舊版 PPT 時，會回報 `CompatibilityIssue`。儲存階段的回呼可以記錄遺失並繼續，或在必須保留所有參考線時拒絕。
- **載入行為:** 載入選項與舊行為也可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) 會將使用過時的簡報鎖定行為辨識為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案必定產生警告，或情境一定對應唯一類別。

## **安全處理中止的操作**

當回呼返回 `ReturnAction::Abort` 時，請勿使用未成功載入的物件，也不要假設呈現或儲存的輸出已完整。操作可能在建立輸出檔案後、完成之前即終止。

將驗證過的結果儲存至其他路徑，例如 `validated-output.pptx`。僅在操作成功完成、警告報告符合應用程式政策且輸出可開啟檢查後，才取代現有簡報。這可避免以部分或被拒絕的結果覆寫有效的來源檔案。

空的警告報告並不保證每個來源功能皆已保留。請依應用程式需求執行任何額外的內容與視覺檢查。另請參閱[開啟簡報](/slides/zh-hant/cpp/open-presentation/)與[儲存簡報](/slides/zh-hant/cpp/save-presentation/)。

## **常見問題**

**警告回呼能處理每個 Aspose.Slides 錯誤嗎？**

不行。它僅處理以警告形式回報的可復原情況。與回呼無關的例外必須在載入、呈現、轉換或儲存呼叫周圍由應用程式自行處理。

**回傳 `ReturnAction::Continue` 是否保證輸出相同？**

不保證。它僅允許處理繼續。報告的情況仍可能導致資料、格式或相容性差異，請檢查收集到的警告類型與描述。

**應用程式如何辨識產生警告的操作？**

為每個操作建立一個回呼實例，並將應用程式自訂的階段與警告類型及描述一起儲存，如範例所示。