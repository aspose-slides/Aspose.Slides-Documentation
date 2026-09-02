---
title: Recuperar y actualizar la información de la presentación en C++
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/cpp/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Explora diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando C++ para obtener ideas más rápidas y auditorías de contenido más inteligentes."
---
## **Visión general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades de documento y actualizar esas propiedades cuando sea necesario.

Los ejemplos se basan en las API [PresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de una presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargar la presentación. Vea este código C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Obtener propiedades de la presentación**

Este código C++ le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) que permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades de documento que se muestran a continuación.

![Propiedades originales del documento de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código muestra cómo editar algunas propiedades de la presentación:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación de PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que le resulten útiles los siguientes enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/cpp/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/cpp/write-protected-presentation/)

## **FAQ**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de presentación, y luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/get_hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Compare el actual [tamaño y orientación de la diapositiva](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slidesize/) con los valores predeterminados; esto ayuda a anticipar el comportamiento para la impresión y exportación.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chart/), compruebe su [fuente de datos](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), y anote si los datos son internos o basados en enlaces, incluyendo los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, contabilice el número de objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para señalar posibles cuellos de botella de rendimiento.