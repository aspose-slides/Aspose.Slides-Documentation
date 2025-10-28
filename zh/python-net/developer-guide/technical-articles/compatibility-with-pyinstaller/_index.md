---
title: 兼容 PyInstaller 和 cx_Freeze
linktitle: 兼容 PyInstaller
type: docs
weight: 122
url: /zh/python-net/compatibility-with-pyinstaller/
keywords:
- 兼容性
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "使用 PyInstaller 打包 Aspose.Slides for Python via .NET。请遵循本指南，将您的应用程序打包、配置并排除故障，以生成独立的可执行文件。"
---

## **兼容 PyInstaller 和 cx_Freeze**

Aspose.Slides for Python via .NET 扩展是标准的 Python C 扩展，因此可以使用 PyInstaller、cx_Freeze（或类似工具）将其冻结为程序依赖项。这使您能够从 Python 脚本生成可执行文件。这类工具被称为 “freezers”，因为它们将您的代码及其依赖项打包成一个可在其他机器上运行的可分发文件，无需安装 Python 或额外的库。这种方式简化了 Python 应用程序的分发。

下面的示例展示了如何将 Aspose.Slides for Python via .NET 扩展作为依赖项进行冻结，示例程序使用了 Aspose.Slides。

### **PyInstaller**

通常，打包依赖 Aspose.Slides for Python via .NET 扩展的程序无需额外操作。当程序以 PyInstaller 能检测到的方式导入该扩展时，扩展会随程序一起被打包。由于 Aspose.Slides for Python via .NET 包含了 PyInstaller hook，相关依赖会自动被检测并复制到打包产物中。

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

然而，PyInstaller 有时会遗漏隐藏导入——即代码动态或间接导入的模块。若需包含隐藏导入，请使用 PyInstaller 的相应选项。扩展的依赖在随 Aspose.Slides for Python via .NET 提供的 PyInstaller hook 中已声明。

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

使用 cx_Freeze 冻结程序时，需要将您使用的 Aspose.Slides for Python via .NET 扩展的根包配置进去。这样即可确保扩展及其所有依赖模块在构建过程中被复制到生成目录中，随应用程序一起分发。

#### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Using the Setup Script**

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

**用户的机器上是否需要安装 Microsoft PowerPoint 或 .NET？**

不需要，PowerPoint 并非必装。Aspose.Slides 是一个独立的引擎；Python 包以 CPython 扩展的形式提供所有必要的组件。用户无需单独安装 .NET。

**我该如何正确地将许可证附加到冻结的应用程序中？**

可以将许可证 XML 放在可执行文件旁边，或将其嵌入为资源，并在首次调用 API 前从可访问路径加载。重要提示：不要修改 XML 内容（包括换行符）。

**如果在构建后字体渲染与开发时不同，我应该怎么办？**

确保在目标环境中（无论是打包进去的还是系统已安装的）所用字体可用，并且运行时能够正确解析其路径；字体行为在 Linux 上尤为敏感。