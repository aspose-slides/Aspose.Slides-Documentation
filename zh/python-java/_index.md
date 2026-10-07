---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /zh/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint 库
- 在 Python 中管理 PowerPoint 演示文稿
- 在 Python 中读取和写入 PowerPoint
- 在 Python 中编辑 PowerPoint 幻灯片
- 在 Python 中将 PowerPoint 导出为 PDF
- 在 Python 中将 PowerPoint 导出为 SVG
- 在 Python 中预览幻灯片
- 在 Python 中向幻灯片添加音频和视频
- 无需 Microsoft Office 的 PowerPoint
- Python
- Java
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for Python via Java，创建第一个演示文稿，并查找常见任务指南、API 参考和支持。"
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java 是一个库，用于在 Python 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint；它通过 JPype 在您的 Python 进程中运行 Aspose.Slides Java 引擎。

它可以加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括支持宏的和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>快速入门</b></p>
<hr>
<p>入门指南</p>
<ul>
<li><a href="/slides/zh/python-java/installation/">安装</a></li>
<li><a href="/slides/zh/python-java/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/python-java/getting-started/">快速入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/python-java/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/python-java/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/python-java/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/python-java/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/python-java/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/python-java/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/python-java/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/python-java/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/python-java/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/python-java/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/python-java/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/python-java/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/python-java/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/python-java/examples/">按幻灯片元素划分的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/python-java/known-issues/">已知问题</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">产品页面</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持服务台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

安装 Python 和 JDK，设置 `JAVA_HOME`，并按照 [安装](/slides/zh/python-java/installation/) 中的描述创建并激活虚拟环境。然后从 PyPI 安装 JPype 和 Aspose.Slides：

```sh
python -m pip install JPype1 aspose-slides-java
```

将此代码保存为 *hello.py*。它启动 Java 虚拟机，在新演示文稿的第一页添加一个带文本的云形状，并保存演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 创建一个包含一个空白幻灯片的演示文稿。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个云形状并设置其文本。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在相同的虚拟环境中运行它：

```sh
python hello.py
```

该脚本会保存名为 *new_presentation.pptx* 的文件，文件包含一张幻灯片，其中有一个带有文本 “Hello, Aspose!” 的云形状。未获取授权时，保存的文件会带有评估水印 — 请参阅 [授权](/slides/zh/python-java/licensing/)。有关创建和填充演示文稿的更多方法，请参阅 [创建演示文稿](/slides/zh/python-java/create-presentation/).