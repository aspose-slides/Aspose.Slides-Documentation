---
title: Cambios de API pública y de incompatibilidad retroactiva en Aspose.Slides para .NET 15.6.0
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
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc., [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), y otros cambios introducidos con la API de Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Se ha cambiado la firma del constructor de DataLabel**
Se ha cambiado la firma del constructor de DataLabel:
antes: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ahora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Los miembros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name) y .Contains(string name) han sido marcados como obsoletos y se han introducido sus sustitutos.**
La propiedad IDocumentProperties.Count y los métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name) y .Contains(string name) han sido marcados como obsoletos. En su lugar se han añadido la propiedad IDocumentProperties.CountOfCustomProperties y los métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name) y .ContainsCustomProperty(string name).
#### **Se ha añadido el método INotesSlideManager.RemoveNotesSlide()**
Se ha añadido el método INotesSlideManager.RemoveNotesSlide() para eliminar la diapositiva de notas de una diapositiva.
#### **Se ha añadido el método Remove a IComment**
Se ha añadido el método IComment.Remove para eliminar un comentario de la colección.
#### **Se ha añadido el método Remove a ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de los comentarios de la colección.
#### **Se han añadido los métodos ClearCustomProperties y ClearBuiltInProperties a IDocumentProperties**
Se ha añadido el método IDocumentProperties.ClearCustomProperties para eliminar todas las propiedades de documento personalizadas.  
Se ha añadido el método IDocumentProperties.ClearBuiltInProperties para eliminar y establecer valores predeterminados para todas las propiedades de documento incorporadas (Company, Subject, Author, etc.).
#### **Se han añadido los métodos RemoveAt, Remove y Clear a ICommentAuthorCollection**
Se ha añadido ICommentAuthorCollection.RemoveAt para eliminar al autor por el índice especificado.  
Se ha añadido ICommentAuthorCollection.Remove para eliminar al autor especificado de la colección.  
Se ha añadido ICommentAuthorCollection.Clear para eliminar todos los elementos de la colección.
#### **Se ha añadido la propiedad AppVersion a IDocumentProperties**
Se ha añadido la propiedad IDocumentProperties.AppVersion para obtener la propiedad de documento incorporada que representa los números de versión internos utilizados por Microsoft durante el desarrollo.
#### **Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape**
Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape.

Esta propiedad especifica cómo se renderizará una forma en modo de visualización en blanco y negro.

|**Valor**|**Significado**|
| :- | :- |
|Color|Renderizar con colores normales|
|Automatic|Renderizar con coloración automática|
|Gray|Renderizar con coloración gris|
|LightGray|Renderizar con coloración gris claro|
|InverseGray|Renderizar con coloración gris inversa|
|GrayWhite|Renderizar con coloración gris y blanco|
|BlackGray|Renderizar con coloración negro y gris|
|BlackWhite|Renderizar con coloración negro y blanco|
|Black|Renderizar solo con coloración negra|
|White|Renderizar con coloración blanca|
|Hidden|No renderizar|
|NotDefined|significa que la propiedad no está establecida|
#### **Se ha añadido la propiedad ISlide.NotesSlideManager. Las propiedades ISlide.NotesSlide y el método ISlide.AddNotesSlide() han sido marcados como obsoletos.**
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