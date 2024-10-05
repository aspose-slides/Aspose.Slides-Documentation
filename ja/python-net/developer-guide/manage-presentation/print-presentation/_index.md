---
title: プレゼンテーションの印刷
type: docs
weight: 50
url: /python-net/print-presentation/
keywords: "印刷 PowerPoint, PPT, PPTX, プレゼンテーションの印刷, Python, プリンター, 印刷オプション"
description: "PythonでPowerPointプレゼンテーションを印刷"
---
Aspose.Slides for Pythonは、プレゼンテーションを印刷するための4つのオーバーロードされた`print`メソッドを提供します。オーバーロードされたメソッドは異なる引数を受け取るため、常に印刷ニーズに合ったメソッドを見つけることができます。

## **デフォルトプリンターに印刷**

このシンプルな印刷操作は、システムのデフォルトプリンターを通じてPowerPointプレゼンテーション内のすべてのスライドを印刷するために使用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、印刷したいプレゼンテーションを渡します。
2. `print`メソッドを呼び出します（パラメーターなし）。

このPythonコードは、PowerPointプレゼンテーションを印刷する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションをロード
presentation = slides.Presentation("Print.ppt")

# デフォルトプリンターに全体のプレゼンテーションを印刷するためにprintメソッドを呼び出します
presentation.print()
```

## **特定のプリンターに印刷**

この操作は、特定のプリンターを通じてPowerPointプレゼンテーション内のすべてのスライドを印刷するために使用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、印刷したいプレゼンテーションを渡します。
2. `print`メソッドを呼び出し、プリンター名を文字列として渡します。

このPythonコードは、特定のプリンターを使用してPowerPointプレゼンテーションを印刷する方法を示しています：

```python
import aspose.slides as slides

try:
    # プレゼンテーションをロード
    with slides.Presentation("pres.pptx") as pres:
        # 希望するプリンターに全体のプレゼンテーションを印刷するためにprintメソッドを呼び出します
        pres.print("ここにプリンター名を設定してください")
except:
    print("プレゼンテーション印刷メソッドに文字列パラメーターとしてプリンター名を設定してください")
```

## **印刷オプションを動的に設定**

`PrinterSettings`クラスのプロパティを使用して、印刷操作を定義するパラメーターを適用できます。印刷するコピーの数、スライドが横向きまたは縦向きで印刷されるべきか、好みの余白などを指定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、印刷したいプレゼンテーションを渡します。
2. `PrinterSettings`クラスをインスタンス化します。
3. 印刷操作のための好みのパラメーターを指定します：
   * コピーの数
   * ページの向き
   * 余白の数値など
4. `print`メソッドを呼び出します。

このPythonコードは、特定の印刷オプションでPowerPointプレゼンテーションを印刷する方法を示します：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```