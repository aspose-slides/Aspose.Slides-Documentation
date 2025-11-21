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
description: "Aspose.Slides for Python via .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化・強化し、開発者にスライドに対する強力な制御を提供する方法を学びます。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Python via .NET を使用すると ActiveX コントロールを管理できますが、管理はやや複雑で通常のスライドシェイプとは異なります。Aspose.Slides for Python via .NET 6.9.0 以降、コンポーネントは ActiveX コントロールの管理をサポートします。現在、プレゼンテーションに追加済みの ActiveX コントロールにアクセスし、さまざまなプロパティを使って変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部でもなく、別個の IControlCollection に属します。この記事ではそれらの操作方法を示します。

## **ActiveX コントロールの変更**
1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
1. インデックスでスライド参照を取得します。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールを取得します。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. TextBox1 ActiveX コントロールのテキスト、フォント、フォントサイズ、フレーム位置などさまざまなプロパティを変更します。
1. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。

コードスニペットは、以下のスライドのようにプレゼンテーションのスライド上の ActiveX コントロールを更新します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX コントロールが含まれるプレゼンテーションにアクセスする
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # プレゼンテーションの最初のスライドにアクセスする
    slide = presentation.slides[0]

    # TextBox のテキストを変更する
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 代替画像を変更する。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、場合によっては画像を変更しなくても問題ない。

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

    # ボタンのキャプションを変更する
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 代替画像を変更する
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
    
    # ActiveX フレームを 100 ポイント下に移動する
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

    # 編集した ActiveX コントロール付きでプレゼンテーションを保存する
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # コントロールを削除する
    slide.controls.clear()

    # クリアした ActiveX コントロール付きでプレゼンテーションを保存する
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **ActiveX Media Player コントロールの追加**
1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプルプレゼンテーションをロードします。
1. ターゲットとなる Presentation クラスのインスタンスを作成し、空のプレゼンテーションを生成します。
1. テンプレートプレゼンテーションの Media Player ActiveX コントロールを含むスライドをターゲット Presentation にクローンします。
1. ターゲット Presentation でクローンされたスライドにアクセスします。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールを取得します。
1. Media Player ActiveX コントロールにアクセスし、プロパティを使用してビデオパスを設定します。
1. プレゼンテーションを PPTX ファイルに保存します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスをインスタンス化する
with slides.Presentation(path + "template.pptx") as presentation:

    # 空のプレゼンテーション インスタンスを作成する
    with slides.Presentation() as newPresentation:

        # デフォルト スライドを削除する
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX コントロールを含むスライドをクローンする
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX コントロールにアクセスし、ビデオ パスを設定する
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # プレゼンテーションを保存する
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Python ランタイムで実行できない場合でも、Aspose.Slides は ActiveX コントロールを読み取り再保存時に保持しますか？**

はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**プレゼンテーションにおける ActiveX コントロールは OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールはインタラクティブな管理対象コントロール（ボタン、テキストボックス、メディアプレーヤー）であり、[OLE](/slides/ja/python-net/manage-ole/) は埋め込みアプリケーションオブジェクト（例: Excel ワークシート）を指します。保存方法や取り扱いが異なり、プロパティモデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX のイベントや VBA マクロは機能しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows の PowerPoint で、セキュリティが許可された場合にのみ実行されます。ライブラリ自体は VBA を実行しません。