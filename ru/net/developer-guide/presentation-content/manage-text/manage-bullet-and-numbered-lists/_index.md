---
title: Управление маркированными и нумерованными списками в презентациях на .NET
linktitle: Управление списками
type: docs
weight: 70
url: /ru/net/manage-bullet-and-numbered-lists
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- маркер‑изображение
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для .NET. Пошаговое руководство."
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как делаете это в Word и других текстовых редакторах. **Aspose.Slides for .NET** также позволяет использовать маркеры и цифры в слайдах ваших презентаций. 

## **Зачем использовать маркированные списки?**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. 

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основные функции:

- привлекает внимание читателей или зрителей к важной информации
- позволяет читателям или зрителям быстро просматривать ключевые пункты
- эффективно передаёт и доставляет важные детали.

## **Зачем использовать нумерованные списки?**

Нумерованные списки также помогают в организации и представлении информации. В идеале следует использовать цифры (вместо маркеров), когда порядок элементов (например, *шаг 1, шаг 2* и т.д.) важен или когда на элемент нужно ссылаться (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (от шага 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса Presentation. 
2. Выполните несколько задач (от шага 3 до шага 14).
3. Сохраните презентацию. 

## **Создание маркеров**

Для создания маркированного списка выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите слайд (в который нужно добавить маркированный список) из коллекции слайдов через объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame]().
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Установите тип маркера как Symbol, а затем задайте символ маркера.
9. Установите текст абзаца.
10. Установите отступ абзаца для задания маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Добавьте второй абзац и повторите шаги 7‑12.
15. Сохраните презентацию.

Этот пример кода на C# — реализация вышеописанных шагов — показывает, как создать маркированный список на слайде:
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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Создание маркеров‑изображений**

Aspose.Slides for .NET позволяет менять маркеры в маркированных списках. Вы можете заменять маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь ещё больше внимания к элементам списка, вы можете использовать собственное изображение в качестве маркера. 

{{% alert color="primary" %}} 
В идеале, если вы планируете заменить обычный символ маркера картинкой, стоит выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров. 

В любом случае выбранное изображение будет уменьшено до очень маленького размера, поэтому мы настоятельно рекомендуем выбрать изображение, которое хорошо выглядит (в качестве замены символа маркера) в списке. 
{{% /alert %}} 

Для создания маркера‑изображения выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов через объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Загрузите изображение с диска и добавьте его в [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images), затем используйте экземпляр [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), возвращённый методом [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Установите тип маркера как Picture, а затем задайте изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для задания маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркеров.
13. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Добавьте второй абзац и повторите шаги 7‑13.
15. Сохраните презентацию.

Этот код на C# показывает, как создать маркер‑изображение на слайде:
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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Создание многоуровневых маркеров**

Чтобы создать маркированный список, содержащий элементы разных уровней — дополнительные списки под главным списком — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов через объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Создайте первый экземпляр абзаца, используя класс [Paragraph] и задав глубину 0.
7. Создайте второй экземпляр абзаца, используя класс Paragraph и задав глубину 1.
8. Создайте третий экземпляр абзаца, используя класс Paragraph и задав глубину 2.
9. Создайте четвёртый экземпляр абзаца, используя класс Paragraph и задав глубину 3.
10. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Сохраните презентацию.

Этот код, реализующий вышеописанные шаги, показывает, как создать многоуровневый маркированный список на C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Создание нумерации**

Этот код на C# показывает, как создать нумерованный список на слайде:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки, созданные с помощью Aspose.Slides, в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркированных и нумерованных списков при экспорте презентаций в такие форматы, как PDF, изображения и другие, обеспечивая согласованные результаты.

**Можно ли импортировать маркированные или нумерованные списки из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать маркированные или нумерованные списки из существующих презентаций, сохраняя их оригинальное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркированные и нумерованные списки в презентациях, созданных на разных языках?**

Да, Aspose.Slides полностью поддерживает многоязычные презентации, позволяя создавать маркированные и нумерованные списки на любом языке, включая использование специальных или нелатинских символов.