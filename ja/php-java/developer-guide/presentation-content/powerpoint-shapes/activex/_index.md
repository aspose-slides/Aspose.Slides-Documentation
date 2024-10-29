---
title: ActiveX
type: docs
weight: 80
url: /ja/php-java/activex/
---


{{% alert color="primary" %}} 

ActiveXコントロールはプレゼンテーションで使用されます。Aspose.Slides for PHP via Javaを使用すると、ActiveXコントロールを追加および管理できますが、通常のプレゼンテーションの図形と比較すると、管理は少し難しくなります。Aspose.Slidesでは、メディアプレーヤーActiveXコントロールを追加するサポートを実装しました。ActiveXコントロールは図形ではなく、プレゼンテーションの[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection)の一部ではありません。代わりに、別の[IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection)の一部です。このトピックでは、これらのコントロールを操作する方法を示します。

{{% /alert %}} 

## **スライドにメディアプレーヤーActiveXコントロールを追加する**
ActiveXメディアプレーヤーコントロールを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)の対象スライドにアクセスします。
1. [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection)が公開する[addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-)メソッドを使用して、メディアプレーヤーActiveXコントロールを追加します。
1. メディアプレーヤーActiveXコントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションをPPTXファイルとして保存します。

上記の手順に基づくサンプルコードは、スライドにメディアプレーヤーActiveXコントロールを追加する方法を示しています：

```php
  # 空のプレゼンテーションインスタンスを作成
  $pres = new Presentation();
  try {
    # メディアプレーヤーActiveXコントロールを追加
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # メディアプレーヤーActiveXコントロールにアクセスし、ビデオパスを設定
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # プレゼンテーションを保存
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ActiveXコントロールの変更**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0以降のバージョンには、ActiveXコントロールを管理するためのコンポーネントが装備されています。プレゼンテーションにすでに追加されたActiveXコントロールにアクセスし、そのプロパティを通じて変更または削除できます。

{{% /alert %}} 

スライド上のテキストボックスやシンプルなコマンドボタンのような単純なActiveXコントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、ActiveXコントロールを含むプレゼンテーションを読み込みます。
1. インデックスを使ってスライドの参照を取得します。
1. [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection)にアクセスしてスライド内のActiveXコントロールにアクセスします。
1. [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl)オブジェクトを使用してTextBox1 ActiveXコントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、フレームの位置を含むTextBox1 ActiveXコントロールのプロパティを変更します。
1. CommandButton1という名前の2つ目のアクセスコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveXコントロールのフレームの位置を移動します。
1. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

このサンプルコードは、上記の手順に基づいて単純なActiveXコントロールを管理する方法を示しています：

```php
  # ActiveXコントロールを含むプレゼンテーションにアクセス
  $pres = new Presentation("ActiveX.pptm");
  try {
    # プレゼンテーションの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # TextBoxのテキストを変更
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "変更されたテキスト";
      $control->getProperties()->set_Item("Value", $newText);
      # 代替画像を変更。PowerPointはActiveXのアクティベーション時にこの画像を置き換えます、
      # したがって、画像をそのままにしておくことが時には正常です。
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # ボタンキャプションを変更
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "メッセージボックスを表示";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # 代替を変更
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # 100ポイント下に移動
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # コントロールを削除
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```