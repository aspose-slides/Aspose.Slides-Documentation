---
title: Отображение слайдов презентации как SVG‑изображения в .NET
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
description: "Узнайте, как отображать слайды PowerPoint как SVG‑изображения с помощью Aspose.Slides для .NET. Высококачественная визуализация с простыми примерами кода на C#."
---

## **Обзор**

Эта статья объясняет, как **конвертировать презентацию PowerPoint в формат SVG с использованием C#**. В ней рассматриваются следующие темы.

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

Другие темы, охваченные в этой статье.
- [См. также](#see-also)

## **Формат SVG**
SVG — аббревиатура от Scalable Vector Graphics — это стандартный тип графики или формат, используемый для отображения двумерных изображений. SVG хранит изображения как векторы в XML с деталями, определяющими их поведение или внешний вид.

SVG — один из немногих форматов изображений, отвечающих самым высоким требованиям по масштабируемости, интерактивности, производительности, доступности, программируемости и другим параметрам. По этим причинам он широко используется в веб‑разработке.

Вам может понадобиться использовать файлы SVG, когда необходимо

- **напечатать презентацию в *очень большом формате*.** SVG‑изображения могут масштабироваться до любой разрешающей способности. Вы можете менять размер SVG‑изображений сколько угодно раз без потери качества.
- **использовать диаграммы и графики со слайдов в *разных носителях или платформах*.** Большинство просмотрщиков умеют интерпретировать SVG‑файлы.
- **получить *наименьший возможный размер изображений*.** SVG‑файлы, как правило, меньше их аналогов с высоким разрешением в других форматах, особенно в растровых (JPEG или PNG).

## **Отобразить слайд как изображение SVG**

Aspose.Slides for .NET позволяет экспортировать слайды презентаций в виде SVG‑изображений. Выполните следующие шаги, чтобы создать SVG‑файлы:

_Шаги: Конвертация PowerPoint в SVG в C#_

Ниже приведён пример кода, демонстрирующий эти конверсии на .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Шаги: Конвертировать PowerPoint в SVG в C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Шаги: Конвертировать PPT в SVG в C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Шаги: Конвертировать PPTX в SVG в C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Шаги: Конвертировать ODP в SVG в C#</strong></a>

_Кодовые шаги:_

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * расширение _.ppt_ — загрузка **PPT**‑файла в класс _Presentation_.
   * расширение _.pptx_ — загрузка **PPTX**‑файла в класс _Presentation_.
   * расширение _.odp_ — загрузка **ODP**‑файла в класс _Presentation_.
   * расширение _.pps_ — загрузка **PPS**‑файла в класс _Presentation_.
2. Пройдитесь по всем слайдам презентации.
3. Запишите каждый слайд в отдельный SVG‑файл через FileStream.

{{% alert color="primary" %}} 

Возможно, вам будет интересно попробовать наше [бесплатное веб-приложение](https://products.aspose.app/slides/conversion/ppt-to-svg), в котором реализована функция конверсии PPT в SVG от Aspose.Slides for .NET.

{{% /alert %}} 

Ниже показан пример кода на C#, демонстрирующий, как конвертировать PowerPoint в SVG с помощью Aspose.Slides: 
``` csharp
// Объект Presentation может загружать форматы PowerPoint, такие как PPT, PPTX, ODP и т.д.
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

Поддержка конкретных возможностей SVG реализована по‑разному в движках браузеров. Параметры [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) помогают сгладить несовместимости.

**Можно ли экспортировать не только слайды, но и отдельные фигуры в SVG?**

Да. Любая [фигура может быть сохранена как отдельный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), что удобно для иконок, пиктограмм и повторного использования графики.

**Можно ли объединить несколько слайдов в один SVG (полоска/документ)?**

Стандартный сценарий — один слайд → один SVG. Объединение нескольких слайдов в один холст SVG выполняется на уровне прикладного кода как постобработка.

## **См. также** 

Эта статья также охватывает следующие темы. Коды такие же, как выше.

_Формат_: **PowerPoint**
- [C# PowerPoint в SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint в SVG Converter](#csharp-powerpoint-to-svg)

_Формат_: **PPT**
- [C# PPT в SVG Code](#csharp-ppt-to-svg)
- [C# PPT в SVG API](#csharp-ppt-to-svg)
- [C# PPT в SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT в SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT в SVG Converter](#csharp-ppt-to-svg)

_Формат_: **PPTX**
- [C# PPTX в SVG Code](#csharp-pptx-to-svg)
- [C# PPTX в SVG API](#csharp-pptx-to-svg)
- [C# PPTX в SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX в SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX в SVG Converter](#csharp-pptx-to-svg)

_Формат_: **ODP**
- [C# ODP в SVG Code](#csharp-odp-to-svg)
- [C# ODP в SVG API](#csharp-odp-to-svg)
- [C# ODP в SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP в SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP в SVG Converter](#csharp-odp-to-svg)