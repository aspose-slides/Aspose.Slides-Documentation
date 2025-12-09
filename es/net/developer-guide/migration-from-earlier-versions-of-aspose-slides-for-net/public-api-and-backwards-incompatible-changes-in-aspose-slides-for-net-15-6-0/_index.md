---
title: API pública y cambios incompatibles retroactivos en Aspose.Slides para .NET 15.6.0
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
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [añadido](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [eliminado](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) y otros cambios introducidos con la API de Aspose.Slides para .NET 15.6.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **La firma del constructor de DataLabel ha cambiado**
La firma del constructor de DataLabel ha cambiado:
antes: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ahora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Los miembros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) han sido marcados como obsoletos y se han introducido sus sustituciones.**
La propiedad IDocumentProperties.Count y los métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) han sido marcados como obsoletos. En su lugar se han añadido la propiedad IDocumentProperties.CountOfCustomProperties y los métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Se ha añadido el método INotesSlideManager.RemoveNotesSlide()**
Se ha añadido el método INotesSlideManager.RemoveNotesSlide() para eliminar la diapositiva de notas de una diapositiva.
#### **Se ha añadido el método Remove a IComment**
Se ha añadido el método IComment.Remove para eliminar un comentario de la colección.
#### **Se ha añadido el método Remove a ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de los comentarios de la colección.
#### **Se han añadido los métodos ClearCustomProperties y ClearBuiltInProperties a IDocumentProperties**
Se ha añadido el método IDocumentProperties.ClearCustomProperties para eliminar todas las propiedades personalizadas del documento.
Se ha añadido el método IDocumentProperties.ClearBuiltInProperties para eliminar y establecer los valores predeterminados de todas las propiedades integradas del documento (Company, Subject, Author, etc.).
#### **Se han añadido los métodos RemoveAt, Remove y Clear a ICommentAuthorCollection**
Se ha añadido el método ICommentAuthorCollection.RemoveAt para eliminar al autor por el índice especificado.
Se ha añadido el método ICommentAuthorCollection.Remove para eliminar al autor especificado de la colección.
Se ha añadido el método ICommentAuthorCollection.Clear para eliminar todos los elementos de la colección.
#### **Se ha añadido la propiedad AppVersion a IDocumentProperties**
Se ha añadido la propiedad IDocumentProperties.AppVersion para obtener la propiedad integrada del documento que representa los números de versión internos utilizados por Microsoft durante el desarrollo.
#### **Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape**
Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape.

Esta propiedad especifica cómo se mostrará una forma en modo de visualización en blanco y negro.

|**Valor**|**Significado**|
| :- | :- |
|Color|Se muestra con coloreado normal|
|Automatic|Se muestra con coloreado automático|
|Gray|Se muestra con coloreado gris|
|LightGray|Se muestra con coloreado gris claro|
|InverseGray|Se muestra con coloreado gris inverso|
|GrayWhite|Se muestra con coloreado gris y blanco|
|BlackGray|Se muestra con coloreado negro y gris|
|BlackWhite|Se muestra con coloreado negro y blanco|
|Black|Se muestra solo con coloreado negro|
|White|Se muestra con coloreado blanco|
|Hidden|No se muestra|
|NotDefined|significa que la propiedad no está establecida|
#### **Se ha añadido la propiedad ISlide.NotesSlideManager. La propiedad ISlide.NotesSlide y el método ISlide.AddNotesSlide() han sido marcados como obsoletos.**
Los miembros ISlide.NotesSlide e ISlide.AddNotesSlide() han sido marcados como obsoletos. Utilice la nueva propiedad ISlide.NotesSlideManager en su lugar.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```