---
title: Системные требования
type: docs
weight: 60
url: /ru/net/system-requirements/
keywords:
- системные требования
- операционная система
- установка
- зависимости
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- Aspose.Slides
description: "Узнайте о системных требованиях Aspose.Slides для .NET. Обеспечьте беспроблемную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

## **Обзор**
Aspose.Slides for .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым механизмом создания, конвертации, разметки страниц и визуализации документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**
Aspose.Slides for .NET поддерживает любые 32‑разрядные или 64‑разрядные операционные системы, на которых установлен .NET или Mono, включая (но не ограничиваясь) следующее:

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine и другие)

{{%  alert  title="Notes"  color="primary"  %}} 

Поскольку CentOS 7 поставляется с GLIBC 2.14, а Aspose.Slides for .NET 6 и .NET 7 (включая кроссплатформенную сборку) требуют Linux x86_64 с GLIBC 2.23 или новее, в такой системе можно использовать Aspose.Slides for .NET Standard. 
{{% /alert %}} 

### **Mac**
- Mac OS X

## **Поддерживаемые фреймворки**
Aspose.Slides for .NET поддерживает .NET и Mono:

### **.NET Framework**
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
- Поддержка COM Interop (COM, C++, VBScript)

### **Mono Framework**
- Поддержка MONO в платформах MAC и Linux

## **Среды разработки**
Aspose.Slides for .NET можно использовать в любой среде разработки, нацеленной на платформу .NET, но официально поддерживаются следующие среды:

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
- На неплатформенных Windows платформах может потребоваться установка библиотеки `libgdiplus` и её зависимостей.
- До версии Aspose.Slides 25.3 для неплатформенных Windows требовалась библиотека .NET Standard 2.0 DLL из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3 пакет NuGet можно использовать напрямую даже на неплатформенных системах.
- При запуске на неплатформенных системах ваше приложение должно включать следующую строку при старте:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **Начиная с версии 25.3 вы можете использовать этот пакет на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Это версия Aspose.Slides, использующая собственный кроссплатформенный графический движок, разработанный командой Aspose.Slides.  
На неплатформенных Windows платформах может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Запланировано для будущей поддержки**  
- *Linux*: aarch64 (ARM64) — *ETA: конец 2025*  

**Не планируется**
- *Windows 11 ARM* (ARM64) — *В настоящее время не рассматривается*

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и визуализации?**

Нет, PowerPoint не требуется; Aspose.Slides — это автономный движок для [создания](/slides/ru/net/create-presentation/), модификации, [конвертации](/slides/ru/net/convert-presentation/) и [визуализации](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какие шрифты нужны для корректной визуализации?**

На практике должны быть доступны шрифты, использованные в презентации, или подходящие [заменители](/slides/ru/net/font-substitution/). Чтобы обеспечить согласованную визуализацию в Linux/macOS, рекомендуется установить общие пакеты шрифтов.