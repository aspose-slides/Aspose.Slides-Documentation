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
description: "Aspose.Slides for PHP via Java が ActiveX を活用して PowerPoint プレゼンテーションを自動化および強化し、開発者にスライドに対する強力な制御を提供する方法を学びます。"
---

{{% alert color="primary" %}} 

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for PHP via Java を使用すると ActiveX コントロールの追加と管理が可能ですが、通常のスライド シェイプに比べてやや扱いが難しくなります。Aspose.Slides では Media Player ActiveX コントロールの追加サポートを実装しました。ActiveX コントロールはシェイプではなく、プレゼンテーションの[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) の一部ではありません。代わりに別の[IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) に属します。このトピックでは、これらの操作方法を示します。

{{% /alert %}} 

## **Add a Media Player ActiveX Control to a Slide**
ActiveX Media Player コントロールを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、空のプレゼンテーションを生成します。
2. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) で対象スライドにアクセスします。
3. [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) が提供する [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) メソッドを使用して Media Player ActiveX コントロールを追加します。
4. Media Player ActiveX コントロールにアクセスし、プロパティを使用してビデオ パスを設定します。
5. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順に基づくサンプルコードは、スライドに Media Player ActiveX コントロールを追加する方法を示しています:
```php
  # 空のプレゼンテーションインスタンスを作成
  $pres = new Presentation();
  try {
    # Media Player ActiveX コントロールを追加
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Media Player ActiveX コントロールにアクセスしてビデオパスを設定
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # プレゼンテーションを保存
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modify an ActiveX Control**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 以降のバージョンには、ActiveX コントロールを管理するコンポーネントが装備されています。プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、プロパティを介して変更または削除できます。

{{% /alert %}} 

スライド上のテキスト ボックスやシンプルなコマンド ボタンなどの基本的な ActiveX コントロールを管理するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
2. インデックスでスライド参照を取得します。
3. スライド内の ActiveX コントロールに [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) を介してアクセスします。
4. [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl) オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
5. テキスト、フォント、フォント サイズ、フレーム位置など、TextBox1 ActiveX コントロールのプロパティを変更します。
6. 2 番目のコントロールである CommandButton1 にアクセスします。
7. ボタンのキャプション、フォント、位置を変更します。
8. ActiveX コントロールのフレーム位置をシフトします。
9. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

上記の手順に基づくサンプルコードは、簡単な ActiveX コントロールを管理する方法を示しています: 
```php
  # ActiveX コントロール付きのプレゼンテーションにアクセス
  $pres = new Presentation("ActiveX.pptm");
  try {
    # プレゼンテーションの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # TextBox のテキストを変更
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # 代替画像を変更します。PowerPoint は ActiveX の有効化時にこの画像を置き換えます、
      # そのため、画像を変更しないままにしておくことも時々許容されます。
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
    # ボタンのキャプションを変更
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # 代替画像を変更
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
    # 100 ポイント下に移動
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


## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Java runtime?**

はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキスト ボックス、メディア プレーヤー）であり、[OLE](/slides/ja/php-java/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。保存方法や取り扱いが異なり、プロパティ モデルも異なります。

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows の PowerPoint でセキュリティが許可されている場合にのみ実行されます。ライブラリ自体は VBA を実行しません。