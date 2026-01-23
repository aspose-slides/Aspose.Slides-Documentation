---
title: PHP を使用してプレゼンテーションの SmartArt シェイプ ノードを管理する
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
description: "Aspose.Slides for PHP via Java を使用して PPT と PPTX の SmartArt シェイプ ノードを管理します。明確なコードサンプルとヒントでプレゼンテーションを効率化しましょう。"
---

## **SmartArt ノードの追加**
Aspose.Slides for PHP via Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. SmartArt シェイプの **NodeCollection** に新しいノードを [Add a new Node](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) で追加し、TextFrame にテキストを設定します。
6. 新しく追加した SmartArt ノードに対し、[Add](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) で **Child Node** を作成し、TextFrame にテキストを設定します。
7. プレゼンテーションを保存します。
```php
  # プレゼンテーションを読み込む
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
        # テキストを設定する
        $TemNode->getTextFrame()->setText("Test");
        # 親ノードに新しい子ノードを追加する。コレクションの末尾に追加される
        $newNode = $TemNode->getChildNodes()->addNode();
        # テキストを設定する
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


## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプのそれぞれのノードに属する子ノードを指定した位置に追加する方法を説明します。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. アクセスしたスライドに [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。
4. 追加した SmartArt シェイプの最初のノードにアクセスします。
5. 選択した **Node** の位置 2 に **Child Node** を追加し、テキストを設定します。
6. プレゼンテーションを保存します。
```php
  # プレゼンテーションのインスタンスを作成する
  $pres = new Presentation();
  try {
    # プレゼンテーションのスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape を追加する
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス 0 の SmartArt ノードにアクセスする
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置 2 に新しい子ノードを追加する
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


## **SmartArt ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されることに注意してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. SmartArt シェイプ内のすべての **Nodes** を走査します。
6. SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # プレゼンテーション クラスをインスタンス化する
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        # SmartArt 内のすべてのノードを走査する
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックス i の SmartArt ノードにアクセスする
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt ノードのパラメータを出力する
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


## **SmartArt 子ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内の各ノードに属する子ノードにアクセスする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. SmartArt シェイプ内のすべての **Nodes** を走査します。
6. 各 **Node** について、該当ノード内のすべての **Child Nodes** を走査します。
7. **Child Node** の位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # Presentation クラスをインスタンス化する
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        # SmartArt 内のすべてのノードを走査する
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # インデックス i の SmartArt ノードにアクセスする
          $node0 = $smart->getAllNodes()->get_Item($i);
          # インデックス i の SmartArt ノード内の子ノードを走査する
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArt ノードの子ノードにアクセスする
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt 子ノードのパラメータを出力する
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


## **特定の位置にある SmartArt 子ノードへのアクセス**
この例では、SmartArt シェイプの各ノードに属する子ノードを特定の位置で取得する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。
4. 追加した SmartArt シェイプにアクセスします。
5. インデックス 0 のノードにアクセスします。
6. **get_Item()** メソッドを使用して、取得した SmartArt ノードの位置 1 にある **Child Node** にアクセスします。
7. **Child Node** の位置、レベル、テキストなどの情報にアクセスして表示します。
```php
  # プレゼンテーションをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライドに SmartArt シェイプを追加する
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # インデックス 0 の SmartArt ノードにアクセスする
    $node = $smart->getAllNodes()->get_Item(0);
    # 親ノードの位置 1 の子ノードにアクセスする
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt 子ノードのパラメータを出力する
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. SmartArt に 0 個以上のノードが存在するか確認します。
6. 削除対象の SmartArt ノードを選択します。
7. 選択したノードを [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode) メソッドで削除します。
8. プレゼンテーションを保存します。
```php
  # 目的のプレゼンテーションをロードする
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


## **特定の位置にある SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを特定の位置で削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. インデックス 0 の SmartArt シェイプノードを選択します。
6. 選択した SmartArt ノードに 2 個以上の子ノードがあるか確認します。
7. **Position 1** のノードを [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode) メソッドで削除します。
8. プレゼンテーションを保存します。
```php
  # 目的のプレゼンテーションをロードする
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


## **SmartArt オブジェクト内の子ノードにカスタム位置を設定**
Aspose.Slides for PHP via Java は、[SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) の [X](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setX) および [Y](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setY) プロパティの設定をサポートします。以下のコードスニペットは、カスタムの SmartArtShape 位置、サイズ、回転を設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。カスタム位置設定により、ユーザーは要件に合わせてノードを配置できます。
```php
  # Presentation クラスをインスタンス化する
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt シェイプを新しい位置に移動する
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt シェイプの幅を変更する
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt シェイプの高さを変更する
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt シェイプの回転を変更する
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **アシスタント ノードの確認**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for PHP via Java を使用してプログラムでプレゼンテーション スライドに追加された SmartArt シェイプの機能をさらに調査します。

{{% /alert %}} 

調査に使用する SmartArt シェイプは、この記事の各セクションで使用します。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: ソース SmartArt シェイプ（スライド）**|

以下のサンプルコードでは、SmartArt ノードコレクション内の **Assistant Nodes** を特定し、変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
2. インデックスを使用して 2 番目のスライドへの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) タイプか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) に型キャストします。
5. SmartArt シェイプ内のすべてのノードを走査し、[**Assistant Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) かどうかを確認します。
6. アシスタント ノードのステータスを通常のノードに変更します。
7. プレゼンテーションを保存します。
```php
  # プレゼンテーション インスタンスを作成する
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # シェイプが SmartArt タイプか確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArt に型キャストする
        $smart = $shape;
        # SmartArt シェイプのすべてのノードを走査する
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # ノードがアシスタントノードか確認する
          if ($node->isAssistant()) {
            # アシスタントノードを false に設定し、通常ノードにする
            $node->isAssistant();
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
|**Figure: スライド内 SmartArt シェイプで変更されたアシスタント ノード**|

## **ノードの塗りつぶし形式の設定**
Aspose.Slides for PHP via Java を使用すると、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できます。本記事では、SmartArt シェイプの作成とアクセス、および塗りつぶし形式の設定方法を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. **LayoutType** を設定して [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) シェイプを追加します。
4. SmartArt シェイプのノードに対して [**Fill Format**](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFillFormat) を設定します。
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。
```php
  # プレゼンテーションをインスタンス化する
  $pres = new Presentation();
  try {
    # スライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt シェイプとノードを追加する
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


## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順で SmartArt の子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Add SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) を実行します。
3. インデックスを使用してノードへの参照を取得します。
4. サムネイル画像を取得します。
5. 任意の画像フォーマットでサムネイル画像を保存します。
```php
  # PPTX ファイルを表す Presentation クラスをインスタンス化する
  $pres = new Presentation();
  try {
    # SmartArt を追加する
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


## **FAQ**

**SmartArt アニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/php-java/shape-animation/)（入場、退場、強調、動きの経路）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付与できます。

**スライド上で内部 ID が不明な特定の SmartArt を確実に見つける方法は？**

[代替テキスト](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) を設定し、検索します。SmartArt に固有の AltText を付与すれば、内部識別子に依存せずプログラムから取得できます。

**プレゼンテーションを PDF に変換するとき、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/php-java/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚忠実度で描画し、レイアウト、色、効果を保持します。

**SmartArt 全体の画像を抽出してプレビューやレポートに利用できますか？**

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) または [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) にレンダリングでき、サムネイル、レポート、Web 用の画像として利用可能です。
```php
  # プレゼンテーションをインスタンス化する
  $pres = new Presentation();
  try {
    # スライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt シェイプとノードを追加する
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
