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
description: "使用 PyInstaller 将 Aspose.Slides for Python via .NET 打包。按照本指南将您的应用程序打包、配置并排除故障为独立可执行文件。"
---


## 与 PyInstaller 和 cx_Freeze 的兼容性 ##

'Aspose.Slides for Python via .NET' 扩展只是 Python C 扩展，可以借助 PyInstaller 和 cx_Freeze（或类似工具）作为程序依赖进行冻结。这意味着您可以使用 PyInstaller 和 cx_Freeze 之类的工具从 Python 脚本创建可执行文件。这些工具被称为冻结器，因为它们将您的代码和依赖项冻结到一个可以在其他机器上运行的单一文件中，而无需 Python 或其他库。这样使得将您的 Python 应用程序分发给他人变得更容易。

将 'Aspose.Slides for Python via .NET' 扩展作为程序依赖进行冻结的示例展示了一个使用 Aspose.Slides 的简单程序。

### PyInstaller ###
一般来说，在打包依赖于 'Aspose.Slides for Python via .NET' 扩展的程序时不需要特别的操作。当程序以 PyInstaller 可见的方式导入扩展时，扩展将与程序一起打包。由于 'Aspose.Slides for Python via .NET' 扩展带有 PyInstaller 钩子，因此将找到并复制它们自己的依赖项到包中。

slide_app.py：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

```
$ pyinstaller slide_app.py
```

但是，有时 PyInstaller 无法检测到一些隐藏导入，这些是被您的代码动态或间接导入的模块。要在 PyInstaller 中处理隐藏导入，请使用 PyInstaller 的选项。扩展的依赖项在与 'Aspose.Slides for Python via .NET' 扩展一起提供的 PyInstaller 钩子中指定。

slide_app.spec：
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```
$ pyinstaller slide_app.spec
```

### cx_Freeze ###
要使用 cx_Freeze 冻结程序，请使用其选项来冻结您正在使用的 'Aspose.Slides for Python via .NET' 扩展的根包。这将确保扩展及其依赖的模块与程序一起复制。

#### 使用 cxfreeze 脚本 ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### 使用 Setup 脚本 ####
setup.py：
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

```
$ python setup.py build_exe
```