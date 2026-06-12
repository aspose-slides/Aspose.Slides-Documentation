---
title: "Dia's toevoegen aan presentaties in Java"
linktitle: "Dia toevoegen"
type: docs
weight: 10
url: /nl/java/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java—naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's programmatisch toe te voegen aan PowerPoint‑presentaties. Een presentatie bevat master‑/lay‑outdia’s en gewone dia’s, en gewone dia’s worden geordend volgens een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentaties zonder dia’s worden niet ondersteund.

Dit artikel legt uit hoe u een `Presentation`‑object maakt, toegang krijgt tot de diapcollectie, een lege dia toevoegt, met de nieuw toegevoegde dia werkt en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde zaken, zoals het invoegen van dia’s op een specifieke positie, het gebruik van lay‑outs, en het begrijpen van de lege dia die aanwezig is in een net aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**

Voordat we ingaan op het toevoegen van dia’s aan presentatiebestanden, bespreken we eerst enkele feiten over dia’s. Elk PowerPoint‑presentatiebestand bevat **Master / Layout**‑dia’s en andere **Normale** dia’s. Dat betekent dat een presentatiebestand minstens één dia bevat. Het is belangrijk om te weten dat presentaties zonder dia’s niet worden ondersteund door Aspose.Slides for Java. Elke dia heeft een unieke Id en alle normale dia’s worden gerangschikt volgens een nul‑gebaseerde index.

Aspose.Slides for Java maakt het voor ontwikkelaars mogelijk om lege dia’s aan hun presentatie toe te voegen. Volg de onderstaande stappen om een lege dia toe te voegen aan de presentatie:

- Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) aan.
- Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection) door een referentie in te stellen naar de [Slides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) (collectie van inhoudsdia‑objecten) eigenschap van het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) object.
- Voeg een lege dia toe aan het einde van de collectie inhoudsdia’s door de **addEmptySlide**‑methode van het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection) object aan te roepen.
- Voer wat bewerkingen uit met de nieuw toegevoegde lege dia.
- Schrijf ten slotte het presentatie‑bestand weg met het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) object.

```java
// Maak een instantie van de Presentation-klasse die het presentatie-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Maak een instantie van de SlideCollection-klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Voeg een lege dia toe aan de Slides-collectie
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Voer wat bewerkingen uit op de nieuw toegevoegde dia

    // Sla het PPTX-bestand op op de schijf
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en [insert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) bewerkingen, zodat u een dia kunt toevoegen op de gewenste index in plaats van alleen aan het einde.

**Worden de thema’s/stijlen behouden bij het toevoegen van een dia op basis van een lay‑out?**

Ja. Een lay‑out erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde lay‑out en de bijbehorende master.

**Welke dia bevindt zich in een nieuwe “lege” presentatie voordat er dia’s worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in gedachten te houden bij het berekenen van invoeg‑indices.

**Hoe kies ik de “juiste” lay‑out voor een nieuwe dia als de master veel opties heeft?**

Kies over het algemeen de [LayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslide/) die overeenkomt met de benodigde structuur ([Titel en Inhoud, Twee Inhoud, enz.](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidelayouttype/)). Als zo’n lay‑out ontbreekt, kunt u deze [aan de master toevoegen](/slides/nl/java/slide-layout/) en daarna gebruiken.