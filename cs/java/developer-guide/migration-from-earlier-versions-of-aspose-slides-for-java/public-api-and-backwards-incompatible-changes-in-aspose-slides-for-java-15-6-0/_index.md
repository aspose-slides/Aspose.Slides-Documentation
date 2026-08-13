---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 15.6.0
linktitle: Aspose.Slides pro Java 15.6.0
type: docs
weight: 140
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro Java, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) třídy, metody, vlastnosti a podobně, všechny nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) zavedené v API Aspose.Slides pro Java 15.6.0.
{{% /alert %}} 
## **Veřejné změny API**
#### **Signatura konstruktoru com.aspose.slides.DataLabel byla změněna**
#### **Členy com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name) a .contains(String name) byly označeny jako zastaralé; místo nich byla zavedena náhrada**
#### **Metoda com.aspose.slides.INotesSlideManager.removeNotesSlide() byla přidána**
#### **Metoda com.aspose.slides.ISlide.getNotesSlideManager() byla přidána. Metody ISlide.getNotesSlide() a ISlide.addNotesSlide() byly označeny jako zastaralé**
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - zastaralé

    // notes = slide.getNotesSlide(); - zastaralé

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Metoda getAppVersion() byla přidána do com.aspose.slides.IDocumentProperties**
#### **Metoda remove() byla přidána do com.aspose.slides.IComment**
#### **Metoda remove() byla přidána do com.aspose.slides.ICommentAuthor**
#### **Metody clearCustomProperties() a clearBuiltInProperties() byly přidány do com.aspose.slides.IDocumentProperties**
Metoda com.aspose.slides.IDocumentProperties.clearCustomProperties() byla přidána pro odstraňování všech vlastních vlastností dokumentu.  
Metoda com.aspose.slides.IDocumentProperties.clearBuiltInProperties() byla přidána pro odstraňování a nastavení výchozích hodnot všech vestavěných vlastností dokumentu (Company, Subject, Author atd.).
#### **Metody getBlackWhiteMode() a setBlackWhiteMode(byte) byly přidány do com.aspose.slides.IShape**
Metody určují, jak bude tvar vykreslen v režimu černobílého zobrazení. Možné hodnoty jsou uvedeny ve třídě com.aspose.slides.BlackWhiteMode.

|**Hodnota** |**Význam** |
| :- | :- |
|Color |Vrací s normálním barvením |
|Automatic |Vrací s automatickým barvením |
|Gray |Vrací se šedým barvením |
|LightGray |Vrací se světle šedým barvením |
|InverseGray |Vrací se inverzním šedým barvením |
|GrayWhite |Vrací se šedým a bílým barvením |
|BlackGray |Vrací se černým a šedým barvením |
|BlackWhite |Vrací se černým a bílým barvením |
|Black |Vrací se jen s černým barvením |
|White |Vrací se s bílým barvením |
|Hidden |Objekt není vykreslen |
#### **Metody removeAt(int), remove(ICommentAuthor) a clear() byly přidány do com.aspose.slides.ICommentAuthorCollection**
Metoda ICommentAuthorCollection.removeAt(int) byla přidána pro odebrání autora podle zadaného indexu.  
Metoda ICommentAuthorCollection.remove(ICommentAuthor) byla přidána pro odebrání určeného autora ze sbírky.  
Metoda ICommentAuthorCollection.clear() byla přaddedána pro odebrání všech položek ze sbírky.