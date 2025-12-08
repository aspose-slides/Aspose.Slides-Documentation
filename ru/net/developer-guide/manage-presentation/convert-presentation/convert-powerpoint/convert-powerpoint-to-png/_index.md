---
title: Конвертировать PowerPoint в PNG на C#
linktitle: Конвертировать PowerPoint в PNG
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-png/
keywords:
- PowerPoint в png
- ppt в png
- pptx в png
- odp в png
- PowerPoint в PNG
- PPT в PNG
- PPTX в PNG
- ODP в PNG
- C#
- Csharp
- Aspose.Slides for .NET
description: Конвертировать презентацию PowerPoint в PNG на C#. Конвертировать PPT в PNG на C#. Конвертировать PPTX в PNG на C#. Конвертировать ODP в PNG на C#
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат PNG с помощью C#. Рассмотрены следующие темы.

- [Конвертировать PowerPoint в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать PPT в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать PPTX в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать ODP в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать слайд PowerPoint в изображение на C#](#convert-powerpoint-to-png)

## **C# PowerPoint в PNG**

Для примера кода C# по конвертации PowerPoint в PNG смотрите раздел ниже — [Конвертировать PowerPoint в PNG](#convert-powerpoint-to-png). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation, а затем сохранять миниатюру слайда в формате PNG. Другие конвертации PowerPoint в изображения, похожие по принципу, такие как JPG, BMP, TIFF и SVG, обсуждаются в следующих статьях.

- [C# PowerPoint в JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все равно широко используется. 

**Случай применения:** Если у вас сложное изображение и размер не имеет значения, PNG — лучший формат изображения, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Вам может быть интересно проверить бесплатные конвертеры Aspose **PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

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


## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Если необходимо получить PNG‑файлы определённого масштаба, задайте значения `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры. 

Следующий код на C# демонстрирует описанную операцию:
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


## **Конвертировать PowerPoint в PNG с пользовательским размером**

Если необходимо получить PNG‑файлы определённого размера, передайте желаемые аргументы `width` и `height` для `imageSize`. 

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

**Как экспортировать только конкретный объект (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/); можно отрисовать фигуру в PNG‑изображение.

**Поддерживается ли параллельная конвертация на сервере?**

Да, но не следует [делить](/slides/ru/net/multithreading/) один экземпляр презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Какие ограничения у пробной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/net/licensing/), пока не будет применена лицензия.