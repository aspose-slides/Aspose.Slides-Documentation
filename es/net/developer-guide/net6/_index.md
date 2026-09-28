---
title: Paquete multiplataforma para .NET 6 y posteriores
linktitle: Paquete multiplataforma
type: docs
weight: 235
url: /es/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- multiplataforma
- compatibilidad con .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Aprenda cuándo usar el paquete Aspose.Slides.NET6.CrossPlatform: por qué existe, en qué plataformas funciona y qué necesita en Linux en lugar de libgdiplus."
---
## **Introducción**

Aspose.Slides para .NET se publica como dos paquetes NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) genera diapositivas a través de la biblioteca System.Drawing.Common de Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) genera las diapositivas con su propio motor gráfico. Este artículo explica por qué existe el segundo paquete, dónde se ejecuta, qué necesita en Linux y cómo convive con System.Drawing.Common en un mismo proyecto.

## **Por qué un paquete separado**

A partir de .NET 6, Microsoft admite System.Drawing.Common solo en Windows. Como resultado, en Linux Aspose.Slides.NET necesita el conmutador `System.Drawing.EnableUnixSupport` además de la biblioteca `libgdiplus`, y falla allí si el proyecto referencia System.Drawing.Common 7 o posterior. [System Requirements](/slides/es/net/system-requirements/) describe estas condiciones.

Aspose.Slides.NET6.CrossPlatform no utiliza System.Drawing.Common ni `libgdiplus`. Su motor gráfico es una biblioteca nativa que el paquete contiene en una compilación por cada plataforma compatible. Ambos paquetes proporcionan los mismos espacios de nombres y clases de Aspose.Slides, por lo que cambiar de uno a otro solo modifica la referencia al paquete, no el código.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Gráficos | System.Drawing.Common | Motor gráfico nativo incluido en el paquete |
| Frameworks de destino | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Requisitos en Linux | `libgdiplus` y el conmutador `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Compatible | No compatible |

## **Plataformas compatibles**

Aspose.Slides.NET6.CrossPlatform funciona con .NET 6 y versiones posteriores en estas plataformas:

- **Windows**: x86 y x64. La biblioteca nativa utiliza el tiempo de ejecución Microsoft Visual C++; consulte [System Requirements](/slides/es/net/system-requirements/).
- **Linux**: x64 con glibc 2.23 o posterior, y ARM64 con glibc 2.39 o posterior.
- **macOS**: x64 (Intel) y ARM64 (silicio de Apple).

No se ejecuta en Windows ARM64, en Alpine Linux ni en otras distribuciones basadas en musl en lugar de glibc, ni en distribuciones con una glibc más antigua, como CentOS 7. Utilice Aspose.Slides.NET en esos sistemas.

## **Instalación en Linux**

En Linux, el paquete requiere la biblioteca `fontconfig`, pero no `libgdiplus`. En Debian y Ubuntu, instale `fontconfig` y luego añada el paquete a su proyecto:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

En Debian y Ubuntu, `libfontconfig1` también instala las fuentes DejaVu, por lo que el texto se muestra sin paquetes de fuentes adicionales. Sin `fontconfig`, la creación de una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) falla con una `TypeInitializationException` cuyo `DllNotFoundException` interno indica que no se puede abrir `libfontconfig.so.1`. [System Requirements](/slides/es/net/system-requirements/) incluye un programa breve que verifica la configuración.

## **Nube y hosts de contenedores**

Al no necesitar `libgdiplus`, Aspose.Slides.NET6.CrossPlatform es el paquete a utilizar en hosts Linux donde no puede instalar `libgdiplus`. Aún necesita `fontconfig` y fuentes, que pueden faltar en imágenes base mínimas. La imagen base de AWS Lambda para .NET 8, por ejemplo, no contiene ninguno de los dos. En una imagen de contenedor construida a partir de ella, ejecute `dnf install -y fontconfig`, lo que también instala las fuentes Noto Sans.

Para guías específicas de plataformas cloud, consulte [Aspose.Slides on Cloud Platforms](/slides/es/net/slides-on-cloud-platforms/).

## **Uso de System.Drawing.Common en el mismo proyecto (CS0433)**

Un proyecto que utiliza Aspose.Slides.NET6.CrossPlatform también puede referenciar System.Drawing.Common, ya sea directamente o a través de otro paquete. La versión actual de Aspose.Slides no expone tipos públicos en los espacios de nombres `System`, por lo que ambas bibliotecas no entran en conflicto y puede importar los espacios de nombres `Aspose.Slides` y `System.Drawing` en el mismo archivo.

Si el compilador informa el error CS0433 porque un tipo como `Image` o `Graphics` existe tanto en Aspose.Slides como en System.Drawing.Common, su proyecto está usando una versión anterior de Aspose.Slides. Actualice el paquete a la última versión. Aspose.Slides devuelve imágenes renderizadas como objetos [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), que se describen en [Modern API](/slides/es/net/modern-api/).

## **FAQ**

**¿Necesito cambiar mi código al pasar de Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform?**

No. Ambos paquetes proporcionan los mismos espacios de nombres y clases de Aspose.Slides, por lo que solo sustituye la referencia al paquete. Aspose.Slides.NET6.CrossPlatform no necesita el conmutador `System.Drawing.EnableUnixSupport`. Añada solo uno de los dos paquetes a un proyecto.

**¿Puedo usar Aspose.Slides.NET6.CrossPlatform en un proyecto .NET Framework?**

No. El paquete está dirigido únicamente a .NET 6 y versiones posteriores. Para .NET Framework 4.6.2 y posteriores, utilice Aspose.Slides.NET.