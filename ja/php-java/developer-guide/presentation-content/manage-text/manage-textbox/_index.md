---
title: PHP を使用したプレゼンテーション内のテキストボックス管理
linktitle: テキストボックスの管理
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
description: "Aspose.Slides for PHP を使用すると、PowerPoint および OpenDocument ファイル内でテキストボックスの作成、編集、複製が簡単になり、プレゼンテーションの自動化が向上します。"
---

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックスにテキストを入れる必要があります。Aspose.Slides for PHP via Java は、テキストを含むシェイプを追加できる [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) インターフェイスを提供しています。

{{% alert title="Info" color="info" %}}
Aspose.Slides には、スライドにシェイプを追加できる [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) インターフェイスも用意されています。ただし、`IShape` インターフェイスで追加したすべてのシェイプがテキストを保持できるわけではありません。`[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)` インターフェイスで追加したシェイプはテキストを含むことができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合は、まずそのシェイプが `IAutoShape` インターフェイスにキャストされているか確認してください。`IAutoShape` の下にあるプロパティ `TextFrame` を使用できるようになるからです。このページの [Update Text](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) セクションをご参照ください。
{{% /alert %}}

## **Create a Text Box on a Slide**

テキスト ボックスをスライドに作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` として `ShapeType` を設定した [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) オブジェクトを追加し、追加された `IAutoShape` オブジェクトへの参照を取得します。  
4. テキストを含む `TextFrame` プロパティを `IAutoShape` オブジェクトに追加します。以下の例では、*Aspose TextBox* というテキストを追加しています。  
5. 最後に `Presentation` オブジェクトを使って PPTX ファイルを書き出します。

以下の PHP コードは、上記手順の実装例で、スライドにテキストを追加する方法を示しています:
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


## **Check for a Text Box Shape**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) クラスの [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) メソッドを提供しており、シェイプがテキスト ボックスかどうかを判定できます。

![Text box and shape](istextbox.png)

この PHP コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています:
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


`addAutoShape` メソッド（[ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラス）で単にオートシェイプを追加した場合、`isTextBox` メソッドは `false` を返します。しかし、`addTextFrame` メソッドまたは `setText` メソッドでオートシェイプにテキストを追加すると、`isTextBox` プロパティは `true` を返します。
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


## **Add Columns to a Text Box**

Aspose.Slides は、[ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) インターフェイスおよび [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスの [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) と [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) プロパティを提供しており、テキスト ボックスに列を追加できます。列数と列間のポイント単位の間隔を設定できます。

以下のコードは、上記操作を実演したものです:
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # タイプを Rectangle に設定した AutoShape を追加
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 矩形に TextFrame を追加
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


## **Add Columns to a Text Frame**

Aspose.Slides for PHP via Java は、[ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) インターフェイスの [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) プロパティを提供しており、テキスト フレーム内に列を追加できます。このプロパティを使用して、テキスト フレーム内の列数を指定できます。

この PHP コードは、テキスト フレームに列を追加する方法を示しています:
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


## **Update Text**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下の PHP コードは、プレゼンテーション内のすべてのテキストを更新（変更）する操作例です:
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # shapeがテキストフレーム（IAutoShape）をサポートしているか確認します。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # テキストフレーム内の段落を反復処理します
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 段落内の各ポーションを反復処理します
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// テキストを変更します

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 書式を変更します

            }
          }
        }
      }
    }
    # 変更したプレゼンテーションを保存します
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Add a Text Box with a Hyperlink** 

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはリンク先へ移動します。

テキスト ボックスにリンクを含める手順は次のとおりです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` として `ShapeType` を設定した `AutoShape` オブジェクトを追加し、追加された AutoShape オブジェクトへの参照を取得します。  
4. `AutoShape` オブジェクトに `TextFrame` を追加し、デフォルトテキストとして *Aspose TextBox* を設定します。  
5. `IHyperlinkManager` クラスのインスタンスを作成します。  
6. `TextFrame` の対象部分に対し、`IHyperlinkManager` オブジェクトを [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) プロパティに割り当てます。  
7. 最後に `Presentation` オブジェクトを使って PPTX ファイルを書き出します。

以下の PHP コードは、上記手順の実装例で、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています:
```php
  # PPTX を表す Presentation クラスをインスタンス化
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
    # ポーションテキストにハイパーリンクを設定
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

**マスタースライドでテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

プレースホルダー（[placeholder](/slides/ja/php-java/manage-placeholder/)）は、[マスタ](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) からスタイル/位置を継承し、[レイアウト](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) でオーバーライド可能です。一方、通常のテキスト ボックスは特定のスライド上の独立オブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキスト フレームを持つオートシェイプだけを対象に反復処理し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)、[テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)）はそれぞれのコレクションを別途走査するか、対象タイプから除外してください。