---
title: Beperk presentatiewijzigingen met vormvergrendelingen in PHP
linktitle: Beperk presentatiewijzigingen
type: docs
weight: 60
url: /nl/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for PHP via Java om selectie, verplaatsing, grootte‑aanpassing en groeperen te beperken."
---
## **Overzicht**

Een veelvoorkomend gebruik van Aspose.Slides for PHP via Java is het maken, bijwerken en opslaan van PowerPoint (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

In dit artikel wordt uitgelegd hoe vormen zijn georganiseerd op dia's en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen laten je specifieke bewerkingsoperaties op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, videokaders, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for PHP via Java wordt elk element op een dia vertegenwoordigd door een object dat erft van de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for PHP via Java biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) vergrendelt autovormen.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen op een volledige [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en wijzigen van de grootte van vormen. Ze maken de volledige presentatie niet onbewerkbaar.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for PHP via Java biedt de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) aan met `true` voor autovormen, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingskaders. Connectoren gebruiken [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormcollectie van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier verwerkte typen blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

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

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en grootte‑beperkingen via [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), en [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Het verwijdert ook de groeperingsbeperking door `false` door te geven aan [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Conclusie**

Aspose.Slides for PHP via Java stelt je in staat om specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund en stel hun waarden in op `false` wanneer je die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsoperaties, terwijl [wachtwoordbeveiliging](/slides/nl/php-java/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerkingen beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de collectie die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormcollectie van de dia, dus ze stellen geen vergrendelingen in voor individuele groepsleden.