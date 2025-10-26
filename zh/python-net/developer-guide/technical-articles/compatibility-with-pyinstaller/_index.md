---
title: 与 PyInstaller 和 cx_Freeze 的兼容性
linktitle: 与 PyInstaller 的兼容性
type: docs
weight: 122
url: /zh/python-net/developer-guide/technical-articles/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "使用 PyInstaller 将 Aspose.Slides for Python via .NET 打包。按照本指南将应用程序打包、配置并排除故障，生成独立可执行文件。"
---

## **与 PyInstaller 和 cx_Freeze 的兼容性**

Aspose.Slides for Python via .NET 扩展是标准的 Python C 扩展，因此可以使用 PyInstaller、cx_Freeze（或类似）等工具将其冻结为程序依赖项。这使您能够根据 Python 脚本创建可执行文件。这类工具被称为 “冻结器”，因为它们将您的代码及其依赖项打包成单个可分发文件，无需在其他机器上安装 Python 或额外库即可运行。这种方法简化了 Python 应用程序的分发。

下面示例演示了如何将 Aspose.Slides for Python via .NET 扩展作为依赖项进行冻结，示例程序使用了 Aspose.Slides。

### **PyInstaller**

通常情况下，打包依赖于 Aspose.Slides for Python via .NET 扩展的程序不需要特殊操作。当程序以 PyInstaller 可检测的方式导入该扩展时，扩展会随程序一起被打包。因为 Aspose.Slides for Python via .NET 包含了 PyInstaller 钩子，其依赖项会自动被检测并复制到捆绑包中。

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

然而，PyInstaller 有时会遗漏隐藏导入——即代码动态或间接导入的模块。要包含隐藏导入，请使用 PyInstaller 的相应选项。该扩展的依赖项已在随 Aspose.Slides for Python via .NET 提供的 PyInstaller 钩子中声明。

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

要使用 cx_Freeze 冻结程序，需配置它以包含您使用的 Aspose.Slides for Python via .NET 扩展的根包。这可确保扩展及其所有依赖模块与您的应用程序一起复制到构建目录中。

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

## **常见问题**

**是否需要在用户机器上安装 Microsoft PowerPoint 或 .NET？**

不需要，PowerPoint 不是必装项。Aspose.Slides 为自包含引擎；Python 包作为 CPython 的扩展提供了所需的全部内容。用户无需单独安装 .NET。

**如何正确地将许可证附加到冻结后的应用程序？**

可以将许可证 XML 与可执行文件放在同一目录下，或将其嵌入为资源，并在首次调用 API 前从可访问路径加载。重要提示：不要修改 XML 内容（包括换行符）。

**构建后字体渲染与开发时不同，该怎么办？**

确保您使用的字体在目标环境中可用（已打包或系统已安装），并且运行时能够正确解析其路径；字体行为在 Linux 上尤为敏感。