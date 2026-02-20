---
title: スマートアート
type: docs
weight: 140
url: /ja/php-java/examples/elements/smartart/
keywords:
- スマートアート
- SmartArt を追加
- SmartArt にアクセス
- SmartArt を削除
- SmartArt のレイアウト
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で SmartArt を作成および編集します。ノードの追加、レイアウトやスタイルの変更、正確なシェイプへの変換、そして PPT、PPTX、ODP 用にエクスポートできます。"
---
このドキュメントは、**Aspose.Slides for PHP via Java** を使用して、SmartArt グラフィックの追加、アクセス、削除、レイアウト変更の方法を示します。

## **SmartArt を追加**

組み込みレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt にアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初の SmartArt にアクセスします。
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt を削除**

スライドから SmartArt シェイプを削除します。

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが SmartArt であると想定しています。
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt のレイアウトを変更**

既存の SmartArt グラフィックのレイアウトタイプを更新します。

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが SmartArt であると想定しています。
        $smartArt = $slide->getShapes()->get_Item(0);

        // SmartArt のレイアウトを変更します。
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```