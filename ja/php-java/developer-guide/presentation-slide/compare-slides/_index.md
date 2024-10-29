---
title: スライドの比較
type: docs
weight: 50
url: /ja/php-java/compare-slides/
---

## **2つのスライドを比較する**
Equalsメソッドが[IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)インターフェースと[BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide)クラスに追加されました。これは、構造と静的コンテンツが同一のスライド/レイアウトおよびスライド/マスタースライドに対してtrueを返します。

全てのシェイプ、スタイル、テキスト、アニメーション、その他の設定などが等しい場合、2つのスライドは等しいです。比較は、スライドの一意の識別子値（例：SlideId）や、日付プレースホルダーの現在の日付値などの動的コンテンツを考慮しません。

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d は SomePresentation2 MasterSlide#%d と等しい", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```