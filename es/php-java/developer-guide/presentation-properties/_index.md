---
title: Administrar propiedades de presentación en PHP
linktitle: Propiedades de presentación
type: docs
weight: 70
url: /es/php-java/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de presentación
- propiedades de documento
- propiedades integradas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos de documento
- editar metadatos
- idioma de revisión
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Administre las propiedades de presentación en Aspose.Slides para PHP a través de Java y agilice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint ofrece una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento:

- Propiedades definidas por el sistema (integradas)
- Propiedades definidas por el usuario (personalizadas)

Las propiedades **integradas** contienen información general sobre el documento, como el título, el nombre del autor, estadísticas del documento, etc. Las propiedades **personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Utilizando Aspose.Slides for PHP via Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas.

{{% /alert %}} 

## **Propiedades del documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es pulsar el icono de Office y, a continuación, el elemento del menú **Preparar | Propiedades | Propiedades avanzadas** de Microsoft PowerPoint 2007, como se muestra a continuación:

{{% alert color="primary" %}} 

Ten en cuenta que no puedes establecer valores en los campos **Aplicación** y **Productor**, porque se mostrará “Aspose Ltd.” y “Aspose.Slides for PHP via Java x.x.x” en esos campos.

{{% /alert %}} 

|**Seleccionar elemento del menú Propiedades avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Propiedades avanzadas**, aparecerá un cuadro de diálogo que permite gestionar las propiedades del documento del archivo PowerPoint, como se muestra en la figura siguiente:

|**Cuadro de diálogo Propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Cuadro de diálogo Propiedades** anterior, puedes ver que hay varias pestañas como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Cada una de estas pestañas permite configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Personalizado** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

### Trabajar con propiedades de documento usando Aspose.Slides for PHP via Java

Como se describió anteriormente, Aspose.Slides for PHP via Java admite dos tipos de propiedades de documento, que son **integradas** y **personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden utilizar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación, como se describe a continuación:

## **Acceder a propiedades integradas**

Estas propiedades, expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de la última impresión), **LastModifiedBy**, **SharedDoc** (¿Está compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**
```php
  # Instanciar la clase Presentation que representa la presentación
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto IDocumentProperties asociado a Presentation
    $dp = $pres->getDocumentProperties();
    # Mostrar las propiedades integradas
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigna un valor de cadena a la propiedad deseada y el valor se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo modificar las propiedades integradas del documento de presentación mediante Aspose.Slides for PHP via Java.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto IDocumentProperties asociado a Presentation
    $dp = $pres->getDocumentProperties();
    # Establecer las propiedades integradas
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Guardar su presentación en un archivo
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Este ejemplo modifica las propiedades integradas de la presentación, que pueden verse como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores agregar valores personalizados a las propiedades del documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.
```php
  $pres = new Presentation();
  try {
    # Obtener propiedades del documento
    $dProps = $pres->getDocumentProperties();
    # Añadir propiedades personalizadas
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Obtener el nombre de la propiedad en un índice concreto
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Eliminar la propiedad seleccionada
    $dProps->removeCustomProperty($getPropertyName);
    # Guardar la presentación
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|**Propiedades de documento personalizadas agregadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puedes acceder y modificar todas estas propiedades personalizadas para una presentación.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto DocumentProperties asociado a Presentation
    $dp = $pres->getDocumentProperties();
    # Acceder y modificar propiedades personalizadas
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Mostrar nombres y valores de las propiedades personalizadas
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modificar valores de las propiedades personalizadas
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Guardar su presentación en un archivo
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Este ejemplo modifica las propiedades personalizadas de la [presentación PPTX](https://docs.fileformat.com/presentation/pptx/). Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades avanzadas de documento**

{{% alert color="primary" %}} 

Se han añadido los nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo), y se ha modificado la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han añadido a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades del documento y permiten cambiarlas y actualizarlas sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento puede implementarse de la siguiente manera:
```php
  # leer la información de la presentación
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtener las propiedades actuales
  $props = $info->readDocumentProperties();
  # establecer los nuevos valores de los campos Autor y Título
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # actualizar la presentación con los nuevos valores
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```


Existe otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```


Se puede crear una nueva plantilla desde cero y luego usarla para actualizar varias presentaciones:
```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```


## **Establecer el idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitir establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el cual se verifica la ortografía y la gramática en PowerPoint.

Este código PHP muestra cómo establecer el idioma de revisión para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase Java PortionFormat?
```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// establecer el Id de un idioma de revisión

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el idioma predeterminado**

Este código PHP muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Añade una nueva forma rectangular con texto
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Comprueba el idioma de la primera porción
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ejemplo en línea**

Prueba la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puedes cambiar sus valores o establecerlas como vacías si la propiedad lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añades una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí, puedes acceder a las propiedades de la presentación sin cargarla completamente usando el método `getPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). Luego, utiliza el método `readDocumentProperties` proporcionado por la clase [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) para leer las propiedades de forma eficiente, ahorrando memoria y mejorando el rendimiento.