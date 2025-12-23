---
title: PHPでプレゼンテーションのインクオブジェクトを管理
linktitle: インクの管理
type: docs
weight: 95
url: /ja/php-java/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPointのインクオブジェクトを管理 — Aspose.Slides for PHP via Javaでデジタルインクを作成、編集、スタイル設定します。トレース、ブラシの色とサイズのコードサンプルを取得できます。"
---

PowerPoint は、標準的でない図形を描くためのインク機能を提供しており、これを使用して他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slides は、インクオブジェクトの作成と管理に必要なすべての Ink タイプ（例: [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) クラス）を提供します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプオブジェクトで表されます。シェイプオブジェクトは、最も単純な形ではオブジェクト自体（フレーム）の領域とそのプロパティを定義するコンテナです。これにはコンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細は [Shape Layout Format](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインクオブジェクトを扱う場合、サイズ以外のフレーム（コンテナ）プロパティはすべて無視されます。コンテナ領域のサイズは標準の `width` と `height` 値で決定されます:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape トレース**

トレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素または標準です。トレースは接続された点のシーケンスを記述した録画です。

最も単純なエンコーディング形態は、各サンプル点の X と Y 座標を指定します。すべての接続された点が描画されると、次のような画像が生成されます:

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

トレース要素の点を結ぶ線を描くためにブラシを使用できます。ブラシには `Brush.Color` と `Brush.Size` プロパティに対応する独自の色とサイズがあります。

### **インク ブラシの色を設定**

この PHP コードはブラシの色を設定する方法を示しています:
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


### **インク ブラシのサイズを設定**

この PHP コードはブラシのサイズを設定する方法を示しています:
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


一般に、ブラシの幅と高さは一致せず、PowerPoint はブラシサイズを表示しません（データ セクションはグレー表示）。しかし、幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します:

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう:

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さをゼロと見なします（最後の画像参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレースオブジェクト）がコンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストを扱う場合も同じ動作を示します:

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/php-java/powerpoint-shapes/) セクションを参照してください。
* 有効な値に関する詳細情報は、[Shape Effective Properties](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value) を参照してください。