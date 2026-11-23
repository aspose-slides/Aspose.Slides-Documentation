---
title: 使用形狀鎖定在 Python 中限制簡報編輯
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PPTX 簡報中鎖定與解鎖形狀，以限制選取、移動、調整大小與群組。"
---
## **背景**

Aspose.Slides for Python via .NET 的常見用途是建立、更新並儲存 PowerPoint (PPTX) 簡報，作為自動化工作流程的一部分。當使用者收到這些簡報時，限制對圖形的變更可以協助保留原本的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對個別圖形的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Python via .NET 中，投影片上的每個元素皆以繼承自[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/)類別是圖形鎖定的基底類別。Aspose.Slides for Python via .NET 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 鎖定連接線圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)中套用鎖定，請遍歷其投影片，並在每個支援的圖形上設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用圖形鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護屬於其他[簡報保護設定](/slides/zh-hant/python-net/password-protected-presentation/)。

### **對 PPTX 圖形套用保護**

Aspose.Slides for Python via .NET 提供[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)類別，以操作投影片上的圖形。

範例將[select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)與[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/)設為 `True`，適用於自動圖形，同時對群組圖形、連接線與圖片框套用等效的鎖定。連接線使用[position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/)控制移動；群組則使用[grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)限制群組操作。

範例會載入現有的 PPTX 簡報，檢查每張投影片的 shape collection，並將這些限制儲存為新檔案。未屬於上述四種處理類型的圖形將保持不變。此迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，只需將其值設為 `False`。以下範例載入含有圖形鎖定的簡報，並透過[AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)與[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/)清除選取、移動與調整大小的限制。它同時清除[GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)，並將簡報另存為新檔。其他鎖定設定則保持不變。

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

將名為 `photo.jpg` 的照片放在工作目錄中。範例會從左側裁切 12%，右側裁切 8%，然後在圖片框上設定[crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/)以保留裁切設定。

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

`PictureLocked.pptx` 會將裁切鎖定儲存為 `True`。在 PowerPoint 中，當選取照片時，**裁切**指令會被停用。

### **將圖表保持群組狀態**

範例會將一個矩形與一支箭頭群組，然後在群組本身設定[ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/)以保持圖表的元件一起存在。其他編輯操作，例如移動群組或變更元件填滿，仍然可用。

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

`DiagramLocked.pptx` 會將取消群組鎖定儲存為 `True`。在 PowerPoint 中，當選取整個圖表時，**取消群組**指令會被停用。

### **結論**

Aspose.Slides for Python via .NET 讓您可以限制個別圖形的特定編輯操作，或在整個簡報中套用相同的限制。依據每種圖形類型支援的鎖定，選擇相應的鎖定項目，並在需要移除限制時將其值設為 `False`。

## **常見問題**

**我可以在同一個簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而[password protection](/slides/zh-hant/python-net/password-protected-presentation/)則可限制開啟或修改簡報。您可以在同一檔案中同時使用兩者。

**我能否只限制特定投影片的編輯，而不影響其他投影片？**

可以。僅對選定投影片上的圖形套用鎖定，不會改變其他投影片的鎖定設定。

**如何對群組內的個別圖形套用鎖定？**

遍歷群組的[shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)集合，並對每個子圖形套用相應的鎖定。對任何巢狀群組重複此程序。上述範例僅處理投影片的 shape collection，因此不會對個別群組成員設定鎖定。