---
title: 在 Java 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/java/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
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

本文说明如何使用 Java 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涵盖以下主题。

- 在 Java 中将 PPTX 转换为 PPT

## **在 Java 中将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 Java 示例代码，请参阅以下章节，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。该示例仅加载 PPTX 文件并保存为 PPT 格式。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [Convert PPTX to PDF in Java](/slides/zh/java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in Java](/slides/zh/java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in Java](/slides/zh/java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in Java](/slides/zh/java/save-presentation/)
- [Convert PPTX to PNG in Java](/slides/zh/java/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的**Save**方法。下面的 Java 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation presentation = new Presentation("template.pptx");

// 将演示文稿保存为 PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **常见问答**

**将 PPTX 的所有效果和功能在保存为传统 PPT（97–2003）格式时是否都能保留下来？**

并非总是如此。PPT 格式缺少某些新功能（例如特定效果、对象和行为），因此在转换过程中可能会对功能进行简化或栅格化。

**是否可以仅将选定的幻灯片转换为 PPT，而不是整个演示文稿？**

直接保存会针对整个演示文稿。要仅转换特定幻灯片，需创建仅包含这些幻灯片的新演示文稿并保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护、使用密码打开，并且还可以[configure protection/encryption settings](/slides/zh/java/password-protected-presentation/)以设置保存后 PPT 的保护/加密参数。