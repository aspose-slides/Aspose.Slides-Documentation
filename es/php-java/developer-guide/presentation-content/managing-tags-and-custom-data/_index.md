---
title: Gestión de Etiquetas y Datos Personalizados
type: docs
weight: 300
url: /es/php-java/managing-tags-and-custom-data

---

## Almacenamiento de Datos en Archivos de Presentación

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura para los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. Se permite que una parte de diapositiva tenga relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por la ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente pares de valores clave de cadena.

{{% /alert %}} 

## Obteniendo los Valores de las Etiquetas

En las diapositivas, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Este código de muestra te muestra cómo obtener el valor de una etiqueta con Aspose.Slides para PHP a través de Java para [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):

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

## Añadiendo Etiquetas a las Presentaciones

Aspose.Slides te permite añadir etiquetas a las presentaciones. Una etiqueta típicamente consiste en dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones basadas en una regla o propiedad específica, entonces podrías beneficiarte de añadir etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o agrupar todas las presentaciones de países de América del Norte, puedes crear una etiqueta de América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como los valores.

Este código de muestra te muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) usando Aspose.Slides para PHP a través de Java:

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

Las etiquetas también se pueden establecer para [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide):

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