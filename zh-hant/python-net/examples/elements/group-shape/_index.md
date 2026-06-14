---
title: 群組形狀
type: docs
weight: 170
url: /zh-hant/python-net/examples/elements/group-shape/
keywords:
- 群組
- 新增群組形狀
- 存取群組形狀
- 移除群組形狀
- 解除群組形狀
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理群組形狀：建立與解除群組、重新排序子形狀、設定變換與邊界，適用於 PowerPoint 與 OpenDocument。"
---
使用 **Aspose.Slides for Python via .NET** 建立形狀群組、存取、解除群組及移除的範例。

## **Add a Group Shape**
建立一個包含兩個基本形狀的群組。

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增群組形狀。
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Group Shape**
從投影片中取得第一個群組形狀。

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取投影片上的第一個群組形狀。
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Remove a Group Shape**
從投影片中刪除群組形狀。

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是群組形狀。
        group = slide.shapes[0]

        # 移除群組形狀。
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ungroup Shapes**
將形狀從群組容器中移出。

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是群組形狀。
        group = slide.shapes[0]

        # 將形狀移出群組。
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```