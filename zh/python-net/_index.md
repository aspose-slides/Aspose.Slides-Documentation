---
title: 适用于 .NET 的 Aspose.Slides Python 版
second_title: Aspose.Slides Python 版
type: docs
weight: 35
url: /zh/python-net/
is_root: true
keywords:
- Aspose.Slides Python 版
- PowerPoint 自动化 Python
- Python PPT 库
- 将 PowerPoint 导出为 PDF 的 Python 库
- 将 PowerPoint 导出为 SVG 的 Python 库
- 在 Python 中编辑 PowerPoint
- 无需 Microsoft Office 的 Python PowerPoint
- 使用 Python 管理 PPTX
- Python 幻灯片预览
- Python 为幻灯片添加音频
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "从这里开始：安装适用于 .NET 的 Aspose.Slides Python 版，创建第一个演示文稿，并查找常用任务指南、API 参考和支持。"
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET 是一个 Python 库，可用于创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint 或 Microsoft Office。

它可以加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括带宏的和模板变体，并导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>快速入门</b></p>
<hr>
<p>开始使用</p>
<ul>
<li><a href="/slides/zh/python-net/installation/">安装</a></li>
<li><a href="/slides/zh/python-net/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/python-net/getting-started/">快速入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/python-net/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/python-net/evaluate-aspose-slides/">试用版限制</a></li>
<li><a href="/slides/zh/python-net/licensing/">授权许可</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/python-net/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/python-net/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/python-net/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/python-net/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/python-net/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/python-net/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/python-net/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/python-net/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/python-net/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/python-net/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/python-net/examples/">按幻灯片元素分类的示例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub 示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh/python-net/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/zh/python-net/release-notes/">发行说明</a></li>
<li><a href="https://releases.aspose.com/slides/zh/python-net/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

从 PyPI 安装包：

```bash
pip install aspose.slides
```

该包包含其使用的 .NET 运行时，因此您无需安装 .NET。在 Linux 上，还需安装 libgdiplus 和 ICU 库；在 Debian 或 Ubuntu 的系统 Python 环境中，请在虚拟环境中运行该命令。macOS 还有其他先决条件，我们尚未验证该平台的安装。请参阅[安装](/slides/zh/python-net/installation/)获取命令、macOS 先决条件以及受支持的 Python 版本。

将此代码保存为 *hello.py*：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加类型为 CLOUD 的自动形状。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

使用 `python hello.py` 运行它。脚本会在当前文件夹中保存 *new_presentation.pptx*，其中包含一张带有云形状并显示“Hello, Aspose!”的幻灯片。若未授权，保存的文件会带有评估水印 —— 请参阅[授权许可](/slides/zh/python-net/licensing/)。欲了解创建和填充演示文稿的更多方法，请查看[创建演示文稿](/slides/zh/python-net/create-presentation/)。