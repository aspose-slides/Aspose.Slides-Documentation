---
title: 在 Android 上将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Android 上使用 Aspose.Slides，轻松将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

本文说明如何使用 Java 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。包括以下主题。

- 在 Java 中将 PPTX 转换为 PPT

## **在 Android 上将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 Java 示例代码，请参见下面的章节，即 [将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它只加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [Java 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java 将 PPTX 转换为图像](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的 **Save** 方法。下面的 Java 示例代码使用默认选项将演示文稿从 PPTX 转换为 PPT。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation presentation = new Presentation("template.pptx");

// save the presentation as PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **常见问题**

**将 PPTX 保存为传统 PPT（97–2003）格式时，所有效果和功能都会保留吗？**

并非总是如此。PPT 格式缺少一些新功能（例如某些效果、对象和行为），因此在转换过程中某些功能可能会被简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若只转换特定幻灯片，可创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持每张幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开它，并且还能 [配置保护/加密设置](/slides/zh/androidjava/password-protected-presentation/) 以保存 PPT。