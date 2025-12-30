---
title: PHP を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint SmartArt の構築と編集を、スライドのデザインと自動化を高速化する明確なコードサンプルで学びます。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、TextFrame メソッドがそれぞれ [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) インターフェイスと [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) からすべてのテキストを取得できます。以下のサンプルコードは SmartArt ノードからテキストを取得する方法を示します。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt オブジェクトのレイアウトタイプを変更する**
[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) のレイアウトタイプを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList を追加します。
- [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを書き出して PPTX ファイルにします。以下の例では、2 つの図形の間にコネクタを追加しています。
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # LayoutType を BasicProcess に変更
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # プレゼンテーションを保存
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt オブジェクトの非表示プロパティを確認する**
注意: メソッド [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) は、データモデルでこのノードが非表示ノードである場合に true を返します。[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) の任意のノードの非表示プロパティを確認するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle を追加します。
- SmartArt にノードを追加します。
- [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) プロパティを確認します。
- プレゼンテーションを書き出して PPTX ファイルにします。以下の例では、2 つの図形の間にコネクタを追加しています。
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # SmartArt にノードを追加
    $node = $smart->getAllNodes()->addNode();
    # isHidden プロパティを確認
    $hidden = $node->isHidden();// true を返します

    if ($hidden) {
      # 何らかの処理または通知を行う
    }
    # プレゼンテーションを保存
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **組織図の種類を取得または設定する**
メソッド [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、現在のノードに関連付けられた組織図の種類を取得または設定します。組織図の種類を取得または設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドに [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- 組織図の種類を取得または [set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)します。
- プレゼンテーションを書き出して PPTX ファイルにします。以下の例では、2 つの図形の間にコネクタを追加しています。
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # 組織図の種類を取得または設定
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # プレゼンテーションを保存
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **画像組織図を作成する**
Aspose.Slides for PHP via Java は、画像組織図 (PictureOrganization) を簡単に作成できるシンプルな API を提供します。スライドにチャートを作成する手順：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと希望のタイプ (ChartType::PictureOrganizationChart) を指定してチャートを追加します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャート作成に使用されます。
```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt の状態を取得または設定する**
SmartArt のレイアウトタイプを変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドに [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
1. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) を使用して SmartArt ダイアグラムの状態を取得または設定します。
1. プレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャート作成に使用されます。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # SmartArt ダイアグラムの状態を取得または設定
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # プレゼンテーションを保存
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**SmartArt は RTL 言語向けにミラーリング/反転をサポートしていますか？**

はい。[setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) メソッドは、選択した SmartArt タイプが反転をサポートしている場合に、図の方向 (LTR/RTL) を切り替えます。

**書式設定を保持したまま、同じスライドまたは別のプレゼンテーションに SmartArt をコピーする方法は？**

[SmartArt shape をクローン](/slides/ja/php-java/shape-manipulations/) するには、シェイプコレクションの ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) を使用するか、またはそのシェイプを含むスライド全体を [クローン](/slides/ja/php-java/clone-slides/) します。どちらの方法もサイズ、位置、スタイリングを保持します。

**プレビューや Web エクスポートのために SmartArt をラスタ画像にレンダリングする方法は？**

[スライドをレンダリング](/slides/ja/php-java/convert-powerpoint-to-png/) （またはプレゼンテーション全体）して PNG/JPEG に変換する API を使用します。SmartArt はスライドの一部として描画されます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt をプログラムで選択する方法は？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)（Alt Text）または [名前](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) を使用し、[スライドシェイプ](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 内でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) であることを確認します。ドキュメントにはシェイプの検索と操作に関する典型的な手法が記載されています。