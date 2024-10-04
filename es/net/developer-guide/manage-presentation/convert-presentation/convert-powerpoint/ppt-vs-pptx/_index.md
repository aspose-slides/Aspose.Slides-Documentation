---
title: PPT vs PPTX
type: docs
weight: 10
url: /net/ppt-vs-pptx/
keywords: "PPT vs PPTX, PPT o PPTX, Presentación de PowerPoint, formato, C#, Csharp, .NET"
description: "Sobre los formatos de Presentación de PowerPoint. PPT vs PPTX. Diferencias en C# o .NET"
---


## **¿Qué es PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) es un formato de archivo binario, es decir, es imposible ver su contenido sin herramientas especiales. Las primeras versiones de PowerPoint 97-2003 trabajaban con el formato de archivo PPT, sin embargo, su expandibilidad es limitada.
## **¿Qué es PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) es un nuevo formato de archivo de presentación, basado en el estándar Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX es un conjunto archivado de archivos XML y multimedia. El formato PPTX es fácilmente expandable. Por ejemplo, es fácil agregar soporte para un nuevo tipo de gráfico o tipo de forma, sin cambiar el formato PPTX en cada nueva versión de PowerPoint. El formato PPTX se utiliza a partir de PowerPoint 2007.

## **PPT vs PPTX**
Aunque PPTX proporciona una funcionalidad mucho más amplia, PPT sigue siendo bastante popular. La necesidad de convertir de PPT a PPTX y viceversa es altamente demandada.

Sin embargo, la conversión entre el antiguo formato PPT y el nuevo formato PPTX es el desafío más complicado entre otros formatos de Microsoft Office. Aunque la especificación del formato PPT es abierta, es difícil trabajar con ella. PowerPoint puede crear partes especiales (MetroBlob) en archivos PPT para almacenar información de PPTX que no es compatible con el formato PPT y no puede mostrarse en versiones antiguas de PowerPoint. Esta información puede ser restaurada cuando un archivo PPT se carga en una versión moderna de PowerPoint o se convierte a formato PPTX.

Aspose.Slides proporciona una interfaz común para trabajar con todos los formatos de presentación. Permite convertir de PPT a PPTX y de PPTX a PPT de una manera muy simple. Aspose.Slides admite completamente la conversión de PPT a PPTX y también admite la conversión de PPTX a PPT con algunas restricciones. Recomendamos utilizar el formato PPTX siempre que sea posible.

{{% alert color="primary" %}} 

Verifique la calidad de las conversiones de PPT a PPTX y de PPTX a PPT con la aplicación en línea [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Guardar la presentación PPTX en formato PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 
Lea más [**Cómo convertir presentaciones de PPT a PPTX**.](/slides/net/convert-ppt-to-pptx/)
{{% /alert %}} 