---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.6.0
linktitle: Aspose.Slides para .NET 15.6.0
type: docs
weight: 170
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides for .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 
Esta página enumera todas las clases [añadidas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides for .NET 15.6.0.
{{% /alert %}} 
## **Cambios en la API pública**
#### **La firma del constructor de DataLabel ha cambiado**
La firma del constructor de DataLabel ha cambiado:
antes: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ahora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Los miembros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) se han marcado como obsoletos y se han introducido sus sustitutos.**
La propiedad IDocumentProperties.Count y los métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) se han marcado como obsoletos. En su lugar se han añadido la propiedad IDocumentProperties.CountOfCustomProperties y los métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Se ha añadido el método INotesSlideManager.RemoveNotesSlide()**
Se ha añadido el método INotesSlideManager.RemoveNotesSlide() para eliminar la diapositiva de notas de una diapositiva.
#### **Se ha añadido el método Remove a IComment**
Se ha añadido el método IComment.Remove para eliminar un comentario de la colección.
#### **Se ha añadido el método Remove a ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de los comentarios de la colección.
#### **Se han añadido los métodos ClearCustomProperties y ClearBuiltInProperties a IDocumentProperties**
Se ha añadido el método IDocumentProperties.ClearCustomProperties para eliminar todas las propiedades personalizadas del documento.
Se ha añadido el método IDocumentProperties.ClearBuiltInProperties para eliminar y restablecer los valores predeterminados de todas las propiedades integradas del documento (Company, Subject, Author, etc.).
#### **Se han añadido los métodos RemoveAt, Remove y Clear a ICommentAuthorCollection**
Se ha añadido ICommentAuthorCollection.RemoveAt para eliminar al autor mediante el índice especificado.
Se ha añadido ICommentAuthorCollection.Remove para eliminar al autor especificado de la colección.
Se ha añadido ICommentAuthorCollection.Clear para eliminar todos los elementos de la colección.
#### **Se ha añadido la propiedad AppVersion a IDocumentProperties**
Se ha añadido la propiedad IDocumentProperties.AppVersion para obtener la propiedad integrada del documento que representa los números de versión internos utilizados por Microsoft durante el desarrollo.
#### **Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape**
Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape.

Esta propiedad especifica cómo se representará una forma en modo de visualización en blanco y negro.

|**Value**|**Meaning**|
| :- | :- |
|Color|Render with normal coloring|
|Automatic|Render with automatic coloring|
|Gray|Render with gray coloring|
|LightGray|Render with light gray coloring|
|InverseGray|Render with inverse gray coloring|
|GrayWhite|Render with gray and white coloring|
|BlackGray|Render with black and gray coloring|
|BlackWhite|Render with black and white coloring|
|Black|Render only with black coloring|
|White|Render with white coloring|
|Hidden|Not render|
|NotDefined|means that property isn't set|
#### **Propiedad ISlide.NotesSlideManager ha sido añadida. La propiedad ISlide.NotesSlide y el método ISlide.AddNotesSlide() se han marcado como obsoletos.**
Los miembros ISlide.NotesSlide y ISlide.AddNotesSlide() se han marcado como obsoletos. Utilice la nueva propiedad ISlide.NotesSlideManager en su lugar.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - obsoleto
    // notes = slide.NotesSlide; - obsoleto

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```