---
title: 字体替换
type: docs
weight: 60
url: /zh/python-net/font-replacement/
keywords: "字体, 替换字体, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中显式替换 PowerPoint 中的字体"
---

如果您改变了对使用某种字体的想法，可以用另一种字体替换该字体。所有旧字体的实例将被新字体替换。

Aspose.Slides 允许您以这种方式替换字体：

1. 加载相关演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 替换字体。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了字体替换：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载将被替换的源字体
    sourceFont = slides.FontData("Arial")

    # 加载新字体
    destFont = slides.FontData("Times New Roman")

    # 替换字体
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # 保存演示文稿
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

要设置规则以确定在某些条件下发生的情况（例如，如果无法访问某种字体），请参见 [**字体替换**](/slides/zh/python-net/font-substitution/)。 

{{% /alert %}}