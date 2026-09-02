---
title: PHP を使用したプレゼンテーションのテキスト ボックス管理
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/php-java/manage-textbox/
keywords:
- テキスト ボックス
- テキスト フレーム
- テキストの追加
- テキストの更新
- テキスト ボックスの作成
- テキスト ボックスの確認
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP は、PowerPoint および OpenDocument ファイル内でテキスト ボックスの作成、編集、クローン作成を簡単に行えるようにし、プレゼンテーションの自動化を強化します。"
---
## **はじめに**

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックスの中にテキストを入れる必要があります。Aspose.Slides for PHP via Java は、テキストを含むシェイプを追加できる [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) クラスを提供します。

{{% alert title="Info" color="info" %}}

Aspose.Slides は、スライドにシェイプを追加できる [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) クラスも提供します。ただし、`Shape` クラスで追加されたすべてのシェイプがテキストを保持できるわけではありません。一方、[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) クラスで追加されたシェイプはテキストを含むことができます。

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

したがって、テキストを追加したいシェイプを扱う場合、そのシェイプが `AutoShape` クラスにキャストされていることを確認したいでしょう。そうで初めて、`AutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を操作できます。このページの [Update Text](/slides/ja/php-java/manage-textbox/#update-text) セクションをご参照ください。

{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

スライドにテキスト ボックスを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置にシェイプタイプを [Rectangle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapetype/#Rectangle) に設定した [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) オブジェクトを追加し、追加された `AutoShape` オブジェクトへの参照を取得します。  
4. テキストを含む `AutoShape` オブジェクトに `TextFrame` を追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。  
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この PHP コードは、上記手順の実装例であり、スライドにテキストを追加する方法を示しています。

```php
  # プレゼンテーションをインスタンス化
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame(" ");
    # テキスト フレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    # テキスト フレーム用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    # テキストを設定
    $portion->setText("Aspose TextBox");
    # プレゼンテーションをディスクに保存
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキスト ボックス シェイプかどうかを確認する**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) クラスの [isTextBox](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/istextbox/) メソッドを提供しており、シェイプを調べてテキスト ボックスかどうかを判別できます。

![テキスト ボックスとシェイプ](istextbox.png)

この PHP コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています。

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

`addAutoShape` メソッド（[ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) クラス）で単に AutoShape を追加した場合、`isTextBox` メソッドは `false` を返します。ただし、`addTextFrame` メソッドまたは `setText` メソッドで AutoShape にテキストを追加した後は、`isTextBox` プロパティは `true` を返します。

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() は false を返す
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() は true を返す

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() は false を返す
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() は true を返す

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() は false を返す
$shape3->addTextFrame("");
// shape3->isTextBox() は false を返す

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() は false を返す
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() は false を返す
```

## **TextFrame を所有しているシェイプを取得する**

一般的なテキスト処理コードでは、どのプレゼンテーション オブジェクトが所有しているか分からないまま [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を受け取ることがあります。所有する [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) に戻るには、[TextFrame::getParentShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParentShape) メソッドを使用します。

[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) または他のテキストを含むシェイプに属するテキスト フレームの場合、`TextFrame::getParentShape` は所有者シェイプを返し、`TextFrame::getParentCell` は `null` を返します。両メソッドは読み取り専用のナビゲーションを提供するため、呼び出しても所有権は変更されません。シェイプへアクセスする前に、必ず `java_is_null` で返り値を確認してください。

SmartArt ノードに関連付けられたシェイプやテーブル セル所有者を特定する完全な例については、[Search and Replace Text](/slides/ja/php-java/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

Aspose.Slides は、[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/) クラスの [setColumnCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/setcolumncount/) と [setColumnSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/setcolumnspacing/) メソッドを提供しており、テキスト ボックスに列を追加できます。列数と列間のポイント単位の間隔を指定できます。

このコードは上記の操作を示しています。

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape を追加
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 矩形に TextFrame を追加
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame のテキスト フォーマットを取得
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame の列数を指定
    $format->setColumnCount(3);
    # 列間の間隔を指定
    $format->setColumnSpacing(10);
    # プレゼンテーションを保存
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキスト フレームに列を追加する**

Aspose.Slides for PHP via Java は、[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/) クラスの [setColumnCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/setcolumncount/) メソッドを提供しており、テキスト フレーム内に列を追加できます。このプロパティを使用して、テキスト フレーム内の希望する列数を指定できます。

この PHP コードは、テキスト フレームに列を追加する方法を示しています。

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストを更新する**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるすべてのテキストを変更または更新できます。

この PHP コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています。

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # シェイプがテキスト フレーム (IAutoShape) をサポートしているか確認します。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # テキスト フレーム内の段落を反復処理
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 段落内の各ポーションを反復処理
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// テキストを変更

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 書式設定を変更

            }
          }
        }
      }
    }
    # 変更されたプレゼンテーションを保存
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ハイパーリンク付きテキスト ボックスを追加する**

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはリンク先を開きます。

ハイパーリンクを含むテキスト ボックスを追加する手順は次のとおりです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `ShapeType` を `Rectangle` に設定した `AutoShape` オブジェクトを追加し、追加された AutoShape オブジェクトへの参照を取得します。  
4. `AutoShape` オブジェクトに *Aspose TextBox* をデフォルト テキストとして含む `TextFrame` を追加します。  
5. `HyperlinkManager` クラスのインスタンスを生成します。  
6. 好みの `TextFrame` の一部に対して、[setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) メソッドを使用してハイパーリンクを割り当てます。  
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この PHP コードは、上記手順の実装例であり、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています。

```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape オブジェクトを追加
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # シェイプを AutoShape にキャスト
    $pptxAutoShape = $shape;
    # AutoShape に関連付けられた ITextFrame プロパティにアクセス
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # フレームにテキストを追加
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # ポーション テキストにハイパーリンクを設定
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX プレゼンテーションを保存
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**マスタースライドで作業する際、テキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/php-java/manage-placeholder/) は、[マスタースライド](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) からスタイル/位置を継承し、[レイアウト](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) で上書き可能ですが、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変化しません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体で一括テキスト置換を行うにはどうすればよいですか？**

テキスト フレームを持つ AutoShape のみを対象にイテレーションし、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/)、[テーブル](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/)）はそれぞれのコレクションを別途走査するか、該当オブジェクトタイプをスキップして除外してください。