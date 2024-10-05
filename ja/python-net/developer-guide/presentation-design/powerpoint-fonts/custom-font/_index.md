---
title: PythonでのカスタムPowerPointフォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /python-net/custom-font/
keywords: "フォント, カスタムフォント, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointのカスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)クラスの`load_external_fonts`メソッドを使用してこれらのフォントを読み込むことができます：

* TrueType (.ttf)およびTrueType Collection (.ttc)フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType)を参照してください。

* OpenType (.otf)フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType)を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slidesでは、プレゼンテーションにレンダリングされるフォントをインストールせずに読み込むことができます。フォントはカスタムディレクトリから読み込まれます。 

1. [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)クラスのインスタンスを作成し、`load_external_fonts`メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)クラスのキャッシュをクリアします。

このPythonコードはフォント読み込みプロセスを示しています：

```python
import aspose.slides as slides

# ドキュメントディレクトリへのパス。
dataDir = "C:\\"

# フォントを探すフォルダ
folders = [ dataDir ]

# カスタムフォントディレクトリのフォントを読み込みます
slides.FontsLoader.load_external_fonts(folders)

# いくつかの作業を行い、プレゼンテーション/スライドのレンダリングを行います
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# フォントキャッシュをクリアします
slides.FontsLoader.clear_cache()
```

## **カスタムフォントフォルダを取得する**
Aspose.Slidesでは、フォントフォルダを見つけるために`get_font_folders()`メソッドを提供しています。このメソッドは、`LoadExternalFonts`メソッドを通じて追加されたフォルダとシステムフォントフォルダを返します。

このPythonコードは`get_font_folders()`の使い方を示しています：

```python
# この行は、フォントファイルがチェックされるフォルダを出力します。
# それらはload_external_fontsメソッドおよびシステムフォントフォルダを通じて追加されたフォルダです。
fontFolders = slides.FontsLoader.get_font_folders()

```


## **プレゼンテーションで使用されるカスタムフォントを指定する**
Aspose.Slidesでは、プレゼンテーションで使用される外部フォントを指定するために`document_level_font_sources`プロパティを提供しています。

このPythonコードは`document_level_font_sources`プロパティの使い方を示しています：

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
            # プレゼンテーションで作業します
            # CustomFont1, CustomFont2、およびassets\fonts & global\fontsフォルダおよびそのサブフォルダからのフォントがプレゼンテーションで利用可能です
            print(len(presentation.slides))
```

## **フォントを外部で管理する**

Aspose.Slidesでは、バイナリデータから外部フォントを読み込むために`load_external_font`(data)メソッドを提供しています。

このPythonコードはバイト配列フォント読み込みプロセスを示しています：

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
        # プレゼンテーションライフタイム中に読み込まれた外部フォント
        print("処理中")
finally:
    FontsLoader.clear_cache()

```