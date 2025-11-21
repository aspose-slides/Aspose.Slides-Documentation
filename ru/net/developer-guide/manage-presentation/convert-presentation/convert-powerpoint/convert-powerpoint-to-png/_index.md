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
- презентация в PNG
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
description: "Быстро преобразуйте презентации PowerPoint в высококачественные PNG‑изображения с помощью Aspose.Slides для .NET, обеспечивая точные и автоматизированные результаты."
---

## **Обзор**

Эта статья объясняет, как конвертировать презентацию PowerPoint в формат PNG с использованием C#. Она охватывает следующие темы.

- [Преобразовать PowerPoint в PNG в C#](#convert-powerpoint-to-png)
- [Преобразовать PPT в PNG в C#](#convert-powerpoint-to-png)
- [Преобразовать PPTX в PNG в C#](#convert-powerpoint-to-png)
- [Преобразовать ODP в PNG в C#](#convert-powerpoint-to-png)
- [Преобразовать слайд PowerPoint в изображение в C#](#convert-powerpoint-to-png)

## **C# PowerPoint в PNG**

Для образца кода C# для конвертации PowerPoint в PNG см. раздел ниже, то есть [Преобразовать PowerPoint в PNG](#convert-powerpoint-to-png). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation, а затем сохранять миниатюру слайда в формате PNG. Другие преобразования PowerPoint в изображения, такие как JPG, BMP, TIFF и SVG, обсуждаются в этих статьях.

- [C# PowerPoint в JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не столь популярен, как JPEG (Joint Photographic Experts Group), но всё равно широко используется. 

**Случай использования:** Когда у вас сложное изображение и размер не имеет значения, PNG лучше подходит, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно попробовать бесплатные конвертеры Aspose **PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) через интерфейс [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Вызовите метод [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) для получения миниатюры каждого слайда. 
4. Используйте метод [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) для сохранения миниатюры слайда в формате PNG. 

Этот код C# показывает, как конвертировать презентацию PowerPoint в PNG. Объект Presentation может загружать PPT, PPTX, ODP и т.д., после чего каждый слайд преобразуется в формат PNG или другие форматы изображений.
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

Если вам нужны PNG‑файлы определённого масштаба, задайте значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

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

Если вам нужны PNG‑файлы определённого размера, передайте желаемые параметры `width` и `height` для `imageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер изображений: 
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

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/); вы можете отобразить форму в PNG‑изображении.

**Поддерживается ли параллельная конвертация на сервере?**

Да, но [не делитесь](/slides/ru/net/multithreading/) единственным экземпляром презентации между потоками. Используйте отдельный экземпляр на каждый поток или процесс.

**Какие ограничения версии для оценки при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/net/licensing/) до установки лицензии.