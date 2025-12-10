---
title: Recuperar y actualizar información de la presentación en C++
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
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando C++ para obtener insights más rápidos y auditorías de contenido más inteligentes."
---

Aspose.Slides for C++ le permite examinar una presentación para descubrir sus propiedades y comprender su comportamiento. 

{{% alert title="Info" color="info" %}}

Las clases [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) y [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) contienen las propiedades y los métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código C++:
``` cpp
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
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```


## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que le resulten útiles estos enlaces:

- [Comprobar si una presentación está encriptada](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobar si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobar si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la contraseña utilizada para proteger una presentación](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la información de [embedded-font](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de la presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para el renderizado.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los predeterminados?**

Sí. Compare el [tamaño y orientación de la diapositiva](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) actual con los valores predefinidos estándar; esto ayuda a anticipar el comportamiento al imprimir y exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorrra todos los [gráficos](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) y anote si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar el renderizado o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para identificar posibles puntos críticos de rendimiento.