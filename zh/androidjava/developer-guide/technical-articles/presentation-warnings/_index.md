---
title: 处理 Android 上的演示文稿警告
type: docs
weight: 90
url: /zh/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（通过 Java）在加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概述**

Aspose.Slides 在加载、渲染、转换或保存演示文稿时可以报告可恢复的问题。示例包括受损的源记录、无法保留的内容、字体替换以及目标格式的限制。警告回调允许运用程序记录这些情况并决定当前操作是否可以继续。

实现 [IWarningCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarningcallback/) 接口并检查通过 [IWarningInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 值。返回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/returnaction/#Continue) 接受警告，或返回 [ReturnAction.Abort](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/returnaction/#Abort) 停止操作。

使用 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 来处理打开演示文稿时产生的警告。渲染和导出选项类继承自 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)，该方法接收来自幻灯片渲染、转换和保存的警告。由于警告本身未标识应用程序的操作，在构建综合报告时请将每个回调实例与相应的操作阶段关联。

## **警告和异常**

警告描述了一种 Aspose.Slides 可以通过回调返回 `ReturnAction.Continue` 来恢复的情况。异常表示请求的操作无法正常完成；异常不会转换为警告，也无法通过警告策略处理。

返回 `ReturnAction.Abort` 会让警告分发器通过抛出异常来终止当前操作。公开的异常取决于操作和演示文稿格式。例如，加载时可能抛出 [PptxReadException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptreadexception/)，而保存或导出时可能抛出 [PptxException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxexception/)。在操作边界处处理异常，并使用警告报告来判断是否因应用程序策略导致终止，而不是仅依赖某一异常子类型或消息。回调在返回 `ReturnAction.Abort` 之前记录警告，确保原因对应用程序仍然可用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/) 类为以下类别提供整数常量：

| 警告类型 | 含义 | 常见策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | 源演示文稿包含损坏，可能导致以原始格式保存的文档无法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#DataLoss) | 加载或保存后可能缺少文本、图表、图像或其他数据。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | 演示文稿可能丢失重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | 可能出现有限的格式差异。 | 记录以供诊断并继续。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | 结果可能在某些应用或旧版本中无法打开或行为不正确。 | 记录日志并继续，除非兼容性是强制要求。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | 源包含不受支持或未识别的内容，其影响可能尚未知。 | 记录并继续，或在严格策略下视为错误。 |

类别应决定策略。将 [getDescription](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值存储用于诊断，但不要在应用逻辑中依赖其文字描述，因为消息文本可能在不同警告场景和产品版本间有所差异。

## **收集和分类警告**

下面的示例为完整的处理管道使用一个应用级报告。单独的回调实例为加载、渲染、PDF 转换和 PPTX 保存产生的警告打标签。策略在源损坏或数据丢失时中止，可选地在重大格式丢失时中止，其他警告则继续。

将 `input.pptx` 放在可写的应用目录中，并将该目录传递给 `PresentationWarningExample.run`。示例将输出保存到同一目录。请在后台线程上运行演示处理，以保持 Android 用户界面响应。

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

在构造 `WarningPolicy` 时，如果接受重大格式差异，请为 `abortOnMajorFormattingLoss` 传入 `false`。即使操作继续，兼容性问题、次要格式丢失和意外内容仍会保留在报告中。如果应用必须拒绝这些类别中的任何一种，请扩展 `WarningPolicy.getAction`。

## **常见警告场景**

警告可能出现在工作流的不同阶段：

- **数字签名：** 已签名的演示文稿在加载时可能产生警告，提示其签名将在处理过程中丢失。Aspose.Slides 通过 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) 报告此 `DataLoss` 状况。加载阶段的回调可让应用程序拒绝文件或明确接受报告的丢失。
- **字体替换：** 当幻灯片渲染或导出时，若缺少字体会被替换。字体替换警告以 `DataLoss` 形式报告，因此上述严格策略会中止，即使应用认为特定替换在视觉上可接受。要观察此行为，请使用包含运行时不可用字体的文本的输入演示文稿。警告描述会指出替换细节；在重试前配置所需字体或 [font substitution rules](/slides/zh/androidjava/font-substitution/)。
- **不受支持或意外内容：** 加载器可能遇到它不识别的演示文稿记录或特性。此类警告可能使用 `UnexpectedContent`，或者在已知数据或格式受影响时使用更严重的类别。
- **格式兼容性：** 保存为其他演示文稿格式可能会省略某些特性，或导致结果在某些应用中行为不同。例如，将包含超过八个水平或八个垂直绘图指南的演示文稿保存为旧版 PPT 会产生 `CompatibilityIssue`。保存阶段的回调可以记录此损失并继续，或在需要保留所有指南时拒绝。
- **加载行为：** 加载选项和旧行为也可能产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 将使用已废弃的演示锁定行为标识为 `CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假设每个文件都会产生警告，或某个场景始终映射到唯一类别。

## **安全处理已中止的操作**

当回调返回 `ReturnAction.Abort` 时，勿使用加载失败的对象，也不要假设渲染或保存的输出已完整。操作可能在创建输出文件后、完成之前就终止。

将验证后的结果保存到单独的路径，例如 `validated-output.pptx`。仅在操作成功完成、警告报告符合应用策略且输出能够打开检查后，才替换已有演示文稿。这样可避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不保证已保留每个源特性。请执行应用所需的任何额外内容和视觉检查。另见 [Open Presentations](/slides/zh/androidjava/open-presentation/) 和 [Save Presentations](/slides/zh/androidjava/save-presentation/)。

## **常见问答**

**警告回调能处理每个 Aspose.Slides 错误吗？**

不能。它仅处理作为警告报告的可恢复情况。独立于回调发生的异常必须由应用在加载、渲染、转换或保存调用周围进行处理。

**返回 `ReturnAction.Continue` 能保证输出完全相同吗？**

不能。它仅允许继续处理。报告的情况仍可能导致数据、格式或兼容性差异，因此需要检查收集的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并将应用自定义的阶段与 [getWarningType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 返回的值一起存储，如示例所示。