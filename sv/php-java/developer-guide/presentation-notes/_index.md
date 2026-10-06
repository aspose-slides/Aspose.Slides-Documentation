---
title: Hantera presentationsanteckningar i PHP
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/php-java/presentation-notes/
keywords:
- anteckningar
- anteckningsbild
- lägg till anteckningar
- ta bort anteckningar
- anteckningsstil
- masteranteckningar
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för PHP via Java. Arbeta sömlöst med PowerPoint- och OpenDocument-anteckningar för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder att ta bort anteckningsbilder från en presentation. I det här avsnittet introducerar vi funktionen, inklusive hur man tar bort anteckningar och hur man applicerar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och även tillämpa stil på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

För att läsa eller ändra anteckningssidans dimensioner, byta orientering och kontrollera exportbeteende, se [Notssida storlek](/slides/sv/php-java/notes-size/).

## **Ta bort anteckningar från en bild**
Anteckningar från en specifik bild kan tas bort enligt exemplet nedan:

```php
  # Skapa ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Tar bort anteckningar från den första bilden
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Sparar presentationen till disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort anteckningar från en presentation**
Anteckningar från alla bilder i en presentation kan tas bort enligt exemplet nedan:

```php
  # Skapa ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Tar bort anteckningar från alla bilder
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Sparar presentationen till disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en anteckningsstil**
Metoden [getNotesStyle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) i klassen [MasterNotesSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterNotesSlide) ger åtkomst till anteckningstextens stil. Implementeringen demonstreras i exemplet nedan.

```php
  # Skapa ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Hämta MasterNotesSlide-textstil
      $notesStyle = $notesMaster->getNotesStyle();
      # Ställ in symbolpunkt för stycken på första nivån
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

**Vilken API‑entitet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningarna nås via bildens anteckningshanterare: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslidemanager/) och en [method](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslidemanager/getnotesslide/) som returnerar anteckningsobjektet, eller `null` om det inte finns några anteckningar.

**Finns det skillnader i anteckningsstöd mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97–nyare) och ODP; anteckningar stöds i dessa format utan att kräva en installerad kopia av PowerPoint.