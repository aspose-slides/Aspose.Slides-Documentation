---
title: 使用 Python 的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/python-net/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習使用 Aspose.Slides for Python 在 PowerPoint 與 OpenDocument 文件中分組與解除分組形狀——快速、一步一步的教學，提供免費程式碼。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀新增至投影片、在其中放置形狀，並儲存更新後的簡報。本文亦示範如何存取群組內的形狀以及讀取它們的 `alternative_text` 值。此外，文章還簡要說明了相關的群組形狀功能，例如巢狀群組、Z 軸順序與鎖定選項。

## **新增群組形狀**

Aspose.Slides 支援在投影片上操作群組形狀。此功能讓您能透過將多個形狀視為單一物件來建立更豐富的簡報。您可以新增群組形狀、存取現有群組、向其中加入子形狀，並讀取或修改其任何屬性。要將群組形狀新增至投影片：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 將 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/) 新增至投影片。
4. 向新群組形狀加入形狀。
5. 將修改後的簡報儲存為 PPTX 檔案。

以下範例示範如何將群組形狀新增至投影片。

```py
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 在投影片上新增群組形狀。
    group_shape = slide.shapes.add_group_shape()

    # 在群組形狀內加入形狀。
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 Alt Text 屬性**

本節說明如何使用 Aspose.Slides 讀取投影片中群組形狀內形狀的 Alt Text。要存取這些形狀的 Alt Text：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別，以代表 PPTX 檔案。
2. 依索引取得投影片參考。
3. 取得投影片的 shapes 集合。
4. 存取 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/)。
5. 讀取 Alt Text 屬性。

以下範例會取得群組形狀內形狀的 Alt Text。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以開啟 PPTX 檔案。
with slides.Presentation("group_shape.pptx") as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # 存取群組形狀。
            for child_shape in shape.shapes:
                # 存取 Alt Text 屬性。
                print(child_shape.alternative_text)
```

## **常見問題**

**是否支援巢狀群組（群組內的群組）？**

是。[GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/) 具備 [parent_group](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/parent_group/) 屬性，直接表明支援階層結構（群組可以是另一個群組的子項）。

**如何控制群組相對於投影片上其他物件的 Z 軸順序？**

使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/) 的 [z_order_position](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/z_order_position/) 屬性來檢查其在顯示堆疊中的位置。

**我可以防止移動、編輯或解除群組嗎？**

是。群組的鎖定區段透過 [group_shape_lock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/group_shape_lock/) 暴露，讓您限制對該物件的操作。