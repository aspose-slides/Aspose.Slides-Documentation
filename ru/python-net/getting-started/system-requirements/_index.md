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
description: "Узнайте о системных требованиях Aspose.Slides for Python via .NET. Обеспечьте беспроблемную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

Aspose.Slides для Python через .NET не требует установки каких-либо сторонних продуктов, таких как Microsoft PowerPoint. Aspose.Slides сам по себе является движком для создания, модификации, преобразования и отображения документов в различных форматах, включая форматы презентаций Microsoft PowerPoint.

## Поддерживаемые операционные системы

Aspose.Slides для Python через .NET поддерживает 64-битные и 32-битные версии Windows, macOS, Linux, на которых установлена Python версии 3.5 или новее.

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

## Системные требования для целевых платформ Linux и macOS

- Библиотеки времени выполнения GCC-6 (или новее).
- [`libgdiplus`](https://github.com/mono/libgdiplus): открытая реализация API GDI+.
- Зависимости .NET Core Runtime. Установка самого .NET Core Runtime НЕ требуется.
- Для Python 3.5-3.7: необходима сборка Python с `pymalloc`. Опция сборки Python `--with-pymalloc` включена по умолчанию. Обычно сборка Python с `pymalloc` помечена суффиксом `m` в имени файла.
- Общая библиотека Python `libpython`. Опция сборки Python `--enable-shared` отключена по умолчанию, некоторые дистрибутивы Python не содержат общую библиотеку `libpython`. Для некоторых платформ Linux общую библиотеку `libpython` можно установить с помощью менеджера пакетов, например: `sudo apt-get install libpython3.7`. Распространенная проблема заключается в том, что библиотека `libpython` установлена в другом месте, чем стандартное системное местоположение для общих библиотек. Проблему можно решить, используя опции сборки Python для установки альтернативных путей библиотек при компиляции Python, или создать символическую ссылку на файл библиотеки `libpython` в стандартном местоположении системы для общих библиотек. Обычно имя файла общей библиотеки `libpython` - `libpythonX.Ym.so.1.0` для Python 3.5-3.7, или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например: libpython3.7m.so.1.0, libpython3.9.so.1.0).  
