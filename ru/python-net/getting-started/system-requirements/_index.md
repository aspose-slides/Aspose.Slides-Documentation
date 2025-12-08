---
title: "Системные требования"
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
description: "Узнайте о системных требованиях Aspose.Slides for Python via .NET. Обеспечьте бесшовную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

## **Введение**

Aspose.Slides for Python via .NET не требует установки каких-либо сторонних продуктов, таких как Microsoft PowerPoint. Aspose.Slides — это движок для создания, изменения, конвертации и рендеринга документов в различных форматах, включая форматы презентаций Microsoft PowerPoint.

## **Поддерживаемые операционные системы**

Aspose.Slides for Python поддерживает Windows (32‑bit и 64‑bit), macOS и 64‑bit Linux на системах с установленным Python 3.5 или более новым.

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
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Системные требования для целевых платформ Linux и macOS**

- Библиотеки выполнения GCC 6 (или новее).
- [libgdiplus](https://github.com/mono/libgdiplus), открытая реализация API GDI+.
- Зависимости среды выполнения .NET Core. Установка самой среды выполнения .NET Core НЕ требуется.
- Для Python 3.5–3.7 требуется сборка Python с `pymalloc`. Параметр сборки `--with-pymalloc` включён по умолчанию. Обычно такая сборка помечается суффиксом `m` в имени файла.
- Общая библиотека `libpython`. Параметр сборки Python `--enable-shared` отключён по умолчанию, и некоторые дистрибутивы Python не включают `libpython`. На некоторых платформах Linux её можно установить через менеджер пакетов (например, `sudo apt-get install libpython3.7`). Частая проблема — установка `libpython` в нестандартное место для совместных библиотек. Это можно решить, указав альтернативные пути к библиотекам при сборке Python или создав символическую ссылку на файл `libpython` в стандартном каталоге совместных библиотек. Как правило, имя файла выглядит как `libpythonX.Ym.so.1.0` для Python 3.5–3.7 или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется; Aspose.Slides — автономный движок для [creating](/slides/ru/python-net/create-presentation/), изменения, [converting](/slides/ru/python-net/convert-presentation/) и [rendering](/slides/ru/python-net/convert-powerpoint-to-png/) презентаций.

**Требуется ли конкретная версия .NET (Core/5+/6+) на машине?**

Установка среды выполнения .NET не обязательна, но её зависимости должны присутствовать на Linux/macOS. Это означает, что система должна содержать пакеты, обычно устанавливаемые как зависимости .NET, без полной установки среды выполнения.

**Какие шрифты необходимы для корректного рендеринга?**

На практике должны быть доступны шрифты, использованные в презентации, или подходящие [substitutes](/slides/ru/python-net/font-substitution/). Чтобы обеспечить согласованный рендеринг на Linux/macOS, рекомендуется установить общие пакеты шрифтов.