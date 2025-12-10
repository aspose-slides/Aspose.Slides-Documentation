---
title: 在 Java 中将 PPTX 转换为 PPT
linktitle: PPTX 转为 PPT
type: docs
weight: 21
url: /zh/java/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPTX
- PPTX 转 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 轻松将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保持演示文稿的布局和质量。"
---

## **概述**

本文介绍如何使用 Java 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。覆盖的主题如下。

- 在 Java 中将 PPTX 转换为 PPT

## **在 Java 中将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 Java 示例代码，请参阅下文即[Convert PPTX to PPT](#convert-pptx-to-ppt)章节。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的**Save**方法。下面的 Java 代码示例使用默认选项将 Presentation 从 PPTX 转换为 PPT。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation presentation = new Presentation("template.pptx");

// 将演示文稿保存为 PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **常见问题**

**在将 PPTX 保存为传统 PPT（97–2003）格式时，所有效果和功能都能保留下来吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中可能会被简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若只转换特定幻灯片，可创建仅包含这些幻灯片的新演示文稿并保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开它，并且还可以为保存的 PPT [configure protection/encryption settings](/slides/zh/java/password-protected-presentation/)。