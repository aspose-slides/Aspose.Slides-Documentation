---
title: Pythonでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
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
- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプの AutoShape を追加します。
- TextFrame にテキストを追加します。
- テキストに Language Id を設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例は以下のサンプルで示しています。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Does language ID trigger automatic text translation?**

いいえ。Aspose.Slides の [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) はスペルチェックや文法校正のための言語情報を保持しますが、テキストの内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**Does language ID affect hyphenation and line breaks during rendering?**

Aspose.Slides では、[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) は校正のために使用されます。ハイフネーションの品質や改行は主に、[proper fonts](/slides/ja/python-net/powerpoint-fonts/) の有無や、書記体系に応じたレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/python-net/font-substitution/) を構成するか、またはプレゼンテーションに[embed fonts](/slides/ja/python-net/embedded-font/) を埋め込んでください。

**Can I set different languages within a single paragraph?**

はい。[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) はテキスト部分レベルで適用されるため、単一の段落内で複数の言語を異なる校正設定で混在させることができます。