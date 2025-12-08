---
title: 在 Python 中配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/python-net/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在将 PowerPoint 和 OpenDocument 演示文稿转换为其他文件格式时，通过 .NET 为 Aspose.Slides for Python 启用最佳字体替代。"
---

## **设置替代规则**

Aspose.Slides 允许您为字体设置规则，以确定在特定条件下（例如，无法访问字体时）应执行的操作，如下所示：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 为替换添加规则。
5. 将该规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

下面的 Python 代码演示了字体替代过程：
```python
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载将被替换的源字体
    sourceFont = slides.FontData("SomeRareFont")

    # 加载新字体
    destFont = slides.FontData("Arial")

    # 添加用于字体替换的字体规则
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # 将规则添加到字体替换规则集合
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # 将字体规则集合添加到规则列表
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial 字体将在 SomeRareFont 不可访问时使用
    with presentation.slides[0].get_image(1, 1) as bmp:
        # 将图像以 JPEG 格式保存到磁盘
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字体替换**](/slides/zh/python-net/font-replacement/)。 
{{% /alert %}}

## **常见问题**

**字体替换和字体替代有什么区别？**

[Replacement](/slides/zh/python-net/font-replacement/) 是在整个演示文稿中强制用另一种字体覆盖原始字体的做法。Substitution 是在特定条件下触发的规则，例如原始字体不可用时，使用指定的后备字体。

**替代规则何时生效？**

这些规则参与标准的[font selection](/slides/zh/python-net/font-selection-sequence/)流程，该流程在加载、渲染和转换期间进行评估；如果所选字体不可用，则会应用替换或替代。

**如果未配置替换或替代且系统缺少该字体，默认行为是什么？**

库会尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时添加自定义外部字体以避免替代吗？**

可以。您可以在运行时[add external fonts](/slides/zh/python-net/custom-font/) ，使库在选择和渲染时考虑这些字体，包括后续的转换。

**Aspose 会随库分发任何字体吗？**

不会。Aspose 不会分发付费或免费字体；您自行添加和使用字体，需自行承担责任。

**在 Windows、Linux 和 macOS 上，替代行为有差异吗？**

有。字体发现从操作系统的字体目录开始。默认可用字体集合和搜索路径因平台而异，这会影响字体的可用性以及是否需要替代。

**如何准备环境以最大限度减少批量转换期间意外的替代？**

在机器或容器之间同步字体集合，[add the external fonts](/slides/zh/python-net/custom-font/) 以满足输出文档的需求，并在可能的情况下在演示文稿中[embed fonts](/slides/zh/python-net/embedded-font/) ，以确保渲染时所选字体可用。