---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 15.6.0
type: docs
weight: 170
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc., [añadidos](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [eliminados](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.6.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **La firma del constructor DataLabel ha sido cambiada**
La firma del constructor DataLabel ha sido cambiada:
era: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ahora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Los miembros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) han sido marcados como Obsoletos y sus sustituciones han sido introducidas.**
La propiedad IDocumentProperties.Count y los métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) han sido marcados como Obsoletos. La propiedad IDocumentProperties.CountOfCustomProperties y los métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) han sido añadidos en su lugar.
#### **El método INotesSlideManager.RemoveNotesSlide() ha sido añadido**
Se ha añadido el método INotesSlideManager.RemoveNotesSlide() para eliminar la diapositiva de notas de alguna diapositiva.
#### **El método Remove ha sido añadido a IComment**
Se ha añadido el método IComment.Remove para eliminar un comentario de la colección.
#### **El método Remove ha sido añadido a ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de comentarios de la colección.
#### **Los métodos ClearCustomProperties y ClearBuiltInProperties han sido añadidos a IDocumentProperties**
Se ha añadido el método IDocumentProperties.ClearCustomProperties para eliminar todas las propiedades personalizadas del documento.
Se ha añadido el método IDocumentProperties.ClearBuiltInProperties para eliminar y establecer valores predeterminados para todas las propiedades incorporadas del documento (Compañía, Asunto, Autor, etc.).
#### **Los métodos RemoveAt, Remove y Clear han sido añadidos a ICommentAuthorCollection**
Se ha añadido el método ICommentAuthorCollection.RemoveAt para eliminar el autor por índice específico.
Se ha añadido el método ICommentAuthorCollection.Remove para eliminar el autor especificado de la colección.
Se ha añadido el método ICommentAuthorCollection.Clear para eliminar todos los elementos de la colección.
#### **La propiedad AppVersion ha sido añadida a IDocumentProperties**
Se ha añadido la propiedad IDocumentProperties.AppVersion para obtener la propiedad de documento incorporada que representa los números de versión interna utilizados por Microsoft durante el desarrollo.
#### **La propiedad BlackWhiteMode ha sido añadida a IShape y a Shape**
Se ha añadido la propiedad BlackWhiteMode a IShape y a Shape.

Esta propiedad especifica cómo se renderiza una forma en modo de pantalla en blanco y negro.

|**Valor** |**Significado** |
| :- | :- |
|Color |Renderizar con color normal |
|Automático |Renderizar con color automático |
|Gris |Renderizar con color gris |
|GrisClaro |Renderizar con color gris claro |
|GrisInverso |Renderizar con color gris inverso |
|GrisBlanco |Renderizar con color gris y blanco |
|NegroGris |Renderizar con color negro y gris |
|NegroBlanco |Renderizar con color negro y blanco |
|Negro |Renderizar solo con color negro |
|Blanco |Renderizar con color blanco |
|Oculto |No renderizar |
|NoDefinido|significa que la propiedad no está establecida|
#### **La propiedad ISlide.NotesSlideManager ha sido añadida. La propiedad ISlide.NotesSlide y el método ISlide.AddNotesSlide() han sido marcados como Obsoletos.**
Los miembros ISlide.NotesSlide, ISlide.AddNotesSlide() han sido marcados como Obsoletos. Utilice la nueva propiedad ISlide.NotesSlideManager en su lugar.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsoleto

// notes = slide.NotesSlide; - obsoleto

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 