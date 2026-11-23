---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in .NET
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 70
url: /nl/net/applying-protection-to-presentation/
keywords:
- voorkomen van bewerkingen
- beschermen tegen bewerking
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groeperen vergrendelen
- PowerPoint
- PPTX
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties met Aspose.Slides voor .NET kunt vergrendelen en ontgrendelen om selectie, verplaatsing, grootte en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides voor .NET is het maken, bijwerken en opslaan van PowerPoint (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingframes, videoframes, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides voor .NET wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface implementeert of ervan erft.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interface is de basinterface voor vormvergrendelingen. Aspose.Slides voor .NET levert de volgende vergrendelingsinterfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) vergrendelt afbeeldingframes.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), doorloop de dia's en stel de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Compatibele presentatieredacteurs gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestandsversleuteling en schrijfbescherming op documentniveau zijn afzonderlijke [presentatiebeveiligingsinstellingen](/slides/nl/net/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor .NET biedt de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld stelt [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), en [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) in op `true` voor autovormen, met equivalente vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingframes. Connectoren gebruiken [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) voor verplaatsing; groepen gebruiken ook [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormcollectie van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier ondersteunde types blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

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

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en wijzigingsbeperkingen via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), en [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Het wist ook [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Een afbeeldingbijsnede behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12% van de linkerkant en 8% van de rechterkant bij, en stelt vervolgens [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) in op het afbeeldingframe. Deze vlag beperkt verdere bijsnijding en behoudt de bestaande bijsnijding.

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

`PictureLocked.pptx` slaat de bijsnijdvergrendeling op als `true`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en stelt vervolgens [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) in op de groep zelf om de componenten van het diagram samen te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de opvulling van een component, blijven beschikbaar.

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

`DiagramLocked.pptx` slaat de ontgroeperingsvergrendeling op als `true`. In PowerPoint is de **Ungroup**‑opdracht uitgeschakeld wanneer het gehele diagram is geselecteerd.

### **Conclusie**

Aspose.Slides voor .NET stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen op meerdere dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/net/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken op specifieke dia's beperken zonder andere dia's te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑collectie van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormcollectie van de dia, dus ze stellen geen vergrendelingen in voor individuele groepsleden.