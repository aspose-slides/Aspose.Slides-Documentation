---
title: 系统需求
type: docs
weight: 60
url: /zh/python-java/system-requirements/
keywords:
- 系统需求
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "检查在 Windows、Linux 和 macOS 上运行 Aspose.Slides for Python via Java 所需的操作系统、Python、Java 和 JPype 要求。"
---
## **概述**

Aspose.Slides for Python via Java 在未安装 Microsoft PowerPoint 的情况下创建、修改、转换和渲染演示文稿。它使用 JPype 从 Python 访问 Java 库，因此环境必须同时支持 Python、Java 和 JPype。

## **受支持的操作系统**

[Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) 支持以下操作系统系列：

- Windows
- Linux
- macOS

请选择与所选 Python、Java 和 JPype 版本兼容的操作系统版本。仅有 Java 可用并不足以保证与 Python 包及其桥接的兼容性。

## **Python、Java 和 JPype 要求**

| 组件 | 要求 |
| --- | --- |
| Python | Aspose.Slides 包声明支持 Python 3.7 至 3.14。所选的 JPype 版本必须支持相同的 Python 版本；例如，[JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) 需要 Python 3.8 或更高版本。 |
| Java | 安装与所选 JPype 版本兼容的 Java 运行时或 JDK。当前的 [JPype prerequisites](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) 指定 Java 11 或更高版本。Java 8 无法运行 JPype1 1.7.1。 |
| JPype | 为您的 Python 解释器、操作系统和 CPU 架构安装 JPype1 包。 |
| CPU 架构 | Python 和 Java 虚拟机 (JVM) 必须使用匹配的架构。例如，64 位 Python 解释器需要兼容的 64 位 JVM。 |

在 Apple Silicon 上，Python 和 Java 必须同时使用 ARM64 或同时使用 x64。如果 JVM 独立运行但其架构与 Python 不同，仍可能通过 JPype 加载失败。

对于新环境，Python 3.12、JDK 17 和 JPype1 1.7.1 是合适的起点。此组合已在 Windows 上使用 Aspose.Slides for Python via Java 26.6.0 进行验证。其他组合必须满足这三项组件的要求。

有关环境设置和可运行的验证示例，请参阅 [Installation](/slides/zh/python-java/installation/)。

## **附加依赖项**

兼容的预构建 JPype wheel 不需要 C++ 编译器。如果必须从源码构建 JPype，请安装兼容的 C++ 编译器以及平台所需的 Python 开发文件。有关构建要求和故障排除，请参阅 [JPype installation instructions](https://jpype.readthedocs.io/en/latest/install.html)。

## **常见问题**

**我需要安装 Microsoft PowerPoint 吗？**

不需要。Aspose.Slides 独立于 PowerPoint 处理演示文稿。仍然需要 Python、Java 和 JPype。

**我可以在任何 JPype 版本下使用 Python 3.7 吗？**

不可以。虽然 Aspose.Slides 包声明支持 Python 3.7，但 JPype1 1.7.1 需要 Python 3.8 或更高版本。请选择需求交叉的版本。

**我可以将 32 位 Python 与 64 位 Java 混合使用吗？**

不可以。JPype 将 JVM 加载到 Python 进程中，因此 Python 与 Java 必须具备匹配的架构。同样的要求也适用于 macOS 上的 ARM64 与 x64。