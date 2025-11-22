---
title: Pythonでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/python-net/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NETを介したAspose.Slides for Pythonでプレースホルダーを手軽に管理できます：テキストの置換、プロンプトのカスタマイズ、PowerPointやOpenDocumentで画像の透明度設定が可能です。"
---

## **概要**

プレースホルダーは、マスター、レイアウト、スライド上に予約領域（タイトル、本文、画像、チャート、日付/時刻、スライド番号、フッターなど）を定義し、コンテンツの配置先と書式の継承方法を制御します。Aspose.Slides for Python を使用すると、`shape.placeholder` が `None` でないことを確認し、`placeholder.type` を調べることで、スライド、レイアウト、またはマスター上のプレースホルダーを検出し、関連するコンテンツや書式を読み書きできます。API を使えば、マスターやレイアウトに新しいプレースホルダーを追加して子スライドに伝搬させたり、既存のプレースホルダーの位置やサイズを変更したり、完全な制御が必要なときにプレースホルダーを通常のシェイプに変換したり、デザインをシンプルにするために削除したりできます。以下の例は、プレースホルダーを列挙し、テキストとスタイルを更新し、適切なレベルで変更を適用してレイアウトの一貫性を保つ方法を示しています。

## **プレースホルダー内のテキストを変更する**

Aspose.Slides for Python を使用すると、プレゼンテーション内のスライド上のプレースホルダーを検索して変更できます。Aspose.Slides では、プレースホルダー内のテキストを変更できます。

**前提条件:** プレースホルダーを含むプレゼンテーションが必要です。このようなプレゼンテーションは Microsoft PowerPoint で作成できます。

プレースホルダーのテキストを置換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
1. インデックスでスライドへの参照を取得します。
1. シェイプを列挙してプレースホルダーを見つけます。
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) に関連付けられた [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を使用してテキストを変更します。
1. 変更済みプレゼンテーションを保存します。

この Python コードは、プレースホルダーのテキストを変更する方法を示しています:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation("ReplacingText.pptx") as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # プレースホルダーを探すためにシェイプを走査します。
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # 各プレースホルダーのテキストを変更します。
            shape.text_frame.text = "This is Placeholder"

    # プレゼンテーションをディスクに保存します。
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **プレースホルダーのプロンプト テキストを設定する**

標準レイアウトやプリビルドレイアウトには、**Click to add a title** や **Click to add a subtitle** といったプレースホルダーのプロンプト テキストが含まれています。Aspose.Slides を使えば、これらのプロンプトをプレースホルダー レイアウト内の独自のテキストに置き換えることができます。

次の Python の例は、プレースホルダーのプロンプト テキストを設定する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # プレースホルダーを見つけるためにシェイプを走査します。
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **プレースホルダー内の画像の透明度を設定する**

Aspose.Slides では、テキスト プレースホルダー内の背景画像の透明度を設定できます。そのフレーム内で画像の透明度を調整することで、テキストと画像のどちらを強調するかを色に応じて選択できます。

次の Python の例は、シェイプ内の画像背景の透明度を設定する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **FAQ**

**ベース プレースホルダーとは何ですか？スライド上のローカル シェイプとどう違いますか？**

ベース プレースホルダーは、レイアウトまたはマスター上の元となるシェイプで、スライドのシェイプはそのタイプ、位置、および一部の書式を継承します。ローカル シェイプは独立しており、ベース プレースホルダーが存在しない場合は継承が適用されません。

**すべてのスライドを走査せずに、プレゼンテーション全体のタイトルやキャプションを一括で更新するには？**

レイアウトまたはマスター上の該当プレースホルダーを編集します。これらのレイアウト/マスターを基にしたスライドは自動的に変更を継承します。

**標準のヘッダー/フッター プレースホルダー（日付と時刻、スライド番号、フッター テキスト）を制御するには？**

適切なスコープ（通常のスライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用し、プレースホルダーのオン/オフを切り替え、内容を設定します。