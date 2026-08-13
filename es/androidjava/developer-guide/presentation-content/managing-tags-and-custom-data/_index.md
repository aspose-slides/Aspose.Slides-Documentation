---
title: Gestionar etiquetas y datos personalizados en presentaciones en Android
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/androidjava/managing-tags-and-custom-data
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- XML personalizado
- parte XML personalizada
- metadatos XML
- ItemId
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para Android mediante Java, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de la presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares simples de cadena clave‑valor, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas útiles XML específicas de la aplicación.

Aspose.Slides proporciona API para añadir, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado de flujo de trabajo, metadatos de cumplimiento, datos de enlace a plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se guardan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura del paquete y las relaciones utilizadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene varias partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una sola diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ITagCollection)) o como partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Ambas están disponibles a través de la interfaz [`ICustomData`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}

Las etiquetas almacenan pares clave‑valor de cadena simples. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.

{{% /alert %}}

## **Trabajar con partes XML personalizadas**

El método [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- `presentation.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a la propia presentación.
- `slide.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a una diapositiva específica.
- `shape.getCustomData().getCustomXmlParts()` contiene las partes XML personalizadas asociadas a una forma específica.

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, sin importar dónde estén asociadas.

### **Añadir una parte XML personalizada a una presentación**

Utilice [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no estar vacío.

El siguiente ejemplo añade metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add asigna un identificador automáticamente. Establezca un UUID específico solo cuando sea necesario.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El método `add` también puede aceptar XML como matriz de bytes o flujo de entrada, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Añadir una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de enlace.

El siguiente ejemplo añade una parte XML personalizada a una diapositiva y otra a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El nivel en el que se añade una parte determina qué colección `getCustomData().getCustomXmlParts()` del objeto contiene la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos a nivel de documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) para obtener todas las partes XML personalizadas de una presentación. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart/) expone su identificador, contenido XML y los esquemas de espacio de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacio de nombres:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contienen XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Use [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) y [`setXmlAsString()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) para trabajar con XML como cadena UTF‑8, o [`getXmlData()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) y [`setXmlData()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) para trabajar con los bytes XML sin procesar.

El método [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) devuelve el UUID que identifica la parte XML personalizada en el documento Office Open XML. Use [`setItemId()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) cuando una integración requiera un identificador nuevo.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Leer el XML actual como texto.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Actualizar el XML como una cadena UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData devuelve el mismo contenido XML como bytes sin procesar.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Reemplazar el identificador cuando lo requiera la integración.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Al llamar a `setXmlAsString` o `setXmlData`, proporcione XML válido y no vacío. Utilice una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPart#remove--) elimina la parte XML personalizada de la presentación.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) elimina una parte específica de una colección de partes XML personalizadas.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) elimina la parte en el índice de colección especificado.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si ya dispone de un `ICustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `customXmlPart.remove()`.

También puede eliminar un elemento por índice:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Borrar todas las partes XML personalizadas de una colección**

Use `clear` cuando todas las partes XML personalizadas asociadas a un objeto de presentación concreto deban eliminarse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` afecta solo a la colección seleccionada. Por ejemplo, vaciar la colección de una diapositiva no elimina las colecciones a nivel de presentación ni a nivel de forma.

Para eliminar todas las partes XML personalizadas de la presentación, recorra `getAllCustomXmlParts()` y elimine cada parte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gestionar partes XML personalizadas enlazadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada desde más de un objeto de presentación. Por ejemplo, un archivo existente puede contener relaciones de varias diapositivas o formas hacia la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizarla con `setXmlAsString`, `setXmlData` o `setItemId` modifica la parte XML subyacente, de modo que el cambio se refleja donde sea que la parte esté referenciada.
- `getItemId()` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `getCustomXmlParts()` concreta la elimina solo de esa colección. Use `ICustomXmlPart.remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o sustituir una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas aún la referencian.

Las sobrecargas de `add` crean una nueva parte XML personalizada a partir del contenido XML; no aceptan un `ICustomXmlPart` existente. Por lo tanto, las relaciones compartidas se encuentran con mayor frecuencia al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita las colecciones a nivel de presentación, diapositiva y forma por `ItemId` e informa de las partes referenciadas desde más de un lugar:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, ya que la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde al método `IDocumentProperties.getKeywords()`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Android mediante Java para [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides le permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad específica, puede añadir etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de Norteamérica, puede crear una etiqueta “NorthAmerican” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) usando Aspose.Slides para Android mediante Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

O para una [Shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IAutoShape) individual:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitaciones**

Las etiquetas añadidas a través de la colección `getCustomData().getTags()` se almacenan solo en el archivo PowerPoint. No se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, `shape.setAlternativeText("MyId")`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#clear--) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [remove(name)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) sobre la [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [getNamesOfTags](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) en la [colección de etiquetas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) para obtener todas las partes XML personalizadas de la presentación.

**¿Debo usar `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` para actualizar una parte XML personalizada?**

Use `getXmlAsString` y `setXmlAsString` cuando la aplicación trabaje con texto XML UTF‑8. Use `getXmlData` y `setXmlData` cuando el XML ya esté disponible como matriz de bytes o cuando el procesamiento binario resulte más cómodo. Ambas representaciones se refieren al contenido XML de la misma parte XML personalizada.