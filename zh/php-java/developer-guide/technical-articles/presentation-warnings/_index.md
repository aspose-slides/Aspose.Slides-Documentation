---
title: 在 PHP 中处理演示文稿警告
type: docs
weight: 90
url: /zh/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回调
- 警告策略
- 数据丢失
- 源损坏
- 兼容性问题
- 字体替换
- 数字签名
- 演示文稿加载
- 演示文稿渲染
- 演示文稿转换
- 演示文稿保存
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for PHP via Java 加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概述**

Aspose.Slides 在加载、渲染、转换或保存演示文稿时可以报告可恢复的问题。示例包括源记录损坏、无法保留的内容、字体替换以及目标格式的限制。警告回调允许应用程序记录这些情况并决定当前操作是否可以继续。

创建一个具有公共 `warning` 方法的 PHP 类，并通过 PHP Java Bridge 使用 `java_closure` 将其公开为 Java [IWarningCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarningcallback/) 接口。检查通过 [IWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 值。返回 [ReturnAction::Continue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/returnaction/#Continue) 以接受警告，或返回 [ReturnAction::Abort](https://reference.aspose.com/slides/zh/php-java/aspose.slides/returnaction/#Abort) 以停止操作。

在打开演示文稿时产生的警告请使用 [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setWarningCallback)。渲染和导出选项类继承自 [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveoptions/#setWarningCallback)，该回调接收来自幻灯片渲染、转换和保存的警告。由于警告本身并未标识应用程序的操作阶段，在构建综合报告时请将每个回调实例与相应的操作阶段关联起来。

## **警告和异常**

Java 异常通过 PHP Java Bridge 暴露给 PHP；请在操作边界捕获它们，如下例所示。本文中的 Java 接口链接描述了桥接使用的回调契约。

警告描述了一种 Aspose.Slides 在回调返回 `ReturnAction::Continue` 时能够恢复的情况。异常表示请求的操作无法正常完成；异常不会被转换为警告，也不能通过警告策略处理。

返回 `ReturnAction::Abort` 会让警告分发器通过抛出异常来终止当前操作。公开的异常取决于具体的操作和演示文稿格式。例如，加载时可能会出现 [PptxReadException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptreadexception/)，而保存或导出时可能会出现 [PptxException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxexception/)。在操作边界捕获异常，并使用警告报告来判断是否因应用程序策略导致终止，而不是仅凭一种异常子类型或信息。回调在返回 `ReturnAction::Abort` 之前会记录警告，确保原因对应用程序仍然可用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/) 类为以下类别提供整数常量：

| 警告类型 | 含义 | 典型策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#SourceFileCorruption) | 源演示文稿包含损坏，可能导致以原始格式保存的文档无法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#DataLoss) | 加载或保存后，文本、图表、图像或其他数据可能缺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | 演示文稿可能失去重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | 可能出现有限的格式差异。 | 记录用于诊断并继续。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#CompatibilityIssue) | 结果可能在某些应用或旧版本中无法打开或表现不正常。 | 记录并继续，除非兼容性是强制要求。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/warningtype/#UnexpectedContent) | 源包含不支持或未识别的内容，其影响可能尚未确定。 | 记录并继续，或在严格策略下视为错误。 |

类别应决定策略选择。将 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值存储用于诊断，但不要在业务逻辑中依赖其文字表述，因为消息文本会因警告场景和产品版本而不同。

## **收集和分类警告**

下面的示例为完整处理流水线使用一个应用级别的报告。不同的回调实例分别标记加载、渲染、PDF 转换和 PPTX 保存阶段的警告。策略在源损坏或数据丢失时中止，可选在重大格式丢失时中止，对其他警告则继续。回调在记录和比较之前使用 `java_values` 将警告值转换为原生 PHP 值。

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

在构造 `WarningPolicy` 时，如果接受重大格式差异，请为 `abortOnMajorFormattingLoss` 传入 `false`。即使操作继续，兼容性问题、次要格式丢失和意外内容仍会保留在报告中。如果应用程序必须拒绝这些类别中的任意一种，可扩展 `WarningPolicy::getAction`。

## **常见警告场景**

警告可以出现在工作流的不同阶段：

- **数字签名：** 对已签名的演示文稿，在加载时可能产生警告，指出其签名在处理过程中将会丢失。Aspose.Slides 通过 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationsignedwarninginfo/) 报告此 `DataLoss` 情况。加载阶段的回调允许应用程序拒绝该文件或显式接受报告的丢失。
- **字体替换：** 当幻灯片渲染或导出时，若字体不可用会被替换。字体替换警告以 `DataLoss` 报告，因此上述严格策略会在即使应用程序认为特定替换在视觉上可接受的情况下也会中止。要观察此行为，请使用包含运行时不可用字体的文本的输入演示稿。警告描述会标识替换的细节；请在重试前配置所需字体或 [font substitution rules](/slides/zh/php-java/font-substitution/)。
- **不受支持或意外的内容：** 加载器可能遇到未识别的演示文稿记录或特性。这类警告可能使用 `UnexpectedContent`，或在数据或格式已知受影响时使用更严重的类别。
- **格式兼容性：** 保存为其他演示文稿格式可能会省略特性或导致在某些应用程序中行为不同。例如，将包含超过八条水平或八条垂直绘图指南的演示文稿保存为旧版 PPT 时会报告 `CompatibilityIssue`。保存阶段的回调可以记录此损失并继续，或在需要保留所有指南时拒绝。
- **加载行为：** 加载选项和旧版行为也可能产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 将使用已废弃的演示文稿锁定行为标识为 `CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假设每个文件都会产生警告，也不要认为某一场景只能对应单一类别。

## **安全处理已中止的操作**

当回调返回 `ReturnAction::Abort` 时，不要使用加载失败的对象，也不要假设渲染或保存的输出已经完成。操作可能在创建输出文件后、完成之前就已终止。

将验证后的结果保存到诸如 `validated-output.pptx` 的独立路径。仅在操作成功完成、警告报告符合应用策略且输出文件能够打开并检查后，才替换已有的演示文稿。这样可避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不能保证所有源特性均已保留。请执行应用程序所需的其他内容和视觉检查。另请参阅 [Open Presentations](/slides/zh/php-java/open-presentation/) 和 [Save Presentations](/slides/zh/php-java/save-presentation/)。

## **常见问答**

**警告回调能处理所有 Aspose.Slides 错误吗？**

不能。它仅处理以警告形式报告的可恢复情况。独立于回调发生的异常必须由应用程序在加载、渲染、转换或保存调用的外围捕获处理。

**返回 `ReturnAction::Continue` 能保证输出完全相同吗？**

不能。它仅允许继续处理。报告的情况仍可能导致数据、格式或兼容性差异，请检查收集的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并像示例中那样将应用自定义的阶段与 [getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值一起存储。