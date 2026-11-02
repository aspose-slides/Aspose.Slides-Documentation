---
title: Gestionar propiedades de la presentación en PHP
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/php-java/presentation-properties/
keywords:
- Propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades incorporadas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos del documento
- editar metadatos
- idioma de revisión
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides para PHP vía Java y optimice la búsqueda, la imagen de marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides for PHP via Java admite **propiedades incorporadas** y **personalizadas** de documentos. Use estas propiedades para leer y actualizar los metadatos de la presentación, como el autor, el título y los valores definidos por el usuario.

Aspose.Slides le permite trabajar con las propiedades del documento de la presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/). Una instancia de esta clase se devuelve mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Los siguientes ejemplos muestran cómo leer, modificar y administrar estas propiedades. Suponen que PHP/Java Bridge y el wrapper de Aspose.Slides para PHP están inicializados.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestiona los metadatos de la aplicación y del productor al guardar presentaciones; estos campos identifican el software que creó la salida.
{{% /alert %}}

## **Gestionar propiedades de la presentación**

Las propiedades del documento almacenan información descriptiva junto al contenido de la presentación. Se dividen en dos categorías:

- **Propiedades incorporadas** que contienen metadatos estándar, como el título, el autor y estadísticas del documento.
- **Propiedades personalizadas** que almacenan pares nombre/valor definidos por el usuario.

Aspose.Slides for PHP via Java proporciona acceso a ambas categorías. En PowerPoint, seleccione **Archivo → Información → Propiedades → Propiedades avanzadas** para inspeccionar los metadatos del documento. El diálogo agrupa la información en pestañas como **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Utilice la pestaña **Personalizado** para gestionar las propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra después de llamar a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) con `false`, sus propiedades del documento permanecen públicas. Entonces una aplicación puede llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) con `true` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades fueron incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El ejemplo requiere una presentación cifrada cuyas propiedades del documento fueron dejadas públicas. Verifica el modo de carga mediante [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) y luego lee las propiedades incorporadas mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexado, clasificación, búsqueda o gestión documental requieran acceder a ellas sin una contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada después de llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) con `true` está destinada a leer metadatos públicos. Aspose.Slides no puede guardar propiedades modificadas de ese objeto solo de metadatos porque las propiedades públicas deben permanecer coherentes con los datos correspondientes dentro de la presentación cifrada. Por ello, la actualización requiere la contraseña de apertura correcta y una carga completa.

El ejemplo requiere una presentación PPTX cifrada con propiedades del documento públicas y una contraseña de apertura conocida. Abre la presentación completa con [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), actualiza las propiedades incorporadas públicas y guarda el resultado. Luego usa [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

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
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
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
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Si a una aplicación no se le permite descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades incorporadas**

La clase [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) expone los metadatos incorporados a través de métodos getter, incluidos [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) y [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Este ejemplo abre una presentación existente e imprime sus metadatos almacenados en la consola. Los valores dependen de la presentación de entrada; algunos campos pueden estar vacíos.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Modificar propiedades incorporadas**

Para actualizar los metadatos incorporados, use los métodos setter del objeto devuelto por [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Este ejemplo abre una presentación existente, llama a [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) y [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), y luego guarda la presentación actualizada con [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). El PPTX guardado contiene los nuevos metadatos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gestionar la base de hipervínculos**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) devuelve la base a nivel de documento para hipervínculos relativos. Use [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) para cambiarla o vaciarla. Esto es útil al mover una presentación y sus archivos enlazados a otra ubicación. Es independiente del [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) de un hipervínculo individual: cambiar la base no reescribe las direcciones de los enlaces almacenados ni modifica destinos absolutos.

El ejemplo requiere una presentación que contenga tanto un enlace relativo, como `target.html`, como un enlace absoluto, como `https://example.org/absolute.html`. Lee la base existente, asigna una nueva dirección base y guarda y vuelve a abrir la presentación para comprobar el valor. Luego vacía la base con una cadena vacía y verifica el valor vacío en un archivo guardado por separado. Reemplace la dirección base de ejemplo con la ubicación de sus archivos enlazados.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Los dos mensajes de verificación deberían imprimir `true`. Vaciar la base deja intactas las direcciones de los hipervínculos individuales.

Un enlace relativo a `target.pptx` abrió `old/target.pptx` cuando la base apuntaba a la carpeta `old`. Después de cambiar la base a la carpeta `new`, guardar y volver a abrir la presentación, el mismo enlace abrió `new/target.pptx`. Un enlace absoluto continuó abriendo el mismo archivo. Pruebe sus enlaces relativos en PowerPoint antes y después de mover la presentación o cambiar su base.

## **Añadir propiedades personalizadas a la presentación**

Las propiedades personalizadas almacenan metadatos que no tienen un campo incorporado correspondiente. El método [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) le permite asignar un valor mediante el nombre de la propiedad. Este ejemplo crea una presentación, añade dos valores de texto y un valor entero de versión, y guarda la presentación con [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Asignar un valor a un nombre existente sustituye el valor de esa propiedad.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acceder y modificar propiedades personalizadas**

Este ejemplo abre una presentación que contiene propiedades personalizadas y usa [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) para iterar sobre ellas. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) acepta un índice basado en cero y devuelve el nombre usado por [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). El ejemplo imprime cada nombre y valor original, sustituye cada valor por una cadena numerada independientemente de su tipo original, y guarda los cambios. Si no existen propiedades personalizadas, el bucle no realiza cambios.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Ver y editar metadatos de PowerPoint**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento usando la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad incorporada de una presentación?**

Las propiedades incorporadas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o dejarlas vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminarla o comprobarla previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) y luego [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Consulte [Construir un inventario ligero de presentaciones](/slides/es/php-java/examine-presentation/) para un ejemplo completo de informes y limitaciones específicas por formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada después de llamar a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) con `false`, y debe cargarse después de llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) con `true`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades del documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer coherentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.