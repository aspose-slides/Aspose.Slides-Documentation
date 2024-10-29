---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für PHP über Java 15.6.0
type: docs
weight: 140
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) Klassen, Methoden, Eigenschaften usw. auf, sowie alle neuen Einschränkungen und andere [Änderungen](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) die mit der Aspose.Slides für PHP über Java 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Die Signatur des Konstruktors com.aspose.slides.DataLabel wurde geändert**
Die Signatur des Konstruktors wurde von DataLabel(com.aspose.slides.IChartSeries) zu DataLabel(com.aspose.slides.IChartDataPoint) geändert.
#### **Die Mitglieder com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) wurden als veraltet markiert; stattdessen wurden Substitutionen eingeführt**
Die Methoden IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) wurden als veraltet markiert. Stattdessen wurden die Methoden IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) eingeführt.
#### **Die Methode com.aspose.slides.INotesSlideManager.removeNotesSlide() wurde hinzugefügt**
Die Methode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizenseite einer Folie zu entfernen.
#### **Die Methode com.aspose.slides.ISlide.getNotesSlideManager() wurde hinzugefügt. Die Methoden ISlide.getNotesSlide() und ISlide.addNotesSlide() wurden als veraltet markiert**
Die Methoden ISlide.getNotesSlide(), ISlide.addNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Methode ISlide.getNotesSlideManager().

```php
  $slide = $$missing$;
  $notes;
  # notes = slide.addNotesSlide(); - veraltet
  # notes = slide.getNotesSlide(); - veraltet
  $notes = $slide->getNotesSlideManager()->getNotesSlide();
  $notes = $slide->getNotesSlideManager()->addNotesSlide();
  $slide->getNotesSlideManager()->removeNotesSlide();

```
#### **Die Methode getAppVersion() wurde zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.getAppVersion() wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die die internen Versionsnummern von Microsoft PowerPoint darstellt.
#### **Die Methode remove() wurde zu com.aspose.slides.IComment hinzugefügt**
Die Methode com.aspose.slides.IComment.remove() wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Die Methode remove() wurde zu com.aspose.slides.ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Die Methoden clearCustomProperties() und clearBuiltInProperties() wurden zu com.aspose.slides.IDocumentProperties hinzugefügt**
Die Methode com.aspose.slides.IDocumentProperties.clearCustomProperties() wurde hinzugefügt, um alle benutzerdefinierten Dokumenteigenschaften zu entfernen.
Die Methode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() wurde hinzugefügt, um alle integrierten Dokumenteigenschaften (Firma, Betreff, Autor usw.) zu entfernen und standardmäßige Werte festzulegen.
#### **Die Methoden getBlackWhiteMode(), setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt**
Die Methoden getBlackWhiteMode(), setBlackWhiteMode(byte) wurden zu com.aspose.slides.IShape hinzugefügt.
Die Methoden geben an, wie eine Form im Schwarzweiß-Anzeigemodus gerendert wird. Die möglichen Werte sind in der Klasse com.aspose.slides.BlackWhiteMode angegeben.

|**Wert** |**Bedeutung** |
| :- | :- |
|Farbe |Rückgabe mit normaler Farbgebung |
|Automatisch |Rückgabe mit automatischer Farbgebung |
|Grau |Rückgabe mit grauer Farbgebung |
|Hellgrau |Rückgabe mit hellgrauer Farbgebung |
|Umgekehrtes Grau |Rückgabe mit umgekehrter grauer Farbgebung |
|Grau-Weiß |Rückgabe mit grauer und weißer Farbgebung |
|Schwarz-Grau |Rückgabe mit schwarzer und grauer Farbgebung |
|Schwarz-Weiß |Rückgabe mit schwarzer und weißer Farbgebung |
|Schwarz |Rückgabe nur mit schwarzer Farbgebung |
|Weiß |Rückgabe mit weißer Farbgebung |
|Versteckt |Das Objekt wird nicht gerendert |
#### **Die Methoden removeAt(int), remove(ICommentAuthor) und clear() wurden zu com.aspose.slides.ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.removeAt(int) wurde hinzugefügt, um den Autor anhand des angegebenen Index zu entfernen. Die Methode ICommentAuthorCollection.remove(ICommentAuthor) wurde hinzugefügt, um den angegebenen Autor aus der Sammlung zu entfernen. Die Methode ICommentAuthorCollection.clear() wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.