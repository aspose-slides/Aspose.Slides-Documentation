---
title: Begränsa redigering av presentationer med lås på former i PHP
linktitle: Begränsa redigering av presentationer
type: docs
weight: 60
url: /sv/php-java/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides for PHP via Java för att begränsa urval, förflyttning, storleksändring och gruppering."
---
## **Översikt**

En vanlig användning av Aspose.Slides for PHP via Java är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan det hjälpa att begränsa ändringar av former för att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former är organiserade på bilder och hur du applicerar och tar bort lås för former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for PHP via Java representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Olika formtyper erbjuder olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) är basklassen för lås på former. Aspose.Slides for PHP via Java tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) låser bildramar.  

För att applicera lås på en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), itererar du genom dess bilder och ställer in lämpliga lås på varje stödjande form.

## **Tillämpa och ta bort skydd**

Lås på former begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oredigerbar.

### **Tillämpa skydd på PPTX-former**

Aspose.Slides for PHP via Java tillhandahåller klassen [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) och [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) med `true` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) för förflyttning; grupper använder också [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte de underliggande formerna i en grupp.

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

### **Ta bort skydd**

För att ta bort ett lås på en form sätter du dess värde till `false`. Följande exempel läser in en presentation med lås på former och rensar urval, förflyttning och storleksändringsbegränsningar via [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), och [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Det tar också bort grupperingbegränsningen genom att skicka `false` till [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

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

### **Slutsats**

Aspose.Slides for PHP via Java låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar på alla bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera lås på former och lösenordsskydd i samma presentation?**

Ja. Lås på former begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/php-java/password-protected-presentation/) kan begränsa öppning eller modifiering av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Applicera lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag applicera lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens metod [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) och applicera lämpliga lås på varje underliggande form. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.