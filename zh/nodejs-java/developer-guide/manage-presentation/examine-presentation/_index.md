---
title: 使用 JavaScript 检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: 使用 JavaScript 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以实现更快速的洞察和更智能的内容审计。
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它说明了如何在不加载完整文件的情况下确定演示文稿的当前格式，读取文档属性，并在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/) API，演示了处理演示文稿元数据的典型操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解该演示文稿当前的格式（PPT、PPTX、ODP 等）。

您可以在无需加载演示文稿的情况下检查其格式。请参见以下 JavaScript 代码：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **获取演示文稿属性**

以下 JavaScript 代码演示了如何获取演示文稿属性（关于演示文稿的信息）：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// 省略
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例演示了如何编辑某些演示文稿属性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [密码保护演示文稿](/slides/zh/nodejs-java/password-protected-presentation/)
- [写保护演示文稿](/slides/zh/nodejs-java/write-protected-presentation/)

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪几种？**

在演示文稿层级查找 [embedded-font information](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [fonts actually used across content](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getfonts/) 的集合进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否有隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/gethidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslidesize/) 和方向与标准预设进行比较；这有助于预测打印和导出的行为。

**有没有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出变慢的‘重量级’幻灯片？**

对于每张幻灯片，统计对象数量并查找大型图像、透明度、阴影、动画和多媒体等因素；给出大致的复杂度评分，以标记潜在的性能热点。