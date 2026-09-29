---
title: 入门
type: docs
weight: 10
url: /zh/java/getting-started/
keywords:
- 入门
- 系统需求
- 安装
- 首个演示文稿
- Maven
- PPT 处理
- PPTX 处理
- ODP 处理
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "从新建 Java 项目到使用 Aspose.Slides 保存的第一个演示文稿的完整路径：检查需求、从 Aspose 的 Maven 仓库添加库、运行第一个程序，并继续执行常见任务。"
---
## **概述**

按顺序完成以下四个步骤。每个步骤指明要做的事情并链接到包含详细信息的文章。评估、授权和支持在步骤之后进行说明。

## **步骤 1：检查系统需求**

Aspose.Slides for Java 是一个不含本机代码的单个 JAR 文件，因此它可以在任何具备受支持 Java 运行时的操作系统上运行。[System Requirements](/slides/zh/java/system-requirements/) 列出了受支持的操作系统和 Java 版本。接下来步骤中的项目和命令需要 JDK 11 或更高版本，并且对于 Maven 方式，需要 [Apache Maven](https://maven.apache.org/install.html)。

## **步骤 2：将库添加到项目中**

Aspose.Slides for Java 发布在 Aspose 自己的 Maven 仓库中，而不在 Maven Central。请选择以下方式之一：

- 使用 Maven：在 *pom.xml* 中声明仓库 `https://releases.aspose.com/java/repo/`，并添加依赖 `com.aspose:aspose-slides`，使用 `jdk16` 分类器。
- 不使用 Maven：从仓库下载文件名以 *-jdk16.jar* 结尾的 JAR，并将其放入类路径。

在 Linux 上，还需安装 fontconfig 库以及至少一种字体。若未安装，保存演示文稿时会出现错误 “Fontconfig head is null, check your fonts or fonts configuration”。  
[Installation](/slides/zh/java/installation/) 提供了 *pom.xml* 条目、JAR 下载方式以及 Linux 命令。

## **步骤 3：创建您的第一个演示文稿**

在 Aspose.Slides for Java 首页的 [quick start on the Aspose.Slides for Java home page](/slides/zh/java/#your-first-presentation) 是一个完整的 Maven 项目：包含 *pom.xml* 文件以及一个向幻灯片添加带文本的云形状并将演示文稿保存为 PPTX 文件的程序。可以使用 `mvn compile exec:java` 运行它。[Create Presentations](/slides/zh/java/create-presentation/) 逐步解释了该程序。要打开已有演示文稿并将其保存为其他格式，请参阅 [Open Presentations](/slides/zh/java/open-presentation/) 和 [Save Presentations](/slides/zh/java/save-presentation/)。

## **步骤 4：继续常见任务**

- [打开演示文稿](/slides/zh/java/open-presentation/)
- [保存演示文稿](/slides/zh/java/save-presentation/)
- [将演示文稿转换为 PDF](/slides/zh/java/convert-powerpoint-to-pdf/)
- [将幻灯片渲染为图像](/slides/zh/java/convert-slide/)
- [编辑演示文稿文本](/slides/zh/java/manage-text/)
- [按幻灯片元素的示例](/slides/zh/java/examples/)

## **评估和授权**

如果没有授权，Aspose.Slides 将以评估模式运行：在每个保存的幻灯片上添加水印，并截断代码从演示文稿读取的文本。

- [评估 Aspose.Slides](/slides/zh/java/evaluate-aspose-slides/) 说明了评估限制以及如何请求临时授权。
- [授权](/slides/zh/java/licensing/) 展示了如何从文件或流应用授权。
- [按使用计量授权](/slides/zh/java/metered-licensing/) 介绍了按使用量计费的授权方式。
- [受支持的文件格式](/slides/zh/java/supported-file-formats/) 列出了 Aspose.Slides 能够加载和保存的格式。

## **获取帮助**

[技术支持](/slides/zh/java/technical-support/) 说明了如何在 [免费支持论坛](https://forum.aspose.com/c/slides/zh/11) 提出问题，以及报告问题时应包含哪些信息。

## **常见问题**

**我需要安装 Microsoft PowerPoint 吗？**

不需要。Aspose.Slides 自行读取和写入演示文稿文件，不使用 PowerPoint，因此也可以在服务器和 Linux 上运行。

**为什么 Maven 找不到 Aspose.Slides for Java？**

该库不在 Maven Central。请在 *pom.xml* 中声明 Aspose 的仓库，如 [Installation](/slides/zh/java/installation/) 所示，Maven 将从该仓库下载库。

**`jdk16` 分类器是否意味着库需要 Java 16？**

不。该分类器用于选择库的 Java SE 构建；另一构建用于 Android。同一构建可在当前的 JDK 上运行，例如 JDK 21。