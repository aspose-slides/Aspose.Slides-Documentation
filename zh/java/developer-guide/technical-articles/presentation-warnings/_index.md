---
title: 在 Java 中处理演示文稿警告
type: docs
weight: 90
url: /zh/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Java
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Java 加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概述**

Aspose.Slides 在加载、渲染、转换或保存演示文稿时可以报告可恢复的问题。示例包括损坏的源记录、无法保留的内容、字体替换以及目标格式的限制。警告回调允许应用程序记录这些情况并决定当前操作是否可以继续。

实现[IWarningCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarningcallback/)接口，并检查通过[IWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/)提供的[getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--)和[getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--)值。返回[ReturnAction.Continue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/returnaction/#Continue)以接受警告，或返回[ReturnAction.Abort](https://reference.aspose.com/slides/zh/java/com.aspose.slides/returnaction/#Abort)以停止操作。

使用[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)处理在打开演示文稿时产生的警告。渲染和导出选项类继承[SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)，该回调接收来自幻灯片渲染、转换和保存的警告。由于警告本身未指明应用程序的操作，构建综合报告时请将每个回调实例与操作阶段关联。

## **警告和异常**

警告描述的是如果回调返回`ReturnAction.Continue`，Aspose.Slides 能够恢复的情况。异常表示请求的操作无法正常完成；异常不会转换为警告，也不能通过警告策略处理。

返回`ReturnAction.Abort`会让警告调度器通过抛出异常来终止当前操作。公共异常取决于具体的操作和演示文稿格式。例如，加载时可能抛出[PptxReadException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxreadexception/)或[PptReadException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptreadexception/)，而保存或导出时可能抛出[PptxException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxexception/)。在操作边界处捕获异常，并使用警告报告来判断终止是否由应用程序策略导致，而不是只依赖某个异常子类型或消息。回调在返回`ReturnAction.Abort`之前记录警告，确保原因仍可供应用程序使用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/)类为以下类别提供整数常量：

| 警告类型 | 含义 | 典型策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#SourceFileCorruption) | 源演示文稿包含的损坏可能导致以原始格式保存的文档不可用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#DataLoss) | 加载或保存后，文本、图表、图像或其他数据可能缺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | 演示文稿可能失去重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | 可能出现有限的格式差异。 | 记录用于诊断并继续。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#CompatibilityIssue) | 结果在某些应用程序或旧版本中可能无法打开或表现不正确。 | 记录日志并继续，除非兼容性是强制要求。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/warningtype/#UnexpectedContent) | 源中包含未支持或未识别的内容，其影响尚不明确。 | 记录并继续，或在严格策略下视为错误。 |

类别应驱动策略决策。将[getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--)返回的值存储用于诊断，但不要在应用逻辑中依赖其文字表达，因为消息文本会因警告场景和产品版本而异。

## **收集和分类警告**

以下示例使用一个应用级别的报告来覆盖完整的处理管道。单独的回调实例为加载、渲染、PDF 转换和 PPTX 保存的警告标记阶段。策略在源损坏或数据丢失时中止，可选地在重大格式丢失时中止，其余警告则继续。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

在构造`WarningPolicy`时，如果可以接受重大格式差异，请将`abortOnMajorFormattingLoss`参数设为`false`。兼容性问题、次要格式丢失以及意外内容仍会保留在报告中，即使操作继续。若应用必须拒绝这些类别中的任何一种，请扩展`WarningPolicy.getAction`。

## **常见警告场景**

警告可能出现在工作流的不同阶段：

- **数字签名**：已签名的演示文稿在加载时可能产生警告，提示其签名将在处理过程中丢失。Aspose.Slides 通过[IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationsignedwarninginfo/)报告此`DataLoss`情况。加载阶段的回调可让应用程序拒绝文件或显式接受报告的丢失。
- **字体替换**：在渲染或导出幻灯片时，若所需字体不可用会被替换。字体替换警告被报告为`DataLoss`，因此上述严格策略会中止，即使应用程序认为特定替代在视觉上可接受。要观察此行为，请使用包含运行时不可用字体的文本的输入演示文稿。警告描述会标明替换的细节；在重试前配置所需字体或[字体替换规则](/slides/zh/java/font-substitution/)。
- **不支持或意外的内容**：加载器可能遇到未识别的演示文稿记录或特性。这类警告可能使用`UnexpectedContent`，或在已知数据或格式受影响时使用更严重的类别。
- **格式兼容性**：保存为其他演示文稿格式时可能会省略某些特性，或产生在某些应用程序中表现不同的结果。例如，将包含超过八条水平或八条垂直绘图指南的演示文稿保存为旧版 PPT 时会报告`CompatibilityIssue`。保存阶段的回调可以记录该损失并继续，或在必须保留所有指南时拒绝保存。
- **加载行为**：加载选项和旧行为也会产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/)将使用已废弃的演示文稿锁定行为标记为`CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假设每个文件都会产生警告，也不要假设某种场景始终映射到单一类别。

## **安全处理已中止的操作**

当回调返回`ReturnAction.Abort`时，不要使用加载失败的对象，也不要假设渲染或保存输出已完整。操作可能在创建输出文件后但在完成之前终止。

将验证后的结果保存到单独的路径，例如`validated-output.pptx`。仅在操作成功完成、警告报告满足应用策略且输出能够打开并检查后，才替换已有的演示文稿。这样可避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不保证每个源特性都已保留。请执行应用程序所需的任何额外内容和视觉检查。另见[打开演示文稿](/slides/zh/java/open-presentation/)和[保存演示文稿](/slides/zh/java/save-presentation/)。

## **FAQ**

**警告回调能处理每个 Aspose.Slides 错误吗？**

不能。它只能处理被报告为警告的可恢复情况。独立于回调出现的异常必须在加载、渲染、转换或保存调用周围由应用程序自行处理。

**返回`ReturnAction.Continue`是否保证输出完全相同？**

不能。它仅允许处理继续。报告的情况仍可能导致数据、格式或兼容性差异，因此需要检查收集到的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并在其中存储应用自定义的阶段信息以及[getWarningType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getWarningType--)和[getDescription](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iwarninginfo/#getDescription--)返回的值，如示例所示。