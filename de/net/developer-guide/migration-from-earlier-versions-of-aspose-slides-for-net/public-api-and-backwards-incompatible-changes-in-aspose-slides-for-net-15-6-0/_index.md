---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.6.0
linktitle: Aspose.Slides für .NET 15.6.0
type: docs
weight: 170
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblicken Sie die öffentlichen API-Updates und inkompatiblen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **DataLabel-Konstruktor-Signatur wurde geändert**
Die Signatur des DataLabel-Konstruktors wurde geändert:
war: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
jetzt: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Mitglieder IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert und ihre Ersatzmethoden wurden eingeführt.**
Die Eigenschaft IDocumentProperties.Count und die Methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert. Die Eigenschaft IDocumentProperties.CountOfCustomProperties und die Methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) wurden stattdessen hinzugefügt.
#### **Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt**
Die Methode INotesSlideManager.RemoveNotesSlide() wurde zum Entfernen einer Notizfolie einer Folie hinzugefügt.
#### **Methode Remove wurde zu IComment hinzugefügt**
Die Methode IComment.Remove wurde zum Entfernen eines Kommentars aus der Sammlung hinzugefügt.
#### **Methode Remove wurde zu ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde zum Entfernen des Autors von Kommentaren aus der Sammlung hinzugefügt.
#### **Methoden ClearCustomProperties und ClearBuiltInProperties wurden zu IDocumentProperties hinzugefügt**
Die Methode IDocumentProperties.ClearCustomProperties wurde zum Entfernen aller benutzerdefinierten Dokumenteigenschaften hinzugefügt.
Die Methode IDocumentProperties.ClearBuiltInProperties wurde zum Entfernen und Zurücksetzen aller integrierten Dokumenteigenschaften (Company, Subject, Author usw.) hinzugefügt.
#### **Methoden RemoveAt, Remove und Clear wurden zu ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.RemoveAt wurde zum Entfernen eines Autors nach angegebenem Index hinzugefügt.
Die Methode ICommentAuthorCollection.Remove wurde zum Entfernen eines angegebenen Autors aus der Sammlung hinzugefügt.
Die Methode ICommentAuthorCollection.Clear wurde zum Entfernen aller Elemente aus der Sammlung hinzugefügt.
#### **Eigenschaft AppVersion wurde zu IDocumentProperties hinzugefügt**
Die Eigenschaft IDocumentProperties.AppVersion wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die interne Versionsnummern darstellt, die von Microsoft während der Entwicklung verwendet werden.
#### **Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt**
Die Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt.

Diese Eigenschaft gibt an, wie eine Form im Schwarz‑weiß‑Anzeige‑Modus gerendert wird.

|**Wert** |**Bedeutung** |
| :- | :- |
|Color |Mit normalen Farben rendern |
|Automatic |Automatisch rendern |
|Gray |Mit Graufärbung rendern |
|LightGray |Mit hellgrauer Färbung rendern |
|InverseGray |Mit invertierter Graufärbung rendern |
|GrayWhite |Mit grauer und weißer Färbung rendern |
|BlackGray |Mit schwarzer und grauer Färbung rendern |
|BlackWhite |Mit schwarzer und weißer Färbung rendern |
|Black |Nur mit schwarzer Färbung rendern |
|White |Mit weißer Färbung rendern |
|Hidden |Nicht rendern |
|NotDefined|bedeutet, dass die Eigenschaft nicht gesetzt ist|
#### **Property ISlide.NotesSlideManager wurde hinzugefügt. Property ISlide.NotesSlide und Methode ISlide.AddNotesSlide() wurden als veraltet markiert.**
Die Mitglieder ISlide.NotesSlide und ISlide.AddNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Eigenschaft ISlide.NotesSlideManager.

``` csharp
 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - veraltet

// notes = slide.NotesSlide; - veraltet

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();
```