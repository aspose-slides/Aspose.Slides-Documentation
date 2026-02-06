---
title: グループシェイプ
type: docs
weight: 170
url: /ja/python-net/examples/elements/group-shape/
keywords:
- グループ
- グループ シェイプを追加
- グループ シェイプにアクセス
- グループ シェイプを削除
- シェイプのグループ解除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python でのグループシェイプの操作：作成とグループ解除、子シェイプの並び替え、変換と境界の設定を PowerPoint および OpenDocument で行います。"
---
**Aspose.Slides for Python via .NET** を使用した、シェイプ グループの作成、アクセス、グループ解除、および削除の例です。

## **グループ シェイプを追加**

2つの基本シェイプを含むグループを作成します。

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # グループ シェイプを追加します。
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **グループ シェイプにアクセス**

スライドから最初のグループ シェイプを取得します。

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初のグループ シェイプにアクセスします。
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **グループ シェイプを削除**

スライドからグループ シェイプを削除します。

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがグループ シェイプであると想定します。
        group = slide.shapes[0]

        # グループ シェイプを削除します。
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプのグループ解除**

シェイプをグループ コンテナから外へ移動します。

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがグループ シェイプであると想定します。
        group = slide.shapes[0]

        # シェイプをグループから外へ移動します。
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```