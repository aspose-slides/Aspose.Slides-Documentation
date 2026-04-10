---
title: Управление абзацами текста PowerPoint в .NET
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/net/manage-paragraph/
keywords:
- добавить текст
- добавить абзац
- управление текстом
- управление абзацем
- управление маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспорт абзаца
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Мастерское форматирование абзацев с Aspose.Slides для .NET — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на C#."
---
Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и частями PowerPoint на C#.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `ITextFame` может иметь один или несколько абзацев (каждый абзац создаётся через возврат каретки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) , позволяющий добавлять объекты, представляющие части. Объект `IParagraph` может иметь одну или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) , позволяющий добавлять объекты, представляющие текст и его свойства форматирования. 

Объект `IParagraph` может обрабатывать тексты с различными свойствами форматирования через свои вложенные объекты `IPortion`.

## **Добавить несколько абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, а каждый абзац содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) .
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) .
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph` .
7. Установите некоторый текст для каждой части.
8. Примените желаемые свойства форматирования к каждой части, используя свойства форматирования, предоставляемые объектом `IPortion` .
9. Сохраните изменённую презентацию.

This C# code is an implementation of the steps for adding paragraphs containing portions:

```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide slide = pres.Slides[0];

    // Добавляет прямоугольный IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Получает TextFrame автофигуры
    ITextFrame tf = ashp.TextFrame;

    // Создаёт абзацы и части с различными форматами текста
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Сохраняет изменённую презентацию
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Управление маркерами абзацев**
Маркированные списки помогают быстро и эффективно организовать и представить информацию. Параграфы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) автофигуры. 
5. Удалите абзац по умолчанию в `TextFrame` .
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) .
8. Установите для абзаца тип маркера `Type` в `Symbol` и задайте символ маркера.
9. Установите `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame` .
14. Добавьте второй абзац и повторите процесс, описанный в пунктах 7–13.
15. Сохраните презентацию.

This C# code shows you how to add a paragraph bullet:

```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];


    // Добавляет и получает автофигуру
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм автофигуры
    ITextFrame txtFrm = aShp.TextFrame;

    // Удаляет абзац по умолчанию
    txtFrm.Paragraphs.RemoveAt(0);

    // Создаёт абзац
    Paragraph para = new Paragraph();

    // Устанавливает стиль маркера абзаца и символ
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Устанавливает текст абзаца
    para.Text = "Welcome to Aspose.Slides";

    // Устанавливает отступ маркера
    para.ParagraphFormat.Indent = 25;

    // Устанавливает цвет маркера
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // устанавливает IsBulletHardColor в true для использования собственного цвета маркера

    // Устанавливает высоту маркера
    para.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовый фрейм
    txtFrm.Paragraphs.Add(para);

    // Создаёт второй абзац
    Paragraph para2 = new Paragraph();

    // Устанавливает тип и стиль маркера абзаца
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Добавляет текст абзаца
    para2.Text = "This is numbered bullet";

    // Устанавливает отступ маркера
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // устанавливает IsBulletHardColor в true для использования собственного цвета маркера

    // Устанавливает высоту маркера
    para2.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовый фрейм
    txtFrm.Paragraphs.Add(para2);


    // Сохраняет изменённую презентацию
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Управление картинными маркерами**
Маркированные списки помогают быстро и эффективно организовать и представить информацию. Параграфы с картинными маркерами легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame` .
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) .
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) .
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) и задайте изображение.
9. Установите `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame` .
14. Добавьте второй абзац и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

This C# code shows you how to add and manage picture bullets:

