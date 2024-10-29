---
title: ActiveX
type: docs
weight: 80
url: /ja/androidjava/activex/
---


{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for Android via Java は、ActiveX コントロールを追加および管理する機能を提供しますが、通常のプレゼンテーションシェイプと比較すると管理が少し難しいです。Aspose.Slides では Media Player Active コントロールを追加するサポートを実装しました。ActiveX コントロールはシェイプではなく、プレゼンテーションの [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) の一部ではありません。代わりに、別の [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) の一部です。このトピックでは、それらの使い方を説明します。

{{% /alert %}} 

## **スライドに Media Player ActiveX コントロールを追加する**
ActiveX Media Player コントロールを追加するには、次の手順を行います：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) で対象のスライドにアクセスします。
1. [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) により公開されている [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) メソッドを使用して、Media Player ActiveX コントロールを追加します。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使って動画パスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順に基づいたこのサンプルコードは、スライドに Media Player ActiveX コントロールを追加する方法を示しています：

```java
// Create empty presentation instance
Presentation pres = new Presentation();
try {
    // Adding the Media Player ActiveX control
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Access the Media Player ActiveX control and set the video path
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Save the Presentation
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX コントロールの変更**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 以降のバージョンには、ActiveX コントロールを管理するコンポーネントが備わっています。すでにプレゼンテーションに追加された ActiveX コントロールにアクセスし、そのプロパティを通じて変更または削除することができます。

{{% /alert %}} 

スライド上のテキストボックスやシンプルなコマンドボタンのようなシンプルな ActiveX コントロールを管理するには、次の手順を行います：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールが含まれているプレゼンテーションを読み込みます。
1. インデックスを指定してスライドへの参照を取得します。
1. [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) にアクセスしてスライド内の ActiveX コントロールにアクセスします。
1. [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、フレーム位置を含む TextBox1 ActiveX コントロールのプロパティを変更します。
1. CommandButton1 という名前の二番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレームの位置をずらします。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

上記の手順に基づいたこのサンプルコードは、シンプルな ActiveX コントロールを管理する方法を示しています： 

```java
// Accessing the presentation with ActiveX controls
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accessing the first slide in presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // changing TextBox text
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Changing substitute image. PowerPoint will replace this image during activeX activation,
        // so sometime it's OK to leave image unchanged.
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

    // Changing Button caption
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Changing substitute
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

            // moving 100 points down
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // removing controls
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```