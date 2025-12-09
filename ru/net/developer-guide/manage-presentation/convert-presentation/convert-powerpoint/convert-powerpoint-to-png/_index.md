---
title: Преобразовать слайды PowerPoint в PNG в .NET
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- .NET
- C#
- Aspose.Slides
description: "Быстро преобразуйте презентации PowerPoint в высококачественные PNG‑изображения с помощью Aspose.Slides для .NET, обеспечивая точные автоматические результаты."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат PNG с помощью C#. Она охватывает следующие темы.

- [Преобразовать PowerPoint в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать PPT в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать PPTX в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать ODP в PNG на C#](#convert-powerpoint-to-png)
- [Преобразовать слайд PowerPoint в изображение на C#](#convert-powerpoint-to-png)

## **PowerPoint в PNG на C#**

Для примера кода на C#, преобразующего PowerPoint в PNG, смотрите раздел ниже, то есть [Преобразовать PowerPoint в PNG](#convert-powerpoint-to-png). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation, а затем сохранять миниатюру слайда в формате PNG. Другие преобразования PowerPoint в изображения, такие как JPG, BMP, TIFF и SVG, обсуждаются в следующих статьях.

- [PowerPoint на C# в JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint на C# в BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint на C# в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [PowerPoint на C# в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен.

**Случай использования:** Когда у вас сложное изображение и размер не критичен, PNG — лучший формат изображения, чем JPEG.

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно ознакомиться с бесплатными конвертерами Aspose **PowerPoint в PNG Конвертеры**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они представляют собой живую реализацию процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) через интерфейс [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Воспользуйтесь методом [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) для получения миниатюры каждого слайда.
4. Используйте метод [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) для сохранения миниатюры слайда в формате PNG.

Этот пример кода на C# показывает, как преобразовать презентацию PowerPoint в PNG. Объект Presentation может загружать PPT, PPTX, ODP и т.д., после чего каждый слайд преобразуется в формат PNG или другие форматы изображений.
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

Если вы хотите получить PNG‑файлы определённого масштаба, можно задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры.

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

Если вам нужны PNG‑файлы определённого размера, можно передать желаемые аргументы `width` и `height` для `imageSize`.

Этот код показывает, как преобразовать PowerPoint в PNG, задав размер изображений:
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


## **Часто задаваемые вопросы**

**Как экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?**  
Aspose.Slides поддерживает [генерацию миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/); вы можете отрисовать фигуру в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**  
Да, но [не делитесь](/slides/ru/net/multithreading/) одной экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**  
Режим оценки добавляет водяной знак к выходным изображениям и накладывает [другие ограничения](/slides/ru/net/licensing/), пока не будет применена лицензия.