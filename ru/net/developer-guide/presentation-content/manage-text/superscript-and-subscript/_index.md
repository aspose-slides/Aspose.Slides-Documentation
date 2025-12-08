---
title: Управление верхним и нижним индексом в C#
linktitle: Верхний и нижний индекс
type: docs
weight: 80
url: /ru/net/superscript-and-subscript/
keywords:
- верхний индекс
- нижний индекс
- добавить верхний индекс
- добавить нижний индекс
- PowerPoint
- OpenDocument
- презентация
- C#
- Csharp
- Aspose.Slides
description: "Освойте верхний и нижний индекс в Aspose.Slides для .NET и улучшите свои презентации с помощью профессионального форматирования текста для максимального воздействия."
---

## **Обзор**

Aspose.Slides for .NET предоставляет возможности интеграции верхнего и нижнего индекса текста в ваши презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP). Если вам нужно выделить химические формулы, математические уравнения или добавить сноски, эти специализированные параметры форматирования помогают сохранить ясность и точность. В этой статье вы узнаете, как бесшовно применять стили верхнего и нижнего индекса и обеспечить профессиональный результат на каждом слайде.

## **Добавить верхний и нижний индекс**

Вы можете добавить текст в верхнем или нижнем индексе внутри любого абзаца презентации. Для этого в Aspose.Slides необходимо использовать свойство `Escapement` класса [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

Это свойство позволяет задать верхний или нижний индекс, значения варьируются от -100 % (нижний индекс) до 100 % (верхний индекс).

Шаги реализации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) типа `Rectangle`.
1. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) , связанному с [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Очистите существующие абзацы.
1. Создайте новый объект [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) для текста в верхнем индексе и добавьте его в коллекцию абзацев [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
1. Создайте новый объект текстовой части.
1. Установите свойство `Escapement` для текстовой части в диапазоне от 0 до 100, чтобы применить верхний индекс (0 — нет верхнего индекса).
1. Задайте некоторый текст для [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
1. Создайте еще один объект [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) для текста в нижнем индексе и добавьте его в коллекцию абзацев.
1. Создайте новый объект текстовой части.
1. Установите свойство `Escapement` для текстовой части в диапазоне от 0 до -100, чтобы применить нижний индекс (0 — нет нижнего индекса).
1. Задайте некоторый текст для [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
1. Сохраните презентацию в файл PPTX.

Следующий код C# реализует эти шаги:
```c#
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Создать текстовое поле.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Создать абзац для текста в верхнем индексе.
    IParagraph superPar = new Paragraph();

    // Создать часть текста с обычным текстом.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Создать часть текста с верхним индексом.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Создать абзац для текста в нижнем индексе.
    IParagraph paragraph2 = new Paragraph();

    // Создать часть текста с обычным текстом.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Создать часть текста с нижним индексом.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Добавить абзацы в текстовое поле.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Результат:

![Верхний и нижний индекс](superscript_and_subscript.png)

## **Вопросы и ответы**

**Сохранятся ли верхний и нижний индексы при экспорте в PDF или другие форматы?**

Да, Aspose.Slides for .NET корректно сохраняет форматирование верхнего и нижнего индекса при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Можно ли комбинировать верхний и нижний индексы с другими стилями форматирования, такими как полужирный или курсив?**

Да, Aspose.Slides позволяет смешивать различные стили текста внутри одной части текста. Вы можете включать полужирный, курсив, подчёркивание и одновременно применять верхний или нижний индекс, задав соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

**Работает ли форматирование верхнего и нижнего индекса для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides for .NET поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) аналогичным образом.