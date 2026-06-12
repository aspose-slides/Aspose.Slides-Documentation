---
title: Dia's toevoegen aan presentaties in PHP
linktitle: Dia toevoegen
type: docs
weight: 10
url: /nl/php-java/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides for PHP via Java - naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's aan PowerPoint‑presentaties toe te voegen via code. Een presentatie bevat master‑/layoutdia’s en normale dia’s, en de normale dia’s worden gerangschikt op een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentatiebestanden zonder dia’s worden niet ondersteund.

Dit artikel legt uit hoe u een `Presentation`‑object maakt, toegang krijgt tot de collectie dia’s, een lege dia toevoegt, werkt met de nieuw toegevoegde dia en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde punten zoals het invoegen van dia’s op een specifieke positie, het gebruik van layouts en het begrijpen van de lege dia die bestaat in een nieuw aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**

Voordat we het hebben over het toevoegen van dia’s aan presentatiebestanden, laten we enkele feiten over dia’s bespreken. Elk PowerPoint‑presentatiebestand bevat een **Master / Layout**‑dia en andere **Normale** dia’s. Dit betekent dat een presentatiebestand minstens één of meer dia’s bevat. Het is belangrijk te weten dat presentatiebestanden zonder dia’s niet worden ondersteund door Aspose.Slides for PHP via Java. Elke dia heeft een unieke Id en alle Normale Dia’s worden gerangschikt in een volgorde die wordt bepaald door de nul‑gebaseerde index.

Aspose.Slides for PHP via Java stelt ontwikkelaars in staat om lege dia’s aan hun presentatie toe te voegen. Om een lege dia toe te voegen aan de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse aan.
- Haal het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) object op door de [getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#getSlides--) (verzameling van inhouds‑Slide‑objecten) methode te gebruiken die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) object.
- Voeg een lege dia toe aan de presentatie aan het einde van de verzameling inhouds‑dia’s door de [**addEmptySlide**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/#addEmptySlide) methode aan te roepen die beschikbaar is via het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) object.
- Voer een aantal bewerkingen uit met de nieuw toegevoegde lege dia.
- Schrijf tenslotte het presentatiebestand weg met behulp van het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) object.

```php
  # Maak een instantie van de Presentation‑klasse die het presentatie‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Maak een instantie van de SlideCollection‑klasse
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Voeg een lege dia toe aan de Slides‑collectie
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Voer een aantal bewerkingen uit op de nieuw toegevoegde dia
    # Sla het PPTX‑bestand op de schijf op
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en [insert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/insertclone/)‑bewerkingen, zodat u een dia kunt toevoegen op de gewenste index in plaats van uitsluitend aan het einde.

**Worden thema’s/stijlen behouden bij het toevoegen van een dia op basis van een layout?**

Ja. Een layout erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde layout en de bijbehorende master.

**Welke dia bevindt zich in een nieuwe “lege” presentatie voordat er dia’s worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in acht te nemen bij het berekenen van invoeg‑indices.

**Hoe kies ik de “juiste” layout voor een nieuwe dia als de master veel opties heeft?**

Kies doorgaans de [LayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidelayouttype/)). Als een dergelijke layout ontbreekt, kunt u deze [voeg deze toe aan de master](/slides/nl/php-java/slide-layout/) toevoegen aan de master en vervolgens gebruiken.