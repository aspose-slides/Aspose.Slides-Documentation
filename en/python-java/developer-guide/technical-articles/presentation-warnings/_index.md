---
title: Handle Presentation Warnings in Python via Java
type: docs
weight: 90
url: /python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Learn how to collect, classify, and act on warnings while loading, rendering, converting, and saving presentations with Aspose.Slides for Python via Java."
---

## **Overview**

Aspose.Slides can report recoverable problems while it loads, renders, converts, or saves a presentation. Examples include damaged source records, content that cannot be preserved, font substitution, and limitations of a target format. A warning callback lets an application record these conditions and decide whether the current operation may continue.

Implement the `IWarningCallback` interface through `jpype.JProxy` and examine the `getWarningType` and `getDescription` values supplied through `IWarningInfo`. Return [ReturnAction.Continue](https://reference.aspose.com/slides/python-java/aspose.slides/returnaction/#Continue) to accept the warning or [ReturnAction.Abort](https://reference.aspose.com/slides/python-java/aspose.slides/returnaction/#Abort) to stop the operation.

Use [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setWarningCallback) for warnings raised while opening a presentation. Rendering and export option classes inherit [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback), which receives warnings from slide rendering, conversion, and saving. Because the warning itself does not identify the application operation, associate each callback instance with an operation stage when you build a combined report.

## **Warnings and Exceptions**

A warning describes a condition from which Aspose.Slides can recover if the callback returns `ReturnAction.Continue`. An exception means the requested operation cannot complete normally; exceptions are not converted into warnings and cannot be handled by a warning policy.

Returning `ReturnAction.Abort` asks the warning dispatcher to terminate the current operation by raising an exception. The public exception depends on the operation and presentation format. For example, loading can surface a [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) or [PptReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptreadexception/), while saving or exporting can surface a [PptxException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxexception/). Handle the exception at the boundary of the operation and use the warning report to determine whether the application policy caused the termination instead of relying on one exception subtype or message. The callback records the warning before returning `ReturnAction.Abort`, ensuring that the reason remains available to the application.

## **Warning Categories**

The [WarningType](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/) class provides integer constants for the following categories:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#SourceFileCorruption) | The source presentation contains corruption that can make a document saved in its original format unusable. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#DataLoss) | Text, charts, images, or other data may be absent after loading or saving. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | The presentation may lose important formatting. | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | A limited formatting difference may occur. | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#CompatibilityIssue) | The result may not open or behave correctly in some applications or older versions. | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/python-java/aspose.slides/warningtype/#UnexpectedContent) | The source contains unsupported or unrecognized content whose effect may not yet be known. | Record and continue, or treat as an error in a strict policy. |

The category should drive the policy decision. Store the value returned by `getDescription` for diagnostics, but do not depend on its wording for application logic because message text can vary between warning scenarios and product versions.

## **Collect and Classify Warnings**

The following example uses one application-level report for the complete processing pipeline. A separate callback instance labels warnings from loading, rendering, PDF conversion, and PPTX saving. The policy aborts on source corruption or data loss, optionally aborts on major formatting loss, and continues for other warnings.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Pass `False` for `abort_on_major_formatting_loss` when constructing `WarningPolicy` if major formatting differences are acceptable. Compatibility issues, minor formatting loss, and unexpected content are still retained in the report even when the operation continues. Extend `WarningPolicy.get_action` if the application must reject any of those categories.

## **Common Warning Scenarios**

Warnings can appear at different stages of a workflow:

- **Digital signatures:** A signed presentation can produce a warning during loading that its signature will be lost during processing. Aspose.Slides reports this `DataLoss` condition through `IPresentationSignedWarningInfo`. A load-stage callback lets the application reject the file or explicitly accept the reported loss.
- **Font substitution:** An unavailable font can be replaced while a slide is rendered or exported. Font substitution warnings are reported as `DataLoss`, so the strict policy above aborts even if the application would consider a particular replacement visually acceptable. To observe this behavior, use an input presentation containing text in a font unavailable to the runtime. The warning description identifies the substitution; configure the required fonts or [font substitution rules](/slides/python-java/font-substitution/) before retrying.
- **Unsupported or unexpected content:** A loader can encounter presentation records or features it does not recognize. Such warnings may use `UnexpectedContent`, or a more severe category when data or formatting is known to be affected.
- **Format compatibility:** Saving to another presentation format can omit features or produce a result that behaves differently in some applications. For example, saving a presentation with more than eight horizontal or eight vertical drawing guides to legacy PPT reports a `CompatibilityIssue`. The save-stage callback can record the loss and continue, or reject it if preserving all guides is required.
- **Loading behavior:** Loading options and legacy behaviors can also produce warnings. For example, `IObsoletePresLockingBehaviorWarningInfo` identifies use of an obsolete presentation-locking behavior as a `CompatibilityIssue`.

Warnings depend on the source document, target format, operation, and Aspose.Slides version. Do not assume that every file produces a warning or that a scenario always maps to only one category.

## **Safely Handle Aborted Operations**

When a callback returns `ReturnAction.Abort`, do not use an object that failed to load and do not assume that a rendering or save output is complete. The operation can terminate after creating an output file but before finishing it.

Save validated results to a separate path such as `validated-output.pptx`. Replace an existing presentation only after the operation finishes successfully, the warning report satisfies the application policy, and the output can be opened and checked. This avoids overwriting a valid source file with a partial or rejected result.

An empty warning report is not a guarantee that every source feature has been preserved. Apply any additional content and visual checks required by the application. See also [Open Presentations](/slides/python-java/open-presentation/) and [Save Presentations](/slides/python-java/save-presentation/).

## **FAQ**

**Can a warning callback handle every Aspose.Slides error?**

No. It handles recoverable conditions reported as warnings. Exceptions that occur independently of the callback must be handled by the application around the loading, rendering, conversion, or saving call.

**Does returning `ReturnAction.Continue` guarantee identical output?**

No. It only permits processing to continue. The reported condition can still cause data, formatting, or compatibility differences, so review the collected warning types and descriptions.

**How can an application identify the operation that produced a warning?**

Create a callback instance for each operation and store an application-defined stage together with the values returned by `getWarningType` and `getDescription`, as shown in the example.

