---
title: Gestionar propiedades de la presentación en PHP
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/php-java/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de la presentación
- Propiedades del documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- Presentación
- PHP
- Aspose.Slides
description: "Domina las propiedades de la presentación en Aspose.Slides para PHP a través de Java y optimiza la búsqueda, la identidad corporativa y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides permite trabajar con las propiedades de documento de una presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/) . Una instancia de esta clase se obtiene mediante el método [Presentation::getDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getDocumentProperties) . Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los sobrescribe en cada guardado, de modo que una presentación guardada siempre indica "Aspose.Slides for PHP via Java" y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta cuando se escribe la presentación.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint ofrece una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento:

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título, el autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor los define el usuario. Con Aspose.Slides for PHP via Java, los desarrolladores pueden acceder y modificar tanto los valores de las propiedades integradas como de las personalizadas.

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Sólo tiene que hacer clic en el icono de Office y, a continuación, en el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007, como se muestra a continuación:

|**Seleccionar elemento del menú Propiedades avanzadas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Al seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades de documento del archivo PowerPoint, como se muestra en la figura siguiente:

|**Cuadro de diálogo de propiedades**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Cuadro de diálogo de propiedades** anterior, puede observar que existen varias pestañas, como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar distintos tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

### Trabajar con propiedades de documento usando Aspose.Slides for PHP via Java

Como hemos descrito anteriormente, Aspose.Slides for PHP via Java admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java proporciona la clase [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **DocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación, como se describe a continuación:

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties) incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

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

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Basta con asignar un valor de cadena a la propiedad deseada y el valor se modificará. En el ejemplo que sigue, mostramos cómo modificar las propiedades integradas de documento de un archivo de presentación usando Aspose.Slides for PHP via Java.

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
    # Guardar la presentación en un archivo
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este ejemplo modifica las propiedades integradas de la presentación, como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Añadir propiedades de documento personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de una presentación. A continuación se muestra un ejemplo que indica cómo establecer propiedades personalizadas para una presentación.

```php
  $pres = new Presentation();
  try {
    # Obtener propiedades del documento
    $dProps = $pres->getDocumentProperties();
    # Añadir propiedades personalizadas
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Obtener el nombre de la propiedad en un índice determinado
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

|**Propiedades de documento personalizadas añadidas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que explica cómo acceder y modificar todas estas propiedades personalizadas para una presentación.

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
    # Guardar la presentación en un archivo
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este ejemplo modifica las propiedades personalizadas de la [PPTX](https://docs.fileformat.com/presentation/pptx/) presentación. Las figuras siguientes muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="info" title="Note" %}}
Se han añadido los nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) y [writeBindedPresentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) a [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo); la lógica del setter de la propiedad [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#setLastSavedTime) ha sido modificada.
{{% /alert %}} 

Los dos nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) y [updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) se han añadido a la clase [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo). Proporcionan acceso rápido a las propiedades de documento y permiten cambiar y actualizar propiedades sin cargar toda la presentación.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento puede implementarse de la siguiente manera:

```php
  # leer la información de la presentación
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtener las propiedades actuales
  $props = $info->readDocumentProperties();
  # establecer los nuevos valores de los campos Author y Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # actualizar la presentación con nuevos valores
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

Una nueva plantilla puede crearse desde cero y luego usarse para actualizar múltiples presentaciones:

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

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el que se comprueban la ortografía y la gramática en PowerPoint.

Este código PHP muestra cómo establecer el idioma de revisión para un PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// establecer el Id de un idioma de revisión

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer idioma predeterminado**

Este código PHP muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint:

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

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte esencial de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminar o comprobar la propiedad antes, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) y luego [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos almacenados del documento sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/php-java/examine-presentation/) para un ejemplo completo de informes y limitaciones específicas de formato.