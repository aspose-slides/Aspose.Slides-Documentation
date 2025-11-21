---
title: Python を使用したプレゼンテーションのテキスト部分の管理
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標取得**

テキスト部分の座標を取得できるように、[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) クラスに [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) メソッドが追加されました。
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

はい、個々の[ハイパーリンクを割り当てる](/slides/ja/python-net/manage-hyperlinks/) を Portion に割り当てることができます。その断片だけがクリック可能となり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: Portion が上書きするものは何で、Paragraph/TextFrame から取得するものは何ですか？**

Portion レベルのプロパティが最優先です。プロパティが [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) に設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) から取得します。そこにも設定がない場合は、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) のスタイルから取得します。

**Portion に指定したフォントが対象のマシン/サーバーに存在しない場合、どうなりますか？**

[Font substitution rules](/slides/ja/python-net/font-selection-sequence/) が適用されます。テキストは再配置される可能性があり、メトリック、ハイフネーション、幅が変わることがあり、正確な配置に影響します。

**段落全体とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。