---
title: 使用形狀鎖定防止簡報編輯
linktitle: 防止簡報編輯
type: docs
weight: 60
url: /zh-hant/python-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 保護免於編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定大小
- 鎖定群組
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何在 PPT、PPTX 與 ODP 檔案中鎖定或解除鎖定形狀，保護簡報安全，同時允許受控編輯並加速交付。"
---
## **背景**

Aspose.Slides 的常見用途是於自動化工作流程中建立、更新與儲存 Microsoft PowerPoint (PPTX) 簡報。以此方式使用 Aspose.Slides 的應用程式使用者能取得產生的簡報，因此保護簡報不被編輯是一項常見的顧慮。確保自動產生的簡報保留原始格式與內容非常重要。

本文說明簡報與投影片的結構，以及 Aspose.Slides for Python via Java 如何對簡報套用保護並稍後移除保護。它為開發人員提供了一種控制其應用程式產生的簡報使用方式的途徑。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Python via Java 中，投影片上的每個元素都以繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 類別的物件表示。

PPTX 的結構相當複雜，因此不像 PPT 那樣可對所有圖形類型使用通用鎖，不同的圖形類型需要不同的鎖。[BaseShapeLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseshapelock/) 類別是 PPTX 的通用鎖定類別。Aspose.Slides for Python via Java 在 PPTX 中支援以下類型的鎖定：

- [AutoShapeLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshapelock/) 鎖定自動圖形。
- [ConnectorLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connectorlock/) 鎖定連接線圖形。
- [GraphicalObjectLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。
- [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshapelock/) 鎖定群組圖形。
- [PictureFrameLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframelock/) 鎖定圖片框。

對 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件中所有圖形物件執行的任何操作，皆會套用至整個簡報。

## **套用與移除保護**

套用保護可確保簡報無法被編輯。這是一項保護簡報內容的實用技術。

### **套用保護於 PPTX 圖形**

Aspose.Slides for Python via Java 提供了用於操作投影片上圖形的 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 類別。

如前所述，每個圖形類別都有對應的圖形鎖定類別以提供保護。本文側重於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定確保圖形無法被選取（透過滑鼠點擊或其他選取方式），且無法被移動或調整大小。

以下程式碼範例會對簡報中的所有圖形類型套用保護。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# 建立代表 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation("Sample.pptx")
try:
    # 遍歷簡報中的所有投影片。
    for slide in presentation.getSlides():
        # 遍歷投影片中的所有圖形。
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    # 儲存簡報檔案。
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **移除保護**

若要解除圖形的鎖定，將已套用的鎖定值設為 `False`。以下程式碼範例示範如何在已鎖定的簡報中解鎖圖形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# 建立代表 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation("ProtectedSample.pptx")
try:
    # 遍歷簡報中的所有投影片。
    for slide in presentation.getSlides():
        # 遍歷投影片中的所有圖形。
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    # 儲存簡報檔案。
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **結論**

Aspose.Slides 提供多種保護簡報中圖形的選項。您可以鎖定單一圖形，或遍歷簡報中的所有圖形並逐一鎖定，以有效保護整個檔案。透過將鎖定值設為 `False` 即可移除保護。

## **常見問題**

**我可以在同一個簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。鎖定會限制檔案內物件的編輯，而 [password protection](/slides/zh-hant/python-java/password-protected-presentation/) 則控制開啟及/或儲存變更的存取權限。這兩種機制互補且可以協同運作。

**我可以僅限制特定投影片的編輯而不影響其他投影片嗎？**

可以。對所選投影片上的圖形套用鎖定；其餘投影片仍保持可編輯。

**圖形鎖定是否適用於群組物件與連接線？**

可以。針對群組、連接線、圖形物件及其他圖形類型皆支援專屬的鎖定類型。