---
title: インクの管理
type: docs
weight: 95
url: /ja/php-java/manage-ink/
keywords: "PowerPoint のインク, インクツール, Java インク, PowerPoint で描画, PowerPoint プレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "インクツールを使用して PowerPoint Java でオブジェクトを描画する"
---

PowerPointは、非標準の図形を描くためのインク機能を提供しており、これを使用して他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slidesは、インクオブジェクトを作成および管理するために必要なすべてのインクタイプ（例: [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) クラス）を提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPointのスライド上のオブジェクトは通常、シェイプオブジェクトとして表されます。シェイプオブジェクトは、その最も簡単な形において、オブジェクト自体の領域（そのフレーム）とそのプロパティを定義するコンテナです。後者には、コンテナの面積サイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[シェイプレイアウトフォーマット](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

ただし、PowerPointがインクオブジェクトを扱う場合、サイズを除くオブジェクトフレーム（コンテナ）のすべてのプロパティを無視します。コンテナエリアのサイズは、標準の `width` および `height` 値によって決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクを記入する際のペンの軌跡を記録するために使用される基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述した記録です。

最も単純な形式のエンコーディングは、各サンプルポイントのX座標とY座標を指定します。すべての接続されたポイントが描画されると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ

ブラシを使用してトレース要素のポイントを結ぶ線を描画できます。ブラシには独自の色とサイズがあり、それは `Brush.Color` および `Brush.Size` プロパティに対応しています。

### **インクブラシの色を設定する**

このPHPコードは、ブラシの色を設定する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **インクブラシのサイズを設定する**

このPHPコードは、ブラシのサイズを設定する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

一般に、ブラシの幅と高さは一致しないため、PowerPointはブラシサイズを表示しません（データセクションはグレーアウトされます）。しかし、ブラシの幅と高さが一致する場合、PowerPointは次のようにそのサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確さのために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）は、ブラシのサイズを考慮しません - 常に線の太さがゼロであると仮定します（最後の画像参照）。

したがって、全体のインクオブジェクトの可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、ターゲットオブジェクト（手書きのテキストトレースオブジェクト）はコンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変更されると、ブラシサイズは一定であり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPointは、テキストを扱うときにも同じ動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらなる学習**

* シェイプに関する一般的な情報については、[PowerPoint シェイプ](https://docs.aspose.com/slides/php-java/powerpoint-shapes/)セクションを参照してください。
* 効果的な値に関する詳細については、[シェイプの効果的なプロパティ](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value)を参照してください。