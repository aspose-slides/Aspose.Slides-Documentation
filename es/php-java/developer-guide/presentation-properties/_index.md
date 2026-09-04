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
description: "Domine las propiedades de presentación en Aspose.Slides for PHP via Java y agilice la búsqueda, la imagen de marca y el flujo de trabajo en sus archivos PowerPowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de documento de una presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/). Una instancia de esta clase se devuelve mediante el método [Presentation::getDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getDocumentProperties). Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los sobrescribe en cada guardado, por lo que una presentación guardada siempre informa "Aspose.Slides for PHP via Java" y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta cuando se escribe la presentación.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint proporciona una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento como se describen a continuación:

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for PHP via Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las personalizadas.

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y, a continuación, en el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007, como se muestra a continuación:

|**Seleccionar la opción Propiedades avanzadas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades de documento del archivo PowerPoint, como se muestra en la figura a continuación:

|**Cuadro de diálogo de Propiedades**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

En el **Cuadro de diálogo de Propiedades** anterior, puede observar que hay varias pestañas como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizada**. Todas estas pestañas permiten configurar distintos tipos de información relacionada con los archivos PowerPoint. La pestaña **Personalizada** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

### Trabajar con propiedades de documento usando Aspose.Slides for PHP via Java

Como describimos anteriormente, Aspose.Slides for PHP via Java admite dos tipos de propiedades de documento, que son **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java proporciona una clase [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **DocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación, como se describe a continuación:

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra pasando `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), sus propiedades de documento permanecen públicas. Entonces, una aplicación puede pasar `true` a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) y leer los metadatos públicos sin proporcionar la contraseña de apertura.

La opción de solo propiedades de documento controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) y luego lee las propiedades integradas mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden exponer nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión de documentos tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada en modo solo propiedades de documento está destinada a leer los metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto solo de metadatos porque las propiedades públicas deben permanecer coherentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword), actualiza las propiedades públicas integradas y guarda el resultado. A continuación, utiliza [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Si a una aplicación no se le permite descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Estas propiedades, tal como las expone el objeto [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

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

Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades integradas del documento de la presentación usando Aspose.Slides for PHP via Java.

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

Este ejemplo modifica las propiedades integradas de la presentación, que pueden verse como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

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

|**Propiedades de documento personalizadas añadidas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for PHP via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

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

Este ejemplo modifica las propiedades personalizadas del [PPTX](https://docs.fileformat.com/presentation/pptx/) de la presentación. Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="info" title="Note" %}}
Se han añadido los nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) y [writeBindedPresentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) a [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo), la lógica del setter de la propiedad [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#setLastSavedTime) ha sido modificada.
{{% /alert %}} 

Los dos nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) y [updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) se han añadido a la clase [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo). Proporcionan acceso rápido a las propiedades de documento y permiten cambiar y actualizar las propiedades sin cargar toda la presentación.

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

Existe otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar las propiedades en otras presentaciones:

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

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el que se verifica la ortografía y la gramática en PowerPoint.

Este código PHP le muestra cómo establecer el idioma de revisión para un PowerPoint: xxx ¿Por qué LanguageId falta en la clase Java PortionFormat?

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

Este código PHP le muestra cómo establecer el idioma predeterminado para una presentación PowerPoint completa:

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

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o dejarlas vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No necesita eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) y luego [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/php-java/examine-presentation/) para ver un ejemplo completo de informe y limitaciones específicas de formato.

**¿Puedo leer las propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. El cifrado de las propiedades del documento debe haberse desactivado antes de que la presentación fuera cifrada, y la presentación debe cargarse en modo solo propiedades de documento.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.