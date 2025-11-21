---
title: Recuperar y actualizar la información de la presentación en .NET
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando .NET para obtener información más rápida y auditorías de contenido más inteligentes."
---

Aspose.Slides for .NET le permite examinar una presentación para conocer sus propiedades y comprender su comportamiento. 

{{% alert title="Info" color="info" %}} 
Las clases [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) y [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) contienen las propiedades y los métodos utilizados en las operaciones aquí.
{{% /alert %}} 

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, es posible que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Obtener propiedades de la presentación**

Este código C# le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


Es posible que desee ver las [propiedades bajo DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) de la clase.

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, es posible que le resulten útiles los siguientes enlaces:

- [Comprobando si una presentación está encriptada](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobando si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobando si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando la contraseña utilizada para proteger una presentación](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de la presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) y la orientación actuales con los valores predeterminados; esto ayuda a anticipar el comportamiento al imprimir y exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorrra todos los [gráficos](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), y observe si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencia, sombras, animaciones y multimedia; asigne una puntuación de complejidad aproximada para señalar posibles cuellos de botella de rendimiento.