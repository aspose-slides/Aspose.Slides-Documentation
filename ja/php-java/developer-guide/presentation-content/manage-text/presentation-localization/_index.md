---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /php-java/presentation-localization/
---

## **プレゼンテーションと図形のテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに[Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle)タイプの[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)を追加します。
- TextFrameにテキストを追加します。
- テキストに[Setting Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-)を設定します。
- プレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は、以下の例で示されています。

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("スペルチェックの言語を適用するテキスト");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```