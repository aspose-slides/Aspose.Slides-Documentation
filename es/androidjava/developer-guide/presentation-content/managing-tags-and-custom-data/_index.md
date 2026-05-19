---
title: Gestionar etiquetas y datos personalizados en presentaciones en Android
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/androidjava/managing-tags-and-custom-data
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Android, con ejemplos en Java para presentaciones PowerPoint y OpenDocument."
---
## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le permiten relaciones explícitas con muchas partes—como las etiquetas definidas por el usuario—definidas por la ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente valores de pares clave-cadena. 

{{% /alert %}} 

## **Obtener valores de etiquetas**

En las diapositivas, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Android mediante Java para [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta suele constar de dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones según una regla o propiedad específica, puede resultarte útil añadir etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o agrupar todas las presentaciones de los países de América del Norte, puedes crear una etiqueta América del Norte y asignar como valores los países correspondientes (EE.UU., México y Canadá). 

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) usando Aspose.Slides para Android mediante Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

O cualquier [Shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IAutoShape) individual:

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

### **Limitaciones**

Las etiquetas añadidas mediante la colección de etiquetas de datos personalizados usando `getCustomData().getTags()` se almacenan únicamente dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puedes almacenar un identificador personalizado en el **Texto alternativo** del objeto (p. ej., `shape.setAlternativeText("MyId")`). Tras exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#clear--) que elimina todos los pares clave-valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utiliza la operación [remove(name)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) en la [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utiliza [getNamesOfTags](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) en la [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.