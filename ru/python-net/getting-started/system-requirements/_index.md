---
title: Системные требования
type: docs
weight: 60
url: /ru/python-net/system-requirements/
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
- Python
- Aspose.Slides
description: "Узнайте о системных требованиях Aspose.Slides для Python через .NET. Обеспечьте беспрепятственную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

## **Введение**

Aspose.Slides for Python via .NET не требует установки каких-либо сторонних продуктов, таких как Microsoft PowerPoint. Aspose.Slides — это движок для создания, изменения, конвертации и рендеринга документов в различных форматах, включая форматы презентаций Microsoft PowerPoint.

## **Поддерживаемые операционные системы**

Aspose.Slides for Python поддерживает Windows (32‑bit и 64‑bit), macOS и 64‑bit Linux на системах с установленным Python 3.5 или новее.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Операционная система</td>
        <td style="font-weight: bold; width:400px">Версии</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>и другие</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 «Monterey»</li>
            </ul>
        </td>
    </tr>
</table>

## **Системные требования для целевых платформ Linux и macOS**

- Библиотеки времени выполнения GCC 6 (или более поздние).
- [libgdiplus](https://github.com/mono/libgdiplus), открытая реализация API GDI+.
- Зависимости среды выполнения .NET Core. Установка самой среды выполнения .NET Core **НЕ** требуется.
- Для Python 3.5–3.7 требуется сборка Python с `pymalloc`. Параметр сборки `--with-pymalloc` включён по умолчанию. Обычно сборка `pymalloc` помечена суффиксом `m` в имени файла.
- Общая библиотека `libpython`. Параметр сборки Python `--enable-shared` отключён по умолчанию, и некоторые дистрибутивы Python не включают общую библиотеку `libpython`. На некоторых платформах Linux её можно установить через менеджер пакетов (например, `sudo apt-get install libpython3.7`). Частая проблема — библиотека `libpython` устанавливается в нестандартное расположение. Это можно исправить, указав альтернативные пути к библиотекам при сборке Python или создав символическую ссылку на файл `libpython` в стандартном каталоге общих библиотек. Обычно имя файла выглядит как `libpythonX.Ym.so.1.0` для Python 3.5–3.7 или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Вопросы и ответы**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется; Aspose.Slides — автономный движок для [создания](/slides/ru/python-net/create-presentation/), изменения, [конвертации](/slides/ru/python-net/convert-presentation/), и [рендеринга](/slides/ru/python-net/convert-powerpoint-to-png/) презентаций.

**Требуется ли определённая версия .NET (Core/5+/6+) на машине?**

Установка среды выполнения .NET не требуется, но её зависимости должны присутствовать в Linux/macOS. Это означает, что в системе должны быть пакеты, обычно устанавливаемые как зависимости .NET, без полной установки среды выполнения.

**Какие шрифты нужны для корректного рендеринга?**

На практике должны быть доступные шрифты, использованные в презентации, либо подходящие [заменители](/slides/ru/python-net/font-substitution/). Чтобы обеспечить согласованный рендеринг в Linux/macOS, рекомендуется установить пакеты общих шрифтов.