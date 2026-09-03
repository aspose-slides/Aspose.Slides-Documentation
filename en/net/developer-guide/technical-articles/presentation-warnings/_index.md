---
title: Handle Presentation Warnings in .NET
type: docs
weight: 120
url: /net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- .NET
- C#
- Aspose.Slides
description: "Learn how to collect, classify, and act on warnings while loading, rendering, converting, and saving presentations with Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides can report recoverable problems while it loads, renders, converts, or saves a presentation. Examples include damaged source records, content that cannot be preserved, font substitution, and limitations of a target format. A warning callback lets an application record these conditions and decide whether the current operation may continue.

Implement the [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) interface and examine the [WarningType](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarninginfo/warningtype/) and [Description](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarninginfo/description/) properties supplied through [IWarningInfo](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarninginfo/). Return [ReturnAction.Continue](https://reference.aspose.com/slides/net/aspose.slides.warnings/returnaction/) to accept the warning or `ReturnAction.Abort` to stop the operation.

Use [LoadOptions.WarningCallback](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/warningcallback/) for warnings raised while opening a presentation. Rendering and export option classes inherit [SaveOptions.WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/), which receives warnings from slide rendering, conversion, and saving. Because the warning itself does not identify the application operation, associate each callback instance with an operation stage when you build a combined report.

## **Warnings and Exceptions**

A warning describes a condition from which Aspose.Slides can recover if the callback returns `ReturnAction.Continue`. An exception means the requested operation cannot complete normally; exceptions are not converted into warnings and cannot be handled by a warning policy.

Returning `ReturnAction.Abort` asks the warning dispatcher to terminate the current operation by raising an exception. The public exception depends on the operation and presentation format. For example, loading can surface a [PptxReadException](https://reference.aspose.com/slides/net/aspose.slides/pptxreadexception/) or [PptReadException](https://reference.aspose.com/slides/net/aspose.slides/pptreadexception/), while saving or exporting can surface a [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/). Handle the exception at the boundary of the operation and use the warning report to determine whether the application policy caused the termination instead of relying on one exception subtype or message. The callback records the warning before returning `ReturnAction.Abort`, ensuring that the reason remains available to the application.

## **Warning Categories**

The [WarningType](https://reference.aspose.com/slides/net/aspose.slides.warnings/warningtype/) enumeration provides the following categories:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| `SourceFileCorruption` | The source presentation contains corruption that can make a document saved in its original format unusable. | Abort. |
| `DataLoss` | Text, charts, images, or other data may be absent after loading or saving. | Abort. |
| `MajorFormattingLoss` | The presentation may lose important formatting. | Abort in strict validation mode; otherwise record and continue. |
| `MinorFormattingLoss` | A limited formatting difference may occur. | Record for diagnostics and continue. |
| `CompatibilityIssue` | The result may not open or behave correctly in some applications or older versions. | Log and continue unless compatibility is mandatory. |
| `UnexpectedContent` | The source contains unsupported or unrecognized content whose effect may not yet be known. | Record and continue, or treat as an error in a strict policy. |

The category should drive the policy decision. Store `Description` for diagnostics, but do not depend on its wording for application logic because message text can vary between warning scenarios and product versions.

## **Collect and Classify Warnings**

The following example uses one application-level report for the complete processing pipeline. A separate callback instance labels warnings from loading, rendering, PDF conversion, and PPTX saving. The policy aborts on source corruption or data loss, optionally aborts on major formatting loss, and continues for other warnings.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Set `abortOnMajorFormattingLoss` to `false` when major formatting differences are acceptable. Compatibility issues, minor formatting loss, and unexpected content are still retained in the report even when the operation continues. Extend `WarningPolicy.GetAction` if the application must reject any of those categories.

## **Common Warning Scenarios**

Warnings can appear at different stages of a workflow:

- **Digital signatures:** A signed presentation can produce a warning during loading that its signature will be lost during processing. Aspose.Slides reports this `DataLoss` condition through [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). A load-stage callback lets the application reject the file or explicitly accept the reported loss.
- **Font substitution:** An unavailable font can be replaced while a slide is rendered or exported. Font substitution warnings are reported as `DataLoss`, so the strict policy above aborts even if the application would consider a particular replacement visually acceptable. To observe this behavior, use an input presentation containing text in a font unavailable to the runtime. The warning description identifies the substitution; configure the required fonts or [font substitution rules](/slides/net/font-substitution/) before retrying.
- **Unsupported or unexpected content:** A loader can encounter presentation records or features it does not recognize. Such warnings may use `UnexpectedContent`, or a more severe category when data or formatting is known to be affected.
- **Format compatibility:** Saving to another presentation format can omit features or produce a result that behaves differently in some applications. For example, saving a presentation with more than eight horizontal or eight vertical drawing guides to legacy PPT reports a `CompatibilityIssue`. The save-stage callback can record the loss and continue, or reject it if preserving all guides is required.
- **Loading behavior:** Loading options and legacy behaviors can also produce warnings. For example, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifies use of an obsolete presentation-locking behavior as a `CompatibilityIssue`.

Warnings depend on the source document, target format, operation, and Aspose.Slides version. Do not assume that every file produces a warning or that a scenario always maps to only one category.

## **Safely Handle Aborted Operations**

When a callback returns `ReturnAction.Abort`, do not use an object that failed to load and do not assume that a rendering or save output is complete. The operation can terminate after creating an output file but before finishing it.

Save validated results to a separate path such as `validated-output.pptx`. Replace an existing presentation only after the operation finishes successfully, the warning report satisfies the application policy, and the output can be opened and checked. This avoids overwriting a valid source file with a partial or rejected result.

An empty warning report is not a guarantee that every source feature has been preserved. Apply any additional content and visual checks required by the application. See also [Open Presentations](/slides/net/open-presentation/) and [Save Presentations](/slides/net/save-presentation/).

## **FAQ**

**Can a warning callback handle every Aspose.Slides error?**

No. It handles recoverable conditions reported as warnings. Exceptions that occur independently of the callback must be handled by the application around the loading, rendering, conversion, or saving call.

**Does returning `ReturnAction.Continue` guarantee identical output?**

No. It only permits processing to continue. The reported condition can still cause data, formatting, or compatibility differences, so review the collected warning types and descriptions.

**How can an application identify the operation that produced a warning?**

Create a callback instance for each operation and store an application-defined stage together with `WarningType` and `Description`, as shown in the example.
