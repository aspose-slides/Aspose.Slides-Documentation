---
title: Voorkom bewerkingen van presentaties met vormvergrendelingen
linktitle: Voorkom bewerkingen van presentaties
type: docs
weight: 60
url: /nl/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Java vormen in PPT-, PPTX- en ODP-bestanden vergrendelt of ontgrendelt, waardoor presentaties worden beveiligd terwijl gecontroleerde bewerkingen mogelijk zijn en een snellere levering wordt bereikt."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides is het maken, bijwerken en opslaan van Microsoft PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Gebruikers van applicaties die Aspose.Slides op deze manier inzetten, hebben toegang tot de gegenereerde presentaties, dus het beschermen tegen bewerking is een veelvoorkomend zorgpunt. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit artikel legt uit hoe presentaties en dia's zijn gestructureerd en hoe Aspose.Slides for Java bescherming kan toepassen op een presentatie en deze later kan verwijderen. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun applicaties genereren, worden gebruikt.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE-objecten, gegroepeerde vormen, afbeeldingframes, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Java wordt elk element op een dia vertegenwoordigd door een object dat de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface implementeert of ervan erft.

De structuur van PPTX is complex, dus in tegenstelling tot PPT, waar een generieke vergrendeling voor alle vormtypen kan worden gebruikt, vereisen verschillende vormtypen verschillende vergrendelingen. De [IBaseShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseshapelock/) interface is de generieke vergrendelingsklasse voor PPTX. De volgende soorten vergrendelingen worden ondersteund in Aspose.Slides for Java voor PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/) vergrendelt afbeeldingframes.  

Elke handeling die wordt uitgevoerd op alle vormobjecten in een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) object, wordt toegepast op de volledige presentatie.

## **Bescherming toepassen en verwijderen**

Het toepassen van bescherming zorgt ervoor dat een presentatie niet bewerkt kan worden. Het is een handige techniek om de inhoud van de presentatie te beveiligen.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Java biedt de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface om met vormen op een dia te werken.

Zoals eerder vermeld, heeft elke vormklasse een gekoppelde shape-lock-klasse voor bescherming. Dit artikel richt zich op de NoSelect-, NoMove- en NoResize-vergrendelingen. Deze vergrendelingen zorgen ervoor dat vormen niet geselecteerd kunnen worden (via muisklikken of andere selectiemethoden) en dat ze niet verplaatst of van grootte kunnen worden veranderd.

De volgende codevoorbeelden passen bescherming toe op alle vormtypen in een presentatie.

```java
// Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
Presentation presentation = new Presentation("Sample.pptx");

// Doorloop alle dia's in de presentatie.
for (ISlide slide : presentation.getSlides()) {

    // Doorloop alle vormen in de dia.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Cast de vorm naar een autovorm en verkrijg de vormvergrendeling.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Cast de vorm naar een gegroepeerde vorm en verkrijg de vormvergrendeling.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Cast de vorm naar een connectorvorm en verkrijg de vormvergrendeling.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Cast de vorm naar een afbeeldingframe en verkrijg de vormvergrendeling.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Sla het presentatiebestand op.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bescherming verwijderen**

Om een vorm te ontgrendelen, stel je de waarde van de toegepaste vergrendeling in op `false`. Het volgende codevoorbeeld laat zien hoe je vormen in een vergrendelde presentatie kunt ontgrendelen.

```java
// Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Doorloop alle dia's in de presentatie.
for (ISlide slide : presentation.getSlides()) {

    // Doorloop alle vormen in de dia.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Cast de vorm naar een autovorm en verkrijg de vormvergrendeling.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Cast de vorm naar een gegroepeerde vorm en verkrijg de vormvergrendeling.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Cast de vorm naar een connectorvorm en verkrijg de vormvergrendeling.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Cast de vorm naar een afbeeldingframe en verkrijg de vormvergrendeling.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Sla het presentatiebestand op.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Conclusie**

Aspose.Slides biedt verschillende opties om vormen in een presentatie te beschermen. Je kunt een individuele vorm vergrendelen of door alle vormen in een presentatie itereren en elke vorm vergrendelen om het hele bestand effectief te beveiligen. Je kunt de bescherming verwijderen door de vergrendelingswaarde in te stellen op `false`.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vergrendelingen beperken het bewerken van objecten binnen het bestand, terwijl [password protection](/slides/nl/java/password-protected-presentation/) de toegang tot het openen en/of opslaan van wijzigingen beheert. Deze mechanismen vullen elkaar aan en werken samen.

**Kan ik bewerken beperken op specifieke dia’s zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen toe op de vormen op de geselecteerde dia’s; de overige dia’s blijven bewerkbaar.

**Geldt vormvergrendeling voor gegroepeerde objecten en connectoren?**

Ja. Er worden speciale vergrendelingssoorten ondersteund voor groepen, connectoren, grafische objecten en andere vormcategorieën.