---
title: 检查演示文稿
type: docs
weight: 30
url: /zh/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- JavaScript
- Node
description: "在 Node 中读取和修改 PowerPoint 演示文稿属性"
---

Aspose.Slides for Node.js via Java 允许您检查演示文稿以了解其属性并理解其行为。

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。参考以下 JavaScript 代码：
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```


## **获取演示文稿属性**

此 JavaScript 代码演示了如何获取演示文稿属性（关于演示文稿的信息）：
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


您可能想查看 [DocumentProperties 类下的属性](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--)。

## **更新演示文稿属性**

Aspose.Slides 提供的 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 方法允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例演示如何编辑部分演示文稿属性：
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用链接**

若想获取有关演示文稿及其安全属性的更多信息，以下链接可能对您有帮助：

- [检查演示文稿是否已加密](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否受写保护（只读）](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载前检查演示文稿是否受密码保护](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查是否嵌入了字体以及具体是哪一些？**

在演示文稿层面查找 [embedded‑font 信息](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [实际在内容中使用的字体集合](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) 对比，以确定哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/)。

**是否能检测自定义幻灯片尺寸和方向是否被使用，以及它们是否与默认值不同？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) 和方向与标准预设进行比较；这有助于在打印和导出时预估行为。

**有没有快速方式查看图表是否引用了外部数据源？**

有。遍历所有 [charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出缓慢的“繁重”幻灯片？**

对每张幻灯片统计对象数量，留意大尺寸图像、透明度、阴影、动画和多媒体；根据这些因素给出一个粗略的复杂度评分，以标记潜在的性能热点。