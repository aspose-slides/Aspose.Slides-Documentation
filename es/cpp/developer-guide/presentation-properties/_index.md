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
description: "Domine las propiedades de la presentación en Aspose.Slides para C++ y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Built-in** y **Custom**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de los documentos de presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/). Una instancia de esta interfaz se devuelve mediante [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_documentproperties/). Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, ya que Aspose Ltd. y Aspose.Slides for C++ x.x.x se mostrarán en dichos campos.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint ofrece una característica para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento como sigue

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

Las propiedades **Built-in** contienen información general sobre el documento, como el título, el nombre del autor, estadísticas del documento, etc. Las propiedades **Custom** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for C++, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Solo tiene que hacer clic en el icono de Office y luego en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Después de seleccionar el elemento de menú **Advanced Properties**, aparecerá un cuadro de diálogo que le permite gestionar las propiedades del documento del archivo PowerPoint. En el **Properties Dialog**, puede ver que hay varias pestañas como **General, Summary, Statistics, Contents and Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación está cifrada pasando `false` a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), sus propiedades de documento permanecen públicas. Una aplicación puede entonces pasar `true` a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) y leer los metadatos públicos sin suministrar la contraseña de apertura.

`set_OnlyLoadDocumentProperties` controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) y luego lee las propiedades integradas mediante [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre `get_IsOnlyDocumentPropertiesLoaded` antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden exponer nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada después de llamar a `set_OnlyLoadDocumentProperties(true)` está pensada para leer metadatos públicos. Aspose.Slides no puede guardar los cambios de propiedades de ese objeto de solo metadatos porque las propiedades públicas deben permanecer consistentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/), actualiza las propiedades integradas públicas y guarda el resultado. Luego utiliza [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) para verificar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Si una aplicación no está autorizada a descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (fecha de creación), **Modified** (fecha de modificación), **Printed** (fecha del último print), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigne un valor de cadena a la propiedad deseada y el valor se modificará. En el ejemplo que sigue, demostramos cómo modificar las propiedades de documento integradas del archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Añadir propiedades personalizadas a la presentación**

Aspose.Slides for C++ también permite a los desarrolladores añadir valores personalizados para las propiedades del documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtener propiedades del documento
auto documentProperties = presentation->get_DocumentProperties();

// Añadir propiedades personalizadas
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Obtener el nombre de la propiedad en un índice concreto
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Eliminar la propiedad seleccionada
documentProperties->RemoveCustomProperty(getPropertyName);

// Guardar la presentación
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for C++ también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas de una presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Establecer el idioma de corrección**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/portionformat/)) para permitirle establecer el idioma de corrección de un documento PowerPoint. El idioma de corrección es el idioma para el que se verifica la ortografía y la gramática en PowerPoint.

Este código C++ muestra cómo establecer el idioma de corrección para un PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN"); // establecer el Id de un idioma de corrección

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Establecer el idioma predeterminado**

Este código C++ muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Añade una nueva forma rectangular con texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Comprueba el idioma de la primera porción
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Ejemplo en directo**

Pruebe la aplicación en línea **Aspose.Slides Metadata** para ver cómo trabajar con las propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte esencial de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminarla o comprobarla antes, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) y luego [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos almacenados del documento sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/cpp/examine-presentation/) para obtener un ejemplo completo de informe y limitaciones específicas por formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada pasando `false` a `set_EncryptDocumentProperties`, y debe cargarse pasando `true` a `set_OnlyLoadDocumentProperties`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.