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

Aspose.Slides for Android via Java 允许您检查演示文稿，以了解其属性并理解其行为。

{{% alert title="Info" color="info" %}} 
PresentationInfo 和 DocumentProperties 类包含此处操作使用的属性和方法。
{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参见以下 Java 代码：
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **获取演示文稿属性**

下面的 Java 代码演示如何获取演示文稿属性（即演示文稿的信息）：
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ……
```


您可能想查看 [DocumentProperties 类下的属性](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

下面的代码示例演示如何编辑部分演示文稿属性：
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

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，以下链接可能对您有帮助：

- [检查演示文稿是否已加密](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否受写保护（只读）](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载之前检查演示文稿是否受密码保护](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪一些？**

在演示文稿级别查找 [embedded-font 信息](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然后将这些条目与 [实际在内容中使用的字体](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) 并检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--)。

**是否可以检测是否使用了自定义幻灯片尺寸和方向，且是否与默认值不同？**

可以。比较当前的 [slide size](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) 和方向与标准预设，从而提前预判打印和导出时的行为。

**是否有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)，并记录数据是内部还是链接式，以及是否存在破损链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对每张幻灯片统计对象数量，查找大尺寸图像、透明效果、阴影、动画和多媒体等因素，给出粗略的复杂度评分，以标记潜在的性能瓶颈。