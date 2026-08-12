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
description: "了解如何使用 Aspose.Slides 在 Java 中保存演示文稿——导出为 PowerPoint 或 OpenDocument 并保留布局、字体和效果。"
---
## **概述**

[在 Java 中打开演示文稿](/slides/zh/java/open-presentation/) 说明了如何使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类打开演示文稿。本文解释了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for Java，您可以保存到 **文件** 或 **流**。本文说明了保存演示文稿的不同方法。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的 `save` 方法并传入文件名和保存格式来将演示文稿保存到文件。以下示例展示了如何使用 Aspose.Slides 保存演示文稿。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 在此执行一些操作...

    // 将演示文稿保存到文件。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的 `save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例创建一个新演示文稿并将其保存到文件流。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // 将演示文稿保存到流中。
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides 通过 [ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/) 类允许您设置 PowerPoint 打开生成的演示文稿时的初始视图。使用来自 [ViewType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewtype/) 枚举的值调用 [setLastView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#setLastView-int-) 方法。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以 Strict Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/) 类并在保存时设置其 conformance 属性。如果将其设置为 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)，输出文件将以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存。

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 将演示文稿以严格的 Office Open XML 格式保存。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任何文件的未压缩大小、压缩后大小以及存档的总体大小均限制为 4 GB（2^32 字节），并且对文件数量限制为 65 535（2^16‑1）。ZIP64 格式扩展将这些限制提升至 2^64。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可与以下模式一起使用：

- [IfNecessary](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。此为默认模式。
- [Never](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Never) 从不使用 ZIP64 格式扩展。
- [Always](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Always) 始终使用 ZIP64 格式扩展。

下面的代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
当使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh/java/com.aspose.slides/zip64mode/#Never) 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同压缩级别保存 Office Open XML 格式的演示文稿**

在处理大型演示文稿时，您可以调整压缩级别以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) 方法，允许您指定在以 Office Open XML 格式保存演示文稿时使用的压缩级别。

可用的压缩级别如下：

- [**None**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#None)：不进行压缩，文件保持原样存储。
- [**Level1**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level1)：最快的压缩速度，压缩比最低。
- [**Level2**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level2)：相对于 **Level1** 有稍好些的压缩比，压缩速度仍然很快。
- [**Level3**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level3)：在处理时间上有适度影响的情况下，提供比 **Level2** 更好的压缩。
- [**Level4**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level4)：比 **Level3** 更好的压缩。
- [**Level5**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level5)：在 **Level4** 基础上进一步提升压缩率，需额外的处理时间。
- [**Level6**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level6)：标准压缩，在处理速度和文件大小之间提供良好平衡。这是 *默认压缩级别*。
- [**Level7**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level7)：比 **Level6** 更好的压缩，但处理速度变慢。
- [**Level8**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level8)：比 **Level7** 更好的压缩。
- [**Level9**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compressionlevel/#Level9)：最高压缩率，生成最小文件大小，但处理时间最长。

下面的示例演示了如何在 *不使用压缩* 的情况下将演示文稿保存为 PPTX 文件：

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

下面的示例演示了如何在 *最大压缩* 的情况下将演示文稿保存为 PPTX 文件：

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **保存演示文稿时不刷新缩略图**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法控制将演示文稿保存为 PPTX 时是否生成缩略图：

- 设置为 `true` 时，保存期间会刷新缩略图。这是默认行为。
- 设置为 `false` 时，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将在保存为 PPTX 时不刷新缩略图。

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
此选项有助于减少将演示文稿保存为 PPTX 格式所需的时间。
{{% /alert %}}

## **以百分比显示保存进度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isaveoptions/) 接口以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveoptions/) 类的 `setProgressCallback` 方法使用。将实现了 [IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/) 的对象传递给 `setProgressCallback`，即可以百分比形式接收保存进度更新。

下面的代码片段展示了如何使用 `IProgressCallback`。

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 在此使用进度百分比值。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose 开发了一个使用其自身 API 的 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片另存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存）仅写入更改？**

不支持。每次保存都会创建完整的目标文件，未实现增量“快速保存”。

**从多个线程同时保存同一 Presentation 实例是否线程安全？**

不安全。一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 实例 **不可线程安全**，请仅在单个线程中保存。

**保存时超链接和外部链接文件会怎样处理？**

[Hyperlinks](/slides/zh/java/manage-hyperlinks/) 会被保留。外部链接文件（如通过相对路径引用的视频）不会自动复制——请确保引用的路径仍然可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。支持标准的 [document properties](/slides/zh/java/presentation-properties/)，保存时会写入文件。