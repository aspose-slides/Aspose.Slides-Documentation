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

Aspose.Slides stöder att ta bort noteringsbilder från en presentation. I det här ämnet kommer vi att introducera den här funktionen, inklusive hur man tar bort noteringar och hur man applicerar en stil på noteringsbilder i en presentation. Aspose.Slides låter dig ta bort noteringar från vilken bild som helst och även applicera formatering på befintliga noteringar. Utvecklare kan ta bort noteringar på följande sätt:

- Ta bort noteringar från en specifik bild i en presentation.
- Ta bort noteringar från alla bilder i en presentation.

## **Ta bort noteringar från en bild**
Noteringar för en viss bild kan tas bort som visas i exemplet nedan:

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Tar bort noteringar från den första bilden
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

## **Ta bort noteringar från en presentation**
Noteringar för alla bilder i en presentation kan tas bort som visas i exemplet nedan:

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Tar bort noteringar från alla bilder
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

## **Lägg till en noteringsstil**
[getNotesStyle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) metod har lagts till i [MasterNotesSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterNotesSlide) klassen respektive. Denna egenskap anger stilen för en noteringstext. Implementeringen demonstreras i exemplet nedan.

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
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

## **Vanliga frågor**

**Vilken API‑entitet ger åtkomst till noteringarna för en specifik bild?**

Noteringar nås via bildens noteringshanterare: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslidemanager/) och en [method](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslidemanager/getnotesslide/) som returnerar noteringsobjektet, eller `null` om det inte finns några noteringar.

**Finns det skillnader i noteringsstöd mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97–nyare) och ODP; noteringar stöds i dessa format utan att vara beroende av en installerad kopia av PowerPoint.