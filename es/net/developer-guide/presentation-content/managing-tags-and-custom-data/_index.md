---
title: Gestionar etiquetas y datos personalizados en presentaciones en .NET
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/net/managing-tags-and-custom-data/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para .NET, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Descripción general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de una presentación pueden almacenarse como etiquetas o partes XML personalizadas. Las etiquetas son pares simples de cadena clave-valor, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas XML específicas de la aplicación.

Aspose.Slides proporciona API para añadir, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado de flujo de trabajo, metadatos de cumplimiento, datos de enlace a plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se almacenan en formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura del paquete y las relaciones utilizadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene múltiples partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una única diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/net/aspose.slides/itagcollection)) o partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection)). Ambas están disponibles a través de la interfaz [`ICustomData`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}

Las etiquetas almacenan pares de cadena clave-valor simples. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.

{{% /alert %}}

## **Trabajar con partes XML personalizadas**

La propiedad [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomdata/customxmlparts/) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- `presentation.CustomData.CustomXmlParts` contiene las partes XML personalizadas asociadas a la propia presentación.
- `slide.CustomData.CustomXmlParts` contiene las partes XML personalizadas asociadas a una diapositiva concreta.
- `shape.CustomData.CustomXmlParts` contiene las partes XML personalizadas asociadas a una forma concreta.

Utilice [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/allcustomxmlparts/) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, independientemente de dónde estén asociadas.

### **Añadir una parte XML personalizada a una presentación**

Utilice [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection/add/) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no vacío.

El siguiente ejemplo añade metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add asigna un identificador automáticamente. Establezca un GUID específico solo cuando sea necesario.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

El método `Add` también puede aceptar XML como una matriz de bytes o flujo, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Añadir una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma específica en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de enlace.

El siguiente ejemplo añade una parte XML personalizada a una diapositiva y otra a una forma:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

El nivel en el que se añade una parte determina qué colección `CustomData.CustomXmlParts` del objeto contiene la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta, y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/allcustomxmlparts/) para obtener todas las partes XML personalizadas de una presentación. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/) expone su identificador, contenido XML y los esquemas de espacio de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacio de nombres:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/namespaceschemas/) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contengan XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Utilice [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/xmlasstring/) para trabajar con XML como cadena UTF-8, o [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/xmldata/) para trabajar con los bytes crudos del XML. Ambas propiedades pueden leerse y actualizarse.

La propiedad [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/itemid/) contiene el GUID que identifica la parte XML personalizada en el documento Office Open XML. También puede modificarse cuando una integración requiere un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Leer el XML actual como texto.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Actualizar el XML como cadena UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData proporciona el mismo contenido XML como bytes sin procesar.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Reemplazar el identificador cuando la integración lo requiera.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Al asignar `XmlAsString` o `XmlData`, proporcione XML válido y no vacío. Use una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpart/remove/) elimina la parte XML personalizada de la presentación.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection/remove/) elimina una parte específica de una colección de partes XML personalizadas.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection/removeat/) elimina la parte en un índice de colección especificado.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection/clear/) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Si ya dispone de un `ICustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `customXmlPart.Remove()`.

También puede eliminar un elemento por índice:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Borrar todas las partes XML personalizadas de una colección**

Utilice `Clear` cuando se deban eliminar todas las partes XML personalizadas asociadas a un objeto de presentación concreto.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` afecta solo a la colección seleccionada. Por ejemplo, vaciar la colección de una diapositiva no vacía las colecciones a nivel de presentación o forma.

Para eliminar cada parte XML personalizada de la presentación, recorra `AllCustomXmlParts` y elimine cada parte:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Gestionar partes XML personalizadas enlazadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada desde más de un objeto de presentación. Por ejemplo, un archivo existente puede contener relaciones desde varias diapositivas o formas hacia la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizar su `XmlAsString`, `XmlData` o `ItemId` modifica la parte XML subyacente, de modo que el cambio se aplica dondequiera que esa parte sea referenciada.
- `ItemId` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `CustomXmlParts` concreta la elimina de esa colección. Utilice `ICustomXmlPart.Remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas siguen referenciándola.

Las sobrecargas de `Add` crean una nueva parte XML personalizada a partir del contenido XML; no aceptan un `ICustomXmlPart` existente. Por lo tanto, las relaciones compartidas se encuentran con mayor frecuencia al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita las colecciones a nivel de presentación, diapositiva y forma mediante `ItemId` e informa de las partes referenciadas desde más de un lugar:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, porque la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde a la propiedad `IDocumentProperties.Keywords`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides le permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad específica, puede añadir etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de América del Norte, puede crear una etiqueta “North American” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) usando Aspose.Slides para .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

O para una [Shape](https://reference.aspose.com/slides/es/net/aspose.slides/shape) individual:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección `CustomData.Tags` se almacenan solo en el archivo PowerPoint. No se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **texto alternativo** del objeto (por ejemplo, `shape.AlternativeText = "MyId"`). Después de exportar a PDF, el texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **FAQ**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/) admite una operación [Clear](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/clear/) que elimina todos los pares clave-valor a la vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [Remove(name)](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/remove/) en la [TagCollection](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [GetNamesOfTags](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/getnamesoftags/) en la [colección de etiquetas](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Utilice [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/allcustomxmlparts/) para recuperar todas las partes XML personalizadas de la presentación.

**¿Debo usar `XmlAsString` o `XmlData` para actualizar una parte XML personalizada?**

Use `XmlAsString` cuando la aplicación trabaje con texto XML UTF-8. Use `XmlData` cuando el XML ya esté disponible como matriz de bytes o cuando el procesamiento orientado a binario sea más conveniente. Ambas propiedades representan el contenido XML de la misma parte XML personalizada.