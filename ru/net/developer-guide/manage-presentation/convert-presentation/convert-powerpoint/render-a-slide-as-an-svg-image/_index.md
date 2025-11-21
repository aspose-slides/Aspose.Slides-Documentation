---
title: Отображение слайдов презентации в виде SVG‑изображений в .NET
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- сохранить PPT как SVG
- сохранить PPTX как SVG
- экспортировать PPT в SVG
- экспортировать PPTX в SVG
- отобразить слайд
- конвертировать слайд
- экспортировать слайд
- векторное изображение
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: Узнайте, как отображать слайды PowerPoint в виде SVG‑изображений с помощью Aspose.Slides для .NET. Высококачественная визуализация с простыми примерами кода на C#.
---

## **Обзор**

Эта статья объясняет, как **конвертировать презентацию PowerPoint в формат SVG с помощью C#**. Она охватывает следующие темы.

**Формат**: **PowerPoint**
- [C# PowerPoint в SVG](#csharp-powerpoint-to-svg)
- [C# Конвертировать PowerPoint в SVG](#csharp-powerpoint-to-svg)
- [C# Как конвертировать файл PowerPoint в SVG](#csharp-powerpoint-to-svg)

**Формат**: **PPT**
- [C# PPT в SVG](#csharp-ppt-to-svg)
- [C# Конвертировать PPT в SVG](#csharp-ppt-to-svg)
- [C# Как конвертировать файл PPT в SVG](#csharp-ppt-to-svg)

**Формат**: **PPTX**
- [C# PPTX в SVG](#csharp-pptx-to-svg)
- [C# Конвертировать PPTX в SVG](#csharp-pptx-to-svg)
- [C# Как конвертировать файл PPTX в SVG](#csharp-pptx-to-svg)

**Формат**: **ODP**
- [C# ODP в SVG](#csharp-odp-to-svg)
- [C# Конвертировать ODP в SVG](#csharp-odp-to-svg)
- [C# Как конвертировать файл ODP в SVG](#csharp-odp-to-svg)

**Формат**: **Slide**
- [C# Конвертировать слайд PowerPoint в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPT в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд PPTX в SVG](#render-a-slide-as-an-svg-image)
- [C# Конвертировать слайд ODP в SVG](#render-a-slide-as-an-svg-image)

Другие темы, покрытые в этой статье.
- [См. также](#see-also)

## **SVG‑формат**
SVG — это аббревиатура от Scalable Vector Graphics, стандартный тип графики или формат, используемый для отображения двумерных изображений. SVG сохраняет изображения как векторы в XML с деталями, определяющими их поведение или внешний вид.

SVG — один из немногих форматов изображений, отвечающих очень высоким требованиям в следующих областях: масштабируемость, интерактивность, производительность, доступность, программируемость и другие. По этим причинам он часто используется в веб‑разработке.

Возможно, вам понадобится использовать файлы SVG, когда нужно

- **напечатать вашу презентацию в *очень большом формате*.** SVG‑изображения могут масштабироваться до любого разрешения. Вы можете изменять размер SVG‑изображений сколько угодно раз без потери качества.
- **использовать диаграммы и графики из ваших слайдов в *разных средах или платформах*.** Большинство просмотрщиков умеют интерпретировать SVG‑файлы.
- **использовать *наименьшие возможные размеры изображений***. SVG‑файлы, как правило, меньше их аналогов в высоком разрешении в других форматах, особенно в растровых (JPEG или PNG).

## **Отобразить слайд как SVG‑изображение**

Aspose.Slides for .NET позволяет экспортировать слайды ваших презентаций в виде SVG‑изображений. Выполните следующие шаги, чтобы создать SVG‑изображения:

_Шаги: Конверсия PowerPoint в SVG на C#_

Следующий пример кода демонстрирует эти конверсии с использованием .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Шаги: Конвертировать PowerPoint в SVG на C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Шаги: Конвертировать PPT в SVG на C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Шаги: Конвертировать PPTX в SVG на C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Шаги: Конвертировать ODP в SVG на C#</strong></a>

_Шаги кода:_

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ — расширение для загрузки файла **PPT** в класс _Presentation_.
   * _.pptx_ — расширение для загрузки файла **PPTX** в класс _Presentation_.
   * _.odp_ — расширение для загрузки файла **ODP** в класс _Presentation_.
   * _.pps_ — расширение для загрузки файла **PPS** в класс _Presentation_.
2. Пройдите по всем слайдам в презентации.
3. Запишите каждый слайд в отдельный SVG‑файл через FileStream.

{{% alert color="primary" %}} 

Возможно, вы захотите попробовать наше [бесплатное веб‑приложение](https://products.aspose.app/slides/conversion/ppt-to-svg), в котором реализована функция конверсии PPT в SVG от Aspose.Slides for .NET. 

{{% /alert %}} 

Этот пример кода на C# показывает, как конвертировать PowerPoint в SVG с помощью Aspose.Slides: 
``` csharp
// Объект Presentation может загружать форматы PowerPoint такие как PPT, PPTX, ODP и др.
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


## **Часто задаваемые вопросы**

**Почему полученный SVG может выглядеть по‑разному в разных браузерах?**

Поддержка конкретных возможностей SVG реализована по‑разному в движках браузеров. Параметры [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) помогают сгладить несовместимости.

**Можно ли экспортировать не только слайды, но и отдельные фигуры в SVG?**

Да. Любую [figure можно сохранить как отдельный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), что удобно для иконок, пиктограмм и повторного использования графики.

**Можно ли объединить несколько слайдов в один SVG (полоска/документ)?**

Обычный сценарий — один слайд → один SVG. Объединение нескольких слайдов в один SVG‑канвас происходит на уровне приложения как постобработка.

## **См. также** 

Эта статья также охватывает следующие темы. Коды такие же, как выше.

**Формат**: **PowerPoint**
- [C# PowerPoint Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint API](#csharp-powerpoint-to-svg)
- [C# PowerPoint Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint Converter](#csharp-powerpoint-to-svg)

**Формат**: **PPT**
- [C# PPT Code](#csharp-ppt-to-svg)
- [C# PPT API](#csharp-ppt-to-svg)
- [C# PPT Programmatically](#csharp-ppt-to-svg)
- [C# PPT Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT Converter](#csharp-ppt-to-svg)

**Формат**: **PPTX**
- [C# PPTX Code](#csharp-pptx-to-svg)
- [C# PPTX API](#csharp-pptx-to-svg)
- [C# PPTX Programmatically](#csharp-pptx-to-svg)
- [C# PPTX Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX Converter](#csharp-pptx-to-svg)

**Формат**: **ODP**
- [C# ODP Code](#csharp-odp-to-svg)
- [C# ODP API](#csharp-odp-to-svg)
- [C# ODP Programmatically](#csharp-odp-to-svg)
- [C# ODP Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP Converter](#csharp-odp-to-svg)