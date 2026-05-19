---
title: Gestionar etiquetas y datos personalizados en presentaciones usando JavaScript
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/nodejs-java/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Node.js, con ejemplos para presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en los archivos PPTX, indica que los datos específicos de la presentación pueden existir como etiquetas y partes XML personalizadas, y define las etiquetas como pares de cadena clave‑valor.

También muestra cómo leer los valores de las etiquetas y cómo añadir etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas comunes de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y obtener la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se guardan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos de una presentación, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas con muchas partes, como las Etiquetas definidas por el usuario, definidas por la ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/TagCollection)) y CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Las etiquetas son esencialmente valores de pares cadena‑clave. 
{{% /alert %}} 

## **Obtener los valores de las etiquetas**

En slides, una etiqueta corresponde a los métodos [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) y [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides for Node.js via Java para [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede resultar útil añadir etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países de Norteamérica, puede crear una etiqueta “North American” y asignar como valores los países relevantes (EE. UU., México y Canadá).

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) usando Aspose.Slides for Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

O cualquier [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/AutoShape) individual:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección de etiquetas de datos personalizados usando `getCustomData().getTags()` se almacenan únicamente dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Alt Text** del objeto (p. ej., `shape.setAlternativeText("MyId")`). Después de exportar a PDF, el Alt Text puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una sola vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/remove/) en la [TagCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiqueta para análisis o filtrado?**

Use [getNamesOfTags](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) en la [colección de etiquetas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiqueta.