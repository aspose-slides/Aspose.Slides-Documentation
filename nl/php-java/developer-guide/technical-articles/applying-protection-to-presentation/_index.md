---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in PHP
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 60
url: /nl/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor PHP via Java om selectie, verplaatsing, groottewijziging en groeperen te beperken."
---
## **Overzicht**

Een veelvoorkomend gebruik van Aspose.Slides voor PHP via Java is het maken, bijwerken en opslaan van PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen zijn georganiseerd op dia's en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen je in staat specifieke bewerkingsacties op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingsframes, videoframes, connectoren en andere elementen die worden gebruikt om een presentatie te bouwen. In Aspose.Slides voor PHP via Java wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypes bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides voor PHP via Java biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) vergrendelt autovormen.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) vergrendelt afbeeldingsframes.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Compatibele presentatieredacteurs gebruiken vormvergrendelingen om individuele bewerkingsacties te beperken. Bestandsversleuteling en schrijfbescherming op documentniveau zijn afzonderlijke [presentatiebeschermingsinstellingen](/slides/nl/php-java/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor PHP via Java biedt de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑klasse om te werken met vormen op een dia.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) aan met `true` voor autovormen, met equivalente vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingsframes. Connectoren gebruiken [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia, en slaat een kopie op met deze toegepaste beperkingen. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en verwijdert de selectie‑, verplaatsings‑ en formaatbeperkingen via [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Het verwijdert ook de groeperingsbeperking door `false` door te geven aan [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bijsnijden van afbeelding behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van links en 8 % van rechts bij, en roept vervolgens [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) aan op de vergrendeling van het afbeeldingsframe. Het doorgeven van `true` beperkt verder bijsnijden en behoudt de bestaande bijsnijding.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` slaat de bijsnijdingsvergrendeling op als `true`. In PowerPoint is het **Crop**‑commando uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) aan op de vergrendeling van de groep om de componenten van het diagram bij elkaar te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` slaat de de‑groeperingsvergrendeling op als `true`. In PowerPoint is het **Ungroup**‑commando uitgeschakeld wanneer het volledige diagram is geselecteerd.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te beoordelen, open je het en lees je het vergrendelingsobject voor elke vorm. De [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks)‑methode retourneert `true` wanneer alle vlaggen op dat object zijn uitgeschakeld en `false` wanneer er minstens één is ingeschakeld. Een groep en zijn onderliggende vormen hebben afzonderlijke vergrendelingsobjecten, dus inspecteer de onderliggende vormen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert de verplaatsing voor autovormen, afbeeldingsframes en groepen. Het controleert ook bijsnijden voor afbeeldingen en de‑groeperen voor groepen. Het rapport geeft de ingeschakelde vlaggen die het herkent weer en markeert vormtypen die niet worden geïnspecteerd.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Stel dat dia 1 van `Sample.pptx` een groep bevat met de naam `Layout` waarvan de de‑groepering vergrendeld is, een afbeelding met de naam `Photo` erin met bijsnijden vergrendeld, en een niet‑vergrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en drukt deze twee regels af:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen bewerkingsvlaggen op vormniveau zonder ze te wijzigen of de presentatie op te slaan. Schrijfbescherming op documentniveau is een afzonderlijke instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides voor PHP via Java stelt je in staat specifieke bewerkingsacties op individuele vormen te beperken of dezelfde beperkingen toe te passen op meerdere dia's. Kies de vergrendelingen die worden ondersteund door elk vormtype, en stel hun waarden in op `false` wanneer je die beperkingen wilt verwijderen.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsacties, terwijl [wachtwoordbeveiliging](/slides/nl/php-java/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Hierdoor worden de vergrendelingsinstellingen op andere dia's niet gewijzigd.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de collectie die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor geneste groepen, volgens de doorloop in het rapportage‑voorbeeld.