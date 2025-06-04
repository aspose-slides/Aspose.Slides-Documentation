---
title: Python でプレゼンテーションを作成する
linktitle: プレゼンテーションを作成
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPT を作成
- 新しい PPT
- PPTX を作成
- 新しい PPTX
- ODP を作成
- 新しい ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint プレゼンテーションを作成します—PPT、PPTX、ODP ファイルを生成し、OpenDocument サポートの利点を活かしてプログラムで保存し、信頼性の高い結果を得る方法を解説します。"
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