---
title: 在 Python 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/python-net/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 幻灯片中嵌入自定义字体，以确保您的演示文稿在任何设备上都保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides允许您使用`load_external_fonts`方法加载这些字体，来自[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)类：

* TrueType (.ttf)和TrueType Collection (.ttc)字体。请参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf)字体。请参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides允许您加载在演示文稿中渲染的字体，而无需安装这些字体。字体从自定义目录加载。 

1. 创建[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)类的实例并调用`load_external_fonts`方法。
2. 加载将被渲染的演示文稿。
3. 清除[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)类中的缓存。

以下Python代码演示了字体加载过程：

```python
import aspose.slides as slides

# 文档目录的路径。
dataDir = "C:\\"

# 查找字体的文件夹
folders = [ dataDir ]

# 加载自定义字体目录的字体
slides.FontsLoader.load_external_fonts(folders)

# 做一些工作并执行演示文稿/幻灯片渲染
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# 清除字体缓存
slides.FontsLoader.clear_cache()
```

## **获取自定义字体文件夹**
Aspose.Slides提供`get_font_folders()`方法，以便您查找字体文件夹。该方法返回通过`LoadExternalFonts`方法添加的文件夹和系统字体文件夹。

以下Python代码向您展示如何使用`get_font_folders()`：

```python
# 这一行输出检查字体文件的文件夹。
# 这些是通过load_external_fonts方法添加的文件夹和系统字体文件夹。
fontFolders = slides.FontsLoader.get_font_folders()

```


## **指定与演示文稿一起使用的自定义字体**
Aspose.Slides提供`document_level_font_sources`属性，以便您指定将与演示文稿一起使用的外部字体。

以下Python代码向您展示如何使用`document_level_font_sources`属性：

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # 处理演示文稿
            # CustomFont1、CustomFont2和来自assets\fonts & global\fonts文件夹及其子文件夹的字体可供演示文稿使用
            print(len(presentation.slides))
```

## **外部管理字体**

Aspose.Slides提供`load_external_font`(data)方法，以便您从二进制数据加载外部字体。

以下Python代码演示了字节数组字体加载过程：

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # 在演示文稿生命周期中加载的外部字体
        print("processing")
finally:
    FontsLoader.clear_cache()

```