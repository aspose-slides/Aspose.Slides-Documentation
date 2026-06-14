---
title: 使用圖形鎖定防止簡報編輯
linktitle: 防止簡報編輯
type: docs
weight: 60
url: /zh-hant/java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定圖形
- 鎖定位置
- 鎖定選取
- 鎖定大小
- 鎖定群組
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何在 PPT、PPTX 與 ODP 檔案中鎖定或解除鎖定圖形，保障簡報安全，同時允許受控編輯並加速交付。"
---
## **背景**

Aspose.Slides 常用於在自動化工作流程中建立、更新與儲存 Microsoft PowerPoint (PPTX) 簡報。以此方式使用 Aspose.Slides 的應用程式使用者可取得產生的簡報，因此防止簡報被編輯是一項常見的顧慮。確保自動產生的簡報保留其原始的格式與內容非常重要。

本篇說明簡報與投影片的結構，以及 Aspose.Slides for Java 如何對簡報套用保護並在之後移除保護。它提供開發人員一種方式，讓應用程式產生的簡報可受到使用上的控制。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用來建構簡報的元素組成。在 Aspose.Slides for Java 中，投影片上的每個元素皆由實作 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面或繼承自實作該介面的類別的物件表示。

PPTX 的結構相當複雜，與 PPT 不同，PPT 中可以使用通用鎖定來處理所有類型的圖形；而 PPTX 中不同類型的圖形必須使用不同的鎖定。[IBaseShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseshapelock/) 介面是 PPTX 的通用鎖定類別。Aspose.Slides for Java 在 PPTX 中支援以下類型的鎖定：

- [IAutoShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/) 鎖定圖片框。  

對 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 物件中所有圖形物件執行的任何動作，皆會套用到整個簡報。

## **套用與移除保護**

套用保護可以確保簡報無法被編輯。這是一項用於保護簡報內容的有效技術。

### **對 PPTX 圖形套用保護**

Aspose.Slides for Java 提供 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面以操作投影片上的圖形。

如前所述，每個圖形類別都有相對應的圖形鎖定類別以實作保護。本篇聚焦於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定可確保圖形無法被選取（透過滑鼠點擊或其他選取方式），且無法被移動或調整大小。

以下程式碼範例會對簡報中的所有圖形類型套用保護。

```java
// 實例化代表 PPTX 檔案的 Presentation 類別。
Presentation presentation = new Presentation("Sample.pptx");

// 遍歷簡報中的所有投影片。
for (ISlide slide : presentation.getSlides()) {

    // 遍歷投影片中的所有圖形。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 將圖形型別轉換為自動圖形，並取得其圖形鎖定。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // 將圖形型別轉換為群組圖形，並取得其圖形鎖定。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // 將圖形型別轉換為連接線圖形，並取得其圖形鎖定。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // 將圖形型別轉換為圖片框，並取得其圖形鎖定。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// 儲存簡報檔案。
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **移除保護**

若要解除圖形的鎖定，將已套用的鎖定值設為 `false`。下列程式碼範例示範如何在已鎖定的簡報中解除圖形的鎖定。

```java
// 實例化代表 PPTX 檔案的 Presentation 類別。
Presentation presentation = new Presentation("ProtectedSample.pptx");

// 遍歷簡報中的所有投影片。
for (ISlide slide : presentation.getSlides()) {

    // 遍歷投影片中的所有圖形。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 將圖形型別轉換為自動圖形，並取得其圖形鎖定。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // 將圖形型別轉換為群組圖形，並取得其圖形鎖定。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // 將圖形型別轉換為連接線圖形，並取得其圖形鎖定。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // 將圖形型別轉換為圖片框，並取得其圖形鎖定。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// 儲存簡報檔案。
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **結論**

Aspose.Slides 提供多種方式來保護簡報中的圖形。您可以鎖定單一圖形，或遍歷簡報中的所有圖形並逐一鎖定，以有效保護整個檔案。透過將鎖定值設為 `false`，即可移除保護。

## **常見問題**

**我可以在同一個簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。鎖定限制檔案內物件的編輯，而 [password protection](/slides/zh-hant/java/password-protected-presentation/) 則控制開啟與/或儲存變更的存取權限。這兩種機制互相補足、共同運作。

**我可以限制特定投影片的編輯，而不影響其他投影片嗎？**

可以。只對選取投影片上的圖形套用鎖定，其他投影片仍可編輯。

**圖形鎖定是否適用於群組物件與連接線？**

適用。針對群組、連接線、圖形物件以及其他圖形類型皆支援專屬的鎖定類型。