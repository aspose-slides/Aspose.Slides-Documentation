---
title: Requisitos del sistema
type: docs
weight: 60
url: /es/net/system-requirements/
keywords:
- requisitos del sistema
- sistema operativo
- instalación
- dependencias
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra los requisitos del sistema de Aspose.Slides para .NET. Garantice un soporte fluido de PowerPoint y OpenDocument en Windows, Linux y macOS."
---
## **Visión general**
Aspose.Slides para .NET no requiere que Microsoft PowerPoint esté instalado porque Aspose.Slides es un motor independiente de creación, conversión, diseño de página y renderizado de documentos de Microsoft PowerPoint.

## **Sistemas operativos compatibles**
Aspose.Slides para .NET es compatible con cualquier sistema operativo de 32 o 64 bits en el que esté instalado .NET o el framework Mono, incluyendo (pero no limitado a):

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
Aspose.Slides para .NET es compatible con los frameworks .NET y Mono:

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
- COM Interop support (COM, C++, VBScript)

### **Framework Mono**
- Soporte MONO en plataformas MAC y Linux

## **Entornos de desarrollo**
Aspose.Slides para .NET puede usarse para desarrollar aplicaciones en cualquier entorno de desarrollo que apunte a la plataforma .NET, pero estos entornos son compatibles explícitamente:

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
Actualmente, existen dos compilaciones principales de Aspose.Slides — Aspose.Slides.NET y Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Este es la versión principal del producto. Utiliza el motor gráfico estándar de .NET.
- En plataformas que no sean Windows, puede que necesite instalar la biblioteca `libgdiplus` y sus dependencias.
- Antes de la versión Aspose.Slides 25.3, para plataformas no Windows era necesario usar el DLL .NET Standard 2.0 del paquete ZIP de Aspose.Slides.
- A partir de la versión Aspose.Slides 25.3, el paquete NuGet puede usarse directamente incluso en sistemas que no sean Windows.
- Al ejecutarse en sistemas que no sean Windows, su aplicación debe incluir la siguiente línea al iniciar:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A partir de la versión 25.3, puede usar este paquete en plataformas que soporten .NET, como Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Esta es la versión de Aspose.Slides que utiliza un motor gráfico multiplataforma personalizado desarrollado por el equipo de Aspose.Slides.  
En plataformas que no sean Windows, puede requerirse la biblioteca `fontconfig`.

**Plataformas compatibles**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Plataformas no compatibles**
- *Windows 11 ARM* (ARM64) — *No está actualmente en consideración*

{{%  alert  title="Notes"  color="primary"  %}}  
Para Linux x64, se requiere GLIBC 2.23+; para Linux ARM64, se requiere GLIBC 2.39+. Sistemas como CentOS 7 (GLIBC 2.14) no son compatibles. Si necesita ejecutar Aspose.Slides en CentOS 7 u otros sistemas incompatibles (p. ej., Alpine), por favor utilice el paquete estándar: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Necesito tener instalado Microsoft PowerPoint para conversiones y renderizado?**

No, PowerPoint no es necesario; Aspose.Slides es un motor independiente para [crear](/slides/es/net/create-presentation/), modificar, [convertir](/slides/es/net/convert-presentation/) y [renderizar](/slides/es/net/convert-powerpoint-to-png/) presentaciones.

**¿Qué fuentes son necesarias para un renderizado correcto?**

En la práctica, las fuentes utilizadas en la presentación o sus [sustitutos](/slides/es/net/font-substitution/) adecuados deben estar disponibles. Para garantizar un renderizado coherente en Linux/macOS, es recomendable instalar paquetes de fuentes comunes.

**¿Por qué una fuente personalizada se muestra como sustituta o texto faltante en Linux?**

Si el archivo de fuente tiene entradas de tabla de nombres inconsistentes o corruptas, la pila de coincidencia de fuentes de Linux (FreeType/fontconfig) puede seleccionar un registro inválido, lo que provoca que la fuente no se resuelva. Utilizar una versión de la fuente con tablas de nombres corregidas o instalar un sustituto coherente resuelve el problema.