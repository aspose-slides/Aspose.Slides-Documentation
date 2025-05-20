---
title: Python でプレゼンテーションの SmartArt グラフィックを管理する
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/python-net/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt を作成
- SmartArt を追加
- SmartArt を編集
- SmartArt を変更
- SmartArt にアクセス
- SmartArt レイアウト タイプ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint の SmartArt グラフィックの作成、編集、スタイリングを自動化する方法を、簡潔なコード例とパフォーマンス重視のガイダンスとともに紹介します。"
---

## **SmartArt図形の作成**
Aspose.Slides for Python via .NETは、スライドにカスタムSmartArt図形をゼロから追加することを簡単にします。Aspose.Slides for Python via .NETは、SmartArt図形を簡単に作成するための最もシンプルなAPIを提供しています。スライドにSmartArt図形を作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutTypeを設定してSmartArt図形を追加します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションのインスタンスを作成
with slides.Presentation() as pres:
    # プレゼンテーションスライドにアクセス
    slide = pres.slides[0]

    # Smart Art図形を追加
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # プレゼンテーションを保存
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **スライド内のSmartArt図形にアクセス**
以下のコードを使用して、プレゼンテーションスライドに追加されたSmartArt図形にアクセスします。サンプルコードでは、スライド内のすべての図形を traverse し、それがSmartArt図形かどうかを確認します。図形がSmartArtタイプである場合、それをSmartArtインスタンスに型変換します。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 目的のプレゼンテーションをロード
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # 最初のスライド内のすべての図形を traverse
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # 図形をSmartArtExに型変換
            print("図形名:" + shape.name)
```



## **特定のレイアウトタイプでSmartArt図形にアクセス**
以下のサンプルコードは、特定のLayoutTypeでSmartArt図形にアクセスするのに役立ちます。SmartArt図形は読み取り専用のため、SmartArt図形が追加されたときにのみLayoutTypeを変更することはできません。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形のあるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を traverse します。
- 図形がSmartArtタイプかどうかを確認し、SmartArtの場合は選択した図形をSmartArtに型変換します。
- 特定のLayoutTypeを持つSmartArt図形を確認し、その後必要な操作を行います。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 最初のスライド内のすべての図形を traverse
    for shape in presentation.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArtレイアウトを確認
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("ここで何かを行う....")
```



## **SmartArt図形のスタイルを変更**
以下のサンプルコードは、特定のLayoutTypeでSmartArt図形にアクセスするのに役立ちます。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形のあるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を traverse します。
- 図形がSmartArtタイプかどうかを確認し、SmartArtの場合は選択した図形をSmartArtに型変換します。
- 特定のスタイルを持つSmartArt図形を見つけます。
- SmartArt図形の新しいスタイルを設定します。
- プレゼンテーションを保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 最初のスライド内のすべての図形を traverse
    for shape in presentation.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArtスタイルを確認
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # SmartArtスタイルを変更
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # プレゼンテーションを保存
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt図形の色スタイルを変更**
この例では、任意のSmartArt図形の色スタイルを変更する方法を学びます。以下のサンプルコードでは、特定の色スタイルを持つSmartArt図形にアクセスし、そのスタイルを変更します。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形のあるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を traverse します。
- 図形がSmartArtタイプかどうかを確認し、SmartArtの場合は選択した図形をSmartArtに型変換します。
- 特定の色スタイルを持つSmartArt図形を見つけます。
- SmartArt図形の新しい色スタイルを設定します。
- プレゼンテーションを保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 最初のスライド内のすべての図形を traverse
    for shape in presentation.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArt色タイプを確認
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # SmartArt色タイプを変更
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # プレゼンテーションを保存
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```