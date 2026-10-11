---
title: Beheer presentatienotities in PHP
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/php-java/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor PHP via Java. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp zullen we deze functie introduceren, inclusief hoe je notities kunt verwijderen en hoe je een stijl kunt toepassen op notitieslides in een presentatie. Aspose.Slides stelt je in staat notities van elke slide te verwijderen en ook stijl toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke slide in een presentatie.
- Verwijder notities van alle slides in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te schakelen en het exportgedrag te controleren, zie [Notes Page Size](/slides/nl/php-java/notes-size/).

## **Notities van een slide verwijderen**
Notities van een specifieke slide kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Notities van de eerste slide verwijderen
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

## **Notities uit een presentatie verwijderen**
Notities van alle slides in een presentatie kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Notities van alle slides verwijderen
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
De [getNotesStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterNotesSlide#getNotesStyle)‑methode van de [MasterNotesSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterNotesSlide)‑klasse biedt toegang tot de tekstopmaak van notities. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```php
  # Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Haal de tekststijl van MasterNotesSlide op
      $notesStyle = $notesMaster->getNotesStyle();
      # Stel een symboolbullet in voor de alinea's van het eerste niveau
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

## **Veelgestelde vragen**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke slide?**

Notities worden benaderd via de notitie‑manager van de slide: de slide heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslidemanager/getnotesslide/) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder afhankelijk te zijn van een geïnstalleerde kopie van PowerPoint.