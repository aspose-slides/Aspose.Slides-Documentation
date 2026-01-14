---
title: PHPでプレゼンテーションのテキストボックスを管理する
linktitle: テキストボックス管理
type: docs
weight: 20
url: /ja/php-java/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキスト追加
- テキスト更新
- テキストボックス作成
- テキストボックス確認
- テキスト列追加
- ハイパーリンク追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP は、PowerPoint および OpenDocument ファイル内のテキストボックスの作成、編集、複製を簡単に行えるようにし、プレゼンテーションの自動化を強化します。"
---


スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキストボックスを追加し、そのテキストボックス内にテキストを入れる必要があります。Aspose.Slides for PHP via Java は、テキストを含むシェイプを追加できる[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)クラスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドにシェイプを追加できる[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)クラスも提供します。ただし、`Shape`クラスで追加されたすべてのシェイプがテキストを保持できるわけではありません。一方、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)クラスで追加されたシェイプはテキストを含むことができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
したがって、テキストを追加したいシェイプを扱う場合、そのシェイプが`AutoShape`クラスを介してキャストされたものであるか確認したいでしょう。`AutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)を使用できるのはその場合だけです。このページの[Update Text](/slides/ja/php-java/manage-textbox/#update-text)セクションをご覧ください。
{{% /alert %}}

## **スライド上にテキストボックスを作成する**

スライドにテキストボックスを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。
3. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)オブジェクトを、シェイプタイプを[Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle)に設定し、スライド上の指定位置に追加し、 新しく追加された`AutoShape`オブジェクトへの参照を取得します。
4. `AutoShape`オブジェクトにテキストを含む`TextFrame`を追加します。以下の例では、次のテキストを追加しました: *Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを使用して PPTX ファイルを書き出します。

以下の PHP コードは、上記手順の実装例で、スライドにテキストを追加する方法を示します。
```php
  # プレゼンテーションのインスタンス化
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame(" ");
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    # テキストフレーム用の Paragraph オブジェクトを作成
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


## **テキストボックスシェイプの確認**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)クラスの[isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/istextbox/)メソッドを提供し、シェイプを調べてテキストボックスかどうかを判別できます。

![テキストボックスとシェイプ](istextbox.png)

以下の PHP コードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示します。
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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


注意: [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)クラスの`addAutoShape`メソッドで単にオートシェイプを追加した場合、オートシェイプの`isTextBox`メソッドは`false`を返します。ただし、`addTextFrame`メソッドまたは`setText`メソッドでオートシェイプにテキストを追加すると、`isTextBox`プロパティは`true`を返します。
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() は false を返します
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() は true を返します

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() は false を返します
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() は true を返します

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() は false を返します
$shape3->addTextFrame("");
// shape3->isTextBox() は false を返します

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() は false を返します
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() は false を返します
```


## **テキストボックスに列を追加する**

Aspose.Slides は、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/)クラスの[setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/)と[setColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumnspacing/)メソッドを提供し、テキストボックスに列を追加できます。テキストボックスの列数を指定し、列間の間隔（ポイント）を設定できます。

このコードは、上記の操作を示しています。
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape を追加
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle に TextFrame を追加
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame のテキスト形式を取得
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


## **テキストフレームに列を追加する**

Aspose.Slides for PHP via Java は、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/)クラスの[setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/)メソッドを提供し、テキストフレームに列を追加できます。このプロパティで、テキストフレームの希望する列数を指定できます。

以下の PHP コードは、テキストフレーム内に列を追加する方法を示します。
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


## **テキストの更新**

Aspose.Slides を使用すると、テキストボックス内のテキストやプレゼンテーション全体のテキストを変更または更新できます。

以下の PHP コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています。
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # シェイプがテキストフレーム（IAutoShape）をサポートしているかチェックします。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # テキストフレーム内の段落を反復処理します。
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 段落内の各ポーションを反復処理します。
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// テキストを変更します。

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 書式を変更します。

            }
          }
        }
      }
    }
    # 変更したプレゼンテーションを保存します。
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンク先を開きます。

リンクを含むテキストボックスを追加するには、次の手順を実行します。

1. `Presentation`クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。
3. `ShapeType`を`Rectangle`に設定した`AutoShape`オブジェクトをスライド上の指定位置に追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。
4. `AutoShape`オブジェクトに、デフォルトテキストとして *Aspose TextBox* を含む`TextFrame`を追加します。
5. `HyperlinkManager`クラスのインスタンスを作成します。
6. `TextFrame`の対象部分に対して、[setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)メソッドを使用してハイパーリンクを割り当てます。
7. 最後に、`Presentation`オブジェクトを使用して PPTX ファイルを書き出します。

以下の PHP コードは、上記手順の実装例で、ハイパーリンク付きテキストボックスをスライドに追加する方法を示します。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape オブジェクトを追加します
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # シェイプを AutoShape にキャストします
    $pptxAutoShape = $shape;
    # AutoShape に関連付けられた ITextFrame プロパティにアクセスします
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # フレームにテキストを追加します
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # ポーションテキストのハイパーリンクを設定します
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX プレゼンテーションを保存します
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**マスタースライドで作業する際、テキストボックスとテキストプレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/php-java/manage-placeholder/)は、[master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)からスタイルと位置を継承し、[layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)で上書きできます。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストを変更せずに、プレゼンテーション全体で一括テキスト置換を実行するにはどうすればよいですか？**

反復処理をテキストフレームを持つオートシェイプのみに限定し、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)）はそれぞれのコレレクションを別途走査するか、該当オブジェクトタイプをスキップして除外してください。