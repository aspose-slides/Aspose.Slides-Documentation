---
title: Seguridad
type: docs
weight: 160
url: /es/net/security/
keywords:
- seguridad
- dependencias
- componentes de terceros
- NuGet
- análisis de vulnerabilidades
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise cómo Aspose.Slides for .NET procesa presentaciones, qué paquetes NuGet necesita para cada framework de destino y qué componentes de terceros incluye."
---
## **Seguridad en Aspose.Slides**

Aspose aplica las mejores prácticas al desarrollar sus productos.

* Aspose.Slides for .NET se utiliza para manipular presentaciones y convertirlas a otros formatos. No ejecuta scripts en las presentaciones. Aspose.Slides analiza la estructura de la presentación y permite que el código del usuario final manipule el modelo de objetos de forma cómoda.
* Aspose.Slides funciona como una biblioteca que analiza e interpreta documentos sin ejecutar código remoto. Todos los productos Aspose se ejecutan en sus máquinas. No transmiten ningún dato a Aspose. La única excepción es una [licencia por consumo](https://purchase.aspose.com/faqs/licensing/metered): si utiliza una, solo se procesa la información de uso de su API.
* Los componentes Aspose se ejecutan en el mismo contexto de usuario que las aplicaciones habituales. Por lo tanto, los componentes Aspose no suponen un riesgo para los recursos vitales del sistema. Además, cuando un componente Aspose abre un documento, no se ejecutan macros automáticamente.
* Los riesgos inherentes o asociados al paquete Microsoft Office no se aplican a los componentes Aspose, por lo que los productos Aspose son muy seguros.

## **Dependencias de NuGet**

Aspose.Slides for .NET depende de paquetes que Microsoft publica en NuGet. Las dependencias varían según el paquete y el framework de destino:

| Package | Target framework | Dependencies |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

La sección **Dependencies** de las páginas de [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) y [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) en NuGet enumera la versión mínima de cada dependencia para cada versión.

Cuando añade Aspose.Slides a un proyecto, NuGet también restaura las dependencias de estos paquetes. Para enumerar todos los paquetes que su proyecto restaura, incluidas estas dependencias transitivas, ejecute este comando en la carpeta del proyecto:

```bash
dotnet list package --include-transitive
```

Para comprobar el mismo conjunto de paquetes contra vulnerabilidades conocidas, ejecute:

```bash
dotnet list package --vulnerable --include-transitive
```

Para otras formas de auditar paquetes NuGet, consulte [Auditoría de dependencias de paquetes para vulnerabilidades de seguridad](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Componentes de terceros**

Aspose.Slides incluye código de componentes de código abierto de terceros. Forman parte del producto, no son paquetes NuGet independientes, por lo que las herramientas que leen solo dependencias NuGet no los listan. Ambos paquetes contienen el archivo *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, que enumera los componentes y sus licencias:

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**¿Qué sistemas se utilizan para monitorizar vulnerabilidades en el código de Aspose?**

Ejecutamos un análisis estático de código para cada versión de Aspose.Slides. Podemos proporcionar informes de seguridad que demuestran que el código de Aspose.Slides supera el OWASP Top 10.

**¿Aspose.Slides utiliza paquetes externos?**

Sí. Depende de los paquetes NuGet de Microsoft enumerados en [Dependencias de NuGet](#nuget-dependencies) y contiene los componentes de terceros listados en [Componentes de terceros](#third-party-components). Incluya ambos en su revisión de seguridad y utilice `dotnet list package --vulnerable --include-transitive` para comprobar los paquetes NuGet que su proyecto restaura.