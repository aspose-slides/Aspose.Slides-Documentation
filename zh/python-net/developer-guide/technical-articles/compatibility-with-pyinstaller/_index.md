---
title: 与 PyInstaller 和 cx_Freeze 的兼容性
linktitle: 与 PyInstaller 的兼容性
type: docs
weight: 122
url: /zh/python-net/compatibility-with-pyinstaller/
keywords:
- 兼容性
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "使用 PyInstaller 打包 Aspose.Slides for Python via .NET。遵循本指南将您的应用程序打包、配置并排查问题，以生成独立可执行文件。"
---

## **与 PyInstaller 和 cx_Freeze 的兼容性**

Aspose.Slides for Python via .NET 扩展是标准的 Python C 扩展，因此可以使用 PyInstaller、cx_Freeze（或类似）等工具将其冻结为程序依赖项。这使您能够从 Python 脚本创建可执行文件。这类工具被称为 “冻结器”，因为它们将您的代码及其依赖项打包成单个可分发文件，无需在其他机器上安装 Python 或额外库即可运行。这种方式简化了 Python 应用程序的分发。

下面演示了如何将 Aspose.Slides for Python via .NET 扩展作为依赖项进行冻结，示例程序使用 Aspose.Slides。

### **PyInstaller**

通常，在打包依赖 Aspose.Slides for Python via .NET 扩展的程序时无需特殊处理。当程序以 PyInstaller 可检测的方式导入扩展时，扩展会随程序一起打包。由于 Aspose.Slides for Python via .NET 包含 PyInstaller 钩子，其依赖项会自动被检测并复制到捆绑包中。

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

然而，PyInstaller 有时会遗漏隐藏导入——即代码动态或间接导入的模块。要包含隐藏导入，请使用 PyInstaller 的选项。扩展的依赖项在 Aspose.Slides for Python via .NET 随附的 PyInstaller 钩子中已指定。

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

### **cx_Freeze**

要使用 cx_Freeze 冻结程序，需要配置其包含您使用的 Aspose.Slides for Python via .NET 扩展的根包。这确保扩展及所有依赖模块在构建时随您的应用程序一起复制。

#### **使用 cxfreeze 脚本**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **使用 Setup 脚本**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**是否需要在用户机器上安装 Microsoft PowerPoint 或 .NET？**

不需要，PowerPoint 不是必需的。Aspose.Slides 是一个独立的引擎；Python 包将所有必需的内容作为 CPython 的扩展一起提供。用户无需单独安装 .NET。

**如何正确地将许可证附加到冻结后的应用程序？**

可以将许可证 XML 文件放在可执行文件旁边，或将其嵌入为资源并在首次 API 调用前从可访问路径加载。重要提示：不要修改 XML 内容（包括换行符）。

**构建后字体渲染与开发时不同，该怎么办？**

确保您使用的字体在目标环境中可用（已打包或系统已安装），并且运行时能够正确解析其路径；字体行为在 Linux 上尤其敏感。