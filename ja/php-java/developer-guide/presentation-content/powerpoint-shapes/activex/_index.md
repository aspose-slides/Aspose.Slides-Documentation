---
title: PHP を使用したプレゼンテーションでの ActiveX コントロールの管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/php-java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java が ActiveX を活用して PowerPoint プレゼンテーションを自動化および強化する方法を学び、開発者にスライドに対する強力な制御を提供します。"
---

{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for PHP via Java は ActiveX コントロールの追加と管理を可能にしますが、通常のプレゼンテーションシェイプに比べてやや扱いが難しくなります。Aspose.Slides に Media Player Active コントロールの追加サポートを実装しました。ActiveX コントロールはシェイプではなく、プレゼンテーションの[ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)の一部ではありません。代わりに別個の[ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/)の一部です。このトピックでは、それらの操作方法をご紹介します。

{{% /alert %}} 

## **スライドに Media Player ActiveX コントロールを追加する**
ActiveX Media Player コントロールを追加するには、次の手順を実行します。

1. 空のプレゼンテーションインスタンスを生成するために、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) で対象のスライドにアクセスします。
1. [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) が提供する[addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/)メソッドを使用して Media Player ActiveX コントロールを追加します。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順に基づくサンプルコードは、スライドに Media Player ActiveX コントロールを追加する方法を示しています。
```php
  # 空のプレゼンテーションインスタンスを作成
  $pres = new Presentation();
  try {
    # Media Player ActiveX コントロールを追加
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Media Player ActiveX コントロールにアクセスし、ビデオパスを設定
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # プレゼンテーションを保存
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ActiveX コントロールを変更する**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 以降のバージョンには、ActiveX コントロールを管理するコンポーネントが装備されています。プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、そのプロパティを通じて変更または削除できます。

{{% /alert %}} 

スライド上のテキストボックスやシンプルなコマンドボタンなどの簡単な ActiveX コントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
1. インデックスでスライド参照を取得します。
1. スライド内の ActiveX コントロールに、[ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) にアクセスして取得します。
1. [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントサイズ、フレーム位置など、TextBox1 ActiveX コントロールのプロパティを変更します。
1. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をずらします。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

上記の手順に基づくサンプルコードは、簡単な ActiveX コントロールを管理する方法を示しています。 
```php
  # ActiveX コントロールでプレゼンテーションにアクセスする
  $pres = new Presentation("ActiveX.pptm");
  try {
    # プレゼンテーションの最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # テキストボックスのテキストを変更する
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # 代替画像を変更します。PowerPoint は ActiveX の有効化中にこの画像を置き換えます,
      # そのため、場合によっては画像をそのままにしておいても問題ありません。
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
    # ボタンのキャプションを変更する
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # 代替画像を変更する
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
    # 100 ポイント下へ移動
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # コントロールを削除する
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Java ランタイムで実行できない場合でも、Aspose.Slides は ActiveX コントロールを読み取り再保存時に保持しますか？**

はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り・変更できます。コントロール自体を実行する必要はありません。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどう異なりますか？**

ActiveX コントロールはインタラクティブな管理対象コントロール（ボタン、テキストボックス、メディアプレーヤー）です。一方、[OLE](/slides/ja/php-java/manage-ole/) は埋め込みアプリケーションオブジェクト（例: Excel ワークシート）を指します。これらは保存方法や取り扱いが異なり、プロパティモデルも異なります。

**Aspose.Slides によってファイルが変更された場合、ActiveX のイベントや VBA マクロは機能しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows 上の PowerPoint でセキュリティが許可された場合にのみ実行されます。ライブラリ自体は VBA を実行しません。