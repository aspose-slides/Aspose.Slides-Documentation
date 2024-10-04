---
title: Propiedades de Presentación
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades de documentos como sigue

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

**Las propiedades integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, las estadísticas del documento y así sucesivamente. **Las propiedades personalizadas** son aquellas que son definidas por los usuarios como pares de **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para PHP a través de Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas, así como las propiedades personalizadas.

{{% /alert %}} 

## **Propiedades del Documento en PowerPoint**
Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el icono de Office y luego en el elemento de menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007, como se muestra a continuación:

{{% alert color="primary" %}} 

Ten en cuenta que no puedes establecer valores en los campos **Aplicación** y **Productor**, porque Aspose Ltd. y Aspose.Slides para PHP a través de Java x.x.x se mostrarán en estos campos.

{{% /alert %}} 

|**Seleccionando el elemento de menú Propiedades Avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento de menú **Propiedades Avanzadas**, aparecerá un diálogo que te permitirá gestionar las propiedades del documento del archivo de PowerPoint, como se muestra a continuación en la figura:

|**Diálogo de Propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Diálogo de Propiedades** anterior, puedes ver que hay muchas pestañas como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizado** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.

Trabajando con las Propiedades del Documento Usando Aspose.Slides para PHP a través de Java

Como hemos descrito anteriormente, Aspose.Slides para PHP a través de Java soporta dos tipos de propiedades de documento, que son las propiedades **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades utilizando la API de Aspose.Slides para PHP a través de Java. Aspose.Slides para PHP a través de Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas con un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) objeto para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

## **Acceder a las Propiedades Integradas**
Estas propiedades, como las expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) incluyen: **Creador** (Autor), **Descripción**, **Palabras Clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **Último Modificado Por**, **Palabras Clave**, **Documento Compartido** (¿Está compartido entre diferentes productores?), **Formato de Presentación**, **Tema** y **Título**.

```php
  # Instanciar la clase Presentation que representa la presentación
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto IDocumentProperties asociado con Presentation
    $dp = $pres->getDocumentProperties();
    # Mostrar las propiedades integradas
    echo("Categoría : " . $dp->getCategory());
    echo("Estado Actual : " . $dp->getContentStatus());
    echo("Fecha de Creación : " . $dp->getCreatedTime());
    echo("Autor : " . $dp->getAuthor());
    echo("Descripción : " . $dp->getComments());
    echo("Palabras Clave : " . $dp->getKeywords());
    echo("Último Modificado Por : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Fecha de Modificación : " . $dp->getLastSavedTime());
    echo("Formato de Presentación : " . $dp->getPresentationFormat());
    echo("Última Fecha de Impresión : " . $dp->getLastPrinted());
    echo("¿Está Compartido entre productores? : " . $dp->getSharedDoc());
    echo("Tema : " . $dp->getSubject());
    echo("Título : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo dado a continuación, hemos demostrado cómo podemos modificar las propiedades del documento integradas del archivo de presentación usando Aspose.Slides para PHP a través de Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto IDocumentProperties asociado con Presentation
    $dp = $pres->getDocumentProperties();
    # Establecer las propiedades integradas
    $dp->setAuthor("Aspose.Slides para PHP a través de Java");
    $dp->setTitle("Modificando Propiedades de Presentación");
    $dp->setSubject("Tema de Aspose");
    $dp->setComments("Descripción de Aspose");
    $dp->setManager("Gerente de Aspose");
    # Guardar tu presentación en un archivo
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este ejemplo modifica las propiedades integradas de la presentación que pueden verse como se muestra a continuación:

|**Propiedades del documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar Propiedades de Documento Personalizadas**
Aspose.Slides para PHP a través de Java también permite a los desarrolladores agregar valores personalizados para las propiedades del documento de presentación. Un ejemplo se da a continuación que muestra cómo establecer las propiedades personalizadas para una presentación.

```php
  $pres = new Presentation();
  try {
    # Obtener Propiedades del Documento
    $dProps = $pres->getDocumentProperties();
    # Agregar Propiedades Personalizadas
    $dProps->set_Item("Nueva Personalizada", 12);
    $dProps->set_Item("Mi Nombre", "Mudassir");
    $dProps->set_Item("Personalizada", 124);
    # Obtener el nombre de la propiedad en un índice particular
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Eliminar la propiedad seleccionada
    $dProps->removeCustomProperty($getPropertyName);
    # Guardando la presentación
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Propiedades de Documento Personalizadas Agregadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para PHP a través de Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. Un ejemplo se da a continuación que muestra cómo puedes acceder y modificar todas estas propiedades personalizadas de una presentación.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crear una referencia al objeto DocumentProperties asociado con Presentation
    $dp = $pres->getDocumentProperties();
    # Acceder y modificar propiedades personalizadas
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Mostrar nombres y valores de las propiedades personalizadas
      echo("Nombre de Propiedad Personalizada : " . $dp->getCustomPropertyName($i));
      echo("Valor de Propiedad Personalizada : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modificar valores de las propiedades personalizadas
      $dp->set_Item($dp->getCustomPropertyName($i), "Nuevo Valor " . $i + 1);
    }
    # Guardar tu presentación en un archivo
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX ](https://docs.fileformat.com/presentation/pptx/). Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades Personalizadas antes de la Modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propiedades Personalizadas después de la Modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades Avanzadas del Documento**
{{% alert color="primary" %}} 

Se han agregado nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) y [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo), la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha sido cambiada.

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) han sido agregados a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades del documento y permiten cambiar y actualizar propiedades sin cargar toda la presentación.

