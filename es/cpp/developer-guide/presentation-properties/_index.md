---
title: Gestionar propiedades de la presentación en C++
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/cpp/presentation-properties/
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
- idioma de corrección
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides para C++ y agilice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides para C++ admite propiedades de documento **integradas** y **personalizadas**. Utilice estas propiedades para leer y actualizar los metadatos de la presentación, como el autor, el título y los valores definidos por el usuario.

Aspose.Slides le permite trabajar con las propiedades de documento de la presentación mediante la interfaz [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/). Una instancia de esta interfaz se devuelve mediante [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Los siguientes ejemplos muestran cómo leer, modificar y administrar estas propiedades.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestiona los metadatos de la aplicación y del productor al guardar presentaciones; estos campos identifican el software que creó la salida.
{{% /alert %}}

## **Administrar propiedades de la presentación**

Las propiedades de documento almacenan información descriptiva junto al contenido de la presentación. Se dividen en dos categorías:

- **Propiedades integradas** contienen metadatos estándar, como el título, el autor y las estadísticas del documento.
- **Propiedades personalizadas** almacenan pares nombre/valor definidos por el usuario.

Aspose.Slides para C++ brinda acceso a ambas categorías. En PowerPoint, seleccione **Archivo → Información → Propiedades → Propiedades avanzadas** para inspeccionar los metadatos del documento. El cuadro de diálogo agrupa la información en pestañas como **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Utilice la pestaña **Personalizado** para gestionar las propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Normalmente, una contraseña de apertura protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra pasando `false` a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), sus propiedades de documento permanecen públicas. Entonces una aplicación puede pasar `true` a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) y leer los metadatos públicos sin proporcionar la contraseña de apertura.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El ejemplo requiere una presentación cifrada cuyas propiedades de documento se dejaron públicas. Verifica el modo de carga mediante [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) y luego lee las propiedades integradas a través de [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

En este modo, el contenido de las diapositivas no se carga. Las diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones siempre deben comprobar [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Security" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexado, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin una contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada pasando `true` a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) está destinada a leer metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto de solo metadatos porque las propiedades públicas deben permanecer consistentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El ejemplo requiere una presentación PPTX cifrada con propiedades de documento públicas y una contraseña de apertura conocida. Abre la presentación completa con [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), actualiza las propiedades integradas públicas y guarda el resultado. Luego usa [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin una contraseña para comprobar los nuevos valores:
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

La interfaz [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) expone metadatos integrados a través de getters tipados, incluidos [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), y [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Este ejemplo abre una presentación existente e imprime sus metadatos almacenados en la consola. Los valores dependen de la presentación de entrada; algunos campos pueden estar vacíos.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Modificar propiedades integradas**

Para actualizar los metadatos integrados, utilice los métodos set en el objeto devuelto por [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Este ejemplo abre una presentación existente, llama a [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), y [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), y luego guarda la presentación actualizada con [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). El PPTX guardado contiene los nuevos metadatos.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Administrar la base de hipervínculos**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) lee la base a nivel de documento para hipervínculos relativos. Esto es útil al mover una presentación y sus archivos vinculados a otra ubicación. Es independiente del [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) de un hipervínculo individual: cambiar la base no reescribe las direcciones de enlace almacenadas ni modifica destinos absolutos.

El ejemplo requiere una presentación que contenga tanto un enlace relativo, como `target.html`, y un enlace absoluto, como `https://example.org/absolute.html`. Lee la base existente, asigna una nueva dirección base con [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), y guarda y vuelve a abrir la presentación para comprobar el valor. Luego elimina la base con `u""` y verifica el valor vacío en un archivo guardado por separado. Reemplace la dirección base del ejemplo por la ubicación de sus archivos vinculados.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Los dos mensajes de verificación deberían imprimir `True`. Eliminar la base deja intactas las direcciones de los hipervínculos individuales.

Un enlace relativo a `target.pptx` abrió `old/target.pptx` cuando la base apuntaba a la carpeta `old`. Después de cambiar la base a la carpeta `new`, guardar y volver a abrir la presentación, el mismo enlace abrió `new/target.pptx`. Un enlace absoluto siguió abriendo el mismo archivo. Pruebe sus enlaces relativos en PowerPoint antes y después de mover la presentación o cambiar su base.

## **Agregar propiedades personalizadas a la presentación**

Las propiedades personalizadas almacenan metadatos que no tienen un campo integrado correspondiente. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) le permite asignar un valor mediante el nombre de la propiedad. Este ejemplo crea una presentación, añade dos valores de texto y un valor entero de versión, y guarda la presentación con [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Asignar un valor a un nombre existente reemplaza el valor de esa propiedad.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Acceder y modificar propiedades personalizadas**

Este ejemplo abre una presentación que contiene propiedades personalizadas y utiliza [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) para iterar sobre ellas. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) acepta un índice basado en cero y devuelve el nombre usado por [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) y [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). El ejemplo imprime cada nombre y valor original, sustituye cada valor por una cadena numerada sin importar su tipo original, y guarda los cambios. Si no hay propiedades personalizadas, el bucle no realiza cambios.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Ver y editar metadatos de PowerPoint**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento usando la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor existente será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) y luego [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/cpp/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas de formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada pasando `false` a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), y debe cargarse pasando `true` a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.