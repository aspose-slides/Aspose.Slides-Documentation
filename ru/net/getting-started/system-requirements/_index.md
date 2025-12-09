---
title: "Системные требования"
type: docs
weight: 60
url: /ru/net/system-requirements/
keywords:
- "системные требования"
- "операционная система"
- "установка"
- "зависимости"
- "Windows"
- "Linux"
- "macOS"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Узнайте о системных требованиях Aspose.Slides для .NET. Обеспечьте беспроблемную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

## **Обзор**
Aspose.Slides for .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым движком для создания, конвертации, компоновки страниц и рендеринга документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**
Aspose.Slides for .NET поддерживает любые 32‑разрядные или 64‑разрядные операционные системы, на которых установлен .NET или Mono, включая (но не ограничиваясь):

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

{{%  alert  title="Notes"  color="primary"  %}} 
Поскольку CentOS 7 поставляется с GLIBC 2.14, а Aspose.Slides for .NET 6 и .NET 7 (включая кросс‑платформенную сборку) требуют Linux x86_64 с GLIBC 2.23 или новее, вы можете использовать Aspose.Slides for .NET Standard на такой системе.
{{% /alert %}} 

### **Mac**
- Mac OS X

## **Поддерживаемые фреймворки**
Aspose.Slides for .NET поддерживает фреймворки .NET и Mono:

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

### **Mono Framework**
- Поддержка MONO на платформах MAC и Linux

## **Среды разработки**
Aspose.Slides for .NET можно использовать для разработки приложений в любой среде разработки, ориентированной на платформу .NET, однако следующие среды официально поддерживаются:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Основные сборки Aspose.Slides**
В настоящее время существует две основные сборки Aspose.Slides — Aspose.Slides.NET и Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Это основная версия продукта. Она использует стандартный графический движок .NET.
- На платформах, отличных от Windows, возможно потребуется установить библиотеку `libgdiplus` и её зависимости.
- До версии Aspose.Slides 25.3 для платформ, отличных от Windows, необходимо было использовать DLL .NET Standard 2.0 из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3, пакет NuGet можно использовать напрямую даже на платформах, отличных от Windows.
- При работе на платформах, отличных от Windows, ваше приложение должно включать следующую строку при запуске:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **Начиная с версии 25.3, вы можете использовать этот пакет на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Это версия Aspose.Slides, использующая собственный кросс‑платформенный графический движок, разработанный командой Aspose.Slides.  
На платформах, отличных от Windows, может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Запланировано в будущей поддержке**  
- *Linux*: aarch64 (ARM64) — *Ожидается к концу 2025 года*  

**Не планируется**  
- *Windows 11 ARM* (ARM64) — *На данный момент не рассматривается*

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется; Aspose.Slides — это автономный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [рендеринга](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какие шрифты нужны для корректного рендеринга?**

На практике должны быть доступны шрифты, использованные в презентации, или подходящие [заменители](/slides/ru/net/font-substitution/). Чтобы обеспечить одинаковый рендеринг на Linux/macOS, рекомендуется установить общие пакеты шрифтов.