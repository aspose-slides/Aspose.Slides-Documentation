---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in .NET
linktitle: Beperk bewerkingen van presentaties
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
- PPTX
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor .NET om selectie, verplaatsing, grootte aanpassen en groeperen te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides for .NET is het creëren, bijwerken en opslaan van PowerPoint (PPTX)‑presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen om de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingsframes, videoframes, connectoren en andere elementen die gebruikt worden om een presentatie samen te stellen. In Aspose.Slides for .NET wordt elk element op een dia vertegenwoordigd door een object dat de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑interface implementeert of ervan erft.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/)‑interface is de basisklasse voor vormvergrendelingen. Aspose.Slides for .NET biedt de volgende vergrendelings‑interfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) vergrendelt autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) vergrendelt connector‑vormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) vergrendelt afbeeldingsframes.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), doorloopt u de dia's en stelt u de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Vergrendeling toepassen en verwijderen**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en van grootte veranderen van vormen. Ze maken de gehele presentatie niet onbewerkbaar.

### **Vergrendeling toepassen op PPTX‑vormen**

Aspose.Slides for .NET biedt de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑interface om met vormen op een dia te werken.

Het voorbeeld stelt [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) en [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) in op `true` voor autoshapes, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingsframes. Connectoren gebruiken [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) voor verplaatsing; groepen gebruiken tevens [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

### **Vergrendeling verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selecteer‑, verplaats‑ en grootte‑beperkingen via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) en [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Het wist tevens [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Conclusie**

Aspose.Slides for .NET stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over meerdere dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [password protection](/slides/nl/net/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking op specifieke dia's beperken zonder de andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑verzameling van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, waardoor geen vergrendelingen op individuele groepsleden worden ingesteld.