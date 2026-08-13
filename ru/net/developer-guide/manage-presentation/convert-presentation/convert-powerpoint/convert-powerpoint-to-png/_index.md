---
title: Преобразование слайдов PowerPoint в PNG в .NET
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
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в качественные PNG‑изображения быстро с помощью Aspose.Slides для .NET, обеспечивая точные и автоматизированные результаты."
---
## **Обзор**

Эта статья объясняет, как конвертировать презентации PowerPoint в PNG‑изображения с помощью Aspose.Slides. Она показывает, как загружать файлы презентаций в форматах PPT, PPTX и ODP, рендерить слайды как изображения и сохранять результаты в формате PNG.

Статья также демонстрирует, как настроить созданные PNG‑изображения, задав значения масштаба или указав желаемую ширину и высоту.

## **Конвертировать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/properties/slides) через интерфейс [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide).
3. Используйте метод [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/) для рендеринга каждого слайда в необходимом масштабе.
4. Используйте метод [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.ipresentation/save/methods/5) для сохранения миниатюры слайда в формате PNG.

Этот код C# демонстрирует, как преобразовать презентацию PowerPoint в PNG. Объект Presentation может загружать PPT, PPTX, ODP и т.д., после чего каждый слайд в объекте презентации конвертируется в формат PNG или другие форматы изображений.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Примечание:** Аргументы масштаба `1f, 1f` рендерят каждый слайд в полном размере, поэтому слайд размером 720×540 pt дает изображение 720×540 px. Перегрузка метода без параметров [GetImage()](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/) возвращает гораздо меньшую миниатюру‑просмотр. 
{{% /alert %}} 

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Если нужно получить PNG‑файлы определённого масштаба, можно задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

Этот код на C# демонстрирует описанную операцию:

```c#
using Aspose.Slides;

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

Если нужно получить PNG‑файлы определённого размера, можно передать желаемые аргументы `width` и `height` для `imageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, задав размер изображений:

```c#
using System.Drawing;
using Aspose.Slides;

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

### Как можно экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

### Поддерживается ли параллельное преобразование на сервере?

Да, но [не используйте](/slides/ru/net/multithreading/) один объект презентации одновременно в нескольких потоках. Создавайте отдельный экземпляр для каждого потока или процесса.

### Какие ограничения у пробной версии при экспорте в PNG?

В режиме оценки к выходным изображениям добавляется водяной знак, а также действуют [прочие ограничения](/slides/ru/net/licensing/), пока не будет применена лицензия.