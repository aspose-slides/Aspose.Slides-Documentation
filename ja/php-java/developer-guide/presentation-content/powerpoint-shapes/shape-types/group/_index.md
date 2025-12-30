---
title: PHP のグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/php-java/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループ 追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint デッキでシェイプをグループ化およびグループ解除する方法を学びます — 迅速でステップバイステップのガイドと無料コード。"
---

## **グループ シェイプを追加**
Aspose.Slides はスライド上のグループ シェイプの操作をサポートします。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for PHP via Java はグループ シェイプの追加や取得をサポートします。追加したグループ シェイプにシェイプを配置したり、グループ シェイプの任意のプロパティにアクセスすることが可能です。Aspose.Slides for PHP via Java を使用してスライドにグループ シェイプを追加する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ シェイプを追加します。
1. 追加したグループ シェイプにシェイプを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループ シェイプを追加します。
```php
  # Presentation クラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # スライドのシェイプコレクションにアクセス
    $slideShapes = $sld->getShapes();
    # スライドにグループ シェイプを追加
    $groupShape = $slideShapes->addGroupShape();
    # 追加したグループ シェイプ内にシェイプを追加
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # グループ シェイプのフレームを追加
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTX ファイルをディスクに保存
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **AltText プロパティにアクセス**
このトピックでは、グループ シェイプを追加し、スライド上のグループ シェイプの AltText プロパティにアクセスするための簡単な手順とコード例を示します。Aspose.Slides for PHP via Java を使用してスライド内のグループ シェイプの AltText にアクセスする手順は以下の通りです。

1. PPTX ファイルを表す [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプ コレクションにアクセスします。
1. グループ シェイプにアクセスします。
1. [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) プロパティにアクセスします。

以下の例はグループ シェイプの代替テキストにアクセスします。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンス化
  $pres = new Presentation("AltText.pptx");
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # スライドのシェイプコレクションにアクセス
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # グループ シェイプにアクセス
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # AltText プロパティにアクセス
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**ネストされたグループ化（グループ内に別のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) には [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) メソッドがあり、階層構造のサポート（あるグループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) の [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) メソッドを使用して、表示スタック内での位置を確認できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロック セクションは [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/) を通じて公開されており、オブジェクトに対する操作を制限できます。