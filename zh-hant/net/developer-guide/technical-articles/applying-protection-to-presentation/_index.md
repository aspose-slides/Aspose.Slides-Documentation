---
title: 使用形狀鎖定限制 .NET 中的簡報編輯
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
description: "了解如何使用 Aspose.Slides for .NET 在 PPTX 簡報中鎖定與解鎖形狀，以限制選取、移動、調整大小和群組操作。"
---
## **背景**

Aspose.Slides for .NET 的常見用途是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制形狀的變更有助於保留原有的版面配置與內容。

本篇說明形狀在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定可限制對個別形狀的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線及其他用於建立簡報的元素組成。在 Aspose.Slides for .NET 中，投影片上的每個元素皆以實作 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面的物件或繼承自該類別的物件表示。

不同的形狀類型會提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 介面是形狀鎖定的基礎介面。Aspose.Slides for .NET 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 鎖定自動形狀。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 鎖定連接線形狀。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 鎖定群組形狀。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的形狀設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用形狀鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是別的 [presentation protection settings](/slides/zh-hant/net/password-protected-presentation/)。

### **套用 PPTX 形狀保護**

Aspose.Slides for .NET 提供 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面以操作投影片上的形狀。

範例將自動形狀的 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) 與 [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) 設為 `true`，群組形狀、連接線與圖片框亦設定對應的鎖定。連接線使用 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) 來限制移動；群組則使用 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 以限制重新分組。

範例會載入既有的 PPTX 簡報，檢查每張投影片的 shape collection，並將這些限制寫入副本。未屬於上述四種型別的形狀保持不變。此迴圈不會遞迴遍歷群組內的子形狀。

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

若要移除形狀鎖定，將其值設為 `false`。以下範例載入含有形狀鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。它也會清除 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 並儲存簡報的副本。其他鎖定設定保持不變。

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

### **保留圖片裁切**

將名為 `photo.jpg` 的照片放置於工作目錄中。範例會從左側裁切 12%、右側裁切 8%，然後在圖片框上設定 [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)。此旗標會限制後續的裁切動作，保留已存在的裁切結果。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取該照片時 **Crop** 指令會被停用。

### **保持圖表群組狀態**

範例先將矩形與箭頭群組，然後在群組本身設定 [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)，以確保圖表的元件保持在一起。其他編輯（例如移動群組或變更元件的填色）仍然可用。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` 將解除群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 指令會被停用。

### **結論**

Aspose.Slides for .NET 讓您能對個別形狀限制特定的編輯操作，或在多張投影片上套用相同的限制。請依每種形狀類型支援的鎖定項目設定值，若需移除限制則將其設定為 `false`。

## **常見問題**

**我可以在同一個簡報中同時使用形狀鎖定與密碼保護嗎？**

可以。形狀鎖定限制特定的編輯操作，而 [password protection](/slides/zh-hant/net/password-protected-presentation/) 則可限制開啟或修改簡報。兩者可以同時存在於同一檔案中。

**我可以只對特定投影片設定編輯限制，而不影響其他投影片嗎？**

可以。僅在選取的投影片上套用鎖定，其他投影片的鎖定設定不會被更改。

**如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合，對每個子形狀套用相應的鎖定。對於任何巢狀群組皆如此。上述範例僅處理投影片的 shape collection，未對群組成員設定鎖定。