---
title: Soporte para .NET6
type: docs
weight: 235
url: /net/net6/
keywords: 
- .NET 6
- Nube
- AWS
- Azure
description: "Soporte para .NET6"
---

## Introducción

A partir de [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), se implementó el soporte para .NET6. La peculiaridad de este soporte es que .NET6 ya no admite System.Drawing.Common para Linux ([cambio importante](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) y Slides implementa este subsistema gráfico por sí mismo como un componente C++.

Aspose.Slides para .NET ahora funciona sin dependencias de GDI/libgdiplus en:
* Windows
* Linux

El soporte para _MacOS_ está en progreso.

## Uso de Slides para .NET6 en AWS y Azure

.NET6 es la versión preferida para Aspose.Slides utilizada en la nube (AWS, Azure u otras soluciones en la nube).

Anteriormente, cuando Aspose.Slides se utilizaba en un host Linux, debían instalarse dependencias adicionales (libgdiplus) y esto a menudo era inconveniente o impráctico (por ejemplo, al usar [AWS Lambda](https://aws.amazon.com/lambda)). Con Slides para .NET6, esas dependencias ya no son necesarias, por lo que el despliegue es mucho más fácil.

Otra consideración son los problemas que ocurrían cuando Aspose.Slides se utilizaba en una solución en la nube con un host Windows. Por ejemplo, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) tienen limitaciones para el proceso y resulta en problemas durante una operación de exportación a PDF (ver [esto](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). El uso de Aspose.Slides para .NET6 resuelve este problema.

## Uso del paquete System.Drawing.Common y clases de Slides para .NET6 (CS0433: El tipo existe en ambos Slides y System.Drawing.Common error)

A veces, es necesario usar tanto System.Drawing como las dependencias de Slides para .NET6 en un proyecto (por ejemplo, cuando el proyecto .NET6 depende de otros paquetes, que a su vez dependen de System.Drawing). Esto puede causar errores de complicación como estos:

* CS0433: El tipo 'Image' existe tanto en 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' como en 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: El tipo 'Graphics' existe tanto en 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' como en 'System.Drawing.Common, Version=6.0.0.0'

En este caso, puedes usar [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) para Aspose.Slides (versión anterior a 24.8):
1) Selecciona el ensamblado de Aspose.Slides de las dependencias del proyecto y luego haz clic en **Propiedades**.
  ![Propiedades del paquete Aspose Slides](package_properties.png)
2) Establece un alias (por ejemplo, "Slides").
  ![Alias de Aspose Slides](set_alias.png)

Ahora, los tipos de System.Drawing.Common se usarán por defecto. El alias de ensamblado externo debe especificarse donde se necesiten tipos de Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Ejemplo completo:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

A partir de la versión 24.8, se ha eliminado la API pública obsoleta con dependencias en System.Drawing. En cuanto al ejemplo de código anterior, puedes obtener la imagen de la diapositiva como se muestra a continuación.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
La nueva API se describe con más detalle en [API moderna](/net/modern-api/).