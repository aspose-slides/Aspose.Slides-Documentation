---
title: ActiveX
type: docs
weight: 80
url: /java/activex/
---


{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Javaは、ActiveX コントロールの追加と管理を可能にしますが、通常のプレゼンテーション図形と比較すると、管理が少し難しくなります。Aspose.Slidesでは、Media Player Active コントロールの追加をサポートしました。ActiveX コントロールは図形ではないことに注意してください; それらはプレゼンテーションの [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection) の一部ではありません。それらは代わりに別の [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) の一部です。このトピックでは、これらを操作する方法を示します。 

{{% /alert %}} 

## **スライドに Media Player ActiveX コントロールを追加する**
ActiveX Media Player コントロールを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 内のターゲットスライドにアクセスします。
1. [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) によって公開されている [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) メソッドを使用して、Media Player ActiveX コントロールを追加します。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順に基づいたこのサンプルコードは、スライドに Media Player ActiveX コントロールを追加する方法を示しています：

```java
// 空のプレゼンテーションインスタンスを作成
Presentation pres = new Presentation();
try {
    // Media Player ActiveX コントロールを追加
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX コントロールにアクセスし、ビデオパスを設定
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // プレゼンテーションを保存
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX コントロールの変更**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 以降のバージョンには、ActiveX コントロールを管理するためのコンポーネントが備わっています。プレゼンテーション内で既に追加された ActiveX コントロールにアクセスし、そのプロパティを介して変更または削除できます。

{{% /alert %}} 

スライド上のテキストボックスや簡単なコマンドボタンのようなシンプルな ActiveX コントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールが含まれたプレゼンテーションを読み込みます。
1. インデックスによってスライド参照を取得します。
1. [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl) オブジェクトを使用して、TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、フレームの位置を含む TextBox1 ActiveX コントロールのプロパティを変更します。
1. CommandButton1 と呼ばれる2番目のアクセスコントロールにアクセスします。
1. ボタンのキャプション、フォント、および位置を変更します。
1. ActiveX コントロールフレームの位置を移動します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

上記の手順に基づいたこのサンプルコードは、シンプルな ActiveX コントロールを管理する方法を示しています： 

```java
// ActiveX コントロールを持つプレゼンテーションにアクセス
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // プレゼンテーションの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox のテキストを変更
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "変更されたテキスト";
        control.getProperties().set_Item("Value", newText);

        // 代替画像を変更。PowerPoint は、ActiveX アクティブ化中にこの画像を置き換えます、
        // したがって、時には画像を変更しないこともあります。
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

    // ボタンキャプションを変更
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "メッセージボックスを表示";
        control.getProperties().set_Item("Caption", newCaption);
        // 代替を変更
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