---
title: Системные требования
type: docs
weight: 60
url: /ru/python-net/getting-started/system-requirements/
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
description: "Узнайте о системных требованиях Aspose.Slides для Python via .NET. Обеспечьте беспроблемную поддержку PowerPoint и OpenDocument на Windows, Linux и macOS."
---

## **Введение**

Aspose.Slides for Python via .NET не требует установки каких-либо сторонних продуктов, таких как Microsoft PowerPoint. Aspose.Slides — это движок для создания, изменения, конвертации и визуализации документов в различных форматах, включая форматы презентаций Microsoft PowerPoint.

## **Поддерживаемые операционные системы**

Aspose.Slides for Python поддерживает Windows (32‑bit и 64‑bit), macOS и 64‑bit Linux на системах с установленным Python 3.5 или более поздней версии.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Операционная система</td>
        <td style="font-weight: bold; width:400px">Версии</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows Server 2003</li>
                <li>Windows Server 2008</li>
                <li>Windows Server 2012</li>
                <li>Windows Server 2012 R2</li>
                <li>Windows Server 2016</li>
                <li>Windows Server 2019</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
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
                <li>12 “Monterey”</li>
            </ul>
        </td>
    </tr>
</table>

## **Системные требования для целевых платформ Linux и macOS**

- Библиотеки времени выполнения GCC 6 (или новее).
- [libgdiplus](https://github.com/mono/libgdiplus), открытая реализация API GDI+.
- Зависимости .NET Core Runtime. Установка самого .NET Core Runtime НЕ требуется.
- Для Python 3.5–3.7: требуется сборка Python с `pymalloc`. Параметр сборки `--with-pymalloc` включён по умолчанию. Обычно сборка `pymalloc` отмечается суффиксом `m` в имени файла.
- `libpython` — общая библиотека. Параметр сборки Python `--enable-shared` отключён по умолчанию, и некоторые дистрибутивы Python не включают общую библиотеку `libpython`. На некоторых платформах Linux её можно установить с помощью менеджера пакетов (например, `sudo apt-get install libpython3.7`). Распространённая проблема — размещение библиотеки `libpython` в нестандартном месте для общих библиотек. Это можно решить, указав альтернативные пути к библиотекам в параметрах сборки Python, либо создав символическую ссылку на файл библиотеки `libpython` в стандартном каталоге общих библиотек системы. Как правило, имя файла общей библиотеки `libpython` выглядит как `libpythonX.Ym.so.1.0` для Python 3.5–3.7 или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Вопросы и ответы**

**Нужен ли установленный Microsoft PowerPoint для конвертации и визуализации?**

Нет, PowerPoint не требуется; Aspose.Slides — это автономный движок для [создания](/slides/ru/python-net/create-presentation/), модификации, [конвертации](/slides/ru/python-net/convert-presentation/) и [визуализации](/slides/ru/python-net/convert-powerpoint-to-png/) презентаций.

**Требуется ли конкретная версия .NET (Core/5+/6+) на машине?**

Установка самого .NET Runtime не требуется, однако его зависимости должны быть присутствовать на Linux/macOS. Это означает, что система должна содержать пакеты, обычно устанавливаемые как зависимости .NET, без полной установки runtime.

**Какие шрифты нужны для корректного отображения?**

На практике должны быть доступны шрифты, использованные в презентации, либо их подходящие [заменители](/slides/ru/python-net/font-substitution/). Чтобы обеспечить согласованное отображение на Linux/macOS, рекомендуется установить общие пакеты шрифтов.