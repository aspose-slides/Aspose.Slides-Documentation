---
title: Handle Presentation Warnings in C++
type: docs
weight: 70
url: /cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- warning callback
- warning policy
- data loss
- source corruption
- compatibility issue
- font substitution
- digital signature
- presentation loading
- presentation rendering
- presentation conversion
- presentation saving
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Learn how to collect, classify, and act on warnings while loading, rendering, converting, and saving presentations with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides can report recoverable problems while it loads, renders, converts, or saves a presentation. Examples include damaged source records, content that cannot be preserved, font substitution, and limitations of a target format. A warning callback lets an application record these conditions and decide whether the current operation may continue.

Implement the [IWarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iwarningcallback/) interface and examine the [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) and [IWarningInfo::get_Description](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iwarninginfo/get_description/) methods supplied through [IWarningInfo](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iwarninginfo/). Return [ReturnAction::Continue](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/returnaction/) to accept the warning or `ReturnAction::Abort` to stop the operation.

Use [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_warningcallback/) for warnings raised while opening a presentation. Rendering and export option classes inherit [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/), which receives warnings from slide rendering, conversion, and saving. Because the warning itself does not identify the application operation, associate each callback instance with an operation stage when you build a combined report.

## **Warnings and Exceptions**

A warning describes a condition from which Aspose.Slides can recover if the callback returns `ReturnAction::Continue`. An exception means the requested operation cannot complete normally; exceptions are not converted into warnings and cannot be handled by a warning policy.

Returning `ReturnAction::Abort` asks the warning dispatcher to terminate the current operation by raising an exception. The public exception depends on the operation and presentation format. For example, loading can surface a [PptxReadException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxreadexception/) or [PptReadException](https://reference.aspose.com/slides/cpp/aspose.slides/pptreadexception/), while saving or exporting can surface a [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/). Handle the exception at the boundary of the operation and use the warning report to determine whether the application policy caused the termination instead of relying on one exception subtype or message. The callback records the warning before returning `ReturnAction::Abort`, ensuring that the reason remains available to the application.

## **Warning Categories**

The [WarningType](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/warningtype/) enumeration provides the following categories:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| `SourceFileCorruption` | The source presentation contains corruption that can make a document saved in its original format unusable. | Abort. |
| `DataLoss` | Text, charts, images, or other data may be absent after loading or saving. | Abort. |
| `MajorFormattingLoss` | The presentation may lose important formatting. | Abort in strict validation mode; otherwise record and continue. |
| `MinorFormattingLoss` | A limited formatting difference may occur. | Record for diagnostics and continue. |
| `CompatibilityIssue` | The result may not open or behave correctly in some applications or older versions. | Log and continue unless compatibility is mandatory. |
| `UnexpectedContent` | The source contains unsupported or unrecognized content whose effect may not yet be known. | Record and continue, or treat as an error in a strict policy. |

The category should drive the policy decision. Store the warning description for diagnostics, but do not depend on its wording for application logic because message text can vary between warning scenarios and product versions.

## **Collect and Classify Warnings**

The following example uses one application-level report for the complete processing pipeline. A separate callback instance labels warnings from loading, rendering, PDF conversion, and PPTX saving. The policy aborts on source corruption or data loss, optionally aborts on major formatting loss, and continues for other warnings.

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

Set `abortOnMajorFormattingLoss` to `false` when major formatting differences are acceptable. Compatibility issues, minor formatting loss, and unexpected content are still retained in the report even when the operation continues. Extend `WarningPolicy::GetAction` if the application must reject any of those categories.

## **Common Warning Scenarios**

Warnings can appear at different stages of a workflow:

- **Digital signatures:** A signed presentation can produce a warning during loading that its signature will be lost during processing. Aspose.Slides reports this `DataLoss` condition through [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). A load-stage callback lets the application reject the file or explicitly accept the reported loss.
- **Font substitution:** An unavailable font can be replaced while a slide is rendered or exported. Font substitution warnings are reported as `DataLoss`, so the strict policy above aborts even if the application would consider a particular replacement visually acceptable. To observe this behavior, use an input presentation containing text in a font unavailable to the runtime. The warning description identifies the substitution; configure the required fonts or [font substitution rules](/slides/cpp/font-substitution/) before retrying.
- **Unsupported or unexpected content:** A loader can encounter presentation records or features it does not recognize. Such warnings may use `UnexpectedContent`, or a more severe category when data or formatting is known to be affected.
- **Format compatibility:** Saving to another presentation format can omit features or produce a result that behaves differently in some applications. For example, saving a presentation with more than eight horizontal or eight vertical drawing guides to legacy PPT reports a `CompatibilityIssue`. The save-stage callback can record the loss and continue, or reject it if preserving all guides is required.
- **Loading behavior:** Loading options and legacy behaviors can also produce warnings. For example, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifies use of an obsolete presentation-locking behavior as a `CompatibilityIssue`.

Warnings depend on the source document, target format, operation, and Aspose.Slides version. Do not assume that every file produces a warning or that a scenario always maps to only one category.

## **Safely Handle Aborted Operations**

When a callback returns `ReturnAction::Abort`, do not use an object that failed to load and do not assume that a rendering or save output is complete. The operation can terminate after creating an output file but before finishing it.

Save validated results to a separate path such as `validated-output.pptx`. Replace an existing presentation only after the operation finishes successfully, the warning report satisfies the application policy, and the output can be opened and checked. This avoids overwriting a valid source file with a partial or rejected result.

An empty warning report is not a guarantee that every source feature has been preserved. Apply any additional content and visual checks required by the application. See also [Open Presentations](/slides/cpp/open-presentation/) and [Save Presentations](/slides/cpp/save-presentation/).

## **FAQ**

**Can a warning callback handle every Aspose.Slides error?**

No. It handles recoverable conditions reported as warnings. Exceptions that occur independently of the callback must be handled by the application around the loading, rendering, conversion, or saving call.

**Does returning `ReturnAction::Continue` guarantee identical output?**

No. It only permits processing to continue. The reported condition can still cause data, formatting, or compatibility differences, so review the collected warning types and descriptions.

**How can an application identify the operation that produced a warning?**

Create a callback instance for each operation and store an application-defined stage together with the warning type and description, as shown in the example.
