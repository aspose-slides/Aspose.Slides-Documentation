---
title: Gestionar etiquetas y datos personalizados en presentaciones usando JavaScript
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para Node.js vía Java, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Descripción general**

Este artículo explica cómo Aspose.Slides funciona con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de la presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares clave‑valor de cadena simples, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas XML específicas de la aplicación.

Aspose.Slides ofrece API para añadir, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado de flujo de trabajo, metadatos de cumplimiento, datos de enlace a plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se guardan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura del paquete y las relaciones usadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene varias partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una sola diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/)) o como partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpartcollection/)). Ambas están disponibles a través de la clase [`CustomData`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Las etiquetas almacenan pares clave‑valor de cadena simples. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.
{{% /alert %}}

## **Trabajar con partes XML personalizadas**

El método `getCustomXmlParts()` de [`CustomData`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customdata/) devuelve la colección de partes XML personalizadas asociadas a un objeto concreto de presentación. Por ejemplo:

- `presentation.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a la propia presentación.
- `slide.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a una diapositiva específica.
- `shape.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a una forma específica.

Utilice [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación sin importar dónde estén asociadas.

### **Añadir una parte XML personalizada a una presentación**

Use el método `add` de [`CustomXmlPartCollection`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpartcollection/) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no estar vacío.

El siguiente ejemplo añade metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add asigna un identificador automáticamente. Establezca un UUID específico solo cuando sea necesario.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El método `add` también puede aceptar XML como un array de bytes, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Añadir una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de enlace.

El siguiente ejemplo añade una parte XML personalizada a una diapositiva y otra a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El nivel en el que se añade una parte determina en qué colección `getCustomData().getCustomXmlParts()` del objeto aparece la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) para recuperar todas las partes XML personalizadas de una presentación. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpart/) expone su identificador, contenido XML y los esquemas de espacios de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacios de nombres:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpart/) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contienen XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Utilice `getXmlAsString()` y `setXmlAsString()` de [`CustomXmlPart`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpart/) para trabajar con XML como una cadena UTF‑8, o `getXmlData()` y `setXmlData()` para trabajar con los bytes XML sin procesar.

El método `getItemId()` devuelve el UUID que identifica la parte XML personalizada en el documento Office Open XML. Use `setItemId()` cuando una integración requiera un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lee el XML actual como texto.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Actualiza el XML como una cadena UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData proporciona el mismo contenido XML como bytes sin procesar.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Reemplaza el identificador cuando lo requiera la integración.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Al llamar a `setXmlAsString` o `setXmlData`, proporcione XML válido y no vacío. Use una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpart/) elimina la parte XML personalizada de la presentación.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpartcollection/) elimina una parte concreta de una colección de partes XML personalizadas.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpartcollection/) elimina la parte en el índice especificado de la colección.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/customxmlpartcollection/) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si ya tiene un `CustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `customXmlPart.remove()`.

También puede eliminar un elemento por índice:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Borrar todas las partes XML personalizadas de una colección**

Use `clear` cuando deban eliminarse todas las partes XML personalizadas asociadas a un objeto concreto de la presentación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` afecta solo a la colección seleccionada. Por ejemplo, borrar la colección de una diapositiva no borra las colecciones a nivel de presentación o forma.

Para eliminar todas las partes XML personalizadas de la presentación, recorra `getAllCustomXmlParts()` y elimine cada parte:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gestionar partes XML personalizadas enlazadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede ser referenciada desde más de un objeto de la presentación. Por ejemplo, un archivo existente puede contener relaciones desde varias diapositivas o formas hacia la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizarla con `setXmlAsString`, `setXmlData` o `setItemId` modifica la parte XML subyacente, de modo que el cambio se aplica donde sea que esa parte esté referenciada.
- `getItemId()` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `getCustomXmlParts()` concreta la quita de esa colección. Use `CustomXmlPart.remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas aún la referencian.

Las sobrecargas de `add` crean una nueva parte XML personalizada a partir del contenido XML; no aceptan una `CustomXmlPart` existente. Por ello, las relaciones compartidas se encuentran mayormente al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita colecciones a nivel de presentación, diapositiva y forma por `ItemId` e informa de las partes referenciadas desde más de un lugar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, porque la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de las etiquetas**

En Slides, una etiqueta corresponde al método `DocumentProperties.getKeywords()`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Node.js vía Java para [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad específica, puede añadir etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de América del Norte, puede crear una etiqueta “NorthAmerican” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) usando Aspose.Slides para Node.js vía Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

O para una [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) individual:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección `getCustomData().getTags()` se guardan solo en el archivo PowerPoint. **No** se transfieren a la estructura de etiquetas del PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, `shape.setAlternativeText("MyId")`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice `remove(name)` en la [colección de etiquetas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use `getNamesOfTags()` en la [colección de etiquetas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde están almacenadas?**

Utilice [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) para recuperar todas las partes XML personalizadas en la presentación.

**¿Debería usar `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` para actualizar una parte XML personalizada?**

Use `getXmlAsString` y `setXmlAsString` cuando la aplicación trabaje con texto XML UTF‑8. Use `getXmlData` y `setXmlData` cuando el XML ya esté disponible como array de bytes o cuando el procesamiento binario sea más conveniente. Ambas representaciones se refieren al contenido XML de la misma parte XML personalizada.