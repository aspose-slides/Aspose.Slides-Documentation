---
title: 在 .NET 中使用形狀鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 70
url: /zh-hant/net/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定圖形
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
description: "了解如何使用 Aspose.Slides for .NET 在 PPTX 簡報中鎖定與解除鎖定圖形，以限制選取、移動、調整大小與群組化。"
---
## **背景**

Aspose.Slides for .NET 的常見用法是於自動化工作流程中建立、更新與保存 PowerPoint (PPTX) 簡報。使用者收到這些簡報時，限制對圖形的變更可以協助保持預期的版面與內容。

本篇說明圖形在投影片上的組織方式以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制個別圖形的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用以建立簡報的元件構成。在 Aspose.Slides for .NET 中，投影片上的每個元件皆由實作 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面的物件或繼承自該類別的類別表示。

不同類型的圖形提供不同的鎖定選項。 [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for .NET 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並在每個支援的圖形上設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用圖形鎖定來限制個別編輯操作。檔案加密與文件層級的寫入保護是獨立的 [presentation protection settings](/slides/zh-hant/net/password-protected-presentation/)。

### **套用 PPTX 圖形保護**

Aspose.Slides for .NET 提供 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 介面，以便操作投影片上的圖形。

範例將自動圖形的 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) 與 [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) 設為 `true`，同時對群組圖形、連接線與圖片框套用等效的鎖定。連接線使用 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) 來限制移動；群組則使用 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 以限制群組化。

此範例載入現有 PPTX 簡報，檢查每張投影片的 ShapeCollection，並將這些限制儲存為新副本。未屬於上述四種處理類型的圖形維持不變。迴圈不會遍歷群組內部的子圖形。

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

若要移除圖形鎖定，將其值設為 `false`。以下範例載入帶有圖形鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 與 [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 解除選取、移動與調整大小的限制。它同時清除 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)，並儲存簡報的副本。其他鎖定設定保持不變。

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

將名為 `photo.jpg` 的照片放置於工作目錄。範例從左側裁切 12%、右側裁切 8%，然後在圖片框上設定 [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)。此旗標可限制後續裁切，保留現有的裁切結果。

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

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **裁剪** 指令會被停用。

### **保持圖表群組化**

範例將一個矩形與一支箭頭群組，然後在群組本身設定 [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)，以防止圖表的元件被拆散。其他編輯操作（如移動群組或變更元件填滿）仍可使用。

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

`DiagramLocked.pptx` 將取消群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **取消群組** 指令會被停用。

### **報告現有圖形鎖定**

若要檢查模板，請開啟它並讀取每個圖形的鎖定物件。當該物件的所有旗標皆為 `false` 時，[NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) 為 `true`；只要有任一旗標為 `true`，則為 `false`。群組與其子圖形各有獨立的鎖定物件，故即使群組本身沒有鎖定，也必須檢查子圖形。

此範例檢查自動圖形、圖片框與群組的移動鎖定、圖片的裁切鎖定以及群組的取消群組鎖定。它會報告所有已辨識的旗標，並標示未檢查的圖形類型。

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

假設 `Sample.pptx` 的第 1 張投影片包含名稱為 `Layout` 的群組，其取消群組被鎖定，群組內的圖片 `Photo` 裁切被鎖定，而名稱為 `Free` 的矩形未上鎖。報告會略過 `Free`，僅輸出以下兩行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

此報告僅讀取已儲存的圖形層級編輯旗標，並不會修改或儲存簡報。文件層級的寫入保護是另一種設定，各旗標的實際執行則取決於編輯器。

### **結論**

Aspose.Slides for .NET 讓您能限制個別圖形的特定編輯操作，或在多張投影片上套用相同的限制。依據每種圖形類型支援的鎖定項目設定值，若需要移除限制，請將其設為 `false`。

## **常見問題**

**我可以在同一簡報中同時使用圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而 [password protection](/slides/zh-hant/net/password-protected-presentation/) 可以限制開啟或修改簡報。兩者可同時使用於同一檔案。

**我可以只針對特定投影片限制編輯，而不影響其他投影片嗎？**

可以。只在選取的投影片上的圖形套用鎖定，不會改變其他投影片的鎖定設定。

**我要如何對群組內的個別圖形套用鎖定？**

遍歷群組的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合，對每個子圖形套用相應的鎖定。對於任何巢狀群組，請依照報告範例的遍歷方式重複此步驟。