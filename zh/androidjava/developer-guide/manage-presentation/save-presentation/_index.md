---
title: 在 Android 上保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/androidjava/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿到文件
- 演示文稿到流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 Java 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---
## **概述**

[Open Presentations on Android](/slides/zh/androidjava/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类来打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for Android，您可以保存到 **文件** 或 **流**。本文说明了保存演示文稿的不同方式。

## **保存演示文稿到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存到文件。将文件名和保存格式传递给该方法。下面的示例展示了如何使用 Aspose.Slides 保存演示文稿。

```java
import com.aspose.slides.*;

// 实例化代表演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 在此执行一些操作……

    // 将演示文稿保存到文件。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **保存演示文稿到流**

您可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的 `save` 方法，将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例创建了一个新演示文稿并将其保存到文件流。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// 实例化代表演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // 将演示文稿保存到流。
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/) 类设置生成的演示文稿打开时 PowerPoint 使用的初始视图。使用 [setLastView](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 方法并传入来自 [ViewType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewtype/) 枚举的值。

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

## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxoptions/) 类并在保存时设置其 conformance 属性。如果将 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) 设置为该值，输出文件将以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存。

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 实例化代表演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 将演示文稿保存为严格的 Office Open XML 格式。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任何文件的未压缩大小、压缩后大小以及整个存档的总大小均限制为 4 GB（2^32 字节），并且存档中文件数量限制为 65 535（2^16‑1）个。ZIP64 格式扩展将这些限制提升至 2^64。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可与以下模式一起使用：

- [IfNecessary](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式扩展。
- [Always](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/zip64mode/#Always) 始终使用 ZIP64 格式扩展。

以下代码演示如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

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
当您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/zip64mode/#Never) 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式中使用压缩级别保存演示文稿**

处理大型演示文稿时，您可以调整压缩级别以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) 方法，允许您指定在 Office Open XML 格式下保存演示文稿时使用的压缩级别。

可用的压缩级别如下：

- [**None**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#None)：不进行压缩，文件按原样存储。
- [**Level1**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level1)：压缩速度最快，压缩率最低。
- [**Level2**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level2)：压缩速度较快，压缩率略高于 **Level1**。
- [**Level3**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level3)：在处理中等影响下提供比 **Level2** 更好的压缩。
- [**Level4**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level4)：提供比 **Level3** 更好的压缩。
- [**Level5**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level5)：在 **Level4** 基础上提升压缩，同时增加处理时间。
- [**Level6**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level6)：标准压缩，在处理速度和文件大小之间取得良好平衡。这是 *默认压缩级别*。
- [**Level7**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level7)：提供比 **Level6** 更好的压缩，但处理速度较慢。
- [**Level8**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level8)：提供比 **Level7** 更好的压缩。
- [**Level9**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compressionlevel/#Level9)：最大压缩。可在获得最小文件大小的同时导致最长的处理时间。

以下示例演示如何在 *不进行压缩* 的情况下将演示文稿保存为 PPTX 文件：

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

此示例展示如何在 *最大压缩* 的情况下将演示文稿保存为 PPTX 文件：

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

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法控制将演示文稿保存为 PPTX 时的缩略图生成行为：

- 如果设置为 `true`，保存时会刷新缩略图。这是默认行为。
- 如果设置为 `false`，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将演示文稿保存为 PPTX，且不刷新其缩略图。

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
此选项有助于减少以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比保存进度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isaveoptions/) 接口以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveoptions/) 类公开的 `setProgressCallback` 方法使用。使用 `setProgressCallback` 分配一个 [IProgressCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprogresscallback/) 实现，可在保存时以百分比形式接收进度更新。

下面的代码片段展示了如何使用 `IProgressCallback`。

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 使用此处的进度百分比值。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose 开发了一个 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/zh/splitter)，使用其自有 API。该应用可通过将选定的幻灯片另存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持 “快速保存”(增量保存) 只写入更改的部分？**

不支持。每次保存时都会生成完整的目标文件，未支持增量 “快速保存”。

**在多个线程中保存同一个 Presentation 实例是否线程安全？**

不安全。一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例 [并非线程安全](/slides/zh/androidjava/multithreading/)，请在单个线程中进行保存。

**保存时超链接和外部链接文件会怎样处理？**

[超链接](/slides/zh/androidjava/manage-hyperlinks/) 会被保留。外部链接文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径保持可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。标准的 [文档属性](/slides/zh/androidjava/presentation-properties/) 已受支持，保存时会写入文件。