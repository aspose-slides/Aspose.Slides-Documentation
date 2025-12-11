---
title: Administrar propiedades de presentación en C++
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/cpp/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades del documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de corrección
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina las propiedades de presentación en Aspose.Slides for C++ y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---

## **Acceder a las propiedades de la presentación**

Como describimos anteriormente, Aspose.Slides para C++ admite dos tipos de propiedades de documento, que son propiedades **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides para C++. Aspose.Slides para C++ proporciona la clase [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) que representa las propiedades del documento asociadas a un archivo de presentación a través del método [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Los desarrolladores pueden usar el método [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) expuesto por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, ya que Aspose Ltd. y Aspose.Slides para C++ x.x.x se mostrarán en esos campos.

{{% /alert %}} 

Microsoft PowerPoint ofrece una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten que información útil se almacene junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento de la siguiente manera:

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides para C++, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que debe hacer es hacer clic en el icono de Office y, a continuación, en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Después de seleccionar el elemento de menú **Advanced Properties**, aparecerá un cuadro de diálogo que le permite gestionar las propiedades del documento del archivo PowerPoint. En el **Properties Dialog**, puede ver que existen varias páginas de pestañas como **General, Summary, Statistics, Contents y Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se usa para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Acceder a las propiedades integradas**

Estas propiedades, tal como las expone el objeto **IDocumentProperties**, incluyen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de última impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Agregar propiedades personalizadas a la presentación**

Aspose.Slides para C++ también permite a los desarrolladores agregar valores personalizados a las propiedades del documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

``` cpp
// Instanciar la clase Presentation
auto presentation = System::MakeObject<Presentation>();

// Obteniendo las propiedades del documento
auto documentProperties = presentation->get_DocumentProperties();

// Añadiendo propiedades personalizadas
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Obteniendo el nombre de la propiedad en un índice específico
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Eliminando la propiedad seleccionada
documentProperties->RemoveCustomProperty(getPropertyName);

// Guardando la presentación
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```


## **Acceder y modificar propiedades personalizadas**

Aspose.Slides para C++ también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Establecer idioma de corrección**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) para permitirle establecer el idioma de corrección para un documento PowerPoint. El idioma de corrección es el idioma para el cual se verifica la ortografía y la gramática en PowerPoint.

Este código C++ le muestra cómo establecer el idioma de corrección para un PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Establecer idioma predeterminado**

Este código C++ le muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades del documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no se pueden eliminar por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si agrega una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad de antemano, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargar completamente la presentación?**

Sí, puede acceder a las propiedades de la presentación sin cargarla completamente mediante el método `GetPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/). Luego, utilice el método `ReadDocumentProperties` proporcionado por la interfaz [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.