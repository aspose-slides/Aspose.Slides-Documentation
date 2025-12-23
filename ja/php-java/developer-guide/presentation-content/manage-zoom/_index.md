---
title: PHPでプレゼンテーションズームを管理
linktitle: ズームの管理
type: docs
weight: 60
url: /ja/php-java/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームを追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、サムネイルやトランジションを PPT、PPTX、ODP プレゼンテーション全体に追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、部分へ、またはそこからジャンプできます。プレゼンテーション中に、コンテンツを素早く移動できるこの機能は非常に便利です。

![overview_image](overview.png)

* 全体のプレゼンテーションを 1 つのスライドに要約するには、[サマリーズーム](#Summary-Zoom) を使用します。
* 選択したスライドだけを表示するには、[スライドズーム](#Slide-Zoom) を使用します。
* 単一のセクションだけを表示するには、[セクションズーム](#Section-Zoom) を使用します。

## **スライドズーム**

スライドズームを使用すると、プレゼンテーションがよりダイナミックになり、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断せずにすみます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなプレゼンテーションシナリオでも使用できます。

スライドズームは、単一のキャンバス上にいるように感じながら、複数の情報に深く踏み込むことを可能にします。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) インターフェイスのいくつかのメソッドを提供しています。

### **ズームフレームの作成**

スライドにズームフレームを追加するには、次の手順を実行します。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、スライド上にズームフレームを作成する方法を示しています。
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
    # 2枚目のスライド用テキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 3枚目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3枚目のスライド用テキストボックスを作成
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


### **カスタム画像付きズームフレームの作成**

With Aspose.Slides for PHP via Java, you can create a zoom frame with a different slide preview image this way:
1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。
3.	スライドに識別テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、別の画像を使用したズームフレームを作成する方法を示しています。
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
    $autoshape->getTextFrame()->setText("Second Slide");
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


### **ズームフレームの書式設定**

In the previous sections, we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a zoom frame. 

You can control a zoom frame's formatting on a slide this way:

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。
3.	作成したスライドにいくつかの識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。
9.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、スライド上でズームフレームの書式設定を変更する方法を示しています。
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
    # 2枚目のスライド用テキストボックスを作成
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 3枚目のスライドの背景を作成
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 3枚目のスライド用テキストボックスを作成
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame オブジェクトを追加
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
    # zoomFrame1 オブジェクトにカスタム画像を設定
    $zoomFrame1->setImage($picture);
    # zoomFrame2 オブジェクトのズームフレーム書式を設定
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # zoomFrame2 オブジェクトの背景を表示しない設定
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

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、強調したいセクションに戻ったり、プレゼンテーションの特定の部分がどのように接続されているかをハイライトしたりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) インターフェイスと [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) インターフェイスのいくつかのメソッドを提供しています。

### **セクションズームフレームの作成**

セクションズームフレームをスライドに追加するには、次の手順を実行します。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、スライド上にセクションズームフレームを作成する方法を示しています。
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


### **カスタム画像付きセクションズームフレームの作成**

Using Aspose.Slides for PHP via Java, you can create a section zoom frame with a different slide preview image this way:

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。
5.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、別の画像を使用したセクションズームフレームを作成する方法を示しています。
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


### **セクションズームフレームの書式設定**

To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。
10.	セクションズームフレームオブジェクトの画像から背景を削除します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの期間を変更します。
13.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、セクションズームフレームの書式設定を変更する方法を示しています。
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

サマリーズームは、プレゼンテーションのすべてのパーツが一度に表示されるランディング ページのようなものです。プレゼンテーション中に、サマリーズームを使って任意の順序でスライド間を移動できます。創造的にスキップしたり、前後に戻ったりしても、プレゼンテーションの流れを中断しません。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) インターフェイスと [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) インターフェイスのいくつかのメソッドを提供しています。

### **サマリーズームの作成**

サマリーズームフレームをスライドに追加するには、次の手順を実行します。

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、スライド上にサマリーズームフレームを作成する方法を示しています。
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


### **サマリーズームセクションの追加と削除**

All sections in a summary zoom frame are represented by [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) interface this way:

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています。
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
    # Summary Zoomにセクションを追加
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Summary Zoomからセクションを削除
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # プレゼンテーションを保存
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **サマリーズームセクションの書式設定**

To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
5.	[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。
8.	2 番目のズームフレームオブジェクトの線の書式を変更します。
9.	トランジションの期間を変更します。
10.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、サマリーズームセクションオブジェクトの書式設定を変更する方法を示しています。
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


## **よくある質問**

**対象を表示した後に「親」スライドに戻ることを制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、有効にすると、視聴者はターゲット コンテンツを閲覧した後、元のスライドに戻ります。

**ズーム トランジションの「速度」や期間を調整できますか？**

はい。Zoom は `TransitionDuration` を設定でき、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められる Zoom オブジェクトの数に制限はありますか？**

ドキュメント化されたハードな API 制限はありません。実際の制限はプレゼンテーション全体の複雑さやビューアーの性能に依存します。多くの Zoom フレームを追加できますが、ファイル サイズや描画時間を考慮してください。