---
title: Python でプレゼンテーションの SmartArt グラフィックスを管理する
linktitle: SmartArt グラフィックス
type: docs
weight: 20
url: /ja/python-net/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウトタイプ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して .NET 経由で Python の PowerPoint SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt 図形の作成**

Aspose.Slides for Python via .NET を使用すると、スライドにカスタム SmartArt 図形を最初から追加できます。この API で簡単に実装できます。スライドに SmartArt 図形を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象のスライドを取得します。
1. レイアウトタイプを指定して SmartArt 図形を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:
    # プレゼンテーションのスライドにアクセス。
    slide = presentation.slides[0]
    # SmartArt 図形を追加。
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # プレゼンテーションをディスクに保存。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **スライド上の SmartArt 図形へのアクセス**

以下のコードは、スライド上の SmartArt 図形にアクセスする方法を示しています。サンプルはスライド上のすべての図形を列挙し、各図形が [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) オブジェクトかどうかを確認します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# プレゼンテーション ファイルを読み込む。
with slides.Presentation("SmartArt.pptx") as presentation:
    # 最初のスライド上のすべての図形を反復処理する。
    for shape in presentation.slides[0].shapes:
        # 図形が SmartArt かどうかを確認する。
        if isinstance(shape, smartart.SmartArt):
            # 図形名を出力する。
            print("Shape name:", shape.name)
```


## **指定したレイアウトタイプの SmartArt 図形へのアクセス**

次の例は、指定したレイアウトタイプを持つ SmartArt 図形にアクセスする方法を示します。SmartArt のレイアウトタイプは読み取り専用で、図形作成時に設定されるため変更できません。

1. SmartArt 図形を含むプレゼンテーションをロードするために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを作成します。
1. インデックスで最初のスライドへの参照を取得します。
1. 最初のスライド上のすべての図形を列挙します。
1. 図形が [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) オブジェクトかどうかを確認します。
1. SmartArt 図形のレイアウトタイプが目的のものと一致した場合、必要な処理を実行します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 最初のスライド上のすべての図形を反復処理する。
    for shape in presentation.slides[0].shapes:
        # 図形が SmartArt かどうかを確認する。
        if isinstance(shape, smartart.SmartArt):
            # SmartArt のレイアウトタイプを確認する。
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **SmartArt 図形のスタイル変更**

次の例は、SmartArt 図形を検索してそのスタイルを変更する方法を示します。

1. SmartArt 図形が含まれるファイルをロードするために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成します。
1. インデックスで最初のスライドへの参照を取得します。
1. 最初のスライド上の各図形を列挙します。
1. 指定したスタイルを持つ SmartArt 図形を見つけます。
1. 新しいスタイルをその SmartArt 図形に割り当てます。
1. プレゼンテーションを保存します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 最初のスライド上のすべての図形を反復処理する。
    for shape in presentation.slides[0].shapes:
        # 図形が SmartArt かどうかを確認する。
        if isinstance(shape, smartart.SmartArt):
            # SmartArt のスタイルを確認する。
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # SmartArt のスタイルを変更する。
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # プレゼンテーションを保存する。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt 図形のカラースタイル変更**

この例は、SmartArt 図形のカラースタイルを変更する方法を示します。サンプルコードは、指定したカラースタイルを持つ SmartArt 図形を検索し、更新します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、SmartArt 図形が含まれるプレゼンテーションをロードします。
1. インデックスで最初のスライドへの参照を取得します。
1. 最初のスライド上の各図形を列挙します。
1. 図形が [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) オブジェクトかどうかを確認します。
1. 指定したカラースタイルを持つ SmartArt 図形を特定します。
1. その SmartArt 図形に新しいカラースタイルを設定します。
1. プレゼンテーションを保存します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 最初のスライド上のすべての図形を反復処理する。
    for shape in presentation.slides[0].shapes:
        # 図形が SmartArt かどうかを確認する。
        if isinstance(shape, smartart.SmartArt):
            # カラータイプを確認する。
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # カラータイプを変更する。
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # プレゼンテーションを保存する。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーションさせることはできますか？**

はい。SmartArt は図形なので、アニメーション API（開始、終了、強調、モーション パス）を使用して [標準アニメーション](/slides/ja/python-net/powerpoint-animation/) を他の図形と同様に適用できます。

**スライド上で内部 ID が不明な特定の SmartArt を見つけるにはどうすればよいですか？**

代替テキスト (AltText) を設定し、その値で図形を検索します。これは対象図形を特定する推奨方法です。

**SmartArt を他の図形とグループ化できますか？**

はい。SmartArt を画像、表などの他の図形とグループ化でき、その後 [グループを操作](/slides/ja/python-net/group/) できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するには？**

図形のサムネイル/画像をエクスポートします。ライブラリは個別の図形を [レンダリング](/slides/ja/python-net/create-shape-thumbnails/) して PNG/JPG/TIFF 形式のラスターファイルに変換できます。

**プレゼンテーション全体を PDF に変換した際に、SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは [PDF エクスポート](/slides/ja/python-net/convert-powerpoint-to-pdf/) において高忠実度を目指しており、品質や互換性のオプションが用意されています。