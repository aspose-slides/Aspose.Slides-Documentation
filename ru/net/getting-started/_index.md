---
title: Начало работы
type: docs
weight: 10
url: /ru/net/getting-started/
keywords:
- начало работы
- системные требования
- установка
- первая презентация
- NuGet
- обработка PPT
- обработка PPTX
- обработка ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Путь от нового проекта .NET до первой сохранённой презентации с Aspose.Slides: проверьте требования, установите пакет, запустите первую программу и продолжайте выполнять типичные задачи."
---
## **Обзор**

Выполните четыре шага ниже последовательно. Каждый шаг указывает, что делать, и содержит ссылку на статью с подробностями. Оценка, лицензирование и поддержка рассматриваются после шагов.

## **Шаг 1: Проверьте системные требования**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) работает в Windows, Linux и macOS. [System Requirements](/slides/ru/net/system-requirements/) перечисляет операционные системы и версии .NET, поддерживаемые каждым пакетом, а также библиотеки, необходимые Linux.

## **Шаг 2: Установите пакет**

Aspose.Slides for .NET распространяется через NuGet как два пакета, предоставляющих одинаковые классы. Добавьте один из них в ваш проект:

- В Windows: `dotnet add package Aspose.Slides.NET`
- В Linux и macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. В Linux сначала установите библиотеку `fontconfig`.
- В Alpine Linux и в системах Linux, где glibc старее 2.23 (x64) или 2.39 (ARM64): Aspose.Slides.NET, с установленной библиотекой `libgdiplus`.

[Installation](/slides/ru/net/installation/) предоставляет команды Linux, дополнительную настройку запуска, которую требует Aspose.Slides.NET в Linux, и шаги для Visual Studio.

## **Шаг 3: Создайте свою первую презентацию**

[quick start on the Aspose.Slides for .NET home page](/slides/ru/net/#your-first-presentation) — это полностью готовая консольная программа: она добавляет текстовое поле на слайд и сохраняет презентацию в файл PPTX. [Create Presentations](/slides/ru/net/create-presentation/) объясняет те же шаги подробнее и показывает, как открыть существующую презентацию и сохранить её в другом формате.

## **Шаг 4: Продолжите с типичными задачами**

- [Open a presentation](/slides/ru/net/open-presentation/)
- [Save a presentation](/slides/ru/net/save-presentation/)
- [Convert a presentation to PDF](/slides/ru/net/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/ru/net/convert-slide/)
- [Edit presentation text](/slides/ru/net/manage-text/)
- [Examples by slide element](/slides/ru/net/examples/)

## **Оценка и лицензирование**

Без лицензии Aspose.Slides работает в режиме оценки: он добавляет водяной знак к каждому сохраняемому слайду и обрезает текст, считанный из презентаций.

- [Evaluate Aspose.Slides](/slides/ru/net/evaluate-aspose-slides/) описывает ограничения оценки и как запросить временную лицензию.
- [Licensing](/slides/ru/net/licensing/) показывает, как применить лицензию из файла, потока или встроенного ресурса.
- [Metered Licensing](/slides/ru/net/metered-licensing/) рассказывает о лицензировании, которое оплачивается по использованию.
- [Supported File Formats](/slides/ru/net/supported-file-formats/) перечисляет форматы, которые Aspose.Slides может загружать и сохранять.

## **Получить помощь**

[Product Support](/slides/ru/net/product-support/) объясняет, как задать вопрос на [free support forum](https://forum.aspose.com/c/slides/11) и что включать при сообщении о проблеме.

## **Вопросы и ответы**

**Нужен ли мне установленный Microsoft PowerPoint?**

Нет. Aspose.Slides самостоятельно читает и записывает файлы презентаций и не использует PowerPoint, поэтому он также работает на серверах и в Linux.

**Какой пакет следует использовать для приложения .NET Framework?**

Aspose.Slides.NET. Он включает сборки для .NET Framework 4.6.2 и новее, .NET 6 и новее, а также .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform требует .NET 6 или новее.