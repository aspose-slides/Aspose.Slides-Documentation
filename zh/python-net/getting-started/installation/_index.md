---
title: 安装
type: docs
weight: 70
url: /zh/python-net/installation/
keywords: "下载 Aspose.Slides, 安装 Aspose.Slides, Aspose.Slides 安装, Windows, macOS, Python"
description: "在 Windows 或 macOS 上通过 .NET 安装 Aspose.Slides for Python"
---

Aspose.Slides for Python via .NET 包含所需的 .NET 库，因此不需要单独安装 .NET。 然而，根据您的平台，您可能需要安装特定的 .NET 依赖项并满足某些要求。

## **Windows**

**系统要求**

检查并确认您的机器规格满足或超过 [系统要求](/slides/zh/python-net/system-requirements/)。

### **安装 Aspose.Slides**

`pip` 是在 Windows 设备上下载和安装 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) 的最简单方法。

要安装 Aspose.Slides，请运行此命令： `pip install aspose.slides`

**使用 Aspose.Slides**

通过运行以下代码创建 PowerPoint 演示文稿来测试您的 Aspose.Slides 安装：

```python
# 导入 Aspose.Slides for Python via .NET 模块
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 对象
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**系统要求**

检查并确认您的机器规格满足或超过 [系统要求](/slides/zh/python-net/system-requirements/)。

### **先决条件**

**具有共享库的 Python**

在 macOS 上安装 Python 有不同的方法，但我们强烈建议您使用 [pyenv 工具](https://github.com/pyenv/pyenv#homebrew-in-macos)。

在您安装并配置 pyenv 后，您必须通过在终端应用中运行以下命令来安装具有共享库的 python：

1. 安装 Python： `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. 将其配置为全局 Python 安装： `pyenv global 3.9.13`
3. 将其配置为 shell Python 安装： `pyenv shell 3.9.13`
4. 在系统库目录中为 libpython 库创建符号链接： `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

注意：需要 Python 3.5 及以上版本。Python 版本 3.9.13 仅作为示例使用。

**安装 libgdiplus 库**

libgdiplus 库是 Windows GDI+ 在 macOS 和 Linux 上的实现，.NET 在这些平台上使用。要安装此库，请运行此命令： `brew install mono-libgdiplus` 

### **安装 Aspose.Slides**

`pip` 是在 macOS 设备上下载和安装 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) 的最简单方法。 要安装 Aspose.Slides，请运行此命令： `pip install aspose.slides`

**使用 Aspose.Slides**

通过运行以下代码创建 PowerPoint 演示文稿来测试您的 Aspose.Slides 安装：

```python
# 导入 Aspose.Slides for Python via .NET 模块
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 对象
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```