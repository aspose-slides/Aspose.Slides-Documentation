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
description: "Python と Aspose.Slides を使用して、PowerPoint および OpenDocument のスライドローカリゼーションを自動化し、実用的なコードサンプルと迅速なグローバル展開のためのヒントを提供します。"
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプの AutoShape を追加します。
- TextFrame にテキストを追加します。
- テキストに Language Id を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**language_id は自動テキスト翻訳をトリガーしますか？**

いいえ。Aspose.Slides の [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) はスペルチェックと文法校正のための言語情報を保持しますが、テキスト内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**language_id はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) は校正用です。ハイフネーションの品質や改行は主に、[適切なフォント](/slides/ja/python-net/powerpoint-fonts/) の有無や、書字体系のレイアウト・改行設定に依存します。正しい表示を保証するには、必要なフォントを用意し、[フォント置換ルール](/slides/ja/python-net/font-substitution/) を設定するか、またはプレゼンテーションに [フォントを埋め込む](/slides/ja/python-net/embedded-font/) 必要があります。

**単一の段落内で異なる言語を設定できますか？**

はい。[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) はテキストの部分レベルで適用されるため、単一の段落内で複数の言語を異なる校正設定と共に混在させることが可能です。