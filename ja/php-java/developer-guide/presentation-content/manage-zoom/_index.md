---
title: ズームの管理
type: docs
weight: 60
url: /ja/php-java/manage-zoom/
keywords: "ズーム, ズームフレーム, ズームの追加, ズームフレームのフォーマット, サマリーズーム, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPointのズームを使用すると、特定のスライド、セクション、およびプレゼンテーションの部分にジャンプすることができます。プレゼンテーションを行う際に、コンテンツを迅速にナビゲートできるこの機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を1つのスライドで要約するには、[サマリーズーム](#Summary-Zoom)を使用します。
* 選択したスライドのみを表示するには、[スライドズーム](#Slide-Zoom)を使用します。
* 特定のセクションのみを表示するには、[セクションズーム](#Section-Zoom)を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションの流れを妨げることなく、選択した順序でスライド間を自由にナビゲートでき、プレゼンテーションをよりダイナミックにすることができます。スライドズームは、セクションが多くない短いプレゼンテーションに最適ですが、さまざまなプレゼンテーションシナリオでも使用できます。

スライドズームは、単一のキャンバスにいるように感じながら、複数の情報の断片を掘り下げることを支援します。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトに関して、Aspose.Slidesは[ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType)列挙型、[IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame)インターフェース、および[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)インターフェースの下にあるいくつかのメソッドを提供します。

### **ズームフレームの作成**

次の手順でスライドにズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクする新しいスライドを作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドに、作成したスライドへの参照を含むズームフレームを追加します。
5. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、スライドにズームフレームを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2枚目のスライドの背景を作成
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 2枚目のスライドのテキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第二スライド");
    # 3枚目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3枚目のスライドのテキストボックスを作成
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第三スライド");
    # ZoomFrameオブジェクトを追加
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **カスタム画像を使用したズームフレームの作成**
Aspose.Slides for PHP via Javaを使用すると、次の手順で異なるスライドプレビュー画像を持つズームフレームを作成できます：
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクする新しいスライドを作成します。
3. スライドに識別テキストと背景を追加します。
4. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、フレームを埋めるために使用される[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。
5. 最初のスライドに（作成したスライドへの参照を含む）ズームフレームを追加します。
6. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、異なる画像でズームフレームを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2枚目のスライドの背景を作成
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 3枚目のスライドのテキストボックスを作成
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第二スライド");
    # ズームオブジェクト用の新しい画像を作成
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ZoomFrameオブジェクトを追加
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ズームフレームのフォーマット**
前のセクションでは、シンプルなズームフレームを作成する方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。ズームフレームに適用できるフォーマットオプションはいくつかあります。

スライド上でズームフレームのフォーマットを制御する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクする新しいスライドを作成します。
3. 作成したスライドにいくつかの識別テキストと背景を追加します。
4. 最初のスライドに（作成したスライドへの参照を含む）ズームフレームを追加します。
5. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、フレームを埋めるために使用される[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。
6. 最初のズームフレームオブジェクトにカスタム画像を設定します。
7. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
8. 2番目のズームフレームオブジェクトの画像の背景を削除します。
9. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、スライド上でズームフレームのフォーマットを変更する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2枚目のスライドの背景を作成
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 2枚目のスライドのテキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第二スライド");
    # 3枚目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3枚目のスライドのテキストボックスを作成
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第三スライド");
    # ZoomFrameオブジェクトを追加
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # ズームオブジェクト用の新しい画像を作成
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # zoomFrame1オブジェクトにカスタム画像を設定
    $zoomFrame1->setImage($picture);
    # zoomFrame2オブジェクトのフォーマットを設定
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # zoomFrame2オブジェクトの背景を表示しない設定
    $zoomFrame2->setShowBackground(false);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **セクションズーム**

セクションズームは、プレゼンテーションのセクションへのリンクです。セクションズームを使用して、特に強調したいセクションに戻ることができます。また、特定のプレゼンテーションの部分がどのように関連しているかを強調するために使用することもできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトに関して、Aspose.Slidesは[ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame)インターフェースおよび[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)インターフェースの下にあるいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

次の手順でスライドにセクションズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームにリンクする新しいセクションを作成します。
5. 最初のスライドに（作成したセクションへの参照を含む）セクションズームフレームを追加します。
6. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、スライドにズームフレームを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # SectionZoomFrameオブジェクトを追加
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **カスタム画像を使用したセクションズームフレームの作成**

Aspose.Slides for PHP via Javaを使用すると、次の手順で異なるスライドプレビュー画像を持つセクションズームフレームを作成できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームにリンクする新しいセクションを作成します。
5. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、フレームを埋めるために使用される[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。
6. 最初のスライドに（作成したセクションへの参照を含む）セクションズームフレームを追加します。
7. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、異なる画像でセクションズームフレームを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # ズームオブジェクト用の新しい画像を作成
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # SectionZoomFrameオブジェクトを追加
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **セクションズームフレームのフォーマット**

より複雑なセクションズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。セクションズームフレームに適用できるフォーマットオプションはいくつかあります。

スライド上でセクションズームフレームのフォーマットを制御する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームにリンクする新しいセクションを作成します。
5. スライドに（作成したセクションへの参照を含む）セクションズームフレームを追加します。
6. 作成したセクションズームオブジェクトのサイズと位置を変更します。
7. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、フレームを埋めるために使用される[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。
8. 作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9. リンクされたセクションからオリジナルのスライドに戻る能力を設定します。
10. セクションズームフレームオブジェクトの画像の背景を削除します。
11. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
12. トランジションの時間を変更します。
13. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、セクションズームフレームのフォーマットを変更する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # SectionZoomFrameオブジェクトを追加
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrameのフォーマット
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべての部分が一度に表示されるランディングページのようなものです。プレゼンテーション中に、ズームを使用してプレゼンテーションの一箇所から別の箇所に好きな順序で移動することができます。創造的になったり、先に進んだり、プレゼンテーションの流れを中断することなくスライドショーの部分を再訪したりできます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトに関して、Aspose.Slidesは[ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)、および[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)インターフェースと、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)インターフェースの下にあるいくつかのメソッドを提供します。

### **サマリーズームの作成**

次の手順でスライドにサマリーズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 作成したスライドの識別背景と新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、スライドにサマリーズームフレームを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 2", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 3", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 4", $slide);
    # サマリーズームフレームオブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)オブジェクトによって表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)オブジェクトに保存されています。[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)インターフェースを介してサマリーズームセクションオブジェクトを追加または削除できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 作成したスライドの識別背景と新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 新しいスライドとセクションをプレゼンテーションに追加します。
5. 作成したセクションをサマリーズームフレームに追加します。
6. サマリーズームフレームから最初のセクションを削除します。
7. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 2", $slide);
    # サマリーズームフレームオブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $section3 = $pres->getSections()->addSection("セクション 3", $slide);
    # サマリーズームにセクションを追加
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # サマリーズームからセクションを削除
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **サマリーズームセクションのフォーマット**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームのフォーマットを変更する必要があります。サマリーズームセクションオブジェクトに適用できるフォーマットオプションはいくつかあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトのフォーマットを制御する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 作成したスライドの識別背景と新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. `ISummaryZoomSectionCollection`から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
5. ズームフレームを埋めるために使用される[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加して[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成します。
6. 作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7. リンクされたセクションからオリジナルのスライドに戻る能力を設定します。
8. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
9. トランジションの時間を変更します。
10. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、サマリーズームセクションオブジェクトのフォーマットを変更する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("セクション 2", $slide);
    # サマリーズームフレームオブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 最初のSummaryZoomSectionオブジェクトを取得
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # SummaryZoomSectionオブジェクトのフォーマット
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```