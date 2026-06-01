---
title: "Requisitos del sistema"
type: docs
weight: 60
url: /es/net/system-requirements/
keywords:
- "requisitos del sistema"
- "sistema operativo"
- "instalación"
- "dependencias"
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra los requisitos del sistema de Aspose.Slides for .NET. Garantice un soporte fluido de PowerPoint y OpenDocument en Windows, Linux y macOS."
---
## **Introducción**

Aspose.Slides for .NET no requiere que Microsoft PowerPoint esté instalado porque Aspose.Slides es un motor independiente de creación, conversión, diseño de página y renderizado de documentos Microsoft PowerPoint.

## **Sistemas operativos compatibles**

Aspose.Slides for .NET es compatible con cualquier sistema operativo de 32 bits o 64 bits donde esté instalado .NET o el framework Mono, incluyendo (pero no limitado a):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine y otros)

### **Mac**

- Mac OS X

## **Frameworks compatibles**

Aspose.Slides for .NET es compatible con los frameworks .NET y Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- Compatibilidad con COM Interop (COM, C++, VBScript)

### **Mono Framework**

- Soporte MONO en plataformas MAC y Linux

## **Entornos de desarrollo**

Aspose.Slides for .NET puede usarse para desarrollar aplicaciones en cualquier entorno de desarrollo que apunte a la plataforma .NET, pero estos entornos están soportados explícitamente:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Compilaciones principales de Aspose.Slides**

Actualmente existen dos compilaciones principales de Aspose.Slides — Aspose.Slides.NET y Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Esta es la versión principal del producto. Utiliza el motor gráfico estándar de .NET.  
- En plataformas que no sean Windows, puede que necesite instalar la biblioteca `libgdiplus` y sus dependencias.  
- Antes de la versión Aspose.Slides 25.3, para plataformas que no sean Windows era necesario usar el DLL .NET Standard 2.0 del paquete ZIP de Aspose.Slides.  
- A partir de la versión Aspose.Slides 25.3, el paquete NuGet puede usarse directamente incluso en sistemas que no sean Windows.  
- Cuando se ejecuta en sistemas que no sean Windows, su aplicación debe incluir la siguiente línea al iniciar:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **A partir de la versión 25.3, puede usar este paquete en plataformas que soporten .NET, como Linux aarch64 (ARM64).**

#### **Paquetes adicionales para Linux Alpine**

Al ejecutar Aspose.Slides for .NET en un contenedor Alpine Linux, instalar solo `libgdiplus` puede no ser suficiente. Los contenedores Alpine normalmente no incluyen fuentes por defecto. Si no hay fuentes disponibles, las operaciones de renderizado o conversión pueden fallar con un error similar a:

```text
System.ArgumentException: Font '?' cannot be found
```  
Para usar Aspose.Slides en Alpine, instale `libgdiplus` junto con al menos un paquete de fuentes.

**Opción 1: fuentes DejaVu**

La opción recomendada es instalar el paquete ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```  

El paquete `ttf-dejavu` instala automáticamente las dependencias relacionadas con fuentes requeridas, como `fontconfig`, `encodings`, `mkfontscale` y `mkfontdir`. No se requieren paquetes de fuentes adicionales para la mayoría de los casos de uso.

**Opción 2: Microsoft Core Fonts**

Si sus presentaciones usan fuentes específicas de Microsoft, como Arial, Times New Roman, Courier New o Verdana, instale Microsoft Core Fonts en su lugar:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```  

Utilice esta opción solo cuando las presentaciones procesadas requieran fuentes de Microsoft. Para la mayoría de los escenarios, instalar `ttf-dejavu` es más sencillo y fiable.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Esta es la versión de Aspose.Slides que usa un motor gráfico multiplataforma desarrollado por el equipo de Aspose.Slides.  
En plataformas que no sean Windows, puede ser necesaria la biblioteca `fontconfig`.

**Plataformas compatibles**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Plataformas no compatibles**
- *Windows 11 ARM* (ARM64) — *No se contempla actualmente*

{{%  alert  title="Notas"  color="primary"  %}}  
Para Linux x64, se requiere GLIBC 2.23+; para Linux ARM64, GLIBC 2.39+ es necesario. Sistemas como CentOS 7 (GLIBC 2.14) no son compatibles. Si necesita ejecutar Aspose.Slides en CentOS 7 u otros sistemas incompatibles (por ejemplo, Alpine), use el paquete estándar: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Necesito tener Microsoft PowerPoint instalado para conversiones y renderizado?**

No, PowerPoint no es necesario; Aspose.Slides es un motor independiente para [crear](/slides/es/net/create-presentation/), modificar, [convertir](/slides/es/net/convert-presentation/) y [renderizar](/slides/es/net/convert-powerpoint-to-png/) presentaciones.

**¿Qué fuentes son necesarias para un renderizado correcto?**

Las fuentes utilizadas en la presentación, o sustitutos adecuados, deben estar disponibles en el sistema operativo. En Linux y macOS, instale paquetes de fuentes comunes para garantizar un renderizado coherente.

Para contenedores Alpine Linux, instale al menos un paquete de fuentes además de `libgdiplus`. La configuración mínima recomendada es `libgdiplus` con `ttf-dejavu`. Si se requieren fuentes de Microsoft como Arial, Times New Roman, Courier New o Verdana, use `msttcorefonts-installer` junto con `fontconfig`.

**¿Por qué una fuente personalizada se muestra como sustituta o texto faltante en Linux?**

Si el archivo de fuente tiene entradas de tabla de nombres inconsistentes o corruptas, la pila de coincidencia de fuentes de Linux (FreeType/fontconfig) puede seleccionar un registro inválido, provocando que la fuente no se resuelva. Utilizar una versión de la fuente con tablas de nombres corregidas o instalar un sustituto coherente resuelve el problema.