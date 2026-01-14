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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint SmartArt の作成と編集を、スライド デザインと自動化を迅速化する明確なコードサンプルで学びます。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、TextFrame メソッドが[SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)からすべてのテキストを取得できます。以下のサンプルコードはSmartArtノードからテキストを取得するのに役立ちます。
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


## **SmartArt オブジェクトのレイアウト タイプを変更する**
[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)のレイアウト タイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)のBasicBlockListを追加します。
- [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/)をBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして書き出します。

以下の例では、2つのシェイプ間にコネクタを追加しています。
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
注意: メソッド[SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/)は、このノードがデータモデル内で非表示ノードの場合に`true`を返します。[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)の任意のノードの非表示プロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)のRadialCycleを追加します。
- SmartArtにノードを追加します。
- [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/)プロパティを確認します。
- プレゼンテーションをPPTXファイルとして書き出します。

以下の例では、2つのシェイプ間にコネクタを追加しています。
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
      # 何らかのアクションまたは通知を実行
    }
    # プレゼンテーションを保存
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **組織図タイプを取得または設定する**
メソッド[SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/)と[SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/)は、現在のノードに関連付けられた組織図タイプの取得または設定を可能にします。組織図タイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- スライドに[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)を追加します。
- 組織図タイプを取得または[set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/)します。
- プレゼンテーションをPPTXファイルとして書き出します。

以下の例では、2つのシェイプ間にコネクタを追加しています。
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess を追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # 組織図のタイプを取得または設定
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
Aspose.Slides for PHP via Java は、PictureOrganizationチャートを簡単に作成できるシンプルなAPIを提供します。スライド上にチャートを作成するには:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと目的のタイプ(ChartType::PictureOrganizationChart)のチャートを追加します。
1. 変更されたプレゼンテーションをPPTXファイルに書き出します。

以下のコードはチャートを作成するために使用されます。
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
[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)のレイアウト タイプを変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドに[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)を追加します。
1. SmartArtダイアグラムの状態を[Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/)または[Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/)します。
1. プレゼンテーションをPPTXファイルとして書き出します。

以下のコードはチャートを作成するために使用されます。
```php
  # PPTX ファイルを表す Presentation クラスをインスタンス化
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

**SmartArt は RTL 言語向けのミラーリング/反転をサポートしていますか？**

はい。選択した SmartArt タイプが反転をサポートしている場合、[setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/)メソッドはダイアグラムの方向(LTR/RTL)を切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーし、書式を保持するにはどうすればよいですか？**

シェイプ コレクションを介して[clone the SmartArt shape](/slides/ja/php-java/shape-manipulations/)（[ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)）またはこのシェイプを含む[clone the entire slide](/slides/ja/php-java/clone-slides/) を使用できます。どちらの方法もサイズ、位置、スタイルを保持します。

**SmartArt をプレビューやウェブエクスポート用のラスタ画像にレンダリングするにはどうすればよいですか？**

API を使用してスライド（またはプレゼンテーション全体）を PNG/JPEG に変換することで、[Render the slide](/slides/ja/php-java/convert-powerpoint-to-png/)できます。SmartArt はスライドの一部として描画されます。

**複数ある場合、スライド上の特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[alternative text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)（Alt Text）や[name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) を使用し、[slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 内でその属性でシェイプを検索し、タイプが[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)であることを確認することです。ドキュメントではシェイプの検索と操作の典型的な手法が説明されています。