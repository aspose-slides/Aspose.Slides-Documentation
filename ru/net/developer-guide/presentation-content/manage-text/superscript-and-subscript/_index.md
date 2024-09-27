---
title: Вверхний индекс и нижний индекс
type: docs
weight: 80
url: /ru/net/superscript-and-subscript/
keywords: "Вверхний индекс, Нижний индекс, Добавить текст вверхнего индекса, Добавить текст нижнего индекса, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте текст верхнего и нижнего индексов в презентации PowerPoint на C# или .NET"
---

## **Управление текстом верхнего и нижнего индексов**
Вы можете добавить текст верхнего и нижнего индексов в любой фрагмент абзаца. Для добавления текста верхнего или нижнего индекса в текстовом фрейме Aspose.Slides необходимо использовать **свойство Escapement** класса PortionFormat.

Это свойство возвращает или задает текст верхнего или нижнего индекса (значение от -100% (нижний индекс) до 100% (верхний индекс). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Прямоугольник на слайд.
- Получите доступ к текстовому фрейму, связанному с автофигурой.
- Очистите существующие абзацы.
- Создайте новый объект абзаца для хранения текста верхнего индекса и добавьте его в коллекцию IParagraphs текстового фрейма.
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до 100 для добавления верхнего индекса. (0 означает отсутствие верхнего индекса)
- Установите некоторый текст для порции, а затем добавьте его в коллекцию порций абзаца.
- Создайте новый объект абзаца для хранения текста нижнего индекса и добавьте его в коллекцию IParagraphs текстового фрейма.
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до -100 для добавления нижнего индекса. (0 означает отсутствие нижнего индекса)
- Установите некоторый текст для порции, а затем добавьте его в коллекцию порций абзаца.
- Сохраните презентацию в виде файла PPTX.

Реализация вышеуказанных шагов приведена ниже.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // Получить слайд
    ISlide slide = presentation.Slides[0];

    // Создать текстовое поле
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Создать абзац для текста верхнего индекса
    IParagraph superPar = new Paragraph();

    // Создать порцию с обычным текстом
    IPortion portion1 = new Portion();
    portion1.Text = "SlideTitle";
    superPar.Portions.Add(portion1);

    // Создать порцию с текстом верхнего индекса
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Создать абзац для текста нижнего индекса
    IParagraph paragraph2 = new Paragraph();

    // Создать порцию с обычным текстом
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Создать порцию с текстом нижнего индекса
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Добавить абзацы в текстовое поле
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```