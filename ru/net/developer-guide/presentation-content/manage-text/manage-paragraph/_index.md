---
title: У管理 PowerPoint 文本 段落 .NET
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
description: "Освойте форматирование абзацев с Aspose.Slides для .NET — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на C#."
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и фрагментами PowerPoint в C#.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создаётся посредством возврата каретки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) , позволяющий добавлять объекты, представляющие фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекцию объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) , позволяющий добавлять объекты, представляющие тексты и их свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с различными свойствами форматирования через свои вложенные объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый кадр, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Задайте текст для каждого фрагмента.
8. Примените желаемые параметры форматирования к каждому фрагменту, используя свойства форматирования, предоставляемые объектом `IPortion`.
9. Сохраните изменённую презентацию.

```c#
// Создаёт объект класса Presentation, представляющий файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide slide = pres.Slides[0];

    // Добавляет прямоугольный IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Получает TextFrame AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Создаёт абзацы и фрагменты с разными форматами текста
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
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Сохраняет изменённую презентацию
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **Управление маркерами абзацев**

Маркированные списки помогают быстро и эффективно упорядочивать и представлять информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) автошейпа.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Установите для абзаца тип маркера `Type` в значение `Symbol` и задайте символ маркера.
9. Задайте абзацу `Text`.
10. Задайте абзацу `Indent` для маркера.
11. Установите цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, указанный в шагах 7–13.
15. Сохраните презентацию.

```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];


    // Добавляет и получает автошейп
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый кадр автошейпа
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
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовый кадр
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
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para2.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовый кадр
    txtFrm.Paragraphs.Add(para2);


    // Сохраняет изменённую презентацию
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Управление рисунками‑маркерами**

Маркированные списки помогают быстро и эффективно упорядочивать и представлять информацию. Абзацы с рисунками‑маркерами легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автошейпа.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Загрузите изображение в объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Установите тип маркера в значение [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) и задайте изображение.
9. Задайте абзацу `Text`.
10. Задайте абзацу `Indent` для маркера.
11. Установите цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните изменённую презентацию.

```c#
// Создаёт объект класса Presentation, представляющий файл PPTX
Presentation presentation = new Presentation();

// Получает первый слайд
ISlide slide = presentation.Slides[0];

// Создаёт изображение для маркеров
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Добавляет и получает автошейп
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Получает текстовый кадр автошейпа
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

// Добавляет абзац в текстовый кадр
textFrame.Paragraphs.Add(paragraph);

// Сохраняет презентацию в файл PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Сохраняет презентацию в файл PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно упорядочивать и представлять информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автошейпа.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй абзац через класс `Paragraph` и задайте глубину 1.
8. Создайте третий абзац через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый абзац через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

```c#
// Создаёт объект класса Presentation, представляющий файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];
    
    // Добавляет и получает автошейп
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый кадр созданного автошейпа
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
    // Устанавливает уровень маркера
    para1.ParagraphFormat.Depth = 0;

    // Добавляет второй абзац
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para2.ParagraphFormat.Depth = 1;

    // Добавляет третий абзац
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para3.ParagraphFormat.Depth = 2;

    // Добавляет четвёртый абзац
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para4.ParagraphFormat.Depth = 3;

    // Добавляет абзацы в коллекцию
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Сохраняет презентацию в файл PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Управление абзацем с пользовательским нумерованным списком**

Aspose.Slides предоставляет интерфейс [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) с свойством [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) и другими, позволяющими управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите слайд, содержащий абзац.
3. Добавьте [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автошейпа.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) и задайте свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) со значением 2.
7. Создайте второй абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` со значением 3.
8. Создайте третий абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` со значением 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Получает текстовый кадр созданного автошейпа
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


## **Установка отступа абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) класса.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) с тремя абзацами к прямоугольному автошейпу.
5. Спрячьте линии прямоугольника.
6. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) через свойство BulletOffset.
7. Запишите изменённую презентацию в файл PPT.

```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Добавляет прямоугольную фигуру
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Добавляет TextFrame к прямоугольнику
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// Устанавливает подгонку текста к форме
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Скрывает линии прямоугольника
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Получает первый абзац в TextFrame и задает его отступ
IParagraph para1 = tf.Paragraphs[0];

// Устанавливает стиль маркера абзаца и символ
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Получает второй абзац в TextFrame и задает его отступ
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Получает третий абзац в TextFrame и задает его отступ
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Сохраняет презентацию на диск
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **Установка висячего отступа для абзаца**

Этот код C# показывает, как установить висячий отступ для абзаца:  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Управление конечными свойствами Run абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) класса.
2. Получите ссылку на слайд, содержащий абзац, через его позицию.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) с двумя абзацами к Прямоугольнику.
5. Установите `FontHeight` и тип шрифта для абзацев.
6. Установите конечные свойства (End) для абзацев.
7. Запишите изменённую презентацию в файл PPTX.

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


## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, прочитанного TextReader, в [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

```c#
// Создаёт пустой экземпляр презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд презентации по умолчанию
    ISlide slide = pres.Slides[0];

    // Добавляет AutoShape для размещения HTML‑контента
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Добавляет текстовый кадр к фигуре
    ashape.AddTextFrame("");

    // Очищает все абзацы в добавленном текстовом кадре
    ashape.TextFrame.Paragraphs.Clear();

    // Загружает HTML‑файл с помощью StreamReader
    TextReader tr = new StreamReader("file.html");

    // Добавляет текст из HTML‑потока в текстовый кадр
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Сохраняет презентацию
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для `StreamWriter` и экспортируйте выбранные абзацы.

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


## **Сохранение абзаца как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующих, как сохранить текстовый абзац, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `GetImage` интерфейса [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац как изображение. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом кадре формы. Затем абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.
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

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить более высокое разрешение при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование может быть особенно полезно, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.
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

**Можно ли полностью отключить перенос строк внутри текстового кадра?**

Да. Используйте параметр переноса текста кадра ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)), чтобы отключить перенос, и строки не будут разрываться у краёв кадра.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить ограничивающий прямоугольник абзаца (и даже отдельного фрагмента), чтобы знать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (left/right/center/justify)?**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) — это параметр уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); он применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии только для части абзаца (например, для одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)), поэтому в одном абзаце могут сосуществовать несколько языков.