---
title: Gestionar etiquetas y datos personalizados
type: docs
weight: 300
url: /es/nodejs-java/managing-tags-and-custom-data
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en presentaciones. 

Con una *diapositiva* como uno de los elementos en presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. Una parte de diapositiva puede tener relaciones explícitas con muchas partes—como etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) y CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente pares de valores clave‑cadena. 

{{% /alert %}} 

## **Obtención de los valores de las etiquetas**

En las diapositivas, una etiqueta corresponde a los métodos [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) y [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Este código de ejemplo muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Node.js vía Java para [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation):
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


## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite agregar etiquetas a presentaciones. Una etiqueta típicamente consiste en dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse al agregar etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta “North American” y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este código de ejemplo muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) usando Aspose.Slides para Node.js vía Java:
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


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide):
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


O cualquier [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) individual:
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


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor a la vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.