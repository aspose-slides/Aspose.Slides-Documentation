---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.6.0
linktitle: Aspose.Slides para .NET 15.6.0
type: docs
weight: 170
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios de ruptura en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) y otros cambios introducidos con la API de Aspose.Slides para .NET 15.6.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha cambiado la firma del constructor de DataLabel**
Se ha cambiado la firma del constructor de DataLabel:
antes: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ahora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Los miembros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) se han marcado como Obsoletos y se han introducido sus sustitutos.**
La propiedad IDocumentProperties.Count y los métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) se han marcado como Obsoletos. La propiedad IDocumentProperties.CountOfCustomProperties y los métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) se han añadido como sustitutos.
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
Se ha añadido ICommentAuthorCollection.RemoveAt para eliminar un autor por índice especificado.  
Se ha añadido ICommentAuthorCollection.Remove para eliminar un autor específico de la colección.  
Se ha añadido ICommentAuthorCollection.Clear para eliminar todos los elementos de la colección.
#### **Se ha añadido la propiedad AppVersion a IDocumentProperties**
Se ha añadido la propiedad IDocumentProperties.AppVersion para obtener la propiedad integrada del documento que representa los números de versión internos usados por Microsoft durante el desarrollo.
#### **Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape**
Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape.

Esta propiedad especifica cómo se renderizará una forma en modo de visualización en blanco y negro.

|**Valor**|**Significado**|
| :- | :- |
|Color|Renderizar con colores normales|
|Automatic|Renderizar con coloreado automático|
|Gray|Renderizar con coloreado gris|
|LightGray|Renderizar con coloreado gris claro|
|InverseGray|Renderizar con coloreado gris inverso|
|GrayWhite|Renderizar con coloreado gris y blanco|
|BlackGray|Renderizar con coloreado negro y gris|
|BlackWhite|Renderizar con coloreado negro y blanco|
|Black|Renderizar solo con coloreado negro|
|White|Renderizar con coloreado blanco|
|Hidden|No renderizar|
|NotDefined|significa que la propiedad no está establecida|
#### **Se ha añadido la propiedad ISlide.NotesSlideManager. La propiedad ISlide.NotesSlide y el método ISlide.AddNotesSlide() se han marcado como obsoletos.**
Los miembros ISlide.NotesSlide y ISlide.AddNotesSlide() se han marcado como Obsoletos. Use la nueva propiedad ISlide.NotesSlideManager en su lugar.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```