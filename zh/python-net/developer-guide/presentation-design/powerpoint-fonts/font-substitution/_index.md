---
title: 字体替换
type: docs
weight: 70
url: /zh/python-net/font-substitution/
keywords: "字体, 替代字体, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中替代 PowerPoint 字体"
---

Aspose.Slides 允许您设置字体规则，以确定在特定条件下必须执行的操作（例如，当无法访问某种字体时），步骤如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 Python 代码演示了字体替换的过程：

```python
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载将被替换的源字体
    sourceFont = slides.FontData("SomeRareFont")

    # 加载新字体
    destFont = slides.FontData("Arial")

    # 添加字体替换规则
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # 将规则添加到字体替代规则集合中
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # 将字体规则集合添加到规则列表中
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # 当 SomeRareFont 无法访问时，将使用 Arial 字体代替
    with presentation.slides[0].get_image(1, 1) as bmp:
        # 将图像保存到硬盘，格式为 JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="注意"  color="warning"   %}} 

您可能想查看 [**字体替换**](/slides/zh/python-net/font-replacement/)。 

{{% /alert %}}