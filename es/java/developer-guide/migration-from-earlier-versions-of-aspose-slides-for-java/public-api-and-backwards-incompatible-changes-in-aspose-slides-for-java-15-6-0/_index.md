---
title: Cambios de API pública y incompatibles hacia atrás en Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides para Java 15.6.0
type: docs
weight: 140
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios críticos en Aspose.Slides for Java para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="primary" %}} 

Esta página enumera todas las [añadidos](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) clases, métodos, propiedades y demás, cualquiera de las nuevas restricciones y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introducidos con la API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Se ha cambiado la firma del constructor de com.aspose.slides.DataLabel**
La firma del constructor se ha cambiado de DataLabel(com.aspose.slides.IChartSeries) a DataLabel(com.aspose.slides.IChartDataPoint).
#### **Los miembros com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) se han marcado como obsoletos; se han introducido sustitutos**
Los métodos IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) se han marcado como obsoletos. En su lugar se han introducido los métodos IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Se ha añadido el método com.aspose.slides.INotesSlideManager.removeNotesSlide()**
Se ha añadido el método com.aspose.slides.INotesSlideManager.RemoveNotesSlide() para eliminar la diapositiva de notas de una diapositiva.
#### **Se ha añadido el método com.aspose.slides.ISlide.getNotesSlideManager(). Los métodos ISlide.getNotesSlide() y ISlide.addNotesSlide() se han marcado como obsoletos**
Los métodos ISlide.getNotesSlide() y ISlide.addNotesSlide() se han marcado como obsoletos. Utilice el nuevo método ISlide.getNotesSlideManager() en su lugar.

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
Se ha añadido el método com.aspose.slides.IDocumentProperties.getAppVersion() para obtener la propiedad de documento incorporada que representa los números de versión internos utilizados por Microsoft PowerPoint.
#### **Se ha añadido el método remove() a com.aspose.slides.IComment**
Se ha añadido el método com.aspose.slides.IComment.remove() para eliminar un comentario de la colección.
#### **Se ha añadido el método remove() a com.aspose.slides.ICommentAuthor**
Se ha añadido el método ICommentAuthor.Remove para eliminar el autor de los comentarios de la colección.
#### **Se han añadido los métodos clearCustomProperties() y clearBuiltInProperties() a com.aspose.slides.IDocumentProperties**
Se ha añadido el método com.aspose.slides.IDocumentProperties.clearCustomProperties() para eliminar todas las propiedades de documento personalizadas.
Se ha añadido el método com.aspose.slides.IDocumentProperties.clearBuiltInProperties() para eliminar y restablecer los valores predeterminados de todas las propiedades de documento incorporadas (Company, Subject, Author, etc.).
#### **Se han añadido los métodos getBlackWhiteMode() y setBlackWhiteMode(byte) a com.aspose.slides.IShape**
Se han añadido los métodos getBlackWhiteMode() y setBlackWhiteMode(byte) a com.aspose.slides.IShape.  
Los métodos especifican cómo se representará una forma en modo de visualización en blanco y negro. Los valores posibles se definen en la clase com.aspose.slides.BlackWhiteMode.

|**Valor**|**Significado**|
| :- | :- |
|Color|Devuelve con coloración normal|
|Automatic|Devuelve con coloración automática|
|Gray|Devuelve con coloración gris|
|LightGray|Devuelve con coloración gris claro|
|InverseGray|Devuelve con coloración gris inversa|
|GrayWhite|Devuelve con coloración gris y blanca|
|BlackGray|Devuelve con coloración negro y gris|
|BlackWhite|Devuelve con coloración negro y blanco|
|Black|Devuelve únicamente con coloración negra|
|White|Devuelve con coloración blanca|
|Hidden|El objeto no se representa|

#### **Se han añadido los métodos removeAt(int), remove(ICommentAuthor) y clear() a com.aspose.slides.ICommentAuthorCollection**
Se ha añadido el método ICommentAuthorCollection.removeAt(int) para eliminar un autor mediante el índice especificado.  
Se ha añadido el método ICommentAuthorCollection.remove(ICommentAuthor) para eliminar el autor especificado de la colección.  
Se ha añadido el método ICommentAuthorCollection.clear() para eliminar todos los elementos de la colección.