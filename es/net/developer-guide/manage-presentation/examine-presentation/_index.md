---
title: Recuperar y actualizar información de la presentación en .NET
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
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando .NET para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades del documento y actualizar esas propiedades cuando sea necesario.

Los ejemplos se basan en las APIs [PresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de la presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP, etc.) está la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código C#:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Obtener propiedades de la presentación**

Este código C# muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Es posible que quiera ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/documentproperties/#properties).

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) que permite modificar las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades del documento original de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código muestra cómo editar algunas propiedades de la presentación:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades del documento modificadas de la presentación de PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que le resulten útiles estos enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/net/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/net/write-protected-presentation/)

## **FAQ**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la información de [embedded-font] en el nivel de la presentación y compárela con el conjunto de [fonts actually used across content] para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [slide collection] y examine la [visibility flag] de cada diapositiva.

**¿Puedo detectar si se utilizan tamaños u orientaciones de diapositiva personalizados y si difieren de los predeterminados?**

Sí. Compare el [slide size] y la orientación actuales con los valores predeterminados; esto ayuda a anticipar el comportamiento al imprimir o exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [charts], compruebe su [data source] y observe si los datos son internos o basados en enlaces, incluidas las rutas rotas.

**¿Cómo puedo evaluar las diapositivas «pesadas» que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y multimedia; asigne una puntuación aproximada de complejidad para señalar posibles cuellos de botella de rendimiento.