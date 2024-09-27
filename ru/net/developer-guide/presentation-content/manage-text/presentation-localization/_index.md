---
title: Локализация Презентации
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords: "Изменить язык, Проверка правописания, Проверка орфографии, Проверяющий правописание, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Измените или проверьте язык в презентации PowerPoint. Проверка орфографии текста в C# или .NET"
---
## **Изменить Язык для Презентации и Текста Формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте Автофигуру типа Прямоугольник на слайд.
- Добавьте текст в текстовое поле.
- Установите идентификатор языка для текста.
- Запишите презентацию в файл формата PPTX.

Реализация вышеуказанных шагов показана ниже на примере.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Текст для применения языка проверки правописания");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```