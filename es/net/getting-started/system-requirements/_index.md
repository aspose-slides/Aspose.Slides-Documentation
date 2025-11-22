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
- Aspose.Slides
description: "Descubra los requisitos del sistema de Aspose.Slides para .NET. Garantice soporte sin problemas de PowerPoint y OpenDocument en Windows, Linux y macOS."
---

## **Visión general**
Aspose.Slides para .NET no requiere que Microsoft PowerPoint esté instalado porque Aspose.Slides es un motor independiente de creación, conversión, diseño de página y renderizado de documentos Microsoft PowerPoint.

## **Sistemas operativos compatibles**
Aspose.Slides para .NET es compatible con cualquier sistema operativo de 32 bits o 64 bits donde esté instalado .NET o Mono, incluidos (pero no limitados a):

### **Windows**
- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine y otros)

{{%  alert  title="Notas"  color="primary"  %}} 

Debido a que CentOS 7 incluye GLIBC 2.14 mientras que Aspose.Slides para .NET 6 y .NET 7 (incluida la compilación multiplataforma) requieren Linux x86_64 con GLIBC 2.23 o superior, puede usar Aspose.Slides para .NET Standard en ese sistema.

{{% /alert %}} 

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
- Soporte COM Interop (COM, C++, VBScript)

### **Mono Framework**
- Soporte MONO en plataformas MAC y Linux

## **Entornos de desarrollo**
Aspose.Slides para .NET puede usarse para desarrollar aplicaciones en cualquier entorno de desarrollo que apunte a la plataforma .NET, pero estos entornos están explícitamente soportados:

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
Actualmente, hay dos compilaciones principales de Aspose.Slides: Aspose.Slides.NET y Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Esta es la versión principal del producto. Utiliza el motor gráfico estándar de .NET.
- En plataformas que no son Windows, puede ser necesario instalar la biblioteca `libgdiplus` y sus dependencias.
- Antes de la versión Aspose.Slides 25.3, para plataformas que no son Windows, era necesario usar el DLL .NET Standard 2.0 del paquete ZIP de Aspose.Slides.
- A partir de la versión Aspose.Slides 25.3, el paquete NuGet puede usarse directamente incluso en sistemas que no son Windows.
- Al ejecutarse en sistemas que no son Windows, su aplicación debe incluir la siguiente línea al iniciar:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **A partir de la versión 25.3, puede usar este paquete en plataformas que soportan .NET, como Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Esta es la versión de Aspose.Slides que utiliza un motor gráfico multiplataforma personalizado desarrollado por el equipo de Aspose.Slides.  
En plataformas que no son Windows, puede requerirse la biblioteca `fontconfig`.

**Plataformas compatibles**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Planificado para soporte futuro**  
- *Linux*: aarch64 (ARM64) — *ETA: fin de 2025*  

**No planificado**
- *Windows 11 ARM* (ARM64) — *No está bajo consideración actualmente*

## **Preguntas frecuentes**

**¿Necesito que Microsoft PowerPoint esté instalado para conversiones y renderizado?**

No, PowerPoint no es necesario; Aspose.Slides es un motor independiente para [crear](/slides/es/net/create-presentation/), modificar, [convertir](/slides/es/net/convert-presentation/) y [renderizar](/slides/es/net/convert-powerpoint-to-png/) presentaciones.

**¿Qué fuentes son necesarias para un renderizado correcto?**

En la práctica, las fuentes usadas en la presentación o sus [sustitutos](/slides/es/net/font-substitution/) adecuados deben estar disponibles. Para garantizar un renderizado consistente en Linux/macOS, se recomienda instalar paquetes de fuentes comunes.