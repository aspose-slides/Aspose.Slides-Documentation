---
title: PHP を使用したプレゼンテーションでのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/php-java/connector/
keywords:
- コネクタ
- コネクタの種類
- コネクタ点
- コネクタ線
- コネクタ角度
- 図形を接続
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP アプリに PowerPoint スライド上で線を描画し、接続し、自動経路設定する機能を提供し、直線、肘、曲線コネクタをフルコントロールできるようにします。"
---

PowerPoint のコネクタは、2 つの図形を接続またはリンクする特殊な線で、スライド上で図形が移動または再配置されても図形に貼り付いたままです。 

コネクタは通常、*接続点*（緑色の点）に接続されます。接続点はすべての図形にデフォルトで存在し、カーソルが近づくと表示されます。

*調整点*（オレンジ色の点）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、肘（角度付き）、曲線のコネクタを使用できます。 

Aspose.Slides は以下のコネクタを提供します：

| コネクタ                      | 画像                                                        | 調整点の数 |
| ------------------------------ | ------------------------------------------------------------ | ---------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0          |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0          |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0          |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1          |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2          |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3          |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0          |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1          |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2          |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3          |

## **コネクタで図形を接続する**

1. [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `addAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) を追加します。
1. `Shapes` オブジェクトが提供する `addConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。
1. コネクタを使用して図形を接続します。 
1. `reroute` メソッドを呼び出して、最短の接続経路を適用します。
1. プレゼンテーションを保存します。 

この PHP コードは、2 つの図形（楕円と長方形）の間にコネクタ（曲がったコネクタ）を追加する方法を示します：
```php
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 特定のスライドのシェイプコレクションにアクセスします
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 楕円のオートシェイプを追加します
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 矩形のオートシェイプを追加します
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # スライドのシェイプコレクションにコネクタシェイプを追加します
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # コネクタを使用してシェイプを接続します
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # シェイプ間の自動最短パスを設定する reroute を呼び出します
    $connector->reroute();
    # プレゼンテーションを保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` メソッドはコネクタの経路を再設定し、図形間の最短経路を取るよう強制します。目的を達成するために、このメソッドは `setStartShapeConnectionSiteIndex` と `setEndShapeConnectionSiteIndex` のポイントを変更することがあります。 

{{% /alert %}} 

## **接続点を指定する**

コネクタが図形上の特定の点を使用して 2 つの図形を接続する場合は、以下のように好みの接続点を指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `addAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) を追加します。
1. `Shapes` オブジェクトが提供する `addConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。
1. コネクタを使用して図形を接続します。 
1. 図形上に好みの接続点を設定します。 
1. プレゼンテーションを保存します。

この PHP コードは、好みの接続点が指定された操作を示します：
```php
  # PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 特定のスライドのシェイプコレクションにアクセスします
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 楕円のオートシェイプを追加します
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 矩形のオートシェイプを追加します
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # スライドのシェイプコレクションにコネクタシェイプを追加します
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # コネクタを使用してシェイプを接続します
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 楕円シェイプの優先接続点インデックスを設定します
    $wantedIndex = 6;
    # 優先インデックスが最大サイトインデックス数未満か確認します
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 楕円オートシェイプに優先接続点を設定します
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # プレゼンテーションを保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **コネクタのポイントを調整する**

既存のコネクタは、調整点を使用して調整できます。調整点を持つコネクタだけがこの方法で変更可能です。**[コネクタの種類](/slides/ja/php-java/connector/#types-of-connectors)** の表をご参照ください。

### **シンプルなケース**

2 つの図形（A と B）間のコネクタが 3 番目の図形（C）を通過するケースを考えてみます：

![connector-obstruction](connector-obstruction.png)
```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


3 番目の図形を回避または迂回するために、コネクタの垂直線を左に移動させて調整できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```


### **複雑なケース** 

より複雑な調整を行うには、以下の点を考慮する必要があります：

- コネクタの調整可能なポイントは、その位置を計算・決定する数式と強く結びついています。そのため、ポイントの位置を変更するとコネクタの形状が変わる可能性があります。
- コネクタの調整点は配列内で厳密な順序で定義されます。調整点はコネクタの開始点から終了点へと番号付けされます。
- 調整点の値はコネクタ形状の幅/高さのパーセンテージを表します。
  - 形状はコネクタの開始点と終了点に 1000 を掛けた範囲で制限されます。
  - 最初のポイントは幅のパーセンテージ、2 番目のポイントは高さのパーセンテージ、3 番目のポイントは再び幅のパーセンテージをそれぞれ定義します。
- コネクタの調整点の座標を算出する計算では、コネクタの回転と反射を考慮する必要があります。**注**：**[コネクタの種類](/slides/ja/php-java/connector/#types-of-connectors)** に示されているすべてのコネクタの回転角度は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタで結ばれているケースを考えます：

![connector-shape-complex](connector-shape-complex.png)
```php
  # PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # コネクタで結合される形状を追加します
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # コネクタを追加します
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # コネクタの方向を指定します
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # コネクタの色を指定します
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # コネクタの線の太さを指定します
    $connector->getLineFormat()->setWidth(3);
    # コネクタで形状同士をリンクします
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # コネクタの調整ポイントを取得します
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**調整**

対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させて、コネクタの調整点の値を変更できます：
```php
  # 調整ポイントの値を変更します
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの個々の部品の座標と形状を決定できるモデルを定義するために、connector.getAdjustments().get_Item(0) のポイントに対応する横方向コンポーネントの形状を作成します：
```php
  # コネクタの垂直成分を描画する
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原則を用いたシンプルなコネクタ調整操作を示しました。通常の状況では、コネクタの回転と表示（connector.getRotation()、connector.getFrame().getFlipH()、connector.getFrame().getFlipV() で設定される）を考慮する必要があります。ここでその手順を示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し（接続用に）、既に作成したオブジェクトに接続する新しい（緑色の）コネクタを作成しましょう。
```php
  # 新しいバインディングオブジェクトを作成します
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # 新しいコネクタを作成します
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # 新しく作成したコネクタでオブジェクトを接続します
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # コネクタの調整ポイントを取得します
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # 調整ポイントの値を変更します
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整点 connector.getAdjustments().get_Item(0) を通過するコネクタの横方向コンポーネントに対応する形状を作成します。コネクタのデータから connector.getRotation()、connector.getFrame().getFlipH()、connector.getFrame().getFlipV() の値を使用し、指定点 x0 周りの回転の一般的な座標変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

このケースでは、オブジェクトの回転角度は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです：
```php
  # コネクタの座標を保存します
  $x = $connector->getX();
  $y = $connector->getY();
  # 必要に応じてコネクタの座標を補正します
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 調整ポイントの値を座標として使用します
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Sin(90)=1、Cos(90)=0 であるため座標を変換します
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 第2調整ポイントの値を使って水平成分の幅を決定します
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```


結果：

![connector-adjusted-4](connector-adjusted-4.png)

シンプルな調整と回転角度を伴う複雑な調整ポイントを含む計算を実演しました。習得した知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整点の値を設定するモデル（またはコード）を作成できます。

## **コネクタラインの角度を求める**

1. クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. コネクタラインのシェイプにアクセスします。
1. 線の幅、高さ、シェイプフレームの高さ、シェイプフレームの幅を使用して角度を計算します。

この PHP コードは、コネクタラインシェイプの角度を計算した操作を示します：
```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**コネクタが特定の図形に「貼り付け」可能かどうかを確認する方法は？**

図形が [connection sites](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合は貼り付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続する前にサイト数をチェックするのが賢明です。

**接続された図形の一つを削除した場合、コネクタはどうなりますか？**

端点は切り離され、コネクタはスライド上に自由端点を持つ普通の線として残ります。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/) を実行できます。

**スライドを別のプレゼンテーションにコピーした場合、コネクタの結合は保持されますか？**

通常は、対象の図形もコピーされていれば保持されます。接続された図形がない状態で別ファイルにスライドを挿入した場合、端点は自由になり、再度接続し直す必要があります。