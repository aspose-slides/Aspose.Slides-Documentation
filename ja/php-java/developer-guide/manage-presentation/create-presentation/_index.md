---
title: PHPを使用してPowerPointプレゼンテーションを作成する
linktitle: プレゼンテーションを作成する
type: docs
weight: 10
url: /ja/php-java/create-presentation/
keywords: ppt javaを作成, pptプレゼンテーションを作成, pptx javaを作成
description: PHPを使用してPPTやPPTXなどのPowerPointプレゼンテーションをゼロから作成する方法を学びましょう。
---

## **PowerPointプレゼンテーションを作成する**
プレゼンテーションの選択したスライドに単純なラインを追加するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapesオブジェクトによって公開されるaddAutoShapeメソッドを使用して、ラインタイプのAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しました。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # ラインタイプのオートシェイプを追加します
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```