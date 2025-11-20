---
title: PyInstaller 与 cx_Freeze 的兼容性
linktitle: PyInstaller 兼容性
type: docs
weight: 122
url: /zh/python-net/compatibility-with-pyinstaller/
keywords:
- 兼容性
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "使用 PyInstaller 打包 Aspose.Slides for Python via .NET。请遵循本指南将您的应用程序打包、配置并排除故障，以生成独立的可执行文件。"
---

## **兼容性与 PyInstaller 和 cx_Freeze**

Aspose.Slides for Python via .NET 扩展是标准的 Python C 扩展，因此可以使用 PyInstaller、cx_Freeze（或类似工具）将其冻结为程序依赖。这使得您可以从 Python 脚本创建可执行文件。这类工具被称为 “freezers”，因为它们会将您的代码及其依赖打包成一个可在其他机器上运行的可分发文件，无需安装 Python 或额外库。这种方式简化了 Python 应用的分发。

下面演示了将 Aspose.Slides for Python via .NET 扩展作为依赖进行冻结的简单示例程序。

### **PyInstaller**

通常，在打包依赖于 Aspose.Slides for Python via .NET 扩展的程序时无需特殊操作。当程序以 PyInstaller 可检测的方式导入该扩展时，扩展会随程序一起打包。由于 Aspose.Slides for Python via .NET 包含 PyInstaller Hook，其依赖会自动被检测并复制到捆绑包中。

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


然而，PyInstaller 有时会遗漏隐藏导入——即代码动态或间接导入的模块。要包含隐藏导入，请使用 PyInstaller 的相应选项。该扩展的依赖已在随 Aspose.Slides for Python via .NET 提供的 PyInstaller Hook 中声明。

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

使用 cx_Freeze 冻结程序时，需要配置它以包含您使用的 Aspose.Slides for Python via .NET 扩展的根包。这样可以保证扩展及所有依赖模块在构建时被复制到输出目录，随应用一起分发。

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

**我是否需要在用户机器上安装 Microsoft PowerPoint 或 .NET？**

不需要。PowerPoint 并非必需。Aspose.Slides 是一个独立的引擎；Python 包作为 CPython 扩展提供所有必需组件，用户无需单独安装 .NET。

**如何正确地将许可证附加到冻结后的应用程序？**

可以将许可证 XML 放置在可执行文件旁边，或作为资源嵌入，并在首次调用 API 之前从可访问路径加载。重要提示：请勿修改 XML 内容（包括换行符）。

**构建后字体渲染与开发时不一致，我该怎么办？**

确保在目标环境中能够找到所使用的字体（已打包或系统已安装），并且运行时能够正确解析其路径；字体行为在 Linux 上尤为敏感。