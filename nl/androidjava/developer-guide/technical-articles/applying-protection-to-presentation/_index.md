---
title: Beperk bewerkingen van presentaties met vormvergrendelingen op Android
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 60
url: /nl/androidjava/applying-protection-to-presentation/
keywords:
- voorkom bewerkingen
- bescherm tegen bewerken
- vergrendel vorm
- vergrendel positie
- vergrendel selectie
- vergrendel grootte wijzigen
- vergrendel groeperen
- PowerPoint
- PPTX
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u vormen kunt vergrendelen en ontgrendelen in PPTX‑presentaties met Aspose.Slides voor Android via Java om selectie, verplaatsing, grootte‑aanpassing en groeperen te beperken."
---
## **Overzicht**

Een veelvoorkomend gebruik van Aspose.Slides voor Android via Java is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia’s zijn georganiseerd en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen laten je specifieke bewerkingsbewerkingen op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeelding‑frames, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides voor Android via Java wordt elk element op een dia vertegenwoordigd door een object dat de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑interface implementeert of van een klasse erft die dat doet.

Verschillende vormtypes bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interface is de basinterface voor vormvergrendelingen. Aspose.Slides voor Android via Java levert de volgende vergrendelingsinterfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) vergrendelt autovormen.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) vergrendelt connectorvormen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) vergrendelt afbeelding‑frames.  

Om vergrendelingen toe te passen over een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), doorloop je de dia’s en stel je de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Compatibele presentatieditoren gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestand‑encryptie en schrijfbeveiliging op documentniveau zijn afzonderlijke [presentatiebeveiligingsinstellingen](/slides/nl/androidjava/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor Android via Java biedt de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), en [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) aan met `true` voor autovormen, met equivalente vergrendelingen voor gegroepeerde vormen, connectoren en afbeelding‑frames. Connectoren gebruiken [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormcollectie van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier verwerkte types blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

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

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en groottelimieten via [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), en [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Het verwijdert ook de groeperingsbeperking door `false` door te geven aan [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Een afbeelding‑bijsnijding behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en roept vervolgens [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) aan op de vergrendeling van het afbeelding‑frame. Het doorgeven van `true` beperkt verdere bijsnijding en behoudt de bestaande bijsnijding.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` slaat de bijsnijdingsvergrendeling op als `true`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto geselecteerd is.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) aan op de vergrendeling van de groep om de componenten van het diagram samen te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

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

`DiagramLocked.pptx` slaat de ontgroeperingsvergrendeling op als `true`. In PowerPoint is de **Ungroup**‑opdracht uitgeschakeld wanneer het hele diagram geselecteerd is.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te beoordelen, open je deze en lees je het vergrendelingsobject voor elke vorm. De [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) methode geeft `true` terug wanneer alle vlaggen op dat object zijn uitgeschakeld en `false` wanneer er minimaal één is ingeschakeld. Een groep en zijn onderliggende elementen hebben afzonderlijke vergrendelingsobjecten, dus controleer de onderliggende elementen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert verplaatsing voor autovormen, afbeelding‑frames en groepen. Het controleert ook bijsnijding voor afbeeldingen en ontgroeperen voor groepen. Het rapport vermeldt de ingeschakelde vlaggen die het herkent en markeert vormtypes die niet worden geïnspecteerd.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

Stel dat dia 1 van `Sample.pptx` een groep met de naam `Layout` bevat waarbij ontgroeperen vergrendeld is, een afbeelding met de naam `Photo` erin waarbij bijsnijden vergrendeld is, en een ontgrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en drukt deze twee regels af:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen vorm‑specifieke bewerkingsvlaggen zonder ze te wijzigen of de presentatie op te slaan. Schrijfbeveiliging op documentniveau is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides voor Android via Java stelt je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia’s toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund en stel hun waarden in op `false` wanneer je die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/androidjava/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking op specifieke dia’s beperken zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia’s. Dit verandert de vergrendelingsinstellingen op andere dia’s niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de collectie die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen, volgens de traversering in het rapportage‑voorbeeld.