---
title: Python でプレゼンテーションの ActiveX コントロールを管理する方法
linktitle: ActiveX
type: docs
weight: 80
url: /ja/python-net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX を管理
- ActiveX を追加
- ActiveX を変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化・強化し、開発者にスライドの強力な制御を提供する方法を学びます。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Python via .NET では ActiveX コントロールを管理できますが、管理はやや手間がかかり、通常のシェイプとは異なります。Aspose.Slides for Python via .NET 6.9.0 以降、コンポーネントは ActiveX コントロールの管理をサポートしています。現在、プレゼンテーションに追加済みの ActiveX コントロールにアクセスし、さまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部ではなく、別個の IControlCollection に属していることを忘れないでください。本記事ではそれらの操作方法を示します。

## **ActiveX コントロールの変更**
テキストボックスやシンプルなコマンドボタンなどの基本的な ActiveX コントロールをスライド上で管理する手順:

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションを読み込みます。  
2. インデックスでスライド参照を取得します。  
3. IControlCollection にアクセスしてスライド上の ActiveX コントロールを取得します。  
4. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。  
5. TextBox1 のテキスト、フォント、フォントサイズ、フレーム位置などのプロパティを変更します。  
6. 2 番目のコントロールである CommandButton1 にアクセスします。  
7. ボタンのキャプション、フォント、位置を変更します。  
8. ActiveX コントロールのフレーム位置をシフトします。  
9. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

以下のコードスニペットは、スライド上の ActiveX コントロールを更新する例です。

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX コントロールが含まれるプレゼンテーションにアクセス
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # プレゼンテーションの最初のスライドにアクセス
    slide = presentation.slides[0]

    # TextBox のテキストを変更
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 代替画像を変更。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、画像を変更しないままにしておくことも時々問題ありません。

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

    # ボタンのキャプションを変更
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 代替画像を変更
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

    # 編集された ActiveX コントロール付きでプレゼンテーションを保存
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # コントロールを削除
    slide.controls.clear()

    # クリアされた ActiveX コントロール付きでプレゼンテーションを保存
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX メディアプレーヤー コントロールの追加**
ActiveX メディアプレーヤー コントロールを追加するには、次の手順を実行してください。

1. Presentation クラスのインスタンスを作成し、メディアプレーヤー ActiveX コントロールが含まれるサンプルプレゼンテーションを読み込みます。  
2. ターゲットとなる Presentation クラスのインスタンスを作成し、空のプレゼンテーションを生成します。  
3. テンプレートプレゼンテーションからメディアプレーヤー ActiveX コントロールを含むスライドをターゲット Presentation にクローンします。  
4. ターゲット Presentation でクローンされたスライドにアクセスします。  
5. IControlCollection にアクセスしてスライド上の ActiveX コントロールを取得します。  
6. メディアプレーヤー ActiveX コントロールにアクセスし、プロパティを使用してビデオパスを設定します。  
7. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンス化
with slides.Presentation(path + "template.pptx") as presentation:

    # 空のプレゼンテーションインスタンスを作成
    with slides.Presentation() as newPresentation:

        # デフォルトのスライドを削除
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX コントロールを含むスライドをクローン
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX コントロールにアクセスし、ビデオパスを設定
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # プレゼンテーションを保存
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides は、Python ランタイムで実行できない ActiveX コントロールを読み込んで再保存した場合でも保持しますか？**

はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み書きできます。コントロール自体を実行する必要はありません。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどう違いますか？**

ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキストボックス、メディアプレーヤー）であり、[OLE](/slides/ja/python-net/manage-ole/) は埋め込みアプリケーションオブジェクト（例: Excel ワークシート）を指します。保存形式やプロパティモデルが異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX のイベントや VBA マクロは機能しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows の PowerPoint でセキュリティが許可された場合にのみ実行されます。ライブラリ自体は VBA を実行しません。