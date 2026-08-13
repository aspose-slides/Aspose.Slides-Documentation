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
description: "Überprüfen Sie die öffentlichen API-Updates und kritischen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**
#### **DataLabel‑Konstruktorsignatur wurde geändert**
Die Signatur des DataLabel‑Konstruktors wurde geändert:
war: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
jetzt: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Mitglieder IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert und durch Ersatzmitglieder ersetzt.**
Die Eigenschaft IDocumentProperties.Count und die Methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert. Stattdessen wurden die Eigenschaft IDocumentProperties.CountOfCustomProperties und die Methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) hinzugefügt.
#### **Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt**
Die Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt, um die Notizfolie einer Folie zu entfernen.
#### **Methode Remove wurde zu IComment hinzugefügt**
Die Methode IComment.Remove wurde hinzugefügt, um einen Kommentar aus der Sammlung zu entfernen.
#### **Methode Remove wurde zu ICommentAuthor hinzugefügt**
Die Methode ICommentAuthor.Remove wurde hinzugefügt, um den Autor von Kommentaren aus der Sammlung zu entfernen.
#### **Methoden ClearCustomProperties und ClearBuiltInProperties wurden zu IDocumentProperties hinzugefügt**
Die Methode IDocumentProperties.ClearCustomProperties wurde hinzugefügt, um alle benutzerdefinierten Dokumenteneigenschaften zu entfernen.
Die Methode IDocumentProperties.ClearBuiltInProperties wurde hinzugefügt, um alle integrierten Dokumenteneigenschaften (Company, Subject, Author usw.) zu entfernen und auf Standardwerte zurückzusetzen.
#### **Methoden RemoveAt, Remove und Clear wurden zu ICommentAuthorCollection hinzugefügt**
Die Methode ICommentAuthorCollection.RemoveAt wurde hinzugefügt, um einen Autor anhand eines angegebenen Indexes zu entfernen.
Die Methode ICommentAuthorCollection.Remove wurde hinzugefügt, um einen angegebenen Autor aus der Sammlung zu entfernen.
Die Methode ICommentAuthorCollection.Clear wurde hinzugefügt, um alle Elemente aus der Sammlung zu entfernen.
#### **Eigenschaft AppVersion wurde zu IDocumentProperties hinzugefügt**
Die Eigenschaft IDocumentProperties.AppVersion wurde hinzugefügt, um die integrierte Dokumenteigenschaft abzurufen, die interne Versionsnummern repräsentiert, die von Microsoft während der Entwicklung verwendet werden.
#### **Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt**
Die Eigenschaft BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt.

Diese Eigenschaft legt fest, wie eine Form im Schwarz‑weiß‑Anzeige‑Modus gerendert wird.

|**Wert** |**Bedeutung** |
| :- | :- |
|Color |Mit normaler Farbgebung rendern |
|Automatic |Mit automatischer Farbgebung rendern |
|Gray |Mit grauer Farbgebung rendern |
|LightGray |Mit hellgrauer Farbgebung rendern |
|InverseGray |Mit invertierter grauer Farbgebung rendern |
|GrayWhite |Mit grauer und weißer Farbgebung rendern |
|BlackGray |Mit schwarzer und grauer Farbgebung rendern |
|BlackWhite |Mit schwarzer und weißer Farbgebung rendern |
|Black |Nur mit schwarzer Farbgebung rendern |
|White |Mit weißer Farbgebung rendern |
|Hidden |Nicht rendern |
|NotDefined |bedeutet, dass die Eigenschaft nicht gesetzt ist|
#### **Eigenschaft ISlide.NotesSlideManager wurde hinzugefügt. Eigenschaft ISlide.NotesSlide und Methode ISlide.AddNotesSlide() wurden als veraltet markiert.**
Die Mitglieder ISlide.NotesSlide und ISlide.AddNotesSlide() wurden als veraltet markiert. Verwenden Sie stattdessen die neue Eigenschaft ISlide.NotesSlideManager.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - veraltet
    // notes = slide.NotesSlide; - veraltet

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```