El escenario típico carga las propiedades, cambia algún valor y actualiza el documento, que se puede implementar de la siguiente manera:

```php
  # leer la información de la presentación
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtener las propiedades actuales
  $props = $info->readDocumentProperties();
  # establecer los nuevos valores de los campos Autor y Título
  $props->setAuthor("Nuevo Autor");
  $props->setTitle("Nuevo Título");
  # actualizar la presentación con nuevos valores
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

Hay otra forma de usar las propiedades de una presentación particular como plantilla para actualizar propiedades en otras presentaciones:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Autor de Plantilla");
  $template->setTitle("Título de Plantilla");
  $template->setCategory("Categoría de Plantilla");
  $template->setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
  $template->setCompany("Nuestra Empresa");
  $template->setComments("Creado a partir de plantilla");
  $template->setContentType("Contenido de Plantilla");
  $template->setSubject("Tema de Plantilla");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

Se puede crear una nueva plantilla desde cero y luego usarla para actualizar múltiples presentaciones:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Autor de Plantilla");
  $template->setTitle("Título de Plantilla");
  $template->setCategory("Categoría de Plantilla");
  $template->setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
  $template->setCompany("Nuestra Empresa");
  $template->setComments("Creado a partir de plantilla");
  $template->setContentType("Contenido de Plantilla");
  $template->setSubject("Tema de Plantilla");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **Verificar si la Presentación ha sido Modificada o Creada**
Aspose.Slides para PHP a través de Java proporciona la facilidad de verificar si una presentación ha sido modificada o creada. Un ejemplo se da a continuación que muestra cómo verificar si la presentación ha sido creada o modificada.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("Nombre de la Aplicación: " . $app);
  echo("Versión de la Aplicación: " . $ver);

```

## **Establecer el Idioma de Revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirte establecer el idioma de revisión para un documento de PowerPoint. El idioma de revisión es el idioma para el cual se verifica la ortografía y gramática en PowerPoint.

Este código PHP te muestra cómo establecer el idioma de revisión para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase PortionFormat de Java?

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

## **Establecer el Idioma Predeterminado**

Este código PHP te muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Agregar una nueva forma rectangular con texto
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("Nuevo Texto");
    # Verifica el idioma de la primera porción
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```