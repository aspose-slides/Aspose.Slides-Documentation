---
title: PowerPoint SmartArt シェイプノードの作成または管理
linktitle: SmartArt シェイプノードの管理
type: docs
weight: 30
url: /ja/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint java api
description: PowerPoint プレゼンテーション内のスマートアートノードと子ノードを管理
---

## **PHPを使用してPowerPointプレゼンテーションにSmartArtノードを追加する**
Aspose.Slides for PHP via Java は、最も簡単な方法でSmartArtシェイプを管理するためのシンプルなAPIを提供しています。以下のサンプルコードは、SmartArtシェイプ内にノードと子ノードを追加するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. SmartArtシェイプの[**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--)に[新しいノードを追加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)し、TextFrameにテキストを設定します。
1. 次に、新しく追加された[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)ノードに[**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)を[追加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)し、TextFrameにテキストを設定します。
1. プレゼンテーションを保存します。

```php
  # 目的のプレゼンテーションをロードする
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        # 新しいSmartArtノードを追加する
        $TemNode = $smart->getAllNodes()->addNode();
        # テキストを追加する
        $TemNode->getTextFrame()->setText("Test");
        # 親ノードに新しい子ノードを追加する。それはコレクションの最後に追加される
        $newNode = $TemNode->getChildNodes()->addNode();
        # テキストを追加する
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # プレゼンテーションを保存する
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **特定の位置にSmartArtノードを追加する**
以下のサンプルコードでは、特定の位置に対応するSmartArtシェイプの子ノードを追加する方法を説明します。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. アクセスしたスライドに[**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList)タイプの[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)シェイプを追加します。
1. 追加されたSmartArtシェイプ内の最初のノードにアクセスします。
1. 選択された[**ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)の位置2に[**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)を追加し、そのテキストを設定します。
1. プレゼンテーションを保存します。

```php
  # プレゼンテーションインスタンスを作成する
  $pres = new Presentation();
  try {
    # プレゼンテーションスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShapeを追加する
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス0のSmartArtノードにアクセスする
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置2に新しい子ノードを追加する
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # テキストを追加する
    $chNode->getTextFrame()->setText("Sample Text Added");
    # プレゼンテーションを保存する
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PHPを使用してPowerPointプレゼンテーション内のSmartArtノードにアクセスする**
以下のサンプルコードは、SmartArtシェイプ内のノードにアクセスするのに役立ちます。SmartArtシェイプが追加されたときに設定されるため、レイアウトタイプを変更することはできないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. SmartArtシェイプ内のすべての[**ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)をトラバースします。
1. SmartArtノードの位置、レベル、テキストのような情報を取得して表示します。

```php
  # Presentationクラスをインスタンス化する
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($slide->getShapes() as $shape) {
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        # SmartArt内のすべてのノードをトラバースする
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックスiのSmartArtノードにアクセスする
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArtノードのパラメータを印刷する
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt子ノードにアクセスする**
以下のサンプルコードは、SmartArtシェイプのそれぞれのノードに属する子ノードにアクセスするのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. SmartArtシェイプ内のすべての[**ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)をトラバースします。
1. 選択されたSmartArtシェイプの[**ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)について、特定のノード内のすべての[**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--)をトラバースします。
1. [**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストのような情報を取得して表示します。

```php
  # Presentationクラスをインスタンス化する
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($slide->getShapes() as $shape) {
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        # SmartArt内のすべてのノードをトラバースする
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックスiのSmartArtノードにアクセスする
          $node0 = $smart->getAllNodes()->get_Item($i);
          # インデックスiのSmartArtノード内の子ノードをトラバースする
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArtノード内の子ノードにアクセスする
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt子ノードのパラメータを印刷する
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **特定の位置にSmartArt子ノードにアクセスする**
この例では、SmartArtシェイプの対応するノードに属する特定の位置に子ノードにアクセスする方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList)タイプのSmartArtシェイプを追加します。
1. 追加されたSmartArtシェイプにアクセスします。
1. アクセスしたSmartArtシェイプのインデックス0のノードにアクセスします。
1. アクセスしたSmartArtノードの位置1の[**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)に**get_Item()**メソッドを使用してアクセスします。
1. [**子ノード**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストのような情報を取得して表示します。

```php
  # プレゼンテーションをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライドにSmartArtシェイプを追加する
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス0のSmartArtノードにアクセスする
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置1の子ノードにアクセスする
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt子ノードのパラメータを印刷する
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PHPを使用してPowerPointプレゼンテーション内のSmartArtノードを削除する**
この例では、SmartArtシェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)が0ノードより多いかチェックします。
1. 削除するSmartArtノードを選択します。
1. 選択したノードを[**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)メソッドを使用して削除します。
1. プレゼンテーションを保存します。

```php
  # 目的のプレゼンテーションをロードする
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # インデックス0のSmartArtノードにアクセスする
          $node = $smart->getAllNodes()->get_Item(0);
          # 選択したノードを削除する
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # プレゼンテーションを保存する
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **特定の位置にSmartArtノードを削除する**
この例では、特定の位置にSmartArtシェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. インデックス0のSmartArtシェイプノードを選択します。
1. 選択したSmartArtノードが2つ以上の子ノードを持つかチェックします。
1. [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-)メソッドを使って**位置1**のノードを削除します。
1. プレゼンテーションを保存します。

```php
  # 目的のプレゼンテーションをロードする
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # インデックス0のSmartArtノードにアクセスする
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 位置1の子ノードを削除する
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # プレゼンテーションを保存する
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArtの子ノードのカスタム位置を設定する**
Aspose.Slides for PHP via Javaは、[SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)の[X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-)および[Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-)プロパティの設定をサポートしています。以下のコードスニペットは、カスタムSmartArtShapeの位置、サイズ、回転を設定する方法を示しています。また、新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。カスタム位置設定を使用すると、ユーザーは要件に応じてノードを設定できます。

```php
  # Presentationクラスをインスタンス化する
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArtシェイプを新しい位置に移動する
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArtシェイプの幅を変更する
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);
    # SmartArtシェイプの高さを変更する
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);
    # SmartArtシェイプの回転を変更する
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **アシスタントノードの確認**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for PHP via Javaを使用してプログラム的にプレゼンテーションスライドに追加されたSmartArtシェイプの機能をさらに調査します。

