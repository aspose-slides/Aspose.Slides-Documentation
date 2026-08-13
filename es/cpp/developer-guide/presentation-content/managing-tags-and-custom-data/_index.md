---
title: Gestionar etiquetas y datos personalizados en presentaciones usando C++
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/cpp/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- XML personalizado
- parte XML personalizada
- metadatos XML
- ItemId
- agregar etiqueta
- valores de pares
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para C++, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides funciona con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de una presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares clave‑valor de cadena simples, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas útiles de XML específicas de la aplicación.

Aspose.Slides proporciona API para agregar, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado de flujo de trabajo, metadatos de cumplimiento, datos de unión de plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura del paquete y las relaciones utilizadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene múltiples partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una sola diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/itagcollection/)) o como partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/)). Ambas están disponibles a través de la interfaz [`ICustomData`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomdata/).

{{% alert color="info" %}}

Las etiquetas almacenan pares clave‑valor de cadena simples. Las partes XML personalizadas almacenan datos XML estructurados y pueden estar asociadas a una presentación, diapositiva o forma.

{{% /alert %}}

## **Trabajar con partes XML personalizadas**

El método [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomdata/get_customxmlparts/) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- `presentation->get_CustomData()->get_CustomXmlParts()` contiene las partes XML personalizadas asociadas a la propia presentación.
- `slide->get_CustomData()->get_CustomXmlParts()` contiene las partes XML personalizadas asociadas a una diapositiva específica.
- `shape->get_CustomData()->get_CustomXmlParts()` contiene las partes XML personalizadas asociadas a una forma específica.

Utilice [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_allcustomxmlparts/) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, sin importar dónde estén asociadas.

### **Agregar una parte XML personalizada a una presentación**

Utilice [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/add/) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no estar vacío.

El siguiente ejemplo agrega metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add asigna un identificador automáticamente. Establezca un GUID específico solo cuando sea necesario.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

El método `Add` también puede aceptar XML como matriz de bytes o flujo, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Agregar una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de enlace.

El siguiente ejemplo agrega una parte XML personalizada a una diapositiva y otra a una forma:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

El nivel en el que se añade una parte determina qué colección `get_CustomData()->get_CustomXmlParts()` del objeto contiene la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_allcustomxmlparts/) para obtener todas las partes XML personalizadas de una presentación. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/) expone su identificador, contenido XML y los esquemas de espacio de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacio de nombres:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contienen XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Utilice [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) y `set_XmlAsString` para trabajar con XML como cadena UTF‑8, o [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/get_xmldata/) y `set_XmlData` para trabajar con los bytes XML sin procesar. Ambas representaciones pueden leerse y actualizarse.

El método [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/get_itemid/) devuelve el GUID que identifica la parte XML personalizada en el documento Office Open XML. El identificador también puede modificarse con `set_ItemId` cuando una integración requiere un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Read the current XML as text.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Update the XML as a UTF-8 string.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData provides the same XML content as raw bytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Replace the identifier when required by the integration.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Al asignar XML con `set_XmlAsString` o `set_XmlData`, proporcione XML válido y no vacío. Use una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpart/remove/) elimina la parte XML personalizada de la presentación.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/remove/) elimina una parte concreta de una colección de partes XML personalizadas.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/removeat/) elimina la parte en el índice de colección especificado.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/clear/) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Si ya dispone de un `ICustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `customXmlPart->Remove()`.

También puede eliminar un elemento por índice:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Borrar todas las partes XML personalizadas de una colección**

Utilice `Clear` cuando todas las partes XML personalizadas asociadas a un objeto de presentación concreto deban eliminarse.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` afecta solo a la colección seleccionada. Por ejemplo, vaciar la colección de una diapositiva no vacía las colecciones a nivel de presentación o forma.

Para eliminar cada parte XML personalizada de la presentación, recorra `get_AllCustomXmlParts()` y elimine cada parte:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Manejar partes XML personalizadas vinculadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada desde más de un objeto de presentación. Por ejemplo, un archivo existente puede contener relaciones de varias diapositivas o formas a la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizarla con `set_XmlAsString`, `set_XmlData` o `set_ItemId` modifica la parte XML subyacente, de modo que el cambio se aplica dondequiera que esa parte esté referenciada.
- `get_ItemId()` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `get_CustomXmlParts()` concreta la quita de esa colección. Use `ICustomXmlPart::Remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas siguen referenciándola.

Las sobrecargas de `Add` crean una nueva parte XML personalizada a partir de contenido XML; no aceptan un `ICustomXmlPart` existente. Por lo tanto, las relaciones compartidas se encuentran con mayor frecuencia al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita las colecciones a nivel de presentación, diapositiva y forma por `ItemId` e informa de las partes referenciadas desde más de un lugar:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, porque la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de las etiquetas**

En Slides, una etiqueta corresponde a la propiedad `IDocumentProperties::get_Keywords`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides for C++ para [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad específica, puede agregar etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de América del Norte, puede crear una etiqueta “NorthAmerican” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) usando Aspose.Slides for C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/):

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

O para una [Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/) individual:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección `get_CustomData()->get_Tags()` se almacenan solo en el archivo PowerPoint. No se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, `shape->set_AlternativeText(u"MyId")`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/) admite una operación [Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [Remove(name)](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/getnamesoftags/) en la [colección de etiquetas](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Utilice [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_allcustomxmlparts/) para obtener todas las partes XML personalizadas de la presentación.

**¿Debo usar `get_XmlAsString`/`set_XmlAsString` o `get_XmlData`/`set_XmlData` para actualizar una parte XML personalizada?**

Use `get_XmlAsString` y `set_XmlAsString` cuando la aplicación trabaje con texto XML UTF‑8. Use `get_XmlData` y `set_XmlData` cuando el XML ya esté disponible como matriz de bytes o cuando el procesamiento orientado a binario sea más conveniente. Ambas representaciones se refieren al contenido XML de la misma parte XML personalizada.