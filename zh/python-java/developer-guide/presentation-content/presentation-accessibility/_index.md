---
title: 通过 Java 的 Python 管理演示文稿可访问性
linktitle: 演示文稿可访问性
type: docs
weight: 30
url: /zh/python-java/presentation-accessibility/
keywords:
- 演示文稿可访问性
- 标记为装饰性
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何帮助自动化 PPT、PPTX 和 ODP 文件的演示文稿可访问性检查——提升屏幕阅读器体验并加强合规性。"
---
## **介绍**

演示文稿的可访问性确保使用辅助技术（例如屏幕阅读器、盲文显示器或仅键盘导航）的人能够像视力正常、使用鼠标的观众一样有效地理解和浏览您的幻灯片。良好的实践侧重于清晰的阅读顺序、对信息性视觉元素提供有意义的替代文本、足够的颜色对比度、可读的排版、描述性的链接文字，以及避免仅通过颜色或位置传达意义。若从一开始就规划可访问性，最终将得到更清晰的结构、更一致的视觉效果，以及无需变通即可触达每位观众的内容。

## **标记为装饰性**

标记为装饰性用于标记纯装饰性的视觉元素，使屏幕阅读器跳过它们，减少噪音并将注意力集中在有意义的内容上。将其应用于背景、花纹和间隔元素——绝不可用于传递信息的图表、图标或图像。Aspose.Slides 为此标记提供检测和验证功能，支持自动化的可访问性检查和清理。

![标记为装饰性](mark_as_decorative.png)

以下代码示例展示了如何确定形状是否标记为装饰性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```