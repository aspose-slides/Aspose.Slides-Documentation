---
title: グループ シェイプ
type: docs
weight: 170
url: /ja/nodejs-java/examples/elements/group-shape/
keywords:
- コード例
- グループ シェイプ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でグループ化されたシェイプを管理します。PPT、PPTX、ODP プレゼンテーションの例を使用して、シェイプの作成、入れ子、整列、順序変更、スタイル設定ができます。"
---
**Aspose.Slides for Node.js via Java** を使用した、シェイプ グループの作成、アクセス、グループ解除、削除の例。

## **グループ シェイプの追加**

2つの基本シェイプを含むグループを作成します。

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **グループ シェイプへのアクセス**

スライドから最初のグループ シェイプを取得します。

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **グループ シェイプの削除**

スライドからグループ シェイプを削除します。

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがグループ シェイプであると仮定しています。
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **シェイプのグループ解除**

シェイプをグループ コンテナから外へ移動します。

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがグループ シェイプであると仮定しています。
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // グループから各シェイプをスライドにクローンします。
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```