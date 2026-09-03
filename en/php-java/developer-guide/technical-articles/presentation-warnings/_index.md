---
title: Handle Presentation Warnings in PHP
type: docs
weight: 90
url: /php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- PHP
- Aspose.Slides
description: "Learn how to collect, classify, and act on warnings while loading, rendering, converting, and saving presentations with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides can report recoverable problems while it loads, renders, converts, or saves a presentation. Examples include damaged source records, content that cannot be preserved, font substitution, and limitations of a target format. A warning callback lets an application record these conditions and decide whether the current operation may continue.

Create a PHP class with a public `warning` method and expose it through PHP Java Bridge as the Java [IWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iwarningcallback/) interface using `java_closure`. Examine the [getWarningType](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/#getWarningType--) and [getDescription](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/#getDescription--) values supplied through [IWarningInfo](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/). Return [ReturnAction::Continue](https://reference.aspose.com/slides/php-java/aspose.slides/returnaction/#Continue) to accept the warning or [ReturnAction::Abort](https://reference.aspose.com/slides/php-java/aspose.slides/returnaction/#Abort) to stop the operation.

Use [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setWarningCallback) for warnings raised while opening a presentation. Rendering and export option classes inherit [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback), which receives warnings from slide rendering, conversion, and saving. Because the warning itself does not identify the application operation, associate each callback instance with an operation stage when you build a combined report.

## **Warnings and Exceptions**

Java exceptions are exposed to PHP through PHP Java Bridge; catch them at the operation boundary, as shown in the example below. The Java interface links in this article describe the callback contract used by the bridge.

A warning describes a condition from which Aspose.Slides can recover if the callback returns `ReturnAction::Continue`. An exception means the requested operation cannot complete normally; exceptions are not converted into warnings and cannot be handled by a warning policy.

Returning `ReturnAction::Abort` asks the warning dispatcher to terminate the current operation by raising an exception. The public exception depends on the operation and presentation format. For example, loading can surface a [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) or [PptReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptreadexception/), while saving or exporting can surface a [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/). Handle the exception at the boundary of the operation and use the warning report to determine whether the application policy caused the termination instead of relying on one exception subtype or message. The callback records the warning before returning `ReturnAction::Abort`, ensuring that the reason remains available to the application.

## **Warning Categories**

The [WarningType](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/) class provides integer constants for the following categories:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#SourceFileCorruption) | The source presentation contains corruption that can make a document saved in its original format unusable. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#DataLoss) | Text, charts, images, or other data may be absent after loading or saving. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | The presentation may lose important formatting. | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | A limited formatting difference may occur. | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#CompatibilityIssue) | The result may not open or behave correctly in some applications or older versions. | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/php-java/aspose.slides/warningtype/#UnexpectedContent) | The source contains unsupported or unrecognized content whose effect may not yet be known. | Record and continue, or treat as an error in a strict policy. |

The category should drive the policy decision. Store the value returned by [getDescription](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/#getDescription--) for diagnostics, but do not depend on its wording for application logic because message text can vary between warning scenarios and product versions.

## **Collect and Classify Warnings**

The following example uses one application-level report for the complete processing pipeline. A separate callback instance labels warnings from loading, rendering, PDF conversion, and PPTX saving. The policy aborts on source corruption or data loss, optionally aborts on major formatting loss, and continues for other warnings. The callback converts warning values to native PHP values with `java_values` before recording and comparing them.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Pass `false` for `abortOnMajorFormattingLoss` when constructing `WarningPolicy` if major formatting differences are acceptable. Compatibility issues, minor formatting loss, and unexpected content are still retained in the report even when the operation continues. Extend `WarningPolicy::getAction` if the application must reject any of those categories.

## **Common Warning Scenarios**

Warnings can appear at different stages of a workflow:

- **Digital signatures:** A signed presentation can produce a warning during loading that its signature will be lost during processing. Aspose.Slides reports this `DataLoss` condition through [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationsignedwarninginfo/). A load-stage callback lets the application reject the file or explicitly accept the reported loss.
- **Font substitution:** An unavailable font can be replaced while a slide is rendered or exported. Font substitution warnings are reported as `DataLoss`, so the strict policy above aborts even if the application would consider a particular replacement visually acceptable. To observe this behavior, use an input presentation containing text in a font unavailable to the runtime. The warning description identifies the substitution; configure the required fonts or [font substitution rules](/slides/php-java/font-substitution/) before retrying.
- **Unsupported or unexpected content:** A loader can encounter presentation records or features it does not recognize. Such warnings may use `UnexpectedContent`, or a more severe category when data or formatting is known to be affected.
- **Format compatibility:** Saving to another presentation format can omit features or produce a result that behaves differently in some applications. For example, saving a presentation with more than eight horizontal or eight vertical drawing guides to legacy PPT reports a `CompatibilityIssue`. The save-stage callback can record the loss and continue, or reject it if preserving all guides is required.
- **Loading behavior:** Loading options and legacy behaviors can also produce warnings. For example, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifies use of an obsolete presentation-locking behavior as a `CompatibilityIssue`.

Warnings depend on the source document, target format, operation, and Aspose.Slides version. Do not assume that every file produces a warning or that a scenario always maps to only one category.

## **Safely Handle Aborted Operations**

When a callback returns `ReturnAction::Abort`, do not use an object that failed to load and do not assume that a rendering or save output is complete. The operation can terminate after creating an output file but before finishing it.

Save validated results to a separate path such as `validated-output.pptx`. Replace an existing presentation only after the operation finishes successfully, the warning report satisfies the application policy, and the output can be opened and checked. This avoids overwriting a valid source file with a partial or rejected result.

An empty warning report is not a guarantee that every source feature has been preserved. Apply any additional content and visual checks required by the application. See also [Open Presentations](/slides/php-java/open-presentation/) and [Save Presentations](/slides/php-java/save-presentation/).

## **FAQ**

**Can a warning callback handle every Aspose.Slides error?**

No. It handles recoverable conditions reported as warnings. Exceptions that occur independently of the callback must be handled by the application around the loading, rendering, conversion, or saving call.

**Does returning `ReturnAction::Continue` guarantee identical output?**

No. It only permits processing to continue. The reported condition can still cause data, formatting, or compatibility differences, so review the collected warning types and descriptions.

**How can an application identify the operation that produced a warning?**

Create a callback instance for each operation and store an application-defined stage together with the values returned by [getWarningType](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/#getWarningType--) and [getDescription](https://reference.aspose.com/slides/java/com.aspose.slides/iwarninginfo/#getDescription--), as shown in the example.
