---
title: 在 Python 透過 Java 中的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/python-java/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中群組與解除群組形狀——一步一步的教學，提供免費的 Python 程式碼。"
---
## **概覽**

本文章說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀新增至投影片、在其中放置形狀，並儲存更新後的簡報。也示範了如何存取群組內的形狀，並使用[getAlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 讀取其替代文字。此外，本文還簡要說明了相關的群組形狀功能，如巢狀群組、Z 軸順序與鎖定選項。

## **新增群組形狀**

Aspose.Slides 支援在投影片上操作群組形狀。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for Python via Java 支援新增與存取群組形狀。您可以在群組形狀內加入其他形狀或存取其屬性。若要使用 Aspose.Slides for Python via Java 將群組形狀新增至投影片：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 在投影片上新增群組形狀。  
1. 將形狀加入群組形狀。  
1. 將修改後的簡報另存為 PPTX 檔案。

以下範例將群組形狀新增至投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# 實例化 Presentation 類別。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 存取投影片的形狀集合。
    slide_shapes = slide.getShapes()

    # 新增群組形狀至投影片。
    group_shape = slide_shapes.addGroupShape()

    # 在群組形狀內新增形狀。
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # 設定群組形狀的框架。
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # 將 PPTX 檔寫入磁碟。
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取替代文字**

本節說明如何存取投影片上群組內形狀的替代文字。使用 Aspose.Slides for Python via Java 取得此文字的方法如下：

1. 建構代表 PPTX 檔案的[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。  
1. 依索引取得投影片的參考。  
1. 存取投影片的 ShapeCollection。  
1. 取得群組形狀。  
1. 使用[getAlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 讀取其形狀的替代文字。

以下範例存取群組內形狀的替代文字：

```python
import jpact
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# 實例化代表 PPTX 檔案的 Presentation 類別。
presentation = Presentation("AltText.pptx")
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # 存取投影片形狀集合中的形狀。
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # 存取群組內的形狀。
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # 讀取替代文字。
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **常見問題**

**是否支援巢狀群組（群組內含群組）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/) 提供[getParentGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getParentGroup) 方法，表示支援階層結構：群組可以是另一個群組的子項。

**如何控制群組相對於投影片上其他物件的 Z 軸順序？**

使用[GroupShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/) 物件的[getZOrderPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getZOrderPosition) 方法，以檢查其在顯示堆疊中的位置。

**我可以防止移動、編輯或解除群組嗎？**

可以。群組的鎖定設定可透過[getGroupShapeLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/#getGroupShapeLock) 取得，讓您限制對該物件的操作。