---
title: Dia's toevoegen aan presentaties in JavaScript
linktitle: Dia toevoegen
type: docs
weight: 10
url: /nl/nodejs-java/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides for Node.js via Java — naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's toe te voegen aan PowerPoint‑presentaties via code. Een presentatie bevat master‑/lay‑outdia's en normale dia's, en normale dia's worden gerangschikt op basis van een nulgebaseerde index. Elke dia heeft een unieke ID, en presentaties zonder dia's worden niet ondersteund.

Dit artikel legt uit hoe u een `Presentation`‑object maakt, de collectie dia's benadert, een lege dia toevoegt, werkt met de zojuist toegevoegde dia, en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde zaken zoals het invoegen van dia's op een specifieke positie, het gebruik van lay‑outs, en het begrijpen van de lege dia die aanwezig is in een nieuw gemaakte presentatie.

## **Dia toevoegen aan presentatie**

Voordat we praten over het toevoegen van dia's aan presentatiebestanden, laten we enkele feiten over dia's bespreken. Elk PowerPoint‑presentatiebestand bevat een **Master / Lay‑out**‑dia en andere **Normale** dia's. Dit betekent dat een presentatiebestand ten minste één of meer dia's bevat. Het is belangrijk te weten dat presentaties zonder dia's niet worden ondersteund door Aspose.Slides for Node.js via Java. Elke dia heeft een unieke Id en alle normale dia's worden gerangschikt in een volgorde bepaald door de nulgebaseerde index.

Aspose.Slides for Node.js via Java maakt het ontwikkelaars mogelijk om lege dia's aan hun presentatie toe te voegen. Volg de onderstaande stappen om een lege dia toe te voegen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)-klasse.
- Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection)-klasse door een verwijzing te zetten naar de [Slides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) (collectie van content‑dia‑objecten) eigenschap die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)-object.
- Voeg een lege dia toe aan de presentatie aan het einde van de collectie content‑dia's door de [**addEmptySlide**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-)‑methode aan te roepen die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection)-object.
- Voer werkzaamheden uit met de zojuist toegevoegde lege dia.
- Schrijf tenslotte het presentatiebestand weg met het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)-object.

```javascript
// Instantieer de Presentation-klasse die het presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Instantieer de SlideCollection-klasse
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Voeg een lege dia toe aan de Slides-collectie
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Voer wat bewerkingen uit op de zojuist toegevoegde dia
    // Sla het PPTX-bestand op naar de schijf
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, en niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en [insert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/insertclone/)-operaties, zodat u een dia op de gewenste index kunt toevoegen in plaats van alleen aan het einde.

**Worden de thema’s/stijlen behouden bij het toevoegen van een dia op basis van een lay‑out?**

Ja. Een lay‑out erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde lay‑out en de bijbehorende master.

**Welke dia is er aanwezig in een nieuwe “lege” presentatie voordat er dia's worden toegevoegd?**

Een nieuw gemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om te overwegen bij het berekenen van invoeg‑indices.

**Hoe kies ik de juiste lay‑out voor een nieuwe dia als de master veel opties heeft?**

Kies over het algemeen de [LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidelayouttype/)). Als zo’n lay‑out ontbreekt, kunt u deze [add it to the master](/slides/nl/nodejs-java/slide-layout/) en vervolgens gebruiken.