---
title: Öffentliche API- und abwärtsinkompatible Änderungen in Aspose.Slides für Java 15.6.0
linktitle: Aspose.Slides für Java 15.6.0
type: docs
weight: 140
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- Migration
- Legacy-Code
- Modern-Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über öffentliche API‑Updates und kritische Änderungen in Aspose.Slides für Java, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) auf, die mit der Aspose.Slides for Java 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Die Signatur des Konstruktors com.aspose.slides.DataLabel wurde geändert**
Die Signatur des Konstruktors wurde von DataLabel(com.aspose.slides.IChartSeries) zu DataLabel(com.aspose.slides.IChartDataPoint) geändert.
#### **Die Mitglieder com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name) und .contains(String name) wurden als veraltet markiert; stattdessen wurden Ersatzmethoden eingeführt**
Die Methoden IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name) und .contains(string name) wurden als veraltet markiert. Stattdessen wurden die Methoden IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name) und .containsCustomProperty(string name) eingeführt.
#### **Methode com.aspose.slides.INotesSlideManager.removeNotesSlide() wurde hinzugefügt**
Die Methode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizfolie einer Folie zu entfernen.
#### **Methode com.aspose.slides.ISlide.getNotesSlideManager() wurde hinzugefügt. Die Methoden ISlide.getNotesSlide() und ISlide.addNotesSlide() wurden als veraltet markiert**
Die Methoden ISlide.getNotesSlide() und ISlide.addNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Methode ISlide.getNotesSlideManager().

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - veraltet

// notes = slide.getNotesSlide(); - veraltet

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Methode getAppVersion() wurde zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.getAppVersion() wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die die von Microsoft PowerPoint verwendeten internen Versionsnummern darstellt.
#### **Methode remove() wurde zu com.aspose.slides.IComment hinzugefügt**
Die Methode com.aspose.slides.IComment.remove() wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Methode remove() wurde zu com.aspose.slides.ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Methoden clearCustomProperties() und clearBuiltInProperties() wurden zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.clearCustomProperties() wurde hinzugefügt, um alle benutzerdefinierten Dokumenteigenschaften zu entfernen.
Die Methode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() wurde hinzugefügt, um alle integrierten Dokumenteigenschaften (Firma, Betreff, Autor usw.) zu entfernen und deren Standardwerte zu setzen.
#### **Methoden getBlackWhiteMode() und setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt**
Die Methoden getBlackWhiteMode() und setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt. Die Methoden geben an, wie eine Form im Schwarz‑weiß‑Anzeigemodus dargestellt wird. Die möglichen Werte sind in der Klasse com.aspose.slides.BlackWhiteMode angegeben.

|**Wert** |**Bedeutung** |
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
#### **Methoden removeAt(int), remove(ICommentAuthor) und clear() wurden zu com.aspose.slides.ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.removeAt(int) wurde hinzugefügt, um einen Autor anhand des angegebenen Index zu entfernen. Die Methode ICommentAuthorCollection.remove(ICommentAuthor) wurde hinzugefügt, um den angegebenen Autor aus der Sammlung zu entfernen. Die Methode ICommentAuthorCollection.clear() wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.