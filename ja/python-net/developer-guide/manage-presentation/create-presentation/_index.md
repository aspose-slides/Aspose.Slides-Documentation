---
title: プレゼンテーションの作成
type: docs
weight: 10
url: /python-net/create-presentation/
keywords: "PowerPointの作成, PPTX, PPT, プレゼンテーションの作成, プレゼンテーションの初期化, Python, .NET"
description: "PythonでPowerPointプレゼンテーションを開く"
---

## **PowerPointプレゼンテーションの作成**
選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `shapes`オブジェクトによって公開されている`add_auto_shape`メソッドを使用して、`LINE`タイプのAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```