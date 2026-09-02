---
title: 在 Java 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/java/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Java 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概述**

Aspose.Slides 可以在不创建完整演示文稿对象模型的情况下识别演示文稿的格式并读取其文档元数据。当您需要对文件进行分类、构建清单或在决定是否加载并处理演示文稿内容之前检查属性时，这非常有用。

本文演示了如何通过 [PresentationFactory](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/) 和 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/) 进行轻量级检查，以及通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/) 进行有针对性的更新。

## **检查演示文稿格式**

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 可在不创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 实例的情况下检查文件。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) 方法报告检测到的格式，例如 PPTX、PPT 或 ODP。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **构建轻量级演示文稿清单**

在处理大量演示文稿文件时，您可能需要一个紧凑的清单用于验证、索引或文档管理系统。在这种情况下，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 获取 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/) 对象，然后调用 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 读取文档元数据。此方法不会创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 实例，也不需要遍历完整的演示文稿对象模型。

由 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/) 暴露的扩展属性提供以下清单值：

| 方法 | 清单值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getSlides--) | 幻灯片总数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 隐藏幻灯片的数量。 |
| [getNotes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getNotes--) | 包含备注的幻灯片数量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | 段落总数（如果可用）。 |
| [getWords](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getWords--) | 单词总数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 音频和视频剪辑的总数。 |

下面的示例在不创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 对象的情况下读取这些值，并输出紧凑的清单。它还结合使用 [getHeadingPairs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) 与 [getTitlesOfParts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) 显示诸如字体、主题和幻灯片标题等内容组。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

每个 [IHeadingPair](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iheadingpair/) 提供组名称以及该组中的项目数量。[IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) 返回一个平铺且有序的数组，因此按每个标题对指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

由 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 返回的清单属性反映了源文档中可用的元数据。Aspose.Slides 并不会在此调用中加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性会以默认值表示，如果最后一次保存文件的应用程序未更新其文档属性，存储的值可能已经过时。

- **PPTX：** 该格式提供了幻灯片、备注、隐藏幻灯片、段落、单词和多媒体计数的扩展文档属性，以及标题对和零件标题。可用性取决于文档生成者写入了哪些属性。
- **PPT：** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未被文档生成者刷新，Aspose.Slides 将返回其存储的或默认值，而不是根据幻灯片计算得出。
- **ODP：** OpenDocument 元数据提供一般文档统计信息，例如页面、段落和单词计数，但这些值并不对应每个 PowerPoint 特有的扩展属性。隐藏幻灯片、备注幻灯片、多媒体、标题对和零件标题的元数据可能不可用，清单属性可能返回默认值。不要将零值或空数组视为对应内容不存在的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。当结果必须反映内存中的更改或需要验证实际演示文稿内容时，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

由 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 返回的属性也可以在不创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 实例的情况下进行修改。使用 [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 应用更改，然后使用 [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) 将绑定的演示文稿写出。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

下面的示例更改标题和最近保存时间，并将结果写入新文件：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用的链接**

有关相关的安全检查和保护设置，请参阅以下文章：

- [Password-Protect Presentations](/slides/zh/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh/java/write-protected-presentation/)

## **常见问题**

**如何检查是否嵌入了字体以及具体是哪一些？**

加载演示文稿并使用 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getFontsManager--)。调用 [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) 获取嵌入的字体，调用 [IFontsManager.getFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getFonts--) 获取演示文稿使用的字体。比较两者即可找出渲染所需但未嵌入的字体。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，可通过 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 与 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 读取 [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--)。这适用于轻量级清单。如果演示文稿在内存中已被修改，存储的元数据可能缺失或过时，或者需要验证实时值，则遍历 [Presentation.getSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlides--) 并检查每个幻灯片的 [ISlide.getHidden](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#getHidden--) 方法。

**我能检测是否使用了自定义幻灯片大小和方向，以及它们是否与默认值不同吗？**

可以。加载演示文稿后调用 [Presentation.getSlideSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlideSize--)。使用 [ISlideSize.getType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidesize/#getType--)、[ISlideSize.getSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidesize/#getSize--) 和 [ISlideSize.getOrientation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidesize/#getOrientation--) 将当前设置与预设的默认尺寸和方向进行比较。

**有没有快速方法查看图表是否引用外部数据源？**

可以。定位每个 [Chart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/) 并调用 [IChartData.getDataSourceType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getDataSourceType--)。对于外部工作簿，还可以调用 [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)。数据源类型和路径可标识外部引用，但是否可用需另行进行资源检查。

**如何评估可能导致渲染或 PDF 导出变慢的“沉重”幻灯片？**

没有单一的复杂度属性。遍历 [Presentation.getSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlides--) 并检查每个幻灯片的 [IBaseSlide.getShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/#getShapes--) 集合。使用形状数量以及是否包含大图片、特效、动画或多媒体等作为筛选信号，并在将幻灯片视为确认的性能瓶颈之前进行代表性的渲染或导出测量。