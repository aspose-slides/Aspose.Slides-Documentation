---
title: 在 Python via Java 中使用回退字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/python-java/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中使用回退字体渲染演示文稿——通过逐步的 Python 代码示例，保持 PPT、PPTX 和 ODP 文本的一致性。"
---
## **概述**

Aspose.Slides 允许您使用回退字体规则渲染演示文稿。本文展示如何创建回退字体规则集合、通过移除或添加回退字体来修改其规则，以及如何使用 [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法分配该集合。

一旦将回退字体规则集合分配给演示文稿的 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)，这些规则将在保存、渲染和转换演示文稿等操作期间生效。示例演示了在渲染幻灯片缩略图并将其保存为 JPEG 图像时如何使用已配置的规则。

## **使用回退字体规则渲染幻灯片**

1. [创建回退字体规则集合](/slides/zh/python-java/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrule/#remove) 回退字体并[添加回退字体](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) 到另一个规则。
1. 使用在 [getFontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getFontsManager) 返回的字体管理器上调用的 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 来分配规则集合。
1. 使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法将演示文稿保存为相同格式或其他格式。将回退字体规则集合分配给 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 后，这些规则将在演示文稿的保存、渲染、转换等操作期间生效。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# 创建一个新的规则集合。
fallback_rules = FontFallBackRulesCollection()

# 创建多个规则。
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # 尝试从规则中移除回退字体 "Tahoma"。
    fallback_rule.remove("Tahoma")

    # 为指定范围更新规则。
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# 移除现有规则，保留至少一个用于渲染的规则。
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # 分配准备好的规则集合。
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # 使用配置好的规则集合渲染缩略图。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 以 JPEG 格式将图像保存到磁盘。
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
了解更多关于如何在 Python via Java 中将 PPT 和 PPTX 转换为 JPG 的信息，请参阅 [将 PPT 和 PPTX 转换为 JPG（Python via Java）](/slides/zh/python-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}