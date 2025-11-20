---
title: 演示文稿中使用 Python 的字体选择序列
linktitle: 字体选择
type: docs
weight: 80
url: /zh/python-net/font-selection-sequence/
keywords:
- 字体选择
- 字体替代
- 字体替换
- 替代规则
- 可用字体
- 缺失字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何选择字体，确保 PPT、PPTX 和 ODP 文件呈现清晰一致—立即改进您的幻灯片。"
---

## **字体选择**

在加载、呈现或转换为其他格式时，演示文稿中的字体适用某些规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体，以验证所选字体在操作系统中是否可用。如果确认字体缺失，则会进行替换——请参阅[**字体替换**](https://docs.aspose.com/slides/python-net/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/python-net/font-substitution/)。

以下是 Aspose.Slides 处理字体时遵循的流程：

1. Aspose.Slides 在操作系统中搜索字体，以查找与演示文稿所选字体匹配的字体。  
2. 如果找到所选字体，Aspose.Slides 会使用它。否则，Aspose.Slides 会使用尽可能接近 PowerPoint 所使用的替代字体。  
3. 如果已通过[FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。  

Aspose.Slides 允许您向应用程序运行时添加字体，然后使用这些字体。请参阅[**自定义字体**](https://docs.aspose.com/slides/python-net/custom-font/)。  

当在演示文稿中嵌入额外字体时，这些字体称为[**嵌入式字体**](https://docs.aspose.com/slides/python-net/embedded-font/)。  

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果您要转换为 PDF 的演示文稿缺少系统和嵌入式字体，您可以将所需字体添加或加载为**外部字体**。  

{{% alert title="Note" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但这需由您自行决定并自行承担责任。  
{{% /alert %}}

## **常见问题**

**如何在转换前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 允许您通过[字体管理器](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) 检查使用的字体，从而决定是否[嵌入](/slides/zh/python-net/embedded-font/)、[替换](/slides/zh/python-net/font-replacement/)或添加[外部来源](/slides/zh/python-net/custom-font/)。这有助于防止在呈现和导出过程中出现不想要的替换。  

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册[外部字体来源](/slides/zh/python-net/custom-font/)（例如文件夹或内存流）用于渲染和导出。这消除了对主机系统字体的依赖，并保持布局可预测。  

**当缺少字形时，如何防止静默回退到不合适的字体？**

预先定义明确的[字体替换](/slides/zh/python-net/font-replacement/)和字体[回退规则](/slides/zh/python-net/fallback-font/)。通过分析使用的字体并为替代字体设置受控的优先级，您可以确保排版一致，避免出现意外结果。