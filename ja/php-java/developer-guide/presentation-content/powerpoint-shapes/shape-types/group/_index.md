---
title: グループ
type: docs
weight: 40
url: /ja/php-java/group/
---

## **グループシェイプを追加する**
Aspose.Slidesは、スライド上のグループシェイプとの作業をサポートしています。この機能は、開発者がよりリッチなプレゼンテーションをサポートするのに役立ちます。Aspose.Slides for PHP via Javaは、グループシェイプを追加またはアクセスすることをサポートしています。追加されたグループシェイプにシェイプを追加して、内容を充填したり、グループシェイプの任意のプロパティにアクセスしたりすることができます。Aspose.Slides for PHP via Javaを使用してスライドにグループシェイプを追加するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループシェイプを追加します。
1. 追加したグループシェイプにシェイプを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、スライドにグループシェイプを追加します。

```php
  # Presentationクラスのインスタンスを生成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # スライドのシェイプコレクションにアクセス
    $slideShapes = $sld->getShapes();
    # スライドにグループシェイプを追加
    $groupShape = $slideShapes->addGroupShape();
    # 追加したグループシェイプ内にシェイプを追加
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # グループシェイプのフレームを追加
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTXファイルをディスクに書き込む
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **AltTextプロパティにアクセスする**
このトピックでは、グループシェイプを追加し、スライド上のグループシェイプのAltTextプロパティにアクセスするための簡単な手順を、コード例とともに示します。Aspose.Slides for PHP via Javaを使用してスライド内のグループシェイプのAltTextにアクセスするには：

1. PPTXファイルを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを生成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプコレクションにアクセスします。
1. グループシェイプにアクセスします。
1. [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--)プロパティにアクセスします。

以下の例では、グループシェイプの代替テキストにアクセスします。

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("AltText.pptx");
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # スライドのシェイプコレクションにアクセス
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # グループシェイプにアクセス
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # AltTextプロパティにアクセス
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