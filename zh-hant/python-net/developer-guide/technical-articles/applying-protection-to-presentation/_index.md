---
title: 使用形狀鎖定在 Python 中限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 70
url: /zh-hant/python-net/applying-protection-to-presentation/
keywords:
- 防止編輯
- 保護免於編輯
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PPTX 簡報中鎖定與解鎖形狀，以限制選取、移動、調整大小和群組。"
---
## **背景**

Aspose.Slides for Python via .NET 的常見用途是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對個別圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建構簡報的元素組成。在 Aspose.Slides for Python via .NET 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 類別是圖形鎖定的基底類別。Aspose.Slides for Python via .NET 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 鎖定連接圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個受支援的圖形設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。它們不會使整個簡報變成不可編輯。

### **套用 PPTX 圖形的保護**

Aspose.Slides for Python via .NET 提供 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 類別，以在投影片上處理圖形。

範例將 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) 與 [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) 設為 `True` 於自動圖形，對群組圖形、連接線與圖片框套用相同的鎖定。連接線使用 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) 以控制移動；群組則使用 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 以限制群組化。

範例載入現有的 PPTX 簡報，檢查每個投影片的圖形集合中的圖形，並儲存套用了這些限制的副本。未屬於上述四種處理類型的圖形將保持不變。此迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，請將其值設為 `False`。以下範例載入含有圖形鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 與 [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。它同時清除 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 並儲存簡報的副本。其他鎖定設定則保持不變。

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

### **結論**

Aspose.Slides for Python via .NET 讓您能限制對單一圖形的特定編輯操作，或於多張投影片上套用相同的限制。請選擇各圖形類型支援的鎖定，並在需要移除限制時將其值設為 `False`。

## **常見問題**

**我可以在同一個簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/python-net/password-protected-presentation/) 可以限制簡報的開啟或修改。您可以在同一個檔案中同時使用兩者。

**我可以僅限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅在選取的投影片上套用鎖定，這不會更改其他投影片的鎖定設定。

**我該如何對群組內的個別圖形套用鎖定？**

遍歷群組的 [形狀](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合，並對每個子圖形套用相應的鎖定。對任何巢狀群組亦重複此動作。上面的範例僅處理投影片的圖形集合，未對個別群組成員設定鎖定。