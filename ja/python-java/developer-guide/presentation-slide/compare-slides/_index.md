---
title: Python でプレゼンテーション スライドを比較する
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/python-java/compare-slides/
keywords:
- スライドを比較
- スライド比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Java 経由で Python 用 Aspose.Slides を使用して、PowerPoint と OpenDocument のプレゼンテーションをプログラムで比較します。コード内でスライドの違いを素早く特定できます。"
---
## **概要**

Aspose.Slides では、[equals](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#equals) メソッドを提供する [BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) クラスを使用して、スライド、レイアウト スライド、マスタースライドを比較できます。このメソッドは、比較対象のスライドの構造と静的コンテンツが同一である場合に `True` を返します。

## **2 つのスライドを比較する**

[equals](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#equals) メソッドは、[BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) クラス内で、構造と静的コンテンツが同一のスライド、レイアウト スライド、マスタースライドに対して `True` を返します。

すべての図形、スタイル、テキスト、アニメーション、およびその他の設定が同一である場合、2 つのスライドは等しいとみなされます。比較では、スライド ID などの一意の識別子や、日付プレースホルダー内の現在の日付などの動的コンテンツは考慮されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getHidden) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2 つの特定のスライドの等価性は、その構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけで、スライドが異なるとは見なされません。

**ハイパーリンクとそのパラメーターは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクのアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データ ソースは比較時に読み込まれることはほとんどなく、スライドの構造と静的状態に存在するものだけが考慮されます。