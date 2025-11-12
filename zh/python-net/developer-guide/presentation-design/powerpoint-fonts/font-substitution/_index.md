---
title: 在 Python 中配置演示文稿的字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/python-net/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 替换字体
- 字体更换
- 替换规则
- 更换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在使用 .NET 的 Aspose.Slides for Python 将 PowerPoint 与 OpenDocument 演示文稿转换为其他文件格式时，实现最佳的字体替换。"
---

## **设置替换规则**

Aspose.Slides 允许您为字体设置规则，以确定在特定条件下（例如无法访问某个字体）应执行的操作，步骤如下：

1. 加载相关演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 为替换添加规则。  
5. 将规则添加到演示文稿的字体替换规则集合中。  
6. 生成幻灯片图片以观察效果。

下面的 Python 代码演示了字体替换的过程：

```python
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载将被替换的源字体
    sourceFont = slides.FontData("SomeRareFont")

    # 加载新字体
    destFont = slides.FontData("Arial")

    # 为字体替换添加规则
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # 将规则添加到字体替换规则集合
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # 将字体规则集合设置到演示文稿
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # 当 SomeRareFont 不可访问时，将使用 Arial 代替
    with presentation.slides[0].get_image(1, 1) as bmp:
        # 将图像以 JPEG 格式保存到磁盘
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字体更换**](/slides/zh/python-net/font-replacement/)。 
{{% /alert %}}

## **常见问题解答**

**字体更换与字体替换有什么区别？**

[更换](/slides/zh/python-net/font-replacement/)是在整个演示文稿中强制用另一种字体覆盖原始字体。字体替换是在特定条件下触发的规则，例如原始字体不可用时，使用指定的备用字体。

**替换规则到底何时生效？**

这些规则参与标准的[字体选择](/slides/zh/python-net/font-selection-sequence/)流程，该流程在加载、渲染和转换期间评估；如果选定的字体不可用，则会应用更换或替换。

**如果系统上既未配置更换也未配置替换且缺少字体，默认行为是什么？**

库会尝试选择最接近的可用系统字体，行为类似于 PowerPoint。

**我可以在运行时附加自定义外部字体以避免替换吗？**

可以。您可以在运行时[添加外部字体](/slides/zh/python-net/custom-font/)，库会将其纳入选择和渲染范围，包括后续的转换。

**Aspose 是否随库分发任何字体？**

不。Aspose 不会分发付费或免费字体；字体的添加和使用完全由您自行决定并自行承担责任。

**在 Windows、Linux 和 macOS 上的替换行为是否有差异？**

有。字体发现从操作系统的字体目录开始。默认可用字体集合和搜索路径在不同平台上有所不同，这会影响可用性及替换需求。

**如何准备环境以在批量转换时最小化意外的替换？**

在机器或容器之间同步字体集，[添加外部字体](/slides/zh/python-net/custom-font/)以满足输出文档的需求，并在可能的情况下在演示文稿中[嵌入字体](/slides/zh/python-net/embedded-font/)，这样在渲染时所需字体即可用。