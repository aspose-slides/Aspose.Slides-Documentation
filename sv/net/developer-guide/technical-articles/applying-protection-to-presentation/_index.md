---
title: Begränsa redigering av presentationer med form-lås i .NET
linktitle: Begränsa redigering av presentationer
type: docs
weight: 70
url: /sv/net/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för .NET för att begränsa urval, förflyttning, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides för .NET är att skapa, uppdatera och spara PowerPoint‑presentationer (PPTX) som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former organiseras på bilder och hur du tillämpar och tar bort lås på former i en PPTX‑presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter som autogestalter, tabeller, OLE‑objekt, grupperade former, bildramar, videoram, anslutare och andra element som används för att bygga en presentation. I Aspose.Slides för .NET representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) eller ärver från en klass som gör det.

Olika formtyper exponerar olika låsalternativ. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) är basgränssnittet för form‑lås. Aspose.Slides för .NET tillhandahåller följande låsgränssnitt:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) låser autogestalter.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) låser grupperade former.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) låser bildramar.  

För att tillämpa lås på en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterera genom dess bilder och ställ in lämpliga lås på varje stödjande form.

## **Tillämpa och ta bort skydd**

Kompatibla presentationsredigerare använder form‑lås för att begränsa enskilda redigeringsåtgärder. Filkryptering och dokument‑nivå skrivrättighetsskydd är separata [presentation protection settings](/slides/sv/net/password-protected-presentation/).

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides för .NET tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) för att arbeta med former på en bild.

Exemplet sätter [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) och [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) till `true` för autogestalter, med motsvarande lås för gruppformer, anslutare och bildramar. Anslutare använder [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) för förflyttning; grupper använder även [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX‑presentation, kontrollerar formerna i varje bilds form‑samling och sparar en kopia med dessa begränsningar tillämpade. Former som inte tillhör de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte underordnade former inuti en grupp.

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

### **Ta bort skydd**

För att ta bort ett form‑lås, sätt dess värde till `false`. Följande exempel läser in en presentation med form‑lås och rensar urval‑, flytt‑ och storleks‑restriktionerna via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) och [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Det rensar även [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

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

### **Bevara bildbeskärning**

Placera en bild med namn `photo.jpg` i arbetskatalogen. Exemplet beskär 12 % från vänster och 8 % från höger, och sätter sedan [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) på bildramen. Detta flagga begränsar ytterligare beskärning och bevarar den befintliga beskärningen.

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

`PictureLocked.pptx` lagrar beskärningslåset som `true`. I PowerPoint är kommandot **Crop** inaktiverat när bilden är markerad.

### **Behåll ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och sätter sedan [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) på själva gruppen för att hålla diagrammets komponenter ihop. Andra redigeringar, såsom att flytta gruppen eller ändra en komponents fyllning, förblir tillgängliga.

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

`DiagramLocked.pptx` lagrar avgrupperingslåset som `true`. I PowerPoint är kommandot **Ungroup** inaktiverat när hela diagrammet är markerat.

### **Rapportera befintliga form‑lås**

För att granska en mall, öppna den och läs lås‑objektet för varje form. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) är `true` när alla flaggor på det objektet är inaktiverade och `false` när minst en är aktiverad. En grupp och dess underordnade har separata lås‑objekt, så inspektera underordnade även när gruppen saknar lås.

Detta exempel kontrollerar förflyttning för autogestalter, bildramar och grupper, beskärning för bilder samt avgruppering för grupper. Det rapporterar de flaggor det känner igen och markerar formtyper som det inte inspekterar.

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

Anta att bild 1 i `Sample.pptx` innehåller en grupp med namn `Layout` där avgruppering är låst, en bild med namn `Photo` inuti den med beskärning låst, och en olåst rektangel med namn `Free`. Rapporten hoppar över `Free` och skriver ut dessa två rader:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapporten läser lagrade form‑nivå redigeringsflaggor utan att ändra dem eller spara presentationen. Dokument‑nivå skrivskydd är en separat inställning, och genomförandet av varje flagga beror på redigeraren.

### **Slutsats**

Aspose.Slides för .NET låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över flera bilder. Välj de lås som stöds av varje formtyp, och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera form‑lås och lösenordsskydd i samma presentation?**

Ja. Form‑lås begränsar specifika redigeringsåtgärder, medan [password protection](/slides/sv/net/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås endast på formerna på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former inuti en grupp?**

Iterera genom gruppens [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑samling och tillämpa lämpliga lås på varje underordnad form. Upprepa detta för eventuella nästlade grupper enligt traverseringen i rapport‑exemplet.