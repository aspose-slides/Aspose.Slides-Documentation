---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in .NET
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 70
url: /nl/net/applying-protection-to-presentation/
keywords:
- voorkom bewerkingen
- bescherm tegen bewerken
- vergrendel vorm
- vergrendel positie
- vergrendel selectie
- vergrendel formaatwijziging
- vergrendel groepering
- PowerPoint
- PPTX
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor .NET om selectie, verplaatsing, formaatwijziging en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides voor .NET is het maken, bijwerken en opslaan van PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen om de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen georganiseerd zijn op dia’s en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen je in staat om specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE-objecten, gegroepeerde vormen, afbeeldingsframes, videoframes, connectoren en andere elementen die gebruikt worden om een presentatie op te bouwen. In Aspose.Slides voor .NET wordt elk element op een dia vertegenwoordigd door een object dat de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface implementeert of van een klasse erft die dat doet.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interface is de basisinterface voor vormvergrendelingen. Aspose.Slides voor .NET biedt de volgende vergrendelingsinterfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) vergrendelt afbeeldingsframes.  

Om vergrendelingen toe te passen over een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), kun je door de dia’s itereren en voor elke ondersteunde vorm de juiste vergrendelingen instellen.

## **Vergrendeling toepassen en verwijderen**

Compatibele presentatieditoren gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestandversleuteling en schrijfbeveiliging op documentniveau zijn afzonderlijke [presentatiebeveiligingsinstellingen](/slides/nl/net/password-protected-presentation/).

### **Beveiliging toepassen op PPTX‑vormen**

Aspose.Slides voor .NET biedt de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface om met vormen op een dia te werken.

In het voorbeeld worden [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) en [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) op `true` gezet voor autovormen, met equivalente vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingsframes. Connectoren gebruiken [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) voor beweging; groepen gebruiken ook [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier verwerkte typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

### **Beveiliging verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. In het volgende voorbeeld wordt een presentatie met vormvergrendelingen geladen en worden de selectie‑, verplaatsings‑ en grootte‑beperkingen gewist via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) en [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Het wist ook [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Een afbeeldingssnede behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en stelt vervolgens [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) in op het afbeeldingsframe. Deze vlag beperkt verdere bijsnijding en behoudt de bestaande snede.

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

`PictureLocked.pptx` stores the crop lock as `true`. In PowerPoint, the **Crop** command is disabled when the photo is selected.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en stelt vervolgens [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) in op de groep zelf om de componenten van het diagram gezamenlijk te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

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

`DiagramLocked.pptx` stores the ungrouping lock as `true`. In PowerPoint, the **Ungroup** command is disabled when the whole diagram is selected.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te bekijken, open je het en lees je het vergrendelingsobject voor elke vorm. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) is `true` wanneer alle vlaggen op dat object zijn uitgeschakeld en `false` wanneer er minstens één is ingeschakeld. Een groep en zijn onderliggende vormen hebben aparte vergrendelingsobjecten, dus inspecteer de onderliggende vormen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert verplaatsing voor autovormen, afbeeldingsframes en groepen, bijsnijden voor afbeeldingen, en ontgroeperen voor groepen. Het rapporteert de vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

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

Stel dat dia 1 van `Sample.pptx` een groep genaamd `Layout` bevat met vergrendeld ontgroeperen, een foto genaamd `Photo` erin met vergrendelde bijsnijding, en een ontgrendelde rechthoek genaamd `Free`. Het rapport slaat `Free` over en print deze twee regels:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen bewerkingsvlaggen op vormniveau zonder ze te wijzigen of de presentatie op te slaan. Schrijfbeveiliging op documentniveau is een afzonderlijke instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides voor .NET stelt je in staat om specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en stel hun waarden in op `false` wanneer je die beperkingen wilt verwijderen.

## **Veelgestelde vragen**

**Kun ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/net/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Itereer door de [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) collectie van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen, volgens de doorloop in het rapportage‑voorbeeld.