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
description: "Узнайте о системных требованиях Aspose.Slides для .NET. Обеспечьте беспроблемную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---
## **Обзор**
Aspose.Slides for .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым движком создания, конвертации, разметки страниц и рендеринга документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**
Aspose.Slides for .NET поддерживает любую 32‑битную или 64‑битную операционную систему, на которой установлен .NET или Mono framework, включая (но не ограничиваясь):

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

### **Mac**
- Mac OS X

## **Поддерживаемые фреймворки**
Aspose.Slides for .NET поддерживает .NET и Mono frameworks:

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
- MONO Support in MAC and Linux platforms

## **Среды разработки**
Aspose.Slides for .NET может использоваться в любой среде разработки, нацеленной на платформу .NET, однако следующие среды официально поддерживаются:

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
- До версии Aspose.Slides 25.3 для неплатформ Windows необходимо было использовать DLL .NET Standard 2.0 из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3 пакет NuGet можно использовать напрямую даже на неплатформах Windows.
- При запуске на неплатформах Windows ваше приложение должно включать следующую строку при старте:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Начиная с версии 25.3 вы можете использовать этот пакет на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Это версия Aspose.Slides, использующая собственный кроссплатформенный графический движок, разработанный командой Aspose.Slides.  
На платформах, отличных от Windows, может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Неподдерживаемые платформы**
- *Windows 11 ARM* (ARM64) — *В настоящее время не рассматривается*

{{%  alert  title="Notes"  color="primary"  %}}  
Для Linux x64 требуется GLIBC 2.23+; для Linux ARM64 — GLIBC 2.39+. Системы типа CentOS 7 (GLIBC 2.14) не поддерживаются. Если необходимо запустить Aspose.Slides на CentOS 7 или других несовместимых системах (например, Alpine), используйте стандартный пакет: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется; Aspose.Slides — автономный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [рендеринга](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какие шрифты необходимы для корректного рендеринга?**

На практике должны быть доступны шрифты, использованные в презентации, или подходящие [заменители](/slides/ru/net/font-substitution/). Чтобы обеспечить единообразный рендеринг в Linux/macOS, рекомендуется установить общие пакеты шрифтов.

**Почему пользовательский шрифт отображается как запасной или отсутствующий текст в Linux?**

Если файл шрифта содержит несогласованные или повреждённые записи в таблице имён, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать недопустимую запись, в результате чего шрифт остаётся неразрешённым. Использование версии шрифта с исправленными записями таблицы имён или установка согласующего заменителя решает проблему.