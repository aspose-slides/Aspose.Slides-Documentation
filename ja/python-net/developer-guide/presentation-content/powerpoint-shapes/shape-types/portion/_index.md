---
title: Pythonでプレゼンテーションのテキスト部分を管理する
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/python-net/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標を取得する**

The [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) method has been added to the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) class which allows retrieving the coordinates of text portions:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の [portion] に[ハイパーリンクを割り当てる](/slides/ja/python-net/manage-hyperlinks/)ことができ、その部分だけがクリック可能になります。段落全体がリンクになることはありません。

**スタイルの継承はどのように機能しますか？Portion が上書きするもの、Paragraph/TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最優先されます。Portion にプロパティが設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) から取得し、そこでも設定されていなければ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/python-net/font-selection-sequence/)が適用されます。テキストの再配置が発生し、メトリック、ハイフネーション、幅が変わる可能性があり、正確な配置に影響します。

**段落全体とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion]レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントとは異なる設定にできます。