---
title: Android でプレゼンテーションにおける ActiveX コントロールの管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/androidjava/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java が ActiveX を活用して PowerPoint プレゼンテーションを自動化・強化し、開発者にスライドの強力な制御を提供する方法を学びます。"
---

{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Android via Java を使用すると ActiveX コントロールを追加および管理できますが、通常のプレゼンテーション シェイプに比べてやや扱いが難しくなります。Aspose.Slides で Media Player Active コントロールの追加サポートを実装しました。ActiveX コントロールはシェイプではなく、プレゼンテーションの [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) の一部ではありません。代わりに別個の [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/) に属します。このトピックでは、これらの操作方法を示します。

{{% /alert %}} 

## **スライドに Media Player ActiveX コントロールを追加する**
ActiveX Media Player コントロールを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、空のプレゼンテーション インスタンスを生成します。
2. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) の対象スライドにアクセスします。
3. [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/) が公開する [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) メソッドを使用して Media Player ActiveX コントロールを追加します。
4. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオ パスを設定します。
5. プレゼンテーションを PPTX ファイルとして保存します。

このサンプルコードは、上記の手順に基づき、スライドに Media Player ActiveX コントロールを追加する方法を示しています:
```java
// 空のプレゼンテーション インスタンスを作成
Presentation pres = new Presentation();
try {
    // Media Player ActiveX コントロールを追加
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX コントロールにアクセスし、ビデオ パスを設定
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // プレゼンテーションを保存
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ActiveX コントロールの変更**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 以降のバージョンには、ActiveX コントロールを管理するコンポーネントが装備されています。プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、そのプロパティを介して変更または削除できます。

{{% /alert %}} 

スライド上のテキスト ボックスやシンプルなコマンド ボタンなど、簡単な ActiveX コントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
2. インデックスでスライド参照を取得します。
3. スライド内の ActiveX コントロールに、[IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/) にアクセスして取得します。
4. [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
5. テキスト、フォント、フォント高さ、フレーム位置を含む TextBox1 ActiveX コントロールのプロパティを変更します。
6. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。
7. ボタンのキャプション、フォント、位置を変更します。
8. ActiveX コントロールのフレーム位置をシフトします。
9. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

このサンプルコードは、上記の手順に基づき、簡単な ActiveX コントロールを管理する方法を示しています:
```java
// ActiveX コントロールを使用したプレゼンテーションへのアクセス
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // プレゼンテーションの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox のテキストを変更
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // 代替画像を変更します。PowerPoint は ActiveX の有効化時にこの画像を置き換えます、
        // そのため、画像を変更しないままにしておいても問題ないことがあります。
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // ボタンのキャプションを変更
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 代替画像を変更
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // 100 ポイント下に移動
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // コントロールを削除
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```


## **よくある質問**

**Aspose.Slides は、Java ランタイムで実行できない場合でも、読み取り後に再保存するときに ActiveX コントロールを保持しますか？**

はい。Aspose.Slides はこれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**プレゼンテーション内の ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールはインタラクティブな管理対象コントロール（ボタン、テキスト ボックス、メディア プレイヤー）です。一方、[OLE](/slides/ja/androidjava/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。保存方法や取り扱いが異なり、プロパティ モデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX イベントや VBA マクロは動作しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows 上の PowerPoint でセキュリティが許可された場合にのみ実行されます。ライブラリ自体は VBA を実行しません。