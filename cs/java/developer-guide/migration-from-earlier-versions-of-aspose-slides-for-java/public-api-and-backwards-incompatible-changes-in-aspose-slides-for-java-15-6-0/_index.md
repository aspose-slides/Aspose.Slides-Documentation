---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.6.0
linktitle: Aspose.Slides pro Java 15.6.0
type: docs
weight: 140
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - migrace
  - zastaralý kód
  - moderní kód
  - zastaralý přístup
  - moderní přístup
  - PowerPoint
  - OpenDocument
  - prezentace
  - Java
  - Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro Java a plynule migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) třídy, metody, vlastnosti a podobně, jakákoli nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) zavedené v API Aspose.Slides for Java 15.6.0.
{{% /alert %}} 
## **Změny veřejného API**
#### **Signatura konstruktoru com.aspose.slides.DataLabel byla změněna**
Signatura konstruktoru byla změněna z DataLabel(com.aspose.slides.IChartSeries) na DataLabel(com.aspose.slides.IChartDataPoint).
#### **Členské funkce com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) byly označeny jako zastaralé; byly zavedeny náhradní alternativy**
Metody IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) byly označeny jako zastaralé. Místo nich byly zavedeny metody IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Metoda com.aspose.slides.INotesSlideManager.removeNotesSlide() byla přidána**
Metoda com.aspose.slides.INotesSlideManager.RemoveNotesSlide() byla přidána pro odebrání poznámkové snímky z určitého snímku.
#### **Metoda com.aspose.slides.ISlide.getNotesSlideManager() byla přidána. Metody ISlide.getNotesSlide() a ISlide.addNotesSlide() byly označeny jako zastaralé**
Metody ISlide.getNotesSlide() a ISlide.addNotesSlide() byly označeny jako zastaralé. Použijte novou metodu ISlide.getNotesSlideManager() místo nich.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - zastaralé

// notes = slide.getNotesSlide(); - zastaralé

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Metoda getAppVersion() byla přidána do com.aspose.slides.IDocumentProperties**
Metoda com.aspose.slides.IDocumentProperties.getAppVersion() byla přidána za účelem získání vestavěné vlastnosti dokumentu, která představuje interní čísla verzí používaná v Microsoft PowerPoint.
#### **Metoda remove() byla přidána do com.aspose.slides.IComment**
Metoda com.aspose.slides.IComment.remove() byla přidána pro odebrání komentáře ze sbírky.
#### **Metoda remove() byla přidána do com.aspose.slides.ICommentAuthor**
Metoda ICommentAuthor.Remove byla přidána pro odebrání autora komentářů ze sbírky.
#### **Metody clearCustomProperties() a clearBuiltInProperties() byly přidány do com.aspose.slides.IDocumentProperties**
Metoda com.aspose.slides.IDocumentProperties.clearCustomProperties() byla přidána pro odebrání všech vlastních vlastností dokumentu. Metoda com.aspose.slides.IDocumentProperties.clearBuiltInProperties() byla přidána pro odebrání a nastavení výchozích hodnot pro všechny vestavěné vlastnosti dokumentu (Company, Subject, Author atd.).
#### **Metody getBlackWhiteMode() a setBlackWhiteMode(byte) byly přidány do com.aspose.slides.IShape**
Metody getBlackWhiteMode() a setBlackWhiteMode(byte) byly přidány do com.aspose.slides.IShape. Tyto metody určují, jak bude tvar vykreslen v režimu černobílého zobrazení. Možné hodnoty jsou uvedeny ve třídě com.aspose.slides.BlackWhiteMode.

|**Value**|**Meaning**|
| :- | :- |
|Color|Vrátí normální barvu|
|Automatic|Vrátí automatické barvení|
|Gray|Vrátí šedé zbarvení|
|LightGray|Vrátí světle šedé zbarvení|
|InverseGray|Vrátí inverzní šedé zbarvení|
|GrayWhite|Vrátí šedé a bílé zbarvení|
|BlackGray|Vrátí černé a šedé zbarvení|
|BlackWhite|Vrátí černé a bílé zbarvení|
|Black|Vrátí pouze černé zbarvení|
|White|Vrátí bílé zbarvení|
|Hidden|Objekt není vykreslen|
#### **Metody removeAt(int), remove(ICommentAuthor) a clear() byly přidány do com.aspose.slides.ICommentAuthorCollection**
Metoda ICommentAuthorCollection.removeAt(int) byla přidána pro odebrání autora podle zadaného indexu. Metoda ICommentAuthorCollection.remove(ICommentAuthor) byla přadded pro odebrání konkrétního autora ze sbírky. Metoda ICommentAuthorCollection.clear() byla přidána pro odebrání všech položek ze sbírky.