---
title: Beheer presentatienotities in PHP
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/php-java/presentation-notes/
keywords:
- notities
- notitiesdia
- notities toevoegen
- notities verwijderen
- notitiestijl
- hoofnotities
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor PHP via Java. Werk moeiteloos met PowerPoint- en OpenDocument-notities om je productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt je in staat notities van elke dia te verwijderen en ook styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke dia in een presentatie.
- Verwijder notities van alle dia's in een presentatie.

## **Notities van een dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Verwijderen van notities van de eerste dia
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Presentatie opslaan op schijf
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Notities van een presentatie verwijderen**
Notities van alle dia's van een presentatie kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Verwijderen van notities van alle dia's
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Presentatie opslaan op schijf
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een notitiestijl toevoegen**
[getNotesStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) methode is toegevoegd aan de [MasterNotesSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterNotesSlide) klasse respectievelijk. Deze eigenschap specificeert de stijl van een notitietekst. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Haal MasterNotesSlide-tekststijl op
      $notesStyle = $notesMaster->getNotesStyle();
      # Stel symbool-bullet in voor de alinea's van het eerste niveau
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitie‑manager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslidemanager/getnotesslide/) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in ondersteuning van notities tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteerd in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.