```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation();

// Получает первый слайд
ISlide slide = presentation.Slides[0];

// Создаёт изображение для маркеров
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Добавляет и получает автофигуру
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Получает текстовый фрейм автофигуры
ITextFrame textFrame = autoShape.TextFrame;

// Удаляет абзац по умолчанию
textFrame.Paragraphs.RemoveAt(0);

// Создаёт новый абзац
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Устанавливает стиль маркера абзаца и изображение
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Устанавливает высоту маркера
paragraph.ParagraphFormat.Bullet.Height = 100;

// Добавляет абзац в текстовый фрейм
textFrame.Paragraphs.Add(paragraph);

// Сохраняет презентацию как файл PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Сохраняет презентацию как файл PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Управление многоуровневыми маркерами**
Маркированные списки помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame` .
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame` .
11. Сохраните изменённую презентацию.

This C# code shows you how to add and manage multilevel bullets:

```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];
    
    // Добавляет и получает автофигуру
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм созданной автофигуры
    ITextFrame text = aShp.AddTextFrame("");
    
    // Очищает абзац по умолчанию
    text.Paragraphs.Clear();

    // Добавляет первый абзац
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Задаёт уровень маркера
    para1.ParagraphFormat.Depth = 0;

    // Добавляет второй абзац
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Задаёт уровень маркера
    para2.ParagraphFormat.Depth = 1;

    // Добавляет третий абзац
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Задаёт уровень маркера
    para3.ParagraphFormat.Depth = 2;

    // Добавляет четвёртый абзац
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Задаёт уровень маркера
    para4.ParagraphFormat.Depth = 3;

    // Добавляет абзацы в коллекцию
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Сохраняет презентацию как файл PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Управление абзацем с пользовательским нумерованным списком**
Интерфейс [IBulletFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class .
2. Получите слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame` .
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) и задайте [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/net/aspose.slides/ibulletformat/numberedbulletstartwith) значение 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` значение 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` значение 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame` .
10. Сохраните изменённую презентацию.

This C# code shows you how to add and manage paragraphs with custom numbering or formatting:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Получает текстовый фрейм созданной автофигуры
	ITextFrame textFrame = shape.TextFrame;

	// Удаляет существующий абзац по умолчанию
	textFrame.Paragraphs.RemoveAt(0);

	// Первый список
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Установить отступ первой строки для абзаца**

Используйте свойство [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) для управления отступом первой строки абзаца. Это свойство смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, а остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) , когда нужно переместить весь абзац. Используйте [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , когда нужно переместить только первую строку.

В примере ниже создаются несколько абзацев и применяются разные значения `Indent`, чтобы продемонстрировать, как отступ первой строки влияет на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) .
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

This code shows you how to set a paragraph indent:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

## **Установить висячий отступ для абзаца**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью свойства [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) . Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) определяет левую позицию тела абзаца, а [IParagraphFormat.Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent` .

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где переносимые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/marginleft/) .
6. Установите отрицательное значение [Indent](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/indent/) , чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

This code shows you how to set a hanging indent for a paragraph:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

## **Управление свойствами End абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) класса.
1. Получите ссылку на слайд, содержащий абзац, по его позиции.
1. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Задайте свойства End для абзацев.
1. Сохраните изменённую презентацию как файл PPTX.

This C# code shows you how to set the End properties for paragraphs in PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Импорт HTML-текста в абзацы**
Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите `autoshape` [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) .
5. Удалите абзац по умолчанию в `ITextFrame` .
6. Прочитайте исходный HTML‑файл с помощью `TextReader` .
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/) .
8. Добавьте содержимое HTML‑файла из прочитанного `TextReader` в [ParagraphCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphcollection/) текстового фрейма.
9. Сохраните изменённую презентацию.

This C# code is an implementation of the steps for importing HTML texts in paragraphs:

```c#
// Создаёт пустой экземпляр презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд презентации по умолчанию
    ISlide slide = pres.Slides[0];

    // Добавляет AutoShape для размещения HTML‑содержимого
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Добавляет текстовый фрейм к фигуре
    ashape.AddTextFrame("");

    // Очищает все абзацы в добавленном текстовом фрейме
    ashape.TextFrame.Paragraphs.Clear();

    // Загружает HTML‑файл с помощью StreamReader
    TextReader tr = new StreamReader("file.html");

    // Добавляет текст из HTML‑потока в текстовый фрейм
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Сохраняет презентацию
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Экспорт текста абзаца в HTML**
Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите фигуру, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для `StreamWriter` и экспортируйте выбранные абзацы.

This C# code shows you how to export PowerPoint paragraph texts to HTML:

```c#
// Загружает файл презентации
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Получает первый слайд презентации по умолчанию
    ISlide slide = pres.Slides[0];

    // Получает требуемый индекс
    int index = 0;

    // Получает добавленную фигуру
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Записывает данные абзацев в HTML, указывая начальный индекс абзаца и количество копируемых абзацев
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Сохранить абзац как изображение**

В этом разделе рассматриваются два примера, демонстрирующие, как сохранить текстовый абзац, представляемый интерфейсом [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) , в виде изображения. Оба примера включают получение изображения фигуры, содержащей абзац, с помощью методов `GetImage` интерфейса [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/) , вычисление границ абзаца внутри фигуры и экспорт его как растрового изображения. Эти подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовый блок, содержащий три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение фигуры с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме фигуры. Затем абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда необходимо сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Фигура извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это обеспечивает более высокое разрешение при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование может быть особенно полезно, когда требуется более детализированное изображение, например, для использования в печатных материалах высокого качества.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста фрейма ([WrapText](https://reference.aspose.com/slides/ru/net/aspose.slides/textframeformat/wraptext/)) , чтобы отключить перенос — строки не будут разбиваться у краёв фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить ограничивающий прямоугольник абзаца (и даже отдельной части), чтобы знать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (по левому/правому краю, по центру, по ширине)?**

[Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphformat/alignment/) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraphformat/) ; она применяется ко всему абзацу независимо от индивидуального форматирования частей.

**Можно ли задать язык проверки правописания только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне части ([PortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/languageid/)), поэтому в одном абзаце могут сосуществовать несколько языков.