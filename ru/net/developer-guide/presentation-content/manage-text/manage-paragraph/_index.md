---
title: Управление абзацами PowerPoint в C#
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: "Добавить абзац PowerPoint, Управлять абзацами, Отступ абзаца, Свойства абзаца, HTML текст, Экспорт текста абзаца, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Создавать и управлять абзацем, текстом, отступами и свойствами в презентациях PowerPoint на C# или .NET"
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и частями PowerPoint на C#.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), который позволяет добавлять объекты, представляющие абзацы. Объект `ITextFrame` может содержать один или несколько абзацев (каждый абзац создается через возврат каретки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/), который позволяет добавлять объекты, представляющие части. Объект `IParagraph` может содержать один или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/), который позволяет добавлять объекты, представляющие тексты и их свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с разными свойствами форматирования через свои базовые объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте прямоугольник [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion каждого `IParagraph`.
7. Установите некоторый текст для каждой части.
8. Примените ваши предпочитаемые функции форматирования к каждой части, используя свойства форматирования, предоставленные объектом `IPortion`.
9. Сохраните измененную презентацию.

Этот код на C# реализует шаги по добавлению абзацев, содержащих части:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide slide = pres.Slides[0];

    // Добавляет прямоугольник IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Получает текстовый фрейм AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Создает абзацы и части с разными форматами текста
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
    // Сохраняет измененную презентацию
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Управление маркерами абзацев**
Списки с маркерами помогают организовать и представить информацию быстро и эффективно. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) автофигуры. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с использованием класса [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Установите `Type` маркера для абзаца на `Symbol` и задайте символ маркера.
9. Установите текст абзаца.
10. Установите отступ `Indent` для маркера.
11. Установите цвет для маркера.
12. Установите высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, описанный в шагах 7–13.
15. Сохраните презентацию.

Этот код на C# показывает, как добавить маркер абзаца:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];


    // Добавляет и получает автофигуру
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовой фрейм автофигуры
    ITextFrame txtFrm = aShp.TextFrame;

    // Удаляет абзац по умолчанию
    txtFrm.Paragraphs.RemoveAt(0);

    // Создает абзац
    Paragraph para = new Paragraph();

    // Устанавливает стиль и символ маркера абзаца
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Устанавливает текст абзаца
    para.Text = "Добро пожаловать в Aspose.Slides";

    // Устанавливает отступ маркера
    para.ParagraphFormat.Indent = 25;

    // Устанавливает цвет маркера
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // устанавливает IsBulletHardColor в true, чтобы использовать свой цвет маркера

    // Устанавливает высоту маркера
    para.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовой фрейм
    txtFrm.Paragraphs.Add(para);

    // Создает второй абзац
    Paragraph para2 = new Paragraph();

    // Устанавливает тип и стиль маркера абзаца
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Добавляет текст абзаца
    para2.Text = "Это нумерованный маркер";

    // Устанавливает отступ маркера
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // устанавливает IsBulletHardColor в true, чтобы использовать свой цвет маркера

    // Устанавливает высоту маркера
    para2.ParagraphFormat.Bullet.Height = 100;

    // Добавляет абзац в текстовой фрейм
    txtFrm.Paragraphs.Add(para2);


    // Сохраняет измененную презентацию
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Управление графическими маркерами**
Списки с маркерами помогают организовать и представить информацию быстро и эффективно. Графические абзацы легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с использованием класса [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Установите тип маркера на [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) и установите изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для маркера.
11. Установите цвет для маркера.
12. Установите высоту для маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните измененную презентацию.

Этот код на C# показывает, как добавить и управлять графическими маркерами:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation();

// Получает первый слайд
ISlide slide = presentation.Slides[0];

// Создает изображение для маркеров
Image image = new Bitmap("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);

// Добавляет и получает автозаглавную фигуру
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Получает текстовой фрейм автофигуры
ITextFrame textFrame = autoShape.TextFrame;

// Удаляет абзац по умолчанию
textFrame.Paragraphs.RemoveAt(0);

// Создает новый абзац
Paragraph paragraph = new Paragraph();
paragraph.Text = "Добро пожаловать в Aspose.Slides";

// Устанавливает стиль и изображение маркера абзаца
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Устанавливает высоту маркера
paragraph.ParagraphFormat.Bullet.Height = 100;

// Добавляет абзац в текстовой фрейм
textFrame.Paragraphs.Add(paragraph);

// Сохраняет презентацию как файл PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Сохраняет презентацию как файл PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Управление многоуровневыми маркерами**
Списки с маркерами помогают организовать и представить информацию быстро и эффективно. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) и установите уровень на 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите уровень на 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите уровень на 2.
9. Создайте четвертый экземпляр абзаца через класс `Paragraph` и установите уровень на 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните измененную презентацию.

Этот код на C# показывает, как добавить и управлять многоуровневыми маркерами:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide slide = pres.Slides[0];
    
    // Добавляет и получает автофигуру
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовой фрейм созданной автофигуры
    ITextFrame text = aShp.AddTextFrame("");
    
    // Очищает абзац по умолчанию
    text.Paragraphs.Clear();

    // Добавляет первый абзац
    IParagraph para1 = new Paragraph();
    para1.Text = "Содержимое";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para1.ParagraphFormat.Depth = 0;

    // Добавляет второй абзац
    IParagraph para2 = new Paragraph();
    para2.Text = "Второй уровень";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para2.ParagraphFormat.Depth = 1;

    // Добавляет третий абзац
    IParagraph para3 = new Paragraph();
    para3.Text = "Третий уровень";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Устанавливает уровень маркера
    para3.ParagraphFormat.Depth = 2;

    // Добавляет четвертый абзац
    IParagraph para4 = new Paragraph();
    para4.Text = "Четвертый уровень";
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

    // Сохраняет презентацию как файл PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Управление абзацем с пользовательским нумерованным списком**
Интерфейс [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) и другие, которые позволяют управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) на 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните измененную презентацию.

Этот код на C# показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Получает текстовой фрейм созданной автофигуры
	ITextFrame textFrame = shape.TextFrame;

	// Удаляет существующий абзац по умолчанию
	textFrame.Paragraphs.RemoveAt(0);

	// Первый список
	var paragraph1 = new Paragraph { Text = "маркер 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "маркер 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "маркер 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Установить отступ абзаца**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на соответствующий слайд через его индекс.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) с тремя абзацами в прямоугольную автофигуру.
1. Скрывайте линии прямоугольника.
1. Установите отступ для каждого [абзаца](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) через их свойство BulletOffset.
1. Запишите измененную презентацию как файл PPT.

Этот код на C# показывает, как установить отступ абзаца:

```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Добавляет прямоугольную фигуру
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Добавляет текстовый фрейм в прямоугольник
ITextFrame tf = rect.AddTextFrame("Это первая строка \rЭто вторая строка \rЭто третья строка");

// Устанавливает текст в соответствии с формой
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Скрывает линии прямоугольника
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Получает первый абзац в текстовом фрейме и устанавливает его отступ
IParagraph para1 = tf.Paragraphs[0];

// Устанавливает стиль и символ маркера абзаца
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Получает второй абзац в текстовом фрейме и устанавливает его отступ
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Получает третий абзац в текстовом фрейме и устанавливает его отступ
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Записывает презентацию на диск
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **Установить висячий отступ для абзаца**

Этот код на C# показывает, как установить висячий отступ для абзаца:  

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Пример"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Установить висячий отступ для абзаца"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "Этот код на C# показывает, как установить висячий отступ для абзаца: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Управление свойствами конца абзаца для абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Получите ссылку на слайд, содержащий абзац, через его позицию.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите конечные свойства для абзацев.
1. Запишите измененную презентацию как файл PPTX.

Этот код на C# показывает, как установить конечные свойства для абзацев в PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Текст примера"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Текст примера 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Импорт HTML текста в абзацы**
Aspose.Slides предоставляет улучшенную поддержку импорта HTML текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите `автофигуру` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML файл в TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Добавьте содержимое HTML файла, прочитанное в TextReader, в коллекцию [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) текстового фрейма.
9. Сохраните измененную презентацию.

Этот код на C# реализует шаги по импорту HTML текстов в абзацы:

```c#
// Создает пустой экземпляр презентации
using (Presentation pres = new Presentation())
{
    // Доступ к первому слайду в презентации
    ISlide slide = pres.Slides[0];

    // Добавляет автофигуру для размещения HTML содержимого
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Добавляет текстовый фрейм к фигуре
    ashape.AddTextFrame("");

    // Очищает все абзацы в добавленном текстовом фрейме
    ashape.TextFrame.Paragraphs.Clear();

    // Загружает HTML файл с помощью потокового ридера
    TextReader tr = new StreamReader("file.html");

    // Добавляет текст из HTML потокового ридера в текстовой фрейм
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Сохраняет презентацию
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Экспорт текста абзацев в HTML**
Aspose.Slides предоставляет улучшенную поддержку для экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Доступ к фигуре, содержащей текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте ваши предпочтительные абзацы.

Этот код на C# показывает, как экспортировать текст абзацев PowerPoint в HTML:

```c#
// Загружает файл презентации
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Доступ к первому слайду в презентации
    ISlide slide = pres.Slides[0];

    // Получает соответствующий индекс
    int index = 0;

    // Получает добавленную фигуру
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Записывает данные абзацев в HTML, указывая начальный индекс абзаца и количество абзацев, которые нужно скопировать
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```