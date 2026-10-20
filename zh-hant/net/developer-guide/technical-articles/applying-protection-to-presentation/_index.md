---
title: 使用 Shape Locks 限制 .NET 中的簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 70
url: /zh-hant/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小和群組操作。"
---
## **背景**

Aspose.Slides for .NET 的常見用途之一是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制形狀的變更可以協助維持預期的版面配置與內容。

本文說明形狀在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定讓您能限制對個別形狀的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於建構簡報的元件組成。在 Aspose.Slides for .NET 中，投影片上的每個元件皆由實作 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面或繼承自該類別的物件表示。

不同的形狀類型會公開不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 介面是形狀鎖定的基礎介面。Aspose.Slides for .NET 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 鎖定連接線形狀。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 鎖定群組形狀。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的形狀設定相應的鎖定。

## **套用與移除保護**

形狀鎖定會限制選取、移動與調整大小等操作，但不會使整個簡報無法編輯。

### **套用 PPTX 形狀保護**

Aspose.Slides for .NET 提供 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面以在投影片上操作形狀。

範例將 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) 與 [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) 設為 `true` 以鎖定自動圖形，並對群組形狀、連接線與圖片框套用等效的鎖定。連接線使用 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) 來限制移動；群組同時使用 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 以限制群組操作。

範例會載入現有的 PPTX 簡報，檢查每張投影片的形狀集合，並儲存套用這些限制的副本。未屬於上述四種處理類型的形狀則保持不變。此迴圈不會遍歷群組內的子形狀。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **移除保護**

若要移除形狀鎖定，只需將其值設為 `false`。以下範例載入一個含有形狀鎖定的簡報，透過 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 與 [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。它也會清除 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)，並儲存簡報的副本。其他鎖定設定則保持不變。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **結論**

Aspose.Slides for .NET 讓您能限制個別形狀的特定編輯操作，或在多張投影片上套用相同的限制。請選擇每種形狀類型支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一簡報中同時使用形狀鎖定與密碼保護嗎？**

可以。形狀鎖定會限制特定的編輯操作，而 [password protection](/slides/zh-hant/net/password-protected-presentation/) 則可限制開啟或修改簡報。您可以在同一檔案中同時使用兩者。

**我可以只限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅對選取的投影片上的形狀套用鎖定，這不會改變其他投影片的鎖定設定。

**如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合，並對每個子形狀套用相應的鎖定。對任何巢狀群組重複此程序。上述範例僅處理投影片的形狀集合，因此不會對個別群組成員設定鎖定。