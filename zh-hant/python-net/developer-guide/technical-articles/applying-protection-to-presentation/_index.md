---
title: 使用形狀鎖限制 Python 中的簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 70
url: /zh-hant/python-net/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PPTX 簡報中鎖定與解除鎖定形狀，從而限制選取、移動、調整大小與群組化。"
---
## **背景**

Aspose.Slides for Python via .NET 的常見用法是建立、更新並儲存 PowerPoint (PPTX) 簡報，作為自動化工作流程的一部份。當使用者收到這些簡報時，限制對形狀的變更可以協助保留預期的版面配置與內容。

本篇說明形狀在投影片中的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖。這些鎖定可讓您限制對個別形狀的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於建構簡報的元素組成。在 Aspose.Slides for Python via .NET 中，投影片上的每個元素皆由繼承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 類別的物件表示。

不同的形狀類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 類別是形狀鎖的基底類別。Aspose.Slides for Python via .NET 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 鎖定連接線形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的形狀設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器會使用形狀鎖來限制個別的編輯操作。檔案加密與文件層級的寫入保護是獨立的 [簡報保護設定](/slides/zh-hant/python-net/password-protected-presentation/)。

### **套用 PPTX 形狀保護**

Aspose.Slides for Python via .NET 提供 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 類別，以在投影片上操作形狀。

範例將 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) 和 [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) 設為 `True`，針對自動圖形，同時對群組形狀、連接線與圖片框設定相同的鎖定。連接線使用 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) 以限制移動；群組亦使用 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 以限制群組化。

範例載入現有的 PPTX 簡報，檢查每張投影片之 shape collection 中的形狀，並儲存套用這些限制的副本。四種處理類型之外的形狀保持不變。此迴圈不會遍歷群組內的子形狀。

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **移除保護**

若要移除形狀鎖，請將其值設為 `False`。以下範例載入含有形狀鎖的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。它同時清除 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 並儲存簡報的副本。其他鎖定設定保持不變。

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **保留圖片裁切**

將名為 `photo.jpg` 的照片放置於工作目錄中。範例將左側裁切 12%，右側裁切 8%，然後在圖片框上設定 [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/)。此旗標限制進一步裁切並保留現有的裁切。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` 將裁切鎖存為 `True`。在 PowerPoint 中，選取照片時 **Crop** 命令會被停用。

### **保留圖表群組化**

範例將矩形與箭頭群組，並在該群組本身設定 [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/)，以保持圖表的元件在一起。其他編輯，例如移動群組或變更元件的填色，仍然可用。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` 將解除群組鎖存為 `True`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 命令會被停用。

### **報告現有形狀鎖定**

若要檢閱範本，請開啟它並閱讀每個形狀的鎖定物件。當該物件的所有旗標皆停用時，[no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) 為 `True`；只要有至少一個啟用則為 `False`。群組及其子形狀各有獨立的鎖定物件，因此即使群組未設定鎖定，也需檢查其子形狀。

此範例檢查自動圖形、圖片框與群組的移動，圖片的裁切，以及群組的解除群組。它會回報其識別的旗標，並標示未檢查的形狀類型。

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

假設 `Sample.pptx` 的第 1 張投影片包含一個名為 `Layout`、已鎖定解除群組的群組，其中有一張名為 `Photo`、已鎖定裁切的圖片，以及一個未鎖定的矩形 `Free`。報告會略過 `Free`，並列印以下兩行：

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

報告會讀取已儲存的形狀層級編輯旗標，且不會修改或儲存簡報。文件層級的寫入保護是另一項設定，且每個旗標的執行方式取決於編輯器。

## **結論**

Aspose.Slides for Python via .NET 允許您限制個別形狀的特定編輯操作，或在全部投影片上套用相同的限制。請依形狀類型選擇支援的鎖定，並在需要移除限制時將其值設為 `False`。

## **常見問題**

**我可以在同一個簡報中同時結合形狀鎖和密碼保護嗎？**

可以。形狀鎖會限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/python-net/password-protected-presentation/) 可以限制開啟或修改簡報。您可以在同一個檔案中同時使用兩者。

**我可以只限制特定投影片的編輯，而不影響其他投影片嗎？**

可以。僅對選取的投影片上的形狀套用鎖定。這不會更改其他投影片的鎖定設定。

**我該如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合，對每個子形狀套用相應的鎖定。對任何巢狀群組重複此動作，遵循報告範例中的遍歷方式。