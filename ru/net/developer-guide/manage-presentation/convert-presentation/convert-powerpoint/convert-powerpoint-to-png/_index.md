---
title: Конвертировать PowerPoint в PNG на C#
linktitle: Конвертировать PowerPoint в PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords: c# poweroint в png, c# ppt в png, c# pptx в png, c# odp в png, PowerPoint в PNG, PPT в PNG, PPTX в PNG, C#, Csharp, Aspose.Slides для .NET
description: Конвертировать презентацию PowerPoint в PNG на C#. Конвертировать PPT в PNG на C#. Конвертировать PPTX в PNG на C#. Конвертировать ODP в PNG на C#
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат PNG с использованием C#. Она охватывает следующие темы.

- [Конвертировать PowerPoint в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать PPT в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать PPTX в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать ODP в PNG на C#](#convert-powerpoint-to-png)
- [Конвертировать слайд PowerPoint в изображение на C#](#convert-powerpoint-to-png)

## **C# PowerPoint в PNG**

Для получения примера кода на C# для конвертации PowerPoint в PNG, пожалуйста, смотрите раздел ниже т.е. [Конвертировать PowerPoint в PNG](#convert-powerpoint-to-png). Код может загружать различные форматы, такие как PPT, PPTX и ODP в объект Presentation, а затем сохранять миниатюру его слайдов в формате PNG. Другие конверсии PowerPoint в изображение, которые более или менее похожи, такие как JPG, BMP, TIFF и SVG, обсуждаются в этих статьях.

- [C# PowerPoint в JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О конверсии PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все же весьма распространен.

**Случай использования:** Когда у вас есть сложное изображение и размер не является проблемой, PNG является лучшим форматом изображения, чем JPEG.

{{% alert title="Совет" color="primary" %}} Вам может быть интересно ознакомиться с бесплатными **Конвертерами PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

Пройдите через следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) под интерфейсом [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Используйте метод [ISlideGetThumbnail](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index), чтобы получить миниатюру для каждого слайда.
4. Используйте метод [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), чтобы сохранить миниатюру слайда в формате PNG.

Этот код на C# показывает, как конвертировать презентацию PowerPoint в PNG. Объект Presentation может загружать PPT, PPTX, ODP и т.д., затем каждый слайд в объекте презентации конвертируется в формат PNG или другие форматы изображений.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];
        slide.GetThumbnail().Save($"slide_{index}.png", ImageFormat.Png);
    }
}
```

## **Конвертировать PowerPoint в PNG с помощью пользовательских размеров**

Если вы хотите получить PNG файлы с определенной масштабностью, вы можете установить значения для `desiredX` и `desiredY`, которые определяют размеры полученной миниатюры.

Этот код на C# демонстрирует описанную операцию:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];
        slide.GetThumbnail(scaleX, scaleY).Save($"slide_{index}.png", ImageFormat.Png); 
    }
}
```

## **Конвертировать PowerPoint в PNG с определенным размером**

Если вы хотите получить PNG файлы определенного размера, вы можете передать свои предпочтительные аргументы `width` и `height` для `ImageSize`.

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер для изображений:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];
        slide.GetThumbnail(size).Save($"slide_{index}.png", ImageFormat.Png);
    }
}
```