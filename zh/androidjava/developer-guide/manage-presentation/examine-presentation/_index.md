---
title: 在 Android 上检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Java 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它解释了如何在不加载完整文件的情况下确定演示文稿的当前格式、读取其文档属性以及在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/documentproperties/) API，演示了处理演示文稿元数据的常见操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参见以下 Java 代码：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **获取演示文稿属性**

以下 Java 代码演示了如何获取演示文稿属性（有关演示文稿的信息）：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ……
```

您可能想查看 [DocumentProperties 类下的属性](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例演示了如何编辑部分演示文稿属性：

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用链接**

欲获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [受密码保护的演示文稿](/slides/zh/androidjava/password-protected-presentation/)
- [受写保护的演示文稿](/slides/zh/androidjava/write-protected-presentation/)

## **常见问题**

**如何检查是否嵌入了字体以及具体哪些字体？**

在演示文稿级别查找 [嵌入字体信息](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然后将这些条目与 [实际使用的字体](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 中实际使用的字体进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否有隐藏幻灯片以及数量？**

遍历 [幻灯片集合](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidecollection/) 并检查每个幻灯片的 [可见性标志](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#getHidden--)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [幻灯片尺寸](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSlideSize--) 和方向与标准预设进行比较；这有助于预判打印和导出时的行为。

**有没有快捷方法查看图表是否引用外部数据源？**

有。遍历所有 [图表](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/)，检查其 [数据源](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)，并记录数据是内部的还是基于链接的，包括任何损坏的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“繁重”幻灯片？**

对于每张幻灯片，统计对象数量并查找大图像、透明度、阴影、动画和多媒体等因素；给出一个大致的复杂度评分，以标记潜在的性能热点。