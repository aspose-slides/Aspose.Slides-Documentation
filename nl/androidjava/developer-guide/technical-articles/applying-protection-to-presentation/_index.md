---
title: Beperk bewerkingen van presentaties met vormvergrendelingen op Android
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 60
url: /nl/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Android via Java om selectie, verplaatsing, grootte-aanpassing en groepering te beperken."
---
## **Overzicht**

Een veelvoorkomende toepassing van Aspose.Slides for Android via Java is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia’s worden georganiseerd en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat om specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingsframes, videoframes, connectors en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Android via Java wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface implementeert of van een klasse erft die dat doet.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interface is de basisinterface voor vormvergrendelingen. Aspose.Slides for Android via Java biedt de volgende vergrendelings‑interfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) vergrendelt connector‑vormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) vergrendelt afbeeldingsframes.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), doorloopt u de dia’s en stelt u de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en van grootte wijzigen van vormen. Ze maken de volledige presentatie niet onbewerkbaar.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Android via Java biedt de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) en [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) aan met `true` voor autovormen, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectors en afbeeldingsframes. Connectors gebruiken [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) voor beweging; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en grootte‑beperkingen via [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) en [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Het verwijdert tevens de groeperingsbeperking door `false` door te geven aan [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusie**

Aspose.Slides for Android via Java stelt u in staat om specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia’s toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/androidjava/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking beperken op specifieke dia’s zonder andere dia’s te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia’s. Dit verandert de vergrendelingsinstellingen op andere dia’s niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de verzameling die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, dus ze stellen geen vergrendelingen in voor individuele groepsleden.