---
title: Administrar etiquetas y datos personalizados en presentaciones usando Java
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/java/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- agregar etiqueta
- valores de pares
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo agregar, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Java, con ejemplos para presentaciones PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le permite tener relaciones explícitas con muchas partes—como las etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Las etiquetas son esencialmente valores de pares cadena‑clave. 
{{% /alert %}} 

## **Obtener valores de etiquetas**

En diapositivas, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Java para [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite agregar etiquetas a presentaciones. Una etiqueta típicamente consta de dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones en función de una regla o propiedad específica, puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea categorizar o agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) usando Aspose.Slides para Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


O cualquier [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una única operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) en la [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) en la [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.