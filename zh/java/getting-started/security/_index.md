---
title: 安全
type: docs
weight: 160
url: /zh/java/security/
keywords:
- 安全
- 依赖项
- 第三方组件
- Maven
- JAR签名
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 如何处理演示文稿、它为您的项目依赖项添加了哪些内容、如何验证 JAR 文件，以及它包含了哪些第三方组件。"
---
## **简介**

本文收集了对使用 Aspose.Slides for Java 的应用程序进行安全审查时通常需要的信息：库如何处理演示文稿、它为项目的依赖项增加了什么、如何检查 JAR 文件是否来自 Aspose，以及 JAR 文件中包含了哪些第三方组件。

## **Aspose.Slides 的安全性**

Aspose 在开发产品时遵循最佳实践。

* Aspose.Slides for Java 用于创建、修改和转换演示文稿。它不会在演示文稿中运行脚本。Aspose.Slides 解析演示文稿结构并让您的代码与对象模型交互。
* Aspose.Slides 作为一个库解析和解释文档，且不执行远程代码。所有 Aspose 产品均在您的机器上运行。它们不会向 Aspose 传输任何数据。唯一例外是[metered licensing](/slides/zh/java/metered-licensing/)：如果使用它，只有您的 API 使用信息会被处理。
* Aspose 组件在与普通应用程序相同的用户上下文中运行。因此，Aspose 组件不会对关键系统资源构成风险。此外，当 Aspose 组件打开文档时，宏不会自动运行。

## **Maven 依赖项**

Aspose.Slides for Java 的 Maven 组件 `com.aspose:aspose-slides` 未声明任何依赖项：其 POM 文件仅包含该组件本身的坐标。将其添加到项目后，Maven 只会下载这一个 JAR 文件，不会添加其他内容。要列出项目解析的所有组件（包括传递依赖），请在项目文件夹中运行以下命令：

```bash
mvn dependency:tree
```

在[Installation](/slides/zh/java/installation/)示例项目中，输出仅列出 Aspose.Slides 为唯一依赖项：

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **验证 JAR 文件**

Aspose 对 JAR 文件进行签名。要检查签名，请在包含 JAR 文件的文件夹中使用 JDK 的 `jarsigner` 工具：

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

当签名有效且未有条目自签名后被更改时，命令会输出 `jar verified.`。此消息未显示签名者姓名。要确认文件由 Aspose 签名，请添加 `-verbose` 和 `-certs` 参数，并检查签名者证书的发行对象为 `CN=ASPOSE PTY LTD`。当 Maven 下载 JAR 文件时，它还会校验仓库随文件一起发布的 SHA-1 校验和值。

## **第三方组件**

Aspose.Slides for Java 包含来自第三方组件的代码和数据。它们是 JAR 文件的一部分，而非独立的 Maven 组件，因此 `mvn dependency:tree` 及其他读取 Maven 依赖的工具不会列出它们。JAR 文件中包含名为 *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* 的说明文件，列出了这些组件及其许可证：

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

要从 JAR 文件中提取说明文件，请在包含 JAR 文件的文件夹中使用 JDK 的 `jar` 工具：

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **常见问题**

**Aspose.Slides for Java 是否使用外部包？**

如[Maven 依赖项](#maven-依赖项)所示，它没有 Maven 依赖，但包含了[第三方组件](#第三方组件)中列出的第三方组件。请在安全审查时同时检查 JAR 文件及这些组件。

**Aspose.Slides for Java 是否需要网络访问？**

不需要。创建、保存和渲染演示文稿可以在没有任何网络连接的系统上完成。唯一会向 Aspose 发送数据的功能是[metered licensing](/slides/zh/java/metered-licensing/)，它会报告 API 使用情况。

**Aspose.Slides for Java 是否包含本机代码？**

不包含。JAR 文件仅包含 Java 类和资源，因此不会向您的应用程序添加本机库。在 Linux 上，Java 运行时的字体支持需要 fontconfig 库和操作系统提供的字体；详见[System Requirements](/slides/zh/java/system-requirements/#linux)。