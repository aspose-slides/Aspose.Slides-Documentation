---
title: Pythonで上付き文字と下付き文字を管理
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/python-net/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字を追加
- 下付き文字を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETで上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大のインパクトに高めましょう。"
---

## **上付き文字と下付き文字の追加**

任意の段落部分に上付き文字や下付き文字を追加できます。Aspose.Slides では、`escapement` プロパティを使用して [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) クラスでこれを制御します。

`escapement` は **-100% から 100%** のパーセンテージです:

- **> 0** → 上付き (例: 25% = わずかに上がる; 100% = 完全な上付き)
- **0** → ベースライン (上付き/下付きなし)
- **< 0** → 下付き (例: -25% = わずかに下がる; -100% = 完全な下付き)

手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、スライドを取得します。
2. 四角形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
3. 既存の段落をクリアします。
4. 上付き文字の場合: 段落と部分を作成し、`portion.portion_format.escapement` を **0 から 100** の値に設定し、テキストを設定して部分を追加します。
5. 下付き文字の場合: 別の段落と部分を作成し、`escapement` を **-100 から 0** の値に設定し、テキストを設定して部分を追加します。
6. プレゼンテーションを PPTX として保存します。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # スライドを取得します。
    slide = presentation.slides[0]

    # テキストボックスを作成します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # 上付き文字用の段落を作成します。
    superscript_paragraph = slides.Paragraph()

    # 通常テキストのテキスト部分を作成します。
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # 上付き文字のテキスト部分を作成します。
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # 下付き文字用の段落を作成します。
    subscript_paragraph = slides.Paragraph()

    # 通常テキストのテキスト部分を作成します。
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # 下付き文字のテキスト部分を作成します。
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # 段落をテキストボックスに追加します。
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**テキスト ボックスだけでなく、テーブルやその他のコンテナでも上付き/下付きを適用できますか？**

はい。テキスト フレーム ([TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)) を公開している任意のオブジェクト（テーブル セルを含む）内で、テキストを上付きまたは下付きとして書式設定できます。この書式はそのフレーム内のテキスト部分に適用されます。

**PDF、HTML、画像などにエクスポートする際に上付き/下付きは保持されますか？**

はい。Aspose.Slides は、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[ラスタ画像](/slides/ja/python-net/convert-powerpoint-to-png/) などの一般的な形式へのエクスポート時に、上付き/下付きの書式設定を保持します。レンダリング パイプラインは部分レベルのテキスト書式設定を尊重します。

**同じテキスト フラグメント内で上付き/下付きとハイパーリンクを組み合わせられますか？**

はい。[ハイパーリンク](/slides/ja/python-net/manage-hyperlinks/) は部分（フラグメント）レベルで割り当てられるため、部分はハイパーリンクを持ちつつ上付きまたは下付きとして書式設定できます。