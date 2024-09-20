---
title: Отобразить слайд в формате SVG в C#
linktitle: Отобразить слайд в формате SVG
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: В этой статье объясняется, как конвертировать презентацию PowerPoint в формат SVG с помощью C#. Вы можете конвертировать форматы PPT, PPTX, ODP в SVG-изображения.
keywords: C# Конвертировать PowerPoint в SVG, C# PPT в SVG, C# PPTX в SVG
---

## Обзор

В этой статье объясняется, как **конвертировать презентацию PowerPoint в формат SVG с помощью C#**. Она охватывает следующие темы.

_Формат_: **PowerPoint**
- [C# PowerPoint в SVG](#csharp-powerpoint-to-svg)
- [C# Конвертировать PowerPoint в SVG](#csharp-powerpoint-to-svg)
- [C# Как конвертировать файл PowerPoint в SVG](#csharp-powerpoint-to-svg)

_Формат_: **PPT**
- [C# PPT в SVG](#csharp-ppt-to-svg)
- [C# Конвертировать PPT в SVG](#csharp-ppt-to-svg)
- [C# Как конвертировать файл PPT в SVG](#csharp-ppt-to-svg)

_Формат_: **PPTX**
- [C# PPTX в SVG](#csharp-pptx-to-svg)
- [C# Конвертировать PPTX в SVG](#csharp-pptx-to-svg)
- [C# Как конвертировать файл PPTX в SVG](#csharp-pptx-to-svg)

_Формат_: **ODP**
- [C# ODP в SVG](#csharp-odp-to-svg)
- [C# Конвертировать ODP в SVG](#csharp-odp-to-svg)
- [C# Как конвертировать файл ODP в SVG](#csharp-odp-to-svg)

_Формат_: **Слайд**
- [C# Конвертировать слайд PowerPoint в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPT в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPTX в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд ODP в SVG](#render-a-slide-as-an-svg-image)

Другие темы, охваченные в этой статье.
- [См. также](#see-also)

## Формат SVG
SVG—акроним для Scalable Vector Graphics—это тип графики или формат, используемый для отображения двумерных изображений. SVG хранит изображения в виде векторов в XML с деталями, которые определяют их поведение или внешний вид.

SVG является одним из немногих форматов изображений, который соответствует очень высоким стандартам в этих терминах: масштабируемость, интерактивность, производительность, доступность, программируемость и другие. По этим причинам его обычно используют в веб-разработке.

Вам может понадобиться использовать файлы SVG, когда вам нужно

- **распечатать вашу презентацию в *очень крупном формате*.** Изображения SVG могут масштабироваться до любого разрешения или уровня. Вы можете изменять размер изображений SVG столько раз, сколько необходимо, без потери качества.
- **использовать графики и таблицы из ваших слайдов в *разных средах или платформах**.* Большинство устройств могут интерпретировать файлы SVG.
- **использовать *как можно меньшие размеры изображений***. Файлы SVG, как правило, меньше, чем их высококачественные эквиваленты в других форматах, особенно тех, которые основаны на растровой графике (JPEG или PNG).

## Отобразить слайд в формате SVG

Aspose.Slides для .NET позволяет экспортировать слайды в ваших презентациях как SVG-изображения. Выполните следующие шаги, чтобы сгенерировать SVG-изображения:

_Шаги: Конвертация PowerPoint в SVG на C#_

Следующий образец кода объясняет эти конверсии с использованием .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Шаги: Конвертировать PowerPoint в SVG на C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Шаги: Конвертировать PPT в SVG на C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Шаги: Конвертировать PPTX в SVG на C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Шаги: Конвертировать ODP в SVG на C#</strong></a>

_Код шагов:_

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ расширение для загрузки **файла PPT** внутри класса _Presentation_.
   * _.pptx_ расширение для загрузки **файла PPTX** внутри класса _Presentation_.
   * _.odp_ расширение для загрузки **файла ODP** внутри класса _Presentation_.
   * _.pps_ расширение для загрузки **файла PPS** внутри класса _Presentation_.
2. Переберите все слайды презентации.
3. Запишите каждый слайд в его собственный файл SVG через FileStream.

{{% alert color="primary" %}} 

Вам может быть интересно попробовать наше [бесплатное веб-приложение](https://products.aspose.app/slides/conversion/ppt-to-svg), в котором мы реализовали функцию преобразования PPT в SVG из Aspose.Slides для .NET.

{{% /alert %}} 

Этот пример кода на C# показывает, как конвертировать PowerPoint в SVG с использованием Aspose.Slides: 

``` csharp
// Объект Presentation может загружать форматы PowerPoint, такие как PPT, PPTX, ODP и т. д.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## См. также 

Эта статья также охватывает эти темы. Коды такие же, как и выше.

_Формат_: **PowerPoint**
- [C# PowerPoint в SVG Код](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG Программно](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG Библиотека](#csharp-powerpoint-to-svg)
- [C# Сохранить PowerPoint как SVG](#csharp-powerpoint-to-svg)
- [C# Генерировать SVG из PowerPoint](#csharp-powerpoint-to-svg)
- [C# Создать SVG из PowerPoint](#csharp-powerpoint-to-svg)
- [C# Конвертер PowerPoint в SVG](#csharp-powerpoint-to-svg)

_Формат_: **PPT**
- [C# PPT в SVG Код](#csharp-ppt-to-svg)
- [C# PPT в SVG API](#csharp-ppt-to-svg)
- [C# PPT в SVG Программно](#csharp-ppt-to-svg)
- [C# PPT в SVG Библиотека](#csharp-ppt-to-svg)
- [C# Сохранить PPT как SVG](#csharp-ppt-to-svg)
- [C# Генерировать SVG из PPT](#csharp-ppt-to-svg)
- [C# Создать SVG из PPT](#csharp-ppt-to-svg)
- [C# Конвертер PPT в SVG](#csharp-ppt-to-svg)

_Формат_: **PPTX**
- [C# PPTX в SVG Код](#csharp-pptx-to-svg)
- [C# PPTX в SVG API](#csharp-pptx-to-svg)
- [C# PPTX в SVG Программно](#csharp-pptx-to-svg)
- [C# PPTX в SVG Библиотека](#csharp-pptx-to-svg)
- [C# Сохранить PPTX как SVG](#csharp-pptx-to-svg)
- [C# Генерировать SVG из PPTX](#csharp-pptx-to-svg)
- [C# Создать SVG из PPTX](#csharp-pptx-to-svg)
- [C# Конвертер PPTX в SVG](#csharp-pptx-to-svg)

_Формат_: **ODP**
- [C# ODP в SVG Код](#csharp-odp-to-svg)
- [C# ODP в SVG API](#csharp-odp-to-svg)
- [C# ODP в SVG Программно](#csharp-odp-to-svg)
- [C# ODP в SVG Библиотека](#csharp-odp-to-svg)
- [C# Сохранить ODP как SVG](#csharp-odp-to-svg)
- [C# Генерировать SVG из ODP](#csharp-odp-to-svg)
- [C# Создать SVG из ODP](#csharp-odp-to-svg)
- [C# Конвертер ODP в SVG](#csharp-odp-to-svg)