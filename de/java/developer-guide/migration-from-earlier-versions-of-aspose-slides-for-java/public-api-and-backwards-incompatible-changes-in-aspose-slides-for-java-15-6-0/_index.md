---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 15.6.0
linktitle: Aspose.Slides für Java 15.6.0
type: docs
weight: 140
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die Updates der öffentlichen API und die breaking changes in Aspose.Slides für Java, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) Klassen, Methoden, Eigenschaften usw., neue Einschränkungen und weitere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) ein, die mit der Aspose.Slides for Java 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Signatur des Konstruktors von com.aspose.slides.DataLabel wurde geändert**
Die Signatur des Konstruktors wurde von DataLabel(com.aspose.slides.IChartSeries) zu DataLabel(com.aspose.slides.IChartDataPoint) geändert.
#### **Mitglieder com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) wurden als veraltet markiert; stattdessen wurden Ersatzmethoden eingeführt**
Die Methoden IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name) und .contains(string name) wurden als veraltet markiert. Stattdessen wurden die Methoden IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name) und .containsCustomProperty(string name) eingeführt.
#### **Methode com.aspose.slides.INotesSlideManager.removeNotesSlide() wurde hinzugefügt**
Die Methode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizfolie einer Folie zu entfernen.
#### **Methode com.aspose.slides.ISlide.getNotesSlideManager() wurde hinzugefügt. Die Methoden ISlide.getNotesSlide() und ISlide.addNotesSlide() wurden als veraltet markiert**
Die Methoden ISlide.getNotesSlide() und ISlide.addNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Methode ISlide.getNotesSlideManager().

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - veraltet

    // notes = slide.getNotesSlide(); - veraltet

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Methode getAppVersion() wurde zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.getAppVersion() wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die die internen Versionsnummern von Microsoft PowerPoint darstellt.
#### **Methode remove() wurde zu com.aspose.slides.IComment hinzugefügt**
Die Methode com.aspose.slides.IComment.remove() wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Methode remove() wurde zu com.aspose.slides.ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Methoden clearCustomProperties() und clearBuiltInProperties() wurden zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.clearCustomProperties() wurde hinzugefügt, um alle benutzerdefinierten Dokumenteigenschaften zu entfernen.
Die Methode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() wurde hinzugefügt, um alle integrierten Dokumenteigenschaften (Firma, Betreff, Autor usw.) zu entfernen und ihre Standardwerte wiederherzustellen.
#### **Methoden getBlackWhiteMode() und setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt**
Die Methoden getBlackWhiteMode() und setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt. Die Methoden geben an, wie eine Form im Schwarz‑Weiß‑Anzeigemodus dargestellt wird. Die möglichen Werte sind in der Klasse com.aspose.slides.BlackWhiteMode definiert.

|**Wert** |**Bedeutung** |
| :- | :- |
|Color |Wird mit normaler Farbgebung zurückgegeben |
|Automatic |Wird mit automatischer Farbgebung zurückgegeben |
|Gray |Wird mit grauer Farbgebung zurückgegeben |
|LightGray |Wird mit hellgrauer Farbgebung zurückgegeben |
|InverseGray |Wird mit umgekehrter grauer Farbgebung zurückgegeben |
|GrayWhite |Wird mit grauer und weißer Farbgebung zurückgegeben |
|BlackGray |Wird mit schwarzer und grauer Farbgebung zurückgegeben |
|BlackWhite |Wird mit schwarzer und weißer Farbgebung zurückgegeben |
|Black |Wird nur mit schwarzer Farbgebung zurückgegeben |
|White |Wird mit weißer Farbgebung zurückgegeben |
|Hidden |Das Objekt wird nicht gerendert |
#### **Methoden removeAt(int), remove(ICommentAuthor) und clear() wurden zu com.aspose.slides.ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.removeAt(int) wurde hinzugefügt, um einen Autor anhand des angegebenen Index zu entfernen. Die Methode ICommentAuthorCollection.remove(ICommentAuthor) wurde hinzugefügt, um einen angegebenen Autor aus der Sammlung zu entfernen. Die Methode ICommentAuthorCollection.clear() wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.