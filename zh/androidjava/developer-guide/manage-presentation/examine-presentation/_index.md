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

Aspose.Slides for Android via Java 允许您检查演示文稿以了解其属性并理解其行为。

{{% alert title="Info" color="info" %}} 
[PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) 和 [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) 类包含此处操作使用的属性和方法。
{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿是 PPT、PPTX、ODP 还是其他格式。

您可以在不加载演示文稿的情况下检查其格式。参见以下 Java 代码：
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **获取演示文稿属性**

以下 Java 代码演示如何获取演示文稿属性（有关演示文稿的信息）：
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```


您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下代码示例演示如何编辑部分演示文稿属性：
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


更改文档属性后的结果如下所示。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **有用链接**

欲获取有关演示文稿及其安全属性的更多信息，以下链接可能对您有帮助：

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查是否嵌入了字体以及具体有哪些？**

在演示文稿级别查找 [embedded-font 信息](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然后将这些条目与 [实际使用的字体集合](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 进行对比，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否存在隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--)。

**我能检测是否使用了自定义幻灯片尺寸和方向，并且它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) 和方向与标准预设进行比较；这有助于预测打印和导出时的行为。

**有没有快速方法查看图表是否引用了外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重”幻灯片？**

对每张幻灯片，统计对象数量并查找大尺寸图像、透明度、阴影、动画和多媒体等因素；给出一个粗略的复杂度分数，以标记潜在的性能热点。