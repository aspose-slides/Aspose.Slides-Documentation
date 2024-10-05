---
title: プレースホルダーの管理
type: docs
weight: 10
url: /python-net/manage-placeholder/
keywords: "プレースホルダー, プレースホルダーテキスト, プロンプトテキスト, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Pythonを使用してPowerPointプレゼンテーションのプレースホルダーテキストとプロンプトテキストを変更する"
---

## **プレースホルダー内のテキストを変更する**

[Aspose.Slides for Python via .NET](/slides/python-net/)を使用すると、プレゼンテーションのスライド上のプレースホルダーを見つけて変更できます。Aspose.Slidesを使用すると、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーが含まれたプレゼンテーションが必要です。そのようなプレゼンテーションは、標準のMicrosoft PowerPointアプリで作成できます。

次の手順で、Aspose.Slidesを使用してそのプレゼンテーション内のプレースホルダーのテキストを置き換えます。

1. [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを通じてスライド参照を取得します。
3. プレースホルダーを見つけるためにシェイプを繰り返します。
4. プレースホルダーシェイプを[`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)に型変換し、[`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)を使ってテキストを変更します。
5. 修正されたプレゼンテーションを保存します。

次のPythonコードは、プレースホルダー内のテキストを変更する方法を示しています。

```python
import aspose.slides as slides

# Presentationクラスをインスタンス化
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # プレースホルダーを見つけるためにシェイプを繰り返す
    for shp in sld.shapes:
        if shp.placeholder != None:
            # 各プレースホルダー内のテキストを変更
            shp.text_frame.text = "これはプレースホルダーです"

    # プレゼンテーションをディスクに保存
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、「***タイトルを追加するにはクリック***」や「***サブタイトルを追加するにはクリック***」などのプレースホルダープロンプトテキストが含まれています。Aspose.Slidesを使用すると、プレースホルダーのレイアウトに好みのプロンプトテキストを挿入できます。

次のPythonコードは、プレースホルダーにプロンプトテキストを設定する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # スライドを繰り返す
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPointは「タイトルを追加するにはクリック」と表示します。
                text = "タイトルを追加"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # サブタイトルを追加します。
                text = "サブタイトルを追加"

            shape.text_frame.text = text

            print("テキストを持つプレースホルダー: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **プレースホルダーの画像の透明度を設定する**

Aspose.Slidesを使用すると、テキストプレースホルダーの背景画像の透明度を設定できます。このようなフレーム内の画像の透明度を調整することで、テキストや画像を際立たせることができます（テキストと画像の色によります）。

次のPythonコードは、図形内の背景画像の透明度を設定する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```