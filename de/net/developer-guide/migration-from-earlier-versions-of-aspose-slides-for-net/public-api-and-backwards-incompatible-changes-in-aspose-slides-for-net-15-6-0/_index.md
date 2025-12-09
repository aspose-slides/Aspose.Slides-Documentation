---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.6.0
linktitle: Aspose.Slides für .NET 15.6.0
type: docs
weight: 170
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- Migration
- Legacy-Code
- moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Signatur des DataLabel-Konstruktors wurde geändert**
Die Signatur des DataLabel-Konstruktors wurde geändert:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Mitglieder IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert und Ersatzmethoden wurden eingeführt.**
Die Eigenschaft IDocumentProperties.Count und die Methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert. Stattdessen wurden die Eigenschaft IDocumentProperties.CountOfCustomProperties und die Methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) hinzugefügt.
#### **Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt**
Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizfolie einer Folie zu entfernen.
#### **Methode Remove wurde zu IComment hinzugefügt**
Methode IComment.Remove wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Methode Remove wurde zu ICommentAuthor hinzugefügt**
Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Methoden ClearCustomProperties und ClearBuiltInProperties wurden zu IDocumentProperties hinzugefügt**
Methode IDocumentProperties.ClearCustomProperties wurde hinzugefügt, um alle benutzerdefinierten Dokumenteigenschaften zu entfernen.
Methode IDocumentProperties.ClearBuiltInProperties wurde hinzugefügt, um alle integrierten Dokumenteigenschaften (Company, Subject, Author usw.) zu entfernen und auf Standardwerte zurückzusetzen.
#### **Methoden RemoveAt, Remove und Clear wurden zu ICommentAuthorCollection hinzugefügt**
Methode ICommentAuthorCollection.RemoveAt wurde hinzugefügt, um einen Autor anhand des angegebenen Index zu entfernen.
Methode ICommentAuthorCollection.Remove wurde hinzugefügt, um einen angegebenen Autor aus der Sammlung zu entfernen.
Methode ICommentAuthorCollection.Clear wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.
#### **Eigenschaft AppVersion wurde zu IDocumentProperties hinzugefügt**
Eigenschaft IDocumentProperties.AppVersion wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die interne Versionsnummern von Microsoft während der Entwicklung repräsentiert.
#### **Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt**
Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt.

Diese Eigenschaft gibt an, wie eine Form im Schwarz‑weiß‑Anzeige‑Modus gerendert wird.

|**Wert** |**Bedeutung** |
| :- | :- |
|Color |Wird mit normaler Farbgebung gerendert |
|Automatic |Wird automatisch eingefärbt |
|Gray |Wird grau eingefärbt |
|LightGray |Wird hellgrau eingefärbt |
|InverseGray |Wird mit invertierter Graufärbung gerendert |
|GrayWhite |Wird mit grau und weiß eingefärbt |
|BlackGray |Wird mit schwarz und grau eingefärbt |
|BlackWhite |Wird mit schwarz und weiß eingefärbt |
|Black |Wird ausschließlich schwarz eingefärbt |
|White |Wird weiß eingefärbt |
|Hidden |Wird nicht gerendert |
|NotDefined |bedeutet, dass die Eigenschaft nicht gesetzt ist |
#### **Eigenschaft ISlide.NotesSlideManager wurde hinzugefügt. Eigenschaft ISlide.NotesSlide und Methode ISlide.AddNotesSlide() wurden als veraltet markiert.**
Die Mitglieder ISlide.NotesSlide und ISlide.AddNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Eigenschaft ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```