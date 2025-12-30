---
title: PHP を使用したプレゼンテーションでの SmartArt シェイプ ノードの管理
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/php-java/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノード位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタント ノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PPT と PPTX の SmartArt シェイプ ノードを管理します。プレゼンテーションを効率化するための明確なコードサンプルとヒントをご提供します。"
---

## **SmartArt ノードを追加する**
Aspose.Slides for PHP via Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) に型キャストします。
1. SmartArt シェイプの **NodeCollection** ([ISmartArtNodeCollection#addNode--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)) に新しいノードを [追加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) し、TextFrame にテキストを設定します。
1. さらに、追加した SmartArt ノードに対して **Child Node** ([ISmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)) を [追加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) し、TextFrame にテキストを設定します。
1. プレゼンテーションを保存します。
```php
  # 目的のプレゼンテーションを読み込む
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        # 新しい SmartArt ノードを追加する
        $TemNode = $smart->getAllNodes()->addNode();
        # テキストを追加する
        $TemNode->getTextFrame()->setText("Test");
        # 親ノードに新しい子ノードを追加する。コレクションの末尾に追加される
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


## **特定の位置に SmartArt ノードを追加する**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを特定の位置に追加する方法を説明します。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. アクセスしたスライドに **StackedList** ([SmartArtLayoutType#StackedList](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList)) 型の SmartArt シェイプを追加します。
1. 追加した SmartArt シェイプの最初のノードにアクセスします。
1. 選択した **Node** ([SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)) の位置 2 に **Child Node** を追加し、テキストを設定します。
1. プレゼンテーションを保存します。
```php
  # プレゼンテーションインスタンスを作成
  $pres = new Presentation();
  try {
    # プレゼンテーションのスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape を追加
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス 0 の SmartArt ノードにアクセス
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置 2 に新しい子ノードを追加
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # テキストを追加
    $chNode->getTextFrame()->setText("Sample Text Added");
    # プレゼンテーションを保存
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt ノードにアクセスする**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、シェイプを追加したときにのみ設定されることに注意してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば型キャストします。
1. SmartArt シェイプ内のすべての **Nodes** ([SmartArt#getAllNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)) を走査します。
1. SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # Presentation クラスをインスタンス化
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャスト
        $smart = $shape;
        # SmartArt 内のすべてのノードを走査
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックス i の SmartArt ノードにアクセス
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt ノードのパラメータを出力
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


## **SmartArt 子ノードにアクセスする**
以下のサンプルコードは、SmartArt シェイプ内の各ノードに属する子ノードにアクセスする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば型キャストします。
1. SmartArt シェイプ内のすべての **Nodes** を走査します。
1. 各選択された SmartArt **Node** ([SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)) について、該当ノード内のすべての **Child Nodes** ([SmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--)) を走査します。
1. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # プレゼンテーション クラスをインスタンス化
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャスト
        $smart = $shape;
        # SmartArt 内のすべてのノードを走査
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックス i の SmartArt ノードにアクセス
          $node0 = $smart->getAllNodes()->get_Item($i);
          # インデックス i の SmartArt ノード内の子ノードを走査
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArt ノードの子ノードにアクセス
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt 子ノードのパラメータを出力
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


## **特定の位置にある SmartArt 子ノードにアクセスする**
この例では、SmartArt シェイプ内の各ノードに属する子ノードを特定の位置で取得する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. **StackedList** 型の SmartArt シェイプを追加します。
1. 追加した SmartArt シェイプにアクセスします。
1. インデックス 0 のノードにアクセスします。
1. **get_Item()** メソッドを使用して、インデックス 1 の **Child Node** にアクセスします。
1. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # プレゼンテーションをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライドに SmartArt シェイプを追加
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス 0 の SmartArt ノードにアクセス
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置 1 の子ノードにアクセス
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt 子ノードのパラメータを出力
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt ノードを削除する**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば型キャストします。
1. SmartArt が 0 以上のノードを持つか確認します。
1. 削除する SmartArt ノードを選択します。
1. **RemoveNode** ([ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)) メソッドを使用して選択したノードを削除します。
1. プレゼンテーションを保存します。
```php
  # 目的のプレゼンテーションを読み込む
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # インデックス 0 の SmartArt ノードにアクセスする
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


## **特定の位置にある SmartArt ノードを削除する**
この例では、特定の位置にある SmartArt シェイプのノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば型キャストします。
1. インデックス 0 の SmartArt シェイプノードを選択します。
1. 選択した SmartArt ノードが 2 つ以上の子ノードを持つか確認します。
1. **RemoveNode** ([ISmartArtNodeCollection#removeNode-int-](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-)) メソッドを使用して位置 **1** のノードを削除します。
1. プレゼンテーションを保存します。
```php
  # 目的のプレゼンテーションを読み込む
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # インデックス 0 の SmartArt ノードにアクセスする
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 位置 1 の子ノードを削除する
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


## **SmartArt オブジェクトの子ノードにカスタム位置を設定する**
現在、Aspose.Slides for PHP via Java は [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) の **X** ([IShape#setX-float-](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-)) および **Y** ([IShape#setY-float-](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-)) プロパティの設定に対応しています。以下のコードスニペットは、カスタム位置、サイズ、回転を設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。カスタム位置設定により、必要に応じてノードを配置できます。
```php
  # プレゼンテーション クラスをインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt シェイプを新しい位置へ移動
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt シェイプの幅を変更
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt シェイプの高さを変更
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt シェイプの回転を変更
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **アシスタント ノードを確認する**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for PHP via Java を使用してプログラムでプレゼンテーション スライドに追加された SmartArt シェイプの機能をさらに調査します。

{{% /alert %}} 

以下のソース SmartArt シェイプを使用して、記事の各セクションで調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソース SmartArt シェイプ**|

以下のサンプルコードでは、SmartArt ノードコレクション内の **Assistant Nodes** を識別し、変更する方法を調べます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して 2 番目のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 型か確認し、SmartArt であれば型キャストします。
1. SmartArt シェイプ内のすべてのノードを走査し、[Assistant Nodes](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) であるか確認します。
1. Assistant Node のステータスを通常ノードに変更します。
1. プレゼンテーションを保存します。
```php
  # プレゼンテーションインスタンスを作成
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャスト
        $smart = $shape;
        # SmartArt シェイプのすべてのノードを走査
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # ノードがアシスタントノードか確認
          if ($node->isAssistant()) {
            # アシスタントノードを false に設定し、通常ノードに変更
            $node->isAssistant();
          }
        }
      }
    }
    # プレゼンテーションを保存
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: スライド内の SmartArt シェイプで変更された Assistant Nodes**|

## **ノードの塗りつぶし形式を設定する**
Aspose.Slides for PHP via Java を使用すると、カスタム SmartArt シェイプを追加し、塗りつぶし形式を設定できます。本稿では、SmartArt シェイプを作成およびアクセスし、塗りつぶし形式を設定する方法を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. **LayoutType** ([SmartArtLayoutType#ClosedChevronProcess](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)) を設定して SmartArt シェイプを追加します。
1. SmartArt シェイプのノードに対して **FillFormat** ([IShape#getFillFormat--](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--)) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。
```php
  # プレゼンテーションをインスタンス化
  $pres = new Presentation();
  try {
    # スライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt シェイプとノードを追加
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # ノードの塗りつぶし色を設定
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # プレゼンテーションを保存
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt 子ノードのサムネイルを生成する**
以下の手順に従って、SmartArt の子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. SmartArt を [追加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```php
  # PPTX ファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation();
  try {
    # SmartArt を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # インデックスを使用してノードの参照を取得
    $node = $smart->getNodes()->get_Item(1);
    # サムネイルを取得
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # サムネイルを保存
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


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/php-java/shape-animation/)（入り、退出、強調、動きのパス）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付与できます。

**スライド上で内部 ID が不明な特定の SmartArt を確実に見つける方法はありますか？**

[代替テキスト](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) を設定して検索します。SmartArt に固有の AltText を設定すれば、内部識別子に依存せずにプログラムから見つけることができます。

**プレゼンテーションを PDF に変換した際に SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/php-java/convert-powerpoint-to-pdf/) 時に高い視覚忠実度で SmartArt をレンダリングし、レイアウト、色、エフェクトを保持します。

**SmartArt 全体の画像を抽出してプレビューやレポートに使用できますか？**

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) または [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) にレンダリングでき、サムネイル、レポート、Web 用などに適した出力が得られます。