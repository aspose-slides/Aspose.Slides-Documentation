---
title: Gestionar etiquetas y datos personalizados en presentaciones usando PHP
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/php-java/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para PHP a través de Java, con ejemplos para presentaciones de PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* como uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le permite tener relaciones explícitas con muchas partes—como las Etiquetas Definidas por el Usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)) y CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Las etiquetas son esencialmente valores de pares cadena‑clave. 
{{% /alert %}} 

## **Obtener valores de las etiquetas**

En las diapositivas, una etiqueta corresponde a los métodos [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) y [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords). Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para PHP a través de Java para [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Añadir etiquetas a presentaciones**

Aspose.Slides le permite añadir etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos:

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones basándose en una regla o propiedad específica, puede beneficiarse de añadir etiquetas a esas presentaciones. Por ejemplo, si desea categorizar o agrupar todas las presentaciones de los países de Norteamérica, puede crear una etiqueta North American y asignar como valores los países relevantes (EE. UU., México y Canadá). 

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) usando Aspose.Slides para PHP a través de Java:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/):
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


O cualquier [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) individual:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor a la vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) en la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.