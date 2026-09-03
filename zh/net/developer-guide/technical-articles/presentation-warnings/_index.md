---
title: 处理 .NET 中的演示文稿警告
type: docs
weight: 120
url: /zh/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回调
- 警告策略
- 数据丢失
- 源文件损坏
- 兼容性问题
- 字体替换
- 数字签名
- 演示文稿加载
- 演示文稿渲染
- 演示文稿转换
- 演示文稿保存
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for .NET 加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概览**

Aspose.Slides 在加载、渲染、转换或保存演示文稿时可能会报告可恢复的问题。示例包括损坏的源记录、无法保留的内容、字体替换以及目标格式的限制。警告回调允许应用程序记录这些情况并决定当前操作是否可以继续。

实现[IWarningCallback](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/iwarningcallback/)接口并检查通过[IWarningInfo](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/iwarninginfo/)提供的[WarningType](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/iwarninginfo/warningtype/)和[Description](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/iwarninginfo/description/)属性。返回[ReturnAction.Continue](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/returnaction/)接受警告，或返回`ReturnAction.Abort`停止操作。

在打开演示文稿时使用[LoadOptions.WarningCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/warningcallback/)获取警告。渲染和导出选项类继承自[SaveOptions.WarningCallback](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveoptions/warningcallback/)，该回调接收来自幻灯片渲染、转换和保存的警告。由于警告本身不标识应用操作，在构建综合报告时请将每个回调实例与操作阶段关联。

## **警告和异常**

警告描述了 Aspose.Slides 在回调返回`ReturnAction.Continue`时可以恢复的情况。异常表示请求的操作无法正常完成；异常不会转换为警告，也无法通过警告策略处理。

返回`ReturnAction.Abort`会让警告分发器通过抛出异常终止当前操作。公开的异常取决于操作和演示文稿格式。例如，加载时可能会抛出[PptxReadException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxreadexception/)或[PptReadException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptreadexception/)，而保存或导出时可能会抛出[PptxException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxexception/)。在操作边界捕获异常，并使用警告报告判断是否因应用策略导致终止，而不是仅依赖某个异常子类型或消息。回调在返回`ReturnAction.Abort`之前记录警告，确保原因对应用程序仍然可用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/warningtype/) 枚举提供以下类别：

| 警告类型 | 含义 | 典型策略 |
| --- | --- | --- |
| `SourceFileCorruption` | 源演示文稿包含损坏，可能导致以原始格式保存的文档无法使用。 | 中止。 |
| `DataLoss` | 加载或保存后可能缺少文本、图表、图像或其他数据。 | 中止。 |
| `MajorFormattingLoss` | 演示文稿可能失去重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| `MinorFormattingLoss` | 可能出现有限的格式差异。 | 记录诊断信息并继续。 |
| `CompatibilityIssue` | 结果在某些应用或旧版本中可能无法打开或行为异常。 | 记录日志并继续，除非兼容性是强制要求。 |
| `UnexpectedContent` | 源包含不受支持或未识别的内容，其影响尚不明确。 | 记录并继续，或在严格策略下视为错误。 |

类别应驱动策略决策。保存 `Description` 供诊断使用，但不要将其文本作为应用逻辑的依据，因为消息文本可能因警告场景和产品版本而异。

## **收集与分类警告**

下面的示例在完整的处理管道中使用一个应用级报告。单独的回调实例为加载、渲染、PDF 转换和 PPTX 保存标记警告。策略在源文件损坏或数据丢失时中止，可选地在出现重大格式丢失时中止，对其他警告继续处理。

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

当可以接受重大格式差异时，将 `abortOnMajorFormattingLoss` 设置为 `false`。兼容性问题、次要格式丢失和意外内容仍会保留在报告中，即使操作继续。如果应用必须拒绝这些类别中的任何一种，请扩展 `WarningPolicy.GetAction`。

## **常见警告场景**

警告可能出现在工作流的不同阶段：

- **数字签名**：已签名的演示文稿在加载时可能产生警告，提示签名将在处理过程中丢失。Aspose.Slides 通过[IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/ipresentationsignedwarninginfo/)报告此 `DataLoss` 情况。加载阶段的回调可让应用程序拒绝文件或显式接受报告的损失。
- **字体替换**：在渲染或导出幻灯片时，未找到的字体可能被替换。字体替换警告以 `DataLoss` 形式报告，因此上述严格策略会中止，即使应用认为特定替换在视觉上是可接受的。要观察此行为，请使用包含运行时不可用字体的文本的输入演示文稿。警告描述会指出替换的字体；在重试之前配置所需字体或[字体替换规则](/slides/zh/net/font-substitution/)。
- **不受支持或意外的内容**：加载器可能遇到未识别的演示文稿记录或特性。此类警告可能使用 `UnexpectedContent`，或在已知数据或格式受到影响时使用更严重的类别。
- **格式兼容性**：保存为其他演示文稿格式可能会省略特性或导致结果在某些应用中表现不同。例如，将包含超过八条水平或垂直绘图指南的演示文稿保存为旧版 PPT 时会报告 `CompatibilityIssue`。保存阶段的回调可以记录此损失并继续，或在必须保留所有指南时拒绝保存。
- **加载行为**：加载选项和旧行为也可能产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) 将使用已废弃的演示文稿锁定行为标记为 `CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假设每个文件都会产生警告，也不要认为某一场景只能映射到单一类别。

## **安全处理已中止的操作**

当回调返回 `ReturnAction.Abort` 时，不要使用加载失败的对象，也不要假设渲染或保存输出已完整。操作可能在创建输出文件后但在完成之前终止。

将验证后的结果保存到单独的路径，例如 `validated-output.pptx`。仅在操作成功完成、警告报告符合应用策略且输出可以打开并检查后，才替换已有的演示文稿。这可以避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不保证每个源特性都已保留。请执行应用程序要求的任何额外内容和视觉检查。另请参阅[打开演示文稿](/slides/zh/net/open-presentation/)和[保存演示文稿](/slides/zh/net/save-presentation/)。

## **常见问题**

**警告回调能处理所有 Aspose.Slides 错误吗？**

不能。它只处理以警告形式报告的可恢复情况。必须在加载、渲染、转换或保存调用的外层由应用程序处理独立于回调的异常。

**返回 `ReturnAction.Continue` 能保证输出完全相同吗？**

不能。它仅允许继续处理。报告的情况仍可能导致数据、格式或兼容性差异，请检查收集到的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并在存储 `WarningType` 和 `Description` 时一起保存应用定义的阶段，如示例所示。