---
title: Voorkom bewerkingen van presentaties met vormvergrendelingen in .NET
linktitle: Voorkom bewerkingen van presentaties
type: docs
weight: 70
url: /nl/net/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groepering vergrendelen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor .NET vormen vergrendelt of ontgrendelt in PPT-, PPTX- en ODP-bestanden, presentaties beveiligt en toch gecontroleerde bewerkingen toestaat."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides is om Microsoft PowerPoint (PPTX)-presentaties te maken, bij te werken en op te slaan als onderdeel van een geautomatiseerde workflow. Gebruikers van applicaties die Aspose.Slides op deze manier inzetten hebben toegang tot de gegenereerde presentaties, waardoor bescherming tegen bewerken een veelvoorkomend aandachtspunt is. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit artikel legt uit hoe presentaties en dia’s zijn opgebouwd en hoe Aspose.Slides for .NET bescherming kan toepassen op een presentatie en deze later kan verwijderen. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun applicaties genereren worden gebruikt.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeelding‑frames, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for .NET wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/)‑interface implementeert of van een klasse erft die dat doet.

De structuur van PPTX is complex, zodat in tegenstelling tot PPT, waar een algemene vergrendeling kan worden gebruikt voor alle type vormen, verschillende vormtypes verschillende vergrendelingen vereisen. De [IBaseShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseshapelock/)‑interface is de generieke vergrendelingsklasse voor PPTX. De volgende soorten vergrendelingen worden ondersteund in Aspose.Slides for .NET voor PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/nl/net/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/nl/net/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/) vergrendelt afbeelding‑frames.  

Elke handeling die wordt uitgevoerd op alle vormobjecten in een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑object wordt toegepast op de volledige presentatie.

## **Bescherming toepassen en verwijderen**

Bescherming toepassen zorgt ervoor dat een presentatie niet kan worden bewerkt. Het is een bruikbare techniek om de inhoud van de presentatie te beveiligen.

### **Bescherming toepassen op PPTX-vormen**

Aspose.Slides for .NET biedt de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/)‑interface om met vormen op een dia te werken.

Zoals eerder vermeld, heeft elke vormklasse een bijbehorende vorm‑vergrendelingsklasse voor bescherming. Dit artikel richt zich op de vergrendelingen NoSelect, NoMove en NoResize. Deze vergrendelingen zorgen ervoor dat vormen niet kunnen worden geselecteerd (via muiskliks of andere selectiemethoden) en dat ze niet kunnen worden verplaatst of van grootte veranderd.

De onderstaande code‑voorbeeld past bescherming toe op alle vormtypes in een presentatie.

```cs
// Instantieer de Presentation‑klasse die een PPTX‑bestand voorstelt.
using Presentation presentation = new Presentation("Sample.pptx");

// Doorloop alle dia's in de presentatie.
foreach (ISlide slide in presentation.Slides)
{
    // Doorloop alle vormen in de dia.
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

// Sla het presentatie‑bestand op.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Bescherming verwijderen**

Om een vorm te ontgrendelen, stel je de waarde van de toegepaste vergrendeling in op `false`. De volgende code‑voorbeeld toont hoe je vormen in een vergrendelde presentatie kunt ontgrendelen.

```cs
// Instantieer de Presentation‑klasse die een PPTX‑bestand voorstelt.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Doorloop alle dia's in de presentatie.
foreach (ISlide slide in presentation.Slides)
{
    // Doorloop alle vormen in de dia.
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

// Sla het presentatie‑bestand op.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusie**

Aspose.Slides biedt verschillende mogelijkheden om vormen in een presentatie te beveiligen. Je kunt een individuele vorm vergrendelen of door alle vormen in een presentatie itereren en elk afzonderlijk vergrendelen om het volledige bestand effectief te beveiligen. Je kunt de bescherming verwijderen door de vergrendelingswaarde op `false` te zetten.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vergrendelingen beperken het bewerken van objecten binnen het bestand, terwijl [password protection](/slides/nl/net/password-protected-presentation/) de toegang regelt tot het openen en/of opslaan van wijzigingen. Deze mechanismen vullen elkaar aan en werken samen.

**Kan ik het bewerken op specifieke dia’s beperken zonder de andere te beïnvloeden?**

Ja. Pas vergrendelingen toe op de vormen van de geselecteerde dia’s; de overige dia’s blijven bewerkbaar.

**Worden vormvergrendelingen ook toegepast op gegroepeerde objecten en connectoren?**

Ja. Er worden speciale vergrendelingstypes ondersteund voor groepen, connectoren, grafische objecten en andere vormsoorten.