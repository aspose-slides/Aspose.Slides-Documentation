---
title: Pythonを使用したプレゼンテーションのローカライズ自動化
linktitle: プレゼンテーションのローカライズ
type: docs
weight: 100
url: /ja/python-net/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語ID
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETを使用して、PythonでPowerPointおよびOpenDocumentスライドのローカライズを自動化します。実用的なコード例とヒントで、グローバル展開を迅速化します。"
---

## **プレゼンテーションおよびシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形型のオートシェイプを追加します。
- テキストフレームにいくつかのテキストを追加します。
- テキストの言語IDを設定します。
- プレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は、以下の例で示されています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("スペルチェック言語を適用するテキスト")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```