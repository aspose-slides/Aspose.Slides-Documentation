---
title: コネクタ
type: docs
weight: 10
url: /php-java/connector/
keywords: "シェイプの接続, コネクタ, PowerPointシェイプ, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointシェイプを接続"
---

PowerPointのコネクタは、2つのシェイプをつなぐ特別な線であり、特定のスライド上でシェイプが移動または再配置されても、そのシェイプに付属し続けます。

コネクタは通常、デフォルトですべてのシェイプに存在する*接続ドット*（緑のドット）に接続されています。接続ドットは、カーソルが近づくと表示されます。

*調整ポイント*（オレンジのドット）は、特定のコネクタにのみ存在し、コネクタの位置や形を変更するために使用されます。

## **コネクタの種類**

PowerPointでは、ストレート、L字型（角度付き）、および曲線のコネクタを使用できます。

Aspose.Slidesは、以下のコネクタを提供します：

| コネクタ                        | 画像                                                          | 調整ポイントの数 |
| ------------------------------ | ------------------------------------------------------------ | ----------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                 |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                 |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                 |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                 |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                 |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                 |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                 |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                 |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                 |

## **コネクタを使用してシェイプを接続する**

1. [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes`オブジェクトが公開している`addAutoShape`メソッドを使用してスライドに2つの[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)を追加します。
1. コネクタタイプを定義して、`Shapes`オブジェクトが公開している`addConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用してシェイプを接続します。
1. `reroute`メソッドを呼び出して、最短接続パスを適用します。
1. プレゼンテーションを保存します。

このPHPコードは、2つのシェイプ（楕円と長方形）の間にコネクタ（L字型コネクタ）を追加する方法を示しています：

```php
// PPTXファイルを表すプレゼンテーションクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 特定のスライドのシェイプコレクションにアクセス
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 楕円のオートシェイプを追加
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 長方形のオートシェイプを追加
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # スライドのシェイプコレクションにコネクタシェイプを追加
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # コネクタを使用してシェイプを接続
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # シェイプ間の自動最短経路を設定するrerouteを呼び出す
    $connector->reroute();
    # プレゼンテーションを保存
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="注"  color="warning"   %}} 

`Connector.reroute`メソッドはコネクタを再ルーティングし、シェイプ間の最短経路を取るよう強制します。目的を達成するために、このメソッドは`setStartShapeConnectionSiteIndex`および`setEndShapeConnectionSiteIndex`のポイントを変更する場合があります。

{{% /alert %}} 

## **接続ドットの指定**

コネクタがシェイプの特定のドットを使用して2つのシェイプをリンクする場合は、次のようにして好みの接続ドットを指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes`オブジェクトが公開している`addAutoShape`メソッドを使用してスライドに2つの[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)を追加します。
1. コネクタタイプを定義して、`Shapes`オブジェクトが公開している`addConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用してシェイプを接続します。
1. シェイプ上の好みの接続ドットを設定します。
1. プレゼンテーションを保存します。

このPHPコードは、好みの接続ドットを指定する操作を示しています：

```php
  # PPTXファイルを表すプレゼンテーションクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 特定のスライドのシェイプコレクションにアクセス
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 楕円のオートシェイプを追加
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 長方形のオートシェイプを追加
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # スライドのシェイプコレクションにコネクタシェイプを追加
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # コネクタを使用してシェイプを接続
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 楕円シェイプの好みの接続ドットインデックスを設定
    $wantedIndex = 6;
    # 好みのインデックスが最大サイトインデックスカウントより小さいか確認
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 楕円のオートシェイプに好みの接続ドットを設定
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # プレゼンテーションを保存
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **コネクタポイントの調整**

既存のコネクタは、その調整ポイントを介して調整できます。調整ポイントを持つコネクタのみがこの方法で変更できます。**[コネクタの種類](/slides/php-java/connector/#types-of-connectors)**の下のテーブルを参照してください。

#### **単純なケース**

2つのシェイプ（AとB）の間にコネクタがあり、そのコネクタが第三のシェイプ（C）を通過する場合を考えます：

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

第三のシェイプを避けてバイパスするために、コネクタを調整してその垂直線を左に移動することができます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **複雑なケース** 

より複雑な調整を行うには、次のことを考慮する必要があります：

* コネクタの調整ポイントは、その位置を計算し決定する数式と強く関連しています。そのため、ポイントの位置を変更するとコネクタの形状が変わる可能性があります。
* コネクタの調整ポイントは配列の中で厳密な順序で定義されています。調整ポイントはコネクタの開始点から終了点まで番号が付けられています。
* 調整ポイントの値は、コネクタ形状の幅/高さのパーセンテージを反映します。
  * 形状は、コネクタの開始点と終了点の1000倍で制約されています。
  * 最初のポイント、2番目のポイント、および3番目のポイントはそれぞれ幅からのパーセンテージ、高さからのパーセンテージ、幅からのパーセンテージを定義します。
* コネクタの調整ポイントの座標を決定するための計算には、コネクタの回転とその反射を考慮する必要があります。**注**：**[コネクタの種類](/slides/php-java/connector/#types-of-connectors)**の下に表示されているすべてのコネクタの回転角度は0です。

#### **ケース 1**

2つのテキストフレームオブジェクトがコネクタを介してリンクされている場合を考えます：

![connector-shape-complex](connector-shape-complex.png)

```php
  # PPTXファイルを表すプレゼンテーションクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # プレゼンテーション内の最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # コネクタを介して結合されるシェイプを追加
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # コネクタを追加
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # コネクタの方向を指定
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # コネクタの色を指定
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # コネクタの線の太さを指定
    $connector->getLineFormat()->setWidth(3);
    # コネクタでシェイプを結びつける
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # コネクタの調整ポイントを取得
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**調整**

コネクタの調整ポイントの値を、対応する幅と高さのパーセンテージをそれぞれ20%と200%増加させることによって変更できます：

```php
  # 調整ポイントの値を変更
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタのすべての部分の座標と形状を決定するモデルを定義するために、コネクタのhorizontalコンポーネントに対応する形状をコネクタ.getAdjustments().get_Item(0)ポイントで作成しましょう：

```php
  # コネクタの垂直コンポーネントを描画
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1**では、基本原則を使用してシンプルなコネクタ調整操作を示しました。通常の状況では、コネクタの回転と表示（これらはconnector.getRotation()、connector.getFrame().getFlipH()、およびconnector.getFrame().getFlipV()によって設定されます）を考慮する必要があります。プロセスを示しましょう。

最初に、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、それを既に作成したオブジェクトに接続する新しい（緑の）コネクタを作成します。

```php
  # 新しいバインディングオブジェクトを作成
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # 新しいコネクタを作成
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # 新しく作成されたコネクタを使用してオブジェクトを接続
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # コネクタの調整ポイントを取得
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # 調整ポイントの値を変更
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイントconnector.getAdjustments().get_Item(0)を通過するコネクタの水平コンポーネントに対応する形状を作成します。コネクタデータからconnector.getRotation()、connector.getFrame().getFlipH()、およびconnector.getFrame().getFlipV()の値を使用し、与えられた点x0を中心とした回転の一般的な座標変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この場合、オブジェクトの回転角度は90度であり、コネクタは垂直に表示されているため、次のようなコードになります：

```php
  # コネクタの座標を保存
  $x = $connector->getX();
  $y = $connector->getY();
  # コネクタの座標が表示される場合は補正
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 調整ポイントの値を座標として取得
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Sin(90) = 1およびCos(90) = 0のために座標を変換
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 二番目の調整ポイントの値を使用して水平コンポーネントの幅を決定
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

簡単な調整と複雑な調整ポイント（回転角度を持つ調整ポイント）に関する計算を示しました。習得した知識を使用して、`GraphicsPath`オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイントの値を設定したりするモデル（またはコード）を開発できます。

## **コネクタ線の角度を求める**

1. クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. コネクタ線形状にアクセスします。
1. 線の幅、高さ、シェイプフレームの高さ、およびシェイプフレームの幅を使用して角度を計算します。

このPHPコードは、コネクタ線形状の角度を計算した操作を示しています：

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