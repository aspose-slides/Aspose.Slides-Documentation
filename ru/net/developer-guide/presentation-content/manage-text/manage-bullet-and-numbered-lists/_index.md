---
title: Управление маркерами и нумерованными списками
type: docs
weight: 70
url: /net/manage-bullet-and-numbered-lists
keywords: "Маркеры, Маркерные списки, Номера, Нумерованные списки, Изображения маркеров, многоуровневые маркеры, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Создание маркерных и нумерованных списков в презентации PowerPoint на C# или .NET"
---

В **Microsoft PowerPoint** вы можете создавать маркерные и нумерованные списки так же, как и в Word и других текстовых редакторах. **Aspose.Slides для .NET** также позволяет использовать маркеры и числа на слайдах ваших презентаций.

### Зачем использовать маркерные списки?

Маркерные списки помогают организовать и представить информацию быстро и эффективно.

**Пример маркерного списка**

В большинстве случаев маркерный список выполняет эти три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко находить ключевые моменты
- эффективно передает и доносит важные детали.

### Зачем использовать нумерованные списки?

Нумерованные списки также помогают в организации и представлении информации. В идеале вы должны использовать номера (вместо маркеров), когда порядок записей (например, *шаг 1, шаг 2* и т.д.) важен или когда запись должна быть упомянута (например, *см. шаг 3*).

**Пример нумерованного списка**

Это резюме шагов (от шага 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (от шага 3 до шага 14).
3. Сохраните презентацию.

## Создание маркеров

Чтобы создать маркерный список, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к слайду (на который вы хотите добавить маркерный список) в коллекции слайдов через объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите параграф по умолчанию в [TextFrame]().
6. Создайте экземпляр первого параграфа с использованием класса [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Установите тип маркера на Символ, а затем установите символ маркера.
9. Установите текст параграфа.
10. Установите отступ параграфа, чтобы задать маркер.
11. Установите цвет маркера.
12. Установите высоту маркера.
13. Добавьте созданный параграф в коллекцию параграфов [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Добавьте второй параграф и повторите шаги 7-12.
15. Сохраните презентацию.

Этот пример кода на C# — это реализация вышеупомянутых шагов, которая показывает, как создать маркерный список на слайде:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Мой текст";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Создание изображений маркеров

Aspose.Slides для .NET позволяет вам изменять маркеры на маркерных списках. Вы можете заменить маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь еще больше внимания к записям в списке, вы можете использовать изображение в качестве маркера.

 {{% alert color="primary" %}} 

В идеале, если вы собираетесь заменить обычный символ маркера на изображение, вам стоит выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего работают в качестве пользовательских символов маркеров.

В любом случае, выбранное вами изображение будет уменьшено до очень маленького размера, поэтому мы настоятельно рекомендуем выбирать изображение, которое хорошо выглядит (в качестве замены символа маркера) в списке. 

{{% /alert %}} 

Чтобы создать изображение маркера, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите параграф по умолчанию в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Создайте экземпляр первого параграфа с использованием класса [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Загрузите изображение с диска и добавьте его в [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images), а затем используйте экземпляр [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), который был возвращен из метода [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Установите тип маркера на Изображение, а затем установите изображение.
9. Установите текст параграфа.
10. Установите отступ параграфа, чтобы задать маркер.
11. Установите цвет маркера.
12. Установите высоту маркеров.
13. Добавьте созданный параграф в коллекцию параграфов [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Добавьте второй параграф и повторите шаги 7-13.
15. Сохраните презентацию.

 Этот код на C# показывает вам, как создать изображение маркера на слайде:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Мой текст";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Создание многоуровневых маркеров

Чтобы создать маркерный список, который содержит элементы на разных уровнях — дополнительные списки под основным маркерным списком — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите параграф по умолчанию в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Создайте экземпляр первого параграфа с использованием класса [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) и установите глубину на 0.
7. Создайте экземпляр второго параграфа с использованием класса Paragraph и установите глубину на 1.
8. Создайте экземпляр третьего параграфа с использованием класса Paragraph и установите глубину на 2.
9. Создайте экземпляр четвертого параграфа с использованием класса Paragraph и установите глубину на 3.
10. Добавьте созданные параграфы в коллекцию параграфов [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Сохраните презентацию.

Этот код, который является реализацией вышеупомянутых шагов, показывает вам, как создать многоуровневый маркерный список на C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "Мой текст Глубина 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "Мой текст Глубина 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "Мой текст Глубина 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "Мой текст Глубина 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Создание чисел

 Этот код на C# показывает вам, как создать нумерованный список на слайде:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "Мой текст 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "Мой текст 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```