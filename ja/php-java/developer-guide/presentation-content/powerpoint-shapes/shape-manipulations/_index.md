---
title: 形の操作
type: docs
weight: 40
url: /php-java/shape-manipulations/
---

## **スライド内の形を見つける**
このトピックでは、開発者が内部IDを使用せずにスライド上の特定の形を見つけるための簡単な技術について説明します。PowerPointプレゼンテーションファイルには、内部の一意のIDを除いてスライド上の形を識別する方法がないことを知っておくことが重要です。開発者が内部の一意のIDを使用して形を見つけることは難しいようです。スライドに追加されたすべての形には、いくつかの代替テキストがあります。特定の形を見つけるために代替テキストを使用することを開発者に推奨します。将来的に変更を計画しているオブジェクトの代替テキストを定義するために、MS PowerPointを使用することができます。

任意の形の代替テキストを設定した後、Aspose.Slides for PHPを使用してそのプレゼンテーションを開き、スライドに追加されたすべての形を繰り返し処理できます。各反復の間に、形の代替テキストを確認し、一致する代替テキストの形が必要な形であることを確認できます。この技術をより良く示すために、特定の形をスライド内で見つけて単にその形を返すメソッド、[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)を作成しました。

```php
  # プレゼンテーションクラスのインスタンスを作成する
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 見つける形の代替テキスト
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("形の名前: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **形をクローンする**
Aspose.Slides for PHPを使用してスライドに形をクローンするには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドの形コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドの形コレクションから新しいスライドに形をクローンします。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、グループ形をスライドに追加します。

```php
  # プレゼンテーションクラスをインスタンス化する
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTXファイルをディスクに書き込む
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形を削除する**
Aspose.Slides for PHPを使用すると、開発者は任意の形を削除できます。任意のスライドから形を削除するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定のAlternativeTextを持つ形を見つけます。
1. その形を削除します。
1. ファイルをディスクに保存します。

```php
  # プレゼンテーションオブジェクトを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプの自動形を追加
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "ユーザー定義";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # プレゼンテーションをディスクに保存
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形を隠す**
Aspose.Slides for PHPを使用すると、開発者は任意の形を隠すことができます。任意のスライドから形を隠すには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定のAlternativeTextを持つ形を見つけます。
1. その形を隠します。
1. ファイルをディスクに保存します。

```php
  # PPTXを表すプレゼンテーションクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプの自動形を追加
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "ユーザー定義";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # プレゼンテーションをディスクに保存
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形の順序を変更する**
Aspose.Slides for PHPを使用すると、開発者は形の順序を変更できます。形の順序を変更することで、どの形が前面にあるか、どの形が背面にあるかを指定できます。任意のスライドから形の順序を変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 形を追加します。
1. 形のテキストフレームにいくつかのテキストを追加します。
1. 同じ座標で別の形を追加します。
1. 形の順序を変更します。
1. ファイルをディスクに保存します。

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("透かしテキスト 透かしテキスト 透かしテキスト");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形のInterop IDを取得する**
Aspose.Slides for PHPを使用すると、[getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--)メソッドとは異なり、スライドスコープ内で一意の形識別子を取得できます。このメソッドはプレゼンテーションスコープで一意の識別子を取得することを可能にします。メソッド[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--)は[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)インターフェースと[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape)クラスにそれぞれ追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--)メソッドによって返される値は、Microsoft.Office.Interop.PowerPoint.ShapeオブジェクトのIdの値に対応します。以下にサンプルコードを示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # スライドスコープ内で一意の形識別子を取得
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形の代替テキストを設定する**
Aspose.Slides for PHPを使用すると、任意の形のAlternateTextを設定できます。
プレゼンテーション内の形は、[AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-)または[Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-)メソッドによって区別されることがあります。
[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-)および[getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--)メソッドは、Aspose.SlidesおよびMicrosoft PowerPointを使用して読み取ったり設定したりすることができます。
このメソッドを使用することで、形にタグを付け、形を削除する、形を隠す、スライド上の形の順序を変更するといった異なる操作を実行できます。
形のAlternateTextを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意の形を追加します。
1. 新しく追加した形で何か作業をします。
1. 形を探すために形を横断します。
1. AlternativeTextを設定します。
1. ファイルをディスクに保存します。

```php
  # PPTXを表すプレゼンテーションクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプの自動形を追加
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("ユーザー定義");
      }
    }
    # プレゼンテーションをディスクに保存
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形のレイアウト形式にアクセスする**
Aspose.Slides for PHPは、形のレイアウト形式にアクセスするための簡単なAPIを提供します。この文書では、どのようにレイアウト形式にアクセスできるかを示します。

以下にサンプルコードを示します。

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形をSVGとしてレンダリングする**
Aspose.Slides for PHPは、形をSVGとしてレンダリングするサポートを追加しました。[writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)メソッド（およびそのオーバーロード）は、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape)クラスおよび[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)インターフェースに追加されました。このメソッドを使用すると、形の内容をSVGファイルとして保存できます。以下のコードスニペットは、スライドの形をSVGファイルにエクスポートする方法を示しています。

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形の整列**
Aspose.Slidesは、形をスライドのマージンに対して整列させることも、互いに整列させることもできます。この目的のために、オーバーロードされたメソッド[SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType)列挙型は、可能な整列オプションを定義します。

**例 1**

以下のソースコードは、インデックス1、2、および4の形をスライドの上端に沿って整列させます。

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**例 2**

以下の例は、形のコレクション全体をコレクション内の最も下の形に対して整列させる方法を示しています。

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```