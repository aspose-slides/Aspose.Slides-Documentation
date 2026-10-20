---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in Node.js
linktitle: Beperk presentatie-bewerkingen
type: docs
weight: 60
url: /nl/nodejs-java/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte wijzigen vergrendelen
- groeperen vergrendelen
- PowerPoint
- PPTX
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor Node.js via Java om selectie, verplaatsing, wijziging van grootte en groeperen te beperken."
---
## **Overzicht**

Een veelvoorkomend gebruik van Aspose.Slides voor Node.js via Java is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen zijn georganiseerd op dia’s en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een dia van een presentatie bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, videokaders, connectors en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides voor Node.js via Java wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides voor Node.js via Java biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) vergrendelt autovormen.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) vergrendelt connector‑vormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), doorloopt u de dia’s en stelt u de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Bescherming toepassen en verwijderen**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en wijzigen van de grootte van vormen. Ze maken de hele presentatie niet onveranderbaar.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor Node.js via Java biedt de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

In het voorbeeld worden [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) aangeroepen met `true` voor autovormen, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectors en afbeeldingskaders. Connectors gebruiken [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het onderstaande voorbeeld laadt een presentatie met vormvergrendelingen en wist de selecteer‑, verplaats‑ en grootte‑beperkingen via [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Het verwijdert tevens de groeperingsbeperking door `false` door te geven aan [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusie**

Aspose.Slides voor Node.js via Java stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen op meerdere dia’s toe te passen. Kies de vergrendelingen die ondersteund worden door elk type vorm en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [password protection](/slides/nl/nodejs-java/password-protected-presentation/) de opening of wijziging van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerkingen op specifieke dia’s beperken zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia’s. Dit verandert de vergrendelingsinstellingen op andere dia’s niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Loop door de collectie die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, dus ze stellen geen vergrendelingen in voor individuele groepsleden.