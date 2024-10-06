---
title: テキストボックスの管理
type: docs
weight: 20
url: /ja/php-java/manage-textbox/
description: PHPを使用してPowerPointスライドにテキストボックスを作成します。PHPを使用してPowerPointスライドにテキストボックスまたはテキストフレームに列を追加します。PHPを使用してPowerPointスライドにハイパーリンク付きのテキストボックスを追加します。
---


スライド上のテキストは一般的にテキストボックスまたは図形に存在します。したがって、スライドにテキストを追加するには、テキストボックスを追加し、その中にテキストを入れる必要があります。Aspose.Slides for PHP via Javaはテキストを含む図形を追加することを可能にする[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)インターフェースを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slidesはまた、スライドに図形を追加することを可能にする[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)インターフェースを提供します。しかし、`IShape`インターフェースを介して追加されたすべての図形がテキストを保持できるわけではありません。ただし、[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)インターフェースを介して追加された図形はテキストを含むことができます。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

したがって、テキストを追加したい図形を扱う場合、それが`IAutoShape`インターフェースを介してキャストされたことを確認する必要があります。そうすれば、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)を使用することができます。このページの[テキストの更新](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text)のセクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

スライドにテキストボックスを作成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. 指定された位置に`ShapeType`が`Rectangle`として設定された[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトの参照を取得します。
4. テキストを含む`TextFrame`プロパティを`IAutoShape`オブジェクトに追加します。以下の例では、次のテキストを追加しました：*Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き込みます。 

以下のPHPコードは、上記の手順の実装を示しており、スライドにテキストを追加する方法を示します：

```php
  # Presentationをインスタンス化します
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 自動図形を長方形として追加します
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 長方形にTextFrameを追加します
    $ashp->addTextFrame(" ");
    # テキストフレームにアクセスします
    $txtFrame = $ashp->getTextFrame();
    # テキストフレーム用の段落オブジェクトを作成します
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用のポーションオブジェクトを作成します
    $portion = $para->getPortions()->get_Item(0);
    # テキストを設定します
    $portion->setText("Aspose TextBox");
    # プレゼンテーションをディスクに保存します
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストボックスの形状を確認する**

Aspose.Slidesは、図形を調べてテキストボックスを見つけるための[isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--)プロパティを提供します（[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)クラスから）。

![テキストボックスと図形](istextbox.png)

このPHPコードは、図形がテキストボックスとして作成されたかどうかを確認する方法を示しています：

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "図形はテキストボックスです" : "図形はテキストボックスではありません");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストボックスに列を追加する**

Aspose.Slidesは、テキストボックスに列を追加できる[ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-)および[ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)インターフェースおよび[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスから）を提供します。テキストボックス内の列の数を指定し、列間のスペーシングをポイント単位で設定できます。

このコードは、前述の操作を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 自動図形を長方形として追加します
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 長方形にTextFrameを追加します
    $aShape->addTextFrame("これらのすべての列は、単一のテキストコンテナ内に制限されています -- " . "テキストを追加したり削除したりできますが、新しいテキストまたは残りのテキストは自動的に " . "コンテナ内で流れるように調整されます。テキストが1つのコンテナから " . "他のコンテナに流れることはありません -- PowerPointのテキストの列オプションは制限されています！");
    # TextFrameのテキストフォーマットを取得します
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame内の列数を指定します
    $format->setColumnCount(3);
    # 列間のスペーシングを指定します
    $format->setColumnSpacing(10);
    # プレゼンテーションを保存します
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストフレームに列を追加する**
Aspose.Slides for PHP via Javaは、テキストフレーム内に列を追加できる[ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-)プロパティを提供します（[ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)インターフェースから）。このプロパティを通じて、テキストフレーム内に好きな数の列を指定できます。

このPHPコードは、テキストフレーム内に列を追加する方法を示します：

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("これらのすべての列は、単一のテキストコンテナ内に保持される必要があります -- " . "テキストを追加したり削除したりできます - 新しいテキストや残りのテキストは自動的に " . "コンテナ内にとどまるように調整されます。テキストが1つのコンテナから " . "他のコンテナに溢れることはありません -- PowerPointのテキストの列オプションは制限されています！");
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

Aspose.Slidesを使用すると、テキストボックスに含まれるテキストを変更または更新したり、プレゼンテーションに含まれるすべてのテキストを変更したりできます。 

このPHPコードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # 図形がテキストフレームをサポートしているか確認します（IAutoShape）。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # テキストフレーム内の段落を繰り返します
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 段落内の各ポーションを繰り返します
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// テキストを変更

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 書式を変更

            }
          }
        }
      }
    }
    # 変更されたプレゼンテーションを保存します
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ハイパーリンク付きのテキストボックスを追加する** 

テキストボックス内にリンクを挿入できます。テキストボックスをクリックすると、ユーザーはリンクを開くように指示されます。 

リンクを含むテキストボックスを追加するには、以下の手順を実行します。

1. `Presentation`クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. 指定された位置に`ShapeType`が`Rectangle`として設定された`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトへの参照を取得します。
4. *Aspose TextBox*をデフォルトのテキストとして含む`AutoShape`オブジェクトに`TextFrame`を追加します。 
5. `IHyperlinkManager`クラスをインスタンス化します。 
6. `IHyperlinkManager`オブジェクトを、`TextFrame`の好きなポーションに関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--)プロパティに割り当てます。
7. 最後に、`Presentation`オブジェクトを使ってPPTXファイルを書き込みます。 

以下のPHPコードは、上記の手順の実装を示しており、ハイパーリンク付きのテキストボックスをスライドに追加する方法を示します：

```php
  # PPTXを表すPresentationクラスをインスタンス化します
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 自動図形オブジェクトを長方形として追加します
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # 図形をAutoShapeにキャストします
    $pptxAutoShape = $shape;
    # AutoShapeに関連付けられたITextFrameプロパティにアクセスします
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # フレームにテキストを追加します
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # ポーションテキストのハイパーリンクを設定します
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTXプレゼンテーションを保存します
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```