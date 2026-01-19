---
title: Soporte .NET 6
type: docs
weight: 235
url: /es/net/net6/
keywords:
- Soporte .NET 6
- Solución en la nube
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Configure Aspose.Slides para .NET 6 para crear, editar y convertir presentaciones PowerPoint PPT, PPTX y ODP en aplicaciones C# modernas y multiplataforma."
---

## **Introducción**

A partir de [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), se implementó la compatibilidad con .NET6. La particularidad de esta compatibilidad es que .NET6 ya no admite System.Drawing.Common para Linux ([cambio de ruptura](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) y Slides implementa este subsistema gráfico por sí mismo como un componente C++.

Aspose.Slides para .NET ahora funciona sin dependencias de GDI/libgdiplus en:
* Windows
* Linux

_El soporte para MacOS está en desarrollo._

## **Uso de Slides para .NET 6 en AWS y Azure**

.NET6 es la versión preferida para Aspose.Slides utilizada en la nube (AWS, Azure u otras soluciones en la nube).

Anteriormente, cuando Aspose.Slides se utilizaba en un host Linux, era necesario instalar dependencias adicionales (libgdiplus) y esto a menudo resultaba incómodo o poco práctico (por ejemplo, al usar [AWS Lambda](https://aws.amazon.com/lambda)). Con Slides para .NET6, esas dependencias ya no son necesarias, por lo que la implementación es mucho más sencilla.

Otro aspecto a considerar son los problemas que se producían cuando Aspose.Slides se utilizaba en una solución en la nube con un host Windows. Por ejemplo, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) tiene limitaciones para el proceso y genera problemas durante una operación de exportación a PDF (ver [esto](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). El uso de Aspose.Slides para .NET6 resuelve este problema.

## **Uso del paquete System.Drawing.Common y clases Slides para .NET 6 (CS0433: El tipo existe en ambas Slides y System.Drawing.Common Error)**

A veces, tanto System.Drawing como las dependencias de Slides para .NET6 deben usarse en un proyecto (por ejemplo, cuando el proyecto .NET6 depende de otros paquetes que, a su vez, dependen de System.Drawing). Esto puede causar errores de complicación como los siguientes:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

En este caso, puedes usar [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) para Aspose.Slides (versión inferior a 24.8):
1) Selecciona el ensamblado Aspose.Slides de las dependencias del proyecto y luego haz clic en **Properties**.
  ![Propiedades del paquete Aspose Slides](package_properties.png)
2) Establece un alias (por ejemplo, "Slides").
  ![Alias de Aspose Slides](set_alias.png)

Ahora, los tipos de System.Drawing.Common se usarán por defecto. El alias del ensamblado externo debe especificarse donde se necesiten los tipos de Aspose.Slides.
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


A partir de la versión 24.8, la API pública obsoleta con dependencias en System.Drawing se ha eliminado. Respecto al ejemplo de código anterior, puedes obtener la imagen de la diapositiva de la siguiente manera.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

La nueva API se describe con más detalle en [API moderna](/slides/es/net/modern-api/).