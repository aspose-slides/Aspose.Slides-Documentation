---
title: 安装
type: docs
weight: 70
url: /zh/python-net/installation/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- macOS
- Python
description: "了解如何快速安装 Aspose.Slides for Python via .NET。一步步指南、系统要求和代码示例——今天就开始使用 PowerPoint 演示文稿！"
---

## **概述**

Aspose.Slides for Python via .NET 包已捆绑所有必需的 .NET 库，这意味着无需单独安装 .NET。这简化了设置流程，开发者可以立即开始处理演示文稿。但需要注意的是，根据您的操作系统或环境，可能仍需安装 .NET 所需的某些平台特定依赖项。此外，还必须满足特定的系统要求，以确保该包的完全兼容性和正常运行。

## **Windows**

**系统要求**

检查并确认您的机器规格满足或超过[系统要求](/slides/zh/python-net/system-requirements/)。

### **安装 Aspose.Slides**

`pip` 是在 Windows 上下载并安装 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) 的最简方式。

要安装 Aspose.Slides，请运行以下命令:
```sh
pip install aspose-slides
```


**使用 Aspose.Slides**

通过运行以下代码创建 PowerPoint 演示文稿来测试您的 Aspose.Slides 安装:
```python
# 导入 Aspose.Slides for Python via .NET 模块。
import aspose.slides as slides

# 实例化代表演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**系统要求**

检查并确认您的机器规格满足或超过[系统要求](/slides/zh/python-net/system-requirements/)。

### **先决条件**

**带共享库的 Python**

在 macOS 上安装 Python 有多种方式，但我们强烈推荐使用[pyenv 工具](https://github.com/pyenv/pyenv#homebrew-in-macos)。

安装并配置好 **pyenv** 后，通过在 Terminal 应用中运行以下命令来安装带共享库的 Python：

1. 安装 Python:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. 将其设为全局 Python 版本:
```sh
pyenv global 3.9.13
```


3. 将其设为特定 shell 的 Python 版本:
```sh
pyenv shell 3.9.13
```


4. 在系统库目录中为 libpython 库创建符号链接:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


注意: 需要 Python 3.5 或更高版本。此处示例使用 3.9.13。

**安装 libgdiplus 库**

**libgdiplus** 库是 .NET 在 macOS 和 Linux 上用于图形功能的 Windows GDI+ 实现。

在 macOS 上安装此库，请运行以下命令:
```sh
brew install mono-libgdiplus
```


### **安装 Aspose.Slides**

`pip` 是在 macOS 上下载并安装 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) 的最简方式。

要安装 Aspose.Slides，请运行以下命令:
```sh
pip install aspose-slides
```


**使用 Aspose.Slides**

通过运行以下代码创建 PowerPoint 演示文稿来测试您的 Aspose.Slides 安装:
```python
# 导入 Aspose.Slides for Python via .NET 模块。
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**我可以在虚拟环境中安装 Aspose.Slides 吗？**

是的，您可以在任何 Python 虚拟环境中使用 `pip` 安装。只需确保该环境能够访问所需的原生依赖项，具体取决于您的操作系统。

**我可以在 Docker 容器中使用 Aspose.Slides 吗？**

是的，但您需要确保 Docker 镜像包含必需的原生库（**libgdiplus**、字体包等）以及正确版本的 Python。

**是否有免费版或试用限制？**

是的，默认情况下，Aspose.Slides 以评估模式运行，会添加水印并可能有其他限制。要移除这些限制，您需要应用有效的[许可证](/slides/zh/python-net/licensing/)。