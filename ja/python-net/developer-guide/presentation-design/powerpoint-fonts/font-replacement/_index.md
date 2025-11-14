---
title: Python でプレゼンテーションのフォント置換を効率化する
linktitle: フォント置換
type: docs
weight: 60
url: /ja/python-net/font-replacement/
keywords:
- フォント
- フォントを置換
- フォント置換
- フォントを変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションの一貫性のあるタイポグラフィを実現するために、シームレスにフォントを置換します。"
---

フォントの使用について気が変わった場合、そのフォントを別のフォントに置き換えることができます。古いフォントのすべてのインスタンスは新しいフォントに置き換えられます。

Aspose.Slidesを使用してフォントをこのように置き換えることができます：

1. 関連するプレゼンテーションを読み込む。
2. 置き換えるフォントを読み込む。
3. 新しいフォントを読み込む。
4. フォントを置き換える。
5. 修正されたプレゼンテーションをPPTXファイルとして保存する。

このPythonコードはフォント置き換えを示しています：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーションを読み込む
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置き換えるソースフォントを読み込む
    sourceFont = slides.FontData("Arial")

    # 新しいフォントを読み込む
    destFont = slides.FontData("Times New Roman")

    # フォントを置き換える
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # プレゼンテーションを保存する
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

特定の条件下で何が起こるかを決定するルールを設定するには（たとえば、フォントにアクセスできない場合）、[**フォントの置き換え**](/slides/ja/python-net/font-substitution/)を参照してください。

{{% /alert %}}