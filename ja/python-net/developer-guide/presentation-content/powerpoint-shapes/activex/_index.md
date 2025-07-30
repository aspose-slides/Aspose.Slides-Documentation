---
title: Python でプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/python-net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化・強化し、開発者にスライドを強力に制御する方法を学びましょう。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Python via .NET を使うことで、ActiveX コントロールを管理できますが、これらを管理するのは少しトリッキーで、通常のプレゼンテーションシェイプとは異なります。Aspose.Slides for Python via .NET 6.9.0 以降、このコンポーネントは ActiveX コントロールの管理をサポートしています。現時点では、プレゼンテーションに追加された ActiveX コントロールにアクセスして、それをさまざまなプロパティを使って修正または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部ではなく、別の IControlCollection に属することを忘れないでください。この記事では、それらとの作業方法を示します。
## **ActiveX コントロールの修正**
スライド上のテキストボックスや単純なコマンドボタンのようなシンプルな ActiveX コントロールを管理するには：

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールを含むプレゼンテーションをロードします。
1. インデックスを使用してスライドの参照を取得します。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールにアクセスします。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、およびフレームの位置など、TextBox1 ActiveX コントロールのさまざまなプロパティを変更します。
1. CommandButton1 と呼ばれる2番目のアクセスコントロールにアクセスします。
1. ボタンキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレームの位置をシフトします。
1. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードスニペットは、プレゼンテーションスライドの ActiveX コントロールを更新します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX コントロールを持つプレゼンテーションにアクセス
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # プレゼンテーションの最初のスライドにアクセス
    slide = presentation.slides[0]

    # TextBox テキストの変更
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "変更されたテキスト"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 代替画像の変更。PowerPoint はこの画像を ActiveX 有効化中に置き換えるため、時には画像を変更しないのが良いこともあります。

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # ボタンキャプションの変更
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "メッセージボックス"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 代替画像の変更
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # ActiveX フレームを 100 ポイント下に移動
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # 編集された ActiveX コントロールを持つプレゼンテーションを保存
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # さて、コントロールを削除
    slide.controls.clear()

    # 清掃された ActiveX コントロールを持つプレゼンテーションを保存
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **ActiveX メディアプレーヤーコントロールの追加**
ActiveX メディアプレーヤーコントロールを追加するには、以下の手順を実行してください：

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールを含むサンプルプレゼンテーションをロードします。
1. 目標となる Presentation クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. テンプレートプレゼンテーションの Media Player ActiveX コントロールを含むスライドを目標の Presentation にクローンします。
1. 目標の Presentation にクローンされたスライドにアクセスします。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールにアクセスします。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用して動画パスを設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンス化
with slides.Presentation(path + "template.pptx") as presentation:

    # 空のプレゼンテーションインスタンスを作成
    with slides.Presentation() as newPresentation:

        # デフォルトのスライドを削除
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX コントロールを持つスライドをクローン
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX コントロールにアクセスし、動画パスを設定
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # プレゼンテーションを保存
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```