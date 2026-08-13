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
## **Введение**

Aspose.Slides для .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым движком для создания, конвертации, верстки страниц и рендеринга документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**

Aspose.Slides для .NET поддерживает любые 32‑битные или 64‑битные операционные системы, на которых установлен .NET или Mono framework, включая (но не ограничиваясь) следующее:

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

Aspose.Slides для .NET поддерживает .NET и Mono frameworks:

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

Aspose.Slides для .NET может использоваться для разработки приложений в любой среде, нацеленой на платформу .NET, но следующие среды официально поддерживаются:

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
- На платформах, отличных от Windows, может потребоваться установить библиотеку `libgdiplus` и её зависимости.
- До версии Aspose.Slides 25.3 для платформ, отличных от Windows, необходимо было использовать DLL .NET Standard 2.0 из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3, пакет NuGet можно использовать напрямую даже на системах, не являющихся Windows.
- При запуске на платформах, отличных от Windows, ваше приложение должно включать следующую строку при старте:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Начиная с версии 25.3, вы можете использовать этот пакет на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

#### **Additional Packages for Linux Alpine**

При запуске Aspose.Slides for .NET в контейнере Alpine Linux установка только `libgdiplus` может быть недостаточной. В Alpine‑контейнерах обычно нет шрифтов по умолчанию. Если шрифты отсутствуют, операции рендеринга или конвертации могут завершиться ошибкой, похожей на:

```text
System.ArgumentException: Font '?' cannot be found
```
Чтобы использовать Aspose.Slides в Alpine, установите `libgdiplus` вместе хотя бы с одним пакетом шрифтов.

**Вариант 1: шрифты DejaVu**

Рекомендуемый вариант — установить пакет ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Пакет `ttf-dejavu` автоматически устанавливает необходимые зависимости, связанные со шрифтами, такие как `fontconfig`, `encodings`, `mkfontscale` и `mkfontdir`. Для большинства сценариев дополнительные пакеты шрифтов не требуются.

**Вариант 2: Microsoft Core Fonts**

Если ваши презентации используют фирменные шрифты Microsoft, такие как Arial, Times New Roman, Courier New или Verdana, установите Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Используйте этот вариант только тогда, когда обрабатываемые презентации требуют шрифтов Microsoft. Для большинства сценариев установка `ttf-dejavu` проще и надёжнее.

**Дополнительные требования для глобализации**

Для корректной поддержки глобализации в Alpine установите пакет `icu-libs` и отключите режим invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Это версия Aspose.Slides, использующая собственный кроссплатформенный графический движок, разработанный командой Aspose.Slides.  
На платформах, отличных от Windows, может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Неподдерживаемые платформы**
- *Windows 11 ARM* (ARM64) — *В данный момент не рассматривается*

{{%  alert  title="Notes"  color="info"  %}}  
Для Linux x64 требуется GLIBC 2.23+; для Linux ARM64 — GLIBC 2.39+. Системы типа CentOS 7 (GLIBC 2.14) не поддерживаются. Если необходимо запустить Aspose.Slides на CentOS 7 или других несовместимых системах (например, Alpine), используйте стандартный пакет: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

### Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?

Нет, PowerPoint не требуется; Aspose.Slides — это автономный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [рендеринга](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

### Какие шрифты необходимы для корректного рендеринга?

Шрифты, используемые в презентации, или подходящие их заменители, должны быть доступны в операционной системе. На Linux и macOS установите общие пакеты шрифтов для обеспечения одинакового рендеринга.

Для контейнеров Alpine Linux установите хотя бы один пакет шрифтов в дополнение к `libgdiplus`. Рекомендуемая минимальная конфигурация — `libgdiplus` вместе с `ttf-dejavu`. Если требуются шрифты Microsoft, такие как Arial, Times New Roman, Courier New или Verdana, используйте `msttcorefonts-installer` вместе с `fontconfig`.

### Почему пользовательский шрифт отображается как запасной или отсутствующий текст на Linux?

Если файл шрифта содержит неконсистентные или повреждённые записи в таблице name, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать недействительную запись, из‑за чего шрифт считается неразрешённым. Использование версии шрифта с исправленными записями name‑таблицы или установка согласующей заменяющей версии решает проблему.