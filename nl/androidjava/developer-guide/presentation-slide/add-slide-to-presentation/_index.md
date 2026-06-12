---
title: Dia's toevoegen aan presentaties op Android
linktitle: Dia toevoegen
type: docs
weight: 10
url: /nl/androidjava/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides for Android via Java - naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's toe te voegen aan PowerPoint‑presentaties via programmeercode. Een presentatie bevat master‑/layoutdia's en gewone dia's, en de gewone dia's worden gerangschikt op een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentatiebestanden zonder dia's worden niet ondersteund.

Dit artikel legt uit hoe u een `Presentation`‑object maakt, de diacollectie benadert, een lege dia toevoegt, werkt met de nieuw toegevoegde dia en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde zaken zoals dia's op een specifieke positie invoegen, layouts gebruiken en het begrip van de lege dia die bestaat in een net aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**

Voordat we ingaan op het toevoegen van dia's aan presentatiebestanden, bespreken we eerst enkele feiten over dia's. Elke PowerPoint‑presentatie‑bestand bevat een **Master / Layout**‑dia en andere **Normale** dia's. Dit betekent dat een presentatie‑bestand ten minste één dia bevat. Het is belangrijk te weten dat presentatiebestanden zonder dia's niet worden ondersteund door Aspose.Slides for Android via Java. Elke dia heeft een unieke Id en alle Normale dia's worden gerangschikt volgens een nul‑gebaseerde index.

Aspose.Slides for Android via Java stelt ontwikkelaars in staat om lege dia's aan hun presentatie toe te voegen. Volg de onderstaande stappen om een lege dia toe te voegen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) aan.
- Instantieer de klasse [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) door een verwijzing naar de eigenschap [Slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) (collectie van inhouds‑Slide‑objecten) in te stellen die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑object.
- Voeg een lege dia toe aan de presentatie aan het einde van de collectie inhoudsdia's door de methode [**addEmptySlide**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) aan te roepen die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection)‑object.
- Voer enige bewerkingen uit met de nieuw toegevoegde lege dia.
- Schrijf tenslotte het presentatie‑bestand weg met behulp van het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑object.

```java
// Instantie van de Presentation-klasse die het presentiebestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Instantie van de SlideCollection-klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Voeg een lege dia toe aan de Slides-collectie
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Voer wat bewerkingen uit op de nieuw toegevoegde dia

    // Sla het PPTX-bestand op naar de schijf
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt diacollecties en de [insert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑operaties, zodat u een dia kunt toevoegen op de gewenste index in plaats van alleen aan het einde.

**Worden thema’s/opmaak bewaard bij het toevoegen van een dia op basis van een layout?**

Ja. Een layout erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde layout en de bijbehorende master.

**Welke dia bevindt zich in een nieuwe “lege” presentatie voordat er dia's worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in overweging te nemen bij het berekenen van invoeg‑indices.

**Hoe kies ik de “juiste” layout voor een nieuwe dia als de master veel opties heeft?**

Kies doorgaans de [LayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur ([Titel en inhoud, Twee inhoud, enz.](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidelayouttype/)). Als zo’n layout ontbreekt, kunt u deze [aan de master toevoegen](/slides/nl/androidjava/slide-layout/) en vervolgens gebruiken.