---
title: 在 JavaScript 中将 PPTX 转换为 PPT
linktitle: 将 PPTX 转换为 PPT
type: docs
weight: 21
url: /zh/nodejs-java/convert-pptx-to-ppt/
keywords: "Java 将 PPTX 转换为 PPT, 转换 PowerPoint 演示文稿, PPTX 转 PPT, Java, Aspose.Slides"
description: "在 JavaScript 中将 PowerPoint PPTX 转换为 PPT"
---

## **概述**

本文介绍如何使用 JavaScript 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涵盖以下主题。

- 在 JavaScript 中将 PPTX 转换为 PPT

## **Java 将 PPTX 转换为 PPT**

有关在 JavaScript 中将 PPTX 转换为 PPT 的示例代码，请参阅以下章节，即[转换 PPTX 为 PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详情请参见这些文章。

- [Java 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java 将 PPTX 转换为图像](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **转换 PPTX 为 PPT**

要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的 **Save** 方法。下面的 JavaScript 示例代码使用默认选项将演示文稿从 PPTX 转换为 PPT。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var presentation = new aspose.slides.Presentation("template.pptx");
// 将演示文稿保存为 PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **常见问题**

**在保存为传统 PPT（97–2003）格式时，所有 PPTX 的效果和功能都会保留吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中可能会对这些功能进行简化或栅格化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，需要先创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持逐幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开，并且还可以[配置保护/加密设置](/slides/zh/nodejs-java/password-protected-presentation/)以保存受密码保护的 PPT。