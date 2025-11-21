---
title: ActiveX
type: docs
weight: 80
url: /ja/nodejs-java/activex/
---

{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Node.js via Java を使用すると ActiveX コントロールを追加および管理できますが、通常のスライド シェイプに比べてやや扱いが難しくなります。Aspose.Slides で Media Player Active コントロールの追加サポートを実装しました。ActiveX コントロールはシェイプではなく、プレゼンテーションの [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) の一部ではありません。代わりに別個の [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) の一部です。このトピックでは、これらの操作方法を示します。

{{% /alert %}} 

## **スライドへのメディアプレーヤー ActiveX コントロールの追加**
ActiveX Media Player コントロールを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成し、空のプレゼンテーションを生成します。
1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) で対象のスライドにアクセスします。
1. [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) が提供する [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) メソッドを使用して Media Player ActiveX コントロールを追加します。
1. Media Player ActiveX コントロールにアクセスし、プロパティを使用してビデオ パスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順に基づくサンプルコードは、スライドに Media Player ActiveX コントロールを追加する方法を示しています:
```javascript
// 空のプレゼンテーションインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // Media Player ActiveX コントロールを追加
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Media Player ActiveX コントロールにアクセスし、ビデオパスを設定
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // プレゼンテーションを保存
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ActiveX コントロールの変更**

スライド上のテキスト ボックスや単純なコマンド ボタンなどのシンプルな ActiveX コントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールを含むプレゼンテーションをロードします。
1. インデックスでスライド参照を取得します。
1. スライド内の [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) にアクセスして ActiveX コントロールを取得します。
1. [Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、フレーム位置など、TextBox1 ActiveX コントロールのプロパティを変更します。
1. 2 番目のコントロールである CommandButton1 にアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

上記の手順に基づくサンプルコードは、シンプルな ActiveX コントロールを管理する方法を示しています:
```javascript
const imageio = java.import("javax.imageio.ImageIO");
// ActiveX コントロールがあるプレゼンテーションにアクセス
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // プレゼンテーションの最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // TextBox のテキストを変更
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // 代替画像を変更します。PowerPoint は ActiveX のアクティベーション時にこの画像を置き換えます、 
        // そのため、画像を変更しないままにしておくことも時々問題ありません。
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // ボタンのキャプションを変更
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 代替画像を変更
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 ポイント下に移動
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // コントロールを削除
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides は、Python ランタイムで実行できない場合でも、読み取りと再保存時に ActiveX コントロールを保持しますか？**

はい。Aspose.Slides はこれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体の実行は保持に必要ありません。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキスト ボックス、メディア プレーヤー）であり、[OLE](/slides/ja/nodejs-java/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。保存および処理方法、プロパティ モデルが異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX イベントや VBA マクロは動作しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows 上の PowerPoint でセキュリティが許可されたときにのみ実行されます。ライブラリ自体は VBA を実行しません。