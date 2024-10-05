---
title: フラッシュ
type: docs
weight: 10
url: /php-java/flash/
description: PHPを使用してPowerPointプレゼンテーションからFlashオブジェクトを抽出する
---

## **プレゼンテーションからFlashオブジェクトを抽出する**

Aspose.Slides for PHP via Javaは、プレゼンテーションからFlashオブジェクトを抽出する機能を提供しています。名前でFlashコントロールにアクセスし、プレゼンテーションから抽出してSWFオブジェクトデータを保存することができます。

```php
  # PPTXを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```