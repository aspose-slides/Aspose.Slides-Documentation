---
title: У��авление надстрочным и подстрочным текстом в презентациях на .NET
linktitle: Надстрочный и подстрочный
type: docs
weight: 80
url: /ru/net/superscript-and-subscript/
keywords:
- надстрочный
- подстрочный
- добавить надстрочный
- добавить подстрочный
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Освойте надстрочный и подстрочный текст в Aspose.Slides для .NET и улучшите свои презентации с помощью профессионального форматирования текста для максимального воздействия."
---

## **Обзор**

Aspose.Slides for .NET предоставляет функции для интеграции текста в верхнем и нижнем индексе в ваши презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP). Независимо от того, нужно ли вам выделять химические формулы, математические уравнения или добавлять сноски, эти специализированные параметры форматирования помогают сохранять ясность и точность. В этой статье вы узнаете, как без усилий применять стили верхнего и нижнего индекса и обеспечивать профессиональный результат на каждом слайде.

## **Добавление верхнего и нижнего индекса**

Вы можете добавить текст в верхнем и нижнем индексе внутри любого абзаца в презентации. Чтобы достичь этого с помощью Aspose.Slides, необходимо использовать свойство `Escapement` класса [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

Это свойство позволяет задавать текст в верхнем или нижнем индексе, значения варьируются от -100% (нижний индекс) до 100% (верхний индекс).

Implementation steps:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте к слайду объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) типа `Rectangle`.
1. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), связанному с [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Очистите существующие абзацы.
1. Создайте новый [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) для текста в верхнем индексе и добавьте его в коллекцию абзацев [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
1. Создайте новый объект текстовой части.
1. Установите свойство `Escapement` для текстовой части в диапазоне от 0 до 100, чтобы применить верхний индекс (0 означает отсутствие верхнего индекса).
1. Задайте текст для [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
1. Создайте еще один [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) для текста в нижнем индексе и добавьте его в коллекцию абзацев.
1. Создайте новый объект текстовой части.
1. Установите свойство `Escapement` для текстовой части в диапазоне от 0 до -100, чтобы применить нижний индекс (0 означает отсутствие нижнего индекса).
1. Задайте текст для [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
1. Сохраните презентацию в файл PPTX.

The following C# code implements these steps:
```c#
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Создать текстовое поле.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Создать абзац для надстрочного текста.
    IParagraph superPar = new Paragraph();

    // Создать часть текста с обычным текстом.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Создать часть текста с надстрочным текстом.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Создать абзац для нижнего индекса.
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

## **Часто задаваемые вопросы**

**Будут ли верхний и нижний индекс сохранены при экспорте в PDF или другие форматы?**

Да, Aspose.Slides for .NET корректно сохраняет форматирование верхнего и нижнего индекса при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специализированное форматирование остается неизменным во всех выходных файлах.

**Можно ли комбинировать верхний и нижний индекс с другими стилями форматирования, например жирным или курсивом?**

Да, Aspose.Slides позволяет смешивать различные стили текста внутри одной части текста. Вы можете включить жирный, курсив, подчёркивание и одновременно применить верхний или нижний индекс, настроив соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

**Работает ли форматирование верхнего и нижнего индекса для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides for .NET поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) аналогичным образом.