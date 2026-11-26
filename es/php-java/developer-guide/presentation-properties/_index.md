---
title: Gestionar propiedades de presentación en PHP
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/php-java/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades integradas
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
description: "Domina las propiedades de presentación en Aspose.Slides for PHP via Java y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides for PHP via Java soporta propiedades de documento **integradas** y **personalizadas**. Utilice estas propiedades para leer y actualizar los metadatos de la presentación, como el autor, el título y los valores definidos por el usuario.

Aspose.Slides le permite trabajar con las propiedades de documento de la presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . Una instancia de esta clase se devuelve mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) . Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades. Suponen que PHP/Java Bridge y el wrapper PHP de Aspose.Slides están inicializados.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestiona los metadatos de la aplicación y del productor al guardar presentaciones; estos campos identifican el software que creó la salida.
{{% /alert %}}

## **Gestionar propiedades de la presentación**

Las propiedades del documento almacenan información descriptiva junto al contenido de la presentación. Se dividen en dos categorías:

- **Propiedades integradas** contienen metadatos estándar, como el título, el autor y las estadísticas del documento.
- **Propiedades personalizadas** almacenan pares nombre/valor definidos por el usuario.

Aspose.Slides for PHP via Java proporciona acceso a ambas categorías. En PowerPoint, seleccione **Archivo → Información → Propiedades → Propiedades avanzadas** para inspeccionar los metadatos del documento. El cuadro de diálogo agrupa la información en pestañas como **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Utilice la pestaña **Personalizado** para gestionar las propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra después de llamar a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `false`, sus propiedades de documento permanecen públicas. Entonces una aplicación puede llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `true` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El ejemplo requiere una presentación cifrada cuyas propiedades de documento se dejaron públicas. Verifica el modo de carga a través de [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) y luego lee las propiedades integradas mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

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

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden exponer nombres de autor, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexado, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada después de llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `true` está destinada a leer metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto de solo metadatos porque las propiedades públicas deben seguir siendo coherentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, la actualización requiere la contraseña de apertura correcta y una carga completa.

El ejemplo requiere una presentación PPTX cifrada con propiedades de documento públicas y una contraseña de apertura conocida. Abre la presentación completa con [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword), actualiza las propiedades integradas públicas y guarda el resultado. Luego usa [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

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

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

La clase [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) expone los metadatos integrados mediante métodos getter, incluidos [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) y [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime). Este ejemplo abre una presentación existente y muestra sus metadatos almacenados en la consola. Los valores dependen de la presentación de entrada; algunos campos pueden estar vacíos.

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

### **Informar número de revisión y tiempo de edición**

Para informar el número de revisión y el tiempo total de edición de cada archivo PPTX en la carpeta `presentations`, use [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer sus [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) sin cargar las diapositivas para editarlas. La API PHP via Java devuelve el tiempo de edición en milisegundos. El ejemplo lo convierte a horas, minutos y segundos e incluye un recuento de días para duraciones de 24 horas o más.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

Para una presentación con número de revisión 17 y un tiempo de edición registrado de 1 día, 2 horas y 5 minutos, el informe muestra la siguiente salida.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) lee un valor que las aplicaciones pueden cambiar con [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) . El número de revisión por sí solo no puede establecer cuántas veces se ha guardado la presentación ni reconstruir su historial de versiones.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) lee la duración de edición registrada en el archivo. Una presentación puede tener una duración almacenada de cero (`00:00:00`) aunque alguien la haya editado.

## **Modificar propiedades integradas**

Para actualizar los metadatos integrados, utilice los métodos setter del objeto devuelto por [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) . Este ejemplo abre una presentación existente, llama a [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor) , [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle) , [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject) , [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) y [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) , y luego guarda la presentación actualizada con [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) . El PPTX guardado contiene los nuevos metadatos.

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

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) devuelve la base a nivel de documento para hipervínculos relativos. Utilice [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) para cambiarla o vaciarla. Esto es útil al mover una presentación y sus archivos vinculados a otra ubicación. Es independiente del método [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) de un hipervínculo individual: cambiar la base no reescribe las direcciones de enlace almacenadas ni modifica destinos absolutos.

El ejemplo necesita una presentación que contenga tanto un vínculo relativo, como `target.html`, como un vínculo absoluto, como `https://example.org/absolute.html` . Lee la base existente, asigna una nueva dirección base y guarda y vuelve a abrir la presentación para comprobar el valor. Luego vacía la base con una cadena vacía y verifica el valor vacío en un archivo guardado separado. Sustituya la dirección base del ejemplo por la ubicación de sus archivos vinculados.

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

Un enlace relativo a `target.pptx` abrió `old/target.pptx` cuando la base apuntaba a la carpeta `old`. Tras cambiar la base a la carpeta `new`, guardar y volver a abrir la presentación, el mismo enlace abrió `new/target.pptx`. Un enlace absoluto siguió abriendo el mismo archivo. Pruebe sus enlaces relativos en PowerPoint antes y después de mover la presentación o cambiar su base.

## **Añadir propiedades de presentación personalizadas**

Las propiedades personalizadas almacenan metadatos que no tienen un campo integrado correspondiente. El método [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) le permite asignar un valor por nombre de propiedad. Este ejemplo crea una presentación, añade dos valores de texto y un valor entero de versión, y guarda la presentación con [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) . Asignar un valor a un nombre existente reemplaza el valor de esa propiedad.

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

Este ejemplo abre una presentación que contiene propiedades personalizadas y utiliza [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) para iterar sobre ellas. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) acepta un índice basado en cero y devuelve el nombre usado por [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) . El ejemplo imprime cada nombre y valor original, reemplaza cada valor por una cadena numerada sin importar su tipo original y guarda los cambios. Si no hay propiedades personalizadas, el bucle no realiza cambios.

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

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual se sobrescribirá con el nuevo. No es necesario eliminarla o comprobarla antes, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) y luego [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) . Consulte [Crear un inventario de presentaciones ligeras](/slides/es/php-java/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas por formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada después de llamar a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `false`, y debe cargarse después de llamar a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `true`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo‑propiedades‑de‑documento?**

No. Los datos de propiedades públicas y cifradas deben mantenerse coherentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.