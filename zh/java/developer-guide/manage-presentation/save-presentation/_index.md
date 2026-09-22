---
title: 在 Java 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/java/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿保存为文件
- 演示文稿保存为流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint 和 OpenDocument 演示文稿保存到文件或流，并配置 PPTX 输出和进度报告。"
---
## **概述**

创建演示文稿或[打开现有演示文稿](/slides/zh/java/open-presentation/)后，使用[Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-)方法写入结果。Aspose.Slides for Java 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等格式。以下章节介绍标准保存操作以及 PPTX 输出的可用选项。

## **将演示文稿保存到文件**

要将演示文稿保存到文件，向[Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-)方法传递输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)值。该格式值决定 Aspose.Slides 创建的文件类型。

下面的示例创建一个演示文稿并将其保存为 PPTX 文件：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // 在此添加或修改演示文稿内容。

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以原始格式保存演示文稿**

有关文件和流检测示例、新创建演示文稿的行为以及源格式与输出格式的区别，请参阅[确定原始演示文稿格式](/slides/zh/java/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，可通过[IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getSourceFormat--)方法读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/sourceformat/)值传递给[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideutil/#toSaveFormat-int-)以获取对应的[SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)值，然后使用[Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-)写入已修改的演示文稿。

下面的完整示例处理输入目录中的每个文件，更新其标题，并按加载时的格式保存到输出目录：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideutil/#toSaveFormat-int-)将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到相应的演示文稿保存格式。它仅映射演示文稿源格式；并非用于选择 PDF、HTML、TIFF 或图像等导出格式。传递不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/sourceformat/)值会导致[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

旧版 PPT、PPS 和 POT 文件使用相同的二进制容器。从没有文件扩展名的流加载此类演示文稿时，PPS 或 POT 文件可能会被识别为 PPT。如果需要保留这些旧子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它。

## **将演示文稿保存到流**

要在不依赖最终文件路径的情况下写入演示文稿，请向[Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)方法传递可写流和一个[SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)值。当输出必须从 Web 服务返回、存储在数据库中或在内存中处理时，此方法非常有用。

下面的示例将新演示文稿保存到文件流：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用预定义视图类型保存演示文稿**

可以指定 PowerPoint 打开已保存演示文稿时的初始视图。保存前，使用带有[ViewType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewtype/)值的[ViewProperties.setLastView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#setLastView-int-)方法。

下面的示例将 Slide Master 视图配置为初始视图：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，实例化一个[PptxOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/)并使用其[setConformance](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/#setConformance-int-)方法，传入[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)。随后将该选项传递给[Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法。

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

标准 ZIP 存档对每个条目的压缩和未压缩大小、总存档大小以及条目数量都有限制。由于 PPTX 文件本身是 ZIP 存档，特别大的演示文稿可能会超出这些限制。ZIP64 扩展提升了相关的大小和条目计数限制。

使用[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-)方法控制 Aspose.Slides 是否写入 ZIP64 扩展：

- [IfNecessary](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#IfNecessary)仅在演示文稿超出标准 ZIP 限制时使用 ZIP64。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Never)禁用 ZIP64 扩展。
- [Always](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Always)始终写入 ZIP64 扩展。

下面的示例始终为输出演示文稿启用 ZIP64 扩展：

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode.Never](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Never)且演示文稿无法适应标准 ZIP 限制，保存操作会抛出[PptxException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **使用压缩级别在 Office Open XML 格式下保存演示文稿**

针对 PPTX 输出，可以通过[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-)方法在保存速度与文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/)类提供以下值：

- [None](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#None)不进行压缩。
- [Level1](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level1)提供最快的压缩速度和最大的压缩后文件。
- [Level2](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level2)至[Level5](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level5)逐步倾向于更小的输出而牺牲保存速度。
- [Level6](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level6)在保存速度和文件大小之间取得平衡。这是默认级别。
- [Level7](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level7)和[Level8](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level8)进一步倾向于更小的输出。
- [Level9](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level9)提供最强的压缩，但需要最长的处理时间。

下面的示例在不进行压缩的情况下保存演示文稿：

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

下面的示例使用最高压缩级别：

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **保存演示文稿时不刷新缩略图**

当演示文稿以 PPTX 格式保存时，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)方法控制文档缩略图的生成：

- `true` 在保存过程中重新生成缩略图。默认值即为 `true`。
- `false` 保持现有缩略图不变。如果演示文稿没有缩略图，Aspose.Slides 不会生成。

下面的示例在保存演示文稿时不刷新其缩略图：

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以减少保存 PPTX 文件所需的时间。
{{% /alert %}}

## **以百分比形式提供保存进度更新**

要监控保存过程，需实现[IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/)接口并将实现传递给[ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-)方法。Aspose.Slides 随后会在导出期间调用[IProgressCallback.reporting](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/#reporting-double-)方法并传递进度值。

下面的示例将 PDF 导出的进度报告到控制台：

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个基于 Aspose.Slides API 的免费[PowerPoint 拆分器](https://products.aspose.app/slides/zh/splitter)。它可以将演示文稿的选定幻灯片保存为单独的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量或“快速保存”？**

不支持。每次保存都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程可以保存同一个 Presentation 实例吗？**

不可以。`[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)`实例**不是线程安全的**(/slides/zh/java/multithreading/)。每次只能由单个线程访问并保存该实例。

**保存演示文稿时超链接和外部链接文件会怎样？**

[超链接](/slides/zh/java/manage-hyperlinks/)会保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些位置。

**我可以保存文档元数据（如作者、标题、公司和创建日期）吗？**

可以。保存前设置相应的[文档属性](/slides/zh/java/presentation-properties/)，Aspose.Slides 会将其写入输出文件。