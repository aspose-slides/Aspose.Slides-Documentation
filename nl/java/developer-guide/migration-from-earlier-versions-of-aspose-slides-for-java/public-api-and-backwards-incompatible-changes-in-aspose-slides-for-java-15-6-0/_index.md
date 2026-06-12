---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.6.0
linktitle: Aspose.Slides voor Java 15.6.0
type: docs
weight: 140
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatie-oplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina toont alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) klassen, methoden, eigenschappen en zo verder, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) geïntroduceerd met de Aspose.Slides for Java 15.6.0 API.

{{% /alert %}} 
## **Publieke API-wijzigingen**
#### **Handtekening van de constructor van com.aspose.slides.DataLabel is gewijzigd**
De handtekening van de constructor is gewijzigd van DataLabel(com.aspose.slides.IChartSeries) naar DataLabel(com.aspose.slides.IChartDataPoint).
#### **Leden com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) zijn gemarkeerd als verouderd; vervangingen zijn geïntroduceerd**
Methoden IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) zijn gemarkeerd als verouderd. In plaats daarvan zijn de methoden IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) geïntroduceerd.
#### **Methode com.aspose.slides.INotesSlideManager.removeNotesSlide() is toegevoegd**
Methode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() is toegevoegd om de notitieslide van een slide te verwijderen.
#### **Methode com.aspose.slides.ISlide.getNotesSlideManager() is toegevoegd. Methodes ISlide.getNotesSlide() en ISlide.addNotesSlide() zijn gemarkeerd als verouderd**
Methoden ISlide.getNotesSlide() en ISlide.addNotesSlide() zijn gemarkeerd als verouderd. Gebruik in plaats daarvan de nieuwe methode ISlide.getNotesSlideManager().

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - verouderd

// notes = slide.getNotesSlide(); - verouderd

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Methode getAppVersion() is toegevoegd aan com.aspose.slides.IDocumentProperties**
Methode com.aspose.slides.IDocumentProperties.getAppVersion() is toegevoegd om de ingebouwde documenteigenschap op te halen die de interne versienummers van Microsoft PowerPoint weergeeft.
#### **Methode remove() is toegevoegd aan com.aspose.slides.IComment**
Methode com.aspose.slides.IComment.remove() is toegevoegd om een opmerking uit de collectie te verwijderen.
#### **Methode remove() is toegevoegd aan com.aspose.slides.ICommentAuthor**
Methode ICommentAuthor.Remove is toegevoegd om de auteur van opmerkingen uit de collectie te verwijderen.
#### **Methoden clearCustomProperties() en clearBuiltInProperties() zijn toegevoegd aan com.aspose.slides.IDocumentProperties**
Methode com.aspose.slides.IDocumentProperties.clearCustomProperties() is toegevoegd om alle aangepaste documenteigenschappen te verwijderen.
Methode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() is toegevoegd om alle ingebouwde documenteigenschappen (Bedrijf, Onderwerp, Auteur enz.) te verwijderen en hun standaardwaarden te herstellen.
#### **Methoden getBlackWhiteMode(), setBlackWhiteMode(byte) zijn toegevoegd aan com.aspose.slides.IShape**
Methoden getBlackWhiteMode(), setBlackWhiteMode(byte) zijn toegevoegd aan com.aspose.slides.IShape. De methoden geven aan hoe een vorm wordt weergegeven in zwart-wit weergavemodus. De mogelijke waarden worden gespecificeerd in de klasse com.aspose.slides.BlackWhiteMode.

|**Waarde**|**Betekenis**|
| :- | :- |
|Color|Teruggeven met normale kleuring|
|Automatic|Teruggeven met automatische kleuring|
|Gray|Teruggeven met grijze kleuring|
|LightGray|Teruggeven met lichtgrijze kleuring|
|InverseGray|Teruggeven met omgekeerde grijze kleuring|
|GrayWhite|Teruggeven met grijze en witte kleuring|
|BlackGray|Teruggeven met zwarte en grijze kleuring|
|BlackWhite|Teruggeven met zwarte en witte kleuring|
|Black|Teruggeven alleen met zwarte kleuring|
|White|Teruggeven met witte kleuring|
|Hidden|Het object wordt niet weergegeven|
#### **Methoden removeAt(int), remove(ICommentAuthor) en clear() zijn toegevoegd aan com.aspose.slides.ICommentAuthorCollection**
Methode ICommentAuthorCollection.removeAt(int) is toegevoegd om een auteur te verwijderen op basis van een opgegeven index. Methode ICommentAuthorCollection.remove(ICommentAuthor) is toegevoegd om een opgegeven auteur uit de collectie te verwijderen. Methode ICommentAuthorCollection.clear() is toegevoegd om alle items uit de collectie te verwijderen.