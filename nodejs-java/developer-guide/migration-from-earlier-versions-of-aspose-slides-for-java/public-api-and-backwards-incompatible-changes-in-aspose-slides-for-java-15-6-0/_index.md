---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Node.js via Java 15.6.0
type: docs
weight: 140
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introduced with the Aspose.Slides for Node.js via Java 15.6.0 API.

{{% /alert %}} 
## **Public API changes**
#### **aspose.slides.DataLabel constructor signature has been changed**
The signature of the constructor has been changed from DataLabel(aspose.slides.IChartSeries) to DataLabel(aspose.slides.IChartDataPoint).
#### **Members aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Methods IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) have been marked as Deprecated. Methods IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) have been introduced instead.
#### **Method aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Method aspose.slides.INotesSlideManager.RemoveNotesSlide() has been added for removing notes slide of some slide.
#### **Method aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
ISlide.getNotesSlide(), ISlide.addNotesSlide() methods have been marked as Deprecated. Use new method ISlide.getNotesSlideManager() instead.

```javascript
    var slide = $missing$;
    var notes;
    // notes = slide.addNotesSlide(); - deprecated
    // notes = slide.getNotesSlide(); - deprecated
    notes = slide.getNotesSlideManager().getNotesSlide();
    notes = slide.getNotesSlideManager().addNotesSlide();
    slide.getNotesSlideManager().removeNotesSlide();
```
#### **Method getAppVersion() has been added to aspose.slides.IDocumentProperties**
Method aspose.slides.IDocumentProperties.getAppVersion() has been added in order to get builtin document property, which represents internal version numbers used by Microsoft PowerPoint.
#### **Method remove() has been added to aspose.slides.IComment**
Method aspose.slides.IComment.remove() has been added for removing comment from the collection.
#### **Method remove() has been added to aspose.slides.ICommentAuthor**
Method ICommentAuthor.Remove has been added for removing author of comments from the collection.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to aspose.slides.IDocumentProperties**
Method aspose.slides.IDocumentProperties.clearCustomProperties() has been added for removing all custom document properties.
Method aspose.slides.IDocumentProperties.clearBuiltInProperties() has been added for removing and setting default values for all builtin document properties (Company, Subject, Author etc).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to aspose.slides.IShape**
Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to aspose.slides.IShape.
The methods specify how a shape will render in black-and-white display mode. The possible values are specified in aspose.slides.BlackWhiteMode class.

|**Value** |**Meaning** |
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
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to aspose.slides.ICommentAuthorCollection**
Method ICommentAuthorCollection.removeAt(int) has added for removing author by specified index. Method ICommentAuthorCollection.remove(ICommentAuthor) has added for removing specified author from collection. Method ICommentAuthorCollection.clear() has been added for removing all items from collection.
