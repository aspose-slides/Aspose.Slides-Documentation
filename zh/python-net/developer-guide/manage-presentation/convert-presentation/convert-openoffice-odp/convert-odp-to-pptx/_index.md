---
title: 在 Python 中将 ODP 转换为 PPTX
linktitle: ODP 转 PPTX
type: docs
weight: 10
url: /zh/python-net/convert-odp-to-pptx/
keywords:
- 转换 OpenDocument
- 转换 ODP
- OpenDocument 转 PPTX
- ODP 转 PPTX
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 ODP 转换为 PPTX。提供简洁代码示例、批处理技巧和高质量结果——无需 PowerPoint。"
---

## **导出 ODP 为 PPTX**

Aspose.Slides for Python via .NET 提供了表示演示文稿文件的 **Presentation**[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。该类现在还可以在实例化对象时通过 Presentation 构造函数访问 ODP。下面的示例演示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。
```py
# 导入 Aspose.Slides for Python via .NET 模块
import aspose.slides as slides

# 打开 ODP 文件
pres = slides.Presentation("AccessOpenDoc.odp")

# 将 ODP 演示文稿保存为 PPTX 格式
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **实时示例**

您可以访问基于 **Aspose.Slides API** 构建的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web 应用。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。

## **常见问题**

**我需要安装 Microsoft PowerPoint 或 LibreOffice 来将 ODP 转换为 PPTX 吗？**

不需要。Aspose.Slides 可独立工作，无需第三方应用程序即可读取或写入 ODP/PPTX。

**在转换过程中，母版幻灯片、布局和主题会被保留吗？**

会。库使用完整的演示文稿对象模型并保留结构，包括母版幻灯片和布局，从而在转换后保持正确的设计。

**我可以转换受密码保护的 ODP 文件吗？**

可以。Aspose.Slides 支持检测保护，提供密码后可以打开并处理[受保护的演示文稿](/slides/zh/python-net/password-protected-presentation/)（包括 ODP），还支持配置加密和访问文档属性。

**Aspose.Slides 适用于云端或基于 REST 的转换服务吗？**

可以。您可以在自己的后端使用本地库，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API），这两种方式都支持 ODP → PPTX 转换。