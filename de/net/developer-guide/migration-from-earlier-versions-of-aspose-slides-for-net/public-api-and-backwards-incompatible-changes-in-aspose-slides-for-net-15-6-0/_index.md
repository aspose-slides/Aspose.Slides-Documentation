---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 15.6.0
type: docs
weight: 170
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Die Signatur des DataLabel-Konstruktors wurde geändert**
Die Signatur des DataLabel-Konstruktors wurde geändert:
früher: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
jetzt: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Die Mitglieder IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als Obsolete markiert, und stattdessen wurden deren Substitutionen eingeführt.**
Die Eigenschaft IDocumentProperties.Count und die Methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als Obsolete markiert. Stattdessen wurden die Eigenschaft IDocumentProperties.CountOfCustomProperties und die Methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) hinzugefügt.
#### **Die Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt**
Die Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizseite einer bestimmten Folie zu entfernen.
#### **Die Methode Remove wurde zu IComment hinzugefügt**
Die Methode IComment.Remove wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Die Methode Remove wurde zu ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Die Methoden ClearCustomProperties und ClearBuiltInProperties wurden zu IDocumentProperties hinzugefügt**
Die Methode IDocumentProperties.ClearCustomProperties wurde hinzugefügt, um alle benutzerdefinierten Dokumenteigenschaften zu entfernen.
Die Methode IDocumentProperties.ClearBuiltInProperties wurde hinzugefügt, um alle integrierten Dokumenteigenschaften (Firma, Betreff, Autor usw.) zu entfernen und Standardwerte festzulegen.
#### **Die Methoden RemoveAt, Remove und Clear wurden zu ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.RemoveAt wurde hinzugefügt, um den Autor anhand des angegebenen Indexes zu entfernen.
Die Methode ICommentAuthorCollection.Remove wurde hinzugefügt, um den angegebenen Autor aus der Sammlung zu entfernen.
Die Methode ICommentAuthorCollection.Clear wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.
#### **Die Eigenschaft AppVersion wurde zu IDocumentProperties hinzugefügt**
Die Eigenschaft IDocumentProperties.AppVersion wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die die internen Versionsnummern, die von Microsoft während der Entwicklung verwendet werden, darstellt.
#### **Die Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt**
Die Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt.

Diese Eigenschaft gibt an, wie eine Form im Schwarz-Weiß-Displaymodus gerendert wird.

|**Wert** |**Bedeutung** |
| :- | :- |
|Farbe |Normalfarbige Darstellung |
|Automatisch |Darstellung mit automatischer Färbung |
|Grau |Darstellung mit grauer Färbung |
|Hellgrau |Darstellung mit hellgrauer Färbung |
|Umgekehrtes Grau |Darstellung mit umgekehrter grauer Färbung |
|Grau-Weiß |Darstellung mit grauer und weißer Färbung |
|Schwarz-Grau |Darstellung mit schwarzer und grauer Färbung |
|Schwarz-Weiß |Darstellung mit schwarzer und weißer Färbung |
|Schwarz |Darstellung nur mit schwarzer Färbung |
|Weiß |Darstellung mit weißer Färbung |
|Unsichtbar |Nicht rendern |
|Nicht definiert|Bedeutet, dass die Eigenschaft nicht gesetzt ist|
#### **Die Eigenschaft ISlide.NotesSlideManager wurde hinzugefügt. Die Eigenschaften ISlide.NotesSlide und die Methode ISlide.AddNotesSlide() wurden als Obsolete markiert.**
Die Mitglieder ISlide.NotesSlide, ISlide.AddNotesSlide() wurden als Obsolete markiert. Verwenden Sie stattdessen die neue Eigenschaft ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolet

// notes = slide.NotesSlide; - obsolet

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 