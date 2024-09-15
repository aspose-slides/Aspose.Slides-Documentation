---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **DataLabel constructor signature has been changed**
DataLabel constructor signature has been changed:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) have been marked as Obsolete and its substitutions have been introduced instead.**
Property IDocumentProperties.Count and methods IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) have been marked as Obsolete. Property IDocumentProperties.CountOfCustomProperties and methods IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) have been added instead.
#### **Method INotesSlideManager.RemoveNotesSlide() has been added**
Method INotesSlideManager.RemoveNotesSlide() has been added for removing notes slide of some slide.
#### **Method Remove has been added to IComment**
Method IComment.Remove has been added for removing comment from the collection.
#### **Method Remove has been added to ICommentAuthor**
Method ICommentAuthor.Remove has been added for removing author of comments from the collection.
#### **Methods ClearCustomProperties and ClearBuiltInProperties have been added to IDocumentProperties**
Method IDocumentProperties.ClearCustomProperties has been added for removing all custom document properties.
Method IDocumentProperties.ClearBuiltInProperties has been added for removing and setting default values for all builtIn document properties (Company, Subject, Author etc).
#### **Methods RemoveAt, Remove and Clear have been added to ICommentAuthorCollection**
Method ICommentAuthorCollection.RemoveAt has added for removing author by specified index.
Method ICommentAuthorCollection.Remove has added for removing specified author from collection.
Method ICommentAuthorCollection.Clear has been added for removing all items from collection.
#### **Property AppVersion has been added to IDocumentProperties**
Property IDocumentProperties.AppVersion has been added to get builtIn document property which representis internal version numbers used by Microsoft during development.
#### **Property BlackWhiteMode has been added to IShape and to Shape**
Property BlackWhiteMode has been added to IShape and to Shape.

This property specifies how a shape will render in black-and-white display mode.

|**Value** |**Meaning** |
| :- | :- |
|Color |Render with normal coloring |
|Automatic |Render with automatic coloring |
|Gray |Render with gray coloring |
|LightGray |Render with light gray coloring |
|InverseGray |Render with inverse gray coloring |
|GrayWhite |Render with gray and white coloring |
|BlackGray |Render with black and gray coloring |
|BlackWhite |Render with black and white coloring |
|Black |Render only with black coloring |
|White |Render with white coloring |
|Hidden |Not render |
|NotDefined|means that property isn't set|
#### **Рroperty ISlide.NotesSlideManager has been added. Property ISlide.NotesSlide and method ISlide.AddNotesSlide() have been marked as Obsolete.**
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
