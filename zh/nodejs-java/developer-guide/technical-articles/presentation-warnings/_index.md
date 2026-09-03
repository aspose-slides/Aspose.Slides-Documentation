---
title: 在 Node.js 中处理演示文稿警告
type: docs
weight: 90
url: /zh/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Node.js via Java 加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概述**

Aspose.Slides 可以在加载、渲染、转换或保存演示文稿时报告可恢复的问题。示例包括受损的源记录、无法保留的内容、字体替换以及目标格式的限制。警告回调允许应用程序记录这些情况并决定当前操作是否可以继续。

使用 `java.newProxy` 在 JavaScript 中实现 [IWarningCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarningcallback/) Java 接口，并检查通过 [IWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 值。返回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/returnaction/#Continue) 以接受警告，或返回 [ReturnAction.Abort](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/returnaction/#Abort) 以停止操作。

在打开演示文稿时产生的警告请使用 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setWarningCallback)。渲染和导出选项类继承自 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)，该回调会接收来自幻灯片渲染、转换和保存的警告。由于警告本身并未标识应用程序的具体操作，构建合并报告时请将每个回调实例与相应的操作阶段关联起来。

## **警告和异常**

警告描述了一种 Aspose.Slides 可以在回调返回 `ReturnAction.Continue` 时恢复的情况。异常表示请求的操作无法正常完成；异常不会转换为警告，也无法通过警告策略进行处理。

返回 `ReturnAction.Abort` 会请求警告分发器通过抛出异常来终止当前操作。公开的异常类型取决于具体的操作和演示文稿格式。例如，加载时可能会出现 [PptxReadException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptreadexception/)，而保存或导出时可能会出现 [PptxException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxexception/)。在操作边界捕获来自 Java 桥接的错误，并使用警告报告来判断是否由于应用程序策略导致终止，而不是仅依赖某一异常子类型或消息。回调在返回 `ReturnAction.Abort` 之前记录警告，确保原因对应用程序仍然可用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/) 类提供以下类别的整数常量：

| 警告类型 | 含义 | 典型策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | 源演示文稿包含的损坏可能导致以原始格式保存的文档不可用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#DataLoss) | 加载或保存后，文本、图表、图像或其他数据可能缺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | 演示文稿可能失去重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | 可能出现有限的格式差异。 | 记录用于诊断并继续。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | 结果可能无法在某些应用程序或旧版本中打开或正常工作。 | 记录并继续，除非兼容性是强制要求。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | 源中包含不受支持或未识别的内容，其影响可能尚不清楚。 | 记录并继续，或在严格策略中视为错误。 |

类别应驱动策略决策。将 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值存储用于诊断，但不要在应用逻辑中依赖其文字表述，因为消息文本可能因警告场景和产品版本而不同。

## **收集和分类警告**

以下 JavaScript 示例为完整的处理管道使用一个应用程序级别的报告。单独的回调实例会标记加载、渲染、PDF 转换和 PPTX 保存产生的警告。策略在源损坏或数据丢失时中止，可选地在重大格式丢失时中止，并对其他警告继续处理。

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

在构造 `WarningPolicy` 时，如果可以接受重大格式差异，请为 `abortOnMajorFormattingLoss` 传入 `false`。即使操作继续，兼容性问题、轻微格式丢失和未预期内容仍会保留在报告中。如果应用程序必须拒绝上述任何类别，请扩展 `WarningPolicy.getAction`。

## **常见警告场景**

警告可能出现在工作流的不同阶段：

- **数字签名：** 在加载期间，已签名的演示文稿可能会产生警告，指出其签名将在处理过程中丢失。Aspose.Slides 通过 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationsignedwarninginfo/) 报告此 `DataLoss` 情况。加载阶段的回调允许应用程序拒绝该文件或显式接受报告的丢失。
- **字体替换：** 当幻灯片渲染或导出时，无法使用的字体可能被替换。字体替换警告以 `DataLoss` 形式报告，因此上述严格策略会中止，即使应用程序可能认为特定替换在视觉上是可接受的。要观察此行为，请使用包含运行时不可用字体的文本的输入演示文稿。警告描述会标识替换情况；在重试前配置所需字体或 [font substitution rules](/slides/zh/nodejs-java/font-substitution/)。
- **不受支持或意外内容：** 加载器可能遇到它不识别的演示文稿记录或功能。这类警告可能使用 `UnexpectedContent`，或在数据或格式已知受影响时使用更严重的类别。
- **格式兼容性：** 保存为其他演示文稿格式时可能会省略某些功能或导致结果在某些应用程序中表现不同。例如，将包含超过八条水平或八条垂直绘图指南的演示文稿保存为旧版 PPT 时会报告 `CompatibilityIssue`。保存阶段的回调可以记录此丢失并继续，或在必须保留所有指南时拒绝它。
- **加载行为：** 加载选项和旧行为也可能产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 将使用过时的演示文稿锁定行为标识为 `CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假设每个文件都会产生警告，或某个场景总是映射到唯一的类别。

## **安全处理已中止的操作**

当回调返回 `ReturnAction.Abort` 时，不要使用加载失败的对象，也不要假设渲染或保存的输出已完成。操作可能在创建输出文件后但在完成之前终止。

将验证后的结果保存到单独的路径，例如 `validated-output.pptx`。仅在操作成功完成、警告报告符合应用程序策略且输出能够打开并检查后，才替换现有演示文稿。这样可以避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不能保证所有源特性都已保留。请执行应用程序要求的任何额外内容和视觉检查。另请参阅 [Open Presentations](/slides/zh/nodejs-java/open-presentation/) 和 [Save Presentations](/slides/zh/nodejs-java/save-presentation/)。

## **常见问题**

**警告回调能够处理所有 Aspose.Slides 错误吗？**

不能。它仅处理以警告形式报告的可恢复情况。独立于回调发生的异常必须由应用程序在加载、渲染、转换或保存调用的周围进行处理。

**返回 `ReturnAction.Continue` 能保证输出完全相同吗？**

不能。它仅允许继续处理。报告的情况仍可能导致数据、格式或兼容性差异，因此需要检查收集到的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并将应用程序自定义的阶段与 [getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值一起存储，如示例所示。