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
- .NET
- C#
- Aspose.Slides
description: "Узнайте о системных требованиях Aspose.Slides for .NET. Обеспечьте беспрепятственную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---
## **Обзор**
Aspose.Slides for .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым движком создания, конвертации, оформления страниц и визуализации документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**
Aspose.Slides for .NET поддерживает любую 32‑разрядную или 64‑разрядную операционную систему, на которой установлен .NET или Mono, включая (но не ограничиваясь) следующее:

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine и др.)

{{%  alert  title="Notes"  color="primary"  %}} 

Поскольку CentOS 7 поставляется с GLIBC 2.14, а Aspose.Slides for .NET 6 и .NET 7 (включая кроссплатформенную сборку) требуют Linux x86_64 с GLIBC 2.23 или новее, в такой системе можно использовать Aspose.Slides for .NET Standard. 

{{% /alert %}} 

### **Mac**
- Mac OS X

## **Поддерживаемые фреймворки**
Aspose.Slides for .NET поддерживает .NET и Mono:

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
- Поддержка COM Interop (COM, C++, VBScript)

### **Mono Framework**
- Поддержка MONO на платформах MAC и Linux

## **Среды разработки**
Aspose.Slides for .NET может использоваться в любой среде разработки, нацеленной на платформу .NET, но официально поддерживаются следующие среды:

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
- На платформах, отличных от Windows, может потребоваться установка библиотеки `libgdiplus` и её зависимостей.
- До версии Aspose.Slides 25.3 для нелинуксовых платформ необходимо было использовать DLL .NET Standard 2.0 из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3, пакет NuGet можно использовать напрямую даже на нелинуксовых системах.
- При запуске на нелинуксовых системах приложение должно включать следующую строку при старте:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Начиная с версии 25.3, этот пакет можно использовать на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Это версия Aspose.Slides, использующая кастомный кроссплатформенный графический движок, разработанный командой Aspose.Slides.  
На платформах, отличных от Windows, может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Запланировано для будущей поддержки**  
- *Linux*: aarch64 (ARM64) — *ETA: конец 2025*  

**Не планируется**  
- *Windows 11 ARM* (ARM64) — *В настоящий момент не рассматривается*

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и визуализации?**

Нет, PowerPoint не требуется; Aspose.Slides — автономный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [визуализации](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какие шрифты необходимы для корректной визуализации?**

На практике должны быть доступны шрифты, использованные в презентации, либо подходящие [замены](/slides/ru/net/font-substitution/). Чтобы обеспечить одинаковый рендеринг в Linux/macOS, рекомендуется установить общие шрифтовые пакеты.

**Почему пользовательский шрифт отображается как запасной или отсутствующий текст в Linux?**

Если в файле шрифта присутствуют некорректные или повреждённые записи таблицы имен, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать недействительную запись, из‑за чего шрифт считается неразрешённым. Использование версии шрифта с исправленными записями таблицы имён или установка согласующей замены решает проблему.