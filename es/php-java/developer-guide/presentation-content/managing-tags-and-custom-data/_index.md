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
- agregar etiqueta
- pares de valores
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a agregar, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para PHP via Java, con ejemplos para presentaciones PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en presentaciones. 

Con una *diapositiva* como uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas a muchas partes—como Etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente pares clave‑valor de tipo cadena. 

{{% /alert %}} 

## **Obtener valores de etiquetas**

En diapositivas, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Este ejemplo de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides for PHP via Java para [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
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


## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta típicamente consta de dos elementos: 

- el nombre de una propiedad personalizada – `MyTag` 
- el valor de la propiedad personalizada – `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse añadiendo etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de los países de América del Norte, puede crear una etiqueta América del Norte y asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este ejemplo de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) usando Aspose.Slides for PHP via Java:
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


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide):
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


O cualquier [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) individual:
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


## **FAQ**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor a la vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) en la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.