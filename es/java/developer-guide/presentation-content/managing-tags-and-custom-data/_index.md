---
title: Gestionar etiquetas y datos personalizados en presentaciones usando Java
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/java/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Java, con ejemplos para presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en los archivos PPTX, indica que los datos específicos de la presentación pueden existir como etiquetas y partes XML personalizadas, y define las etiquetas como pares de cadena clave-valor.

También muestra cómo leer los valores de las etiquetas y cómo agregar etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas habituales de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y obtener la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas a muchas partes—como Etiquetas definidas por el usuario—definidas por ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Las etiquetas son esencialmente valores de pares cadena-clave. 
{{% /alert %}} 

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/es/java/com.aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/es/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Java para [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite agregar etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea categorizar o agrupar todas las presentaciones de los países de América del Norte, puede crear una etiqueta de América del Norte y asignar los países relevantes (EE. UU., México y Canadá) como valores.

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation) usando Aspose.Slides para Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

O cualquier [Shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) individual:

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

Las etiquetas añadidas mediante la colección de etiquetas de datos personalizados usando `getCustomData().getTags()` se almacenan solo dentro del archivo de PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Workaround**: Puede almacenar un identificador personalizado en el **Alt Text** del objeto (p. ej., `shape.setAlternativeText("MyId")`). Después de exportar a PDF, el Alt Text puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/) soporta una operación [clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/#clear--) que elimina todos los pares clave-valor a la vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) sobre la [tag collection](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [getNamesOfTags](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/#getNamesOfTags--) en la [tag collection](https://reference.aspose.com/slides/es/java/com.aspose.slides/tagcollection/); devuelve un array con todos los nombres de etiquetas.