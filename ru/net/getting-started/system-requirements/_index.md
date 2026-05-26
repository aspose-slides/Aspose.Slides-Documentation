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
description: "Узнайте о системных требованиях Aspose.Slides for .NET. Обеспечьте бесперебойную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---
## **Введение**

Aspose.Slides for .NET не требует установки Microsoft PowerPoint, поскольку Aspose.Slides является независимым движком для создания, конвертации, компоновки страниц и визуализации документов Microsoft PowerPoint.

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine и другие)

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

- MONO Support in MAC and Linux platforms

## **Среды разработки**

Aspose.Slides for .NET может использоваться в любой среде разработки, нацеленной на платформу .NET, однако официально поддерживаются следующие среды:

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

В настоящее время существуют две основные сборки Aspose.Slides — Aspose.Slides.NET и Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides для .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Это основная версия продукта. Она использует стандартный графический движок .NET.
- На платформах, отличных от Windows, может потребоваться установить библиотеку `libgdiplus` и её зависимости.
- До версии Aspose.Slides 25.3 для платформ, не являющихся Windows, необходимо было использовать DLL .NET Standard 2.0 из ZIP‑пакета Aspose.Slides.
- Начиная с версии Aspose.Slides 25.3 пакет NuGet можно использовать напрямую даже на системах, отличных от Windows.
- При работе на платформах, отличных от Windows, в приложении должна быть добавлена следующая строка при запуске:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Начиная с версии 25.3, вы можете использовать этот пакет на платформах, поддерживающих .NET, таких как Linux aarch64 (ARM64).**

#### **Дополнительные пакеты для Linux Alpine**

При запуске Aspose.Slides for .NET в контейнере Alpine Linux установка только `libgdiplus` может быть недостаточной. В Alpine обычно не включены шрифты. При отсутствии шрифтов операции визуализации или конвертации могут завершиться ошибкой, похожей на:

```text
System.ArgumentException: Font '?' cannot be found
```
Чтобы использовать Aspose.Slides в Alpine, установите `libgdiplus` вместе как минимум с одним пакетом шрифтов.

**Вариант 1: шрифты DejaVu**

Рекомендуемый вариант — установить пакет `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Пакет `ttf-dejavu` автоматически устанавливает необходимые зависимости, связанные со шрифтами, такие как `fontconfig`, `encodings`, `mkfontscale` и `mkfontdir`. Для большинства сценариев дополнительных пакетов шрифтов не требуется.

**Вариант 2: Microsoft Core Fonts**

Если ваши презентации используют специфические шрифты Microsoft, такие как Arial, Times New Roman, Courier New или Verdana, установите Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Используйте этот вариант только тогда, когда обрабатываемые презентации требуют шрифтов Microsoft. Во всех остальных случаях установка `ttf-dejavu` проще и надёжнее.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Это версия Aspose.Slides, использующая собственный кросс‑платформенный графический движок, разработанный командой Aspose.Slides.  
На платформах, отличных от Windows, может потребоваться библиотека `fontconfig`.

**Поддерживаемые платформы**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Неподдерживаемые платформы**
- *Windows 11 ARM* (ARM64) — *пока не рассматривается*

{{%  alert  title="Notes"  color="primary"  %}}  
Для Linux x64 требуется GLIBC 2.23+; для Linux ARM64 — GLIBC 2.39+. Системы вроде CentOS 7 (GLIBC 2.14) не поддерживаются. Если необходимо запустить Aspose.Slides на CentOS 7 или других несовместимых системах (например, Alpine), используйте стандартный пакет: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Нужен ли мне Microsoft PowerPoint для конвертации и визуализации?**

Нет, PowerPoint не требуется; Aspose.Slides — автономный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [визуализации](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какие шрифты необходимы для корректного отображения?**

Шрифты, использованные в презентации, либо подходящие их заменители, должны быть доступны в операционной системе. На Linux и macOS установите общие пакеты шрифтов для обеспечения одинакового отображения.

Для контейнеров Alpine Linux установите как минимум один пакет шрифтов в дополнение к `libgdiplus`. Рекомендуемая минимальная конфигурация — `libgdiplus` вместе с `ttf-dejavu`. Если требуются шрифты Microsoft, такие как Arial, Times New Roman, Courier New или Verdana, используйте `msttcorefonts-installer` вместе с `fontconfig`.

**Почему пользовательский шрифт отображается как заменяемый или отсутствующий текст в Linux?**

Если в файле шрифта есть несоответствующие или повреждённые записи в таблице имен, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать неверную запись, из‑за чего шрифт не будет найден. Использование версии шрифта с исправленными записями таблицы имен или установка подходящей замены решает проблему.