---
title: Python を使用したプレゼンテーションでの ActiveX コントロールの管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/python-java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java が ActiveX を使用して PowerPoint プレゼンテーションを自動化および強化する方法を学び、開発者にスライドに対する強力な制御を提供します。"
---
## **はじめに**

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Python via Java を使用すると ActiveX コントロールを追加および管理できますが、通常のスライドシェイプに比べてやや取り扱いが難しくなります。Aspose.Slides は Media Player ActiveX コントロールの追加をサポートしています。ActiveX コントロールはシェイプではなく、プレゼンテーションの[ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/)の一部ではありません。代わりに別の[ControlCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/controlcollection/)の一部です。本トピックでは、これらの操作方法を示します。

## **スライドに Media Player ActiveX コントロールを追加する**

ActiveX Media Player コントロールを追加するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、空のプレゼンテーション インスタンスを生成します。
2. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) で対象のスライドにアクセスします。
3. [ControlCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/controlcollection/) が提供する[addControl](https://reference.aspose.com/slides/ja/python-java/aspose.slides/controlcollection/#addControl) メソッドを使用して Media Player ActiveX コントロールを追加します。
4. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオ パスを設定します。
5. プレゼンテーションを PPTX ファイルとして保存します。

以下のサンプルコードは、上記の手順に基づき、スライドに Media Player ActiveX コントロールを追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    # Media Player ActiveX コントロールを追加します。
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # ビデオ パスを設定します。
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # プレゼンテーションを保存します。
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ActiveX コントロールの変更**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は ActiveX コントロールの管理用コンポーネントを提供します。プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、そのプロパティを通じて変更または削除できます。
{{% /alert %}}

スライド上のテキストボックスやシンプルなコマンドボタンなどのシンプルな ActiveX コントロールを管理するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
2. インデックスでスライド参照を取得します。
3. [ControlCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/controlcollection/) にアクセスして、スライド内の ActiveX コントロールにアクセスします。
4. [Control](https://reference.aspose.com/slides/ja/python-java/aspose.slides/control/) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
5. テキスト、フォント、フォント高さ、フレーム位置を含む TextBox1 ActiveX コントロールのプロパティを変更します。
6. CommandButton1 と呼ばれる 2 番目の ActiveX コントロールにアクセスします。
7. ボタンのキャプション、フォント、位置を変更します。
8. ActiveX コントロールのフレーム位置をシフトします。
9. 変更されたプレゼンテーションを PPTM ファイルとして書き出します。

以下のサンプルコードは、上記の手順に基づき、シンプルな ActiveX コントロールを管理する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# ActiveX コントロールを含むプレゼンテーションをロードします。
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # 最初のスライドにアクセスします。
        slide = presentation.getSlides().get_Item(0)

        # テキストボックスのテキストを変更します。
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # 代替画像を変更します。PowerPoint は ActiveX の有効化時に画像を置き換えます、
            # したがって、変更しなくても問題ない場合があります。
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # ボタンのキャプションを変更します。
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # 代替画像を変更します。
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # コントロールを下に 100 ポイント移動します。
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # コントロールを削除します。
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **よくある質問**

**Aspose.Slides は、Python ランタイムで実行できなくても、読み取りおよび再保存時に ActiveX コントロールを保持しますか？**

はい。Aspose.Slides はこれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールはインタラクティブな管理対象コントロール（ボタン、テキストボックス、メディアプレーヤー）であり、[OLE](/slides/ja/python-java/manage-ole/) は埋め込みアプリケーションオブジェクト（例: Excel のワークシート）を指します。保存方法や取り扱いが異なり、プロパティモデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX のイベントや VBA マクロは機能しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows の PowerPoint 内で、セキュリティが許可した場合にのみ実行されます。このライブラリは VBA を実行しません。