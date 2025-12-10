---
title: Преобразование слайдов PowerPoint в PNG в .NET
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-png/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для .NET, обеспечивая точные, автоматизированные результаты."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат PNG с помощью C#. Она охватывает следующие темы.

- [Преобразовать PowerPoint в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать PPT в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать PPTX в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать ODP в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать слайд PowerPoint в изображение на C#](#convert-powerpoint-to-png)

## **PowerPoint в PNG в .NET**

Для примера кода на C# по преобразованию PowerPoint в PNG смотрите раздел ниже, а именно [Преобразовать PowerPoint в PNG](#convert-powerpoint-to-png). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation, а затем сохранять миниатюру слайда в формате PNG. Другие преобразования PowerPoint в изображения, аналогичные JPG, BMP, TIFF и SVG, рассматриваются в следующих статьях.

- [C# PowerPoint в JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все равно очень популярен.

**Сценарий использования:** Когда у вас сложное изображение и размер не является проблемой, PNG — лучший формат изображения по сравнению с JPEG.

{{% alert title="Tip" color="primary" %}} Вы можете захотеть посмотреть бесплатные конвертеры Aspose **Конвертеры PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) под интерфейсом [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Вызовите метод [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) для получения миниатюры каждого слайда.
4. Используйте метод [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) для сохранения миниатюры слайда в формате PNG.

Этот код на C# показывает, как преобразовать презентацию PowerPoint в PNG. Объект Presentation может загружать PPT, PPTX, ODP и др., после чего каждый слайд в объекте Presentation преобразуется в формат PNG или другие форматы изображений.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить файлы PNG определённого масштаба, вы можете установить значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры.

Этот код на C# демонстрирует описанную операцию:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **Преобразовать PowerPoint в PNG с пользовательским размером**

Если вы хотите получить файлы PNG определённого размера, вы можете передать желаемые аргументы `width` и `height` для `imageSize`.

Этот код показывает, как преобразовать PowerPoint в PNG, указывая размер изображений:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **Вопросы и ответы**

**Как экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/); вы можете отобразить форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делитесь](/slides/ru/net/multithreading/) одной экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [прочие ограничения](/slides/ru/net/licensing/), пока не будет применена лицензия.