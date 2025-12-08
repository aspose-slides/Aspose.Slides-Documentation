---
title: Отобразить слайд как изображение SVG в C#
linktitle: Отобразить слайд как изображение SVG
type: docs
weight: 50
url: /ru/net/render-a-slide-as-an-svg-image/
description: Эта статья объясняет, как конвертировать презентацию PowerPoint в формат SVG с использованием C#. Вы можете конвертировать форматы PPT, PPTX, ODP в SVG‑изображения.
keywords: C# Конвертировать PowerPoint в SVG, C# PPT в SVG, C# PPTX в SVG
---

## **Обзор**

Эта статья объясняет, как **конвертировать презентацию PowerPoint в формат SVG с использованием C#**. Она охватывает следующие темы.

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

_Формат_: **Slide**
- [C# Конвертировать слайд PowerPoint в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPT в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPTX в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд ODP в SVG](#render-a-slide-as-an-svg-image)

Другие темы, рассмотренные в этой статье.
- [См. также](#see-also)

## **Формат SVG**
SVG — это аббревиатура от Scalable Vector Graphics, стандартный тип графики или формат, используемый для отображения двумерных изображений. SVG хранит изображения как векторы в XML с деталями, определяющими их поведение или внешний вид.

SVG — один из немногих форматов изображений, отвечающих очень высоким требованиям в таких областях, как масштабируемость, интерактивность, производительность, доступность, программируемость и другие. По этим причинам SVG широко применяется в веб‑разработке.

Вы можете использовать файлы SVG, когда необходимо

- **распечатать презентацию в *очень большом формате*.** SVG‑изображения могут масштабироваться до любого разрешения. Вы можете изменять размер SVG‑изображений сколько угодно раз без потери качества.
- **использовать диаграммы и графики из ваших слайдов в *разных средах или платформах*.** Большинство программ способны корректно отображать SVG‑файлы.
- **получить *наименьший возможный размер изображений*.** SVG‑файлы, как правило, меньше их высокоразрешённых аналогов в растровых форматах (JPEG или PNG).

## **Отобразить слайд как изображение SVG**

Aspose.Slides for .NET позволяет экспортировать слайды ваших презентаций в виде SVG‑изображений. Выполните следующие шаги для создания SVG‑изображений:

_Шаги: Конвертация PowerPoint в SVG на C#_

Ниже приведён пример кода, демонстрирующий эти конвертации с использованием .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Шаги: Конвертировать PowerPoint в SVG на C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Шаги: Конвертировать PPT в SVG на C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Шаги: Конвертировать PPTX в SVG на C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Шаги: Конвертировать ODP в SVG на C#</strong></a>

_Код шагов:_

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * расширение _.ppt_ — загрузка **PPT**‑файла в класс _Presentation_.
   * расширение _.pptx_ — загрузка **PPTX**‑файла в класс _Presentation_.
   * расширение _.odp_ — загрузка **ODP**‑файла в класс _Presentation_.
   * расширение _.pps_ — загрузка **PPS**‑файла в класс _Presentation_.
2. Пройдитесь по всем слайдам в презентации.
3. Запишите каждый слайд в отдельный SVG‑файл через FileStream.

{{% alert color="primary" %}} 

Вы можете попробовать наше [бесплатное веб‑приложение](https://products.aspose.app/slides/conversion/ppt-to-svg), в котором реализована функция конвертации PPT в SVG с помощью Aspose.Slides for .NET.

{{% /alert %}} 

Ниже пример кода на C#, показывающий, как конвертировать PowerPoint в SVG с помощью Aspose.Slides: 
``` csharp
// Объект Presentation может загружать форматы PowerPoint такие как PPT, PPTX, ODP и т.д.
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


## **FAQ**

**Почему полученный SVG может выглядеть по‑разному в разных браузерах?**

Поддержка конкретных возможностей SVG реализуется по-разному в движках браузеров. Параметры [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) помогают сгладить эти несовместимости.

**Можно ли экспортировать не только слайды, но и отдельные фигуры в SVG?**

Да. Любую [фигуру можно сохранить как отдельный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), что удобно для значков, пиктограмм и повторного использования графики.

**Можно ли объединить несколько слайдов в один SVG (полоска/документ)?**

Обычный сценарий — один слайд → один SVG. Объединение нескольких слайдов в один SVG‑канвас обычно выполняется на этапе пост‑обработки в приложении.

## **См. также** 

Эта статья также охватывает перечисленные ниже темы. Код остаётся тем же, что и выше.

_Формат_: **PowerPoint**
- [C# PowerPoint Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint API](#csharp-powerpoint-to-svg)
- [C# PowerPoint Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint Converter](#csharp-powerpoint-to-svg)

_Формат_: **PPT**
- [C# PPT Code](#csharp-ppt-to-svg)
- [C# PPT API](#csharp-ppt-to-svg)
- [C# PPT Programmatically](#csharp-ppt-to-svg)
- [C# PPT Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT Converter](#csharp-ppt-to-svg)

_Формат_: **PPTX**
- [C# PPTX Code](#csharp-pptx-to-svg)
- [C# PPTX API](#csharp-pptx-to-svg)
- [C# PPTX Programmatically](#csharp-pptx-to-svg)
- [C# PPTX Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX Converter](#csharp-pptx-to-svg)

_Формат_: **ODP**
- [C# ODP Code](#csharp-odp-to-svg)
- [C# ODP API](#csharp-odp-to-svg)
- [C# ODP Programmatically](#csharp-odp-to-svg)
- [C# ODP Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP Converter](#csharp-odp-to-svg)