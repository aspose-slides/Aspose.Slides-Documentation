---
title: PHPでプレゼンテーションズームを管理する
linktitle: ズームを管理する
type: docs
weight: 60
url: /ja/php-java/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームの追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、サムネイルやトランジションを PPT、PPTX、ODP プレゼンテーションに追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーションの特定のスライド、セクション、および部分にジャンプしたり戻ったりできます。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。 

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドに要約するには、[Summary Zoom](#Summary-Zoom) を使用します。  
* 選択したスライドだけを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。  
* 1 つのセクションだけを表示するには、[Section Zoom](#Section-Zoom) を使用します。  

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションをより動的にし、任意の順序でスライド間を中断せずに自由にナビゲートできます。スライドズームはセクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオで使用できます。

スライドズームは、単一のキャンバス上にいるかのように複数の情報を詳細に掘り下げるのに役立ちます。 

![overview_image](slidezoomsel.png)

スライドズーム オブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/) 列挙体、[ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) クラス、および [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **ズーム フレームの作成**

スライドにズーム フレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズーム フレームでリンクする新しいスライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。  
5.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはスライドにズーム フレームを作成する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2 番目のスライドの背景を作成
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 2 番目のスライドにテキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 3 番目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3 番目のスライドにテキストボックスを作成
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame オブジェクトを追加
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

### **カスタム画像付きズーム フレームの作成**
Aspose.Slides for PHP via Java を使用すると、次の手順で別のスライド プレビュー画像を持つズーム フレームを作成できます。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズーム フレームでリンクする新しいスライドを作成します。  
3.	スライドに識別テキストと背景を追加します。  
4.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
5.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。  
6.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードは別の画像を使用したズーム フレームの作成方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2 番目のスライドの背景を作成
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 3 番目のスライドのテキストボックスを作成
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ズーム オブジェクト用の新しい画像を作成
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ZoomFrame オブジェクトを追加
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

### **ズーム フレームの書式設定**
前のセクションではシンプルなズーム フレームの作成方法を示しました。より複雑なズーム フレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズーム フレームに適用できる書式設定オプションは多数あります。 

スライド上でズーム フレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズーム フレームでリンクする新しいスライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。  
5.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
6.	最初のズーム フレーム オブジェクトにカスタム画像を設定します。  
7.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。  
8.	2 番目のズーム フレーム オブジェクトの画像から背景を削除します。  
5.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはスライド上でズーム フレームの書式設定を変更する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 2 番目のスライドの背景を作成
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 2 番目のスライドにテキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 3 番目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3 番目のスライドにテキストボックスを作成
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame オブジェクトを追加
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # ズーム オブジェクト用の新しい画像を作成
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # zoomFrame1 オブジェクトにカスタム画像を設定
    $zoomFrame1->setImage($picture);
    # zoomFrame2 オブジェクトのズームフレーム書式を設定
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # zoomFrame2 オブジェクトの背景非表示設定
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

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、特に強調したいセクションに戻ったり、プレゼンテーションの特定の部分がどのように接続しているかをハイライトしたりできます。 

![overview_image](seczoomsel.png)

セクションズーム オブジェクトについては、Aspose.Slides が [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) クラスと [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **セクションズーム フレームの作成**

スライドにセクションズーム フレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別背景を追加します。  
4.	ズーム フレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズーム フレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはスライドにズーム フレームを作成する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame オブジェクトを追加
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **カスタム画像付きセクションズーム フレームの作成**

Aspose.Slides for PHP via Java を使用すると、次の手順で別のスライド プレビュー画像を持つセクションズーム フレームを作成できます。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別背景を追加します。  
4.	ズーム フレームでリンクする新しいセクションを作成します。  
5.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
5.	最初のスライドにセクションズーム フレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードは別の画像を使用したズーム フレームの作成方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
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
    # SectionZoomFrame オブジェクトを追加
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

### **セクションズーム フレームの書式設定**

より複雑なセクションズーム フレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズーム フレームに適用できる書式設定オプションは多数あります。 

スライド上でセクションズーム フレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別背景を追加します。  
4.	ズーム フレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズーム フレーム（作成したセクションへの参照を含む）を追加します。  
6.	作成したセクションズーム オブジェクトのサイズと位置を変更します。  
7.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
8.	作成したセクションズーム フレーム オブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドへ戻る* 動作を設定します。  
10.	セクションズーム フレーム オブジェクトの画像から背景を削除します。  
11.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。  
12.	遷移時間を変更します。  
13.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはセクションズーム フレームの書式設定を変更する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame オブジェクトを追加
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrame の書式設定
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

サマリーズームは、プレゼンテーションのすべての要素を一度に表示するランディング ページのようなものです。プレゼンテーション中に、ズームを使用して任意の順序で任意の場所に移動したり、スキップしたり、再度表示したりできます。  

![overview_image](sumzoomsel.png)

サマリーズーム オブジェクトについては、Aspose.Slides が [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/)、[SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/)、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) クラスと [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **サマリーズームの作成**

スライドにサマリーズーム フレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別背景と新しいセクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリーズーム フレームを追加します。  
4.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはスライドにサマリーズーム フレームを作成する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 2", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 3", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 4", $slide);
    # SummaryZoomFrame オブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **サマリーズーム セクションの追加と削除**

サマリーズーム フレーム内のすべてのセクションは [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) オブジェクトで表され、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) オブジェクトに格納されます。セクションの追加または削除は、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) クラスを使用して次のように行えます。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別背景と新しいセクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリーズーム フレームを追加します。  
4.	プレゼンテーションに新しいスライドとセクションを追加します。  
5.	作成したセクションをサマリーズーム フレームに追加します。  
6.	サマリーズーム フレームから最初のセクションを削除します。  
7.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはサマリーズーム フレーム内のセクションを追加および削除する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame オブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Summary Zoom にセクションを追加
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Summary Zoom からセクションを削除
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **サマリーズーム セクションの書式設定**

より複雑なサマリーズーム セクション オブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリーズーム セクション オブジェクトに適用できる書式設定オプションは多数あります。 

サマリーズーム フレーム内のセクション オブジェクトの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別背景と新しいセクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリーズーム フレームを追加します。  
4.	`SummaryZoomSectionCollection` から最初のオブジェクトのサマリーズーム セクション オブジェクトを取得します。  
7.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
8.	作成したセクションズーム フレーム オブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドへ戻る* 動作を設定します。  
11.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。  
12.	遷移時間を変更します。  
13.	変更したプレゼンテーションを書き出して PPTX ファイルにします。  

この PHP コードはサマリーズーム セクション オブジェクトの書式設定を変更する方法を示しています。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 1", $slide);
    # プレゼンテーションに新しいスライドを追加
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # プレゼンテーションに新しいセクションを追加
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame オブジェクトを追加
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 最初の SummaryZoomSection オブジェクトを取得
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # SummaryZoomSection オブジェクトの書式設定
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


## **FAQ**

**対象を表示した後に「親」スライドに戻る動作を制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、これを有効にすると、閲覧者はターゲット コンテンツを閲覧した後に元のスライドに戻ります。

**ズームの「速度」や遷移時間を調整できますか？**

はい。Zoom では `TransitionDuration` を設定でき、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められるズーム オブジェクトの数に制限はありますか？**

ドキュメント化されたハードな API 制限はありません。実際の制限はプレゼンテーション全体の複雑さやビューアのパフォーマンスに依存します。多数のズーム フレームを追加できますが、ファイルサイズやレンダリング時間を考慮してください。