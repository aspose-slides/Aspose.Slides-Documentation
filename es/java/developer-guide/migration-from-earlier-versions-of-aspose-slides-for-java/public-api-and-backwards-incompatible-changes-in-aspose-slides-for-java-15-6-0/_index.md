---
title: API público y cambios incompatibles hacia atrás en Aspose.Slides para Java 15.6.0
type: docs
weight: 140
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), métodos, propiedades y demás, cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introducidos con la API de Aspose.Slides para Java 15.6.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **La firma del constructor com.aspose.slides.DataLabel ha sido cambiada**
La firma del constructor ha sido cambiada de DataLabel(com.aspose.slides.IChartSeries) a DataLabel(com.aspose.slides.IChartDataPoint).
#### **Los miembros com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) han sido marcados como Obsoletos; se han introducido sustituciones en su lugar**
Los métodos IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) han sido marcados como Obsoletos. Se han introducido en su lugar los métodos IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **El método com.aspose.slides.INotesSlideManager.removeNotesSlide() ha sido agregado**
El método com.aspose.slides.INotesSlideManager.RemoveNotesSlide() ha sido agregado para eliminar la diapositiva de notas de alguna diapositiva.
#### **El método com.aspose.slides.ISlide.getNotesSlideManager() ha sido agregado. Los métodos ISlide.getNotesSlide() y ISlide.addNotesSlide() han sido marcados como Obsoletos**
Los métodos ISlide.getNotesSlide(), ISlide.addNotesSlide() han sido marcados como Obsoletos. Utilice el nuevo método ISlide.getNotesSlideManager() en su lugar.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - obsoleto

// notes = slide.getNotesSlide(); - obsoleto

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **El método getAppVersion() ha sido agregado a com.aspose.slides.IDocumentProperties**
El método com.aspose.slides.IDocumentProperties.getAppVersion() ha sido agregado para obtener la propiedad del documento incorporada, que representa los números de versión interna utilizados por Microsoft PowerPoint.
#### **El método remove() ha sido agregado a com.aspose.slides.IComment**
El método com.aspose.slides.IComment.remove() ha sido agregado para eliminar comentarios de la colección.
#### **El método remove() ha sido agregado a com.aspose.slides.ICommentAuthor**
El método ICommentAuthor.Remove ha sido agregado para eliminar al autor de los comentarios de la colección.
#### **Los métodos clearCustomProperties() y clearBuiltInProperties() han sido agregados a com.aspose.slides.IDocumentProperties**
El método com.aspose.slides.IDocumentProperties.clearCustomProperties() ha sido agregado para eliminar todas las propiedades del documento personalizadas.
El método com.aspose.slides.IDocumentProperties.clearBuiltInProperties() ha sido agregado para eliminar y establecer valores predeterminados para todas las propiedades del documento incorporadas (Compañía, Asunto, Autor, etc.).
#### **Los métodos getBlackWhiteMode(), setBlackWhiteMode(byte) han sido agregados a com.aspose.slides.IShape**
Los métodos getBlackWhiteMode(), setBlackWhiteMode(byte) han sido agregados a com.aspose.slides.IShape.
Los métodos especifican cómo se renderizará una forma en modo de visualización en blanco y negro. Los valores posibles se especifican en la clase com.aspose.slides.BlackWhiteMode.

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
|Oculto |El objeto no se renderiza |
#### **Los métodos removeAt(int), remove(ICommentAuthor) y clear() han sido agregados a com.aspose.slides.ICommentAuthorCollection**
El método ICommentAuthorCollection.removeAt(int) ha sido agregado para eliminar al autor por índice especificado. El método ICommentAuthorCollection.remove(ICommentAuthor) ha sido agregado para eliminar al autor especificado de la colección. El método ICommentAuthorCollection.clear() ha sido agregado para eliminar todos los elementos de la colección.