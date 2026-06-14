---
title: 防止簡報在 Python 中透過形狀鎖定編輯
linktitle: 防止簡報編輯
type: docs
weight: 70
url: /zh-hant/python-net/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定大小
- 鎖定群組
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何在 PPT、PPTX 與 ODP 檔案中鎖定或解鎖形狀，保護簡報安全，同時允許受控編輯與更快速的交付。"
---
## **背景**

Aspose.Slides 的常見用法是於自動化工作流程中建立、更新與儲存 Microsoft PowerPoint (PPTX) 簡報。以此方式使用 Aspose.Slides 的應用程式使用者可以取得產生的簡報，因而對防止內容被編輯抱持高度關切。確保自動產生的簡報保留其原始格式與內容是十分重要的。

本篇說明簡報與投影片的結構，以及 Aspose.Slides for Python 如何對簡報套用保護並於之後移除。它為開發者提供一種方式，讓他們能控制應用程式產生的簡報的使用方式。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於建立簡報的元素構成。在 Aspose.Slides for Python 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別的物件表示。

PPTX 的結構相當複雜，因而不同於 PPT（可對所有形狀類型使用通用鎖定），不同形狀類型需要不同的鎖定。[BaseShapeLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseshapelock/) 類別是 PPTX 的通用鎖定類別。以下是 Aspose.Slides for Python 在 PPTX 中支援的鎖定類型：

- [AutoShapeLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/connectorlock/) 鎖定連接形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/) 鎖定圖片框。  

對 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件中的所有形狀物件所執行的任何操作，都會套用至整個簡報。

## **套用與移除保護**

套用保護可確保簡報無法被編輯。這是一項用於保護簡報內容的實用技術。

### **套用保護至 PPTX 形狀**

Aspose.Slides for Python 提供 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別，以處理投影片上的形狀。

如前所述，每個形狀類別都有對應的 shape-lock 類別以提供保護。本篇聚焦於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定可防止形狀被選取（透過滑鼠點擊或其他選取方式），亦防止其被移動或調整大小。

以下程式碼範例會對簡報中的所有形狀類型套用保護。

```py
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation("Sample.pptx") as presentation:
    # 遍歷簡報中的所有投影片。
    for slide in presentation.slides:
        # 遍歷投影片中的所有形狀。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # 儲存簡報檔案。
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **移除保護**

若要解除形狀的鎖定，將已套用的鎖定值設為 `False`。以下程式碼範例示範如何在已鎖定的簡報中解除形狀的鎖定。

```py
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # 遍歷簡報中的所有投影片。
    for slide in presentation.slides:
        # 遍歷投影片中的所有形狀。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # 儲存簡報檔案。
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **結論**

Aspose.Slides 提供多種保護簡報中形狀的選項。您可以鎖定單一形狀，或遍歷簡報中的所有形狀並逐一鎖定，以有效保護整個檔案。亦可透過將鎖定值設為 `False` 來移除保護。

## **常見問題**

**我可以在同一個簡報中同時結合形狀鎖定與密碼保護嗎？**

可以。鎖定限制檔案內物件的編輯，而 [password protection](/slides/zh-hant/python-net/password-protected-presentation/) 控制開啟與/或儲存變更的存取權限。這兩種機制相輔相成，可共同運作。

**我可以限制特定投影片的編輯而不影響其他投影片嗎？**

可以。對所選投影片上的形狀套用鎖定，其他投影片則保持可編輯。

**形狀鎖定會套用於群組物件與連接線嗎？**

會。針對群組、連接線、圖形物件以及其他形狀類型均支援專屬的鎖定類別。