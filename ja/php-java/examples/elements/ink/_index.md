---
title: インク
type: docs
weight: 180
url: /ja/php-java/examples/elements/ink/
keywords:
  - インク
  - インクへのアクセス
  - インクの削除
  - コード例
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - PHP
  - Aspose.Slides
description: "Aspose.Slides を使用した PHP のスライドでデジタルインクを操作します。ペンストロークの追加、パスの編集、色と幅の設定、そして PowerPoint と OpenDocument 用に結果をエクスポートできます。"
---
既存のインク シェイプへのアクセスと削除の例を **Aspose.Slides for PHP via Java** を使用して提供します。

> ❗ **Note:** インク シェイプは専門デバイスからのユーザー入力を表します。Aspose.Slides はプログラムから新しいインク ストロークを作成できませんが、既存のインクを読み取って変更することは可能です。

## **インクへのアクセス**

スライド上の最初のインク シェイプを取得します。

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のインク シェイプにアクセスします。
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **インクの削除**

スライドからインク シェイプを削除します。

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがインク シェイプであると想定しています。
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```