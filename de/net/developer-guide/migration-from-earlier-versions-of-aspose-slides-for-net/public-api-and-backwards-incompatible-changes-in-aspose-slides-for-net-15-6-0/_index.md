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
description: "Überblick über öffentliche API‑Aktualisierungen und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle hinzugefügten oder entfernten Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **DataLabel-Konstruktorsignatur wurde geändert**
DataLabel constructor signature has been changed:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Mitglieder IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) wurden als veraltet markiert und stattdessen wurden ihre Ersatzmethoden eingeführt.**
Property IDocumentProperties.Count and methods IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) have been marked as Obsolete. Property IDocumentProperties.CountOfCustomProperties and methods IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) have been added instead.
#### **Methode INotesSlideManager.RemoveNotesSlide() wurde hinzugefügt**
Method INotesSlideManager.RemoveNotesSlide() has been added for removing notes slide of some slide.
#### **Methode Remove wurde zu IComment hinzugefügt**
Method IComment.Remove has been added for removing comment from the collection.
#### **Methode Remove wurde zu ICommentAuthor hinzugefügt**
Method ICommentAuthor.Remove has been added for removing author of comments from the collection.
#### **Methoden ClearCustomProperties und ClearBuiltInProperties wurden zu IDocumentProperties hinzugefügt**
Method IDocumentProperties.ClearCustomProperties has been added for removing all custom document properties.
Method IDocumentProperties.ClearBuiltInProperties has been added for removing and setting default values for all builtIn document properties (Company, Subject, Author etc).
#### **Methoden RemoveAt, Remove und Clear wurden zu ICommentAuthorCollection hinzugefügt**
Method ICommentAuthorCollection.RemoveAt has added for removing author by specified index.
Method ICommentAuthorCollection.Remove has added for removing specified author from collection.
Method ICommentAuthorCollection.Clear has been added for removing all items from collection.
#### **Property AppVersion wurde zu IDocumentProperties hinzugefügt**
Property IDocumentProperties.AppVersion has been added to get builtIn document property which representis internal version numbers used by Microsoft during development.
#### **Property BlackWhiteMode wurde zu IShape und zu Shape hinzugefügt**
Property BlackWhiteMode has been added to IShape and to Shape.

Diese Eigenschaft gibt an, wie eine Form im Schwarz‑Weiß‑Anzeigemodus gerendert wird.

|**Wert** |**Bedeutung** |
| :- | :- |
|Color |Mit normaler Farbgebung rendern |
|Automatic |Mit automatischer Farbgebung rendern |
|Gray |Mit grauer Farbgebung rendern |
|LightGray |Mit hellgrauer Farbgebung rendern |
|InverseGray |Mit inverser grauer Farbgebung rendern |
|GrayWhite |Mit grauer und weißer Farbgebung rendern |
|BlackGray |Mit schwarzer und grauer Farbgebung rendern |
|BlackWhite |Mit schwarzer und weißer Farbgebung rendern |
|Black |Nur mit schwarzer Farbgebung rendern |
|White |Mit weißer Farbgebung rendern |
|Hidden |Nicht rendern |
|NotDefined|bedeutet, dass die Eigenschaft nicht gesetzt ist|
#### **Property ISlide.NotesSlideManager wurde hinzugefügt. Property ISlide.NotesSlide und Methode ISlide.AddNotesSlide() wurden als veraltet markiert.**
ISlide.NotesSlide, ISlide.AddNotesSlide() members has been marked as Obsolete. Use new property ISlide.NotesSlideManager instead.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```