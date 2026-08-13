---
title: Gestionar propiedades de la presentación en C++
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/cpp/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de la presentación
- Propiedades del documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides para C++ y agilice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de documento de la presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_document_properties). Una instancia de esta interfaz se devuelve mediante el método [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_documentproperties/). Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" %}} 
Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, ya que se mostrará Aspose Ltd. y Aspose.Slides for C++ x.x.x en dichos campos.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint ofrece una funcionalidad para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento como se indica a continuación

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for C++, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y, a continuación, en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Después de seleccionar el elemento de menú **Advanced Properties**, aparecerá un cuadro de diálogo que le permitirá gestionar las propiedades de documento del archivo de PowerPoint. En el **Properties Dialog**, puede ver que hay muchas pestañas como **General, Summary, Statistics, Contents and Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (fecha de creación), **Modified** (fecha de modificación), **Printed** (fecha del último impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Añadir propiedades personalizadas a la presentación**

Aspose.Slides for C++ también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

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
// Obtener las propiedades del documento
// Agregar propiedades personalizadas
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

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/portionformat/)) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el cual se comprueban la ortografía y la gramática en el PowerPoint.

Este código C++ le muestra cómo establecer el idioma de revisión para un PowerPoint:

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

portionFormat->set_LanguageId(u"zh-CN");
// establecer el Id de un idioma de revisión

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Establecer idioma predeterminado**

Este código C++ le muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

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

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades de documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## ***Preguntas frecuentes**

### ¿Cómo puedo eliminar una propiedad integrada de una presentación?

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

### ¿Qué ocurre si añado una propiedad personalizada que ya existe?

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad de antemano, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

### ¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?

Sí, puede acceder a las propiedades de la presentación sin cargarla completamente utilizando el método `GetPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/). A continuación, utilice el método `ReadDocumentProperties` proporcionado por la interfaz [IPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/) para leer las propiedades de forma eficiente, ahorrando memoria y mejorando el rendimiento.