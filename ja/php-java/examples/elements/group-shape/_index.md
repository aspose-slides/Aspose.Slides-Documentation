---
title: グループシェイプ
type: docs
weight: 170
url: /ja/php-java/examples/elements/group-shape/
keywords:
- グループ
- グループシェイプの追加
- グループシェイプへのアクセス
- グループシェイプの削除
- シェイプのグループ解除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でグループシェイプを操作します：作成とグループ解除、子シェイプの並べ替え、PowerPoint と OpenDocument の変換と境界を設定します。"
---
**Aspose.Slides for PHP via Java** を使用して、シェイプのグループ作成、アクセス、グループ解除、および削除の例を示します。

## **グループ シェイプの追加**

2つの基本シェイプを含むグループを作成します。

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **グループ シェイプへのアクセス**

スライドから最初のグループ シェイプを取得します。

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のグループシェイプにアクセスします。
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **グループ シェイプの削除**

スライドからグループ シェイプを削除します。

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // スライド上の最初のシェイプがグループシェイプであると想定しています。
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **グループの解除**

シェイプをグループ コンテナから外します。

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがグループシェイプであると想定しています。
        $group = $slide->getShapes()->get_Item(0);

        // グループから各シェイプをクローンし、スライドに追加します。
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```