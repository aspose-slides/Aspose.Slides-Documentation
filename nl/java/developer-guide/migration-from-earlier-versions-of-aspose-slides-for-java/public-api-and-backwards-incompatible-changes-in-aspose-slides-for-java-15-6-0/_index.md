---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.6.0
linktitle: Aspose.Slides voor Java 15.6.0
type: docs
weight: 140
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) geïntroduceerd met de Aspose.Slides for Java 15.6.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
De handtekening van de constructor is gewijzigd van DataLabel(com.aspose.slides.IChartSeries) naar DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Methoden IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) zijn gemarkeerd als verouderd. In plaats daarvan zijn de methoden IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) geïntroduceerd.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Methode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() is toegevoegd om een notitieslideshow van een dia te verwijderen.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Methoden ISlide.getNotesSlide() en ISlide.addNotesSlide() zijn gemarkeerd als verouderd. Gebruik in plaats daarvan de nieuwe methode ISlide.getNotesSlideManager().
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - verouderd

    // notes = slide.getNotesSlide(); - verouderd

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Methode com.aspose.slides.IDocumentProperties.getAppVersion() is toegevoegd om de ingebouwde documenteigenschap op te vragen die de interne versienummers van Microsoft PowerPoint weergeeft.
#### **Method remove() has been added to com.aspose.slides.IComment**
Methode com.aspose.slides.IComment.remove() is toegevoegd om een opmerking uit de collectie te verwijderen.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Methode ICommentAuthor.Remove is toegevoegd om een auteur van opmerkingen uit de collectie te verwijderen.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Methode com.aspose.slides.IDocumentProperties.clearCustomProperties() is toegevoegd om alle aangepaste documenteigenschappen te verwijderen.  
Methode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() is toegevoegd om alle ingebouwde documenteigenschappen (Company, Subject, Author etc.) te verwijderen en hun standaardwaarden in te stellen.
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Methoden getBlackWhiteMode(), setBlackWhiteMode(byte) zijn toegevoegd aan com.aspose.slides.IShape.  
De methoden geven aan hoe een vorm wordt weergegeven in zwart‑wit modus. De mogelijke waarden worden gespecificeerd in de klasse com.aspose.slides.BlackWhiteMode.

|**Waarde** |**Betekenis** |
| :- | :- |
|Color |Return with normal coloring |
|Automatic |Return with automatic coloring |
|Gray |Return with gray coloring |
|LightGray |Return with light gray coloring |
|InverseGray |Return with inverse gray coloring |
|GrayWhite |Return with gray and white coloring |
|BlackGray |Return with black and gray coloring |
|BlackWhite |Return with black and white coloring |
|Black |Return only with black coloring |
|White |Return with white coloring |
|Hidden |The object is not rendered |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Methode ICommentAuthorCollection.removeAt(int) is toegevoegd om een auteur op een opgegeven index te verwijderen. Methode ICommentAuthorCollection.remove(ICommentAuthor) is toegevoegd om een opgegeven auteur uit de collectie te verwijderen. Methode ICommentAuthorCollection.clear() is toegevoegd om alle items uit de collectie te verwijderen.