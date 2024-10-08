---
title: 比较幻灯片
type: docs
weight: 50
url: /python-net/compare-slides/
keywords: "比较 PowerPoint 幻灯片, 比较两张幻灯片, 演示文稿, Python, Aspose.Slides"
description: "在 Python 中比较 PowerPoint 演示文稿幻灯片"
---

## **比较两张幻灯片**
Equals 方法已添加到 [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) 接口和 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类中。对于结构和静态内容相同的幻灯片/布局和幻灯片/母版幻灯片，它返回 true。

如果所有形状、样式、文本、动画和其他设置等都相等，则两张幻灯片是相等的。比较不考虑唯一标识符值，例如 SlideId 和动态内容，例如日期占位符中的当前日期值。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("演示文稿1 的母版幻灯片#{0} 等于 演示文稿2 的母版幻灯片#{1}".format(i,j))
```