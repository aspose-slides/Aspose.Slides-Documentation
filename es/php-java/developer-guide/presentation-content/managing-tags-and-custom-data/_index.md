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
- XML personalizado
- parte XML personalizada
- metadatos XML
- ItemId
- añadir etiqueta
- pares de valores
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para PHP a través de Java, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Descripción general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de una presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares de cadena clave‑valor simples, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas XML específicas de la aplicación.

Aspose.Slides proporciona API para agregar, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado de flujo de trabajo, metadatos de cumplimiento, datos de vinculación de plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se guardan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura de paquetes y relaciones utilizadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene varias partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una sola diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/)) o como partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/)). Ambas están disponibles a través de la clase [`CustomData`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Las etiquetas almacenan pares de cadena clave‑valor simples. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.
{{% /alert %}}

## **Trabajar con partes XML personalizadas**

El método [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customdata/#getCustomXmlParts) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- `$presentation->getCustomData()->getCustomXmlParts()` contiene partes XML personalizadas asociadas a la propia presentación.
- `$slide->getCustomData()->getCustomXmlParts()` contiene partes XML personalizadas asociadas a una diapositiva concreta.
- `$shape->getCustomData()->getCustomXmlParts()` contiene partes XML personalizadas asociadas a una forma concreta.

Utilice [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getAllCustomXmlParts) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, independientemente de dónde estén asociadas.

### **Agregar una parte XML personalizada a una presentación**

Use [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/#add) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no estar vacío.

El siguiente ejemplo añade metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add asigna un identificador automáticamente. Establezca un UUID específico solo cuando sea necesario.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El método `add` también puede aceptar XML como matriz de bytes o flujo de entrada, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Agregar una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de enlace.

El siguiente ejemplo añade una parte XML personalizada a una diapositiva y otra a una forma:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El nivel en el que se añade una parte determina qué colección `getCustomData()->getCustomXmlParts()` del objeto contiene la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getAllCustomXmlParts) para obtener todas las partes XML personalizadas de una presentación. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/) expone su identificador, contenido XML y los esquemas de espacios de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacios de nombres:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contienen XML producido por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Use [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#getXmlAsString) y [`setXmlAsString()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#setXmlAsString) para trabajar con XML como cadena UTF‑8, o [`getXmlData()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#getXmlData) y [`setXmlData()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#setXmlData) para trabajar con los bytes XML sin procesar.

El método [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#getItemId) devuelve el UUID que identifica la parte XML personalizada en el documento Office Open XML. Use [`setItemId()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#setItemId) cuando una integración requiera un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Leer el XML actual como texto.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Actualizar el XML como cadena UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData proporciona el mismo contenido XML como bytes sin procesar.
    $customXmlData = $customXmlPart->getXmlData();

    // Reemplazar el identificador cuando lo requiera la integración.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Al llamar a `setXmlAsString` o `setXmlData`, proporcione XML válido y no vacío. Use una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpart/#remove) elimina la parte XML personalizada de la presentación.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/#remove) elimina una parte concreta de una colección de partes XML personalizadas.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/#removeAt) elimina la parte en el índice de colección especificado.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/es/php-java/aspose.slides/customxmlpartcollection/#clear) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si ya dispone de un `CustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `$customXmlPart->remove()`.

También puede eliminar un elemento por índice:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Borrar todas las partes XML personalizadas de una colección**

Use `clear` cuando todas las partes XML personalizadas asociadas a un objeto de presentación concreto deban eliminarse.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` afecta solo a la colección seleccionada. Por ejemplo, borrar la colección de una diapositiva no borra las colecciones a nivel de presentación o forma.

Para eliminar cada parte XML personalizada de la presentación, recorra `getAllCustomXmlParts()` y elimine cada parte:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gestionar partes XML personalizadas enlazadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada desde más de un objeto de la presentación. Por ejemplo, un archivo existente puede contener relaciones desde varias diapositivas o formas hacia la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizarla con `setXmlAsString`, `setXmlData` o `setItemId` modifica la parte XML subyacente, por lo que el cambio se aplica dondequiera que esa parte esté referenciada.
- `getItemId()` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `getCustomXmlParts()` concreta la elimina de esa colección. Use `CustomXmlPart::remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas siguen referenciándola.

Las sobrecargas de `add` crean una nueva parte XML personalizada a partir del contenido XML; no aceptan un `CustomXmlPart` existente. Por lo tanto, las relaciones compartidas se encuentran con mayor frecuencia al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita las colecciones a nivel de presentación, diapositiva y forma por `ItemId` e informa de las partes referenciadas desde más de un lugar:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, porque la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde al método `DocumentProperties::getKeywords()`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para PHP vía Java para [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad específica, puede agregar etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países norteamericanos, puede crear una etiqueta “NorthAmerican” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) usando Aspose.Slides para PHP vía Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

O para una [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) individual:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección `getCustomData()->getTags()` se almacenan solo en el archivo PowerPoint. No se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, `$shape->setAlternativeText("MyId")`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/#clear) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [remove(name)](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/#remove) en la [colección de etiquetas](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [getNamesOfTags](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/#getNamesOfTags) en la [colección de etiquetas](https://reference.aspose.com/slides/es/php-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Use [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getAllCustomXmlParts) para obtener todas las partes XML personalizadas de la presentación.

**¿Debo usar `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` para actualizar una parte XML personalizada?**

Use `getXmlAsString` y `setXmlAsString` cuando la aplicación trabaje con texto XML UTF‑8. Use `getXmlData` y `setXmlData` cuando el XML ya esté disponible como matriz de bytes o cuando el procesamiento orientado a binarios sea más conveniente. Ambas representaciones se refieren al contenido XML de la misma parte XML personalizada.