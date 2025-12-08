---
title: Pythonでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションローカリゼーション
type: docs
weight: 100
url: /ja/python-net/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して、PowerPoint および OpenDocument スライドのローカリゼーションを自動化し、実用的なコードサンプルとヒントでグローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプの AutoShape を追加します。
- TextFrame にテキストを追加します。
- テキストに Language Id を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

The implementation of the above steps is demonstrated below in an example.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**language_id は自動テキスト翻訳をトリガーしますか？**

No. Aspose.Slides の language_id はスペルチェックと文法校正のための言語情報を保持しますが、テキストを翻訳したり内容を変更したりはしません。これは PowerPoint が校正のために理解するメタデータです。

**language_id はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では language_id は校正用です。ハイフネーションの品質や改行は主に適切なフォントの有無や、文字体系に応じたレイアウト/改行設定に依存します。正しくレンダリングするには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/python-net/font-substitution/) を構成するか、[embed fonts](/slides/ja/python-net/embedded-font/) をプレゼンテーションに埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。language_id はテキストの段落レベルで適用されるため、単一の段落内で複数の言語を混在させ、それぞれ異なる校正設定を持たせることができます。