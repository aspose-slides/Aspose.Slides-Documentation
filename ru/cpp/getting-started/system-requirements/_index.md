---
title: Системные требования
type: docs
weight: 80
url: /ru/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Узнайте о системных требованиях Aspose.Slides for C++. Обеспечьте бесшовную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---
## **Введение**

Aspose.Slides не требует установки Microsoft PowerPoint, так как Aspose.Slides является независимым движком создания, конвертации, верстки и рендеринга документов Microsoft PowerPoint.

## **Поддерживаемые операционные системы**
Aspose.Slides for C++ — это нативная библиотека C++. Aspose.Slides for C++ поддерживает следующие 64‑разрядные и 32‑разрядные операционные системы и платформы:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 или более поздняя версия.
- CentOS 8 или более поздняя версия.
- Fedora 24 или более поздняя версия.
- И другие Linux x86_64 с glibc 2.23 или более поздней версией.

### **macOS**
- macOS Monterey 12.1 или более поздняя версия.

## **Среды разработки**
Вы можете использовать Aspose.Slides for C++ при разработке приложений для Windows, Linux или macOS.

### **Windows**
- Microsoft Visual Studio 2017 или более поздняя версия.
- CMake 3.18 или более поздняя версия.

### **Linux**
- Clang 3.9 или более поздняя версия.
- GCC 6.1 или более поздняя версия.
- CMake 3.18 или более поздняя версия.

### **macOS**
- Xcode 13.4 или более поздняя версия.

## **Часто задаваемые вопросы**

**Нужен ли установленный Microsoft PowerPoint для конвертации и визуализации?**

Нет, PowerPoint не требуется; Aspose.Slides — это автономный движок для [создания](/slides/ru/cpp/create-presentation/), изменения, [конвертирования](/slides/ru/cpp/convert-presentation/) и [визуализации](/slides/ru/cpp/convert-powerpoint-to-png/) презентаций.

**Какие шрифты нужны для корректного отображения?**

На практике должны быть доступны шрифты, использованные в презентации, или подходящие [замены](/slides/ru/cpp/font-substitution/). Чтобы обеспечить согласованный рендеринг на Linux/macOS, рекомендуется установить общие пакеты шрифтов.

**Почему пользовательский шрифт отображается как запасной или отсутствующий текст в Linux?**

Если в файле шрифта имеются несогласованные или повреждённые записи таблицы имён, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать неверную запись, что приводит к невозможности найти шрифт. Использование версии шрифта с исправленными записями таблицы имён или установка согласованной замены решает проблему.