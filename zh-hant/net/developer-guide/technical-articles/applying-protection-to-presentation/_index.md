---
title: 在 .NET 中使用形狀鎖定防止簡報編輯
linktitle: 防止簡報編輯
type: docs
weight: 70
url: /zh-hant/net/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定大小
- 鎖定群組
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何在 PPT、PPTX 與 ODP 檔案中鎖定或解除鎖定形狀，保護簡報安全，同時允許受控的編輯。"
---
## **Background**

Aspose.Slides 的常見用途是於自動化工作流程中建立、更新與儲存 Microsoft PowerPoint (PPTX) 簡報。以此方式使用 Aspose.Slides 的應用程式使用者能取得產生的簡報，因而保護其不被編輯是一項常見的顧慮。確保自動產生的簡報保留原始的格式與內容非常重要。

本文件說明簡報與投影片的結構，以及 Aspose.Slides for .NET 如何對簡報套用保護並在之後移除保護。它提供開發人員一種方式來控制應用程式產生的簡報的使用方式。

## **Composition of a Slide**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建構簡報的元件組成。在 Aspose.Slides for .NET 中，投影片上的每個元件皆以實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面的物件或繼承自該類別的物件表示。

PPTX 的結構相當複雜，與 PPT 不同，PPT 中可使用通用鎖定來處理所有類型的圖形，而 PPTX 必須針對不同的圖形類型使用不同的鎖定。[IBaseShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseshapelock/) 介面是 PPTX 的通用鎖定類別。Aspose.Slides for .NET 在 PPTX 中支援以下類型的鎖定：

- [IAutoShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/) 鎖定圖片框。  

對 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件中所有圖形物件執行的任何動作，都會套用至整個簡報。

## **Apply and Remove Protection**

套用保護可確保簡報無法被編輯。這是一種保護簡報內容的有效技術。

### **Apply Protection to PPTX Shapes**

Aspose.Slides for .NET 提供 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面以操作投影片上的圖形。

如前所述，每個圖形類別都有對應的圖形鎖定類別以實現保護。本文聚焦於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定確保圖形無法被選取（透過滑鼠點擊或其他選取方式），也無法被移動或調整大小。

以下程式碼範例會對簡報中的所有圖形類型套用保護。

```cs
// 實例化代表 PPTX 檔案的 Presentation 類別。
using Presentation presentation = new Presentation("Sample.pptx");

// 遍歷簡報中的所有投影片。
foreach (ISlide slide in presentation.Slides)
{
    // 遍歷投影片中的所有圖形。
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// 儲存簡報檔案。
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remove Protection**

若要解除圖形的鎖定，只需將已套用的鎖定值設為 `false`。以下程式碼範例說明如何解除已鎖定簡報中的圖形。

```cs
// 實例化代表 PPTX 檔案的 Presentation 類別。
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// 遍歷簡報中的所有投影片。
foreach (ISlide slide in presentation.Slides)
{
    // 遍歷投影片中的所有圖形。
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// 儲存簡報檔案。
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusion**

Aspose.Slides 提供多種方式來保護簡報中的圖形。您可以鎖定單一圖形，或遍歷簡報中的所有圖形並逐一鎖定，以有效保護整個檔案。若要移除保護，只需將鎖定值設為 `false`。

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

可以。鎖定限制檔案內物件的編輯，而 [password protection](/slides/zh-hant/net/password-protected-presentation/) 控制開啟與/或儲存變更的權限。這兩種機制相輔相成，協同運作。

**Can I restrict editing on specific slides without affecting others?**

可以。對選取的投影片上的圖形套用鎖定，其他投影片仍可編輯。

**Do shape locks apply to grouped objects and connectors?**

可以。對群組、連接線、圖形物件以及其他圖形類型皆支援專屬的鎖定類別。