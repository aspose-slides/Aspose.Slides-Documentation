---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in Java
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 60
url: /nl/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties met Aspose.Slides for Java kunt vergrendelen en ontgrendelen om selectie, verplaatsing, grootte-aanpassing en groeperen te beperken."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides for Java is het maken, bijwerken en opslaan van PowerPoint (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay-out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe vormvergrendelingen toe te passen en te verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, videokaders, connectoren en andere elementen die worden gebruikt om een presentatie te bouwen. In Aspose.Slides for Java wordt elk element op een dia vertegenwoordigd door een object dat de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑interface implementeert of ervan erft.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) interface is de basisklasse voor vormvergrendelingen. Aspose.Slides for Java levert de volgende vergrendelingsinterfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen over een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Vergrendeling toepassen en verwijderen**

Compatibele presentatieredacties gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestandscodering en schrijfbescherming op documentniveau zijn aparte [wachtwoordbeveiliging](/slides/nl/java/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Java biedt de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) en [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) aan met `true` voor autovormen, met equivalente vergrendelingen voor groep‑vormen, connectoren en afbeeldingskaders. Connectoren gebruiken [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selecteer‑, verplaats‑ en formaatbeperkingen via [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) en [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Het verwijdert ook de groeperingsbeperking door `false` door te geven aan [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Afbeeldings‑crop behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en roept vervolgens [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) aan op de vergrendeling van het afbeeldingskader. Het doorgeven van `true` beperkt verdere bijsnijden en behoudt de bestaande crop.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` slaat de crop‑vergrendeling op als `true`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) aan op de vergrendeling van de groep om de componenten van het diagram samen te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de opvulling van een component, blijven beschikbaar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` slaat de ungroup‑vergrendeling op als `true`. In PowerPoint is de **Ungroup**‑opdracht uitgeschakeld wanneer het volledige diagram is geselecteerd.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te beoordelen, open je deze en lees je het vergrendelingsobject voor elke vorm. De [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--)‑methode geeft `true` terug wanneer alle vlaggen op dat object zijn uitgeschakeld en `false` wanneer er minstens één is ingeschakeld. Een groep en zijn onderliggende vormen hebben afzonderlijke vergrendelingsobjecten, controleer dus de onderliggende vormen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert de verplaatsing voor autovormen, afbeeldingskaders en groepen. Het controleert ook de bijsnijding voor afbeeldingen en het ontgroeperen voor groepen. Het rapport vermeldt de ingeschakelde vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Stel dat dia 1 van `Sample.pptx` een groep met de naam `Layout` bevat met een vergrendeld ontgroeperen, een foto met de naam `Photo` erin met een vergrendelde bijsnijding, en een ontgrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en toont deze twee regels:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen vorm‑specifieke bewerkingsvlaggen zonder ze te wijzigen of de presentatie op te slaan. Schrijfbescherming op documentniveau is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides for Java stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia’s toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/java/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerkingen op specifieke dia's beperken zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de verzameling die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen, volgens de doorloop in het rapportagevoorbeeld.