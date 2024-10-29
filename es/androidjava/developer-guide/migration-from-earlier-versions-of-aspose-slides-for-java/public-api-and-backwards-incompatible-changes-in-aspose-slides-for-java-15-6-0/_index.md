---
title: API Pública y Cambios Incompatibles en Aspose.Slides para Java 15.6.0
type: docs
weight: 140
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introducidos con la API de Aspose.Slides para Java 15.6.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **La firma del constructor de com.aspose.slides.DataLabel ha sido cambiada**
La firma del constructor ha sido cambiada de DataLabel(com.aspose.slides.IChartSeries) a DataLabel(com.aspose.slides.IChartDataPoint).
#### **Los miembros com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) han sido marcados como Obsoletos; se han introducido sustituciones**
Los métodos IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) han sido marcados como Obsoletos. Se han introducido los métodos IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name) en su lugar.
#### **Se ha añadido el método com.aspose.slides.INotesSlideManager.removeNotesSlide()**
Se ha añadido el método com.aspose.slides.INotesSlideManager.removeNotesSlide() para eliminar la diapositiva de notas de alguna diapositiva.
#### **Se ha añadido el método com.aspose.slides.ISlide.getNotesSlideManager(). Los métodos ISlide.getNotesSlide() y ISlide.addNotesSlide() han sido marcados como Obsoletos**
Los métodos ISlide.getNotesSlide() y ISlide.addNotesSlide() han sido marcados como Obsoletos. Usa el nuevo método ISlide.getNotesSlideManager() en su lugar.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - obsoleto

// notes = slide.getNotesSlide(); - obsoleto

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Se ha añadido el método getAppVersion() a com.aspose.slides.IDocumentProperties**
Se ha añadido el método com.aspose.slides.IDocumentProperties.getAppVersion() para obtener la propiedad del documento incorporada, que representa los números de versión interna utilizados por Microsoft PowerPoint.
#### **Se ha añadido el método remove() a com.aspose.slides.IComment**
Se ha añadido el método com.aspose.slides.IComment.remove() para eliminar un comentario de la colección.
#### **Se ha añadido el método remove() a com.aspose.slides.ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de los comentarios de la colección.
#### **Se han añadido los métodos clearCustomProperties() y clearBuiltInProperties() a com.aspose.slides.IDocumentProperties**
Se ha añadido el método com.aspose.slides.IDocumentProperties.clearCustomProperties() para eliminar todas las propiedades de documento personalizadas.
Se ha añadido el método com.aspose.slides.IDocumentProperties.clearBuiltInProperties() para eliminar y establecer valores predeterminados para todas las propiedades de documento incorporadas (Compañía, Asunto, Autor, etc.).
#### **Se han añadido los métodos getBlackWhiteMode(), setBlackWhiteMode(byte) a com.aspose.slides.IShape**
Se han añadido los métodos getBlackWhiteMode(), setBlackWhiteMode(byte) a com.aspose.slides.IShape.
Los métodos especifican cómo una forma se representará en el modo de visualización en blanco y negro. Los posibles valores están especificados en la clase com.aspose.slides.BlackWhiteMode.

|**Valor** |**Significado** |
| :- | :- |
|Color |Retornar con coloración normal |
|Automático |Retornar con coloración automática |
|Gris |Retornar con coloración gris |
|GrisClaro |Retornar con coloración gris claro |
|InversoGris |Retornar con coloración gris inversa |
|GrisBlanco |Retornar con coloración gris y blanca |
|NegroGris |Retornar con coloración negra y gris |
|NegroBlanco |Retornar con coloración negra y blanca |
|Negro |Retornar solo con coloración negra |
|Blanco |Retornar con coloración blanca |
|Oculto |El objeto no se representa |
#### **Se han añadido los métodos removeAt(int), remove(ICommentAuthor) y clear() a com.aspose.slides.ICommentAuthorCollection**
Se ha añadido el método ICommentAuthorCollection.removeAt(int) para eliminar al autor por el índice especificado. Se ha añadido el método ICommentAuthorCollection.remove(ICommentAuthor) para eliminar al autor especificado de la colección. Se ha añadido el método ICommentAuthorCollection.clear() para eliminar todos los elementos de la colección.