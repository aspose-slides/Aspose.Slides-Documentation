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
- pares de valores
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides for PHP via Java, con ejemplos para presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Este artículo explica cómo funciona Aspose.Slides con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en archivos PPTX, indica que los datos específicos de una presentación pueden existir como etiquetas y partes XML personalizadas, y define las etiquetas como pares de cadena clave‑valor.

También muestra cómo leer valores de etiquetas y cómo añadir etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas comunes de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y obtener la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se guardan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/)) y partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente valores de pares clave‑cadena. 

{{% /alert %}} 

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde a los métodos [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getKeywords) y [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#setKeywords). Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides for PHP via Java para [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation):

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

Aspose.Slides permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse añadiendo etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta *North American* y asignar los países pertinentes (EE. UU., México y Canadá) como valores. 

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation) usando Aspose.Slides for PHP via Java:

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

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/):

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

O cualquier [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) individual:

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

### **Limitaciones**

Las etiquetas añadidas a través de la colección de etiquetas de datos personalizados mediante `getCustomData()->getTags()` se almacenan solo dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede guardar un identificador personalizado en el **Texto alternativo** del objeto (p. ej., `$shape->setAlternativeText("MyId")`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una única operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una sola vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/remove/) en la [tag collection](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [getNamesOfTags](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.