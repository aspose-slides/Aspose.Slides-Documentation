---
title: コネクタ
type: docs
weight: 190
url: /ja/php-java/examples/elements/connector/
keywords:
- コネクタ
- コネクタの追加
- コネクタへのアクセス
- コネクタの削除
- シェイプの再接続
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でコネクタを描画および制御します。コネクタの追加、経路設定、再経路設定、接続点、矢印、スタイルを設定して、PPT、PPTX、ODP のシェイプをリンクします。"
---
**Aspose.Slides for PHP via Java** を使用して、シェイプをコネクタで接続し、ターゲットを変更する方法を示します。

## **コネクタの追加**

スライド上の2点間にコネクタ シェイプを挿入します。

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **コネクタへのアクセス**

スライドに追加された最初のコネクタ シェイプを取得します。

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のコネクタにアクセスします。
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **コネクタの削除**

スライドからコネクタを削除します。

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがコネクタであると想定します。
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **シェイプの再接続**

開始および終了のターゲットを割り当てて、コネクタを2つのシェイプに接続します。

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```