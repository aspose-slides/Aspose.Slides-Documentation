---
title: 在 Python 中将 ODP 转换为 PPTX
linktitle: ODP 转 PPTX
type: docs
weight: 10
url: /zh/python-java/convert-odp-to-pptx/
keywords:
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 ODP
- OpenDocument 转 PPTX
- ODP 转 PPTX
- 将 ODP 保存为 PPTX
- 导出 ODP 为 PPTX
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 ODP 演示文稿转换为 PPTX。使用完整的 Python 示例，无需安装 PowerPoint 或 LibreOffice。"
---
## **概述**

本文档说明如何使用 Aspose.Slides for Python via Java 将 OpenDocument（ODP）演示文稿转换为 PowerPoint（PPTX）格式。

## **将 ODP 转换为 PPTX**

[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类可以直接加载 ODP 文件。使用 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 将加载的演示文稿保存为 PPTX 格式。

在运行示例之前，请先遵循[installation instructions](/slides/zh/python-java/installation/)。将名为 `AccessOpenDoc.odp` 的 ODP 演示文稿放置在工作目录中。以下代码在必要时启动 JVM，打开 ODP 文件，并将其保存为 `AccessOpenDoc_out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # 将 ODP 演示文稿保存为 PPTX 格式。
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **实时示例**

尝试使用 [Aspose.Slides Conversion](https://products.aspose.app/slides/zh/conversion/) Web 应用查看由 Aspose.Slides 提供支持的 ODP 到 PPTX 转换。

## **常见问题**

**我是否需要安装 Microsoft PowerPoint 或 LibreOffice 来将 ODP 转换为 PPTX？**

不需要。Aspose.Slides for Python via Java 可以在不依赖上述任何应用的情况下读取和写入演示文稿文件。您只需安装 Python 包并拥有兼容的 Java 运行时。

**在转换过程中，母版幻灯片、布局和主题会被保留吗？**

Aspose.Slides 会将源演示文稿的结构和格式映射到 PPTX。不过，ODP 与 PPTX 支持的功能不同，某些元素在转换后可能会有所差异。请确保所需字体可用，并对具有复杂格式的演示文稿进行检查。有关兼容性注意事项，请参阅[OpenDocument conversion](/slides/zh/python-java/convert-openoffice-odp/)。

**我可以转换受密码保护的 ODP 文件吗？**

可以，只需提供打开文件所需的密码。有关在另存为其他格式之前加载受保护文件的详细信息，请参阅[password-protected presentations](/slides/zh/python-java/password-protected-presentation/)。

**Aspose.Slides 适用于云或基于 REST 的转换服务吗？**

适用。您可以在后端使用 Aspose.Slides for Python via Java 并配备所需的 Java 运行时。若需 REST API，请参阅 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh/family/)。