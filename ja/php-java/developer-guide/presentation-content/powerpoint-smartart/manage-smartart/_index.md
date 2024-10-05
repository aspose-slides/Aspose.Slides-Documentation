---
title: スマートアートの管理
type: docs
weight: 10
url: /php-java/manage-smartart/
---

## **スマートアートからテキストを取得**
現在、TextFrameメソッドが[ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape)インターフェースおよび[SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)からすべてのテキストを取得できます。以下のサンプルコードは、スマートアートノードからテキストを取得するのに役立ちます。

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

## **スマートアートのレイアウトタイプを変更する**
[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockListを追加します。
- [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-)をBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcessを追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # LayoutTypeをBasicProcessに変更
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # プレゼンテーションを保存
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スマートアートの隠しプロパティを確認する**
注意: メソッド[ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)は、このノードがデータモデル内の隠しノードである場合にtrueを返します。[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)の任意のノードの隠しプロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycleを追加します。
- スマートアートにノードを追加します。
- [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)プロパティを確認します。
- プレゼンテーションをPPTXファイルとして保存します。

以下の例では、2つの図形の間にコネクタを追加しました。

```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcessを追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # スマートアートにノードを追加
    $node = $smart->getAllNodes()->addNode();
    # isHiddenプロパティを確認
    $hidden = $node->isHidden();// trueを返します

    if ($hidden) {
      # 何らかのアクションや通知を行う
    }
    # プレゼンテーションを保存
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **組織図タイプの取得または設定**
メソッド[ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)は、現在のノードに関連付けられた組織図タイプを取得または設定することを可能にします。組織図タイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- スライドに[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
- 組織図タイプを[取得](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--)または[設定](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcessを追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # 組織図タイプを取得または設定
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # プレゼンテーションを保存
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **画像組織図の作成**
Aspose.Slides for PHP via Javaは、画像組織図を簡単に作成するためのシンプルなAPIを提供します。スライド上にチャートを作成するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータとともに必要なタイプ（ChartType::PictureOrganizationChart）でチャートを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

以下のコードは、チャートを作成するために使用されます。

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

## **スマートアートの状態の取得または設定**
[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドに[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
1. スマートアートダイアグラムの状態を[取得](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--)または[設定](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-)します。
1. プレゼンテーションをPPTXファイルとして保存します。

以下のコードは、チャートを作成するために使用されます。

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # SmartArt BasicProcessを追加
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # スマートアートダイアグラムの状態を取得または設定
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