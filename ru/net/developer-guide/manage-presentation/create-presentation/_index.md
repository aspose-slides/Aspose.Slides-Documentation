---
title: Создание презентации в .NET
linktitle: Создание презентации
type: docs
weight: 10
url: /net/create-presentation/
keywords: "Создание PowerPoint, PPTX, PPT, Создание презентации, Инициализация презентации, C#, .NET"
description: "Создание презентаций PowerPoint программным образом на C#, например, PPT, PPTX, ODP и т.д."
---

## Создание презентации PowerPoint
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте фигуру типа линия с помощью метода AddAutoShape, предоставленного объектом Shapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```c#
// Создание объекта Presentation, представляющего файл презентации
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд
    ISlide slide = presentation.Slides[0];

    // Добавьте автозаготовку типа линия
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## Создание и сохранение презентации

<a name="csharp-create-save-presentation"><strong>Шаги: Создание и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## Открытие и сохранение презентации

<a name="csharp-open-save-presentation"><strong>Шаги: Открытие и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с любым форматом, т.е. PPT, PPTX, ODP и т.д.
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).

```c#
// Загрузите любой поддерживаемый файл в Presentation, например, ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```