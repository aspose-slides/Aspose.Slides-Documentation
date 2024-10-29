---
title: Propiedades de Presentación
type: docs
weight: 70
url: /es/cpp/presentation-properties/
---


## **Acceder a las Propiedades de Presentación**
Como hemos descrito anteriormente, Aspose.Slides para C++ admite dos tipos de propiedades de documentos, que son **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades utilizando la API de Aspose.Slides para C++. Aspose.Slides para C++ proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) que representa las propiedades del documento asociadas con un archivo de presentación a través del método [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Los desarrolladores pueden usar el método [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) expuesto por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores contra los campos **Aplicación** y **Productor**, porque Aspose Ltd. y Aspose.Slides para C++ x.x.x se mostrarán contra estos campos.

{{% /alert %}} 


Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades de documentos como se indica a continuación:

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, las estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para C++, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el ícono de Office y luego en el elemento de menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007. Después de seleccionar el elemento de menú **Propiedades Avanzadas**, aparecerá un cuadro de diálogo que le permitirá gestionar las propiedades del documento del archivo de PowerPoint. En el **Cuadro de Diálogo de Propiedades**, puede ver que hay muchas páginas de pestañas como **General, Resumen, Estadísticas, Contenidos y Personalizada**. Todas estas páginas de pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizada** se utiliza para gestionar propiedades personalizadas de los archivos de PowerPoint.


## **Acceder a las Propiedades Integradas**
Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creador (Autor)**, **Descripción**, **Palabras Clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **Último Modificado Por**, **Palabras Clave**, **DocCompartido** (¿Está compartido entre diferentes productores?), **Formato de Presentación**, **Asunto** y **Título**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificaría. En el ejemplo dado a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Agregar Propiedades de Presentación Personalizadas**
Aspose.Slides para C++ también permite a los desarrolladores agregar valores personalizados para las propiedades del documento de presentación. A continuación se muestra un ejemplo que muestra cómo establecer las propiedades personalizadas para una presentación.

``` cpp
// Instanciar la clase Presentación
auto presentation = System::MakeObject<Presentation>();

// Obtener Propiedades del Documento
auto documentProperties = presentation->get_DocumentProperties();

// Agregar propiedades personalizadas
documentProperties->idx_set(u"Nueva Personalizada", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"Mi Nombre", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Personalizado", ObjectExt::Box<int32_t>(124));

// Obtener el nombre de la propiedad en un índice particular
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Eliminar la propiedad seleccionada
documentProperties->RemoveCustomProperty(getPropertyName);

// Guardar la presentación
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Acceder y Modificar Propiedades de Presentación Personalizadas**
Aspose.Slides para C++ también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que muestra cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}


## **Verificar si la Presentación ha sido Modificada o Creada**
Aspose.Slides para C++ proporciona una función para verificar si una presentación ha sido modificada o creada. A continuación se muestra un ejemplo que muestra cómo verificar si la presentación ha sido creada o modificada.

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **Establecer el Idioma de Revisión**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) para permitirle establecer el idioma de revisión para un documento de PowerPoint. El idioma de revisión es el idioma para el cual se verifican la ortografía y la gramática en PowerPoint.

Este código C++ le muestra cómo establecer el idioma de revisión para un PowerPoint:

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
// establecer el Id de un idioma de revisión

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Establecer el Idioma Predeterminado**

Este código C++ le muestra cómo establecer el idioma predeterminado para una presentación de PowerPoint completa:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Agregar una nueva forma de rectángulo con texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Nuevo Texto");

// Verificar el idioma de la primera porción
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```