{{% /alert %}} 

以下のソースSmartArtシェイプを使用して、この記事のさまざまなセクションでの調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソースSmartArtシェイプ**|

以下のサンプルコードでは、SmartArtノードコレクション内の**アシスタントノード**を特定し、それらを変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して2番目のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)タイプであるかチェックし、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)に型キャストします。
1. SmartArtシェイプ内のすべてのノードをトラバースし、それらが[**アシスタントノード**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--)であるか確認します。
1. アシスタントノードの状態を通常のノードに変更します。
1. プレゼンテーションを保存します。

```php
  # プレゼンテーションインスタンスを作成する
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 最初のスライド内のすべてのシェイプをトラバースする
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプがSmartArtタイプかチェックする
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプをSmartArtに型キャストする
        $smart = $shape;
        # SmartArtシェイプのすべてのノードをトラバースする
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # ノードがアシスタントノードかチェックする
          if ($node->isAssistant()) {
            # アシスタントノードをfalseに設定して通常のノードにする
            $node->isAssistant(false);
          }
        }
      }
    }
    # プレゼンテーションを保存する
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: スライド内のSmartArtシェイプのアシスタントノードが変更された**|

## **ノードの塗りつぶしフォーマットを設定する**
Aspose.Slides for PHP via Javaは、カスタムSmartArtシェイプを追加し、その塗りつぶしフォーマットを設定することを可能にします。このセクションでは、SmartArtシェイプを作成してアクセスし、それらの塗りつぶしフォーマットを設定する方法を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)シェイプを追加し、その[**レイアウトタイプ**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)を設定します。
1. SmartArtシェイプノードの[**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--)を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

```php
  # プレゼンテーションをインスタンス化する
  $pres = new Presentation();
  try {
    # スライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArtシェイプとノードを追加する
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # ノードの塗りつぶし色を設定する
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # プレゼンテーションを保存する
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt子ノードのサムネイルを生成する**
開発者は以下の手順に従って、SmartArtの子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)を追加します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の形式でサムネイル画像を保存します。

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化する
  $pres = new Presentation();
  try {
    # SmartArtを追加する
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # インデックスを使用してノードの参照を取得する
    $node = $smart->getNodes()->get_Item(1);
    # サムネイルを取得する
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # サムネイルを保存する
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```