---
title: Convertir ODP a PPTX en C#
linktitle: Convertir ODP a PPTX
type: docs
weight: 10
url: /net/convert-odp-to-pptx/
keywords: "Convertir Presentación OpenOffice, ODP, ODP a PPTX, C#, Csharp, .NET"
description: "Convertir ODP de OpenOffice a Presentación PPTX en C# o .NET"
---

## Descripción general

Este artículo explica los siguientes temas.

- [C# Convertir ODP a PPTX](#csharp-odp-to-pptx)
- [C# Convertir ODP a PowerPoint](#csharp-odp-to-powerpoint)

## Conversión de ODP a PPTX en C#

Aspose.Slides para .NET ofrece la clase Presentation que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) ahora también puede acceder a ODP a través del constructor de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Pasos: Convertir ODP a PPTX en C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Pasos: Convertir ODP a PowerPoint en C#</strong></a>

```c#
// Abrir el archivo ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Guardando la presentación ODP en formato PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Ejemplo en vivo**
Puedes visitar [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) una aplicación web que está construida con **Aspose.Slides API.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con la API de Aspose.Slides.